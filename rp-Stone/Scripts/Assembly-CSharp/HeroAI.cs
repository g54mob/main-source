using UnityEngine;

[RequireComponent(typeof(Hero))]
public class HeroAI : HeroController
{
	public int ticsPerMoveH = 2;

	public int ticsPerMoveV = 4;

	public int ticsPerTargetAcquisition = 4;

	private int elapsedTicsMoveH;

	private int elapsedTicsMoveV;

	private int elapsedTicsTargetAcquisition;

	private HarvestableResource targetHarvest;

	public HarvestableResource nearestHarvest;

	private HarvestTool harvestTool;

	private int nearestDistance;

	private bool nextEnemyWithinRange;

	public static bool moveSpeedBuffsEnabled = true;

	public Enemy targetEnemy { get; set; }

	public Pickup targetPickup { get; set; }

	public WayPoint targetWaypoint { get; private set; }

	public float remainingPause { get; set; }

	public string DiagnosticString()
	{
		string text = "";
		if (targetEnemy != null)
		{
			text = text + "foe: " + targetEnemy.id + "(" + targetEnemy.GetStateNumericRepresentation() + ")";
		}
		else if (targetPickup != null)
		{
			text = text + "pickup: " + targetPickup.id;
		}
		else
		{
			text += "target: ";
			if (targetWaypoint != null)
			{
				text += targetWaypoint.id;
			}
			if (harvestTool != null)
			{
				text += harvestTool;
			}
		}
		text = text + " .distance: " + nearestDistance;
		if (nearestHarvest != null)
		{
			int num = nearestHarvest.character.PositionX - base.hero.PositionX;
			text = text + ", harvest: " + nearestHarvest.character.id + " .distance: " + num;
		}
		return text;
	}

