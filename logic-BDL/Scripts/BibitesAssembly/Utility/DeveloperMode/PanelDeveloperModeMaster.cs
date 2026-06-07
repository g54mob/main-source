using System.Collections.Generic;
using UIScripts;
using UnityEngine;

namespace Utility.DeveloperMode
{
	public class PanelDeveloperModeMaster : MonoBehaviour
	{
		[SerializeField]
		protected UIPanel panel;

		[SerializeField]
		protected List<DeveloperModeElement> developerElements;

		[SerializeField]
		protected List<GameObject> elementsToHide;

		[SerializeField]
		protected List<GameObject> elementsToShow;

		private Transform realParent;

		protected bool developerMode;

		public void Awake()
		{
			realParent = base.transform.parent;
			RectTransform panelRT = panel.GetComponent<RectTransform>();
			developerElements.ForEach(delegate(DeveloperModeElement e)
			{
				e.SetTarget(panelRT);
			});
			OnDeveloperModeToggle();
		}

		public void ToggleDeveloperMode()
		{
			developerMode = !developerMode;
			OnDeveloperModeToggle();
		}

		protected virtual void OnDeveloperModeToggle()
		{
			panel.transform.SetParent(developerMode ? DeveloperModeUI.tr : realParent);
			developerElements.ForEach(delegate(DeveloperModeElement e)
			{
				e.gameObject.SetActive(developerMode);
			});
			developerElements.ForEach(delegate(DeveloperModeElement e)
			{
				e.OnDeveloperModeChange(developerMode);
			});
			elementsToHide.ForEach(delegate(GameObject b)
			{
				b.SetActive(!developerMode);
			});
			elementsToShow.ForEach(delegate(GameObject b)
			{
				b.SetActive(developerMode);
			});
		}
	}
}
