using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : HealthBase
{
    [Header("Enemy setup")]
    public int damage = 10;

    public Animator animator;
    public string triggerAttack = "Attack";
    public string triggerDeath = "Death";

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     Debug.Log(collision.transform.name);
    //     var health = collision.GetComponent<HealthBase>();

    //     if(health != null)
    //     {
    //         health.Damage(damage);
    //     }

    // }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log(collision.transform.name);
        var health = collision.gameObject.GetComponent<HealthBase>();

        if (health != null)
        {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }

    private void PlayDeathAnimation()
    {
        animator.SetTrigger(triggerDeath);
    }

    private void OnEnemyKill()
    {
        OnKill -= OnEnemyKill;
        PlayDeathAnimation();
    }

    void Start()
    {
        OnKill += OnEnemyKill;
    }

}
