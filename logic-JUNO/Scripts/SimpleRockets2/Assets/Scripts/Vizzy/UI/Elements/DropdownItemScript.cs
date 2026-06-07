using System.Linq;
using ModApi.Craft.Program;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Vizzy.UI.Elements
{
	public class DropdownItemScript : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
	{
		private ListElementScript _listElement;

		private string _text;

		public void Initialize(ListElementScript listElementScript)
		{
			TextMeshProUGUI componentInChildren = GetComponent<Toggle>().GetComponentInChildren<TextMeshProUGUI>();
			_text = componentInChildren.text;
			_listElement = listElementScript;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			ListItemInfo listItemInfo = _listElement.Items.Where((ListItemInfo x) => x.Text == _text).FirstOrDefault();
			if (listItemInfo != null)
			{
				_listElement.VizzyUI.ShowMessage($"{listItemInfo.Text}: {listItemInfo.Tooltip}");
			}
		}
	}
}
