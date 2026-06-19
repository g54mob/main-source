using System;
using System.Runtime.CompilerServices;
using OUSystems.Basics.UI;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIPipe : ClickListener
{
	public Pipe Pipe;

	public Image Graphic;

	public Sprite DefaultSprite;

	public Sprite SelectedSprite;

	public Sprite DisabledSprite;

	public bool Interactable;

	public bool Highlighted;

	public static event Action<UIPipe> AnnounceSelectUIPipe
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

	public static event Action<UIPipe> AnnounceHoverUIPipe
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

	public static event Action<UIPipe> AnnounceHoverEndUIPipe
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

	public abstract bool CanHandlePipe(Pipe pipe);

	public void Set(Pipe pipe)
	{
	}

	public override void Click()
	{
	}

	public override void OnHover()
	{
	}

	public override void OnHoverEnd()
	{
	}

	public abstract void HandlePipe(Pipe pipe);

	public void SetInteractable(bool interactable)
	{
	}

	public void SetHighlights(bool selected)
	{
	}

	public void Evaluate()
	{
	}
}
