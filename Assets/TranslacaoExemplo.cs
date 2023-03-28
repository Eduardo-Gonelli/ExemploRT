using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslacaoExemplo : MonoBehaviour
{
    public enum Eixo {
        x, y, z
    }

    public Eixo eixo;    
    public float quantidade_translacao;

    private Vector3 eixo_de_translacao;
    // Start is called before the first frame update
    void Start()
    {
        switch (eixo)
        {
            case Eixo.x:
                eixo_de_translacao = Vector3.right;
                break;
            case Eixo.y:
                eixo_de_translacao = Vector3.up;
                break;
            case Eixo.z:
                eixo_de_translacao = Vector3.forward;
                break;
        }
        AplicaTranslacao(eixo_de_translacao, quantidade_translacao);
    }

    void AplicaTranslacao(Vector3 eixo, float quantidade)
    {
        // cria uma matria de translacao 4x4
        Matrix4x4 matriz_de_translacao = Matrix4x4.Translate(eixo * quantidade);

        // converte a posicao atual do objeto para coordenadas homogeneas
        Vector4 posicao_atual = new Vector4(transform.position.x, transform.position.y, transform.position.z, 1.0f);

        // aplica a matriz de translacao a posicao atual
        Vector4 posicao_nova = matriz_de_translacao * posicao_atual;

        // atualiza a posicao do objeto para a nova posicao calculada
        transform.position = new Vector3(posicao_nova.x, posicao_nova.y, posicao_nova.z);
    }
}
