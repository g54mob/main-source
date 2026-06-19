using System;
using System.Runtime.CompilerServices;
using UnityEngine.EventSystems;

namespace OUSystems.Basics.UI
{
	public class PressListener : HoverListener, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		private bool _pressed;

		public bool Pressed
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public event Action AnnouncePress
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

		public event Action AnnouncePressEnd
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

		public override void OnDisable()
		{
		}

		public override void OnHoverEnd()
		{
		}

		public virtual void OnPress()
		{
		}

		public virtual void OnPressEnd()
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}
	}
}
