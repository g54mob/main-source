using Bolt;
using DV.Tutorial.QT;
using DV.UI;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitCategory("Tutorial")]
[UnitSubtitle("Resume when QuickTutorialInitiator does its thing")]
[TypeIcon(typeof(Coroutine))]
[UnitTitle("Wait For Tutorial Routine")]
public class WaitForLocoTutorialRoutineUnit : GenericWaitForCondition
{
	private class Context
	{
		public bool QTStarted;

		public bool QTComplete;

		public bool BlockersGone;
	}

	protected override void InternalDefinition()
	{
	}

	public override object PrepareContext(Flow flow)
	{
		return new Context();
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		Context context2 = (Context)context;
		if (!context2.QTStarted)
		{
			context2.QTStarted = QuickTutorialHost.IsTutorialRunning || SingletonBehaviour<QuickTutorialInitiator>.Instance.IsRoutineRunning;
		}
		else
		{
			if (!context2.QTComplete)
			{
				context2.QTComplete = !QuickTutorialHost.IsTutorialRunning && !SingletonBehaviour<QuickTutorialInitiator>.Instance.IsRoutineRunning;
				return false;
			}
			if (!context2.BlockersGone)
			{
				context2.BlockersGone = !SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Blockers);
			}
		}
		return context2.BlockersGone;
	}
}
