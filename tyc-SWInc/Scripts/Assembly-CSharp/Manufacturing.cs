using System;
using System.Collections.Generic;
using System.Linq;
using Tyd;

public class Manufacturing
{
	public readonly HardwareComponent[] Components;

	public readonly ComponentProcess[] Processes;

	public readonly ComponentProcess FinalProcess;

	public readonly SoftwareType Type;

	public readonly IManufacturable Category;

	public readonly int FinalTime = 5;

	public readonly Dictionary<string, KeyValuePair<uint, uint>> NewDependencies = new Dictionary<string, KeyValuePair<uint, uint>>();

	public readonly Dictionary<string, int> Designs = new Dictionary<string, int>();

	public readonly Dictionary<string, Dictionary<string, string>> FeatureBindings = new Dictionary<string, Dictionary<string, string>>();

	public HashSet<string> Dependencies;

	public void FixDependencies()
	{
		if (Dependencies == null)
		{
			return;
		}
		foreach (string dependency in Dependencies)
		{
			NewDependencies[dependency] = new KeyValuePair<uint, uint>(0u, uint.MaxValue);
		}
		Dependencies = null;
	}

	public Manufacturing()
	{
	}

	public Manufacturing(Manufacturing o, SoftwareType type, IManufacturable category)
	{
		FinalTime = o.FinalTime;
		Components = o.Components.SelectInPlace((HardwareComponent x) => new HardwareComponent(x, this));
		Processes = o.Processes.SelectInPlace((ComponentProcess x) => new ComponentProcess(x, this));
		FinalProcess = Processes.First((ComponentProcess x) => x.Final);
		Designs = o.Designs.ToDictionary((KeyValuePair<string, int> x) => x.Key, (KeyValuePair<string, int> x) => x.Value);
		FeatureBindings = o.FeatureBindings.ToDictionary((KeyValuePair<string, Dictionary<string, string>> x) => x.Key, (KeyValuePair<string, Dictionary<string, string>> x) => x.Value.ToDictionary((KeyValuePair<string, string> z) => z.Key, (KeyValuePair<string, string> z) => z.Value));
		InitDependencies();
		Type = type;
		Category = category;
	}

	private void LoadDesigns(TydNode n)
	{
		if (n == null)
		{
			return;
		}
		TydList tydList = n as TydList;
		if (tydList != null)
		{
			foreach (TydNode node in tydList.Nodes)
			{
				TydList tydList2 = node as TydList;
				if (tydList2 != null)
				{
					Designs[((TydString)tydList2[0]).Value] = ((TydString)tydList2[1]).Value.ConvertToIntDef(0);
				}
				else
				{
					TydString tydString = node as TydString;
					if (tydString != null)
					{
						Designs[tydString.Value] = 0;
					}
				}
			}
			return;
		}
		TydString tydString2 = n as TydString;
		if (tydString2 != null)
		{
			Designs[tydString2.Value] = 0;
		}
	}

	public IEnumerable<HardwareDesign> GetValidDesigns(int year)
	{
		foreach (KeyValuePair<string, int> design in Designs)
		{
			if (year >= design.Value - 1900)
			{
				HardwareDesign orNull = ObjectDatabase.Instance.HardwareDesigns.GetOrNull(design.Key);
				if (orNull != null)
				{
					yield return orNull;
				}
			}
		}
	}

	public HardwareDesign GetBestDesign(int year)
	{
		HardwareDesign result = null;
		int num = -1;
		foreach (KeyValuePair<string, int> design in Designs)
		{
			if (year >= design.Value - 1900)
			{
				HardwareDesign orNull = ObjectDatabase.Instance.HardwareDesigns.GetOrNull(design.Key);
				if (orNull != null && (design.Value > num || (design.Value == num && Utilities.RandomValue > 0.5f)))
				{
					num = design.Value;
					result = orNull;
				}
			}
		}
		return result;
	}

