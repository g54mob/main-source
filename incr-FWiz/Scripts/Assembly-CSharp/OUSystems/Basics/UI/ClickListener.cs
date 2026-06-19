using System;
using System.Runtime.CompilerServices;
using UnityEngine.EventSystems;

namespace OUSystems.Basics.UI
{
	public class ClickListener : PressListener, IPointerClickHandler, IEventSystemHandler
	{
		public event Action AnnounceClick
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

		public void OnPointerClick(PointerEventData eventData)
		{
		}

		public virtual void Click()
		{
		}
	}
}
