// Translate, rotate and scale a mesh. Try varying
// the parameters in the inspector while running
// to see the effect they have.

using UnityEngine;

public class SetTRS : MonoBehaviour
{
    public Vector3 translation;
    public Vector3 eulerAngles;
    public Vector3 scale = new Vector3(1, 1, 1);
    private MeshFilter mf; // componente que contém a malha e seus vértices
    private Vector3[] origVerts;
    private Vector3[] newVerts;

    void Start()
    {
        mf = GetComponent<MeshFilter>();
        origVerts = mf.mesh.vertices; // captura os vértices originais
        newVerts = new Vector3[origVerts.Length];
    }

    void Update()
    {
        // cria a matriz de transformação
        Quaternion rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z);
        // cria a matriz identidade
        Matrix4x4 m = Matrix4x4.identity;
        // o método SetTRS recebe a translação, rotação e escala
        // e retorna a matriz de transformação
        m.SetTRS(translation, rotation, scale);
        int i = 0;     
        // multiplica cada vértice pela matriz de transformação
        while (i < origVerts.Length)
        {
            newVerts[i] = m.MultiplyPoint3x4(origVerts[i]);
            i++;
        }       
        // atualiza os vértices da malha
        mf.mesh.vertices = newVerts;
    }
}
