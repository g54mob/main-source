using UnityEngine;

namespace Utility.DeveloperMode
{
	public class DeveloperModeUI : MonoBehaviour
	{
		public static Transform tr;

		private void Awake()
		{
			tr = base.transform;
		}
	}
}
