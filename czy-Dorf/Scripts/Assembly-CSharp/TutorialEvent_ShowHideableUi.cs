using System.Collections.Generic;
using Dorfromantik.UI;
using UnityEngine;
using UnityEngine.Serialization;

public class TutorialEvent_ShowHideableUi : TutorialEvent
{
	[SerializeField]
	private List<HideableUi> targets;

	[SerializeField]
	[FormerlySerializedAs("showOnBegin")]
	private bool callOnBegin = true;

	[SerializeField]
	private bool targetStateOnBegin = true;

	[SerializeField]
	private bool lockOnBegin;

	[SerializeField]
	private bool hideOnFinish = true;

	[SerializeField]
	private bool animate = true;

	public override void Begin()
	{
		if (!callOnBegin)
		{
			return;
		}
		foreach (HideableUi target in targets)
		{
			target.Show(targetStateOnBegin, animate);
			if (lockOnBegin)
			{
				target.Lock(shouldLock: true);
			}
		}
	}

	public override void Finish()
	{
		if (!hideOnFinish)
		{
			return;
		}
		foreach (HideableUi target in targets)
		{
			target.Show(shouldShow: false, animate);
		}
	}

	public override void Skip()
	{
		Begin();
		Finish();
	}
}
