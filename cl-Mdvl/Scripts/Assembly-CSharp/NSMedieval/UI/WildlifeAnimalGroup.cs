using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class WildlifeAnimalGroup : AnimalPanelGroup
	{
		[SerializeField]
		private CustomToggle huntToggle;

		[SerializeField]
		private TMP_Text huntRetaliateLabel;

		[SerializeField]
		private CustomToggle tameToggle;

		[SerializeField]
		private TMP_Text tameableLabel;

		[SerializeField]
		private TMP_Text tameRetaliateLabel;

		protected override void UpdateData()
		{
			base.UpdateData();
			float attributeValue = base.Animal.GetAttributeValue(AttributeType.HuntingRetaliateChance);
			huntRetaliateLabel.SetText($"{attributeValue:P1}");
			float attributeValue2 = base.Animal.GetAttributeValue(AttributeType.AnimalTameChance);
			tameableLabel.SetText($"{attributeValue2:P1}");
			float attributeValue3 = base.Animal.GetAttributeValue(AttributeType.TameRetaliateChance);
			tameRetaliateLabel.SetText($"{attributeValue3:P1}");
			huntToggle.SetIsOnWithoutNotify(base.Animal.OrderType.Equals(AnimalOrderType.Hunt));
			tameToggle.SetIsOnWithoutNotify(base.Animal.OrderType.Equals(AnimalOrderType.Tame));
			bool interactable = base.Animal.Blueprint.CanBeTamed && base.Animal.AnimalType != AnimalType.WildAggressive;
			tameToggle.interactable = interactable;
		}

		protected override void OnPetOwnerChanged(AnimalInstance arg1, CreatureBase arg2)
		{
		}

		protected override void Start()
		{
			base.Start();
			huntToggle.onValueChanged.AddListener(OnHuntChanged);
			huntToggle.SetIsOnWithoutNotify(base.Animal.OrderType == AnimalOrderType.Hunt);
			tameToggle.onValueChanged.AddListener(OnTameChanged);
			tameToggle.SetIsOnWithoutNotify(base.Animal.OrderType == AnimalOrderType.Tame);
		}

		protected override void OnOrderGivenFromAnimalUI(AnimalInstance animalInstance)
		{
			if (base.Animal == animalInstance)
			{
				switch (animalInstance.OrderType)
				{
				case AnimalOrderType.None:
					huntToggle.SetIsOnWithoutNotify(value: false);
					tameToggle.SetIsOnWithoutNotify(value: false);
					break;
				case AnimalOrderType.Hunt:
					huntToggle.SetIsOnWithoutNotify(value: true);
					tameToggle.SetIsOnWithoutNotify(value: false);
					break;
				case AnimalOrderType.Tame:
					huntToggle.SetIsOnWithoutNotify(value: false);
					tameToggle.SetIsOnWithoutNotify(value: true);
					break;
				}
			}
		}

		public void OnTameChanged(bool isOn)
		{
			AnimalOrderType orderType = (isOn ? AnimalOrderType.Tame : AnimalOrderType.None);
			MonoSingleton<AnimalController>.Instance.MarkForOrder(orderType, base.Animal);
			huntToggle.SetIsOnWithoutNotify(value: false);
			UpdateData();
		}

		public void OnHuntChanged(bool isOn)
		{
			AnimalOrderType orderType = (isOn ? AnimalOrderType.Hunt : AnimalOrderType.None);
			MonoSingleton<AnimalController>.Instance.MarkForOrder(orderType, base.Animal);
			tameToggle.SetIsOnWithoutNotify(value: false);
			UpdateData();
		}
	}
}
