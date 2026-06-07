using System;

namespace ModApi.Ui.Events
{
	public class UserInterfaceLoadedEventArgs : EventArgs
	{
		public string UserInterfaceId { get; }

		public IXmlLayout XmlLayout { get; }

		public UserInterfaceLoadedEventArgs(string userInterfaceId, IXmlLayout xmlLayout)
		{
			UserInterfaceId = userInterfaceId;
			XmlLayout = xmlLayout;
		}
	}
}
