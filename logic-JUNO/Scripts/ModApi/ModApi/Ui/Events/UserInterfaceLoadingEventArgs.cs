using System;

namespace ModApi.Ui.Events
{
	public class UserInterfaceLoadingEventArgs : EventArgs
	{
		public BuildUserInterfaceXmlRequest BuildXmlRequest { get; }

		public string UserInterfaceId { get; }

		public IXmlLayout XmlLayout { get; }

		public UserInterfaceLoadingEventArgs(BuildUserInterfaceXmlRequest buildXmlRequest, IXmlLayout xmlLayout)
		{
			UserInterfaceId = buildXmlRequest.UserInterfaceId;
			BuildXmlRequest = buildXmlRequest;
			XmlLayout = xmlLayout;
		}
	}
}
