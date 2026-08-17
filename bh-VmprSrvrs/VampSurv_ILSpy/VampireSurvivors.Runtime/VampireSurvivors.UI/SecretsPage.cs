using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Coffee.UIEffects;
using Coffee.UIExtensions;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Internal;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Platforms;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.VFX.Shatter;
using VampireSurvivors.Spells;
using VampireSurvivors.Tools;

namespace VampireSurvivors.UI;

public class SecretsPage : BaseUIPage
{
	private sealed class _003C_003Ec__DisplayClass110_0
	{
		public SecretsPage _003C_003E4__this;

		public CanvasScaler c;

		internal unsafe void _003CSpin_003Eb__0()
		{
			//IL_0029: Expected O, but got Ref
			SecretsPage secretsPage = _003C_003E4__this;
			Transform transform = secretsPage._Spinner.transform;
			object obj = default(object);
			transform.localEulerAngles = (Vector3)(&obj);
			SecretsPage secretsPage2 = _003C_003E4__this;
			MobileConfig component = secretsPage2._PanelShake.GetComponent<MobileConfig>();
			component.enabled = true;
			SecretsPage secretsPage3 = _003C_003E4__this;
			Shake component2 = secretsPage3._PanelShake.GetComponent<Shake>();
			component2.enabled = true;
		}

		internal unsafe void _003CSpin_003Eb__1()
		{
			//IL_0021: Expected O, but got Ref
			Transform transform = c.transform;
			object obj = default(object);
			transform.localEulerAngles = (Vector3)(&obj);
		}
	}

	private sealed class _003C_003Ec__DisplayClass86_0
	{
		public GameObject k;

		public SecretsPage _003C_003E4__this;

		internal void _003CBuildKeyboard_003Eb__0()
		{
			_003C_003E4__this.SetNextCharacter(k);
		}
	}

	private sealed class _003C_003Ec__DisplayClass87_0
	{
		public SecretsPage _003C_003E4__this;

		public SecretType t;

		internal void _003CUnlock_003Eb__0()
		{
			MultiplayerManager.s_instance.EnableAllUIInteraction();
			SecretsPage secretsPage = _003C_003E4__this;
			secretsPage._spellsManager.StartSpell(t);
		}
	}

