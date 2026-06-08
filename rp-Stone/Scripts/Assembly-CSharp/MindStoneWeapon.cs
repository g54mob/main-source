using UnityEngine;

public class MindStoneWeapon : Weapon
{
	private const string ABILITY_NAME = "mind";

	public Decoration dodgeVfxPrefab;

	private int cooldownDuration = 360;

	private int dodgeDistance = 15;

	private bool isReady = true;

	private bool dodgePending;

	private AbilityClock clock;

	private void DodgeBack()
	{
		if ((bool)base.Owner)
		{
			Decoration decoration = Object.Instantiate(dodgeVfxPrefab);
			decoration.PositionX = base.Owner.PositionX;
			decoration.PositionY = base.Owner.PositionY;
			decoration.PositionZ = base.Owner.PositionZ;
			GameStates.Singleton.level.AddCharacter(decoration);
			base.Owner.PositionX -= dodgeDistance;
			AchievementController.singleton.ReportMindStoneUsed();
		}
	}

	private void Update()
	{
		if (!isReady && GameStates.Singleton.CurrentState < GameStates.State.Playing)
		{
			isReady = true;
		}
		if (currentSprite != null)
		{
			currentSprite.colorOverride = (isReady ? ColorConstants.white : ColorConstants.grey);
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (dodgePending && GameStates.Singleton.CurrentState == GameStates.State.Playing)
		{
			dodgePending = false;
			SetState(State.Cooldown);
			clock.Play();
			DodgeBack();
		}
		else
		{
			CheckTime();
		}
	}

	private void HandleCharacterEquippedWeapon(Character c, Weapon w)
	{
		if (w == this && (GameStates.Singleton.CurrentState == GameStates.State.Playing || GameStates.Singleton.CurrentState == GameStates.State.PlayItemScreen))
		{
			CheckTime();
			if (isReady)
			{
				isReady = false;
				dodgePending = true;
			}
		}
	}

	private void CheckTime()
	{
		if (!isReady && clock.GetPercent() >= 1f)
		{
			isReady = true;
		}
	}

	private void Start()
	{
		Character.OnCharacterEquippedWeapon += HandleCharacterEquippedWeapon;
	}

	protected override void Awake()
	{
		base.Awake();
		clock = AbilityClock.GetClockForAbility("mind");
		clock.duration = cooldownDuration;
		clock.elapsed = cooldownDuration;
	}

	protected override void OnDestroy()
	{
		Character.OnCharacterEquippedWeapon -= HandleCharacterEquippedWeapon;
		clock = null;
		base.OnDestroy();
	}
}
