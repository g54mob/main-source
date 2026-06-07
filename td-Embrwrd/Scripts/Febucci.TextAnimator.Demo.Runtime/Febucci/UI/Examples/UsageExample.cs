using UnityEngine;

namespace Febucci.UI.Examples
{
	[AddComponentMenu(null)]
	public class UsageExample : MonoBehaviour
	{
		public TypewriterByCharacter textAnimatorPlayer;

		[TextArea(3, 50)]
		[SerializeField]
		private string textToShow;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void ShowText()
		{
		}
	}
}
