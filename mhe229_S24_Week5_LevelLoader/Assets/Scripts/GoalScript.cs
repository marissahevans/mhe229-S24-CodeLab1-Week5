using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LevelGoal"))
        {
            ASCIILevelLoader.instance.CurrentLevel++;
        }
        if (other.CompareTag("Enemy"))
        {
            ASCIILevelLoader.instance.CurrentLevel;
        }
    }
}
