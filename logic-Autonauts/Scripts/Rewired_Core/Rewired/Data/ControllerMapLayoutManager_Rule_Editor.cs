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
		[Serialize]
		[SerializeField]
		private string _tag;

		[Serialize]
		[SerializeField]
		private List<int> _categoryIds;

		[SerializeField]
		[Serialize]
		private int _layoutId;

		[SerializeField]
		[Serialize]
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
			_categoryIds = new List<int>();
			_layoutId = -1;
			_controllerSetSelector = new ControllerSetSelector_Editor(ControllerSetSelector.Type.ControllerType);
		}

		public ControllerMapLayoutManager_Rule_Editor(ControllerMapLayoutManager_Rule_Editor source)
		{
			while (true)
			{
				int num = 1447154543;
				while (true)
				{
					switch (num ^ 0x5641D36A)
					{
					case 0:
						break;
					default:
						return;
					case 5:
					{
						int num2;
						if (source != null)
						{
							num = 1447154536;
							num2 = num;
						}
						else
						{
							num = 1447154537;
							num2 = num;
						}
						continue;
					}
					case 3:
						throw new ArgumentNullException("source");
					case 2:
						_tag = source._tag;
						num = 1447154539;
						continue;
					case 1:
						_categoryIds = ListTools.ShallowCopy(source._categoryIds);
						_layoutId = source._layoutId;
						_controllerSetSelector = MiscTools.DeepClone(source._controllerSetSelector);
						num = 1447154542;
						continue;
					case 4:
						return;
					}
					break;
				}
			}
		}

		internal ControllerMapLayoutManager.Rule ToRuntime()
		{
			return new ControllerMapLayoutManager.Rule(_tag, (_categoryIds != null) ? _categoryIds.ToArray() : new int[0], _layoutId, _controllerSetSelector.UaSeBxgSckzTTOlibRIWoQHplqI());
		}

		object IDeepCloneable.DeepClone()
		{
			return new ControllerMapLayoutManager_Rule_Editor(this);
		}
	}
}
