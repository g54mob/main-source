using System.Collections.Generic;
using System.Diagnostics;
using Sirenix.OdinInspector.Internal;

namespace Sirenix.OdinInspector
{
	public class ColumnGroupAttribute : PropertyGroupAttribute, ISubGroupProviderAttribute
	{
		[Conditional("UNITY_EDITOR")]
		public class ColumnSubGroupAttribute : PropertyGroupAttribute
		{
			public ColumnSize Size;

			public ColumnSubGroupAttribute(ColumnGroupAttribute column, string groupId, float order)
				: base(null, 0f)
			{
			}
		}

		public const string DEFAULT_ROW_NAME = "_DefaultRow";

		public string ColumnId;

		public List<ColumnGroupAttribute> Columns;

		public ColumnSize Size;

		public ColumnGroupAttribute(string rowId, string columnId, ColumnType columnType = ColumnType.Auto, float columnSize = 0f, float order = 0f)
			: base(null, 0f)
		{
		}

		public ColumnGroupAttribute(string rowId, string columnId, float columnSize, float order = 0f)
			: base(null, 0f)
		{
		}

		public ColumnGroupAttribute(string columnId)
			: base(null, 0f)
		{
		}

		public ColumnGroupAttribute(string columnId, float columnSize, float order = 0f)
			: base(null, 0f)
		{
		}

		public ColumnGroupAttribute(string columnId, ColumnType columnType, float columnSize, float order = 0f)
			: base(null, 0f)
		{
		}

		public IList<PropertyGroupAttribute> GetSubGroupAttributes()
		{
			return null;
		}

		public string RepathMemberAttribute(PropertyGroupAttribute attr)
		{
			return null;
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
		}
	}
}
