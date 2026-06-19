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
			return false;
		}

		public override TMPShowAnimation GetEffect(string name)
		{
			return null;
		}
	}
}
