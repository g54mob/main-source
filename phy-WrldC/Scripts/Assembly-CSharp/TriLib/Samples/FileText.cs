using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TriLib.Samples
{
	public class FileText : MonoBehaviour, ISelectHandler, IEventSystemHandler
	{
		public string Text
		{
			get
			{
				return GetComponent<Text>().text;
			}
			set
			{
				GetComponent<Text>().text = value;
			}
		}

		public ItemType ItemType { get; set; }

		public void OnSelect(BaseEventData eventData)
		{
			FileOpenDialog.Instance.HandleEvent(ItemType, Text);
		}
	}
}
