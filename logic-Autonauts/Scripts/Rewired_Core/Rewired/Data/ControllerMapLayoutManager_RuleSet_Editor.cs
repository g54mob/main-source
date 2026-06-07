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
	public sealed class ControllerMapLayoutManager_RuleSet_Editor
	{
		[Serialize]
		[SerializeField]
		private int _id;

		[SerializeField]
		[Serialize]
		private string _name;

		[Serialize]
		[SerializeField]
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
			while (true)
			{
				switch (0x1DA63C75 ^ 0x1DA63C77)
				{
				case 0:
					continue;
				case 2:
					if (source == null)
					{
						throw new ArgumentNullException("source");
					}
					break;
				}
				break;
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
			if (_rules != null)
			{
				int num = 0;
				while (true)
				{
					int num2 = -2002305642;
					while (true)
					{
						switch (num2 ^ -2002305645)
						{
						case 0:
							break;
						case 1:
							num++;
							num2 = -2002305641;
							continue;
						case 4:
							goto IL_0048;
						case 5:
							num2 = -2002305641;
							continue;
						case 3:
							if (_rules[num] != null)
							{
								list.Add(_rules[num].ToRuntime());
								num2 = -2002305646;
								continue;
							}
							goto case 1;
						default:
							goto end_IL_0013;
						}
						break;
						IL_0048:
						int num3;
						if (num < _rules.Count)
						{
							num2 = -2002305648;
							num3 = num2;
						}
						else
						{
							num2 = -2002305647;
							num3 = num2;
						}
					}
					continue;
					end_IL_0013:
					break;
				}
			}
			return new ControllerMapLayoutManager.RuleSet(true, _tag, list);
		}
	}
}
