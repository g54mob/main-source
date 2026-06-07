using System.Collections.Generic;
using UnityEngine;

namespace UMA.Dynamics.Examples
{
	public class ClothHelper : MonoBehaviour
	{
		public float distance;

		public float penetration;

		public float distanceMax;

		public float penetrationMax;

		public Texture2D clothWeightMap;

		[HideInInspector]
		public bool drawFlag;

		[HideInInspector]
		public Dictionary<Vector3, int> clothVerts;

		private Cloth m_Cloth;

		private float m_CubeLen;

		private void Start()
		{
		}

		private void OnDrawGizmos()
		{
		}

		public void SetAllClothContraints()
		{
		}
	}
}
