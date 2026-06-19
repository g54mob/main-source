using Aggro.Core;
using Aggro.Core.Networking;
using UnityEngine.UI;

public class startShiftFloaterUI : EntityBehaviourBase
{
	public Image[] timerImages;

	public float exitTimeSeconds = 1f;

	protected override void OnUpdatePresentationEarly()
	{
		FloaterUI floaterUI = base.entity.GetObject<FloaterUI>();
		float secondsRemaining = NetworkAggroManagerBase<ShiftManager>.instance.secondsRemaining;
		if (secondsRemaining < exitTimeSeconds && GameUtil.GetCurrentRoomType() == RoomType.Warehouse)
		{
			floaterUI.SetVisibleThisFrame();
		}
		if (floaterUI.visible)
		{
			Image[] array = timerImages;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].fillAmount = secondsRemaining / NetworkAggroManagerBase<ShiftManager>.instance.organizationalDuration;
			}
		}
	}
}
