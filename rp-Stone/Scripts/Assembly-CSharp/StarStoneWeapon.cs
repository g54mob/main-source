using System.Collections.Generic;
using UnityEngine;

public class StarStoneWeapon : Weapon
{
	private struct PickupStruct
	{
		public Pickup pickup;

		public float offsetX;

		public float offsetZ;

		public float velX;

		public float velZ;
	}

	public int suckDistance = 20;

	public float acceleration = 0.2f;

	public float velocityZ = 0.25f;

	private int lastHeroX = -1;

	private List<PickupStruct> activePickups = new List<PickupStruct>();

	private Dictionary<Character, PickupStruct> activePickupsDict = new Dictionary<Character, PickupStruct>();

	private List<PickupStruct> _toExecute = new List<PickupStruct>();

	private int _lastLevel = -1;

	public static StarStoneWeapon singleton { get; private set; }

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (lastHeroX != base.Owner.PositionX)
		{
			lastHeroX = base.Owner.PositionX;
			CheckForPickups();
		}
		UpdateActivePickups();
	}

	private void CheckForPickups()
	{
		for (int i = 0; i < GameStates.Singleton.level.Pickups.Count; i++)
		{
			Pickup pickup = GameStates.Singleton.level.Pickups[i];
			if (!activePickupsDict.ContainsKey(pickup) && pickup.PositionX <= base.Owner.PositionX + suckDistance)
			{
				PickupStruct pickupStruct = new PickupStruct
				{
					pickup = pickup
				};
				activePickups.Add(pickupStruct);
				activePickupsDict.Add(pickup, pickupStruct);
				AchievementController.singleton.ReportStarStoneUsed();
			}
		}
	}

	private void UpdateActivePickups()
	{
		for (int num = activePickups.Count - 1; num >= 0; num--)
		{
			PickupStruct pickupStruct = activePickups[num];
			if (pickupStruct.pickup == null || !pickupStruct.pickup.Alive || pickupStruct.pickup.gameObject == null)
			{
				activePickups.RemoveAt(num);
			}
			else
			{
				if (pickupStruct.pickup.PositionX > base.Owner.PositionX + 2)
				{
					pickupStruct.velX -= acceleration;
				}
				else if (pickupStruct.pickup.PositionX < base.Owner.PositionX)
				{
					pickupStruct.velX += acceleration;
				}
				pickupStruct.offsetX += pickupStruct.velX;
				while (pickupStruct.offsetX > 1f)
				{
					pickupStruct.offsetX -= 1f;
					pickupStruct.pickup.PositionX++;
				}
				while (pickupStruct.offsetX < -1f)
				{
					pickupStruct.offsetX += 1f;
					pickupStruct.pickup.PositionX--;
				}
				if (pickupStruct.pickup.PositionX <= base.Owner.PositionX + suckDistance / 2)
				{
					pickupStruct.pickup.PositionY = 1;
				}
				if (pickupStruct.pickup.PositionZ > base.Owner.PositionZ)
				{
					pickupStruct.velZ = 0f - velocityZ;
				}
				else if (pickupStruct.pickup.PositionZ < base.Owner.PositionZ)
				{
					pickupStruct.velZ = velocityZ;
				}
				pickupStruct.offsetZ += pickupStruct.velZ;
				while (pickupStruct.offsetZ > 1f)
				{
					pickupStruct.offsetZ -= 1f;
					pickupStruct.pickup.PositionZ++;
				}
				while (pickupStruct.offsetZ < -1f)
				{
					pickupStruct.offsetZ += 1f;
					pickupStruct.pickup.PositionZ--;
				}
				if (pickupStruct.pickup.PositionX >= base.Owner.PositionX - 1 && pickupStruct.pickup.PositionX <= base.Owner.PositionX + 3)
				{
					pickupStruct.velX = 0f;
					if (pickupStruct.pickup.PositionZ >= base.Owner.PositionZ - 1 && pickupStruct.pickup.PositionZ <= base.Owner.PositionZ + 1)
					{
						_toExecute.Add(pickupStruct);
					}
				}
				activePickups[num] = pickupStruct;
			}
		}
		for (int i = 0; i < _toExecute.Count; i++)
		{
			_toExecute[i].pickup.ExecutePickUp(base.Owner);
			activePickups.Remove(_toExecute[i]);
			activePickupsDict.Remove(_toExecute[i].pickup);
		}
		_toExecute.Clear();
	}

	private void HandleDrawingIdle(AsciiSprite s, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		UpdateEquippedColor();
	}

	private void UpdateEquippedColor()
	{
		if (_lastLevel != level)
		{
			_lastLevel = level;
			Color colorForLevel = UpgradeRelicScreen.GetColorForLevel(level);
			idleSprite.colorOverride = colorForLevel;
			leftHandIdleSprite.colorOverride = colorForLevel;
			leftHandPickingUpSprite.colorOverride = colorForLevel;
		}
	}

	private void HandleUnequippedWeapon(Character c, Weapon w)
	{
		if (w == this)
		{
			activePickups.Clear();
			activePickupsDict.Clear();
		}
	}

	private void HandleCharacterCleanedUp(Character c)
	{
		if (activePickupsDict.ContainsKey(c))
		{
			PickupStruct item = activePickupsDict[c];
			activePickups.Remove(item);
			activePickupsDict.Remove(c);
		}
	}

	public static void Parse(string sjson)
	{
		if (!Inventory.Singleton.HasItemById("star_stone"))
		{
			singleton = null;
		}
	}

	public static void ClearProgress()
	{
		singleton = null;
	}

	protected override void Awake()
	{
		base.Awake();
		singleton = this;
		Character.OnCharacterUnequippedWeapon += HandleUnequippedWeapon;
		Character.OnCharacterCleanedUp += HandleCharacterCleanedUp;
		idleSprite.OnDraw += HandleDrawingIdle;
		leftHandIdleSprite.OnDraw += HandleDrawingIdle;
	}

	protected override void OnDestroy()
	{
		Character.OnCharacterUnequippedWeapon -= HandleUnequippedWeapon;
		Character.OnCharacterCleanedUp -= HandleCharacterCleanedUp;
		idleSprite.OnDraw -= HandleDrawingIdle;
		leftHandIdleSprite.OnDraw -= HandleDrawingIdle;
		if (singleton == this)
		{
			singleton = null;
		}
		base.OnDestroy();
	}
}
