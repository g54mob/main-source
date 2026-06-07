using System;
using System.Collections.Generic;
using System.Linq;
using Tyd;

[Serializable]
public class ComponentProcess
{
	public readonly Manufacturing Parent;

	public readonly HardwareComponent[] Inputs;

	public readonly HardwareComponent Output;

	public readonly bool Final;

	public readonly int Mask;

	public int InputMask;

	public int Order;

	[NonSerialized]
	public List<ProductPrinter> ActiveAssemblers = new List<ProductPrinter>();

	public ComponentProcess()
	{
	}

	public ComponentProcess(ComponentProcess o, Manufacturing parent)
	{
		Parent = parent;
		Inputs = o.Inputs.SelectInPlace((HardwareComponent x) => parent.Components.First((HardwareComponent y) => y.Name.Equals(x.Name)));
		for (int num = 0; num < Inputs.Length; num++)
		{
			Inputs[num].InputProcess = this;
		}
		Mask = o.Mask;
		InputMask = o.InputMask;
		Order = o.Order;
		Final = o.Final;
		if (!Final)
		{
			Output = parent.Components.First((HardwareComponent x) => x.Name.Equals(o.Output.Name));
			Output.OutputProcess = this;
		}
	}

	public ComponentProcess(TydTable root, HardwareComponent[] components, Manufacturing parent)
	{
		Parent = parent;
		List<string> list = root.GetChild<TydList>("Inputs").GetChildValues().ToList();
		if (list.Count == 0)
		{
			throw new Exception("Input for a process is empty");
		}
		Inputs = new HardwareComponent[list.Count];
		for (int i = 0; i < list.Count; i++)
		{
			string node = list[i];
			HardwareComponent hardwareComponent = components.FirstOrDefault((HardwareComponent x) => x.Name.Equals(node));
			if (hardwareComponent == null)
			{
				throw new Exception("Component does not exist: " + node);
			}
			if (hardwareComponent.InputProcess != null)
			{
				throw new Exception("Component is already part of a process " + node);
			}
			Inputs[i] = hardwareComponent;
			hardwareComponent.InputProcess = this;
			InputMask |= hardwareComponent.Mask;
		}
		string o = root.GetChildValue("Output");
		if (o.Equals("Final"))
		{
			Final = true;
			Mask = InputMask;
			return;
		}
		HardwareComponent hardwareComponent2 = components.FirstOrDefault((HardwareComponent x) => x.Name.Equals(o));
		if (hardwareComponent2 == null)
		{
			throw new Exception("Component does not exist: " + o);
		}
		if (hardwareComponent2.OutputProcess != null)
		{
			throw new Exception("Component is already part of a process " + o);
		}
		Output = hardwareComponent2;
		Output.OutputProcess = this;
		Mask = Output.Mask | InputMask;
	}

	public string GetBaseName()
	{
		if (!Final)
		{
			return Output.GetBaseName();
		}
		return "FinalAssembly".Loc();
	}

	public string GetPrettyName()
	{
		return GetBaseName() + " (" + Parent.Category.GetPrettyName() + ")";
	}

	public string GetOutputName()
	{
		if (!Final)
		{
			return Output.Name;
		}
		return "Final assembly";
	}

	public string GetPath()
	{
		return Parent.Type.Name + "/" + Parent.Category.GetActualName() + "/" + (Final ? "Final" : Output.Name);
	}

	public override string ToString()
	{
		return GetOutputName() + " assembly (" + Parent.Category.ToString() + ")";
	}
}
