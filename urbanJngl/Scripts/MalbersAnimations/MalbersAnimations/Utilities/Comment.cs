using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Tools/Comment")]
	public class Comment : MonoBehaviour
	{
		[Multiline]
		public string text;

		public Object reference;

		public bool ShowDescription;

		[ContextMenu("Show Reference")]
		private void ShowReference()
		{
			ShowDescription = !ShowDescription;
		}
	}
}
