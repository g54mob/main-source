using System;
using System.Runtime.CompilerServices;
using OUSystems.Basics.UI;
using UnityEngine;

public class BuildingEditOptionsUI : HoverListener
{
	[SerializeField]
	private SpriteRenderer _areaSpriteRenderer;

	public GameObject DestroyButton;

	public event Action AnnounceDestroy
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

	public event Action AnnounceMove
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

	public void TryDestroy()
	{
	}

	public void TryMove()
	{
	}

	public void SetToBuilding(BuildingDeconstructable building)
	{
	}
}
