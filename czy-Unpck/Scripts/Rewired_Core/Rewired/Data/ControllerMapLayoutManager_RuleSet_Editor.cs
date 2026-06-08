using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[Preserve]
	public sealed class ControllerMapLayoutManager_RuleSet_Editor
	{
		[Serialize]
		[SerializeField]
		private int _id;

		[Serialize]
		[SerializeField]
		private string _name;

		[SerializeField]
		[Serialize]
		private string _tag;

		[SerializeField]
		[Serialize]
		private List<ControllerMapLayoutManager_Rule_Editor> _rules;

		public int id
		{
			get
			{
				return _id;
			}
			set
			{
				_id = value;
			}
		}

		public string name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

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

		public List<ControllerMapLayoutManager_Rule_Editor> rules
		{
			get
			{
				return _rules;
			}
			set
			{
				_rules = value;
			}
		}

		public ControllerMapLayoutManager_RuleSet_Editor()
		{
			_rules = new List<ControllerMapLayoutManager_Rule_Editor>();
		}

		public ControllerMapLayoutManager_RuleSet_Editor(ControllerMapLayoutManager_RuleSet_Editor source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			_id = source._id;
			_name = source._name;
			_tag = source._tag;
			_rules = MiscTools.DeepClone(source._rules);
		}

		internal ControllerMapLayoutManager_RuleSet_Editor Clone()
		{
			return new ControllerMapLayoutManager_RuleSet_Editor(this);
		}

		internal ControllerMapLayoutManager.RuleSet ToRuntime()
		{
			List<ControllerMapLayoutManager.Rule> list = new List<ControllerMapLayoutManager.Rule>();
			int num2 = default(int);
			while (true)
			{
				int num = 1597786085;
				while (true)
				{
					switch (num ^ 0x5F3C47E1)
					{
					case 0:
						break;
					case 2:
					{
						int num3;
						if (num2 < _rules.Count)
						{
							num = 1597786082;
							num3 = num;
						}
						else
						{
							num = 1597786080;
							num3 = num;
						}
						continue;
					}
					case 3:
						if (_rules[num2] != null)
						{
							list.Add(_rules[num2].ToRuntime());
							num = 1597786084;
							continue;
						}
						goto case 5;
					case 4:
						if (_rules != null)
						{
							num2 = 0;
							num = 1597786083;
							continue;
						}
						goto default;
					case 5:
						num2++;
						num = 1597786083;
						continue;
					default:
						return new ControllerMapLayoutManager.RuleSet(enabled: true, _tag, list);
					}
					break;
				}
			}
		}
	}
}
