// Translate, rotate and scale a mesh. Try varying
// the parameters in the inspector while running
// to see the effect they have.

using UnityEngine;
using System.Collections;

public class SetTRS : MonoBehaviour
{
    public Vector3 translation;
    public Vector3 eulerAngles;
    public Vector3 scale = new Vector3(1, 1, 1);
    private MeshFilter mf;
    private Vector3[] origVerts;
    private Vector3[] newVerts;

    void Start()
    {
        mf = GetComponent<MeshFilter>();
        origVerts = mf.mesh.vertices;
        newVerts = new Vector3[origVerts.Length];
    }

    void Update()
    {
        Quaternion rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z);
        Matrix4x4 m = Matrix4x4.identity;
        m.SetTRS(translation, rotation, scale);
        int i = 0;        
        while (i < origVerts.Length/2)
        {
            newVerts[i] = m.MultiplyPoint3x4(origVerts[i]);
            i++;
        }        
        mf.mesh.vertices = newVerts;
    }
}
