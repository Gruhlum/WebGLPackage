using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HexTecGames
{
    public class DelayedSceneLoader : MonoBehaviour
    {
        [SerializeField] private float delayTime = 2f;
        [SerializeField] private string sceneName = default;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(delayTime);

            SceneManager.LoadScene(sceneName);
        }
    }
}