using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unicorn : Piece
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
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x + 2, cubeLoc.y + 1, cubeLoc.z - 3)));
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x + 3, cubeLoc.y - 1, cubeLoc.z - 2)));
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x + 1, cubeLoc.y - 3, cubeLoc.z + 2)));
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x - 1, cubeLoc.y - 2, cubeLoc.z + 3)));
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x - 3, cubeLoc.y + 2, cubeLoc.z + 1)));
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x - 2, cubeLoc.y + 3, cubeLoc.z - 1)));
        }
        else
        {
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x - 2, cubeLoc.y - 1, cubeLoc.z + 3)));
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x - 3, cubeLoc.y + 1, cubeLoc.z + 2)));
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x - 1, cubeLoc.y + 3, cubeLoc.z - 2)));
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x + 1, cubeLoc.y + 2, cubeLoc.z - 3)));
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x + 3, cubeLoc.y - 2, cubeLoc.z - 1)));
            moves.Add(CubeToUnityCell(new Vector3Int(cubeLoc.x + 2, cubeLoc.y - 3, cubeLoc.z + 1)));
        }

        return moves;
    }
}
