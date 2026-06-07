using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMOD.Studio;
using I2.Loc;
using MEC;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpUI : OverlayUI
{
	[CompilerGenerated]
	private sealed class _003C_AnimateBanish_003Ed__192 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelUpUI _003C_003E4__this;

		public int selIdx;

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
		public _003C_AnimateBanish_003Ed__192(int _003C_003E1__state)
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
	private sealed class _003C_AnimateCloseLevelUp_003Ed__191 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelUpUI _003C_003E4__this;

		public int selIdx;

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
		public _003C_AnimateCloseLevelUp_003Ed__191(int _003C_003E1__state)
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
	private sealed class _003C_AnimateReroll_003Ed__198 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelUpUI _003C_003E4__this;

		private int _003Ci_003E5__2;

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
		public _003C_AnimateReroll_003Ed__198(int _003C_003E1__state)
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
	private sealed class _003C_AutopickerWaitForSeconds_003Ed__250 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelUpUI _003C_003E4__this;

		public float secs;

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
		public _003C_AutopickerWaitForSeconds_003Ed__250(int _003C_003E1__state)
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
	private sealed class _003C_EnterAutopickerCursor_003Ed__248 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public Rect tgtRect;

		public LevelUpUI _003C_003E4__this;

		private Vector2 _003CvizPos_003E5__2;

		private Vector2 _003CstartPos_003E5__3;

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
		public _003C_EnterAutopickerCursor_003Ed__248(int _003C_003E1__state)
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
	private sealed class _003C_ExitAutopickerCursor_003Ed__249 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelUpUI _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private Vector2 _003CstartPos_003E5__3;

		private Vector2 _003CtgtPos_003E5__4;

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
		public _003C_ExitAutopickerCursor_003Ed__249(int _003C_003E1__state)
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
	private sealed class _003C_FlashBGSpeed_003Ed__218 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float len;

		public float startSpeed;

		public float endSpeed;

		public LevelUpUI _003C_003E4__this;

		public float flashSpeed;

		public AnimationCurve crv;

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
		public _003C_FlashBGSpeed_003Ed__218(int _003C_003E1__state)
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
	private sealed class _003C_FlashStars_003Ed__216 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float len;

		public float startAlpha;

		public float endAlpha;

		public LevelUpUI _003C_003E4__this;

		public float flashAlpha;

		public AnimationCurve crv;

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
		public _003C_FlashStars_003Ed__216(int _003C_003E1__state)
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
	private sealed class _003C_LerpBGSpeed_003Ed__220 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelUpUI _003C_003E4__this;

		public float len;

		public float tgtSpeed;

		private float _003CstartTime_003E5__2;

		private float _003CstartSpeed_003E5__3;

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
		public _003C_LerpBGSpeed_003Ed__220(int _003C_003E1__state)
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
	private sealed class _003C_RefreshDetailsContent_003Ed__243 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelUpUI _003C_003E4__this;

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
		public _003C_RefreshDetailsContent_003Ed__243(int _003C_003E1__state)
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
	private sealed class _003C_RefreshEvoPanel_003Ed__230 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelUpUI _003C_003E4__this;

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
		public _003C_RefreshEvoPanel_003Ed__230(int _003C_003E1__state)
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
	private sealed class _003C_RefreshLevelUp_003Ed__193 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelUpUI _003C_003E4__this;

		public int selIdx;

		private int _003Ci_003E5__2;

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
		public _003C_RefreshLevelUp_003Ed__193(int _003C_003E1__state)
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
	private sealed class _003C_RevealAvailComboComponents_003Ed__212 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelUpUI _003C_003E4__this;

		private int _003Cidx_003E5__2;

		private int _003Ci_003E5__3;

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
		public _003C_RevealAvailComboComponents_003Ed__212(int _003C_003E1__state)
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
	private sealed class _003C_RevealCombo_003Ed__205 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelUpUI _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private int _003Ci_003E5__3;

		private float _003CfStartTime_003E5__4;

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
		public _003C_RevealCombo_003Ed__205(int _003C_003E1__state)
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
	private sealed class _003C_RevealComboOptions_003Ed__202 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelUpUI _003C_003E4__this;

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
		public _003C_RevealComboOptions_003Ed__202(int _003C_003E1__state)
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
	private sealed class _003C_RevealEvoOptions_003Ed__206 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelUpUI _003C_003E4__this;

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
		public _003C_RevealEvoOptions_003Ed__206(int _003C_003E1__state)
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
	private sealed class _003C_RevealFreeUpgrades_003Ed__223 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelUpUI _003C_003E4__this;

		public bool isMoney;

		private float _003CstartTime_003E5__2;

		private Vector2 _003CentryDir_003E5__3;

		private float _003CfStartTime_003E5__4;

		private int _003Ci_003E5__5;

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
		public _003C_RevealFreeUpgrades_003Ed__223(int _003C_003E1__state)
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
	private sealed class _003C_RevealFusion_003Ed__225 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelUpUI _003C_003E4__this;

		private UpgradeInfo _003CevoInf_003E5__2;

		private UpgradeInfo[] _003CupgComponents_003E5__3;

		private float _003CstartTime_003E5__4;

		private int _003Ci_003E5__5;

		private float _003CfStartTime_003E5__6;

		private int _003Cidx_003E5__7;

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
		public _003C_RevealFusion_003Ed__225(int _003C_003E1__state)
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
	private sealed class _003C_RunAutopicker_003Ed__253 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelUpUI _003C_003E4__this;

		private int _003CbestIdx_003E5__2;

		private HeroCombo _003CbestCombo_003E5__3;

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
		public _003C_RunAutopicker_003Ed__253(int _003C_003E1__state)
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
	private sealed class _003C_RunEvoPollClosed_003Ed__269 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelUpUI _003C_003E4__this;

		public List<PollResult> results;

		public int totalVotes;

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
		public _003C_RunEvoPollClosed_003Ed__269(int _003C_003E1__state)
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
	private sealed class _003C_RunGamble_003Ed__208 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelUpUI _003C_003E4__this;

		private int _003Ci_003E5__2;

		private int _003Cj_003E5__3;

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
		public _003C_RunGamble_003Ed__208(int _003C_003E1__state)
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
	private sealed class _003C_RunLvlUpPollClosed_003Ed__268 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public List<PollResult> results;

		public LevelUpUI _003C_003E4__this;

		public int totalVotes;

		private float _003Clen_003E5__2;

		private float _003CstartTime_003E5__3;

		private int _003Cwinner_003E5__4;

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
		public _003C_RunLvlUpPollClosed_003Ed__268(int _003C_003E1__state)
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
	private sealed class _003C_WaitAndHoverBtn_003Ed__166 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelUpUI _003C_003E4__this;

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
		public _003C_WaitAndHoverBtn_003Ed__166(int _003C_003E1__state)
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
	private sealed class _003C_WaitForCurrentVibrationAndVibrate_003Ed__261 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LevelUpUI _003C_003E4__this;

		public float intensity;

		public float len;

		private float _003CendTime_003E5__2;

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
		public _003C_WaitForCurrentVibrationAndVibrate_003Ed__261(int _003C_003E1__state)
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

	public static LevelUpUI I;

	public PixelCanvasScaler PixCvsScaler;

	public LevelUpType Type;

	public LevelUpPage CurPage;

	private bool _isFuserRevealed;

	public SlidingPanel PanelMain;

	public Localize LocTitleMain;

	public TextMeshProUGUI TxtTitleMain;

	public LocalizationParamsManager ParamsTitle;

	public Localize LocTitleSelection;

	public SlidingPanel PanelSelection;

	public RectTransform WrapperSelectionContent;

	public CoolButton BtnViewStatsClose;

	public DetailedStatsPanel StatPanel;

	public CoolButton BtnViewStatsContinue;

	public CharInfoPanel BasicInfoPanel;

	public GameObject WrapperBasicInfo;

	public GameObject WrapperDetailedStats;

	public bool IsShowingDetailedStats;

	public CoolButton BtnStatDisplayToggle;

	public Localize LocStatDisplayToggle;

	private int[] _tmpStats;

	public GameObject WrapperLvlUpBtnPrompts;

	public CoolButton BtnPickUpgradeClose;

	public CoolButtonGroup LevelUpBtnGrp;

	public HorizontalLayoutGroup LevelUpLayoutGrp;

	private int _numUpgradeChoices;

	public LevelUpBtn[] Btns;

	public SerializedObjectPool<LevelUpStatRow> StatRowPool;

	public CharInfoPanel PickUpgradesCharPanel;

	public RectTransform WrapperCurHeroes;

	public LevelUpCurEquipItem[] CurHeroItems;

	public RectTransform WrapperCurPassives;

	public LevelUpCurEquipItem[] CurPassiveItems;

	public PetDisplayItemBattle[] CurPetItems;

	private bool _isBanishing;

	public TextMeshProUGUI TxtCurGold;

	public CoolButton BtnReroll;

	public Localize LocReroll;

	public LocalizationParamsManager ParamsReroll;

	private int _rerollCost;

	public CoolButton BtnBanish;

	public Localize LocBanish;

	public LocalizationParamsManager ParamsBanish;

	public TwitchVoteBtn BtnLvlUpTwitchVote;

	private bool _pickedFirstUpgrade;

	private int _upgradeStreak;

	private CoroutineHandle _gambleAnim;

	private bool _isAnimatingGamble;

	private bool _doneAnimatingGamble;

	private int _gambleIdx;

	public CoolButton BtnSelectUpgrade;

	public Localize LocSelectUpgrade;

	private LevelUpBtn _selectedLvlUpBtn;

	public LvlUpEquipTab CurEquipTab;

	public GameObject WrapperEquipTabNav;

	[NamedArray(typeof(LvlUpEquipTab))]
	public CoolButton[] EquipTabBtns;

	[NamedArray(typeof(LvlUpEquipTab))]
	public GameObject[] WrapperEquipTabs;

	public SlidingPanel PanelSelectionDetails;

	public ScrollRect ScrlDetails;

	public Localize LocDetailsCat;

	public LocalizationParamsManager ParamsDetailCat;

	public Localize LocDetailsName;

	public LocalizationParamsManager ParamsDetailsName;

	public LocalizationParamsManager ParamsDetailsDmg;

	public Localize LocDetailsDesc;

	public LocalizationParamsManager ParamsDetailsDesc;

	public Localize LocDetailsComboDesc1;

	public LocalizationParamsManager ParamsDetailsComboDesc1;

	public Localize LocDetailsComboDesc2;

	public LocalizationParamsManager ParamsDetailsComboDesc2;

	public Localize LocDetailsComboDetails;

	public LocalizationParamsManager ParamsDetailsComboDetails;

	public GameObject WrapperDetailsStats;

	public GameObject WrapperEvoName;

	public EquipmentEvoPanel[] DetailsEvoPanels;

	[NamedArray(typeof(LevelUpPage))]
	public GameObject[] Wrappers;

	public CoolButton BtnTreasureContinue;

	public Localize LocTreasureContinue;

	public LocalizationParamsManager ParamsTreasureContinue;

	public SlidingPanel PanelFuser;

	public CoolButton BtnGotFuserClose;

	public GameObject WrapperFuserOptions;

	public CoolSelectableWrapper SelectableFuserOptions;

	private float _fuserBGTime;

	private float _fuserBGSpeed;

	private CoroutineHandle _bgSpeedLerpAnim;

	public BtnPrompt BtnPromptFuserEncyclo;

	public FuserOptionBtn BtnFuserFreeUpgrades;

	public FuserOptionBtn BtnFuserCombo;

	public FuserOptionBtn BtnFuserEvolution;

	private FuserOptionType _selectedFuserOption;

	public RectTransform XfmFuser;

	public GameObject WrapperFuserPreviewCam;

	public FuserPickupObj PreviewFuser;

	public PartSys PartSysFuserShockwave;

	public PartSys PartSysFuserSparks;

	public PartSys PartSysFuserLargeBurst;

	public Image ImgFuserBackground;

	public Image ImgFuserBackgroundGlow;

	public FreeUpgradeItem[] FuserItems;

	public CoolButton BtnGotTreasureContinue;

	public Localize LocGotTreasureContinue;

	public LocalizationParamsManager ParamsGotTreasureContinue;

	public BtnPromptLocParams LocParamsGotTreasureContinue;

	public TextMeshProUGUI TxtGotTreasureContinue;

	public CanvasGroup GrpEvoInfo;

	public VerticalLayoutGroup VertGrpEvoInfo;

	public ScrollRect ScrlEvoInf;

	public EquipmentInfoPanel EvoInfPanel;

	private EventInstance _loopingSFX;

	private int _curEvoPage;

	public GameObject WrapperEvoPrev;

	public CoolButton BtnEvoPrev;

	public GameObject WrapperEvoNext;

	public CoolButton BtnEvoNext;

	public GameObject WrapperSelectEvo;

	public EvoSelectBtn[] EvoSelectBtns;

	public SlidingPanel EvoSelectInfoSlider;

	public EquipmentInfoPanel EvoSelectInfoPanel;

	public CoolButton BtnTouchSelectEvo;

	private int _selectedEvoIdx;

	public TwitchVoteBtn BtnEvoTwitchVote;

	private bool _isTwitchPolling;

	private bool _isAwaitingPollResults;

	private bool _receivedPollResults;

	private bool _lastPollFailed;

	private List<PollResult> _latestPollResults;

	public GameObject WrapperSelectCombo;

	public CoolSelectableWrapper SelectComboSelectable;

	public ComboSelectItem[] ComboSelectItems;

	private List<ComboSelectItem> _selectedComboBtns;

	public TwitchVoteBtn BtnComboTwitchVote;

	public AnimationCurve CrvInitialStarPulse;

	private CoroutineHandle _curFuserBGStarAnim;

	private int _numGoldGot;

	private const int kMinFuserGold = 75;

	private const int kMaxFuserGold = 150;

	public Image RendAutopickPointer;

	private bool _skipAutopick;

	private CoroutineHandle _autopickRoutine;

	private CoroutineHandle _fuserAnim;

	private CoroutineHandle _fuserXfmAnim;

	private bool _isRevealingEvo;

	private bool _isRevealingCombo;

	private bool _isRevealingFreeUpgrades;

	private List<UpgradeChoice> _availHeroUpgrades;

	private List<UpgradeChoice> _availNewHeroes;

	private List<UpgradeChoice> _availPassiveUpgrades;

	private List<UpgradeChoice> _availNewPassives;

	private List<UpgradeChoice> _availPetUpgrades;

	private List<UpgradeChoice> _availNewPetUpgrades;

	private List<UpgradeChoice> _availMerges;

	private List<HeroCombo> _availHCombos;

	private List<UpgradeChoice> _prevChoices;

	private List<UpgradeChoice> _choices;

	private List<int> _fusionChoices;

	private System.Random _rnd;

	private EvoSelectBtn _hoveredEvo;

	private const float kDefaultStarOpacity = 0.05f;

	private const float kDefaultStarSpeed = -0.05f;

	private const float kPointerLen = 0.3f;

	private float _lastVibrateTime;

	private float _lastVibrateIntensity;

	private float _lastVibrateLen;

	private CoroutineHandle _vbWaitAnim;

	private void Awake()
	{
	}

	protected override void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnResolutionChanged()
	{
	}

	private void PopulateUpgrades()
	{
	}

	private int GetTotalAvailFusions()
	{
		return 0;
	}

	private bool HasFreeUpgrades()
	{
		return false;
	}

	public void Activate(LevelUpType t)
	{
	}

	[IteratorStateMachine(typeof(_003C_WaitAndHoverBtn_003Ed__166))]
	private IEnumerator<float> _WaitAndHoverBtn()
	{
		return null;
	}

	private bool ShouldAutopick()
	{
		return false;
	}

	protected override void MyUpdate()
	{
	}

	private void OnCloseClicked()
	{
	}

	public override bool OnBPressed()
	{
		return false;
	}

	protected override void OnEntryPct(float pct)
	{
	}

	public override void OnExitPct(float pct)
	{
	}

	protected override void OnEntryComplete()
	{
	}

	private int GetNumValidComboHeroes()
	{
		return 0;
	}

	private int GetNumPossibleCombos()
	{
		return 0;
	}

	public void SetPage(LevelUpPage pg, bool force = false)
	{
	}

	public void ToggleDetailedStats(bool isOn)
	{
	}

	private void OnStatsToggled()
	{
	}

	public override void Deactivate()
	{
	}

	public override void OnExitComplete()
	{
	}

	public void SetEquipTab(LvlUpEquipTab tab)
	{
	}

	public void OnCharEquipClicked()
	{
	}

	public void OnPetEquipClicked()
	{
	}

	public void HoverBtn(LevelUpBtn bItem)
	{
	}

	private void AddRejectionStats(int selectedIdx)
	{
	}

	public void SelectBtn(LevelUpBtn btn)
	{
	}

	public void HoverEvo(EvoSelectBtn btn, bool isVisible)
	{
	}

	private void OnTouchSelectEvoClicked()
	{
	}

	public void SelectEvo(EvoSelectBtn btn)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateCloseLevelUp_003Ed__191))]
	private IEnumerator<float> _AnimateCloseLevelUp(int selIdx)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_AnimateBanish_003Ed__192))]
	private IEnumerator<float> _AnimateBanish(int selIdx)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RefreshLevelUp_003Ed__193))]
	private IEnumerator<float> _RefreshLevelUp(int selIdx)
	{
		return null;
	}

	private void RefreshRerolls()
	{
	}

	private void OnRerollClicked()
	{
	}

	private void SetBanishing(bool isBanishing)
	{
	}

	private void OnBanishClicked()
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateReroll_003Ed__198))]
	private IEnumerator<float> _AnimateReroll()
	{
		return null;
	}

	private void OnRerollHover()
	{
	}

	private void OnContinueClicked()
	{
	}

	public void SelectFuserOption(FuserOptionType opt)
	{
	}

	[IteratorStateMachine(typeof(_003C_RevealComboOptions_003Ed__202))]
	private IEnumerator<float> _RevealComboOptions()
	{
		return null;
	}

	private void ApplyCombo()
	{
	}

	private void RebuildEvoDetailsLayout()
	{
	}

	[IteratorStateMachine(typeof(_003C_RevealCombo_003Ed__205))]
	private IEnumerator<float> _RevealCombo()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RevealEvoOptions_003Ed__206))]
	private IEnumerator<float> _RevealEvoOptions()
	{
		return null;
	}

	private void HighlightBtn(int idx)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunGamble_003Ed__208))]
	private IEnumerator<float> _RunGamble()
	{
		return null;
	}

	private void CompleteGamble()
	{
	}

	private void OnSelectUpgradeClicked()
	{
	}

	private void CloseLevelUp()
	{
	}

	[IteratorStateMachine(typeof(_003C_RevealAvailComboComponents_003Ed__212))]
	private IEnumerator<float> _RevealAvailComboComponents()
	{
		return null;
	}

	private void SetStarOpacity(float alpha)
	{
	}

	private void SetStarSpeed(float speed)
	{
	}

	public void FlashStars(float startAlpha, float flashAlpha, float endAlpha, float len, AnimationCurve crv = null)
	{
	}

	[IteratorStateMachine(typeof(_003C_FlashStars_003Ed__216))]
	private IEnumerator<float> _FlashStars(float startAlpha, float flashAlpha, float endAlpha, float len, AnimationCurve crv)
	{
		return null;
	}

	public void FlashBGSpeed(float startSpeed, float flashSpeed, float endSpeed, float len, AnimationCurve crv = null)
	{
	}

	[IteratorStateMachine(typeof(_003C_FlashBGSpeed_003Ed__218))]
	private IEnumerator<float> _FlashBGSpeed(float startSpeed, float flashSpeed, float endSpeed, float len, AnimationCurve crv)
	{
		return null;
	}

	private void LerpBGSpeed(float tgtSpeed, float len)
	{
	}

	[IteratorStateMachine(typeof(_003C_LerpBGSpeed_003Ed__220))]
	private IEnumerator<float> _LerpBGSpeed(float tgtSpeed, float len)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RevealFreeUpgrades_003Ed__223))]
	private IEnumerator<float> _RevealFreeUpgrades(bool isMoney)
	{
		return null;
	}

	private void SkipFreeUpgrades()
	{
	}

	[IteratorStateMachine(typeof(_003C_RevealFusion_003Ed__225))]
	private IEnumerator<float> _RevealFusion()
	{
		return null;
	}

	public void SelectComboComponent(ComboSelectItem item)
	{
	}

	private void RefreshComboBtn()
	{
	}

	private void SkipRevealFusion()
	{
	}

	private void CheckEvoAch(UpgradeInfo evoInf)
	{
	}

	[IteratorStateMachine(typeof(_003C_RefreshEvoPanel_003Ed__230))]
	private IEnumerator<float> _RefreshEvoPanel()
	{
		return null;
	}

	public int GetIgnoreValue()
	{
		return 0;
	}

	private void ConfirmIgnoreFuser()
	{
	}

	private void ConfirmIgnoreBonus()
	{
	}

	private void RefreshCurEquipment()
	{
	}

	private LevelUpCurEquipItem GetCurUpgradeItem(UpgradeChoice c)
	{
		return null;
	}

	private LevelUpCurEquipItem GetCurUpgradeItem(UpgradeInfo inf)
	{
		return null;
	}

	private LevelUpCurEquipItem GetHeroItem(HeroType ht)
	{
		return null;
	}

	private LevelUpCurEquipItem GetPassiveItem(PassiveType pt)
	{
		return null;
	}

	private LevelUpCurEquipItem GetFreeHeroItem()
	{
		return null;
	}

	private LevelUpCurEquipItem GetFreePassiveItem()
	{
		return null;
	}

	private void OnGrpEntered(CoolButton btn)
	{
	}

	private void OnGrpNav(CoolButton btnPrev, CoolButton btnNext)
	{
	}

	[IteratorStateMachine(typeof(_003C_RefreshDetailsContent_003Ed__243))]
	private IEnumerator<float> _RefreshDetailsContent()
	{
		return null;
	}

	private void OnGrpExited(CoolButton btn)
	{
	}

	private void AddStatRows(UpgradeInfo inf, int tgtLvl)
	{
	}

	private void AddStatRow(string label, UpgradeInfo inf, int lvl, PropertyType pt, PropertyType pt2 = PropertyType.kNum)
	{
	}

	[IteratorStateMachine(typeof(_003C_EnterAutopickerCursor_003Ed__248))]
	private IEnumerator<float> _EnterAutopickerCursor(Rect tgtRect)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_ExitAutopickerCursor_003Ed__249))]
	private IEnumerator<float> _ExitAutopickerCursor()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_AutopickerWaitForSeconds_003Ed__250))]
	private IEnumerator<float> _AutopickerWaitForSeconds(float secs)
	{
		return null;
	}

	private float GetComboScore(int i, HeroCombo c)
	{
		return 0f;
	}

	private bool ShouldAutopickerPause()
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003C_RunAutopicker_003Ed__253))]
	private IEnumerator<float> _RunAutopicker()
	{
		return null;
	}

	private void OnInputTypeChanged()
	{
	}

	private void VibrateController(float intensity, float len)
	{
	}

	private void WaitForCurrentVibrationAndVibrate(float intensity, float len)
	{
	}

	[IteratorStateMachine(typeof(_003C_WaitForCurrentVibrationAndVibrate_003Ed__261))]
	private IEnumerator<float> _WaitForCurrentVibrationAndVibrate(float intensity, float len)
	{
		return null;
	}

	public void SetEvoPage(int pg)
	{
	}

	private void OnPrevEvoClicked()
	{
	}

	private void OnNextEvoClicked()
	{
	}

	private void OnLvlUpVoteClicked()
	{
	}

	private void OnEvoVoteClicked()
	{
	}

	private void OnPollClosed(List<PollResult> results, int totalVotes)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunLvlUpPollClosed_003Ed__268))]
	private IEnumerator<float> _RunLvlUpPollClosed(List<PollResult> results, int totalVotes)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunEvoPollClosed_003Ed__269))]
	private IEnumerator<float> _RunEvoPollClosed(List<PollResult> results, int totalVotes)
	{
		return null;
	}

	private void OnComboVoteClicked()
	{
	}

	private int GetHeroIdxFromSlug(string slug)
	{
		return 0;
	}
}
