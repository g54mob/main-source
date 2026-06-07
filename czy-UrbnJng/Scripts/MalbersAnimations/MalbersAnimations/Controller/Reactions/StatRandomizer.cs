using MalbersAnimations.Utilities;
using UnityEngine;

namespace MalbersAnimations.Controller.Reactions
{
	[CreateAssetMenu(menuName = "Malbers Animations/Modifier/Stat Randomizer", fileName = "New Stat Randomizer", order = -100)]
	public class StatRandomizer : ScriptableObject
	{
		public enum StatValues
		{
			Value = 1,
			Multiplier = 2,
			MinValue = 4,
			MaxValue = 8,
			RegenerationRate = 0x10,
			RegenerationWaitTime = 0x20,
			DegenerationRate = 0x40,
			DegenerationWaitTime = 0x80,
			InmuneTime = 0x100
		}

		public StatID statID;

		[Flag]
		public StatValues modify;

		[Tooltip("Current Value of the Stat")]
		public RangedFloat Value = new RangedFloat(80f, 120f);

		[Tooltip("Multipler that is applied to the Stat Value")]
		public RangedFloat Multiplier = new RangedFloat(0.5f, 1.5f);

		[Tooltip("Minimum Stat Value")]
		public RangedFloat MinValue;

		[Tooltip("Maximum Stat Value")]
		public RangedFloat MaxValue = new RangedFloat(100f, 200f);

		[Tooltip("Regeneration Rate")]
		public RangedFloat RegenRate = new RangedFloat(0f, 10f);

		[Tooltip("Regeneration Rate wait time")]
		public RangedFloat RegenWaitTime = new RangedFloat(0f, 10f);

		[Tooltip("Degeneration Rate")]
		public RangedFloat DegenRate = new RangedFloat(0f, 10f);

		[Tooltip("Degeneration Rate wait time")]
		public RangedFloat DegenWaitTime = new RangedFloat(0f, 10f);

		[Tooltip("Inmune time, uses to avoid fast changes to the Stat value")]
		public RangedFloat InmuneTime = new RangedFloat(0f, 5f);

		public void Randomize(Stats stats)
		{
			Stat stat = stats.Stat_Get(statID);
			if (stat != null)
			{
				if (Check(StatValues.Value))
				{
					stat.SetValue(Value.RandomValue);
				}
				if (Check(StatValues.Multiplier))
				{
					stat.Multiplier = Multiplier.RandomValue;
				}
				if (Check(StatValues.MinValue))
				{
					stat.MinValue = MinValue.RandomValue;
				}
				if (Check(StatValues.MaxValue))
				{
					stat.MaxValue = MaxValue.RandomValue;
				}
				if (Check(StatValues.RegenerationRate))
				{
					stat.RegenRate = RegenRate.RandomValue;
				}
				if (Check(StatValues.RegenerationWaitTime))
				{
					stat.RegenWaitTime = RegenWaitTime.RandomValue;
				}
				if (Check(StatValues.DegenerationRate))
				{
					stat.DegenRate = DegenRate.RandomValue;
				}
				if (Check(StatValues.DegenerationWaitTime))
				{
					stat.DegenWaitTime = DegenWaitTime.RandomValue;
				}
				if (Check(StatValues.InmuneTime))
				{
					stat.ImmuneTime = InmuneTime.RandomValue;
				}
			}
		}

		private bool Check(StatValues modifier)
		{
			return (modify & modifier) == modifier;
		}
	}
}
