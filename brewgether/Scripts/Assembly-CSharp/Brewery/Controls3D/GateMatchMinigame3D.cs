using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Stations;
using UnityEngine;

namespace Brewery.Controls3D
{
	public class GateMatchMinigame3D : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CHandleSubmitSequence_003Ed__54 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GateMatchMinigame3D _003C_003E4__this;

			public bool allCorrect;

			public bool[] dialResults;

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
			public _003CHandleSubmitSequence_003Ed__54(int _003C_003E1__state)
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

		[Header("Dials (4 dials, one per gate slot)")]
		[SerializeField]
		private ElementDial3D dial0;

		[SerializeField]
		private ElementDial3D dial1;

		[SerializeField]
		private ElementDial3D dial2;

		[SerializeField]
		private ElementDial3D dial3;

		[Header("Gate Slots (4 slots showing requirements)")]
		[SerializeField]
		private GateSlot3D gateSlot0;

		[SerializeField]
		private GateSlot3D gateSlot1;

		[SerializeField]
		private GateSlot3D gateSlot2;

		[SerializeField]
		private GateSlot3D gateSlot3;

		[Header("Candidate")]
		[SerializeField]
		private GameObject candidatePrefab;

		[SerializeField]
		private Transform candidateSpawnPoint;

		[Header("Push Button")]
		[SerializeField]
		private Button3D pushButton;

		[Header("Result Feedback")]
		[SerializeField]
		private GameObject tickPrefab;

		[SerializeField]
		private GameObject crossPrefab;

		[SerializeField]
		private Transform resultSpawnPoint;

		[Header("Result Animation")]
		[SerializeField]
		private TweenConfig resultShowAnimation;

		[SerializeField]
		private TweenConfig resultHideAnimation;

		[SerializeField]
		private float resultDisplayDuration;

		[Header("Timing")]
		[SerializeField]
		private float nextRoundDelay;

		[Header("Rewards")]
		[Tooltip("Seconds added to processing timer per correct round.")]
		[SerializeField]
		private float correctTimeReward;

		[Header("Fake Probability")]
		[Tooltip("Chance (0-1) that each gate slot shows a fake element.")]
		[SerializeField]
		[Range(0f, 1f)]
		private float fakeProbability;

		[Header("Juice")]
		[SerializeField]
		private StationJuice3D juice;

		private BaseBreweryStation activeStation;

		private bool isActive;

		private int roundsCompleted;

		private readonly int[] gateElements;

		private readonly bool[] gateFakes;

		private readonly List<GameObject> candidatePool;

		private GameObject activeCandidate;

		private readonly List<GameObject> tickPool;

		private readonly List<GameObject> crossPool;

		private GameObject activeResult;

		private int resultTweenId;

		private Coroutine resultCoroutine;

		private Coroutine roundCoroutine;

		private Vector3 tickPrefabScale;

		private Vector3 crossPrefabScale;

		public bool IsActive => false;

		public event Action<GateMatchMinigame3D> OnCorrectMatch
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

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void Bind(BaseBreweryStation station)
		{
		}

		public void Unbind()
		{
		}

		public void FullReset()
		{
		}

		private void StartRound()
		{
		}

		private void GenerateGateRequirements()
		{
		}

		private void ShowGateElements()
		{
		}

		private void ShowGateSlot(GateSlot3D slot, int index)
		{
		}

		private void HideAllGateSlots(bool animate)
		{
		}

		private void HandlePushPressed()
		{
		}

		private bool CheckAllDials()
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CHandleSubmitSequence_003Ed__54))]
		private IEnumerator HandleSubmitSequence(bool allCorrect, bool[] dialResults)
		{
			return null;
		}

		private void WiggleGateSlot(GateSlot3D slot)
		{
		}

		private bool CheckDial(ElementDial3D dial, int gateIndex)
		{
			return false;
		}

		private void ShowResult(bool correct)
		{
		}

		private void HideResult(bool animate)
		{
		}

		private GameObject GetTickFromPool()
		{
			return null;
		}

		private GameObject GetCrossFromPool()
		{
			return null;
		}

		private void SpawnCandidate()
		{
		}

		private GameObject GetCandidateFromPool()
		{
			return null;
		}

		private void RecycleCandidate()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