	private static string GetBindingNodeValue(TydNode n)
	{
		TydString tydString = n as TydString;
		if (tydString != null)
		{
			return tydString.Value;
		}
		throw new Exception("Failed loading feature binding for manufacturing");
	}

	private static void LoadBindings(TydTable root, Dictionary<string, Dictionary<string, string>> bindings)
	{
		foreach (TydList item in root.Nodes.OfType<TydList>())
		{
			if (item.Name.Equals("FeatureBinding") && item.Nodes.Count == 3)
			{
				bindings.Append(GetBindingNodeValue(item.Nodes[0]))[GetBindingNodeValue(item.Nodes[1])] = GetBindingNodeValue(item.Nodes[2]);
			}
		}
	}

	public HashSet<string> GetDisallowed(string design, IList<FeatureBase> features)
	{
		HashSet<string> hashSet = new HashSet<string>();
		Dictionary<string, string> value;
		if (FeatureBindings.TryGetValue(design, out value))
		{
			foreach (KeyValuePair<string, string> pair in value)
			{
				if (!features.Any((FeatureBase x) => x.Name.Equals(pair.Value)))
				{
					hashSet.Add(pair.Key);
				}
			}
		}
		return hashSet;
	}

	public Manufacturing(TydTable root, SoftwareType type, IManufacturable category, string modPath)
	{
		FinalTime = root.GetChildValue("FinalTime", true, 0);
		Components = GetComponents(root, this, modPath);
		Processes = GetProcesses(root, Components, this, out FinalProcess);
		InitDependencies();
		LoadDesigns(root.GetChild("Design"));
		LoadBindings(root, FeatureBindings);
		Type = type;
		Category = category;
	}

	public Manufacturing(TydTable root, string modPath)
	{
		FinalTime = root.GetChildValue("FinalTime", true, 0);
		Components = GetComponents(root, this, modPath);
		Processes = GetProcesses(root, Components, this, out FinalProcess);
		LoadDesigns(root.GetChild("Design"));
		LoadBindings(root, FeatureBindings);
		InitDependencies();
	}

	public bool IsDependency(string feature, uint factor)
	{
		KeyValuePair<uint, uint> value;
		if (NewDependencies.TryGetValue(feature, out value))
		{
			if (factor == 0 || value.Key == 0)
			{
				return true;
			}
			if (factor >= value.Key)
			{
				return factor <= value.Value;
			}
			return false;
		}
		return false;
	}

	private void InitDependencies()
	{
		for (int i = 0; i < Components.Length; i++)
		{
			HardwareComponent hardwareComponent = Components[i];
			if (hardwareComponent.DependsOn != null)
			{
				KeyValuePair<uint, uint> value;
				if (NewDependencies.TryGetValue(hardwareComponent.DependsOn, out value))
				{
					NewDependencies[hardwareComponent.DependsOn] = new KeyValuePair<uint, uint>(hardwareComponent.DependMin.Min(value.Key), hardwareComponent.DependMax.Max(value.Value));
				}
				else
				{
					NewDependencies[hardwareComponent.DependsOn] = new KeyValuePair<uint, uint>(hardwareComponent.DependMin, hardwareComponent.DependMax);
				}
			}
		}
	}

	private static HardwareComponent[] GetComponents(TydTable root, Manufacturing parent, string modPath)
	{
		List<TydNode> nodes = root.GetChild<TydList>("Components").Nodes;
		if (nodes.Count > 31)
		{
			throw new Exception("You can only have 31 components per software");
		}
		HardwareComponent[] array = new HardwareComponent[nodes.Count];
		for (int i = 0; i < nodes.Count; i++)
		{
			TydTable tydTable = nodes[i] as TydTable;
			if (tydTable != null)
			{
				array[i] = new HardwareComponent(tydTable, i, parent, modPath);
				continue;
			}
			throw new Exception("Components should be defined in tables");
		}
		return array;
	}

