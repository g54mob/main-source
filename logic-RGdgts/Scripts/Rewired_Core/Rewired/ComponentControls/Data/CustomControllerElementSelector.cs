using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	[Serializable]
	[CustomClassObfuscation]
	public sealed class CustomControllerElementSelector
	{
		[CustomObfuscation]
		public enum ElementType
		{
			Axis = 0,
			Button = 1
		}

		[CustomObfuscation]
		public enum SelectorType
		{
			Name = 0,
			Index = 1,
			Id = 2
		}

		[CustomObfuscation]
		[SerializeField]
		private ElementType _elementType;

		[CustomObfuscation]
		[SerializeField]
		private SelectorType _selectorType;

		[CustomObfuscation]
		[SerializeField]
		private string _elementName;

		[SerializeField]
		[CustomObfuscation]
		private int _elementIndex;

		[CustomObfuscation]
		[SerializeField]
		private int _elementId;

		[HideInInspector]
		private int ixaJxirPKsqWlcunKuFepLLtBDjt;

		[HideInInspector]
		private int uadoCSWdUFdTHaCNMYHnmmvfSpuhA;

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

		private IList<ControllerElementIdentifier> pocllWKIBagzoXZzgPmoCZWhGOUK(Rewired.CustomController P_0, ElementType P_1)
		{
			return null;
		}

		public void ClearCache()
		{
		}
	}
}
