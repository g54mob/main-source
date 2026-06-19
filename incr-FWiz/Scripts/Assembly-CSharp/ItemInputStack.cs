using System;
using System.Runtime.CompilerServices;

[Serializable]
public abstract class ItemInputStack : ItemStack
{
	public int Demand;

	public bool Empty => false;

	public bool Satisfied => false;

	public bool Full => false;

	public abstract int Maximum { get; }

	public override int Value
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public event Action AnnounceSatisfied
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

	protected ItemInputStack(ItemType type, int count)
		: base(null, 0)
	{
	}

	public bool TryDecrement()
	{
		return false;
	}

	public bool TryIncrement()
	{
		return false;
	}
}
