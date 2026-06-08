using System;

namespace Dorfromantik
{
	[Serializable]
	public class CustomInstanceInt
	{
		public string propertyName;

		public int value;

		public CustomInstanceInt(string propertyName, int value)
		{
			this.propertyName = propertyName;
			this.value = value;
		}
	}
}
