using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{
    [Header ("Damage Settings")]
    public int damage;
    [Header ("Atack Directions")]
    public Vector2 atackDirection;
    public GameObject attackObj;
    public GameObject[] attackObjDirection;

    [Header ("Atack Range")]
    public float sphereRadius = 2.0f;
    public LayerMask TargetMask;
    private Collider2D[] hitColliders;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetFaceDirection();
        AttackRangeCollision();
        MakeDamage();
    }

    public void SetFaceDirection()
    {
        atackDirection.x = MovementScript.GetInputDirection().x;
        atackDirection.y = MovementScript.GetInputDirection().y;

        atackDirection = atackDirection.normalized;

        if(atackDirection.y > 0 && atackDirection.x < 0)
            attackObj.transform.position = attackObjDirection[4].transform.position;
        else if(atackDirection.y < 0 && atackDirection.x > 0)
            attackObj.transform.position = attackObjDirection[5].transform.position;
        
        else if(atackDirection.y > 0 && atackDirection.x > 0)
            attackObj.transform.position = attackObjDirection[6].transform.position;
        else if(atackDirection.y < 0 && atackDirection.x < 0)
            attackObj.transform.position = attackObjDirection[7].transform.position;

        else if(atackDirection.y > 0)
            attackObj.transform.position = attackObjDirection[0].transform.position;
        else if(atackDirection.y < 0)
            attackObj.transform.position = attackObjDirection[1].transform.position;

        else if(atackDirection.x > 0)
            attackObj.transform.position = attackObjDirection[2].transform.position;
        else if(atackDirection.x < 0)
            attackObj.transform.position = attackObjDirection[3].transform.position;       
    }

   public List<GameObject> AttackRangeCollision()
    {
        hitColliders = Physics2D.OverlapCircleAll(attackObj.transform.position, sphereRadius, TargetMask);
        List<GameObject> hitGameObjects = new List<GameObject>();

        foreach (var hitCollider in hitColliders)
        {
            hitGameObjects.Add(hitCollider.gameObject);
        }
        
        return hitGameObjects;
    }

    public void MakeDamage()
    {
        List<GameObject> Enemys = AttackRangeCollision();
        if(Enemys.Count != 0)
        {
            if(Input.GetKeyDown(KeyCode.G))
            {
                foreach (var item in Enemys)
                {
                    item.GetComponent<EnemyLife>().TakeDamege(damage);
                }
            }
        }

    }

    void OnDrawGizmos()
    {
        // Define a cor do Gizmo
        Gizmos.color = Color.green;

        // Desenha o wireframe da esfera de colisão
        Gizmos.DrawWireSphere(attackObj.transform.position, sphereRadius);

        // Se colidiu, desenha os objetos colididos em vermelho
        if (hitColliders != null)
        {
            Gizmos.color = Color.red;
            foreach (var hitCollider in hitColliders)
            {
                // Desenha uma linha até o objeto colidido para visualização
                Gizmos.DrawLine(attackObj.transform.position, hitCollider.transform.position);
            }
        }
    }
}
