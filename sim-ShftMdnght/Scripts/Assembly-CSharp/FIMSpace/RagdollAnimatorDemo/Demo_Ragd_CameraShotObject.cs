using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_CameraShotObject : FimpossibleComponent
	{
		public GameObject ToShot;

		public float Velocity = 10f;

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray.origin, ray.direction, out var hitInfo))
				{
					Vector3 point = hitInfo.point;
					Rigidbody component = Object.Instantiate(ToShot).GetComponent<Rigidbody>();
					Vector3 vector = point - base.transform.position;
					vector.Normalize();
					component.position = base.transform.position + vector;
					component.AddForce(vector * Velocity, ForceMode.VelocityChange);
				}
			}
		}
	}
}
