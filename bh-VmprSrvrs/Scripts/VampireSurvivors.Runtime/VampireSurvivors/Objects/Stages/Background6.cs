using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Video;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.VFX.Shatter;

namespace VampireSurvivors.Objects.Stages
{
	public class Background6 : BackgroundManager
	{
		[CompilerGenerated]
		private sealed class _003CEnterPhase5PostShatterAnimation_003Ed__80 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Background6 _003C_003E4__this;

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
			public _003CEnterPhase5PostShatterAnimation_003Ed__80(int _003C_003E1__state)
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
		private sealed class _003CShatterImageRoutine_003Ed__100 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Background6 _003C_003E4__this;

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
			public _003CShatterImageRoutine_003Ed__100(int _003C_003E1__state)
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

		private DirecterManager _directerManager;

		private GameObject _fakePlayerUiLevelUpPrefab;

		private bool _hasMirror;

		private bool _hasTrumpet;

		private bool _hasJubilee;

		private bool _canContinueStageZoom;

		private float _colorBgValue;

		private Transform _spritesRootTransform;

		private PhaserSprite _snap;

		private SpriteAnimation _snapAnimation;

		private PhaserSprite _sSunCircle;

		private PhaserSprite _sMoonCircle;

		private PhaserSprite _sWorldCircle;

		private PhaserSprite _sCentralCircle;

		private PhaserSprite _sunCircle;

		private PhaserSprite _moonCircle;

		private PhaserSprite _worldCircle;

		private PhaserSprite _centralCircle;

		private PhaserSprite _colorBg;

		private List<PhaserSprite> _windows;

		private FakeTilingBackground _tilingBg;

		private MultiTargetTween _sunCircleTween;

		private MultiTargetTween _moonCircleTween;

		private MultiTargetTween _worldCircleTween;

		private MultiTargetTween _stageZoomTween;

		private Timer _colorBgTimer;

		private ParticleEmitterManager _pfxEmitter;

		private ParticleSystem _pfxFire1;

		private ParticleSystem _pfxFire2;

		private ParticleSystem _pfxFireRed1;

		private ParticleSystem _pfxFireRed2;

		private ShatterVFX _shatterVfx;

		private Texture2D _capturedScreenshot;

		private bool _hasCaptureScreenshot;

		private SpriteRenderer _shatterVfxRenderer;

		private float _shatterGlobalScale;

		private Tween[] _shatterMoveTweens;

		private Tween[] _shatterAngleTweens;

		private Tween[] _shatterAlphaTweens;

		private Pickup _pickupDirecter;

		private EnemyDirecter _directer;

		private int _stageKeyIndex;

		private List<string> _stageKeys;

		public float _OriginalZoom;

		public float _OriginalUIZoom;

		private RectTransform _mainUIView;

		private GameObject _videoPlayerPrefab;

		private Dictionary<string, VideoClip> _videoClips;

		private List<string> _videoKeys;

		private List<float> _videoStarts;

		private List<float> _videoEnds;

		private List<int> _videoBlinks;

		private List<VideoPlayerHelper> _videoPlayerHelpers;

		private VideoPlaybackManager _videoPlaybackManager;

		public EnemyDirecter Directer => null;

		public ParticleSystem PfxFire1 => null;

		public ParticleSystem PfxFire2 => null;

		private DirecterManager DirecterMan => null;

		protected override void OnDestroy()
		{
		}

		protected override void OnUpdate()
		{
		}

		public DirecterManager GetDirecterManager()
		{
			return null;
		}

		public override void Create()
		{
		}

		private void OnRemoteItemInstantiated(Pickup item)
		{
		}

		private void OnRemoteEnemySpawned(EnemyController enemy)
		{
		}

		public void SwapDirecters()
		{
		}

		public void OnPhase1()
		{
		}

		public void OnPhase2()
		{
		}

		public void OnPhase3()
		{
		}

		public void OnPhase4()
		{
		}

		public void OnPhase5()
		{
		}

		public void RemoveCircles()
		{
		}

		public void RemoveTileset()
		{
		}

		public void RemoveWalls()
		{
		}

		public void ZoomOverStages()
		{
		}

		public void TurnBgToFire()
		{
		}

		public void StartColorChangingBackground()
		{
		}

		[IteratorStateMachine(typeof(_003CEnterPhase5PostShatterAnimation_003Ed__80))]
		public IEnumerator EnterPhase5PostShatterAnimation()
		{
			return null;
		}

		public void BlockInput()
		{
		}

		public void ShatterImage()
		{
		}

		public void OpenWindows()
		{
		}

		public void StartZoomingOut()
		{
		}

		public void RemoveColorBg()
		{
		}

		public void AddLevelUpBars()
		{
		}

		public void StartGifts()
		{
		}

		public void MakeThrowingHands()
		{
		}

		public void PlayVideos()
		{
		}

		private void GenerateSprites()
		{
		}

		private void GenerateFakeTilingBackground()
		{
		}

		private void RemovePowerUps()
		{
		}

		private void RemovePowers(List<string> frames)
		{
		}

		private void SnapEggs()
		{
		}

		private void MakeCircles()
		{
		}

		private void MakeFireEmitters()
		{
		}

		private void MakeWindows()
		{
		}

		private void MakeDirector()
		{
		}

		private void InitShatterVfx()
		{
		}

		[IteratorStateMachine(typeof(_003CShatterImageRoutine_003Ed__100))]
		private IEnumerator ShatterImageRoutine()
		{
			return null;
		}

		private void Shatter()
		{
		}

		private void KillShatterTweens()
		{
		}

		private static void KillTween(Tween[] tweens)
		{
		}

		private void SpawnFakePlayerUILevelUp(float xPos, float yPos)
		{
		}

		private void SendGem(bool isCluster, bool isRandomColor)
		{
		}

		private void SendCoins(bool isRandomType)
		{
		}

		private void CacheVideoHelpers()
		{
		}

		private void CleanupVideoPlaybackManager()
		{
		}

		private void PlayVideosAt(int index, List<Vector2> positions, float scale = 0.75f)
		{
		}
	}
}
