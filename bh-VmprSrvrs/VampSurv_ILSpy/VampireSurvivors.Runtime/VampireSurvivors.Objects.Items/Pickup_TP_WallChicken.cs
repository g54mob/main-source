using DarkTonic.MasterAudio;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class Pickup_TP_WallChicken : NetworkPickup
{
	protected override void Awake()
	{
		//IL_0016: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
	}

	public override void SetData(ItemType itemType)
	{
		base.SetData(itemType);
		OnRecycle();
	}

	protected virtual void OnRecycle()
	{
	}

	public override void GetTaken()
	{
		//IL_0089: Expected O, but got I4
		//IL_022a: Expected O, but got I4
		//IL_0132: Expected O, but got I4
		if (!((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			_targetPlayer.RecoverHp(((Pickup)this)._003CValue_003Ek__BackingField, showRecovery: true, mulByRegen: true);
			CharacterController targetPlayer = _targetPlayer;
			_targetPlayer.IsInvul = true;
			float invincibilityTimer = targetPlayer._invincibilityTimer + 0.3f;
			targetPlayer._invincibilityTimer = invincibilityTimer;
			base.AddToRunPickups();
			base.SetHasSeenItem();
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Recovery, soundConfig, 500f, 5, time);
			GameManager gameManager = _gameManager;
			ArcanaManager arcanaManager = gameManager._arcanaManager;
			CharacterController targetPlayer2 = _targetPlayer;
			bool flag = targetPlayer2._deficiencyControl == null;
			bool flag2 = true;
			if (!flag)
			{
				CharacterADControl deficiencyControl = targetPlayer2._deficiencyControl;
				object obj = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
				bool flag3 = obj == null;
				flag2 = !flag3;
			}
			int num = targetPlayer2._PlayerIndex >> 31;
			int num2 = (flag2 ? 1 : 0) & num;
			bool flag4 = num2 == 0;
			object obj2 = !flag4;
			if (obj2 == null && arcanaManager._hasBreadAnathema)
			{
				arcanaManager.arcanaManager_Support.OnFoodPickedUp(targetPlayer2, ((Pickup)this)._003CPickupType_003Ek__BackingField, ((Pickup)this)._003CValue_003Ek__BackingField);
			}
			if (!_taken)
			{
				((Pickup)this).GetTaken();
				_taken = true;
			}
		}
	}
}
