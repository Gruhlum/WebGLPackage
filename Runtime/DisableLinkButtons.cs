using HexTecGames.Basics.UI.Buttons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HexTecGames
{
    public class DisableLinkButtons : MonoBehaviour
    {
        private void Awake()
        {
            var results = FindObjectsOfType<LinkButton>(true);
            foreach (var result in results)
            {
                result.GetComponent<Button>().interactable = false;
            }
        }
    }
}