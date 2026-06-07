using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace MyStuff.Environment
{
	public class FlowerFireflyController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CActivateFireflies_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FlowerFireflyController _003C_003E4__this;

			private int _003Cspawned_003E5__2;

			private List<(Transform flower, int prefabIndex)>.Enumerator _003C_003E7__wrap2;

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
			public _003CActivateFireflies_003Ed__33(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CDeactivateFireflies_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FlowerFireflyController _003C_003E4__this;

			private float _003CmaxWaitTime_003E5__2;

			private float _003Celapsed_003E5__3;

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
			public _003CDeactivateFireflies_003Ed__34(int _003C_003E1__state)
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

		[Header("Configuration")]
		[Tooltip("Firefly particle effect prefabs (randomly assigned to flowers)")]
		[SerializeField]
		private List<ParticleSystem> fireflyPrefabs;

		[Tooltip("Percentage of flowers that get fireflies (0-1)")]
		[Range(0f, 1f)]
		[SerializeField]
		private float fireflyPercentage;

		[Tooltip("Height offset above flower to spawn fireflies")]
		[SerializeField]
		private float heightOffset;

		[Tooltip("Start hour for fireflies (24h format, e.g., 23 for 11 PM)")]
		[Range(0f, 23f)]
		[SerializeField]
		private int startHour;

		[Tooltip("End hour for fireflies (24h format, e.g., 5 for 5 AM)")]
		[Range(0f, 23f)]
		[SerializeField]
		private int endHour;

		[Header("Performance")]
		[Tooltip("How often to check time (seconds)")]
		[SerializeField]
		private float checkInterval;

		[Tooltip("Maximum fireflies to spawn per frame during activation")]
		[SerializeField]
		private int spawnBatchSize;

		[Tooltip("Enable distance-based culling (recommended for large flower counts)")]
		[SerializeField]
		private bool useDistanceCulling;

		[Tooltip("Distance from player within which fireflies are visible")]
		[SerializeField]
		private float cullingDistance;

		[Tooltip("How often to update distance culling (seconds)")]
		[SerializeField]
		private float cullingUpdateInterval;

		[Tooltip("Maximum active fireflies at any time (0 = unlimited)")]
		[SerializeField]
		private int maxActiveFireflies;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private List<Transform> allFlowers;

		private List<(Transform flower, int prefabIndex)> selectedFlowers;

		private int lastDayIndex;

		private Dictionary<Transform, (ParticleSystem particles, int prefabIndex)> activeFireflies;

		private Dictionary<int, Queue<ParticleSystem>> fireflyPools;

		private bool firefliesActive;

		private bool isTransitioning;

		private float lastCheckTime;

		private float lastCullingUpdateTime;

		private float startTimeNormalized;

		private float endTimeNormalized;

		private float cullingDistanceSqr;

		private Transform playerTransform;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void CollectFlowers()
		{
		}

		private void CheckTimeAndUpdateFireflies()
		{
		}

		private bool IsWithinFireflyHours()
		{
			return false;
		}

		private void UpdateDistanceCulling()
		{
		}

		private Transform FindPlayerTransform()
		{
			return null;
		}

		private void SelectFlowersForDay(int dayIndex)
		{
		}

		[IteratorStateMachine(typeof(_003CActivateFireflies_003Ed__33))]
		private IEnumerator ActivateFireflies()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDeactivateFireflies_003Ed__34))]
		private IEnumerator DeactivateFireflies()
		{
			return null;
		}

		private void PreWarmPools(int countPerType)
		{
		}

		private ParticleSystem GetFireflyFromPool(int prefabIndex)
		{
			return null;
		}

		private void ReturnFireflyToPool(ParticleSystem firefly, int prefabIndex)
		{
		}

		private ParticleSystem CreateFireflyInstance(int prefabIndex)
		{
			return null;
		}

		private void Log(string message)
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
