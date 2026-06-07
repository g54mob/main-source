using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class SetCraftPropertyInstruction : ProgramInstruction
	{
		private string _category;

		private CraftProperty _craftProperty;

		[ProgramNodeProperty]
		private string _property;

		public override ProgramInstruction Execute(IThreadContext context)
		{
			_craftProperty.Setter(context, this);
			return base.Execute(context);
		}

		public override List<ListItemInfo> GetListItems(string listId)
		{
			List<CraftProperty> propertiesInCategory = CraftProperties.GetPropertiesInCategory(_category);
			List<ListItemInfo> list = new List<ListItemInfo>();
			foreach (CraftProperty item in propertiesInCategory)
			{
				list.Add(new ListItemInfo(item.XmlName, item.DisplayName, item.Tooltip, item.ItemType));
			}
			return list;
		}

		public override string GetListValue(string listId)
		{
			return _craftProperty.XmlName;
		}

		public override void OnDeserialized(XElement xml)
		{
			base.OnDeserialized(xml);
			_craftProperty = CraftProperties.GetProperty(_property);
			if (_craftProperty?.Setter != null)
			{
				_category = _craftProperty.Category;
				return;
			}
			throw new InvalidOperationException("Could not find property " + _property);
		}

		public override void SetListValue(string listId, string value)
		{
			List<CraftProperty> propertiesInCategory = CraftProperties.GetPropertiesInCategory(_category);
			_craftProperty = propertiesInCategory.Where((CraftProperty x) => x.XmlName == value).First();
			_property = _craftProperty.XmlName;
		}
	}
}
