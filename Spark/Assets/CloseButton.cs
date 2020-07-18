using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    public Button exitButton;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        exitButton.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ExitGame()
    {
        print("hello");
        text.enabled = true;
        Application.Quit();
    }
}
