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
		[CustomClassObfuscation]
		[Preserve]
		public sealed class Rule : IDeepCloneable
		{
			[Serialize]
			[SerializeField]
			private string _tag;

			[Serialize]
			[SerializeField]
			private bool _enable;

			[SerializeField]
			[Serialize]
			private int[] _categoryIds;

			[Serialize]
			[SerializeField]
			private int[] _layoutIds;

			[SerializeField]
			[Serialize]
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

			public Rule(Rule P_0)
			{
			}

			internal Rule(string P_0, bool P_1, int[] P_2, int[] P_3, ControllerSetSelector P_4)
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
		public sealed class RuleSet : IList<Rule>, ICollection<Rule>, IEnumerable<Rule>, IEnumerable, IDeepCloneable
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

			internal RuleSet(bool P_0, string P_1, List<Rule> P_2)
			{
			}

			public RuleSet()
			{
			}

			public RuleSet(RuleSet P_0)
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

		internal class bfKxbNaTbdokMFkgReyogCBTNRVl
		{
			public bool zbiIUygVHQtgeEPXnokrnmpIrTVg;

			public qmEcFrQmpjkfExHMGEuMliRmNVKH[] zcqaKwvyXhAGLtSnQTXsWmqKHjoD;

			public bfKxbNaTbdokMFkgReyogCBTNRVl(bool P_0, qmEcFrQmpjkfExHMGEuMliRmNVKH[] P_1)
			{
			}
		}

		private bool llkLFSoLVtaASCstwdnHCsIDxnhYb;

		private Player UvBXHObDlZYGHHCzDkZZTJyJLvx;

		private bfKxbNaTbdokMFkgReyogCBTNRVl MhmCTAhiehkWjtxhLprkaiHIUdqTA;

		private readonly int TcEXPUvjqSTMTFutCAtGRnMeNwub;

		private List<RuleSet> PblvdecObnfYBDkGUhZbCLLZIHRJA;

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

		internal ControllerMapEnabler(Player P_0, bfKxbNaTbdokMFkgReyogCBTNRVl P_1)
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

		private SerializedObject OwZlvwNnIfDEsAMweyvGbtLoYQJtA()
		{
			return null;
		}

		private void tnEqLMFFwugjoHOyMvcImNymgKGl(SerializedObject P_0)
		{
		}

		private bool xIgDRHQmTOVJkRVsknhXpBHuPygR(SerializedObject P_0)
		{
			return false;
		}
	}
}
