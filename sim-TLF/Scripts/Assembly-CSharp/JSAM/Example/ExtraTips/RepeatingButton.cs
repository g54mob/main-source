using UnityEngine;

namespace JSAM.Example.ExtraTips
{
	public class RepeatingButton : MonoBehaviour
	{
		[SerializeField]
		private SoundFileObject soundToPlay;

		private bool buttonDown;

		private void Update()
		{
			if (buttonDown)
			{
				soundToPlay.Play();
			}
		}

		public void ButtonDown()
		{
			buttonDown = true;
		}

		public void ButtonUp()
		{
			buttonDown = false;
		}
	}
}
