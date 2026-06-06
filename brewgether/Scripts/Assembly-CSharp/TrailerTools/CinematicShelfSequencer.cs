using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Shelf;
using Brewery.Systems;
using InventorySystem;
using UnityEngine;

namespace TrailerTools
{
	public class CinematicShelfSequencer : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CPhaseBarrelsToBottles_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CinematicShelfSequencer _003C_003E4__this;

			private List<GameObject> _003Cbarrels_003E5__2;

			private int _003CbarrelIndex_003E5__3;

			private int _003CglobalSlotIndex_003E5__4;

			private int _003Cs_003E5__5;

			private ShelfConfig _003Cconfig_003E5__6;

			private Transform _003CshelfT_003E5__7;

			private Transform _003Ccontainer_003E5__8;

			private int _003Cslot_003E5__9;

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
			public _003CPhaseBarrelsToBottles_003Ed__32(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CPhaseBottlesToMoney_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CinematicShelfSequencer _003C_003E4__this;

			private List<GameObject> _003Cbottles_003E5__2;

			private int _003CbottleObjIndex_003E5__3;

			private int _003Cs_003E5__4;

			private ShelfConfig _003Cconfig_003E5__5;

			private Transform _003CshelfT_003E5__6;

			private Transform _003Ccontainer_003E5__7;

			private int _003CgridSize_003E5__8;

			private int _003Cslot_003E5__9;

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
			public _003CPhaseBottlesToMoney_003Ed__33(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CPhaseSpawnBarrels_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CinematicShelfSequencer _003C_003E4__this;

			private int _003Cs_003E5__2;

			private ShelfConfig _003Cconfig_003E5__3;

			private Transform _003CshelfT_003E5__4;

			private Transform _003Ccontainer_003E5__5;

			private int _003Cslot_003E5__6;

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
			public _003CPhaseSpawnBarrels_003Ed__31(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CRunSequence_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CinematicShelfSequencer _003C_003E4__this;

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
			public _003CRunSequence_003Ed__30(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CSpawnBottleGridCoroutine_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Item item;

			public ShelfConfig config;

			public Transform shelfT;

			public int slot;

			public Transform container;

			public CinematicShelfSequencer _003C_003E4__this;

			private float _003Cscale_003E5__2;

			private int _003Ccolumns_003E5__3;

			private Vector3 _003Cspacing_003E5__4;

			private int _003CmaxItems_003E5__5;

			private Vector3 _003CbaseOffsetPosition_003E5__6;

			private Quaternion _003Crotation_003E5__7;

			private int _003Ci_003E5__8;

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
			public _003CSpawnBottleGridCoroutine_003Ed__34(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CSpawnMoneyStackCoroutine_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Transform shelfT;

			public ShelfConfig config;

			public int slot;

			public CinematicShelfSequencer _003C_003E4__this;

			public Transform container;

			private GameObject _003CstackObj_003E5__2;

			private List<Transform> _003Cchildren_003E5__3;

			private List<Vector3> _003CoriginalScales_003E5__4;

			private List<Vector3> _003CoriginalPositions_003E5__5;

			private int _003Ci_003E5__6;

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
			public _003CSpawnMoneyStackCoroutine_003Ed__35(int _003C_003E1__state)
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

		[Header("Shelves (sequence order)")]
		[Tooltip("Assign shelves in the order they should animate. Each must have ShelfDisplayController + ShelfInventoryManager.")]
		[SerializeField]
		private ShelfDisplayController[] shelves;

		[Header("Money Config")]
		[SerializeField]
		private MoneyConfig moneyConfig;

		[Header("Phase Timing")]
		[Tooltip("Seconds between each barrel appearing")]
		[SerializeField]
		private float barrelInterval;

		[Tooltip("Seconds between starting each slot's bottle transition")]
		[SerializeField]
		private float bottleSlotInterval;

		[Tooltip("Seconds between starting each slot's money transition")]
		[SerializeField]
		private float moneySlotInterval;

		[Tooltip("Pause between phases (barrels -> bottles, bottles -> money)")]
		[SerializeField]
		private float phasePause;

		[Header("Spawn Animation")]
		[SerializeField]
		private float spawnDuration;

		[SerializeField]
		private float despawnDuration;

		[SerializeField]
		private float dropHeight;

		[SerializeField]
		private float scaleOvershoot;

		[Header("Stagger")]
		[Tooltip("Delay between each bottle in a grid when spawning")]
		[SerializeField]
		private float bottleStagger;

		[Tooltip("Delay between each money child when spawning")]
		[SerializeField]
		private float moneyChildStagger;

		private bool _isRunning;

		private Coroutine _sequenceCoroutine;

		private readonly List<GameObject> _spawnedObjects;

		private readonly List<Transform> _containers;

		private Item _barrelItem;

		private Item _beerItem;

		private Item _wineItem;

		private Item _spiritsItem;

		private Item _moneyItem;

		private ShelfConfig[] _configs;

		public bool IsRunning => false;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void LoadItems()
		{
		}

		public void Toggle()
		{
		}

		public void StartSequence()
		{
		}

		public void StopAndReset()
		{
		}

		[IteratorStateMachine(typeof(_003CRunSequence_003Ed__30))]
		private IEnumerator RunSequence()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPhaseSpawnBarrels_003Ed__31))]
		private IEnumerator PhaseSpawnBarrels()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPhaseBarrelsToBottles_003Ed__32))]
		private IEnumerator PhaseBarrelsToBottles()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPhaseBottlesToMoney_003Ed__33))]
		private IEnumerator PhaseBottlesToMoney()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSpawnBottleGridCoroutine_003Ed__34))]
		private IEnumerator SpawnBottleGridCoroutine(Transform shelfT, ShelfConfig config, int slot, Transform container, Item item)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSpawnMoneyStackCoroutine_003Ed__35))]
		private IEnumerator SpawnMoneyStackCoroutine(Transform shelfT, ShelfConfig config, int slot, Transform container)
		{
			return null;
		}

		private void AnimateSpawnIn(GameObject obj, Vector3 targetPos, Vector3 targetScale, float delay)
		{
		}

		private void AnimateDespawn(GameObject obj, float delay)
		{
		}

		private void AnimateMoneyChildIn(Transform child, Vector3 originalScale, Vector3 originalLocalPos, float delay)
		{
		}

		private Item GetBottleItem(int globalSlotIndex)
		{
			return null;
		}

		private void EnableBarrelDispenser(GameObject barrelObj)
		{
		}

		private void DisablePhysics(GameObject obj)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
