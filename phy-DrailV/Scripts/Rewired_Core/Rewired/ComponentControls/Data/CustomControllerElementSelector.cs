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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The target Custom Controller element type.")]
		private ElementType _elementType;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The method to use to look up the target Custom Controller element.")]
		private SelectorType _selectorType = SelectorType.Id;

		[SerializeField]
		[Tooltip("The target Custom Controller element name.")]
		[CustomObfuscation(rename = false)]
		private string _elementName;

		[SerializeField]
		[Tooltip("The target Custom Controller element index.")]
		[CustomObfuscation(rename = false)]
		[FieldRange(-1, int.MaxValue)]
		private int _elementIndex;

		[Tooltip("The target Custom Controller element id.")]
		[FieldRange(-1, int.MaxValue)]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _elementId = -1;

		[HideInInspector]
		private int TaewktJcJypDNPLNjhRMsmziPApE = -1;

		[HideInInspector]
		private int FDrHUZscCPsKlrltthkTzIzedVee = -1;

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
			if (TaewktJcJypDNPLNjhRMsmziPApE >= 0 && TaewktJcJypDNPLNjhRMsmziPApE != customController.id)
			{
				ClearCache();
			}
			if (FDrHUZscCPsKlrltthkTzIzedVee >= 0)
			{
				return FDrHUZscCPsKlrltthkTzIzedVee;
			}
			TaewktJcJypDNPLNjhRMsmziPApE = customController.id;
			switch (_selectorType)
			{
			case SelectorType.Id:
			{
				IList<ControllerElementIdentifier> list = OEeuCLsJvmAOMsVvZSeOTfrgKDMF(customController, _elementType);
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].id == _elementId)
					{
						FDrHUZscCPsKlrltthkTzIzedVee = j;
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
				IList<ControllerElementIdentifier> list = OEeuCLsJvmAOMsVvZSeOTfrgKDMF(customController, _elementType);
				if (_elementIndex >= list.Count)
				{
					return -1;
				}
				FDrHUZscCPsKlrltthkTzIzedVee = _elementIndex;
				break;
			}
			case SelectorType.Name:
			{
				if (_elementName == null)
				{
					return -1;
				}
				IList<ControllerElementIdentifier> list = OEeuCLsJvmAOMsVvZSeOTfrgKDMF(customController, _elementType);
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].name.Equals(_elementName))
					{
						FDrHUZscCPsKlrltthkTzIzedVee = i;
						break;
					}
				}
				break;
			}
			default:
				throw new NotImplementedException();
			}
			return FDrHUZscCPsKlrltthkTzIzedVee;
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

		private IList<ControllerElementIdentifier> OEeuCLsJvmAOMsVvZSeOTfrgKDMF(Rewired.CustomController P_0, ElementType P_1)
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
			TaewktJcJypDNPLNjhRMsmziPApE = -1;
			FDrHUZscCPsKlrltthkTzIzedVee = -1;
		}
	}
}
