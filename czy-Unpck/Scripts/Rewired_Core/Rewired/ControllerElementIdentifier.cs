using System;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class ControllerElementIdentifier : IControllerElementIdentifierCommon_Internal
	{
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _id;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _name;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _positiveName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _negativeName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ControllerElementType _elementType;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CompoundControllerElementType _compoundElementType;

		internal readonly bool isMappableOnPlatform;

		private bool yUyawoDmbmvqRHFODQrxsVStOAB;

		private static ControllerElementIdentifier yqMbcljeAvorYyeouupjdOGcRME;

		public int id => _id;

		public string name
		{
			get
			{
				return _name;
			}
			internal set
			{
				KMzQnAufOVsppeuQmqRTinGCRle();
				_name = value;
			}
		}

		public string positiveName
		{
			get
			{
				return _positiveName;
			}
			internal set
			{
				KMzQnAufOVsppeuQmqRTinGCRle();
				_positiveName = value;
			}
		}

		public string negativeName
		{
			get
			{
				return _negativeName;
			}
			internal set
			{
				KMzQnAufOVsppeuQmqRTinGCRle();
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
				if (yqMbcljeAvorYyeouupjdOGcRME == null)
				{
					ControllerElementIdentifier controllerElementIdentifier = new ControllerElementIdentifier();
					controllerElementIdentifier._id = -1;
					while (true)
					{
						int num = 1675460217;
						while (true)
						{
							switch (num ^ 0x63DD7E7B)
							{
							case 0:
								break;
							case 2:
								goto IL_0032;
							default:
								return yqMbcljeAvorYyeouupjdOGcRME = controllerElementIdentifier;
							}
							break;
							IL_0032:
							controllerElementIdentifier.yUyawoDmbmvqRHFODQrxsVStOAB = true;
							num = 1675460218;
						}
					}
				}
				return yqMbcljeAvorYyeouupjdOGcRME;
			}
		}

		public ControllerElementIdentifier()
		{
		}

		public ControllerElementIdentifier(ControllerElementIdentifier source)
		{
			isMappableOnPlatform = source.isMappableOnPlatform;
			_id = source._id;
			_name = source._name;
			_positiveName = source._positiveName;
			_negativeName = source._negativeName;
			_elementType = source._elementType;
			_compoundElementType = source._compoundElementType;
		}

		internal ControllerElementIdentifier(int id, string name, string positiveName, string negativeName, ControllerElementType elementType, CompoundControllerElementType compoundElementType, bool isMappableOnPlatform)
		{
			_id = id;
			_name = name;
			_positiveName = positiveName;
			_negativeName = negativeName;
			_elementType = elementType;
			_compoundElementType = compoundElementType;
			this.isMappableOnPlatform = isMappableOnPlatform;
		}

		internal ControllerElementIdentifier(int id, string name, string positiveName, string negativeName, ControllerElementType elementType, bool isMappableOnPlatform)
		{
			_id = id;
			_name = name;
			_positiveName = positiveName;
			_negativeName = negativeName;
			_elementType = elementType;
			_compoundElementType = CompoundControllerElementType.Axis2D;
			this.isMappableOnPlatform = isMappableOnPlatform;
		}

		internal ControllerElementIdentifier(ControllerElementIdentifier source, bool isMappableOnPlatform, ControllerElementType changedElementType)
			: this(source)
		{
			_elementType = changedElementType;
			this.isMappableOnPlatform = isMappableOnPlatform;
		}

		public ControllerElementIdentifier Clone()
		{
			return new ControllerElementIdentifier(this);
		}

		public string GetDisplayName(ControllerElementType actualElementType, AxisRange axisRange)
		{
			int num;
			switch (actualElementType)
			{
			default:
				num = -914637988;
				goto IL_0015;
			case ControllerElementType.Axis:
				goto IL_00a9;
			case ControllerElementType.Button:
				goto IL_00e4;
				IL_0015:
				switch (num ^ -914637987)
				{
				case 4:
					break;
				case 6:
					return name + " -";
				case 2:
					throw new NotImplementedException();
				case 3:
					goto IL_0066;
				case 5:
					goto IL_00a9;
				case 1:
					goto IL_00d3;
				default:
					goto IL_00e4;
				}
				goto default;
				IL_00e4:
				return name;
				IL_00d3:
				if (actualElementType == ControllerElementType.CompoundElement)
				{
					return name;
				}
				throw new NotImplementedException();
				IL_006d:
				if (string.IsNullOrEmpty(positiveName))
				{
					return name + " +";
				}
				return positiveName;
				IL_0066:
				return name;
				IL_00a9:
				switch (axisRange)
				{
				case AxisRange.Full:
					break;
				case AxisRange.Positive:
					goto IL_006d;
				case AxisRange.Negative:
					goto IL_0092;
				default:
					goto IL_00bd;
				}
				goto IL_0066;
				IL_00bd:
				num = -914637985;
				goto IL_0015;
				IL_0092:
				if (!string.IsNullOrEmpty(negativeName))
				{
					return negativeName;
				}
				num = -914637989;
				goto IL_0015;
			}
		}

		public string GetDisplayName(AxisRange axisRange)
		{
			return GetDisplayName(_elementType, axisRange);
		}

		private void KMzQnAufOVsppeuQmqRTinGCRle()
		{
			if (yUyawoDmbmvqRHFODQrxsVStOAB)
			{
				throw new Exception("The object is marked readonly and you are trying to modify its values.");
			}
		}
	}
}
