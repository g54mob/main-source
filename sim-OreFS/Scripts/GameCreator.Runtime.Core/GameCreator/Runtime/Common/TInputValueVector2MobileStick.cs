using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public abstract class TInputValueVector2MobileStick : TInputValueVector2
	{
		protected ITouchStick Stick { get; set; }

		public override void OnStartup()
		{
			Enable();
		}

		public override void OnDispose()
		{
			Disable();
			if (!(Stick?.Root == null))
			{
				UnityEngine.Object.Destroy(Stick.Root);
			}
		}

		public override Vector2 Read()
		{
			return Stick?.Value ?? Vector2.zero;
		}

		protected virtual void Enable()
		{
			if (Stick == null)
			{
				ITouchStick touchStick = (Stick = CreateTouchStick());
			}
			Stick.Root.SetActive(value: true);
		}

		protected virtual void Disable()
		{
			if (!(Stick?.Root == null))
			{
				Stick.Root.SetActive(value: false);
			}
		}

		protected abstract ITouchStick CreateTouchStick();
	}
}
