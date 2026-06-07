using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gh.Tk.UI
{
	public class HoverListenerUGUI : MonoBehaviour, ITooltipProvider, ITooltipProviderOverrider, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public List<BaseInteractable3DUIView> linkedHover;

		public event EventHandler<EventArgs<bool>> HoverChanged
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

		public event EventHandler TooltipChanged
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

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		public TooltipData GetTooltipData()
		{
			return null;
		}

		public Vector3 GetTooltipPosition()
		{
			return default(Vector3);
		}

		public ITooltipProvider GetTooltipProvider()
		{
			return null;
		}
	}
}
