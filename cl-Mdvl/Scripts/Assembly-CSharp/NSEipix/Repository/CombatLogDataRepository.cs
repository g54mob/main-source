using System;
using System.Collections.Generic;
using System.Linq;
using NSMedieval.Model;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using Social;

namespace NSEipix.Repository
{
	public class CombatLogDataRepository : DynamicJsonRepository<CombatLogDataRepository, PersonalLogData>
	{
		private Dictionary<AnimalAttackType, LocKeys[]> locKeysByAnimalAttackType;

		public string GetRandomVariantLocalized(string id, string variantId = "default")
		{
			return RandomVariantLocalized(GetByID(id).GetVariantLocKeys(variantId));
		}

		private static string RandomVariantLocalized(LocKeys[] lk)
		{
			string result = null;
			if (lk != null && LocKeyUtils.GetRandomVariation(lk, out var randomVariant))
			{
				result = UiUtils.Localize.GetText(randomVariant);
			}
			return result;
		}

		public override void Deserialize()
		{
			base.Deserialize();
			LocKeys[] locKeys = GetByID("beast_hit_action").Variant.FirstOrDefault((ConversationVariant cv) => cv.VariantId.Equals("default")).LocKeys;
			LocKeys[] locKeys2 = GetByID("beast_hit_action").Variant.FirstOrDefault((ConversationVariant cv) => cv.VariantId.Equals("clawed")).LocKeys;
			LocKeys[] locKeys3 = GetByID("beast_hit_action").Variant.FirstOrDefault((ConversationVariant cv) => cv.VariantId.Equals("hoofed")).LocKeys;
			LocKeys[] locKeys4 = GetByID("beast_hit_action").Variant.FirstOrDefault((ConversationVariant cv) => cv.VariantId.Equals("bird")).LocKeys;
			locKeysByAnimalAttackType = new Dictionary<AnimalAttackType, LocKeys[]>
			{
				[AnimalAttackType.Default] = locKeys,
				[AnimalAttackType.Claw] = locKeys2.Concat(locKeys).ToArray(),
				[AnimalAttackType.Hoof] = locKeys3.Concat(locKeys).ToArray(),
				[AnimalAttackType.Bird] = locKeys4.Concat(locKeys).ToArray()
			};
		}

		public string GetBeastHitAction(AnimalAttackType animalAttackType)
		{
			return RandomVariantLocalized(locKeysByAnimalAttackType[animalAttackType]);
		}

		public string GetWeaponHitAction(WeaponType weaponType)
		{
			switch (weaponType)
			{
			case WeaponType.None:
				return GetRandomVariantLocalized("hit_action", "ranged");
			case WeaponType.TwoHandBow:
			case WeaponType.TwoHandCrossbow:
			case WeaponType.OneHandThrow:
			case WeaponType.OneHandSling:
			case WeaponType.TwoHandSling:
				return GetRandomVariantLocalized("hit_action", "ranged");
			case WeaponType.OneHandMace:
			case WeaponType.TwoHandMace:
			case WeaponType.TwoHandStaff:
			case WeaponType.TwoHandRam:
			case WeaponType.TwoHandBowMelee:
				return GetRandomVariantLocalized("hit_action", "blunt");
			case WeaponType.TwoHandSpear:
			case WeaponType.OneHandSpear:
				return GetRandomVariantLocalized("hit_action", "pointy");
			case WeaponType.OneHandAxe:
			case WeaponType.TwoHandAxe:
			case WeaponType.OneHandSword:
			case WeaponType.TwoHandSword:
				return GetRandomVariantLocalized("hit_action", "sharp");
			default:
				throw new ArgumentOutOfRangeException("weaponType", weaponType, null);
			}
		}

		protected override string JsonFile()
		{
			return "SocialInteraction/CombatLogData.json";
		}
	}
}
