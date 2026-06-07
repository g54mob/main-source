using System.Collections.Generic;
using UnityEngine;

namespace UIScripts
{
	public class MenuManager : MonoBehaviour
	{
		public List<GameObject> Panels = new List<GameObject>();

		private void Start()
		{
			SetActiveAllPanels();
			SetActiveAllPanels(active: false);
		}

		public void SetActiveAllPanels(bool active = true)
		{
			foreach (GameObject panel in Panels)
			{
				panel.SetActive(active);
			}
		}
	}
}
