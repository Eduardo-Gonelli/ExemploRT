using UnityEngine;

public class ControleTransformacoes : MonoBehaviour
{
    public ExemploRotacao er;
    public TranslacaoExemplo te;
    public Ordem ordem;    
    public GameObject objeto_a_transformar;
    public Eixo eixo_de_rotacao;
    public float quantidade_de_rotacao;
    public Eixo eixo_de_translacao;
    public float quantidade_de_translacao;

    Vector3 eixo_escolhido;

    void Start()
    {
        // a ordem das transformações alteram o resultado
        // ao transformar rotação e translação (RT), o objeto 
        // gira corretamente e depois fica na posição desejada
        // se iniciar translação e depois rotação (TR), o objeto
        // será deslocado em outro eixo além do escolhido.
        Vector3 eixo_r = SetEixo(eixo_de_rotacao);
        Vector3 eixo_t = SetEixo(eixo_de_translacao);
        if(ordem == Ordem.RT)
        {
            er.AplicarRotacao(eixo_r, quantidade_de_rotacao, objeto_a_transformar);
            te.AplicarTranslacao(eixo_t, quantidade_de_translacao, objeto_a_transformar);
        }
        else
        {
            te.AplicarTranslacao(eixo_t, quantidade_de_translacao, objeto_a_transformar);
            er.AplicarRotacao(eixo_r, quantidade_de_rotacao, objeto_a_transformar);            
        }        
    }

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
