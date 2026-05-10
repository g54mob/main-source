using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class ActionPutDrinkOnPlate : ActionConstructor<AgentActionGrabDrinkOnPlate>
	{
		[SerializeField]
		private SoftReference<Drink> _drink;

		protected override AgentActionGrabDrinkOnPlate ConstructAction()
		{
			return new AgentActionGrabDrinkOnPlate(_drink);
		}
	}
}
