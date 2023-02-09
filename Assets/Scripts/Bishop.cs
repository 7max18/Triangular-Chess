using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
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
            int i = 0;
            while (true)
            {
                i++;
                if ((i - 1) % 3 == 0)
                    continue;
                else
                {
                    Vector3Int nextLoc = CubeToUnityCell(new Vector3Int(cubeLoc.x + i, cubeLoc.y - i, cubeLoc.z));
                    if (boardManager.board.HasTile(nextLoc))
                    {
                        moves.Add(nextLoc);
                    }
                    else
                        break;
                }

            }
            i = 0;
            while (true)
            {
                i++;
                if ((i - 1) % 3 == 0)
                    continue;
                else
                {
                    Vector3Int nextLoc = CubeToUnityCell(new Vector3Int(cubeLoc.x, cubeLoc.y + i, cubeLoc.z - i));
                    if (boardManager.board.HasTile(nextLoc))
                    {
                        moves.Add(nextLoc);
                    }
                    else
                        break;
                }
            }
            i = 0;
            while (true)
            {
                i++;
                if ((i - 1) % 3 == 0)
                    continue;
                else
                {
                    Vector3Int nextLoc = CubeToUnityCell(new Vector3Int(cubeLoc.x - i, cubeLoc.y, cubeLoc.z + i));
                    if (boardManager.board.HasTile(nextLoc))
                    {
                        moves.Add(nextLoc);
                    }
                    else
                        break;
                }
            }
        }
        else
        {
            int i = 0;
            while (true)
            {
                i++;
                if ((i - 1) % 3 == 0)
                    continue;
                else
                {
                    Vector3Int nextLoc = CubeToUnityCell(new Vector3Int(cubeLoc.x - i, cubeLoc.y + i, cubeLoc.z));

                    if (boardManager.board.HasTile(nextLoc))
                    {
                        moves.Add(nextLoc);
                    }
                    else
                        break;
                }

            }
            i = 0;
            while (true)
            {
                i++;
                if ((i - 1) % 3 == 0)
                    continue;
                else
                {
                    Vector3Int nextLoc = CubeToUnityCell(new Vector3Int(cubeLoc.x, cubeLoc.y - i, cubeLoc.z + i));
                    if (boardManager.board.HasTile(nextLoc))
                    {
                        moves.Add(nextLoc);
                    }
                    else
                        break;
                }

            }
            i = 0;
            while (true)
            {
                i++;
                if ((i - 1) % 3 == 0)
                    continue;
                else
                {
                    Vector3Int nextLoc = CubeToUnityCell(new Vector3Int(cubeLoc.x + i, cubeLoc.y, cubeLoc.z - i));
                    if (boardManager.board.HasTile(nextLoc))
                    {
                        moves.Add(nextLoc);
                    }
                    else
                        break;
                }
            }
        }

        return moves;
    }
}
