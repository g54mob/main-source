using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class OverlayHoverTracker : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public static bool Hovered => false;

	public static List<GameObject> HoveredUIHoverables { get; private set; }

	public static event Action AnnounceHovered
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

	public static event Action AnnounceNotHovered
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

	public void OnHover()
	{
	}

	public void OnEndHover()
	{
	}

	private void OnDisable()
	{
	}
}
