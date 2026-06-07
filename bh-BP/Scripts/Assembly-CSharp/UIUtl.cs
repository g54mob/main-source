using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public static class UIUtl
{
	[CompilerGenerated]
	private sealed class _003CCyclePanelLeft_003Ed__26 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public RectTransform xfm;

		public float len;

		public Action onRefresh;

		private Vector2 _003CtgtMin_003E5__2;

		private Vector2 _003CtgtMax_003E5__3;

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
		public _003CCyclePanelLeft_003Ed__26(int _003C_003E1__state)
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
	private sealed class _003CCyclePanelRight_003Ed__25 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public RectTransform xfm;

		public float len;

		public Action onRefresh;

		private Vector2 _003CtgtMin_003E5__2;

		private Vector2 _003CtgtMax_003E5__3;

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
		public _003CCyclePanelRight_003Ed__25(int _003C_003E1__state)
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
	private sealed class _003CGrowUIToFillScreen_003Ed__5 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public RectTransform xfm;

		public float len;

		private float _003CstartTime_003E5__2;

		private Vector2 _003CstartAnchorMin_003E5__3;

		private Vector2 _003CstartAnchorMax_003E5__4;

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
		public _003CGrowUIToFillScreen_003Ed__5(int _003C_003E1__state)
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
	private sealed class _003CMoveAnchorsFromOffset_003Ed__17 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public RectTransform xfm;

		public Vector2 offset;

		public float len;

		public AnimationCurve curve;

		public float delay;

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
		public _003CMoveAnchorsFromOffset_003Ed__17(int _003C_003E1__state)
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
	private sealed class _003CMoveAnchorsFromOffsetTo_003Ed__20 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public RectTransform xfm;

		public Vector2 tgtAnchorMin;

		public Vector2 offset;

		public Vector2 tgtAnchorMax;

		public float len;

		public AnimationCurve curve;

		public float delay;

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
		public _003CMoveAnchorsFromOffsetTo_003Ed__20(int _003C_003E1__state)
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
	private sealed class _003CMoveAnchorsFromTo_003Ed__19 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public RectTransform xfm;

		public Vector2 startAnchorMin;

		public Vector2 startAnchorMax;

		public Vector2 tgtAnchorMin;

		public Vector2 tgtAnchorMax;

		public float len;

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
		public _003CMoveAnchorsFromTo_003Ed__19(int _003C_003E1__state)
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
	private sealed class _003CMoveAnchorsFromToOffset_003Ed__21 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public RectTransform xfm;

		public Vector2 tgtAnchorMin;

		public Vector2 tgtAnchorMax;

		public Vector2 offset;

		public float len;

		public AnimationCurve curve;

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
		public _003CMoveAnchorsFromToOffset_003Ed__21(int _003C_003E1__state)
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
	private sealed class _003CMoveAnchorsToAndRotateFromTo_003Ed__18 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public RectTransform xfm;

		public float len;

		public float rotFrom;

		public float rotTo;

		public Vector2 tgtAnchorMin;

		public Vector2 tgtAnchorMax;

		private float _003CstartTime_003E5__2;

		private Vector2 _003CstartAnchorMin_003E5__3;

		private Vector2 _003CstartAnchorMax_003E5__4;

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
		public _003CMoveAnchorsToAndRotateFromTo_003Ed__18(int _003C_003E1__state)
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
	private sealed class _003CMoveAnchorsToOffset_003Ed__16 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public RectTransform xfm;

		public Vector2 offset;

		public float len;

		public AnimationCurve curve;

		public float delay;

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
		public _003CMoveAnchorsToOffset_003Ed__16(int _003C_003E1__state)
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
	private sealed class _003CRotateXfm_003Ed__2 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public Transform xfm;

		public float len;

		public float targ;

		private Vector3 _003CstartRot_003E5__2;

		private float _003CstartTime_003E5__3;

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
		public _003CRotateXfm_003Ed__2(int _003C_003E1__state)
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
	private sealed class _003CScaleXfm_003Ed__3 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public Transform xfm;

		public float len;

		public float targ;

		private Vector3 _003CstartScale_003E5__2;

		private float _003CstartTime_003E5__3;

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
		public _003CScaleXfm_003Ed__3(int _003C_003E1__state)
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
	private sealed class _003CShakeUI_003Ed__4 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float delay;

		public RectTransform xfm;

		public float amt;

		public float len;

		private float _003CstartTime_003E5__2;

		private Vector2 _003CstartOffsetMin_003E5__3;

		private Vector2 _003CstartOffsetMax_003E5__4;

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
		public _003CShakeUI_003Ed__4(int _003C_003E1__state)
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
	private sealed class _003CTranslateByAnchor_003Ed__23 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public RectTransform xfm;

		public Vector2 amt;

		public float len;

		private float _003CstartTime_003E5__2;

		private Vector2 _003CstartAnchorMin_003E5__3;

		private Vector2 _003CstartAnchorMax_003E5__4;

		private Vector2 _003CtgtAnchorMin_003E5__5;

		private Vector2 _003CtgtAnchorMax_003E5__6;

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
		public _003CTranslateByAnchor_003Ed__23(int _003C_003E1__state)
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
	private sealed class _003CTranslateByAnchorAndRotate_003Ed__24 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public RectTransform xfm;

		public Vector2 amt;

		public float len;

		public float rotAmt;

		private float _003CstartTime_003E5__2;

		private Vector2 _003CstartAnchorMin_003E5__3;

		private Vector2 _003CstartAnchorMax_003E5__4;

		private Vector2 _003CtgtAnchorMin_003E5__5;

		private Vector2 _003CtgtAnchorMax_003E5__6;

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
		public _003CTranslateByAnchorAndRotate_003Ed__24(int _003C_003E1__state)
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
	private sealed class _003C_AnimateEdgeExpander_003Ed__40 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public Image img;

		public AnimationCurve crv;

		public float len;

		public float margin;

		private float _003CstartTime_003E5__2;

		private RectTransform _003Cxfm_003E5__3;

		private Vector2 _003CoffsetMinStart_003E5__4;

		private Vector2 _003CoffsetMaxStart_003E5__5;

		private Color _003Cc_003E5__6;

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
		public _003C_AnimateEdgeExpander_003Ed__40(int _003C_003E1__state)
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
	private sealed class _003C_AnimateOffsets_003Ed__8 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float len;

		public RectTransform xfm;

		public Vector2 startOffsetMin;

		public Vector2 tgtOffsetMin;

		public Vector2 startOffsetMax;

		public Vector2 tgtOffsetMax;

		private float _003CstartTime_003E5__2;

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
		public _003C_AnimateOffsets_003Ed__8(int _003C_003E1__state)
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
	private sealed class _003C_AnimateOffsetsFrom_003Ed__6 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public RectTransform xfm;

		public Vector2 offset;

		public float len;

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
		public _003C_AnimateOffsetsFrom_003Ed__6(int _003C_003E1__state)
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
	private sealed class _003C_AnimateOffsetsTo_003Ed__7 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public RectTransform xfm;

		public Vector2 offset;

		public float len;

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
		public _003C_AnimateOffsetsTo_003Ed__7(int _003C_003E1__state)
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
	private sealed class _003C_CenterOnSelection_003Ed__48 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public ScrollRect scrl;

		public RectTransform selXfm;

		public float len;

		private Vector2 _003CstartPos_003E5__2;

		private Vector2 _003CtgtPos_003E5__3;

		private float _003CstartTime_003E5__4;

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
		public _003C_CenterOnSelection_003Ed__48(int _003C_003E1__state)
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
	private sealed class _003C_FadeGroup_003Ed__29 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public CanvasGroup grp;

		public float len;

		public float tgtAlpha;

		private float _003CstartAlpha_003E5__2;

		private float _003CstartTime_003E5__3;

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
		public _003C_FadeGroup_003Ed__29(int _003C_003E1__state)
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
	private sealed class _003C_FadeImg_003Ed__30 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public Image img;

		public float len;

		public float tgtAlpha;

		private Color _003Cc_003E5__2;

		private float _003CstartAlpha_003E5__3;

		private float _003CstartTime_003E5__4;

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
		public _003C_FadeImg_003Ed__30(int _003C_003E1__state)
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
	private sealed class _003C_FadeText_003Ed__31 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float len;

		public TextMeshProUGUI txt;

		public Color startColor;

		public Color tgtColor;

		private float _003CstartTime_003E5__2;

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
		public _003C_FadeText_003Ed__31(int _003C_003E1__state)
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
	private sealed class _003C_MoveAnchorsTo_003Ed__15 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float delay;

		public RectTransform xfm;

		public float len;

		public AnimationCurve curve;

		public Vector2 tgtAnchorMin;

		public Vector2 tgtAnchorMax;

		private float _003CstartTime_003E5__2;

		private Vector2 _003CstartAnchorMin_003E5__3;

		private Vector2 _003CstartAnchorMax_003E5__4;

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
		public _003C_MoveAnchorsTo_003Ed__15(int _003C_003E1__state)
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
	private sealed class _003C_MoveToAnchoredPos_003Ed__52 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public RectTransform xfm;

		public float len;

		public Vector2 tgtPos;

		private float _003CstartTime_003E5__2;

		private Vector2 _003CstartPos_003E5__3;

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
		public _003C_MoveToAnchoredPos_003Ed__52(int _003C_003E1__state)
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
	private sealed class _003C_MoveXfmToPos_003Ed__27 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public RectTransform xfm;

		public float len;

		public AnimationCurve crv;

		public Vector2 tgtPos;

		private Vector2 _003CstartPos_003E5__2;

		private float _003CstartTime_003E5__3;

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
		public _003C_MoveXfmToPos_003Ed__27(int _003C_003E1__state)
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
	private sealed class _003C_PulseXfm_003Ed__28 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float len;

		public RectTransform xfm;

		public float extraSize;

		private float _003CstartTime_003E5__2;

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
		public _003C_PulseXfm_003Ed__28(int _003C_003E1__state)
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
	private sealed class _003C_ScrollToBottom_003Ed__39 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public ScrollRect scroll;

		public float len;

		private float _003CstartPos_003E5__2;

		private float _003CstartTime_003E5__3;

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
		public _003C_ScrollToBottom_003Ed__39(int _003C_003E1__state)
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
	private sealed class _003C_ScrollToPos_003Ed__43 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public ScrollRect scrl;

		public float len;

		public Vector2 tgtPos;

		private Vector2 _003CstartPos_003E5__2;

		private float _003CstartTime_003E5__3;

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
		public _003C_ScrollToPos_003Ed__43(int _003C_003E1__state)
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
	private sealed class _003C_ScrollToSelection_003Ed__42 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public ScrollRect scrl;

		public CoolSelectable nextSelect;

		private float _003Clen_003E5__2;

		private Vector2 _003CstartPos_003E5__3;

		private Vector2 _003CtgtPos_003E5__4;

		private float _003CstartTime_003E5__5;

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
		public _003C_ScrollToSelection_003Ed__42(int _003C_003E1__state)
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
	private sealed class _003C_ShakeAnchoredPos_003Ed__51 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public RectTransform xfm;

		public Vector2 defaultPos;

		public float shakeAmt;

		public float shakeLen;

		private float _003CstartTime_003E5__2;

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
		public _003C_ShakeAnchoredPos_003Ed__51(int _003C_003E1__state)
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

	private static Vector3[] _scratchWorldCorners;

	public static void SetRectXfmAnchorsAndFill(RectTransform xfm, Vector2 anchorMin, Vector2 anchorMax)
	{
	}

	public static void CopyRectXfm(RectTransform from, RectTransform to)
	{
	}

	[IteratorStateMachine(typeof(_003CRotateXfm_003Ed__2))]
	public static IEnumerator<float> RotateXfm(Transform xfm, float targ, float len)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CScaleXfm_003Ed__3))]
	public static IEnumerator<float> ScaleXfm(Transform xfm, float targ, float len)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CShakeUI_003Ed__4))]
	public static IEnumerator<float> ShakeUI(RectTransform xfm, float amt, float delay, float len)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CGrowUIToFillScreen_003Ed__5))]
	public static IEnumerator<float> GrowUIToFillScreen(RectTransform xfm, float len = 0.1f)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_AnimateOffsetsFrom_003Ed__6))]
	public static IEnumerator<float> _AnimateOffsetsFrom(this RectTransform xfm, Vector2 offset, float len)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_AnimateOffsetsTo_003Ed__7))]
	public static IEnumerator<float> _AnimateOffsetsTo(this RectTransform xfm, Vector2 offset, float len)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_AnimateOffsets_003Ed__8))]
	public static IEnumerator<float> _AnimateOffsets(this RectTransform xfm, Vector2 startOffsetMin, Vector2 startOffsetMax, Vector2 tgtOffsetMin, Vector2 tgtOffsetMax, float len)
	{
		return null;
	}

	public static void SetAnchors(this RectTransform xfm, Vector2 anchorMin, Vector2 anchorMax)
	{
	}

	public static void SetAnchorMin(this RectTransform xfm, Vector2 anchorMin)
	{
	}

	public static void SetAnchorMax(this RectTransform xfm, Vector2 anchorMax)
	{
	}

	public static void SetAnchorsX(this RectTransform xfm, float xMin, float xMax)
	{
	}

	public static void SetAnchorsY(this RectTransform xfm, float yMin, float yMax)
	{
	}

	public static void SetAnchors(this MonoBehaviour xfm, Vector2 anchorMin, Vector2 anchorMax)
	{
	}

	[IteratorStateMachine(typeof(_003C_MoveAnchorsTo_003Ed__15))]
	public static IEnumerator<float> _MoveAnchorsTo(this RectTransform xfm, Vector2 tgtAnchorMin, Vector2 tgtAnchorMax, float len, AnimationCurve curve = null, float delay = 0f)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CMoveAnchorsToOffset_003Ed__16))]
	public static IEnumerator<float> MoveAnchorsToOffset(RectTransform xfm, Vector2 offset, float len, AnimationCurve curve = null, float delay = 0f)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CMoveAnchorsFromOffset_003Ed__17))]
	public static IEnumerator<float> MoveAnchorsFromOffset(RectTransform xfm, Vector2 offset, float len, AnimationCurve curve = null, float delay = 0f)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CMoveAnchorsToAndRotateFromTo_003Ed__18))]
	public static IEnumerator<float> MoveAnchorsToAndRotateFromTo(RectTransform xfm, Vector2 tgtAnchorMin, Vector2 tgtAnchorMax, float rotFrom, float rotTo, float len)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CMoveAnchorsFromTo_003Ed__19))]
	public static IEnumerator<float> MoveAnchorsFromTo(RectTransform xfm, Vector2 startAnchorMin, Vector2 startAnchorMax, Vector2 tgtAnchorMin, Vector2 tgtAnchorMax, float len)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CMoveAnchorsFromOffsetTo_003Ed__20))]
	public static IEnumerator<float> MoveAnchorsFromOffsetTo(RectTransform xfm, Vector2 offset, Vector2 tgtAnchorMin, Vector2 tgtAnchorMax, float len, AnimationCurve curve = null, float delay = 0f)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CMoveAnchorsFromToOffset_003Ed__21))]
	public static IEnumerator<float> MoveAnchorsFromToOffset(RectTransform xfm, Vector2 offset, Vector2 tgtAnchorMin, Vector2 tgtAnchorMax, float len, AnimationCurve curve = null)
	{
		return null;
	}

	public static void TranslateByAnchor(RectTransform xfm, Vector2 amt)
	{
	}

	[IteratorStateMachine(typeof(_003CTranslateByAnchor_003Ed__23))]
	public static IEnumerator<float> TranslateByAnchor(RectTransform xfm, Vector2 amt, float len)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CTranslateByAnchorAndRotate_003Ed__24))]
	public static IEnumerator<float> TranslateByAnchorAndRotate(RectTransform xfm, Vector2 amt, float rotAmt, float len)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCyclePanelRight_003Ed__25))]
	public static IEnumerator<float> CyclePanelRight(RectTransform xfm, Action onRefresh, float len)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCyclePanelLeft_003Ed__26))]
	public static IEnumerator<float> CyclePanelLeft(RectTransform xfm, Action onRefresh, float len)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_MoveXfmToPos_003Ed__27))]
	public static IEnumerator<float> _MoveXfmToPos(this RectTransform xfm, Vector2 tgtPos, float len, AnimationCurve crv = null)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_PulseXfm_003Ed__28))]
	public static IEnumerator<float> _PulseXfm(RectTransform xfm, float extraSize, float len)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_FadeGroup_003Ed__29))]
	public static IEnumerator<float> _FadeGroup(this CanvasGroup grp, float tgtAlpha, float len)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_FadeImg_003Ed__30))]
	public static IEnumerator<float> _FadeImg(this Image img, float tgtAlpha, float len)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_FadeText_003Ed__31))]
	public static IEnumerator<float> _FadeText(this TextMeshProUGUI txt, Color startColor, Color tgtColor, float len)
	{
		return null;
	}

	public static void SetXfmParent(Transform xfm, Transform parent)
	{
	}

	public static PointerEventData CreateFakePointerEvent()
	{
		return null;
	}

	public static Rect RectTransformToScreenSpace(RectTransform transform)
	{
		return default(Rect);
	}

	public static Rect RectTransformToScreenSpace(RectTransform transform, Camera cam, bool cutDecimals = false)
	{
		return default(Rect);
	}

	public static Rect CameraRectTransformToScreenSpace(RectTransform transform, Camera cam)
	{
		return default(Rect);
	}

	public static AxisEventData CreateFakeAxisEvent(MoveDirection dir)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_ScrollToBottom_003Ed__39))]
	public static IEnumerator<float> _ScrollToBottom(this ScrollRect scroll, float len)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_AnimateEdgeExpander_003Ed__40))]
	public static IEnumerator<float> _AnimateEdgeExpander(this Image img, float len, float margin, AnimationCurve crv)
	{
		return null;
	}

	public static void ScrollToSelection(this ScrollRect scrl, CoolSelectable nextSelect)
	{
	}

	[IteratorStateMachine(typeof(_003C_ScrollToSelection_003Ed__42))]
	public static IEnumerator<float> _ScrollToSelection(this ScrollRect scrl, CoolSelectable nextSelect)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_ScrollToPos_003Ed__43))]
	public static IEnumerator<float> _ScrollToPos(this ScrollRect scrl, Vector2 tgtPos, float len = 0.2f)
	{
		return null;
	}

	public static void ScrollToRect(this ScrollRect scrl, RectTransform selXfm, float paddingTop = 0f, float paddingBot = 0f)
	{
	}

	public static Vector2 GetScrollToRectPos(this ScrollRect scrl, RectTransform selXfm, float paddingTop = 0f, float paddingBot = 0f)
	{
		return default(Vector2);
	}

	public static void CenterOnSelection(this ScrollRect scrl, RectTransform selXfm)
	{
	}

	public static Vector2 GetCenteredScrollPos(this ScrollRect scrl, RectTransform selXfm)
	{
		return default(Vector2);
	}

	[IteratorStateMachine(typeof(_003C_CenterOnSelection_003Ed__48))]
	public static IEnumerator<float> _CenterOnSelection(this ScrollRect scrl, RectTransform selXfm, float len = 0.2f)
	{
		return null;
	}

	public static bool IsPointerOverUIObject()
	{
		return false;
	}

	public static bool IsPointerOverCoolButton()
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003C_ShakeAnchoredPos_003Ed__51))]
	public static IEnumerator<float> _ShakeAnchoredPos(this RectTransform xfm, Vector2 defaultPos, float shakeAmt, float shakeLen)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_MoveToAnchoredPos_003Ed__52))]
	public static IEnumerator<float> _MoveToAnchoredPos(this RectTransform xfm, Vector2 tgtPos, float len)
	{
		return null;
	}
}
