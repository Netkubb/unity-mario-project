using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeAttack : MonoBehaviour
{
    public Transform hitblock;
    public float attackRadius = 0.5f;
    public int attackDamage = 20;
    float attackSpeed = 2f;
    float nextAttack = 0f;
    public LayerMask enemyLayer;

    public Animator animator;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Hit"))
        {
            if (Time.time >= nextAttack)
            {
                nextAttack = Time.time + 1f / attackSpeed;
                Attack();
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitenemy = Physics2D.OverlapCircleAll(hitblock.position, attackRadius, enemyLayer);
        foreach (Collider2D enemy in hitenemy)
        {
            Debug.Log("hit enemy");
            enemy.GetComponent<enemy>().getHitted(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (hitblock == null)
        {
            return;
        }
        Gizmos.DrawSphere(hitblock.position, attackRadius);
    }
}
