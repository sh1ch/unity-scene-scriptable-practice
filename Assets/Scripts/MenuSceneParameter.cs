using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMenu", menuName = "SceneScript/Menu")]
public class MenuSceneParameter : GameSceneParameter
{
    [Header("Menu Parameters")]
    public MenuType Type = MenuType.MainMenu;
}
