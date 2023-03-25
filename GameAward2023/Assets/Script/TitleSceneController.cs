using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour
{
	[SerializeReference] Object m_nextScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {		
		if (Input.anyKeyDown)
			SceneManager.LoadScene(m_nextScene.name);
    }
}