using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Malbers/Damage/Damageable Set Profile", 0)]
	public class MDamageableReaction : Reaction
	{
		[Tooltip("Changes the Profile of the Main Damageable Component of a Character. Leave it null to Restore to the Defaul Profile")]
		public StringReference Profile = new StringReference();

		public override Type ReactionType => typeof(MDamageable);

		protected override bool _TryReact(Component reactor)
		{
			MDamageable mDamageable = reactor as MDamageable;
			if (string.IsNullOrEmpty(Profile.Value))
			{
				mDamageable.Profile_Restore();
			}
			else
			{
				mDamageable.Profile_Set(Profile);
			}
			return true;
		}
	}
}
