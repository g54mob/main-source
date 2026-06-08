using System.Collections.Generic;
using Dorfromantik.UI;
using UnityEngine;
using UnityEngine.Serialization;

public class TutorialEvent_SetActive : TutorialEvent
{
	[SerializeField]
	private bool changeStateOnBegin = true;

	[SerializeField]
	private bool targetStateOnBegin = true;

	[FormerlySerializedAs("setInactiveOnFinish")]
	[SerializeField]
	private bool changeStateOnFinish = true;

	[SerializeField]
	private bool targetStateOnFinish;

	[SerializeField]
	private List<GameObject> targetObjects;

	[SerializeField]
	private List<HideableUi> targetUi;

	[SerializeField]
	private bool animate = true;

	[SerializeField]
	private bool lockUiOnBegin;

	[SerializeField]
	private bool targetLockState = true;

	public override void Begin()
	{
		if (!changeStateOnBegin)
		{
			return;
		}
		foreach (GameObject targetObject in targetObjects)
		{
			targetObject.SetActive(targetStateOnBegin);
		}
		foreach (HideableUi item in targetUi)
		{
			if (!targetLockState && lockUiOnBegin)
			{
				item.Lock(targetLockState);
			}
			item.Show(targetStateOnBegin, animate);
			if (targetLockState && lockUiOnBegin)
			{
				item.Lock(targetLockState);
			}
		}
	}

	public override void Finish()
	{
		if (!changeStateOnFinish)
		{
			return;
		}
		foreach (GameObject targetObject in targetObjects)
		{
			targetObject.SetActive(targetStateOnFinish);
		}
		foreach (HideableUi item in targetUi)
		{
			item.Show(targetStateOnBegin, animate);
		}
	}

	public override void Skip()
	{
		Begin();
		Finish();
	}
}
