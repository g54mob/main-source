using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Source.UI
{
	public class UIHelper
	{
		public static bool IsMouseOverUi => EventSystem.current?.IsPointerOverGameObject() ?? false;

		public static GameObject GetMouseOverGameObject()
		{
			Camera main = Camera.main;
			Vector3 vector = main.ScreenToWorldPoint(PlayerControls.MousePosition);
			vector.z = main.transform.position.z;
			return Physics2D.Raycast(vector, Vector2.zero).collider?.gameObject;
		}

		public static string HighlightText(string text)
		{
			return "<color=#FFD100>" + text + "</color>";
		}
	}
}
