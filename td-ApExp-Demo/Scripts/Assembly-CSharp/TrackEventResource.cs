using System;
using UnityEngine;

public class TrackEventResource : TrackEvent
{
	public static bool isResourceSignalActivated;

	private TrackEventIndicator indicator2;

	private TrackEventIndicator[] indicators;

	public Vector3 SpawnPos { get; private set; }

	public bool DoubleSpawn { get; private set; }

	public ResourceTypes ResourceType { get; private set; }

	public ResourceTypes ResourceType2 { get; private set; }

	public static event Action OnResourceSignalActivated;

	public TrackEventResource(float schedule, ResourceTypes resourceType)
	{
		base.ScheduledDistance = schedule;
		ResourceType = resourceType;
	}

	public override void Update()
	{
		base.Update();
		if (indicators == null)
		{
			return;
		}
		TrackEventIndicator[] array = indicators;
		foreach (TrackEventIndicator trackEventIndicator in array)
		{
			if (!IsWithinRange())
			{
				trackEventIndicator.gameObject.SetActive(value: false);
				break;
			}
			trackEventIndicator.StartWarning();
			int radarLevel = UIManager.Instance.radarLevel;
			if (radarLevel == 0)
			{
				if (ResourceType == ResourceTypes.Ammo)
				{
					if (trackEventIndicator == indicator)
					{
						trackEventIndicator.SetColor(UIManager.Instance.ColorGreen);
					}
					else
					{
						trackEventIndicator.SetColor(new Color(0.67f, 0.39f, 0.2f));
					}
				}
				else if (ResourceType == ResourceTypes.Scrap)
				{
					if (trackEventIndicator == indicator)
					{
						trackEventIndicator.SetColor(new Color(0.67f, 0.39f, 0.2f));
					}
					else
					{
						trackEventIndicator.SetColor(UIManager.Instance.ColorGreen);
					}
				}
				else if (ResourceType == ResourceTypes.Rerolls)
				{
					if (trackEventIndicator == indicator)
					{
						trackEventIndicator.SetColor(new Color(0.67f, 0.39f, 0.2f));
					}
					else
					{
						trackEventIndicator.SetColor(UIManager.Instance.ColorGreen);
					}
				}
				trackEventIndicator.DistancePanelTf.gameObject.SetActive(value: false);
			}
			else
			{
				if (radarLevel >= 1)
				{
					trackEventIndicator.SetColor(distanceColor);
				}
				if (radarLevel == 2)
				{
					trackEventIndicator.DistancePanelTf.gameObject.SetActive(value: true);
					trackEventIndicator.DistanceText.text = coloredDistanceString;
				}
			}
		}
	}

	public override void StartEvent()
	{
		base.StartEvent();
		isResourceSignalActivated = true;
		if (ResourceType == ResourceTypes.Ammo)
		{
			indicator = UIManager.Instance.IndicatorAmmo;
		}
		else if (ResourceType == ResourceTypes.Scrap)
		{
			indicator = UIManager.Instance.IndicatorScrap;
		}
		else if (ResourceType == ResourceTypes.Rerolls)
		{
			indicator = UIManager.Instance.IndicatorBoom;
		}
		DoubleSpawn = UnityEngine.Random.Range(0f, 100f) < LevelManager.Instance.Config.DoubleResourcePercentChance;
		int num = 0;
		TrackEventResource currentResourceEvent = LevelManager.Instance.CurrentResourceEvent;
		TrackEventSwitch currentSwitchEvent = LevelManager.Instance.CurrentSwitchEvent;
		num = ((currentSwitchEvent == null || !(Mathf.Abs(currentResourceEvent.ScheduledDistance - currentSwitchEvent.ScheduledDistance) < 20f)) ? ((UnityEngine.Random.Range(0, 2) == 0) ? 1 : (-1)) : ((currentSwitchEvent.trackSwitchDir == TrainDirections.Left) ? 1 : (-1)));
		float num2 = (float)UnityEngine.Random.Range(1, 4) * 0.2f;
		SpawnPos = new Vector3(0f, (float)num * num2);
		RectTransform component = indicator.GetComponent<RectTransform>();
		component.anchoredPosition = new Vector3(component.anchoredPosition.x, SpawnPos.y * 100f);
		if (DoubleSpawn)
		{
			if (ResourceType == ResourceTypes.Rerolls)
			{
				if (ProbUtils.CheckWithReverseLuck(TrackManager.Instance.ChanceForFakeResources) && ZoneManager.Instance.CurrentZone.Definition.ZoneName == "Z4_Snow")
				{
					indicator2 = UIManager.Instance.IndicatorBoom2;
					ResourceType2 = ResourceTypes.Rerolls;
				}
				else if (LootUtils.GetWeightedIndex(new float[2]
				{
					LevelManager.Instance.Config.ResourceWeightAmmo,
					LevelManager.Instance.Config.ResourceWeightScrap
				}) == 1)
				{
					indicator2 = UIManager.Instance.IndicatorScrap;
					ResourceType2 = ResourceTypes.Scrap;
				}
				else
				{
					indicator2 = UIManager.Instance.IndicatorAmmo;
					ResourceType2 = ResourceTypes.Ammo;
				}
			}
			else if (ProbUtils.CheckWithReverseLuck(TrackManager.Instance.ChanceForFakeResources) && ZoneManager.Instance.CurrentZone.Definition.ZoneName == "Z4_Snow")
			{
				indicator2 = UIManager.Instance.IndicatorBoom2;
				ResourceType2 = ResourceTypes.Rerolls;
			}
			else if (ResourceType == ResourceTypes.Ammo)
			{
				indicator2 = UIManager.Instance.IndicatorScrap;
				ResourceType2 = ResourceTypes.Scrap;
			}
			else if (ResourceType == ResourceTypes.Scrap)
			{
				indicator2 = UIManager.Instance.IndicatorAmmo;
				ResourceType2 = ResourceTypes.Ammo;
			}
			RectTransform component2 = indicator2.GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector3(component2.anchoredPosition.x, (0f - SpawnPos.y) * 100f);
		}
		if (DoubleSpawn)
		{
			indicators = new TrackEventIndicator[2] { indicator, indicator2 };
		}
		else
		{
			indicators = new TrackEventIndicator[1] { indicator };
		}
		TrackEventResource.OnResourceSignalActivated?.Invoke();
	}

	public override void EndEvent()
	{
		isResourceSignalActivated = false;
		indicator?.StopWarning();
		indicator2?.StopWarning();
	}
}
