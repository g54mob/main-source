using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I2.Loc;
using MEC;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MaskedFTUEOverlay : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_Activate_003Ed__29 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public MaskedFTUEOverlay _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private Color _003Cc_003E5__3;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_Activate_003Ed__29(int _003C_003E1__state)
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
	private sealed class _003C_Deactivate_003Ed__31 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public MaskedFTUEOverlay _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private Color _003Cc_003E5__3;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_Deactivate_003Ed__31(int _003C_003E1__state)
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

	public static MaskedFTUEOverlay I;

	public Canvas Cvs;

	public PixelCanvasScaler PixCvsScaler;

	public Image ImgOverlay;

	public Image ImgVisible;

	public GameObject RaycastBlockers;

	public TextSizeRectFitter Fitter;

	public CanvasGroup GrpDesc;

	public Image ImgDescBacking;

	public TextMeshProUGUI TxtDesc;

	public Localize LocDesc;

	public LocalizationParamsManager ParamsDesc;

	public CoolButton BtnContinue;

	public CoolButton BtnTgt;

	private bool _isAnimating;

	private bool _isDeactivating;

	private CoroutineHandle _curAnim;

	private FTUEArgs _curArgs;

	private List<FTUEArgs> _queuedArgs;

	private const float kEntryLen = 0.25f;

	private const float kOverlayAlpha = 0.6f;

	private void Awake()
	{
	}

	public void Activate(FTUEArgs args)
	{
	}

	public void Activate(RectTransform tgtXfm, Vector2 descOffset, float descWidth, string desc, bool showBtn, string paramName = null, string paramVal = null)
	{
	}

	public void Activate(MonoBehaviour tgt, Vector2 descOffset, float descWidth, string desc, bool showBtn, string paramName = null, string paramVal = null)
	{
	}

	public void Activate(RectTransform tgtXfm, Vector2 vizOffset, Vector2 vizSize, Vector2 descOffset, float descWidth, string desc, bool showBtn, string paramName = null, string paramVal = null)
	{
	}

	public void Activate(MonoBehaviour tgt, Vector2 vizOffset, Vector2 vizSize, Vector2 descOffset, float descWidth, string desc, bool showBtn, string paramName = null, string paramVal = null)
	{
	}

	public void Activate(CoolButton tgt, Vector2 descOffset, float descWidth, string desc, bool showBtn, string paramName = null, string paramVal = null)
	{
	}

	private void RefreshVisiblePos()
	{
	}

	[IteratorStateMachine(typeof(_003C_Activate_003Ed__29))]
	private IEnumerator<float> _Activate()
	{
		return null;
	}

	public void Deactivate()
	{
	}

	[IteratorStateMachine(typeof(_003C_Deactivate_003Ed__31))]
	private IEnumerator<float> _Deactivate()
	{
		return null;
	}

	public bool IsShowing()
	{
		return false;
	}

	public bool IsAnimating()
	{
		return false;
	}

	public bool IsShowingWithBtn()
	{
		return false;
	}

	private void OnBtnClicked()
	{
	}

	public FTUEArgs GetCurArgs()
	{
		return null;
	}
}
