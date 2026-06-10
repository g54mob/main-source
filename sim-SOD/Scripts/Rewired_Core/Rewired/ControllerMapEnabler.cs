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
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		[Preserve]
		public sealed class Rule : IDeepCloneable
		{
			[SerializeField]
			[Serialize(Name = "tag")]
			private string _tag;

			[Serialize(Name = "enable")]
			[SerializeField]
			private bool _enable;

			[Serialize(Name = "categoryIds")]
			[SerializeField]
			private int[] _categoryIds;

			[SerializeField]
			[Serialize(Name = "layoutIds")]
			private int[] _layoutIds;

			[SerializeField]
			[Serialize(Name = "controllerSetSelector")]
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
		[SerializationType(SerializationTypeAttribute.SerializationType.Object)]
		[Preserve]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class RuleSet : IDeepCloneable, IEnumerable, IList<Rule>, ICollection<Rule>, IEnumerable<Rule>
		{
			private const string className = "ControllerMapEnabler.RuleSet";

			[Serialize(Name = "enabled")]
			[SerializeField]
			private bool _enabled;

			[Serialize(Name = "tag")]
			[SerializeField]
			private string _tag;

			[Serialize(Name = "rules")]
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

			public Rule this[int index]
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

		internal class fsUQkYqqhRgcoNtKSwSjudaKpiM
		{
			public bool bncPgdmRtwpPAGrKmCTitEoJCNS;

			public acSAziGagXRkcjooVPiFpvmdfmV[] jsipkrvEsJAOlhPkRMnzQnNJjgz;

			public fsUQkYqqhRgcoNtKSwSjudaKpiM(bool enabled, acSAziGagXRkcjooVPiFpvmdfmV[] startingRuleSets)
			{
			}
		}

		private bool fYgWWBiWXTDKmooXjoXGiYdmpQy;

		private Player GvbAEQGJJPtOgFdmijEOTtulCyiG;

		private fsUQkYqqhRgcoNtKSwSjudaKpiM CRgkCFsPwXTYZhZZWRMlyiuPCSf;

		private readonly int RSGBQYfltigFuhDMRviugFIbvohH;

		private List<RuleSet> TojRulwzrXbMvLzqXprsUvmWGcS;

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

		internal ControllerMapEnabler(Player player, fsUQkYqqhRgcoNtKSwSjudaKpiM startingSettings)
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

		private SerializedObject IJTYgxRVETFGIEeOvEZXpvilyrI()
		{
			return null;
		}

		private void jXAdZRZwSrlEcNOETABxqFQbRRm(SerializedObject P_0)
		{
		}

		private bool jygDICBMHaTDOHrItEJCbjkpEXhs(SerializedObject P_0)
		{
			return false;
		}
	}
}
