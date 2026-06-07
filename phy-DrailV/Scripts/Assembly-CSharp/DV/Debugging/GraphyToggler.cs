using Tayx.Graphy;
using Tayx.Graphy.Utils;
using UnityEngine;

namespace DV.Debugging
{
	public class GraphyToggler : MonoBehaviour
	{
		public GameObject vr;

		public GameObject nonvr;

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.F11))
			{
				if ((bool)G_Singleton<GraphyManager>.Instance)
				{
					G_Singleton<GraphyManager>.Instance.ToggleActive();
				}
				else
				{
					Object.Instantiate(VRManager.IsVREnabled() ? vr : nonvr);
				}
			}
		}
	}
}
