using System;
using System.Linq;
using Restory.Gameplay.Common;
using UnityEngine;

namespace Restory.Gameplay.MoneyCash
{
	public class MoneyInteractiveItemSumStatesSwitcher : MonoBehaviour
	{
		private static class Style
		{
			public const string MoneyStatesSettingsGroup = "States For Various Sums Held";

			public const string MinMoneyStateGroup = "States For Various Sums Held/Min Money State";
		}

		[Serializable]
		private class MoneyInteractiveItemAmountState
		{
			public int MinMoneyCount = 10000;

			public GameObject[] ObjectsToActivate = new GameObject[0];

			public GameObject[] ObjectsToDeactivate = new GameObject[0];

			public BoxCollider ColliderSettings;
		}

		[SerializeField]
		[HideInInspector]
		private MoneyInteractiveItemAmountState minMoneyState;

		[SerializeField]
		private GameObject[] minMoneyStateObjectsToActivate = new GameObject[0];

		[SerializeField]
		private GameObject[] minMoneyStateObjectsToDeactivate = new GameObject[0];

		[SerializeField]
		private BoxCollider minMoneyStateColliderSettings;

		[SerializeField]
		private InteractionTrigger interactionTrigger;

		[SerializeField]
		private MoneyInteractiveItemAmountState[] largerSumStates = new MoneyInteractiveItemAmountState[0];

		private MoneyInteractiveItemAmountState currentlyActiveState;

		public void UpdateState(int newMoneyAmount)
		{
			for (int num = largerSumStates.Length - 1; num >= 0; num--)
			{
				if (TryToSwitchStateWithPassedMoneyThreshold(newMoneyAmount, largerSumStates[num]))
				{
					return;
				}
			}
			SwitchState(minMoneyState);
		}

		private bool TryToSwitchStateWithPassedMoneyThreshold(int newMoneyAmount, MoneyInteractiveItemAmountState state)
		{
			if (state.MinMoneyCount > newMoneyAmount)
			{
				return false;
			}
			SwitchState(state);
			return true;
		}

		private void SwitchState(MoneyInteractiveItemAmountState newState)
		{
			if (newState == null || newState == currentlyActiveState)
			{
				return;
			}
			GameObject[] objectsToActivate = newState.ObjectsToActivate;
			foreach (GameObject gameObject in objectsToActivate)
			{
				if ((bool)gameObject)
				{
					gameObject.SetActive(value: true);
				}
			}
			objectsToActivate = newState.ObjectsToDeactivate;
			foreach (GameObject gameObject2 in objectsToActivate)
			{
				if ((bool)gameObject2)
				{
					gameObject2.SetActive(value: false);
				}
			}
			interactionTrigger.ChangeColliderParams(newState.ColliderSettings);
			currentlyActiveState = newState;
		}

		private void SortStatesByMoneyRequired()
		{
			largerSumStates = largerSumStates.OrderBy((MoneyInteractiveItemAmountState x) => x.MinMoneyCount).ToArray();
		}
	}
}
