using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects
{
	public class WorldEaterVFX
	{
		private PhaserSprite _sprite1;

		private MultiTargetTween _tween1;

		private PhaserSprite _faderImage;

		private MultiTargetTween _worldEaterTween1;

		private MultiTargetTween _worldEaterTween2;

		private MultiTargetTween _worldEaterTween3;

		private bool _isPlayingWorldEaterVfx;

		private PhaserSprite _worldEaterImage;

		private ParticleEmitterManager _pfxEmitter;

		private ParticleSystem _ppp;

		private List<PhaserSprite> _rays;

		private MultiTargetTween _raysTween;

		private VampireSurvivors.Objects.Characters.CharacterController _Owner;

		public int TriggeredTimes;

		public WorldEaterVFX(VampireSurvivors.Objects.Characters.CharacterController owner)
		{
		}

		public void CastSoulSteal(Action callback = null, bool isCursed = false)
		{
		}

		public void PlayWorldEater(Action callback = null, bool isCursed = false)
		{
		}

		public void DoSoulSteal(bool isCursed = false)
		{
		}

		public void ScreenShake()
		{
		}
	}
}
