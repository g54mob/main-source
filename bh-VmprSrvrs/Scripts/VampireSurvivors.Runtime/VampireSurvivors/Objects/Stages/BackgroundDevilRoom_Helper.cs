using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using DarkTonic.MasterAudio;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Stages
{
	public class BackgroundDevilRoom_Helper
	{
		public BackgroundDevilRoom backgroundManager;

		public PhaserScene scene;

		public ParticleSystem TopEmitter;

		public ParticleSystem BottomEmitter;

		public ParticleSystem SkullsEmitter;

		public PhaserSprite _darkBackground;

		public PhaserSprite _lightBackground;

		public MultiTargetTween _tween1;

		public MultiTargetTween _tween2;

		public Light2D _globalLight;

		private float _currentCameraAngleZ;

		private Sequence _pulseLightSeq;

		private TweenerCore<float, float, FloatOptions> _darkToLightTween;

		private List<SpriteRenderer> _backgroundClouds;

		private List<MultiTargetTween> _movingBgTweens;

		private Transform _spritesRootTransform;

		private PlaySoundResult _geiger1AL;

		private PlaySoundResult _geiger2AR;

		private PlaySoundResult _geiger3BL;

		private PlaySoundResult _geiger4BR;

		public PhaserSprite _centralSprite;

		private MultiTargetTween _eyeTween;

		private float IntroDurationMS;

		private float LoopDurationMS;

		private List<string> _eyeFrames;

		private List<string> _eyeFrames2;

		private Timer bloodEmitterTimer;

		private Timer _musicIntroTimedEvent;

		private Timer _musicLoopEvent;

		private TweenerCore<Vector3, Vector3, VectorOptions> _eyeScaleTween;

		private Light2D _redLight;

		private int _wallEyesCounter;

		private List<PhaserSprite> _eyeWallSprites;

		private int _backgroundEyesCounter;

		private List<PhaserSprite> _eyeSprites;

		private float _geigerTime;

		private bool _isPlayingGeigerNoise;

		private bool _bgEnabled;

		public BackgroundDevilRoom_Helper(PhaserScene _scene, BackgroundDevilRoom _backgroundManager)
		{
		}

		public void MakeRedLight()
		{
		}

		public void DarkToLight(float value = 1f)
		{
		}

		public void StartMusic()
		{
		}

		private void RegisterMusicLoopEvents()
		{
		}

		public void RedLightSwoop(int index = 0)
		{
		}

		public void WallEyes(int index = 0, int amount = 1)
		{
		}

		public void BackgroundEyes(int index = 0, int amount = 1)
		{
		}

		public void PulseLight(float value = 1f)
		{
		}

		public void PulseBlood(float value = 1f)
		{
		}

		public void StartBlood(float value = 1f)
		{
		}

		public void TiltCamera()
		{
		}

		public void ResetCameraRotation()
		{
		}

		public void PulseBackground()
		{
		}

		public void MakeEmitters()
		{
		}

		public void MakeBackgrounds()
		{
		}

		public void TweenEye(PhaserSprite sprite)
		{
		}

		public void AddRotatingBackground()
		{
		}

		private void ReTween(SpriteRenderer s, int i)
		{
		}

		public void StartGeigerNoise()
		{
		}

		public void StopGeigerNoise()
		{
		}

		public void Update()
		{
		}

		public void DisableMovingBackground()
		{
		}
	}
}
