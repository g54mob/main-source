using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Stations;
using UnityEngine;

namespace Brewery.Controls3D
{
	public class SterilizationMinigame3D : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CRespawnAfterDelay_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SterilizationMinigame3D _003C_003E4__this;

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
			public _003CRespawnAfterDelay_003Ed__30(int _003C_003E1__state)
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

		[Header("Tools")]
		[SerializeField]
		private SterilizationTool3D brushTool;

		[SerializeField]
		private SterilizationTool3D rinseTool;

		[SerializeField]
		private SterilizationTool3D sanitizeTool;

		[SerializeField]
		private SterilizationTool3D dryTool;

		[Header("Candidate")]
		[SerializeField]
		private GameObject candidatePrefab;

		[SerializeField]
		private Transform candidateSpawnPoint;

		[Header("Rewards")]
		[Tooltip("Seconds added to processing timer per successful sanitization.")]
		[SerializeField]
		private float sanitizationTimeReward;

		[Header("Candidate Spawn Settings")]
		[Tooltip("Minimum extra contamination states beyond mandatory Unsanitized.")]
		[SerializeField]
		[Range(0f, 3f)]
		private int minExtraStates;

		[Tooltip("Maximum extra contamination states beyond mandatory Unsanitized.")]
		[SerializeField]
		[Range(0f, 3f)]
		private int maxExtraStates;

		[Header("Timing")]
		[Tooltip("Brief delay after sanitization before spawning the next candidate.")]
		[SerializeField]
		private float respawnDelay;

		[Header("Juice")]
		[SerializeField]
		private StationJuice3D juice;

		private BaseBreweryStation activeStation;

		private SterilizationCandidate3D activeCandidate;

		private bool isActive;

		private Coroutine respawnCoroutine;

		private readonly List<SterilizationCandidate3D> candidatePool;

		private SterilizationTool3D[] allTools;

		public bool IsActive => false;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void CheckToolHover()
		{
		}

		private void ApplyTool(SterilizationTool3D tool)
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

		private void SpawnCandidate()
		{
		}

		private SterilizationCandidate3D GetFromPool()
		{
			return null;
		}

		private void RecycleActiveCandidate()
		{
		}

		private void HandleCandidateSanitized(SterilizationCandidate3D candidate)
		{
		}

		[IteratorStateMachine(typeof(_003CRespawnAfterDelay_003Ed__30))]
		private IEnumerator RespawnAfterDelay()
		{
			return null;
		}

		private void OnDestroy()
		{
		}

		private float GetGrapeStompingSkillBonus()
		{
			return 0f;
		}

		private static void ShuffleList<T>(List<T> list)
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
