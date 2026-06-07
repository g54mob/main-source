using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace FractureField.Drones.UI
{
	public class DroneRadiusVisual : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CFadeRadius_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DroneRadiusVisual _003C_003E4__this;

			public bool fadeIn;

			private float _003CstartAlpha_003E5__2;

			private float _003CtargetAlpha_003E5__3;

			private float _003Cduration_003E5__4;

			private float _003Celapsed_003E5__5;

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
			public _003CFadeRadius_003Ed__23(int _003C_003E1__state)
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
		private sealed class _003CWaitForDroneInitialization_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DroneRadiusVisual _003C_003E4__this;

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
			public _003CWaitForDroneInitialization_003Ed__17(int _003C_003E1__state)
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
		[SerializeField]
		private DroneRadiusConfig[] radiusConfigs;

		[Header("Visual Settings")]
		[SerializeField]
		private float lineWidth;

		[SerializeField]
		private int segments;

		[SerializeField]
		private float fadeInDuration;

		[SerializeField]
		private float fadeOutDuration;

		[SerializeField]
		private float maxAlpha;

		[SerializeField]
		private float hoverDetectionRadius;

		private LineRenderer radiusRenderer;

		private Drone drone;

		private DroneController droneController;

		private bool isHovered;

		private Coroutine fadeCoroutine;

		private float currentAlpha;

		private Color baseColor;

		private DroneRadiusConfig currentConfig;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForDroneInitialization_003Ed__17))]
		private IEnumerator WaitForDroneInitialization()
		{
			return null;
		}

		private void OnDroneInitialized()
		{
		}

		private void CreateRadiusVisual()
		{
		}

		private void Update()
		{
		}

		private void HandleHoverDetection()
		{
		}

		private void StartFade(bool fadeIn)
		{
		}

		[IteratorStateMachine(typeof(_003CFadeRadius_003Ed__23))]
		private IEnumerator FadeRadius(bool fadeIn)
		{
			return null;
		}

		private void UpdateColor(float alpha)
		{
		}

		private void UpdateRadiusVisual()
		{
		}

		private float GetDroneRadius()
		{
			return 0f;
		}

		private void OnDestroy()
		{
		}
	}
}
