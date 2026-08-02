using UnityEngine;

namespace JUTPS.GravitySwitchSystem
{
	[AddComponentMenu("JU TPS/Third Person System/Gravity Switcher/Gravity Sphere")]
	public class GravitySphere : MonoBehaviour
	{
		[Header("Settings")]
		public bool Activated;

		public float Radious = 10f;

		public float Force = 9.8f;

		[Header("AlignSettings")]
		public bool AlignRigidbodies;

		public float AlignForce = 35f;

		public float DistanceToStopAligning = 5f;

		public bool AlignJUTPSCharacters;

		private void Start()
		{
		}

		private void Update()
		{
			JUGravity.SimulateGravityPoint(base.transform.position, out var rblist, Radious, Force, AlignRigidbodies, DistanceToStopAligning, AlignForce);
			JUGravity.AlignJUTPSCharacterUpOrientation(base.transform.position, rblist, DistanceToStopAligning);
		}

		public static void Change(Vector3 GravityCenterPosition, float Radious = 10f, float GravityForce = 9.8f, bool AlignRigidBodies = false, float DistanceToStopAligning = 5f, float AlingForce = 35f)
		{
			Collider[] array = Physics.OverlapSphere(GravityCenterPosition, Radious);
			for (int i = 0; i < array.Length; i++)
			{
				Rigidbody component = array[i].GetComponent<Rigidbody>();
				if (component != null)
				{
					float num = Vector3.Distance(component.position, GravityCenterPosition);
					float num2 = component.mass / (num * Radious);
					Vector3 normalized = (component.position - GravityCenterPosition).normalized;
					component.AddForce(normalized * (100f * GravityForce * Time.deltaTime) * num2);
					if (num > DistanceToStopAligning && AlignRigidBodies)
					{
						component.transform.rotation = Quaternion.Lerp(component.transform.rotation, Quaternion.FromToRotation(component.transform.up, normalized) * component.transform.rotation, AlingForce * num2 * Time.deltaTime);
					}
				}
			}
		}

		public static void Change(Vector3 GravityCenterPosition, out Collider[] rblist, float Radious = 10f, float GravityForce = 9.8f, bool AlignRigidBodies = false, float DistanceToStopAligning = 5f, float AlingForce = 35f)
		{
			Collider[] array = (rblist = Physics.OverlapSphere(GravityCenterPosition, Radious));
			for (int i = 0; i < array.Length; i++)
			{
				Rigidbody component = array[i].GetComponent<Rigidbody>();
				if (component != null)
				{
					float num = Vector3.Distance(component.position, GravityCenterPosition);
					float num2 = component.mass / (num * Radious);
					Vector3 normalized = (component.position - GravityCenterPosition).normalized;
					component.AddForce(normalized * (100f * GravityForce * Time.deltaTime) * num2);
					if (num > DistanceToStopAligning && AlignRigidBodies)
					{
						component.transform.rotation = Quaternion.Lerp(component.transform.rotation, Quaternion.FromToRotation(component.transform.up, normalized) * component.transform.rotation, AlingForce * num2 * Time.deltaTime);
					}
				}
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = new Color(0f, 1f, 0f, 0.1f);
			Gizmos.DrawSphere(base.transform.position, Radious);
			Gizmos.color = new Color(0.5f, 1f, 0.5f, 0.3f);
			Gizmos.DrawWireSphere(base.transform.position, Radious);
			Gizmos.color = new Color(1f, 0f, 0f, 0.1f);
			Gizmos.DrawSphere(base.transform.position, DistanceToStopAligning);
			Gizmos.color = new Color(1f, 0.5f, 0.5f, 0.3f);
			Gizmos.DrawWireSphere(base.transform.position, DistanceToStopAligning);
		}
	}
}
