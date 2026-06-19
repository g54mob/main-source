using Aggro.Core;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class TitlePlayer : EntityBehaviourBase
{
	private static readonly int PlayerAssigned = Animator.StringToHash("playerAssigned");

	public Animator animator;

	public GameObject namePlatePrefab;

	public GameObject namePlate;

	private NamePlateUI _ui;

	public Transform namePlateTransform;

	public PlayerColorManager playerColorManager;

	public Camera uiCamera;

	public Camera mainCamera;

	protected override void OnEntityCreated()
	{
		animator.SetBool(PlayerAssigned, value: true);
		namePlate = Object.Instantiate(namePlatePrefab, Vector3.zero, Quaternion.identity);
		_ui = namePlate.GetComponent<NamePlateUI>();
		_ui.canvas.worldCamera = uiCamera;
		_ui.playerColorManager = playerColorManager;
		_ui.player = namePlateTransform;
		_ui.nameTextUI.text = Platform.GetUserName();
		_ui.nameTextUI.overflowMode = TextOverflowModes.Overflow;
		_ui.readyUpParent.SetActive(value: false);
	}

	protected override void OnUpdatePresentation()
	{
		_ui.nameTextUI.transform.localPosition = SetTargetPosition(_ui.player.position + Vector3.up * _ui.offset);
		_ui.nameTextUI.color = playerColorManager.GetPlayerColor(ui: true);
	}

	private Vector2 SetTargetPosition(Vector3 worldPos)
	{
		Vector3 vector = mainCamera.WorldToScreenPoint(worldPos);
		vector *= math.sign(vector.z);
		RectTransformUtility.ScreenPointToLocalPointInRectangle(_ui.container, vector, uiCamera, out var localPoint);
		return localPoint;
	}

	protected override void OnEntityDestroyed()
	{
		if (namePlate != null)
		{
			Object.Destroy(namePlate);
			namePlate = null;
		}
	}
}
