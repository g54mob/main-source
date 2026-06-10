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
		[Tooltip("The target Custom Controller element type.")]
		[SerializeField]
		private ElementType _elementType;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The method to use to look up the target Custom Controller element.")]
		private SelectorType _selectorType;

		[SerializeField]
		[Tooltip("The target Custom Controller element name.")]
		[CustomObfuscation(rename = false)]
		private string _elementName;

		[Tooltip("The target Custom Controller element index.")]
		[FieldRange(-1, int.MaxValue)]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _elementIndex;

		[Tooltip("The target Custom Controller element id.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(-1, int.MaxValue)]
		private int _elementId;

		[HideInInspector]
		private int gLeEmdjwAWCAVDaZHIjhovwsugaN;

		[HideInInspector]
		private int qppzNBUoKhbTbQPdZvhsqDOwPUz;

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

		private IList<ControllerElementIdentifier> vCmYaPMBJIAzQcLJpsAzlAvyvbDM(Rewired.CustomController P_0, ElementType P_1)
		{
			return null;
		}

		public void ClearCache()
		{
		}
	}
}
