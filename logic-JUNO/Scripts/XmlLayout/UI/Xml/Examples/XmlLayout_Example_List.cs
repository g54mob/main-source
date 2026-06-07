using UnityEngine;

namespace UI.Xml.Examples
{
	internal class XmlLayout_Example_List : XmlLayoutController
	{
		private XmlElementReference<XmlLayoutProgressBar> progressBar;

		private void Start()
		{
			progressBar = XmlElementReference<XmlLayoutProgressBar>("progressBar");
		}

		private void Update()
		{
			progressBar.element.percentage += Time.deltaTime * 2.5f;
			if (progressBar.element.percentage >= 100f)
			{
				progressBar.element.percentage = 0f;
			}
		}
	}
}
