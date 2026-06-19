using TMPEffects.Components.Animator;
using TMPEffects.TMPAnimations;
using UnityEngine;

namespace TMPEffects.Databases.AnimationDatabase
{
	[CreateAssetMenu(fileName = "new TMPAnimationDatabase", menuName = "TMPEffects/Database/Animation Database", order = 0)]
	public class TMPAnimationDatabase : TMPEffectDatabase<ITMPAnimation>
	{
		[SerializeField]
		private TMPBasicAnimationDatabase basicAnimationDatabase;

		[SerializeField]
		private TMPShowAnimationDatabase showAnimationDatabase;

		[SerializeField]
		private TMPHideAnimationDatabase hideAnimationDatabase;

		[SerializeField]
		[HideInInspector]
		private TMPBasicAnimationDatabase prevBasicAnimationDatabase;

		[SerializeField]
		[HideInInspector]
		private TMPShowAnimationDatabase prevShowAnimationDatabase;

		[SerializeField]
		[HideInInspector]
		private TMPHideAnimationDatabase prevHideAnimationDatabase;

		public TMPBasicAnimationDatabase BasicAnimationDatabase => null;

		public TMPShowAnimationDatabase ShowAnimationDatabase => null;

		public TMPHideAnimationDatabase HideAnimationDatabase => null;

		public bool ContainsEffect(string name, TMPAnimationType type)
		{
			return false;
		}

		public override bool ContainsEffect(string name)
		{
			return false;
		}

		public ITMPAnimation GetEffect(string name, TMPAnimationType type)
		{
			return null;
		}

		public override ITMPAnimation GetEffect(string name)
		{
			return null;
		}

		protected override void OnValidate()
		{
		}

		private void OnChanged(object sender)
		{
		}
	}
}
