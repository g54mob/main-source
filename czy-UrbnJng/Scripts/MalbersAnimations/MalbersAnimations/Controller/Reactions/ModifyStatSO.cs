using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Controller.Reactions
{
	[CreateAssetMenu(menuName = "Malbers Animations/Modifier/Stat", fileName = "New Stat Modifier", order = -100)]
	public class ModifyStatSO : ScriptableObject
	{
		[HideInInspector]
		public StatModifier modifier;

		public List<StatModifier> modifiers = new List<StatModifier>();

		[SerializeField]
		[HideInInspector]
		private bool V2Updated;

		public void Modify(Stats stats)
		{
			foreach (StatModifier modifier in modifiers)
			{
				modifier.ModifyStat(stats);
			}
		}

		public void Modify(Component stats)
		{
			Modify(stats.MFindComponentInRoot<Stats>());
		}

		public void Modify(GameObject stats)
		{
			Modify(stats.MFindComponentInRoot<Stats>());
		}

		private void OnValidate()
		{
			if (!V2Updated)
			{
				if (modifiers == null || modifiers.Count == 0)
				{
					modifiers = new List<StatModifier> { modifier };
				}
				V2Updated = true;
				MTools.SetDirty(this);
			}
		}
	}
}
