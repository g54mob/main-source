using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace UMA
{
	[Serializable]
	public class UMARecipesEvent : UnityEvent<List<UMATextRecipe>>
	{
		public UMARecipesEvent()
		{
		}

		public UMARecipesEvent(UMARecipesEvent source)
		{
		}

		public void AddAction(Action<List<UMATextRecipe>> action)
		{
		}

		public void RemoveAction(Action<List<UMATextRecipe>> action)
		{
		}
	}
}
