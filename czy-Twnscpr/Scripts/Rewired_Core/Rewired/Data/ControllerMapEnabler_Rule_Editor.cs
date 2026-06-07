using System;
using System.Collections.Generic;
using Rewired.Utils.Attributes;
using Rewired.Utils.Interfaces;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Data
{
	[Serializable]
	[Preserve]
	[CustomClassObfuscation]
	public sealed class ControllerMapEnabler_Rule_Editor : IDeepCloneable
	{
		[SerializeField]
		[Serialize]
		private string _tag;

		[Serialize]
		[SerializeField]
		private bool _enable;

		[Serialize]
		[SerializeField]
		private List<int> _categoryIds;

		[Serialize]
		[SerializeField]
		private List<int> _layoutIds;

		[SerializeField]
		[Serialize]
		private ControllerSetSelector_Editor _controllerSetSelector;

		public string tag
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool enable
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public List<int> categoryIds
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public List<int> layoutIds
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ControllerSetSelector_Editor controllerSetSelector
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ControllerMapEnabler_Rule_Editor()
		{
		}

		public ControllerMapEnabler_Rule_Editor(ControllerMapEnabler_Rule_Editor source)
		{
		}

		internal ControllerMapEnabler.Rule ToRuntime()
		{
			return null;
		}

		object IDeepCloneable.DeepClone()
		{
			return null;
		}
	}
}
