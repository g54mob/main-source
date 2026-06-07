using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coffee.UIEffects;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.VFX.Shatter;
using VampireSurvivors.Spells;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.UI
{
	public class SecretsPage : BaseUIPage
	{
		[CompilerGenerated]
		private sealed class _003CDelayedInitShatter_003Ed__66 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SecretsPage _003C_003E4__this;

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
			public _003CDelayedInitShatter_003Ed__66(int _003C_003E1__state)
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
		private sealed class _003CDisableGravityWell_003Ed__98 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SecretsPage _003C_003E4__this;

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
			public _003CDisableGravityWell_003Ed__98(int _003C_003E1__state)
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
		private sealed class _003CWaitAndReselectSpells_003Ed__90 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SecretsPage _003C_003E4__this;

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
			public _003CWaitAndReselectSpells_003Ed__90(int _003C_003E1__state)
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
		private sealed class _003CWaitAndResetSliderValue_003Ed__93 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SecretsPage _003C_003E4__this;

			public float f;

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
			public _003CWaitAndResetSliderValue_003Ed__93(int _003C_003E1__state)
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
		private sealed class _003CWaitAndSelect_003Ed__73 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SecretsPage _003C_003E4__this;

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
			public _003CWaitAndSelect_003Ed__73(int _003C_003E1__state)
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
		private sealed class _003CWaitForParticles_003Ed__101 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SecretsPage _003C_003E4__this;

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
			public _003CWaitForParticles_003Ed__101(int _003C_003E1__state)
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
		private TextMeshProUGUI _Title;

		[SerializeField]
		private TextMeshProUGUI _ObtainsText;

		[SerializeField]
		private GameObject _KeyboardButtonPrefab;

		[SerializeField]
		private GameObject _SpellCharacterPrefab;

		[SerializeField]
		private RectTransform _KeyboardContainer;

		[SerializeField]
		private RectTransform _SpellCharacterContainer;

		[SerializeField]
		private RectTransform _SpellCharacterContainer2;

		[SerializeField]
		private RectTransform _SpellCharacterBackground;

		[SerializeField]
		private GameObject _ShowKeyboardButton;

		[SerializeField]
		private GameObject _SecretPrefab;

		[SerializeField]
		private RectTransform _SecretContainer;

		[SerializeField]
		private TextMeshProUGUI _Unlocks;

		[SerializeField]
		private Image _CharacterRewardIcon;

		[SerializeField]
		private Image _OtherRewardIcon;

		[SerializeField]
		private Shake _PanelShake;

		[SerializeField]
		private ParticleEmitterManager _RuneParticlesEmitter;

		[SerializeField]
		private SecretUnlockPopup _UnlockPopup;

		[SerializeField]
		private GameObject _TwirlPrefab;

		[SerializeField]
		private RectTransform _TwirlContainer;

		[SerializeField]
		private RectTransform _Spinner;

		[FormerlySerializedAs("fakeScreenSprite")]
		[SerializeField]
		private Sprite fakeScreenSpriteLandScape;

		[SerializeField]
		private Sprite fakeScreenSpritePortrait;

		[Header("DevilRoom")]
		[SerializeField]
		private Image _DevilFader;

		[SerializeField]
		private UIDissolve _DevilPattern;

		[SerializeField]
		private RectTransform _DevilSpinner;

		[SerializeField]
		private RectTransform _Skull;

		[SerializeField]
		private ShatterVFX _Shatter;

		[SerializeField]
		private Texture2D _GeneratedTexture;

		[SerializeField]
		private RawImage _RunePatternImage;

		[SerializeField]
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

		[Inject]
		private void Construct(DataManager data, PlayerOptions player, SpellsManager spellsManager, AchievementManager achievementManager)
		{
		}

		private void Start()
		{
		}

		protected override void Awake()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedInitShatter_003Ed__66))]
		private IEnumerator DelayedInitShatter()
		{
			return null;
		}

		public void ShowKeyboard()
		{
		}

		public void SetInfoPanel(SecretData data, SecretType type, SecretItemUI item)
		{
		}

		public void DoDevilEffect()
		{
		}

		public void PlayRunes()
		{
		}

		private void CreateRuneTexture()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndSelect_003Ed__73))]
		private IEnumerator WaitAndSelect()
		{
			return null;
		}

		protected override void OnHideStart(GameObject g)
		{
		}

		private void NavigationWrap()
		{
		}

		private bool GetMusicData(BgmType bgmType, out MusicData musicData)
		{
			musicData = null;
			return false;
		}

		private void PlaySoundTrack()
		{
		}

		private void BuildTwirls()
		{
		}

		private void OnDestroy()
		{
		}

		private GameObject SpawnTwirl(GameObject container, Vector2 pos, string spriteName, string textureName, float angle)
		{
			return null;
		}

		private void StartRuneParticles()
		{
		}

		private void StartInputParticles()
		{
		}

		protected override void Update()
		{
		}

		private void Populate()
		{
		}

		private void ClearSpawned()
		{
		}

		private void BuildKeyboard()
		{
		}

		private void Unlock(SecretType t)
		{
		}

		private void PostUnlock()
		{
		}

		private void CheckUnlockedSecretAchievements(SecretType t)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndReselectSpells_003Ed__90))]
		private IEnumerator WaitAndReselectSpells()
		{
			return null;
		}

		private void everything()
		{
		}

		private void everywhere()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndResetSliderValue_003Ed__93))]
		private IEnumerator WaitAndResetSliderValue(float f)
		{
			return null;
		}

		private void ShowTwirls()
		{
		}

		private void HideTwirls()
		{
		}

		private void SetNextCharacter(GameObject sender)
		{
		}

		private void SetNextCharacter(string s)
		{
		}

		[IteratorStateMachine(typeof(_003CDisableGravityWell_003Ed__98))]
		private IEnumerator DisableGravityWell()
		{
			return null;
		}

		private void PlayHitSound()
		{
		}

		private void Backspace()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForParticles_003Ed__101))]
		private IEnumerator WaitForParticles()
		{
			return null;
		}

		private void PlayInputParticles(Transform character)
		{
		}

		private RectTransform GetSpellContainer()
		{
			return null;
		}

		private void FormatSpell()
		{
		}

		private void CheckSpells()
		{
		}

		private void ClearSpell()
		{
		}

		private void BuildSpellBase()
		{
		}

		private void AddSpellCharacter()
		{
		}

		private bool CheckForCheat(SecretType t)
		{
			return false;
		}

		private void Spin()
		{
		}
	}
}
