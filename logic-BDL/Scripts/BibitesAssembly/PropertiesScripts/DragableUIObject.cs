using UnityEngine;

namespace PropertiesScripts
{
	public class DragableUIObject : MonoBehaviour
	{
		private Rigidbody2D rb;

		private Camera cam;

		private bool clicked;

		private float clickTime;

		private void Start()
		{
			rb = GetComponent<Rigidbody2D>();
			cam = Camera.main;
		}

		private void OnMouseOver()
		{
			if (Input.GetMouseButtonDown(0))
			{
				clicked = true;
				clickTime = 0f;
			}
			if (Input.GetMouseButtonUp(0))
			{
				clicked = false;
			}
			if (clicked && !(clickTime < 0.15f))
			{
				clicked = false;
			}
		}

		private void Update()
		{
			if (clicked)
			{
				clickTime += Time.unscaledDeltaTime;
			}
		}

		private void OnMouseDrag()
		{
			Vector3 vector = cam.ScreenToWorldPoint(Input.mousePosition) - base.transform.position;
			vector.z = 0f;
			base.transform.position += vector;
		}
	}
}
