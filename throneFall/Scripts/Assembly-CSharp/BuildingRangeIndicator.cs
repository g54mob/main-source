using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingRangeIndicator : MonoBehaviour
{
	public Transform weaponsParent;

	public BuildSlot buildSlot;

	public BuildingInteractor interactor;

	public Shrine optionalShrine;

	private Coroutine tickRoutine;

	public void Activate()
	{
		if (tickRoutine != null)
		{
			StopCoroutine(tickRoutine);
			tickRoutine = null;
		}
		tickRoutine = StartCoroutine(Tick());
	}

	private IEnumerator Tick()
	{
		while (true)
		{
			bool flag = false;
			bool flag2 = false;
			float num = 0f;
			float num2 = 0f;
			if (DayNightCycle.Instance.CurrentTimestate == DayNightCycle.Timestate.Day && (buildSlot.State == BuildSlot.BuildingState.Built || interactor.Focussed))
			{
				foreach (Transform item in weaponsParent)
				{
					if (!item.gameObject.activeSelf)
					{
						continue;
					}
					AutoAttack component = item.GetComponent<AutoAttack>();
					PerkDestroyGameObjectModifyer component2 = item.GetComponent<PerkDestroyGameObjectModifyer>();
					if ((bool)component2 && component2.IsGoingToBeDestroyed)
					{
						continue;
					}
					PerkRangeModifyer component3 = item.GetComponent<PerkRangeModifyer>();
					float num3 = 1f;
					if ((bool)component3 && component3.IsActive)
					{
						num3 = component3.rangeMultiplyer;
					}
					if (!component)
					{
						continue;
					}
					if (item.gameObject.activeInHierarchy)
					{
						flag = true;
						foreach (TargetPriority targetPriority in component.targetPriorities)
						{
							if (targetPriority.range * num3 > num)
							{
								num = targetPriority.range * num3;
							}
						}
						continue;
					}
					flag2 = true;
					foreach (TargetPriority targetPriority2 in component.targetPriorities)
					{
						if (targetPriority2.range * num3 > num2)
						{
							num2 = targetPriority2.range * num3;
						}
					}
				}
				if (buildSlot.CanBeUpgraded)
				{
					List<GameObject> list = new List<GameObject>();
					List<GameObject> gameObjectsThatWillUnlockWhenUpgraded = buildSlot.GetGameObjectsThatWillUnlockWhenUpgraded(BuildingInteractor.CurrentUpgradePreviewBranchNumber);
					list.AddRange(gameObjectsThatWillUnlockWhenUpgraded);
					foreach (GameObject item2 in list)
					{
						AutoAttack component4 = item2.GetComponent<AutoAttack>();
						PerkDestroyGameObjectModifyer component5 = item2.GetComponent<PerkDestroyGameObjectModifyer>();
						if ((bool)component5 && component5.IsGoingToBeDestroyed)
						{
							continue;
						}
						PerkRangeModifyer component6 = item2.GetComponent<PerkRangeModifyer>();
						float num4 = 1f;
						if ((bool)component6 && component6.IsActive)
						{
							num4 = component6.rangeMultiplyer;
						}
						if ((bool)component4)
						{
							flag2 = true;
							foreach (TargetPriority targetPriority3 in component4.targetPriorities)
							{
								if (targetPriority3.range * num4 > num2)
								{
									num2 = targetPriority3.range * num4;
								}
							}
						}
						TowerUpgrade component7 = item2.GetComponent<TowerUpgrade>();
						if ((bool)component7)
						{
							flag2 = true;
							num2 *= component7.RangeMulti;
							break;
						}
					}
				}
				if (optionalShrine != null)
				{
					if (!optionalShrine.ShrineHasBeenActivated)
					{
						RangeIndicatorHandler.instance.ShowIndicator(base.transform.position, optionalShrine.CollectionRange, base.gameObject, RangeIndicatorHandler.IndicatorType.Special);
					}
					else
					{
						RangeIndicatorHandler.instance.HideIndicator(base.gameObject, RangeIndicatorHandler.IndicatorType.Special);
					}
				}
			}
			if (flag)
			{
				RangeIndicatorHandler.instance.ShowIndicator(base.transform.position, num, base.gameObject, RangeIndicatorHandler.IndicatorType.Built);
			}
			else
			{
				RangeIndicatorHandler.instance.HideIndicator(base.gameObject, RangeIndicatorHandler.IndicatorType.Built);
			}
			if (flag2 && !Mathf.Approximately(num, num2))
			{
				RangeIndicatorHandler.instance.ShowIndicator(base.transform.position, num2, base.gameObject, RangeIndicatorHandler.IndicatorType.Preview);
			}
			else
			{
				RangeIndicatorHandler.instance.HideIndicator(base.gameObject, RangeIndicatorHandler.IndicatorType.Preview);
			}
			yield return null;
		}
	}

	public void Deactivate()
	{
		StopAllCoroutines();
		RangeIndicatorHandler.instance.HideIndicator(base.gameObject, RangeIndicatorHandler.IndicatorType.Built);
		RangeIndicatorHandler.instance.HideIndicator(base.gameObject, RangeIndicatorHandler.IndicatorType.Preview);
		if ((bool)optionalShrine)
		{
			RangeIndicatorHandler.instance.HideIndicator(base.gameObject, RangeIndicatorHandler.IndicatorType.Special);
		}
	}
}
