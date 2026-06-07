using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.Framework
{
	public class GizmoManager : IInitializable, IDisposable, ITickable
	{
		public float AngelYOffset;

		public float IconYOffset;

		public float LevelUpYOffset;

		[Inject]
		private GameSessionData _gameSessionData;

		private GameObject _particlesObject;

		private ParticleEmitterManager _particleEmitterManager;

		private ParticleSystem _pfxEmitter;

		private ParticleSystem _quickTreasureEmitter;

		private List<Sprite> _angelFrames;

		private PhaserSprite _highlight;

		private PhaserSprite _rainbow;

		private MultiTargetTween _highlightTween;

		private MultiTargetTween _highlightTween2;

		private MultiTargetTween _rainbowTween;

		private MultiTargetTween _rainbowTween2;

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public void Tick()
		{
		}

		public void ShowHighlightAt(float x, float y)
		{
		}

		public void DisplayLevelUp(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		public void DisplayLimitBreakLevelUp(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		public void DisplayMultiplayerRevive(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		public void DisplayWeaponLevelup(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		public void DisplayWeaponIconOverhead(WeaponType weaponType, string value, Color? color, VampireSurvivors.Objects.Characters.CharacterController character, float displayTimeMultiplier = 1f, Vector2 vOffset = default(Vector2))
		{
		}

		public void DisplayIconOverhead(string frameName, string value, Color? color, VampireSurvivors.Objects.Characters.CharacterController character, float displayTimeMultiplier = 1f, Vector2 vOffset = default(Vector2), string textureName = "items")
		{
		}

		public void DisplayQuickTreasureChestAnimation(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		private void Init()
		{
		}

		private void InitLevelUp()
		{
		}

		private void InitQuickTreasureChest()
		{
		}

		private void DisplayAngel(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}
	}
}
