using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;

public class SettingsGraphics : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAvailableRefreshRatesAfterFrame_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SettingsGraphics _003C_003E4__this;

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
		public _003CAvailableRefreshRatesAfterFrame_003Ed__32(int _003C_003E1__state)
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
	private VolumeProfile volumeProfile;

	[SerializeField]
	private bool isMainMenu;

	[Header("Resolution & Display")]
	[SerializeField]
	private TMP_Dropdown resolutionDropdown;

	[SerializeField]
	private TMP_Dropdown refreshRateDropdown;

	[SerializeField]
	private Toggle fullScreenToggle;

	[SerializeField]
	private TMP_Dropdown limitfpsDropdown;

	private Resolution[] resolutions;

	private int currentResolutionIndex;

	[Header("Quality Settings")]
	[SerializeField]
	private TMP_Dropdown qualityDropDown;

	[SerializeField]
	private TMP_Dropdown antiAliasingDropdown;

	[SerializeField]
	private TMP_Dropdown upscalingModeDropdown;

	[SerializeField]
	private GameObject upscalingModeObject;

	public bool forcedIndirectMultilierOne;

	[SerializeField]
	private CinemachineCamera virtualCamera;

	[SerializeField]
	private Slider sliderFieldOfView;

	[SerializeField]
	private TextMeshProUGUI textFieldOfViewValue;

	[SerializeField]
	private Slider sliderShadowDistance;

	[SerializeField]
	private TextMeshProUGUI textShadowDistanceValue;

	[SerializeField]
	private Slider sliderMotionBlur;

	[SerializeField]
	private TextMeshProUGUI textMotionBlurValue;

	[SerializeField]
	private Slider sliderExposure;

	[SerializeField]
	private TextMeshProUGUI textExposureValue;

	[Header("Anti-Aliasing")]
	[SerializeField]
	private Camera mainCamera;

	private HDAdditionalCameraData hdCameraData;

	private List<string> antiAliasingOptions;

	private int screenWidth;

	private int screenHeight;

	private void Start()
	{
	}

	public void SetQuality(int qualityIndex)
	{
	}

	public void SetFullScreen(bool isFullScreen)
	{
	}

	public void SetResDropDown(int resolutionIndex)
	{
	}

	private void SetResolution(int width, int height)
	{
	}

	[IteratorStateMachine(typeof(_003CAvailableRefreshRatesAfterFrame_003Ed__32))]
	private IEnumerator AvailableRefreshRatesAfterFrame()
	{
		return null;
	}

	public void AvailableRefreshRate()
	{
	}

	public void SetRefreshRate(int _refreshRate)
	{
	}

	public void LimitFrameRate(int _framerate)
	{
	}

	private void LoadSettings()
	{
	}

	public void ChangeDepthOfField(float startFarFocus, float endFarFocus)
	{
	}

	public void ResetDepthOfField()
	{
	}

	public void SetFieldOfView(float fov)
	{
	}

	public void SetShadowDistance(float distance)
	{
	}

	public void SetMotionBlur(float motion)
	{
	}

	public void SetExposure(float exposure)
	{
	}

	public void SetupAA()
	{
	}

	public void SetAntiAliasing(int index)
	{
	}

	public void SetAAQuality(int index)
	{
	}

	private bool IsDLSSSupported()
	{
		return false;
	}
}
