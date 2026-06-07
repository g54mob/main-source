using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Gh.Tk;
using UnityEngine;

namespace Gh
{
	public class SoundOcclusionChecker : MonoBehaviour
	{
		public enum CameraOption
		{
			Tavern = 0,
			WorldMap = 1
		}

		[CompilerGenerated]
		private sealed class _003COcclusionCheck_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SoundOcclusionChecker _003C_003E4__this;

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
			public _003COcclusionCheck_003Ed__30(int _003C_003E1__state)
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

		private static float UpdateInterval;

		private const float MaxLevel = 1f;

		private const float MinLevel = 0f;

		public CameraOption listenerCamera;

		private IEnumerator _occlusionCheckRoutine;

		private CameraRigBase _listenerCameraRig;

		private GameObject _listenerObject;

		public AkGameObj owner;

		private AkAmbient _ambientObject;

		[Header("Settings")]
		[Range(0f, 10f)]
		public float obstructionOcclusionFadeInRate;

		[Range(0f, 10f)]
		public float obstructionOcclusionFadeOutRate;

		[Range(0f, 1f)]
		public float occulusionMaxScale;

		[Tooltip("The higher the number the small the unobstructed soundbox will be")]
		[Range(0f, 1f)]
		public float obstructedScreenSize;

		[Header("Target Values (ReadOnly)")]
		[SerializeField]
		private float _obstructionTargetLevel;

		[SerializeField]
		private float _occlusionTargetLevel;

		[Header("Distance from soundbox that obstruction takes to reach max obstruction")]
		[Tooltip("Value 1 is the edge of screen, 0 is soundbox. Values greater than one will be offscreen")]
		public AnimationCurve obstructionRollOffCurve;

		private static FrameCachedValue<float> _aspectedWidthHalfSize;

		private static FrameCachedValue<float> _screenWidthHalfSize;

		private static FrameCachedValue<float> _screenHeightHalfSize;

		private bool _isDirty;

		private float _previousObstructionLevel;

		private float _previousOcclusionLevel;

		[Header("Debug")]
		public bool drawSoundBoxVisuals;

		[SerializeField]
		private float _obstructionRollOff;

		private static Vector4 _alphaValue;

		private static Texture2D _debugTexture;

		private Color _debugColor;

		[field: Header("Current Values (ReadOnly)")]
		[field: SerializeField]
		public float ObstructionCurrentLevel { get; private set; }

		[field: SerializeField]
		public float OcclusionCurrentLevel { get; private set; }

		public bool ApplyToOwner { get; set; }

		private static Texture2D DebugTexture => null;

		private Color DebugColor => default(Color);

		public event EventHandler OnObstructionOcclusionChanged
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

		private void OnEnable()
		{
		}

		public void Init()
		{
		}

		private void UpdateListenerCameraRig(object sender, EventArgs e)
		{
		}

		private void UpdateListenerCameraRig()
		{
		}

		private void MarkDirty(object sender, EventArgs e)
		{
		}

		private void OnDisable()
		{
		}

		[IteratorStateMachine(typeof(_003COcclusionCheck_003Ed__30))]
		private IEnumerator OcclusionCheck()
		{
			return null;
		}

		private void UpdateObstructionOcclusionTargets()
		{
		}

		private float CalculateOverage(float screenPoint, float soundBoxRadius, float screenSizeRadius)
		{
			return 0f;
		}

		private (float, float) GetObstructionOcclusionValues(Vector3 point)
		{
			return default((float, float));
		}

		private void OnGUI()
		{
		}

		private void Update()
		{
		}

		private float CalculateFadeDelta(float current, float target)
		{
			return 0f;
		}

		private void SetLevels(float obstruction, float occlusion)
		{
		}

		private void OnDrawGizmos()
		{
		}

		private static void DrawDebugBox(Rect rect, Color color)
		{
		}
	}
}
