using UnityEngine;

namespace DV.UI.ContextMenu
{
	public abstract class AHUDTurntableProvider : MonoBehaviour
	{
		public abstract void Move(bool right);

		public abstract Vector2 GetScreenCoords();
	}
}
