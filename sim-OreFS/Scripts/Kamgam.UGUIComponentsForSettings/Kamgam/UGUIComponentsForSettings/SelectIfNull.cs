using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Kamgam.UGUIComponentsForSettings
{
	public class SelectIfNull : MonoBehaviour
	{
		public enum Trigger
		{
			Awake = 0,
			OnEnable = 1,
			Start = 2,
			Update = 3,
			LateUpdate = 4,
			OnDirectionInput = 5
		}

		[Tooltip("Defines when the select if null logic should be executed. You can pick one or more times.")]
		public Trigger[] Triggers;

		[Tooltip("Optional: If candidates are set then these are the preferred target for the selection. A candidate will only be selected if it is enable, active and interactable.")]
		public Selectable[] Candidates;

		[Tooltip("Search for any interactable selectable if none of the Candidates is valid?")]
		public bool SearchForSelectables = true;

		public void Awake()
		{
			if (containsTrigger(Trigger.Awake))
			{
				selectIfNull();
			}
		}

		public void Start()
		{
			if (containsTrigger(Trigger.Start))
			{
				selectIfNull();
			}
		}

		public void OnEnable()
		{
			if (containsTrigger(Trigger.OnEnable))
			{
				selectIfNull();
			}
		}

		public void Update()
		{
			if (containsTrigger(Trigger.Update))
			{
				selectIfNull();
			}
			if (containsTrigger(Trigger.OnDirectionInput) && InputUtils.AnyDirection())
			{
				selectIfNull();
			}
		}

		public void LateUpdate()
		{
			if (containsTrigger(Trigger.LateUpdate))
			{
				selectIfNull();
			}
		}

		private bool containsTrigger(Trigger trigger)
		{
			if (Triggers == null || Triggers.Length == 0)
			{
				return false;
			}
			Trigger[] triggers = Triggers;
			for (int i = 0; i < triggers.Length; i++)
			{
				if (triggers[i] == trigger)
				{
					return true;
				}
			}
			return false;
		}

		private void selectIfNull()
		{
			if (!(EventSystem.current != null) || !(EventSystem.current.currentSelectedGameObject == null))
			{
				return;
			}
			Selectable selectable = null;
			Selectable[] candidates = Candidates;
			foreach (Selectable selectable2 in candidates)
			{
				if (selectable2.enabled && selectable2.interactable && selectable2.gameObject.activeInHierarchy)
				{
					selectable = selectable2;
					break;
				}
			}
			if (SearchForSelectables && selectable == null)
			{
				candidates = Selectable.allSelectablesArray;
				foreach (Selectable selectable3 in candidates)
				{
					if (selectable3.isActiveAndEnabled && selectable3.interactable && selectable3.gameObject.activeInHierarchy)
					{
						selectable = selectable3;
						break;
					}
				}
			}
			if (selectable != null)
			{
				EventSystem.current.SetSelectedGameObject(selectable.gameObject);
			}
		}
	}
}
