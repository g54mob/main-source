using System;
using TMPEffects.SerializedCollections;
using TMPEffects.TMPAnimations;
using UnityEngine;

namespace TMPEffects.Databases.AnimationDatabase
{
	[CreateAssetMenu(fileName = "new TMPBasicAnimationDatabase", menuName = "TMPEffects/Database/Basic Animation Database", order = 11)]
	public class TMPBasicAnimationDatabase : TMPAnimationDatabaseBase<TMPAnimation>
	{
		[SerializeField]
		private SerializedDictionary<string, TMPAnimation> animations;

		public override bool ContainsEffect(string name)
		{
			return animations.ContainsKey(name);
		}

		public override TMPAnimation GetEffect(string name)
		{
			TMPAnimation tMPAnimation = animations[name];
			if (tMPAnimation == null)
			{
				throw new InvalidOperationException("The animation " + name + " is unassigned on database " + base.name);
			}
			return tMPAnimation;
		}
	}
}
