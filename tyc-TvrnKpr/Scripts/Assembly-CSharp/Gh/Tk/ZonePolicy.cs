using System;
using LitJson;

namespace Gh.Tk
{
	[Serializable]
	public class ZonePolicy
	{
		public string id;

		public string label;

		public bool isEnabled;

		public bool isShown;

		public string[] zonesRequired;

		[JsonIgnore]
		public bool IsVisible => false;

		[JsonIgnore]
		public bool IsRequirementsMet => false;

		public ZonePolicy Clone()
		{
			return null;
		}
	}
}
