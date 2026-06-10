using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Types;
using NSMedieval.UI.Utils;

namespace NSMedieval.Repository
{
	public class EquipmentRepository : DynamicJsonRepository<EquipmentRepository, Equipment>
	{
		private List<Equipment> qualityEquipment = new List<Equipment>();

		private List<Equipment> taintedEquipment = new List<Equipment>();

		private Dictionary<string, Equipment> equipmentDictionary = new Dictionary<string, Equipment>();

		public EquipmentRepository(ResourceRepository resourceRepository)
		{
			InitializeEquipmentItems();
		}

		public override Equipment GetByID(string id)
		{
			if (equipmentDictionary.TryGetValue(id, out var value))
			{
				return value;
			}
			return base.GetByID(id);
		}

		public override bool TryGetValue(string id, out Equipment model)
		{
			if (equipmentDictionary.TryGetValue(id, out model))
			{
				return true;
			}
			return base.TryGetValue(id, out model);
		}

		public override IEnumerable<Equipment> GetAllItems()
		{
			return qualityEquipment;
		}

		protected override void Refresh()
		{
			base.Refresh();
			InitializeEquipmentItems();
		}

		public void InitializeEquipmentItems()
		{
			qualityEquipment.Clear();
			equipmentDictionary.Clear();
			Equipment[] array = base.AllItems.ToArray();
			foreach (Equipment proto in array)
			{
				Resource resource = Repository<ResourceRepository, Resource>.Instance.ProtoItems.FirstOrDefault((Resource r) => r.GetID().Equals(proto.GetID()));
				bool isEnabled;
				if (resource == null)
				{
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(56, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Items\\EquipmentRepository.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(proto.GetID());
						messageBuilder.AppendLiteral(" is missing in ResourceRepository.QualityResources array");
					}
					Log.Info(messageBuilder);
					continue;
				}
				ItemQuality[] itemQualities = EquipmentUtils.GetItemQualities(proto.GetID());
				if (itemQualities == null)
				{
					continue;
				}
				string[] materials = resource.Materials;
				foreach (string text in materials)
				{
					MaterialSettings materialSettings = null;
					string arg = proto.GetID();
					if (!text.Equals(string.Empty))
					{
						arg = text + "_" + proto.GetID();
						materialSettings = Repository<MaterialSettingsRepository, MaterialSettings>.Instance.GetByID(text);
						if (materialSettings == null)
						{
							FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(21, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Items\\EquipmentRepository.cs");
							if (isEnabled)
							{
								messageBuilder2.AppendLiteral("There is no ");
								messageBuilder2.AppendFormatted(text);
								messageBuilder2.AppendLiteral(" material");
							}
							Log.Error(messageBuilder2);
						}
					}
					ItemQuality[] array2 = itemQualities;
					foreach (ItemQuality itemQuality in array2)
					{
						string text2 = $"{itemQuality.Quality}_{arg}".ToLower(CultureInfo.InvariantCulture);
						Equipment equipment = new Equipment();
						float decompositionCoefficient = MultiplySafely(proto.DecompositionCoefficient, itemQuality.DecompositionCoefficientMultiplier);
						List<string> onEquipEffectors = new List<string>();
						if (proto.OnEquipEffectors != null)
						{
							onEquipEffectors.AddRange(proto.OnEquipEffectors);
						}
						if (itemQuality.OnEquipEffectors != null)
						{
							string[] onEquipEffectors2 = itemQuality.OnEquipEffectors;
							foreach (string item in onEquipEffectors2)
							{
								if (!onEquipEffectors.Contains(item))
								{
									onEquipEffectors.Add(item);
								}
							}
							if (materialSettings != null && materialSettings.OnEquipEffectors != null)
							{
								onEquipEffectors.AddRange(materialSettings.OnEquipEffectors.Where((string effector) => !onEquipEffectors.Contains(effector)));
							}
						}
						float num4 = proto.ArmorRating;
						if (proto.ItemType.Equals(ItemType.Armor) && itemQuality is ArmorQuality armorQuality)
						{
							num4 = MultiplySafely(proto.ArmorRating, armorQuality.ArmorRatingMultiplier);
							if (materialSettings != null)
							{
								num4 = MultiplySafely(num4, materialSettings.ArmorRatingMultiplier);
							}
						}
						FloatRange warmthModifier = proto.WarmthModifier;
						if (proto.ItemType.Equals(ItemType.Garment) && itemQuality is GarmentQuality garmentQuality)
						{
							float min = MultiplySafely(proto.WarmthModifier.Min, garmentQuality.WarmthModifierMultiplier.Min);
							float max = MultiplySafely(proto.WarmthModifier.Max, garmentQuality.WarmthModifierMultiplier.Max);
							warmthModifier = new FloatRange(min, max);
						}
						WeaponMode primaryWeaponMode = null;
						WeaponMode secondaryWeaponMode = null;
						if (proto.ItemType.Equals(ItemType.Weapon) && itemQuality is WeaponQuality weaponQuality)
						{
							primaryWeaponMode = GenerateWeaponModeWithModifiers(proto.PrimaryWeaponMode, weaponQuality, materialSettings);
							if (proto.SecondaryWeaponMode != null)
							{
								WeaponQuality weaponQuality2 = Repository<WeaponQualitySettingsRepository, WeaponQualitySettings>.Instance.GetWeaponQuality(proto.SecondaryWeaponMode.WeaponType, weaponQuality.Quality);
								secondaryWeaponMode = GenerateWeaponModeWithModifiers(proto.SecondaryWeaponMode, weaponQuality2, materialSettings);
							}
						}
						equipment.SetupEquipmentWithQuality(text2, proto, primaryWeaponMode, secondaryWeaponMode, decompositionCoefficient, warmthModifier, num4, onEquipEffectors.ToArray(), itemQuality, materialSettings);
						qualityEquipment.Add(equipment);
						equipmentDictionary.TryAdd(equipment.GetID(), equipment);
						if (resource.GenerateTaintedVersion)
						{
							Equipment equipment2 = new Equipment();
							string id = (text2 + "_tainted").ToLower(CultureInfo.InvariantCulture);
							onEquipEffectors.Add("WearingDeadManItem");
							equipment2.SetupEquipmentWithQuality(id, proto, primaryWeaponMode, secondaryWeaponMode, decompositionCoefficient, warmthModifier, num4, onEquipEffectors.ToArray(), itemQuality, materialSettings, tainted: true);
							qualityEquipment.Add(equipment2);
							taintedEquipment.Add(equipment2);
							equipmentDictionary.TryAdd(equipment2.GetID(), equipment2);
						}
					}
				}
			}
			Repository<ResourceRepository, Resource>.Instance.CacheEquipmentQualityItems();
		}

		private static WeaponMode GenerateWeaponModeWithModifiers(WeaponMode proto, WeaponQuality weaponQuality, MaterialSettings materialSettings)
		{
			float num = MultiplySafely(proto.Damage, weaponQuality.DamageMultiplier);
			float precisionFalloff = MultiplySafely(proto.PrecisionFalloff, weaponQuality.PrecisionFalloffMultiplier);
			float precision = MultiplySafely(proto.Precision, weaponQuality.PrecisionMultiplier);
			float num2 = MultiplySafely(proto.AttackSpeed, weaponQuality.AttackSpeedMultiplier);
			float range = MultiplySafely(proto.Range, weaponQuality.RangeMultiplier);
			float ignoresArmor = MultiplySafely(proto.IgnoresArmor, weaponQuality.IgnoresArmorMultiplier);
			float armorDamage = MultiplySafely(proto.ArmorDamage, weaponQuality.ArmorDamageMultiplier);
			float buildingDamage = MultiplySafely(proto.BuildingDamage, weaponQuality.BuildingDamageMultiplier);
			string[] hitEffectorGroupIDs = proto.HitEffectorGroupIDs;
			string[] criticalHitEffectorGroupIDs = proto.CriticalHitEffectorGroupIDs;
			float num3 = MultiplySafely(proto.HpLossPerUse, weaponQuality.HpLossPerUseMultiplier);
			float num4 = MultiplySafely(proto.HpLossFlammableProjectileModifier, weaponQuality.HpLossFlammableProjectileModifierMultiplier);
			if (materialSettings != null)
			{
				num = MultiplySafely(num, materialSettings.DamageMultiplier);
				num2 = MultiplySafely(num2, materialSettings.AttackSpeedMultiplier);
				num3 = MultiplySafely(num3, materialSettings.HpLossPerUseMultiplier);
				num4 = MultiplySafely(num4, materialSettings.HpLossFlammableProjectileModifierMultiplier);
				if (materialSettings.HitEffectorGroupIDs != null && materialSettings.HitEffectorGroupIDs.Length != 0)
				{
					List<string> list = new List<string>();
					if (hitEffectorGroupIDs != null)
					{
						list = hitEffectorGroupIDs.ToList();
						list.AddRange(materialSettings.HitEffectorGroupIDs.Where((string effector) => !hitEffectorGroupIDs.Contains(effector)));
					}
					else
					{
						list.AddRange(materialSettings.HitEffectorGroupIDs);
					}
					hitEffectorGroupIDs = list.ToArray();
				}
				if (materialSettings.CriticalHitEffectorGroupIDs != null && materialSettings.CriticalHitEffectorGroupIDs.Length != 0)
				{
					List<string> list2 = new List<string>();
					if (criticalHitEffectorGroupIDs != null)
					{
						list2 = criticalHitEffectorGroupIDs.ToList();
						list2.AddRange(materialSettings.CriticalHitEffectorGroupIDs.Where((string effector) => !criticalHitEffectorGroupIDs.Contains(effector)));
					}
					else
					{
						list2.AddRange(materialSettings.CriticalHitEffectorGroupIDs);
					}
					criticalHitEffectorGroupIDs = list2.ToArray();
				}
			}
			return proto.GenerateQualityClone(num, precisionFalloff, precision, num2, range, ignoresArmor, armorDamage, buildingDamage, hitEffectorGroupIDs, criticalHitEffectorGroupIDs, num3, num4);
		}

		protected override string JsonFile()
		{
			return "Items/Equipment.json";
		}

		private static float MultiplySafely(float baseValue, float multiplier)
		{
			if (multiplier == 0f)
			{
				return baseValue;
			}
			return baseValue * multiplier;
		}
	}
}
