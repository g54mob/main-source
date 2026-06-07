using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class UniversalGizmoConfig : Settings
	{
		[SerializeField]
		private UniversalGizmoSettingsCategory _inheritCategory;

		[SerializeField]
		private UniversalGizmoSettingsType _inheritType = UniversalGizmoSettingsType.LookAndFeel3D;

		[SerializeField]
		private UniversalGizmoSettingsCategory _displayCategory;

		public UniversalGizmoSettingsCategory InheritCategory
		{
			get
			{
				return _inheritCategory;
			}
			set
			{
				_inheritCategory = value;
			}
		}

		public UniversalGizmoSettingsType InheritType
		{
			get
			{
				return _inheritType;
			}
			set
			{
				_inheritType = value;
			}
		}

		public UniversalGizmoSettingsCategory DisplayCategory
		{
			get
			{
				return _displayCategory;
			}
			set
			{
				_displayCategory = value;
			}
		}
	}
}
