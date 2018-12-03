
using UnityEngine;
using System.Collections;

public class Ice : FollowingProjectile
{

    protected override void OnHitEnemy()
    {
        enemyToFollow.Freeze();
        Destroy(gameObject);
    }
}
