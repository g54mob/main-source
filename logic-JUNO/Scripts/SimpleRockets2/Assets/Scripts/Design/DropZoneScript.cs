using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class DropZoneScript : MonoBehaviour
	{
		private bool _selected;

		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				if (_selected != value)
				{
					_selected = value;
					XmlElement component = GetComponent<XmlElement>();
					if (_selected)
					{
						component.AddClass("dropzone-selected");
					}
					else
					{
						component.RemoveClass("dropzone-selected");
					}
				}
			}
		}

		public void UpdateDropZone(Vector2 screenPosition)
		{
			RectTransform component = GetComponent<RectTransform>();
			Selected = RectTransformUtility.RectangleContainsScreenPoint(component, screenPosition) && base.gameObject.activeInHierarchy;
		}
	}
}
