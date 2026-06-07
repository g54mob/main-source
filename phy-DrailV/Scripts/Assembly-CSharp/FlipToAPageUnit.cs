using Bolt;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(SphereCollider))]
[UnitCategory("Interaction")]
[UnitSubtitle("Flip through the pages of a booklet")]
[UnitTitle("Flip To A Page")]
public class FlipToAPageUnit : GenericWaitForConditionWithMessage
{
	public enum ComparisonType
	{
		Equal = 0,
		NotEqual = 1,
		GreaterOrEqual = 2,
		LessOrEqual = 3
	}

	private class Context
	{
		public TutorialPageFlipWrapper TPFW;

		public int TargetPage;

		public float RequiredTime;

		public float LastCheckTime;

		public float TimeElapsed;

		public ComparisonType Comparison;
	}

	[DoNotSerialize]
	public ValueInput targetItem;

	[DoNotSerialize]
	public ValueInput targetPage;

	[DoNotSerialize]
	public ValueInput comparisonValue;

	[DoNotSerialize]
	public ValueInput requiredTimeValue;

	protected override string DoneFieldName => "Flipped";

	protected override void InternalDefinition()
	{
		targetItem = ValueInput<GameObject>("Item", null);
		targetPage = ValueInput("Page", 0);
		comparisonValue = ValueInput("Comparison", ComparisonType.Equal);
		requiredTimeValue = ValueInput("Time", 1f);
		Requirement(targetItem, inputTrigger);
	}

	public override object PrepareContext(Flow flow)
	{
		Context context = new Context();
		GameObject value = flow.GetValue<GameObject>(targetItem);
		context.TPFW = value.AddComponent<TutorialPageFlipWrapper>();
		context.TPFW.CheckForPageFlip(on: true);
		context.TargetPage = flow.GetValue<int>(targetPage);
		context.Comparison = flow.GetValue<ComparisonType>(comparisonValue);
		context.RequiredTime = flow.GetValue<float>(requiredTimeValue);
		context.LastCheckTime = Time.time;
		return context;
	}

	public override void CleanupContext(Flow flow, object context)
	{
		Context obj = (Context)context;
		Object.Destroy(obj.TPFW);
		obj.TPFW = null;
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		float time = Time.time;
		float num = time - context2.LastCheckTime;
		context2.LastCheckTime = time;
		bool flag;
		switch (context2.Comparison)
		{
		case ComparisonType.Equal:
			flag = context2.TPFW.CurrentPage == context2.TargetPage;
			break;
		case ComparisonType.NotEqual:
			flag = context2.TPFW.CurrentPage != context2.TargetPage;
			break;
		case ComparisonType.GreaterOrEqual:
			flag = context2.TPFW.CurrentPage >= context2.TargetPage;
			break;
		case ComparisonType.LessOrEqual:
			flag = context2.TPFW.CurrentPage <= context2.TargetPage;
			break;
		default:
			flag = false;
			break;
		}
		if (flag)
		{
			if (context2.RequiredTime <= 0f)
			{
				return true;
			}
			context2.TimeElapsed += num;
			if (context2.TimeElapsed >= context2.RequiredTime)
			{
				return true;
			}
		}
		else
		{
			context2.TimeElapsed = 0f;
		}
		return false;
	}
}
