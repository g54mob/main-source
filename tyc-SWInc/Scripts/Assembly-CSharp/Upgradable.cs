using System;
using UnityEngine;

public class Upgradable : MonoBehaviour
{
	public Transform SmokePosition;

	public float Quality = 1f;

	public float RepairTime;

	public float AtrophyModifier = 1f;

	public float FireStarter;

	public SDateTime LastRepair;

	public float TimeToAtrophy = 12f;

	public float MinutesToRepair = 5f;

	public bool DegradeAlways = true;

	public bool ModifiableAtrophy;

	public bool ManualDegrade;

	public bool AffectedByTemp;

	public bool AffectedByAirQuality;

	public bool Broken;

	public bool CanBreak = true;

	public Furniture furn;

	private Server server;

	public Animation Anim;

	[NonSerialized]
	public bool HasAnim;

	[NonSerialized]
	public SDateTime LastUpdate;

	private System.Random _fireStart;

	[NonSerialized]
	public bool FromInventory;

	private System.Random GetFireStart()
	{
		if (_fireStart == null)
		{
			_fireStart = new System.Random((int)furn.DID);
		}
		return _fireStart;
	}

	public string GetDescription()
	{
		return "State".Loc() + ": " + Mathf.Round(Quality * 100f) + "%";
	}

	private void Awake()
	{
		furn = GetComponent<Furniture>();
		HasAnim = Anim != null;
	}

	private void Start()
	{
		if (furn == null || furn.isTemporary)
		{
			Furniture furniture = furn ?? GetComponent<Furniture>();
			if (furniture.isTemporary)
			{
				furniture.PowerToggled(true);
			}
			return;
		}
		if (SmokePosition == null)
		{
			SmokePosition = base.transform;
		}
		server = GetComponent<Server>();
		LastUpdate = TimeOfDay.GetDateLocked();
		if (!furn.Deserialized)
		{
			LastRepair = TimeOfDay.GetDateLocked();
		}
		else
		{
			FixLastRepair();
		}
	}

	public void DegradeMonths(float months)
	{
		if (ModifiableAtrophy && AtrophyModifier == 0f)
		{
			return;
		}
		float num = months / TimeToAtrophy;
		num *= 1f - furn.Parent.GetAwardValue(AwardTrophy.BuffType.FurnitureBreakage);
		if (!(num > 0f))
		{
			return;
		}
		if (AffectedByTemp)
		{
			float temperature = furn.Parent.Temperature;
			if (temperature > 15f)
			{
				num *= 1f + (temperature - 12f) / 20f;
				if (temperature > 28f && !NotificationManager.CheckAggregate<FurnitureHeatNotification>(furn))
				{
					NotificationManager.AddNotification(new FurnitureHeatNotification(furn));
				}
			}
		}
		if (AffectedByAirQuality)
		{
			num *= 1f + furn.Parent.Smell;
		}
		if (ModifiableAtrophy)
		{
			num *= AtrophyModifier;
		}
		Quality = Mathf.Max(0f, Quality - num * UnityEngine.Random.Range(0.25f, 2f));
	}

	private void Degrade(SDateTime now)
	{
		float quality = Quality;
		if (UseAdvancedUpdate())
		{
			if (LastUpdate != now)
			{
				DegradeMonths(SDateTime.GetMonths(LastUpdate, now));
			}
		}
		else
		{
			Quality = Mathf.Min(Quality, SDateTime.GetMonths(LastRepair, now).MapRange(0f, TimeToAtrophy, 1f, 0f, true));
		}
		if (furn.ITFix)
		{
			if (Quality < 0.8f && quality >= 0.8f)
			{
				GameSettings.Instance.BrokenIT.Add(furn);
			}
			else if (quality < 1f && Quality >= 1f)
			{
				GameSettings.Instance.BrokenIT.Remove(furn);
			}
		}
	}

	public bool RepairMe(float factor = 1f)
	{
		if (!Broken && Quality >= 0.99f)
		{
			FixNow();
			return true;
		}
		RepairTime += Utilities.PerHour(60f / MinutesToRepair) * factor;
		if (RepairTime >= 1f - Quality)
		{
			FixNow();
			return true;
		}
		return false;
	}

	private void FixNow()
	{
		RepairTime = 0f;
		LastRepair = SDateTime.Now();
		Quality = 1f;
		GameSettings.Instance.BrokenIT.Remove(furn);
		if (CanBreak)
		{
			Broken = false;
		}
		if (furn.AlwaysOn)
		{
			furn.IsOn = true;
		}
		if (server != null)
		{
			GameSettings.CalculateServerPowerNow.Add(server.ServerName);
		}
		if (furn.AuraValues != null && furn.AuraValues.Length != 0)
		{
			furn.Parent.DirtyStateVariables = true;
		}
	}

	private bool UseAdvancedUpdate()
	{
		if (!ModifiableAtrophy && DegradeAlways && !AffectedByTemp)
		{
			return AffectedByAirQuality;
		}
		return true;
	}

