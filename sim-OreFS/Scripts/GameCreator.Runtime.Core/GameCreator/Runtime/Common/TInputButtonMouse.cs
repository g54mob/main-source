using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Keywords(new string[] { "Key", "Button", "Left", "Right", "Middle" })]
	public abstract class TInputButtonMouse : TInputButton
	{
		[SerializeField]
		protected MouseButton m_Button;

		protected bool WasPressedThisFrame
		{
			get
			{
				if (Mouse.current != null)
				{
					return GetButton().wasPressedThisFrame;
				}
				return false;
			}
		}

		protected bool WasReleasedThisFrame
		{
			get
			{
				if (Mouse.current != null)
				{
					return GetButton().wasReleasedThisFrame;
				}
				return false;
			}
		}

		protected bool IsPressed
		{
			get
			{
				if (Mouse.current != null)
				{
					return GetButton().IsPressed();
				}
				return false;
			}
		}

		protected int PressCount
		{
			get
			{
				if (Mouse.current == null)
				{
					return 0;
				}
				return Mouse.current.clickCount.ReadValue();
			}
		}

		private ButtonControl GetButton()
		{
			return m_Button switch
			{
				MouseButton.Left => Mouse.current.leftButton, 
				MouseButton.Right => Mouse.current.rightButton, 
				MouseButton.Middle => Mouse.current.middleButton, 
				MouseButton.Forward => Mouse.current.forwardButton, 
				MouseButton.Back => Mouse.current.backButton, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}
