using Data.Operator;
using UnityEngine;

namespace Data.Quests.QuestViews
{
	public class OnboardingHologramView : MonoBehaviour
	{
		[SerializeField]
		private FactoryObjectData factoryObjectData;

		public FactoryObjectData FactoryObjectData => factoryObjectData;
	}
}
