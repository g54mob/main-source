using Bolt;
using Ludiq;
using UnityEngine;

[UnitSubtitle("Flip through the pages of a booklet")]
[UnitCategory("Interaction")]
[TypeIcon(typeof(SphereCollider))]
[UnitTitle("Flip Pages")]
public class FlipPagesUnit : GenericWaitForConditionWithMessage
{
	private class Context
	{
		public TutorialPageFlipWrapper TPFW;

		public bool Flipped;

		public void OnTutorialBookletPageFlipped(InventoryItemSpec item)
		{
			Flipped = true;
		}
	}

	[DoNotSerialize]
	public ValueInput targetItem;

	protected override string DoneFieldName => "Flipped";

	protected override string AnchorFieldName => string.Empty;

	protected override string OffsetFieldName => string.Empty;

	protected override void InternalDefinition()
	{
		targetItem = ValueInput<GameObject>("Item", null);
	}

	public override object PrepareContext(Flow flow)
	{
		Context context = new Context();
		GameObject value = flow.GetValue<GameObject>(targetItem);
		context.TPFW = value.AddComponent<TutorialPageFlipWrapper>();
		context.TPFW.CheckForBookletOpen(on: true);
		context.TPFW.BookletOpen += context.OnTutorialBookletPageFlipped;
		return context;
	}

	public override void CleanupContext(Flow flow, object context)
	{
		Context context2 = (Context)context;
		context2.TPFW.BookletOpen -= context2.OnTutorialBookletPageFlipped;
		Object.Destroy(context2.TPFW);
		context2.TPFW = null;
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		return ((Context)context).Flipped;
	}
}
