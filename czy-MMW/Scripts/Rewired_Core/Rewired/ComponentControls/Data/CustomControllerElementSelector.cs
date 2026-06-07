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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The target Custom Controller element type.")]
		private ElementType _elementType;

		[Tooltip("The method to use to look up the target Custom Controller element.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private SelectorType _selectorType = SelectorType.Id;

		[SerializeField]
		[Tooltip("The target Custom Controller element name.")]
		[CustomObfuscation(rename = false)]
		private string _elementName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(-1, int.MaxValue)]
		[Tooltip("The target Custom Controller element index.")]
		private int _elementIndex;

		[FieldRange(-1, int.MaxValue)]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The target Custom Controller element id.")]
		private int _elementId = -1;

		[HideInInspector]
		private int zbChhJGIMONihVXVJiKVUcZbTTXmA = -1;

		[HideInInspector]
		private int ZlooEMFfohYrThUuDRznGQslTsPh = -1;

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
				if (!(_elementName == value))
				{
					_elementName = value;
					ClearCache();
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
				if (_elementId != value)
				{
					_elementId = value;
					ClearCache();
				}
			}
		}

		public bool isAssigned => selectorType switch
		{
			SelectorType.Id => _elementId >= 0, 
			SelectorType.Index => _elementIndex >= 0, 
			SelectorType.Name => !string.IsNullOrEmpty(_elementName), 
			_ => throw new NotImplementedException(), 
		};

		public int GetElementIndex(Rewired.CustomController customController)
		{
			if (customController == null)
			{
				return -1;
			}
			if (zbChhJGIMONihVXVJiKVUcZbTTXmA >= 0 && zbChhJGIMONihVXVJiKVUcZbTTXmA != customController.id)
			{
				ClearCache();
			}
			if (ZlooEMFfohYrThUuDRznGQslTsPh >= 0)
			{
				return ZlooEMFfohYrThUuDRznGQslTsPh;
			}
			zbChhJGIMONihVXVJiKVUcZbTTXmA = customController.id;
			switch (_selectorType)
			{
			case SelectorType.Id:
			{
				IList<ControllerElementIdentifier> list = FkUlBcwxkXnLHZnJEQABlAokNiph(customController, _elementType);
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid == _elementId)
					{
						ZlooEMFfohYrThUuDRznGQslTsPh = j;
						break;
					}
				}
				break;
			}
			case SelectorType.Index:
			{
				if (_elementIndex < 0)
				{
					return -1;
				}
				IList<ControllerElementIdentifier> list = FkUlBcwxkXnLHZnJEQABlAokNiph(customController, _elementType);
				if (_elementIndex >= list.Count)
				{
					return -1;
				}
				ZlooEMFfohYrThUuDRznGQslTsPh = _elementIndex;
				break;
			}
			case SelectorType.Name:
			{
				if (_elementName == null)
				{
					return -1;
				}
				IList<ControllerElementIdentifier> list = FkUlBcwxkXnLHZnJEQABlAokNiph(customController, _elementType);
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename.Equals(_elementName))
					{
						ZlooEMFfohYrThUuDRznGQslTsPh = i;
						break;
					}
				}
				break;
			}
			default:
				throw new NotImplementedException();
			}
			return ZlooEMFfohYrThUuDRznGQslTsPh;
		}

		public string GetSelectorFormattedString()
		{
			return selectorType switch
			{
				SelectorType.Id => "Id: " + _elementId, 
				SelectorType.Index => "Index: " + _elementIndex, 
				SelectorType.Name => "Name: " + _elementName, 
				_ => throw new NotImplementedException(), 
			};
		}

		private IList<ControllerElementIdentifier> FkUlBcwxkXnLHZnJEQABlAokNiph(Rewired.CustomController P_0, ElementType P_1)
		{
			return P_1 switch
			{
				ElementType.Axis => P_0.AxisElementIdentifiers, 
				ElementType.Button => P_0.ButtonElementIdentifiers, 
				_ => throw new NotImplementedException(), 
			};
		}

		public void ClearCache()
		{
			zbChhJGIMONihVXVJiKVUcZbTTXmA = -1;
			ZlooEMFfohYrThUuDRznGQslTsPh = -1;
		}
	}
}
