using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Menu
{
	public class AboutPageScript : MonoBehaviour
	{
		private XmlElement _mainPanel;

		public void Close()
		{
			_mainPanel.Hide();
		}

		public void OnLayoutRebuilt(XmlLayoutController x)
		{
			_mainPanel = x.xmlLayout.GetElementById("main-panel");
		}

		public void Show()
		{
			_mainPanel.Show();
		}

		private void OnCloseAboutPage()
		{
			Close();
		}

		private void Update()
		{
			if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				OnCloseAboutPage();
			}
		}
	}
}
