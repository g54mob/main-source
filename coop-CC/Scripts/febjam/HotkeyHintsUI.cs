using Aggro.Core;
using Unity.Mathematics;
using UnityEngine;

public class HotkeyHintsUI : EntityBehaviourBase
{
	public RectTransform container;

	public RectTransform placeHintTransform;

	public RectTransform pickUpHintTransform;

	public RectTransform useHintTransform;

	public EaseUI pickUpEaseUI;

	public EaseUI placeEaseUI;

	public EaseUI useEaseUI;

	public EaseUI taptapEaseUI;

	public TipTapPhoneVisual tipTapPhoneVisual;

	protected override void OnUpdatePresentationLate()
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		if (GameUtil.TryGetLocalPlayer(out var player))
		{
			PlayerGrabber playerGrabber = player.GetObject<PlayerGrabber>();
			if (playerGrabber.grabState == PlayerGrabState.Grabbed)
			{
				if (playerGrabber.syncGrabTarget.TryGetObject<BoxStation>(out var _))
				{
					flag2 = true;
					placeHintTransform.localPosition = SetTargetPosition(playerGrabber.syncGrabTarget.transform.position);
				}
				if (playerGrabber.syncGrabTarget.TryGetObject<BoxExtinguisher>(out var _))
				{
					flag3 = true;
					useHintTransform.localPosition = SetTargetPosition(playerGrabber.syncGrabTarget.transform.position);
				}
				if (playerGrabber.syncGrabTarget.TryGetObject<BoxVacuum>(out var _))
				{
					flag3 = true;
					useHintTransform.localPosition = SetTargetPosition(playerGrabber.syncGrabTarget.transform.position);
				}
				if (playerGrabber.syncGrabTarget.TryGetObject<BoxBlower>(out var _))
				{
					flag3 = true;
					useHintTransform.localPosition = SetTargetPosition(playerGrabber.syncGrabTarget.transform.position);
				}
				BoxScrubber obj5 = null;
				if (playerGrabber.syncGrabTarget.TryGetObject<BoxScrubber>(out obj5) && obj5.showHotkeyHint)
				{
					flag3 = true;
					useHintTransform.localPosition = SetTargetPosition(playerGrabber.syncGrabTarget.transform.position);
				}
			}
			PlayerStationPlacer playerStationPlacer = player.GetObject<PlayerStationPlacer>();
			if (playerStationPlacer.pickUpCandidate.Exists())
			{
				Station obj6 = null;
				if (playerStationPlacer.pickUpCandidate.TryGetObject<Station>(out obj6))
				{
					flag = true;
					pickUpHintTransform.localPosition = SetTargetPosition(playerStationPlacer.transform.position);
				}
			}
		}
		flag4 = tipTapPhoneVisual.tiptapOpen;
		taptapEaseUI.show = flag4;
		pickUpEaseUI.show = false;
		placeEaseUI.show = false;
		useEaseUI.show = false;
		if (flag)
		{
			pickUpEaseUI.show = true;
		}
		else if (flag2)
		{
			placeEaseUI.show = true;
		}
		else if (flag3)
		{
			useEaseUI.show = true;
		}
	}

	private Vector2 SetTargetPosition(Vector3 worldPos)
	{
		Vector3 vector = GameUtil.mainCamera.WorldToScreenPoint(worldPos);
		vector *= math.sign(vector.z) / Options.renderScale;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(container, vector, GameUtil.uiCamera, out var localPoint);
		return localPoint;
	}
}
