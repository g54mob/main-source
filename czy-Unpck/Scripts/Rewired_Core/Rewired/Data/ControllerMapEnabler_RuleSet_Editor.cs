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
	public sealed class ControllerMapEnabler_RuleSet_Editor
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

		[Serialize]
		[SerializeField]
		private List<ControllerMapEnabler_Rule_Editor> _rules;

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

		public List<ControllerMapEnabler_Rule_Editor> rules
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

		public ControllerMapEnabler_RuleSet_Editor()
		{
			while (true)
			{
				int num = -1486327158;
				while (true)
				{
					switch (num ^ -1486327160)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0024;
					case 1:
						return;
					}
					break;
					IL_0024:
					_rules = new List<ControllerMapEnabler_Rule_Editor>();
					num = -1486327159;
				}
			}
		}

		public ControllerMapEnabler_RuleSet_Editor(ControllerMapEnabler_RuleSet_Editor source)
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

		internal ControllerMapEnabler_RuleSet_Editor Clone()
		{
			return new ControllerMapEnabler_RuleSet_Editor(this);
		}

		internal ControllerMapEnabler.RuleSet ToRuntime()
		{
			List<ControllerMapEnabler.Rule> list = new List<ControllerMapEnabler.Rule>();
			int num2 = default(int);
			while (true)
			{
				int num = -847849084;
				while (true)
				{
					switch (num ^ -847849082)
					{
					case 6:
						break;
					case 2:
						if (_rules != null)
						{
							num2 = 0;
							num = -847849081;
							continue;
						}
						goto default;
					case 0:
						num2++;
						num = -847849081;
						continue;
					case 1:
					{
						int num4;
						if (num2 >= _rules.Count)
						{
							num = -847849086;
							num4 = num;
						}
						else
						{
							num = -847849083;
							num4 = num;
						}
						continue;
					}
					case 3:
					{
						int num3;
						if (_rules[num2] == null)
						{
							num = -847849082;
							num3 = num;
						}
						else
						{
							num = -847849085;
							num3 = num;
						}
						continue;
					}
					case 5:
						list.Add(_rules[num2].ToRuntime());
						num = -847849082;
						continue;
					default:
						return new ControllerMapEnabler.RuleSet(enabled: true, _tag, list);
					}
					break;
				}
			}
		}
	}
}
