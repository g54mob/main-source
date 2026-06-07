using TMPro;
using UnityEngine;

namespace PhEngine.ThaiTextCare.Utility
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	[ExecuteAlways]
	[DisallowMultipleComponent]
	public class Highlightable : MonoBehaviour
	{
		[SerializeField]
		[HideInInspector]
		private TextMeshProUGUI text;

		private void Awake()
		{
		}

		public bool HighlightBy(WordHighlighter highlighter)
		{
			return false;
		}
	}
}
