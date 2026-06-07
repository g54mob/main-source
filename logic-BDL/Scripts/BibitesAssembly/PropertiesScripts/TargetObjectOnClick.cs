using ManagementScripts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PropertiesScripts
{
	public class TargetObjectOnClick : MonoBehaviour
	{
		private TargetableObject targetableObject;

		private float clickTime;

		private bool clicked;

		public const float ClickThreshold = 0.15f;

		private void Awake()
		{
			targetableObject = GetComponent<TargetableObject>();
			if (targetableObject == null)
			{
				Object.Destroy(this);
			}
		}

		private void OnMouseOver()
		{
			if (!EventSystem.current.IsPointerOverGameObject())
			{
				if (Input.GetMouseButtonDown(0))
				{
					clicked = true;
					clickTime = 0f;
				}
				if (clicked)
				{
					clickTime += Time.unscaledDeltaTime;
				}
				if (Input.GetMouseButtonUp(0) && clickTime > 0f && clickTime < 0.15f)
				{
					UserControl.Instance.SelectTarget(base.gameObject);
				}
			}
		}
	}
}
