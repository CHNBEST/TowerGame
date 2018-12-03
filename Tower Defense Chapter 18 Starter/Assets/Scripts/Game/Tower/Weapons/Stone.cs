
using UnityEngine;
using System.Collections;

public class Stone : FollowingProjectile
{
    //1
    public float damage;
    //2
    protected override void OnHitEnemy()
    {
        //3
        enemyToFollow.TakeDamage(damage);
        Destroy(gameObject);
    }
}
