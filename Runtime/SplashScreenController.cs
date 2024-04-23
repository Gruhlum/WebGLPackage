using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HexTecGames
{
	public class SplashScreenController : MonoBehaviour
	{
		[SerializeField] private string nextScene = default;
		[SerializeField] private float duration = 2;

		private IEnumerator Start()
		{
			yield return new WaitForSeconds(duration);
			SceneManager.LoadScene(nextScene);
		}
	}
}