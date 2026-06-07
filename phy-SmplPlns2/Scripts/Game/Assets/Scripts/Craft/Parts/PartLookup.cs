using System.Collections.Generic;

namespace Assets.Scripts.Craft.Parts
{
	public class PartLookup
	{
		private Dictionary<PartData, bool> _parts = new Dictionary<PartData, bool>();

		public IEnumerable<PartData> Parts => _parts.Keys;

		public void AddPart(PartData part)
		{
			_parts[part] = true;
		}

		public bool ContainsPart(PartData part)
		{
			return _parts.ContainsKey(part);
		}
	}
}
