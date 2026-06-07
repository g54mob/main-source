using System;
using System.Collections.Generic;
using NWH.VehiclePhysics2.Powertrain;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain.Tree
{
	public class PowertrainNode
	{
		public List<PowertrainNode> Children { get; private set; } = new List<PowertrainNode>();

		public float EstimatedInputRPM { get; set; }

		public float EstimatedInputTorque { get; set; }

		public float EstimatedOutputRPM { get; set; }

		public float EstimatedOutputTorque { get; set; }

		public float GearRatio { get; set; } = 1f;

		public Func<IPowertrain, PowertrainComponent, PowertrainComponent> InitializePowertrain { get; set; }

		public PowertrainNodeConnection InputConnection { get; }

		public bool IsReversed { get; set; }

		public string Name { get; }

		public IPowertrainNode Part { get; private set; }

		public PowertrainNode(IPowertrainNode part, PowertrainNodeConnection inputConnection)
		{
			InputConnection = inputConnection;
			Name = $"{part.Part.Part.Name} #{part.Part.Part.Id}";
			Part = part;
		}

		public void AddChild(PowertrainNode child)
		{
			Children.Add(child);
		}

		public void ExecuteOnTree(Action<PowertrainNode> action)
		{
			action(this);
			foreach (PowertrainNode child in Children)
			{
				child.ExecuteOnTree(action);
			}
		}
	}
}
