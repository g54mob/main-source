using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/extension-shake/")]
	public class ProCamera2DShake : BasePC2D
	{
		[CompilerGenerated]
		private sealed class _003CApplyShakeTimedRoutine_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DShake _003C_003E4__this;

			public bool ignoreTimeScale;

			public float duration;

			public Vector2 shake;

			public Quaternion rotation;

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
			public _003CApplyShakeTimedRoutine_003Ed__44(int _003C_003E1__state)
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
		private sealed class _003CApplyShakesTimedRoutine_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DShake _003C_003E4__this;

			public float[] durations;

			public IList<Vector2> shakes;

			public IList<Quaternion> rotations;

			public bool ignoreTimeScale;

			private int _003Ccount_003E5__2;

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
			public _003CApplyShakesTimedRoutine_003Ed__43(int _003C_003E1__state)
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
		private sealed class _003CCalculateConstantShakePosition_003Ed__46 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float frequencyMin;

			public float frequencyMax;

			public float amplitudeX;

			public float amplitudeY;

			public float amplitudeZ;

			public int index;

			public ProCamera2DShake _003C_003E4__this;

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
			public _003CCalculateConstantShakePosition_003Ed__46(int _003C_003E1__state)
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
		private sealed class _003CConstantShakeRoutine_003Ed__47 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DShake _003C_003E4__this;

			public float intensity;

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
			public _003CConstantShakeRoutine_003Ed__47(int _003C_003E1__state)
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
		private sealed class _003CShakeRoutine_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DShake _003C_003E4__this;

			public bool ignoreTimeScale;

			public float smoothness;

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
			public _003CShakeRoutine_003Ed__41(int _003C_003E1__state)
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
		private sealed class _003CStopConstantShakeRoutine_003Ed__45 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DShake _003C_003E4__this;

			public float duration;

			private Vector3 _003Cvelocity_003E5__2;

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
			public _003CStopConstantShakeRoutine_003Ed__45(int _003C_003E1__state)
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

		public static string ExtensionName;

		private static ProCamera2DShake _instance;

		public Action OnShakeCompleted;

		public List<ShakePreset> ShakePresets;

		public List<ConstantShakePreset> ConstantShakePresets;

		public ConstantShakePreset StartConstantShakePreset;

		public ConstantShakePreset CurrentConstantShakePreset;

		private Transform _shakeParent;

		private List<Coroutine> _applyInfluencesCoroutines;

		private List<Coroutine> _shakeTimedCoroutines;

		private Coroutine _shakeCoroutine;

		private Vector3 _shakeVelocity;

		private List<Vector3> _shakePositions;

		private Quaternion _rotationTarget;

		private Quaternion _originalRotation;

		private float _rotationTime;

		private float _rotationVelocity;

		private List<Vector3> _influences;

		private Vector3 _influencesSum;

		private Vector3[] _constantShakePositions;

		private Vector3 _constantShakePosition;

		private bool _isConstantShaking;

		public static ProCamera2DShake Instance => null;

		public static bool Exists => false;

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void Shake(float duration, Vector2 strength, int vibrato = 10, float randomness = 0.1f, float initialAngle = -1f, Vector3 rotation = default(Vector3), float smoothness = 0.1f, bool ignoreTimeScale = false)
		{
		}

		public void Shake(int presetIndex)
		{
		}

		public void Shake(string presetName)
		{
		}

		public void Shake(ShakePreset preset)
		{
		}

		public void StopShaking()
		{
		}

		public void ConstantShake(ConstantShakePreset preset)
		{
		}

		public void ConstantShake(string presetName)
		{
		}

		public void ConstantShake(int presetIndex)
		{
		}

		public void StopConstantShaking(float duration = 0.3f)
		{
		}

		public Coroutine ApplyShakesTimed(Vector2[] shakes, Vector3[] rotations, float[] durations, float smoothness = 0.1f, bool ignoreTimeScale = false)
		{
			return null;
		}

		public void ApplyInfluenceIgnoringBoundaries(Vector2 influence)
		{
		}

		private Coroutine ApplyShakesTimed(Vector2[] shakes, Quaternion[] rotations, float[] durations, float smoothness = 0.1f, bool ignoreTimeScale = false)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CShakeRoutine_003Ed__41))]
		private IEnumerator ShakeRoutine(float smoothness, bool ignoreTimeScale = false)
		{
			return null;
		}

		private void ShakeCompleted()
		{
		}

		[IteratorStateMachine(typeof(_003CApplyShakesTimedRoutine_003Ed__43))]
		private IEnumerator ApplyShakesTimedRoutine(IList<Vector2> shakes, IList<Quaternion> rotations, float[] durations, bool ignoreTimeScale = false)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CApplyShakeTimedRoutine_003Ed__44))]
		private IEnumerator ApplyShakeTimedRoutine(Vector2 shake, Quaternion rotation, float duration, bool ignoreTimeScale = false)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CStopConstantShakeRoutine_003Ed__45))]
		private IEnumerator StopConstantShakeRoutine(float duration)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CCalculateConstantShakePosition_003Ed__46))]
		private IEnumerator CalculateConstantShakePosition(int index, float frequencyMin, float frequencyMax, float amplitudeX, float amplitudeY, float amplitudeZ)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CConstantShakeRoutine_003Ed__47))]
		private IEnumerator ConstantShakeRoutine(float intensity)
		{
			return null;
		}
	}
}
