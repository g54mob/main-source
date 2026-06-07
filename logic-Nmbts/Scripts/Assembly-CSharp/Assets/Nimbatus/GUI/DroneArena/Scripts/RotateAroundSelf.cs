using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneArena.Scripts
{
	public class RotateAroundSelf : MonoBehaviour
	{
		public float Speed = 40f;

		public void Update()
		{
			base.transform.Rotate(-Vector3.forward, Speed * Time.deltaTime);
		}
	}
}
