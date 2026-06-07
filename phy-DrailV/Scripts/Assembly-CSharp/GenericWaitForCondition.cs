using System.Collections;
using Bolt;
using Ludiq;

public abstract class GenericWaitForCondition : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput doneTrigger;

	protected virtual string DoneFieldName => "Done";

	protected virtual string InputFieldName => "Input";

	protected abstract void InternalDefinition();

	protected override void Definition()
	{
		doneTrigger = (string.IsNullOrEmpty(DoneFieldName) ? null : ControlOutput(DoneFieldName));
		inputTrigger = ControlInputCoroutine(InputFieldName, Routine);
		InternalDefinition();
	}

	public virtual object PrepareContext(Flow flow)
	{
		return null;
	}

	public virtual void Initialize(Flow flow, object context, bool silent = false)
	{
	}

	public virtual bool EarlyOutCheck(Flow flow, object context, bool silent = false)
	{
		return CheckCondition(flow, context, silent: true);
	}

	public virtual void Deinitialize(Flow flow, object context, bool silent = false)
	{
	}

	public virtual void CleanupContext(Flow flow, object context)
	{
	}

	public abstract bool CheckCondition(Flow flow, object context, bool silent = false);

	public virtual ControlOutput GetOutputTrigger(Flow flow, object context)
	{
		return doneTrigger;
	}

	private IEnumerator Routine(Flow flow)
	{
		object context = PrepareContext(flow);
		if (EarlyOutCheck(flow, context))
		{
			ControlOutput outputTrigger = GetOutputTrigger(flow, context);
			CleanupContext(flow, context);
			yield return outputTrigger;
			yield break;
		}
		Initialize(flow, context);
		while (!CheckCondition(flow, context))
		{
			yield return null;
		}
		Deinitialize(flow, context);
		CleanupContext(flow, context);
		yield return GetOutputTrigger(flow, context);
	}
}
