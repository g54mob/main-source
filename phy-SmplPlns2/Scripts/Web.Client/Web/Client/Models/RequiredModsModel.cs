#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace Web.Client.Models
{
	[Serializable]
	public class RequiredModsModel
	{
		private List<RequiredModModel> _requiredMods;

		public IReadOnlyList<RequiredModModel> RequiredMods => _requiredMods;

		public RequiredModsModel()
		{
			_requiredMods = new List<RequiredModModel>();
		}

		public RequiredModsModel(string requiredModsXml)
		{
			List<RequiredModModel> list = null;
			if (!string.IsNullOrWhiteSpace(requiredModsXml))
			{
				try
				{
					list = (from x in XDocument.Parse(requiredModsXml).Elements("RequiredMods").Elements("RequiredMod")
						select RequiredModModel.CreateFromXml(x)).ToList();
				}
				catch (Exception ex)
				{
					Trace.TraceError(ex.ToString());
				}
			}
			_requiredMods = list ?? new List<RequiredModModel>();
		}

		public void Add(RequiredModModel mod)
		{
			RequiredModModel requiredModModel = _requiredMods.FirstOrDefault((RequiredModModel x) => x.Name == mod.Name && x.Version == mod.Version && x.Author == mod.Author && x.LastModified == mod.LastModified);
			if (requiredModModel == null)
			{
				_requiredMods.Add(mod);
			}
			else if (mod.RequiresCodeExecution)
			{
				requiredModModel.RequiresCodeExecution = mod.RequiresCodeExecution;
			}
		}

		public XElement GenerateXml()
		{
			return new XElement("RequiredMods", RequiredMods.Select((RequiredModModel x) => x.GenerateXml()));
		}

		public void Remove(RequiredModModel mod)
		{
			if (_requiredMods.Contains(mod))
			{
				_requiredMods.Remove(mod);
			}
		}
	}
}
