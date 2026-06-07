using UnityEngine;

public class WorldObjectUI : MonoBehaviour
{
	private enum EPosition
	{
		Top = 0,
		Center = 1,
		Bottom = 2
	}

	private GameObject followTarget;

	private RectTransform canvasTransform;

	private RectTransform rectTransform;

	[SerializeField]
	private Vector3 offset = Vector3.up;

	[SerializeField]
	private EPosition position;

	private Camera mainCamera;

	private Vector3 startOffset;

	private Vector3 ogScale;

	public GameObject FollowTarget
	{
		get
		{
			return followTarget;
		}
		set
		{
			followTarget = value;
		}
	}

	public Camera MainCamera
	{
		get
		{
			if (!mainCamera)
			{
				mainCamera = Camera.main;
			}
			return mainCamera;
		}
	}

	public Vector3 Offset
	{
		get
		{
			return offset;
		}
		set
		{
			offset = value;
		}
	}

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		ogScale = rectTransform.localScale;
		startOffset = Offset;
	}

	private void Start()
	{
		if ((bool)FollowTarget)
		{
			SetFollowTarget(FollowTarget);
		}
		if ((bool)GameManager.instance.PlayerController)
		{
			if ((bool)GameManager.instance.PlayerController.CurrentHUD)
			{
				canvasTransform = GameManager.instance.PlayerController.CurrentHUD.gameObject.GetComponent<RectTransform>();
				base.transform.SetParent(GameManager.instance.PlayerController.CurrentHUD.WorldObjectsContainer.transform);
			}
			GameManager.instance.PlayerController.onSpawnHUD += OnHUDSpawned;
		}
		GameManager.instance.onSpawnPlayer += OnPlayerSpawned;
		rectTransform.localScale = ogScale;
	}

	private void LateUpdate()
	{
		if ((bool)FollowTarget && (bool)canvasTransform && canvasTransform.gameObject.activeSelf)
		{
			UpdatePosition();
		}
	}

	private void OnDestroy()
	{
		GameManager.instance.PlayerController.onSpawnHUD -= OnHUDSpawned;
		GameManager.instance.onSpawnPlayer -= OnPlayerSpawned;
	}

	public void SetFollowTarget(GameObject target)
	{
		FollowTarget = target;
		if ((bool)FollowTarget)
		{
			offset.y = startOffset.y;
			switch (position)
			{
			case EPosition.Top:
				offset.y += FunctionLibrary.GetObjectHeight(FollowTarget);
				break;
			case EPosition.Center:
				offset.y += FunctionLibrary.GetObjectHeight(FollowTarget) * 0.5f;
				break;
			}
		}
	}

	private void UpdatePosition()
	{
		if (Vector3.Angle(MainCamera.transform.forward, FollowTarget.transform.position - MainCamera.transform.position) < 90f)
		{
			Vector2 vector = MainCamera.WorldToViewportPoint(FollowTarget.transform.position + Offset);
			Vector2 anchoredPosition = new Vector2(vector.x * canvasTransform.sizeDelta.x - canvasTransform.sizeDelta.x * 0.5f, vector.y * canvasTransform.sizeDelta.y - canvasTransform.sizeDelta.y * 0.5f);
			rectTransform.anchoredPosition = anchoredPosition;
		}
		else
		{
			rectTransform.anchoredPosition = new Vector2(-10000f, 0f);
		}
	}

	private void OnPlayerSpawned(Character character, PlayerController playerController, Character oldCharacter, PlayerController oldPlayerController)
	{
		if ((bool)oldPlayerController)
		{
			oldPlayerController.onSpawnHUD -= OnHUDSpawned;
		}
		if ((bool)playerController.CurrentHUD)
		{
			canvasTransform = playerController.CurrentHUD.gameObject.GetComponent<RectTransform>();
			base.transform.SetParent(playerController.CurrentHUD.WorldObjectsContainer.transform);
		}
		playerController.onSpawnHUD += OnHUDSpawned;
		rectTransform.localScale = ogScale;
	}

	private void OnHUDSpawned(HUD hud)
	{
		canvasTransform = hud.gameObject.GetComponent<RectTransform>();
		base.transform.SetParent(hud.WorldObjectsContainer.transform);
		rectTransform.localScale = ogScale;
	}
}
