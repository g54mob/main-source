using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Data
{
	[Serializable]
	[Preserve]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
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

		[SerializeField]
		[Serialize]
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
			_rules = new List<ControllerMapEnabler_Rule_Editor>();
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
				int num = -1795414332;
				while (true)
				{
					switch (num ^ -1795414336)
					{
					case 0:
						break;
					case 2:
					{
						int num3;
						if (num2 >= _rules.Count)
						{
							num = -1795414333;
							num3 = num;
						}
						else
						{
							num = -1795414331;
							num3 = num;
						}
						continue;
					}
					case 5:
						if (_rules[num2] != null)
						{
							list.Add(_rules[num2].ToRuntime());
							num = -1795414335;
							continue;
						}
						goto case 1;
					case 1:
						num2++;
						num = -1795414334;
						continue;
					case 4:
						if (_rules != null)
						{
							num2 = 0;
							num = -1795414334;
							continue;
						}
						goto default;
					default:
						return new ControllerMapEnabler.RuleSet(true, _tag, list);
					}
					break;
				}
			}
		}
	}
}
