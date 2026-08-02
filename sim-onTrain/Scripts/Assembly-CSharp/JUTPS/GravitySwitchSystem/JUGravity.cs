using JUTPS.CharacterBrain;
using UnityEngine;

namespace JUTPS.GravitySwitchSystem
{
	public class JUGravity
	{
		public static void SimulateGravityPoint(Vector3 GravityCenterPosition, float Radious = 10f, float GravityForce = -200f, bool AlignRigidBodies = false, float DistanceToStopAligning = 5f, float AlignForce = 35f)
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
						component.transform.rotation = Quaternion.Lerp(component.transform.rotation, Quaternion.FromToRotation(component.transform.up, normalized) * component.transform.rotation, AlignForce * num2 * Time.deltaTime);
					}
				}
			}
		}

		public static void SimulateGravityPoint(Vector3 GravityCenterPosition, out Collider[] rblist, float Radious = 10f, float GravityForce = -200f, bool AlignRigidBodies = false, float DistanceToStopAligning = 5f, float AlignForce = 35f, string[] TagsToIgnore = null)
		{
			Collider[] array = (rblist = Physics.OverlapSphere(GravityCenterPosition, Radious));
			foreach (Collider collider in array)
			{
				if (TagsToIgnore != null)
				{
					foreach (string text in TagsToIgnore)
					{
						if (collider.tag == text)
						{
							return;
						}
					}
				}
				Rigidbody component = collider.GetComponent<Rigidbody>();
				if (component != null)
				{
					float num = Vector3.Distance(component.position, GravityCenterPosition);
					float num2 = component.mass / (num * Radious);
					Vector3 normalized = (component.position - GravityCenterPosition).normalized;
					component.AddForce(normalized * (100f * GravityForce * Time.deltaTime) * num2);
					if (num > DistanceToStopAligning && AlignRigidBodies)
					{
						component.transform.rotation = Quaternion.Lerp(component.transform.rotation, Quaternion.FromToRotation(component.transform.up, normalized) * component.transform.rotation, AlignForce * num2 * Time.deltaTime);
					}
				}
			}
		}

		public static void SimulateGravityBox(Vector3 BoxPosition, Vector3 BoxScale, Quaternion BoxOrientation, Vector3 GravityDirection, float GravityForce, bool AlignRigidBodies, float AlignForce, float DistanceToStopAligning, out Collider[] collider, string[] TagsToIgnore = null)
		{
			Collider[] array = (collider = Physics.OverlapBox(BoxPosition, BoxScale, BoxOrientation));
			foreach (Collider collider2 in array)
			{
				if (TagsToIgnore.Length != 0)
				{
					foreach (string text in TagsToIgnore)
					{
						if (collider2.tag == text)
						{
							return;
						}
					}
				}
				Rigidbody component = collider2.GetComponent<Rigidbody>();
				if (component != null)
				{
					float num = Vector3.Distance(component.position, BoxPosition);
					float num2 = component.mass / (num * 1f);
					Vector3 vector = -GravityDirection;
					component.AddForce(vector * (100f * GravityForce * Time.deltaTime) * num2);
					if (num > DistanceToStopAligning && AlignRigidBodies)
					{
						component.transform.rotation = Quaternion.Lerp(component.transform.rotation, Quaternion.FromToRotation(component.transform.up, vector) * component.transform.rotation, AlignForce * num2 * Time.deltaTime);
					}
				}
			}
		}

		public static void AlignJUTPSCharacterUpOrientation(Vector3 GravityCenterPosition, Collider[] collidersReturnedBySimulation, float DistanceToAlign)
		{
			foreach (Collider collider in collidersReturnedBySimulation)
			{
				JUCharacterBrain component = collider.GetComponent<JUCharacterBrain>();
				float num = Vector3.Distance(collider.transform.position, GravityCenterPosition);
				if (component != null && num < DistanceToAlign)
				{
					component.UpDirection = (collider.transform.position - GravityCenterPosition).normalized;
				}
			}
		}

		public static void AlignJUTPSCharacterUpOrientation(Collider[] collidersReturnedBySimulation, Vector3 UpOrientation)
		{
			for (int i = 0; i < collidersReturnedBySimulation.Length; i++)
			{
				JUCharacterBrain component = collidersReturnedBySimulation[i].GetComponent<JUCharacterBrain>();
				if (component != null)
				{
					component.UpDirection = UpOrientation;
				}
			}
		}
	}
}
