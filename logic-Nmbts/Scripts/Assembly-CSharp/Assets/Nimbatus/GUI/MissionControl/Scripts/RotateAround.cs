using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts
{
	public class RotateAround : MonoBehaviour
	{
		public void Update()
		{
			base.transform.RotateAround(base.transform.parent.position, -Vector3.forward, 40f * Time.deltaTime);
		}
	}
}
