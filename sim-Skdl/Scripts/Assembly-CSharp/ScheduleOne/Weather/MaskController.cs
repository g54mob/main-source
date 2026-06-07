using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

namespace ScheduleOne.Weather
{
	public class MaskController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass32_0
		{
			public AsyncGPUReadbackRequest request;

			internal bool _003CDoHeightConversionRoutine_003Eb__0()
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CDoHeightConversionRoutine_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MaskController _003C_003E4__this;

			private _003C_003Ec__DisplayClass32_0 _003C_003E8__1;

			private ComputeBuffer _003CheightBuffer_003E5__2;

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
			public _003CDoHeightConversionRoutine_003Ed__32(int _003C_003E1__state)
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

		[Header("Components")]
		[SerializeField]
		private ComputeShader _wetMaskShader;

		[SerializeField]
		private ComputeShader _maskDownsampleShader;

		[SerializeField]
		private RenderTexture _wetMaskTexture;

		[Header("General Settings")]
		[SerializeField]
		private int _worldSize;

		[SerializeField]
		[Header("Wet Mask Settings")]
		private int _wetMaskResolution;

		[SerializeField]
		private float _wetGrowthRate;

		[SerializeField]
		private float _wetDecayRate;

		[SerializeField]
		private float _sunEvapMultiplier;

		[SerializeField]
		private AnimationCurve _wetnessGrowthCurve;

		[Header("Height Settings")]
		[SerializeField]
		private Texture2D _heightMask;

		[SerializeField]
		private int _downsampledResolution;

		[SerializeField]
		private Vector2 _minMaxHeight;

		[Header("Debugging & Development")]
		[SerializeField]
		private RenderTexture _debugTexture;

		private Vector2[] _weatherVolumeOrigins;

		private float[] _weatherRainValues;

		private float[] _weatherSunValues;

		private ComputeBuffer _volumeOriginsBuffer;

		private ComputeBuffer _volumeRainBuffer;

		private ComputeBuffer _volumeSunBuffer;

		private Coroutine _heightConversionCo;

		private float[] _heightMap;

		public float WorldSize => 0f;

		public int HeightMapResolution => 0;

		public float[] HeightMap => null;

		public Vector2 MinMaxHeight => default(Vector2);

		public void Initialise(int weatherVolumeCount, float blendAmount, Vector3 weatherVolumeSize)
		{
		}

		public void RunWetMaskShader(List<WeatherVolume> weatherVolumes)
		{
		}

		public void ConvertHeightToArray()
		{
		}

		[IteratorStateMachine(typeof(_003CDoHeightConversionRoutine_003Ed__32))]
		private IEnumerator DoHeightConversionRoutine()
		{
			return null;
		}

		private void OnDestroy()
		{
		}
	}
}
