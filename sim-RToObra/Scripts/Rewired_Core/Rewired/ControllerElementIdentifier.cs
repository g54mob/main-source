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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _positiveName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _negativeName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerElementType _elementType;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CompoundControllerElementType _compoundElementType;

		internal readonly bool isMappableOnPlatform;

		private bool opqFCidZJywDAhKxeolcaVpqNEsC;

		private static ControllerElementIdentifier ikKKjpkzjdHJabGJHEcubgXrQyU;

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
				QblXkCsMfRtCRnWiBRNEJpaBQVM();
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
				QblXkCsMfRtCRnWiBRNEJpaBQVM();
				while (true)
				{
					int num = -858178463;
					while (true)
					{
						switch (num ^ -858178464)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0024;
						case 2:
							return;
						}
						break;
						IL_0024:
						_positiveName = value;
						num = -858178462;
					}
				}
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
				QblXkCsMfRtCRnWiBRNEJpaBQVM();
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
				if (ikKKjpkzjdHJabGJHEcubgXrQyU == null)
				{
					ControllerElementIdentifier controllerElementIdentifier = new ControllerElementIdentifier();
					controllerElementIdentifier._id = -1;
					controllerElementIdentifier.opqFCidZJywDAhKxeolcaVpqNEsC = true;
					return ikKKjpkzjdHJabGJHEcubgXrQyU = controllerElementIdentifier;
				}
				return ikKKjpkzjdHJabGJHEcubgXrQyU;
			}
		}

		public ControllerElementIdentifier()
		{
		}

		public ControllerElementIdentifier(ControllerElementIdentifier source)
		{
			while (true)
			{
				int num = -1479582756;
				while (true)
				{
					switch (num ^ -1479582755)
					{
					case 5:
						break;
					case 1:
						isMappableOnPlatform = source.isMappableOnPlatform;
						num = -1479582755;
						continue;
					case 0:
						_id = source._id;
						num = -1479582753;
						continue;
					case 3:
						_positiveName = source._positiveName;
						_negativeName = source._negativeName;
						num = -1479582759;
						continue;
					case 2:
						_name = source._name;
						num = -1479582754;
						continue;
					default:
						_elementType = source._elementType;
						_compoundElementType = source._compoundElementType;
						return;
					}
					break;
				}
			}
		}

		internal ControllerElementIdentifier(int id, string name, string positiveName, string negativeName, ControllerElementType elementType, CompoundControllerElementType compoundElementType, bool isMappableOnPlatform)
		{
			while (true)
			{
				int num = -972609662;
				while (true)
				{
					switch (num ^ -972609664)
					{
					case 0:
						break;
					default:
						return;
					case 4:
						this.isMappableOnPlatform = isMappableOnPlatform;
						num = -972609661;
						continue;
					case 1:
						_name = name;
						_positiveName = positiveName;
						num = -972609659;
						continue;
					case 5:
						_negativeName = negativeName;
						_elementType = elementType;
						_compoundElementType = compoundElementType;
						num = -972609660;
						continue;
					case 2:
						_id = id;
						num = -972609663;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
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
			switch (actualElementType)
			{
			case ControllerElementType.Axis:
				while (true)
				{
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
						goto IL_00b0;
					case AxisRange.Positive:
						{
							if (string.IsNullOrEmpty(positiveName))
							{
								int num = -758061891;
								while (true)
								{
									switch (num ^ -758061891)
									{
									case 3:
										num = -758061895;
										continue;
									case 4:
										break;
									case 0:
										return name + " +";
									case 1:
										goto IL_00b0;
									default:
										goto end_IL_0049;
									}
									break;
								}
								continue;
							}
							return positiveName;
						}
						IL_00b0:
						return name;
						end_IL_0049:
						break;
					}
					break;
				}
				goto case ControllerElementType.Button;
			case ControllerElementType.Button:
				return name;
			case ControllerElementType.CompoundElement:
				return name;
			default:
				throw new NotImplementedException();
			}
		}

		public string GetDisplayName(AxisRange axisRange)
		{
			return GetDisplayName(_elementType, axisRange);
		}

		private void QblXkCsMfRtCRnWiBRNEJpaBQVM()
		{
			if (opqFCidZJywDAhKxeolcaVpqNEsC)
			{
				throw new Exception("The object is marked readonly and you are trying to modify its values.");
			}
		}
	}
}
