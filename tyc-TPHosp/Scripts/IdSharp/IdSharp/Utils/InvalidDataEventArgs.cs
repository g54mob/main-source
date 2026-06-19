using System;

namespace IdSharp.Utils
{
	public sealed class InvalidDataEventArgs : EventArgs
	{
		private string m_Property;

		private string m_Message;

		public string Property => m_Property;

		public string Message => m_Message;

		public InvalidDataEventArgs(string propertyName, string message)
		{
			m_Property = propertyName;
			m_Message = message;
		}
	}
}
