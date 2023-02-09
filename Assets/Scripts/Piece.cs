using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Piece : MonoBehaviour
{  
    [SerializeField]
    public bool isWhite;
    [SerializeField]
    protected BoardManager boardManager;
    [HideInInspector]
    protected Collider2D col;
    
    protected virtual void Start()
    {
        col = gameObject.GetComponent<Collider2D>();
        boardManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<BoardManager>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider == col && boardManager.isWhiteTurn == isWhite)
            {
                boardManager.ClearMoves();
                boardManager.selectedPiece = gameObject;
                Vector3Int cubeLoc = UnityCellToCube(boardManager.grid.WorldToCell(transform.position));
                //Check if current triangle points up or down
                if (boardManager.board.HasTile(CubeToUnityCell(new Vector3Int(cubeLoc.x - 1, cubeLoc.y + 1, cubeLoc.z))) ||
                    boardManager.board.HasTile(CubeToUnityCell(new Vector3Int(cubeLoc.x + 1, cubeLoc.y, cubeLoc.z - 1))) ||
                    boardManager.board.HasTile(CubeToUnityCell(new Vector3Int(cubeLoc.x, cubeLoc.y - 1, cubeLoc.z + 1))))
                {
                    boardManager.moves = GetMoves(cubeLoc, true);
                }
                else
                {
                    boardManager.moves = GetMoves(cubeLoc, false);
                }
                    
                boardManager.HighlightMoves();
            }
        }
    }

    //Adapted from https://github.com/Unity-Technologies/2d-extras/issues/69
    //x=s, y=r, z=q
    protected Vector3Int UnityCellToCube(Vector3Int cell)
    {
        var yCell = cell.x;
        var xCell = cell.y;
        var x = yCell - (xCell - (xCell & 1)) / 2;
        var z = xCell;
        var y = -x - z;
        return new Vector3Int(x, y, z);
    }
    protected Vector3Int CubeToUnityCell(Vector3Int cube)
    {
        var x = cube.x;
        var z = cube.z;
        var col = x + (z - (z & 1)) / 2;
        var row = z;

        return new Vector3Int(col, row, 0);
    }
    protected abstract List<Vector3Int> GetMoves(Vector3Int cubeLoc, bool upParity);
}
