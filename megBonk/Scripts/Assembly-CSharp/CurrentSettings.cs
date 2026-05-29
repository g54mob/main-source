using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Assets.Scripts.Settings___Saves.SaveFiles;
using UnityEngine;
using UnityEngine.Audio;

public class CurrentSettings : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDoUpdateResolution_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public int index;

		public CurrentSettings _003C_003E4__this;

		public int oldValue;

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
		public _003CDoUpdateResolution_003Ed__17(int _003C_003E1__state)
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
	private sealed class _003CDoUpdateTargetMonitor_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public int index;

		public CurrentSettings _003C_003E4__this;

		public int oldValue;

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
		public _003CDoUpdateTargetMonitor_003Ed__22(int _003C_003E1__state)
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
	private sealed class _003CMoveToPrimaryDisplay_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003CMoveToPrimaryDisplay_003Ed__27(int _003C_003E1__state)
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

	public AudioMixer audioMixer;

	public Material warningMaterial;

	public static CurrentSettings Instance;

	public static Action<EControllerType> A_ControllerTypeChanged;

	public static Action<string, object, object> A_SettingUpdated;

	public static Action<int> A_ResolutionChanged;

	private Resolution resolutionBeforeMonitorChange;

	private static bool firstResolutionChange;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void UpdateSave()
	{
	}

	public void BetterUpdateCfSettings(string settingName, object value, CFSettings cfSettings)
	{
	}

	private void OnSettingUpdated(string name, object value, object oldValue)
	{
	}

	private void UpdateInputDelay(int i)
	{
	}

	private void UpdateLanguage(int i)
	{
	}

	private void UpdateSkipChestAnimation(int i)
	{
	}

	private void UpdateWarningColor(int i)
	{
	}

	private void UpdateResolution(int index, int oldValue)
	{
	}

	private void UpdateMonitor(int index, int oldValue)
	{
	}

	[IteratorStateMachine(typeof(_003CDoUpdateResolution_003Ed__17))]
	private IEnumerator DoUpdateResolution(int index, int oldValue)
	{
		return null;
	}

	private void AcceptResolution(int newValue)
	{
	}

	private void RevertResolution(int oldValue)
	{
	}

	[IteratorStateMachine(typeof(_003CDoUpdateTargetMonitor_003Ed__22))]
	private IEnumerator DoUpdateTargetMonitor(int index, int oldValue)
	{
		return null;
	}

	private void AcceptTargetMonitor(int newValue)
	{
	}

	private void RevertTargetMonitor(int oldValue)
	{
	}

	private void SetResolution(int index)
	{
	}

	[IteratorStateMachine(typeof(_003CMoveToPrimaryDisplay_003Ed__27))]
	private IEnumerator MoveToPrimaryDisplay()
	{
		return null;
	}

	private void UpdateFullscreenMode(int i)
	{
	}

	private void UpdateVSync(int i)
	{
	}

	private void UpdateMaxFps(int i)
	{
	}

	private void UpdateShadowQuality(int i)
	{
	}

	private void UpdateShadowResolution(int i)
	{
	}

	private void UpdateTextureQuality(int i)
	{
	}

	private void UpdateAntiAliasing(int i)
	{
	}

	private void UpdateSoftParticles(int b)
	{
	}

	public void UpdateMixerVolume(float f, string groupVolumeName)
	{
	}

	private float SliderToDb(float sliderValue)
	{
		return 0f;
	}

	private void RefreshAudioMixer()
	{
	}
}
