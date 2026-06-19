using System;
using System.Runtime.CompilerServices;
using OUSystems.Basics.UI;

public class ClickHoldActionHandler : HoverListener
{
	public bool CanDoOtherActionsWhileHovered;

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

	public event Action AnnounceHold
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

	public event Action AnnounceHoldStart
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

	public event Action AnnounceHoldEnd
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

	public override void OnHover()
	{
	}

	public override void OnHoverEnd()
	{
	}

	public virtual void DoClick()
	{
	}

	public virtual void DoStartHold()
	{
	}

	public virtual void DoHold()
	{
	}

	public virtual void DoStopHold()
	{
	}
}
