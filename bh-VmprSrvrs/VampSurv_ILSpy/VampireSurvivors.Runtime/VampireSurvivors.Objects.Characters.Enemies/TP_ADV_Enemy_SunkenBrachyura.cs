using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class TP_ADV_Enemy_SunkenBrachyura : EnemyCrabbino
{
	protected override void Awake()
	{
		//IL_0094: Expected O, but got I8
		//IL_00a5: Expected O, but got I4
		//IL_001e: Expected O, but got I4
		//IL_004a: Expected O, but got I4
		//IL_005d: Expected O, but got I8
		//IL_006e: Expected O, but got I4
		((EnemyController)this).Awake();
		PhaserSprite pincerSpriteL = _pincerSpriteL;
		LeftOffset = (Vector2)3196730737L;
		_ = 1049582633;
		RightOffset = (Vector2)1049247089;
		_ = 1049582633;
		PhaserSprite phaserSprite = _pincerSpriteL.setOrigin(pincerSpriteL._originX, (float?)(object)1);
		PhaserSprite pincerSpriteR = _pincerSpriteR;
		PhaserSprite phaserSprite2 = _pincerSpriteR.setOrigin(pincerSpriteR._originX, (float?)(object)1);
		LeftOffset = (Vector2)3205287117L;
		_ = 1056964608;
		RightOffset = (Vector2)1057803469;
		_ = 1056964608;
	}

	protected override void SetupPincers()
	{
		//IL_00bf: Expected O, but got I4
		//IL_00eb: Expected O, but got I4
		PhaserSprite phaserSprite = RenderingExtensions.SetScale(_pincerSpriteL, 1f);
		PhaserSprite phaserSprite2 = RenderingExtensions.SetScale(_pincerSpriteR, 1f);
		Sprite sprite = SpriteManager.GetSprite("TP_BrachyuraClawL_i", "TP_enemies");
		PhaserSprite phaserSprite3 = _pincerSpriteL.setFrame(sprite);
		Sprite sprite2 = SpriteManager.GetSprite("TP_BrachyuraClawR_i", "TP_enemies");
		PhaserSprite phaserSprite4 = _pincerSpriteR.setFrame(sprite2);
		PhaserSprite pincerSpriteL = _pincerSpriteL;
		PhaserSprite phaserSprite5 = _pincerSpriteL.setOrigin(pincerSpriteL._originX, (float?)(object)1);
		PhaserSprite pincerSpriteR = _pincerSpriteR;
		PhaserSprite phaserSprite6 = _pincerSpriteR.setOrigin(pincerSpriteR._originX, (float?)(object)1);
		Tween fadeOutPincersTween = _fadeOutPincersTween;
		if (_fadeOutPincersTween != null && fadeOutPincersTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_fadeOutPincersTween);
		}
		PhaserSprite phaserSprite7 = _pincerSpriteL.setTint(_saveTint);
		PhaserSprite phaserSprite8 = _pincerSpriteR.setTint(_saveTint);
		base.UpdatePincerTransforms();
	}
}
