using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Brewery.Environment
{
	public class FireplaceController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDelayedInitialCheck_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FireplaceController _003C_003E4__this;

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
			public _003CDelayedInitialCheck_003Ed__17(int _003C_003E1__state)
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

		[Header("Fire Visual")]
		[Tooltip("The child GameObject containing fire particles and lights. Will be enabled/disabled.")]
		[SerializeField]
		private GameObject fireVisualObject;

		[Header("Schedule")]
		[Tooltip("Hour when fireplace turns ON (0-23). Default: 18 (6pm)")]
		[SerializeField]
		[Range(0f, 23f)]
		private int turnOnHour;

		[Tooltip("Minute when fireplace turns ON (0-59).")]
		[SerializeField]
		[Range(0f, 59f)]
		private int turnOnMinute;

		[Tooltip("Hour when fireplace turns OFF (0-23). Default: 7 (7am)")]
		[SerializeField]
		[Range(0f, 23f)]
		private int turnOffHour;

		[Tooltip("Minute when fireplace turns OFF (0-59).")]
		[SerializeField]
		[Range(0f, 59f)]
		private int turnOffMinute;

		[Header("Settings")]
		[Tooltip("How often to check time (seconds). Lower = more responsive but more checks.")]
		[SerializeField]
		private float checkInterval;

		[Tooltip("Start with fire on regardless of time (useful for testing).")]
		[SerializeField]
		private bool forceOnInEditor;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private bool isFireOn;

		private float checkTimer;

		private float turnOnNormalized;

		private float turnOffNormalized;

		private AudioSource fireLoopSource;

		public bool IsFireOn => false;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedInitialCheck_003Ed__17))]
		private IEnumerator DelayedInitialCheck()
		{
			return null;
		}

		private void OnDisable()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void UpdateFireState(bool forceUpdate)
		{
		}

		private bool ShouldFireBeOn()
		{
			return false;
		}

		private void TurnOnFire()
		{
		}

		private void TurnOffFire()
		{
		}

		private void StartFireSound()
		{
		}

		private void StopFireSound()
		{
		}

		public void ForceOn()
		{
		}

		public void ForceOff()
		{
		}

		public void ResumeAutomatic()
		{
		}

		private string GetCurrentTimeString()
		{
			return null;
		}

		private void OnDrawGizmos()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		[ContextMenu("Turn On Fire")]
		private void EditorTurnOn()
		{
		}

		[ContextMenu("Turn Off Fire")]
		private void EditorTurnOff()
		{
		}
	}
}
