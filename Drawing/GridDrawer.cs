using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDrawer : MonoBehaviour
{
    FastNoise _fastNoise;

    [SerializeField, GetSet("GridSize")]
    private Vector3Int _gridSize;
    public Vector3Int GridSize
    {
        get { return _gridSize; }
        set { _gridSize = value; }
    }

    [SerializeField, GetSet("Increment")]
    private float _increment;
    public float Increment
    {
        get { return _increment; }
        set { _increment = value; }
    }

    [SerializeField, GetSet("Offset")]
    private Vector3 _offset;
    public Vector3 Offset
    {
        get { return _offset; }
        set { _offset = value; }
    }

    [SerializeField, GetSet("OffsetSpeed")]
    private Vector3 _offsetSpeed;
    public Vector3 OffsetSpeed
    {
        get { return _offsetSpeed; }
        set { _offsetSpeed = value; }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        _fastNoise = new FastNoise();
        //** Creating the flow grid **//

        float xOff = 0.0f;
        for (int x = 0; x < GridSize.x; x++)
        {
            float yOff = 0.0f;
            for (int y = 0; y < GridSize.y; y++)
            {
                float zOff = 0.0f;
                for (int z = 0; z < GridSize.z; z++)
                {
                    //3D Grid, GetSimplex returns [0, 1], + 1 to get [1, 2]
                    float noise = _fastNoise.GetSimplex(xOff + Offset.x, yOff + Offset.y, zOff + Offset.z) + 1;

                    //** Get direction of noise & draw direction lines **//
                    Vector3 noiseDirection = new Vector3(Mathf.Cos(noise * Mathf.PI), Mathf.Sin(noise * Mathf.PI), Mathf.Cos(noise * Mathf.PI));
                    Gizmos.color = new Color(noiseDirection.normalized.x, noiseDirection.normalized.y, noiseDirection.normalized.z, 1f);
                    Vector3 pos = new Vector3(x, y, z) + transform.position;
                    Vector3 endPos = pos + Vector3.Normalize(noiseDirection);
                    Gizmos.DrawLine(pos, endPos);

                    //* Unity slows a bit with drawing grid so removed spheres at end **//
                    //Gizmos.DrawSphere(endPos, 0.1f);

                    xOff += Increment;
                }
                yOff += Increment;
            }
            xOff += Increment;
        }

    }
}
