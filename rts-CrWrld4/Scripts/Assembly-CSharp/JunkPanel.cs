using System.Collections.Generic;
using UnityEngine;

public class JunkPanel : MonoBehaviour
{
	public class TerrainTree
	{
		private Vector3 _position;

		private Vector3 _scale;

		private Quaternion _rotation;

		public Matrix4x4 matrix;

		public Vector3 position
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 scale
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Quaternion rotation
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		public TerrainTree(Vector3 position, Quaternion rotation, Vector3 scale)
		{
		}

		private void UpdateMatrix()
		{
		}
	}

	public Mesh testMesh;

	public Material material;

	private Matrix4x4[] matrices;

	private Vector3 scale;

	private int count;

	private List<TerrainTree> terrainTrees;

	private MaterialPropertyBlock mpb;

	private void AddTree(Vector3 position, Quaternion rotation, Vector3 scale)
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
