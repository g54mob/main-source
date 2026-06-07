using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Decision/Check Malbers Tag", order = 5)]
	public class CheckMalbersTag : MAIDecision
	{
		public Affected CheckOn;

		public bool CheckInParent = true;

		public Tag[] tags;

		public override string DisplayName => "General/Check Malbers Tag";

		public override bool Decide(MAnimalBrain brain, int Index)
		{
			if (CheckOn == Affected.Self)
			{
				if (CheckInParent)
				{
					return brain.gameObject.HasMalbersTagInParent(tags);
				}
				return brain.gameObject.HasMalbersTag(tags);
			}
			if ((bool)brain.Target)
			{
				if (CheckInParent)
				{
					return brain.Target.HasMalbersTagInParent(tags);
				}
				return brain.Target.HasMalbersTag(tags);
			}
			return false;
		}
	}
}
