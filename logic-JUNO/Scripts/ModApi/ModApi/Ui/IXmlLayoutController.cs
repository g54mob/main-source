using System;

namespace ModApi.Ui
{
	public interface IXmlLayoutController
	{
		bool LayoutRebuildInProgress { get; set; }

		Action<IXmlLayoutController> OnLayoutRebuilt { get; set; }

		IXmlLayout XmlLayout { get; }
	}
}
