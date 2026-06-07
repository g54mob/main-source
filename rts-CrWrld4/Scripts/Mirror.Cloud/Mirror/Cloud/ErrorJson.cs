using System;

namespace Mirror.Cloud
{
	[Serializable]
	public struct ErrorJson : ICanBeJson
	{
		public string code;

		public string message;

		public int HtmlCode => 0;
	}
}
