using TMPro;
using UnityEngine;

namespace PhEngine.ThaiTextCare.Utility
{
	public class Highlight_ExampleScript : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text text;

		[SerializeField]
		private WordHighlighter wordHighlighter;

		private void Start()
		{
		}

		private void OnWordHighlighted(Highlight obj)
		{
		}
	}
}
