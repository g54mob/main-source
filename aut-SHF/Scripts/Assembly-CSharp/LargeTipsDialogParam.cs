using System;
using System.Runtime.CompilerServices;
using System.Text;

public record LargeTipsDialogParam(eLargeTips[] tips, bool isAllView)
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

	public eLargeTips[] tips { get; set; }

	public bool isAllView { get; set; }

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
	public virtual bool Equals(LargeTipsDialogParam? other)
	{
		return false;
	}

	[CompilerGenerated]
	protected LargeTipsDialogParam(LargeTipsDialogParam original)
	{
	}

	[CompilerGenerated]
	public void Deconstruct(out eLargeTips[] tips, out bool isAllView)
	{
		tips = null;
		isAllView = default(bool);
	}
}
