using Febucci.TextAnimatorForUnity;
using UnityEngine;

namespace Febucci.UI.Examples
{
	[AddComponentMenu("")]
	public class UsageExample : MonoBehaviour
	{
		public TypewriterComponent textAnimatorPlayer;

		[TextArea(3, 50)]
		[SerializeField]
		private string textToShow = " ";

		private void Awake()
		{
		}

		private void Start()
		{
			ShowText();
		}

		public void ShowText()
		{
			textAnimatorPlayer.ShowText(textToShow);
		}
	}
}
