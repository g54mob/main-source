using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MyBox;
using UnityEngine;
using UnityEngine.Rendering;

public class DayCycleManager : NoktaSingleton<DayCycleManager>
{
	[CompilerGenerated]
	private sealed class _003CDayCycle_003Ed__82 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DayCycleManager _003C_003E4__this;

		public bool newDay;

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
		public _003CDayCycle_003Ed__82(int _003C_003E1__state)
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

	[Separator("Day Length", false)]
	[SerializeField]
	private float m_DayDurationInRealtime;

	[SerializeField]
	private int m_DayDurationInGameTime;

	[SerializeField]
	[Range(5f, 11f)]
	private int m_DayStartingTime;

	[Separator("Lighting", false)]
	[SerializeField]
	private Light m_DirectionalLight;

	[SerializeField]
	private LightingPresetsSO m_LightingPreset;

	[SerializeField]
	private Material m_WindowLightsMaterial;

	[SerializeField]
	[ColorUsage(false, true)]
	private Color m_WindowLightsEmission;

	[SerializeField]
	private float m_WindowLightsActivationHours;

	[Separator("Lens Flare", false)]
	[SerializeField]
	private LensFlareComponentSRP m_LensFlare;

	[SerializeField]
	private float m_DisablingLensFlarePercentage;

	[SerializeField]
	private float m_DisablingLensFlareSpeed;

	[Separator("Skybox", false)]
	[SerializeField]
	private Material m_SkyboxMaterial;

	[SerializeField]
	private float m_SkyboxRotationSpeed;

	[Separator("Components", false)]
	[SerializeField]
	private NextDayInteraction m_NextDayInteraction;

	private float m_DayDurationInGameTimeInSeconds;

	private float m_DayDurationInReelTimeInSeconds;

	private float m_GameTimeScale;

	private float m_CurrentTimeInFloat;

	private int m_CurrentTimeInSeconds;

	private int m_CurrentTimeInMinutes;

	private int m_CurrentTimeInHours;

	private float m_DayPercentage;

	private bool m_AM;

	private bool m_DayCycling;

	public Action OnTimeChanged;

	public Action OnFullHour;

	public Action OnDayFinished;

	public Action OnStartedNewDay;

	public Action OnDisabled;

	private Coroutine _dayCycleCoroutine;

	public NextDayInteraction M_NextDayInteraction => null;

	public int CurrentTimeInSeconds
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public float DayDurationInReelTimeInSeconds => 0f;

	public int CurrentMinute
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int CurrentHour
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int DayStartingTime => 0;

	public float DayDurationInGameTimeInSeconds => 0f;

	public float GameTimeScale => 0f;

	public bool AM => false;

	public int NumberOfDaysSinceLastPriceChange => 0;

	public int CurrentDay
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool EnableFinishingDay
	{
		set
		{
		}
	}

	public float DayPercentage
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	private bool LensFlare
	{
		set
		{
		}
	}

	public bool EndOfDay => false;

	public float CurrentTime
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float CurrentGameTime
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool DayCycling => false;

	private void Awake()
	{
	}

	public void LoadSaveProgress()
	{
	}

	private void Update()
	{
	}

	public void OnDisable()
	{
	}

	public void SyncCurrentDay_RPC(bool aM, float dayDurationInGameTimeInSeconds, float dayDurationInReelTimeInSeconds, float gameTimeScale, float currentTimeInFloat, int currentTimeInSeconds, int currentTimeInMinutes, int currentTimeInHours, float dayPercentage, int currentDay, float currentTime, bool dayCycling)
	{
	}

	public void StartNextDay()
	{
	}

	public void FinishTheDay()
	{
	}

	public void StartDayCycle(bool value)
	{
	}

	private void SetupDay()
	{
	}

	[IteratorStateMachine(typeof(_003CDayCycle_003Ed__82))]
	private IEnumerator DayCycle(bool newDay)
	{
		return null;
	}

	private void UpdateTimer()
	{
	}

	private void UpdateGameTime()
	{
	}

	private void UpdateLighting()
	{
	}

	private void OnHourChanged(float hours)
	{
	}
}
