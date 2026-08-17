using System;
using System.Collections.Generic;
using Assets.Scripts._Data;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Upgrades;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine;

public class WeaponData : UnlockableBase, IUpgradable
{
	public EWeapon eWeapon;

	public Texture icon;

	public bool onlySpawnWhenCloseEnemies;

	public Dictionary<EStat, float> baseStats;

	public float damage;

	public float knockback;

	public float critChance;

	public EElement element;

	public int projectiles;

	public int projectileBounces;

	public float attackDuration;

	public float maxDuration;

	public float maxSizeMultiplier;

	public float effectDuration;

	public float projectileSpeed;

	public float endCooldown;

	public float burstTime;

	public float minBurstInterval;

	public bool canBounce;

	public EAmplificationMode amplificationMode;

	public float procCoefficient;

	public bool useVision;

	public bool canMultiHit;

	public bool hasCrosshair;

	public float spawnProjectileRange;

	public bool isAura;

	public Vector3 spawnOffset;

	public GameObject attack;

	public UpgradeData upgradeData;

	public MyAchievement AchievementRequirement;

	private string _003CdamageSourceName_003Ek__BackingField;

	public string damageSourceName
	{
		get
		{
			return _003CdamageSourceName_003Ek__BackingField;
		}
		private set
		{
			_003CdamageSourceName_003Ek__BackingField = value;
		}
	}

	public unsafe void Init()
	{
		//IL_012d: Expected O, but got Ref
		//IL_0083: Expected F4, but got I4
		//IL_009e: Expected F4, but got I4
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		_003CdamageSourceName_003Ek__BackingField = text;
		Dictionary<EStat, float> dictionary = new Dictionary<EStat, float>();
		dictionary._002Ector();
		baseStats = dictionary;
		((Dictionary<System.Int32Enum, float>)(object)baseStats).Add((System.Int32Enum)15, 1f);
		((Dictionary<System.Int32Enum, float>)(object)baseStats).Add((System.Int32Enum)12, damage);
		((Dictionary<System.Int32Enum, float>)(object)baseStats).Add((System.Int32Enum)24, knockback);
		((Dictionary<System.Int32Enum, float>)(object)baseStats).Add((System.Int32Enum)16, (float)projectiles);
		((Dictionary<System.Int32Enum, float>)(object)baseStats).Add((System.Int32Enum)45, (float)projectileBounces);
		((Dictionary<System.Int32Enum, float>)(object)baseStats).Add((System.Int32Enum)10, attackDuration);
		((Dictionary<System.Int32Enum, float>)(object)baseStats).Add((System.Int32Enum)11, projectileSpeed);
		((Dictionary<System.Int32Enum, float>)(object)baseStats).Add((System.Int32Enum)9, 1f);
		((Dictionary<System.Int32Enum, float>)(object)baseStats).Add((System.Int32Enum)18, critChance);
		((Dictionary<System.Int32Enum, float>)(object)baseStats).Add((System.Int32Enum)19, 0f);
	}

	public string GetUpgradeDescription(int level, List<StatModifier> upgradeOffer, ERarity rarity)
	{
		if (level != 0)
		{
			return StatUtility.GetUpgradeDescriptionWeapon(upgradeOffer, this);
		}
		return base.GetDescription();
	}

	public override Texture GetIcon()
	{
		return icon;
	}

	public override MyAchievement GetUnlockRequirement()
	{
		return AchievementRequirement;
	}

	public override UnlockableBase GetUnlockableRequirement()
	{
		return null;
	}

