using FMODUnity;
using OUSystems.Basics.UI;
using UnityEngine;

namespace OUSystems.Basics
{
	public class HoverListenerSFX : MonoBehaviour
	{
		[SerializeField]
		private HoverListener _hoverListener;

		public EventReference HoverSound;

		public EventReference HoverEndSound;

		protected virtual void Start()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		public void PlayHoverSound()
		{
		}

		public void PlayHoverEndSound()
		{
		}
	}
}
