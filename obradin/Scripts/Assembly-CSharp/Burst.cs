using System;
using UnityEngine;

public class Burst : MonoBehaviour
{
	public enum Method
	{
		Sphere = 0,
		Flight = 1,
		ToChild = 2
	}

	[Serializable]
	public class Spec
	{
		public Method method;

		public Dust.Shade shade;

		public Transform transformA;

		public Transform transformB;

		public Mesh meshA;

		public Mesh meshB;

		public float density;

		public int flightSteps;

		public int flightLines;
	}

	public Spec spec;

	private void Start()
	{
	}
}
