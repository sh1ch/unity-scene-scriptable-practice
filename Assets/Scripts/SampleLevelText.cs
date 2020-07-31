using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleLevelText : MonoBehaviour
{
    public SceneWorkFlowManager Sample;
    private LevelSceneParameter _Level;

    // Start is called before the first frame update
    void Start()
    {
        _Level = Sample.GetLevelFromResources();

        var text = this.GetComponent<Text>();

        text.text = $"{_Level.name}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
