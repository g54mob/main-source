using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIScripts
{
	public class MyDropdown : Selectable, IPointerClickHandler, IEventSystemHandler, ISubmitHandler, ICancelHandler
	{
		public TextMeshProUGUI label;

		public GameObject template;

		public GameObject choiceItemTemplate;

		protected List<DropdownItem> items = new List<DropdownItem>();

		protected override void Start()
		{
			base.Start();
			template.SetActive(value: false);
			choiceItemTemplate.SetActive(value: false);
		}

		public void AddOption(DropdownItemData info)
		{
			DropdownItem component = Object.Instantiate(choiceItemTemplate, choiceItemTemplate.transform.parent).GetComponent<DropdownItem>();
			component.InitItem(info, OnChange);
			items.Add(component);
		}

		public void ClearOptions()
		{
			for (int num = items.Count - 1; num >= 0; num--)
			{
				Object.Destroy(items[num].gameObject);
			}
			items.Clear();
		}

		public virtual void OnChange(int index = 0)
		{
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			template.SetActive(value: true);
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			base.OnPointerExit(eventData);
			template.SetActive(value: false);
		}

		public void OnSubmit(BaseEventData eventData)
		{
			template.SetActive(value: false);
		}

		public void OnCancel(BaseEventData eventData)
		{
			template.SetActive(value: false);
		}
	}
}
