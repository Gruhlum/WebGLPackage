using HexTecGames.Basics.UI.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace HexTecGames
{
    public class DisableLinkButtons : MonoBehaviour
    {
        private void Awake()
        {
            LinkButton[] results = FindObjectsOfType<LinkButton>(true);
            foreach (LinkButton result in results)
            {
                result.GetComponent<Button>().interactable = false;
            }
        }
    }
}