	public override void UpdateTic()
	{
		if (base.hero.frozenTics > 0)
		{
			return;
		}
		base.UpdateTic();
		if (remainingPause > 0f)
		{
			remainingPause -= 0.03333333f;
			return;
		}
		elapsedTicsMoveH++;
		elapsedTicsMoveV++;
		elapsedTicsTargetAcquisition++;
		Level level = GameStates.Singleton.level;
		bool flag = (level.SecondsLeft() < 1 || level.QuestData.sections != null) && (level.Enemies.Count == 0 || (level.Enemies.Count == 1 && !level.Enemies[0].Alive));
		if (level.QuestData.sections != null && level.QuestData.sections.Length != 0 && (float)base.hero.PositionX < (float)((level.QuestData.sections.Length - 1) * 69) - 34.5f)
		{
			flag = false;
		}
		if (elapsedTicsTargetAcquisition >= ticsPerTargetAcquisition || (targetEnemy != null && !targetEnemy.Alive))
		{
			elapsedTicsTargetAcquisition = 0;
			targetEnemy = null;
			Enemy enemy = null;
			targetHarvest = null;
			nearestHarvest = null;
			harvestTool = null;
			targetPickup = null;
			targetWaypoint = null;
			nearestDistance = 9999;
			int num = 9999;
			for (int i = 0; i < level.Enemies.Count; i++)
			{
				Enemy enemy2 = level.Enemies[i];
				if (!enemy2.Alive || !enemy2.hostile)
				{
					continue;
				}
				int num2 = enemy2.PositionX - base.hero.PositionX;
				if (num2 > 0)
				{
					if (num2 < nearestDistance)
					{
						enemy = targetEnemy;
						num = nearestDistance;
						targetEnemy = enemy2;
						nearestDistance = num2;
					}
					else if (num2 < num)
					{
						enemy = enemy2;
						num = num2;
					}
				}
			}
			bool flag2 = targetEnemy != null && nearestDistance <= base.hero.ComputeMaxWeaponRange(targetEnemy);
			nextEnemyWithinRange = flag2 && enemy != null && num <= base.hero.ComputeMaxWeaponRange(enemy);
			if (!flag2 || targetEnemy.CurrentState == Enemy.State.Sleeping)
			{
				for (int j = 0; j < level.HarvestableResources.Count; j++)
				{
					HarvestableResource harvestableResource = level.HarvestableResources[j];
					if (!harvestableResource.character.Alive)
					{
						continue;
					}
					int num3 = harvestableResource.character.PositionX - base.hero.PositionX;
					if (num3 < 0 || num3 > nearestDistance || !Inventory.Singleton.HasToolToHarvest(harvestableResource.resourceType))
					{
						continue;
					}
					HarvestTool toolToHarvest = Inventory.Singleton.GetToolToHarvest(harvestableResource.resourceType);
					if (!(toolToHarvest == null))
					{
						if (nearestHarvest == null || (harvestableResource.character.PositionX < nearestHarvest.character.PositionX && harvestableResource.character.PositionX >= base.hero.PositionX))
						{
							nearestHarvest = harvestableResource;
						}
						if (Inventory.Singleton.IsToolToHarvestEquipped(harvestableResource.resourceType))
						{
							targetEnemy = null;
							targetHarvest = harvestableResource;
							harvestTool = toolToHarvest;
							nearestDistance = num3;
						}
					}
				}
				for (int k = 0; k < level.Pickups.Count; k++)
				{
					Pickup pickup = level.Pickups[k];
					if (pickup.Alive)
					{
						int num4 = pickup.PositionX - base.hero.PositionX;
						if (num4 < nearestDistance)
						{
							targetEnemy = null;
							targetHarvest = null;
							targetPickup = pickup;
							nearestDistance = num4;
						}
					}
				}
			}
			for (int l = 0; l < level.WayPoints.Count; l++)
			{
				WayPoint wayPoint = level.WayPoints[l];
				if (wayPoint.Alive)
				{
					int num5 = wayPoint.PositionX - base.hero.PositionX;
					if (num5 >= 0 && num5 < nearestDistance)
					{
						targetEnemy = null;
						targetHarvest = null;
						targetPickup = null;
						targetWaypoint = wayPoint;
						nearestDistance = num5;
					}
				}
			}
		}
		if (targetEnemy == null && targetHarvest == null && base.hero.CurrentState == Hero.State.Attacking)
		{
			base.hero.CancelAttack();
		}
		if (base.hero.CurrentState == Hero.State.Idle || base.hero.CurrentState == Hero.State.Walking)
		{
			if ((!flag || targetPickup != null || targetHarvest != null || targetWaypoint != null || (targetEnemy != null && targetEnemy.willProbablyDie && !nextEnemyWithinRange)) && elapsedTicsMoveH >= ComputeTicsPerMoveH())
			{
				if (targetPickup != null && targetPickup.PositionX < base.hero.PositionX + 2)
				{
					elapsedTicsMoveH = 0;
					base.hero.PositionX--;
					base.hero.SetState(Hero.State.Walking);
				}
				else if (base.hero.PositionX < level.heroLimitX)
				{
					int num6 = ((!(targetEnemy != null)) ? 1 : Mathf.Max(base.hero.ComputeMinWeaponRange(targetEnemy), 1));
					if ((targetEnemy == null && targetHarvest == null && targetPickup == null && targetWaypoint == null) || (targetEnemy != null && targetEnemy.PositionX - base.hero.PositionX > num6) || (targetEnemy != null && targetEnemy.willProbablyDie && !nextEnemyWithinRange && targetEnemy.PositionX - base.hero.PositionX > 4) || (targetHarvest != null && targetHarvest.character.PositionX - base.hero.PositionX > harvestTool.weapon.baseRange) || (targetPickup != null && targetPickup.PositionX - base.hero.PositionX > 3) || (targetWaypoint != null && targetWaypoint.PositionX > base.hero.PositionX))
					{
						elapsedTicsMoveH = 0;
						base.hero.PositionX++;
						base.hero.SetState(Hero.State.Walking);
					}
				}
			}
			if ((!flag || targetPickup != null || targetHarvest != null || targetWaypoint != null) && elapsedTicsMoveV >= ComputeTicsPerMoveV() && ((targetEnemy != null && targetEnemy.PositionZ != base.hero.PositionZ) || (targetHarvest != null && targetHarvest.character.PositionZ != base.hero.PositionZ) || (targetPickup != null && targetPickup.PositionZ != base.hero.PositionZ) || (targetWaypoint != null && targetWaypoint.PositionZ != base.hero.PositionZ)))
			{
				elapsedTicsMoveV = 0;
				int positionZ = base.hero.PositionZ;
				if (targetEnemy != null)
				{
					positionZ = targetEnemy.PositionZ;
				}
				else if (targetHarvest != null)
				{
					positionZ = targetHarvest.character.PositionZ;
				}
				else if (targetPickup != null)
				{
					positionZ = targetPickup.PositionZ;
				}
				else if (targetWaypoint != null)
				{
					positionZ = targetWaypoint.PositionZ;
				}
				if (base.hero.PositionZ < positionZ)
				{
					base.hero.PositionZ++;
				}
				else if (base.hero.PositionZ > positionZ)
				{
					base.hero.PositionZ--;
				}
				base.hero.SetState(Hero.State.Walking);
			}
		}
		if (targetEnemy != null)
		{
			base.hero.TryToAttack(targetEnemy);
		}
		if (targetHarvest != null)
		{
			base.hero.TryToAttack(targetHarvest.character);
		}
		if (targetPickup != null && base.hero.CurrentState != Hero.State.Attacking && targetPickup.PositionZ == base.hero.PositionZ)
		{
			int num7 = targetPickup.PositionX - base.hero.PositionX;
			if ((num7 <= 3 && num7 >= 2 && base.hero.lookDirection == Character.LookDirection.Right) || (num7 <= 3 && num7 >= -2 && base.hero.lookDirection == Character.LookDirection.Left))
			{
				base.hero.Pickup(targetPickup);
			}
		}
	}

	private int ComputeTicsPerMoveH()
	{
		if (base.hero.statModController != null && moveSpeedBuffsEnabled)
		{
			return base.hero.statModController.ModTicsPerMove(ticsPerMoveH);
		}
		return ticsPerMoveH;
	}

	private int ComputeTicsPerMoveV()
	{
		if (base.hero.statModController != null && moveSpeedBuffsEnabled)
		{
			return base.hero.statModController.ModTicsPerMove(ticsPerMoveV);
		}
		return ticsPerMoveV;
	}

	public override void UpdateInput(float deltaTime)
	{
	}

	public void PauseForSeconds(float time)
	{
		remainingPause = Mathf.Max(remainingPause, time);
	}

	private void Update()
	{
		if (QuickCheats.SkipAheadKeyPressed())
		{
			if (targetPickup != null)
			{
				base.hero.PositionX = targetPickup.PositionX - 2;
				base.hero.PositionZ = targetPickup.PositionZ;
			}
			else if (targetEnemy != null)
			{
				base.hero.PositionX = targetEnemy.PositionX - 5;
				base.hero.PositionZ = targetEnemy.PositionZ;
			}
			else if (targetHarvest != null)
			{
				base.hero.PositionX = targetHarvest.character.PositionX - 3;
				base.hero.PositionZ = targetHarvest.character.PositionZ;
			}
		}
	}

	private void HandleUpdateTic(Character c)
	{
		if (targetEnemy != null && targetEnemy.PositionX > base.hero.PositionX)
		{
			base.hero.lookDirection = Character.LookDirection.Right;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		base.hero.OnPostUpdateTic += HandleUpdateTic;
	}
}
