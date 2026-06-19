using TMPEffects.Databases;
using TMPEffects.TMPAnimations;

namespace TMPEffects.Components.Animator
{
	internal struct DummyDatabase : ITMPEffectDatabase<ITMPAnimation>, ITMPEffectDatabase
	{
		private string name;

		private ITMPAnimation animation;

		public DummyDatabase(string name, ITMPAnimation animation)
		{
			this.name = null;
			this.animation = null;
		}

		public bool ContainsEffect(string name)
		{
			return false;
		}

		public ITMPAnimation GetEffect(string name)
		{
			return null;
		}
	}
}
