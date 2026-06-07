using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Stages
{
	public class BackgroundBatCountry : BackgroundManager
	{
		[HideInInspector]
		public float _LerpV;

		private bool _canChangeColor;

		private bool _fixedBgColor;

		private int _colorIndex;

		private float2 _center;

		private readonly uint[] _colorsTop;

		private readonly uint[] _colorsBottom;

		private GottaSphereFast _sphereImage;

		private RainbowCheckerboard _checkerboardImage;

		private MultiTargetTween _sphereAlphaTween;

		private MultiTargetTween _checkerboardAlphaTween;

		private Timer _colorChangeTimeout;

		private PhaserSprite _backgroundTile;

		private Timer _pizzaDelayTimer;

		private bool _customBG;

		private bool _canPizza;

		private bool _isTilesetVisible;

		private bool _isCheckerBoardVisible;

		private bool _isSphereVisible;

		private Circle _pizzaA;

		private PhaserSprite _pizzaAsprite;

		private PhaserSprite _pizzaBsprite;

		private Circle _pizzaB;

		private PhaserSprite _pizzaCsprite;

		private Circle _pizzaC;

		private MapToken _mapToken;

		private Timer _checkSecretTimer;

		protected override void OnUpdate()
		{
		}

		public override void Cleanup()
		{
		}

		public override void Create()
		{
		}

		public override void OnInitCompleted()
		{
		}

		public override void CheckMinute(int minute)
		{
		}

		private void InitBackground()
		{
		}

		private void InitVFX()
		{
		}

		private void StartColorChange()
		{
		}

		private void GetCenter()
		{
		}

		private void ChangeColor()
		{
		}

		public override void DisableMovingBackground()
		{
		}

		public override void EnableMovingBackground()
		{
		}

		private void FadeSphere(float value, float duration)
		{
		}

		private void FadeCheckerboard(float value, float duration)
		{
		}

		private void BonusRound()
		{
		}

		private void EndBonusRound()
		{
		}

		private void FadeTileset(float alpha = 1f, float durationMillis = 1000f)
		{
		}

		private void SpawnRelicInConcrete(ItemType relicType)
		{
		}

		private void DisplayWarningZone()
		{
		}

		private void SingleWarning(float2 position)
		{
		}

		public void MakePizza()
		{
		}

		public void CheckPizzas(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		public void AnimPizza(PhaserSprite pizzaSprite)
		{
		}

		public void DelayPizza()
		{
		}

		public void MakeRings()
		{
		}

		public void CheckSecret()
		{
		}
	}
}
