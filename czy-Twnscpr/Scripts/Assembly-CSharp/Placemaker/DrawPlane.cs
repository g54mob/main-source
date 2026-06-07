using System.Collections.Generic;
using Placemaker.Quads;
using Unity.Mathematics;
using UnityEngine;

namespace Placemaker
{
	public class DrawPlane : MonoBehaviour
	{
		[SerializeField]
		private WorldMaster worldMaster;

		[SerializeField]
		private int2 lastHexPos;

		[SerializeField]
		private List<Quad> nodes;

		[SerializeField]
		private int hoverIndex;

		[SerializeField]
		private MeshFilter meshFilter;

		private Mesh mesh;

		private float2 camDir;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private bool AllowedQuad(Quad quad)
		{
			return false;
		}

		public void SetToHoverData()
		{
		}

		private void IterateUpdate()
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
