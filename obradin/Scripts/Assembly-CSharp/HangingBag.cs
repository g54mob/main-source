using System;
using UnityEngine;

public class HangingBag : MonoBehaviour
{
	public enum Kind
	{
		Spring = 0,
		HingeX = 1,
		HingeY = 2,
		HingeZ = 3
	}

	[Serializable]
	public class Spec
	{
		public Kind kind;

		public float drag;

		public float mass = 5f;

		public float autoComRadius = 0.2f;
	}

	public Spec spec = new Spec();

	[Readonly]
	public float distToCom;

	private int gravityDelay;

	private Vector3 startingEulerAngles;

	private void Start()
	{
		gravityDelay = (int)(10f + UnityEngine.Random.value * 50f);
		startingEulerAngles = base.transform.localRotation.eulerAngles;
	}

	private void Update()
	{
		Vector3 gravityDir = WaveMotion.GetGravityDir(gravityDelay);
		Matrix4x4 matrix4x = Matrix4x4.TRS(Vector3.zero, Quaternion.LookRotation(gravityDir, base.transform.forward), Vector3.one);
		Matrix4x4 matrix4x2 = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(-90f, 0f, 0f), Vector3.one);
		Matrix4x4 matrix4x3 = matrix4x * matrix4x2;
		if (spec.kind == Kind.Spring)
		{
			float num = 4f;
			float num2 = distToCom;
			float num3 = Mathf.Sqrt(1f / num2);
			float num4 = (float)Math.PI * 2f / num3;
			float num5 = (Clock.play.time - (float)gravityDelay / 30f + 10f) % num4;
			float x = num * Mathf.Sin(num5 * num3);
			Matrix4x4 matrix4x4 = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(x, 0f, 0f), Vector3.one);
			matrix4x3 = matrix4x4 * matrix4x3;
			Quaternion rotation = Util.QuaternionFromMatrix(matrix4x3);
			base.transform.rotation = rotation;
			return;
		}
		Quaternion rotation2 = Util.QuaternionFromMatrix(matrix4x3);
		base.transform.rotation = rotation2;
		Vector3 euler = startingEulerAngles;
		if (spec.kind == Kind.HingeX)
		{
			euler.x = base.transform.localRotation.eulerAngles.x;
		}
		if (spec.kind == Kind.HingeY)
		{
			euler.y = base.transform.localRotation.eulerAngles.y;
		}
		if (spec.kind == Kind.HingeZ)
		{
			euler.z = base.transform.localRotation.eulerAngles.z;
		}
		base.transform.localRotation = Quaternion.Euler(euler);
	}

	private Bounds GetHierarchyBounds()
	{
		Bounds result = default(Bounds);
		bool flag = false;
		foreach (GameObject item in base.gameObject.AllDescendents())
		{
			Renderer component = item.GetComponent<Renderer>();
			if (!(component == null))
			{
				if (flag)
				{
					result.Encapsulate(component.bounds);
					continue;
				}
				result = component.bounds;
				flag = true;
			}
		}
		return result;
	}
}
