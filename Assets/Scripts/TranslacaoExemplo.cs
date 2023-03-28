using UnityEngine;

public class TranslacaoExemplo : MonoBehaviour
{
    public void AplicarTranslacao(Vector3 eixo, float quantidade, GameObject objeto)
    {
        // cria uma matria de translacao 4x4
        Matrix4x4 matriz_de_translacao = Matrix4x4.Translate(eixo * quantidade);

        // converte a posicao atual do objeto para coordenadas homogeneas
        Vector4 posicao_atual = new Vector4(objeto.transform.position.x, objeto.transform.position.y, objeto.transform.position.z, 1.0f);

        // aplica a matriz de translacao a posicao atual
        Vector4 posicao_nova = matriz_de_translacao * posicao_atual;

        // atualiza a posicao do objeto para a nova posicao calculada
        objeto.transform.position = new Vector3(posicao_nova.x, posicao_nova.y, posicao_nova.z);
    }
}
