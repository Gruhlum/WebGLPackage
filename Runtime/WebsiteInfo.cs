using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexTecGames.WebGLPackage
{
    [CreateAssetMenu(menuName = "HexTecGames/Editor/WebsiteInfo")]
    public class WebsiteInfo : ScriptableObject
    {
        [TextArea][SerializeField] private string infoUrl = default;

        [TextArea][SerializeField] private List<string> validUrls;

        public List<string> GetValidUrls()
        {
            List<string> results = new List<string>();
            results.AddRange(validUrls);
            return results;
        }

        [ContextMenu("Open Info")]
        public void OpenInfoUrl()
        {
            if (!string.IsNullOrEmpty(infoUrl))
            {
                Application.OpenURL(infoUrl);
            }
        }
    }
}