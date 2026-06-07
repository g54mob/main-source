using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DarkTonic.MasterAudio;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class TPCreditsPage : BaseUIPage
	{
		[CompilerGenerated]
		private sealed class _003CWaitAndFormatPortrait_003Ed__52 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TPCreditsPage _003C_003E4__this;

			private float _003Cheight_003E5__2;

			private float _003Cwidth_003E5__3;

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
			public _003CWaitAndFormatPortrait_003Ed__52(int _003C_003E1__state)
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
		private sealed class _003CWaitAndHide_003Ed__51 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TPCreditsPage _003C_003E4__this;

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
			public _003CWaitAndHide_003Ed__51(int _003C_003E1__state)
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
		private sealed class _003CWaitAndPlay_003Ed__54 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TPCreditsPage _003C_003E4__this;

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
			public _003CWaitAndPlay_003Ed__54(int _003C_003E1__state)
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

		public static CharacterType[] CharactersToUnlocks;

		[SerializeField]
		private RectTransform _Container;

		[SerializeField]
		private GameObject _TextPrefab;

		[SerializeField]
		private TextMeshProUGUI _Title;

		[SerializeField]
		private RectTransform _CongaContainer;

		[SerializeField]
		private GameObject _CongaItem;

		[SerializeField]
		private CanvasGroup _NowLoading;

		[SerializeField]
		private TPCreditsScene _ScenePrefab;

		[SerializeField]
		private AnimationClip _Animation;

		[SerializeField]
		private Animator _Animator;

		[SerializeField]
		private GameObject _Hand;

		[SerializeField]
		private Image _EndFlash;

		[SerializeField]
		private RectTransform _Rotator;

		[SerializeField]
		private GameObject _Overlay;

		[SerializeField]
		private GameObject _VideoDisplay;

		[SerializeField]
		private Material _NowLoadingMaterial;

		[SerializeField]
		private float _NowLoadingInputSpeed;

		private PlayerOptions _playerOptions;

		private DataManager _data;

		private MultiplayerManager _multiplayerManager;

		public static string CACHE_GROUP_NAME;

		private TPCreditsScene _sceneInstance;

		private List<WiggleTween> _movementTweens;

		private List<EnemyType> _enemyList;

		private List<CharacterType> _characterList;

		private Dictionary<EnemyType, List<EnemyData>> _enemyData;

		private Dictionary<CharacterType, List<CharacterData>> _characterData;

		private List<UISpriteAnimation> _anims;

		private int _moveTweenIndex;

		[SerializeField]
		[ReadOnly]
		private float _congaSpeed;

		private int _congaLength;

		private float _widthCounter;

		private int _enemyCount;

		private int _characterCount;

		private bool _syncAudioCheck;

		private float _currentTime;

		private Vector2 _JSDefaultScreenSize;

		private List<RectTransform> _spawnedConga;

		private PlaySoundResult _soundResult;

		private float _normalizedTime;

		private float _animLength;

		private bool _isPlaying;

		private bool _loadingComplete;

		[Inject]
		private void Construct(PlayerOptions player, DataManager data, MultiplayerManager multi)
		{
		}

		protected void FixedUpdate()
		{
		}

		protected override void Update()
		{
		}

		public void SetTime(float time)
		{
		}

		public void TakeMyHand()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		protected override void OnShowFinish(GameObject g)
		{
		}

		protected override void OnHideFinish(GameObject g)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndHide_003Ed__51))]
		private IEnumerator WaitAndHide()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWaitAndFormatPortrait_003Ed__52))]
		private IEnumerator WaitAndFormatPortrait()
		{
			return null;
		}

		private void Play()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndPlay_003Ed__54))]
		private IEnumerator WaitAndPlay()
		{
			return null;
		}

		private void GenerateFramesAndEvents()
		{
		}

		private void GenerateTextKeyFrames()
		{
		}

		private void SetMusic()
		{
		}

		private void CreateConga()
		{
		}

		private void CreateWiggleTweens()
		{
		}

		private void CreateEnemyList()
		{
		}

		public void PlayVideo()
		{
		}

		private void GetNextCharacter()
		{
		}

		private GameObject CreateEnemyAnimation(EnemyType type, int frameIndex = 0)
		{
			return null;
		}

		private void CreateCharacterAnimation(CharacterType type, int frameIndex = 0)
		{
		}

		private GameObject CreatePawn(List<Sprite> sprites, bool flip = false)
		{
			return null;
		}

		private void CreateCharacterList()
		{
		}

		private void BuildCredits()
		{
		}

		private void AddText(string t)
		{
		}

		public void DisableAllInput()
		{
		}
	}
}
