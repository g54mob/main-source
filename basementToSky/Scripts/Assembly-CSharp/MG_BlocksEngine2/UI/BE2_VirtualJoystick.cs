using UnityEngine;

namespace MG_BlocksEngine2.UI
{
	public class BE2_VirtualJoystick : MonoBehaviour
	{
		public static BE2_VirtualJoystick instance;

		public BE2_VirtualJoystickButton[] keys = new BE2_VirtualJoystickButton[6];

		private void Awake()
		{
			instance = this;
			int num = 0;
			foreach (Transform item in base.transform.GetChild(0))
			{
				BE2_VirtualJoystickButton component = item.GetComponent<BE2_VirtualJoystickButton>();
				if (component != null)
				{
					keys[num] = component;
					num++;
				}
			}
		}
	}
}
