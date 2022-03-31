using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Team))]
public class contactdamage : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float damage = 1f;
    private Team team;

    void Awake() {
        team = GetComponent<Team>();
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(!other.gameObject.TryGetComponent<Health>(out Health otherHealth)){return;}
        if(!other.gameObject.TryGetComponent<Team>(out Team otherTeam)){return;}
        if(otherTeam.teamEnum == team.teamEnum){return;}

        otherHealth.TakeDamage(damage);
    }

}
