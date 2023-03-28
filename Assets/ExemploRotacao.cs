using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExemploRotacao : MonoBehaviour
{
    public enum Eixo
    {
        x, y, z
    }

    public Eixo eixo;
    public float angulo_de_rotacao;
    private Vector3 eixo_de_rotacao;
    // Start is called before the first frame update
    void Start()
    {
        switch (eixo)
        {
            case Eixo.x:
                eixo_de_rotacao = Vector3.right;
                break;
            case Eixo.y:
                eixo_de_rotacao = Vector3.up;
                break;
            case Eixo.z:
                eixo_de_rotacao = Vector3.forward;
                break;
        }
        AplicarRotacao(eixo_de_rotacao, angulo_de_rotacao);
    }

    void AplicarRotacao(Vector3 eixo, float angulo)
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
        transform.position = matriz_de_rotacao.MultiplyPoint3x4(transform.position);
        transform.rotation = matriz_de_rotacao.rotation;        
    }
}
