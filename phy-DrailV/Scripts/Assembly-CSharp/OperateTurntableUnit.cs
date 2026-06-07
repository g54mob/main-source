using Bolt;
using Ludiq;
using UnityEngine;

[UnitTitle("Operate Turntable")]
[UnitCategory("Interaction")]
[TypeIcon(typeof(SphereCollider))]
[UnitSubtitle("Operate a turntable and wait for it to snap to a position")]
public class OperateTurntableUnit : GenericWaitForConditionWithMessage
{
	private class Context
	{
		public GameObject TrackReference;

		public TutorialTurnTableFinder TurnTableFinder;

		public RailTrack OffTurntableTrack;

		public bool Snapped;

		public void OnSnapped()
		{
			Snapped = true;
		}

		public void OnTracksUpdated(RailTrack frontTrack, RailTrack backTrack)
		{
			if ((frontTrack != null && frontTrack == OffTurntableTrack) || (backTrack != null && backTrack == OffTurntableTrack))
			{
				Snapped = true;
			}
		}
	}

	[DoNotSerialize]
	public ValueInput turntableFinderObject;

	[DoNotSerialize]
	public ValueInput trackReferenceObject;

	protected override string DoneFieldName => "Snapped";

	protected override string AnchorFieldName => "Attention";

	protected override void InternalDefinition()
	{
		turntableFinderObject = ValueInput<GameObject>("Turntable", null);
		trackReferenceObject = ValueInput<GameObject>("Track", null);
	}

	public override object PrepareContext(Flow flow)
	{
		Context context = new Context
		{
			TrackReference = flow.GetValue<GameObject>(trackReferenceObject),
			TurnTableFinder = flow.GetValue<GameObject>(turntableFinderObject).GetComponent<TutorialTurnTableFinder>()
		};
		context.TurnTableFinder.Initialize();
		if (context.TrackReference == null)
		{
			context.TurnTableFinder.controller.Snapped += context.OnSnapped;
		}
		else
		{
			context.OffTurntableTrack = CarSpawner.GetTrackClosestTo(context.TrackReference.transform.position, 1f, out var _);
			context.TurnTableFinder.controller.turntable.TracksUpdated += context.OnTracksUpdated;
		}
		return context;
	}

	public override void CleanupContext(Flow flow, object context)
	{
		Context context2 = (Context)context;
		if (context2.TrackReference == null)
		{
			context2.TurnTableFinder.controller.Snapped -= context2.OnSnapped;
		}
		else
		{
			context2.TurnTableFinder.controller.turntable.TracksUpdated -= context2.OnTracksUpdated;
		}
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		return ((Context)context).Snapped;
	}
}
