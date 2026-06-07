using PajamaLlama.Generic;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	[CreateAssetMenu(menuName = "Flotsam/Agent/Morale/Properties")]
	public class MoraleProperties : ScriptableObject
	{
		[SerializeField]
		private MoraleStyle _style;

		[SerializeField]
		private bool _subtractNeed = true;

		public MoraleEffect[] MoralEffectProperties = new MoraleEffect[0];

		public MoraleCategory[] Categories = new MoraleCategory[0];

		[MinMaxRangeInt(-100, 100)]
		public RangedInt MoraleRange;

		public int MoraleNeedCap = 10;

		[Tooltip("The amount of morale lost/gained per day, when moving to target morale score.")]
		[SerializeField]
		[ConditionalEnumHide("_style", 2, false, HideInInspector = true)]
		private float _moraleTargetSpeed = 10f;

		public MoraleStyle Style => _style;

		public bool SubtractNeed => _subtractNeed;

		public float MoraleTargetSpeed => _moraleTargetSpeed;

		public bool TryReturnCategoryLimits(int currentLevel, int maxLevel, MoraleCategory category, out RangedInt limits)
		{
			int num = MoraleRange.Minimum;
			MoraleRange.ReturnSize();
			for (int i = 0; i < Categories.Length; i++)
			{
				MoraleCategory moraleCategory = Categories[i];
				if (moraleCategory.IsAvailable(currentLevel))
				{
					int num2 = moraleCategory.ReturnRelativeSize(currentLevel, maxLevel, Categories, MoraleRange);
					int num3 = num + num2;
					if (i < Categories.Length - 1)
					{
						num3--;
					}
					num3 = Mathf.Clamp(num3, MoraleRange.Minimum, MoraleRange.Maximum);
					if (moraleCategory == category)
					{
						limits = new RangedInt(num, num3);
						return true;
					}
					num += num2;
				}
			}
			limits = default(RangedInt);
			return false;
		}

		public bool TryReturnCategory(int morale, int currentLevel, int maxLevel, out MoraleCategory category, out int index)
		{
			int num = MoraleRange.Minimum;
			morale = Mathf.Clamp(morale, MoraleRange.Minimum, MoraleRange.Maximum);
			for (index = 0; index < Categories.Length; index++)
			{
				category = Categories[index];
				if (category.IsAvailable(currentLevel))
				{
					int num2 = category.ReturnRelativeSize(currentLevel, maxLevel, Categories, MoraleRange);
					int num3 = num + num2;
					if ((num2 == 0 && morale == num) || (morale >= num && morale < num3) || (num3 == MoraleRange.Maximum && morale == num3))
					{
						return true;
					}
					num = num3;
				}
			}
			category = null;
			return false;
		}
	}
}
