using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Stats/Modify Stats")]
	public class ModifyStat : MonoBehaviour
	{
		public static readonly string[] Tooltips = new string[27]
		{
			"[None] Skips the stat modification", "Adds to the stat Value", "Sets the stat value", "Substracts from the stat value", "Modifies the Stat maximum Value (Adds or Remove)", "Set the Stat maximum Value", "Enables the Degeneration and sets the Degen Rate Value. If the value is 0, the rate Value wont be changed", "Stops the Degeneration", "Enables the Regeneration and sets the Regen Rate Value.  If the value is 0, the rate Value wont be changed", "Stops the Regeneration",
			"Reset the Stat to the Default Min or Max Value", "Reduce the Value of the Stat by a percent", "Increase the Value of the Stat by a percent", "Sets the multiplier value of the stat", "Reset the Stat to the maximun Value", "Reset the Stat to the minimun Value", "Enable/Disable the Stat", "Set Imnune", "Starts the Regeneration", "Restore the Regeneration to its default",
			"Restore the Degeneration to its default", "Restore the Value to its default", "Restore the Max Value to its default", "Restore the Min to its default", "Restore the value to its default", "Restore the Mutliplier to its default", "Adds or Remove a value to the Multiplier"
		};

		public Stats stats;

		public List<StatModifier> modifiers = new List<StatModifier>();

		public virtual void SetStats(GameObject go)
		{
			stats = go.FindComponent<Stats>();
		}

		public virtual void SetStats(Component go)
		{
			SetStats(go.gameObject);
		}

		public virtual void Modify()
		{
			foreach (StatModifier modifier in modifiers)
			{
				modifier.ModifyStat(stats);
			}
		}

		public virtual void Modify(GameObject target)
		{
			SetStats(target);
			Modify();
		}

		public virtual void Modify(Component target)
		{
			Modify(target.gameObject);
		}

		public virtual void Modify(int index)
		{
			if (modifiers != null && index < modifiers.Count)
			{
				modifiers[index]?.ModifyStat(stats);
			}
		}
	}
}
