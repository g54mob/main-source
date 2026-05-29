using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class MenuSettingsDisplay : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CWaitForApplyResolutionInAlert_003Ed__48 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MenuSettingsDisplay _003C_003E4__this;

		private int _003Ctime_003E5__2;

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
		public _003CWaitForApplyResolutionInAlert_003Ed__48(int _003C_003E1__state)
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

	[Header("Menu Resolution")]
	public List<MenuSettingsDisplayResolution> resolutions;

	public TMP_Text viewResolution;

	public TMP_Text viewTextAcceptButton;

	public RectTransform applyResolutionButton;

	public RectTransform alertResolutionButton;

	public MenuSettingsDisplayResolution lastResolution;

	public int lastindexResolutions;

	public MenuSettingsDisplayResolution selectedResolution;

	public int nowindexResolutions;

	public string Testowa;

	[Header("Menu Window")]
	public List<string> windowMode;

	public TMP_Text viewWindowMode;

	private int nowindexWindowMode;

	private string selectedWindowMode;

	[Header("Menu Vertical Synch")]
	public List<string> verticalSynch;

	public TMP_Text viewVerticalSynch;

	private int nowindexVerticalSynch;

	private string selectedVerticalSynch;

	[Header("Menu Show FPS")]
	public List<string> showFPS;

	public TMP_Text viewShowFPS;

	public Transform FPSManager;

	public CanvasGroup viewShowFPSCanvasGroup;

	public RectTransform viewShowFPSRectTransform;

	private int nowindexShowFPS;

	private string selectedShowFPS;

	[Header("Menu Max FPS")]
	public List<int> maxFPS;

	public TMP_Text viewMaxFPS;

	public Scrollbar viewScrollbarMaxFPS;

	public int nowindexMaxFPS;

	public int selectedMaxFPS;

	private MenuSettingsListAnimView animViewMaxFPS;

	[Header("Process Profile")]
	public PostProcessProfile[] processProfile;

	[Header("Menu Gamma")]
	public TMP_Text viewGamma;

	public Scrollbar viewScrollbarGamma;

	[Header("Menu Brightness")]
	public TMP_Text viewBrightness;

	public Scrollbar viewScrollbarBrightness;

	[Header("Menu Saturation")]
	public TMP_Text viewSaturation;

	public Scrollbar viewScrollbarSaturation;

	[Header("Menu Contrast")]
	public TMP_Text viewContrast;

	public Scrollbar viewScrollbarContrast;

	private Resolution[] _resolutions;

	private Coroutine wait;

	private void Start()
	{
	}

	public void SetNextResolutionButton(int value)
	{
	}

	private void SetResolutionAction(int value, bool increment = true)
	{
	}

	public void ApplyResolutionInList()
	{
	}

	public void RevertResolutionInAlert()
	{
	}

	public void ApplyResolutionInAlert()
	{
	}

	[IteratorStateMachine(typeof(_003CWaitForApplyResolutionInAlert_003Ed__48))]
	private IEnumerator WaitForApplyResolutionInAlert()
	{
		return null;
	}

	public void SetNextWindowModeButton(int value)
	{
	}

	private void SetWindowModeAction(int value, bool increment = true)
	{
	}

	public void SetNextVerticalSynchButton(int value)
	{
	}

	private void SetNextVerticalSynchAction(int value, bool increment = true)
	{
	}

	public void SetNextShowFPSButton(int value)
	{
	}

	private void SetNextShowFPSAction(int value, bool increment = true)
	{
	}

	public void SetNextMaxFPSButton(int value)
	{
	}

	public void SetNextMaxFPSAction(int value, bool increment = true)
	{
	}

	public void ChangedScrollbarMaxFPS(float value)
	{
	}

	public void ChangeScrollbarMaxFPS(float value, bool updateScroll = false)
	{
	}

	public void SetNextGamma(float value)
	{
	}

	public void SetNextGammaAction(float value, bool increment = true)
	{
	}

	public void ChangedScrollbarGamma(float value)
	{
	}

	public void SetNextBrightness(float value)
	{
	}

	public void SetNextBrightnessAction(float value, bool increment = true)
	{
	}

	public void ChangedScrollbarBrightness(float value)
	{
	}

	public void SetNextSaturation(float value)
	{
	}

	public void SetNextSaturationAction(float value, bool increment = true)
	{
	}

	public void ChangedScrollbarSaturation(float value)
	{
	}

	public void SetNextContrast(float value)
	{
	}

	public void SetNextContrastAction(float value, bool increment = true)
	{
	}

	public void ChangedScrollbarContrast(float value)
	{
	}

	public static int AddValue(int now, int value, bool increment)
	{
		return 0;
	}

	public static float AddValue(float now, float value, bool increment)
	{
		return 0f;
	}

	public void SetResolution(int width, int height)
	{
	}

	public void SetFullScreen(bool isFullScreen)
	{
	}

	public void SetVSync(bool isVSyncEnabled)
	{
	}

	public void SetMaxFPS(int fps)
	{
	}

	public void SetGamma(float gamma)
	{
	}

	public void SetBrightness(float brightness)
	{
	}

	public void SetSaturation(float saturation)
	{
	}

	public void SetContrast(float contrast)
	{
	}

	public void SetDeflaut()
	{
	}

	public void LoadSettings()
	{
	}

	public void UpdateTranslateText()
	{
	}
}
