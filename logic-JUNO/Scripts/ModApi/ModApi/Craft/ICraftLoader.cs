using System;
using System.Xml.Linq;

namespace ModApi.Craft
{
	public interface ICraftLoader
	{
		CraftData LoadCraftImmediate(string craftId);

		CraftData LoadCraftImmediate(XElement craftXml);

		void LoadCraftInteractive(string craftId, Action<CraftData> successCallback, Action failureCallback);

		void LoadCraftInteractive(XElement craftXml, Action<CraftData> successCallback, Action failureCallback);
	}
}
