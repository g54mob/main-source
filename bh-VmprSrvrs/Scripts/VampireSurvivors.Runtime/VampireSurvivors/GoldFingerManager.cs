using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors
{
	public class GoldFingerManager
	{
		private PhaserScene _scene;

		private CharacterController _player;

		private PhaserSprite _fogRays;

		private PhaserSprite _logoSprite;

		private PhaserSprite _logoSpriteShadow;

		private PhaserSprite _clapSpriteL;

		private PhaserSprite _clapSpriteR;

		private BitmapText _totalText;

		private float _targetScale;

		private int _awardReached;

		private float _elapsedGfBonusTime;

		private float _gFCooldownBonus;

		private float _startingEnemiesCounter;

		private int _shadowBumps;

		private int _previousAwardReached;

		private float _gfEndInvulBonusTime;

		private MultiTargetTween _logoTween1;

		private MultiTargetTween _logoTween2;

		private MultiTargetTween _logoTween3;

		private MultiTargetTween _exitTween;

		private MultiTargetTween _clapTweenL;

		private MultiTargetTween _clapTweenR;

		private MultiTargetTween _clapAlphaTween;

		private MultiTargetTween _shadowTween;

		private List<float> _fontScales;

		private List<uint> _fontTints;

		private List<int> _thresholds;

		private List<string> _frames;

		private const float GfDuration = 10000f;

		private float GFDurationWithBonus => 0f;

		public GoldFingerManager(PhaserScene scene)
		{
		}

		public void ActivateGoldFinger(CharacterController targetPlayer)
		{
		}

		public void GoldenFingerUpdate()
		{
		}

		private void GiveAward(int award = 0)
		{
		}

		private void DoExitAnimation()
		{
		}

		private float CurrentEnemiesCounter()
		{
			return 0f;
		}

		private void MakeItem(List<ItemType> choices)
		{
		}

		private void GiveRandomWeapon(List<WeaponType> choices)
		{
		}

		private void SendCoins(bool isRandomType = false, int totalCoins = 32)
		{
		}

		private static float Approach(float start, float end, float shift)
		{
			return 0f;
		}
	}
}
