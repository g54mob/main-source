using System;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	[CustomClassObfuscation]
	public class ControllerTemplateElementIdentifier : IControllerElementIdentifierCommon_Internal, IControllerTemplateElementIdentifier
	{
		[SerializeField]
		[CustomObfuscation]
		private int _id;

		[CustomObfuscation]
		[SerializeField]
		private string _name;

		[SerializeField]
		[CustomObfuscation]
		private string _positiveName;

		[SerializeField]
		[CustomObfuscation]
		private string _negativeName;

		[CustomObfuscation]
		[SerializeField]
		private ControllerTemplateElementType _elementType;

		internal readonly bool isMappableOnPlatform;

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

		public ControllerTemplateElementType elementType => default(ControllerTemplateElementType);

		internal virtual bool useEditorElementTypeOverride => false;

		internal virtual ControllerElementType editorElementTypeOverride => default(ControllerElementType);

		object IControllerElementIdentifierCommon_Internal.elementType => null;

		bool IControllerElementIdentifierCommon_Internal.useEditorElementTypeOverride => false;

		ControllerElementType IControllerElementIdentifierCommon_Internal.editorElementTypeOverride => default(ControllerElementType);

		public ControllerTemplateElementIdentifier()
		{
		}

		public ControllerTemplateElementIdentifier(ControllerTemplateElementIdentifier source)
		{
		}

		internal ControllerTemplateElementIdentifier(int id, string name, string positiveName, string negativeName, ControllerTemplateElementType elementType, bool isMappableOnPlatform)
		{
		}

		internal ControllerTemplateElementIdentifier(ControllerTemplateElementIdentifier source, ControllerTemplateElementType changedElementType, bool isMappableOnPlatform)
		{
		}

		public virtual ControllerTemplateElementIdentifier Clone()
		{
			return null;
		}

		public string GetDisplayName(AxisRange axisRange)
		{
			return null;
		}

		internal ControllerElementIdentifier ToControllerElementIdentifier()
		{
			return null;
		}
	}
}
