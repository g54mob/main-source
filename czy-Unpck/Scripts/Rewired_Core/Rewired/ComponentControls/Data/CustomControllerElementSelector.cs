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
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ElementType _elementType;

		[Tooltip("The method to use to look up the target Custom Controller element.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private SelectorType _selectorType = SelectorType.Id;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The target Custom Controller element name.")]
		private string _elementName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[FieldRange(-1, int.MaxValue)]
		[Tooltip("The target Custom Controller element index.")]
		private int _elementIndex;

		[CustomObfuscation(rename = false)]
		[Tooltip("The target Custom Controller element id.")]
		[SerializeField]
		[FieldRange(-1, int.MaxValue)]
		private int _elementId = -1;

		[HideInInspector]
		private int CslfLFTzhzEZipQvNhbuvrwVaOY = -1;

		[HideInInspector]
		private int UTuEktuLnATuGFlXTrcxeVGFSmL = -1;

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
					while (true)
					{
						switch (-434586736 ^ -434586734)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				_elementType = value;
				ClearCache();
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
				if (_selectorType != value)
				{
					_selectorType = value;
					ClearCache();
				}
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
					return;
				}
				while (true)
				{
					_elementName = value;
					ClearCache();
					int num = 1926412891;
					while (true)
					{
						switch (num ^ 0x72D2BA59)
						{
						case 0:
							goto IL_000f;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_000f:
						num = 1926412888;
					}
				}
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
				if (_elementIndex != value)
				{
					_elementIndex = value;
					ClearCache();
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
					return;
				}
				while (true)
				{
					_elementId = value;
					int num = 1067751982;
					while (true)
					{
						switch (num ^ 0x3FA49A2F)
						{
						case 0:
							num = 1067751980;
							continue;
						default:
							return;
						case 3:
							break;
						case 1:
							ClearCache();
							num = 1067751981;
							continue;
						case 2:
							return;
						}
						break;
					}
				}
			}
		}

		public bool isAssigned
		{
			get
			{
				switch (selectorType)
				{
				default:
					while (true)
					{
						switch (0x7ED9148B ^ 0x7ED9148A)
						{
						case 0:
							continue;
						case 1:
							throw new NotImplementedException();
						}
						break;
					}
					goto case SelectorType.Id;
				case SelectorType.Id:
					return _elementId >= 0;
				case SelectorType.Index:
					return _elementIndex >= 0;
				case SelectorType.Name:
					return !string.IsNullOrEmpty(_elementName);
				}
			}
		}

		public int GetElementIndex(Rewired.CustomController customController)
		{
			if (customController == null)
			{
				goto IL_0006;
			}
			int num;
			if (CslfLFTzhzEZipQvNhbuvrwVaOY >= 0 && CslfLFTzhzEZipQvNhbuvrwVaOY != customController.id)
			{
				ClearCache();
				num = -846574637;
				goto IL_000b;
			}
			goto IL_0088;
			IL_0006:
			num = -846574638;
			goto IL_000b;
			IL_000b:
			IList<ControllerElementIdentifier> list = default(IList<ControllerElementIdentifier>);
			int num3 = default(int);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -846574639)
				{
				case 10:
					break;
				case 15:
					return -1;
				case 2:
					goto IL_0088;
				case 16:
					throw new NotImplementedException();
				case 12:
					goto IL_00be;
				case 14:
					if (list[num3].name.Equals(_elementName))
					{
						UTuEktuLnATuGFlXTrcxeVGFSmL = num3;
						num = -846574656;
						continue;
					}
					goto case 9;
				case 21:
					if (list[num2].id == _elementId)
					{
						UTuEktuLnATuGFlXTrcxeVGFSmL = num2;
						num = -846574634;
						continue;
					}
					goto case 18;
				case 7:
					num = -846574630;
					continue;
				case 8:
					if (num3 >= list.Count)
					{
						num = -846574630;
						continue;
					}
					goto case 14;
				case 17:
					num = -846574630;
					continue;
				case 0:
					goto IL_014f;
				case 19:
					switch (_selectorType)
					{
					case SelectorType.Name:
						break;
					case SelectorType.Index:
						goto IL_014f;
					default:
						goto IL_019c;
					case SelectorType.Id:
						goto IL_01e9;
					}
					goto IL_00be;
				case 3:
					return -1;
				case 1:
					num = -846574651;
					continue;
				case 13:
					num = -846574630;
					continue;
				case 6:
					goto IL_01e9;
				case 20:
					if (num2 >= list.Count)
					{
						num = -846574630;
						continue;
					}
					goto case 21;
				case 5:
					return -1;
				case 4:
					num = -846574631;
					continue;
				case 18:
					num2++;
					num = -846574651;
					continue;
				case 9:
					num3++;
					num = -846574631;
					continue;
				default:
					{
						return UTuEktuLnATuGFlXTrcxeVGFSmL;
					}
					IL_01e9:
					list = BapxfzgFivEdhUKxnHGyYrrPSbr(customController, _elementType);
					num2 = 0;
					num = -846574640;
					continue;
					IL_019c:
					num = -846574655;
					continue;
				}
				break;
				IL_014f:
				if (_elementIndex < 0)
				{
					return -1;
				}
				list = BapxfzgFivEdhUKxnHGyYrrPSbr(customController, _elementType);
				if (_elementIndex < list.Count)
				{
					UTuEktuLnATuGFlXTrcxeVGFSmL = _elementIndex;
					num = -846574628;
				}
				else
				{
					num = -846574626;
				}
				continue;
				IL_00be:
				if (_elementName == null)
				{
					num = -846574636;
					continue;
				}
				list = BapxfzgFivEdhUKxnHGyYrrPSbr(customController, _elementType);
				num3 = 0;
				num = -846574635;
			}
			goto IL_0006;
			IL_0088:
			if (UTuEktuLnATuGFlXTrcxeVGFSmL >= 0)
			{
				return UTuEktuLnATuGFlXTrcxeVGFSmL;
			}
			CslfLFTzhzEZipQvNhbuvrwVaOY = customController.id;
			num = -846574654;
			goto IL_000b;
		}

		public string GetSelectorFormattedString()
		{
			switch (selectorType)
			{
			default:
				while (true)
				{
					switch (-1798582737 ^ -1798582739)
					{
					case 0:
						continue;
					case 2:
						throw new NotImplementedException();
					}
					break;
				}
				goto case SelectorType.Id;
			case SelectorType.Id:
				return "Id: " + _elementId;
			case SelectorType.Index:
				return "Index: " + _elementIndex;
			case SelectorType.Name:
				return "Name: " + _elementName;
			}
		}

		private IList<ControllerElementIdentifier> BapxfzgFivEdhUKxnHGyYrrPSbr(Rewired.CustomController P_0, ElementType P_1)
		{
			while (true)
			{
				switch (0x17E4E53B ^ 0x17E4E539)
				{
				case 0:
					continue;
				case 2:
					switch (P_1)
					{
					case ElementType.Axis:
						break;
					case ElementType.Button:
						return P_0.ButtonElementIdentifiers;
					default:
						throw new NotImplementedException();
					}
					break;
				}
				break;
			}
			return P_0.AxisElementIdentifiers;
		}

		public void ClearCache()
		{
			CslfLFTzhzEZipQvNhbuvrwVaOY = -1;
			UTuEktuLnATuGFlXTrcxeVGFSmL = -1;
		}
	}
}
