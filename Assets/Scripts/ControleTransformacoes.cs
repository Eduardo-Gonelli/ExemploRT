using UnityEngine;

public class ControleTransformacoes : MonoBehaviour
{
    Rotacao rotacao; // script de rota��o
    Translacao translacao; // script de transla��o
    public Ordem ordem; // enum para escolher a ordem das transforma��es

    public GameObject objeto_a_transformar;

    public Eixo eixo_de_rotacao; // enum para escolher o eixo de rota��o
    public float quantidade_de_rotacao;

    public Eixo eixo_de_translacao; // enum para escolher o eixo da transla��o
    public float quantidade_de_translacao;

    void Start()
    {
        rotacao = GetComponent<Rotacao>();
        translacao = GetComponent<Translacao>();
        Vector3 eixo_r = SetEixo(eixo_de_rotacao);
        Vector3 eixo_t = SetEixo(eixo_de_translacao);

        // a ordem das transforma��es alteram o resultado
        // ao transformar rota��o e transla��o (RT), o objeto 
        // gira corretamente e depois fica na posi��o desejada
        // se iniciar transla��o e depois rota��o (TR), o objeto
        // ser� deslocado em outro eixo al�m do escolhido.
        if (ordem == Ordem.RT)
        {
            rotacao.AplicarRotacao(eixo_r, quantidade_de_rotacao, objeto_a_transformar);
            translacao.AplicarTranslacao(eixo_t, quantidade_de_translacao, objeto_a_transformar);
        }
        else
        {
            translacao.AplicarTranslacao(eixo_t, quantidade_de_translacao, objeto_a_transformar);
            rotacao.AplicarRotacao(eixo_r, quantidade_de_rotacao, objeto_a_transformar);            
        }        
    }

    // Configura o eixo de rota��o
    public Vector3 SetEixo(Eixo eixo)
    {
        switch (eixo)
        {
            case Eixo.x:
                return Vector3.right;
            case Eixo.y:
                return Vector3.up;
            case Eixo.z:
                return Vector3.forward;
            default:
                return Vector3.zero;
        }
    }
}
