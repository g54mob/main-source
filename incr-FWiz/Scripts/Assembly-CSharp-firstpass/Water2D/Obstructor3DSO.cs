using System;
using UnityEngine;

namespace Water2D
{
	[Serializable]
	public class Obstructor3DSO
	{
		public Transform source;

		public Transform obstructor;

		public MeshRenderer sourceRenderer;

		public MeshRenderer obstructorRenderer;

		public float size;

		public float minY;

		public Obstructor3DSO(Transform source, Transform obstructor, MeshRenderer sourceRenderer, MeshRenderer obstructorRenderer, float size, float minY)
		{
		}
	}
}
