using FMODUnity;
using OUSystems.Basics.UI;
using UnityEngine;

namespace OUSystems.Basics
{
	public class PressListenerSFX : MonoBehaviour
	{
		[SerializeField]
		private PressListener _uiPressable;

		public EventReference HoverSound;

		public EventReference HoverEndSound;

		public EventReference PressSound;

		public EventReference PressEndSound;

		public void Start()
		{
		}

		private void OnDestroy()
		{
		}

		public void PlayHoverSound()
		{
		}

		public void PlayHoverEndSound()
		{
		}

		public void PlayPressSound()
		{
		}

		public void PlayPressEndSound()
		{
		}
	}
}
