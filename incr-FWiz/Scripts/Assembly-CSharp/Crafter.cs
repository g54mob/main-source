using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using OUSystems.Basics.DataStructures;
using UnityEngine;

public class Crafter : BuildingBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCraftingProcessEnumerator_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Crafter _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCraftingProcessEnumerator_003Ed__43(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[SerializeField]
	private List<Recipe> _recipes;

	public Recipe CurrentRecipe;

	[SerializeField]
	private QuotaCollector _quotaCollector;

	[SerializeField]
	private CrafterUI _crafterUI;

	[SerializeField]
	private int _maxCapacity;

	[SerializeField]
	private CrafterFueler _crafterFueler;

	[SerializeField]
	private Transform _generatePoint;

	[SerializeField]
	private float _generationDist;

	[SerializeField]
	private EventReference _craftItemSound;

	private float _craftSpeedModifier;

	private float _craftProgress;

	private bool _wasFueled;

	public Action<ItemType> AnnounceCompleteItem;

	public ItemSendPipe ItemSendPipe;

	private Coroutine _craftingCoroutine;

	public List<Recipe> Recipes => null;

	[field: SerializeField]
	public Building Building { get; private set; }

	[field: SerializeField]
	public QuotaGroup CurrentQuota { get; private set; }

	public BoolContainer IsCrafting { get; private set; }

	public event Action<float> AnnounceCraftProgress
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

	public override void SetBuilding(Building building)
	{
	}

	public IEnumerable<ItemStack> GetStorageItemsForDeconstruction()
	{
		return null;
	}

	public void AddCapacity(int capacity)
	{
	}

	public override void Initiate()
	{
	}

	public override void ClearForDestroy()
	{
	}

	public void SetRecipe(Recipe recipe)
	{
	}

	private void Clear()
	{
	}

	private void InitiateCrafting()
	{
	}

	private void SubscribeToCraftingStart()
	{
	}

	private void UnsubscribeFromCraftingStart()
	{
	}

	private void StartCraftingCoroutine()
	{
	}

	[IteratorStateMachine(typeof(_003CCraftingProcessEnumerator_003Ed__43))]
	public IEnumerator CraftingProcessEnumerator()
	{
		return null;
	}

	public void DoCraftUpdate()
	{
	}

	public bool OutputItem()
	{
		return false;
	}

	public void AddCraftSpeedModifier(float rate)
	{
	}
}
