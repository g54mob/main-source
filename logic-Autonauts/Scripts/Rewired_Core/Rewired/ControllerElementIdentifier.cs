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

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private CompoundControllerElementType _compoundElementType;

		internal readonly bool isMappableOnPlatform;

		private bool BxkVLvlCVmksheKkQLjigmvgFDd;

		private static ControllerElementIdentifier FOMTWkGbopmNTJZHrEeeSecnDcl;

		public int id
		{
			get
			{
				return _id;
			}
		}

		public string name
		{
			get
			{
				return _name;
			}
			internal set
			{
				jOdfpVDInJcvsPDrrrPIesyJkCD();
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
				jOdfpVDInJcvsPDrrrPIesyJkCD();
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
				jOdfpVDInJcvsPDrrrPIesyJkCD();
				_negativeName = value;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return _elementType;
			}
		}

		public CompoundControllerElementType compoundElementType
		{
			get
			{
				return _compoundElementType;
			}
		}

		internal bool isCompoundElement
		{
			get
			{
				return _elementType == ControllerElementType.CompoundElement;
			}
		}

		object IControllerElementIdentifierCommon_Internal.elementType
		{
			get
			{
				return _elementType;
			}
		}

		bool IControllerElementIdentifierCommon_Internal.useEditorElementTypeOverride
		{
			get
			{
				return false;
			}
		}

		ControllerElementType IControllerElementIdentifierCommon_Internal.editorElementTypeOverride
		{
			get
			{
				return _elementType;
			}
		}

		internal static ControllerElementIdentifier BlankReadOnly
		{
			get
			{
				if (FOMTWkGbopmNTJZHrEeeSecnDcl == null)
				{
					ControllerElementIdentifier controllerElementIdentifier = new ControllerElementIdentifier();
					while (true)
					{
						int num = -1371103059;
						while (true)
						{
							switch (num ^ -1371103060)
							{
							case 2:
								break;
							case 1:
								goto IL_002b;
							default:
								return FOMTWkGbopmNTJZHrEeeSecnDcl = controllerElementIdentifier;
							}
							break;
							IL_002b:
							controllerElementIdentifier._id = -1;
							controllerElementIdentifier.BxkVLvlCVmksheKkQLjigmvgFDd = true;
							num = -1371103060;
						}
					}
				}
				return FOMTWkGbopmNTJZHrEeeSecnDcl;
			}
		}

		public ControllerElementIdentifier()
		{
		}

		public ControllerElementIdentifier(ControllerElementIdentifier source)
		{
			while (true)
			{
				int num = 634114889;
				while (true)
				{
					switch (num ^ 0x25CBD348)
					{
					case 0:
						break;
					case 1:
						goto IL_0024;
					default:
						_elementType = source._elementType;
						_compoundElementType = source._compoundElementType;
						return;
					}
					break;
					IL_0024:
					isMappableOnPlatform = source.isMappableOnPlatform;
					_id = source._id;
					_name = source._name;
					_positiveName = source._positiveName;
					_negativeName = source._negativeName;
					num = 634114890;
				}
			}
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
			while (true)
			{
				int num = -1257319600;
				while (true)
				{
					switch (num ^ -1257319597)
					{
					case 2:
						break;
					case 3:
						_id = id;
						_name = name;
						_positiveName = positiveName;
						num = -1257319597;
						continue;
					case 0:
						_negativeName = negativeName;
						_elementType = elementType;
						_compoundElementType = CompoundControllerElementType.Axis2D;
						num = -1257319598;
						continue;
					default:
						this.isMappableOnPlatform = isMappableOnPlatform;
						return;
					}
					break;
				}
			}
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
			AxisRange axisRange2 = default(AxisRange);
			while (true)
			{
				int num = -1393634077;
				while (true)
				{
					switch (num ^ -1393634073)
					{
					case 2:
						break;
					case 4:
						switch (actualElementType)
						{
						case ControllerElementType.Axis:
							break;
						case ControllerElementType.Button:
							goto IL_00ef;
						case ControllerElementType.CompoundElement:
							return name;
						default:
							throw new NotImplementedException();
						}
						goto case 5;
					case 6:
						return name;
					case 5:
						axisRange2 = axisRange;
						num = -1393634074;
						continue;
					case 0:
						return name + " +";
					case 3:
						throw new NotImplementedException();
					case 1:
						switch (axisRange2)
						{
						case AxisRange.Full:
							break;
						case AxisRange.Positive:
							if (string.IsNullOrEmpty(positiveName))
							{
								num = -1393634073;
								continue;
							}
							return positiveName;
						case AxisRange.Negative:
							if (string.IsNullOrEmpty(negativeName))
							{
								return name + " -";
							}
							return negativeName;
						default:
							num = -1393634076;
							continue;
						}
						goto case 6;
					default:
						goto IL_00ef;
						IL_00ef:
						return name;
					}
					break;
				}
			}
		}

		public string GetDisplayName(AxisRange axisRange)
		{
			return GetDisplayName(_elementType, axisRange);
		}

		private void jOdfpVDInJcvsPDrrrPIesyJkCD()
		{
			if (!BxkVLvlCVmksheKkQLjigmvgFDd)
			{
				return;
			}
			while (true)
			{
				switch (0x2FFB811 ^ 0x2FFB810)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					throw new Exception("The object is marked readonly and you are trying to modify its values.");
				case 2:
					return;
				}
			}
		}
	}
}
