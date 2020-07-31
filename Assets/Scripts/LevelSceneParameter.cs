using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevel", menuName = "SceneScript/Level")]
public class LevelSceneParameter : GameSceneParameter
{
    [Header("Level Parameters")]
    public int EnemiesCount;
}
