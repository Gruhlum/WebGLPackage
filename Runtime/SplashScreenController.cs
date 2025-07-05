using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace HexTecGames.WebGLPackage
{
    public class SplashScreenController : MonoBehaviour
    {
        [SerializeField] private VideoPlayer videoPlayer = default;
        [SerializeField] private string path = default;
        [SerializeField] private string startSceneName = default;
        [SerializeField] private TMP_Text errorText = default;

        private void Reset()
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.1f);
            videoPlayer.loopPointReached += VideoPlayer_loopPointReached;
            StartVideo();
        }
        private void StartVideo()
        {
            if (videoPlayer != null)
            {
                videoPlayer.errorReceived += VideoPlayer_errorReceived;
                string streamingPath = System.IO.Path.Combine(Application.streamingAssetsPath, path);
                //errorText.text = streamingPath;
                videoPlayer.url = streamingPath;
                videoPlayer.Play();
            }
        }

        private void VideoPlayer_errorReceived(VideoPlayer source, string message)
        {
            errorText.text = message;
        }

        private void VideoPlayer_loopPointReached(VideoPlayer source)
        {
            SceneManager.LoadScene(startSceneName);
            videoPlayer.loopPointReached -= VideoPlayer_loopPointReached;
        }
    }
}