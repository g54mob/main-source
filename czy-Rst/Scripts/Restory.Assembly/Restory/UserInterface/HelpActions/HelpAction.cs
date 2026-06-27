using System;
using System.Collections.Generic;
using UnityEngine;

namespace Restory.UserInterface.HelpActions
{
	[Serializable]
	public class HelpAction
	{
		[SerializeField]
		private HelpActionObject button;

		private List<HelpActionElement> elements;

		public HelpActionObject Button => button;

		public string LocalizationNameKey => Button.LocalizationNameKey;

		public List<HelpActionElement> Elements => elements ?? (elements = CreateElements());

		public bool Interactable
		{
			set
			{
				SetInteractable(value);
			}
		}

		public HelpAction(HelpActionObject button)
		{
			this.button = button;
			elements = CreateElements();
		}

		private List<HelpActionElement> CreateElements()
		{
			List<HelpActionElement> list = new List<HelpActionElement>();
			foreach (HelpActionElementObject inputActionButton in button.InputActionButtons)
			{
				list.Add(new HelpActionElement(inputActionButton));
			}
			return list;
		}

		public void SetInteractable(bool interactable)
		{
			foreach (HelpActionElement element in Elements)
			{
				element.SetInteractable(interactable);
			}
		}

		public void SetProgress(float progress)
		{
			foreach (HelpActionElement element in Elements)
			{
				element.SetProgress(progress);
			}
		}
	}
}
