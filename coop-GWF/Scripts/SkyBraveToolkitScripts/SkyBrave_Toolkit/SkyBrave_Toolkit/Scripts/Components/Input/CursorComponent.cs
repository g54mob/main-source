using UnityEngine;

namespace SkyBrave_Toolkit.SkyBrave_Toolkit.Scripts.Components.Input
{
	public class CursorComponent : MonoBehaviour
	{
		public void ChangeVisibilityOfCursor(bool state)
		{
			Cursor.visible = state;
		}

		public void LockCursor()
		{
			Cursor.lockState = CursorLockMode.Locked;
		}

		public void FreeCursorLockState()
		{
			Cursor.lockState = CursorLockMode.None;
		}

		public void ConfineCursorLockState()
		{
			Cursor.lockState = CursorLockMode.Confined;
		}

		public void ChangeTheAppearanceOfCursorTo(Texture2D customCursorTexture)
		{
			if (customCursorTexture != null)
			{
				Cursor.SetCursor(customCursorTexture, Vector2.zero, CursorMode.ForceSoftware);
			}
		}

		public void UpdateCursorPosition()
		{
			Vector3 vector = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
			base.transform.position = new Vector3(vector.x, vector.y, 0f);
		}
	}
}
