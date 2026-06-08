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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _positiveName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _negativeName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ControllerTemplateElementType _elementType;

		internal readonly bool isMappableOnPlatform;

		public int id => _id;

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

		public ControllerTemplateElementType elementType => _elementType;

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
			while (true)
			{
				int num = -371947416;
				while (true)
				{
					switch (num ^ -371947415)
					{
					case 0:
						break;
					case 1:
						goto IL_0024;
					default:
						_name = name;
						_positiveName = positiveName;
						_negativeName = negativeName;
						_elementType = elementType;
						this.isMappableOnPlatform = isMappableOnPlatform;
						return;
					}
					break;
					IL_0024:
					_id = id;
					num = -371947413;
				}
			}
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
			int num;
			switch (_elementType)
			{
			default:
				num = -535486394;
				goto IL_001a;
			case ControllerTemplateElementType.Axis:
				goto IL_00b6;
			case ControllerTemplateElementType.Button:
				break;
				IL_001a:
				switch (num ^ -535486393)
				{
				case 5:
					break;
				case 4:
					goto IL_004e;
				case 3:
					return name + " +";
				case 2:
					goto IL_00b6;
				default:
					goto end_IL_0008;
				case 1:
					return name;
				}
				goto default;
				IL_00b6:
				switch (axisRange)
				{
				case AxisRange.Full:
					break;
				case AxisRange.Positive:
					goto IL_0055;
				case AxisRange.Negative:
					goto IL_0081;
				default:
					throw new NotImplementedException();
				}
				goto IL_004e;
				IL_0081:
				if (string.IsNullOrEmpty(negativeName))
				{
					return name + " -";
				}
				return negativeName;
				IL_0055:
				if (string.IsNullOrEmpty(positiveName))
				{
					num = -535486396;
					goto IL_001a;
				}
				return positiveName;
				IL_004e:
				return name;
				end_IL_0008:
				break;
			}
			return name;
		}

		internal ControllerElementIdentifier ToControllerElementIdentifier()
		{
			return new ControllerElementIdentifier(_id, _name, _positiveName, _negativeName, zRJHFfVYpYamSokTjXZVUKlCnAG.bfOOOfvhbAfeUGROtAICBZCUJgir(_elementType), CompoundControllerElementType.Axis2D, isMappableOnPlatform);
		}
	}
}