	private sealed class _003CDelayedInitShatter_003Ed__66(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public SecretsPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_027a: Expected I4, but got O
			SecretsPage secretsPage = _003C_003E4__this;
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
				if ((object)_003C_003E4__this != null)
				{
					_003C_003E4__this.CreateRuneTexture();
					if ((object)secretsPage._Shatter != null)
					{
						GameObject gameObject = secretsPage._Shatter.gameObject;
						if ((object)gameObject != null)
						{
							gameObject.SetActive(value: false);
							if ((object)secretsPage._Shatter != null)
							{
								SpriteRenderer component = secretsPage._Shatter.GetComponent<SpriteRenderer>();
								if ((object)component != null)
								{
									component.sprite = secretsPage.fakeScreenSpriteLandScape;
									if ((object)secretsPage._Shatter != null)
									{
										RectTransform component2 = secretsPage._Shatter.GetComponent<RectTransform>();
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
										if ((object)component2 != null)
										{
											Vector2 anchoredPosition = default(Vector2);
											component2.anchoredPosition = anchoredPosition;
											if ((object)secretsPage._Shatter != null)
											{
												SpriteRenderer[] array = secretsPage._Shatter.Shatter();
												if ((object)secretsPage._Shatter != null)
												{
													RectTransform component3 = secretsPage._Shatter.GetComponent<RectTransform>();
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
													if ((object)component3 != null)
													{
														Vector2 anchoredPosition2 = default(Vector2);
														component3.anchoredPosition = anchoredPosition2;
														goto IL_0266;
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
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			goto IL_0266;
			IL_0266:
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

	private sealed class _003CDisableGravityWell_003Ed__98(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public SecretsPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0078: Expected I4, but got I8
			//IL_010f: Expected I4, but got O
			SecretsPage secretsPage = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				WaitForSeconds waitForSeconds = null;
				waitForSeconds.m_Seconds = 0.1f;
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null && (object)secretsPage._gravityWell != null)
				{
					GameObject gameObject = secretsPage._gravityWell.gameObject;
					if ((object)gameObject != null)
					{
						gameObject.SetActive(value: false);
						goto IL_00fb;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			goto IL_00fb;
			IL_00fb:
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

	private sealed class _003CWaitAndReselectSpells_003Ed__90(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public SecretsPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0115: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_00e9: Expected I4, but got I8
			//IL_005c: Expected I4, but got I8
			//IL_0140: Expected I4, but got O
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj == 1)
					{
						SecretsPage secretsPage = _003C_003E4__this;
						_003C_003E1__state = -1;
						if ((object)_003C_003E4__this != null && (object)secretsPage._SpellCharacterBackground != null)
						{
							Selectable component = secretsPage._SpellCharacterBackground.GetComponent<Selectable>();
							if ((object)component != null)
							{
								component.Select();
								goto IL_015f;
							}
						}
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					goto IL_015f;
				}
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			}
			_003C_003E1__state = -1;
			_003C_003E2__current = null;
			_003C_003E1__state = 1;
			return true;
			IL_015f:
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

	private sealed class _003CWaitAndResetSliderValue_003Ed__93(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public SecretsPage _003C_003E4__this;

		public float f;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_01a2: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_0176: Expected I4, but got I8
			//IL_0055: Expected I4, but got I8
			//IL_0217: Expected I4, but got O
			//IL_00d9: Expected O, but got Ref
			SecretsPage secretsPage = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj != 1)
					{
						goto IL_0040;
					}
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null && (object)secretsPage._Slider != null)
					{
						secretsPage._Slider.value = f;
						if (secretsPage._spawned != null)
						{
							List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
							if (enumerator.MoveNext())
							{
								List<GameObject>.Enumerator enumerator2 = (List<GameObject>.Enumerator)(&enumerator);
								throw new NullReferenceException();
							}
							goto IL_0040;
						}
					}
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			}
			_003C_003E1__state = -1;
			_003C_003E2__current = null;
			_003C_003E1__state = 1;
			return true;
			IL_0040:
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

	private sealed class _003CWaitAndSelect_003Ed__73(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public SecretsPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			SecretsPage secretsPage = _003C_003E4__this;
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
				List<GameObject> spawned = secretsPage._spawned;
				if (spawned._size <= 0)
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					bool result = default(bool);
					return result;
				}
				GameObject[] items = spawned._items;
				Selectable component = items[0].GetComponent<Selectable>();
				component.Select();
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

	private sealed class _003CWaitForParticles_003Ed__101(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public SecretsPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_00ae: Expected O, but got I4
			//IL_00f7: Expected O, but got I4
			SecretsPage secretsPage = _003C_003E4__this;
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
				if (secretsPage._characterIndex != 0)
				{
					List<GameObject> spellGameCharacters = secretsPage._spellGameCharacters;
					object obj = secretsPage._characterIndex - 1;
					if ((nint)obj >= spellGameCharacters._size)
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						bool result = default(bool);
						return result;
					}
					GameObject[] items = spellGameCharacters._items;
					object obj2 = secretsPage._characterIndex - 1;
					Transform transform = items[obj2].transform;
					secretsPage.PlayInputParticles(transform);
				}
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

	private TextMeshProUGUI _Title;

	private TextMeshProUGUI _ObtainsText;

	private GameObject _KeyboardButtonPrefab;

	private GameObject _SpellCharacterPrefab;

	private RectTransform _KeyboardContainer;

	private RectTransform _SpellCharacterContainer;

	private RectTransform _SpellCharacterContainer2;

	private RectTransform _SpellCharacterBackground;

	private GameObject _ShowKeyboardButton;

	private GameObject _SecretPrefab;

	private RectTransform _SecretContainer;

	private TextMeshProUGUI _Unlocks;

	private Image _CharacterRewardIcon;

	private Image _OtherRewardIcon;

	private Shake _PanelShake;

	private ParticleEmitterManager _RuneParticlesEmitter;

	private SecretUnlockPopup _UnlockPopup;

	private GameObject _TwirlPrefab;

	private RectTransform _TwirlContainer;

	private RectTransform _Spinner;

	private Sprite fakeScreenSpriteLandScape;

	private Sprite fakeScreenSpritePortrait;

	private Image _DevilFader;

	private UIDissolve _DevilPattern;

	private RectTransform _DevilSpinner;

	private RectTransform _Skull;

	private ShatterVFX _Shatter;

	private Texture2D _GeneratedTexture;

	private RawImage _RunePatternImage;

	private RectTransform _RuneContainer;

	private Dictionary<SecretType, SecretData> _secrets;

	private Dictionary<CharacterType, List<CharacterData>> _characterData;

	private string _currentEnteredCheat;

	private int _characterIndex;

	private int _maxLength;

	private int _baseLength;

	private bool _allowInput;

	private bool _isBusy;

	private bool _twirlsBuilt;

	private DataManager _data;

	private PlayerOptions _playerOptions;

	private SpellsManager _spellsManager;

	private ParticleSystem _runeParticles;

	private ParticleSystem _inputParticles;

	private GravityWell _gravityWell;

	private List<Button> _keyboardButtons;

	private List<GameObject> _spellGameCharacters;

	private List<string> _spells;

	private List<GameObject> _spawned;

	private List<char> _characters;

	private string[] _tints;

	private string _spellString;

	private float _baseCharacterSize;

	private Vector3 _baseScale;

	private SecretData _currentData;

	private SecretType _currentType;

	private SecretItemUI _currentItem;

	private List<GameObject> _twirlContainer;

	private List<Image> _twirlImages;

	private bool _canNavigate;

	private BgmType _previousBGM;

	private BgmModType _previousBGMMod;

	private AchievementManager _achievementManager;

	private void Construct(DataManager data, PlayerOptions player, SpellsManager spellsManager, AchievementManager achievementManager)
	{
		_data = data;
		_playerOptions = player;
		_spellsManager = spellsManager;
		AchievementManager achievementManager2 = default(AchievementManager);
		_achievementManager = achievementManager2;
	}

	private void Start()
	{
		BuildTwirls();
	}

	protected override void Awake()
	{
		base.Awake();
		_003CDelayedInitShatter_003Ed__66 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = CoroutineRunner.Instance.StartCoroutine(obj);
	}

	private IEnumerator DelayedInitShatter()
	{
		_003CDelayedInitShatter_003Ed__66 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public void ShowKeyboard()
	{
		List<Button> keyboardButtons = _keyboardButtons;
		if (keyboardButtons._size == 0)
		{
			BuildKeyboard();
		}
		_ShowKeyboardButton.SetActive(value: false);
	}

	public unsafe void SetInfoPanel(SecretData data, SecretType type, SecretItemUI item)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00df: Expected I4, but got O
		//IL_0316: Expected I4, but got O
		//IL_0352: Expected I4, but got O
		//IL_01ae: Expected I4, but got O
		//IL_07fa: Expected O, but got Ref
		//IL_03a5: Expected I4, but got O
		//IL_0432: Expected I4, but got O
		//IL_0432: Expected O, but got I4
		//IL_05ca: Expected O, but got I
		//IL_0667: Expected O, but got Ref
		//IL_136e: Expected I, but got O
		//IL_1a78: Expected O, but got I4
		//IL_1a78: Expected I4, but got O
		//IL_1a8c: Expected O, but got I
		//IL_13c3: Expected O, but got Ref
		//IL_06f7: Expected O, but got I
		//IL_0779: Unknown result type (might be due to invalid IL or missing references)
		//IL_077e: Expected O, but got Unknown
		//IL_0766: Expected I4, but got O
		//IL_0766: Expected O, but got I4
		//IL_0ba6: Expected O, but got I
		//IL_14ef: Expected O, but got Ref
		//IL_1646: Expected O, but got Ref
		//IL_0d18: Expected I, but got O
		//IL_1552: Expected O, but got Ref
		//IL_1574: Expected O, but got I
		//IL_16b3: Expected O, but got Ref
		//IL_15bd: Expected O, but got Ref
		//IL_15cf: Expected I, but got O
		//IL_0dd0: Expected O, but got Ref
		//IL_170f: Expected O, but got Ref
		//IL_1721: Expected I, but got O
		//IL_1772: Expected O, but got Ref
		//IL_17df: Expected O, but got Ref
		//IL_183b: Expected O, but got Ref
		//IL_184d: Expected I, but got O
		//IL_195c: Expected O, but got Ref
		//IL_19cf: Expected O, but got Ref
		//IL_1a2b: Expected O, but got Ref
		//IL_1a3d: Expected I, but got O
		//IL_1254->IL110d: Incompatible stack heights: 1 vs 0
		//IL_07e6->IL110d: Incompatible stack heights: 1 vs 0
		//IL_0838->IL110d: Incompatible stack heights: 1 vs 0
		//IL_12ae->IL110d: Incompatible stack heights: 2 vs 0
		//IL_1319->IL110d: Incompatible stack heights: 3 vs 0
		//IL_1414->IL110d: Incompatible stack heights: 6 vs 0
		//IL_0a4c->IL110d: Incompatible stack heights: 6 vs 0
		//IL_08cd->IL110d: Incompatible stack heights: 6 vs 0
		//IL_0a76->IL110d: Incompatible stack heights: 6 vs 0
		//IL_08f9->IL110d: Incompatible stack heights: 6 vs 0
		//IL_0aa0->IL110d: Incompatible stack heights: 6 vs 0
		//IL_0923->IL110d: Incompatible stack heights: 6 vs 0
		//IL_0acd->IL110d: Incompatible stack heights: 6 vs 0
		//IL_0af9->IL110d: Incompatible stack heights: 6 vs 0
		//IL_0b25->IL110d: Incompatible stack heights: 6 vs 0
		//IL_146e->IL110d: Incompatible stack heights: 7 vs 0
		//IL_0b53->IL110d: Incompatible stack heights: 6 vs 0
		//IL_0b7f->IL110d: Incompatible stack heights: 6 vs 0
		//IL_14be->IL110d: Incompatible stack heights: 8 vs 0
		//IL_0bbe->IL110d: Incompatible stack heights: 6 vs 0
		//IL_0965->IL110d: Incompatible stack heights: 8 vs 0
		//IL_0991->IL110d: Incompatible stack heights: 8 vs 0
		//IL_160f->IL110d: Incompatible stack heights: 6 vs 0
		//IL_0c15->IL110d: Incompatible stack heights: 6 vs 0
		//IL_0f31->IL110d: Incompatible stack heights: 6 vs 0
		//IL_0c41->IL110d: Incompatible stack heights: 6 vs 0
		//IL_151b->IL110d: Incompatible stack heights: 9 vs 0
		//IL_0f60->IL110d: Incompatible stack heights: 6 vs 0
		//IL_0c8a->IL110d: Incompatible stack heights: 6 vs 0
		//IL_09ce->IL110d: Incompatible stack heights: 9 vs 0
		//IL_09fa->IL110d: Incompatible stack heights: 9 vs 0
		//IL_167c->IL110d: Incompatible stack heights: 7 vs 0
		//IL_0d0b->IL110d: Incompatible stack heights: 6 vs 0
		//IL_0f99->IL110d: Incompatible stack heights: 7 vs 0
		//IL_0d3c->IL110d: Incompatible stack heights: 6 vs 0
		//IL_158c->IL110d: Incompatible stack heights: 10 vs 0
		//IL_0d68->IL110d: Incompatible stack heights: 6 vs 0
		//IL_0d92->IL110d: Incompatible stack heights: 6 vs 0
		//IL_16de->IL110d: Incompatible stack heights: 8 vs 0
		//IL_0dbc->IL110d: Incompatible stack heights: 6 vs 0
		//IL_15d5->IL0bd6: Incompatible stack heights: 11 vs 6
		//IL_0e0e->IL110d: Incompatible stack heights: 6 vs 0
		//IL_173b->IL110d: Incompatible stack heights: 9 vs 0
		//IL_15ef->IL110d: Incompatible stack heights: 6 vs 0
		//IL_0fea->IL110d: Incompatible stack heights: 9 vs 0
		//IL_0e88->IL110d: Incompatible stack heights: 6 vs 0
		//IL_1019->IL110d: Incompatible stack heights: 9 vs 0
		//IL_0eb4->IL110d: Incompatible stack heights: 6 vs 0
		//IL_0ee0->IL110d: Incompatible stack heights: 6 vs 0
		//IL_17a8->IL110d: Incompatible stack heights: 10 vs 0
		//IL_1052->IL110d: Incompatible stack heights: 10 vs 0
		//IL_180a->IL110d: Incompatible stack heights: 11 vs 0
		//IL_1871->IL110d: Incompatible stack heights: 12 vs 0
		//IL_18cb->IL110d: Incompatible stack heights: 13 vs 0
		//IL_1925->IL110d: Incompatible stack heights: 14 vs 0
		//IL_10a9->IL110d: Incompatible stack heights: 14 vs 0
		//IL_10e5->IL110d: Incompatible stack heights: 14 vs 0
		//IL_1998->IL110d: Incompatible stack heights: 15 vs 0
		//IL_19fa->IL110d: Incompatible stack heights: 16 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		bool flag6 = default(bool);
		GameObject gameObject = default(GameObject);
		string text = default(string);
		bool flag7 = default(bool);
		if ((object)item != null)
		{
			Sprite characterReward = item.GetCharacterReward(data);
			if ((object)_CharacterRewardIcon != null)
			{
				_CharacterRewardIcon.sprite = characterReward;
				if (data != null)
				{
					if ((object)data._003CcharacterToUnlock_003Ek__BackingField == null)
					{
						bool flag = data._003CskinsToUnlock_003Ek__BackingField == null;
						SecretItemUI secretItemUI = item;
						if (!flag)
						{
							List<SkinToUnlock> list = data._003CskinsToUnlock_003Ek__BackingField;
							bool flag2 = list._size <= 0;
							secretItemUI = item;
							if (!flag2)
							{
								List<CharacterData> list2 = ((Dictionary<CharacterType, List<CharacterData>>)(object)list).get_Item(CharacterType.VOID);
								if (_data == null)
								{
									goto IL_110d;
								}
								Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _data.GetConvertedCharacterData();
								bool flag3 = convertedCharacterData == null;
								secretItemUI = item;
								if (!flag3)
								{
									if (list2 == null)
									{
										goto IL_110d;
									}
									object obj3 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)list2._items);
									bool flag4 = obj3 == null;
									secretItemUI = item;
									if (!flag4)
									{
										List<CharacterData> list3 = ((Dictionary<CharacterType, List<CharacterData>>)obj3).get_Item((CharacterType)list2._items);
										bool flag5 = list3 == null;
										secretItemUI = item;
										if (!flag5)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rax_v364 (System.Collections.Generic.List`1<VampireSurvivors.Data.Characters.CharacterData>)+14]");
											_ = 0;
											string fullName = ((CharacterData)(object)list3).GetFullName((CharacterType)list2._items, false, true);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1526 @ rax_v367 (System.Collections.Generic.List`1<VampireSurvivors.Data.Characters.CharacterData>)+184]");
											_ = 0;
											string translation = LocalizationManager.GetTranslation("lang/genericPopup_unlocked", FixForRTL: true, 0, ignoreRTLnumbers: true, flag6, gameObject, text, flag7);
											string text2 = translation + " " + fullName;
											if ((object)_Unlocks == null)
											{
												goto IL_110d;
											}
											List<CharacterData> list4 = ((Dictionary<CharacterType, List<CharacterData>>)66).get_Item((CharacterType)_Unlocks);
											secretItemUI = null;
										}
									}
								}
							}
						}
						goto IL_0441;
					}
					if ((object)data._003CcharacterToUnlock_003Ek__BackingField == null)
					{
						goto IL_1136;
					}
					if (_characterData != null)
					{
						System.Int32Enum key = (System.Int32Enum)((object?)data._003CcharacterToUnlock_003Ek__BackingField >> 32);
						object obj4 = ((Dictionary<System.Int32Enum, object>)(object)_characterData).get_Item(key);
						if (obj4 != null)
						{
							List<CharacterData> list5 = ((Dictionary<CharacterType, List<CharacterData>>)obj4).get_Item((CharacterType)key);
							Image unlocks = (Image)(object)_Unlocks;
							string translation2 = LocalizationManager.GetTranslation("lang/genericPopup_unlocked", FixForRTL: true, 0, ignoreRTLnumbers: true, flag6, gameObject, text, flag7);
							if ((object)data._003CcharacterToUnlock_003Ek__BackingField == null)
							{
								goto IL_1136;
							}
							if (list5 != null)
							{
								CharacterType t = (CharacterType)((object?)data._003CcharacterToUnlock_003Ek__BackingField >> 32);
								string fullName2 = ((CharacterData)(object)list5).GetFullName(t, false, true);
								string text3 = translation2 + " " + fullName2;
								if ((object)_Unlocks != null)
								{
									SecretItemUI secretItemUI = (SecretItemUI)(object)unlocks;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v218 @ r9_v49 (VampireSurvivors.UI.SecretItemUI)+558] (should have been resolved before IL gen)");
									goto IL_0441;
								}
							}
						}
					}
				}
			}
		}
		goto IL_110d;
		IL_1141:
		Vector2 sizeDelta = default(Vector2);
		if ((object)_Unlocks != null)
		{
			Transform transform = _Unlocks.transform;
			if ((object)transform != null)
			{
				bool flag8 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				IntPtr parent_Injected = Transform.GetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr);
				Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected);
				if ((object)transform2 != null)
				{
					Image component = transform2.GetComponent<Image>();
					if ((object)component != null)
					{
						Color color = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
						_ = 0;
						component.color = color;
						Image obtainsText = (Image)(object)_ObtainsText;
						if ((object)_ObtainsText != null)
						{
							bool flag9 = ((UnityEngine.Object)obtainsText).m_CachedPtr == (IntPtr)0;
							IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)obtainsText).m_CachedPtr);
							GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
							if ((object)gameObject2 != null)
							{
								bool flag10 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
								GameObject.SetActive_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr, true);
								Sprite secondReward = item.GetSecondReward(data);
								Image characterRewardIcon = _CharacterRewardIcon;
								if ((object)_CharacterRewardIcon != null)
								{
									bool flag11 = ((UnityEngine.Object)characterRewardIcon).m_CachedPtr == (IntPtr)0;
									IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)characterRewardIcon).m_CachedPtr);
									Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
									nint num = (nint)typeof(Vector3);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2914 @ rcx_v138 (Il2CppClass<UnityEngine.Vector3>)+B8]");
									nint num2 = 0;
									bool flag12 = (object)transform3 == null;
									_ = Vector3.oneVector;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2915 @ rax_v145 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
									_ = 0;
									bool flag13 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
									object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
									Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)obj5);
									Component otherRewardIcon;
									if ((object)secondReward != null)
									{
										bool flag14 = ((UnityEngine.Object)secondReward).m_CachedPtr == (IntPtr)0;
										otherRewardIcon = _OtherRewardIcon;
										if (!flag14)
										{
											if ((object)_OtherRewardIcon != null)
											{
												Transform transform4 = _OtherRewardIcon.transform;
												if ((object)transform4 != null)
												{
													Transform parent = transform4.parent;
													if ((object)parent != null)
													{
														bool flag15 = ((UnityEngine.Object)parent).m_CachedPtr == (IntPtr)0;
														IntPtr gcHandlePtr3 = Component.get_gameObject_Injected(((UnityEngine.Object)parent).m_CachedPtr);
														GameObject gameObject3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr3);
														if ((object)gameObject3 != null)
														{
															bool flag16 = ((UnityEngine.Object)gameObject3).m_CachedPtr == (IntPtr)0;
															GameObject.SetActive_Injected(((UnityEngine.Object)gameObject3).m_CachedPtr, true);
															if ((object)_OtherRewardIcon != null)
															{
																_OtherRewardIcon.sprite = secondReward;
																if ((object)_Unlocks != null)
																{
																	RectTransform rectTransform = _Unlocks.rectTransform;
																	if ((object)rectTransform != null)
																	{
																		bool flag17 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
																		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 95));
																		RectTransform.set_sizeDelta_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, ref *(Vector2*)obj6);
																		if ((object)_ObtainsText != null)
																		{
																			RectTransform rectTransform2 = _ObtainsText.rectTransform;
																			if ((object)_ObtainsText != null)
																			{
																				RectTransform rectTransform3 = _ObtainsText.rectTransform;
																				if ((object)rectTransform3 != null)
																				{
																					_ = 0;
																					bool flag18 = ((UnityEngine.Object)rectTransform3).m_CachedPtr == (IntPtr)0;
																					object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 95));
																					RectTransform.get_sizeDelta_Injected(((UnityEngine.Object)rectTransform3).m_CachedPtr, out *(Vector2*)obj7);
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+63]");
																					object obj8 = 0;
																					if ((object)rectTransform2 != null)
																					{
																						bool flag19 = ((SecretData)(object)rectTransform2)._003Cdescription_003Ek__BackingField == null;
																						object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
																						RectTransform.set_sizeDelta_Injected((IntPtr)((SecretData)(object)rectTransform2)._003Cdescription_003Ek__BackingField, ref *(Vector2*)obj9);
																						goto IL_0bd6;
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
											goto IL_110d;
										}
									}
									else
									{
										otherRewardIcon = _OtherRewardIcon;
									}
									if ((object)otherRewardIcon != null)
									{
										Transform transform5 = otherRewardIcon.transform;
										if ((object)transform5 != null)
										{
											Transform parent2 = transform5.parent;
											if ((object)parent2 != null)
											{
												GameObject gameObject4 = parent2.gameObject;
												if ((object)gameObject4 != null)
												{
													gameObject4.SetActive(value: false);
													if ((object)_Unlocks != null)
													{
														RectTransform rectTransform4 = _Unlocks.rectTransform;
														if ((object)rectTransform4 != null)
														{
															rectTransform4.sizeDelta = sizeDelta;
															if ((object)_ObtainsText != null)
															{
																RectTransform rectTransform5 = _ObtainsText.rectTransform;
																if ((object)_ObtainsText != null)
																{
																	RectTransform rectTransform6 = _ObtainsText.rectTransform;
																	if ((object)rectTransform6 != null)
																	{
																		Vector2 sizeDelta2 = rectTransform6.sizeDelta;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+63]");
																		object obj8 = 0;
																		if ((object)rectTransform5 != null)
																		{
																			rectTransform5.sizeDelta = sizeDelta;
																			goto IL_0bd6;
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
							}
						}
					}
				}
			}
		}
		goto IL_110d;
		IL_1166:
		throw new IndexOutOfRangeException();
		IL_0bd6:
		if (!item._hasAchieved)
		{
			if ((object)_Unlocks != null)
			{
				RectTransform rectTransform7 = _Unlocks.rectTransform;
				if ((object)rectTransform7 != null)
				{
					rectTransform7.sizeDelta = sizeDelta;
					Sprite sprite = SpriteManager.GetSprite("QuestionMark", "UI");
					if ((object)_CharacterRewardIcon != null)
					{
						_CharacterRewardIcon.sprite = sprite;
						RectTransform unlocks2 = (RectTransform)(object)_Unlocks;
						string translation3 = LocalizationManager.GetTranslation("lang/genericPopup_unlocks", FixForRTL: true, 0, ignoreRTLnumbers: true, flag6, gameObject, text, flag7);
						string text4 = translation3 + "???";
						if ((object)_Unlocks != null)
						{
							nint num3 = (nint)unlocks2;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v222 @ r9_v54 (Il2CppClass<UnityEngine.RectTransform>)+558] (should have been resolved before IL gen)");
							if ((object)_Unlocks != null)
							{
								Transform transform6 = _Unlocks.transform;
								if ((object)transform6 != null)
								{
									Transform parent3 = transform6.parent;
									if ((object)parent3 != null)
									{
										Image component2 = parent3.GetComponent<Image>();
										if ((object)component2 != null)
										{
											Color color2 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12250]");
											_ = 0;
											component2.color = color2;
											TextMeshProUGUI unlocks3 = _Unlocks;
											if ((object)_Unlocks != null)
											{
												if (((TMP_Text)unlocks3).m_HorizontalAlignment != HorizontalAlignmentOptions.Center)
												{
													((TMP_Text)unlocks3).m_HorizontalAlignment = HorizontalAlignmentOptions.Center;
													((TMP_Text)unlocks3).m_havePropertiesChanged = true;
													_Unlocks.SetVerticesDirty();
												}
												if ((object)_Unlocks != null)
												{
													RectTransform rectTransform8 = _Unlocks.rectTransform;
													if ((object)rectTransform8 != null)
													{
														rectTransform8.sizeDelta = sizeDelta;
														if ((object)_ObtainsText != null)
														{
															GameObject gameObject5 = _ObtainsText.gameObject;
															if ((object)gameObject5 != null)
															{
																gameObject5.SetActive(value: false);
																goto IL_15f4;
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
				}
			}
			goto IL_110d;
		}
		goto IL_15f4;
		IL_110d:
		throw new NullReferenceException();
		IL_1136:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		goto IL_1166;
		IL_15f4:
		if ((object)_CharacterRewardIcon != null)
		{
			RectTransform rectTransform9 = _CharacterRewardIcon.rectTransform;
			Image characterRewardIcon2 = _CharacterRewardIcon;
			if ((object)_CharacterRewardIcon != null)
			{
				Image sprite2 = (Image)(object)characterRewardIcon2.m_Sprite;
				if ((object)characterRewardIcon2.m_Sprite != null)
				{
					_ = 0;
					bool flag20 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
					object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
					Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out *(Rect*)obj10);
					Image characterRewardIcon3 = _CharacterRewardIcon;
					if ((object)_CharacterRewardIcon != null)
					{
						Image sprite3 = (Image)(object)characterRewardIcon3.m_Sprite;
						if ((object)characterRewardIcon3.m_Sprite != null)
						{
							_ = 0;
							bool flag21 = ((UnityEngine.Object)sprite3).m_CachedPtr == (IntPtr)0;
							object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite3).m_CachedPtr, out *(Rect*)obj11);
							if ((object)rectTransform9 != null)
							{
								bool flag22 = ((SecretData)(object)rectTransform9)._003Cdescription_003Ek__BackingField == null;
								object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 95));
								RectTransform.set_sizeDelta_Injected((IntPtr)((SecretData)(object)rectTransform9)._003Cdescription_003Ek__BackingField, ref *(Vector2*)obj12);
								if ((object)_OtherRewardIcon != null)
								{
									RectTransform rectTransform10 = _OtherRewardIcon.rectTransform;
									Image otherRewardIcon2 = _OtherRewardIcon;
									if ((object)_OtherRewardIcon != null)
									{
										Image sprite4 = (Image)(object)otherRewardIcon2.m_Sprite;
										if ((object)otherRewardIcon2.m_Sprite != null)
										{
											_ = 0;
											bool flag23 = ((UnityEngine.Object)sprite4).m_CachedPtr == (IntPtr)0;
											object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
											Sprite.get_rect_Injected(((UnityEngine.Object)sprite4).m_CachedPtr, out *(Rect*)obj13);
											Image otherRewardIcon3 = _OtherRewardIcon;
											if ((object)_OtherRewardIcon != null)
											{
												Image sprite5 = (Image)(object)otherRewardIcon3.m_Sprite;
												if ((object)otherRewardIcon3.m_Sprite != null)
												{
													_ = 0;
													bool flag24 = ((UnityEngine.Object)sprite5).m_CachedPtr == (IntPtr)0;
													object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
													Sprite.get_rect_Injected(((UnityEngine.Object)sprite5).m_CachedPtr, out *(Rect*)obj14);
													if ((object)rectTransform10 != null)
													{
														bool flag25 = ((SecretData)(object)rectTransform10)._003Cdescription_003Ek__BackingField == null;
														object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 95));
														RectTransform.set_sizeDelta_Injected((IntPtr)((SecretData)(object)rectTransform10)._003Cdescription_003Ek__BackingField, ref *(Vector2*)obj15);
														Image otherRewardIcon4 = _OtherRewardIcon;
														if ((object)_OtherRewardIcon != null)
														{
															bool flag26 = ((UnityEngine.Object)otherRewardIcon4).m_CachedPtr == (IntPtr)0;
															IntPtr gcHandlePtr4 = Component.get_transform_Injected(((UnityEngine.Object)otherRewardIcon4).m_CachedPtr);
															Transform transform7 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
															if ((object)transform7 != null)
															{
																bool flag27 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
																IntPtr parent_Injected2 = Transform.GetParent_Injected(((UnityEngine.Object)transform7).m_CachedPtr);
																Transform transform8 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected2);
																if ((object)transform8 != null)
																{
																	Image component3 = transform8.GetComponent<Image>();
																	if ((object)component3 != null)
																	{
																		RectTransform rectTransform11 = component3.rectTransform;
																		SecretsPage sprite6 = (SecretsPage)(object)component3.m_Sprite;
																		if ((object)component3.m_Sprite != null)
																		{
																			_ = 0;
																			bool flag28 = ((UnityEngine.Object)sprite6).m_CachedPtr == (IntPtr)0;
																			object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
																			Sprite.get_rect_Injected(((UnityEngine.Object)sprite6).m_CachedPtr, out *(Rect*)obj16);
																			Image sprite7 = (Image)(object)component3.m_Sprite;
																			if ((object)component3.m_Sprite != null)
																			{
																				_ = 0;
																				bool flag29 = ((UnityEngine.Object)sprite7).m_CachedPtr == (IntPtr)0;
																				object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
																				Sprite.get_rect_Injected(((UnityEngine.Object)sprite7).m_CachedPtr, out *(Rect*)obj17);
																				if ((object)rectTransform11 != null)
																				{
																					bool flag30 = ((SecretData)(object)rectTransform11)._003Cdescription_003Ek__BackingField == null;
																					object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 95));
																					RectTransform.set_sizeDelta_Injected((IntPtr)((SecretData)(object)rectTransform11)._003Cdescription_003Ek__BackingField, ref *(Vector2*)obj18);
																					return;
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
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_110d;
		IL_0441:
		if (data._003CweaponListToUnlock_003Ek__BackingField != null)
		{
			Sprite sprite8 = SpriteManager.GetSprite(data._003CcustomFrame_003Ek__BackingField, data._003CcustomTexture_003Ek__BackingField);
			if ((object)_CharacterRewardIcon != null)
			{
				_CharacterRewardIcon.sprite = sprite8;
				Image unlocks4 = (Image)(object)_Unlocks;
				string translation4 = LocalizationManager.GetTranslation("lang/genericPopup_unlocked", FixForRTL: true, 0, ignoreRTLnumbers: true, flag6, gameObject, text, flag7);
				string text5 = translation4 + " ";
				if ((object)_Unlocks != null)
				{
					SecretItemUI secretItemUI = (SecretItemUI)(object)unlocks4;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v218 @ r9_v49 (VampireSurvivors.UI.SecretItemUI)+558] (should have been resolved before IL gen)");
					Image image = null;
					Image image2 = null;
					while (true)
					{
						List<WeaponType> list6 = data._003CweaponListToUnlock_003Ek__BackingField;
						if (data._003CweaponListToUnlock_003Ek__BackingField == null)
						{
							break;
						}
						Image image3 = image2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rax_v336 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						if ((nint)image3 >= 0)
						{
							goto IL_1141;
						}
						if (data._003CweaponListToUnlock_003Ek__BackingField == null)
						{
							break;
						}
						Image image4 = image;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rax_v336 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						if ((nint)image4 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rax_v336 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
							object obj19 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rax_v336 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
							if ((nint)0 == 0)
							{
								break;
							}
							Image image5 = image;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v476 @ rcx_v301+18]");
							if ((nint)image5 < 0)
							{
								TextMeshProUGUI unlocks5 = _Unlocks;
								if ((object)_Unlocks == null)
								{
									break;
								}
								string text6 = _Unlocks.text;
								_ = typeof(WeaponType);
								Enum obj20 = (Enum)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
								_ = -1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v476 @ rcx_v301+20+v230 @ rbx_v85 (UnityEngine.UI.Image)*4]");
								_ = 0;
								string text7 = obj20.ToString();
								string text8 = "weaponLang/{" + text7 + "}name";
								_ = 0;
								bool flag31 = LocalizationManager.TryGetTranslation(text8, out System.Runtime.CompilerServices.Unsafe.As<object, string>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 95)), FixForRTL: true, 0, flag6, (byte)(int)gameObject != 0, (GameObject)(object)text, (string)flag7);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+5F]");
								string text9 = (string)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+5F]");
								if ((nint)0 == 0 || text9._stringLength <= 0)
								{
									text9 = text8;
								}
								string text10 = text6 + text9;
								secretItemUI = (SecretItemUI)(object)unlocks5;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v218 @ r9_v49 (VampireSurvivors.UI.SecretItemUI)+558] (should have been resolved before IL gen)");
								List<WeaponType> list7 = data._003CweaponListToUnlock_003Ek__BackingField;
								if (data._003CweaponListToUnlock_003Ek__BackingField == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v349 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
								object obj21 = -1;
								if (System.Runtime.CompilerServices.Unsafe.As<Image, UIntPtr>(ref image) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj21))
								{
									if ((object)_Unlocks == null)
									{
										break;
									}
									string text11 = _Unlocks.text;
									string text12 = text11 + " + ";
									List<CharacterData> list8 = ((Dictionary<CharacterType, List<CharacterData>>)66).get_Item((CharacterType)_Unlocks);
								}
								image = (Image)(image + 1);
								image2 = image;
								continue;
							}
						}
						else
						{
							System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						}
						goto IL_1166;
					}
				}
			}
			goto IL_110d;
		}
		goto IL_1141;
	}

	public unsafe void DoDevilEffect()
	{
		//IL_00d2: Expected O, but got Ref
		//IL_018f: Expected O, but got I4
		MultiplayerManager.s_instance.DisableAllUIInteraction();
		Vector2 vector = default(Vector2);
		_Skull.anchoredPosition = vector;
		TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOAnchorPos(_Skull, vector, 0.5f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rax_v19 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 7;
				_ = 0;
			}
		}
		RectTransform skull = _Skull;
		bool flag = ((UnityEngine.Object)skull).m_CachedPtr == (IntPtr)0;
		Vector2 value = default(Vector2);
		Transform.set_localScale_Injected(((UnityEngine.Object)skull).m_CachedPtr, ref *(Vector3*)(&value));
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(_Skull, 3f, 0.7f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v653 @ rax_v27 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 22;
				_ = 0;
			}
		}
		Image component = _Skull.GetComponent<Image>();
		object obj = default(object);
		component.color = (Color)(&obj);
		Image component2 = _Skull.GetComponent<Image>();
		TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleUI.DOFade(component2, 0.45f, 0.7f);
		TweenCallback tweenCallback = delegate
		{
			Image component3 = _Skull.GetComponent<Image>();
			TweenerCore<Color, Color, ColorOptions> tweenerCore4 = DOTweenModuleUI.DOFade(component3, 0f, 0.3f);
		};
		if (tweenerCore3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v741 @ rax_v32 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		SoundManager.StopMusic(BgmType.BGM_Secret);
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_forbiddenSpell, new SoundManager.SoundConfig
		{
			Volume = (float?)(object)1,
			Rate = 1.25f
		}, 0f, 10, time);
		Sequence sequence = DOTween.Sequence();
		Sequence sequence2 = TweenSettingsExtensions.AppendInterval(sequence, 0.3f);
		TweenCallback tweenCallback2 = delegate
		{
			//IL_0008: Expected O, but got Ref
			//IL_08c7: Expected I, but got O
			//IL_0915: Expected I, but got O
			//IL_0958: Expected I, but got O
			//IL_0107: Expected I, but got O
			//IL_0115: Expected O, but got Ref
			//IL_018c: Expected I, but got O
			//IL_0221: Expected F4, but got I4
			//IL_022a: Expected O, but got I4
			//IL_0238: Expected F4, but got I4
			//IL_0a85: Expected O, but got Ref
			//IL_110b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1110: Expected O, but got Unknown
			//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f7: Expected O, but got Unknown
			//IL_0724: Unknown result type (might be due to invalid IL or missing references)
			//IL_0729: Expected O, but got Unknown
			//IL_0d8b: Expected O, but got Ref
			//IL_0dd5: Expected O, but got Ref
			//IL_0f1a: Expected O, but got Ref
			//IL_0f69: Expected I, but got O
			//IL_0f77: Expected O, but got Ref
			//IL_111d->IL09f1: Incompatible stack heights: 1 vs 0
			//IL_02e3->IL0865: Incompatible stack heights: 1 vs 0
			//IL_0316->IL0865: Incompatible stack heights: 1 vs 0
			//IL_0340->IL0865: Incompatible stack heights: 1 vs 0
			//IL_036a->IL0865: Incompatible stack heights: 1 vs 0
			//IL_04c4->IL0865: Incompatible stack heights: 3 vs 0
			//IL_0394->IL0865: Incompatible stack heights: 1 vs 0
			//IL_118b->IL0865: Incompatible stack heights: 3 vs 0
			//IL_052a->IL0865: Incompatible stack heights: 4 vs 0
			//IL_0c2b->IL0865: Incompatible stack heights: 5 vs 0
			//IL_0c8b->IL0865: Incompatible stack heights: 6 vs 0
			//IL_0736->IL0b68: Incompatible stack heights: 5 vs 3
			//IL_05f6->IL0865: Incompatible stack heights: 5 vs 0
			//IL_0ceb->IL0865: Incompatible stack heights: 7 vs 0
			//IL_063b->IL0865: Incompatible stack heights: 5 vs 0
			//IL_0d4b->IL0865: Incompatible stack heights: 8 vs 0
			//IL_0fda->IL0865: Incompatible stack heights: 18 vs 0
			//IL_103a->IL0865: Incompatible stack heights: 19 vs 0
			//IL_109a->IL0865: Incompatible stack heights: 20 vs 0
			//IL_07fb->IL0865: Incompatible stack heights: 21 vs 0
			//IL_081d->IL0865: Incompatible stack heights: 21 vs 0
			//IL_084c->IL0865: Incompatible stack heights: 21 vs 0
			object obj3 = default(object);
			object obj2 = (object)(&obj3);
			if ((object)_Shatter != null)
			{
				GameObject gameObject = _Shatter.gameObject;
				if ((object)gameObject != null)
				{
					gameObject.SetActive(value: true);
					Physics.simulationMode = SimulationMode.FixedUpdate;
					if ((object)_Shatter != null)
					{
						RectTransform component3 = _Shatter.GetComponent<RectTransform>();
						nint num = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rcx_v111 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ rax_v116 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
						_ = 0;
						_ = Vector3.oneVector;
						if ((object)component3 != null)
						{
							Vector2 vector2 = default(Vector2);
							component3.anchorMin = vector2;
							nint num3 = (nint)typeof(Vector3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1024 @ rax_v120 (Il2CppClass<UnityEngine.Vector3>)+B8]");
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1025 @ rax_v121 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
							_ = 0;
							_ = Vector3.oneVector;
							component3.anchorMax = vector2;
							nint num5 = (nint)typeof(Vector3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1121 @ rax_v125 (Il2CppClass<UnityEngine.Vector3>)+B8]");
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1122 @ rax_v126 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
							_ = 0;
							_ = Vector3.oneVector;
							component3.pivot = vector2;
							if ((object)_Shatter != null)
							{
								SpriteRenderer component4 = _Shatter.GetComponent<SpriteRenderer>();
								if ((object)component4 != null)
								{
									component4.sprite = fakeScreenSpriteLandScape;
									Image devilFader = _DevilFader;
									if ((object)_DevilFader != null)
									{
										nint num7 = (nint)devilFader;
										Color color = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj3, 25));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F20]");
										_ = 0;
										_DevilFader.color = color;
										object devilPattern = _DevilPattern;
										if ((object)_DevilPattern != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
											object obj4 = default(object);
											if (obj4 == null)
											{
												nint num8 = (nint)devilPattern;
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1391 @ rax_v379 (Il2CppClass<System.Object>)+2A8] (should have been resolved before IL gen)");
											}
											_ = 0;
											_ = 0;
											if ((object)_Shatter != null)
											{
												Transform transform = _Shatter.transform;
												if ((object)transform != null)
												{
													Transform child = transform.GetChild(0);
													if ((object)child != null)
													{
														Transform[] componentsInChildren = child.GetComponentsInChildren<Transform>();
														bool flag2 = componentsInChildren == null;
														float num9 = 0f;
														object obj5 = 0;
														object obj6 = null;
														float num10 = 0f;
														object obj7 = null;
														if (!flag2)
														{
															TweenerCore<Color, Color, ColorOptions> t = default(TweenerCore<Color, Color, ColorOptions>);
															while (true)
															{
																if ((nint)obj7 >= componentsInChildren.Length)
																{
																	float num11 = num9 / (float)obj5;
																	GameObject gameObject2 = new GameObject();
																	GameObject.Internal_CreateGameObject(gameObject2, (string)null);
																	bool flag3 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
																	IntPtr gcHandlePtr = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr);
																	Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
																	bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
																	object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj3, 57));
																	Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj8);
																	bool flag5 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
																	IntPtr gcHandlePtr2 = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr);
																	Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
																	bool flag6 = (object)transform3.GetType() != typeof(RectTransform);
																	Transform transform4 = null;
																	if (!flag6)
																	{
																		transform4 = transform3;
																	}
																	if ((object)transform4 != null)
																	{
																		Debug.LogWarning("Parent of RectTransform is being set with parent property. Consider using the SetParent method instead, with the worldPositionStays argument set to false. This will retain local orientation and scale rather than world orientation and scale, which can prevent common UI scaling issues.", transform3);
																	}
																	transform3.SetParent(child, worldPositionStays: true);
																	Rigidbody[] componentsInChildren2 = child.GetComponentsInChildren<Rigidbody>();
																	if (componentsInChildren2 != null)
																	{
																		object obj9 = null;
																		object obj10 = null;
																		while (true)
																		{
																			if ((nint)obj10 >= componentsInChildren2.Length)
																			{
																				IntPtr gcHandlePtr3 = GameObject.CreatePrimitive_Injected(PrimitiveType.Sphere);
																				GameObject gameObject3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr3);
																				if ((object)gameObject3 == null)
																				{
																					break;
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v168 (UnityEngine.GameObject)+10]");
																				bool flag7 = (nint)0 == 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v168 (UnityEngine.GameObject)+10]");
																				IntPtr gcHandlePtr4 = GameObject.get_transform_Injected((IntPtr)0);
																				Transform transform5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
																				bool flag8 = ((UnityEngine.Object)child).m_CachedPtr == (IntPtr)0;
																				IntPtr gcHandlePtr5 = Component.get_transform_Injected(((UnityEngine.Object)child).m_CachedPtr);
																				Transform transform6 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr5);
																				if ((object)transform6 == null)
																				{
																					break;
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v178 (UnityEngine.Transform)+10]");
																				bool flag9 = (nint)0 == 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v178 (UnityEngine.Transform)+10]");
																				IntPtr parent_Injected = Transform.GetParent_Injected((IntPtr)0);
																				Transform transform7 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected);
																				if ((object)transform7 == null)
																				{
																					break;
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rax_v183 (UnityEngine.Transform)+10]");
																				bool flag10 = (nint)0 == 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rax_v183 (UnityEngine.Transform)+10]");
																				IntPtr parent_Injected2 = Transform.GetParent_Injected((IntPtr)0);
																				Transform parent = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected2);
																				if ((object)transform5 == null)
																				{
																					break;
																				}
																				transform5.SetParent(parent, worldPositionStays: true);
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v168 (UnityEngine.GameObject)+10]");
																				bool flag11 = (nint)0 == 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v168 (UnityEngine.GameObject)+10]");
																				IntPtr gcHandlePtr6 = GameObject.get_transform_Injected((IntPtr)0);
																				Transform transform8 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr6);
																				if ((object)transform8 == null)
																				{
																					break;
																				}
																				_ = 0;
																				_ = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rax_v194 (UnityEngine.Transform)+10]");
																				bool flag12 = (nint)0 == 0;
																				object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj3, 57));
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rax_v194 (UnityEngine.Transform)+10]");
																				Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj11);
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-31]");
																				float num12 = 0f - -10f;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rax_v194 (UnityEngine.Transform)+10]");
																				bool flag13 = (nint)0 == 0;
																				object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj3, 41));
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rax_v194 (UnityEngine.Transform)+10]");
																				Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)obj12);
																				Rigidbody rigidbody = gameObject3.AddComponent<Rigidbody>();
																				bool flag14 = (object)rigidbody == null;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4064 @ rax_v204 (UnityEngine.Rigidbody)+10]");
																				bool flag15 = (nint)0 == 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4064 @ rax_v204 (UnityEngine.Rigidbody)+10]");
																				Rigidbody.set_isKinematic_Injected((IntPtr)0, true);
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4064 @ rax_v204 (UnityEngine.Rigidbody)+10]");
																				bool flag16 = (nint)0 == 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4064 @ rax_v204 (UnityEngine.Rigidbody)+10]");
																				Rigidbody.set_useGravity_Injected((IntPtr)0, false);
																				int value2 = LayerMask.NameToLayer("Player");
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v168 (UnityEngine.GameObject)+10]");
																				bool flag17 = (nint)0 == 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v168 (UnityEngine.GameObject)+10]");
																				GameObject.set_layer_Injected((IntPtr)0, value2);
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v168 (UnityEngine.GameObject)+10]");
																				bool flag18 = (nint)0 == 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v168 (UnityEngine.GameObject)+10]");
																				IntPtr gcHandlePtr7 = GameObject.get_transform_Injected((IntPtr)0);
																				Transform transform9 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr7);
																				bool flag19 = (object)transform9 == null;
																				_ = 500f;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4065 @ rax_v222 (UnityEngine.Transform)+10]");
																				bool flag20 = (nint)0 == 0;
																				object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj3, 25));
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4065 @ rax_v222 (UnityEngine.Transform)+10]");
																				Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj13);
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v168 (UnityEngine.GameObject)+10]");
																				bool flag21 = (nint)0 == 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v168 (UnityEngine.GameObject)+10]");
																				IntPtr gcHandlePtr8 = GameObject.get_transform_Injected((IntPtr)0);
																				Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr8);
																				nint num13 = (nint)typeof(Vector3);
																				Vector3 endValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj3, 57));
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4549 @ rcx_v204 (Il2CppClass<UnityEngine.Vector3>)+B8]");
																				nint num14 = 0;
																				_ = Vector3.zeroVector;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4551 @ rax_v233 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
																				_ = 0;
																				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOLocalMove(target, endValue, 0.01f);
																				Renderer component5 = gameObject3.GetComponent<Renderer>();
																				if ((object)component5 == null)
																				{
																					break;
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v236 (UnityEngine.Renderer)+10]");
																				bool flag22 = (nint)0 == 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v236 (UnityEngine.Renderer)+10]");
																				Renderer.set_enabled_Injected((IntPtr)0, false);
																				object runeContainer = _RuneContainer;
																				if ((object)_RuneContainer == null)
																				{
																					break;
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rbx_v50 (System.Object)+10]");
																				bool flag23 = (nint)0 == 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rbx_v50 (System.Object)+10]");
																				IntPtr gcHandlePtr9 = Component.get_gameObject_Injected((IntPtr)0);
																				GameObject gameObject4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr9);
																				if ((object)gameObject4 == null)
																				{
																					break;
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v245 (UnityEngine.GameObject)+10]");
																				bool flag24 = (nint)0 == 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v245 (UnityEngine.GameObject)+10]");
																				GameObject.SetActive_Injected((IntPtr)0, true);
																				EventSystem current = EventSystem.current;
																				if ((object)current == null || (object)current.m_CurrentSelected == null)
																				{
																					break;
																				}
																				SelectableUI component6 = current.m_CurrentSelected.GetComponent<SelectableUI>();
																				if ((object)component6 == null)
																				{
																					break;
																				}
																				SelectableUI.OnSetSelectorVisibility setSelectorVisibility = SelectableUI.SetSelectorVisibility;
																				if (SelectableUI.SetSelectorVisibility != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v4700.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
																				}
																				return;
																			}
																			bool flag25 = (nint)obj9 >= componentsInChildren2.Length;
																			object obj14 = componentsInChildren2[obj9];
																			if ((object)componentsInChildren2[obj9] == null)
																			{
																				break;
																			}
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rbx_v53 (System.Object)+10]");
																			bool flag26 = (nint)0 == 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rbx_v53 (System.Object)+10]");
																			IntPtr gcHandlePtr10 = Component.get_transform_Injected((IntPtr)0);
																			Transform transform10 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr10);
																			bool flag27;
																			if ((object)transform10 != null)
																			{
																				object obj15 = (object)transform10 - (object)child;
																				flag27 = obj15 == null;
																			}
																			else
																			{
																				flag27 = ((UnityEngine.Object)child).m_CachedPtr == (IntPtr)0;
																			}
																			if (!flag27)
																			{
																				componentsInChildren2[obj9].collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
																				componentsInChildren2[obj9].interpolation = RigidbodyInterpolation.Interpolate;
																				GameObject gameObject5 = componentsInChildren2[obj9].gameObject;
																				int layer = LayerMask.NameToLayer("Enemies");
																				if ((object)gameObject5 == null)
																				{
																					break;
																				}
																				gameObject5.layer = layer;
																				GameObject gameObject6 = componentsInChildren2[obj9].gameObject;
																				if ((object)gameObject6 == null)
																				{
																					break;
																				}
																				string text = ((UnityEngine.Object)gameObject6).GetName();
																				string message2 = "RB : " + text;
																				Debug.Log(message2);
																				SpriteRenderer component7 = componentsInChildren2[obj9].GetComponent<SpriteRenderer>();
																				TweenerCore<Color, Color, ColorOptions> tweenerCore5 = DOTweenModuleSprite.DOFade(component7, 0f, 2f);
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
																				TweenerCore<Color, Color, ColorOptions> tweenerCore6 = TweenSettingsExtensions.SetDelay(t, 0.4f);
																				Transform target2 = componentsInChildren2[obj9].transform;
																				TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOScale(target2, 0.4f, 2f);
																				TweenerCore<Color, Color, ColorOptions> tweenerCore7 = TweenSettingsExtensions.SetDelay((TweenerCore<Color, Color, ColorOptions>)(object)t2, 0.4f);
																				num10 = 0.4f;
																			}
																			obj9++;
																			obj10 = obj9;
																		}
																	}
																	break;
																}
																bool flag28 = (nint)obj6 >= componentsInChildren.Length;
																bool flag29;
																if ((object)componentsInChildren[obj6] != null)
																{
																	object obj16 = (object)componentsInChildren[obj6] - (object)child;
																	flag29 = obj16 == null;
																}
																else
																{
																	flag29 = ((UnityEngine.Object)child).m_CachedPtr == (IntPtr)0;
																}
																if (!flag29)
																{
																	if ((object)componentsInChildren[obj6] == null)
																	{
																		break;
																	}
																	GameObject gameObject7 = componentsInChildren[obj6].gameObject;
																	if ((object)gameObject7 == null)
																	{
																		break;
																	}
																	BoxCollider boxCollider = gameObject7.AddComponent<BoxCollider>();
																	if ((object)boxCollider == null)
																	{
																		break;
																	}
																	GameObject gameObject8 = boxCollider.gameObject;
																	if ((object)gameObject8 == null)
																	{
																		break;
																	}
																	Rigidbody rigidbody2 = gameObject8.AddComponent<Rigidbody>();
																	if ((object)rigidbody2 == null)
																	{
																		break;
																	}
																	rigidbody2.useGravity = false;
																	Vector3 position = componentsInChildren[obj6].position;
																	_ = position.x;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-31]");
																	num10 = 0f + position.z;
																	obj5++;
																	num9 = num10;
																}
																obj6++;
																obj7 = obj6;
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
				}
			}
			throw new NullReferenceException();
		};
		object message;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback2 != null)
					{
						Sequence sequence3 = Sequence.DoInsertCallback(sequence, tweenCallback2, ((Tween)sequence).duration);
					}
					goto IL_032e;
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
		goto IL_032e;
		IL_032e:
		PlayRunes();
	}

	public unsafe void PlayRunes()
	{
		//IL_0037: Expected O, but got I4
		//IL_004d: Expected F4, but got I4
		//IL_0187: Expected O, but got I4
		//IL_013a: Invalid comparison between O and F4
		//IL_0411: Invalid comparison between O and F4
		//IL_0291->IL0218: Incompatible stack heights: 1 vs 0
		//IL_0452->IL0218: Incompatible stack heights: 1 vs 0
		//IL_0087->IL0218: Incompatible stack heights: 2 vs 0
		//IL_0331->IL0218: Incompatible stack heights: 3 vs 0
		//IL_00be->IL0218: Incompatible stack heights: 3 vs 0
		//IL_038b->IL0218: Incompatible stack heights: 4 vs 0
		//IL_03d4->IL0218: Incompatible stack heights: 4 vs 0
		//IL_0429->IL042e: Incompatible stack heights: 5 vs 1
		//IL_01c3->IL0218: Incompatible stack heights: 5 vs 0
		//IL_01ef->IL0218: Incompatible stack heights: 5 vs 0
		RectTransform component = GetComponent<RectTransform>();
		if ((object)component != null)
		{
			bool flag = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
			RectTransform.get_rect_Injected(((UnityEngine.Object)component).m_CachedPtr, out Rect _);
			if ((object)_GeneratedTexture != null)
			{
				int height = _GeneratedTexture.height;
				object obj = height + height;
				object obj3 = default(object);
				object obj2 = obj3 / obj;
				float num = 0f;
				Rect value = default(Rect);
				Rect rect = default(Rect);
				object obj4 = default(object);
				while (true)
				{
					GameObject runePatternImage = (GameObject)(object)_RunePatternImage;
					if ((object)_RunePatternImage == null)
					{
						break;
					}
					bool flag2 = ((UnityEngine.Object)runePatternImage).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)runePatternImage).m_CachedPtr);
					GameObject original = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
					GameObject gameObject = UnityEngine.Object.Instantiate(original, _RuneContainer);
					if ((object)gameObject == null)
					{
						break;
					}
					bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, true);
					RectTransform component2 = gameObject.GetComponent<RectTransform>();
					if ((object)_GeneratedTexture == null)
					{
						break;
					}
					int width = _GeneratedTexture.width;
					if ((object)component2 == null)
					{
						break;
					}
					bool flag4 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
					RectTransform.set_sizeDelta_Injected(((UnityEngine.Object)component2).m_CachedPtr, ref *(Vector2*)(&value));
					RawImage component3 = gameObject.GetComponent<RawImage>();
					if ((object)component3 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186D87BAEh\"");
					if ((object)component3.m_UVRect == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186D87BAEh\"");
						if ((object)rect == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186D87BAEh\"");
							if ((object)rect == (object)1f)
							{
								bool flag5 = (object)rect == obj2;
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186D87BAEh\"");
								if (flag5)
								{
									goto IL_0390;
								}
							}
						}
					}
					component3.m_UVRect = (Rect)0;
					component3.SetVerticesDirty();
					goto IL_0390;
					IL_0390:
					component3.texture = _GeneratedTexture;
					num += 50f;
					RuneStripUI component4 = gameObject.GetComponent<RuneStripUI>();
					if ((object)component4 == null)
					{
						break;
					}
					component4.Initialize();
					bool flag6 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
					RectTransform.get_rect_Injected(((UnityEngine.Object)component).m_CachedPtr, out Rect _);
					bool flag7 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num);
					obj = obj4;
					if (!flag7)
					{
						if ((object)_RuneContainer == null)
						{
							break;
						}
						GameObject gameObject2 = _RuneContainer.gameObject;
						if ((object)gameObject2 == null)
						{
							break;
						}
						gameObject2.SetActive(value: false);
						VampireSurvivors.App.Tools.Extensions.RefreshLayoutGroupsImmediateAndRecursive(_RuneContainer);
						Canvas.ForceUpdateCanvases();
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void CreateRuneTexture()
	{
		//IL_0024: Expected O, but got Ref
		//IL_015c: Expected O, but got I4
		//IL_0165: Expected F4, but got I4
		//IL_0729: Expected O, but got I4
		//IL_073f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0744: Expected I4, but got Unknown
		//IL_0236: Expected I4, but got O
		//IL_028b: Expected F8, but got I4
		//IL_038d: Expected O, but got I4
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Expected O, but got Unknown
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Expected O, but got Unknown
		//IL_031e: Expected F8, but got I4
		//IL_03d3: Expected I4, but got O
		//IL_0667: Expected O, but got I
		//IL_04aa: Expected I4, but got O
		//IL_054a: Expected I4, but got O
		//IL_0a4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a51: Expected O, but got Unknown
		//IL_0576: Expected O, but got I
		//IL_0590: Expected O, but got I
		//IL_05b3: Expected O, but got Ref
		//IL_05de: Invalid comparison between F8 and I4
		//IL_0a90: Expected O, but got I4
		//IL_0a90: Expected O, but got I
		//IL_0a99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9e: Expected O, but got Unknown
		//IL_0603: Expected I4, but got F8
		//IL_07a5->IL0668: Incompatible stack heights: 1 vs 0
		//IL_02a3->IL0668: Incompatible stack heights: 1 vs 0
		//IL_0345->IL0668: Incompatible stack heights: 1 vs 0
		//IL_032b->IL02a8: Incompatible stack heights: 2 vs 1
		//IL_0638->IL0668: Incompatible stack heights: 1 vs 0
		//IL_03f0->IL0668: Incompatible stack heights: 2 vs 0
		//IL_0448->IL0668: Incompatible stack heights: 3 vs 0
		//IL_0b28->IL0668: Incompatible stack heights: 2 vs 0
		//IL_0805->IL0668: Incompatible stack heights: 4 vs 0
		//IL_0858->IL0668: Incompatible stack heights: 5 vs 0
		//IL_08bd->IL0668: Incompatible stack heights: 7 vs 0
		//IL_0910->IL0668: Incompatible stack heights: 8 vs 0
		//IL_09fe->IL0668: Incompatible stack heights: 14 vs 0
		//IL_05bc->IL0668: Incompatible stack heights: 15 vs 0
		//IL_0aad->IL0aad: Incompatible stack heights: 15 vs 1
		List<Sprite> list = new List<Sprite>();
		int num = 0;
		int num2 = 0;
		Rect ret = default(Rect);
		List<Sprite>.Enumerator enumerator = default(List<Sprite>.Enumerator);
		int num4 = default(int);
		bool flag4 = default(bool);
		IntPtr intPtr = default(IntPtr);
		bool createUninitialized = default(bool);
		int height = default(int);
		object obj12 = default(object);
		while (true)
		{
			string text = System.Number.FormatInt32(num2, (ReadOnlySpan<char>)(&ret), null);
			string spriteName = "runeFont-export_" + text;
			Sprite sprite = SpriteManager.GetSprite(spriteName, "runeFont-export 1");
			bool flag2;
			object typeFromHandle;
			if ((object)sprite != null)
			{
				bool flag = ((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0;
				flag2 = true;
				typeFromHandle = typeof(UnityEngine.Object);
				if (flag)
				{
					goto IL_00eb;
				}
			}
			string text2 = num.ToString();
			string message = "MISSING RUNE : " + text2;
			Debug.LogError(message);
			flag2 = false;
			goto IL_00eb;
			IL_00eb:
			if (list == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
			num2++;
			bool flag3 = num2 < 24;
			num = num2;
			if (flag3)
			{
				continue;
			}
			List<Sprite> list2 = list;
			object obj = 25;
			float num3 = 0f;
			if (enumerator.MoveNext())
			{
				Sprite sprite2 = null;
				Debug.LogError("NULL SPRITE");
				typeFromHandle = "NULL SPRITE";
				throw new NullReferenceException();
			}
			Texture2D generatedTexture = new Texture2D(25, height, TextureFormat.ARGB4444, num4, flag4, intPtr, createUninitialized, (MipmapLimitDescriptor)1);
			height = list._size * obj;
			_GeneratedTexture = generatedTexture;
			int num5 = (int)_GeneratedTexture;
			if ((object)_GeneratedTexture == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rbx_v29 (System.Int32)+10]");
			bool flag5 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rbx_v29 (System.Int32)+10]");
			Texture.set_wrapMode_Injected((IntPtr)0, TextureWrapMode.Repeat);
			if ((object)_GeneratedTexture == null)
			{
				break;
			}
			Color[] pixels = _GeneratedTexture.GetPixels();
			bool flag6 = pixels == null;
			double num6 = 0.0;
			object obj2 = null;
			object obj3 = null;
			typeFromHandle = null;
			if (flag6)
			{
				break;
			}
			while ((nint)obj3 < pixels.Length)
			{
				bool flag7 = (nint)obj2 >= pixels.Length;
				object obj4 = obj2 + 2;
				object obj5 = obj4 + obj4;
				_ = 0;
				obj2++;
				num6 = 0.0;
				obj3 = obj2;
			}
			if ((object)_GeneratedTexture == null)
			{
				break;
			}
			int width = _GeneratedTexture.width;
			int height2 = _GeneratedTexture.height;
			_GeneratedTexture.SetPixels(0, 0, width, num4, (Color[])flag4, (int)(nint)intPtr);
			int num7 = 0;
			object obj6 = null;
			object obj7 = null;
			while (true)
			{
				if ((nint)obj7 < list._size)
				{
					bool flag8 = (nint)obj6 >= list._size;
					int num8 = (int)list._items;
					if (list._items == null)
					{
						break;
					}
					object obj8 = obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rbx_v34 (System.Int32)+18]");
					bool flag9 = (nint)obj8 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rbx_v34 (System.Int32)+20+v709 @ r15_v27 (System.Object)*8]");
					int num9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rbx_v34 (System.Int32)+20+v709 @ r15_v27 (System.Object)*8]");
					if ((nint)0 == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rbx_v35 (System.Int32)+10]");
					bool flag10 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rbx_v35 (System.Int32)+10]");
					IntPtr gcHandlePtr = Sprite.get_texture_Injected((IntPtr)0);
					Texture2D texture2D = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Texture2D>(gcHandlePtr);
					if ((object)texture2D == null)
					{
						break;
					}
					int width2 = texture2D.width;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rbx_v35 (System.Int32)+10]");
					bool flag11 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rbx_v35 (System.Int32)+10]");
					object obj9 = Sprite.get_uv_Injected((IntPtr)0);
					if (obj9 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v720 @ rax_v127+18]");
					bool flag12 = (nint)0 <= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rbx_v35 (System.Int32)+10]");
					bool flag13 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rbx_v35 (System.Int32)+10]");
					IntPtr gcHandlePtr2 = Sprite.get_texture_Injected((IntPtr)0);
					Texture2D texture2D2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Texture2D>(gcHandlePtr2);
					if ((object)texture2D2 == null)
					{
						break;
					}
					int num10 = (int)texture2D2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v487 @ r8_v39 (System.Int32)+1A8] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rbx_v35 (System.Int32)+10]");
					bool flag14 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rbx_v35 (System.Int32)+10]");
					object obj10 = Sprite.get_uv_Injected((IntPtr)0);
					if (obj10 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v721 @ rax_v139+18]");
					bool flag15 = (nint)0 <= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rbx_v35 (System.Int32)+10]");
					bool flag16 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rbx_v35 (System.Int32)+10]");
					IntPtr gcHandlePtr3 = Sprite.get_texture_Injected((IntPtr)0);
					Texture2D texture2D3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Texture2D>(gcHandlePtr3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rbx_v35 (System.Int32)+10]");
					bool flag17 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rbx_v35 (System.Int32)+10]");
					Sprite.get_rect_Injected((IntPtr)0, out Rect _);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rbx_v35 (System.Int32)+10]");
					bool flag18 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rbx_v35 (System.Int32)+10]");
					Sprite.get_rect_Injected((IntPtr)0, out Rect _);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rbx_v35 (System.Int32)+10]");
					bool flag19 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rbx_v35 (System.Int32)+10]");
					Sprite.get_rect_Injected((IntPtr)0, out Rect _);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rbx_v35 (System.Int32)+10]");
					bool flag20 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rbx_v35 (System.Int32)+10]");
					Sprite.get_rect_Injected((IntPtr)0, out Rect ret5);
					if ((object)texture2D3 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rsp+7Ch]\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r9d,dword ptr [rsp+0A0h]\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,dword ptr [rsp+0D4h]\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,dword ptr [rsp+0C0h]\"");
					Color[] pixels2 = texture2D3.GetPixels((int)(&ret5), (int)texture2D2, width, num4, flag4 ? 1 : 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rbx_v35 (System.Int32)+10]");
					bool flag21 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rbx_v35 (System.Int32)+10]");
					Sprite.get_rect_Injected((IntPtr)0, out ret);
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rsp+68h]\"");
					object obj11 = 25 - obj12;
					float num11 = (float)obj11 * 0.5f;
					num6 = Math.Ceiling(num11);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rbx_v34 (System.Int32)+20+v709 @ r15_v27 (System.Object)*8]");
					Rect rect = ((Sprite)0).rect;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rbx_v34 (System.Int32)+20+v709 @ r15_v27 (System.Object)*8]");
					Rect rect2 = ((Sprite)0).rect;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2119 @ stack_8+1B8]");
					bool flag22 = (nint)0 == 0;
					typeFromHandle = (object)(&list2);
					if (flag22)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0Ch]\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r9d,xmm6\"");
					bool flag23 = num6 < 0.0;
					num7 = 0;
					if (!flag23)
					{
						num7 = (int)num6;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2119 @ stack_8+1B8]");
					((Texture2D)0).SetPixels(num7, 0, width, num4, (Color[])flag4, (int)(nint)intPtr);
					obj6++;
					obj7 = obj6;
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2119 @ stack_8+1B8]");
				int num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2119 @ stack_8+1B8]");
				if ((nint)0 == 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ rbx_v32 (System.Int32)+10]");
				bool flag24 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ rbx_v32 (System.Int32)+10]");
				Texture.set_filterMode_Injected((IntPtr)0, FilterMode.Point);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2119 @ stack_8+1B8]");
				if ((nint)0 == 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2119 @ stack_8+1B8]");
				((Texture2D)0).Apply(updateMipmaps: true, makeNoLongerReadable: false);
				return;
			}
			break;
		}
		throw new NullReferenceException();
	}

	protected unsafe override void OnShowStart(GameObject g)
	{
		//IL_1244: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_1298: Expected O, but got I
		//IL_0196: Expected O, but got I
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		//IL_01d0: Expected O, but got I4
		//IL_0276: Expected O, but got I
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_036f: Expected O, but got I
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Expected O, but got Unknown
		//IL_041d: Expected O, but got I
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_0435: Expected O, but got Unknown
		//IL_04cb: Expected O, but got I
		//IL_04de: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e3: Expected O, but got Unknown
		//IL_13ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d3: Expected O, but got Unknown
		//IL_13db: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e0: Expected O, but got Unknown
		//IL_13ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f2: Expected O, but got Unknown
		//IL_064e: Expected O, but got I4
		//IL_05a2: Expected O, but got Ref
		//IL_0934: Expected O, but got I
		//IL_074e: Expected O, but got I4
		//IL_0845: Expected O, but got I4
		//IL_06a2: Expected O, but got Ref
		//IL_091f: Expected O, but got I
		//IL_0799: Expected O, but got Ref
		//IL_05eb: Expected O, but got I
		//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f9: Expected O, but got Unknown
		//IL_061d: Expected O, but got I
		//IL_08e5: Expected O, but got I
		//IL_0a22: Expected O, but got I
		//IL_08ad: Expected O, but got I
		//IL_06eb: Expected O, but got I
		//IL_06f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f9: Expected O, but got Unknown
		//IL_071d: Expected O, but got I
		//IL_07e2: Expected O, but got I
		//IL_07eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f0: Expected O, but got Unknown
		//IL_0814: Expected O, but got I
		//IL_0a0d: Expected O, but got I
		//IL_0a77: Expected O, but got I4
		//IL_09d3: Expected O, but got I
		//IL_099b: Expected O, but got I
		//IL_0ec5: Expected O, but got I
		//IL_0ba2: Expected O, but got I
		//IL_0eb0: Expected O, but got I
		//IL_1883: Expected O, but got I
		//IL_0b8d: Expected O, but got I
		//IL_0fa3: Expected O, but got I
		//IL_0e4e: Expected O, but got I
		//IL_0bc7: Expected O, but got I4
		//IL_0b53: Expected O, but got I
		//IL_0b11: Expected O, but got I
		//IL_0f8e: Expected O, but got I
		//IL_0be6: Expected O, but got I
		//IL_0bfc: Expected O, but got I
		//IL_0c18: Expected O, but got I4
		//IL_1093: Expected O, but got I
		//IL_0f2c: Expected O, but got I
		//IL_107e: Expected O, but got I
		//IL_0d39: Expected O, but got I
		//IL_1044: Expected O, but got I
		//IL_1651: Expected O, but got I
		//IL_1183: Expected O, but got I
		//IL_100a: Expected O, but got I
		//IL_0d24: Expected O, but got I
		//IL_116e: Expected O, but got I
		//IL_0dde: Expected O, but got I4
		//IL_0cea: Expected O, but got I
		//IL_0d7c: Expected O, but got I
		//IL_0d96: Expected I4, but got I8
		//IL_0d96: Expected O, but got I
		//IL_0db6: Expected O, but got I4
		//IL_0dc6: Expected O, but got I
		//IL_0cb2: Expected O, but got I
		//IL_1134: Expected O, but got I
		//IL_10fa: Expected O, but got I
		base.OnShowStart(g);
		DataManager data = _data;
		bool flag7;
		bool flag9;
		bool flag11;
		Dictionary<SecretType, SecretData> dictionary;
		if (_data != null)
		{
			_secrets = data._003CAllSecrets_003Ek__BackingField;
			if (_data != null)
			{
				Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _data.GetConvertedCharacterData();
				_characterData = convertedCharacterData;
				if (_playerOptions != null)
				{
					PlayerOptionsData config = _playerOptions.Config;
					if (config != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rax_v19 (VampireSurvivors.Data.PlayerOptionsData)+188]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rax_v19 (VampireSurvivors.Data.PlayerOptionsData)+188]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rcx_v17+18]");
							bool flag;
							if ((nint)0 == 0)
							{
								flag = false;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rcx_v17+18]");
								dictionary = (Dictionary<SecretType, SecretData>)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
								object obj3 = default(object);
								object obj2 = obj3 - -1;
								bool flag2 = obj2 == null;
								flag = !flag2;
							}
							if (_playerOptions != null)
							{
								PlayerOptionsData config2 = _playerOptions.Config;
								if (config2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rax_v22 (VampireSurvivors.Data.PlayerOptionsData)+188]");
									object obj4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rax_v22 (VampireSurvivors.Data.PlayerOptionsData)+188]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rcx_v21+18]");
										GameObject gameObject;
										if ((nint)0 == 0)
										{
											gameObject = null;
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rcx_v21+18]");
											dictionary = (Dictionary<SecretType, SecretData>)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
											object obj6 = default(object);
											object obj5 = obj6 - -1;
											bool flag3 = obj5 == null;
											bool flag4 = !flag3;
											gameObject = (GameObject)flag4;
										}
										if (_playerOptions != null)
										{
											PlayerOptionsData config3 = _playerOptions.Config;
											if (config3 != null)
											{
												List<WeaponType> list = config3._003CUnlockedWeapons_003Ek__BackingField;
												if (config3._003CUnlockedWeapons_003Ek__BackingField != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rcx_v24 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
													bool flag5;
													if ((nint)0 == 0)
													{
														flag5 = false;
													}
													else
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rcx_v24 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
														dictionary = (Dictionary<SecretType, SecretData>)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
														object obj8 = default(object);
														object obj7 = obj8 - -1;
														bool flag6 = obj7 == null;
														flag5 = !flag6;
													}
													if (_playerOptions != null)
													{
														PlayerOptionsData config4 = _playerOptions.Config;
														if (config4 != null && _playerOptions != null)
														{
															PlayerOptionsData config5 = _playerOptions.Config;
															if (config5 != null)
															{
																List<ItemType> list2 = config5._003CCollectedItems_003Ek__BackingField;
																if (config5._003CCollectedItems_003Ek__BackingField != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
																	if ((nint)0 == 0)
																	{
																		flag7 = false;
																	}
																	else
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
																		dictionary = (Dictionary<SecretType, SecretData>)0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
																		object obj10 = default(object);
																		object obj9 = obj10 - -1;
																		bool flag8 = obj9 == null;
																		flag7 = !flag8;
																	}
																	if (_playerOptions != null)
																	{
																		PlayerOptionsData config6 = _playerOptions.Config;
																		if (config6 != null)
																		{
																			List<ItemType> list3 = config6._003CCollectedItems_003Ek__BackingField;
																			if (config6._003CCollectedItems_003Ek__BackingField != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rcx_v33 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
																				if ((nint)0 == 0)
																				{
																					flag9 = false;
																				}
																				else
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rcx_v33 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
																					dictionary = (Dictionary<SecretType, SecretData>)0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
																					object obj12 = default(object);
																					object obj11 = obj12 - -1;
																					bool flag10 = obj11 == null;
																					flag9 = !flag10;
																				}
																				if (_playerOptions != null)
																				{
																					PlayerOptionsData config7 = _playerOptions.Config;
																					if (config7 != null)
																					{
																						List<ItemType> list4 = config7._003CCollectedItems_003Ek__BackingField;
																						if (config7._003CCollectedItems_003Ek__BackingField != null)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ rcx_v37 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
																							if ((nint)0 == 0)
																							{
																								flag11 = false;
																							}
																							else
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ rcx_v37 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
																								dictionary = (Dictionary<SecretType, SecretData>)0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
																								object obj14 = default(object);
																								object obj13 = obj14 - -1;
																								bool flag12 = obj13 == null;
																								flag11 = !flag12;
																							}
																							object obj15 = gameObject & flag;
																							GameObject gameObject2 = (GameObject)(obj15 & flag5);
																							object obj16 = config4._003CHasSeenFinalFireworks_003Ek__BackingField & gameObject2;
																							if (obj16 == null)
																							{
																								goto IL_185a;
																							}
																							if (_secrets != null)
																							{
																								object obj17 = ((Dictionary<System.Int32Enum, object>)(object)_secrets).get_Item((System.Int32Enum)89);
																								if (obj17 != null)
																								{
																									_ = 0;
																									goto IL_185a;
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
		}
		goto IL_122d;
		IL_1641:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rax_v124+170]");
		object obj18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rax_v124+170]");
		if ((nint)0 == 0)
		{
			goto IL_122d;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ rcx_v106+18]");
		bool flag13 = (nint)0 == 0;
		Dictionary<SecretType, SecretData> dictionary2 = dictionary;
		object obj19;
		if (!flag13)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ rcx_v106+18]");
			dictionary2 = (Dictionary<SecretType, SecretData>)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ rcx_v106+10]");
			int num = ((Dictionary<DlcType, BundleManifestData>)0).FindEntry((DlcType)(-1));
			bool flag14 = num != -1;
			obj19 = 20;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ rcx_v106+18]");
			dictionary = (Dictionary<SecretType, SecretData>)0;
			if (flag14)
			{
				goto IL_15c3;
			}
		}
		obj19 = 1172;
		dictionary = dictionary2;
		goto IL_15c3;
		IL_16f4:
		PlaySoundTrack();
		GameObject playerOptions = (GameObject)(object)_playerOptions;
		if (_playerOptions == null)
		{
			goto IL_122d;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v901 @ rdi_v19 (UnityEngine.GameObject)+68]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v901 @ rdi_v19 (UnityEngine.GameObject)+58]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v901 @ rdi_v19 (UnityEngine.GameObject)+78]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v901 @ rdi_v19 (UnityEngine.GameObject)+78]");
					object obj20 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2938 @ rax_v101+2CC]");
					if ((nint)0 != 0)
					{
						goto IL_1750;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v901 @ rdi_v19 (UnityEngine.GameObject)+50]");
				object obj21 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v901 @ rdi_v19 (UnityEngine.GameObject)+50]");
				if ((nint)0 == 0)
				{
					goto IL_122d;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v901 @ rdi_v19 (UnityEngine.GameObject)+58]");
				object obj21 = 0;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v901 @ rdi_v19 (UnityEngine.GameObject)+68]");
			object obj21 = 0;
		}
		goto IL_1750;
		IL_1873:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v897 @ rdi_v25 (UnityEngine.GameObject)+188]");
		object obj22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v897 @ rdi_v25 (UnityEngine.GameObject)+188]");
		if ((nint)0 == 0)
		{
			goto IL_122d;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rcx_v103+18]");
		bool flag15 = (nint)0 == 0;
		obj19 = 20;
		if (!flag15)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rcx_v103+18]");
			dictionary = (Dictionary<SecretType, SecretData>)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rcx_v103+10]");
			int num2 = ((Dictionary<DlcType, BundleManifestData>)0).FindEntry((DlcType)211);
			bool flag16 = num2 == -1;
			obj19 = 20;
			if (!flag16)
			{
				GameObject playerOptions2 = (GameObject)(object)_playerOptions;
				if (_playerOptions == null)
				{
					goto IL_122d;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ rdi_v26 (UnityEngine.GameObject)+68]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ rdi_v26 (UnityEngine.GameObject)+58]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ rdi_v26 (UnityEngine.GameObject)+78]");
						object obj23;
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ rdi_v26 (UnityEngine.GameObject)+78]");
							obj23 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rax_v124+2CC]");
							if ((nint)0 != 0)
							{
								goto IL_1641;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ rdi_v26 (UnityEngine.GameObject)+50]");
						obj23 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ rdi_v26 (UnityEngine.GameObject)+50]");
						if ((nint)0 == 0)
						{
							goto IL_122d;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ rdi_v26 (UnityEngine.GameObject)+58]");
						object obj23 = 0;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ rdi_v26 (UnityEngine.GameObject)+68]");
					object obj23 = 0;
				}
				goto IL_1641;
			}
		}
		goto IL_15c3;
		IL_15c3:
		GameObject playerOptions3 = (GameObject)(object)_playerOptions;
		if (_playerOptions == null)
		{
			goto IL_122d;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v899 @ rdi_v17 (UnityEngine.GameObject)+68]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v899 @ rdi_v17 (UnityEngine.GameObject)+58]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v899 @ rdi_v17 (UnityEngine.GameObject)+78]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v899 @ rdi_v17 (UnityEngine.GameObject)+78]");
					object obj24 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rax_v59+2CC]");
					if ((nint)0 != 0)
					{
						goto IL_169e;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v899 @ rdi_v17 (UnityEngine.GameObject)+50]");
				if ((nint)0 == 0)
				{
					goto IL_122d;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v899 @ rdi_v17 (UnityEngine.GameObject)+58]");
				object obj24 = 0;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v899 @ rdi_v17 (UnityEngine.GameObject)+68]");
			object obj24 = 0;
		}
		goto IL_169e;
		IL_15ac:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2419 @ rax_v52+6C]");
		_previousBGMMod = BgmModType.Normal;
		Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
		if (loadedDlc != null)
		{
			int num3 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc).FindEntry((System.Int32Enum)5);
			bool flag17 = num3 < 0;
			obj19 = 20;
			if (flag17)
			{
				goto IL_15c3;
			}
			GameObject playerOptions4 = (GameObject)(object)_playerOptions;
			if (_playerOptions != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v895 @ rdi_v24 (UnityEngine.GameObject)+68]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v895 @ rdi_v24 (UnityEngine.GameObject)+58]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v895 @ rdi_v24 (UnityEngine.GameObject)+78]");
						GameObject gameObject4;
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v895 @ rdi_v24 (UnityEngine.GameObject)+78]");
							GameObject gameObject3 = (GameObject)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2634 @ rax_v139 (UnityEngine.GameObject)+2CC]");
							if ((nint)0 != 0)
							{
								gameObject4 = gameObject3;
								goto IL_1873;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v895 @ rdi_v24 (UnityEngine.GameObject)+50]");
						gameObject4 = (GameObject)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v895 @ rdi_v24 (UnityEngine.GameObject)+50]");
						if ((nint)0 == 0)
						{
							goto IL_122d;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v895 @ rdi_v24 (UnityEngine.GameObject)+58]");
						GameObject gameObject4 = (GameObject)0;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v895 @ rdi_v24 (UnityEngine.GameObject)+68]");
					GameObject gameObject4 = (GameObject)0;
				}
				goto IL_1873;
			}
		}
		goto IL_122d;
		IL_169e:
		GameObject playerOptions5 = (GameObject)(object)_playerOptions;
		if (_playerOptions == null)
		{
			goto IL_122d;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v900 @ rdi_v18 (UnityEngine.GameObject)+68]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v900 @ rdi_v18 (UnityEngine.GameObject)+58]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v900 @ rdi_v18 (UnityEngine.GameObject)+78]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v900 @ rdi_v18 (UnityEngine.GameObject)+78]");
					object obj25 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2781 @ rax_v61+2CC]");
					if ((nint)0 != 0)
					{
						goto IL_16f4;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v900 @ rdi_v18 (UnityEngine.GameObject)+50]");
				if ((nint)0 == 0)
				{
					goto IL_122d;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v900 @ rdi_v18 (UnityEngine.GameObject)+58]");
				object obj25 = 0;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v900 @ rdi_v18 (UnityEngine.GameObject)+68]");
			object obj25 = 0;
		}
		goto IL_16f4;
		IL_17a8:
		_ = _previousBGMMod;
		Populate();
		StartRuneParticles();
		StartInputParticles();
		NavigationWrap();
		GameObject unlockPopup = (GameObject)(object)_UnlockPopup;
		int num4;
		if ((object)_UnlockPopup != null)
		{
			if (((UnityEngine.Object)unlockPopup).m_CachedPtr == (IntPtr)0)
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_UnlockPopup);
				Dictionary<SecretType, SecretData>.Enumerator unlockPopup2 = (Dictionary<SecretType, SecretData>.Enumerator)_UnlockPopup;
				goto IL_141e;
			}
			IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)unlockPopup).m_CachedPtr);
			GameObject gameObject5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
			if ((object)gameObject5 != null)
			{
				bool flag18 = ((UnityEngine.Object)gameObject5).m_CachedPtr == (IntPtr)0;
				GameObject.SetActive_Injected(((UnityEngine.Object)gameObject5).m_CachedPtr, false);
				_003CWaitAndSelect_003Ed__73 obj26 = null;
				obj26._003C_003E1__state = num4;
				obj26._003C_003E4__this = this;
				Coroutine coroutine = StartCoroutine(obj26);
				return;
			}
		}
		goto IL_122d;
		IL_1549:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2317 @ rax_v49+68]");
		_previousBGM = BgmType.BGM_Forest;
		GameObject playerOptions6 = (GameObject)(object)_playerOptions;
		if (_playerOptions == null)
		{
			goto IL_122d;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v894 @ rdi_v15 (UnityEngine.GameObject)+68]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v894 @ rdi_v15 (UnityEngine.GameObject)+58]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v894 @ rdi_v15 (UnityEngine.GameObject)+78]");
				object obj27;
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v894 @ rdi_v15 (UnityEngine.GameObject)+78]");
					obj27 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2419 @ rax_v52+2CC]");
					if ((nint)0 != 0)
					{
						goto IL_15ac;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v894 @ rdi_v15 (UnityEngine.GameObject)+50]");
				obj27 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v894 @ rdi_v15 (UnityEngine.GameObject)+50]");
				if ((nint)0 == 0)
				{
					goto IL_122d;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v894 @ rdi_v15 (UnityEngine.GameObject)+58]");
				object obj27 = 0;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v894 @ rdi_v15 (UnityEngine.GameObject)+68]");
			object obj27 = 0;
		}
		goto IL_15ac;
		IL_122d:
		throw new NullReferenceException();
		IL_185a:
		object obj28 = default(object);
		if (flag7)
		{
			dictionary = _secrets;
			if (_secrets == null)
			{
				goto IL_122d;
			}
			Dictionary<SecretType, SecretData>.Enumerator enumerator = default(Dictionary<SecretType, SecretData>.Enumerator);
			while (enumerator.MoveNext())
			{
				bool flag19 = obj28 == null;
				Dictionary<SecretType, SecretData>.Enumerator unlockPopup2 = (Dictionary<SecretType, SecretData>.Enumerator)(&enumerator);
				if (!flag19)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1984 @ stack_-60+88]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1984 @ stack_-60+88]");
						object obj29 = (nint)0 >> 32;
						object obj30 = obj29 - 211;
						bool flag20 = obj30 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1984 @ stack_-60+88]");
						object obj31 = (nint)0 & (nint)(flag20 ? 1 : 0);
						if (obj31 != null)
						{
							_ = 0;
						}
					}
					continue;
				}
				goto IL_141e;
			}
			object obj32 = 0;
			num4 = 0;
		}
		else
		{
			num4 = 0;
		}
		if (flag9)
		{
			dictionary = _secrets;
			if (_secrets == null)
			{
				goto IL_122d;
			}
			Dictionary<SecretType, SecretData>.Enumerator enumerator2 = default(Dictionary<SecretType, SecretData>.Enumerator);
			while (enumerator2.MoveNext())
			{
				bool flag21 = obj28 == null;
				Dictionary<SecretType, SecretData>.Enumerator enumerator3 = (Dictionary<SecretType, SecretData>.Enumerator)(&enumerator2);
				if (!flag21)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1984 @ stack_-60+88]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1984 @ stack_-60+88]");
						object obj33 = (nint)0 >> 32;
						object obj34 = obj33 - 230;
						bool flag22 = obj34 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1984 @ stack_-60+88]");
						object obj35 = (nint)0 & (nint)(flag22 ? 1 : 0);
						if (obj35 != null)
						{
							_ = 0;
						}
					}
					continue;
				}
				throw new NullReferenceException();
			}
			object obj32 = 0;
		}
		if (flag11)
		{
			dictionary = _secrets;
			if (_secrets == null)
			{
				goto IL_122d;
			}
			Dictionary<SecretType, SecretData>.Enumerator enumerator4 = default(Dictionary<SecretType, SecretData>.Enumerator);
			while (enumerator4.MoveNext())
			{
				bool flag23 = obj28 == null;
				Dictionary<SecretType, SecretData>.Enumerator enumerator5 = (Dictionary<SecretType, SecretData>.Enumerator)(&enumerator4);
				if (!flag23)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1984 @ stack_-60+88]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1984 @ stack_-60+88]");
						object obj36 = (nint)0 >> 32;
						object obj37 = obj36 - 100;
						bool flag24 = obj37 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1984 @ stack_-60+88]");
						object obj38 = (nint)0 & (nint)(flag24 ? 1 : 0);
						if (obj38 != null)
						{
							_ = 0;
						}
					}
					continue;
				}
				throw new NullReferenceException();
			}
			object obj32 = 0;
		}
		ClearSpell();
		GameObject playerOptions7 = (GameObject)(object)_playerOptions;
		if (_playerOptions == null)
		{
			goto IL_122d;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v893 @ rdi_v14 (UnityEngine.GameObject)+68]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v893 @ rdi_v14 (UnityEngine.GameObject)+58]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v893 @ rdi_v14 (UnityEngine.GameObject)+78]");
				object obj39;
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v893 @ rdi_v14 (UnityEngine.GameObject)+78]");
					obj39 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2317 @ rax_v49+2CC]");
					if ((nint)0 != 0)
					{
						goto IL_1549;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v893 @ rdi_v14 (UnityEngine.GameObject)+50]");
				obj39 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v893 @ rdi_v14 (UnityEngine.GameObject)+50]");
				if ((nint)0 == 0)
				{
					goto IL_122d;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v893 @ rdi_v14 (UnityEngine.GameObject)+58]");
				object obj39 = 0;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v893 @ rdi_v14 (UnityEngine.GameObject)+68]");
			object obj39 = 0;
		}
		goto IL_1549;
		IL_1750:
		_ = _previousBGM;
		GameObject playerOptions8 = (GameObject)(object)_playerOptions;
		if (_playerOptions == null)
		{
			goto IL_122d;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v902 @ rdi_v20 (UnityEngine.GameObject)+68]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v902 @ rdi_v20 (UnityEngine.GameObject)+58]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v902 @ rdi_v20 (UnityEngine.GameObject)+78]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v902 @ rdi_v20 (UnityEngine.GameObject)+78]");
					object obj40 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3048 @ rax_v98+2CC]");
					if ((nint)0 != 0)
					{
						goto IL_17a8;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v902 @ rdi_v20 (UnityEngine.GameObject)+50]");
				object obj41 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v902 @ rdi_v20 (UnityEngine.GameObject)+50]");
				if ((nint)0 == 0)
				{
					goto IL_122d;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v902 @ rdi_v20 (UnityEngine.GameObject)+58]");
				object obj41 = 0;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v902 @ rdi_v20 (UnityEngine.GameObject)+68]");
			object obj41 = 0;
		}
		goto IL_17a8;
		IL_141e:
		throw new NullReferenceException();
	}

	private IEnumerator WaitAndSelect()
	{
		_003CWaitAndSelect_003Ed__73 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	protected override void OnHideStart(GameObject g)
	{
		base.OnHideStart(g);
		PlayerOptionsData config = _playerOptions.Config;
		SoundManager.StopMusic(config._003CSelectedBGM_003Ek__BackingField);
		ResetBackButtonNavigation();
		ParticleSystem inputParticles = _inputParticles;
		if ((object)_inputParticles != null && ((UnityEngine.Object)inputParticles).m_CachedPtr != (IntPtr)0)
		{
			_gravityWell.RemoveParticleSystem(_inputParticles);
			GameObject obj = _inputParticles.gameObject;
			UnityEngine.Object.Destroy(obj, 0f);
		}
	}

	private unsafe void NavigationWrap()
	{
		//IL_0018: Expected O, but got I4
		//IL_0061: Expected O, but got I4
		//IL_0140: Expected O, but got I4
		//IL_0189: Expected O, but got I4
		//IL_01b6: Expected O, but got Ref
		List<GameObject> spawned = _spawned;
		object obj = spawned._size - 1;
		if ((nint)obj < spawned._size)
		{
			GameObject[] items = spawned._items;
			object obj2 = spawned._size - 1;
			Selectable component = items[obj2].GetComponent<Selectable>();
			List<GameObject> spawned2 = _spawned;
			if (spawned2._size > 0)
			{
				GameObject[] items2 = spawned2._items;
				Selectable component2 = items2[0].GetComponent<Selectable>();
				Selectable right = default(Selectable);
				ForceBackButtonNavigation(component, component2, null, right);
				Selectable component3 = BackButtonController.Instance.GetComponent<Selectable>();
				LayoutRebuilder.ForceRebuildLayoutImmediate(_content);
				Canvas.ForceUpdateCanvases();
				List<GameObject> spawned3 = _spawned;
				object obj3 = spawned3._size - 1;
				if ((nint)obj3 < spawned3._size)
				{
					GameObject[] items3 = spawned3._items;
					object obj4 = spawned3._size - 1;
					Selectable component4 = items3[obj4].GetComponent<Selectable>();
					object obj5 = default(object);
					component4.navigation = (Navigation)(&obj5);
					SetNavigationDown(component4, component3);
					SetNavigationUp(component4);
					return;
				}
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe bool GetMusicData(BgmType bgmType, out MusicData musicData)
	{
		//IL_011b: Expected I4, but got O
		ref MusicData reference = ref *(MusicData*)null;
		DataManager data = _data;
		if (_data != null && data._003CAllMusicData_003Ek__BackingField != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)data._003CAllMusicData_003Ek__BackingField).FindEntry((System.Int32Enum)bgmType);
			if (num < 0)
			{
				return false;
			}
			DataManager data2 = _data;
			if (_data != null && data2._003CAllMusicData_003Ek__BackingField != null)
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)data2._003CAllMusicData_003Ek__BackingField).get_Item((System.Int32Enum)bgmType);
				reference = ref *(MusicData*)obj;
				return true;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void PlaySoundTrack()
	{
		//IL_027a: Expected O, but got I4
		//IL_01c7: Expected O, but got I
		//IL_01dc: Expected F4, but got I
		//IL_01f1: Expected O, but got I
		//IL_020b: Expected F4, but got I
		//IL_0146: Expected O, but got I
		//IL_015b: Expected F4, but got I
		//IL_0170: Expected O, but got I
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = null;
		DataManager data = _data;
		int num = ((Dictionary<System.Int32Enum, object>)(object)data._003CAllMusicData_003Ek__BackingField).FindEntry((System.Int32Enum)SoundManager._003CCurrentBgm_003Ek__BackingField);
		if (num >= 0)
		{
			DataManager data2 = _data;
			object obj2 = ((Dictionary<System.Int32Enum, object>)(object)data2._003CAllMusicData_003Ek__BackingField).get_Item((System.Int32Enum)SoundManager._003CCurrentBgm_003Ek__BackingField);
			obj = obj2;
		}
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CSelectedBGMMod_003Ek__BackingField != BgmModType.Hyper)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			if (config2._003CSelectedBGMMod_003Ek__BackingField != BgmModType.Forsaken)
			{
				goto IL_026c;
			}
			if (obj == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ stack_18_v4 (System.Object)+58]");
			if ((nint)0 == 0)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ stack_18_v4 (System.Object)+58]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v599 @ rax_v31+10]");
			soundConfig.Rate = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ stack_18_v4 (System.Object)+58]");
			object obj4 = 0;
		}
		else
		{
			if (obj == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ stack_18_v4 (System.Object)+50]");
			if ((nint)0 == 0)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ stack_18_v4 (System.Object)+50]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v26+10]");
			soundConfig.Rate = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ stack_18_v4 (System.Object)+50]");
			object obj4 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v17+14]");
		soundConfig.Detune = 0f;
		goto IL_026c;
		IL_026c:
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Loop = true;
		PlayerOptionsData config3 = _playerOptions.Config;
		SoundManager.PlayMusic(config3._003CSelectedBGM_003Ek__BackingField, soundConfig);
	}

	private unsafe void BuildTwirls()
	{
		//IL_004c: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_0bfb: Expected I, but got O
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_00f7: Expected O, but got I
		//IL_00c2: Expected I, but got O
		//IL_09b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b9: Expected O, but got Unknown
		//IL_096f: Expected O, but got I
		//IL_0a17: Expected F4, but got I4
		//IL_0a21: Expected O, but got I4
		//IL_0a2b: Expected I, but got O
		//IL_0e16: Expected O, but got Ref
		//IL_0eb2: Expected O, but got Ref
		//IL_0b94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b99: Expected O, but got Unknown
		//IL_0f91: Expected O, but got I
		//IL_00e5->IL00e5: Incompatible stack heights: 1 vs 0
		//IL_09e1->IL0d9f: Incompatible stack heights: 14 vs 0
		//IL_0a04->IL0bc5: Incompatible stack heights: 14 vs 0
		//IL_0bc5->IL0f96: Incompatible stack heights: 14 vs 0
		//IL_0f96->IL0fb4: Incompatible stack heights: 19 vs 14
		if (_twirlsBuilt)
		{
			return;
		}
		Vector2 vector = (Vector2)0;
		object obj = 0;
		SecretsPage secretsPage = this;
		object obj3 = default(object);
		IntPtr intPtr = default(IntPtr);
		object obj4 = default(object);
		Vector3 value = default(Vector3);
		Vector3 value2 = default(Vector3);
		Vector2 vector2 = default(Vector2);
		string textureName = default(string);
		float angle = default(float);
		SecretsPage secretsPage2 = default(SecretsPage);
		object obj5;
		while (true)
		{
			List<GameObject> list = new List<GameObject>();
			Type[] array = new Type[1];
			nint num = (nint)typeof(RectTransform);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = obj3 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			num = intPtr;
			if (array != null)
			{
				if (num != 0)
				{
					nint num2 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag = obj4 == null;
				}
				array[0] = (Type)num;
				GameObject gameObject = new GameObject("TwirlContainer", array);
				if ((object)gameObject != null)
				{
					Transform transform = gameObject.transform;
					if ((object)transform != null)
					{
						transform.parent = secretsPage._TwirlContainer;
						Transform transform2 = gameObject.transform;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1074 @ rax_v63 (UnityEngine.Transform)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1074 @ rax_v63 (UnityEngine.Transform)+10]");
						Transform.set_localScale_Injected((IntPtr)0, ref value);
						Transform transform3 = gameObject.transform;
						bool flag3 = (object)transform3 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1516 @ rax_v71 (UnityEngine.Transform)+10]");
						bool flag4 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1516 @ rax_v71 (UnityEngine.Transform)+10]");
						Transform.set_localPosition_Injected((IntPtr)0, ref value2);
						GameObject gameObject2 = secretsPage.SpawnTwirl(gameObject, vector2, "sheen04", textureName, angle);
						GameObject gameObject3 = secretsPage.SpawnTwirl(gameObject, vector2, "sheen05", textureName, angle);
						GameObject gameObject4 = secretsPage.SpawnTwirl(gameObject, vector2, "sheen06", textureName, angle);
						GameObject gameObject5 = secretsPage.SpawnTwirl(gameObject, vector2, "sheen07", textureName, angle);
						bool flag5 = (object)gameObject2 == null;
						RectTransform component = gameObject2.GetComponent<RectTransform>();
						TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOAnchorPosY(component, -200f, 2f);
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2297 @ rax_v85 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2297 @ rax_v85 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
								if ((nint)0 == 0)
								{
									_ = 4294967295L;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2297 @ rax_v85 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
									if ((nint)0 == 0)
									{
										_ = 2139095040;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2297 @ rax_v85 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
								if ((nint)0 != 0)
								{
									_ = 4;
									_ = 0;
								}
							}
						}
						bool flag6 = (object)gameObject3 == null;
						RectTransform component2 = gameObject3.GetComponent<RectTransform>();
						TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore2 = DOTweenModuleUI.DOAnchorPosX(component2, 200f, 4f);
						if (tweenerCore2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2402 @ rax_v88 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2402 @ rax_v88 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
								if ((nint)0 == 0)
								{
									_ = 4294967295L;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2402 @ rax_v88 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
									if ((nint)0 == 0)
									{
										_ = 2139095040;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2402 @ rax_v88 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
								if ((nint)0 != 0)
								{
									_ = 4;
									_ = 0;
								}
							}
						}
						bool flag7 = (object)gameObject4 == null;
						RectTransform component3 = gameObject4.GetComponent<RectTransform>();
						TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore3 = DOTweenModuleUI.DOAnchorPosY(component3, 200f, 2f);
						if (tweenerCore3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2531 @ rax_v91 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2531 @ rax_v91 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
								if ((nint)0 == 0)
								{
									_ = 4294967295L;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2531 @ rax_v91 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
									if ((nint)0 == 0)
									{
										_ = 2139095040;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2531 @ rax_v91 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
								if ((nint)0 != 0)
								{
									_ = 4;
									_ = 0;
								}
							}
						}
						bool flag8 = (object)gameObject5 == null;
						RectTransform component4 = gameObject5.GetComponent<RectTransform>();
						TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore4 = DOTweenModuleUI.DOAnchorPosX(component4, -200f, 4f);
						bool flag9 = tweenerCore4 == null;
						bool flag10 = false;
						if (!flag9)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2660 @ rax_v94 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
							bool flag11 = (nint)0 == 0;
							flag10 = false;
							if (!flag11)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2660 @ rax_v94 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
								if ((nint)0 == 0)
								{
									_ = 4294967295L;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2660 @ rax_v94 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
									if ((nint)0 == 0)
									{
										_ = 2139095040;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2660 @ rax_v94 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
								bool flag12 = (nint)0 == 0;
								flag10 = false;
								if (!flag12)
								{
									_ = 4;
									_ = 0;
									flag10 = false;
								}
							}
						}
						bool flag13 = list == null;
						int version = list._version + 1;
						list._version = version;
						GameObject[] items = list._items;
						bool flag14 = list._items == null;
						if (list._size >= items.Length)
						{
							((List<object>)(object)list).AddWithResize((object)gameObject2);
						}
						else
						{
							int size = list._size + 1;
							list._size = size;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version2 = list._version + 1;
						list._version = version2;
						GameObject[] items2 = list._items;
						bool flag15 = list._items == null;
						if (list._size >= items2.Length)
						{
							((List<object>)(object)list).AddWithResize((object)gameObject3);
						}
						else
						{
							int size2 = list._size + 1;
							list._size = size2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version3 = list._version + 1;
						list._version = version3;
						GameObject[] items3 = list._items;
						bool flag16 = list._items == null;
						if (list._size >= items3.Length)
						{
							((List<object>)(object)list).AddWithResize((object)gameObject4);
						}
						else
						{
							int size3 = list._size + 1;
							list._size = size3;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version4 = list._version + 1;
						list._version = version4;
						GameObject[] items4 = list._items;
						bool flag17 = list._items == null;
						if (list._size >= items4.Length)
						{
							((List<object>)(object)list).AddWithResize((object)gameObject5);
						}
						else
						{
							int size4 = list._size + 1;
							list._size = size4;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						List<object> twirlContainer = (List<object>)(object)secretsPage2._twirlContainer;
						bool flag18 = secretsPage2._twirlContainer == null;
						int version5 = twirlContainer._version + 1;
						twirlContainer._version = version5;
						object[] items5 = twirlContainer._items;
						bool flag19 = twirlContainer._items == null;
						if (twirlContainer._size >= items5.Length)
						{
							((List<object>)(object)secretsPage2._twirlContainer).AddWithResize((object)gameObject);
							GameObject gameObject6 = (GameObject)0;
						}
						else
						{
							int size5 = twirlContainer._size + 1;
							twirlContainer._size = size5;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							GameObject gameObject6 = gameObject;
						}
						obj++;
						bool flag20 = (nint)obj < 48;
						vector = vector2;
						secretsPage = secretsPage2;
						if (flag20)
						{
							continue;
						}
						if (secretsPage2._twirlContainer != null)
						{
							float num3 = 0f;
							obj5 = 0;
							break;
						}
					}
				}
			}
			throw new NullReferenceException();
		}
		List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
		while (enumerator.MoveNext())
		{
			nint num4 = unchecked((nint)null);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rbx_v29 (Il2CppClass<UnityEngine.RectTransform>)+10]");
			bool flag21 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rbx_v29 (Il2CppClass<UnityEngine.RectTransform>)+10]");
			IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
			Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore5 = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&value2), 6f, RotateMode.LocalAxisAdd);
			if (tweenerCore5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3065 @ rax_v113 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3065 @ rax_v113 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 4294967295L;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3065 @ rax_v113 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
						if ((nint)0 == 0)
						{
							_ = 2139095040;
						}
					}
				}
			}
			float delay = (float)obj5 * 0.128f;
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore6 = TweenSettingsExtensions.SetDelay(tweenerCore5, delay);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rbx_v29 (Il2CppClass<UnityEngine.RectTransform>)+10]");
			bool flag22 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rbx_v29 (Il2CppClass<UnityEngine.RectTransform>)+10]");
			IntPtr gcHandlePtr2 = GameObject.get_transform_Injected((IntPtr)0);
			Transform target2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore7 = ShortcutExtensions.DOScale(target2, (Vector3)(&value), 6f);
			if (tweenerCore7 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3170 @ rax_v120 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3170 @ rax_v120 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 4294967295L;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3170 @ rax_v120 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
						if ((nint)0 == 0)
						{
							_ = 2139095040;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3170 @ rax_v120 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 7;
						_ = 0;
					}
				}
			}
			float num3 = (float)obj5 * 0.128f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore8 = TweenSettingsExtensions.SetDelay(tweenerCore7, num3);
			obj5++;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rbx_v29 (Il2CppClass<UnityEngine.RectTransform>)+10]");
			bool flag23 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rbx_v29 (Il2CppClass<UnityEngine.RectTransform>)+10]");
			IntPtr gcHandlePtr3 = GameObject.get_transform_Injected((IntPtr)0);
			Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
			bool flag24 = (object)transform4 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1680 @ rax_v127 (UnityEngine.Transform)+10]");
			bool flag25 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1680 @ rax_v127 (UnityEngine.Transform)+10]");
			Transform.SetAsFirstSibling_Injected((IntPtr)0);
			GameObject gameObject6 = (GameObject)0;
		}
		secretsPage2._twirlsBuilt = true;
	}

	private void OnDestroy()
	{
		int num = DG.Tweening.Core.TweenManager.DespawnAll();
	}

	private unsafe GameObject SpawnTwirl(GameObject container, Vector2 pos, string spriteName, string textureName, float angle)
	{
		//IL_007e: Expected O, but got Ref
		//IL_01f8->IL017f: Incompatible stack heights: 1 vs 0
		if ((object)container != null)
		{
			Transform parent = container.transform;
			GameObject gameObject = UnityEngine.Object.Instantiate(_TwirlPrefab, parent);
			if ((object)gameObject != null)
			{
				Transform transform = gameObject.transform;
				if ((object)transform != null)
				{
					object obj = default(object);
					transform.localEulerAngles = (Vector3)(&obj);
					Transform transform2 = gameObject.transform;
					if ((object)transform2 != null)
					{
						bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Vector2 value = default(Vector2);
						Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value));
						RectTransform component = gameObject.GetComponent<RectTransform>();
						if ((object)component != null)
						{
							component.anchoredPosition = pos;
							Vector2 sizeDelta = component.sizeDelta;
							object obj3 = default(object);
							object obj2 = obj3 + obj3;
							Vector2 sizeDelta2 = default(Vector2);
							component.sizeDelta = sizeDelta2;
							Image component2 = gameObject.GetComponent<Image>();
							string textureName2 = default(string);
							Sprite sprite = SpriteManager.GetSprite(spriteName, textureName2);
							bool flag2 = (object)component2 == null;
							component2.sprite = sprite;
							Image component3 = gameObject.GetComponent<Image>();
							bool flag3 = _twirlImages == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A77500");
							return gameObject;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void StartRuneParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0082: Expected O, but got I
		//IL_00a3: Expected O, but got I
		//IL_0486: Expected O, but got I4
		//IL_04ad: Expected O, but got I4
		//IL_04c6: Expected O, but got Ref
		//IL_04e0: Expected native int or pointer, but got O
		//IL_04fa: Expected O, but got I
		//IL_051a: Expected O, but got Ref
		//IL_0534: Expected native int or pointer, but got O
		//IL_054e: Expected O, but got I
		//IL_057c: Expected O, but got I4
		//IL_0595: Expected O, but got Ref
		//IL_05af: Expected native int or pointer, but got O
		//IL_079f: Expected O, but got I4
		//IL_05d4: Expected O, but got Ref
		//IL_05ee: Expected native int or pointer, but got O
		//IL_07d9: Expected O, but got I
		//IL_0626: Expected O, but got Ref
		//IL_0640: Expected native int or pointer, but got O
		//IL_0813: Expected O, but got I
		//IL_0697: Expected O, but got I
		//IL_06b8: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem runeParticles = _runeParticles;
		if ((object)_runeParticles == null || ((UnityEngine.Object)runeParticles).m_CachedPtr == (IntPtr)0)
		{
			GravityWellConfig gravityWellConfig = new GravityWellConfig();
			_ = 0;
			_ = 0;
			_ = 1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
			gravityWellConfig._x = (float?)(object)0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
			gravityWellConfig._y = (float?)(object)0;
			gravityWellConfig._power = 10f;
			gravityWellConfig._epsilon = 200f;
			gravityWellConfig._gravity = 200f;
			gravityWellConfig.requiresLateUpdate = true;
			Transform parent = _RuneParticlesEmitter.transform;
			GravityWell gravityWell = _RuneParticlesEmitter.CreateGravityWell(gravityWellConfig, parent);
			_gravityWell = gravityWell;
			GameObject gameObject = _gravityWell.gameObject;
			gameObject.SetActive(value: false);
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"_runes_02");
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
				((List<object>)(object)list).AddWithResize((object)"_runes_03");
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
				((List<object>)(object)list).AddWithResize((object)"_runes_04");
			}
			else
			{
				int size3 = list._size + 1;
				list._size = size3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version4 = list._version + 1;
			list._version = version4;
			string[] items4 = list._items;
			if (list._size >= items4.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"_runes_05");
			}
			else
			{
				int size4 = list._size + 1;
				list._size = size4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version5 = list._version + 1;
			list._version = version5;
			string[] items5 = list._items;
			if (list._size >= items5.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"_runes_06");
			}
			else
			{
				int size5 = list._size + 1;
				list._size = size5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
			particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(240f, 310f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(3000f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 230f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
			_ = 0;
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 3f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+68]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+78]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-20]");
			_ = 0;
			_ = 0;
			_ = 1127481344;
			_ = 1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
			particleSystemConfig._frequency = (float?)(object)0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
			particleSystemConfig._quantity = (int?)(object)0;
			Transform transform = _RuneParticlesEmitter.transform;
			Transform parent2 = default(Transform);
			string psName = default(string);
			bool isAdditive = default(bool);
			bool requiresMasking = default(bool);
			ParticleSystem runeParticles2 = _RuneParticlesEmitter.CreateUIEmitter(particleSystemConfig, "UI", 100, parent2, psName, isAdditive, requiresMasking);
			_runeParticles = runeParticles2;
			UIParticle componentInChildren = _runeParticles.GetComponentInChildren<UIParticle>();
			float num = (float)componentInChildren.m_Scale3D * 0.65f;
			Vector3 scale3D = default(Vector3);
			componentInChildren.m_Scale3D = scale3D;
			RenderingExtensions.Start(_runeParticles);
		}
	}

	private unsafe void StartInputParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0385: Expected O, but got I4
		//IL_03ac: Expected O, but got I4
		//IL_03c5: Expected O, but got Ref
		//IL_03df: Expected native int or pointer, but got O
		//IL_03f9: Expected O, but got I
		//IL_0419: Expected O, but got Ref
		//IL_0433: Expected native int or pointer, but got O
		//IL_044d: Expected O, but got I
		//IL_047b: Expected O, but got I4
		//IL_0494: Expected O, but got Ref
		//IL_04ae: Expected native int or pointer, but got O
		//IL_06e6: Expected O, but got I4
		//IL_04d3: Expected O, but got Ref
		//IL_04ed: Expected native int or pointer, but got O
		//IL_0720: Expected O, but got I
		//IL_0525: Expected O, but got Ref
		//IL_053f: Expected native int or pointer, but got O
		//IL_075a: Expected O, but got I
		//IL_0596: Expected O, but got I
		//IL_05b7: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem inputParticles = _inputParticles;
		if ((object)_inputParticles == null || ((UnityEngine.Object)inputParticles).m_CachedPtr == (IntPtr)0)
		{
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"_runes_02");
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
				((List<object>)(object)list).AddWithResize((object)"_runes_03");
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
				((List<object>)(object)list).AddWithResize((object)"_runes_04");
			}
			else
			{
				int size3 = list._size + 1;
				list._size = size3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version4 = list._version + 1;
			list._version = version4;
			string[] items4 = list._items;
			if (list._size >= items4.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"_runes_05");
			}
			else
			{
				int size4 = list._size + 1;
				list._size = size4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version5 = list._version + 1;
			list._version = version5;
			string[] items5 = list._items;
			if (list._size >= items5.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"_runes_06");
			}
			else
			{
				int size5 = list._size + 1;
				list._size = size5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
			particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(50f, 150f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
			_ = 0;
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.5f, 1f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+68]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+78]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-20]");
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
			particleSystemConfig._frequency = (float?)(object)0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
			particleSystemConfig._quantity = (int?)(object)0;
			Transform transform = _RuneParticlesEmitter.transform;
			Transform parent = default(Transform);
			string psName = default(string);
			bool isAdditive = default(bool);
			bool requiresMasking = default(bool);
			ParticleSystem inputParticles2 = _RuneParticlesEmitter.CreateUIEmitter(particleSystemConfig, "UI", 109, parent, psName, isAdditive, requiresMasking);
			_inputParticles = inputParticles2;
			ParticleSystemRenderer component = _inputParticles.GetComponent<ParticleSystemRenderer>();
			component.enabled = true;
			((UnityEngine.Object)_inputParticles).SetName("InputParticles");
			ParticleSystemRenderer component2 = _inputParticles.GetComponent<ParticleSystemRenderer>();
			Material material = ((Renderer)component2).GetMaterial();
			Shader shader = Shader.Find("UI/Default");
			material.shader = shader;
			_gravityWell.AddParticleSystem(_inputParticles);
		}
	}

	protected unsafe override void Update()
	{
		//IL_0855: Expected O, but got I4
		//IL_086f: Expected O, but got I4
		//IL_072e: Expected O, but got I4
		//IL_0748: Expected O, but got I4
		//IL_0155: Invalid comparison between F4 and I4
		//IL_0193: Invalid comparison between F4 and I4
		//IL_01d7: Invalid comparison between F4 and I4
		//IL_0285: Invalid comparison between I4 and F4
		//IL_0333: Invalid comparison between I4 and F4
		//IL_080d: Expected O, but got I
		//IL_0431: Expected O, but got I
		//IL_07a6: Expected O, but got Ref
		//IL_07a6: Expected O, but got Ref
		//IL_043f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0444: Expected O, but got Unknown
		//IL_0454: Expected O, but got I
		//IL_07bc: Expected O, but got Ref
		//IL_07bc: Expected O, but got Ref
		//IL_0251: Expected O, but got Ref
		//IL_07d2: Expected O, but got Ref
		//IL_07d2: Expected O, but got Ref
		//IL_02ff: Expected O, but got Ref
		//IL_03ad: Expected O, but got Ref
		//IL_08a4: Expected O, but got I4
		//IL_04e7: Expected O, but got I
		base.Update();
		if (_isBusy)
		{
			return;
		}
		if (_allowInput)
		{
			EventSystem current = EventSystem.current;
			GameObject currentSelected = current.m_CurrentSelected;
			GameObject gameObject = _SpellCharacterBackground.gameObject;
			bool flag = (object)current.m_CurrentSelected == null;
			bool flag2 = (object)gameObject == null;
			object obj = flag & flag2;
			bool flag3 = obj == null;
			object obj2 = !flag3;
			if (obj2 == null)
			{
				bool flag4;
				if ((object)gameObject != null)
				{
					if ((object)current.m_CurrentSelected != null)
					{
						object obj3 = (object)current.m_CurrentSelected - (object)gameObject;
						flag4 = obj3 == null;
					}
					else
					{
						flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					}
				}
				else
				{
					flag4 = ((UnityEngine.Object)currentSelected).m_CachedPtr == (IntPtr)0;
				}
				if (!flag4)
				{
					_allowInput = false;
					return;
				}
			}
			float axis = Player.GetAxis("UIVertical");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186D8DA93h\"");
			if (axis == 0f)
			{
				float axis2 = Player.GetAxis("UIHorizontal");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186D8DA93h\"");
				if (axis2 == 0f)
				{
					_canNavigate = true;
				}
			}
			if (_canNavigate)
			{
				float axis3 = Player.GetAxis("UIVertical");
				Vector3 vector2 = default(Vector3);
				if (axis3 > 0f && !Input.GetKeyInt(KeyCode.W))
				{
					Button component = _SpellCharacterBackground.GetComponent<Button>();
					Transform transform = _SpellCharacterBackground.transform;
					Quaternion rotation = transform.rotation;
					float num = default(float);
					Vector3 vector = (Quaternion)(&num) * (Vector3)(&vector2);
					float num2 = default(float);
					Selectable selectable = component.FindSelectable((Vector3)(&num2));
					selectable.Select();
				}
				float axis4 = Player.GetAxis("UIVertical");
				if (0f > axis4 && !Input.GetKeyInt(KeyCode.S))
				{
					Button component2 = _SpellCharacterBackground.GetComponent<Button>();
					Transform transform2 = _SpellCharacterBackground.transform;
					Quaternion rotation2 = transform2.rotation;
					float num3 = default(float);
					Vector3 vector3 = (Quaternion)(&num3) * (Vector3)(&vector2);
					float num4 = default(float);
					Selectable selectable2 = component2.FindSelectable((Vector3)(&num4));
					selectable2.Select();
				}
				float axis5 = Player.GetAxis("UIHorizontal");
				if (0f > axis5 && !Input.GetKeyInt(KeyCode.A))
				{
					Button component3 = _SpellCharacterBackground.GetComponent<Button>();
					Transform transform3 = _SpellCharacterBackground.transform;
					Quaternion rotation3 = transform3.rotation;
					float num5 = default(float);
					Vector3 vector4 = (Quaternion)(&num5) * (Vector3)(&vector2);
					float num6 = default(float);
					Selectable selectable3 = component3.FindSelectable((Vector3)(&num6));
					selectable3.Select();
				}
			}
			string text = null;
			object obj4 = default(object);
			object obj5 = default(object);
			object obj7 = default(object);
			while (true)
			{
				if (obj4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-48_v11+1C]");
					if (obj5 != null)
					{
						break;
					}
					object obj6 = obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-48_v11+18]");
					if ((nint)obj6 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-48_v11+10]");
					object obj8 = 0;
					object obj9 = obj7 + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEF8]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1836 @ rcx_v54+E4]");
					if ((nint)0 == 0)
					{
					}
					string text2 = string.FastAllocateString(1);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v797 @ rdx_v25+20+v777 @ stack_-40_v10*2]");
					text2._firstChar = '\0';
					bool keyDownString = UnityEngine.Internal.InputUnsafeUtility.GetKeyDownString(text2);
					bool flag5 = !keyDownString;
					obj7 = obj9;
					if (!flag5)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEF8]");
						object obj11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1926 @ rcx_v58+E4]");
						if ((nint)0 == 0)
						{
						}
						string text3 = string.FastAllocateString(1);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v797 @ rdx_v25+20+v777 @ stack_-40_v10*2]");
						text3._firstChar = '\0';
						SetNextCharacter(text3);
						obj7 = obj9;
					}
					continue;
				}
				throw new NullReferenceException();
			}
			bool flag6 = obj4 == null;
			text = (string)0;
			if (!flag6)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-48_v11+1C]");
				if (obj5 == null)
				{
					object obj12 = Input.GetKeyDownInt(KeyCode.Backspace);
					if (obj12 != null)
					{
						Backspace();
					}
					return;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				text = null;
			}
			throw new NullReferenceException();
		}
		EventSystem current2 = EventSystem.current;
		GameObject currentSelected2 = current2.m_CurrentSelected;
		GameObject gameObject2 = _SpellCharacterBackground.gameObject;
		bool flag7 = (object)gameObject2 == null;
		bool flag8 = (object)current2.m_CurrentSelected == null;
		object obj13 = flag8 & flag7;
		bool flag9 = obj13 == null;
		object obj14 = !flag9;
		if (obj14 == null)
		{
			bool flag10;
			if ((object)gameObject2 != null)
			{
				if ((object)current2.m_CurrentSelected != null)
				{
					object obj15 = (object)current2.m_CurrentSelected - (object)gameObject2;
					flag10 = obj15 == null;
				}
				else
				{
					flag10 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag10 = ((UnityEngine.Object)currentSelected2).m_CachedPtr == (IntPtr)0;
			}
			if (!flag10)
			{
				return;
			}
		}
		_allowInput = true;
		_canNavigate = false;
		IBaseAccount account = SystemPlatform.Account;
		account.DisplayOnscreenKeyboard();
	}

	private unsafe void Populate()
	{
		//IL_06ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b0: Expected I4, but got Unknown
		//IL_0449: Expected I, but got O
		//IL_046b: Expected O, but got Ref
		//IL_0486: Expected O, but got I4
		//IL_04b2: Expected I, but got O
		//IL_04f7: Expected I, but got O
		//IL_0519: Expected O, but got Ref
		//IL_0534: Expected O, but got I4
		//IL_0560: Expected I, but got O
		ClearSpawned();
		bool flag = _secrets == null;
		SecretsPage secretsPage = this;
		if (!flag)
		{
			string secrets = (string)(object)_secrets;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			Dictionary<SecretType, SecretData>.Enumerator enumerator = default(Dictionary<SecretType, SecretData>.Enumerator);
			if (enumerator.MoveNext())
			{
				bool flag2 = CheckForCheat(SecretType.CastThiefSpell);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
				SecretData secretData = null;
				throw new NullReferenceException();
			}
			int num4 = this + 492;
			string text = ((int*)num4)->ToString();
			string text2 = "Max spell length : " + text;
			Debug.Log(text2);
			List<GameObject> spawned = _spawned;
			bool flag3 = _spawned == null;
			secretsPage = (SecretsPage)(object)text2;
			if (!flag3)
			{
				if (spawned._size <= 0)
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return;
				}
				GameObject[] items = spawned._items;
				bool flag4 = spawned._items == null;
				secretsPage = (SecretsPage)(object)text2;
				if (!flag4)
				{
					bool flag5 = (object)items[0] == null;
					secretsPage = (SecretsPage)(object)items[0];
					if (!flag5)
					{
						Selectable component = items[0].GetComponent<Selectable>();
						bool flag6 = (object)component == null;
						secretsPage = (SecretsPage)(object)items[0];
						if (!flag6)
						{
							component.Select();
							SecretsPage title = (SecretsPage)(object)_Title;
							bool flag7 = (object)_Title == null;
							secretsPage = (SecretsPage)(object)_Title;
							if (!flag7)
							{
								nint num5 = (nint)title;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1127 @ rdx_v19 (Il2CppClass<VampireSurvivors.UI.SecretsPage>)+548] (should have been resolved before IL gen)");
								object obj = default(object);
								string newValue = System.Number.FormatInt32(num3, (ReadOnlySpan<char>)(&obj), null);
								string text3 = default(string);
								bool flag8 = text3 == null;
								secretsPage = (SecretsPage)num3;
								if (!flag8)
								{
									string text4 = text3.Replace("%0", newValue);
									nint num6 = (nint)title;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v164 @ r9_v14 (Il2CppClass<VampireSurvivors.UI.SecretsPage>)+558] (should have been resolved before IL gen)");
									SecretsPage title2 = (SecretsPage)(object)_Title;
									bool flag9 = (object)_Title == null;
									secretsPage = (SecretsPage)(object)_Title;
									if (!flag9)
									{
										nint num7 = (nint)title2;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1226 @ rdx_v24 (Il2CppClass<VampireSurvivors.UI.SecretsPage>)+548] (should have been resolved before IL gen)");
										string newValue2 = System.Number.FormatInt32(num2, (ReadOnlySpan<char>)(&obj), null);
										string text5 = default(string);
										bool flag10 = text5 == null;
										secretsPage = (SecretsPage)num2;
										if (!flag10)
										{
											string text6 = text5.Replace("%1", newValue2);
											nint num8 = (nint)title2;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1049 @ r9_v17 (Il2CppClass<VampireSurvivors.UI.SecretsPage>)+558] (should have been resolved before IL gen)");
											ClearSpell();
											return;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		object obj2 = secretsPage;
		throw new NullReferenceException();
	}

	private unsafe void ClearSpawned()
	{
		//IL_0012: Expected O, but got Ref
		//IL_0094: Expected I4, but got O
		//IL_0094: Expected O, but got I
		bool flag = _spawned == null;
		SecretsPage secretsPage = this;
		if (!flag)
		{
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			if (enumerator.MoveNext())
			{
				List<GameObject>.Enumerator enumerator2 = (List<GameObject>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			secretsPage = (SecretsPage)(object)_spawned;
			if (_spawned != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v3 (VampireSurvivors.UI.SecretsPage)+1C]");
				_ = (nint)0 + (nint)1;
				((MonoBehaviour)secretsPage).m_CancellationTokenSource = null;
				if ((nint)((MonoBehaviour)secretsPage).m_CancellationTokenSource > 0)
				{
					Array.Clear((Array)(nint)((UnityEngine.Object)secretsPage).m_CachedPtr, 0, (int)((MonoBehaviour)secretsPage).m_CancellationTokenSource);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void BuildKeyboard()
	{
		//IL_0079: Expected O, but got I
		//IL_046a: Expected O, but got I4
		//IL_0473: Expected O, but got I4
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_0128: Expected O, but got I
		//IL_050a: Unknown result type (might be due to invalid IL or missing references)
		//IL_050f: Expected O, but got Unknown
		//IL_0207: Expected I, but got O
		//IL_021d: Expected O, but got I
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected O, but got Unknown
		//IL_0294: Expected I, but got O
		//IL_058f: Expected O, but got I4
		//IL_05a6: Expected I, but got I8
		//IL_027d: Expected I, but got I8
		//IL_05d9: Expected F4, but got I
		//IL_0580->IL0580: Incompatible stack heights: 3 vs 1
		//IL_0434->IL0601: Incompatible stack heights: 7 vs 0
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		while (true)
		{
			bool flag = obj == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ stack_-88_v4+1C]");
			_003C_003Ec__DisplayClass86_0 obj7;
			Button component;
			UnityAction unityAction;
			if (obj2 == null)
			{
				object obj3 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ stack_-88_v4+18]");
				if ((nint)obj3 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ stack_-88_v4+10]");
					object obj5 = 0;
					object obj6 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rdx_v36+18]");
					if ((nint)obj6 >= 0)
					{
						break;
					}
					obj4++;
					obj7 = new _003C_003Ec__DisplayClass86_0
					{
						_003C_003E4__this = this
					};
					GameObject k = UnityEngine.Object.Instantiate(_KeyboardButtonPrefab, _KeyboardContainer);
					obj7.k = k;
					Text componentInChildren = obj7.k.GetComponentInChildren<Text>(includeInactive: false);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEF8]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1420 @ rcx_v52+E4]");
					if ((nint)0 == 0)
					{
					}
					string text = string.FastAllocateString(1);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rdx_v36+20+v749 @ rcx_v44*2]");
					text._firstChar = '\0';
					string text2 = text.ToUpperInvariant();
					componentInChildren.text = text2;
					component = obj7.k.GetComponent<Button>();
					unityAction = null;
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ r10_v24 (Il2CppMethodInfo)+8]");
					((Delegate)unityAction).method_ptr = (IntPtr)0;
					((Delegate)unityAction).method = (nint)__ldftn(_003C_003Ec__DisplayClass86_0._003CBuildKeyboard_003Eb__0);
					((Delegate)unityAction).m_target = obj7;
					((Delegate)unityAction).method_code = (IntPtr)unityAction;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ r10_v24 (Il2CppMethodInfo)+4C]");
					object obj9 = (nint)0 >> 4;
					object obj10 = obj9 & 1;
					nint num2;
					if (obj10 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ r10_v24 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num2 = unchecked((nint)6447293664L);
							goto IL_0586;
						}
					}
					((Delegate)unityAction).method_code = (IntPtr)((Delegate)unityAction).m_target;
					num2 = ((Delegate)unityAction).method_ptr;
					goto IL_0586;
				}
			}
			bool flag2 = obj == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ stack_-88_v4+1C]");
			bool flag3 = obj2 != null;
			List<Button> keyboardButtons = _keyboardButtons;
			object obj11 = 0;
			object obj12 = 0;
			while (true)
			{
				List<Button> keyboardButtons2 = _keyboardButtons;
				if ((nint)obj12 < keyboardButtons._size)
				{
					if ((nint)obj11 >= keyboardButtons2._size)
					{
						break;
					}
					Button[] items = keyboardButtons2._items;
					CanvasGroup component2 = items[obj11].GetComponent<CanvasGroup>();
					TweenerCore<float, float, FloatOptions> t = DOTweenModuleUI.DOFade(component2, 1f, 0.2f);
					float delay = (float)obj11 * 0.02f;
					TweenerCore<float, float, FloatOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, delay);
					obj11++;
					keyboardButtons = _keyboardButtons;
					obj12 = obj11;
					continue;
				}
				if (keyboardButtons2._size <= 0)
				{
					break;
				}
				Button[] items2 = keyboardButtons2._items;
				items2[0].Select();
				return;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			break;
			IL_0586:
			object obj13 = 24;
			((Delegate)unityAction).extra_arg = unchecked((nint)6447293568L);
			component.m_OnClick.AddListener(unityAction);
			CanvasGroup canvasGroup = obj7.k.AddComponent<CanvasGroup>();
			bool flag4 = ((UnityEngine.Object)canvasGroup).m_CachedPtr == (IntPtr)0;
			CanvasGroup.set_alpha_Injected(((UnityEngine.Object)canvasGroup).m_CachedPtr, 0f);
			List<object> keyboardButtons3 = (List<object>)(object)_keyboardButtons;
			bool flag5 = (object)obj7.k == null;
			Button component3 = obj7.k.GetComponent<Button>();
			bool flag6 = _keyboardButtons == null;
			int version = keyboardButtons3._version + 1;
			keyboardButtons3._version = version;
			object[] items3 = keyboardButtons3._items;
			bool flag7 = keyboardButtons3._items == null;
			if (keyboardButtons3._size >= items3.Length)
			{
				((List<object>)(object)_keyboardButtons).AddWithResize((object)component3);
			}
			else
			{
				int size = keyboardButtons3._size + 1;
				keyboardButtons3._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			string text3 = string.FastAllocateString(1);
			bool flag8 = text3 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rdx_v36+20+v749 @ rcx_v44*2]");
			text3._firstChar = '\0';
			bool flag9 = (object)obj7.k == null;
			((UnityEngine.Object)obj7.k).SetName(text3);
		}
		throw new IndexOutOfRangeException();
	}

	private void Unlock(SecretType t)
	{
		//IL_285f: Expected O, but got I4
		//IL_0b1c: Expected O, but got I
		//IL_04ed: Expected I4, but got F4
		//IL_128c: Expected I4, but got F4
		//IL_082a: Expected I4, but got F4
		//IL_1023: Expected I4, but got F4
		//IL_12d1: Expected I4, but got F4
		//IL_0bb0: Expected I4, but got F4
		//IL_224d: Expected O, but got I
		//IL_22aa: Expected O, but got I
		//IL_29a2: Expected O, but got I
		//IL_0647: Expected I4, but got F4
		//IL_0985: Expected I4, but got F4
		//IL_2307: Expected O, but got I
		//IL_16a0: Expected O, but got I
		//IL_13eb: Expected I4, but got F4
		//IL_1af8: Expected O, but got I
		//IL_0eec: Expected O, but got I
		//IL_0ca7: Expected O, but got I
		//IL_1f3a: Expected O, but got I
		//IL_1407: Expected I4, but got F4
		//IL_0f46: Expected O, but got I
		//IL_0f06: Expected O, but got I
		//IL_0f86: Expected O, but got I
		//IL_0fb5: Expected I4, but got O
		//IL_26d4: Expected O, but got I4
		//IL_26f2: Expected O, but got I
		//IL_2715: Expected O, but got I4
		//IL_2779: Expected F4, but got I4
		//IL_2758: Expected O, but got I8
		//IL_2a5e: Expected O, but got I
		//IL_2acc: Expected O, but got I
		//IL_2b3c: Expected O, but got I
		//IL_0787: Expected O, but got I
		//IL_0dbc: Expected I4, but got F4
		//IL_0ac6: Expected O, but got I
		//IL_151f: Expected O, but got I
		//IL_0df8: Expected O, but got I
		//IL_2a43: Expected O, but got I
		//IL_07c3: Expected I4, but got O
		//IL_1263: Expected I4, but got O
		//IL_0e33: Expected O, but got I
		//IL_0b02: Expected I4, but got O
		//IL_154e: Expected I4, but got O
		//IL_25e6: Expected I4, but got O
		//IL_18ad: Expected O, but got I
		//IL_2147: Expected O, but got I
		//IL_1d22: Expected O, but got I
		//IL_190a: Expected O, but got I
		//IL_21a4: Expected O, but got I
		//IL_193f: Expected O, but got I
		//IL_1d7f: Expected O, but got I
		//IL_21de: Expected O, but got I
		//IL_1977: Expected O, but got I
		//IL_1db9: Expected O, but got I
		//IL_19a6: Expected I4, but got O
		//IL_220d: Expected I4, but got O
		//IL_1de8: Expected I4, but got O
		//IL_22ca->IL293c: Incompatible stack heights: 1 vs 0
		//IL_22f2->IL2986: Incompatible stack heights: 1 vs 0
		//IL_2bf9->IL293c: Incompatible stack heights: 1 vs 0
		//IL_2321->IL293c: Incompatible stack heights: 1 vs 0
		//IL_16c0->IL293c: Incompatible stack heights: 1 vs 0
		//IL_267d->IL293c: Incompatible stack heights: 1 vs 0
		//IL_1b18->IL293c: Incompatible stack heights: 1 vs 0
		//IL_0cc7->IL293c: Incompatible stack heights: 1 vs 0
		//IL_234e->IL25f0: Incompatible stack heights: 1 vs 0
		//IL_1f5a->IL293c: Incompatible stack heights: 1 vs 0
		//IL_16e8->IL2986: Incompatible stack heights: 1 vs 0
		//IL_1b40->IL2986: Incompatible stack heights: 1 vs 0
		//IL_0cee->IL2986: Incompatible stack heights: 1 vs 0
		//IL_2373->IL293c: Incompatible stack heights: 1 vs 0
		//IL_1f82->IL2986: Incompatible stack heights: 1 vs 0
		//IL_170d->IL2980: Incompatible stack heights: 1 vs 0
		//IL_1b65->IL2980: Incompatible stack heights: 1 vs 0
		//IL_0d0b->IL293c: Incompatible stack heights: 1 vs 0
		//IL_23ab->IL25f0: Incompatible stack heights: 1 vs 0
		//IL_1fa7->IL2980: Incompatible stack heights: 1 vs 0
		//IL_1748->IL293c: Incompatible stack heights: 1 vs 0
		//IL_2797->IL293c: Incompatible stack heights: 1 vs 0
		//IL_1ba0->IL293c: Incompatible stack heights: 1 vs 0
		//IL_275d->IL2bfe: Incompatible stack heights: 2 vs 1
		//IL_23e3->IL25f0: Incompatible stack heights: 1 vs 0
		//IL_1fe2->IL293c: Incompatible stack heights: 1 vs 0
		//IL_0eba->IL2992: Incompatible stack heights: 1 vs 0
		//IL_0d71->IL293c: Incompatible stack heights: 1 vs 0
		//IL_17ae->IL293c: Incompatible stack heights: 1 vs 0
		//IL_1bf0->IL293c: Incompatible stack heights: 1 vs 0
		//IL_2048->IL293c: Incompatible stack heights: 1 vs 0
		//IL_280f->IL280f: Incompatible stack heights: 1 vs 0
		//IL_2498->IL293c: Incompatible stack heights: 1 vs 0
		//IL_1c23->IL293c: Incompatible stack heights: 1 vs 0
		//IL_17df->IL293c: Incompatible stack heights: 1 vs 0
		//IL_0e18->IL293c: Incompatible stack heights: 1 vs 0
		//IL_2079->IL293c: Incompatible stack heights: 1 vs 0
		//IL_1813->IL2980: Incompatible stack heights: 1 vs 0
		//IL_1c54->IL293c: Incompatible stack heights: 1 vs 0
		//IL_25d4->IL293c: Incompatible stack heights: 1 vs 0
		//IL_20ad->IL2980: Incompatible stack heights: 1 vs 0
		//IL_1830->IL293c: Incompatible stack heights: 1 vs 0
		//IL_1c88->IL2980: Incompatible stack heights: 1 vs 0
		//IL_25f0->IL25f0: Incompatible stack heights: 1 vs 0
		//IL_20ca->IL293c: Incompatible stack heights: 1 vs 0
		//IL_1874->IL293c: Incompatible stack heights: 1 vs 0
		//IL_1ca5->IL293c: Incompatible stack heights: 1 vs 0
		//IL_210e->IL293c: Incompatible stack heights: 1 vs 0
		//IL_1ce9->IL293c: Incompatible stack heights: 1 vs 0
		//IL_18cd->IL293c: Incompatible stack heights: 2 vs 0
		//IL_2167->IL293c: Incompatible stack heights: 2 vs 0
		//IL_18f5->IL2986: Incompatible stack heights: 2 vs 0
		//IL_1d42->IL293c: Incompatible stack heights: 2 vs 0
		//IL_218f->IL2986: Incompatible stack heights: 2 vs 0
		//IL_192a->IL293c: Incompatible stack heights: 2 vs 0
		//IL_1d6a->IL2986: Incompatible stack heights: 2 vs 0
		//IL_21c4->IL293c: Incompatible stack heights: 2 vs 0
		//IL_1d9f->IL293c: Incompatible stack heights: 2 vs 0
		//IL_1994->IL293c: Incompatible stack heights: 2 vs 0
		//IL_21fb->IL293c: Incompatible stack heights: 2 vs 0
		//IL_1dd6->IL293c: Incompatible stack heights: 2 vs 0
		//IL_19b0->IL19b0: Incompatible stack heights: 2 vs 0
		//IL_2217->IL2217: Incompatible stack heights: 2 vs 0
		//IL_1df2->IL1df2: Incompatible stack heights: 2 vs 0
		_003C_003Ec__DisplayClass87_0 CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass87_0();
		if (CS_0024_003C_003E8__locals15 != null)
		{
			CS_0024_003C_003E8__locals15._003C_003E4__this = this;
			CS_0024_003C_003E8__locals15.t = t;
			ClearSpell();
			if (CS_0024_003C_003E8__locals15.t == SecretType.Spinnn)
			{
				Spin();
				return;
			}
			if (CS_0024_003C_003E8__locals15.t == SecretType.Everything)
			{
				everything();
			}
			if (CS_0024_003C_003E8__locals15.t != SecretType.Everywhere)
			{
				goto IL_0283;
			}
			if (_playerOptions != null)
			{
				_playerOptions.UnlockHyper(StageType.FOREST);
				if (_playerOptions != null)
				{
					_playerOptions.UnlockStage(StageType.LIBRARY);
					if (_playerOptions != null)
					{
						_playerOptions.UnlockHyper(StageType.LIBRARY);
						if (_playerOptions != null)
						{
							_playerOptions.UnlockStage(StageType.WAREHOUSE);
							if (_playerOptions != null)
							{
								_playerOptions.UnlockHyper(StageType.WAREHOUSE);
								if (_playerOptions != null)
								{
									_playerOptions.UnlockStage(StageType.TOWER);
									if (_playerOptions != null)
									{
										_playerOptions.UnlockHyper(StageType.TOWER);
										if (_playerOptions != null)
										{
											_playerOptions.UnlockStage(StageType.CHAPEL);
											if (_playerOptions != null)
											{
												_playerOptions.UnlockHyper(StageType.CHAPEL);
												if (_playerOptions != null)
												{
													_playerOptions.Save();
													Dictionary<WeaponType, List<WeaponData>> dictionary = null;
													goto IL_0283;
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
		goto IL_293c;
		IL_0b0c:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+80]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+80]");
		bool flag = (nint)0 == 0;
		List<SecretUnlockInfo> list2;
		List<SecretUnlockInfo> list = list2;
		SecretUnlockInfo secretUnlockInfo;
		float num = default(float);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		List<WeaponData> list3;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2976 @ rax_v48+18]");
			bool flag2 = (nint)0 <= (nint)0;
			list = list2;
			if (!flag2)
			{
				secretUnlockInfo = new SecretUnlockInfo();
				string translation = LocalizationManager.GetTranslation("lang/genericPopup_unlocked", FixForRTL: true, 0, ignoreRTLnumbers: true, (byte)(int)num != 0, localParametersRoot, overrideLanguage, allowLocalizedParameters);
				string text = translation + " ";
				if (secretUnlockInfo != null)
				{
					secretUnlockInfo.Name = text;
					if (_data != null)
					{
						Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
						Dictionary<WeaponType, List<WeaponData>> dictionary = convertedWeapons;
						SecretType secretType = SecretType.CastThiefSpell;
						list3 = null;
						SecretType secretType2 = SecretType.CastThiefSpell;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+80]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+80]");
							if ((nint)0 == 0)
							{
								break;
							}
							SecretType num2 = secretType;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rcx_v237+18]");
							if ((nint)num2 >= (nint)0)
							{
								goto IL_0eba;
							}
							SecretType num3 = secretType2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rcx_v237+18]");
							bool flag3 = (nint)num3 >= (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rcx_v237+10]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rcx_v237+10]");
							if ((nint)0 == 0)
							{
								break;
							}
							SecretType num4 = secretType2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v581 @ rcx_v253+18]");
							if ((nint)num4 < (nint)0)
							{
								if (dictionary == null)
								{
									break;
								}
								Dictionary<WeaponType, List<WeaponData>> dictionary2 = dictionary;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v581 @ rcx_v253+20+v682 @ rbx_v43 (VampireSurvivors.Data.SecretType)*4]");
								object obj4 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).get_Item((System.Int32Enum)0);
								if (obj4 != null)
								{
									List<WeaponData> list4 = ((Dictionary<WeaponType, List<WeaponData>>)obj4).get_Item(WeaponType.VOID);
									if (list4 == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v581 @ rcx_v253+20+v682 @ rbx_v43 (VampireSurvivors.Data.SecretType)*4]");
									string localizedNameTerm = ((WeaponData)(object)list4).GetLocalizedNameTerm(WeaponType.VOID);
									string text2 = string.Concat(str1: LocalizationManager.GetTranslation(localizedNameTerm, FixForRTL: true, 0, ignoreRTLnumbers: true, (byte)(int)num != 0, localParametersRoot, overrideLanguage, allowLocalizedParameters), str0: secretUnlockInfo.Name);
									secretUnlockInfo.Name = text2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+80]");
									object obj5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+80]");
									if ((nint)0 == 0)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v490 @ rax_v307+18]");
									object obj6 = -1;
									bool flag4 = (nint)secretType2 >= (nint)obj6;
									list3 = list4;
									if (!flag4)
									{
										string text3 = secretUnlockInfo.Name + ", ";
										secretUnlockInfo.Name = text3;
										list3 = list4;
									}
								}
								secretType2++;
								dictionary = convertedWeapons;
								secretType = secretType2;
								continue;
							}
							goto IL_2986;
						}
					}
				}
				goto IL_293c;
			}
		}
		goto IL_0fc6;
		IL_19b0:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+30]");
		if ((nint)0 == 0)
		{
			goto IL_1df2;
		}
		SecretUnlockInfo secretUnlockInfo2 = new SecretUnlockInfo();
		bool flag5;
		string translation2 = LocalizationManager.GetTranslation("lang/genericPopup_unlockedHyper", FixForRTL: true, 0, ignoreRTLnumbers: true, flag5, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		if (_data != null)
		{
			Dictionary<StageType, List<StageData>> convertedStages = _data.GetConvertedStages();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+30]");
			if ((nint)0 == 0)
			{
				goto IL_2980;
			}
			if (convertedStages != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+30]");
				System.Int32Enum key = (System.Int32Enum)((nint)0 >> 32);
				object obj7 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item(key);
				if (obj7 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ rax_v146 (System.Object)+18]");
					bool flag6 = (nint)0 <= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ rax_v146 (System.Object)+10]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ rax_v146 (System.Object)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rax_v147+18]");
						if ((nint)0 <= (nint)0)
						{
							goto IL_2986;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+30]");
						if ((nint)0 == 0)
						{
							goto IL_2980;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+30]");
						SecretType sType = (SecretType)((nint)0 >> 32);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rax_v147+20]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C74]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rax_v147+20]");
							string prefix = ((StageData)0).GetPrefix((StageType)sType);
							string term = prefix + "stageName";
							string translation3 = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, flag5, localParametersRoot, overrideLanguage, allowLocalizedParameters);
							if (translation2 != null)
							{
								string text4 = translation2.Replace("%0", translation3);
								if (secretUnlockInfo2 != null)
								{
									secretUnlockInfo2.Name = text4;
									if (_data != null)
									{
										Dictionary<StageType, List<StageData>> convertedStages2 = _data.GetConvertedStages();
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+30]");
										if ((nint)0 == 0)
										{
											goto IL_2980;
										}
										if (convertedStages2 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+30]");
											System.Int32Enum key2 = (System.Int32Enum)((nint)0 >> 32);
											object obj9 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages2).get_Item(key2);
											if (obj9 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v155 (System.Object)+18]");
												bool flag7 = (nint)0 <= (nint)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v155 (System.Object)+10]");
												object obj10 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v155 (System.Object)+10]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v523 @ rax_v156+18]");
													if ((nint)0 <= (nint)0)
													{
														goto IL_2986;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v523 @ rax_v156+20]");
													object obj11 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v523 @ rax_v156+20]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rax_v157+58]");
														secretUnlockInfo2.FrameName = (string)0;
														secretUnlockInfo2.TextureName = "UI";
														if (list != null)
														{
															List<WeaponData> list5 = ((Dictionary<WeaponType, List<WeaponData>>)(object)list).get_Item((WeaponType)secretUnlockInfo2);
															goto IL_1df2;
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
			}
		}
		goto IL_293c;
		IL_0283:
		if (CS_0024_003C_003E8__locals15.t != SecretType.ForbiddenBox)
		{
			AchievementManager achievementManager;
			AchievementType achievement;
			if (CS_0024_003C_003E8__locals15.t == SecretType.FreezeArrow)
			{
				achievementManager = _achievementManager;
				if (_achievementManager == null)
				{
					goto IL_293c;
				}
				achievement = AchievementType.ObtainGraciasMirror;
			}
			else
			{
				if (CS_0024_003C_003E8__locals15.t != SecretType.DootDoot)
				{
					goto IL_035d;
				}
				achievementManager = _achievementManager;
				if (_achievementManager == null)
				{
					goto IL_293c;
				}
				achievement = AchievementType.ObtainSeventhTrumpet;
			}
			achievementManager.UnlockAchievement(achievement);
			goto IL_035d;
		}
		DoDevilEffect();
		Sequence s = DOTween.Sequence();
		Sequence sequence = TweenSettingsExtensions.AppendInterval(s, 3f);
		TweenCallback callback = delegate
		{
			MultiplayerManager.s_instance.EnableAllUIInteraction();
			SecretsPage secretsPage = CS_0024_003C_003E8__locals15._003C_003E4__this;
			secretsPage._spellsManager.StartSpell(CS_0024_003C_003E8__locals15.t);
		};
		Sequence sequence2 = TweenSettingsExtensions.AppendCallback(s, callback);
		return;
		IL_293c:
		throw new NullReferenceException();
		IL_126d:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+40]");
		bool flag8 = (nint)0 == 0;
		flag5 = (byte)(int)num != 0;
		if (flag8)
		{
			goto IL_1558;
		}
		SecretUnlockInfo secretUnlockInfo3 = new SecretUnlockInfo();
		string translation4 = LocalizationManager.GetTranslation("lang/genericPopup_unlocked", FixForRTL: true, 0, ignoreRTLnumbers: true, (byte)(int)num != 0, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		DataManager data = _data;
		if (_data != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+40]");
			if ((nint)0 == 0)
			{
				goto IL_2980;
			}
			if (data._003CAllArcanas_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+40]");
				System.Int32Enum key3 = (System.Int32Enum)((nint)0 >> 32);
				object obj12 = ((Dictionary<System.Int32Enum, object>)(object)data._003CAllArcanas_003Ek__BackingField).get_Item(key3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+40]");
				if ((nint)0 == 0)
				{
					goto IL_2980;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+40]");
				SecretType t2 = (SecretType)((nint)0 >> 32);
				if (obj12 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C17]");
					bool flag9 = (nint)0 != 0;
					flag5 = (byte)(int)num != 0;
					if (!flag9)
					{
						_ = 1;
						flag5 = (byte)(int)num != 0;
					}
					string localPrefix = ((ArcanaData)obj12).GetLocalPrefix((ArcanaType)t2);
					string term2 = localPrefix + "name";
					string translation5 = LocalizationManager.GetTranslation(term2, FixForRTL: true, 0, ignoreRTLnumbers: true, flag5, localParametersRoot, overrideLanguage, allowLocalizedParameters);
					string text5 = translation4 + " " + translation5;
					if (secretUnlockInfo3 != null)
					{
						secretUnlockInfo3.Name = text5;
						DataManager data2 = _data;
						if (_data != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+40]");
							if ((nint)0 == 0)
							{
								goto IL_2980;
							}
							if (data2._003CAllArcanas_003Ek__BackingField != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+40]");
								System.Int32Enum key4 = (System.Int32Enum)((nint)0 >> 32);
								object obj13 = ((Dictionary<System.Int32Enum, object>)(object)data2._003CAllArcanas_003Ek__BackingField).get_Item(key4);
								if (obj13 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rax_v224 (System.Object)+40]");
									secretUnlockInfo3.FrameName = (string)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rax_v224 (System.Object)+38]");
									secretUnlockInfo3.TextureName = (string)0;
									if (list != null)
									{
										List<WeaponData> list6 = ((Dictionary<WeaponType, List<WeaponData>>)(object)list).get_Item((WeaponType)secretUnlockInfo3);
										goto IL_1558;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_293c;
		IL_07cd:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+20]");
		if ((nint)0 == 0)
		{
			goto IL_0b0c;
		}
		SecretUnlockInfo secretUnlockInfo4 = new SecretUnlockInfo();
		string translation6 = LocalizationManager.GetTranslation("lang/genericPopup_unlocked", FixForRTL: true, 0, ignoreRTLnumbers: true, (byte)(int)num != 0, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		if (_data != null)
		{
			Dictionary<WeaponType, List<WeaponData>> convertedWeapons2 = _data.GetConvertedWeapons();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+20]");
			if ((nint)0 == 0)
			{
				goto IL_2980;
			}
			if (convertedWeapons2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+20]");
				System.Int32Enum key5 = (System.Int32Enum)((nint)0 >> 32);
				object obj14 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons2).get_Item(key5);
				if (obj14 != null)
				{
					List<WeaponData> list7 = ((Dictionary<WeaponType, List<WeaponData>>)obj14).get_Item(WeaponType.VOID);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+20]");
					if ((nint)0 == 0)
					{
						goto IL_2980;
					}
					if (list7 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+20]");
						WeaponType wType = (WeaponType)((nint)0 >> 32);
						string localizedNameTerm2 = ((WeaponData)(object)list7).GetLocalizedNameTerm(wType);
						string translation7 = LocalizationManager.GetTranslation(localizedNameTerm2, FixForRTL: true, 0, ignoreRTLnumbers: true, (byte)(int)num != 0, localParametersRoot, overrideLanguage, allowLocalizedParameters);
						string text6 = translation6 + " " + translation7;
						if (secretUnlockInfo4 != null && _data != null)
						{
							Dictionary<WeaponType, List<WeaponData>> convertedWeapons3 = _data.GetConvertedWeapons();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+20]");
							if ((nint)0 == 0)
							{
								goto IL_2980;
							}
							if (convertedWeapons3 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+20]");
								System.Int32Enum key6 = (System.Int32Enum)((nint)0 >> 32);
								object obj15 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons3).get_Item(key6);
								if (obj15 != null)
								{
									List<WeaponData> list8 = ((Dictionary<WeaponType, List<WeaponData>>)obj15).get_Item(WeaponType.VOID);
									if (list8 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v484 @ rax_v326 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+40]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v484 @ rax_v326 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+38]");
										Dictionary<WeaponType, List<WeaponData>> dictionary = (Dictionary<WeaponType, List<WeaponData>>)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v484 @ rax_v326 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+38]");
										_ = 0;
										if (list2 != null)
										{
											List<WeaponData> list9 = ((Dictionary<WeaponType, List<WeaponData>>)(object)list2).get_Item((WeaponType)secretUnlockInfo4);
											goto IL_0b0c;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_293c;
		IL_1558:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+28]");
		if ((nint)0 == 0)
		{
			goto IL_19b0;
		}
		SecretUnlockInfo secretUnlockInfo5 = new SecretUnlockInfo();
		string translation8 = LocalizationManager.GetTranslation("lang/genericPopup_unlocked", FixForRTL: true, 0, ignoreRTLnumbers: true, flag5, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		if (_data != null)
		{
			Dictionary<StageType, List<StageData>> convertedStages3 = _data.GetConvertedStages();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+28]");
			if ((nint)0 == 0)
			{
				goto IL_2980;
			}
			if (convertedStages3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+28]");
				System.Int32Enum key7 = (System.Int32Enum)((nint)0 >> 32);
				object obj16 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages3).get_Item(key7);
				if (obj16 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ rax_v181 (System.Object)+18]");
					bool flag10 = (nint)0 <= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ rax_v181 (System.Object)+10]");
					object obj17 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ rax_v181 (System.Object)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rax_v182+18]");
						if ((nint)0 <= (nint)0)
						{
							goto IL_2986;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+28]");
						if ((nint)0 == 0)
						{
							goto IL_2980;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+28]");
						SecretType sType2 = (SecretType)((nint)0 >> 32);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rax_v182+20]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C74]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rax_v182+20]");
							string prefix2 = ((StageData)0).GetPrefix((StageType)sType2);
							string term3 = prefix2 + "stageName";
							string translation9 = LocalizationManager.GetTranslation(term3, FixForRTL: true, 0, ignoreRTLnumbers: true, flag5, localParametersRoot, overrideLanguage, allowLocalizedParameters);
							string text7 = translation8 + " " + translation9;
							if (secretUnlockInfo5 != null)
							{
								secretUnlockInfo5.Name = text7;
								if (_data != null)
								{
									Dictionary<StageType, List<StageData>> convertedStages4 = _data.GetConvertedStages();
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+28]");
									if ((nint)0 == 0)
									{
										goto IL_2980;
									}
									if (convertedStages4 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+28]");
										System.Int32Enum key8 = (System.Int32Enum)((nint)0 >> 32);
										object obj18 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages4).get_Item(key8);
										if (obj18 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v511 @ rax_v190 (System.Object)+18]");
											bool flag11 = (nint)0 <= (nint)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v511 @ rax_v190 (System.Object)+10]");
											object obj19 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v511 @ rax_v190 (System.Object)+10]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v512 @ rax_v191+18]");
												if ((nint)0 <= (nint)0)
												{
													goto IL_2986;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v512 @ rax_v191+20]");
												object obj20 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v512 @ rax_v191+20]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ rcx_v162+60]");
													string frameName = (string)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ rcx_v162+60]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ rcx_v162+58]");
														frameName = (string)0;
													}
													secretUnlockInfo5.FrameName = frameName;
													secretUnlockInfo5.TextureName = "UI";
													if (list != null)
													{
														List<WeaponData> list10 = ((Dictionary<WeaponType, List<WeaponData>>)(object)list).get_Item((WeaponType)secretUnlockInfo5);
														goto IL_19b0;
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
		}
		goto IL_293c;
		IL_0fc6:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+38]");
		if ((nint)0 == 0)
		{
			goto IL_126d;
		}
		SecretUnlockInfo secretUnlockInfo6 = new SecretUnlockInfo();
		string translation10 = LocalizationManager.GetTranslation("lang/genericPopup_unlocked", FixForRTL: true, 0, ignoreRTLnumbers: true, (byte)(int)num != 0, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		DataManager data3 = _data;
		if (_data != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+38]");
			if ((nint)0 == 0)
			{
				goto IL_2980;
			}
			if (data3._003CAllItems_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+38]");
				System.Int32Enum key9 = (System.Int32Enum)((nint)0 >> 32);
				object obj21 = ((Dictionary<System.Int32Enum, object>)(object)data3._003CAllItems_003Ek__BackingField).get_Item(key9);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+38]");
				if ((nint)0 == 0)
				{
					goto IL_2980;
				}
				if (obj21 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+38]");
					ItemType type = (ItemType)((nint)0 >> 32);
					string localizedName = ((ItemData)obj21).GetLocalizedName(type);
					string text8 = translation10 + " " + localizedName;
					if (secretUnlockInfo6 != null)
					{
						DataManager data4 = _data;
						if (_data != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+38]");
							if ((nint)0 == 0)
							{
								goto IL_2980;
							}
							if (data4._003CAllItems_003Ek__BackingField != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+38]");
								System.Int32Enum key10 = (System.Int32Enum)((nint)0 >> 32);
								object obj22 = ((Dictionary<System.Int32Enum, object>)(object)data4._003CAllItems_003Ek__BackingField).get_Item(key10);
								if (obj22 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v251 (System.Object)+38]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v251 (System.Object)+30]");
									_ = 0;
									if (list != null)
									{
										List<WeaponData> list11 = ((Dictionary<WeaponType, List<WeaponData>>)(object)list).get_Item((WeaponType)secretUnlockInfo6);
										goto IL_126d;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_293c;
		IL_0eba:
		if (list3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3448 @ r15_v26 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+40]");
			secretUnlockInfo.FrameName = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3448 @ r15_v26 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+38]");
			secretUnlockInfo.TextureName = (string)0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+90]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+90]");
			secretUnlockInfo.TextureName = (string)0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+98]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+98]");
			secretUnlockInfo.FrameName = (string)0;
		}
		if (list2 != null)
		{
			List<WeaponData> list12 = ((Dictionary<WeaponType, List<WeaponData>>)(object)list2).get_Item((WeaponType)secretUnlockInfo);
			list = list2;
			goto IL_0fc6;
		}
		goto IL_293c;
		IL_2980:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		goto IL_2986;
		IL_035d:
		list2 = new List<SecretUnlockInfo>();
		if (_secrets != null)
		{
			object obj23 = ((Dictionary<System.Int32Enum, object>)(object)_secrets).get_Item((System.Int32Enum)CS_0024_003C_003E8__locals15.t);
			if (obj23 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+74]");
				if ((nint)0 == 0)
				{
					if (_playerOptions != null)
					{
						PlayerOptionsData config = _playerOptions.Config;
						if (config != null && config._003CSecrets_003Ek__BackingField != null)
						{
							SecretData secretData = ((Dictionary<SecretType, SecretData>)(object)config._003CSecrets_003Ek__BackingField).get_Item(CS_0024_003C_003E8__locals15.t);
							if (secretData != null)
							{
								return;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+18]");
							if ((nint)0 == 0)
							{
								goto IL_07cd;
							}
							SecretUnlockInfo secretUnlockInfo7 = new SecretUnlockInfo();
							string translation11 = LocalizationManager.GetTranslation("lang/genericPopup_unlocked", FixForRTL: true, 0, ignoreRTLnumbers: true, (byte)(int)num != 0, localParametersRoot, overrideLanguage, allowLocalizedParameters);
							if (_data != null)
							{
								Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _data.GetConvertedCharacterData();
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+18]");
								if ((nint)0 == 0)
								{
									goto IL_2980;
								}
								if (convertedCharacterData != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+18]");
									System.Int32Enum key11 = (System.Int32Enum)((nint)0 >> 32);
									object obj24 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item(key11);
									if (obj24 != null)
									{
										List<CharacterData> list13 = ((Dictionary<CharacterType, List<CharacterData>>)obj24).get_Item((CharacterType)key11);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+18]");
										if ((nint)0 == 0)
										{
											goto IL_2980;
										}
										if (list13 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+18]");
											CharacterType t3 = (CharacterType)((nint)0 >> 32);
											string firstNameLocKey = ((CharacterData)(object)list13).GetFirstNameLocKey(t3);
											string translation12 = LocalizationManager.GetTranslation(firstNameLocKey, FixForRTL: true, 0, ignoreRTLnumbers: true, (byte)(int)num != 0, localParametersRoot, overrideLanguage, allowLocalizedParameters);
											string text9 = translation11 + " " + translation12;
											if (secretUnlockInfo7 != null && _data != null)
											{
												Dictionary<CharacterType, List<CharacterData>> convertedCharacterData2 = _data.GetConvertedCharacterData();
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+18]");
												if ((nint)0 == 0)
												{
													goto IL_2980;
												}
												if (convertedCharacterData2 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+18]");
													System.Int32Enum key12 = (System.Int32Enum)((nint)0 >> 32);
													object obj25 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData2).get_Item(key12);
													if (obj25 != null)
													{
														List<CharacterData> list14 = ((Dictionary<CharacterType, List<CharacterData>>)obj25).get_Item((CharacterType)key12);
														if (list14 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rax_v343 (System.Collections.Generic.List`1<VampireSurvivors.Data.Characters.CharacterData>)+48]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rax_v343 (System.Collections.Generic.List`1<VampireSurvivors.Data.Characters.CharacterData>)+40]");
															Dictionary<WeaponType, List<WeaponData>> dictionary = (Dictionary<WeaponType, List<WeaponData>>)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rax_v343 (System.Collections.Generic.List`1<VampireSurvivors.Data.Characters.CharacterData>)+40]");
															_ = 0;
															if (list2 != null)
															{
																List<CharacterData> list15 = ((Dictionary<CharacterType, List<CharacterData>>)(object)list2).get_Item((CharacterType)secretUnlockInfo7);
																goto IL_07cd;
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
				}
				else if (_spellsManager != null)
				{
					_spellsManager.StartSpell(CS_0024_003C_003E8__locals15.t);
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
					soundConfig.Volume = (float?)(object)1;
					soundConfig.Rate = 1f;
					float num5 = UnityEngine.Random.Range(0f, 1f);
					float num6 = num5 - 0.5f;
					float detune = num6 * 500f;
					soundConfig.Detune = detune;
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Secret, soundConfig, 0f, 10, num);
					return;
				}
			}
		}
		goto IL_293c;
		IL_25f0:
		_isBusy = true;
		if ((object)_UnlockPopup != null)
		{
			GameObject gameObject = _UnlockPopup.gameObject;
			if ((object)gameObject != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v542 @ rax_v56 (UnityEngine.GameObject)+10]");
				bool flag12 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v542 @ rax_v56 (UnityEngine.GameObject)+10]");
				GameObject.SetActive_Injected((IntPtr)0, true);
				Action onComplete = HideTwirls;
				if ((object)_UnlockPopup != null)
				{
					_UnlockPopup.SetSecrets(list, onComplete);
					if (_playerOptions != null)
					{
						PlayerOptionsData config2 = _playerOptions.Config;
						bool flag13 = _playerOptions.UnlockSecret(CS_0024_003C_003E8__locals15.t, config2);
						ShowTwirls();
						SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig
						{
							Volume = (float?)(object)1,
							Rate = 1f
						};
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
						object obj26 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
						bool flag14 = (nint)0 != 0;
						float? num7 = (float?)(object)1;
						if (!flag14)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							bool flag15 = obj26 == null;
							num7 = (float?)(object)6573110936L;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v4283 @ rax_v69 (should have been resolved before IL gen)");
						float num8 = 0f - 0.5f;
						float f = num8 * 500f;
						PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Secret, soundConfig2, 0f, 10, flag5 ? 1 : 0);
						if ((object)_Slider != null)
						{
							float value = _Slider.value;
							ClearSpawned();
							Populate();
							IEnumerator routine = WaitAndResetSliderValue(f);
							Coroutine coroutine = StartCoroutine(routine);
							LayoutRebuilder.ForceRebuildLayoutImmediate(_content);
							IEnumerator routine2 = WaitAndReselectSpells();
							Coroutine coroutine2 = StartCoroutine(routine2);
							return;
						}
					}
				}
			}
		}
		goto IL_293c;
		IL_2217:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+78]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+78]");
			object obj27 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ rax_v88+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ rax_v88+18]");
				bool flag16 = (nint)0 <= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ rax_v88+10]");
				object obj28 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ rax_v88+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ r15_v17+18]");
					if ((nint)0 <= (nint)0)
					{
						goto IL_2986;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ r15_v17+20]");
					object obj29 = 0;
					if (_data != null)
					{
						Dictionary<CharacterType, List<CharacterData>> convertedCharacterData3 = _data.GetConvertedCharacterData();
						if (convertedCharacterData3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ r15_v17+20]");
							if ((nint)0 == 0)
							{
								goto IL_293c;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ r15_v18+10]");
							object obj30 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData3).get_Item((System.Int32Enum)0);
							if (obj30 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ r15_v18+10]");
								List<CharacterData> list16 = ((Dictionary<CharacterType, List<CharacterData>>)obj30).get_Item(CharacterType.VOID);
								if (list16 != null)
								{
									SecretUnlockInfo secretUnlockInfo8 = new SecretUnlockInfo();
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ r15_v18+14]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ r15_v18+10]");
									string fullName = ((CharacterData)(object)list16).GetFullName(CharacterType.VOID, false, true);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3350 @ rax_v91 (System.Collections.Generic.List`1<VampireSurvivors.Data.Characters.CharacterData>)+184]");
									_ = 0;
									string translation13 = LocalizationManager.GetTranslation("lang/genericPopup_unlocked", FixForRTL: true, 0, ignoreRTLnumbers: true, flag5, localParametersRoot, overrideLanguage, allowLocalizedParameters);
									string text10 = translation13 + " " + fullName;
									if (secretUnlockInfo8 != null)
									{
										secretUnlockInfo8.Name = text10;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ r15_v18+14]");
										Skin skinData = ((CharacterData)(object)list16).GetSkinData(SkinType.DEFAULT);
										if (skinData != null)
										{
											string text11 = skinData._003CspriteName_003Ek__BackingField;
											if (skinData._003CspriteName_003Ek__BackingField != null && text11._stringLength > 0)
											{
												string text12 = skinData._003CtextureName_003Ek__BackingField;
												if (skinData._003CtextureName_003Ek__BackingField != null && text12._stringLength > 0)
												{
													secretUnlockInfo8.FrameName = skinData._003CspriteName_003Ek__BackingField;
													secretUnlockInfo8.TextureName = skinData._003CtextureName_003Ek__BackingField;
												}
											}
										}
										if (list != null)
										{
											List<WeaponData> list17 = ((Dictionary<WeaponType, List<WeaponData>>)(object)list).get_Item((WeaponType)secretUnlockInfo8);
											goto IL_25f0;
										}
									}
									goto IL_293c;
								}
							}
						}
						goto IL_25f0;
					}
				}
				goto IL_293c;
			}
		}
		goto IL_25f0;
		IL_1df2:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+48]");
		if ((nint)0 == 0)
		{
			goto IL_2217;
		}
		SecretUnlockInfo secretUnlockInfo9 = new SecretUnlockInfo();
		string translation14 = LocalizationManager.GetTranslation("lang/genericPopup_unlocked", FixForRTL: true, 0, ignoreRTLnumbers: true, flag5, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		if (_data != null)
		{
			Dictionary<PowerUpType, List<PowerUpData>> convertedPowerUpData = _data.GetConvertedPowerUpData();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+48]");
			if ((nint)0 == 0)
			{
				goto IL_2980;
			}
			if (convertedPowerUpData != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+48]");
				System.Int32Enum key13 = (System.Int32Enum)((nint)0 >> 32);
				object obj31 = ((Dictionary<System.Int32Enum, object>)(object)convertedPowerUpData).get_Item(key13);
				if (obj31 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v528 @ rax_v111 (System.Object)+18]");
					bool flag17 = (nint)0 <= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v528 @ rax_v111 (System.Object)+10]");
					object obj32 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v528 @ rax_v111 (System.Object)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rax_v112+18]");
						if ((nint)0 <= (nint)0)
						{
							goto IL_2986;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+48]");
						if ((nint)0 == 0)
						{
							goto IL_2980;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+48]");
						SecretType type2 = (SecretType)((nint)0 >> 32);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rax_v112+20]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C7B]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rax_v112+20]");
							string prefix3 = ((PowerUpData)0).GetPrefix((PowerUpType)type2);
							string term4 = prefix3 + "name";
							string translation15 = LocalizationManager.GetTranslation(term4, FixForRTL: true, 0, ignoreRTLnumbers: true, flag5, localParametersRoot, overrideLanguage, allowLocalizedParameters);
							string text13 = translation14 + " " + translation15;
							if (secretUnlockInfo9 != null)
							{
								secretUnlockInfo9.Name = text13;
								if (_data != null)
								{
									Dictionary<PowerUpType, List<PowerUpData>> convertedPowerUpData2 = _data.GetConvertedPowerUpData();
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+48]");
									if ((nint)0 == 0)
									{
										goto IL_2980;
									}
									if (convertedPowerUpData2 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v38 (System.Object)+48]");
										System.Int32Enum key14 = (System.Int32Enum)((nint)0 >> 32);
										object obj33 = ((Dictionary<System.Int32Enum, object>)(object)convertedPowerUpData2).get_Item(key14);
										if (obj33 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v533 @ rax_v120 (System.Object)+18]");
											bool flag18 = (nint)0 <= (nint)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v533 @ rax_v120 (System.Object)+10]");
											object obj34 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v533 @ rax_v120 (System.Object)+10]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ rax_v121+18]");
												if ((nint)0 <= (nint)0)
												{
													goto IL_2986;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ rax_v121+20]");
												object obj35 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ rax_v121+20]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ rax_v122+38]");
													secretUnlockInfo9.FrameName = (string)0;
													secretUnlockInfo9.TextureName = "items";
													if (list != null)
													{
														List<WeaponData> list18 = ((Dictionary<WeaponType, List<WeaponData>>)(object)list).get_Item((WeaponType)secretUnlockInfo9);
														goto IL_2217;
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
		}
		goto IL_293c;
		IL_2986:
		throw new IndexOutOfRangeException();
	}

	private void PostUnlock()
	{
		//IL_00f4: Expected O, but got I4
		//IL_0112: Expected O, but got I
		//IL_0135: Expected O, but got I4
		//IL_003e: Expected O, but got I8
		ShowTwirls();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		float? num = (float?)(object)1;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			num = (float?)(object)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v64 @ rax_v8 (should have been resolved before IL gen)");
		float num2 = 0f - 0.5f;
		float f = (soundConfig.Detune = num2 * 500f);
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Secret, soundConfig, 0f, 10, time);
		float value = _Slider.value;
		ClearSpawned();
		Populate();
		IEnumerator routine = WaitAndResetSliderValue(f);
		Coroutine coroutine = StartCoroutine(routine);
		LayoutRebuilder.ForceRebuildLayoutImmediate(_content);
		IEnumerator routine2 = WaitAndReselectSpells();
		Coroutine coroutine2 = StartCoroutine(routine2);
	}

	private void CheckUnlockedSecretAchievements(SecretType t)
	{
		switch (t)
		{
		case SecretType.FreezeArrow:
			_achievementManager.UnlockAchievement(AchievementType.ObtainGraciasMirror);
			break;
		case SecretType.DootDoot:
			_achievementManager.UnlockAchievement(AchievementType.ObtainSeventhTrumpet);
			break;
		}
	}

	private IEnumerator WaitAndReselectSpells()
	{
		_003CWaitAndReselectSpells_003Ed__90 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void everything()
	{
		DataManager data = _data;
		if (_data != null && data._003CAllWeaponData_003Ek__BackingField != null)
		{
			Dictionary<WeaponType, Newtonsoft.Json.Linq.JArray>.Enumerator enumerator = default(Dictionary<WeaponType, Newtonsoft.Json.Linq.JArray>.Enumerator);
			while (enumerator.MoveNext())
			{
				if (_playerOptions != null)
				{
					_playerOptions.UnlockWeapon(WeaponType.VOID);
					continue;
				}
				throw new NullReferenceException();
			}
			if (_playerOptions != null)
			{
				_playerOptions.Save();
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void everywhere()
	{
		_playerOptions.UnlockHyper(StageType.FOREST);
		_playerOptions.UnlockStage(StageType.LIBRARY);
		_playerOptions.UnlockHyper(StageType.LIBRARY);
		_playerOptions.UnlockStage(StageType.WAREHOUSE);
		_playerOptions.UnlockHyper(StageType.WAREHOUSE);
		_playerOptions.UnlockStage(StageType.TOWER);
		_playerOptions.UnlockHyper(StageType.TOWER);
		_playerOptions.UnlockStage(StageType.CHAPEL);
		_playerOptions.UnlockHyper(StageType.CHAPEL);
		_playerOptions.Save();
	}

	private IEnumerator WaitAndResetSliderValue(float f)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002e: Expected O, but got I8
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_010a: Expected O, but got I4
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		_003CWaitAndResetSliderValue_003Ed__93 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		if (!flag)
		{
			object obj2 = obj + 32;
			object obj3 = obj2 >> 12;
			object obj4 = 6603864928L;
			object obj5 = obj3 & 0x1FFFFF;
			object obj6 = obj5 >> 6;
			object obj7 = obj5 & 0x3F;
			nint num2;
			do
			{
				object obj8 = 1 << (int)obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				object obj9 = 0 | obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				if (num == 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
			}
			while (num2 != 0);
			obj.f = f;
			return obj;
		}
		obj.f = f;
		return obj;
	}

	private void ShowTwirls()
	{
		//IL_00ac: Expected O, but got I4
		//IL_0049: Expected I, but got O
		string[] tints = _tints;
		object obj = UnityEngine.Random.RandomRangeInt(0, tints.Length);
		bool flag = (nint)obj >= tints.Length;
		Color color = ColourHelper.HexToColor(tints[obj]);
		List<Image>.Enumerator enumerator = default(List<Image>.Enumerator);
		while (enumerator.MoveNext())
		{
			MissingMethodException ex = null;
			nint num = (nint)ex;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v444 @ r8_v8 (Il2CppClass<System.MissingMethodException>)+2A8] (should have been resolved before IL gen)");
		}
		CanvasGroup component = _TwirlContainer.GetComponent<CanvasGroup>();
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleUI.DOFade(component, 1f, 0.8f);
	}

	private void HideTwirls()
	{
		CanvasGroup component = _TwirlContainer.GetComponent<CanvasGroup>();
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleUI.DOFade(component, 0f, 2f);
		TweenCallback tweenCallback = delegate
		{
			_isBusy = false;
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
	}

	private void SetNextCharacter(GameObject sender)
	{
		//IL_02c7: Expected O, but got I4
		//IL_0121: Expected O, but got I
		//IL_0136: Expected O, but got I
		if (_characterIndex >= _maxLength)
		{
			ClearSpell();
		}
		List<GameObject> spellGameCharacters = _spellGameCharacters;
		if (_characterIndex >= spellGameCharacters._size)
		{
			AddSpellCharacter();
		}
		Text componentInChildren = sender.GetComponentInChildren<Text>(includeInactive: false);
		string text = componentInChildren.text;
		List<char> characters = _characters;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v14 (System.Collections.Generic.List`1<System.Char>)+18]");
		object obj = UnityEngine.Random.RandomRangeInt(0, 0);
		List<GameObject> spellGameCharacters2 = _spellGameCharacters;
		int characterIndex = _characterIndex;
		bool flag = _characterIndex >= spellGameCharacters2._size;
		GameObject[] items = spellGameCharacters2._items;
		Text componentInChildren2 = items[characterIndex].GetComponentInChildren<Text>(includeInactive: false);
		List<char> characters2 = _characters;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rcx_v21 (System.Collections.Generic.List`1<System.Char>)+18]");
		bool flag2 = (nint)obj >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rcx_v21 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEF8]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ rcx_v23+E4]");
		if ((nint)0 == 0)
		{
		}
		string text2 = string.FastAllocateString(1);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rcx_v22+20+v125 @ rax_v22*2]");
		text2._firstChar = '\0';
		string text3 = text2.ToUpperInvariant();
		componentInChildren2.text = text3;
		int characterIndex2 = _characterIndex + 1;
		_characterIndex = characterIndex2;
		string text4 = text.ToString();
		string spellString = string.Concat(str1: text4.ToLowerInvariant(), str0: _spellString);
		_spellString = spellString;
		string message = "Current spell : " + _spellString;
		Debug.Log(message);
		Vector2 intensity = default(Vector2);
		Action callback = default(Action);
		_PanelShake.StartShake(0.15f, intensity, force: false, callback);
		FormatSpell();
		CheckSpells();
		IEnumerator routine = WaitForParticles();
		Coroutine coroutine = StartCoroutine(routine);
		PlayHitSound();
	}

	private void SetNextCharacter(string s)
	{
		//IL_02b6: Expected O, but got I4
		//IL_0121: Expected O, but got I
		//IL_0136: Expected O, but got I
		Debug.Log("Setting next char");
		if (_characterIndex >= _maxLength)
		{
			ClearSpell();
		}
		List<GameObject> spellGameCharacters = _spellGameCharacters;
		if (_characterIndex >= spellGameCharacters._size)
		{
			AddSpellCharacter();
		}
		List<char> characters = _characters;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v18 (System.Collections.Generic.List`1<System.Char>)+18]");
		object obj = UnityEngine.Random.RandomRangeInt(0, 0);
		List<GameObject> spellGameCharacters2 = _spellGameCharacters;
		int characterIndex = _characterIndex;
		bool flag = _characterIndex >= spellGameCharacters2._size;
		GameObject[] items = spellGameCharacters2._items;
		Text componentInChildren = items[characterIndex].GetComponentInChildren<Text>(includeInactive: false);
		List<char> characters2 = _characters;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rcx_v19 (System.Collections.Generic.List`1<System.Char>)+18]");
		bool flag2 = (nint)obj >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rcx_v19 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEF8]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v521 @ rcx_v21+E4]");
		if ((nint)0 == 0)
		{
		}
		string text = string.FastAllocateString(1);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rcx_v20+20+v169 @ rax_v21*2]");
		text._firstChar = '\0';
		string text2 = text.ToUpperInvariant();
		componentInChildren.text = text2;
		int characterIndex2 = _characterIndex + 1;
		_characterIndex = characterIndex2;
		string text3 = s.ToString();
		string spellString = string.Concat(str1: text3.ToLowerInvariant(), str0: _spellString);
		_spellString = spellString;
		string message = "Current spell : " + _spellString;
		Debug.Log(message);
		Vector2 intensity = default(Vector2);
		Action callback = default(Action);
		_PanelShake.StartShake(0.15f, intensity, force: false, callback);
		FormatSpell();
		CheckSpells();
		IEnumerator routine = WaitForParticles();
		Coroutine coroutine = StartCoroutine(routine);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 497 Invalid \"Jump target not found in method: 0x186D92810\"");
		throw new NullReferenceException();
	}

	private IEnumerator DisableGravityWell()
	{
		_003CDisableGravityWell_003Ed__98 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void PlayHitSound()
	{
		//IL_008f: Expected O, but got I4
		//IL_00ad: Expected O, but got I
		//IL_00d0: Expected O, but got I4
		//IL_003e: Expected O, but got I8
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		float? num = (float?)(object)1;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			num = (float?)(object)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v56 @ rax_v4 (should have been resolved before IL gen)");
		float num2 = 0f - 0.5f;
		float detune = num2 * 500f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LittleHit, soundConfig, 0f, 10, time);
	}

	private void Backspace()
	{
		//IL_0104: Expected O, but got I4
		//IL_00a2: Expected O, but got I
		if (_characterIndex <= 0)
		{
			return;
		}
		int characterIndex = _characterIndex;
		List<GameObject> spellGameCharacters = _spellGameCharacters;
		int num = --_characterIndex;
		if (num <= _baseLength)
		{
			if (num < spellGameCharacters._size)
			{
				GameObject[] items = spellGameCharacters._items;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rdx_v15 (UnityEngine.GameObject[])+18+v52 @ r8_v2 (System.Int32)*8]");
				Text componentInChildren = ((GameObject)0).GetComponentInChildren<Text>(includeInactive: false);
				componentInChildren.text = "a";
				goto IL_0145;
			}
		}
		else if (num < spellGameCharacters._size)
		{
			GameObject[] items2 = spellGameCharacters._items;
			object obj = _characterIndex - 1;
			UnityEngine.Object.Destroy(items2[obj], 0f);
			_spellGameCharacters.RemoveAt(_characterIndex);
			goto IL_0145;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_0145:
		string spellString = _spellString;
		int startIndex = spellString._stringLength - 1;
		string spellString2 = _spellString.Remove(startIndex);
		_spellString = spellString2;
		IEnumerator enumerator = WaitForParticles();
		Vector2 intensity = default(Vector2);
		Action callback = default(Action);
		_PanelShake.StartShake(0.15f, intensity, force: false, callback);
		PlayHitSound();
	}

	private IEnumerator WaitForParticles()
	{
		_003CWaitForParticles_003Ed__101 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void PlayInputParticles(Transform character)
	{
		//IL_01e8->IL0197: Incompatible stack heights: 1 vs 0
		//IL_0078->IL0197: Incompatible stack heights: 1 vs 0
		//IL_0237->IL0197: Incompatible stack heights: 2 vs 0
		//IL_00b0->IL0197: Incompatible stack heights: 2 vs 0
		//IL_00dc->IL0197: Incompatible stack heights: 2 vs 0
		if ((object)character != null)
		{
			Transform transform = character.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if ((object)_SpellCharacterBackground != null)
				{
					Transform transform2 = _SpellCharacterBackground.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret2);
						if ((object)_inputParticles != null)
						{
							Transform transform3 = _inputParticles.transform;
							if ((object)_inputParticles != null)
							{
								Transform transform4 = _inputParticles.transform;
								if ((object)transform4 != null)
								{
									bool flag3 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out Vector3 ret3);
									bool flag4 = (object)transform3 == null;
									bool flag5 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
									Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref ret);
									Transform inputParticles = (Transform)(object)_inputParticles;
									bool flag6 = (object)_inputParticles == null;
									bool flag7 = ((UnityEngine.Object)inputParticles).m_CachedPtr == (IntPtr)0;
									ParticleSystem.Emit_Internal_Injected(((UnityEngine.Object)inputParticles).m_CachedPtr, 10);
									bool flag8 = (object)_gravityWell == null;
									Transform transform5 = _gravityWell.transform;
									Transform transform6 = character.transform;
									bool flag9 = (object)transform6 == null;
									bool flag10 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform6).m_CachedPtr, out ret2);
									bool flag11 = (object)transform5 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1253 @ rax_v69 (UnityEngine.Transform)+10]");
									bool flag12 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1253 @ rax_v69 (UnityEngine.Transform)+10]");
									Transform.set_position_Injected((IntPtr)0, ref ret3);
									bool flag13 = (object)_gravityWell == null;
									GameObject gameObject = _gravityWell.gameObject;
									bool flag14 = (object)gameObject == null;
									gameObject.SetActive(value: true);
									_003CDisableGravityWell_003Ed__98 obj = null;
									obj._003C_003E1__state = 0;
									obj._003C_003E4__this = this;
									Coroutine coroutine = StartCoroutine(obj);
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

	private RectTransform GetSpellContainer()
	{
		//IL_0024: Invalid comparison between I4 and F4
		List<GameObject> spellGameCharacters = _spellGameCharacters;
		if (_spellGameCharacters != null)
		{
			float num = (float)_maxLength * 0.5f;
			if ((float)spellGameCharacters._size < num)
			{
				return _SpellCharacterContainer;
			}
			return _SpellCharacterContainer2;
		}
		return (RectTransform)(object)new NullReferenceException();
	}

	private unsafe void FormatSpell()
	{
		//IL_023a: Expected O, but got I4
		//IL_0254: Expected O, but got I4
		//IL_00e5: Invalid comparison between O and F4
		//IL_0361->IL0361: Incompatible stack heights: 7 vs 0
		RectTransform spellContainer = GetSpellContainer();
		RectTransform spellCharacterContainer = _SpellCharacterContainer;
		bool flag = (object)spellContainer == null;
		bool flag2 = (object)_SpellCharacterContainer == null;
		object obj = flag & flag2;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)_SpellCharacterContainer != null)
			{
				if ((object)spellContainer != null)
				{
					object obj3 = (object)spellContainer - (object)_SpellCharacterContainer;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)spellCharacterContainer).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)spellContainer).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				goto IL_0361;
			}
		}
		Vector2 sizeDelta = _SpellCharacterContainer.sizeDelta;
		Vector2 sizeDelta2 = _SpellCharacterBackground.sizeDelta;
		float num = (float)sizeDelta2 - 50f;
		if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref sizeDelta) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num))
		{
			float num2 = (float)sizeDelta2 - 50f;
			float num3 = num2 / (float)sizeDelta;
			float baseCharacterSize = _baseCharacterSize * num3;
			_baseCharacterSize = baseCharacterSize;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.SecretsPage)+26C]");
			float num4 = 0f * num3;
			Vector2 baseScale = default(Vector2);
			_baseScale = baseScale;
		}
		goto IL_0361;
		IL_0361:
		List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
		List<GameObject>.Enumerator value = default(List<GameObject>.Enumerator);
		while (enumerator.MoveNext())
		{
			RectTransform component = ((GameObject)null).GetComponent<RectTransform>();
			LayoutElement component2 = ((GameObject)null).GetComponent<LayoutElement>();
			bool flag5 = (object)component2 == null;
			component2.preferredWidth = _baseCharacterSize;
			bool flag6 = (object)component == null;
			bool flag7 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)component).m_CachedPtr);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag8 = (object)transform == null;
			bool flag9 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			IntPtr child_Injected = Transform.GetChild_Injected(((UnityEngine.Object)transform).m_CachedPtr, 0);
			Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(child_Injected);
			bool flag10 = (object)transform2 == null;
			bool flag11 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value));
		}
	}

	private unsafe void CheckSpells()
	{
		//IL_0053: Expected O, but got Ref
		//IL_02b3: Expected O, but got I
		//IL_0771: Expected O, but got I
		//IL_044d: Expected O, but got I
		//IL_048a: Expected O, but got I
		//IL_04cc: Expected O, but got I
		//IL_07cd: Expected O, but got I
		//IL_0552: Expected I4, but got O
		//IL_05a6: Expected I, but got O
		//IL_05bc: Expected O, but got I
		//IL_05c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ca: Expected O, but got Unknown
		//IL_0633: Expected I, but got O
		//IL_0640: Expected O, but got I
		//IL_083b: Expected O, but got I4
		//IL_0852: Expected I, but got I8
		//IL_061c: Expected O, but got I8
		//IL_02db->IL069d: Incompatible stack heights: 1 vs 0
		//IL_0308->IL069d: Incompatible stack heights: 1 vs 0
		//IL_0376->IL069d: Incompatible stack heights: 1 vs 0
		//IL_03b1->IL069d: Incompatible stack heights: 1 vs 0
		//IL_03dd->IL069d: Incompatible stack heights: 1 vs 0
		//IL_0414->IL069d: Incompatible stack heights: 1 vs 0
		//IL_0475->IL069d: Incompatible stack heights: 2 vs 0
		//IL_04b2->IL069d: Incompatible stack heights: 2 vs 0
		//IL_0500->IL069d: Incompatible stack heights: 2 vs 0
		//IL_0536->IL069d: Incompatible stack heights: 2 vs 0
		//IL_082d->IL069d: Incompatible stack heights: 3 vs 0
		//IL_086c->IL069d: Incompatible stack heights: 3 vs 0
		//IL_067c->IL069d: Incompatible stack heights: 3 vs 0
		//IL_069c->IL069c: Incompatible stack heights: 3 vs 0
		bool flag = _spellString == null;
		DataManager spellString = (DataManager)(object)_spellString;
		List<SecretUnlockInfo> list;
		Action action;
		if (!flag)
		{
			string spellString2 = _spellString.ToLowerInvariant();
			_spellString = spellString2;
			spellString = (DataManager)(object)_spellString;
			if (_secrets != null)
			{
				Dictionary<SecretType, SecretData>.Enumerator enumerator = default(Dictionary<SecretType, SecretData>.Enumerator);
				if (enumerator.MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					SecretType secretType = SecretType.CastThiefSpell;
					Dictionary<SecretType, SecretData>.Enumerator enumerator2 = (Dictionary<SecretType, SecretData>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				}
				bool flag2 = _spellString == null;
				spellString = (DataManager)(object)_spellString;
				if (!flag2)
				{
					if (!_spellString.Contains("guinigigi"))
					{
						return;
					}
					ClearSpell();
					SecretUnlockInfo secretUnlockInfo = new SecretUnlockInfo();
					bool applyParameters = default(bool);
					GameObject localParametersRoot = default(GameObject);
					string overrideLanguage = default(string);
					bool allowLocalizedParameters = default(bool);
					string translation = LocalizationManager.GetTranslation("lang/genericPopup_unlocked", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
					spellString = _data;
					if (_data != null)
					{
						Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
						if (convertedWeapons != null)
						{
							object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)510);
							bool flag3 = obj == null;
							spellString = (DataManager)(object)convertedWeapons;
							if (!flag3)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v33 (System.Object)+18]");
								bool flag4 = (nint)0 <= (nint)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v33 (System.Object)+10]");
								object obj2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v33 (System.Object)+10]");
								bool flag5 = (nint)0 == 0;
								spellString = (DataManager)(object)convertedWeapons;
								if (!flag5)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v34+20]");
									bool flag6 = (nint)0 == 0;
									spellString = (DataManager)(object)convertedWeapons;
									if (!flag6)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C61]");
										if ((nint)0 == 0)
										{
											_ = 1;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v34+20]");
										string prefix = ((WeaponData)0).GetPrefix(WeaponType.FOLLOWER_KNIFE1);
										string term = prefix + "name";
										string translation2 = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
										string text = translation + " " + translation2;
										bool flag7 = secretUnlockInfo == null;
										spellString = (DataManager)(object)translation;
										if (!flag7)
										{
											secretUnlockInfo.Name = text;
											spellString = _data;
											if (_data != null)
											{
												Dictionary<WeaponType, List<WeaponData>> convertedWeapons2 = _data.GetConvertedWeapons();
												if (convertedWeapons2 != null)
												{
													object obj3 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons2).get_Item((System.Int32Enum)510);
													bool flag8 = obj3 == null;
													spellString = (DataManager)(object)convertedWeapons2;
													if (!flag8)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v42 (System.Object)+18]");
														bool flag9 = (nint)0 <= (nint)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v42 (System.Object)+10]");
														object obj4 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v42 (System.Object)+10]");
														bool flag10 = (nint)0 == 0;
														spellString = (DataManager)(object)convertedWeapons2;
														if (!flag10)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v43+20]");
															object obj5 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v43+20]");
															bool flag11 = (nint)0 == 0;
															spellString = (DataManager)(object)convertedWeapons2;
															if (!flag11)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r9_v13+40]");
																secretUnlockInfo.FrameName = (string)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r9_v13+38]");
																secretUnlockInfo.TextureName = (string)0;
																_isBusy = true;
																bool flag12 = (object)_UnlockPopup == null;
																spellString = (DataManager)(object)_UnlockPopup;
																if (!flag12)
																{
																	GameObject gameObject = _UnlockPopup.gameObject;
																	bool flag13 = (object)gameObject == null;
																	spellString = (DataManager)(object)_UnlockPopup;
																	if (!flag13)
																	{
																		bool flag14 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
																		GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, true);
																		list = new List<SecretUnlockInfo>();
																		bool flag15 = list == null;
																		spellString = (DataManager)(object)list;
																		if (!flag15)
																		{
																			List<WeaponData> list2 = ((Dictionary<WeaponType, List<WeaponData>>)(object)list).get_Item((WeaponType)secretUnlockInfo);
																			action = null;
																			nint num = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ r10_v9 (Il2CppMethodInfo)+8]");
																			((Delegate)action).method_ptr = (IntPtr)0;
																			((Delegate)action).method = (nint)__ldftn(SecretsPage.HideTwirls);
																			((Delegate)action).m_target = this;
																			((Delegate)action).method_code = (IntPtr)action;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ r10_v9 (Il2CppMethodInfo)+4C]");
																			object obj6 = (nint)0 >> 4;
																			object obj7 = obj6 & 1;
																			if (obj7 != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ r10_v9 (Il2CppMethodInfo)+52]");
																				if ((nint)0 == 0)
																				{
																					spellString = (DataManager)6447293664L;
																					goto IL_0832;
																				}
																			}
																			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
																			spellString = (DataManager)(nint)((Delegate)action).method_ptr;
																			goto IL_0832;
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
							}
						}
					}
				}
			}
		}
		goto IL_069d;
		IL_0832:
		object obj8 = 24;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		if ((object)_UnlockPopup != null)
		{
			_UnlockPopup.SetSecrets(list, action);
			bool flag16 = _playerOptions == null;
			spellString = (DataManager)(object)_playerOptions;
			if (!flag16)
			{
				_playerOptions.UnlockWeapon(WeaponType.FOLLOWER_KNIFE1);
				PostUnlock();
				return;
			}
		}
		goto IL_069d;
		IL_069d:
		throw new NullReferenceException();
	}

	private unsafe void ClearSpell()
	{
		//IL_0012: Expected O, but got Ref
		//IL_0094: Expected I4, but got O
		//IL_0094: Expected O, but got I
		bool flag = _spellGameCharacters == null;
		SecretsPage secretsPage = this;
		if (!flag)
		{
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			if (enumerator.MoveNext())
			{
				List<GameObject>.Enumerator enumerator2 = (List<GameObject>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			secretsPage = (SecretsPage)(object)_spellGameCharacters;
			if (_spellGameCharacters != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rcx_v3 (VampireSurvivors.UI.SecretsPage)+1C]");
				_ = (nint)0 + (nint)1;
				((MonoBehaviour)secretsPage).m_CancellationTokenSource = null;
				if ((nint)((MonoBehaviour)secretsPage).m_CancellationTokenSource > 0)
				{
					Array.Clear((Array)(nint)((UnityEngine.Object)secretsPage).m_CachedPtr, 0, (int)((MonoBehaviour)secretsPage).m_CancellationTokenSource);
				}
				_characterIndex = 0;
				_spellString = "";
				BuildSpellBase();
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void BuildSpellBase()
	{
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0079->IL0205: Incompatible stack heights: 1 vs 0
		//IL_00a0->IL0205: Incompatible stack heights: 1 vs 0
		//IL_00d4->IL0205: Incompatible stack heights: 1 vs 0
		//IL_0115->IL0205: Incompatible stack heights: 1 vs 0
		//IL_0165->IL0205: Incompatible stack heights: 2 vs 0
		//IL_019e->IL0205: Incompatible stack heights: 2 vs 0
		//IL_02c0->IL0205: Incompatible stack heights: 3 vs 0
		//IL_0325->IL0205: Incompatible stack heights: 4 vs 0
		//IL_0385->IL0205: Incompatible stack heights: 5 vs 0
		bool flag = _baseLength <= 0;
		object obj = null;
		if (!flag)
		{
			do
			{
				AddSpellCharacter();
				obj++;
			}
			while ((nint)obj < _baseLength);
		}
		List<GameObject> spellGameCharacters = _spellGameCharacters;
		if (_spellGameCharacters != null)
		{
			bool flag2 = spellGameCharacters._size <= 0;
			GameObject[] items = spellGameCharacters._items;
			if (spellGameCharacters._items != null && (object)items[0] != null)
			{
				LayoutElement component = items[0].GetComponent<LayoutElement>();
				if ((object)component != null)
				{
					float preferredWidth = component.preferredWidth;
					List<GameObject> spellGameCharacters2 = _spellGameCharacters;
					float baseCharacterSize = default(float);
					_baseCharacterSize = baseCharacterSize;
					if (_spellGameCharacters != null)
					{
						bool flag3 = spellGameCharacters2._size <= 0;
						GameObject[] items2 = spellGameCharacters2._items;
						if (spellGameCharacters2._items != null)
						{
							object obj2 = items2[0];
							if ((object)items2[0] != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rdi_v16 (System.Object)+10]");
								bool flag4 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rdi_v16 (System.Object)+10]");
								IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
								Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
								if ((object)transform != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v40 (UnityEngine.Transform)+10]");
									bool flag5 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v40 (UnityEngine.Transform)+10]");
									IntPtr child_Injected = Transform.GetChild_Injected((IntPtr)0, 0);
									Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(child_Injected);
									if ((object)transform2 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v45 (UnityEngine.Transform)+10]");
										bool flag6 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v45 (UnityEngine.Transform)+10]");
										IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
										Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
										if ((object)transform3 != null)
										{
											bool flag7 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
											Transform.get_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 ret);
											_baseScale = ret;
											_ = 0;
											string text = System.Number.FormatSingle(info: NumberFormatInfo.CurrentInfo, value: _baseCharacterSize, format: null);
											string message = "Default spell character size : " + text;
											Debug.Log(message);
											return;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void AddSpellCharacter()
	{
		//IL_0041: Expected I, but got O
		RectTransform spellContainer = GetSpellContainer();
		GameObject gameObject = UnityEngine.Object.Instantiate(_SpellCharacterPrefab, spellContainer);
		Text componentInChildren = gameObject.GetComponentInChildren<Text>(includeInactive: false);
		nint num = (nint)componentInChildren;
		componentInChildren.text = "-";
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
	}

	private unsafe bool CheckForCheat(SecretType t)
	{
		//IL_003d: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Expected O, but got Unknown
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Expected O, but got Unknown
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Expected O, but got Unknown
		//IL_0176: Expected O, but got I4
		//IL_017f: Expected O, but got I4
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Expected O, but got Unknown
		//IL_04da: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Expected O, but got Unknown
		//IL_0582: Unknown result type (might be due to invalid IL or missing references)
		//IL_0587: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected O, but got Unknown
		//IL_082f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0834: Expected O, but got Unknown
		//IL_0844: Expected O, but got I
		//IL_0596: Expected O, but got I4
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Expected O, but got Unknown
		//IL_0156: Expected O, but got I4
		//IL_015f: Expected O, but got I4
		//IL_0852: Expected O, but got I4
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_0377: Expected O, but got Unknown
		//IL_05a4: Expected O, but got I4
		//IL_05c7: Expected O, but got Ref
		//IL_04c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cc: Expected O, but got Unknown
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Expected O, but got Unknown
		//IL_056f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0574: Expected O, but got Unknown
		//IL_081c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0821: Expected O, but got Unknown
		//IL_05dd: Expected O, but got Ref
		//IL_08bd: Expected O, but got I
		//IL_0b33: Expected O, but got I4
		//IL_08cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d0: Expected O, but got Unknown
		//IL_0aa8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aad: Expected O, but got Unknown
		//IL_0a61: Expected O, but got I4
		//IL_09f2: Expected O, but got I
		//IL_0a32: Expected O, but got I
		object obj = ((Dictionary<System.Int32Enum, object>)(object)_secrets).get_Item((System.Int32Enum)t);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+18]");
		bool flag = (nint)0 == 0;
		object obj2 = 0;
		object obj3 = 0;
		if (!flag)
		{
			PlayerOptionsData config = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+18]");
			if ((nint)0 == 0)
			{
				goto IL_0b7d;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+18]");
			SecretType key = (SecretType)((nint)0 >> 32);
			SecretData secretData = ((Dictionary<SecretType, SecretData>)(object)config._003CUnlockedCharacters_003Ek__BackingField).get_Item(key);
			if (secretData == null)
			{
				PlayerOptionsData config2 = _playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+18]");
				if ((nint)0 == 0)
				{
					goto IL_0b7d;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+18]");
				SecretType key2 = (SecretType)((nint)0 >> 32);
				SecretData secretData2 = ((Dictionary<SecretType, SecretData>)(object)config2._003CBoughtCharacters_003Ek__BackingField).get_Item(key2);
				bool flag2 = secretData2 == null;
				obj2 = 0;
				obj3 = 1;
				if (flag2)
				{
					goto IL_0b58;
				}
			}
			obj2 = 1;
			obj3 = 1;
		}
		goto IL_0b58;
		IL_0db1:
		object obj4 = obj2 - obj3;
		return obj4 == null;
		IL_0b58:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+20]");
		if ((nint)0 != 0)
		{
			obj3++;
			PlayerOptionsData config3 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+20]");
			if ((nint)0 == 0)
			{
				goto IL_0b7d;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+20]");
			SecretType key3 = (SecretType)((nint)0 >> 32);
			SecretData secretData3 = ((Dictionary<SecretType, SecretData>)(object)config3._003CUnlockedWeapons_003Ek__BackingField).get_Item(key3);
			if (secretData3 != null)
			{
				obj2++;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+28]");
		if ((nint)0 != 0)
		{
			obj3++;
			PlayerOptionsData config4 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+28]");
			if ((nint)0 == 0)
			{
				goto IL_0b7d;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+28]");
			SecretType key4 = (SecretType)((nint)0 >> 32);
			SecretData secretData4 = ((Dictionary<SecretType, SecretData>)(object)config4._003CUnlockedStages_003Ek__BackingField).get_Item(key4);
			if (secretData4 != null)
			{
				obj2++;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+30]");
		if ((nint)0 != 0)
		{
			obj3++;
			PlayerOptionsData config5 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+30]");
			if ((nint)0 == 0)
			{
				goto IL_0b7d;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+30]");
			SecretType key5 = (SecretType)((nint)0 >> 32);
			SecretData secretData5 = ((Dictionary<SecretType, SecretData>)(object)config5._003CUnlockedHypers_003Ek__BackingField).get_Item(key5);
			if (secretData5 != null)
			{
				obj2++;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+38]");
		if ((nint)0 != 0)
		{
			obj3++;
			PlayerOptionsData config6 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+38]");
			if ((nint)0 == 0)
			{
				goto IL_0b7d;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+38]");
			SecretType key6 = (SecretType)((nint)0 >> 32);
			SecretData secretData6 = ((Dictionary<SecretType, SecretData>)(object)config6._003CCollectedItems_003Ek__BackingField).get_Item(key6);
			if (secretData6 != null)
			{
				obj2++;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+48]");
		if ((nint)0 != 0)
		{
			obj3++;
			PlayerOptionsData config7 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+48]");
			if ((nint)0 == 0)
			{
				goto IL_0b7d;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+48]");
			SecretType key7 = (SecretType)((nint)0 >> 32);
			SecretData secretData7 = ((Dictionary<SecretType, SecretData>)(object)config7._003CUnlockedPowerUpRanks_003Ek__BackingField).get_Item(key7);
			if (secretData7 != null)
			{
				obj2++;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+40]");
		if ((nint)0 != 0)
		{
			obj3++;
			PlayerOptionsData config8 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+40]");
			if ((nint)0 == 0)
			{
				goto IL_0b7d;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+40]");
			SecretType key8 = (SecretType)((nint)0 >> 32);
			SecretData secretData8 = ((Dictionary<SecretType, SecretData>)(object)config8._003CUnlockedArcanas_003Ek__BackingField).get_Item(key8);
			if (secretData8 != null)
			{
				obj2++;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+78]");
		PlayerOptionsData playerOptionsData;
		Dictionary<System.Int32Enum, object> dictionary;
		if ((nint)0 != 0)
		{
			obj3++;
			object obj5 = 1;
			List<SkinToUnlock>.Enumerator enumerator = default(List<SkinToUnlock>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj6 = 0;
				PlayerOptions playerOptions = _playerOptions;
				bool flag3 = _playerOptions == null;
				dictionary = (Dictionary<System.Int32Enum, object>)(&enumerator);
				if (!flag3)
				{
					dictionary = (Dictionary<System.Int32Enum, object>)(&enumerator);
					if (playerOptions._onlineClientWithRunDataConfig == null)
					{
						if (playerOptions._hostGameConfig == null)
						{
							if (playerOptions._currentAdventureSaveData != null)
							{
								playerOptionsData = playerOptions._currentAdventureSaveData;
								if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
								{
									goto IL_0c8f;
								}
							}
							playerOptionsData = playerOptions._mainGameConfig;
						}
						else
						{
							playerOptionsData = playerOptions._hostGameConfig;
						}
					}
					else
					{
						playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
					}
					goto IL_0c8f;
				}
				throw new NullReferenceException();
			}
			if (obj5 != null)
			{
				obj2++;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+80]");
		if ((nint)0 != 0)
		{
			obj3++;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v41 (System.Object)+80]");
			object obj7 = 0;
			object obj8 = 1;
			object obj10 = default(object);
			object obj9 = obj10;
			object obj11 = default(object);
			object obj13 = default(object);
			nint num2 = default(nint);
			object obj17 = default(object);
			while (true)
			{
				PlayerOptionsData playerOptionsData2;
				if (obj9 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1808 @ rcx_v38+1C]");
					if (obj11 != null)
					{
						break;
					}
					object obj12 = obj13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1808 @ rcx_v38+18]");
					if ((nint)obj12 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1808 @ rcx_v38+10]");
					object obj14 = 0;
					obj13++;
					PlayerOptions playerOptions2 = _playerOptions;
					if (playerOptions2._onlineClientWithRunDataConfig == null)
					{
						if (playerOptions2._hostGameConfig == null)
						{
							if (playerOptions2._currentAdventureSaveData != null)
							{
								playerOptionsData2 = playerOptions2._currentAdventureSaveData;
								if ((object)playerOptionsData2._003CSelectedAdventureType_003Ek__BackingField != null)
								{
									goto IL_0993;
								}
							}
							playerOptionsData2 = playerOptions2._mainGameConfig;
						}
						else
						{
							playerOptionsData2 = playerOptions2._hostGameConfig;
						}
					}
					else
					{
						playerOptionsData2 = playerOptions2._onlineClientWithRunDataConfig;
					}
					goto IL_0993;
				}
				throw new NullReferenceException();
				IL_0993:
				List<WeaponType> list = playerOptionsData2._003CUnlockedWeapons_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1776 @ r10_v11 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				bool flag4 = (nint)0 == 0;
				nint num = num2;
				object obj15 = obj7;
				object obj16 = obj9;
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1776 @ r10_v11 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					bool flag5 = (nint)obj17 != -1;
					num = 0;
					obj16 = obj10;
					num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1776 @ r10_v11 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					obj7 = 0;
					obj9 = obj10;
					if (flag5)
					{
						continue;
					}
				}
				num2 = num;
				obj7 = obj15;
				obj8 = 0;
				obj9 = obj16;
			}
			if (obj9 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1808 @ rcx_v38+1C]");
				if (obj11 == null)
				{
					if (obj8 != null)
					{
						obj2++;
					}
					goto IL_0db1;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				obj9 = 0;
			}
			throw new NullReferenceException();
		}
		goto IL_0db1;
		IL_0b7d:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		dictionary = null;
		throw new NullReferenceException();
		IL_0c8f:
		if (playerOptionsData != null)
		{
			dictionary = (Dictionary<System.Int32Enum, object>)(object)playerOptionsData._003CUnlockedSkinsV2_003Ek__BackingField;
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	private unsafe void Spin()
	{
		//IL_0338: Expected O, but got I
		//IL_03a0: Invalid comparison between I4 and F4
		//IL_00c0: Expected I, but got I8
		//IL_01a2: Expected O, but got Ref
		//IL_025b: Expected O, but got Ref
		//IL_0387->IL02ca: Incompatible stack heights: 1 vs 0
		//IL_00c5->IL038c: Incompatible stack heights: 2 vs 1
		//IL_00f1->IL02ca: Incompatible stack heights: 1 vs 0
		//IL_011e->IL02ca: Incompatible stack heights: 1 vs 0
		//IL_014a->IL02ca: Incompatible stack heights: 1 vs 0
		//IL_0177->IL02ca: Incompatible stack heights: 1 vs 0
		//IL_022d->IL02ca: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass110_0 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass110_0();
		if (CS_0024_003C_003E8__locals11 != null)
		{
			CS_0024_003C_003E8__locals11._003C_003E4__this = this;
			CanvasScaler componentInParent = GetComponentInParent<CanvasScaler>();
			CS_0024_003C_003E8__locals11.c = componentInParent;
			if ((object)CS_0024_003C_003E8__locals11.c != null)
			{
				Canvas component = CS_0024_003C_003E8__locals11.c.GetComponent<Canvas>();
				if ((object)component != null)
				{
					bool flag = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
					Canvas.set_renderMode_Injected(((UnityEngine.Object)component).m_CachedPtr, RenderMode.WorldSpace);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
					bool flag2 = (nint)0 != 0;
					nint cachedPtr = ((UnityEngine.Object)component).m_CachedPtr;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						bool flag3 = obj == null;
						cachedPtr = unchecked((nint)6573110936L);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v576 @ rax_v22 (should have been resolved before IL gen)");
					if (0f > 0.5f)
					{
					}
					if ((object)_PanelShake != null)
					{
						MobileConfig component2 = _PanelShake.GetComponent<MobileConfig>();
						if ((object)component2 != null)
						{
							component2.enabled = false;
							if ((object)_PanelShake != null)
							{
								Shake component3 = _PanelShake.GetComponent<Shake>();
								if ((object)component3 != null)
								{
									component3.enabled = false;
									if ((object)_Spinner != null)
									{
										Transform target = _Spinner.transform;
										object obj2 = default(object);
										TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DORotate(target, (Vector3)(&obj2), 2f, RotateMode.LocalAxisAdd);
										TweenCallback tweenCallback = delegate
										{
											//IL_0029: Expected O, but got Ref
											SecretsPage secretsPage = CS_0024_003C_003E8__locals11._003C_003E4__this;
											Transform transform = secretsPage._Spinner.transform;
											object obj3 = default(object);
											transform.localEulerAngles = (Vector3)(&obj3);
											SecretsPage secretsPage2 = CS_0024_003C_003E8__locals11._003C_003E4__this;
											MobileConfig component4 = secretsPage2._PanelShake.GetComponent<MobileConfig>();
											component4.enabled = true;
											SecretsPage secretsPage3 = CS_0024_003C_003E8__locals11._003C_003E4__this;
											Shake component5 = secretsPage3._PanelShake.GetComponent<Shake>();
											component5.enabled = true;
										};
										if (tweenerCore != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v684 @ rax_v29 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
											if ((nint)0 == 0)
											{
											}
										}
										if ((object)CS_0024_003C_003E8__locals11.c != null)
										{
											Transform target2 = CS_0024_003C_003E8__locals11.c.transform;
											TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(target2, (Vector3)(&obj2), 2f, RotateMode.LocalAxisAdd);
											TweenCallback tweenCallback2 = delegate
											{
												//IL_0021: Expected O, but got Ref
												Transform transform = CS_0024_003C_003E8__locals11.c.transform;
												object obj3 = default(object);
												transform.localEulerAngles = (Vector3)(&obj3);
											};
											if (tweenerCore2 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v757 @ rax_v34 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
												if ((nint)0 == 0)
												{
												}
											}
											return;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public SecretsPage()
	{
		//IL_00ba: Expected O, but got I
		//IL_0114: Expected O, but got I
		//IL_0d3b: Expected O, but got I
		//IL_017e: Expected O, but got I
		//IL_0d63: Expected O, but got I
		//IL_01e8: Expected O, but got I
		//IL_0d8b: Expected O, but got I
		//IL_0252: Expected O, but got I
		//IL_0db3: Expected O, but got I
		//IL_02bc: Expected O, but got I
		//IL_0ddb: Expected O, but got I
		//IL_0326: Expected O, but got I
		//IL_0e03: Expected O, but got I
		//IL_0390: Expected O, but got I
		//IL_0e2b: Expected O, but got I
		//IL_03fa: Expected O, but got I
		//IL_0e53: Expected O, but got I
		//IL_0464: Expected O, but got I
		//IL_0e7b: Expected O, but got I
		//IL_04ce: Expected O, but got I
		//IL_0ea3: Expected O, but got I
		//IL_0538: Expected O, but got I
		//IL_0ecb: Expected O, but got I
		//IL_05a2: Expected O, but got I
		//IL_0ef3: Expected O, but got I
		//IL_060c: Expected O, but got I
		//IL_0f1b: Expected O, but got I
		//IL_0676: Expected O, but got I
		//IL_0f43: Expected O, but got I
		//IL_06e0: Expected O, but got I
		//IL_0f6b: Expected O, but got I
		//IL_074a: Expected O, but got I
		//IL_0f93: Expected O, but got I
		//IL_07b4: Expected O, but got I
		//IL_0fbb: Expected O, but got I
		//IL_081e: Expected O, but got I
		//IL_0fe3: Expected O, but got I
		//IL_0888: Expected O, but got I
		//IL_100b: Expected O, but got I
		//IL_08f2: Expected O, but got I
		//IL_1033: Expected O, but got I
		//IL_095c: Expected O, but got I
		//IL_105b: Expected O, but got I
		//IL_09c6: Expected O, but got I
		//IL_1083: Expected O, but got I
		//IL_0a30: Expected O, but got I
		//IL_10ab: Expected O, but got I
		//IL_0a9a: Expected O, but got I
		//IL_10d3: Expected O, but got I
		//IL_0b04: Expected O, but got I
		//IL_10fb: Expected O, but got I
		//IL_0b6e: Expected O, but got I
		//IL_1123: Expected O, but got I
		//IL_0bd8: Expected O, but got I
		//IL_114b: Expected O, but got I
		//IL_0c43: Expected O, but got I
		Dictionary<CharacterType, List<CharacterData>> characterData = new Dictionary<CharacterType, List<CharacterData>>();
		_characterData = characterData;
		_baseLength = 8;
		_keyboardButtons = new List<Button>();
		_spellGameCharacters = new List<GameObject>();
		_spells = new List<string>();
		_spawned = new List<GameObject>();
		List<char> list = new List<char>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rdx_v14+18]");
		if (num >= 0)
		{
			list.AddWithResize('a');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 97;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v513 @ rdx_v16+18]");
		if (num2 >= 0)
		{
			list.AddWithResize('b');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 98;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ rdx_v18+18]");
		if (num3 >= 0)
		{
			list.AddWithResize('c');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 99;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v515 @ rdx_v20+18]");
		if (num4 >= 0)
		{
			list.AddWithResize('d');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 100;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ rdx_v22+18]");
		if (num5 >= 0)
		{
			list.AddWithResize('e');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 101;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rdx_v24+18]");
		if (num6 >= 0)
		{
			list.AddWithResize('f');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 102;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rdx_v26+18]");
		if (num7 >= 0)
		{
			list.AddWithResize('g');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 103;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ rdx_v28+18]");
		if (num8 >= 0)
		{
			list.AddWithResize('h');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 104;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v520 @ rdx_v30+18]");
		if (num9 >= 0)
		{
			list.AddWithResize('i');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 105;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v521 @ rdx_v32+18]");
		if (num10 >= 0)
		{
			list.AddWithResize('j');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 106;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rdx_v34+18]");
		if (num11 >= 0)
		{
			list.AddWithResize('k');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 107;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v523 @ rdx_v36+18]");
		if (num12 >= 0)
		{
			list.AddWithResize('l');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 108;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rdx_v38+18]");
		if (num13 >= 0)
		{
			list.AddWithResize('m');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 109;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ rdx_v40+18]");
		if (num14 >= 0)
		{
			list.AddWithResize('n');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 110;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v526 @ rdx_v42+18]");
		if (num15 >= 0)
		{
			list.AddWithResize('o');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 111;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ rdx_v44+18]");
		if (num16 >= 0)
		{
			list.AddWithResize('p');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj32 = (nint)0 + (nint)1;
			_ = 112;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v528 @ rdx_v46+18]");
		if (num17 >= 0)
		{
			list.AddWithResize('q');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj34 = (nint)0 + (nint)1;
			_ = 113;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rdx_v48+18]");
		if (num18 >= 0)
		{
			list.AddWithResize('r');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj36 = (nint)0 + (nint)1;
			_ = 114;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ rdx_v50+18]");
		if (num19 >= 0)
		{
			list.AddWithResize('s');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj38 = (nint)0 + (nint)1;
			_ = 115;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ rdx_v52+18]");
		if (num20 >= 0)
		{
			list.AddWithResize('t');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj40 = (nint)0 + (nint)1;
			_ = 116;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ rdx_v54+18]");
		if (num21 >= 0)
		{
			list.AddWithResize('u');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj42 = (nint)0 + (nint)1;
			_ = 117;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v533 @ rdx_v56+18]");
		if (num22 >= 0)
		{
			list.AddWithResize('v');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj44 = (nint)0 + (nint)1;
			_ = 118;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ rdx_v58+18]");
		if (num23 >= 0)
		{
			list.AddWithResize('w');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj46 = (nint)0 + (nint)1;
			_ = 119;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj47 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ rdx_v60+18]");
		if (num24 >= 0)
		{
			list.AddWithResize('x');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj48 = (nint)0 + (nint)1;
			_ = 120;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj49 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rdx_v62+18]");
		if (num25 >= 0)
		{
			list.AddWithResize('y');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj50 = (nint)0 + (nint)1;
			_ = 121;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj51 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ rdx_v64+18]");
		if (num26 >= 0)
		{
			list.AddWithResize('z');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj52 = (nint)0 + (nint)1;
			_ = 122;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj53 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rdx_v66+18]");
		if (num27 >= 0)
		{
			list.AddWithResize('-');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj54 = (nint)0 + (nint)1;
			_ = 45;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+10]");
		object obj55 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
		nint num28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ rdx_v68+18]");
		if (num28 >= 0)
		{
			list.AddWithResize('1');
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v17 (System.Collections.Generic.List`1<System.Char>)+18]");
			object obj56 = (nint)0 + (nint)1;
			_ = 49;
		}
		_characters = list;
		string[] tints = new string[5];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_tints = tints;
		_twirlContainer = new List<GameObject>();
		_twirlImages = new List<Image>();
		base._002Ector();
	}

	private void _003CDoDevilEffect_003Eb__69_0()
	{
		Image component = _Skull.GetComponent<Image>();
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(component, 0f, 0.3f);
	}

	private unsafe void _003CDoDevilEffect_003Eb__69_1()
	{
		//IL_0008: Expected O, but got Ref
		//IL_08c7: Expected I, but got O
		//IL_0915: Expected I, but got O
		//IL_0958: Expected I, but got O
		//IL_0107: Expected I, but got O
		//IL_0115: Expected O, but got Ref
		//IL_018c: Expected I, but got O
		//IL_0221: Expected F4, but got I4
		//IL_022a: Expected O, but got I4
		//IL_0238: Expected F4, but got I4
		//IL_0a85: Expected O, but got Ref
		//IL_110b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1110: Expected O, but got Unknown
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f7: Expected O, but got Unknown
		//IL_0724: Unknown result type (might be due to invalid IL or missing references)
		//IL_0729: Expected O, but got Unknown
		//IL_0d8b: Expected O, but got Ref
		//IL_0dd5: Expected O, but got Ref
		//IL_0f1a: Expected O, but got Ref
		//IL_0f69: Expected I, but got O
		//IL_0f77: Expected O, but got Ref
		//IL_111d->IL09f1: Incompatible stack heights: 1 vs 0
		//IL_02e3->IL0865: Incompatible stack heights: 1 vs 0
		//IL_0316->IL0865: Incompatible stack heights: 1 vs 0
		//IL_0340->IL0865: Incompatible stack heights: 1 vs 0
		//IL_036a->IL0865: Incompatible stack heights: 1 vs 0
		//IL_04c4->IL0865: Incompatible stack heights: 3 vs 0
		//IL_0394->IL0865: Incompatible stack heights: 1 vs 0
		//IL_118b->IL0865: Incompatible stack heights: 3 vs 0
		//IL_052a->IL0865: Incompatible stack heights: 4 vs 0
		//IL_0c2b->IL0865: Incompatible stack heights: 5 vs 0
		//IL_0c8b->IL0865: Incompatible stack heights: 6 vs 0
		//IL_0736->IL0b68: Incompatible stack heights: 5 vs 3
		//IL_05f6->IL0865: Incompatible stack heights: 5 vs 0
		//IL_0ceb->IL0865: Incompatible stack heights: 7 vs 0
		//IL_063b->IL0865: Incompatible stack heights: 5 vs 0
		//IL_0d4b->IL0865: Incompatible stack heights: 8 vs 0
		//IL_0fda->IL0865: Incompatible stack heights: 18 vs 0
		//IL_103a->IL0865: Incompatible stack heights: 19 vs 0
		//IL_109a->IL0865: Incompatible stack heights: 20 vs 0
		//IL_07fb->IL0865: Incompatible stack heights: 21 vs 0
		//IL_081d->IL0865: Incompatible stack heights: 21 vs 0
		//IL_084c->IL0865: Incompatible stack heights: 21 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((object)_Shatter != null)
		{
			GameObject gameObject = _Shatter.gameObject;
			if ((object)gameObject != null)
			{
				gameObject.SetActive(value: true);
				Physics.simulationMode = SimulationMode.FixedUpdate;
				if ((object)_Shatter != null)
				{
					RectTransform component = _Shatter.GetComponent<RectTransform>();
					nint num = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rcx_v111 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ rax_v116 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
					_ = 0;
					_ = Vector3.oneVector;
					if ((object)component != null)
					{
						Vector2 vector = default(Vector2);
						component.anchorMin = vector;
						nint num3 = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1024 @ rax_v120 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1025 @ rax_v121 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
						_ = 0;
						_ = Vector3.oneVector;
						component.anchorMax = vector;
						nint num5 = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1121 @ rax_v125 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1122 @ rax_v126 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
						_ = 0;
						_ = Vector3.oneVector;
						component.pivot = vector;
						if ((object)_Shatter != null)
						{
							SpriteRenderer component2 = _Shatter.GetComponent<SpriteRenderer>();
							if ((object)component2 != null)
							{
								component2.sprite = fakeScreenSpriteLandScape;
								Image devilFader = _DevilFader;
								if ((object)_DevilFader != null)
								{
									nint num7 = (nint)devilFader;
									Color color = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F20]");
									_ = 0;
									_DevilFader.color = color;
									object devilPattern = _DevilPattern;
									if ((object)_DevilPattern != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
										object obj3 = default(object);
										if (obj3 == null)
										{
											nint num8 = (nint)devilPattern;
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1391 @ rax_v379 (Il2CppClass<System.Object>)+2A8] (should have been resolved before IL gen)");
										}
										_ = 0;
										_ = 0;
										if ((object)_Shatter != null)
										{
											Transform transform = _Shatter.transform;
											if ((object)transform != null)
											{
												Transform child = transform.GetChild(0);
												if ((object)child != null)
												{
													Transform[] componentsInChildren = child.GetComponentsInChildren<Transform>();
													bool flag = componentsInChildren == null;
													float num9 = 0f;
													object obj4 = 0;
													object obj5 = null;
													float num10 = 0f;
													object obj6 = null;
													if (!flag)
													{
														TweenerCore<Color, Color, ColorOptions> t = default(TweenerCore<Color, Color, ColorOptions>);
														while (true)
														{
															if ((nint)obj6 < componentsInChildren.Length)
															{
																bool flag2 = (nint)obj5 >= componentsInChildren.Length;
																bool flag3;
																if ((object)componentsInChildren[obj5] != null)
																{
																	object obj7 = (object)componentsInChildren[obj5] - (object)child;
																	flag3 = obj7 == null;
																}
																else
																{
																	flag3 = ((UnityEngine.Object)child).m_CachedPtr == (IntPtr)0;
																}
																if (!flag3)
																{
																	if ((object)componentsInChildren[obj5] == null)
																	{
																		break;
																	}
																	GameObject gameObject2 = componentsInChildren[obj5].gameObject;
																	if ((object)gameObject2 == null)
																	{
																		break;
																	}
																	BoxCollider boxCollider = gameObject2.AddComponent<BoxCollider>();
																	if ((object)boxCollider == null)
																	{
																		break;
																	}
																	GameObject gameObject3 = boxCollider.gameObject;
																	if ((object)gameObject3 == null)
																	{
																		break;
																	}
																	Rigidbody rigidbody = gameObject3.AddComponent<Rigidbody>();
																	if ((object)rigidbody == null)
																	{
																		break;
																	}
																	rigidbody.useGravity = false;
																	Vector3 position = componentsInChildren[obj5].position;
																	_ = position.x;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-31]");
																	num10 = 0f + position.z;
																	obj4++;
																	num9 = num10;
																}
																obj5++;
																obj6 = obj5;
																continue;
															}
															float num11 = num9 / (float)obj4;
															GameObject gameObject4 = new GameObject();
															GameObject.Internal_CreateGameObject(gameObject4, (string)null);
															bool flag4 = ((UnityEngine.Object)gameObject4).m_CachedPtr == (IntPtr)0;
															IntPtr gcHandlePtr = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject4).m_CachedPtr);
															Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
															bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
															object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
															Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj8);
															bool flag6 = ((UnityEngine.Object)gameObject4).m_CachedPtr == (IntPtr)0;
															IntPtr gcHandlePtr2 = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject4).m_CachedPtr);
															Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
															bool flag7 = (object)transform3.GetType() != typeof(RectTransform);
															Transform transform4 = null;
															if (!flag7)
															{
																transform4 = transform3;
															}
															if ((object)transform4 != null)
															{
																Debug.LogWarning("Parent of RectTransform is being set with parent property. Consider using the SetParent method instead, with the worldPositionStays argument set to false. This will retain local orientation and scale rather than world orientation and scale, which can prevent common UI scaling issues.", transform3);
															}
															transform3.SetParent(child, worldPositionStays: true);
															Rigidbody[] componentsInChildren2 = child.GetComponentsInChildren<Rigidbody>();
															if (componentsInChildren2 == null)
															{
																break;
															}
															object obj9 = null;
															object obj10 = null;
															while (true)
															{
																if ((nint)obj10 < componentsInChildren2.Length)
																{
																	bool flag8 = (nint)obj9 >= componentsInChildren2.Length;
																	object obj11 = componentsInChildren2[obj9];
																	if ((object)componentsInChildren2[obj9] == null)
																	{
																		break;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rbx_v53 (System.Object)+10]");
																	bool flag9 = (nint)0 == 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rbx_v53 (System.Object)+10]");
																	IntPtr gcHandlePtr3 = Component.get_transform_Injected((IntPtr)0);
																	Transform transform5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
																	bool flag10;
																	if ((object)transform5 != null)
																	{
																		object obj12 = (object)transform5 - (object)child;
																		flag10 = obj12 == null;
																	}
																	else
																	{
																		flag10 = ((UnityEngine.Object)child).m_CachedPtr == (IntPtr)0;
																	}
																	if (!flag10)
																	{
																		componentsInChildren2[obj9].collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
																		componentsInChildren2[obj9].interpolation = RigidbodyInterpolation.Interpolate;
																		GameObject gameObject5 = componentsInChildren2[obj9].gameObject;
																		int layer = LayerMask.NameToLayer("Enemies");
																		if ((object)gameObject5 == null)
																		{
																			break;
																		}
																		gameObject5.layer = layer;
																		GameObject gameObject6 = componentsInChildren2[obj9].gameObject;
																		if ((object)gameObject6 == null)
																		{
																			break;
																		}
																		string text = ((UnityEngine.Object)gameObject6).GetName();
																		string message = "RB : " + text;
																		Debug.Log(message);
																		SpriteRenderer component3 = componentsInChildren2[obj9].GetComponent<SpriteRenderer>();
																		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(component3, 0f, 2f);
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
																		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t, 0.4f);
																		Transform target = componentsInChildren2[obj9].transform;
																		TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOScale(target, 0.4f, 2f);
																		TweenerCore<Color, Color, ColorOptions> tweenerCore3 = TweenSettingsExtensions.SetDelay((TweenerCore<Color, Color, ColorOptions>)(object)t2, 0.4f);
																		num10 = 0.4f;
																	}
																	obj9++;
																	obj10 = obj9;
																	continue;
																}
																IntPtr gcHandlePtr4 = GameObject.CreatePrimitive_Injected(PrimitiveType.Sphere);
																GameObject gameObject7 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr4);
																if ((object)gameObject7 == null)
																{
																	break;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v168 (UnityEngine.GameObject)+10]");
																bool flag11 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v168 (UnityEngine.GameObject)+10]");
																IntPtr gcHandlePtr5 = GameObject.get_transform_Injected((IntPtr)0);
																Transform transform6 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr5);
																bool flag12 = ((UnityEngine.Object)child).m_CachedPtr == (IntPtr)0;
																IntPtr gcHandlePtr6 = Component.get_transform_Injected(((UnityEngine.Object)child).m_CachedPtr);
																Transform transform7 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr6);
																if ((object)transform7 == null)
																{
																	break;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v178 (UnityEngine.Transform)+10]");
																bool flag13 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v178 (UnityEngine.Transform)+10]");
																IntPtr parent_Injected = Transform.GetParent_Injected((IntPtr)0);
																Transform transform8 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected);
																if ((object)transform8 == null)
																{
																	break;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rax_v183 (UnityEngine.Transform)+10]");
																bool flag14 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rax_v183 (UnityEngine.Transform)+10]");
																IntPtr parent_Injected2 = Transform.GetParent_Injected((IntPtr)0);
																Transform parent = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected2);
																if ((object)transform6 == null)
																{
																	break;
																}
																transform6.SetParent(parent, worldPositionStays: true);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v168 (UnityEngine.GameObject)+10]");
																bool flag15 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v168 (UnityEngine.GameObject)+10]");
																IntPtr gcHandlePtr7 = GameObject.get_transform_Injected((IntPtr)0);
																Transform transform9 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr7);
																if ((object)transform9 == null)
																{
																	break;
																}
																_ = 0;
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rax_v194 (UnityEngine.Transform)+10]");
																bool flag16 = (nint)0 == 0;
																object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rax_v194 (UnityEngine.Transform)+10]");
																Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj13);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-31]");
																float num12 = 0f - -10f;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rax_v194 (UnityEngine.Transform)+10]");
																bool flag17 = (nint)0 == 0;
																object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rax_v194 (UnityEngine.Transform)+10]");
																Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)obj14);
																Rigidbody rigidbody2 = gameObject7.AddComponent<Rigidbody>();
																bool flag18 = (object)rigidbody2 == null;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4064 @ rax_v204 (UnityEngine.Rigidbody)+10]");
																bool flag19 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4064 @ rax_v204 (UnityEngine.Rigidbody)+10]");
																Rigidbody.set_isKinematic_Injected((IntPtr)0, true);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4064 @ rax_v204 (UnityEngine.Rigidbody)+10]");
																bool flag20 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4064 @ rax_v204 (UnityEngine.Rigidbody)+10]");
																Rigidbody.set_useGravity_Injected((IntPtr)0, false);
																int value = LayerMask.NameToLayer("Player");
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v168 (UnityEngine.GameObject)+10]");
																bool flag21 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v168 (UnityEngine.GameObject)+10]");
																GameObject.set_layer_Injected((IntPtr)0, value);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v168 (UnityEngine.GameObject)+10]");
																bool flag22 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v168 (UnityEngine.GameObject)+10]");
																IntPtr gcHandlePtr8 = GameObject.get_transform_Injected((IntPtr)0);
																Transform transform10 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr8);
																bool flag23 = (object)transform10 == null;
																_ = 500f;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4065 @ rax_v222 (UnityEngine.Transform)+10]");
																bool flag24 = (nint)0 == 0;
																object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4065 @ rax_v222 (UnityEngine.Transform)+10]");
																Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj15);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v168 (UnityEngine.GameObject)+10]");
																bool flag25 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v168 (UnityEngine.GameObject)+10]");
																IntPtr gcHandlePtr9 = GameObject.get_transform_Injected((IntPtr)0);
																Transform target2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr9);
																nint num13 = (nint)typeof(Vector3);
																Vector3 endValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4549 @ rcx_v204 (Il2CppClass<UnityEngine.Vector3>)+B8]");
																nint num14 = 0;
																_ = Vector3.zeroVector;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4551 @ rax_v233 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
																_ = 0;
																TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOLocalMove(target2, endValue, 0.01f);
																Renderer component4 = gameObject7.GetComponent<Renderer>();
																if ((object)component4 == null)
																{
																	break;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v236 (UnityEngine.Renderer)+10]");
																bool flag26 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v236 (UnityEngine.Renderer)+10]");
																Renderer.set_enabled_Injected((IntPtr)0, false);
																object runeContainer = _RuneContainer;
																if ((object)_RuneContainer == null)
																{
																	break;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rbx_v50 (System.Object)+10]");
																bool flag27 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rbx_v50 (System.Object)+10]");
																IntPtr gcHandlePtr10 = Component.get_gameObject_Injected((IntPtr)0);
																GameObject gameObject8 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr10);
																if ((object)gameObject8 == null)
																{
																	break;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v245 (UnityEngine.GameObject)+10]");
																bool flag28 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v245 (UnityEngine.GameObject)+10]");
																GameObject.SetActive_Injected((IntPtr)0, true);
																EventSystem current = EventSystem.current;
																if ((object)current == null || (object)current.m_CurrentSelected == null)
																{
																	break;
																}
																SelectableUI component5 = current.m_CurrentSelected.GetComponent<SelectableUI>();
																if ((object)component5 == null)
																{
																	break;
																}
																SelectableUI.OnSetSelectorVisibility setSelectorVisibility = SelectableUI.SetSelectorVisibility;
																if (SelectableUI.SetSelectorVisibility != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v4700.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
																}
																return;
															}
															break;
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
			}
		}
		throw new NullReferenceException();
	}

	private void _003CHideTwirls_003Eb__95_0()
	{
		_isBusy = false;
	}
}
