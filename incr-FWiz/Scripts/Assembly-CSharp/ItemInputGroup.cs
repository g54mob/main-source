using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using OUSystems.Basics.DataStructures;

[Serializable]
public abstract class ItemInputGroup<I> where I : ItemInputStack
{
	public List<I> Stacks;

	public bool Prepared { get; private set; }

	public bool PreviouslyPrepared { get; private set; }

	public BoolContainer Satisfied { get; private set; }

	public int TotalItemsRequired => 0;

	public int TotalItems => 0;

	public virtual bool Valid => false;

	public float SatisfiedLevel => 0f;

	public event Action AnnounceEvaluate
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

	public ItemInputGroup()
	{
	}

	public virtual void Prepare()
	{
	}

	private void OnChange(ValueUpdateData<int> date)
	{
	}

	public virtual bool CanAdd(ItemType type)
	{
		return false;
	}

	public virtual void Add(ItemType type)
	{
	}

	public virtual void Remove(ItemType type)
	{
	}

	protected virtual void Evaluate()
	{
	}
}
