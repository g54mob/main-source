using System.Diagnostics;
using SaintsField.Interfaces;
using SaintsField.Utils;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	public class AdvancedDropdownAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly string FuncName;

		public const float DefaultTitleHeight = 45f;

		private const float DefaultSepHeight = 4f;

		public const float TitleHeight = 45f;

		public const float ItemHeight = -1f;

		public const float SepHeight = 4f;

		public const float MinHeight = -1f;

		public const bool UseTotalItemCount = false;

		public readonly EUnique EUnique;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Field;

		public string GroupBy => "__LABEL_FIELD__";

		public AdvancedDropdownAttribute(string funcName = null, EUnique unique = EUnique.None)
		{
			FuncName = RuntimeUtil.ParseCallback(funcName).content;
			EUnique = unique;
		}

		public AdvancedDropdownAttribute(EUnique unique)
			: this(null, unique)
		{
		}
	}
}
