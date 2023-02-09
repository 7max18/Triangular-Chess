using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    public Grid grid;
    public Tilemap board;
    public Tilemap moveTiles;
    public Tile moveable;
    [HideInInspector]
    public List<Vector3Int> moves;
    public GameObject selectedPiece;
    public bool isWhiteTurn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if(moveTiles.GetTile(moveTiles.WorldToCell(hit.point)) != null)
            {
                selectedPiece.transform.position = moveTiles.CellToWorld(moveTiles.WorldToCell(hit.point)) + new Vector3(0, 0, selectedPiece.transform.position.z - board.transform.position.z);
                ClearMoves();
                isWhiteTurn = !isWhiteTurn;
            }
        }
    }

    public void HighlightMoves()
    {
        foreach (Vector3Int move in moves)
        {
            Vector3 pos = board.CellToWorld(move);
            if (board.HasTile(move))
            {
                RaycastHit2D hit = Physics2D.CircleCast(new Vector2(pos.x, pos.y), 0.35f, Vector2.zero, Mathf.Infinity, Physics2D.DefaultRaycastLayers, -1.5f, -0.5f);
                if (hit.collider == null || hit.transform.gameObject.GetComponent<Piece>().isWhite != selectedPiece.GetComponent<Piece>().isWhite)
                {
                    moveTiles.SetTile(move, moveable);
                }
            }
        }
    }

    public void ClearMoves()
    {
        foreach (Vector3Int move in moves)
        {
            moveTiles.SetTile(move, null);
        }
        moves.Clear();
    }
}
