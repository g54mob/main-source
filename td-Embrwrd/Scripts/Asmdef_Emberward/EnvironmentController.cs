using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_FastForwardToNight_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float curPercentage;

		public EnvironmentController _003C_003E4__this;

		private float _003Cduration_003E5__2;

		private float _003Ctime_003E5__3;

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
		public _003CCR_FastForwardToNight_003Ed__30(int _003C_003E1__state)
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
	private sealed class _003CCR_IntroFogClearEffect_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EnvironmentController _003C_003E4__this;

		public float duration;

		private float _003Ctime_003E5__2;

		private Vector2 _003CfogEndDist_003E5__3;

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
		public _003CCR_IntroFogClearEffect_003Ed__23(int _003C_003E1__state)
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

	[SerializeField]
	private Light light_SceneDirectional;

	[SerializeField]
	private Material mat_RenderFeatureSceneFog;

	[SerializeField]
	private Material mat_RenderFeatureSceneFog_CandleFlame;

	[SerializeField]
	private EnvSceneSettingData settingData_Day;

	[SerializeField]
	private EnvSceneSettingData settingData_Night;

	[SerializeField]
	private bool debug_AlwaysDayTime;

	private bool useNightEnvironment;

	private int curRoundIndex;

	private eSceneTimeType curSceneTimeType;

	private bool isInitialized;

	private Color originalFogColor;

	private Color originalGroundBorderColor;

	private GameSceneReferenceHandler gameSceneReferenceHandler;

	private bool pauseLightUpdate;

	private int currentScreenWidth;

	private int currentScreenHeight;

	public RenderTexture fogOfWarRenderTexture;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void OnShowStageAnnounce(int index, float duration)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_IntroFogClearEffect_003Ed__23))]
	private IEnumerator CR_IntroFogClearEffect(float duration)
	{
		return null;
	}

	private void OnRoundStart(int roundIndex, int totalRound)
	{
	}

	public void UpdateFogColorSetting()
	{
	}

	private void OnInitializeEnvSceneBindings(GameSceneReferenceHandler refHandler)
	{
	}

	private void OnUpdateRoundTimer(float time, float percentage)
	{
	}

	private void OnRequestPauseLightUpdate(bool isPause)
	{
	}

	private void OnRoundTimeFastForwardToNight(float curPercentage)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_FastForwardToNight_003Ed__30))]
	private IEnumerator CR_FastForwardToNight(float curPercentage)
	{
		return null;
	}

	private void SetEnvironmentValue(EnvSceneSettingData data, float t, bool isFastForward = false, bool isFirstDay = false)
	{
	}
}
