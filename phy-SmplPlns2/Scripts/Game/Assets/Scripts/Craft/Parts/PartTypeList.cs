using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Craft.Exceptions;
using Assets.Scripts.Mods;

namespace Assets.Scripts.Craft.Parts
{
	public class PartTypeList
	{
		private Dictionary<string, PartType> _partTypes;

		public PartTypeList()
		{
			_partTypes = new Dictionary<string, PartType>();
		}

		public List<Type> GetDistinctModModifierTypes()
		{
			List<Type> list = new List<Type>();
			foreach (PartType value in _partTypes.Values)
			{
				foreach (Type modModifierType in value.ModModifierTypes)
				{
					if (!list.Contains(modModifierType))
					{
						list.Add(modModifierType);
					}
				}
			}
			return list;
		}

		public PartType GetPartType(string id)
		{
			if (_partTypes.ContainsKey(id))
			{
				return _partTypes[id];
			}
			throw new InvalidPartTypeException("Could not find part type: " + id, id);
		}

		public void LoadModPart(XElement partTypeXml, LoadedMod mod)
		{
			PartType partType = new PartType(partTypeXml, mod);
			if (_partTypes.ContainsKey(partType.PartTypeId))
			{
				throw new Exception("Part Type list has duplicate ID: " + partType.PartTypeId);
			}
			_partTypes[partType.PartTypeId] = partType;
		}

		public void LoadXml(string xml)
		{
			XDocument xDocument = XDocument.Parse(xml);
			try
			{
				foreach (XElement item in xDocument.Element("PartTypes").Elements("PartType"))
				{
					PartType partType = new PartType(item);
					if (!_partTypes.ContainsKey(partType.PartTypeId))
					{
						_partTypes[partType.PartTypeId] = partType;
						foreach (string redirectedPartType in partType.RedirectedPartTypes)
						{
							_partTypes[redirectedPartType] = partType;
						}
						continue;
					}
					throw new Exception("Part Type list has duplicate ID: " + partType.PartTypeId);
				}
			}
			catch (Exception)
			{
				throw new Exception("Failed to parse part types XML.");
			}
		}
	}
}
