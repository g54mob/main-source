using System;
using UnityEngine;

public class Dust : MonoBehaviour
{
	public enum Method
	{
		None = 0,
		Mesh = 1,
		Sphere = 2,
		Faded = 3,
		Surface = 4,
		Texture = 5
	}

	public enum Shade
	{
		Invert = 0,
		Black = 1,
		White = 2
	}

	[Serializable]
	public class Spec
	{
		public Shade shade;

		public Method method;

		public Mesh mesh;

		public float randomOffset = 0.05f;

		public float sphereRadius = 1f;

		public int sphereCount = 500;

		public Texture2D texture;
	}

	public Spec spec;
}