	private static ComponentProcess[] GetProcesses(TydTable root, HardwareComponent[] components, Manufacturing parent, out ComponentProcess final)
	{
		List<TydNode> nodes = root.GetChild<TydList>("Processes").Nodes;
		ComponentProcess[] array = new ComponentProcess[nodes.Count];
		final = null;
		for (int i = 0; i < nodes.Count; i++)
		{
			TydTable tydTable = nodes[i] as TydTable;
			if (tydTable != null)
			{
				array[i] = new ComponentProcess(tydTable, components, parent);
				if (array[i].Final)
				{
					if (final != null)
					{
						throw new Exception("Manufacturing needs exactly one final assembly process");
					}
					final = array[i];
				}
				continue;
			}
			throw new Exception("Manufacturing processes should be defined in tables");
		}
		if (final == null)
		{
			throw new Exception("Manufacturing needs exactly one final assembly process");
		}
		SetOrder(final, 0);
		Array.Sort(array, ProcessComparison);
		FixMask(final);
		return array;
	}

	private static int FixMask(ComponentProcess process)
	{
		if (process == null)
		{
			return 0;
		}
		int num = process.InputMask;
		for (int i = 0; i < process.Inputs.Length; i++)
		{
			HardwareComponent hardwareComponent = process.Inputs[i];
			num |= FixMask(hardwareComponent.OutputProcess);
		}
		process.InputMask |= num;
		return num;
	}

	private static int ProcessComparison(ComponentProcess a, ComponentProcess b)
	{
		return b.Order - a.Order;
	}

	private static void SetOrder(ComponentProcess process, int order)
	{
		process.Order = order;
		for (int i = 0; i < process.Inputs.Length; i++)
		{
			HardwareComponent hardwareComponent = process.Inputs[i];
			if (hardwareComponent.OutputProcess != null)
			{
				SetOrder(hardwareComponent.OutputProcess, order + 1);
			}
		}
	}

	public void GetProcessInfo(IList<FeatureBase> features, IList<uint> factors, out float price, out int mask, out int inputMask)
	{
		price = 0f;
		mask = 0;
		inputMask = 0;
		for (int i = 0; i < Processes.Length; i++)
		{
			ComponentProcess componentProcess = Processes[i];
			bool flag = false;
			bool flag2 = componentProcess.Final || componentProcess.Output.Valid(features, factors);
			if (!componentProcess.Final)
			{
				componentProcess.Output.assembled = false;
			}
			for (int j = 0; j < componentProcess.Inputs.Length; j++)
			{
				HardwareComponent hardwareComponent = componentProcess.Inputs[j];
				if (hardwareComponent.Valid(features, factors))
				{
					flag = true;
					if (!componentProcess.Final && flag2)
					{
						componentProcess.Output.assembled = true;
					}
					if (!hardwareComponent.assembled)
					{
						price += hardwareComponent.Price;
						inputMask |= hardwareComponent.Mask;
					}
					mask |= hardwareComponent.Mask;
				}
				else if ((!flag || (!componentProcess.Final && flag2 && !componentProcess.Output.assembled)) && ValidInput(hardwareComponent, features, factors, true))
				{
					flag = true;
					if (!componentProcess.Final && flag2)
					{
						componentProcess.Output.assembled = true;
					}
				}
			}
			if (flag2 && flag && !componentProcess.Final)
			{
				mask |= componentProcess.Output.Mask;
			}
		}
	}

	private bool ValidInput(HardwareComponent c, IList<FeatureBase> features, IList<uint> factors, bool first)
	{
		if (!first && c.Valid(features, factors))
		{
			return true;
		}
		ComponentProcess componentProcess = Processes.FirstOrDefault((ComponentProcess x) => x.Output == c);
		if (componentProcess != null)
		{
			for (int num = 0; num < componentProcess.Inputs.Length; num++)
			{
				HardwareComponent c2 = componentProcess.Inputs[num];
				if (ValidInput(c2, features, factors, false))
				{
					return true;
				}
			}
		}
		return false;
	}

	public override string ToString()
	{
		return Category.ToString() + " Manufacturing";
	}
}
