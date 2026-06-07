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

		[SerializeField]
		[CustomObfuscation]
		private string _name;

		[CustomObfuscation]
		[SerializeField]
		private string _positiveName;

		[CustomObfuscation]
		[SerializeField]
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

		public ControllerTemplateElementIdentifier(ControllerTemplateElementIdentifier P_0)
		{
		}

		internal ControllerTemplateElementIdentifier(int P_0, string P_1, string P_2, string P_3, ControllerTemplateElementType P_4, bool P_5)
		{
		}

		internal ControllerTemplateElementIdentifier(ControllerTemplateElementIdentifier P_0, ControllerTemplateElementType P_1, bool P_2)
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
