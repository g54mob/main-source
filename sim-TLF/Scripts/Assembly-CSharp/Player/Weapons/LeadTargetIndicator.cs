using UnityEngine;
using UnityEngine.UI;

namespace Player.Weapons
{
	public class LeadTargetIndicator : MonoBehaviour
	{
		[Header("Посилання")]
		[Tooltip("Ракетниця гравця — потрібна для зчитування швидкості снаряда та позиції дула.")]
		public RocketLauncher launcher;

		[Tooltip("Рухома ціль.")]
		public Transform target;

		[Header("HUD — маркер упередження")]
		[Tooltip("RectTransform маркера точки упередження (куди треба цілитись).")]
		public RectTransform leadMarkerRect;

		[Tooltip("Колір маркера коли рішення знайдено (ціль досяжна).")]
		public Color colorReachable = new Color(0.15f, 1f, 0.25f, 1f);

		[Tooltip("Колір маркера коли ціль недосяжна (рухається занадто швидко).")]
		public Color colorUnreachable = new Color(1f, 0.2f, 0.15f, 1f);

		[Header("HUD — маркер самої цілі (необов'язково)")]
		[Tooltip("RectTransform маркера поточної позиції цілі. Залиш порожнім якщо не потрібен.")]
		public RectTransform targetMarkerRect;

		[Header("Поведінка")]
		[Tooltip("Ховати маркер коли точка упередження виходить за межі екрана.")]
		public bool hideLeadWhenOffScreen = true;

		[Tooltip("Ховати маркер цілі коли вона за межами екрана.")]
		public bool hideTargetWhenOffScreen = true;

		[Tooltip("Враховувати гравітацію при розрахунку упередження.")]
		public bool accountForGravity = true;

		[Header("Gizmos")]
		public bool drawGizmos = true;

		private Camera _cam;

		private Graphic _leadGraphic;

		private Graphic _targetGraphic;

		private Vector3 _prevTargetPos;

		private Vector3 _cachedTargetVelocity;

		private bool _velocityInitialized;

		public Vector3 LeadPoint { get; private set; }

		public bool SolutionFound { get; private set; }

		private void Awake()
		{
			_cam = Camera.main;
			if (leadMarkerRect != null)
			{
				_leadGraphic = leadMarkerRect.GetComponent<Graphic>();
			}
			if (targetMarkerRect != null)
			{
				_targetGraphic = targetMarkerRect.GetComponent<Graphic>();
			}
		}

		private void LateUpdate()
		{
			if (target != null)
			{
				if (_velocityInitialized)
				{
					_cachedTargetVelocity = (target.position - _prevTargetPos) / Time.deltaTime;
				}
				_prevTargetPos = target.position;
				_velocityInitialized = true;
			}
			else
			{
				_velocityInitialized = false;
			}
		}

		private void Update()
		{
			if (target == null || launcher == null)
			{
				HideAll();
				return;
			}
			UpdateTargetMarker();
			SolutionFound = TryCalculateLeadPoint(out var leadPoint);
			LeadPoint = leadPoint;
			if (SolutionFound)
			{
				UpdateLeadMarker(leadPoint);
			}
			else
			{
				HideLeadMarker();
			}
		}

		public void SetTarget(Transform newTarget)
		{
			target = newTarget;
			_velocityInitialized = false;
		}

		public void ClearTarget()
		{
			target = null;
		}

		private bool TryCalculateLeadPoint(out Vector3 leadPoint)
		{
			leadPoint = target.position;
			Transform transform = ((launcher.muzzlePoint != null) ? launcher.muzzlePoint : launcher.transform);
			float initialSpeed = launcher.initialSpeed;
			Vector3 targetVelocity = GetTargetVelocity();
			Vector3 vector = target.position - transform.position;
			float a = Vector3.Dot(targetVelocity, targetVelocity) - initialSpeed * initialSpeed;
			float b = 2f * Vector3.Dot(vector, targetVelocity);
			float c = Vector3.Dot(vector, vector);
			float num = SolveQuadratic(a, b, c);
			if (num < 0f)
			{
				return false;
			}
			leadPoint = target.position + targetVelocity * num;
			if (accountForGravity)
			{
				float num2 = 9.81f * launcher.gravityScale;
				float num3 = 0.5f * num2 * num * num;
				leadPoint += Vector3.up * num3;
			}
			return true;
		}

