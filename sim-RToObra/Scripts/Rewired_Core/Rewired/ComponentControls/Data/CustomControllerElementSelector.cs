using System;
using System.Collections.Generic;
using Rewired.Utils.Attributes;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public sealed class CustomControllerElementSelector
	{
		[CustomObfuscation(rename = false)]
		public enum ElementType
		{
			Axis = 0,
			Button = 1
		}

		[CustomObfuscation(rename = false)]
		public enum SelectorType
		{
			Name = 0,
			Index = 1,
			Id = 2
		}

		[Tooltip("The target Custom Controller element type.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ElementType _elementType;

		[Tooltip("The method to use to look up the target Custom Controller element.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private SelectorType _selectorType = SelectorType.Id;

		[SerializeField]
		[Tooltip("The target Custom Controller element name.")]
		[CustomObfuscation(rename = false)]
		private string _elementName;

		[FieldRange(-1, int.MaxValue)]
		[Tooltip("The target Custom Controller element index.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _elementIndex;

		[SerializeField]
		[Tooltip("The target Custom Controller element id.")]
		[CustomObfuscation(rename = false)]
		[FieldRange(-1, int.MaxValue)]
		private int _elementId = -1;

		[HideInInspector]
		private int WhtgVNHjOtdqEbyRkoIvbSSWheqT = -1;

		[HideInInspector]
		private int WlyPqvmSKKSpkCanggOqCXcYbUtk = -1;

		public ElementType elementType
		{
			get
			{
				return _elementType;
			}
			set
			{
				if (_elementType == value)
				{
					return;
				}
				while (true)
				{
					_elementType = value;
					int num = 504632887;
					while (true)
					{
						switch (num ^ 0x1E141637)
						{
						case 2:
							goto IL_000a;
						case 1:
							break;
						default:
							ClearCache();
							return;
						}
						break;
						IL_000a:
						num = 504632886;
					}
				}
			}
		}

		public SelectorType selectorType
		{
			get
			{
				return _selectorType;
			}
			set
			{
				if (_selectorType == value)
				{
					while (true)
					{
						switch (-1780094481 ^ -1780094483)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				_selectorType = value;
				ClearCache();
			}
		}

		public string elementName
		{
			get
			{
				return _elementName;
			}
			set
			{
				if (_elementName == value)
				{
					goto IL_000e;
				}
				goto IL_0038;
				IL_000e:
				int num = -35878161;
				goto IL_0013;
				IL_0013:
				switch (num ^ -35878162)
				{
				case 2:
					break;
				case 1:
					return;
				case 0:
					goto IL_0038;
				default:
					ClearCache();
					return;
				}
				goto IL_000e;
				IL_0038:
				_elementName = value;
				num = -35878163;
				goto IL_0013;
			}
		}

		public int elementIndex
		{
			get
			{
				return _elementIndex;
			}
			set
			{
				if (_elementIndex == value)
				{
					return;
				}
				while (true)
				{
					_elementIndex = value;
					ClearCache();
					int num = 937037101;
					while (true)
					{
						switch (num ^ 0x37DA0D2F)
						{
						case 0:
							goto IL_000a;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_000a:
						num = 937037102;
					}
				}
			}
		}

		public int elementId
		{
			get
			{
				return _elementId;
			}
			set
			{
				if (_elementId == value)
				{
					goto IL_0009;
				}
				goto IL_0033;
				IL_0009:
				int num = -417265705;
				goto IL_000e;
				IL_000e:
				switch (num ^ -417265708)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					return;
				case 1:
					goto IL_0033;
				case 2:
					return;
				}
				goto IL_0009;
				IL_0033:
				_elementId = value;
				ClearCache();
				num = -417265706;
				goto IL_000e;
			}
		}

		public bool isAssigned
		{
			get
			{
				switch (selectorType)
				{
				case SelectorType.Id:
					return _elementId >= 0;
				case SelectorType.Index:
					return _elementIndex >= 0;
				case SelectorType.Name:
					return !string.IsNullOrEmpty(_elementName);
				default:
					throw new NotImplementedException();
				}
			}
		}

		public int GetElementIndex(Rewired.CustomController customController)
		{
			if (customController == null)
			{
				return -1;
			}
			if (WhtgVNHjOtdqEbyRkoIvbSSWheqT >= 0)
			{
				goto IL_0011;
			}
			goto IL_016b;
			IL_016b:
			if (WlyPqvmSKKSpkCanggOqCXcYbUtk >= 0)
			{
				return WlyPqvmSKKSpkCanggOqCXcYbUtk;
			}
			WhtgVNHjOtdqEbyRkoIvbSSWheqT = customController.id;
			int num = 1120201722;
			goto IL_0016;
			IL_0011:
			num = 1120201724;
			goto IL_0016;
			IL_0016:
			IList<ControllerElementIdentifier> list = default(IList<ControllerElementIdentifier>);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x42C4EBFA)
				{
				case 8:
					break;
				case 11:
					num = 1120201704;
					continue;
				case 15:
					goto IL_0079;
				case 13:
					if (list[num2].id == _elementId)
					{
						WlyPqvmSKKSpkCanggOqCXcYbUtk = num2;
						num = 1120201707;
						continue;
					}
					goto case 1;
				case 0:
					switch (_selectorType)
					{
					case SelectorType.Id:
						goto IL_00de;
					case SelectorType.Index:
						goto IL_013e;
					case SelectorType.Name:
						goto IL_0205;
					}
					num = 1120201727;
					continue;
				case 3:
					goto IL_00de;
				case 16:
					if (num3 >= list.Count)
					{
						num = 1120201704;
						continue;
					}
					goto case 7;
				case 17:
					num = 1120201704;
					continue;
				case 2:
					goto IL_0118;
				case 10:
					goto IL_013e;
				case 14:
					num = 1120201704;
					continue;
				case 9:
					goto IL_016b;
				case 4:
					num3++;
					num = 1120201706;
					continue;
				case 6:
					if (WhtgVNHjOtdqEbyRkoIvbSSWheqT != customController.id)
					{
						ClearCache();
						num = 1120201715;
						continue;
					}
					goto IL_016b;
				case 1:
					num2++;
					num = 1120201717;
					continue;
				case 7:
					if (list[num3].name.Equals(_elementName))
					{
						WlyPqvmSKKSpkCanggOqCXcYbUtk = num3;
						num = 1120201713;
						continue;
					}
					goto case 4;
				case 5:
					throw new NotImplementedException();
				case 12:
					goto IL_0205;
				default:
					{
						return WlyPqvmSKKSpkCanggOqCXcYbUtk;
					}
					IL_00de:
					list = TDbQJhgSJbtFTTCZMuhhvoRYbpL(customController, _elementType);
					num2 = 0;
					num = 1120201717;
					continue;
				}
				break;
				IL_0118:
				if (_elementIndex >= list.Count)
				{
					return -1;
				}
				WlyPqvmSKKSpkCanggOqCXcYbUtk = _elementIndex;
				num = 1120201704;
				continue;
				IL_013e:
				if (_elementIndex < 0)
				{
					return -1;
				}
				list = TDbQJhgSJbtFTTCZMuhhvoRYbpL(customController, _elementType);
				num = 1120201720;
				continue;
				IL_0079:
				int num4;
				if (num2 >= list.Count)
				{
					num = 1120201716;
					num4 = num;
				}
				else
				{
					num = 1120201719;
					num4 = num;
				}
				continue;
				IL_0205:
				if (_elementName == null)
				{
					return -1;
				}
				list = TDbQJhgSJbtFTTCZMuhhvoRYbpL(customController, _elementType);
				num3 = 0;
				num = 1120201706;
			}
			goto IL_0011;
		}

		public string GetSelectorFormattedString()
		{
			switch (selectorType)
			{
			case SelectorType.Id:
				return "Id: " + _elementId;
			case SelectorType.Index:
				return "Index: " + _elementIndex;
			case SelectorType.Name:
				return "Name: " + _elementName;
			default:
				throw new NotImplementedException();
			}
		}

		private IList<ControllerElementIdentifier> TDbQJhgSJbtFTTCZMuhhvoRYbpL(Rewired.CustomController P_0, ElementType P_1)
		{
			switch (P_1)
			{
			case ElementType.Axis:
				return P_0.AxisElementIdentifiers;
			case ElementType.Button:
				return P_0.ButtonElementIdentifiers;
			default:
				throw new NotImplementedException();
			}
		}

		public void ClearCache()
		{
			WhtgVNHjOtdqEbyRkoIvbSSWheqT = -1;
			WlyPqvmSKKSpkCanggOqCXcYbUtk = -1;
		}
	}
}
