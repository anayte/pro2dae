using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{

    public TeamEnum teamEnum { get { return team; } private set {team = value;}}
    [SerializeField] TeamEnum team = TeamEnum.trampas;


}
