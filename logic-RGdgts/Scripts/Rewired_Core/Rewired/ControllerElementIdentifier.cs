using System;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	[CustomClassObfuscation]
	public sealed class ControllerElementIdentifier : IControllerElementIdentifierCommon_Internal
	{
		[SerializeField]
		[CustomObfuscation]
		private int _id;

		[SerializeField]
		[CustomObfuscation]
		private string _name;

		[CustomObfuscation]
		[SerializeField]
		private string _positiveName;

		[SerializeField]
		[CustomObfuscation]
		private string _negativeName;

		[SerializeField]
		[CustomObfuscation]
		private ControllerElementType _elementType;

		[CustomObfuscation]
		[SerializeField]
		private CompoundControllerElementType _compoundElementType;

		internal readonly bool isMappableOnPlatform;

		private bool GZlaoDruTrxbpKABIxsvccmRvfdp;

		private static ControllerElementIdentifier YZZmfYAtkqfsBjwUxLvwSrAMvHpE;

		public int id => 0;

		public string name
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public string positiveName
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public string negativeName
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public ControllerElementType elementType => default(ControllerElementType);

		public CompoundControllerElementType compoundElementType => default(CompoundControllerElementType);

		internal bool isCompoundElement => false;

		object IControllerElementIdentifierCommon_Internal.elementType => null;

		bool IControllerElementIdentifierCommon_Internal.useEditorElementTypeOverride => false;

		ControllerElementType IControllerElementIdentifierCommon_Internal.editorElementTypeOverride => default(ControllerElementType);

		internal static ControllerElementIdentifier BlankReadOnly => null;

		public ControllerElementIdentifier()
		{
		}

		public ControllerElementIdentifier(ControllerElementIdentifier P_0)
		{
		}

		internal ControllerElementIdentifier(int P_0, string P_1, string P_2, string P_3, ControllerElementType P_4, CompoundControllerElementType P_5, bool P_6)
		{
		}

		internal ControllerElementIdentifier(int P_0, string P_1, string P_2, string P_3, ControllerElementType P_4, bool P_5)
		{
		}

		internal ControllerElementIdentifier(ControllerElementIdentifier P_0, bool P_1, ControllerElementType P_2)
		{
		}

		public ControllerElementIdentifier Clone()
		{
			return null;
		}

		public string GetDisplayName(ControllerElementType actualElementType, AxisRange axisRange)
		{
			return null;
		}

		public string GetDisplayName(AxisRange axisRange)
		{
			return null;
		}

		private void eLytIlKLbWEwmltOfYSVwAnoYcHq()
		{
		}
	}
}
