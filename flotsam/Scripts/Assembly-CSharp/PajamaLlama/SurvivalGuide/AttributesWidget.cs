using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using UnityEngine;

namespace PajamaLlama.SurvivalGuide
{
	internal class AttributesWidget : BaseWidget
	{
		internal class Parameters : BaseParameters
		{
			public Parameters(Dictionary<string, object> parameters)
			{
			}
		}

		[SerializeField]
		private DrifterAttributes _drifterAttributes;

		[SerializeField]
		private Table _table;

		[SerializeField]
		private LocalizedString _attributeName = null;

		[SerializeField]
		private LocalizedString _attributeDescription = null;

		[SerializeField]
		private float _attributeNameWidth = 130f;

		[SerializeField]
		private float _attributeDescriptionWidth = 300f;

		internal override void Initialize(BaseParameters parameters)
		{
			Table.Row row = _table.AddRow();
			_table.TryAddEntry(row, "header", _attributeName, _attributeNameWidth, out var entry);
			_table.TryAddEntry(row, "header", _attributeDescription, _attributeDescriptionWidth, out entry);
			foreach (DrifterAttributes.AttributeType item in from e in DrifterAttributes.ReturnAttributeTypes()
				orderby e.ToString()
				select e)
			{
				LocalizedString localizedString = _drifterAttributes.ReturnAttributeName(item);
				LocalizedString description = _drifterAttributes.ReturnAttribute(item).Description;
				if ((string)localizedString != null && (string)description != null)
				{
					Table.Row row2 = _table.AddRow();
					_table.TryAddEntry(row2, "row-highlighted", localizedString, _attributeNameWidth, out entry);
					_table.TryAddEntry(row2, "row", description, _attributeDescriptionWidth, out entry);
				}
			}
		}

		internal override BaseParameters CreateParameters(Dictionary<string, object> parameters)
		{
			return new Parameters(parameters);
		}
	}
}