	public override string GetUnlockableTypeDisplayString()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831721A3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return LocalizationUtility.GetLocalizedString("Unlockables", "WEAPON", "Weapon");
	}

	public unsafe override string GetInternalName()
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		return ((Enum)(&obj)).ToString();
	}

	public int GetLevel()
	{
		//IL_007d: Expected I4, but got O
		if ((object)GameManager.Instance != null)
		{
			PlayerInventory playerInventory = GameManager.Instance.GetPlayerInventory();
			if (playerInventory != null && playerInventory.weaponInventory != null)
			{
				return playerInventory.weaponInventory.GetWeaponLevel(eWeapon);
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public int GetMaxLevel()
	{
		return InventoryUtility.GetWeaponMaxLevel();
	}

	public List<StatModifier> GetUpgradeOffer(ERarity rarity)
	{
		if ((object)upgradeData != null)
		{
			return upgradeData.GetUpgradeOffer(rarity, eWeapon);
		}
		return (List<StatModifier>)(object)new NullReferenceException();
	}

	public float GetBaseStat(EStat eStat)
	{
		return ((Dictionary<System.Int32Enum, float>)(object)baseStats).get_Item((System.Int32Enum)eStat);
	}

	public float CalculateTotalDistance(float initialSpeed, float reduction)
	{
		//IL_0009: Invalid comparison between F4 and I4
		//IL_001b: Expected F4, but got I4
		//IL_0032: Expected F4, but got I4
		//IL_00c9: Invalid comparison between I4 and F4
		//IL_006e: Expected F4, but got I4
		//IL_008e: Invalid comparison between F4 and I4
		float num = default(float);
		bool flag = !(num > 0f);
		float result = 0f;
		if (!flag)
		{
			float num2 = 0f;
			do
			{
				num2 += num;
				num -= reduction;
				if (!(0f > num))
				{
					if (num > 99f)
					{
						num = 99f;
					}
				}
				else
				{
					num = 0f;
				}
			}
			while (num > 0f);
			result = num2;
		}
		return result;
	}

	public float GetSpawnProjectileRange()
	{
		return spawnProjectileRange;
	}

	public override string ToString()
	{
		//IL_0141: Expected I4, but got O
		string[] array = new string[10];
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string text = $"Cooldown: {arg}\n";
		if (array.Length > 0)
		{
			array[0] = text;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			string text2 = $"Damage: {arg2}\n";
			if (array.Length > 1)
			{
				array[1] = text2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object arg3 = default(object);
				string text3 = $"Knockback: {arg3}\n";
				if (array.Length > 2)
				{
					array[2] = text3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
					object arg4 = default(object);
					string text4 = $"Crit Chance: {arg4}\n";
					if (array.Length > 3)
					{
						array[3] = text4;
						object obj = default(object);
						object arg5 = (EElement)obj;
						string text5 = $"Element: {arg5}\n";
						if (array.Length > 4)
						{
							array[4] = text5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
							object arg6 = default(object);
							string text6 = $"Projectile count: {arg6}\n";
							if (array.Length > 5)
							{
								array[5] = text6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
								object arg7 = default(object);
								string text7 = $"Bounces: {arg7}\n";
								if (array.Length > 6)
								{
									array[6] = text7;
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
									object arg8 = default(object);
									string text8 = $"Duration: {arg8}\n";
									if (array.Length > 7)
									{
										array[7] = text8;
										Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
										object arg9 = default(object);
										string text9 = $"Projecttile Speed: {arg9}\n";
										if (array.Length > 8)
										{
											array[8] = text9;
											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
											object arg10 = default(object);
											string text10 = $"Proc Coeffcient: {arg10}\n";
											if (array.Length > 9)
											{
												array[9] = text10;
												return string.Concat(array);
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		return (string)(object)new IndexOutOfRangeException();
	}

	public WeaponData()
	{
		//IL_00a5: Expected O, but got I4
		damage = 10f;
		knockback = 0.1f;
		projectiles = 1;
		attackDuration = 1.5f;
		maxDuration = -1f;
		maxSizeMultiplier = -1f;
		effectDuration = 1.5f;
		projectileSpeed = 1f;
		endCooldown = 1f;
		burstTime = 0.5f;
		minBurstInterval = 0.1f;
		procCoefficient = 1f;
		useVision = true;
		spawnProjectileRange = 50f;
		spawnOffset = (Vector3)0;
		_ = 1065353216;
		_ = 1065353216;
		base._002Ector();
	}
}
