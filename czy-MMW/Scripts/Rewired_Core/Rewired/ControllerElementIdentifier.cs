using System;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class ControllerElementIdentifier : IControllerElementIdentifierCommon_Internal
	{
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _id;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _name;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _positiveName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _negativeName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ControllerElementType _elementType;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CompoundControllerElementType _compoundElementType;

		internal readonly bool isMappableOnPlatform;

		private bool FjvQQCvOsRKYAEoHSbIAnEjmHuUp;

		private static ControllerElementIdentifier kerecHtyiphoaHoSSGQskINaFGTnA;

		int IControllerElementIdentifierCommon_Internal.id => _id;

		string IControllerElementIdentifierCommon_Internal.name
		{
			get
			{
				return _name;
			}
			internal set
			{
				sTfrdBekgMzDfWRKKBHHOLcjIxuGA();
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
				sTfrdBekgMzDfWRKKBHHOLcjIxuGA();
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
				sTfrdBekgMzDfWRKKBHHOLcjIxuGA();
				_negativeName = value;
			}
		}

		public ControllerElementType elementType => _elementType;

		public CompoundControllerElementType compoundElementType => _compoundElementType;

		internal bool isCompoundElement => _elementType == ControllerElementType.CompoundElement;

		object IControllerElementIdentifierCommon_Internal.elementType => _elementType;

		bool IControllerElementIdentifierCommon_Internal.useEditorElementTypeOverride => false;

		ControllerElementType IControllerElementIdentifierCommon_Internal.editorElementTypeOverride => _elementType;

		internal static ControllerElementIdentifier BlankReadOnly
		{
			get
			{
				if (kerecHtyiphoaHoSSGQskINaFGTnA == null)
				{
					ControllerElementIdentifier result = new ControllerElementIdentifier
					{
						_id = -1,
						FjvQQCvOsRKYAEoHSbIAnEjmHuUp = true
					};
					kerecHtyiphoaHoSSGQskINaFGTnA = result;
					return result;
				}
				return kerecHtyiphoaHoSSGQskINaFGTnA;
			}
		}

		public ControllerElementIdentifier()
		{
		}

		public ControllerElementIdentifier(ControllerElementIdentifier P_0)
		{
			isMappableOnPlatform = P_0.isMappableOnPlatform;
			_id = P_0._id;
			_name = P_0._name;
			_positiveName = P_0._positiveName;
			_negativeName = P_0._negativeName;
			_elementType = P_0._elementType;
			_compoundElementType = P_0._compoundElementType;
		}

		internal ControllerElementIdentifier(int P_0, string P_1, string P_2, string P_3, ControllerElementType P_4, CompoundControllerElementType P_5, bool P_6)
		{
			_id = P_0;
			_name = P_1;
			_positiveName = P_2;
			_negativeName = P_3;
			_elementType = P_4;
			_compoundElementType = P_5;
			isMappableOnPlatform = P_6;
		}

		internal ControllerElementIdentifier(int P_0, string P_1, string P_2, string P_3, ControllerElementType P_4, bool P_5)
		{
			_id = P_0;
			_name = P_1;
			_positiveName = P_2;
			_negativeName = P_3;
			_elementType = P_4;
			_compoundElementType = CompoundControllerElementType.Axis2D;
			isMappableOnPlatform = P_5;
		}

		internal ControllerElementIdentifier(ControllerElementIdentifier P_0, bool P_1, ControllerElementType P_2)
			: this(P_0)
		{
			_elementType = P_2;
			isMappableOnPlatform = P_1;
		}

		public ControllerElementIdentifier Clone()
		{
			return new ControllerElementIdentifier(this);
		}

		public string GetDisplayName(ControllerElementType actualElementType, AxisRange axisRange)
		{
			switch (actualElementType)
			{
			case ControllerElementType.Axis:
				switch (axisRange)
				{
				case AxisRange.Full:
					return ((IControllerElementIdentifierCommon_Internal)this).name;
				case AxisRange.Positive:
					if (string.IsNullOrEmpty(((IControllerElementIdentifierCommon_Internal)this).positiveName))
					{
						return ((IControllerElementIdentifierCommon_Internal)this).name + " +";
					}
					return ((IControllerElementIdentifierCommon_Internal)this).positiveName;
				case AxisRange.Negative:
					if (string.IsNullOrEmpty(((IControllerElementIdentifierCommon_Internal)this).negativeName))
					{
						return ((IControllerElementIdentifierCommon_Internal)this).name + " -";
					}
					return ((IControllerElementIdentifierCommon_Internal)this).negativeName;
				default:
					throw new NotImplementedException();
				}
			case ControllerElementType.Button:
				return ((IControllerElementIdentifierCommon_Internal)this).name;
			case ControllerElementType.CompoundElement:
				return ((IControllerElementIdentifierCommon_Internal)this).name;
			default:
				throw new NotImplementedException();
			}
		}

		public string GetDisplayName(AxisRange axisRange)
		{
			return GetDisplayName(_elementType, axisRange);
		}

		private void sTfrdBekgMzDfWRKKBHHOLcjIxuGA()
		{
			if (FjvQQCvOsRKYAEoHSbIAnEjmHuUp)
			{
				throw new Exception("The object is marked readonly and you are trying to modify its values.");
			}
		}
	}
}
