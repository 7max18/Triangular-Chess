using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class King : Piece
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override List<Vector3Int> GetMoves(Vector3Int cubeLoc, bool upParity)
    {
        List<Vector3Int> moves = new List<Vector3Int>();

        if (upParity)
        {
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x - 1, cubeLoc.y + 1, cubeLoc.z)));
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x + 1, cubeLoc.y, cubeLoc.z - 1)));
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x, cubeLoc.y - 1, cubeLoc.z + 1)));
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x, cubeLoc.y + 2, cubeLoc.z - 2)));
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x - 2, cubeLoc.y, cubeLoc.z + 2)));
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x + 2, cubeLoc.y - 2, cubeLoc.z)));
        }
        else
        {
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x + 1, cubeLoc.y - 1, cubeLoc.z)));
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x - 1, cubeLoc.y, cubeLoc.z + 1)));
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x, cubeLoc.y + 1, cubeLoc.z - 1)));
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x, cubeLoc.y - 2, cubeLoc.z + 2)));
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x + 2, cubeLoc.y, cubeLoc.z - 2)));
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x - 2, cubeLoc.y + 2, cubeLoc.z)));
        }

        return moves;
    }
}
