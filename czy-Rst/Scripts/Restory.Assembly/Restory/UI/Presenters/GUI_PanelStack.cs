using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Restory.UI.Presenters
{
	public class GUI_PanelStack : UIBehaviour
	{
		private readonly List<GameObject> panels = new List<GameObject>();

		private GameObject selectedPanel;

		private GUI_RewiredPanelInputModule inputModule;

		public IReadOnlyList<GameObject> Panels => panels;

		[Inject]
		private void Construct(GUI_RewiredPanelInputModule inputModule)
		{
			this.inputModule = inputModule;
		}

		public void AddPanel(GameObject panel)
		{
			if (!panels.Contains(panel))
			{
				panels.Add(panel);
				SetSelectedPanel();
			}
		}

		public void RemovePanel(GameObject panel)
		{
			panels.Remove(panel);
			SetSelectedPanel();
		}

		private void SetSelectedPanel()
		{
			object obj;
			if (panels.Count <= 0)
			{
				obj = null;
			}
			else
			{
				List<GameObject> list = panels;
				obj = list[list.Count - 1].gameObject;
			}
			GameObject gameObject = (GameObject)obj;
			if (!(selectedPanel == gameObject))
			{
				inputModule.RemoveSelectedPanel(selectedPanel);
				selectedPanel = gameObject;
				inputModule.AddSelectedPanel(selectedPanel);
			}
		}
	}
}
