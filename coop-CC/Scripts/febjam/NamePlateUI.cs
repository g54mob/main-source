using Aggro.Core;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class NamePlateUI : EntityBehaviourBase
{
	public Transform player;

	public TextMeshProUGUI nameTextUI;

	public Entity playerEntity;

	public PlayerColorManager playerColorManager;

	public Canvas canvas;

	public RectTransform container;

	public float offset = 3f;

	public GameObject readyUpParent;

	public GameObject readyUpCheck;

	protected override void OnEntityCreated()
	{
		canvas.worldCamera = GameUtil.uiCamera;
	}

	protected override void OnUpdatePresentationLate()
	{
		readyUpParent.SetActive(GameUtil.isLobby);
		nameTextUI.transform.localPosition = SetTargetPosition(player.position + Vector3.up * offset);
		nameTextUI.color = playerColorManager.GetPlayerColor(ui: true);
		nameTextUI.overflowMode = TextOverflowModes.Overflow;
		if (playerEntity.TryGetObject<PlayerEffects>(out var obj))
		{
			container.gameObject.SetActive(!obj.syncInvisible);
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
