using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.Utilities;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Keywords(new string[] { "Finger", "Touch", "Press", "Tap" })]
	public abstract class TInputButtonTouch : TInputButton
	{
		protected bool WasTouchedThisFrame
		{
			get
			{
				foreach (Touch activeTouch in Touch.activeTouches)
				{
					if (activeTouch.began)
					{
						return true;
					}
				}
				return false;
			}
		}

		protected bool WasReleasedThisFrame
		{
			get
			{
				foreach (Touch activeTouch in Touch.activeTouches)
				{
					if (activeTouch.ended)
					{
						return true;
					}
				}
				return false;
			}
		}

		protected bool IsPressed
		{
			get
			{
				foreach (Touch activeTouch in Touch.activeTouches)
				{
					if (activeTouch.inProgress)
					{
						return true;
					}
				}
				return false;
			}
		}

		protected int TapCount
		{
			get
			{
				ReadOnlyArray<Touch> activeTouches = Touch.activeTouches;
				int num = ((activeTouches.Count > 0) ? 1 : 0);
				foreach (Touch item in activeTouches)
				{
					if (num < item.tapCount)
					{
						num = item.tapCount;
					}
				}
				return num;
			}
		}

		protected Vector2 Position
		{
			get
			{
				ReadOnlyArray<Touch> activeTouches = Touch.activeTouches;
				if (activeTouches.Count <= 0)
				{
					return Vector2.one * -1f;
				}
				return activeTouches[activeTouches.Count - 1].screenPosition;
			}
		}

		public override void OnStartup()
		{
			base.OnStartup();
			Singleton<InputManager>.Instance.RequireEnhancedTouchInput();
		}
	}
}
