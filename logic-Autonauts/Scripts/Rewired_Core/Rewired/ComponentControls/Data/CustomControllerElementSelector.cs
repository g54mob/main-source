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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The method to use to look up the target Custom Controller element.")]
		private SelectorType _selectorType = SelectorType.Id;

		[SerializeField]
		[Tooltip("The target Custom Controller element name.")]
		[CustomObfuscation(rename = false)]
		private string _elementName;

		[FieldRange(-1, int.MaxValue)]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The target Custom Controller element index.")]
		private int _elementIndex;

		[SerializeField]
		[FieldRange(-1, int.MaxValue)]
		[CustomObfuscation(rename = false)]
		[Tooltip("The target Custom Controller element id.")]
		private int _elementId = -1;

		[HideInInspector]
		private int nwzlOUfHIvFVlBYOUvCjPvSCXdfc = -1;

		[HideInInspector]
		private int fyigxiKzQSRMTeroEqMwmZiMGPg = -1;

		public ElementType elementType
		{
			get
			{
				return _elementType;
			}
			set
			{
				if (_elementType != value)
				{
					_elementType = value;
					ClearCache();
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
						switch (0xCC6C4A0 ^ 0xCC6C4A1)
						{
						case 0:
							continue;
						case 1:
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
				int num = 229224052;
				goto IL_0013;
				IL_0013:
				switch (num ^ 0xDA9AE77)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					return;
				case 1:
					goto IL_0038;
				case 2:
					return;
				}
				goto IL_000e;
				IL_0038:
				_elementName = value;
				ClearCache();
				num = 229224053;
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
					ClearCache();
					int num = 567306865;
					while (true)
					{
						switch (num ^ 0x21D06A70)
						{
						case 0:
							goto IL_000a;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_000a:
						num = 567306866;
					}
				}
			}
		}

		public bool isAssigned
		{
			get
			{
				SelectorType selectorType = this.selectorType;
				while (true)
				{
					int num = -1346731771;
					while (true)
					{
						switch (num ^ -1346731770)
						{
						case 0:
							break;
						case 3:
							switch (selectorType)
							{
							default:
								goto IL_003b;
							case SelectorType.Id:
								break;
							case SelectorType.Index:
								return _elementIndex >= 0;
							case SelectorType.Name:
								return !string.IsNullOrEmpty(_elementName);
							}
							goto default;
						default:
							return _elementId >= 0;
						case 1:
							throw new NotImplementedException();
						}
						break;
						IL_003b:
						num = -1346731769;
					}
				}
			}
		}

		public int GetElementIndex(Rewired.CustomController customController)
		{
			if (customController == null)
			{
				return -1;
			}
			if (nwzlOUfHIvFVlBYOUvCjPvSCXdfc >= 0 && nwzlOUfHIvFVlBYOUvCjPvSCXdfc != customController.id)
			{
				goto IL_0022;
			}
			goto IL_00d4;
			IL_0095:
			if (_elementName == null)
			{
				return -1;
			}
			IList<ControllerElementIdentifier> list = czrjCcMpPdRgwhqMeQlpCOZAByQ(customController, _elementType);
			int num = 1565917014;
			goto IL_0027;
			IL_01b6:
			if (_elementIndex < 0)
			{
				return -1;
			}
			list = czrjCcMpPdRgwhqMeQlpCOZAByQ(customController, _elementType);
			if (_elementIndex >= list.Count)
			{
				return -1;
			}
			fyigxiKzQSRMTeroEqMwmZiMGPg = _elementIndex;
			num = 1565917022;
			goto IL_0027;
			IL_0022:
			num = 1565917019;
			goto IL_0027;
			IL_0027:
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x5D55FF58)
				{
				case 7:
					break;
				case 2:
					num2++;
					num = 1565917001;
					continue;
				case 8:
					num = 1565917022;
					continue;
				case 10:
					goto IL_0095;
				case 17:
					goto IL_00b7;
				case 1:
					goto IL_00d4;
				case 12:
					goto IL_0113;
				case 18:
					num3++;
					num = 1565917012;
					continue;
				case 0:
					num = 1565917012;
					continue;
				case 5:
					if (list[num3].id == _elementId)
					{
						fyigxiKzQSRMTeroEqMwmZiMGPg = num3;
						num = 1565917011;
						continue;
					}
					goto case 18;
				case 16:
					if (list[num2].name.Equals(_elementName))
					{
						fyigxiKzQSRMTeroEqMwmZiMGPg = num2;
						num = 1565917022;
						continue;
					}
					goto case 2;
				case 3:
					ClearCache();
					num = 1565917017;
					continue;
				case 14:
					num2 = 0;
					num = 1565917001;
					continue;
				case 9:
					goto IL_01b6;
				case 13:
					goto IL_01f5;
				case 4:
					num = 1565917022;
					continue;
				case 11:
					num = 1565917022;
					continue;
				case 15:
					throw new NotImplementedException();
				default:
					return fyigxiKzQSRMTeroEqMwmZiMGPg;
				}
				break;
				IL_0113:
				int num4;
				if (num3 < list.Count)
				{
					num = 1565917021;
					num4 = num;
				}
				else
				{
					num = 1565917020;
					num4 = num;
				}
				continue;
				IL_00b7:
				int num5;
				if (num2 < list.Count)
				{
					num = 1565917000;
					num5 = num;
				}
				else
				{
					num = 1565917008;
					num5 = num;
				}
			}
			goto IL_0022;
			IL_0109:
			num = 1565917015;
			goto IL_0027;
			IL_00d4:
			if (fyigxiKzQSRMTeroEqMwmZiMGPg >= 0)
			{
				return fyigxiKzQSRMTeroEqMwmZiMGPg;
			}
			nwzlOUfHIvFVlBYOUvCjPvSCXdfc = customController.id;
			switch (_selectorType)
			{
			case SelectorType.Name:
				break;
			default:
				goto IL_0109;
			case SelectorType.Index:
				goto IL_01b6;
			case SelectorType.Id:
				goto IL_01f5;
			}
			goto IL_0095;
			IL_01f5:
			list = czrjCcMpPdRgwhqMeQlpCOZAByQ(customController, _elementType);
			num3 = 0;
			num = 1565917016;
			goto IL_0027;
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

		private IList<ControllerElementIdentifier> czrjCcMpPdRgwhqMeQlpCOZAByQ(Rewired.CustomController P_0, ElementType P_1)
		{
			switch (P_1)
			{
			default:
				while (true)
				{
					switch (-159231534 ^ -159231536)
					{
					case 0:
						continue;
					case 2:
						throw new NotImplementedException();
					}
					break;
				}
				goto case ElementType.Axis;
			case ElementType.Axis:
				return P_0.AxisElementIdentifiers;
			case ElementType.Button:
				return P_0.ButtonElementIdentifiers;
			}
		}

		public void ClearCache()
		{
			nwzlOUfHIvFVlBYOUvCjPvSCXdfc = -1;
			fyigxiKzQSRMTeroEqMwmZiMGPg = -1;
		}
	}
}
