using System.Collections.Generic;
using System.Xml.Linq;
using Jundroo.ModTools;
using ModApi.Exceptions;

namespace ModApi.Craft.Parts
{
	public class PartTypeList
	{
		private Dictionary<string, PartType> _partTypes;

		public PartTypeList()
		{
			_partTypes = new Dictionary<string, PartType>();
		}

		public PartType Add(XElement partTypeElement, ILoadedMod mod = null)
		{
			PartType partType = new PartType(partTypeElement, mod);
			if (!_partTypes.ContainsKey(partType.Id))
			{
				_partTypes[partType.Id] = partType;
				return partType;
			}
			throw new GameException("Part Type list has duplicate ID: " + partType.Id);
		}

		public PartType GetPartType(string id)
		{
			if (_partTypes.ContainsKey(id))
			{
				return _partTypes[id];
			}
			throw new InvalidPartTypeException("Could not find part type: " + id, id);
		}
	}
}
