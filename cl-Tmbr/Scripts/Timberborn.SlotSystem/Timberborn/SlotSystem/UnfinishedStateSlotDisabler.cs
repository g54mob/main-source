using System.Collections.Immutable;
using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using UnityEngine;

namespace Timberborn.SlotSystem
{
	internal class UnfinishedStateSlotDisabler : BaseComponent, IAwakableComponent, IUnfinishedStateListener
	{
		private readonly SlotRetriever _slotRetriever;

		private ImmutableArray<Transform> _slots;

		public UnfinishedStateSlotDisabler(SlotRetriever slotRetriever)
		{
			_slotRetriever = slotRetriever;
		}

		public void Awake()
		{
			UnfinishedStateSlotDisablerSpec component = GetComponent<UnfinishedStateSlotDisablerSpec>();
			_slots = _slotRetriever.GetSlots(base.GameObject, component.SlotKeyword).ToImmutableArray();
		}

		public void OnEnterUnfinishedState()
		{
			ImmutableArray<Transform>.Enumerator enumerator = _slots.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.gameObject.SetActive(value: false);
			}
		}

		public void OnExitUnfinishedState()
		{
			ImmutableArray<Transform>.Enumerator enumerator = _slots.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.gameObject.SetActive(value: true);
			}
		}
	}
}
