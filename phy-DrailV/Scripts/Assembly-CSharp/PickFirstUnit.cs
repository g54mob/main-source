using Bolt;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(Branch))]
[UnitSubtitle("Continue the branch that first meets the condition")]
[UnitTitle("Pick First")]
[UnitCategory("Branching")]
public class PickFirstUnit : GenericWaitForCondition
{
	public enum VerbosityMode
	{
		FirstOnly = 0,
		All = 1,
		None = 2
	}

	private class Context
	{
		public GenericWaitForCondition[] OutputConditions;

		public object[] Contexts;

		public VerbosityMode Mode;

		public int Selected = -1;

		public ControlOutput ChosenOutput;

		public bool ShouldBeSilent(int index)
		{
			if (Mode != VerbosityMode.None)
			{
				if (Mode == VerbosityMode.FirstOnly)
				{
					return index != 0;
				}
				return false;
			}
			return true;
		}
	}

	private const int MAX_BRANCHES = 16;

	[DoNotSerialize]
	public ValueInput verbosityModeValue;

	public ControlOutput[] OutputTriggers;

	[Inspectable]
	[UnitHeaderInspectable("Count")]
	public int Count { get; set; } = 1;

	protected override string DoneFieldName => string.Empty;

	protected override void InternalDefinition()
	{
		verbosityModeValue = ValueInput("Verbosity", VerbosityMode.FirstOnly);
		int num = Mathf.Clamp(Count, 1, 16);
		OutputTriggers = new ControlOutput[num];
		for (int i = 0; i < num; i++)
		{
			OutputTriggers[i] = ControlOutput($"Branch {i}");
		}
	}

	public override object PrepareContext(Flow flow)
	{
		Context context = new Context();
		context.Mode = flow.GetValue<VerbosityMode>(verbosityModeValue);
		context.OutputConditions = new GenericWaitForCondition[OutputTriggers.Length];
		context.Contexts = new object[OutputTriggers.Length];
		for (int i = 0; i < OutputTriggers.Length; i++)
		{
			if (OutputTriggers[i].hasValidConnection)
			{
				IUnit unit = OutputTriggers[i].connection.destination.unit;
				if (unit is GenericWaitForCondition genericWaitForCondition)
				{
					context.OutputConditions[i] = genericWaitForCondition;
				}
				else
				{
					Debug.LogError(string.Format("Branch {0} is connected to a unit that is not a {1}, this won't work: ", i, "GenericWaitForCondition") + unit.GetType());
				}
			}
			else
			{
				Debug.LogWarning($"Branch {i} is not connected to anything");
			}
		}
		for (int j = 0; j < OutputTriggers.Length; j++)
		{
			if (context.OutputConditions[j] != null)
			{
				context.Contexts[j] = context.OutputConditions[j].PrepareContext(flow);
			}
		}
		return context;
	}

	public override bool EarlyOutCheck(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		for (int i = 0; i < context2.OutputConditions.Length; i++)
		{
			bool flag = context2.ShouldBeSilent(i);
			if (context2.OutputConditions[i] != null && context2.OutputConditions[i].EarlyOutCheck(flow, context2.Contexts[i], silent || flag))
			{
				context2.Selected = i;
				context2.ChosenOutput = context2.OutputConditions[context2.Selected].GetOutputTrigger(flow, context2.Contexts[context2.Selected]);
				return true;
			}
		}
		return false;
	}

	public override void Initialize(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		for (int i = 0; i < context2.OutputConditions.Length; i++)
		{
			bool flag = context2.ShouldBeSilent(i);
			if (context2.OutputConditions[i] != null)
			{
				context2.OutputConditions[i].Initialize(flow, context2.Contexts[i], silent || flag);
			}
		}
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		for (int i = 0; i < context2.OutputConditions.Length; i++)
		{
			bool flag = context2.ShouldBeSilent(i);
			if (context2.OutputConditions[i] != null && context2.OutputConditions[i].CheckCondition(flow, context2.Contexts[i], silent || flag))
			{
				context2.Selected = i;
				context2.ChosenOutput = context2.OutputConditions[context2.Selected].GetOutputTrigger(flow, context2.Contexts[context2.Selected]);
				return true;
			}
		}
		return false;
	}

	public override void Deinitialize(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		for (int i = 0; i < context2.OutputConditions.Length; i++)
		{
			bool flag = context2.ShouldBeSilent(i);
			if (context2.OutputConditions[i] != null)
			{
				context2.OutputConditions[i].Deinitialize(flow, context2.Contexts[i], silent || flag);
			}
		}
	}

	public override void CleanupContext(Flow flow, object context)
	{
		Context context2 = (Context)context;
		for (int i = 0; i < context2.OutputConditions.Length; i++)
		{
			if (context2.OutputConditions[i] != null)
			{
				context2.OutputConditions[i].CleanupContext(flow, context2.Contexts[i]);
				context2.Contexts[i] = null;
				context2.OutputConditions[i] = null;
			}
		}
	}

	public override ControlOutput GetOutputTrigger(Flow flow, object context)
	{
		return ((Context)context).ChosenOutput;
	}
}
