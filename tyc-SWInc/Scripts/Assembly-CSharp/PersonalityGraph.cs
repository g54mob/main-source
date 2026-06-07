using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tyd;
using UnityEngine;

[Serializable]
[AltDeprecate("PersonalityEffects", typeof(Dictionary<string, float[]>))]
public class PersonalityGraph : IByteData
{
	private Dictionary<KeyValuePair<string, string>, float> Compatibility = new Dictionary<KeyValuePair<string, string>, float>();

	private Dictionary<string, List<string>> Incompatibility = new Dictionary<string, List<string>>();

	public Dictionary<string, string> Expressions = new Dictionary<string, string>();

	public Dictionary<string, Employee.Trait[]> Traits = new Dictionary<string, Employee.Trait[]>();

	public List<string> PersonalityTraits = new List<string>();

	public static int Effects = 3;

	public bool Replace;

	[NonSerialized]
	private Dictionary<string, Dictionary<string, float>> _fasterCompatibility;

	private static List<string> _personalityCache = new List<string>();

	private static HashSet<string> _incompatibleCache = new HashSet<string>();

	private static PersonalityGraph _lastCacheUse;

	public float this[string p1, string p2]
	{
		get
		{
			if (p1.Equals(p2))
			{
				return 2f;
			}
			if (_fasterCompatibility == null)
			{
				CreateFasterCompatibility();
			}
			Dictionary<string, float> value;
			if (_fasterCompatibility.TryGetValue(p1, out value))
			{
				return value.GetOrDefault(p2, 1f);
			}
			return 1f;
		}
	}

