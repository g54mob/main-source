using System;
using System.Collections.Generic;
using UnityEngine;

namespace Technie.PhysicsCreator
{
	[Serializable]
	public class Hull
	{
		public string name = "<unnamed hull>";

		public bool isVisible = true;

		public HullType type = HullType.ConvexHull;

		public Color colour = Color.white;

		public PhysicMaterial material;

		public bool enableInflation;

		public float inflationAmount = 0.01f;

		public bool isTrigger;

		public bool isChildCollider;

		public List<int> selectedFaces = new List<int>();

		public Mesh collisionMesh;

		public Mesh faceCollisionMesh;

		public Bounds collisionBox;

		public Sphere collisionSphere;

		public bool hasColliderError;

		public int numColliderFaces;

		public void Destroy()
		{
		}
	}
}
