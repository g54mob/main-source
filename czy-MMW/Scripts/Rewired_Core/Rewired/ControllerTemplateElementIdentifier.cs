using System;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public class ControllerTemplateElementIdentifier : IControllerElementIdentifierCommon_Internal, IControllerTemplateElementIdentifier
	{
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _id;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _name;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _positiveName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _negativeName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerTemplateElementType _elementType;

		internal readonly bool isMappableOnPlatform;

		int IControllerElementIdentifierCommon_Internal.id => _id;

		string IControllerElementIdentifierCommon_Internal.name
		{
			get
			{
				return _name;
			}
			internal set
			{
				_name = value;
			}
		}

		string IControllerElementIdentifierCommon_Internal.positiveName
		{
			get
			{
				return _positiveName;
			}
			internal set
			{
				_positiveName = value;
			}
		}

		string IControllerElementIdentifierCommon_Internal.negativeName
		{
			get
			{
				return _negativeName;
			}
			internal set
			{
				_negativeName = value;
			}
		}

		ControllerTemplateElementType IControllerTemplateElementIdentifier.elementType => _elementType;

		internal virtual bool useEditorElementTypeOverride => false;

		internal virtual ControllerElementType editorElementTypeOverride
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		object IControllerElementIdentifierCommon_Internal.elementType => _elementType;

		bool IControllerElementIdentifierCommon_Internal.useEditorElementTypeOverride => useEditorElementTypeOverride;

		ControllerElementType IControllerElementIdentifierCommon_Internal.editorElementTypeOverride => editorElementTypeOverride;

		public ControllerTemplateElementIdentifier()
		{
		}

		public ControllerTemplateElementIdentifier(ControllerTemplateElementIdentifier P_0)
		{
			isMappableOnPlatform = P_0.isMappableOnPlatform;
			_id = P_0._id;
			_name = P_0._name;
			_positiveName = P_0._positiveName;
			_negativeName = P_0._negativeName;
			_elementType = P_0._elementType;
		}

		internal ControllerTemplateElementIdentifier(int P_0, string P_1, string P_2, string P_3, ControllerTemplateElementType P_4, bool P_5)
		{
			_id = P_0;
			_name = P_1;
			_positiveName = P_2;
			_negativeName = P_3;
			_elementType = P_4;
			isMappableOnPlatform = P_5;
		}

		internal ControllerTemplateElementIdentifier(ControllerTemplateElementIdentifier P_0, ControllerTemplateElementType P_1, bool P_2)
			: this(P_0)
		{
			_elementType = P_1;
			isMappableOnPlatform = P_2;
		}

		public virtual ControllerTemplateElementIdentifier Clone()
		{
			return new ControllerTemplateElementIdentifier(this);
		}

		public string GetDisplayName(AxisRange axisRange)
		{
			switch (_elementType)
			{
			case ControllerTemplateElementType.Axis:
				switch (axisRange)
				{
				case AxisRange.Full:
					return Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
				case AxisRange.Positive:
					if (string.IsNullOrEmpty(Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName))
					{
						return Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " +";
					}
					return Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName;
				case AxisRange.Negative:
					if (string.IsNullOrEmpty(Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EnegativeName))
					{
						return Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " -";
					}
					return Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EnegativeName;
				default:
					throw new NotImplementedException();
				}
			case ControllerTemplateElementType.Button:
				return Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
			default:
				return Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
			}
		}

		internal ControllerElementIdentifier ToControllerElementIdentifier()
		{
			return new ControllerElementIdentifier(_id, _name, _positiveName, _negativeName, pMvvECjJycyKibKKCAXEnFbBPTVk.qiCEXRJtssyvtdadsNZbLyyWCGGU(_elementType), CompoundControllerElementType.Axis2D, isMappableOnPlatform);
		}
	}
}
