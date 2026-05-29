using System;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public class ControllerTemplateElementIdentifier : IControllerElementIdentifierCommon_Internal, IControllerTemplateElementIdentifier
	{
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _id;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _name;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _positiveName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _negativeName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ControllerTemplateElementType _elementType;

		internal readonly bool isMappableOnPlatform;

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
				_negativeName = value;
			}
		}

		public ControllerTemplateElementType elementType
		{
			get
			{
				return _elementType;
			}
		}

		internal virtual bool useEditorElementTypeOverride
		{
			get
			{
				return false;
			}
		}

		internal virtual ControllerElementType editorElementTypeOverride
		{
			get
			{
				throw new NotImplementedException();
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
				return useEditorElementTypeOverride;
			}
		}

		ControllerElementType IControllerElementIdentifierCommon_Internal.editorElementTypeOverride
		{
			get
			{
				return editorElementTypeOverride;
			}
		}

		public ControllerTemplateElementIdentifier()
		{
		}

		public ControllerTemplateElementIdentifier(ControllerTemplateElementIdentifier source)
		{
			while (true)
			{
				int num = -575916763;
				while (true)
				{
					switch (num ^ -575916764)
					{
					case 0:
						break;
					case 1:
						goto IL_0024;
					default:
						_id = source._id;
						_name = source._name;
						_positiveName = source._positiveName;
						_negativeName = source._negativeName;
						_elementType = source._elementType;
						return;
					}
					break;
					IL_0024:
					isMappableOnPlatform = source.isMappableOnPlatform;
					num = -575916762;
				}
			}
		}

		internal ControllerTemplateElementIdentifier(int id, string name, string positiveName, string negativeName, ControllerTemplateElementType elementType, bool isMappableOnPlatform)
		{
			_id = id;
			_name = name;
			_positiveName = positiveName;
			_negativeName = negativeName;
			_elementType = elementType;
			this.isMappableOnPlatform = isMappableOnPlatform;
		}

		internal ControllerTemplateElementIdentifier(ControllerTemplateElementIdentifier source, ControllerTemplateElementType changedElementType, bool isMappableOnPlatform)
			: this(source)
		{
			_elementType = changedElementType;
			this.isMappableOnPlatform = isMappableOnPlatform;
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
				while (true)
				{
					IL_00ab:
					switch (axisRange)
					{
					case AxisRange.Negative:
						if (string.IsNullOrEmpty(negativeName))
						{
							return name + " -";
						}
						return negativeName;
					default:
						throw new NotImplementedException();
					case AxisRange.Full:
						return name;
					case AxisRange.Positive:
						{
							if (!string.IsNullOrEmpty(positiveName))
							{
								return positiveName;
							}
							int num = 520831193;
							while (true)
							{
								switch (num ^ 0x1F0B40DB)
								{
								case 0:
									num = 520831194;
									continue;
								case 2:
									return name + " +";
								case 3:
									break;
								case 1:
									goto IL_00ab;
								default:
									goto end_IL_00ae;
								}
								break;
							}
							goto case AxisRange.Full;
						}
						end_IL_00ae:
						break;
					}
					break;
				}
				goto case ControllerTemplateElementType.Button;
			case ControllerTemplateElementType.Button:
				return name;
			default:
				return name;
			}
		}

		internal ControllerElementIdentifier ToControllerElementIdentifier()
		{
			return new ControllerElementIdentifier(_id, _name, _positiveName, _negativeName, KVNLqybISELdZVRJeMgGCnyHIcv.GbAArqJlIQEtJddnaipTXTcVclHP(_elementType), CompoundControllerElementType.Axis2D, isMappableOnPlatform);
		}
	}
}
