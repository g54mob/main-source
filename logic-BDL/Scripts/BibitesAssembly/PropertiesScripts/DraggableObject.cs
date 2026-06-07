using ManagementScripts;
using SimulationScripts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PropertiesScripts
{
	public class DraggableObject : MonoBehaviour
	{
		private UserControl controller;

		private Rigidbody2D rb;

		private Camera cam;

		public float speed = 10f;

		private bool isTargetable;

		private bool clicked;

		private float clickTime;

		private bool canDragObject;

		private void Start()
		{
			controller = UserControl.Instance;
			rb = GetComponent<Rigidbody2D>();
			isTargetable = GetComponent<TargetObjectOnClick>() != null;
			cam = Camera.main;
		}

		private void OnMouseOver()
		{
			if (!isTargetable || ChallengeManager.isChallenge || EventSystem.current.IsPointerOverGameObject())
			{
				return;
			}
			if (Input.GetMouseButtonDown(0))
			{
				clicked = true;
				clickTime = 0f;
			}
			if (Input.GetMouseButtonUp(0))
			{
				canDragObject = false;
				clicked = false;
			}
			if (clicked)
			{
				clickTime += Time.unscaledDeltaTime;
				if (!(clickTime < 0.15f))
				{
					canDragObject = true;
					clicked = false;
				}
			}
		}

		private void OnMouseDrag()
		{
			if (EventSystem.current.IsPointerOverGameObject() || ChallengeManager.isChallenge || (isTargetable && !canDragObject))
			{
				return;
			}
			Vector3 vector = cam.ScreenToWorldPoint(Input.mousePosition) - base.transform.position;
			vector.z = 0f;
			if (Input.GetKey(KeyCode.LeftControl))
			{
				if (Time.deltaTime > 0f && rb != null)
				{
					Vector3 vector2 = new Vector3(Screen.width, Screen.height, 0f);
					Vector3 vector3 = (Input.mousePosition - vector2 / 2f) / Mathf.Max(Screen.width, Screen.height) * 2f;
					Transform obj = base.transform;
					obj.up = (obj.up + (1f - vector3.magnitude) * speed / 2f * vector.normalized * Time.unscaledDeltaTime).normalized;
				}
				else
				{
					base.transform.up = vector.normalized;
				}
			}
			else if (!(controller != null) || (!controller.CompareTarget(base.gameObject) && UserControl.AllowControl))
			{
				if (Time.deltaTime > 0f && rb != null)
				{
					rb.linearVelocity = speed * vector / Time.timeScale;
				}
				else
				{
					base.transform.position += vector;
				}
			}
		}
	}
}
