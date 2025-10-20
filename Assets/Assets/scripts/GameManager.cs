using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int inimigosMortos = 0;
    public int inimigosNecessarios = 5;
    public GameObject bossPrefab;
    public Transform bossSpawn;

    private bool bossInvocado = false;
    private bool bossMorto = false;

    void Awake() {
        instance = this;
    }

    public void InimigoMorto() {
        if (bossMorto) return; // se o boss j� morreu, ignora

        inimigosMortos++;

        // S� invoca o boss uma vez
        if (!bossInvocado && inimigosMortos >= inimigosNecessarios) {
            InvocarBoss();
        }
    }

    void InvocarBoss() {
        bossInvocado = true;
        Debug.Log("Boss apareceu!");
        Instantiate(bossPrefab, bossSpawn.position, Quaternion.identity);
    }

    // Chame este m�todo quando o boss morrer
    public void BossMorreu() {
        bossMorto = true;
        bossInvocado = false;
        Debug.Log("Boss derrotado!");
    }
}
