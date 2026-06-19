using System;
using TMPEffects.SerializedCollections;
using TMPEffects.TMPAnimations;
using UnityEngine;

namespace TMPEffects.Databases.AnimationDatabase
{
	[CreateAssetMenu(fileName = "new TMPShowAnimationDatabase", menuName = "TMPEffects/Database/Show Animation Database", order = 12)]
	public class TMPShowAnimationDatabase : TMPAnimationDatabaseBase<TMPShowAnimation>
	{
		[SerializeField]
		private SerializedDictionary<string, TMPShowAnimation> showAnimations;

		public override bool ContainsEffect(string name)
		{
			return showAnimations.ContainsKey(name);
		}

		public override TMPShowAnimation GetEffect(string name)
		{
			TMPShowAnimation tMPShowAnimation = showAnimations[name];
			if (tMPShowAnimation == null)
			{
				throw new InvalidOperationException("The animation " + name + " is unassigned on database " + base.name);
			}
			return tMPShowAnimation;
		}
	}
}
