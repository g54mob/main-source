using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TinyGiantStudio.Text
{
	[Serializable]
	public class UIState
	{
		public enum StateEnum
		{
			normal = 0,
			hovered = 1,
			focused = 2,
			disabled = 3,
			press = 4,
			pressStart = 5,
			beingPressed = 6,
			pressComplete = 7,
			unhovered = 8,
			unfocused = 9
		}

		[SerializeField]
		public StateEnum _state;

		public StateEnum State
		{
			get
			{
				return default(StateEnum);
			}
			set
			{
			}
		}

		public event EventHandler HoverEnter
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler HoverExit
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler PressStart
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler PressComplete
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler Focused
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler Unfocused
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void CallAppropriateMethods()
		{
		}
	}
}
