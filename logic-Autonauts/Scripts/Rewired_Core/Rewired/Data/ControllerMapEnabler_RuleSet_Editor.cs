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
		[SerializeField]
		[Serialize]
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
			int num3 = default(int);
			while (true)
			{
				int num = 526143329;
				while (true)
				{
					switch (num ^ 0x1F5C4F63)
					{
					case 0:
						break;
					case 3:
					{
						int num5;
						if (num3 < _rules.Count)
						{
							num = 526143332;
							num5 = num;
						}
						else
						{
							num = 526143334;
							num5 = num;
						}
						continue;
					}
					case 7:
					{
						int num4;
						if (_rules[num3] != null)
						{
							num = 526143335;
							num4 = num;
						}
						else
						{
							num = 526143333;
							num4 = num;
						}
						continue;
					}
					case 6:
						num3++;
						num = 526143328;
						continue;
					case 1:
						num3 = 0;
						num = 526143328;
						continue;
					case 4:
						list.Add(_rules[num3].ToRuntime());
						num = 526143333;
						continue;
					case 2:
					{
						int num2;
						if (_rules != null)
						{
							num = 526143330;
							num2 = num;
						}
						else
						{
							num = 526143334;
							num2 = num;
						}
						continue;
					}
					default:
						return new ControllerMapEnabler.RuleSet(true, _tag, list);
					}
					break;
				}
			}
		}
	}
}
