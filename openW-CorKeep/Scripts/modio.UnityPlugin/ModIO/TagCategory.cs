using System;

namespace ModIO
{
	[Serializable]
	public struct TagCategory
	{
		public string name;

		public Tag[] tags;

		public bool multiSelect;

		public bool hidden;

		public bool locked;
	}
}
