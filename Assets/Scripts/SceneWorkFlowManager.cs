using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "NewSample", menuName = "SceneScript/Sample")]
public class SceneWorkFlowManager : ScriptableObject
{
    public List<LevelSceneParameter> Levels = new List<LevelSceneParameter>();
    public List<MenuSceneParameter> Menus = new List<MenuSceneParameter>();

    public int CurrentLevel = 1;

    public LevelSceneParameter GetLevelFromResources()
    {
        LevelSceneParameter scene = null;

        scene = Resources.Load<LevelSceneParameter>($"SceneWorkFlow/Level{CurrentLevel}");

        return scene;
    }

    public LevelSceneParameter GetLevelSceneFromInspector()
    {
        LevelSceneParameter scene = null;

        scene = Levels.ElementAt(CurrentLevel - 1);

        return scene;
    }

    public void LoadScene(int levelIndex)
    {
        if (levelIndex > Levels.Count)
        {
            CurrentLevel = 1; // リセット
        }

        SceneManager.LoadSceneAsync($"LevelScene");
    }

    public void GotoNewLevelScene()
    {
        CurrentLevel = 1;

        LoadScene(CurrentLevel);
    }

    public void GotoCurrentLevelScene()
    {
        LoadScene(CurrentLevel);
    }

    public void GotoNextLevelScene()
    {
        CurrentLevel += 1;

        LoadScene(CurrentLevel);
    }

    public void LoadMainMenu()
    {
        var menuScene = Menus.SingleOrDefault(p => p.Type == MenuType.MainMenu);

        Debug.Log("load:" + menuScene.SceneName);

        if (menuScene != null)
        {
            SceneManager.LoadSceneAsync(menuScene.SceneName);
        }
    }

    public event EventHandler PopedMenu;
    public event EventHandler UnPopedMenu;

    public void PopPauseMenu()
    {
        var menuScene = Menus.SingleOrDefault(p => p.Type == MenuType.PauseMenu);

        Debug.Log("pop:" + menuScene.SceneName);

        if (menuScene != null)
        {
            SceneManager.LoadSceneAsync(menuScene.SceneName, LoadSceneMode.Additive);
        }

        PopedMenu?.Invoke(this, EventArgs.Empty);
    }

    public void UnpopPauseMenu()
    {
        var menuScene = Menus.SingleOrDefault(p => p.Type == MenuType.PauseMenu);

        Debug.Log("unpop:" + menuScene.SceneName);

        if (menuScene != null)
        {
            SceneManager.UnloadSceneAsync(menuScene.SceneName, UnloadSceneOptions.None);
        }

        UnPopedMenu?.Invoke(this, EventArgs.Empty);
    }
}
