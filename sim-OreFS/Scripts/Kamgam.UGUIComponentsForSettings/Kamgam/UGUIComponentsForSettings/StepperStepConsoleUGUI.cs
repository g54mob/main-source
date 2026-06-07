using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.UGUIComponentsForSettings
{
	public class StepperStepConsoleUGUI : MonoBehaviour
	{
		public GameObject Inactive;

		public GameObject Active;

		public static List<StepperStepConsoleUGUI> CreateSteps(Transform container, GameObject template, int totalSteps)
		{
			if (template == null)
			{
				return null;
			}
			template.gameObject.SetActive(value: false);
			StepperStepConsoleUGUI[] componentsInChildren = container.GetComponentsInChildren<StepperStepConsoleUGUI>(includeInactive: true);
			foreach (StepperStepConsoleUGUI stepperStepConsoleUGUI in componentsInChildren)
			{
				if (!stepperStepConsoleUGUI.name.EndsWith("_Template"))
				{
					smartDestroy(stepperStepConsoleUGUI.gameObject);
				}
			}
			List<StepperStepConsoleUGUI> list = new List<StepperStepConsoleUGUI>();
			for (int j = 0; j < totalSteps; j++)
			{
				GameObject obj = Object.Instantiate(template, container);
				obj.name = template.name.Replace("_Template", "");
				obj.SetActive(value: true);
				StepperStepConsoleUGUI component = obj.GetComponent<StepperStepConsoleUGUI>();
				component.SetActive(active: false);
				list.Add(component);
			}
			return list;
		}

		public static void SetActive(List<StepperStepConsoleUGUI> steps, int activeSteps)
		{
			if (steps != null)
			{
				for (int i = 0; i < steps.Count; i++)
				{
					steps[i].SetActive(i < activeSteps);
				}
			}
		}

		private static void smartDestroy(Object obj)
		{
			if (!(obj == null))
			{
				Object.Destroy(obj);
			}
		}

		public void SetActive(bool active)
		{
			Active.gameObject.SetActive(active);
			Inactive.gameObject.SetActive(!active);
		}
	}
}
