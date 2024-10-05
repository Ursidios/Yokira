using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab do inimigo a ser spawnado
    public float spawnRadius = 10f; // Raio ao redor do ponto de spawn
    public float spawnInterval = 5f; // Intervalo de tempo entre spawns
    public int maxEnemies = 10; // Quantidade máxima de inimigos ativos ao mesmo tempo

    private List<GameObject> activeEnemies = new List<GameObject>(); // Lista de inimigos ativos

    // Start é chamado no início do jogo
    void Start()
    {
        // Começa o processo de spawn repetido
        StartCoroutine(SpawnEnemies());
    }

    // Corroutine que faz o spawn de inimigos repetidamente
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (activeEnemies.Count < maxEnemies)
            {
                SpawnEnemy(); // Spawn de um novo inimigo se o limite não foi alcançado
            }

            // Espera pelo próximo intervalo de spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Função que faz o spawn do inimigo em uma posição aleatória
    void SpawnEnemy()
    {
        // Gera uma posição aleatória dentro de um círculo de raio `spawnRadius`
        Vector2 spawnPosition = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos3D = new Vector3(spawnPosition.x, 0, spawnPosition.y); // Mantém y como 0

        // Spawna o inimigo e armazena a referência na lista
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPos3D, Quaternion.identity);
        activeEnemies.Add(newEnemy);

        // Limpa inimigos destruídos da lista
    }

    // Para visualizar o raio de spawn no editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
