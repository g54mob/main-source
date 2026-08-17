using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Coherence;
using Coherence.Log;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using Newtonsoft.Json.Linq;
using Rewired.Integration.UnityUI;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.App.Framework;
using VampireSurvivors.App.Tools;
using VampireSurvivors.App.UI;
using VampireSurvivors.App.UI.Twitch;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.UI;

public class LevelUpPage : BaseUIPage
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<LevelUpItemUI, bool> _003C_003E9__144_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CChooseRandomLimitBreak_003Eb__144_0(LevelUpItemUI uiPanel)
		{
			bool flag = ((UnityEngine.Object)uiPanel).m_CachedPtr == (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 43 ConditionalJump @-1, v51 @ ZF_v5 (System.Boolean) --- -1 Nop");
			/*Error: End of method reached without returning.*/;
		}
	}

	private sealed class _003C_003Ec__DisplayClass102_0
	{
		public LevelUpItemUI v;

		internal bool _003CCanCharacterReceivePass_003Eb__0(Equipment x)
		{
			//IL_007f: Expected I4, but got O
			//IL_005d: Expected O, but got I4
			if ((object)x != null)
			{
				LevelUpItemUI levelUpItemUI = v;
				if ((object)v != null)
				{
					object obj = x._equipmentType - levelUpItemUI._type;
					return obj == null;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CCanCharacterReceivePass_003Eb__1(Equipment x)
		{
			//IL_007f: Expected I4, but got O
			//IL_005d: Expected O, but got I4
			if ((object)x != null)
			{
				LevelUpItemUI levelUpItemUI = v;
				if ((object)v != null)
				{
					object obj = x._equipmentType - levelUpItemUI._type;
					return obj == null;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass105_0
	{
		public LevelUpItemUI v;

		internal bool _003CPerformPass_003Eb__0(Equipment x)
		{
			//IL_007f: Expected I4, but got O
			//IL_005d: Expected O, but got I4
			if ((object)x != null)
			{
				LevelUpItemUI levelUpItemUI = v;
				if ((object)v != null)
				{
					object obj = x._equipmentType - levelUpItemUI._type;
					return obj == null;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CPerformPass_003Eb__1(Equipment x)
		{
			//IL_007f: Expected I4, but got O
			//IL_005d: Expected O, but got I4
			if ((object)x != null)
			{
				LevelUpItemUI levelUpItemUI = v;
				if ((object)v != null)
				{
					object obj = x._equipmentType - levelUpItemUI._type;
					return obj == null;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass129_0
	{
		public RectTransform b;

		internal void _003CTweenButtonIn_003Eb__0()
		{
			Button component = b.GetComponent<Button>();
			component.enabled = true;
			Button component2 = b.GetComponent<Button>();
			component2.interactable = true;
		}
	}

	private sealed class _003C_003Ec__DisplayClass140_0
	{
		public WeaponType weaponType;

		internal bool _003CSpawnLimitBreak_003Eb__0(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - weaponType;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass141_0
	{
		public WeaponType t;

		internal bool _003CAddEvoSpritesForPlayer_003Eb__0(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - t;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CAddEvoSpritesForPlayer_003Eb__1(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - t;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass95_0
	{
		public float time;

		public LevelUpPage _003C_003E4__this;

		public WeaponType type;

		internal float _003CBanishWeapon_003Eb__0()
		{
			return time;
		}

		internal void _003CBanishWeapon_003Eb__1(float x)
		{
			time = x;
		}

		internal void _003CBanishWeapon_003Eb__2()
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_007b: Expected I, but got O
			//IL_009a: Expected O, but got I
			LevelUpPage levelUpPage = _003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			levelUpPage._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
			LevelUpPage levelUpPage2 = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F560");
		}
	}

	private sealed class _003CDelaySetFooter_003Ed__86(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public LevelUpPage _003C_003E4__this;

		public bool enabled;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0078: Expected I4, but got I8
			//IL_0196: Expected I4, but got O
			//IL_0115: Expected O, but got I
			//IL_017c: Expected O, but got I
			BaseUIPage baseUIPage = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				WaitForSeconds waitForSeconds = null;
				waitForSeconds.m_Seconds = 0.4f;
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					bool active = enabled && _003C_003E4__this.IsLocalPlayerControllingUi();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdi_v1 (VampireSurvivors.UI.BaseUIPage)+E0]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdi_v1 (VampireSurvivors.UI.BaseUIPage)+E0]");
						((GameObject)0).SetActive(active);
						bool active2;
						if (!enabled)
						{
							active2 = false;
						}
						else
						{
							bool flag = _003C_003E4__this.IsLocalPlayerControllingUi();
							active2 = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdi_v1 (VampireSurvivors.UI.BaseUIPage)+1D8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdi_v1 (VampireSurvivors.UI.BaseUIPage)+1D8]");
							((GameObject)0).SetActive(active2);
							return false;
						}
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CForceLeftLayoutDelayed_003Ed__122(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public LevelUpPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_00e1: Expected I4, but got O
			LevelUpPage levelUpPage = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null || (object)levelUpPage._LeftStatsLayoutGroup == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				RectTransform component = levelUpPage._LeftStatsLayoutGroup.GetComponent<RectTransform>();
				LayoutRebuilder.ForceRebuildLayoutImmediate(component);
				Canvas.ForceUpdateCanvases();
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CSelectElementLater_003Ed__107(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public Selectable s;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_006e: Expected I4, but got I8
			//IL_00ab: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
				_003C_003E2__current = waitForEndOfFrame;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)s == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				s.Select();
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CTweenButtonsNextFrame_003Ed__128(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public LevelUpPage _003C_003E4__this;

		private float _003CskipButtonScale_003E5__2;

		private float _003CbanishButtonScale_003E5__3;

		private float _003CrerollButtonScale_003E5__4;

		private float _003CpassButtonScale_003E5__5;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_01a5: Expected I4, but got I8
			//IL_0174->IL0763: Incompatible stack heights: 17 vs 0
			LevelUpPage levelUpPage = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003CskipButtonScale_003E5__2 = 1f;
				_003CbanishButtonScale_003E5__3 = 1f;
				_003CrerollButtonScale_003E5__4 = 1f;
				_003CpassButtonScale_003E5__5 = 1f;
				if ((object)_003C_003E4__this != null && (object)levelUpPage._SkipButton != null)
				{
					Transform transform = levelUpPage._SkipButton.transform;
					bool flag = (object)transform == null;
					bool flag2 = ((ABSSequentiable)(object)transform).tweenType == TweenType.Tweener;
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected((IntPtr)(nint)((ABSSequentiable)(object)transform).tweenType, ref value);
					bool flag3 = (object)levelUpPage._BanishButton == null;
					Transform transform2 = levelUpPage._BanishButton.transform;
					bool flag4 = (object)transform2 == null;
					bool flag5 = ((ABSSequentiable)(object)transform2).tweenType == TweenType.Tweener;
					Vector3 value2 = default(Vector3);
					Transform.set_localScale_Injected((IntPtr)(nint)((ABSSequentiable)(object)transform2).tweenType, ref value2);
					bool flag6 = (object)levelUpPage._RerollButton == null;
					Transform transform3 = levelUpPage._RerollButton.transform;
					bool flag7 = (object)transform3 == null;
					bool flag8 = ((ABSSequentiable)(object)transform3).tweenType == TweenType.Tweener;
					Transform.set_localScale_Injected((IntPtr)(nint)((ABSSequentiable)(object)transform3).tweenType, ref value);
					bool flag9 = (object)levelUpPage._PassButton == null;
					Transform transform4 = levelUpPage._PassButton.transform;
					bool flag10 = (object)transform4 == null;
					bool flag11 = ((ABSSequentiable)(object)transform4).tweenType == TweenType.Tweener;
					Transform.set_localScale_Injected((IntPtr)(nint)((ABSSequentiable)(object)transform4).tweenType, ref value2);
					bool flag12 = (object)levelUpPage._LimitBreakRandomAlways == null;
					Transform transform5 = levelUpPage._LimitBreakRandomAlways.transform;
					bool flag13 = (object)transform5 == null;
					bool flag14 = ((ABSSequentiable)(object)transform5).tweenType == TweenType.Tweener;
					Transform.set_localScale_Injected((IntPtr)(nint)((ABSSequentiable)(object)transform5).tweenType, ref value);
					bool flag15 = (object)levelUpPage._LimitBreakRandomOnce == null;
					Transform transform6 = levelUpPage._LimitBreakRandomOnce.transform;
					bool flag16 = (object)transform6 == null;
					bool flag17 = ((ABSSequentiable)(object)transform6).tweenType == TweenType.Tweener;
					Transform.set_localScale_Injected((IntPtr)(nint)((ABSSequentiable)(object)transform6).tweenType, ref value2);
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_04d8;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				Sequence sequence = DOTween.Sequence();
				if ((object)_003C_003E4__this == null)
				{
					goto IL_04d8;
				}
				Sequence t = _003C_003E4__this.TweenButtonIn(levelUpPage._SkipButton, _003CskipButtonScale_003E5__2);
				if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
				{
					Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, 0f);
				}
				Sequence t2 = _003C_003E4__this.TweenButtonIn(levelUpPage._BanishButton, _003CbanishButtonScale_003E5__3);
				if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t2, false))
				{
					Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)t2, 0f);
				}
				Sequence t3 = _003C_003E4__this.TweenButtonIn(levelUpPage._RerollButton, _003CrerollButtonScale_003E5__4);
				if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t3, false))
				{
					Sequence sequence4 = Sequence.DoInsert(sequence, (Tween)t3, 0f);
				}
				Sequence t4 = _003C_003E4__this.TweenButtonIn(levelUpPage._PassButton, _003CpassButtonScale_003E5__5);
				if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t4, false))
				{
					Sequence sequence5 = Sequence.DoInsert(sequence, (Tween)t4, 0f);
				}
				Sequence t5 = _003C_003E4__this.TweenButtonIn(levelUpPage._LimitBreakRandomAlways);
				if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t5, false))
				{
					Sequence sequence6 = Sequence.DoInsert(sequence, (Tween)t5, 0f);
				}
				Sequence t6 = _003C_003E4__this.TweenButtonIn(levelUpPage._LimitBreakRandomOnce);
				if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t6, false))
				{
					Sequence sequence7 = Sequence.DoInsert(sequence, (Tween)t6, 0f);
				}
				TweenCallback onComplete = delegate
				{
					if (TwitchIntegration._sInstance.IsTwitchOn() && TwitchIntegration._sInstance.IsTwitchWorking())
					{
						_003C_003E4__this._TwitchLevelUpPanel.ShowCountdown();
					}
				};
				if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
				{
					sequence.onComplete = onComplete;
				}
			}
			return false;
			IL_04d8:
			throw new NullReferenceException();
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CWaitSelectBanish_003Ed__87(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public bool isOn;

		public LevelUpPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0073: Expected I4, but got I8
			//IL_010d: Expected I4, but got O
			LevelUpPage levelUpPage = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				bool flag = !isOn;
				_003C_003E1__state = -1;
				if (!flag)
				{
					if ((object)_003C_003E4__this != null && (object)levelUpPage._BanishButton != null)
					{
						Button component = levelUpPage._BanishButton.GetComponent<Button>();
						if ((object)component != null)
						{
							component.Select();
							goto IL_0139;
						}
					}
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
			}
			goto IL_0139;
			IL_0139:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private GameObject _luck;

	private RectTransform Container;

	private GameObject LevelUpItemPrefab;

	private Image ProgressBar;

	private RectTransform _Panel;

	private UISpriteAnimation _ExplosionVFX;

	private GameObject _SkipButton;

	private TextMeshProUGUI _SkipRemainingText;

	private GameObject _RerollButton;

	private TextMeshProUGUI _RerollRemainingText;

	private GameObject _BanishButton;

	private TextMeshProUGUI _BanishRemainingText;

	private GameObject _PassButton;

	private TextMeshProUGUI _PassRemainingText;

	private ParticleSystem _Gems;

	private GameObject _CancelButton;

	private Image _RedFadey;

	private Localize _Title;

	private UISpriteAnimation _BanishVFX;

	private GameObject _Equipment;

	private List<PauseEquipmentPanel> _EquipmentPanels;

	private GameObject _CharacterStatsPanel;

	private GameObject _LimitBreakRandomOnce;

	private GameObject _LimitBreakRandomAlways;

	private RectTransform _BanishedWeaponsContainer;

	private GameObject _BanishedWeaponPrefab;

	private ParticleEmitterManager _GemManager;

	private SpriteReel _LeftBanner;

	private SpriteReel _RightBanner;

	private VerticalLayoutGroup _LeftStatsLayoutGroup;

	private TwitchLevelUpPanel _TwitchLevelUpPanel;

	private GameObject _SuggestText;

	private SignalBus _signalBus;

	private LevelUpFactory _levelUpFactory;

	private DataManager _data;

	private GameSessionData _gameSession;

	private PlayerOptions _playerOptions;

	private LimitBreakManager _limitBreakManager;

	private bool _isBanishMode;

	private readonly List<LevelUpItemUI> _spawnedItems;

	private Dictionary<WeaponType, List<WeaponData>> _weaponData;

	private List<WeaponType> _currentWeapons;

	private List<GameObject> _banishedWeaponList;

	private Sequence _colorTween;

	private ParticleSystem _Cats;

	private bool _hasReRolls;

	private bool _hasSkips;

	private bool _hasBanish;

	private bool _canPass;

	private bool _canLimitBreak;

	private bool _isDoingALimitBreak;

	private bool _particlesBuilt;

	private List<Tween> _activeTweens;

	private bool _hasPassed;

	private bool _hasSelected;

	private Coherence.Log.Logger _logger;

	public List<LevelUpItemUI> LevelUpItems => _spawnedItems;

	public bool HasReRolls
	{
		get
		{
			return _hasReRolls;
		}
		set
		{
			_hasReRolls = value;
		}
	}

	public bool HasSkips
	{
		get
		{
			return _hasSkips;
		}
		set
		{
			_hasSkips = value;
		}
	}

	public bool HasBanish
	{
		get
		{
			return _hasBanish;
		}
		set
		{
			_hasBanish = value;
		}
	}

	public bool CanPass
	{
		get
		{
			return _canPass;
		}
		set
		{
			_canPass = value;
		}
	}

	public GameObject RerollButton => _RerollButton;

	public GameObject SkipButton => _SkipButton;

	public GameObject BanishButton => _BanishButton;

	public GameObject CancelButton => _CancelButton;

	public GameObject PassButton => _PassButton;

	private void Construct(SignalBus signalBus, LevelUpFactory levelUpFactory, DataManager data, GameSessionData session, PlayerOptions playerOptions, LimitBreakManager limitBreak)
	{
		_signalBus = signalBus;
		_levelUpFactory = levelUpFactory;
		_data = data;
		GameSessionData gameSession = default(GameSessionData);
		_gameSession = gameSession;
		PlayerOptions playerOptions2 = default(PlayerOptions);
		_playerOptions = playerOptions2;
		LimitBreakManager limitBreakManager = default(LimitBreakManager);
		_limitBreakManager = limitBreakManager;
	}

	private void OnDestroy()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Expected O, but got Unknown
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Expected O, but got Unknown
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Expected O, but got Unknown
		//IL_0488: Unknown result type (might be due to invalid IL or missing references)
		//IL_048d: Expected O, but got Unknown
		//IL_0542: Unknown result type (might be due to invalid IL or missing references)
		//IL_0547: Expected O, but got Unknown
		Action<UISignals.BanishWeaponLevelUpSignal> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9EF70");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		Action token2 = OnLevelUpReRollRequest;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rbx_v6 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v431 @ rbx_v7 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		_signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
		Action<OnlineSignals.OnlineLevelUpReRoll> token3 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F050");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ rbx_v10 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ rbx_v11 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType3 = default(Type);
		_signalBus.UnsubscribeInternal(signalType3, (object)null, (object)token3, throwIfMissing);
		Action<OnlineSignals.OnlineLevelUpPass> token4 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F130");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v631 @ rbx_v14 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rbx_v15 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj8 = default(object);
		object obj7 = obj8 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType4 = default(Type);
		_signalBus.UnsubscribeInternal(signalType4, (object)null, (object)token4, throwIfMissing);
		Action<OnlineSignals.OnlineLevelUpWithItem> token5 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F210");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v727 @ rbx_v18 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v744 @ rbx_v19 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj10 = default(object);
		object obj9 = obj10 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType5 = default(Type);
		_signalBus.UnsubscribeInternal(signalType5, (object)null, (object)token5, throwIfMissing);
		Action<OnlineSignals.OnlineLevelUpWithFriendshipAmulet> token6 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F2F0");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v823 @ rbx_v22 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v840 @ rbx_v23 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj12 = default(object);
		object obj11 = obj12 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType6 = default(Type);
		_signalBus.UnsubscribeInternal(signalType6, (object)null, (object)token6, throwIfMissing);
		Action<OnlineSignals.OnlineLevelUpWithLimitBreak> token7 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F3D0");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v919 @ rbx_v26 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v936 @ rbx_v27 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj14 = default(object);
		object obj13 = obj14 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType7 = default(Type);
		_signalBus.UnsubscribeInternal(signalType7, (object)null, (object)token7, throwIfMissing);
		Action token8 = LevelUpSkip;
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1017 @ rbx_v30 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1034 @ rbx_v31 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj16 = default(object);
		object obj15 = obj16 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType8 = default(Type);
		_signalBus.UnsubscribeInternal(signalType8, (object)null, (object)token8, throwIfMissing);
	}

	public void Reroll()
	{
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_02ab: Expected O, but got F4
		//IL_02b9: Invalid comparison between I4 and F4
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		//IL_0126: Invalid comparison between F4 and I4
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Expected O, but got Unknown
		//IL_029d: Expected O, but got I
		Button component = _RerollButton.GetComponent<Button>();
		component.enabled = false;
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		PlayerModifierStats playerStats = activeCharacter._playerStats;
		EggFloat eggFloat = playerStats._003CReRolls_003Ek__BackingField;
		float num = eggFloat._eggVal + eggFloat._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				bool flag = num == -1f / 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186CF3762h\"");
				if (flag || !(num > 0f))
				{
					goto IL_020d;
				}
			}
		}
		object obj3 = UnityEngine.Random.value;
		if (0f < playerStats._003CRecycle_003Ek__BackingField)
		{
			goto IL_020d;
		}
		EggFloat eggFloat2 = playerStats._003CReRolls_003Ek__BackingField;
		float num2 = eggFloat2._val - 1f;
		object obj4 = num2 & -2147483649L;
		if ((nint)obj4 != 2139095040)
		{
			object obj5 = num2 & -2147483649L;
			if ((nint)obj5 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186CF37F6h\"");
				if (num2 == -1f / 0f)
				{
					num2 = -3.4028235E+38f;
				}
				goto IL_02cd;
			}
		}
		num2 = 3.4028235E+38f;
		goto IL_02cd;
		IL_020d:
		GameManager core2 = GM.Core;
		if (!core2._multiplayer.IsOnlineMultiplayer)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
			List<WeaponType> currentWeapons = _levelUpFactory.RerollLevelUpPowerUps(_currentWeapons, characterControllingUi);
			_currentWeapons = currentWeapons;
			ResetLevelUpViewsAfterReRoll();
		}
		else
		{
			object instance = OnlineStageManager._instance;
			Action action = OnlineStageManager._instance.RequestLevelUpReRoll;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rbx_v4 (System.Object)+78]");
			bool flag2 = ((CoherenceSync)0).SendCommand(action, MessageTarget.AuthorityOnly);
		}
		return;
		IL_02cd:
		eggFloat2._val = num2;
		playerStats.ReRolls = eggFloat2;
		goto IL_020d;
	}

	public unsafe void SetBanishMode()
	{
		//IL_01f5: Expected O, but got Ref
		_isBanishMode = true;
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
			myPlayerInfo._isInBanishMode = true;
		}
		ParticleSystem gems = _Gems;
		if ((object)_Gems != null && ((UnityEngine.Object)gems).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = _Gems.gameObject;
			gameObject.SetActive(value: false);
		}
		if (IsLocalPlayerControllingUi())
		{
			_CancelButton.SetActive(value: true);
			Selectable component = _CancelButton.GetComponent<Selectable>();
			component.Select();
			_RerollButton.SetActive(value: false);
			_SkipButton.SetActive(value: false);
			_BanishButton.SetActive(value: false);
			_PassButton.SetActive(value: false);
		}
		PlayerOptionsData config = _playerOptions.Config;
		if (!config._003ChideXPBar_003Ek__BackingField)
		{
			_RedFadey.enabled = true;
		}
		Color color = _RedFadey.color;
		Color color2 = _RedFadey.color;
		Color color3 = _RedFadey.color;
		object obj = default(object);
		_RedFadey.color = (Color)(&obj);
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(_RedFadey, 0.3f, 0.5f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v25 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v25 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v25 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
					if ((nint)0 == 0)
					{
						_ = 2139095040;
					}
				}
			}
		}
		_Title.Term = "lang/levelup_header_ban";
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
		_luck.SetActive(value: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 619 Invalid \"Jump target not found in method: 0x186CF3E70\"");
		throw new NullReferenceException();
	}

	private void UpdateFriendshipAmuletForBanishState(bool isInBanishMode)
	{
		List<LevelUpItemUI>.Enumerator enumerator = default(List<LevelUpItemUI>.Enumerator);
		if (enumerator.MoveNext())
		{
			LevelUpItemUI levelUpItemUI = null;
			throw new NullReferenceException();
		}
	}

	public void CancelBanishMode()
	{
		_003CWaitSelectBanish_003Ed__87 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.isOn = _isBanishMode;
		Coroutine coroutine = StartCoroutine(obj);
		_isBanishMode = false;
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
			myPlayerInfo._isInBanishMode = false;
		}
		ParticleSystem gems = _Gems;
		if ((object)_Gems != null && ((UnityEngine.Object)gems).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = _Gems.gameObject;
			gameObject.SetActive(value: true);
		}
		if (IsLocalPlayerControllingUi())
		{
			_CancelButton.SetActive(value: false);
			_RerollButton.SetActive(value: true);
			_SkipButton.SetActive(value: true);
			_BanishButton.SetActive(value: true);
		}
		_RedFadey.enabled = false;
		_Title.Term = "lang/levelup_header";
		bool active = IsLocalPlayerControllingUi();
		_luck.SetActive(active);
		ValidateButtonStates();
		UpdateButtonsUI();
		UpdateFriendshipAmuletForBanishState(isInBanishMode: false);
	}

	private IEnumerator DelaySetFooter(bool enabled)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0110: Expected O, but got I4
		_003CDelaySetFooter_003Ed__86 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		if (!flag)
		{
			object obj2 = obj + 32;
			object obj3 = obj2 >> 12;
			object obj4 = obj3 & 0x1FFFFF;
			object obj5 = obj4 >> 6;
			object obj6 = obj4 & 0x3F;
			object obj7 = obj5 * 8;
			object obj8 = 6603864928L + obj7;
			do
			{
				object obj9 = 1 << (int)obj6;
				object obj10 = obj8 | obj9;
				if (obj8 == obj8)
				{
					obj8 = obj10;
				}
			}
			while (obj8 != obj8);
			obj.enabled = enabled;
			return obj;
		}
		obj.enabled = enabled;
		return obj;
	}

	private IEnumerator WaitSelectBanish(bool isOn)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0110: Expected O, but got I4
		_003CWaitSelectBanish_003Ed__87 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		if (!flag)
		{
			object obj2 = obj + 40;
			object obj3 = obj2 >> 12;
			object obj4 = obj3 & 0x1FFFFF;
			object obj5 = obj4 >> 6;
			object obj6 = obj4 & 0x3F;
			object obj7 = obj5 * 8;
			object obj8 = 6603864928L + obj7;
			do
			{
				object obj9 = 1 << (int)obj6;
				object obj10 = obj8 | obj9;
				if (obj8 == obj8)
				{
					obj8 = obj10;
				}
			}
			while (obj8 != obj8);
			obj.isOn = isOn;
			return obj;
		}
		obj.isOn = isOn;
		return obj;
	}

	public void SelectWeapon(WeaponType type, LevelUpItemUI ui)
	{
		int param = default(int);
		if (_isBanishMode)
		{
			BlockAllSelectables();
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				BanishWeapon(type, ui);
				return;
			}
			OnlineStageManager instance = OnlineStageManager._instance;
			long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
			Action<long, int> action = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5A20");
			bool flag = instance._sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, param);
		}
		else if (!_hasSelected)
		{
			GameManager core2 = GM.Core;
			VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
			if (!core2._multiplayer.IsOnlineMultiplayer)
			{
				core2.FinishLevelUpActions(type, true, (VampireSurvivors.Objects.Characters.CharacterController)null);
			}
			else
			{
				OnlineStageManager instance2 = OnlineStageManager._instance;
				long startingOnlineClientFrame2 = OnlineStageManager._instance.GetStartingOnlineClientFrame();
				Action<long, int, CoherenceSync> action2 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5950");
				object param2 = default(object);
				bool flag2 = instance2._sync.SendCommand((Action<long, int, object>)action2, MessageTarget.All, startingOnlineClientFrame2, param, param2);
			}
			BlockAllSelectables();
			_hasSelected = true;
		}
	}

	private void BlockAllSelectables()
	{
		List<LevelUpItemUI>.Enumerator enumerator = default(List<LevelUpItemUI>.Enumerator);
		if (!enumerator.MoveNext())
		{
			return;
		}
		throw new NullReferenceException();
	}

	private void BlockAllButtons()
	{
		if (_spawnedItems != null)
		{
			List<LevelUpItemUI>.Enumerator enumerator = default(List<LevelUpItemUI>.Enumerator);
			if (enumerator.MoveNext())
			{
				Component component = null;
				throw new NullReferenceException();
			}
			if ((object)_RerollButton != null)
			{
				Button component2 = _RerollButton.GetComponent<Button>();
				if ((object)component2 != null)
				{
					component2.interactable = false;
					if ((object)_PassButton != null)
					{
						Button component3 = _PassButton.GetComponent<Button>();
						if ((object)component3 != null)
						{
							component3.interactable = false;
							if ((object)_BanishButton != null)
							{
								Button component4 = _BanishButton.GetComponent<Button>();
								if ((object)component4 != null)
								{
									component4.interactable = false;
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void EnableLevelupOptions()
	{
		//IL_0074->IL0074: Incompatible stack heights: 2 vs 0
		List<LevelUpItemUI>.Enumerator enumerator = default(List<LevelUpItemUI>.Enumerator);
		while (enumerator.MoveNext())
		{
			Button component = ((Component)null).GetComponent<Button>();
			bool flag = (object)component == null;
			bool flag2 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
			Behaviour.set_enabled_Injected(((UnityEngine.Object)component).m_CachedPtr, true);
		}
	}

	private void DisableLevelupOptions()
	{
		//IL_0074->IL0074: Incompatible stack heights: 2 vs 0
		List<LevelUpItemUI>.Enumerator enumerator = default(List<LevelUpItemUI>.Enumerator);
		while (enumerator.MoveNext())
		{
			Button component = ((Component)null).GetComponent<Button>();
			bool flag = (object)component == null;
			bool flag2 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
			Behaviour.set_enabled_Injected(((UnityEngine.Object)component).m_CachedPtr, false);
		}
	}

	public void SelectLimitBreak(WeightedLimitBreak wl, int index)
	{
		//IL_008f: Expected O, but got I
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_0104: Expected O, but got I
		//IL_019c: Expected O, but got I4
		//IL_00ef: Expected O, but got I8
		if (_hasSelected)
		{
			return;
		}
		_hasSelected = true;
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
			HandleLimitBreakLevelUp(wl, characterControllingUi);
			return;
		}
		OnlineStageManager instance = OnlineStageManager._instance;
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi2 = GetCharacterControllingUi();
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi3 = GetCharacterControllingUi();
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		Action<long, int, bool, CoherenceSync> action = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ r10_v3 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		_ = OnlineStageManager._instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ r10_v3 (Il2CppMethodInfo)+4C]");
		object obj = (nint)0 >> 4;
		object obj2 = obj & 1;
		object obj3;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ r10_v3 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 4)
			{
				obj3 = 6447794656L;
				goto IL_0193;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rax_v16 (System.Action`4<System.Int64, System.Int32, System.Boolean, Coherence.Toolkit.CoherenceSync>)+10]");
		obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rax_v16 (System.Action`4<System.Int64, System.Int32, System.Boolean, Coherence.Toolkit.CoherenceSync>)+20]");
		_ = 0;
		goto IL_0193;
		IL_0193:
		object obj4 = 24;
		_ = 6447794512L;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F64C80");
	}

	private void HandleLimitBreakLevelUp(WeightedLimitBreak wl, VampireSurvivors.Objects.Characters.CharacterController receivingCharacter)
	{
		(string, object)[] args = new(string, object)[2];
		WeaponType weaponType = default(WeaponType);
		object item = weaponType;
		(string, object) tuple = ("Weapon", item);
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object item2 = default(object);
		(string, object) tuple2 = ("Index", item2);
		_ = 0;
		_logger.Info("Applying Limit Break Level Up", args);
		bool flag = GM.Core.LimitBreakWeaponUp(wl, receivingCharacter);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F4B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F560");
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
		BlockAllButtons();
	}

	public unsafe void BanishWeapon(WeaponType type, LevelUpItemUI ui)
	{
		//IL_0086: Expected I4, but got O
		//IL_00ed: Expected O, but got I
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_0781: Expected O, but got F4
		//IL_0791: Invalid comparison between F4 and I
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_01eb: Expected O, but got I
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Expected O, but got Unknown
		//IL_01bf: Invalid comparison between F4 and I4
		//IL_033d: Expected O, but got I4
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_0710: Expected O, but got I4
		//IL_0826->IL073f: Incompatible stack heights: 1 vs 0
		//IL_05cd->IL073f: Incompatible stack heights: 1 vs 0
		//IL_05fc->IL073f: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass95_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass95_0();
		if (CS_0024_003C_003E8__locals7 != null)
		{
			CS_0024_003C_003E8__locals7._003C_003E4__this = this;
			CS_0024_003C_003E8__locals7.type = type;
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				GameSessionData gameSessionData = core._gameSessionData;
				if (core._gameSessionData != null)
				{
					WeaponType weaponType = (WeaponType)gameSessionData._activeCharacter;
					if ((object)gameSessionData._activeCharacter != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v6 (VampireSurvivors.Data.WeaponType)+218]");
						WeaponType weaponType2 = WeaponType.VOID;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v6 (VampireSurvivors.Data.WeaponType)+218]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rdi_v7 (VampireSurvivors.Data.WeaponType)+98]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rdi_v7 (VampireSurvivors.Data.WeaponType)+98]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v17+14]");
								float num = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v17+10]");
								float num2 = num + 0f;
								object obj2 = num2 & -2147483649L;
								if ((nint)obj2 != 2139095040)
								{
									object obj3 = num2 & -2147483649L;
									if ((nint)obj3 <= 2139095040)
									{
										bool flag = num2 == -1f / 0f;
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186CF579Fh\"");
										if (flag || !(num2 > 0f))
										{
											goto IL_02cc;
										}
									}
								}
								object obj4 = UnityEngine.Random.value;
								float num3 = num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rdi_v7 (VampireSurvivors.Data.WeaponType)+C8]");
								if (num3 < 0f)
								{
									goto IL_02cc;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rdi_v7 (VampireSurvivors.Data.WeaponType)+98]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rdi_v7 (VampireSurvivors.Data.WeaponType)+98]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rdx_v39+10]");
									num2 = 0f - 1f;
									object obj6 = num2 & -2147483649L;
									if ((nint)obj6 != 2139095040)
									{
										object obj7 = num2 & -2147483649L;
										if ((nint)obj7 <= 2139095040)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186CF5833h\"");
											if (num2 == -1f / 0f)
											{
												num2 = -3.4028235E+38f;
											}
											goto IL_07a5;
										}
									}
									num2 = 3.4028235E+38f;
									goto IL_07a5;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0771;
		IL_0771:
		throw new NullReferenceException();
		IL_02cc:
		if (_levelUpFactory != null)
		{
			_levelUpFactory.Banish(CS_0024_003C_003E8__locals7.type);
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Banish, soundConfig, 0f, 10, time);
			if ((object)_BanishVFX != null)
			{
				Image componentInParent = _BanishVFX.GetComponentInParent<Image>();
				if (_playerOptions != null)
				{
					PlayerOptionsData config = _playerOptions.Config;
					if (config != null)
					{
						bool flag2 = !config._003CFlashingVFXEnabled_003Ek__BackingField;
						bool flag3 = !flag2;
						if ((object)componentInParent != null)
						{
							int value__ = ((WeaponType*)(&componentInParent))->value__;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v966 @ r8_v7 (System.Int32)+298] (should have been resolved before IL gen)");
							int value__2 = ((WeaponType*)(&componentInParent))->value__;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v975 @ rax_v31 (System.Int32)+2A8] (should have been resolved before IL gen)");
							if ((object)_BanishVFX != null)
							{
								_BanishVFX.Play(hideWhenDone: true);
								if ((object)_BanishVFX != null)
								{
									RectTransform component = _BanishVFX.GetComponent<RectTransform>();
									if ((object)component != null)
									{
										Transform transform = component.transform;
										LevelUpItemUI levelUpItemUI = default(LevelUpItemUI);
										if ((object)levelUpItemUI != null && (object)levelUpItemUI._Icon != null)
										{
											RectTransform rectTransform = levelUpItemUI._Icon.rectTransform;
											if ((object)transform != null)
											{
												transform.parent = rectTransform;
												if ((object)_BanishVFX != null)
												{
													RectTransform component2 = _BanishVFX.GetComponent<RectTransform>();
													if ((object)component2 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1013 @ rax_v38 (UnityEngine.RectTransform)+10]");
														bool flag4 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1013 @ rax_v38 (UnityEngine.RectTransform)+10]");
														Vector3 value = default(Vector3);
														Transform.set_localPosition_Injected((IntPtr)0, ref value);
														if ((object)_BanishVFX != null)
														{
															Transform transform2 = _BanishVFX.transform;
															Transform parent = base.transform;
															if ((object)transform2 != null)
															{
																transform2.parent = parent;
																if ((object)levelUpItemUI._Icon != null)
																{
																	levelUpItemUI._Icon.enabled = false;
																	CS_0024_003C_003E8__locals7.time = 0f;
																	DOGetter<float> getter = null;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
																	DOSetter<float> dOSetter = null;
																	float x = default(float);
																	((_003C_003Ec__DisplayClass95_0)(object)dOSetter)._003CBanishWeapon_003Eb__1(x);
																	TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 1f, 0.2f);
																	TweenCallback tweenCallback = delegate
																	{
																		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
																		//IL_0031: Expected O, but got Unknown
																		//IL_007b: Expected I, but got O
																		//IL_009a: Expected O, but got I
																		LevelUpPage levelUpPage = CS_0024_003C_003E8__locals7._003C_003E4__this;
																		nint num4 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
																		object obj9 = default(object);
																		object obj8 = obj9 + 32;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
																		IntPtr intPtr = default(IntPtr);
																		num4 = intPtr;
																		object obj10 = default(object);
																		object signal = (IntPtr)obj10;
																		bool requireDeclaration = default(bool);
																		levelUpPage._signalBus.InternalFire((Type)num4, signal, (object)null, requireDeclaration);
																		LevelUpPage levelUpPage2 = CS_0024_003C_003E8__locals7._003C_003E4__this;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F560");
																	};
																	if (tweenerCore != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1160 @ rax_v57 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
																		if ((nint)0 == 0)
																		{
																		}
																	}
																	PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
																	PlaySoundResult playSoundResult4 = SoundManager.PlaySound(SfxType.Banish, new SoundManager.SoundConfig
																	{
																		Volume = (float?)(object)1,
																		Rate = 1f
																	}, 0f, 10, time);
																	return;
																}
															}
														}
													}
													throw new NullReferenceException();
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0771;
		IL_07a5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829EE550");
		goto IL_02cc;
	}

	public void SelectItem(ItemData item, ItemType type)
	{
		//IL_0145: Expected I4, but got F4
		//IL_00c4: Expected O, but got I
		if (_hasSelected)
		{
			return;
		}
		_hasSelected = true;
		float num = default(float);
		if (type == ItemType.FRIENDSHIP)
		{
			GameManager core = GM.Core;
			if (core._multiplayer.IsOnlineMultiplayer)
			{
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, num);
				BlockAllButtons();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
				object obj = default(object);
				Action action = ((OnlineStageManager)obj).RequestFriendshipAmulet;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rax_v32 (System.Object)+78]");
				bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.AuthorityOnly);
				return;
			}
		}
		GameManager core2 = GM.Core;
		if (!core2._multiplayer.IsOnlineMultiplayer)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
			ProcessItemLevelUp(type, characterControllingUi);
			return;
		}
		OnlineStageManager instance = OnlineStageManager._instance;
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi2 = GetCharacterControllingUi();
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		Action<long, int, CoherenceSync> action2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5950");
		object param = default(object);
		bool flag2 = instance._sync.SendCommand((Action<long, int, object>)action2, MessageTarget.All, startingOnlineClientFrame, (int)num, param);
	}

	private void ProcessItemLevelUp(ItemType type, VampireSurvivors.Objects.Characters.CharacterController receivingCharacter)
	{
		GM.Core.MakeAndActivatePickup(type, receivingCharacter);
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
		characterControllingUi.IsInvul = true;
		if (0.5f > characterControllingUi._invincibilityTimer)
		{
			characterControllingUi._invincibilityTimer = 0.5f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F4B0");
		BlockAllButtons();
	}

	private void ProcessFriendshipAmuletLevelup()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
		characterControllingUi.IsInvul = true;
		if (0.5f > characterControllingUi._invincibilityTimer)
		{
			characterControllingUi._invincibilityTimer = 0.5f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F4B0");
		BlockAllButtons();
	}

	public void Skip()
	{
		//IL_009c: Expected I8, but got O
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			LevelUpSkip();
			return;
		}
		OnlineStageManager instance = OnlineStageManager._instance;
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		Action<long> action = null;
		((OnlineStageManager)(object)action).LevelUpSkipOnline((long)OnlineStageManager._instance);
		bool flag = instance._sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void LevelUpSkip()
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_00b4: Expected I, but got O
		//IL_00d3: Expected O, but got I
		//IL_008d: Expected F4, but got I4
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F560");
		GameManager core2 = GM.Core;
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool flag = default(bool);
		core2._signalBus.InternalFire((Type)num, signal, (object)null, flag);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, flag ? 1 : 0);
	}

	private unsafe void CheckIfPassAvailable()
	{
		//IL_0019: Expected O, but got I4
		//IL_002b: Expected O, but got Ref
		object obj = 0;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = null;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		if (obj != null && _hasSkips)
		{
			_canPass = true;
		}
	}

	private bool CanCharacterReceivePass(VampireSurvivors.Objects.Characters.CharacterController chara)
	{
		//IL_0099: Expected O, but got I4
		//IL_010e: Expected O, but got I4
		//IL_01e7: Expected O, but got I4
		//IL_024f: Expected O, but got I4
		//IL_05cb: Expected O, but got I4
		//IL_0366: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3278]");
		bool flag = (nint)0 != 0;
		bool flag2 = (object)chara == null;
		LevelUpPage levelUpPage = this;
		if (!flag2)
		{
			CharacterWeaponsManager weaponsManager = chara._weaponsManager;
			bool flag3 = (object)chara._weaponsManager == null;
			levelUpPage = this;
			if (!flag3)
			{
				levelUpPage = (LevelUpPage)(object)((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
				if (((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField != null)
				{
					LevelUpPage levelUpPage2 = (LevelUpPage)(chara._maxWeaponBonus + chara._maxWeaponCount);
					CharacterAccessoriesManager accessoriesManager = chara._accessoriesManager;
					if ((object)chara._accessoriesManager != null)
					{
						levelUpPage = (LevelUpPage)(object)((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField;
						if (((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField != null)
						{
							object obj = chara._maxAccessoryBonus + chara._maxAccessoryCount;
							List<LevelUpItemUI> list = _spawnedItems;
							if (_spawnedItems != null)
							{
								bool result = false;
								List<LevelUpItemUI>.Enumerator enumerator = default(List<LevelUpItemUI>.Enumerator);
								nint num2 = default(nint);
								IEnumerable<object> enumerable = default(IEnumerable<object>);
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass102_0 CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass102_0();
									bool flag4 = CS_0024_003C_003E8__locals15 == null;
									levelUpPage = (LevelUpPage)(object)typeof(_003C_003Ec__DisplayClass102_0);
									object obj2;
									nint num;
									LevelUpPage levelUpPage3;
									if (!flag4)
									{
										CS_0024_003C_003E8__locals15.v = null;
										levelUpPage = (LevelUpPage)(object)typeof(_003C_003Ec__DisplayClass102_0);
										LevelUpItemUI v = CS_0024_003C_003E8__locals15.v;
										if ((object)CS_0024_003C_003E8__locals15.v != null)
										{
											bool flag5 = v._type == WeaponType.VOID;
											obj2 = 0;
											num = num2;
											if (!flag5)
											{
												levelUpPage = (LevelUpPage)(object)v._data;
												if (v._data == null)
												{
													throw new NullReferenceException();
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rcx_v20 (VampireSurvivors.UI.LevelUpPage)+101]");
												flag = (nint)0 != 0;
												obj2 = 0;
												num = num2;
												if (!flag)
												{
													CharacterWeaponsManager weaponsManager2 = chara._weaponsManager;
													if ((object)chara._weaponsManager == null)
													{
														throw new NullReferenceException();
													}
													enumerable = ((EquipmentManager)weaponsManager2)._003CActiveEquipment_003Ek__BackingField;
													Func<Equipment, bool> predicate = delegate(Equipment x)
													{
														//IL_007f: Expected I4, but got O
														//IL_005d: Expected O, but got I4
														if ((object)x != null)
														{
															LevelUpItemUI v3 = CS_0024_003C_003E8__locals15.v;
															if ((object)CS_0024_003C_003E8__locals15.v != null)
															{
																object obj3 = x._equipmentType - v3._type;
																return obj3 == null;
															}
														}
														NullReferenceException ex = new NullReferenceException();
														return (byte)(int)ex != 0;
													};
													int num3 = Enumerable.Count(((EquipmentManager)weaponsManager2)._003CActiveEquipment_003Ek__BackingField, (Func<object, bool>)predicate);
													CancellationTokenSource cancellationTokenSource = ((MonoBehaviour)levelUpPage).m_CancellationTokenSource;
													flag = System.Runtime.CompilerServices.Unsafe.As<CancellationTokenSource, UIntPtr>(ref cancellationTokenSource) >= System.Runtime.CompilerServices.Unsafe.As<LevelUpPage, UIntPtr>(ref levelUpPage2);
													levelUpPage = levelUpPage2;
													if (!flag)
													{
														levelUpPage = (LevelUpPage)(object)CS_0024_003C_003E8__locals15.v;
														if ((object)CS_0024_003C_003E8__locals15.v == null)
														{
															throw new NullReferenceException();
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rcx_v20 (VampireSurvivors.UI.LevelUpPage)+149]");
														bool flag6 = (nint)0 == 0;
														levelUpPage3 = (LevelUpPage)(object)CS_0024_003C_003E8__locals15.v;
														if (!flag6)
														{
															goto IL_035d;
														}
													}
													flag = num3 <= 0;
													obj2 = 0;
													num = 0;
													list = null;
													if (!flag)
													{
														levelUpPage3 = levelUpPage;
														goto IL_035d;
													}
												}
											}
											goto IL_067a;
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
									IL_0582:
									result = true;
									IEnumerable<object> enumerable2;
									enumerable = enumerable2;
									nint num4;
									num2 = num4;
									List<LevelUpItemUI> list2;
									list = list2;
									bool flag7;
									flag = flag7;
									continue;
									IL_067a:
									LevelUpItemUI v2 = CS_0024_003C_003E8__locals15.v;
									if ((object)CS_0024_003C_003E8__locals15.v != null)
									{
										bool flag8 = v2._type == WeaponType.VOID;
										num2 = num;
										if (!flag8)
										{
											levelUpPage = (LevelUpPage)(object)v2._data;
											if (v2._data == null)
											{
												throw new NullReferenceException();
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rcx_v20 (VampireSurvivors.UI.LevelUpPage)+101]");
											bool flag9 = (nint)0 == 0;
											num2 = num;
											if (!flag9)
											{
												CharacterAccessoriesManager accessoriesManager2 = chara._accessoriesManager;
												if ((object)chara._accessoriesManager == null)
												{
													throw new NullReferenceException();
												}
												enumerable = ((EquipmentManager)accessoriesManager2)._003CActiveEquipment_003Ek__BackingField;
												Func<Equipment, bool> predicate2 = delegate(Equipment x)
												{
													//IL_007f: Expected I4, but got O
													//IL_005d: Expected O, but got I4
													if ((object)x != null)
													{
														LevelUpItemUI v3 = CS_0024_003C_003E8__locals15.v;
														if ((object)CS_0024_003C_003E8__locals15.v != null)
														{
															object obj3 = x._equipmentType - v3._type;
															return obj3 == null;
														}
													}
													NullReferenceException ex = new NullReferenceException();
													return (byte)(int)ex != 0;
												};
												int num5 = Enumerable.Count(((EquipmentManager)accessoriesManager2)._003CActiveEquipment_003Ek__BackingField, (Func<object, bool>)predicate2);
												CancellationTokenSource cancellationTokenSource2 = ((MonoBehaviour)levelUpPage).m_CancellationTokenSource;
												if (System.Runtime.CompilerServices.Unsafe.As<CancellationTokenSource, UIntPtr>(ref cancellationTokenSource2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
												{
													levelUpPage = (LevelUpPage)(object)CS_0024_003C_003E8__locals15.v;
													if ((object)CS_0024_003C_003E8__locals15.v == null)
													{
														throw new NullReferenceException();
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rcx_v20 (VampireSurvivors.UI.LevelUpPage)+149]");
													flag7 = (nint)0 != 0;
													enumerable2 = ((EquipmentManager)accessoriesManager2)._003CActiveEquipment_003Ek__BackingField;
													num4 = 0;
													list2 = null;
													if (flag7)
													{
														goto IL_0582;
													}
												}
												flag = num5 > 0;
												num2 = 0;
												list = null;
												enumerable2 = enumerable;
												num4 = 0;
												list2 = null;
												flag7 = flag;
												if (flag)
												{
													goto IL_0582;
												}
											}
										}
										bool flag10 = obj2 == null;
										enumerable2 = enumerable;
										num4 = num2;
										list2 = list;
										flag7 = flag;
										if (flag10)
										{
											continue;
										}
										goto IL_0582;
									}
									throw new NullReferenceException();
									IL_035d:
									obj2 = 1;
									num = 0;
									list = null;
									levelUpPage = levelUpPage3;
									goto IL_067a;
								}
								return result;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void Pass()
	{
		//IL_024b: Expected O, but got F4
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_01ec: Expected O, but got I
		object obj = UnityEngine.Random.value;
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		PlayerModifierStats playerStats = activeCharacter._playerStats;
		float num = default(float);
		if (num < playerStats._003CRecycle_003Ek__BackingField)
		{
			goto IL_01f6;
		}
		GameManager core2 = GM.Core;
		GameSessionData gameSessionData2 = core2._gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter2 = gameSessionData2._activeCharacter;
		PlayerModifierStats playerStats2 = activeCharacter2._playerStats;
		EggFloat eggFloat = playerStats2._003CSkips_003Ek__BackingField;
		float num2 = eggFloat._val - 1f;
		object obj2 = num2 & -2147483649L;
		if ((nint)obj2 != 2139095040)
		{
			object obj3 = num2 & -2147483649L;
			if ((nint)obj3 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186CF6EA3h\"");
				if (num2 == -1f / 0f)
				{
					num2 = -3.4028235E+38f;
				}
				goto IL_0204;
			}
		}
		num2 = 3.4028235E+38f;
		goto IL_0204;
		IL_0204:
		eggFloat._val = num2;
		playerStats2._003CSkips_003Ek__BackingField = eggFloat;
		goto IL_01f6;
		IL_01f6:
		GameManager core3 = GM.Core;
		if (!core3._multiplayer.IsOnlineMultiplayer)
		{
			bool flag = FindViablePassPlayer();
			VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
			GameManager core4 = GM.Core;
			CoopConfig coopConfig = core4.CoopConfig;
			EnterMultiplayerControl(characterControllingUi, coopConfig._levelupVibrationMilliseconds);
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 319 Invalid \"Jump target not found in method: 0x186CF71E0\"");
		}
		object instance = OnlineStageManager._instance;
		Action action = OnlineStageManager._instance.RequestLevelUpPassOnline;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rbx_v3 (System.Object)+78]");
		bool flag2 = ((CoherenceSync)0).SendCommand(action, MessageTarget.AuthorityOnly);
	}

	private bool FindViablePassPlayer()
	{
		//IL_0224: Expected I4, but got O
		//IL_0186: Expected O, but got I
		//IL_019c: Expected O, but got I
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Expected O, but got Unknown
		while ((object)GM.Core != null)
		{
			GM.Core.CycleActivePlayer();
			GameManager core = GM.Core;
			if ((object)GM.Core == null)
			{
				break;
			}
			GameSessionData gameSessionData = core._gameSessionData;
			if (core._gameSessionData == null)
			{
				break;
			}
			if (CanCharacterReceivePass(gameSessionData._activeCharacter))
			{
				GameManager core2 = GM.Core;
				if ((object)GM.Core == null)
				{
					break;
				}
				GameSessionData gameSessionData2 = core2._gameSessionData;
				if (core2._gameSessionData == null)
				{
					break;
				}
				_ = gameSessionData2._activeCharacter;
				if (_playerOptions == null)
				{
					break;
				}
				PlayerOptionsData config = _playerOptions.Config;
				if (config == null)
				{
					break;
				}
				List<WeaponType> list = config._003CUnlockedWeapons_003Ek__BackingField;
				if (config._003CUnlockedWeapons_003Ek__BackingField == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				object obj = -21;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				object obj2 = (nint)0 ^ (nint)0x15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				object obj3 = 0 ^ obj;
				object obj4 = obj2 & obj3;
				bool flag = (nint)obj4 < 0;
				bool flag2 = (nint)obj < 0;
				bool flag3 = obj == null;
				bool flag4 = flag2 == flag;
				bool flag5 = !flag3;
				return flag5 & flag4;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void PerformPass(bool showStats)
	{
		//IL_0017: Expected O, but got Ref
		//IL_0184: Expected O, but got I
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected O, but got Unknown
		//IL_027f: Expected O, but got I
		//IL_03a5: Expected O, but got I4
		//IL_02e6: Expected O, but got I
		//IL_03fe: Expected O, but got I4
		//IL_04b2: Expected O, but got I
		//IL_0634: Expected O, but got I
		//IL_09f5: Expected O, but got I
		//IL_08d9: Expected O, but got I
		//IL_0809: Expected O, but got I
		//IL_05ae: Expected O, but got I
		//IL_0a5e: Expected O, but got I
		//IL_0728: Expected O, but got I
		//IL_05fa: Expected O, but got I4
		//IL_0854: Expected O, but got I
		//IL_0774: Expected O, but got I4
		//IL_0b4b: Expected O, but got I
		//IL_02f9->IL0c14: Incompatible stack heights: 10 vs 1
		//IL_04fb->IL0c4b: Incompatible stack heights: 7 vs 6
		//IL_0675->IL0c76: Incompatible stack heights: 8 vs 7
		//IL_08e3->IL0ce0: Incompatible stack heights: 10 vs 4
		//IL_087e->IL0c4b: Incompatible stack heights: 9 vs 6
		//IL_08a3->IL0c76: Incompatible stack heights: 10 vs 7
		//IL_05ec->IL085e: Incompatible stack heights: 10 vs 9
		//IL_05ff->IL0c4b: Incompatible stack heights: 9 vs 6
		//IL_05f1->IL05f1: Incompatible stack heights: 10 vs 9
		//IL_0766->IL0888: Incompatible stack heights: 11 vs 10
		//IL_085e->IL0ce0: Incompatible stack heights: 10 vs 4
		//IL_0779->IL0c76: Incompatible stack heights: 10 vs 7
		//IL_076b->IL076b: Incompatible stack heights: 11 vs 10
		//IL_0aa4->IL0d5a: Incompatible stack heights: 6 vs 4
		//IL_0842->IL0ce0: Incompatible stack heights: 10 vs 4
		//IL_0b7d->IL0e4e: Incompatible stack heights: 5 vs 4
		//IL_0e06->IL0e06: Incompatible stack heights: 9 vs 6
		List<WeaponType> list = new List<WeaponType>();
		List<LevelUpItemUI>.Enumerator enumerator = default(List<LevelUpItemUI>.Enumerator);
		if (enumerator.MoveNext())
		{
			Component component = null;
			List<LevelUpItemUI>.Enumerator enumerator2 = (List<LevelUpItemUI>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		List<LevelUpItemUI> spawnedItems = _spawnedItems;
		int version = spawnedItems._version + 1;
		spawnedItems._version = version;
		spawnedItems._size = 0;
		if (spawnedItems._size > 0)
		{
			Array.Clear(spawnedItems._items, 0, spawnedItems._size);
		}
		VerticalLayoutGroup component2 = Container.GetComponent<VerticalLayoutGroup>();
		bool flag = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
		Behaviour.set_enabled_Injected(((UnityEngine.Object)component2).m_CachedPtr, true);
		int num = 0;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		while (true)
		{
			bool flag2 = obj == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ stack_-C0_v39+1C]");
			if (obj2 == null)
			{
				object obj3 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ stack_-C0_v39+18]");
				if ((nint)obj3 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ stack_-C0_v39+10]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ stack_-C0_v39+10]");
					bool flag3 = (nint)0 == 0;
					object obj6 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v984 @ rdx_v121+18]");
					bool flag4 = (nint)obj6 >= 0;
					obj4++;
					bool flag5 = _data == null;
					Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
					bool flag6 = convertedWeapons == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v984 @ rdx_v121+20+v1858 @ rcx_v186*4]");
					object obj7 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
					bool flag7 = obj7 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1052 @ rax_v264 (System.Object)+18]");
					bool flag8 = (nint)0 <= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1052 @ rax_v264 (System.Object)+10]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1052 @ rax_v264 (System.Object)+10]");
					bool flag9 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1049 @ rdx_v124+18]");
					bool flag10 = (nint)0 <= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1049 @ rdx_v124+20]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v984 @ rdx_v121+20+v1858 @ rcx_v186*4]");
					SpawnWeapon((WeaponData)num2, WeaponType.VOID, num);
					num++;
					continue;
				}
				break;
			}
			break;
		}
		bool flag11 = obj == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ stack_-C0_v39+1C]");
		bool flag12 = obj2 != null;
		LayoutRebuilder.ForceRebuildLayoutImmediate(Container);
		Canvas.ForceUpdateCanvases();
		ValidateButtonStates();
		UpdateButtonsUI();
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
		CharacterWeaponsManager weaponsManager = characterControllingUi._weaponsManager;
		List<Equipment> list2 = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi2 = GetCharacterControllingUi();
		LevelUpPage levelUpPage = (LevelUpPage)(characterControllingUi2._maxWeaponBonus + characterControllingUi2._maxWeaponCount);
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi3 = GetCharacterControllingUi();
		CharacterAccessoriesManager accessoriesManager = characterControllingUi3._accessoriesManager;
		List<Equipment> list3 = ((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField;
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi4 = GetCharacterControllingUi();
		object obj9 = characterControllingUi4._maxAccessoryBonus + characterControllingUi4._maxAccessoryCount;
		List<LevelUpItemUI> list4 = _spawnedItems;
		Component component3 = null;
		List<LevelUpItemUI>.Enumerator enumerator3 = default(List<LevelUpItemUI>.Enumerator);
		while (enumerator3.MoveNext())
		{
			_003C_003Ec__DisplayClass105_0 CS_0024_003C_003E8__locals21 = new _003C_003Ec__DisplayClass105_0();
			bool flag13 = CS_0024_003C_003E8__locals21 == null;
			CS_0024_003C_003E8__locals21.v = null;
			IntPtr cachedPtr = ((UnityEngine.Object)(object)CS_0024_003C_003E8__locals21).m_CachedPtr;
			bool flag14 = ((UnityEngine.Object)(object)CS_0024_003C_003E8__locals21).m_CachedPtr == (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1959 @ rax_v215 (System.IntPtr)+110]");
			bool flag15 = (nint)0 == 0;
			List<WeaponType> list5 = null;
			if (!flag15)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1959 @ rax_v215 (System.IntPtr)+100]");
				LevelUpPage levelUpPage2 = (LevelUpPage)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1959 @ rax_v215 (System.IntPtr)+100]");
				bool flag16 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1961 @ rcx_v170 (VampireSurvivors.UI.LevelUpPage)+101]");
				bool flag17 = (nint)0 != 0;
				list5 = null;
				if (!flag17)
				{
					VampireSurvivors.Objects.Characters.CharacterController characterControllingUi5 = GetCharacterControllingUi();
					bool flag18 = (object)characterControllingUi5 == null;
					CharacterWeaponsManager weaponsManager2 = characterControllingUi5._weaponsManager;
					bool flag19 = (object)characterControllingUi5._weaponsManager == null;
					int num3 = Enumerable.Count(predicate: (Func<object, bool>)(Func<Equipment, bool>)delegate(Equipment x)
					{
						//IL_007f: Expected I4, but got O
						//IL_005d: Expected O, but got I4
						if ((object)x != null)
						{
							LevelUpItemUI v = CS_0024_003C_003E8__locals21.v;
							if ((object)CS_0024_003C_003E8__locals21.v != null)
							{
								object obj16 = x._equipmentType - v._type;
								return obj16 == null;
							}
						}
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}, source: ((EquipmentManager)weaponsManager2)._003CActiveEquipment_003Ek__BackingField);
					if (list2._size < (nint)levelUpPage)
					{
						LevelUpPage levelUpPage3 = (LevelUpPage)(nint)((UnityEngine.Object)(object)CS_0024_003C_003E8__locals21).m_CachedPtr;
						bool flag20 = ((UnityEngine.Object)(object)CS_0024_003C_003E8__locals21).m_CachedPtr == (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1770 @ rcx_v178 (VampireSurvivors.UI.LevelUpPage)+149]");
						if ((nint)0 != 0)
						{
							goto IL_05f1;
						}
					}
					bool flag21 = num3 <= 0;
					list5 = null;
					if (!flag21)
					{
						goto IL_05f1;
					}
				}
			}
			goto IL_0c4b;
			IL_0c76:
			IntPtr cachedPtr2 = ((UnityEngine.Object)(object)CS_0024_003C_003E8__locals21).m_CachedPtr;
			bool flag22 = ((UnityEngine.Object)(object)CS_0024_003C_003E8__locals21).m_CachedPtr == (IntPtr)0;
			VampireSurvivors.Objects.Characters.CharacterController characterControllingUi6 = GetCharacterControllingUi();
			bool flag23 = _levelUpFactory == null;
			LevelUpFactory levelUpFactory = _levelUpFactory;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2447 @ rax_v219 (System.IntPtr)+110]");
			bool flag24 = levelUpFactory.IsBlockedDueToCoop(WeaponType.VOID, characterControllingUi6);
			LevelUpPage levelUpPage4 = null;
			if (!flag24)
			{
				levelUpPage4 = (LevelUpPage)(object)list5;
			}
			if ((object)levelUpPage4 != null)
			{
				bool flag25 = ((UnityEngine.Object)(object)CS_0024_003C_003E8__locals21).m_CachedPtr == (IntPtr)0;
				((LevelUpItemUI)(nint)((UnityEngine.Object)(object)CS_0024_003C_003E8__locals21).m_CachedPtr).EnableSelection();
				if ((object)component3 != null)
				{
					bool flag26 = ((UnityEngine.Object)component3).m_CachedPtr != (IntPtr)0;
					list4 = null;
					if (flag26)
					{
						continue;
					}
				}
				component3 = (Component)(nint)((UnityEngine.Object)(object)CS_0024_003C_003E8__locals21).m_CachedPtr;
				list4 = null;
			}
			else
			{
				bool flag27 = ((UnityEngine.Object)(object)CS_0024_003C_003E8__locals21).m_CachedPtr == (IntPtr)0;
				((LevelUpItemUI)(nint)((UnityEngine.Object)(object)CS_0024_003C_003E8__locals21).m_CachedPtr).DisableSelection();
				list4 = null;
			}
			continue;
			IL_05f1:
			list5 = (List<WeaponType>)1;
			goto IL_0c4b;
			IL_0c4b:
			IntPtr cachedPtr3 = ((UnityEngine.Object)(object)CS_0024_003C_003E8__locals21).m_CachedPtr;
			bool flag28 = ((UnityEngine.Object)(object)CS_0024_003C_003E8__locals21).m_CachedPtr == (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2212 @ rax_v217 (System.IntPtr)+110]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2212 @ rax_v217 (System.IntPtr)+100]");
				LevelUpPage levelUpPage5 = (LevelUpPage)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2212 @ rax_v217 (System.IntPtr)+100]");
				bool flag29 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2214 @ rcx_v161 (VampireSurvivors.UI.LevelUpPage)+101]");
				if ((nint)0 != 0)
				{
					VampireSurvivors.Objects.Characters.CharacterController characterControllingUi7 = GetCharacterControllingUi();
					bool flag30 = (object)characterControllingUi7 == null;
					CharacterAccessoriesManager accessoriesManager2 = characterControllingUi7._accessoriesManager;
					bool flag31 = (object)characterControllingUi7._accessoriesManager == null;
					int num4 = Enumerable.Count(predicate: (Func<object, bool>)(Func<Equipment, bool>)delegate(Equipment x)
					{
						//IL_007f: Expected I4, but got O
						//IL_005d: Expected O, but got I4
						if ((object)x != null)
						{
							LevelUpItemUI v = CS_0024_003C_003E8__locals21.v;
							if ((object)CS_0024_003C_003E8__locals21.v != null)
							{
								object obj16 = x._equipmentType - v._type;
								return obj16 == null;
							}
						}
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}, source: ((EquipmentManager)accessoriesManager2)._003CActiveEquipment_003Ek__BackingField);
					if (list3._size < (nint)obj9)
					{
						LevelUpPage levelUpPage6 = (LevelUpPage)(nint)((UnityEngine.Object)(object)CS_0024_003C_003E8__locals21).m_CachedPtr;
						bool flag32 = ((UnityEngine.Object)(object)CS_0024_003C_003E8__locals21).m_CachedPtr == (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2029 @ rcx_v169 (VampireSurvivors.UI.LevelUpPage)+149]");
						if ((nint)0 != 0)
						{
							goto IL_076b;
						}
					}
					if (num4 > 0)
					{
						goto IL_076b;
					}
				}
			}
			goto IL_0c76;
			IL_076b:
			list5 = (List<WeaponType>)1;
			goto IL_0c76;
		}
		bool flag33 = (object)component3 == null;
		_003CSelectElementLater_003Ed__107 obj10 = (_003CSelectElementLater_003Ed__107)(object)list4;
		if (!flag33)
		{
			bool flag34 = ((UnityEngine.Object)component3).m_CachedPtr == (IntPtr)0;
			obj10 = (_003CSelectElementLater_003Ed__107)(object)list4;
			if (!flag34)
			{
				Selectable component4 = component3.GetComponent<Selectable>();
				_003CSelectElementLater_003Ed__107 obj11 = null;
				obj11._003C_003E1__state = 0;
				obj11.s = component4;
				Coroutine coroutine = StartCoroutine(obj11);
				obj10 = obj11;
			}
		}
		bool flag35 = !showStats;
		LevelUpItemUI levelUpItemUI = null;
		List<LevelUpItemUI>.Enumerator enumerator4 = (List<LevelUpItemUI>.Enumerator)list4;
		if (!flag35)
		{
			StatsPanelUI component5 = _CharacterStatsPanel.GetComponent<StatsPanelUI>();
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _data.GetConvertedCharacterData();
			VampireSurvivors.Objects.Characters.CharacterController characterControllingUi8 = GetCharacterControllingUi();
			object obj12 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterControllingUi8._characterType);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v161 (System.Object)+18]");
			bool flag36 = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v161 (System.Object)+10]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v162+18]");
			bool flag37 = (nint)0 <= (nint)0;
			VampireSurvivors.Objects.Characters.CharacterController characterControllingUi9 = GetCharacterControllingUi();
			VampireSurvivors.Objects.Characters.CharacterController characterControllingUi10 = GetCharacterControllingUi();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v162+20]");
			component5.SetCharacter((CharacterData)0, characterControllingUi9._characterType, characterControllingUi10);
			obj10 = (_003CSelectElementLater_003Ed__107)(object)_EquipmentPanels;
			List<PauseEquipmentPanel>.Enumerator enumerator5 = default(List<PauseEquipmentPanel>.Enumerator);
			while (enumerator5.MoveNext())
			{
				Component component6 = null;
				bool flag38 = ((UnityEngine.Object)component6).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)component6).m_CachedPtr);
				GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				bool flag39 = (object)gameObject == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3012 @ rax_v178 (UnityEngine.GameObject)+10]");
				bool flag40 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3012 @ rax_v178 (UnityEngine.GameObject)+10]");
				GameObject.SetActive_Injected((IntPtr)0, true);
				VampireSurvivors.Objects.Characters.CharacterController characterControllingUi11 = GetCharacterControllingUi();
				((PauseEquipmentPanel)null).Populate(characterControllingUi11);
			}
			levelUpItemUI = null;
			enumerator4 = (List<LevelUpItemUI>.Enumerator)obj10;
		}
		GameManager core = GM.Core;
		if (core._mainCharacters == null)
		{
			return;
		}
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
		if (mainCharacters._size <= 1)
		{
			return;
		}
		GameObject gameObject2 = base.gameObject;
		Component componentsInChildren = (Component)(object)gameObject2.GetComponentsInChildren<MultiplayerCharacterBanner>(includeInactive: true);
		int num5 = 0;
		int num6 = 0;
		while (true)
		{
			int num7 = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3874 @ rax_v147 (UnityEngine.Component)+18]");
			if ((nint)num7 < (nint)0)
			{
				int num8 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3874 @ rax_v147 (UnityEngine.Component)+18]");
				bool flag41 = (nint)num8 >= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3874 @ rax_v147 (UnityEngine.Component)+20+v196 @ r14_v7 (System.Int32)*8]");
				object obj14 = 0;
				object obj15 = obj14;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3955 @ rax_v151+188] (should have been resolved before IL gen)");
				num5++;
				num6 = num5;
				continue;
			}
			break;
		}
	}

	private void ShowMultiplayerBanners()
	{
		//IL_006b: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		GameManager core = GM.Core;
		if (core._mainCharacters == null)
		{
			return;
		}
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
		if (mainCharacters._size > 1)
		{
			GameObject gameObject = base.gameObject;
			MultiplayerCharacterBanner[] componentsInChildren = gameObject.GetComponentsInChildren<MultiplayerCharacterBanner>(includeInactive: true);
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < componentsInChildren.Length)
			{
				componentsInChildren[obj].Show();
				obj++;
				obj2 = obj;
			}
		}
	}

	private IEnumerator SelectElementLater(Selectable s)
	{
		_003CSelectElementLater_003Ed__107 obj = null;
		obj._003C_003E1__state = 0;
		obj.s = s;
		return obj;
	}

	public void LimitBreakRandomOnce()
	{
		ChooseRandomLimitBreak();
	}

	public void LimitBreakRandomAlways()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
		characterControllingUi._003CAlwaysRandomLimitBreak_003Ek__BackingField = true;
		ChooseRandomLimitBreak();
	}

	protected override void Awake()
	{
		//IL_00a3: Expected O, but got I
		//IL_00c7: Expected O, but got I
		//IL_01bd: Expected O, but got I
		//IL_01e1: Expected O, but got I
		//IL_02e4: Expected O, but got I4
		//IL_02e4: Expected O, but got I
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		//IL_09c4: Expected O, but got I
		//IL_03fa: Expected O, but got I4
		//IL_03fa: Expected O, but got I
		//IL_0403: Unknown result type (might be due to invalid IL or missing references)
		//IL_0408: Expected O, but got Unknown
		//IL_09fd: Expected O, but got I
		//IL_0510: Expected O, but got I4
		//IL_0510: Expected O, but got I
		//IL_0519: Unknown result type (might be due to invalid IL or missing references)
		//IL_051e: Expected O, but got Unknown
		//IL_0a38: Expected O, but got I
		//IL_0626: Expected O, but got I4
		//IL_0626: Expected O, but got I
		//IL_062f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0634: Expected O, but got Unknown
		//IL_0a71: Expected O, but got I
		//IL_073c: Expected O, but got I4
		//IL_073c: Expected O, but got I
		//IL_0745: Unknown result type (might be due to invalid IL or missing references)
		//IL_074a: Expected O, but got Unknown
		//IL_0aaa: Expected O, but got I
		//IL_0852: Expected O, but got I4
		//IL_0852: Expected O, but got I
		//IL_085b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0860: Expected O, but got Unknown
		//IL_0ae3: Expected O, but got I
		//IL_0968: Expected O, but got I4
		//IL_0968: Expected O, but got I
		//IL_0971: Unknown result type (might be due to invalid IL or missing references)
		//IL_0976: Expected O, but got Unknown
		//IL_0b1e: Expected O, but got I
		base.Awake();
		Coherence.Log.Logger logger = Log.GetLogger<LevelUpPage>();
		_logger = logger;
		Action<UISignals.BanishWeaponLevelUpSignal> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9EF70");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rbx_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.BanishWeaponLevelUpSignal>)obj)._003CSubscribeId_003Eb__0;
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
		SignalBus signalBus = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rax_v16 (System.Object)+10]");
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(typeFromHandle, (object)null, (object)0, callback);
		Action action3 = OnLevelUpReRollRequest;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v708 @ rbx_v6 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rbx_v7 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rbx_v7 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj2 = null;
		Action<object> action4 = ((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.OnlineLevelUpReRollRequested>)obj2)._003CSubscribeId_003Eb__0;
		Type typeFromHandle2 = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
		SignalBus signalBus2 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ rax_v31 (System.Object)+10]");
		signalBus2.SubscribeInternal(typeFromHandle2, (object)null, (object)0, callback);
		Action<OnlineSignals.OnlineLevelUpReRoll> action5 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F050");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v824 @ rbx_v10 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rbx_v11 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rbx_v11 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj3 = null;
		Action<object> action6 = ((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.OnlineLevelUpReRoll>)obj3)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.OnlineLevelUpReRoll>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj5 = default(object);
		object obj4 = obj5 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus3 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v46 (System.Object)+10]");
		Type signalType = default(Type);
		signalBus3.SubscribeInternal(signalType, (object)null, (object)0, callback);
		Action<OnlineSignals.OnlineLevelUpPass> action7 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F130");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1033 @ rbx_v14 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rbx_v15 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rbx_v15 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj6 = null;
		Action<object> action8 = ((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.OnlineLevelUpPass>)obj6)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.OnlineLevelUpPass>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj8 = default(object);
		object obj7 = obj8 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus4 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rax_v61 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus4.SubscribeInternal(signalType2, (object)null, (object)0, callback);
		Action action9 = OnLevelUpPassRequested;
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1244 @ rbx_v18 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rbx_v19 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rbx_v19 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj9 = null;
		Action<object> action10 = ((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.RequestOnlineLevelUpPass>)obj9)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.RequestOnlineLevelUpPass>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj11 = default(object);
		object obj10 = obj11 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus5 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rax_v76 (System.Object)+10]");
		Type signalType3 = default(Type);
		signalBus5.SubscribeInternal(signalType3, (object)null, (object)0, callback);
		Action<OnlineSignals.OnlineLevelUpWithItem> action11 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F210");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1453 @ rbx_v22 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rbx_v23 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rbx_v23 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj12 = null;
		Action<object> action12 = ((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.OnlineLevelUpWithItem>)obj12)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.OnlineLevelUpWithItem>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj14 = default(object);
		object obj13 = obj14 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus6 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rax_v91 (System.Object)+10]");
		Type signalType4 = default(Type);
		signalBus6.SubscribeInternal(signalType4, (object)null, (object)0, callback);
		Action<OnlineSignals.OnlineLevelUpWithFriendshipAmulet> action13 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F2F0");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1662 @ rbx_v26 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rbx_v27 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rbx_v27 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj15 = null;
		Action<object> action14 = ((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.OnlineLevelUpWithFriendshipAmulet>)obj15)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.OnlineLevelUpWithFriendshipAmulet>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj17 = default(object);
		object obj16 = obj17 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus7 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rax_v106 (System.Object)+10]");
		Type signalType5 = default(Type);
		signalBus7.SubscribeInternal(signalType5, (object)null, (object)0, callback);
		Action<OnlineSignals.OnlineLevelUpWithLimitBreak> action15 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F3D0");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1871 @ rbx_v30 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rbx_v31 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rbx_v31 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj18 = null;
		Action<object> action16 = ((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.OnlineLevelUpWithLimitBreak>)obj18)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.OnlineLevelUpWithLimitBreak>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj20 = default(object);
		object obj19 = obj20 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus8 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rax_v121 (System.Object)+10]");
		Type signalType6 = default(Type);
		signalBus8.SubscribeInternal(signalType6, (object)null, (object)0, callback);
		Action action17 = LevelUpSkip;
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2082 @ rbx_v34 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rbx_v35 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rbx_v35 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj21 = null;
		Action<object> action18 = ((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.OnlineLevelUpSkip>)obj21)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.OnlineLevelUpSkip>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj23 = default(object);
		object obj22 = obj23 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus9 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v136 (System.Object)+10]");
		Type signalType7 = default(Type);
		signalBus9.SubscribeInternal(signalType7, (object)null, (object)0, callback);
	}

	private void OnLevelUpWithLimitBreak(OnlineSignals.OnlineLevelUpWithLimitBreak levelUpWithLimitBreak)
	{
		(string, object)[] args = new(string, object)[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object item = default(object);
		(string, object) tuple = ("AlwaysRandom", item);
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object item2 = default(object);
		(string, object) tuple2 = ("Limit Break Index", item2);
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object item3 = default(object);
		(string, object) tuple3 = ("Number Of Spawned Items", item3);
		_ = 0;
		int num = default(int);
		object item4 = (CharacterType)num;
		(string, object) tuple4 = ("Receiving character", item4);
		_ = 0;
		_logger.Info("Received On Level Up With Limit Break", args);
		VampireSurvivors.Objects.Characters.CharacterController receivingCharacter = levelUpWithLimitBreak.ReceivingCharacter;
		receivingCharacter._003CAlwaysRandomLimitBreak_003Ek__BackingField = levelUpWithLimitBreak.AlwaysRandomLimitBreak;
		List<LevelUpItemUI> spawnedItems = _spawnedItems;
		int chosenLimitBreakIndex = levelUpWithLimitBreak.ChosenLimitBreakIndex;
		if (levelUpWithLimitBreak.ChosenLimitBreakIndex < spawnedItems._size)
		{
			LevelUpItemUI[] items = spawnedItems._items;
			LevelUpItemUI levelUpItemUI = items[chosenLimitBreakIndex];
			HandleLimitBreakLevelUp(levelUpItemUI._wlBreak, levelUpWithLimitBreak.ReceivingCharacter);
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new IndexOutOfRangeException();
	}

	private void OnLevelUpWithItem(OnlineSignals.OnlineLevelUpWithItem levelUpWithItem)
	{
		ProcessItemLevelUp(levelUpWithItem.ItemType, levelUpWithItem.ReceivingCharacter);
	}

	private void OnLevelUpWithFriendshipAmulet(OnlineSignals.OnlineLevelUpWithFriendshipAmulet levelUpWithAmulet)
	{
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
		characterControllingUi.IsInvul = true;
		if (0.5f > characterControllingUi._invincibilityTimer)
		{
			characterControllingUi._invincibilityTimer = 0.5f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F4B0");
		BlockAllButtons();
	}

	private void OnLevelUpPassRequested()
	{
		bool showStats = FindViablePassPlayer();
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
		OnlineStageManager._instance.SendLevelUpPassOnline(characterControllingUi, showStats);
	}

	private unsafe void OnLevelUpPass(OnlineSignals.OnlineLevelUpPass pass)
	{
		//IL_000e: Expected I4, but got O
		//IL_0033: Expected O, but got Ref
		//IL_008c: Expected I4, but got O
		object obj = default(object);
		object arg = (CharacterType)obj;
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj2 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Received pass for character {0}", (System.ParamsArray)(&obj2));
		Debug.Log(message);
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
		GameManager core = GM.Core;
		CoopConfig coopConfig = core.CoopConfig;
		EnterMultiplayerControl(characterControllingUi, coopConfig._levelupVibrationMilliseconds);
		PerformPass((byte)(int)pass != 0);
		ValidateButtonStates();
		UpdateButtonsUI();
	}

	private void OnLevelUpReRoll(OnlineSignals.OnlineLevelUpReRoll reRoll)
	{
		_currentWeapons = (List<WeaponType>)reRoll;
		ResetLevelUpViewsAfterReRoll();
	}

	private void OnLevelUpReRollRequest()
	{
		//IL_0050: Expected O, but got I
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
		List<WeaponType> enumList = _levelUpFactory.RerollLevelUpPowerUps(_currentWeapons, characterControllingUi);
		object instance = OnlineStageManager._instance;
		byte[] param = SerializationUtils.SerializeEnum(enumList);
		Action<byte[]> action = OnlineStageManager._instance.LevelUpReRollOnline;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rbx_v3 (System.Object)+78]");
		bool flag = ((CoherenceSync)0).SendCommand((Action<object>)action, MessageTarget.All, param);
	}

	private unsafe void OnWeaponBanishedRemotely(UISignals.BanishWeaponLevelUpSignal banishedSignal)
	{
		//IL_009f: Expected I4, but got O
		//IL_0017: Expected O, but got Ref
		List<LevelUpItemUI>.Enumerator enumerator = default(List<LevelUpItemUI>.Enumerator);
		if (enumerator.MoveNext())
		{
			LevelUpItemUI levelUpItemUI = null;
			List<LevelUpItemUI>.Enumerator enumerator2 = (List<LevelUpItemUI>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		LevelUpItemUI ui = null;
		BanishWeapon((WeaponType)banishedSignal, ui);
	}

	protected override void Update()
	{
		base.Update();
		if (IsLocalPlayerControllingUi())
		{
			return;
		}
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		PlayerInfo playerInfoForCharacter = OnlineStageManager._instance.GetPlayerInfoForCharacter(gameSessionData._activeCharacter);
		if ((object)playerInfoForCharacter == null || ((UnityEngine.Object)playerInfoForCharacter).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if (playerInfoForCharacter._isInBanishMode)
		{
			if (!_isBanishMode)
			{
				SetBanishMode();
				return;
			}
			if (playerInfoForCharacter._isInBanishMode)
			{
				return;
			}
		}
		if (_isBanishMode)
		{
			CancelBanishMode();
		}
	}

	protected unsafe override void OnShowStart(GameObject g)
	{
		//IL_0033: Expected O, but got Ref
		//IL_042c: Expected O, but got I
		//IL_0442: Expected O, but got I
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_0457: Expected O, but got Unknown
		//IL_0649: Expected I4, but got I8
		//IL_073c: Expected O, but got I
		//IL_07e9: Expected O, but got I
		//IL_0a9e: Expected O, but got I
		//IL_0a89: Expected O, but got I
		//IL_0a53: Expected O, but got I
		//IL_0a1b: Expected O, but got I
		//IL_0ba9: Expected O, but got I
		//IL_0b94: Expected O, but got I
		//IL_0c18: Expected O, but got Ref
		//IL_0bd8: Expected O, but got Ref
		//IL_0b5e: Expected O, but got I
		//IL_0b26: Expected O, but got I
		//IL_0cac: Expected O, but got Ref
		//IL_0da4: Expected I4, but got I8
		//IL_03c3->IL1099: Incompatible stack heights: 21 vs 19
		//IL_1053->IL1053: Incompatible stack heights: 25 vs 0
		//IL_11b6->IL148f: Incompatible stack heights: 26 vs 24
		//IL_1135->IL1135: Incompatible stack heights: 26 vs 24
		//IL_07ee->IL07ee: Incompatible stack heights: 37 vs 25
		//IL_0a79->IL133e: Incompatible stack heights: 33 vs 32
		//IL_09b9->IL12e7: Incompatible stack heights: 36 vs 31
		//IL_0b84->IL13d6: Incompatible stack heights: 36 vs 35
		//IL_0d46->IL13fe: Incompatible stack heights: 35 vs 36
		//IL_0c8e->IL0c8e: Incompatible stack heights: 36 vs 35
		//IL_0d68->IL13fe: Incompatible stack heights: 35 vs 36
		//IL_0d22->IL0d22: Incompatible stack heights: 36 vs 35
		//IL_0e38->IL0f1b: Incompatible stack heights: 38 vs 37
		//IL_0d8d->IL13fe: Incompatible stack heights: 35 vs 36
		//IL_0dd2->IL13fe: Incompatible stack heights: 35 vs 36
		//IL_0dea->IL13fe: Incompatible stack heights: 35 vs 36
		//IL_148a->IL1042: Incompatible stack heights: 40 vs 38
		//IL_0f1b->IL0f1b: Incompatible stack heights: 42 vs 37
		//IL_1042->IL146e: Incompatible stack heights: 42 vs 40
		CharacterType characterType = default(CharacterType);
		System.ParamsArray paramsArray2 = default(System.ParamsArray);
		Vector2 anchoredPosition = default(Vector2);
		bool flag30;
		List<PauseEquipmentPanel>.Enumerator enumerator = default(List<PauseEquipmentPanel>.Enumerator);
		int num2;
		List<PauseEquipmentPanel>.Enumerator enumerator2 = default(List<PauseEquipmentPanel>.Enumerator);
		while (true)
		{
			base.OnShowStart(g);
			VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
			bool flag = (object)characterControllingUi == null;
			object arg = characterType;
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			string message = string.FormatHelper((IFormatProvider)null, "SHOWING LEVEL UP PAGE FOR CHARACTER {0}", (System.ParamsArray)(&paramsArray2));
			Debug.Log(message);
			VampireSurvivors.Objects.Characters.CharacterController characterControllingUi2 = GetCharacterControllingUi();
			GameManager core = GM.Core;
			bool flag2 = (object)GM.Core == null;
			CoopConfig coopConfig = core.CoopConfig;
			bool flag3 = (object)core.CoopConfig == null;
			EnterMultiplayerControl(characterControllingUi2, coopConfig._levelupVibrationMilliseconds);
			BuildParticles();
			_hasPassed = false;
			_isBanishMode = false;
			bool flag4 = (object)_SkipButton == null;
			SelectableUI component = _SkipButton.GetComponent<SelectableUI>();
			bool flag5 = (object)component == null;
			component.IsDefaultSelectedOnPage = false;
			bool flag6 = (object)_RerollButton == null;
			SelectableUI component2 = _RerollButton.GetComponent<SelectableUI>();
			bool flag7 = (object)component2 == null;
			component2.IsDefaultSelectedOnPage = false;
			bool flag8 = (object)_BanishButton == null;
			SelectableUI component3 = _BanishButton.GetComponent<SelectableUI>();
			bool flag9 = (object)component3 == null;
			component3.IsDefaultSelectedOnPage = false;
			bool flag10 = (object)_GemManager == null;
			Transform transform = _GemManager.transform;
			Canvas canvas = UIHelper.Canvas;
			bool flag11 = (object)canvas == null;
			RectTransform component4 = canvas.GetComponent<RectTransform>();
			bool flag12 = (object)transform == null;
			transform.SetParent(component4, worldPositionStays: true);
			bool flag13 = (object)_GemManager == null;
			RectTransform component5 = _GemManager.GetComponent<RectTransform>();
			bool flag14 = (object)component5 == null;
			component5.anchoredPosition = anchoredPosition;
			bool flag15 = (object)_GemManager == null;
			Transform transform2 = _GemManager.transform;
			Transform parent = base.transform;
			bool flag16 = (object)transform2 == null;
			transform2.SetParent(parent, worldPositionStays: true);
			bool flag17 = (object)_CancelButton == null;
			_CancelButton.SetActive(value: false);
			GameManager core2 = GM.Core;
			bool flag18 = (object)GM.Core == null;
			bool flag19 = core2._multiplayer == null;
			if (core2._multiplayer.IsOnlineMultiplayer)
			{
				bool flag20 = (object)OnlineStageManager._instance == null;
				PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
				bool flag21 = (object)myPlayerInfo == null;
				myPlayerInfo._isInBanishMode = false;
			}
			bool flag22 = _playerOptions == null;
			PlayerOptionsData config = _playerOptions.Config;
			bool flag23 = config == null;
			List<WeaponType> list = config._003CUnlockedWeapons_003Ek__BackingField;
			bool flag24 = config._003CUnlockedWeapons_003Ek__BackingField == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rax_v50 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj = -21;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rax_v50 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 ^ (nint)0x15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rax_v50 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj3 = 0 ^ obj;
			object obj4 = obj2 & obj3;
			bool flag25 = (nint)obj4 < 0;
			bool flag26 = (nint)obj < 0;
			bool flag27 = obj == null;
			bool flag28 = flag26 == flag25;
			bool flag29 = !flag27;
			flag30 = flag29 & flag28;
			bool flag31 = (object)_Equipment == null;
			_Equipment.SetActive(flag30);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rax_v50 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			bool num;
			if ((nint)0 > (nint)21)
			{
				bool flag32 = _EquipmentPanels == null;
				num = flag32;
				while (enumerator.MoveNext())
				{
					GameObject gameObject = ((Component)null).gameObject;
					bool flag33 = (object)gameObject == null;
					bool flag34 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, true);
					VampireSurvivors.Objects.Characters.CharacterController characterControllingUi3 = GetCharacterControllingUi();
					((PauseEquipmentPanel)null).Populate(characterControllingUi3);
				}
				num2 = 0;
			}
			else
			{
				bool flag35 = _EquipmentPanels == null;
				num = flag35;
				while (enumerator2.MoveNext())
				{
					GameObject gameObject2 = ((Component)null).gameObject;
					bool flag36 = (object)gameObject2 == null;
					bool flag37 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
					GameObject.SetActive_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr, false);
				}
				num2 = 0;
			}
			object characterStatsPanel = _CharacterStatsPanel;
			bool flag38 = (object)_CharacterStatsPanel == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rsi_v13 (System.Object)+10]");
			if ((nint)0 != 0)
			{
				break;
			}
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_CharacterStatsPanel);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rsi_v13 (System.Object)+10]");
		GameObject.SetActive_Injected((IntPtr)0, flag30);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rax_v50 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		if ((nint)0 > (nint)21)
		{
			bool flag39 = (object)_CharacterStatsPanel == null;
			StatsPanelUI component6 = _CharacterStatsPanel.GetComponent<StatsPanelUI>();
			bool flag40 = (object)component6 == null;
			if (!component6._hasLoaded)
			{
				component6.Populate();
			}
			TextAutoSizeHelper.UpdateTextSizes(component6._statTextLines, -1);
			bool flag41 = (object)_CharacterStatsPanel == null;
			StatsPanelUI component7 = _CharacterStatsPanel.GetComponent<StatsPanelUI>();
			bool flag42 = _data == null;
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _data.GetConvertedCharacterData();
			VampireSurvivors.Objects.Characters.CharacterController characterControllingUi4 = GetCharacterControllingUi();
			bool flag43 = (object)characterControllingUi4 == null;
			bool flag44 = convertedCharacterData == null;
			object obj5 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterControllingUi4._characterType);
			bool flag45 = obj5 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rax_v200 (System.Object)+18]");
			bool flag46 = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rax_v200 (System.Object)+10]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rax_v200 (System.Object)+10]");
			bool flag47 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v201+18]");
			bool flag48 = (nint)0 <= (nint)0;
			VampireSurvivors.Objects.Characters.CharacterController characterControllingUi5 = GetCharacterControllingUi();
			bool flag49 = (object)characterControllingUi5 == null;
			VampireSurvivors.Objects.Characters.CharacterController characterControllingUi6 = GetCharacterControllingUi();
			bool flag50 = (object)component7 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v201+20]");
			component7.SetCharacter((CharacterData)0, characterControllingUi5._characterType, characterControllingUi6);
		}
		_003CForceLeftLayoutDelayed_003Ed__122 obj7 = null;
		obj7._003C_003E1__state = num2;
		obj7._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj7);
		CancelBanishMode();
		bool flag51 = (object)Container == null;
		VerticalLayoutGroup component8 = Container.GetComponent<VerticalLayoutGroup>();
		bool flag52 = (object)component8 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rax_v78 (UnityEngine.UI.VerticalLayoutGroup)+10]");
		bool flag53 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rax_v78 (UnityEngine.UI.VerticalLayoutGroup)+10]");
		Behaviour.set_enabled_Injected((IntPtr)0, true);
		bool flag54 = _data == null;
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
		_weaponData = convertedWeapons;
		Populate();
		BuildBanishedWeaponsList();
		ValidateButtonStates();
		object luck = _luck;
		bool flag55 = (object)_luck == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rsi_v16 (System.Object)+10]");
		bool flag56 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rsi_v16 (System.Object)+10]");
		GameObject.SetActive_Injected((IntPtr)0, false);
		DisableLevelupOptions();
		if (_spawnedItems != null)
		{
			List<LevelUpItemUI> spawnedItems = _spawnedItems;
			if (spawnedItems._size > 0)
			{
				bool flag57 = spawnedItems._size <= 0;
				LevelUpItemUI[] items = spawnedItems._items;
				bool flag58 = spawnedItems._items == null;
				bool flag59 = items.Length <= 0;
				bool flag60 = (object)items[0] == null;
				Button component9 = items[0].GetComponent<Button>();
				bool flag61 = (object)component9 == null;
				component9.Select();
			}
		}
		Component progressBar = ProgressBar;
		object playerOptions = _playerOptions;
		bool flag62 = _playerOptions == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rsi_v17 (System.Object)+68]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rsi_v17 (System.Object)+58]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rsi_v17 (System.Object)+78]");
				object obj8;
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rsi_v17 (System.Object)+78]");
					obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rax_v95+2CC]");
					if ((nint)0 != 0)
					{
						goto IL_133e;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rsi_v17 (System.Object)+50]");
				obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rsi_v17 (System.Object)+50]");
				bool flag63 = (nint)0 == 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rsi_v17 (System.Object)+58]");
				object obj8 = 0;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rsi_v17 (System.Object)+68]");
			object obj8 = 0;
		}
		goto IL_133e;
		IL_13d6:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rax_v101+118]");
		if ((nint)0 == 0)
		{
			bool flag64 = (object)ProgressBar == null;
			ProgressBar.color = (Color)(&paramsArray2);
		}
		else
		{
			Sequence colorTween = DOTween.Sequence();
			_colorTween = colorTween;
			Sequence colorTween2 = _colorTween;
			TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleUI.DOColor(ProgressBar, (Color)(&paramsArray2), 0.3f);
			if (TweenSettingsExtensions.ValidateAddToSequence(_colorTween, (Tween)t, false))
			{
				bool flag65 = _colorTween == null;
				Sequence sequence = Sequence.DoInsert(_colorTween, (Tween)t, ((Tween)colorTween2).duration);
			}
			Sequence colorTween3 = _colorTween;
			TweenerCore<Color, Color, ColorOptions> t2 = DOTweenModuleUI.DOColor(ProgressBar, (Color)(&paramsArray2), 0.3f);
			if (TweenSettingsExtensions.ValidateAddToSequence(_colorTween, (Tween)t2, false))
			{
				bool flag66 = _colorTween == null;
				Sequence sequence2 = Sequence.DoInsert(_colorTween, (Tween)t2, ((Tween)colorTween3).duration);
			}
			Sequence colorTween4 = _colorTween;
			if (_colorTween != null && ((Tween)colorTween4)._003Cactive_003Ek__BackingField && !((Tween)colorTween4).creationLocked)
			{
				((Tween)colorTween4).loops = -1;
				((Tween)colorTween4).loopType = LoopType.Yoyo;
				if (((ABSSequentiable)colorTween4).tweenType == TweenType.Tweener)
				{
					((Tween)colorTween4).fullDuration = 1f / 0f;
				}
			}
		}
		UpdateButtonsUI();
		bool flag67 = TwitchIntegration._sInstance == null;
		if (TwitchIntegration._sInstance.IsTwitchOn())
		{
			bool flag68 = TwitchIntegration._sInstance == null;
			if (TwitchIntegration._sInstance.IsTwitchWorking())
			{
				TwitchLevelUpPanel twitchLevelUpPanel = _TwitchLevelUpPanel;
				bool flag69 = (object)_TwitchLevelUpPanel == null;
				twitchLevelUpPanel._levelUpPage = this;
				_TwitchLevelUpPanel.DisableAllUIInteraction();
				bool flag70 = (object)twitchLevelUpPanel._canvasGroup == null;
				twitchLevelUpPanel._canvasGroup.alpha = 1f;
				bool flag71 = (object)GM.Core == null;
				VampireSurvivors.Objects.Characters.CharacterController interactingPlayer = GM.Core.InteractingPlayer;
				bool flag72 = (object)interactingPlayer == null;
				interactingPlayer._003CAlwaysRandomLimitBreak_003Ek__BackingField = true;
				twitchLevelUpPanel._banishChoice = false;
				_TwitchLevelUpPanel.CleanTwitchOptions();
				_TwitchLevelUpPanel.CreateCountDownBar();
			}
		}
		DoIntroEffects();
		GameManager core3 = GM.Core;
		bool flag73 = (object)GM.Core == null;
		if (core3._mainCharacters == null)
		{
			return;
		}
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core3._mainCharacters;
		if (mainCharacters._size > 1)
		{
			GameObject gameObject3 = base.gameObject;
			bool flag74 = (object)gameObject3 == null;
			MultiplayerCharacterBanner[] componentsInChildren = gameObject3.GetComponentsInChildren<MultiplayerCharacterBanner>(includeInactive: true);
			bool flag75 = componentsInChildren == null;
			for (int num3 = num2; num3 < componentsInChildren.Length; num3 = num2)
			{
				bool flag76 = num2 >= componentsInChildren.Length;
				bool flag77 = (object)componentsInChildren[num2] == null;
				componentsInChildren[num2].Show();
				num2++;
			}
		}
		return;
		IL_133e:
		bool flag78 = (object)ProgressBar == null;
		bool flag79 = ((UnityEngine.Object)progressBar).m_CachedPtr == (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rax_v95+124]");
		bool value = (nint)0 == 0;
		Behaviour.set_enabled_Injected(((UnityEngine.Object)progressBar).m_CachedPtr, value);
		object playerOptions2 = _playerOptions;
		bool flag80 = _playerOptions == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rsi_v19 (System.Object)+68]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rsi_v19 (System.Object)+58]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rsi_v19 (System.Object)+78]");
				object obj9;
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rsi_v19 (System.Object)+78]");
					obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rax_v101+2CC]");
					if ((nint)0 != 0)
					{
						goto IL_13d6;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rsi_v19 (System.Object)+50]");
				obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rsi_v19 (System.Object)+50]");
				bool flag81 = (nint)0 == 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rsi_v19 (System.Object)+58]");
				object obj9 = 0;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rsi_v19 (System.Object)+68]");
			object obj9 = 0;
		}
		goto IL_13d6;
	}

	protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
	{
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._multiplayer != null)
		{
			if (core._multiplayer.IsOnlineMultiplayer)
			{
				if ((object)GM.Core != null)
				{
					return GM.Core.InteractingPlayer;
				}
			}
			else
			{
				GameSessionData gameSession = _gameSession;
				if (_gameSession != null)
				{
					return gameSession._activeCharacter;
				}
			}
		}
		return (VampireSurvivors.Objects.Characters.CharacterController)(object)new NullReferenceException();
	}

	private IEnumerator ForceLeftLayoutDelayed()
	{
		_003CForceLeftLayoutDelayed_003Ed__122 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void BuildParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0272: Expected O, but got I4
		//IL_02a2: Expected O, but got Ref
		//IL_02c0: Expected native int or pointer, but got O
		//IL_02da: Expected O, but got I
		//IL_02fa: Expected O, but got Ref
		//IL_0314: Expected native int or pointer, but got O
		//IL_032e: Expected O, but got I
		//IL_035c: Expected O, but got I4
		//IL_0375: Expected O, but got Ref
		//IL_03ad: Expected native int or pointer, but got O
		//IL_0a72: Expected O, but got I4
		//IL_03df: Expected O, but got Ref
		//IL_0407: Expected native int or pointer, but got O
		//IL_0aac: Expected O, but got I
		//IL_0458: Expected O, but got I
		//IL_0ae2: Expected O, but got I
		//IL_0bf5: Expected O, but got Ref
		//IL_06eb: Expected O, but got I4
		//IL_0739: Expected O, but got Ref
		//IL_0757: Expected native int or pointer, but got O
		//IL_0771: Expected O, but got I
		//IL_0791: Expected O, but got Ref
		//IL_07ab: Expected native int or pointer, but got O
		//IL_07c5: Expected O, but got I
		//IL_07f3: Expected O, but got I4
		//IL_080c: Expected O, but got Ref
		//IL_0844: Expected native int or pointer, but got O
		//IL_0b47: Expected O, but got I
		//IL_088b: Expected O, but got Ref
		//IL_08a4: Expected native int or pointer, but got O
		//IL_0b81: Expected O, but got I
		//IL_08f5: Expected O, but got I
		//IL_0baf: Expected O, but got I
		//IL_0c2a: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (_particlesBuilt)
		{
			return;
		}
		Camera main = Camera.main;
		bool flag = (object)main == null;
		float num = 1f;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
			num = 1f;
			if (!flag2)
			{
				Camera main2 = Camera.main;
				num = 0.666875f;
			}
		}
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("items");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"GemRed.png");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"GemBlue.png");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"GemGreen.png");
		}
		else
		{
			int size3 = list._size + 1;
			list._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, renderer.width));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+18]");
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+28]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(4000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
		float max = num * 200f;
		float min = num * 100f;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(min, max));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+68]");
		_ = 0;
		particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 120));
		float min2 = num + num;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(min2, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+88]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
		_ = 0;
		_ = 0;
		_ = 4;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+160]");
		particleSystemConfig._quantity = (int?)(object)0;
		Transform transform = _GemManager.transform;
		Transform parent = default(Transform);
		string psName = default(string);
		bool isAdditive = default(bool);
		bool requiresMasking = default(bool);
		ParticleSystem gems = _GemManager.CreateUIEmitter(particleSystemConfig, "UI", 2, parent, psName, isAdditive, requiresMasking);
		_Gems = gems;
		_ = _Gems;
		_ = _Gems;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C8]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj3 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 368));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1717 @ rax_v53 (should have been resolved before IL gen)");
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("items");
		List<string> list2 = new List<string>();
		list2._002Ector();
		int version4 = list2._version + 1;
		list2._version = version4;
		string[] items4 = list2._items;
		if (list2._size >= items4.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"cat_i01");
		}
		else
		{
			int size4 = list2._size + 1;
			list2._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list2._version + 1;
		list2._version = version5;
		string[] items5 = list2._items;
		if (list2._size >= items5.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"cat3_i01");
		}
		else
		{
			int size5 = list2._size + 1;
			list2._size = size5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version6 = list2._version + 1;
		list2._version = version6;
		string[] items6 = list2._items;
		if (list2._size >= items6.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"cat2_i01");
		}
		else
		{
			int size6 = list2._size + 1;
			list2._size = size6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		if ((object)GM.Core == null)
		{
			throw new NullReferenceException();
		}
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, renderer2.width));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+98]");
		particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 184));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B8]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C8]");
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(4000f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 216));
		float max2 = num * 200f;
		float min3 = num * 100f;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(min3, max2));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+D8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
		particleSystemConfig2._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
		_ = 0;
		float min4 = num + num;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 248));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(min4, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+108]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-10]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+10]");
		_ = 0;
		_ = 0;
		_ = 4;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+160]");
		particleSystemConfig2._quantity = (int?)(object)0;
		Transform transform2 = _GemManager.transform;
		ParticleSystem cats = _GemManager.CreateUIEmitter(particleSystemConfig2, "UI", 0, parent, psName, isAdditive, requiresMasking);
		_Cats = cats;
		_ = _Cats;
		_ = _Cats;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C8]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj5 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
		}
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 376));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2584 @ rax_v91 (should have been resolved before IL gen)");
		GameObject gameObject = _Cats.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = _Gems.gameObject;
		gameObject2.SetActive(value: false);
		_particlesBuilt = true;
	}

	private unsafe void BuildBanishedWeaponsList()
	{
		//IL_00b7: Expected O, but got I
		//IL_00c6: Expected O, but got I
		//IL_01dc: Expected O, but got I
		//IL_01c7: Expected O, but got I
		//IL_01f1: Expected O, but got I
		//IL_01b2: Expected O, but got I
		//IL_0233: Expected O, but got I
		//IL_017a: Expected O, but got I
		//IL_03ee: Expected O, but got I4
		//IL_0b3b: Expected I4, but got O
		//IL_040d: Expected F4, but got I
		//IL_0416: Expected O, but got I4
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Expected F4, but got Unknown
		//IL_0832: Expected O, but got Ref
		//IL_08f2: Expected O, but got I4
		//IL_0c7b: Expected I4, but got O
		//IL_05d3: Expected O, but got I
		//IL_05d3: Expected O, but got I
		//IL_06e0: Expected O, but got Ref
		//IL_07e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07eb: Expected O, but got Unknown
		//IL_0b06->IL08f7: Incompatible stack heights: 1 vs 0
		//IL_0a1c->IL08f7: Incompatible stack heights: 1 vs 0
		//IL_0b55->IL08f7: Incompatible stack heights: 2 vs 0
		//IL_02db->IL08f7: Incompatible stack heights: 1 vs 0
		//IL_0cc9->IL08f7: Incompatible stack heights: 2 vs 0
		//IL_0aa6->IL08f7: Incompatible stack heights: 2 vs 0
		//IL_0311->IL08f7: Incompatible stack heights: 2 vs 0
		//IL_0349->IL0349: Incompatible stack heights: 2 vs 0
		//IL_0458->IL0b64: Incompatible stack heights: 3 vs 2
		//IL_083b->IL08f7: Incompatible stack heights: 2 vs 0
		//IL_04f5->IL0b64: Incompatible stack heights: 6 vs 2
		//IL_0c46->IL08f7: Incompatible stack heights: 3 vs 0
		//IL_0862->IL08f7: Incompatible stack heights: 3 vs 0
		//IL_0c80->IL0cce: Incompatible stack heights: 4 vs 2
		//IL_07fb->IL0b8a: Incompatible stack heights: 15 vs 14
		//IL_080a->IL0b64: Incompatible stack heights: 15 vs 2
		bool flag = _banishedWeaponList == null;
		GameObject gameObject = (GameObject)(object)this;
		object obj;
		if (!flag)
		{
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			while (enumerator.MoveNext())
			{
				UnityEngine.Object.Destroy(null, 0f);
			}
			gameObject = (GameObject)(object)_banishedWeaponList;
			if (_banishedWeaponList != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rcx_v58 (UnityEngine.GameObject)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rcx_v58 (UnityEngine.GameObject)+18]");
				int num = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rcx_v58 (UnityEngine.GameObject)+18]");
				if ((nint)0 > (nint)0)
				{
					IntPtr cachedPtr = ((UnityEngine.Object)gameObject).m_CachedPtr;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rcx_v58 (UnityEngine.GameObject)+18]");
					Array.Clear((Array)(nint)cachedPtr, 0, 0);
					gameObject = (GameObject)(nint)((UnityEngine.Object)gameObject).m_CachedPtr;
				}
				if (_levelUpFactory != null)
				{
					gameObject = (GameObject)(object)LevelUpFactory._banishedWeapons;
					if (LevelUpFactory._banishedWeapons != null)
					{
						object playerOptions = _playerOptions;
						if (_playerOptions != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdi_v30 (System.Object)+68]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdi_v30 (System.Object)+58]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdi_v30 (System.Object)+78]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdi_v30 (System.Object)+78]");
										obj = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v79+2CC]");
										if ((nint)0 != 0)
										{
											goto IL_09af;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdi_v30 (System.Object)+50]");
									obj = 0;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdi_v30 (System.Object)+58]");
									obj = 0;
								}
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdi_v30 (System.Object)+68]");
								obj = 0;
							}
							goto IL_09af;
						}
					}
				}
			}
		}
		goto IL_08f7;
		IL_09af:
		List<GameObject>.Enumerator enumerator2;
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v79+268]");
			gameObject = (GameObject)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v79+268]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rcx_v58 (UnityEngine.GameObject)+18]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rcx_v58 (UnityEngine.GameObject)+18]");
				enumerator2 = (List<GameObject>.Enumerator)(num2 - 0);
				if ((nint)enumerator2 <= 11)
				{
					goto IL_0349;
				}
				gameObject = _BanishedWeaponPrefab;
				if ((object)_BanishedWeaponPrefab != null)
				{
					RectTransform component = _BanishedWeaponPrefab.GetComponent<RectTransform>();
					if ((object)component != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ rax_v161 (UnityEngine.RectTransform)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ rax_v161 (UnityEngine.RectTransform)+10]");
						RectTransform.get_sizeDelta_Injected((IntPtr)0, out Vector2 ret);
						if ((object)_BanishedWeaponPrefab != null)
						{
							RectTransform component2 = _BanishedWeaponPrefab.GetComponent<RectTransform>();
							if ((object)component2 != null)
							{
								bool flag3 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
								RectTransform.get_sizeDelta_Injected(((UnityEngine.Object)component2).m_CachedPtr, out Vector2 ret2);
								float num3 = (float)ret2 * 12f;
								object obj2 = (object)enumerator2 * (object)ret;
								float num4 = (float)obj2 - num3;
								float num5 = num4 / (float)enumerator2;
								if ((object)_BanishedWeaponsContainer != null)
								{
									HorizontalLayoutGroup component3 = _BanishedWeaponsContainer.GetComponent<HorizontalLayoutGroup>();
									if ((object)component3 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
										float spacing = num5 ^ 0;
										component3.spacing = spacing;
										int num = 0;
										goto IL_0349;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_08f7;
		IL_08f7:
		throw new NullReferenceException();
		IL_0349:
		object banishedWeaponsContainer = _BanishedWeaponsContainer;
		if ((object)_BanishedWeaponsContainer != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rdi_v32 (System.Object)+10]");
			bool flag4 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rdi_v32 (System.Object)+10]");
			IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
			GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
			if ((object)gameObject2 != null)
			{
				bool flag5 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
				object obj3 = (object)enumerator2 ^ (object)enumerator2;
				object obj4 = (object)enumerator2 & obj3;
				bool flag6 = (nint)obj4 < 0;
				bool flag7 = (nint)enumerator2 < 0;
				bool flag8 = (object)enumerator2 == null;
				bool flag9 = flag7 == flag6;
				bool flag10 = !flag8;
				object obj5 = flag10 & flag9;
				GameObject.SetActive_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr, (byte)(int)obj5 != 0);
				if (_levelUpFactory != null)
				{
					LinkedList<WeaponType> banishedWeapons = LevelUpFactory._banishedWeapons;
					if (LevelUpFactory._banishedWeapons != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ r9_v32 (System.Collections.Generic.LinkedList`1<VampireSurvivors.Data.WeaponType>)+1C]");
						float num6 = 0f;
						object obj6 = 0;
						LinkedList<WeaponType>.Enumerator enumerator3 = default(LinkedList<WeaponType>.Enumerator);
						System.Int32Enum key = default(System.Int32Enum);
						LinkedList<WeaponType>.Enumerator enumerator4 = default(LinkedList<WeaponType>.Enumerator);
						while (enumerator3.MoveNext())
						{
							bool flag11 = _weaponData == null;
							int num7 = ((Dictionary<System.Int32Enum, object>)(object)_weaponData).FindEntry(key);
							int num = 0;
							if (flag11)
							{
								continue;
							}
							bool flag12 = _playerOptions == null;
							PlayerOptionsData config = _playerOptions.Config;
							bool flag13 = config == null;
							bool flag14 = config._003CContentGroupSealedWeapons_003Ek__BackingField == null;
							int num8 = ((Dictionary<WeaponType, List<WeaponData>>)(object)config._003CContentGroupSealedWeapons_003Ek__BackingField).FindEntry((WeaponType)key);
							bool flag15 = num8 != 0;
							num = 0;
							if (flag15)
							{
								continue;
							}
							bool flag16 = _weaponData == null;
							object obj7 = ((Dictionary<System.Int32Enum, object>)(object)_weaponData).get_Item(key);
							bool flag17 = obj7 == null;
							List<WeaponData> list = ((Dictionary<WeaponType, List<WeaponData>>)obj7).get_Item(WeaponType.VOID);
							GameObject gameObject3 = UnityEngine.Object.Instantiate(_BanishedWeaponPrefab, _BanishedWeaponsContainer);
							bool flag18 = (object)gameObject3 == null;
							Image component4 = gameObject3.GetComponent<Image>();
							bool flag19 = list == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3049 @ rax_v125 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+40]");
							nint num9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3049 @ rax_v125 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+38]");
							Sprite sprite = SpriteManager.GetSprite((string)num9, (string)0);
							bool flag20 = (object)component4 == null;
							component4.sprite = sprite;
							Transform transform = gameObject3.transform;
							bool flag21 = (object)transform == null;
							Transform child = transform.GetChild(0);
							bool flag22 = (object)child == null;
							Image component5 = child.GetComponent<Image>();
							if ((nint)enumerator2 > 11)
							{
								bool flag23 = (object)component5 == null;
								component5.enabled = false;
								banishedWeapons = null;
								num = 0;
							}
							else
							{
								bool flag24 = (object)component5 == null;
								component5.color = (Color)(&enumerator4);
								TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleUI.DOFade(component5, 0.25f, 1.2f);
								num6 = (float)obj6 * 0.2f;
								TweenerCore<Color, Color, ColorOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, num6);
								if (tweenerCore != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1523 @ rax_v140 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1523 @ rax_v140 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
										if ((nint)0 == 0)
										{
											_ = 4294967295L;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1523 @ rax_v140 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
											if ((nint)0 == 0)
											{
												_ = 2139095040;
											}
										}
									}
								}
								bool flag25 = _activeTweens == null;
								TweenerCore<Color, Color, ColorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay((TweenerCore<Color, Color, ColorOptions>)(object)_activeTweens, num6);
								obj6++;
								banishedWeapons = null;
								num = 0;
							}
							bool flag26 = _banishedWeaponList == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
						}
						if (_banishedWeaponList == null)
						{
							return;
						}
						object banishedWeaponsContainer2 = _BanishedWeaponsContainer;
						bool flag27 = (object)_BanishedWeaponsContainer == null;
						gameObject = (GameObject)(&enumerator3);
						if (!flag27)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rbx_v33 (System.Object)+10]");
							bool flag28 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rbx_v33 (System.Object)+10]");
							IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
							GameObject gameObject4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
							List<GameObject> banishedWeaponList = _banishedWeaponList;
							if (_banishedWeaponList != null && (object)gameObject4 != null)
							{
								bool flag29 = ((UnityEngine.Object)gameObject4).m_CachedPtr == (IntPtr)0;
								int num10 = banishedWeaponList._size ^ banishedWeaponList._size;
								int num11 = banishedWeaponList._size & num10;
								bool flag30 = num11 < 0;
								bool flag31 = banishedWeaponList._size < 0;
								bool flag32 = banishedWeaponList._size == 0;
								bool flag33 = flag31 == flag30;
								bool flag34 = !flag32;
								Image image = (Image)(flag34 & flag33);
								GameObject.SetActive_Injected(((UnityEngine.Object)gameObject4).m_CachedPtr, (byte)(int)image != 0);
								return;
							}
						}
					}
				}
			}
		}
		goto IL_08f7;
	}

	private void UpdateButtonsUI()
	{
		//IL_0068: Expected I, but got O
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_021e: Expected I, but got O
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected O, but got Unknown
		//IL_03d4: Expected I, but got O
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Expected O, but got Unknown
		//IL_045c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0461: Expected O, but got Unknown
		bool active = _hasReRolls && IsLocalPlayerControllingUi();
		_RerollButton.SetActive(active);
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation("lang/levelup_Xleft", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		nint num = (nint)this;
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
		PlayerModifierStats playerStats = characterControllingUi._playerStats;
		EggFloat eggFloat = playerStats._003CReRolls_003Ek__BackingField;
		float num2 = eggFloat._eggVal + eggFloat._val;
		object obj = num2 & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num2 & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186CFD8C6h\"");
				if (num2 == -1f / 0f)
				{
					num2 = -3.4028235E+38f;
				}
				goto IL_05ab;
			}
		}
		num2 = 3.4028235E+38f;
		goto IL_05ab;
		IL_05c8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		float num3;
		string newValue = System.Number.FormatSingle(num3, null, currentInfo);
		string translation2;
		string text = translation2.Replace("%0", newValue);
		_SkipRemainingText.text = text;
		bool active2 = _hasBanish && IsLocalPlayerControllingUi();
		_BanishButton.SetActive(active2);
		string translation3 = LocalizationManager.GetTranslation("lang/levelup_Xleft", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		nint num4 = (nint)this;
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi2 = GetCharacterControllingUi();
		PlayerModifierStats playerStats2 = characterControllingUi2._playerStats;
		EggFloat eggFloat2 = playerStats2._003CBanish_003Ek__BackingField;
		float num5 = eggFloat2._eggVal + eggFloat2._val;
		object obj3 = num5 & -2147483649L;
		float value;
		if ((nint)obj3 != 2139095040)
		{
			object obj4 = num5 & -2147483649L;
			if ((nint)obj4 <= 2139095040)
			{
				bool flag = num5 == -1f / 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186CFDBE5h\"");
				value = -3.4028235E+38f;
				if (!flag)
				{
					value = num5;
				}
				goto IL_05e5;
			}
		}
		value = 3.4028235E+38f;
		goto IL_05e5;
		IL_05e5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		NumberFormatInfo currentInfo2 = NumberFormatInfo.CurrentInfo;
		string newValue2 = System.Number.FormatSingle(value, null, currentInfo2);
		string text2 = translation3.Replace("%0", newValue2);
		_BanishRemainingText.text = text2;
		bool active3 = _hasSkips && _canPass && IsLocalPlayerControllingUi();
		_PassButton.SetActive(active3);
		_PassRemainingText.text = text;
		return;
		IL_05ab:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		NumberFormatInfo currentInfo3 = NumberFormatInfo.CurrentInfo;
		string newValue3 = System.Number.FormatSingle(num2, null, currentInfo3);
		string text3 = translation.Replace("%0", newValue3);
		_RerollRemainingText.text = text3;
		bool active4 = _hasSkips && IsLocalPlayerControllingUi();
		_SkipButton.SetActive(active4);
		translation2 = LocalizationManager.GetTranslation("lang/levelup_Xleft", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		nint num6 = (nint)this;
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi3 = GetCharacterControllingUi();
		PlayerModifierStats playerStats3 = characterControllingUi3._playerStats;
		EggFloat eggFloat3 = playerStats3._003CSkips_003Ek__BackingField;
		num3 = eggFloat3._eggVal + eggFloat3._val;
		object obj5 = num3 & -2147483649L;
		if ((nint)obj5 != 2139095040)
		{
			object obj6 = num3 & -2147483649L;
			if ((nint)obj6 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186CFDA59h\"");
				if (num3 == -1f / 0f)
				{
					num3 = -3.4028235E+38f;
				}
				goto IL_05c8;
			}
		}
		num3 = 3.4028235E+38f;
		goto IL_05c8;
	}

	private void ValidateButtonStates()
	{
		//IL_0039: Expected I, but got O
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_04b4: Expected I, but got O
		//IL_04bd: Invalid comparison between F4 and I4
		//IL_04cc: Invalid comparison between F4 and I4
		//IL_04f5: Expected O, but got I4
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_0513: Expected I, but got O
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Expected O, but got Unknown
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Expected O, but got Unknown
		//IL_0562: Unknown result type (might be due to invalid IL or missing references)
		//IL_0567: Expected O, but got Unknown
		//IL_0581: Expected O, but got I4
		//IL_05a2: Invalid comparison between F4 and I4
		//IL_067e: Invalid comparison between F4 and I4
		GameManager core = GM.Core;
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
		bool flag = core._levelUpFactory.HasPowerupsInStore(characterControllingUi);
		List<WeightedWeapon> weightedStore = LevelUpFactory._weightedStore;
		nint num = (nint)this;
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi2 = GetCharacterControllingUi();
		PlayerModifierStats playerStats = characterControllingUi2._playerStats;
		EggFloat eggFloat = playerStats._003CReRolls_003Ek__BackingField;
		float num2 = eggFloat._eggVal + eggFloat._val;
		object obj = num2 & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num2 & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186CFDED4h\"");
				if (num2 == -1f / 0f)
				{
					num2 = -3.4028235E+38f;
				}
				goto IL_04a5;
			}
		}
		num2 = 3.4028235E+38f;
		goto IL_04a5;
		IL_04a5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		nint num3 = (nint)this;
		bool flag2 = num2 < 0f;
		bool flag3 = num2 == 0f;
		bool flag4 = !flag2;
		bool flag5 = !flag3;
		object obj3 = flag5 & flag4;
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi3 = GetCharacterControllingUi();
		PlayerModifierStats playerStats2 = characterControllingUi3._playerStats;
		EggFloat eggFloat2 = playerStats2._003CSkips_003Ek__BackingField;
		float num4 = eggFloat2._eggVal + eggFloat2._val;
		object obj4 = num4 & -2147483649L;
		if ((nint)obj4 != 2139095040)
		{
			object obj5 = num4 & -2147483649L;
			if ((nint)obj5 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186CFDF61h\"");
				if (num4 == -1f / 0f)
				{
					num4 = -3.4028235E+38f;
				}
				goto IL_0504;
			}
		}
		num4 = 3.4028235E+38f;
		goto IL_0504;
		IL_0504:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		nint num5 = (nint)this;
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi4 = GetCharacterControllingUi();
		PlayerModifierStats playerStats3 = characterControllingUi4._playerStats;
		EggFloat eggFloat3 = playerStats3._003CBanish_003Ek__BackingField;
		float num6 = eggFloat3._eggVal + eggFloat3._val;
		object obj6 = num6 & -2147483649L;
		float num7;
		if ((nint)obj6 != 2139095040)
		{
			object obj7 = num6 & -2147483649L;
			if ((nint)obj7 <= 2139095040)
			{
				bool flag6 = num6 == -1f / 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186CFDFDCh\"");
				num7 = -3.4028235E+38f;
				if (!flag6)
				{
					num7 = num6;
				}
				goto IL_0522;
			}
		}
		num7 = 3.4028235E+38f;
		goto IL_0522;
		IL_0522:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		bool flag7 = weightedStore._size <= 4;
		bool flag8 = false;
		if (!flag7)
		{
			flag8 = flag;
		}
		object obj8 = obj3 & flag8;
		bool flag9 = obj8 == null;
		object obj9 = !flag9;
		bool hasReRolls;
		if (obj9 == null)
		{
			hasReRolls = false;
		}
		else
		{
			bool flag10 = !_hasPassed;
			hasReRolls = flag10;
		}
		_hasReRolls = hasReRolls;
		bool flag11 = !(num4 > 0f);
		bool hasSkips = false;
		if (!flag11)
		{
			hasSkips = flag;
		}
		_hasSkips = hasSkips;
		bool flag12 = !(num7 > 0f);
		bool flag13 = false;
		if (!flag12)
		{
			flag13 = flag;
		}
		bool hasBanish;
		if (!flag13)
		{
			hasBanish = false;
		}
		else
		{
			bool flag14 = !_hasPassed;
			hasBanish = flag14;
		}
		_hasBanish = hasBanish;
		_canPass = false;
		GameManager core2 = GM.Core;
		if (core2._mainCharacters == null)
		{
			return;
		}
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core2._mainCharacters;
		if (mainCharacters._size <= 1)
		{
			return;
		}
		GameManager core3 = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = core3._characters;
		bool flag15 = false;
		bool flag16 = false;
		bool flag17 = false;
		VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = default(VampireSurvivors.Objects.Characters.CharacterController);
		while ((flag17 ? 1 : 0) < characters._size)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			if (!characterController.IsDisconnectedFromOnlinePlay)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				if (!characterController2._isDead && !characterController2.IsDisconnectedFromOnlinePlay)
				{
					flag15 = (byte)((flag15 ? 1u : 0u) + 1u) != 0;
				}
			}
			flag16 = (byte)((flag16 ? 1u : 0u) + 1u) != 0;
			flag17 = flag16;
		}
		if (!flag15)
		{
			CheckIfPassAvailable();
		}
	}

	private unsafe void DoIntroEffects()
	{
		//IL_009b: Expected O, but got Ref
		//IL_0127: Expected O, but got Ref
		//IL_0239: Expected O, but got Ref
		if ((object)_ExplosionVFX != null)
		{
			Image componentInParent = _ExplosionVFX.GetComponentInParent<Image>();
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null && (object)componentInParent != null)
				{
					Color color = componentInParent.color;
					Vector3 value = default(Vector3);
					componentInParent.color = (Color)(&value);
					if ((object)_ExplosionVFX != null)
					{
						_ExplosionVFX.Play(hideWhenDone: true);
						if ((object)_Panel != null)
						{
							Transform transform = _Panel.transform;
							if ((object)transform != null)
							{
								object obj = default(object);
								transform.localEulerAngles = (Vector3)(&obj);
								if ((object)_Panel != null)
								{
									Transform target = _Panel.transform;
									TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DORotate(target, (Vector3)(&obj), 0.15f);
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
									Transform transform2 = _Panel.transform;
									bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
									Transform target2 = _Panel.transform;
									TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target2, 1f, 0.15f);
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
									Animate();
									_003CDelaySetFooter_003Ed__86 obj2 = null;
									obj2._003C_003E1__state = 0;
									obj2._003C_003E4__this = this;
									obj2.enabled = true;
									Coroutine coroutine = StartCoroutine(obj2);
									_003CTweenButtonsNextFrame_003Ed__128 obj3 = null;
									obj3._003C_003E1__state = 0;
									obj3._003C_003E4__this = this;
									Coroutine coroutine2 = StartCoroutine(obj3);
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private IEnumerator TweenButtonsNextFrame()
	{
		_003CTweenButtonsNextFrame_003Ed__128 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe Sequence TweenButtonIn(GameObject g, float baseScale = 1f)
	{
		//IL_00ac: Expected O, but got Ref
		//IL_023a: Expected O, but got Ref
		_003C_003Ec__DisplayClass129_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass129_0();
		RectTransform component = g.GetComponent<RectTransform>();
		CS_0024_003C_003E8__locals9.b = component;
		Button component2 = CS_0024_003C_003E8__locals9.b.GetComponent<Button>();
		component2.enabled = false;
		Transform transform = CS_0024_003C_003E8__locals9.b.transform;
		bool flag = (object)transform == null;
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		bool flag3 = (object)CS_0024_003C_003E8__locals9.b == null;
		Transform transform2 = CS_0024_003C_003E8__locals9.b.transform;
		bool flag4 = (object)transform2 == null;
		object obj = default(object);
		transform2.eulerAngles = (Vector3)(&obj);
		Sequence sequence = DOTween.Sequence();
		TweenerCore<Quaternion, Vector3, QuaternionOptions> t = ShortcutExtensions.DOLocalRotate(CS_0024_003C_003E8__locals9.b, (Vector3)(&obj), 0.15f);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, 0f);
		}
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(CS_0024_003C_003E8__locals9.b, baseScale, 0.15f);
		TweenCallback tweenCallback = delegate
		{
			Button component3 = CS_0024_003C_003E8__locals9.b.GetComponent<Button>();
			component3.enabled = true;
			Button component4 = CS_0024_003C_003E8__locals9.b.GetComponent<Button>();
			component4.interactable = true;
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rax_v34 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)tweenerCore, 0f);
		}
		return sequence;
	}

	private unsafe void Animate()
	{
		//IL_06bc: Expected I, but got O
		//IL_06dc: Expected O, but got I
		//IL_00af: Expected O, but got I4
		//IL_00b8: Expected O, but got I4
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Expected O, but got Unknown
		//IL_04c6: Expected I, but got O
		//IL_04dc: Expected O, but got I
		//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ea: Expected O, but got Unknown
		//IL_0560: Expected I, but got O
		//IL_07a0: Expected O, but got I4
		//IL_07b7: Expected I, but got I8
		//IL_053c: Expected I, but got I8
		LayoutRebuilder.ForceRebuildLayoutImmediate(Container);
		Canvas.ForceUpdateCanvases();
		RectTransform component = Container.GetComponent<RectTransform>();
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rcx_v9 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rdx_v5 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		object obj = 0;
		Vector2 vector = default(Vector2);
		component.anchoredPosition = vector;
		VerticalLayoutGroup component2 = Container.GetComponent<VerticalLayoutGroup>();
		component2.enabled = false;
		Sequence sequence = DOTween.Sequence();
		if (_spawnedItems == null)
		{
			return;
		}
		List<LevelUpItemUI> spawnedItems = _spawnedItems;
		TweenCallback tweenCallback = null;
		Vector2 vector2 = vector;
		object obj2 = 0;
		object obj3 = 0;
		Component component4 = default(Component);
		Component component6 = default(Component);
		object obj4 = default(object);
		while (true)
		{
			List<LevelUpItemUI> spawnedItems2 = _spawnedItems;
			if ((nint)obj3 < spawnedItems._size)
			{
				if ((nint)obj2 >= spawnedItems2._size)
				{
					break;
				}
				LevelUpItemUI[] items = spawnedItems2._items;
				LevelUpItemUI levelUpItemUI = items[obj2];
				if ((object)items[obj2] != null && ((UnityEngine.Object)levelUpItemUI).m_CachedPtr != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Button component3 = component4.GetComponent<Button>();
					component3.enabled = false;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					RectTransform component5 = component6.GetComponent<RectTransform>();
					Vector2 anchoredPosition = component5.anchoredPosition;
					component5.anchoredPosition = vector;
					Vector2 sizeDelta = component5.sizeDelta;
					Vector2 anchoredPosition2 = component5.anchoredPosition;
					float num3 = (float)obj2 * 0.03f;
					float duration = num3 + 0.15f;
					TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOAnchorPos(component5, vector, duration);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
					bool flag = false;
					obj = obj4;
					tweenCallback = null;
					vector2 = vector;
				}
				spawnedItems = _spawnedItems;
				obj2++;
				obj3 = obj2;
				continue;
			}
			float num4 = (float)spawnedItems2._size * 0.03f;
			float num5 = num4 + 0.15f;
			object message;
			if (sequence != null)
			{
				if (((Tween)sequence)._003Cactive_003Ek__BackingField)
				{
					if (!((Tween)sequence).creationLocked)
					{
						num5 += ((Tween)sequence).duration;
						sequence.lastTweenInsertTime = ((Tween)sequence).duration;
						((Tween)sequence).duration = num5;
						goto IL_03c8;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					message = "You can't add elements to an inactive/killed Sequence";
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message = "You can't add elements to a NULL Sequence";
			}
			Debugger.LogWarning(message);
			tweenCallback = null;
			goto IL_03c8;
			IL_061c:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
			return;
			IL_0797:
			object obj5 = 24;
			TweenCallback tweenCallback2;
			((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
			Tween t;
			object message2;
			if (sequence != null)
			{
				if (((Tween)sequence)._003Cactive_003Ek__BackingField)
				{
					if (!((Tween)sequence).creationLocked)
					{
						float duration = ((Tween)sequence).duration;
						Sequence sequence2 = Sequence.DoInsertCallback(sequence, tweenCallback2, ((Tween)sequence).duration);
						bool flag = false;
						tweenCallback = tweenCallback2;
						goto IL_061c;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					tweenCallback = null;
					t = null;
					message2 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					tweenCallback = null;
					t = null;
					message2 = "You can't add elements to an inactive/killed Sequence";
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				tweenCallback = null;
				t = null;
				message2 = "You can't add elements to a NULL Sequence";
			}
			Debugger.LogWarning(message2, t);
			goto IL_061c;
			IL_03c8:
			List<LevelUpItemUI> spawnedItems3 = _spawnedItems;
			if (spawnedItems3._size > 0)
			{
				if (spawnedItems3._size <= 0)
				{
					break;
				}
				LevelUpItemUI[] items2 = spawnedItems3._items;
				LevelUpItemUI levelUpItemUI2 = items2[0];
				if ((object)items2[0] != null && ((UnityEngine.Object)levelUpItemUI2).m_CachedPtr != (IntPtr)0)
				{
					tweenCallback2 = null;
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ r10_v5 (Il2CppMethodInfo)+8]");
					((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
					((Delegate)tweenCallback2).method = (nint)__ldftn(LevelUpPage._003CAnimate_003Eb__130_0);
					((Delegate)tweenCallback2).m_target = this;
					((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ r10_v5 (Il2CppMethodInfo)+4C]");
					object obj6 = (nint)0 >> 4;
					object obj7 = obj6 & 1;
					nint num7;
					if (obj7 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ r10_v5 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num7 = unchecked((nint)6447293664L);
							goto IL_0797;
						}
					}
					num7 = ((Delegate)tweenCallback2).method_ptr;
					((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
					goto IL_0797;
				}
			}
			goto IL_061c;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	private void OnLevelUpPageIntroAnimComplete()
	{
		if (TwitchIntegration._sInstance.IsTwitchOn() && TwitchIntegration._sInstance.IsTwitchWorking())
		{
			_TwitchLevelUpPanel.ShowCountdown();
		}
	}

	protected override void OnHideStart(GameObject g)
	{
		base.OnHideStart(g);
		if (_particlesBuilt)
		{
			ParticleSystem gems = _Gems;
			if ((object)_Gems != null && ((UnityEngine.Object)gems).m_CachedPtr != (IntPtr)0)
			{
				_GemManager.RemoveEmitter(_Gems);
				UnityEngine.Object.Destroy(_Gems, 0f);
			}
			ParticleSystem cats = _Cats;
			if ((object)_Cats != null && ((UnityEngine.Object)cats).m_CachedPtr != (IntPtr)0)
			{
				_GemManager.RemoveEmitter(_Cats);
				UnityEngine.Object.Destroy(_Cats, 0f);
			}
			_particlesBuilt = false;
		}
	}

	protected override void OnHideFinish(GameObject g)
	{
		//IL_00e2: Invalid comparison between F4 and I4
		//IL_0115: Expected I4, but got F4
		//IL_0115: Expected O, but got I4
		//IL_0122: Expected O, but got I4
		//IL_01b0: Invalid comparison between F4 and I4
		//IL_01e3: Expected I4, but got F4
		//IL_01e3: Expected O, but got I4
		//IL_017c->IL055f: Incompatible stack heights: 1 vs 0
		//IL_0673->IL047f: Incompatible stack heights: 1 vs 0
		//IL_07a4->IL047f: Incompatible stack heights: 1 vs 0
		//IL_06d3->IL047f: Incompatible stack heights: 2 vs 0
		//IL_0804->IL047f: Incompatible stack heights: 2 vs 0
		//IL_03a8->IL03a8: Incompatible stack heights: 3 vs 0
		//IL_047e->IL047e: Incompatible stack heights: 3 vs 0
		base.OnHideFinish(g);
		Tween colorTween = _colorTween;
		if (_colorTween != null && colorTween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Kill(_colorTween);
		}
		if (_activeTweens != null)
		{
			List<Tween>.Enumerator enumerator = default(List<Tween>.Enumerator);
			while (enumerator.MoveNext())
			{
				Tween tween = null;
			}
			colorTween = (Tween)(object)_activeTweens;
			if (_activeTweens != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rcx_v45 (DG.Tweening.Tween)+1C]");
				_ = (nint)0 + (nint)1;
				((ABSSequentiable)colorTween).sequencedEndPosition = 0f;
				if (((ABSSequentiable)colorTween).sequencedEndPosition > 0f)
				{
					Array.Clear((Array)((ABSSequentiable)colorTween).tweenType, 0, (int)((ABSSequentiable)colorTween).sequencedEndPosition);
					colorTween = (Tween)((ABSSequentiable)colorTween).tweenType;
				}
				if (_spawnedItems != null)
				{
					List<LevelUpItemUI>.Enumerator enumerator2 = default(List<LevelUpItemUI>.Enumerator);
					while (enumerator2.MoveNext())
					{
						object obj = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rdi_v34 (System.Object)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rdi_v34 (System.Object)+10]");
						IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
						GameObject obj2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
						UnityEngine.Object.Destroy(obj2, 0f);
					}
					colorTween = (Tween)(object)_spawnedItems;
					if (_spawnedItems != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rcx_v45 (DG.Tweening.Tween)+1C]");
						_ = (nint)0 + (nint)1;
						((ABSSequentiable)colorTween).sequencedEndPosition = 0f;
						if (((ABSSequentiable)colorTween).sequencedEndPosition > 0f)
						{
							Array.Clear((Array)((ABSSequentiable)colorTween).tweenType, 0, (int)((ABSSequentiable)colorTween).sequencedEndPosition);
						}
						ExitMultiplayerControl();
						TwitchLevelUpPanel twitchLevelUpPanel = _TwitchLevelUpPanel;
						if ((object)_TwitchLevelUpPanel == null || ((UnityEngine.Object)twitchLevelUpPanel).m_CachedPtr == (IntPtr)0)
						{
							goto IL_02d1;
						}
						TwitchLevelUpPanel twitchLevelUpPanel2 = _TwitchLevelUpPanel;
						bool flag2 = (object)_TwitchLevelUpPanel == null;
						colorTween = (Tween)(object)typeof(UnityEngine.Object);
						if (!flag2 && (object)twitchLevelUpPanel2._NavigatorsRoot != null)
						{
							twitchLevelUpPanel2._NavigatorsRoot.SetActive(value: true);
							RewiredStandaloneInputModule inputModule = _TwitchLevelUpPanel.InputModule;
							if ((object)inputModule != null)
							{
								inputModule.enabled = true;
								Debug.Log("Re-enabling all UI interaction");
								goto IL_02d1;
							}
						}
					}
				}
			}
		}
		goto IL_047f;
		IL_047f:
		throw new NullReferenceException();
		IL_02d1:
		TwitchLevelUpPanel gems = (TwitchLevelUpPanel)(object)_Gems;
		if ((object)_Gems == null || ((UnityEngine.Object)gems).m_CachedPtr == (IntPtr)0)
		{
			goto IL_03a8;
		}
		if ((object)_GemManager != null)
		{
			_GemManager.RemoveEmitter(_Gems);
			object gems2 = _Gems;
			if ((object)_Gems != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rdi_v29 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rdi_v29 (System.Object)+10]");
				IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
				Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
				if ((object)transform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rax_v125 (UnityEngine.Transform)+10]");
					bool flag4 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rax_v125 (UnityEngine.Transform)+10]");
					IntPtr parent_Injected = Transform.GetParent_Injected((IntPtr)0);
					Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected);
					if ((object)transform2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rax_v130 (UnityEngine.Transform)+10]");
						bool flag5 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rax_v130 (UnityEngine.Transform)+10]");
						IntPtr gcHandlePtr3 = Component.get_gameObject_Injected((IntPtr)0);
						GameObject obj3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr3);
						UnityEngine.Object.Destroy(obj3, 0f);
						_Gems = null;
						goto IL_03a8;
					}
				}
			}
		}
		goto IL_047f;
		IL_03a8:
		TwitchLevelUpPanel cats = (TwitchLevelUpPanel)(object)_Cats;
		if ((object)_Cats == null || ((UnityEngine.Object)cats).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if ((object)_GemManager != null)
		{
			_GemManager.RemoveEmitter(_Cats);
			object cats2 = _Cats;
			if ((object)_Cats != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdi_v25 (System.Object)+10]");
				bool flag6 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdi_v25 (System.Object)+10]");
				IntPtr gcHandlePtr4 = Component.get_transform_Injected((IntPtr)0);
				Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
				if ((object)transform3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rax_v83 (UnityEngine.Transform)+10]");
					bool flag7 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rax_v83 (UnityEngine.Transform)+10]");
					IntPtr parent_Injected2 = Transform.GetParent_Injected((IntPtr)0);
					Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected2);
					if ((object)transform4 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rax_v88 (UnityEngine.Transform)+10]");
						bool flag8 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rax_v88 (UnityEngine.Transform)+10]");
						IntPtr gcHandlePtr5 = Component.get_gameObject_Injected((IntPtr)0);
						GameObject obj4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr5);
						UnityEngine.Object.Destroy(obj4, 0f);
						_Cats = null;
						return;
					}
				}
			}
		}
		goto IL_047f;
	}

	private void Populate()
	{
		//IL_0013: Expected F4, but got I4
		//IL_0021: Expected F4, but got I4
		//IL_0048: Expected F4, but got I4
		//IL_025a: Expected O, but got I
		//IL_10de: Expected O, but got I
		//IL_0245: Expected O, but got I
		//IL_020f: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_01cd: Expected O, but got I
		//IL_065c: Expected O, but got I
		//IL_06a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ae: Expected O, but got Unknown
		//IL_03e5: Expected O, but got I
		//IL_0731: Expected O, but got I
		//IL_0d6a: Expected O, but got I
		//IL_03c0: Expected O, but got I
		//IL_03d0: Expected O, but got I
		//IL_0798: Expected I4, but got O
		//IL_0798: Expected O, but got I
		//IL_07a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a6: Expected O, but got Unknown
		//IL_037a: Expected O, but got I
		//IL_05bf: Expected O, but got I
		//IL_03ab: Expected O, but got I
		//IL_0342: Expected O, but got I
		//IL_0859: Expected O, but got I
		//IL_08a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ab: Expected O, but got Unknown
		//IL_0989: Expected O, but got I
		//IL_092a: Expected I4, but got O
		//IL_0938: Unknown result type (might be due to invalid IL or missing references)
		//IL_093d: Expected O, but got Unknown
		//IL_0567: Expected O, but got I4
		//IL_09e4: Expected O, but got I
		//IL_0b70: Expected I4, but got O
		//IL_0b79: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7e: Expected O, but got Unknown
		//IL_0a68: Expected I4, but got O
		//IL_0bf4: Expected O, but got I
		//IL_0c0d: Expected F4, but got I4
		//IL_0c1d: Expected I4, but got O
		//IL_004d->IL0cba: Incompatible stack heights: 2 vs 1
		//IL_0235->IL0d2d: Incompatible stack heights: 6 vs 5
		//IL_0471->IL056c: Incompatible stack heights: 8 vs 7
		//IL_0d6f->IL0d6f: Incompatible stack heights: 7 vs 6
		//IL_03d5->IL0d6f: Incompatible stack heights: 7 vs 6
		//IL_07ab->IL0edc: Incompatible stack heights: 14 vs 6
		//IL_03b0->IL0d6f: Incompatible stack heights: 8 vs 6
		//IL_0e17->IL0dd3: Incompatible stack heights: 10 vs 7
		//IL_0942->IL0f13: Incompatible stack heights: 16 vs 11
		//IL_056c->IL0df8: Incompatible stack heights: 13 vs 10
		//IL_09ed->IL0f4a: Incompatible stack heights: 17 vs 15
		//IL_0a75->IL0f4a: Incompatible stack heights: 20 vs 15
		//IL_0c48->IL0c48: Incompatible stack heights: 20 vs 0
		//IL_0c26->IL0eae: Incompatible stack heights: 22 vs 11
		//IL_0c3d->IL0c3d: Incompatible stack heights: 23 vs 20
		List<LevelUpItemUI>.Enumerator enumerator = default(List<LevelUpItemUI>.Enumerator);
		object obj3 = default(object);
		object obj4 = default(object);
		object obj6 = default(object);
		object obj11 = default(object);
		object obj12 = default(object);
		object obj14 = default(object);
		List<VampireSurvivors.Objects.Characters.CharacterController> affectedCharacters = default(List<VampireSurvivors.Objects.Characters.CharacterController>);
		List<WeightedLimitBreak>.Enumerator enumerator2 = default(List<WeightedLimitBreak>.Enumerator);
		object obj22 = default(object);
		while (true)
		{
			List<LevelUpItemUI> list = _spawnedItems;
			bool flag = _spawnedItems == null;
			float num = 0f;
			while (enumerator.MoveNext())
			{
				float num2 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v847 @ rbx_v58 (System.Single)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v847 @ rbx_v58 (System.Single)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject obj = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				UnityEngine.Object.Destroy(obj, 0f);
				num = 0f;
			}
			List<LevelUpItemUI> spawnedItems = _spawnedItems;
			bool flag3 = _spawnedItems == null;
			int version = spawnedItems._version + 1;
			spawnedItems._version = version;
			spawnedItems._size = 0;
			if (spawnedItems._size > 0)
			{
				Array.Clear(spawnedItems._items, 0, spawnedItems._size);
				list = null;
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(Container);
			Canvas.ForceUpdateCanvases();
			GameManager core = GM.Core;
			bool flag4 = (object)GM.Core == null;
			bool flag5 = core._multiplayer == null;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				RectTransform playerOptions = (RectTransform)(object)_playerOptions;
				bool flag6 = _playerOptions == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rbx_v45 (UnityEngine.RectTransform)+68]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rbx_v45 (UnityEngine.RectTransform)+58]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rbx_v45 (UnityEngine.RectTransform)+78]");
						RectTransform rectTransform2;
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rbx_v45 (UnityEngine.RectTransform)+78]");
							RectTransform rectTransform = (RectTransform)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1686 @ rax_v230 (UnityEngine.RectTransform)+2CC]");
							if ((nint)0 != 0)
							{
								rectTransform2 = rectTransform;
								goto IL_10ce;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rbx_v45 (UnityEngine.RectTransform)+50]");
						rectTransform2 = (RectTransform)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rbx_v45 (UnityEngine.RectTransform)+50]");
						bool flag7 = (nint)0 == 0;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rbx_v45 (UnityEngine.RectTransform)+58]");
						RectTransform rectTransform2 = (RectTransform)0;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rbx_v45 (UnityEngine.RectTransform)+68]");
					RectTransform rectTransform2 = (RectTransform)0;
				}
				goto IL_10ce;
			}
			OnlineStageManager instance = OnlineStageManager._instance;
			bool flag8 = (object)OnlineStageManager._instance == null;
			bool flag9 = instance._003CChosenLevelUpWeapons_003Ek__BackingField == null;
			object obj2 = null;
			while (true)
			{
				bool flag10 = obj3 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ stack_-B0_v35+1C]");
				if (obj4 == null)
				{
					object obj5 = obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ stack_-B0_v35+18]");
					if ((nint)obj5 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ stack_-B0_v35+10]");
						object obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ stack_-B0_v35+10]");
						bool flag11 = (nint)0 == 0;
						object obj8 = obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1477 @ rdx_v87+18]");
						bool flag12 = (nint)obj8 >= 0;
						obj6++;
						bool flag13 = _weaponData == null;
						Dictionary<WeaponType, List<WeaponData>> weaponData = _weaponData;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1477 @ rdx_v87+20+v2483 @ rcx_v124*4]");
						object obj9 = ((Dictionary<System.Int32Enum, object>)(object)weaponData).get_Item((System.Int32Enum)0);
						bool flag14 = obj9 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1563 @ rax_v175 (System.Object)+18]");
						bool flag15 = (nint)0 <= (nint)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1563 @ rax_v175 (System.Object)+10]");
						object obj10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1563 @ rax_v175 (System.Object)+10]");
						bool flag16 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1555 @ rdx_v89+18]");
						bool flag17 = (nint)0 <= (nint)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1555 @ rdx_v89+20]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1477 @ rdx_v87+20+v2483 @ rcx_v124*4]");
						SpawnWeapon((WeaponData)num3, WeaponType.VOID, (int)obj2);
						obj2++;
						continue;
					}
					break;
				}
				break;
			}
			bool flag18 = obj3 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ stack_-B0_v35+1C]");
			bool flag19 = obj4 != null;
			OnlineStageManager instance2 = OnlineStageManager._instance;
			bool flag20 = (object)OnlineStageManager._instance == null;
			bool flag21 = instance2._003CChosenLevelUpItems_003Ek__BackingField == null;
			while (true)
			{
				bool flag22 = obj11 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ stack_-98_v35+1C]");
				if (obj12 == null)
				{
					object obj13 = obj14;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ stack_-98_v35+18]");
					if ((nint)obj13 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ stack_-98_v35+10]");
						object obj15 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ stack_-98_v35+10]");
						bool flag23 = (nint)0 == 0;
						object obj16 = obj14;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2315 @ rdx_v81+18]");
						bool flag24 = (nint)obj16 >= 0;
						obj14++;
						DataManager data = _data;
						bool flag25 = _data == null;
						bool flag26 = data._003CAllItems_003Ek__BackingField == null;
						Dictionary<ItemType, ItemData> dictionary = data._003CAllItems_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2315 @ rdx_v81+20+v3287 @ rcx_v115*4]");
						object data2 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2315 @ rdx_v81+20+v3287 @ rcx_v115*4]");
						SpawnItem(ItemType.VOID, (ItemData)data2, (int)obj2, affectedCharacters);
						obj2++;
						continue;
					}
					break;
				}
				break;
			}
			bool flag27 = obj11 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ stack_-98_v35+1C]");
			bool flag28 = obj12 != null;
			OnlineStageManager instance3 = OnlineStageManager._instance;
			bool flag29 = (object)OnlineStageManager._instance == null;
			bool flag30 = instance3._003CChosenAmuletTargets_003Ek__BackingField == null;
			ItemData itemData = (ItemData)0;
			if (!flag30)
			{
				OnlineStageManager instance4 = OnlineStageManager._instance;
				bool flag31 = (object)OnlineStageManager._instance == null;
				List<VampireSurvivors.Objects.Characters.CharacterController> list2 = instance4._003CChosenAmuletTargets_003Ek__BackingField;
				bool flag32 = instance4._003CChosenAmuletTargets_003Ek__BackingField == null;
				bool flag33 = list2._size <= 0;
				itemData = (ItemData)0;
				if (!flag33)
				{
					DataManager data3 = _data;
					bool flag34 = _data == null;
					bool flag35 = data3._003CAllItems_003Ek__BackingField == null;
					object obj17 = ((Dictionary<System.Int32Enum, object>)(object)data3._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)65);
					bool flag36 = (object)OnlineStageManager._instance == null;
					SpawnItem(ItemType.FRIENDSHIP, (ItemData)obj17, (int)obj2, affectedCharacters);
					itemData = (ItemData)obj17;
				}
			}
			OnlineStageManager instance5 = OnlineStageManager._instance;
			bool flag37 = (object)OnlineStageManager._instance == null;
			List<WeightedLimitBreak> list3 = instance5._003CChosenLimitBreaks_003Ek__BackingField;
			bool flag38 = instance5._003CChosenLimitBreaks_003Ek__BackingField == null;
			int num4 = list3._size ^ list3._size;
			int num5 = list3._size & num4;
			bool flag39 = num5 < 0;
			bool flag40 = list3._size < 0;
			bool flag41 = list3._size == 0;
			bool flag42 = flag40 == flag39;
			bool flag43 = !flag41;
			bool isDoingALimitBreak = flag43 & flag42;
			_isDoingALimitBreak = isDoingALimitBreak;
			OnlineStageManager instance6 = OnlineStageManager._instance;
			bool flag44 = (object)OnlineStageManager._instance == null;
			list = (List<LevelUpItemUI>)(object)instance6._003CChosenLimitBreaks_003Ek__BackingField;
			bool flag45 = instance6._003CChosenLimitBreaks_003Ek__BackingField == null;
			while (enumerator2.MoveNext())
			{
				SpawnLimitBreak(null, (int)obj2);
				obj2++;
				list = null;
				itemData = (ItemData)obj2;
			}
			object limitBreakRandomAlways = _LimitBreakRandomAlways;
			bool value;
			if (!_isDoingALimitBreak)
			{
				value = false;
			}
			else
			{
				bool flag46 = IsLocalPlayerControllingUi();
				value = flag46;
			}
			bool flag47 = (object)_LimitBreakRandomAlways == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rbx_v40 (System.Object)+10]");
			bool flag48;
			nint num6;
			object obj18;
			List<LevelUpItemUI>.Enumerator enumerator3;
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rbx_v40 (System.Object)+10]");
				GameObject.SetActive_Injected((IntPtr)0, value);
				object limitBreakRandomOnce = _LimitBreakRandomOnce;
				if (!_isDoingALimitBreak)
				{
					flag48 = false;
				}
				else
				{
					bool flag49 = IsLocalPlayerControllingUi();
					flag48 = flag49;
				}
				bool flag50 = (object)_LimitBreakRandomOnce == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rbx_v41 (System.Object)+10]");
				num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rbx_v41 (System.Object)+10]");
				bool flag51 = (nint)0 == 0;
				obj18 = 0;
				bool flag52 = (nint)0 != 0;
				num = 0f;
				enumerator3 = (List<LevelUpItemUI>.Enumerator)list;
				int num7 = (int)itemData;
				if (flag52)
				{
					break;
				}
				bool flag53 = (nint)0 == 0;
			}
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_LimitBreakRandomAlways);
			continue;
			IL_0d6f:
			object obj19;
			bool flag54 = obj19 == null;
			bool canLimitBreak = !flag54;
			_canLimitBreak = canLimitBreak;
			VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
			bool flag55 = _levelUpFactory == null;
			bool flag56 = _levelUpFactory.HasPowerupsInStore(characterControllingUi);
			if (!flag56)
			{
				int num7;
				if (_canLimitBreak != flag56)
				{
					bool flag57 = _limitBreakManager == null;
					if (_limitBreakManager.HasLimitBreaks())
					{
						_isDoingALimitBreak = true;
						bool flag58 = _limitBreakManager == null;
						List<WeightedLimitBreak> limitBreakBonuses = _limitBreakManager.GetLimitBreakBonuses();
						bool flag59 = limitBreakBonuses == null;
						int num8 = 0;
						num7 = 0;
						object obj20 = null;
						while ((nint)obj20 < limitBreakBonuses._size)
						{
							bool flag60 = num8 >= limitBreakBonuses._size;
							WeightedLimitBreak[] items = limitBreakBonuses._items;
							bool flag61 = limitBreakBonuses._items == null;
							bool flag62 = num8 >= items.Length;
							SpawnLimitBreak(items[num8], num8);
							num8++;
							list = null;
							num7 = num8;
							obj20 = num8;
						}
						goto IL_0dd3;
					}
				}
				_isDoingALimitBreak = false;
				PickItemLevelUps();
				num7 = 0;
			}
			else
			{
				PickRandomLevelUps();
				_isDoingALimitBreak = false;
				int num7 = 0;
			}
			goto IL_0dd3;
			IL_0dd3:
			object limitBreakRandomAlways2 = _LimitBreakRandomAlways;
			bool flag63 = (object)_LimitBreakRandomAlways == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rbx_v50 (System.Object)+10]");
			bool flag64 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rbx_v50 (System.Object)+10]");
			GameObject.SetActive_Injected((IntPtr)0, _isDoingALimitBreak);
			RectTransform limitBreakRandomOnce2 = (RectTransform)(object)_LimitBreakRandomOnce;
			flag48 = _isDoingALimitBreak;
			bool flag65 = (object)_LimitBreakRandomOnce == null;
			num6 = ((UnityEngine.Object)limitBreakRandomOnce2).m_CachedPtr;
			bool flag66 = ((UnityEngine.Object)limitBreakRandomOnce2).m_CachedPtr == (IntPtr)0;
			obj18 = 0;
			enumerator3 = (List<LevelUpItemUI>.Enumerator)list;
			break;
			IL_0d5a:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2227 @ rax_v221+50]");
			obj19 = 0;
			goto IL_0d6f;
			IL_10ce:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v46 (UnityEngine.RectTransform)+188]");
			object obj21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v46 (UnityEngine.RectTransform)+188]");
			bool flag67 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rcx_v133+18]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rcx_v133+18]");
				list = (List<LevelUpItemUI>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				if ((nint)obj22 != -1)
				{
					RectTransform playerOptions2 = (RectTransform)(object)_playerOptions;
					bool flag68 = _playerOptions == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v53 (UnityEngine.RectTransform)+68]");
					object obj23;
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v53 (UnityEngine.RectTransform)+58]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v53 (UnityEngine.RectTransform)+78]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v53 (UnityEngine.RectTransform)+78]");
								obj23 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2227 @ rax_v221+2CC]");
								if ((nint)0 != 0)
								{
									goto IL_0d5a;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v53 (UnityEngine.RectTransform)+50]");
							object obj24 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v53 (UnityEngine.RectTransform)+50]");
							bool flag69 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ rax_v225+50]");
							obj19 = 0;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v53 (UnityEngine.RectTransform)+58]");
							object obj25 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2226 @ rax_v223+50]");
							obj19 = 0;
						}
						goto IL_0d6f;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v53 (UnityEngine.RectTransform)+68]");
					obj23 = 0;
					goto IL_0d5a;
				}
			}
			obj19 = null;
			goto IL_0d6f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3237 @ rax_v84 (should have been resolved before IL gen)");
	}

	private void PickRandomLimitBreaks()
	{
		List<WeightedLimitBreak> limitBreakBonuses = _limitBreakManager.GetLimitBreakBonuses();
		int num = 0;
		int num2 = 0;
		while (true)
		{
			if (num2 < limitBreakBonuses._size)
			{
				if (num >= limitBreakBonuses._size)
				{
					break;
				}
				WeightedLimitBreak[] items = limitBreakBonuses._items;
				SpawnLimitBreak(items[num], num);
				num++;
				num2 = num;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	private void PickRandomLevelUps()
	{
		//IL_00b8: Invalid comparison between F4 and I4
		//IL_071f: Expected O, but got I
		//IL_0160: Expected O, but got I
		//IL_0742: Expected O, but got I
		//IL_03a8: Invalid comparison between F4 and I4
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
		//IL_03db: Expected I4, but got F4
		//IL_0385: Expected I4, but got O
		//IL_038d: Expected I4, but got O
		//IL_0249: Expected O, but got I
		//IL_054d: Invalid comparison between F4 and I4
		//IL_0436: Invalid comparison between F4 and I4
		//IL_02b8: Expected I4, but got O
		//IL_02b8: Expected O, but got I
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_02ce: Expected I4, but got O
		//IL_05d3: Invalid comparison between F4 and I4
		//IL_04bc: Invalid comparison between F4 and I4
		//IL_0856: Invalid comparison between F4 and I4
		//IL_078f: Invalid comparison between F4 and I4
		//IL_0879: Expected I, but got F4
		//IL_07b2: Expected I, but got F4
		//IL_08af: Expected O, but got I
		//IL_063d: Expected O, but got I
		//IL_07e9: Expected O, but got I
		//IL_08d6: Expected O, but got I4
		//IL_0526: Expected O, but got I
		//IL_0810: Expected O, but got I4
		//IL_087e->IL0839: Incompatible stack heights: 1 vs 0
		//IL_07b7->IL0772: Incompatible stack heights: 1 vs 0
		//IL_08ef->IL07db: Incompatible stack heights: 1 vs 0
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
		if (_levelUpFactory != null)
		{
			List<WeaponType> levelUpPowerups = _levelUpFactory.GetLevelUpPowerups(characterControllingUi);
			_currentWeapons = levelUpPowerups;
			LevelUpFactory currentWeapons = (LevelUpFactory)(object)_currentWeapons;
			if (_currentWeapons != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F650");
				if (_levelUpFactory != null)
				{
					List<VampireSurvivors.Objects.Characters.CharacterController> list = _levelUpFactory.FindFriendshipAmuletTargets(checkAmuletBag: true);
					if (list != null && currentWeapons._previousXpFactor == 4f)
					{
						float num = currentWeapons._previousXpFactor - 1f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047F780");
					}
					LevelUpFactory levelUpFactory = null;
					object obj = default(object);
					object obj2 = default(object);
					object obj4 = default(object);
					while (true)
					{
						if (obj != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ stack_-98_v21+1C]");
							if (obj2 != null)
							{
								break;
							}
							object obj3 = obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ stack_-98_v21+18]");
							if ((nint)obj3 >= 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ stack_-98_v21+10]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ stack_-98_v21+10]");
							if ((nint)0 != 0)
							{
								object obj6 = obj4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rdx_v59+18]");
								if ((nint)obj6 < 0)
								{
									obj4++;
									if (_weaponData != null)
									{
										Dictionary<WeaponType, List<WeaponData>> weaponData = _weaponData;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rdx_v59+20+v1181 @ rcx_v106*4]");
										object obj7 = ((Dictionary<System.Int32Enum, object>)(object)weaponData).get_Item((System.Int32Enum)0);
										if (obj7 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ rax_v145 (System.Object)+18]");
											if ((nint)0 > (nint)0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ rax_v145 (System.Object)+10]");
												object obj8 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ rax_v145 (System.Object)+10]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rdx_v61+18]");
													if ((nint)0 > (nint)0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rdx_v61+20]");
														nint num2 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rdx_v59+20+v1181 @ rcx_v106*4]");
														SpawnWeapon((WeaponData)num2, WeaponType.VOID, (int)levelUpFactory);
														LevelUpFactory levelUpFactory2 = (LevelUpFactory)(levelUpFactory + 1);
														int num3 = (int)levelUpFactory;
														levelUpFactory = levelUpFactory2;
														continue;
													}
													throw new IndexOutOfRangeException();
												}
												throw new NullReferenceException();
											}
											System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								throw new IndexOutOfRangeException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					bool flag = obj == null;
					LevelUpFactory levelUpFactory3 = (LevelUpFactory)0;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ stack_-98_v21+1C]");
						if (obj2 == null)
						{
							bool flag2 = list == null;
							ItemData itemData = (ItemData)0;
							if (!flag2)
							{
								DataManager data = _data;
								if (_data == null || data._003CAllItems_003Ek__BackingField == null)
								{
									goto IL_0642;
								}
								object obj9 = ((Dictionary<System.Int32Enum, object>)(object)data._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)65);
								List<VampireSurvivors.Objects.Characters.CharacterController> affectedCharacters = default(List<VampireSurvivors.Objects.Characters.CharacterController>);
								SpawnItem(ItemType.FRIENDSHIP, (ItemData)obj9, (int)levelUpFactory, affectedCharacters);
								int num3 = (int)levelUpFactory;
								itemData = (ItemData)obj9;
							}
							LevelUpFactory cats;
							if (currentWeapons._previousXpFactor == 0f)
							{
								cats = (LevelUpFactory)(object)_Cats;
							}
							else
							{
								int num3 = (int)currentWeapons._previousXpFactor;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
								cats = (LevelUpFactory)(object)_Cats;
								object obj10 = default(object);
								bool flag3 = (nint)obj10 != -1;
								itemData = null;
								if (flag3)
								{
									if ((object)_Cats != null && cats._defaultXPFactor != 0f)
									{
										if ((object)_Cats != null)
										{
											GameObject gameObject = _Cats.gameObject;
											if ((object)gameObject != null)
											{
												bool flag4 = ((LevelUpFactory)(object)gameObject)._defaultXPFactor == 0f;
												GameObject.SetActive_Injected((IntPtr)((LevelUpFactory)(object)gameObject)._defaultXPFactor, true);
												goto IL_0839;
											}
										}
										goto IL_0642;
									}
									goto IL_0839;
								}
							}
							if (cats != null && cats._defaultXPFactor != 0f)
							{
								if ((object)_Cats != null)
								{
									GameObject gameObject2 = _Cats.gameObject;
									if ((object)gameObject2 != null)
									{
										bool flag5 = ((LevelUpFactory)(object)gameObject2)._defaultXPFactor == 0f;
										GameObject.SetActive_Injected((IntPtr)((LevelUpFactory)(object)gameObject2)._defaultXPFactor, false);
										goto IL_0772;
									}
								}
								goto IL_0642;
							}
							goto IL_0772;
						}
						System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
						levelUpFactory3 = null;
					}
					throw new NullReferenceException();
				}
			}
		}
		goto IL_0642;
		IL_08e0:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2303 @ rax_v63 (should have been resolved before IL gen)");
		return;
		IL_0642:
		throw new NullReferenceException();
		IL_0839:
		LevelUpFactory gems = (LevelUpFactory)(object)_Gems;
		if ((object)_Gems == null || gems._defaultXPFactor == 0f)
		{
			return;
		}
		bool num4;
		if ((object)_Gems != null)
		{
			GameObject gameObject3 = _Gems.gameObject;
			if ((object)gameObject3 != null)
			{
				LevelUpFactory levelUpFactory4 = (LevelUpFactory)(nint)((UnityEngine.Object)gameObject3).m_CachedPtr;
				bool flag6 = ((UnityEngine.Object)gameObject3).m_CachedPtr == (IntPtr)0;
				num4 = flag6;
				object obj11 = 0;
				object obj12 = 0;
				ItemData itemData = null;
				goto IL_08e0;
			}
		}
		goto IL_0642;
		IL_0772:
		LevelUpFactory gems2 = (LevelUpFactory)(object)_Gems;
		if ((object)_Gems == null || gems2._defaultXPFactor == 0f)
		{
			return;
		}
		if ((object)_Gems != null)
		{
			GameObject gameObject4 = _Gems.gameObject;
			if ((object)gameObject4 != null)
			{
				LevelUpFactory levelUpFactory4 = (LevelUpFactory)(nint)((UnityEngine.Object)gameObject4).m_CachedPtr;
				bool flag7 = ((UnityEngine.Object)gameObject4).m_CachedPtr == (IntPtr)0;
				num4 = flag7;
				object obj11 = 0;
				object obj12 = 1;
				goto IL_08e0;
			}
		}
		goto IL_0642;
	}

	private unsafe void ResetLevelUpViewsAfterReRoll()
	{
		//IL_008a: Expected F4, but got I4
		//IL_0097: Expected O, but got Ref
		//IL_0168: Expected O, but got I
		//IL_01cc: Expected I4, but got O
		//IL_023e: Expected O, but got I
		//IL_07f4: Expected I, but got O
		//IL_0433: Expected I, but got O
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Expected O, but got Unknown
		//IL_0327: Expected O, but got I
		//IL_0bfd: Expected I, but got O
		//IL_0396: Expected O, but got I
		//IL_066d: Expected I, but got O
		//IL_0b9d: Expected O, but got I
		//IL_09a5: Expected O, but got I
		//IL_0b07: Expected O, but got I
		//IL_0c5f: Expected O, but got I
		//IL_0a67: Expected O, but got I
		//IL_06c7: Expected O, but got I
		//IL_06ec: Expected O, but got Ref
		//IL_0c9d: Expected I, but got O
		//IL_0ca6: Expected O, but got I4
		//IL_0540: Expected O, but got I
		//IL_0aa9: Expected O, but got I4
		//IL_076c: Expected O, but got I4
		//IL_0ba6->IL079e: Incompatible stack heights: 1 vs 0
		//IL_09ae->IL079e: Incompatible stack heights: 1 vs 0
		//IL_0b10->IL079e: Incompatible stack heights: 1 vs 0
		//IL_0c68->IL079e: Incompatible stack heights: 1 vs 0
		//IL_0be2->IL0b3a: Incompatible stack heights: 2 vs 0
		//IL_0a70->IL079e: Incompatible stack heights: 1 vs 0
		//IL_09ea->IL0942: Incompatible stack heights: 2 vs 0
		//IL_0cbf->IL0a0e: Incompatible stack heights: 2 vs 0
		GameObject rerollButton = _RerollButton;
		nint num6;
		if ((object)_RerollButton != null)
		{
			Button component = _RerollButton.GetComponent<Button>();
			if ((object)component != null)
			{
				component.enabled = true;
				List<LevelUpItemUI> list = _spawnedItems;
				bool flag = _spawnedItems == null;
				rerollButton = (GameObject)(object)component;
				if (!flag)
				{
					float num = 0f;
					List<LevelUpItemUI>.Enumerator enumerator = default(List<LevelUpItemUI>.Enumerator);
					if (enumerator.MoveNext())
					{
						List<LevelUpItemUI>.Enumerator enumerator2 = (List<LevelUpItemUI>.Enumerator)(&enumerator);
						throw new NullReferenceException();
					}
					rerollButton = (GameObject)(object)_spawnedItems;
					if (_spawnedItems != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rcx_v62 (UnityEngine.GameObject)+1C]");
						_ = (nint)0 + (nint)1;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rcx_v62 (UnityEngine.GameObject)+18]");
						if ((nint)0 > (nint)0)
						{
							IntPtr cachedPtr = ((UnityEngine.Object)rerollButton).m_CachedPtr;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rcx_v62 (UnityEngine.GameObject)+18]");
							Array.Clear((Array)(nint)cachedPtr, 0, 0);
							list = null;
						}
						LayoutRebuilder.ForceRebuildLayoutImmediate(Container);
						Canvas.ForceUpdateCanvases();
						List<WeaponType> currentWeapons = _currentWeapons;
						bool flag2 = _currentWeapons == null;
						rerollButton = null;
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F650");
							int num2 = (int)list;
							int num3 = 0;
							object obj = default(object);
							object obj2 = default(object);
							object obj4 = default(object);
							while (true)
							{
								if (obj != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ stack_-A8_v34+1C]");
									if (obj2 != null)
									{
										break;
									}
									object obj3 = obj4;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ stack_-A8_v34+18]");
									if ((nint)obj3 >= 0)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ stack_-A8_v34+10]");
									object obj5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ stack_-A8_v34+10]");
									if ((nint)0 != 0)
									{
										object obj6 = obj4;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ rdx_v89+18]");
										if ((nint)obj6 < 0)
										{
											obj4++;
											if (_weaponData != null)
											{
												Dictionary<WeaponType, List<WeaponData>> weaponData = _weaponData;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ rdx_v89+20+v1526 @ rcx_v185*4]");
												object obj7 = ((Dictionary<System.Int32Enum, object>)(object)weaponData).get_Item((System.Int32Enum)0);
												if (obj7 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rax_v241 (System.Object)+18]");
													if ((nint)0 > (nint)0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rax_v241 (System.Object)+10]");
														object obj8 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rax_v241 (System.Object)+10]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ rdx_v91+18]");
															if ((nint)0 > (nint)0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ rdx_v91+20]");
																nint num4 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ rdx_v89+20+v1526 @ rcx_v185*4]");
																SpawnWeapon((WeaponData)num4, WeaponType.VOID, num3);
																num3++;
																num2 = num3;
																continue;
															}
															throw new IndexOutOfRangeException();
														}
														throw new NullReferenceException();
													}
													System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
												}
												throw new NullReferenceException();
											}
											throw new NullReferenceException();
										}
										throw new IndexOutOfRangeException();
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							bool flag3 = obj == null;
							nint num5 = 0;
							if (!flag3)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ stack_-A8_v34+1C]");
								if (obj2 == null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r14_v32 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
									ParticleSystem cats;
									if ((nint)0 == 0)
									{
										cats = _Cats;
										num6 = 0;
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r14_v32 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
										num2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
										cats = _Cats;
										object obj9 = default(object);
										bool flag4 = (nint)obj9 != -1;
										num6 = unchecked((nint)null);
										if (flag4)
										{
											if ((object)_Cats != null && ((UnityEngine.Object)cats).m_CachedPtr != (IntPtr)0)
											{
												RectTransform cats2 = (RectTransform)(object)_Cats;
												bool flag5 = (object)_Cats == null;
												rerollButton = (GameObject)(object)typeof(UnityEngine.Object);
												if (!flag5)
												{
													bool flag6 = ((UnityEngine.Object)cats2).m_CachedPtr == (IntPtr)0;
													IntPtr intPtr = Component.get_gameObject_Injected(((UnityEngine.Object)cats2).m_CachedPtr);
													GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(intPtr);
													bool flag7 = (object)gameObject == null;
													rerollButton = (GameObject)(nint)intPtr;
													if (!flag7)
													{
														bool flag8 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
														GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, true);
														goto IL_0b3a;
													}
												}
												goto IL_079e;
											}
											goto IL_0b3a;
										}
									}
									if ((object)cats != null && ((UnityEngine.Object)cats).m_CachedPtr != (IntPtr)0)
									{
										RectTransform cats3 = (RectTransform)(object)_Cats;
										bool flag9 = (object)_Cats == null;
										rerollButton = (GameObject)(object)typeof(UnityEngine.Object);
										if (!flag9)
										{
											bool flag10 = ((UnityEngine.Object)cats3).m_CachedPtr == (IntPtr)0;
											IntPtr intPtr2 = Component.get_gameObject_Injected(((UnityEngine.Object)cats3).m_CachedPtr);
											GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(intPtr2);
											bool flag11 = (object)gameObject2 == null;
											rerollButton = (GameObject)(nint)intPtr2;
											if (!flag11)
											{
												bool flag12 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
												GameObject.SetActive_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr, false);
												goto IL_0942;
											}
										}
										goto IL_079e;
									}
									goto IL_0942;
								}
								System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
								num5 = unchecked((nint)null);
							}
							throw new NullReferenceException();
						}
					}
				}
			}
		}
		goto IL_079e;
		IL_0b3a:
		ParticleSystem gems = _Gems;
		bool flag13 = (object)_Gems == null;
		num6 = unchecked((nint)null);
		bool num7;
		bool num8;
		if (!flag13)
		{
			bool flag14 = ((UnityEngine.Object)gems).m_CachedPtr == (IntPtr)0;
			num6 = unchecked((nint)null);
			if (!flag14)
			{
				RectTransform gems2 = (RectTransform)(object)_Gems;
				bool flag15 = (object)_Gems == null;
				rerollButton = (GameObject)(object)typeof(UnityEngine.Object);
				if (!flag15)
				{
					bool flag16 = ((UnityEngine.Object)gems2).m_CachedPtr == (IntPtr)0;
					num7 = flag16;
					IntPtr intPtr3 = Component.get_gameObject_Injected(((UnityEngine.Object)gems2).m_CachedPtr);
					GameObject gameObject3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(intPtr3);
					bool flag17 = (object)gameObject3 == null;
					rerollButton = (GameObject)(nint)intPtr3;
					if (!flag17)
					{
						IntPtr cachedPtr2 = ((UnityEngine.Object)gameObject3).m_CachedPtr;
						bool flag18 = ((UnityEngine.Object)gameObject3).m_CachedPtr == (IntPtr)0;
						num8 = flag18;
						object obj10 = 0;
						num6 = unchecked((nint)null);
						object obj11 = 0;
						goto IL_0cb0;
					}
				}
				goto IL_079e;
			}
		}
		goto IL_0545;
		IL_0545:
		LayoutRebuilder.ForceRebuildLayoutImmediate(Container);
		Canvas.ForceUpdateCanvases();
		bool flag19 = (object)Container == null;
		rerollButton = (GameObject)(object)Container;
		if (!flag19)
		{
			VerticalLayoutGroup component2 = Container.GetComponent<VerticalLayoutGroup>();
			bool flag20 = (object)component2 == null;
			rerollButton = (GameObject)(object)Container;
			if (!flag20)
			{
				bool flag21 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
				Behaviour.set_enabled_Injected(((UnityEngine.Object)component2).m_CachedPtr, true);
				List<WeaponType> currentWeapons2 = _currentWeapons;
				bool flag22 = _currentWeapons == null;
				rerollButton = (GameObject)(nint)((UnityEngine.Object)component2).m_CachedPtr;
				if (!flag22)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rax_v111 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					List<LevelUpItemUI>.Enumerator enumerator3 = default(List<LevelUpItemUI>.Enumerator);
					string text = System.Number.FormatInt32(0, (ReadOnlySpan<char>)(&enumerator3), null);
					string message = "Rewards : " + text;
					Debug.Log(message);
					DoIntroEffects();
					float time = default(float);
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
					PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.LevelUp, new SoundManager.SoundConfig
					{
						Rate = 1f,
						Volume = (float?)(object)1
					}, 0f, 10, time);
					ValidateButtonStates();
					UpdateButtonsUI();
					return;
				}
			}
		}
		goto IL_079e;
		IL_0cb0:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3343 @ rax_v100 (should have been resolved before IL gen)");
		goto IL_0545;
		IL_079e:
		throw new NullReferenceException();
		IL_0942:
		ParticleSystem gems3 = _Gems;
		if ((object)_Gems != null && ((UnityEngine.Object)gems3).m_CachedPtr != (IntPtr)0)
		{
			RectTransform gems4 = (RectTransform)(object)_Gems;
			bool flag23 = (object)_Gems == null;
			rerollButton = (GameObject)(object)typeof(UnityEngine.Object);
			if (!flag23)
			{
				bool flag24 = ((UnityEngine.Object)gems4).m_CachedPtr == (IntPtr)0;
				num7 = flag24;
				IntPtr intPtr4 = Component.get_gameObject_Injected(((UnityEngine.Object)gems4).m_CachedPtr);
				GameObject gameObject4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(intPtr4);
				bool flag25 = (object)gameObject4 == null;
				rerollButton = (GameObject)(nint)intPtr4;
				if (!flag25)
				{
					IntPtr cachedPtr2 = ((UnityEngine.Object)gameObject4).m_CachedPtr;
					bool flag26 = ((UnityEngine.Object)gameObject4).m_CachedPtr == (IntPtr)0;
					num8 = flag26;
					object obj10 = 0;
					object obj11 = 1;
					goto IL_0cb0;
				}
			}
			goto IL_079e;
		}
		goto IL_0545;
	}

	private void PickItemLevelUps()
	{
		//IL_019b: Expected O, but got I
		//IL_008a: Expected O, but got I
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		List<ItemType> levelUpItems = _levelUpFactory.GetLevelUpItems();
		int num = 0;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		List<VampireSurvivors.Objects.Characters.CharacterController> affectedCharacters = default(List<VampireSurvivors.Objects.Characters.CharacterController>);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ stack_-28_v3+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ stack_-28_v3+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ stack_-28_v3+10]");
						object obj5 = 0;
						obj4++;
						DataManager data = _data;
						Dictionary<ItemType, ItemData> dictionary = data._003CAllItems_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rdx_v11+20+v479 @ rcx_v16*4]");
						object data2 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rdx_v11+20+v479 @ rcx_v16*4]");
						SpawnItem(ItemType.VOID, (ItemData)data2, num, affectedCharacters);
						num++;
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag = obj == null;
		LevelUpFactory levelUpFactory = (LevelUpFactory)0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ stack_-28_v3+1C]");
			if (obj2 == null)
			{
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			levelUpFactory = null;
		}
		throw new NullReferenceException();
	}

	private void SpawnItem(ItemType type, ItemData data, int index, List<VampireSurvivors.Objects.Characters.CharacterController> affectedCharacters = null)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(LevelUpItemPrefab, Container);
		LevelUpItemUI component = gameObject.GetComponent<LevelUpItemUI>();
		int index2 = default(int);
		List<VampireSurvivors.Objects.Characters.CharacterController> affectedCharacters2 = default(List<VampireSurvivors.Objects.Characters.CharacterController>);
		component.SetItemData(type, data, this, index2, affectedCharacters2);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F780");
	}

	private void SpawnLimitBreak(WeightedLimitBreak d, int index)
	{
		_003C_003Ec__DisplayClass140_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass140_0();
		GameObject gameObject = UnityEngine.Object.Instantiate(LevelUpItemPrefab, Container);
		LevelUpItemUI component = gameObject.GetComponent<LevelUpItemUI>();
		CS_0024_003C_003E8__locals2.weaponType = d.WeaponType;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)_weaponData).get_Item((System.Int32Enum)d.WeaponType);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v12 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
			CharacterWeaponsManager weaponsManager = characterControllingUi._weaponsManager;
			Func<Equipment, bool> predicate = delegate(Equipment x)
			{
				//IL_0053: Expected I4, but got O
				//IL_0031: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj2 = x._equipmentType - CS_0024_003C_003E8__locals2.weaponType;
				return obj2 == null;
			};
			object e = Enumerable.FirstOrDefault(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField, (Func<object, bool>)predicate);
			WeaponData baseWeaponData = default(WeaponData);
			WeaponType weaponType = default(WeaponType);
			int index2 = default(int);
			component.SetLimitBreakData(this, d, (Equipment)e, baseWeaponData, weaponType, index2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F780");
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private unsafe List<Sprite> AddEvoSpritesForPlayer(WeaponData data, WeaponType type, VampireSurvivors.Objects.Characters.CharacterController player, bool checkSlotLimits = false)
	{
		//IL_0240: Expected O, but got I4
		//IL_0251: Expected O, but got I4
		//IL_01d4: Expected O, but got I4
		//IL_014a: Expected O, but got I4
		//IL_10fc: Expected O, but got Ref
		//IL_0790: Expected O, but got I4
		//IL_0b31: Expected O, but got Ref
		//IL_02d1: Expected O, but got I
		//IL_0b5b: Expected O, but got Ref
		//IL_0b77: Expected O, but got I4
		//IL_070f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0714: Expected O, but got Unknown
		//IL_068c: Expected O, but got I
		//IL_068c: Expected O, but got I
		//IL_06af: Expected O, but got I
		List<Sprite> list = new List<Sprite>();
		bool flag = data == null;
		List<Sprite> list2 = list;
		List<Equipment> list3;
		if (!flag)
		{
			bool flag2 = (object)player == null;
			list2 = list;
			if (!flag2)
			{
				bool flag3 = ((!data._003CisPowerUp_003Ek__BackingField) ? ((object)player._weaponsManager == null) : ((object)player._accessoriesManager == null));
				list2 = list;
				if (!flag3)
				{
					object obj = default(object);
					bool flag4 = obj == null;
					list2 = list;
					if (flag4)
					{
						goto IL_01d9;
					}
					if (data._003CisPowerUp_003Ek__BackingField)
					{
						CharacterAccessoriesManager accessoriesManager = player._accessoriesManager;
						bool flag5 = (object)player._accessoriesManager == null;
						list2 = list;
						if (!flag5)
						{
							list3 = ((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField;
							bool flag6 = ((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField == null;
							list2 = list;
							if (!flag6)
							{
								list2 = (List<Sprite>)(player._maxAccessoryCount + player._maxAccessoryBonus);
								goto IL_1057;
							}
						}
					}
					else
					{
						CharacterWeaponsManager weaponsManager = player._weaponsManager;
						bool flag7 = (object)player._weaponsManager == null;
						list2 = list;
						if (!flag7)
						{
							list3 = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
							bool flag8 = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField == null;
							list2 = list;
							if (!flag8)
							{
								list2 = (List<Sprite>)(player._maxWeaponCount + player._maxWeaponBonus);
								goto IL_1057;
							}
						}
					}
				}
			}
		}
		goto IL_0ee4;
		IL_1057:
		if (list3._size < (nint)list2)
		{
			goto IL_01d9;
		}
		goto IL_113b;
		IL_0ee4:
		throw new NullReferenceException();
		IL_113b:
		return list;
		IL_01d9:
		bool flag9 = data._003CevoSynergy_003Ek__BackingField == null;
		VampireSurvivors.Objects.Characters.CharacterController characterController = player;
		if (!flag9)
		{
			WeaponType[] array = data._003CevoSynergy_003Ek__BackingField;
			bool flag10 = array.Length == 0;
			characterController = player;
			if (!flag10)
			{
				object obj2 = 0;
				WeaponType[] array2 = array;
				object obj3 = 0;
				object obj4 = default(object);
				object obj5 = default(object);
				object obj8 = default(object);
				for (characterController = player; (nint)obj3 < array2.Length; obj2++, array2 = array, obj3 = obj2, characterController = player)
				{
					_003C_003Ec__DisplayClass141_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass141_0();
					bool flag11 = (nint)obj2 >= array2.Length;
					list2 = (List<Sprite>)(object)typeof(_003C_003Ec__DisplayClass141_0);
					List<Sprite> list5;
					if (!flag11)
					{
						bool flag12 = CS_0024_003C_003E8__locals7 == null;
						list2 = (List<Sprite>)(object)typeof(_003C_003Ec__DisplayClass141_0);
						if (!flag12)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ r15_v36 (VampireSurvivors.Data.WeaponType[])+20+v138 @ rsi_v41*4]");
							list2 = (List<Sprite>)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ r15_v36 (VampireSurvivors.Data.WeaponType[])+20+v138 @ rsi_v41*4]");
							CS_0024_003C_003E8__locals7.t = WeaponType.VOID;
							CharacterWeaponsManager weaponsManager2 = characterController._weaponsManager;
							if ((object)characterController._weaponsManager != null)
							{
								List<Sprite> list4 = (List<Sprite>)(object)((EquipmentManager)weaponsManager2)._003CActiveEquipment_003Ek__BackingField;
								Predicate<Equipment> predicate = delegate(Equipment x)
								{
									//IL_0053: Expected I4, but got O
									//IL_0031: Expected O, but got I4
									if ((object)x == null)
									{
										NullReferenceException ex = new NullReferenceException();
										return (byte)(int)ex != 0;
									}
									object obj11 = x._equipmentType - CS_0024_003C_003E8__locals7.t;
									return obj11 == null;
								};
								bool flag13 = ((EquipmentManager)weaponsManager2)._003CActiveEquipment_003Ek__BackingField == null;
								list2 = (List<Sprite>)(object)predicate;
								if (!flag13)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805EA0E0");
									bool flag14 = (nint)obj4 != -1;
									list5 = (List<Sprite>)(object)((EquipmentManager)weaponsManager2)._003CActiveEquipment_003Ek__BackingField;
									if (flag14)
									{
										goto IL_0469;
									}
									CharacterAccessoriesManager accessoriesManager2 = player._accessoriesManager;
									bool flag15 = (object)player._accessoriesManager == null;
									list2 = (List<Sprite>)(object)((EquipmentManager)weaponsManager2)._003CActiveEquipment_003Ek__BackingField;
									if (!flag15)
									{
										List<Sprite> list6 = (List<Sprite>)(object)((EquipmentManager)accessoriesManager2)._003CActiveEquipment_003Ek__BackingField;
										Predicate<Equipment> predicate2 = delegate(Equipment x)
										{
											//IL_0053: Expected I4, but got O
											//IL_0031: Expected O, but got I4
											if ((object)x == null)
											{
												NullReferenceException ex = new NullReferenceException();
												return (byte)(int)ex != 0;
											}
											object obj11 = x._equipmentType - CS_0024_003C_003E8__locals7.t;
											return obj11 == null;
										};
										bool flag16 = ((EquipmentManager)accessoriesManager2)._003CActiveEquipment_003Ek__BackingField == null;
										list2 = (List<Sprite>)(object)predicate2;
										if (!flag16)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805EA0E0");
											bool flag17 = (nint)obj5 == -1;
											list5 = (List<Sprite>)(object)((EquipmentManager)accessoriesManager2)._003CActiveEquipment_003Ek__BackingField;
											list2 = (List<Sprite>)(object)((EquipmentManager)accessoriesManager2)._003CActiveEquipment_003Ek__BackingField;
											if (flag17)
											{
												continue;
											}
											goto IL_0469;
										}
									}
								}
							}
						}
						goto IL_0ee4;
					}
					throw new IndexOutOfRangeException();
					IL_0469:
					bool flag18 = data._003CevoInto_003Ek__BackingField == null;
					list2 = list5;
					if (flag18)
					{
						continue;
					}
					bool flag19 = IsEvolutionUnlocked(data);
					bool flag20 = !flag19;
					list2 = (List<Sprite>)(object)this;
					if (flag20)
					{
						continue;
					}
					bool flag21 = _weaponData == null;
					list2 = (List<Sprite>)(object)_weaponData;
					if (!flag21)
					{
						int num = ((Dictionary<System.Int32Enum, object>)(object)_weaponData).FindEntry((System.Int32Enum)CS_0024_003C_003E8__locals7.t);
						bool flag22 = num < 0;
						list2 = (List<Sprite>)(object)_weaponData;
						if (flag22)
						{
							continue;
						}
						bool flag23 = _weaponData == null;
						list2 = (List<Sprite>)(object)_weaponData;
						if (!flag23)
						{
							object obj6 = ((Dictionary<System.Int32Enum, object>)(object)_weaponData).get_Item((System.Int32Enum)CS_0024_003C_003E8__locals7.t);
							bool flag24 = obj6 == null;
							list2 = (List<Sprite>)(object)_weaponData;
							if (!flag24)
							{
								List<WeaponData> list7 = ((Dictionary<WeaponType, List<WeaponData>>)obj6).get_Item(WeaponType.VOID);
								bool flag25 = list7 == null;
								list2 = (List<Sprite>)obj6;
								if (!flag25)
								{
									bool flag26 = _weaponData == null;
									list2 = (List<Sprite>)(object)_weaponData;
									if (!flag26)
									{
										object obj7 = ((Dictionary<System.Int32Enum, object>)(object)_weaponData).get_Item((System.Int32Enum)CS_0024_003C_003E8__locals7.t);
										bool flag27 = obj7 == null;
										list2 = (List<Sprite>)(object)_weaponData;
										if (!flag27)
										{
											List<WeaponData> list8 = ((Dictionary<WeaponType, List<WeaponData>>)obj7).get_Item(WeaponType.VOID);
											bool flag28 = list8 == null;
											list2 = (List<Sprite>)obj7;
											if (!flag28)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v155 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+40]");
												nint num2 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v157 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+38]");
												Sprite sprite = SpriteManager.GetSprite((string)num2, (string)0);
												bool flag29 = list == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v155 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+40]");
												list2 = (List<Sprite>)0;
												if (!flag29)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F7E0");
													bool flag30 = obj8 != null;
													list2 = list;
													if (!flag30)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
														list2 = list;
													}
													continue;
												}
											}
										}
									}
								}
							}
						}
					}
					goto IL_0ee4;
				}
			}
		}
		CharacterWeaponsManager weaponsManager3 = characterController._weaponsManager;
		if ((object)characterController._weaponsManager != null && ((EquipmentManager)weaponsManager3)._003CActiveEquipment_003Ek__BackingField != null)
		{
			List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj9 = 0;
				Dictionary<System.Int32Enum, object> weaponData = (Dictionary<System.Int32Enum, object>)(object)_weaponData;
				throw new NullReferenceException();
			}
			bool flag31 = (object)characterController == null;
			list2 = (List<Sprite>)(&enumerator);
			if (!flag31)
			{
				CharacterAccessoriesManager accessoriesManager3 = characterController._accessoriesManager;
				bool flag32 = (object)characterController._accessoriesManager == null;
				list2 = (List<Sprite>)(&enumerator);
				if (!flag32)
				{
					bool flag33 = ((EquipmentManager)accessoriesManager3)._003CActiveEquipment_003Ek__BackingField == null;
					list2 = (List<Sprite>)(&enumerator);
					if (!flag33)
					{
						List<Equipment>.Enumerator enumerator2 = default(List<Equipment>.Enumerator);
						if (enumerator2.MoveNext())
						{
							object obj10 = 0;
							throw new NullReferenceException();
						}
						goto IL_113b;
					}
				}
			}
		}
		goto IL_0ee4;
	}

	private bool IsEvolutionUnlocked(WeaponData data)
	{
		//IL_0162: Expected I4, but got O
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null && data != null)
			{
				WeaponType weaponType = Enum.Parse<WeaponType>(data._003CevoInto_003Ek__BackingField);
				if (config._003CCollectedWeapons_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
					object obj = default(object);
					if (obj != null)
					{
						return true;
					}
					PlayerOptions playerOptions = _playerOptions;
					if (_playerOptions != null)
					{
						PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
						if (playerOptions._mainGameConfig != null)
						{
							WeaponType weaponType2 = Enum.Parse<WeaponType>(data._003CevoInto_003Ek__BackingField);
							if (mainGameConfig._003CCollectedWeapons_003Ek__BackingField != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
								bool result = default(bool);
								return result;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void SpawnWeapon(WeaponData data, WeaponType type, int index)
	{
		//IL_02ce: Expected O, but got I4
		//IL_0124: Expected O, but got I4
		//IL_012d: Expected O, but got I4
		//IL_02dc: Expected O, but got I4
		//IL_02e4: Expected O, but got Ref
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected I4, but got Unknown
		//IL_0474: Expected O, but got I4
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected O, but got Unknown
		//IL_0443: Expected O, but got I4
		//IL_0443: Expected O, but got I4
		//IL_0443: Expected I4, but got O
		//IL_0443: Expected O, but got I4
		if (data._003CisPowerUp_003Ek__BackingField)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
			CharacterWeaponsManager accessoriesManager = (CharacterWeaponsManager)(object)characterControllingUi._accessoriesManager;
		}
		else
		{
			VampireSurvivors.Objects.Characters.CharacterController characterControllingUi2 = GetCharacterControllingUi();
			CharacterWeaponsManager accessoriesManager = characterControllingUi2._weaponsManager;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterControllingUi3 = GetCharacterControllingUi();
		bool flag = default(bool);
		List<Sprite> list = AddEvoSpritesForPlayer(data, type, characterControllingUi3, flag);
		bool flag2 = list._size != 0;
		VampireSurvivors.Objects.Characters.CharacterController characterController = null;
		int num3;
		VampireSurvivors.Objects.Characters.CharacterController[] items;
		if (!flag2)
		{
			GameManager core = GM.Core;
			List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
			object characterControllingUi4 = GetCharacterControllingUi();
			int num = Array.IndexOf(mainCharacters._items, characterControllingUi4, 0, mainCharacters._size);
			GameManager core2 = GM.Core;
			int num2 = num;
			object obj = 1;
			object obj2 = 1;
			while (true)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters2 = core2._mainCharacters;
				if ((nint)obj >= mainCharacters2._size)
				{
					break;
				}
				GameManager core3 = GM.Core;
				List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters3 = core3._mainCharacters;
				object obj3 = obj2 + num2;
				num3 = obj3 % mainCharacters3._size;
				GameManager core4 = GM.Core;
				List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters4 = core4._mainCharacters;
				if (num3 < mainCharacters4._size)
				{
					items = mainCharacters4._items;
					List<Sprite> list2 = AddEvoSpritesForPlayer(data, type, items[num3], flag);
					if (list2 == null || list2._size <= 0)
					{
						obj2++;
						core2 = GM.Core;
						num2 = num;
						obj = obj2;
						continue;
					}
					goto IL_0286;
				}
				goto IL_0466;
			}
			characterController = null;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = null;
		VampireSurvivors.Objects.Characters.CharacterController characterController3 = characterController;
		goto IL_02bc;
		IL_02bc:
		int num4 = 0;
		object obj4 = 0;
		List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
		List<Equipment>.Enumerator enumerator2;
		if (enumerator.MoveNext())
		{
			object obj5 = 0;
			enumerator2 = (List<Equipment>.Enumerator)(&enumerator);
			goto IL_0479;
		}
		int num5 = default(int);
		if (obj4 != null)
		{
			num5 = num4 + 1;
			if (obj4 == null)
			{
				num5 = num4;
			}
		}
		DataManager data2 = _data;
		object dataArray = ((Dictionary<System.Int32Enum, object>)(object)data2._003CAllWeaponData_003Ek__BackingField).get_Item((System.Int32Enum)type);
		bool weaponDataForLevel = DataHelper.GetWeaponDataForLevel((JArray)dataArray, num5, out var concreteData);
		if ((object)characterController3 != null && ((UnityEngine.Object)characterController2).m_CachedPtr != (IntPtr)0)
		{
			CharacterData currentSkinData = characterController2._currentSkinData;
			Sprite sprite = SpriteManager.GetSprite(currentSkinData._003CspriteName_003Ek__BackingField, currentSkinData._003CtextureName_003Ek__BackingField);
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(LevelUpItemPrefab, Container);
		LevelUpItemUI component = gameObject.GetComponent<LevelUpItemUI>();
		int index2 = default(int);
		int newLevel = default(int);
		bool isNew = default(bool);
		component.SetWeaponData(this, type, data, (WeaponData)flag, index2, newLevel, isNew, (byte)(int)concreteData != 0, (List<Sprite>)index, (Sprite)num5);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F780");
		return;
		IL_0286:
		characterController2 = items[num3];
		characterController3 = items[num3];
		goto IL_02bc;
		IL_0479:
		throw new NullReferenceException();
		IL_0466:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		enumerator2 = (List<Equipment>.Enumerator)0;
		goto IL_0479;
	}

	private unsafe void ChooseRandomLimitBreak()
	{
		//IL_013b: Expected O, but got Ref
		Func<LevelUpItemUI, bool> predicate = _003C_003Ec._003C_003E9__144_0;
		if (_003C_003Ec._003C_003E9__144_0 == null)
		{
			predicate = (_003C_003Ec._003C_003E9__144_0 = delegate(LevelUpItemUI uiPanel)
			{
				bool flag = ((UnityEngine.Object)uiPanel).m_CachedPtr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 43 ConditionalJump @-1, v51 @ ZF_v5 (System.Boolean) --- -1 Nop");
				/*Error: End of method reached without returning.*/;
			});
		}
		IEnumerable<LevelUpItemUI> enumerable = Enumerable.Where(_spawnedItems, predicate);
		if (enumerable != null)
		{
			List<object> list = new List<object>(enumerable);
			LevelUpItemUI levelUpItemUI = VampireSurvivors.App.Tools.Extensions.PickRnd((IList<LevelUpItemUI>)list);
			if ((object)levelUpItemUI != null && ((UnityEngine.Object)levelUpItemUI).m_CachedPtr != (IntPtr)0 && levelUpItemUI._wlBreak != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterControllingUi = GetCharacterControllingUi();
				WeightedLimitBreak wlBreak = levelUpItemUI._wlBreak;
				SelectLimitBreak(levelUpItemUI._wlBreak, levelUpItemUI._index);
				string localizedDescription = wlBreak.KeyValues.GetLocalizedDescription();
				GameManager core = GM.Core;
				object obj = default(object);
				VampireSurvivors.Objects.Characters.CharacterController character = default(VampireSurvivors.Objects.Characters.CharacterController);
				float displayTimeMultiplier = default(float);
				Vector2 vOffset = default(Vector2);
				core._gizmoManager.DisplayWeaponIconOverhead(wlBreak.WeaponType, localizedDescription, (Color?)(object)(&obj), character, displayTimeMultiplier, vOffset);
			}
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	private void EditorSkipLevelUp()
	{
		Skip();
	}

	public LevelUpPage()
	{
		List<PauseEquipmentPanel> equipmentPanels = new List<PauseEquipmentPanel>();
		_EquipmentPanels = equipmentPanels;
		_spawnedItems = new List<LevelUpItemUI>();
		_weaponData = new Dictionary<WeaponType, List<WeaponData>>();
		_currentWeapons = new List<WeaponType>();
		_banishedWeaponList = new List<GameObject>();
		_activeTweens = new List<Tween>();
		base._002Ector();
	}

	private void _003CTweenButtonsNextFrame_003Eb__128_0()
	{
		if (TwitchIntegration._sInstance.IsTwitchOn() && TwitchIntegration._sInstance.IsTwitchWorking())
		{
			_TwitchLevelUpPanel.ShowCountdown();
		}
	}

	private void _003CAnimate_003Eb__130_0()
	{
		List<LevelUpItemUI> spawnedItems = _spawnedItems;
		if (spawnedItems._size > 0)
		{
			LevelUpItemUI[] items = spawnedItems._items;
			Button component = items[0].GetComponent<Button>();
			component.Select();
			EnableLevelupOptions();
			GameObject gameObject = Container.gameObject;
			VerticalLayoutGroup component2 = gameObject.GetComponent<VerticalLayoutGroup>();
			component2.enabled = true;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}
}
