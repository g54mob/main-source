using System;
using TMPEffects.SerializedCollections;
using TMPEffects.TMPAnimations;
using UnityEngine;

namespace TMPEffects.Databases.AnimationDatabase
{
	[CreateAssetMenu(fileName = "new TMPHideAnimationDatabase", menuName = "TMPEffects/Database/Hide Animation Database", order = 13)]
	public class TMPHideAnimationDatabase : TMPAnimationDatabaseBase<TMPHideAnimation>
	{
		[SerializeField]
		private SerializedDictionary<string, TMPHideAnimation> hideAnimations;

		public override bool ContainsEffect(string name)
		{
			return hideAnimations.ContainsKey(name);
		}

		public override TMPHideAnimation GetEffect(string name)
		{
			TMPHideAnimation tMPHideAnimation = hideAnimations[name];
			if (tMPHideAnimation == null)
			{
				throw new InvalidOperationException("The animation " + name + " is unassigned on database " + base.name);
			}
			return tMPHideAnimation;
		}
	}
}
