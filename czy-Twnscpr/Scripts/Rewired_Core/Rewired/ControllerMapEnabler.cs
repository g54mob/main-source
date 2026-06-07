using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Interfaces;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired
{
	public sealed class ControllerMapEnabler
	{
		[Serializable]
		[Preserve]
		[CustomClassObfuscation]
		public sealed class Rule : IDeepCloneable
		{
			[Serialize]
			[SerializeField]
			private string _tag;

			[Serialize]
			[SerializeField]
			private bool _enable;

			[Serialize]
			[SerializeField]
			private int[] _categoryIds;

			[SerializeField]
			[Serialize]
			private int[] _layoutIds;

			[Serialize]
			[SerializeField]
			private ControllerSetSelector _controllerSetSelector;

			[NonSerialized]
			private string[] _preInitCategoryNames;

			[NonSerialized]
			private string[] _preInitLayoutNames;

			internal bool appliesToAllLayouts => false;

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

			public ControllerSetSelector controllerSetSelector
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public int[] categoryIds
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public int[] layoutIds
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public int categoryId
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public int layoutId
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public string[] categoryNames
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public string[] layoutNames
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public string categoryName
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public string layoutName
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			internal bool isValid => false;

			public Rule()
			{
			}

			public Rule(Rule source)
			{
			}

			internal Rule(string tag, bool enabled, int[] categoryIds, int[] layoutIds, ControllerSetSelector controllerSetSelector)
			{
			}

			internal bool Matches(ControllerMap map)
			{
				return false;
			}

			private void Initialize()
			{
			}

			private void CheckNoControllerTypeError()
			{
			}

			object IDeepCloneable.DeepClone()
			{
				return null;
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		[Preserve]
		public sealed class RuleSet : IDeepCloneable, IEnumerable, IList<Rule>, ICollection<Rule>, IEnumerable<Rule>
		{
			private const string className = "ControllerMapEnabler.RuleSet";

			[Serialize]
			[SerializeField]
			private bool _enabled;

			[Serialize]
			[SerializeField]
			private string _tag;

			[Serialize]
			[SerializeField]
			private List<Rule> _rules;

			public bool enabled
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

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

			public List<Rule> rules
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public Rule Item
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public int Count => 0;

			bool ICollection<Rule>.IsReadOnly => false;

			internal RuleSet(bool enabled, string tag, List<Rule> rules)
			{
			}

			public RuleSet()
			{
			}

			public RuleSet(RuleSet source)
			{
			}

			public Rule Find(Predicate<Rule> predicate)
			{
				return null;
			}

			public Rule FindLast(Predicate<Rule> predicate)
			{
				return null;
			}

			public int FindIndex(Predicate<Rule> predicate)
			{
				return 0;
			}

			public int FindLastIndex(Predicate<Rule> predicate)
			{
				return 0;
			}

			public int IndexOf(Rule item)
			{
				return 0;
			}

			public void Insert(int index, Rule item)
			{
			}

			public void RemoveAt(int index)
			{
			}

			public void Add(Rule item)
			{
			}

			public void Clear()
			{
			}

			public bool Contains(Rule item)
			{
				return false;
			}

			public void CopyTo(Rule[] array, int arrayIndex)
			{
			}

			public bool Remove(Rule item)
			{
				return false;
			}

			public IEnumerator<Rule> GetEnumerator()
			{
				return null;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}

			object IDeepCloneable.DeepClone()
			{
				return null;
			}

			private void CheckList()
			{
			}
		}

		internal class qIjMFrOnBtzCkPNWSvzPUfZdmEE
		{
			public bool wlPaxAMhtAxmIQWhcqhKHVpqLOI;

			public xwlhFTsQYtjrmxDuPWBtZARKTuD[] yZVKDYDIYhQVfxAePEUFwTcofahB;

			public qIjMFrOnBtzCkPNWSvzPUfZdmEE(bool enabled, xwlhFTsQYtjrmxDuPWBtZARKTuD[] startingRuleSets)
			{
			}
		}

		private bool ebJsAuYejvRqociTxulmKyAPKrq;

		private Player FcOGyfuEtfnVeFmuqZdutvFYIsk;

		private qIjMFrOnBtzCkPNWSvzPUfZdmEE ZJLqHyWxSlNwNxBsUcANGGRgYSt;

		private readonly int UmlfknJGLCaKwkBKLxTOQfvOngpe;

		private List<RuleSet> IfICxEEjBlFojVXqJWfYmxVlmKW;

		public bool enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public List<RuleSet> ruleSets
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal ControllerMapEnabler(Player player, qIjMFrOnBtzCkPNWSvzPUfZdmEE startingSettings)
		{
		}

		public void Apply()
		{
		}

		public void LoadDefaults()
		{
		}

		public string ToXmlString()
		{
			return null;
		}

		public string ToJsonString()
		{
			return null;
		}

		public bool ImportXml(string xmlString)
		{
			return false;
		}

		public bool ImportJson(string jsonString)
		{
			return false;
		}

		private SerializedObject JmwEySjsRbHsSSCjraSnRZkWpCK()
		{
			return null;
		}

		private void ujdDDoifWuqiKaPALJfjeGuYvJZI(SerializedObject P_0)
		{
		}

		private bool cLtgvbqpSWEWaXWDxkkwTJrGVrd(SerializedObject P_0)
		{
			return false;
		}
	}
}
