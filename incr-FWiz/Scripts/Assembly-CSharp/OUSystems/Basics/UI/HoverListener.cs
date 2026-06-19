using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

namespace OUSystems.Basics.UI
{
	public class HoverListener : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public bool CheckIfHoveredOnEnable;

		private bool _hovered;

		public bool Hovered
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public event Action AnnounceHover
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

		public event Action AnnounceHoverEnd
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

		public event Action<bool> AnnounceHoverState
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

		public virtual void OnHover()
		{
		}

		public virtual void OnHoverEnd()
		{
		}

		public virtual void OnEnable()
		{
		}

		public virtual void OnDisable()
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		private void CheckIfCurrentlyHovered()
		{
		}
	}
}
