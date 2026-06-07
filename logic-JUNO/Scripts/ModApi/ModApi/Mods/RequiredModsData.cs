using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ModApi.Mods
{
	public class RequiredModsData
	{
		public const string XmlRootName = "RequiredMods";

		private List<RequiredModData> _mods;

		public IReadOnlyList<RequiredModData> Mods => _mods;

		public RequiredModsData()
		{
			_mods = new List<RequiredModData>();
		}

		public RequiredModsData(XElement xml)
		{
			_mods = (from x in xml?.Elements("RequiredMod")
				select new RequiredModData(x)).ToList() ?? new List<RequiredModData>(0);
		}

		public RequiredModsData(RequiredMods requiredMods)
		{
			_mods = new List<RequiredModData>(requiredMods.Mods.Select((RequiredMod x) => new RequiredModData(x)));
		}

		public void Add(RequiredModsData requiredMods)
		{
			if (requiredMods == null)
			{
				return;
			}
			IReadOnlyList<RequiredModData> mods = requiredMods.Mods;
			if (mods.Count <= 0)
			{
				return;
			}
			foreach (RequiredModData item in mods)
			{
				Add(item);
			}
		}

		public void Add(RequiredModData requiredMod)
		{
			RequiredModData requiredModData = _mods.FirstOrDefault((RequiredModData x) => x.Name == requiredMod.Name && x.Version == requiredMod.Version && x.Author == requiredMod.Author && x.LastModified == requiredMod.LastModified);
			if (requiredModData == null)
			{
				_mods.Add(requiredMod);
			}
			else if (requiredMod.RequiresCodeExecution)
			{
				requiredModData.RequiresCodeExecution = requiredMod.RequiresCodeExecution;
			}
		}

		public XElement GenerateXml()
		{
			if (_mods.Count != 0)
			{
				return new XElement("RequiredMods", _mods.Select((RequiredModData x) => x.GenerateXml()));
			}
			return null;
		}

		public bool Remove(RequiredModData requiredMod)
		{
			return _mods.Remove(requiredMod);
		}
	}
}
