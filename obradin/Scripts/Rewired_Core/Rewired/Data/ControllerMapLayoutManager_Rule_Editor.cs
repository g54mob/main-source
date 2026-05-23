using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Interfaces;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[Preserve]
	public sealed class ControllerMapLayoutManager_Rule_Editor : IDeepCloneable
	{
		[SerializeField]
		[Serialize]
		private string _tag;

		[Serialize]
		[SerializeField]
		private List<int> _categoryIds;

		[Serialize]
		[SerializeField]
		private int _layoutId;

		[Serialize]
		[SerializeField]
		private ControllerSetSelector_Editor _controllerSetSelector;

		public string tag
		{
			get
			{
				return _tag;
			}
			set
			{
				_tag = value;
			}
		}

		public List<int> categoryIds
		{
			get
			{
				return _categoryIds;
			}
			set
			{
				_categoryIds = value;
			}
		}

		public int layoutId
		{
			get
			{
				return _layoutId;
			}
			set
			{
				_layoutId = value;
			}
		}

		public ControllerSetSelector_Editor controllerSetSelector
		{
			get
			{
				return _controllerSetSelector;
			}
			set
			{
				_controllerSetSelector = value;
			}
		}

		public ControllerMapLayoutManager_Rule_Editor()
		{
			while (true)
			{
				int num = 1177320060;
				while (true)
				{
					switch (num ^ 0x462C7A7D)
					{
					case 0:
						break;
					case 1:
						goto IL_0024;
					default:
						_controllerSetSelector = new ControllerSetSelector_Editor(ControllerSetSelector.Type.ControllerType);
						return;
					}
					break;
					IL_0024:
					_categoryIds = new List<int>();
					_layoutId = -1;
					num = 1177320063;
				}
			}
		}

		public ControllerMapLayoutManager_Rule_Editor(ControllerMapLayoutManager_Rule_Editor source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			_tag = source._tag;
			_categoryIds = ListTools.ShallowCopy(source._categoryIds);
			_layoutId = source._layoutId;
			_controllerSetSelector = MiscTools.DeepClone(source._controllerSetSelector);
		}

		internal ControllerMapLayoutManager.Rule ToRuntime()
		{
			return new ControllerMapLayoutManager.Rule(_tag, (_categoryIds != null) ? _categoryIds.ToArray() : new int[0], _layoutId, _controllerSetSelector.fNKUAeEnaeBekawvLSEGNjPnlfR());
		}

		object IDeepCloneable.DeepClone()
		{
			return new ControllerMapLayoutManager_Rule_Editor(this);
		}
	}
}
