using UnityEngine;

public class ControleTransformacoes : MonoBehaviour
{
    Rotacao rotacao; // script de rotação
    Translacao translacao; // script de translação
    public Ordem ordem; // enum para escolher a ordem das transformações

    public GameObject objeto_a_transformar;

    public Eixo eixo_de_rotacao; // enum para escolher o eixo de rotação
    public float quantidade_de_rotacao;

    public Eixo eixo_de_translacao; // enum para escolher o eixo da translação
    public float quantidade_de_translacao;

    void Start()
    {
        rotacao = GetComponent<Rotacao>();
        translacao = GetComponent<Translacao>();
        Vector3 eixo_r = SetEixo(eixo_de_rotacao);
        Vector3 eixo_t = SetEixo(eixo_de_translacao);

        // a ordem das transformações alteram o resultado
        // ao transformar rotação e translação (RT), o objeto 
        // gira corretamente e depois fica na posição desejada
        // se iniciar translação e depois rotação (TR), o objeto
        // será deslocado em outro eixo além do escolhido.
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

    // Configura o eixo de rotação
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
