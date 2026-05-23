using System.Collections.Generic;
using Factory.Mech;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Factory.UI
{
	public class FieldMouseoverSettingWindowCtrl : MonoBehaviour
	{
		public enum State
		{
			Close = 0,
			Wait = 1,
			Prepare = 2,
			Open = 3
		}

		[SerializeField]
		private Image icon;

		[SerializeField]
		private Image product;

		[SerializeField]
		private GameObject priorityGroup;

		[SerializeField]
		private GameObject priorityOutputTitleObj;

		[SerializeField]
		private GameObject priorityInputTitleObj;

		[SerializeField]
		private GameObject filterGroup;

		[SerializeField]
		private List<Toggle> priorityToggles;

		[SerializeField]
		private FieldMouseoverSelectBoxItem selectBoxItemPrefab;

		[SerializeField]
		private ToggleGroup selectBoxToggleGroup;

		[SerializeField]
		private Transform selectBoxParent;

		private List<FieldMouseoverSelectBoxItem> selectBoxItemList;

		private InputActionController input;

		public State state;

		public MechBase mechBase;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void SwitchToggleActive(int count, UnityAction<bool> action)
		{
		}

		private void SetEquipmentIcon()
		{
		}

		public void InitSelectBox()
		{
		}

		private void SortSelectBox(List<eLuggage> luggages)
		{
		}

		public void OnSelectBoxValueChanged()
		{
		}

		private void SetLuggageIcon(eLuggage luggage)
		{
		}

		public void ResetSelectBox(bool initialize = false)
		{
		}

		public void OnChangeOutputPriorityValue(bool isOn)
		{
		}

		public void OnChangeInputPriorityValue(bool isOn)
		{
		}
	}
}
