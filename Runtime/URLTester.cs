using System.Collections.Generic;
using HexTecGames.Basics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HexTecGames.WebGLPackage
{
    public class URLTester : MonoBehaviour
    {
        [SerializeField] private List<string> validUrls = default;

        [SerializeField] private List<WebsiteInfo> websiteInfos = new List<WebsiteInfo>();

        public enum BounceMode { Quit, Scene, GameObject }
        public BounceMode mode;
        [DrawIf(nameof(mode), BounceMode.Scene)]
        [SerializeField]
        [Tooltip("Scene to load for invalid host")]
        private string bounceSceneName = default;
        [DrawIf(nameof(mode), BounceMode.GameObject)][SerializeField] private GameObject bounceGO = default;


        [SerializeField] private bool testBounce = default;

        private void Start()
        {
            if (testBounce && Application.isEditor)
            {
                Bounce();
            }
            else PiracyCheck();
        }

        public void PiracyCheck()
        {
            if (Application.platform != RuntimePlatform.WebGLPlayer)
            {
                return;
            }
            if (!IsValidHost())
            {
                Bounce();
            }
        }
        private bool IsValidHost()
        {
            if (!IsValidHost(validUrls))
            {
                return false;
            }
            foreach (WebsiteInfo websiteInfo in websiteInfos)
            {
                if (IsValidHost(websiteInfo.GetValidUrls()))
                {
                    return true;
                }
            }
            return true;
        }

        private bool IsValidHost(List<string> urls)
        {
            foreach (string host in urls)
            {
                if (Application.absoluteURL.Contains(host))
                {
                    return true;
                }
            }
            return false;
        }

        private void Bounce()
        {
            Debug.Log("Invalid: " + Application.absoluteURL);

            switch (mode)
            {
                case BounceMode.Quit:
#if UNITY_EDITOR
                    EditorApplication.ExitPlaymode();
#endif
                    Application.Quit();
                    break;
                case BounceMode.Scene:
                    SceneManager.LoadScene(bounceSceneName);
                    break;
                case BounceMode.GameObject:
                    if (bounceGO != null)
                    {
                        bounceGO.SetActive(true);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
