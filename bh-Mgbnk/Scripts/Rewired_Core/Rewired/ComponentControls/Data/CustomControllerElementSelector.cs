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
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private SelectorType _selectorType;

		[Tooltip("The target Custom Controller element name.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _elementName;

		[Tooltip("The target Custom Controller element index.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(-1, 2147483647)]
		private int _elementIndex;

		[Tooltip("The target Custom Controller element id.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(-1, 2147483647)]
		private int _elementId;

		[HideInInspector]
		private int kXgWXmllNAXRyHpLQUEhiYAHraLe;

		[HideInInspector]
		private int CBAVFMcKTjXdnftWYTHqQcfDtjXo;

		public ElementType elementType
		{
			get
			{
				return default(ElementType);
			}
			set
			{
			}
		}

		public SelectorType selectorType
		{
			get
			{
				return default(SelectorType);
			}
			set
			{
			}
		}

		public string elementName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int elementIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int elementId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool isAssigned => false;

		public int GetElementIndex(Rewired.CustomController customController)
		{
			return 0;
		}

		public string GetSelectorFormattedString()
		{
			return null;
		}

		private IList<ControllerElementIdentifier> YcmjOsEVCRaWbnTPLuMOPnPAZrfKA(Rewired.CustomController P_0, ElementType P_1)
		{
			return null;
		}

		public void ClearCache()
		{
		}
	}
}
