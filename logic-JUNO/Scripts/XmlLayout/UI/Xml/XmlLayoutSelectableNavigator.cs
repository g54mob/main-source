using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Xml
{
	public class XmlLayoutSelectableNavigator : MonoBehaviour
	{
		public static XmlLayoutSelectableNavigator instance;

		private EventSystem system;

		private void Start()
		{
			system = EventSystem.current;
		}

		private void OnEnable()
		{
			if (instance != null && instance != this)
			{
				Object.Destroy(this);
			}
			instance = this;
			if (!XmlLayoutUtilities.XmlLayoutConfiguration.UseXmlLayoutSelectableNavigation)
			{
				base.enabled = false;
			}
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Tab))
			{
				Selectable selectable = null;
				if (system.currentSelectedGameObject != null)
				{
					selectable = ((!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift)) ? system.currentSelectedGameObject.GetComponent<Selectable>()?.FindSelectableOnDown() : system.currentSelectedGameObject.GetComponent<Selectable>()?.FindSelectableOnUp());
				}
				if (selectable == null)
				{
					selectable = Selectable.allSelectablesArray[0];
				}
				if (selectable != null)
				{
					selectable.Select();
				}
			}
			if (!Input.GetButtonDown("Submit") || !(system.currentSelectedGameObject != null))
			{
				return;
			}
			XmlElement component = system.currentSelectedGameObject.GetComponent<XmlElement>();
			if (!(component != null))
			{
				return;
			}
			if (component.m_onSubmitEvents != null && component.m_onSubmitEvents.Count > 0)
			{
				if (!(component.tagType == "InputField") || !Input.GetKeyDown(KeyCode.Space))
				{
					component.OnSubmit(new BaseEventData(system));
				}
			}
			else
			{
				component.OnPointerClick(new PointerEventData(system));
			}
		}
	}
}
