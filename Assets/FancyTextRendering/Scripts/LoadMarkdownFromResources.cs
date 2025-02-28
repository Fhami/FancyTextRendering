using JimmysUnityUtilities;
using TriInspector;
using UnityEngine;

namespace LogicUI.FancyTextRendering
{
    [RequireComponent(typeof(MarkdownRenderer))]
    public class LoadMarkdownFromResources : MonoBehaviour
    {
        [SerializeField] string MarkdownResourcesPath;

        private void Awake()
        {
            LoadMarkdown();
        }

        [Button]
        private void LoadMarkdown()
        {
            string markdown = ResourcesUtilities.ReadTextFromFile(MarkdownResourcesPath);
            GetComponent<MarkdownRenderer>().Source = markdown;
        }
    }
}