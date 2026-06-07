using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Stations;
using UnityEngine;

namespace Brewery.Controls3D
{
	public class BlendingMinigame3D : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CRespawnAfterDelay_003Ed__54 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BlendingMinigame3D _003C_003E4__this;

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
			public _003CRespawnAfterDelay_003Ed__54(int _003C_003E1__state)
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

		[Header("Materials (Corners)")]
		[SerializeField]
		private BlendMaterial3D yeastMaterial;

		[SerializeField]
		private BlendMaterial3D sugarMaterial;

		[SerializeField]
		private BlendMaterial3D nutrientsMaterial;

		[SerializeField]
		private BlendMaterial3D tanninMaterial;

		[Header("Blend Slots (Middle)")]
		[SerializeField]
		private BlendSlot3D slot1;

		[SerializeField]
		private BlendSlot3D slot2;

		[Header("Generate")]
		[SerializeField]
		private Button3D generateButton;

		[Header("Output")]
		[SerializeField]
		private GameObject blendOutputPrefab;

		[SerializeField]
		private Transform outputSpawnPoint;

		[Header("Candidate")]
		[SerializeField]
		private GameObject candidatePrefab;

		[SerializeField]
		private Transform candidateSpawnPoint;

		[Tooltip("Local rotation applied to spawned candidates.")]
		[SerializeField]
		private Vector3 candidateSpawnRotation;

		[Header("Rewards")]
		[Tooltip("Seconds added to processing timer per successful candidate completion.")]
		[SerializeField]
		private float candidateTimeReward;

		[Header("Timing")]
		[Tooltip("Brief delay after candidate completion before spawning the next.")]
		[SerializeField]
		private float respawnDelay;

		[Header("Milestone Popup")]
		[Tooltip("3D text object (e.g. '+1') shown on each candidate completion. Normally inactive.")]
		[SerializeField]
		private GameObject milestonePopup;

		[Tooltip("How long the popup stays visible.")]
		[SerializeField]
		private float popupDuration;

		[Tooltip("How far the popup floats upward (local Y).")]
		[SerializeField]
		private float popupFloatDistance;

		[Tooltip("Scale overshoot for the punch-in.")]
		[SerializeField]
		private float popupPunchScale;

		[Header("Juice")]
		[SerializeField]
		private StationJuice3D juice;

		private BaseBreweryStation activeStation;

		private BlendingCandidate3D activeCandidate;

		private BlendOutput3D activeOutput;

		private bool isActive;

		private Coroutine respawnCoroutine;

		private int candidatesCompleted;

		private Vector3 popupBasePos;

		private Vector3 popupBaseScale;

		private readonly List<BlendingCandidate3D> candidatePool;

		private readonly List<BlendOutput3D> outputPool;

		private static readonly BlendPairType[] AllPairs;

		public bool IsActive => false;

		public event Action<BlendingMinigame3D> OnCandidateCompleted
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

		private void CheckOutputHover()
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

		private void HandleMaterialAdd(BlendMaterial3D material)
		{
		}

		private void HandleSlotClicked(BlendSlot3D slot)
		{
		}

		private void HandleGeneratePressed()
		{
		}

		private void SpawnOutput(BlendPairType pair)
		{
		}

		private BlendOutput3D GetOutputFromPool()
		{
			return null;
		}

		private void RecycleActiveOutput()
		{
		}

		private void HandleOutputConsumed(BlendOutput3D output)
		{
		}

		private void SetInputsBlocked(bool blocked)
		{
		}

		private void SpawnCandidate()
		{
		}

		private BlendingCandidate3D GetFromPool()
		{
			return null;
		}

		private void RecycleActiveCandidate()
		{
		}

		private void HandleCandidateComplete(BlendingCandidate3D candidate)
		{
		}

		[IteratorStateMachine(typeof(_003CRespawnAfterDelay_003Ed__54))]
		private IEnumerator RespawnAfterDelay()
		{
			return null;
		}

		private void ShowMilestonePopup()
		{
		}

		private void HideMilestonePopup()
		{
		}

		private (BlendPairType, BlendPairType) GetRandomRequirements()
		{
			return default((BlendPairType, BlendPairType));
		}

		private void OnDestroy()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
