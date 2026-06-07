using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Tyd;
using UnityEngine;

public class BehaviorNode
{
	public string Name;

	public string LocName;

	public BehaviorNode Success;

	public BehaviorNode Failure;

	public bool Atomic;

	public bool HasStop;

	public Func<Actor, int> Run;

	public Action<Actor> Stop;

	public AI.NodeFlag Flags;

	public BehaviorNode(string name, Func<Actor, int> run, bool atomic, string locName = null, AI.NodeFlag flags = AI.NodeFlag.None)
	{
		Name = name;
		LocName = locName ?? name;
		Run = run;
		Atomic = atomic;
		Flags = flags;
	}

	public BehaviorNode(string name, Func<Actor, int> run, Action<Actor> stop, bool atomic, string locName = null, AI.NodeFlag flags = AI.NodeFlag.None)
	{
		Name = name;
		LocName = locName ?? name;
		Run = run;
		Stop = stop;
		HasStop = true;
		Atomic = atomic;
		Flags = flags;
	}

	public BehaviorNode(TydTable table, params Type[] methodHolder)
	{
		Name = table.Name;
		LocName = table.GetChildValue("LocName", false, Name);
		string childValue = table.GetChildValue("Run");
		Run = (Func<Actor, int>)Delegate.CreateDelegate(typeof(Func<Actor, int>), FindMethod(methodHolder, childValue));
		string childValue2 = table.GetChildValue("Stop", false);
		if (childValue2 != null)
		{
			Stop = (Action<Actor>)Delegate.CreateDelegate(typeof(Action<Actor>), FindMethod(methodHolder, childValue2));
			HasStop = true;
		}
		Atomic = table.GetChildValue("Atomic", false, true);
		Flags = table.GetChildValue("Flags", false, "None").Split('+').SelectInPlace((string x) => (AI.NodeFlag)Enum.Parse(typeof(AI.NodeFlag), x))
			.Aggregate((AI.NodeFlag x, AI.NodeFlag y) => x | y);
	}

	private static MethodInfo FindMethod(Type[] types, string run)
	{
		for (int i = 0; i < types.Length; i++)
		{
			MethodInfo method = types[i].GetMethod(run, BindingFlags.Static | BindingFlags.NonPublic);
			if (method != null)
			{
				return method;
			}
		}
		throw new Exception("AI method: " + run + " not found");
	}

	public void SetTree(Dictionary<string, BehaviorNode> behaviorNodes, TydTable table, string name)
	{
		string childValue = table.GetChildValue("Success", false);
		if (childValue != null)
		{
			BehaviorNode value;
			if (behaviorNodes.TryGetValue(childValue, out value))
			{
				Success = value;
			}
			else
			{
				Debug.LogError("Failed finding success node: " + childValue + " for AI: " + name);
			}
		}
		string childValue2 = table.GetChildValue("Failure", false);
		if (childValue2 != null)
		{
			BehaviorNode value2;
			if (behaviorNodes.TryGetValue(childValue2, out value2))
			{
				Failure = value2;
			}
			else
			{
				Debug.LogError("Failed finding fail node: " + childValue2 + " for AI: " + name);
			}
		}
	}

	private static string CheckForInfinites(List<BehaviorNode> nodes)
	{
		HashSet<BehaviorNode> hashSet = new HashSet<BehaviorNode>();
		HashSet<BehaviorNode> hashSet2 = new HashSet<BehaviorNode>();
		string fail = null;
		foreach (BehaviorNode node in nodes)
		{
			if (!node.Atomic)
			{
				if (CheckForInfiniteSub(node, hashSet, hashSet2, ref fail))
				{
					return fail;
				}
				hashSet.Clear();
				hashSet2.Clear();
			}
		}
		return null;
	}

	private static bool CheckForInfiniteSub(BehaviorNode node, HashSet<BehaviorNode> current, HashSet<BehaviorNode> stop, ref string fail)
	{
		HashSet<BehaviorNode> current2 = current;
		if (node.Atomic && current.Count > 0)
		{
			current2 = new HashSet<BehaviorNode>();
		}
		else if (!current.Add(node))
		{
			fail = node.Name;
			return true;
		}
		if (!stop.Add(node))
		{
			current.Remove(node);
			return false;
		}
		if (node.Success != null && CheckForInfiniteSub(node.Success, current2, stop, ref fail))
		{
			fail = node.Name + ".Success -> " + fail;
			return true;
		}
		if (node.Failure != null && CheckForInfiniteSub(node.Failure, current2, stop, ref fail))
		{
			fail = node.Name + ".Failure -> " + fail;
			return true;
		}
		stop.Remove(node);
		current.Remove(node);
		return false;
	}

	public static Dictionary<string, BehaviorNode> LoadTree(TydDocument doc, string tree, params Type[] methodHolder)
	{
		Dictionary<string, BehaviorNode> dictionary = new Dictionary<string, BehaviorNode>();
		Dictionary<BehaviorNode, TydTable> dictionary2 = new Dictionary<BehaviorNode, TydTable>();
		dictionary["Dummy"] = AI.DummyNode;
		foreach (TydTable item in doc.Nodes.OfType<TydTable>())
		{
			BehaviorNode behaviorNode;
			try
			{
				behaviorNode = new BehaviorNode(item, methodHolder);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed loading node " + item.Name + " in tree " + tree + ":\n" + ex);
			}
			dictionary[behaviorNode.Name] = behaviorNode;
			dictionary2[behaviorNode] = item;
		}
		foreach (KeyValuePair<BehaviorNode, TydTable> item2 in dictionary2)
		{
			item2.Key.SetTree(dictionary, item2.Value, tree);
		}
		return dictionary;
	}

	public override string ToString()
	{
		return Name;
	}
}
