using System;
using System.Runtime.CompilerServices;

public class PacedClickHandler : ClickHoldActionHandler
{
	public float _bufferTime;

	private float _clickTimer;

	private float _lastTime;

	public event Action AnnouncePacedClick
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

	public override void DoClick()
	{
	}

	public override void DoHold()
	{
	}

	public void CompletePacedClick()
	{
	}
}
