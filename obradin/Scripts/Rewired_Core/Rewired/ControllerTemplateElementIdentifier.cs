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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _name;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _positiveName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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
			isMappableOnPlatform = source.isMappableOnPlatform;
			_id = source._id;
			_name = source._name;
			_positiveName = source._positiveName;
			_negativeName = source._negativeName;
			_elementType = source._elementType;
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
			while (true)
			{
				int num = -263965766;
				while (true)
				{
					switch (num ^ -263965765)
					{
					case 0:
						break;
					case 1:
						goto IL_0025;
					default:
						this.isMappableOnPlatform = isMappableOnPlatform;
						return;
					}
					break;
					IL_0025:
					_elementType = changedElementType;
					num = -263965767;
				}
			}
		}

		public virtual ControllerTemplateElementIdentifier Clone()
		{
			return new ControllerTemplateElementIdentifier(this);
		}

		public string GetDisplayName(AxisRange axisRange)
		{
			ControllerTemplateElementType controllerTemplateElementType = _elementType;
			while (true)
			{
				switch (-1019504005 ^ -1019504007)
				{
				case 4:
					continue;
				case 2:
					switch (controllerTemplateElementType)
					{
					case ControllerTemplateElementType.Axis:
						break;
					case ControllerTemplateElementType.Button:
						goto end_IL_0012;
					default:
						return name;
					}
					goto case 1;
				case 3:
					return name;
				case 1:
					{
						switch (axisRange)
						{
						case AxisRange.Full:
							break;
						case AxisRange.Positive:
							if (string.IsNullOrEmpty(positiveName))
							{
								return name + " +";
							}
							return positiveName;
						case AxisRange.Negative:
							if (string.IsNullOrEmpty(negativeName))
							{
								return name + " -";
							}
							return negativeName;
						default:
							throw new NotImplementedException();
						}
						goto case 3;
					}
					end_IL_0012:
					break;
				}
				break;
			}
			return name;
		}

		internal ControllerElementIdentifier ToControllerElementIdentifier()
		{
			return new ControllerElementIdentifier(_id, _name, _positiveName, _negativeName, jHLGlrXjGMMIuxAEONcGlnwHltw.dESgFzzjUASSsXqyQnTPkfkTyAG(_elementType), CompoundControllerElementType.Axis2D, isMappableOnPlatform);
		}
	}
}
