using System;
using UnityEngine.SceneManagement;

namespace UI.Xml.Examples
{
	internal class XmlLayout_Example_HUD : XmlLayoutController
	{
		public XmlLayout_Example_ExampleMenu ExampleMenu;

		public override void Hide(Action onCompleteCallback = null)
		{
			if (ExampleMenu != null)
			{
				ExampleMenu.SelectExample();
				return;
			}
			base.Hide(delegate
			{
				SceneManager.LoadScene("ExampleScene");
			});
		}
	}
}