		private static float SolveQuadratic(float a, float b, float c)
		{
			if (Mathf.Abs(a) < 1E-06f)
			{
				if (Mathf.Abs(b) < 1E-06f)
				{
					return -1f;
				}
				float num = (0f - c) / b;
				if (!(num >= 0f))
				{
					return -1f;
				}
				return num;
			}
			float num2 = b * b - 4f * a * c;
			if (num2 < 0f)
			{
				return -1f;
			}
			float num3 = Mathf.Sqrt(num2);
			float num4 = (0f - b - num3) / (2f * a);
			float num5 = (0f - b + num3) / (2f * a);
			if (num4 >= 0f && num5 >= 0f)
			{
				return Mathf.Min(num4, num5);
			}
			if (num4 >= 0f)
			{
				return num4;
			}
			if (num5 >= 0f)
			{
				return num5;
			}
			return -1f;
		}

		private Vector3 GetTargetVelocity()
		{
			Rigidbody component = target.GetComponent<Rigidbody>();
			if (component != null)
			{
				return component.linearVelocity;
			}
			if (!_velocityInitialized)
			{
				return Vector3.zero;
			}
			return _cachedTargetVelocity;
		}

		private void UpdateLeadMarker(Vector3 worldPoint)
		{
			if (leadMarkerRect == null)
			{
				return;
			}
			if (!TryWorldToScreen(worldPoint, out var screenPos))
			{
				if (hideLeadWhenOffScreen)
				{
					HideLeadMarker();
					return;
				}
				screenPos = ClampToScreenEdge(worldPoint);
			}
			leadMarkerRect.gameObject.SetActive(value: true);
			leadMarkerRect.position = screenPos;
			if (_leadGraphic != null)
			{
				_leadGraphic.color = colorReachable;
			}
		}

		private void UpdateTargetMarker()
		{
			if (targetMarkerRect == null)
			{
				return;
			}
			if (!TryWorldToScreen(target.position, out var screenPos))
			{
				if (hideTargetWhenOffScreen)
				{
					targetMarkerRect.gameObject.SetActive(value: false);
					return;
				}
				screenPos = ClampToScreenEdge(target.position);
			}
			targetMarkerRect.gameObject.SetActive(value: true);
			targetMarkerRect.position = screenPos;
		}

		private void HideLeadMarker()
		{
			if (leadMarkerRect != null)
			{
				if (_leadGraphic != null)
				{
					_leadGraphic.color = colorUnreachable;
				}
				leadMarkerRect.gameObject.SetActive(value: false);
			}
		}

		private void HideAll()
		{
			HideLeadMarker();
			if (targetMarkerRect != null)
			{
				targetMarkerRect.gameObject.SetActive(value: false);
			}
		}

		private bool TryWorldToScreen(Vector3 worldPos, out Vector2 screenPos)
		{
			screenPos = Vector2.zero;
			Vector3 vector = _cam.WorldToViewportPoint(worldPos);
			if (vector.z <= 0f || vector.x < 0f || vector.x > 1f || vector.y < 0f || vector.y > 1f)
			{
				return false;
			}
			screenPos = _cam.WorldToScreenPoint(worldPos);
			return true;
		}

		private Vector2 ClampToScreenEdge(Vector3 worldPos)
		{
			Vector3 vector = _cam.WorldToScreenPoint(worldPos);
			if (vector.z < 0f)
			{
				vector = -vector;
			}
			float num = 40f;
			vector.x = Mathf.Clamp(vector.x, num, (float)Screen.width - num);
			vector.y = Mathf.Clamp(vector.y, num, (float)Screen.height - num);
			return vector;
		}

		private void OnDrawGizmos()
		{
			if (drawGizmos && !(target == null) && Application.isPlaying)
			{
				if (SolutionFound)
				{
					Gizmos.color = colorReachable;
					Gizmos.DrawLine(((launcher != null && launcher.muzzlePoint != null) ? launcher.muzzlePoint : base.transform).position, LeadPoint);
					Gizmos.DrawWireSphere(LeadPoint, 0.35f);
					Gizmos.color = new Color(1f, 0.85f, 0f, 0.7f);
					Gizmos.DrawLine(target.position, LeadPoint);
				}
				else
				{
					Gizmos.color = colorUnreachable;
					Gizmos.DrawWireSphere(target.position, 0.5f);
				}
			}
		}

		internal void SetWeapon(RocketLauncher playerRocketLauncher)
		{
			launcher = playerRocketLauncher;
		}
	}
}
