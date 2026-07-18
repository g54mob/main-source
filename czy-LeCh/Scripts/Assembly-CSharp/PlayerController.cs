using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	public static PlayerController Instance;

	private GameControls gameControls;

	private Vector3 forward;

	private Vector3 right;

	[Header("Player Variables")]
	[SerializeField]
	private float moveSpeed;

	private float h;

	private float v;

	[SerializeField]
	private float minMaxValue;

	[SerializeField]
	private Vector3 startPosition;

	private void Awake()
	{
		Instance = this;
		gameControls = new GameControls();
	}

	private void OnEnable()
	{
		gameControls.Enable();
	}

	private void OnDisable()
	{
		gameControls.Disable();
	}

	private void Start()
	{
		forward = Camera.main.transform.forward;
		forward.y = 0f;
		forward = Vector3.Normalize(forward);
		right = Quaternion.Euler(0f, 90f, 0f) * forward;
	}

	private void Update()
	{
		if (!SettingsManager.Instance.IsSettingsOpen() && !TileUnlockController.Instance.TileUnlockCanvasActive())
		{
			GetInput();
			Move();
			if (Keyboard.current.gKey.isPressed)
			{
				ResetCameraPosition();
			}
		}
	}

	private void GetInput()
	{
		h = gameControls.Game.Move.ReadValue<Vector2>().x;
		v = gameControls.Game.Move.ReadValue<Vector2>().y;
	}

	private void Move()
	{
		Vector3 vector = right * moveSpeed * Time.deltaTime * h;
		Vector3 vector2 = forward * moveSpeed * 1.5f * Time.deltaTime * v;
		base.transform.position += vector;
		base.transform.position += vector2;
		float num = base.transform.position.x;
		float num2 = base.transform.position.z;
		if (num < 0f - minMaxValue)
		{
			num = 0f - minMaxValue;
		}
		if (num > minMaxValue)
		{
			num = minMaxValue;
		}
		if (num2 < 0f - minMaxValue)
		{
			num2 = 0f - minMaxValue;
		}
		if (num2 > minMaxValue)
		{
			num2 = minMaxValue;
		}
		base.transform.position = new Vector3(num, base.transform.position.y, num2);
		if (TutorialController.Instance.GetCurrentTutorialStep() == 1 && Vector3.Distance(base.transform.position, startPosition) >= 7f)
		{
			TutorialController.Instance.ShowNextTutorialStep();
		}
	}

	public void ResetCameraPosition()
	{
		base.transform.position = startPosition;
	}
}
