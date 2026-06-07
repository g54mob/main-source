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
		[SerializeField]
		[Serialize]
		private int _id;

		[SerializeField]
		[Serialize]
		private string _name;

		[Serialize]
		[SerializeField]
		private string _tag;

		[Serialize]
		[SerializeField]
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
			int num3 = default(int);
			while (true)
			{
				int num = -582616623;
				while (true)
				{
					switch (num ^ -582616622)
					{
					case 2:
						break;
					case 5:
						if (_rules[num3] != null)
						{
							list.Add(_rules[num3].ToRuntime());
							num = -582616621;
							continue;
						}
						goto case 1;
					case 0:
						num3 = 0;
						num = -582616619;
						continue;
					case 1:
						num3++;
						num = -582616618;
						continue;
					case 7:
						num = -582616618;
						continue;
					case 4:
					{
						int num4;
						if (num3 >= _rules.Count)
						{
							num = -582616620;
							num4 = num;
						}
						else
						{
							num = -582616617;
							num4 = num;
						}
						continue;
					}
					case 3:
					{
						int num2;
						if (_rules == null)
						{
							num = -582616620;
							num2 = num;
						}
						else
						{
							num = -582616622;
							num2 = num;
						}
						continue;
					}
					default:
						return new ControllerMapLayoutManager.RuleSet(true, _tag, list);
					}
					break;
				}
			}
		}
	}
}
