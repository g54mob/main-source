using SettingScripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace ManagementScripts
{
	public class CameraManager : MonoBehaviour
	{
		public static CameraManager instance;

		private Rigidbody2D rb;

		private Camera cam;

		private Vector2 md;

		public UserControl controller;

		public static UnityEvent OnCameraZoomChange = new UnityEvent();

		public static UnityEvent<float> onCameraSizeChange = new UnityEvent<float>();

		public static float camSize;

		private Vector3 panOrigin;

		private Vector3 pos;

		private GameObject followTarget;

		private bool hasTarget;

		private readonly Vector3 offset = new Vector3(0f, 0f, -855f);

		private float speed;

		public float scrollSpeed;

		public float startScrollDragHeight;

		private float speedScale = 1f;

		private Vector2 gradualInput = Vector2.zero;

		private Vector3 origin = Vector3.zero;

		private bool dragging;

		private static readonly FloatSetting SimulationSize = ScenarioIndependentSettings.Instance.SimulationSize;

		private static float simulationSize = SimulationSize.SubscribeTo<FloatSetting, float>(UpdateSimulationSize);

		private static void UpdateSimulationSize(float val)
		{
			simulationSize = val;
		}

		private void Awake()
		{
			instance = this;
			rb = GetComponent<Rigidbody2D>();
			cam = Camera.main;
		}

		private void Start()
		{
			controller.onTargetChange.AddListener(SetFollowTarget);
			camSize = cam.orthographicSize;
			speed = 0f;
			UserSettings.BackgroundColor.SubscribeTo<ColorUserSetting, Color>(UpdateBackgroundColor);
			ScenarioSettings.Instance.shadeOutsideOfBounds.SubscribeTo<BoolSetting, bool>(UpdateBackgroundColor);
			UpdateBackgroundColor();
		}

		public void UpdateBackgroundColor()
		{
			cam.backgroundColor = (ScenarioSettings.Instance.shadeOutsideOfBounds.val ? Color.black : UserSettings.BackgroundColor.val);
		}

		private void Update()
		{
			if (UserControl.AllowKeyboardControl && UserControl.AllowControl)
			{
				if (Input.GetKeyDown(KeyCode.PageUp))
				{
					speedScale *= 1.25f;
				}
				else if (Input.GetKeyDown(KeyCode.PageDown) || Input.GetKeyDown(KeyCode.KeypadMinus))
				{
					speedScale /= 1.25f;
				}
				if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.KeypadPlus))
				{
					CameraZoom(0.25f);
				}
				else if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus))
				{
					CameraZoom(-0.2f);
				}
				if (Input.GetKeyDown(KeyCode.Home))
				{
					controller.SelectTarget(null);
					cam.transform.position = origin + offset;
					gradualInput = Vector2.zero;
				}
			}
		}

		private void LateUpdate()
		{
			if (hasTarget && followTarget != null)
			{
				cam.transform.position = followTarget.transform.position + offset;
			}
			if (!UserControl.AllowControl || !UserControl.AllowKeyboardControl)
			{
				return;
			}
			Vector2 vector = Input.mousePosition;
			if (!(vector.x < 0f) && !(vector.y < 0f) && !(vector.x > (float)Screen.width) && !(vector.y > (float)Screen.height))
			{
				speed = cam.orthographicSize * speedScale;
				if (UserSettings.allowArrowKeyCameraControl.val)
				{
					ArrowsMove();
				}
				MouseDrag();
				MouseSlide();
				MouseScroll();
				MouseDragScroll();
			}
		}

		private void MouseDrag()
		{
			if (Input.GetMouseButton(1) && !Input.GetKey(KeyCode.LeftControl))
			{
				if (hasTarget)
				{
					controller.SelectTarget(null);
				}
				if (Input.GetMouseButtonDown(1))
				{
					dragging = true;
					panOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
				}
				if (Input.GetMouseButtonUp(1))
				{
					dragging = false;
				}
				if (dragging)
				{
					Vector3 vector = cam.ScreenToWorldPoint(Input.mousePosition) - panOrigin;
					cam.transform.position -= vector;
				}
			}
		}

		private void MouseSlide()
		{
			if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButton(1))
			{
				dragging = false;
				if (hasTarget)
				{
					controller.SelectTarget(null);
				}
				Vector2 vector = 2f * ((Vector2)Input.mousePosition - new Vector2(Screen.width, Screen.height) / 2f) / Screen.height;
				cam.transform.position += (Vector3)(vector * vector.magnitude * speed) * Time.deltaTime;
			}
		}

		private void MouseScroll()
		{
			if (!EventSystem.current.IsPointerOverGameObject())
			{
				md = Input.mouseScrollDelta;
				if (md.y != 0f)
				{
					CameraZoom(md.y / 10f * scrollSpeed);
				}
			}
		}

		private void MouseDragScroll()
		{
			if (Input.GetMouseButton(2))
			{
				if (Input.GetMouseButtonDown(2))
				{
					startScrollDragHeight = Input.mousePosition.y;
				}
				float num = (Input.mousePosition.y - startScrollDragHeight) / (float)Screen.height;
				CameraZoom(num * scrollSpeed * speedScale * Time.unscaledDeltaTime);
			}
		}

		private void ArrowsMove()
		{
			Vector2 vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
			if (vector == Vector2.zero)
			{
				gradualInput = Vector2.zero;
			}
			gradualInput += 2f * (vector - gradualInput) * Time.unscaledDeltaTime;
			cam.transform.position += (Vector3)gradualInput * speed * Time.unscaledDeltaTime;
		}

		private void CameraZoom(float ratio)
		{
			float num = camSize;
			num -= num * ratio;
			float num2 = 5f;
			float num3 = Mathf.Max(250f, 2f * simulationSize);
			if (num < num2)
			{
				num = num2;
			}
			if (num > num3)
			{
				num = num3;
			}
			camSize = num;
			cam.orthographicSize = camSize;
			OnCameraZoomChange.Invoke();
			onCameraSizeChange.Invoke(camSize);
		}

		public void SetCamSize(float val)
		{
			camSize = val;
			cam.orthographicSize = val;
		}

		private void SetFollowTarget(GameObject newTarget)
		{
			hasTarget = newTarget != null;
			followTarget = newTarget;
		}

		private void OnDestroy()
		{
			UserSettings.BackgroundColor.UnSubscribeTo<ColorUserSetting, Color>(UpdateBackgroundColor);
			ScenarioSettings.Instance.shadeOutsideOfBounds.UnSubscribeTo<BoolSetting, bool>(UpdateBackgroundColor);
			OnCameraZoomChange.RemoveAllListeners();
			onCameraSizeChange.RemoveAllListeners();
		}
	}
}
