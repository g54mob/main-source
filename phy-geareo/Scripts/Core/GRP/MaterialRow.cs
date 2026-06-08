using System;
using UnityEngine;

namespace GRP
{
	[Serializable]
	public class MaterialRow
	{
		public string key;

		public string name;

		public Material material;

		public float density;

		public PhysicsMaterial physicsMaterial;
	}
}