	public void WriteData(Stream st)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		st.WriteInt(PersonalityTraits.Count);
		for (int i = 0; i < PersonalityTraits.Count; i++)
		{
			string text = PersonalityTraits[i];
			dictionary[text] = i;
			st.WriteStringUTF8(text);
		}
		st.WriteInt(Compatibility.Count);
		foreach (KeyValuePair<KeyValuePair<string, string>, float> item in Compatibility)
		{
			st.WriteInt(dictionary[item.Key.Key]);
			st.WriteInt(dictionary[item.Key.Value]);
			st.WriteFloat(item.Value);
		}
		st.WriteInt(Incompatibility.Count);
		foreach (KeyValuePair<string, List<string>> item2 in Incompatibility)
		{
			st.WriteInt(dictionary[item2.Key]);
			st.WriteInt(item2.Value.Count);
			for (int j = 0; j < item2.Value.Count; j++)
			{
				st.WriteInt(dictionary[item2.Value[j]]);
			}
		}
		st.WriteInt(Expressions.Count);
		foreach (KeyValuePair<string, string> expression in Expressions)
		{
			st.WriteInt(dictionary[expression.Key]);
			st.WriteStringUTF8(expression.Value);
		}
		st.WriteInt(Traits.Count);
		foreach (KeyValuePair<string, Employee.Trait[]> trait2 in Traits)
		{
			st.WriteInt(dictionary[trait2.Key]);
			ulong num = 0uL;
			Employee.Trait[] value = trait2.Value;
			foreach (Employee.Trait trait in value)
			{
				num |= (ulong)trait;
			}
			st.WriteUInt64(num);
		}
	}

	public static PersonalityGraph ReadData(Stream st)
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		int num = st.ReadInt();
		for (int i = 0; i < num; i++)
		{
			dictionary[i] = st.ReadStringUTF8();
		}
		Dictionary<KeyValuePair<string, string>, float> dictionary2 = new Dictionary<KeyValuePair<string, string>, float>();
		num = st.ReadInt();
		for (int j = 0; j < num; j++)
		{
			dictionary2[new KeyValuePair<string, string>(dictionary[st.ReadInt()], dictionary[st.ReadInt()])] = st.ReadFloat();
		}
		Dictionary<string, List<string>> dictionary3 = new Dictionary<string, List<string>>();
		num = st.ReadInt();
		for (int k = 0; k < num; k++)
		{
			string key = dictionary[st.ReadInt()];
			List<string> list = (dictionary3[key] = new List<string>());
			List<string> list3 = list;
			int num2 = st.ReadInt();
			for (int l = 0; l < num2; l++)
			{
				list3.Add(dictionary[st.ReadInt()]);
			}
		}
		Dictionary<string, string> dictionary4 = new Dictionary<string, string>();
		num = st.ReadInt();
		for (int m = 0; m < num; m++)
		{
			dictionary4[dictionary[st.ReadInt()]] = st.ReadStringUTF8();
		}
		Dictionary<string, Employee.Trait[]> dictionary5 = new Dictionary<string, Employee.Trait[]>();
		num = st.ReadInt();
		for (int n = 0; n < num; n++)
		{
			dictionary5[dictionary[st.ReadInt()]] = Employee.EnumTraits((Employee.Trait)st.ReadUint64()).ToArray();
		}
		return new PersonalityGraph
		{
			PersonalityTraits = dictionary.Values.ToList(),
			Compatibility = dictionary2,
			Incompatibility = dictionary3,
			Expressions = dictionary4,
			Traits = dictionary5
		};
	}

	public void FixTraits()
	{
		if (Traits.Count != 0)
		{
			return;
		}
		PersonalityGraph personalityGraph = GameData.VanillaPersonalities();
		for (int i = 0; i < PersonalityTraits.Count; i++)
		{
			string key = PersonalityTraits[i];
			Employee.Trait[] value;
			if (personalityGraph.Traits.TryGetValue(key, out value))
			{
				Traits[key] = value.ToArray();
			}
			else if (UnityEngine.Random.value > 0.5f)
			{
				Traits[key] = new Employee.Trait[1] { (Employee.Trait)Utilities.GetRandomBit(1082146688uL) };
			}
			else
			{
				Traits[key] = new Employee.Trait[2]
				{
					(Employee.Trait)Utilities.GetRandomBit(3087007871uL),
					(Employee.Trait)Utilities.GetRandomBit(4353671168uL)
				};
			}
		}
	}

	public Employee.Trait CombineTraits(string personality)
	{
		Employee.Trait trait = Employee.Trait.None;
		Employee.Trait[] array = Traits[personality];
		for (int i = 0; i < array.Length; i++)
		{
			trait |= array[i];
		}
		return trait;
	}

	private void CreateFasterCompatibility()
	{
		_fasterCompatibility = new Dictionary<string, Dictionary<string, float>>();
		foreach (KeyValuePair<KeyValuePair<string, string>, float> item in Compatibility)
		{
			_fasterCompatibility.GetOrAdd(item.Key.Key, (string x) => new Dictionary<string, float>())[item.Key.Value] = item.Value;
		}
	}

	public PersonalityGraph()
	{
	}

	public IEnumerable<KeyValuePair<string, float>> GetCompatibilities(string personality)
	{
		for (int i = 0; i < PersonalityTraits.Count; i++)
		{
			yield return new KeyValuePair<string, float>(PersonalityTraits[i], this[personality, PersonalityTraits[i]]);
		}
	}

	public PersonalityGraph(TydCollection node)
	{
		Replace = node.GetChildValue("Replace", false, false);
		HashSet<string> hashSet = new HashSet<string>();
		foreach (TydCollection item in node.GetChild<TydCollection>("Personalities").Nodes.OfType<TydCollection>())
		{
			string p = item.GetChildValue("Name");
			string childValue = item.GetChildValue("Expression", false);
			if (childValue != null)
			{
				Expressions[p] = childValue;
			}
			hashSet.Remove(p);
			if (!PersonalityTraits.Contains(p))
			{
				PersonalityTraits.Add(p);
				SetIncompatibility(p, p);
			}
			TydCollection child = item.GetChild<TydCollection>("Relationships");
			if (child != null)
			{
				if (child is TydTable)
				{
					foreach (TydString item2 in child.Nodes.OfType<TydString>())
					{
						SetCompatibility(p, item2.Name, item2.Value.ConvertToFloat(item2.Name), hashSet);
					}
				}
				else
				{
					foreach (TydCollection item3 in child.Nodes.OfType<TydCollection>())
					{
						SetCompatibility(p, item3.GetChildValue(0), item3.GetChildValue<float>(1), hashSet);
					}
				}
			}
			TydList child2 = item.GetChild<TydList>("Traits");
			if (child2 == null)
			{
				throw new Exception("Traits are missing for personality " + p);
			}
			Employee.Trait[] array = child2.Nodes.SelectInPlace(delegate(TydNode x)
			{
				TydString tydString = x as TydString;
				if (tydString != null)
				{
					Employee.Trait res;
					if (tydString.Value.ToEnum<Employee.Trait>(out res))
					{
						return res;
					}
					throw new Exception("Trait " + tydString.Value + " does not exist for personality " + p);
				}
				throw new Exception("Traits are not formatted correctly for personality " + p);
			});
			Traits[p] = array;
			if (array.Length > 2 || array.Length == 0 || (array.Length == 1 && !(Employee.Trait.NightOwl | Employee.Trait.BornLeader | Employee.Trait.FirmwareInc | Employee.Trait.SuperFocus | Employee.Trait.Unphased | Employee.Trait.JustTheFlu | Employee.Trait.Detached | Employee.Trait.Watch | Employee.Trait.FriendMaker).HasBits(array[0])) || (array.Length == 2 && (!(Employee.Trait.FastLearner | Employee.Trait.Independant | Employee.Trait.BigBrain | Employee.Trait.Humble | Employee.Trait.Capacitor | Employee.Trait.WalkItOff | Employee.Trait.ThisIsFine | Employee.Trait.Sunshine | Employee.Trait.Skyscraper | Employee.Trait.RGBThumb | Employee.Trait.Clean).HasBits(array[0]) || !(Employee.Trait.Stressed | Employee.Trait.Hypochondriac | Employee.Trait.SlowEater | Employee.Trait.NervousBladder | Employee.Trait.BumLeg | Employee.Trait.Forgetful | Employee.Trait.Cupholder | Employee.Trait.NeatFreak | Employee.Trait.SilentButDeadly | Employee.Trait.WalkInstead | Employee.Trait.UnderTheWeather | Employee.Trait.Claustrophobic).HasBits(array[1]))))
			{
				throw new Exception("Personality " + p + " should have a good and a bad trait, or one neutral trait");
			}
		}
		if (hashSet.Count > 0)
		{
			throw new Exception("Relationship defined for nonexistent personality: " + hashSet.First());
		}
		TydCollection child3 = node.GetChild<TydCollection>("Incompatibilities");
		if (child3 == null)
		{
			return;
		}
		HashSet<string> hashSet2 = PersonalityTraits.ToHashSet();
		foreach (TydCollection item4 in child3.Nodes.OfType<TydCollection>())
		{
			string childValue2 = item4.GetChildValue(0);
			string childValue3 = item4.GetChildValue(1);
			if (hashSet2.Contains(childValue2) && hashSet2.Contains(childValue3))
			{
				SetIncompatibility(childValue2, childValue3);
			}
		}
	}

	public string SelectRandom(string[] previous)
	{
		lock (this)
		{
			_incompatibleCache.Clear();
			foreach (string personality in previous)
			{
				GetIncompatibilities(personality, _incompatibleCache);
			}
			if (_lastCacheUse != this)
			{
				_personalityCache.Clear();
				_personalityCache.AddRange(PersonalityTraits);
			}
			_lastCacheUse = this;
			while (_personalityCache.Count > 0)
			{
				int index = Utilities.RandomRange(0, _personalityCache.Count);
				string text = _personalityCache[index];
				if (!previous.Contains(text) && !_incompatibleCache.Contains(text))
				{
					return text;
				}
				_lastCacheUse = null;
				_personalityCache.RemoveAt(index);
			}
			return null;
		}
	}

	public HashSet<string> GetIncompatibilities(string personality, HashSet<string> cache = null)
	{
		List<string> value;
		if (personality != null && Incompatibility.TryGetValue(personality, out value))
		{
			if (cache != null)
			{
				cache.AddRange(value);
				return cache;
			}
			return value.ToHashSet();
		}
		if (cache == null)
		{
			return new HashSet<string>();
		}
		return cache;
	}

	public void MergeWith(PersonalityGraph graph)
	{
		if (graph == null)
		{
			return;
		}
		foreach (KeyValuePair<KeyValuePair<string, string>, float> item in graph.Compatibility)
		{
			SetCompatibility(item.Key.Key, item.Key.Value, item.Value, null);
		}
		foreach (KeyValuePair<string, Employee.Trait[]> trait in graph.Traits)
		{
			if (!PersonalityTraits.Contains(trait.Key))
			{
				PersonalityTraits.Add(trait.Key);
				SetIncompatibility(trait.Key, trait.Key);
			}
			Traits[trait.Key] = trait.Value;
		}
		foreach (KeyValuePair<string, List<string>> item2 in graph.Incompatibility)
		{
			if (Incompatibility.ContainsKey(item2.Key))
			{
				Incompatibility[item2.Key].AddRange(item2.Value);
			}
			else
			{
				Incompatibility[item2.Key] = item2.Value.ToList();
			}
		}
		foreach (KeyValuePair<string, string> expression in graph.Expressions)
		{
			Expressions[expression.Key] = expression.Value;
		}
		_fasterCompatibility = null;
	}

	public PersonalityGraph Clone()
	{
		PersonalityGraph personalityGraph = new PersonalityGraph();
		personalityGraph.PersonalityTraits = PersonalityTraits.ToList();
		foreach (KeyValuePair<KeyValuePair<string, string>, float> item in Compatibility)
		{
			personalityGraph.SetCompatibility(item.Key.Key, item.Key.Value, item.Value, null);
		}
		personalityGraph.Incompatibility = Incompatibility.ToDictionary((KeyValuePair<string, List<string>> x) => x.Key, (KeyValuePair<string, List<string>> x) => x.Value);
		personalityGraph.Traits = Traits.ToDictionary((KeyValuePair<string, Employee.Trait[]> x) => x.Key, (KeyValuePair<string, Employee.Trait[]> x) => x.Value);
		personalityGraph.Expressions = Expressions.ToDictionary((KeyValuePair<string, string> x) => x.Key, (KeyValuePair<string, string> x) => x.Value);
		return personalityGraph;
	}

	private void SetIncompatibility(string p1, string p2)
	{
		if (!Incompatibility.ContainsKey(p1))
		{
			Incompatibility[p1] = new List<string>();
		}
		if (!Incompatibility.ContainsKey(p2))
		{
			Incompatibility[p2] = new List<string>();
		}
		if (!Incompatibility[p1].Contains(p2))
		{
			Incompatibility[p1].Add(p2);
			if (!p1.Equals(p2))
			{
				Incompatibility[p2].Add(p1);
			}
		}
	}

	private void SetCompatibility(string p1, string p2, float score, HashSet<string> missing)
	{
		if (!PersonalityTraits.Contains(p2))
		{
			PersonalityTraits.Add(p2);
			SetIncompatibility(p2, p2);
			if (missing != null)
			{
				missing.Add(p2);
			}
		}
		Compatibility[new KeyValuePair<string, string>(p1, p2)] = score;
		Compatibility[new KeyValuePair<string, string>(p2, p1)] = score;
	}

	public int CountPersonalities()
	{
		HashSet<string> hashSet = new HashSet<string>();
		int num = 0;
		for (int i = 0; i < PersonalityTraits.Count; i++)
		{
			string personality = PersonalityTraits[i];
			GetIncompatibilities(personality, hashSet);
			for (int j = i + 1; j < PersonalityTraits.Count; j++)
			{
				string item = PersonalityTraits[j];
				if (!hashSet.Contains(item))
				{
					num++;
				}
			}
			hashSet.Clear();
		}
		return num;
	}
}