	public void UpdateMe()
	{
		if (furn.isTemporary)
		{
			return;
		}
		if (CanBreak && Broken && GameSettings.GameSpeed > 0f && UnityEngine.Random.Range(0, 4 - HUD.Instance.GameSpeed) == 0 && furn.Parent.IsContentVisible())
		{
			HUD.Instance.SmokeSystem.Emit(new ParticleSystem.EmitParams
			{
				position = SmokePosition.position,
				velocity = new Vector3(UnityEngine.Random.Range(-0.1f, 0.1f), UnityEngine.Random.Range(1f, 2f), UnityEngine.Random.Range(-0.1f, 0.1f))
			}, 1);
		}
		if (HasAnim)
		{
			foreach (AnimationState item in Anim)
			{
				item.speed = ((furn.IsOn && !Broken) ? GameSettings.GameSpeed : 0f);
			}
		}
		if (!ManualDegrade && furn.IsActuallyPlayerControlled())
		{
			SDateTime sDateTime = SDateTime.Now();
			if (DegradeAlways || furn.IsOn)
			{
				Degrade(sDateTime);
			}
			if (UseAdvancedUpdate())
			{
				LastUpdate = sDateTime;
			}
		}
		if (!CanBreak || Quality != 0f || Broken)
		{
			return;
		}
		GameSettings.Instance.BrokenIT.Add(furn);
		if (FromInventory)
		{
			FromInventory = false;
		}
		else if (GameSettings.Instance.Difficulty.Fires > 0f && GameSettings.HasCompletedMission("Security") && furn.Parent.IsPlayerControlled() && GetFireStart().NextFloat() < FireStarter * furn.Parent.Temperature.MapRange(30f, 50f, 1f, 2f, true) && !GameSettings.Instance.CancelDanger())
		{
			NotificationManager.AddNotification(new SingleFurnitureNotification(furn, "FireWarningFurniture".Loc(), "Fire", SDateTime.Now(), NotificationManager.NotificationType.Warning));
			GameSettings.Instance.RegisterStat("Fires", 1f);
			if (furn.Parent.Outdoors || furn.Parent.Outside)
			{
				furn.SetFire();
			}
			else
			{
				furn.Parent.StartFire();
			}
		}
		if (furn.AuraValues != null && furn.AuraValues.Length != 0)
		{
			furn.Parent.DirtyStateVariables = true;
		}
		Broken = true;
		if (server != null)
		{
			GameSettings.CalculateServerPowerNow.Add(server.ServerName);
		}
		Battery component = GetComponent<Battery>();
		if (component != null)
		{
			component.CurrentCharge = 0f;
		}
		furn.IsOn = false;
		for (int i = 0; i < furn.InteractionPoints.Length; i++)
		{
			furn.InteractionPoints[i].ClearQueue();
		}
		FurnitureRepairNotification.RepairType repairType = ((!furn.ITFix) ? FurnitureRepairNotification.RepairType.Janitor : FurnitureRepairNotification.RepairType.IT);
		if (!NotificationManager.CheckAggregate<FurnitureRepairNotification>(furn, (uint)repairType))
		{
			NotificationManager.AddNotification(new FurnitureRepairNotification(repairType, furn));
		}
		TutorialSystem.Instance.StartTutorial("Staff");
	}

	public void BreakNow()
	{
		if (CanBreak && !Broken)
		{
			Quality = 0f;
			Broken = true;
			GameSettings.Instance.BrokenIT.Add(furn);
			if (server != null)
			{
				GameSettings.CalculateServerPowerNow.Add(server.ServerName);
			}
			furn.IsOn = false;
			for (int i = 0; i < furn.InteractionPoints.Length; i++)
			{
				furn.InteractionPoints[i].ClearQueue();
			}
		}
	}

	public void Deserialize(WriteDictionary dictionary)
	{
		Quality = dictionary.Get("Quality", 1f);
		SDateTime dateLocked = TimeOfDay.GetDateLocked();
		LastRepair = dictionary.Get("LastRepair", dateLocked);
		RepairTime = dictionary.Get("RepairTime", 0);
		AtrophyModifier = dictionary.Get("AtrophyModifier", 1f);
		Broken = dictionary.Get("Broken", CanBreak && Quality == 0f);
		_fireStart = dictionary.Get<System.Random>("FireStart", null);
	}

	public void FixLastRepair()
	{
		if (!UseAdvancedUpdate())
		{
			SDateTime dateLocked = TimeOfDay.GetDateLocked();
			if (!SDateTime.GetMonths(LastRepair, dateLocked).MapRange(0f, TimeToAtrophy, 1f, 0f, true).Appx(Quality, 0.01f))
			{
				SetLastRepair(dateLocked);
			}
		}
	}

	public void SetLastRepair(SDateTime now)
	{
		float num = TimeToAtrophy * (1f - Quality);
		LastRepair = now - num;
	}

	public void Serialize(WriteDictionary dictionary)
	{
		dictionary["Quality"] = Quality;
		dictionary["LastRepair"] = LastRepair;
		dictionary["RepairTime"] = RepairTime;
		dictionary["AtrophyModifier"] = AtrophyModifier;
		if (CanBreak)
		{
			dictionary["Broken"] = Broken;
		}
		if (_fireStart != null)
		{
			dictionary["FireStart"] = _fireStart;
		}
	}

	public static void SerializeReset(WriteDictionary dictionary)
	{
		dictionary["Quality"] = 1;
		dictionary["LastRepair"] = null;
		dictionary["RepairTime"] = 0;
		dictionary["AtrophyModifier"] = 1f;
		dictionary["FireStart"] = null;
	}
}
