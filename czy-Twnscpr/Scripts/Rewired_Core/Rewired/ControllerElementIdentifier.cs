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

		[CustomObfuscation]
		[SerializeField]
		private string _name;

		[CustomObfuscation]
		[SerializeField]
		private string _positiveName;

		[CustomObfuscation]
		[SerializeField]
		private string _negativeName;

		[CustomObfuscation]
		[SerializeField]
		private ControllerElementType _elementType;

		[SerializeField]
		[CustomObfuscation]
		private CompoundControllerElementType _compoundElementType;

		internal readonly bool isMappableOnPlatform;

		private bool XdGBivBxlbeHDIntPpcCMFstJAw;

		private static ControllerElementIdentifier TJckJccsXiEibjQKkgYYkYjwAHa;

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

		public ControllerElementIdentifier(ControllerElementIdentifier source)
		{
		}

		internal ControllerElementIdentifier(int id, string name, string positiveName, string negativeName, ControllerElementType elementType, CompoundControllerElementType compoundElementType, bool isMappableOnPlatform)
		{
		}

		internal ControllerElementIdentifier(int id, string name, string positiveName, string negativeName, ControllerElementType elementType, bool isMappableOnPlatform)
		{
		}

		internal ControllerElementIdentifier(ControllerElementIdentifier source, bool isMappableOnPlatform, ControllerElementType changedElementType)
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

		private void hBXnlLsQBAfqUbXyyLqcOGpUNHA()
		{
		}
	}
}
