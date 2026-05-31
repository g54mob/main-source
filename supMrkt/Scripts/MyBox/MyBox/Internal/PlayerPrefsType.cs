using System;

namespace MyBox.Internal
{
	[Serializable]
	public abstract class PlayerPrefsType
	{
		public string Key { get; protected set; }

		public bool IsSet => false;

		public void Delete()
		{
		}
	}
}
