
using UnityEngine;
using System.Collections;

public class FireTower : Tower
{
    //1
    public GameObject fireParticlesPrefab;
    //2
    protected override void AttackEnemy()
    {
        //3
        base.AttackEnemy();
        //4
        GameObject particles = (GameObject)Instantiate(fireParticlesPrefab, transform.position + new Vector3(0, .5f),
          fireParticlesPrefab.transform.rotation);
        //5
        particles.transform.localScale *= aggroRadius / 10f; // Scale fire particle radius with the aggro radius
                                                             //6
        foreach (Enemy enemy in EnemyManager.Instance.GetEnemiesInRange(transform.position, aggroRadius))
        {
            enemy.TakeDamage(attackPower);
        }
    }
}
