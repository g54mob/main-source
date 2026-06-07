using System;
using System.Collections.Generic;
using System.Diagnostics;
using SaintsField.Interfaces;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	public class RequireTypeAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly IReadOnlyList<Type> RequiredTypes;

		public readonly EPick EditorPick;

		public readonly bool CustomPicker;

		public readonly bool FreeSign;

		public virtual SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public virtual string GroupBy => "";

		public RequireTypeAttribute(EPick editorPick = EPick.Assets | EPick.Scene, bool freeSign = false, bool customPicker = true, params Type[] requiredTypes)
		{
			RequiredTypes = requiredTypes;
			EditorPick = ((editorPick == (EPick)0) ? (EPick.Assets | EPick.Scene) : editorPick);
			CustomPicker = customPicker;
			FreeSign = freeSign;
		}

		public RequireTypeAttribute(bool freeSign = false, bool customPicker = true, params Type[] requiredTypes)
			: this(EPick.Assets | EPick.Scene, freeSign, customPicker, requiredTypes)
		{
		}

		public RequireTypeAttribute(bool freeSign, params Type[] requiredTypes)
			: this(EPick.Assets | EPick.Scene, freeSign, customPicker: true, requiredTypes)
		{
		}

		public RequireTypeAttribute(EPick editorPick, params Type[] requiredTypes)
			: this(editorPick, freeSign: false, customPicker: true, requiredTypes)
		{
		}

		public RequireTypeAttribute(params Type[] requiredTypes)
			: this(EPick.Assets | EPick.Scene, freeSign: false, customPicker: true, requiredTypes)
		{
		}
	}
}
