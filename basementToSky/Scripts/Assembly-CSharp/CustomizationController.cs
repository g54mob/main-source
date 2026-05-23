using UnityEngine;
using UnityEngine.EventSystems;

public class CustomizationController : MonoBehaviour
{
	public GameObject rocket;

	public float sensitivity = 1.5f;

	private InputSystem_Actions input;

	private float rotationY;

	private float rotationX;

	private LayerMask installableLayer;

	private bool isDragging;

	private bool clickBlankedSpace;

	private bool isWingInstalling;

	private bool wingInstalling;

	private int mask;

	private int numOfWings = 1;

	private GameObject wing;

	private void Awake()
	{
		input = GameManager.S.player.playerInput;
		input.Player.MouseRightClick.started += delegate
		{
			clickBlankedSpace = true;
		};
		input.Player.MouseRightClick.canceled += delegate
		{
			clickBlankedSpace = false;
		};
		input.Player.MouseRightClick.canceled += delegate
		{
			isDragging = false;
		};
		input.Player.MouseLeftClick.started += delegate
		{
			wingInstalling = true;
		};
		input.Player.MouseLeftClick.canceled += delegate
		{
			wingInstalling = false;
		};
		mask = ~LayerMask.GetMask("Player");
	}

	private void Start()
	{
		installableLayer = LayerMask.GetMask("Interactable");
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
		if (!isDragging && clickBlankedSpace && !EventSystem.current.IsPointerOverGameObject())
		{
			isDragging = true;
		}
		if (isDragging)
		{
			TouchRocket();
		}
	}

	private void TouchRocket()
	{
		Vector2 mouseInput = GameManager.S.player.GetMouseInput();
		float angle = (0f - mouseInput.x) * sensitivity;
		float num = (0f - mouseInput.y) * sensitivity;
		rocket.transform.Rotate(Vector3.up, angle, Space.World);
		rocket.transform.Rotate(Camera.main.transform.right, 0f - num, Space.World);
	}
}
