using System;
using System.Runtime.CompilerServices;
using System.Text;

public record PauseDialogParam(eMessageId messageId, bool isSlowMode)
{
	[CompilerGenerated]
	protected virtual Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
	}

	public eMessageId messageId { get; set; }

	public bool isSlowMode { get; set; }

	[CompilerGenerated]
	public override string ToString()
	{
		return null;
	}

	[CompilerGenerated]
	protected virtual bool PrintMembers(StringBuilder builder)
	{
		return false;
	}

	[CompilerGenerated]
	public virtual bool Equals(PauseDialogParam? other)
	{
		return false;
	}

	[CompilerGenerated]
	protected PauseDialogParam(PauseDialogParam original)
	{
	}

	[CompilerGenerated]
	public void Deconstruct(out eMessageId messageId, out bool isSlowMode)
	{
		messageId = default(eMessageId);
		isSlowMode = default(bool);
	}
}
