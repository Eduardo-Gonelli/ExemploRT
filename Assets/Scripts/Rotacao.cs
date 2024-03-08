using UnityEngine;

public class Rotacao : MonoBehaviour
{    
    public void AplicarRotacao(Vector3 eixo, float angulo, GameObject objeto)
    {                
        // variaveis necessarias para a rotacao
        float radianos = angulo * Mathf.Deg2Rad;
        float cosTheta = Mathf.Cos(radianos);
        float sinTheta = Mathf.Sin(radianos);
        float um_menos_cos_theta = 1 - cosTheta;

        Vector3 eixo_normalizado = eixo.normalized;
        float x = eixo_normalizado.x;
        float y = eixo_normalizado.y;
        float z = eixo_normalizado.z;

        // cria a matriz de rotacao
        Matrix4x4 matriz_de_rotacao = new Matrix4x4(
            new Vector4(cosTheta + um_menos_cos_theta * x * x, um_menos_cos_theta * x * y + sinTheta * z, um_menos_cos_theta * x * z - sinTheta * y, 0),
            new Vector4(um_menos_cos_theta * x * y - sinTheta * z, cosTheta + um_menos_cos_theta * y * y, um_menos_cos_theta * y * z + sinTheta * x, 0),
            new Vector4(um_menos_cos_theta * x * z + sinTheta * y, um_menos_cos_theta * y * z - sinTheta * x, cosTheta + um_menos_cos_theta * z * z, 0),
            new Vector4(0, 0, 0, 1)
            );

        

        // aplica a matriz de rotacao a posicao e rotacao do objeto
        objeto.transform.position = matriz_de_rotacao.MultiplyPoint3x4(objeto.transform.position);
        objeto.transform.rotation = matriz_de_rotacao.rotation;        
    }
}
