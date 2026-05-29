using System.Collections.Generic;
using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Demos
{
	[ExecuteAlways]
	[RequireComponent(typeof(IBlockModelProvider), typeof(MeshFilter), typeof(MeshRenderer))]
	public class BlockRenderer : MonoBehaviour
	{
		public bool CenterBlockModel;

		public bool UseAsCollider;

		private IBlockModelProvider blockModelProvider;

		private BlockModel blockModel;

		private int renderFaceCount;

		private List<Vector3> renderVertices = new List<Vector3>();

		private List<int> renderTriangles = new List<int>();

		private List<Color> renderColor = new List<Color>();

		private void Start()
		{
			GenerateBlockModelAndMesh();
		}

		private void GenerateBlockModelAndMesh()
		{
			if (blockModelProvider == null)
			{
				blockModelProvider = GetComponent<IBlockModelProvider>();
			}
			blockModel = blockModelProvider.GenerateBlockModel();
			GetComponent<MeshFilter>().sharedMesh = GenerateMesh();
			if (UseAsCollider)
			{
				GetComponent<MeshCollider>().sharedMesh = GetComponent<MeshFilter>().sharedMesh;
			}
		}

		private Block GetBlock(int _X, int _Y, int _Z)
		{
			if ((float)_X >= blockModel.Size.x || _X < 0 || (float)_Y >= blockModel.Size.y || _Y < 0 || (float)_Z >= blockModel.Size.z || _Z < 0)
			{
				return null;
			}
			int num = (int)((float)_X + blockModel.Size.x * ((float)_Y + blockModel.Size.y * (float)_Z));
			return blockModel.BlockArray[num];
		}

		private Mesh GenerateMesh()
		{
			renderFaceCount = 0;
			renderVertices.Clear();
			renderTriangles.Clear();
			renderColor.Clear();
			if (blockModel != null)
			{
				for (int i = 0; (float)i < blockModel.Size.x; i += Block.BlockSize)
				{
					for (int j = 0; (float)j < blockModel.Size.y; j += Block.BlockSize)
					{
						for (int k = 0; (float)k < blockModel.Size.z; k += Block.BlockSize)
						{
							Block block = GetBlock(i, j, k);
							GenerateBlockMesh(i, j, k, block);
						}
					}
				}
			}
			if (CenterBlockModel)
			{
				Vector3 vector = new Vector3(blockModel.Size.x / 2f, 0f, blockModel.Size.z / 2f);
				for (int l = 0; l < renderVertices.Count; l++)
				{
					renderVertices[l] -= vector;
				}
			}
			Mesh mesh = new Mesh();
			mesh.vertices = renderVertices.ToArray();
			mesh.triangles = renderTriangles.ToArray();
			mesh.colors = renderColor.ToArray();
			mesh.RecalculateNormals();
			return mesh;
		}

		private bool ShallRenderFace(int _X, int _Y, int _Z, Block _NeighbourBlock)
		{
			return _NeighbourBlock == null;
		}

		private void GenerateBlockMesh(int _X, int _Y, int _Z, Block _Block)
		{
			if (_Block != null)
			{
				Block block = GetBlock(_X, _Y + 1, _Z);
				if (ShallRenderFace(_X, _Y, _Z, block))
				{
					List<Vector3> collection = CubeTop(_X, _Y, _Z, _Block, Block.BlockSize);
					List<int> collection2 = CreateCubeFace();
					Color color = _Block.Color;
					renderVertices.AddRange(collection);
					renderTriangles.AddRange(collection2);
					renderColor.AddRange(new Color[4] { color, color, color, color });
				}
				block = GetBlock(_X, _Y - 1, _Z);
				if (ShallRenderFace(_X, _Y, _Z, block))
				{
					List<Vector3> collection3 = CubeBot(_X, _Y, _Z, _Block, Block.BlockSize);
					List<int> collection4 = CreateCubeFace();
					Color color2 = _Block.Color;
					renderVertices.AddRange(collection3);
					renderTriangles.AddRange(collection4);
					renderColor.AddRange(new Color[4] { color2, color2, color2, color2 });
				}
				block = GetBlock(_X + 1, _Y, _Z);
				if (ShallRenderFace(_X, _Y, _Z, block))
				{
					List<Vector3> collection5 = CubeEast(_X, _Y, _Z, _Block, Block.BlockSize);
					List<int> collection6 = CreateCubeFace();
					Color color3 = _Block.Color;
					renderVertices.AddRange(collection5);
					renderTriangles.AddRange(collection6);
					renderColor.AddRange(new Color[4] { color3, color3, color3, color3 });
				}
				block = GetBlock(_X - 1, _Y, _Z);
				if (ShallRenderFace(_X, _Y, _Z, block))
				{
					List<Vector3> collection7 = CubeWest(_X, _Y, _Z, _Block, Block.BlockSize);
					List<int> collection8 = CreateCubeFace();
					Color color4 = _Block.Color;
					renderVertices.AddRange(collection7);
					renderTriangles.AddRange(collection8);
					renderColor.AddRange(new Color[4] { color4, color4, color4, color4 });
				}
				block = GetBlock(_X, _Y, _Z + 1);
				if (ShallRenderFace(_X, _Y, _Z, block))
				{
					List<Vector3> collection9 = CubeNorth(_X, _Y, _Z, _Block, Block.BlockSize);
					List<int> collection10 = CreateCubeFace();
					Color color5 = _Block.Color;
					renderVertices.AddRange(collection9);
					renderTriangles.AddRange(collection10);
					renderColor.AddRange(new Color[4] { color5, color5, color5, color5 });
				}
				block = GetBlock(_X, _Y, _Z - 1);
				if (ShallRenderFace(_X, _Y, _Z, block))
				{
					List<Vector3> collection11 = CubeSouth(_X, _Y, _Z, _Block, Block.BlockSize);
					List<int> collection12 = CreateCubeFace();
					Color color6 = _Block.Color;
					renderVertices.AddRange(collection11);
					renderTriangles.AddRange(collection12);
					renderColor.AddRange(new Color[4] { color6, color6, color6, color6 });
				}
			}
		}

		private List<Vector3> CubeTop(float x, float y, float z, Block _Block, float _BlockSize)
		{
			return new List<Vector3>
			{
				new Vector3(x, y + _BlockSize, z + _BlockSize),
				new Vector3(x + _BlockSize, y + _BlockSize, z + _BlockSize),
				new Vector3(x + _BlockSize, y + _BlockSize, z),
				new Vector3(x, y + _BlockSize, z)
			};
		}

		private List<Vector3> CubeBot(float x, float y, float z, Block _Block, float _BlockSize)
		{
			return new List<Vector3>
			{
				new Vector3(x, y, z),
				new Vector3(x + _BlockSize, y, z),
				new Vector3(x + _BlockSize, y, z + _BlockSize),
				new Vector3(x, y, z + _BlockSize)
			};
		}

		private List<Vector3> CubeNorth(float x, float y, float z, Block _Block, float _BlockSize)
		{
			return new List<Vector3>
			{
				new Vector3(x + _BlockSize, y, z + _BlockSize),
				new Vector3(x + _BlockSize, y + _BlockSize, z + _BlockSize),
				new Vector3(x, y + _BlockSize, z + _BlockSize),
				new Vector3(x, y, z + _BlockSize)
			};
		}

		private List<Vector3> CubeEast(float x, float y, float z, Block _Block, float _BlockSize)
		{
			return new List<Vector3>
			{
				new Vector3(x + _BlockSize, y, z),
				new Vector3(x + _BlockSize, y + _BlockSize, z),
				new Vector3(x + _BlockSize, y + _BlockSize, z + _BlockSize),
				new Vector3(x + _BlockSize, y, z + _BlockSize)
			};
		}

		private List<Vector3> CubeSouth(float x, float y, float z, Block _Block, float _BlockSize)
		{
			return new List<Vector3>
			{
				new Vector3(x, y, z),
				new Vector3(x, y + _BlockSize, z),
				new Vector3(x + _BlockSize, y + _BlockSize, z),
				new Vector3(x + _BlockSize, y, z)
			};
		}

		protected virtual List<Vector3> CubeWest(float x, float y, float z, Block _Block, float _BlockSize)
		{
			return new List<Vector3>
			{
				new Vector3(x, y, z + _BlockSize),
				new Vector3(x, y + _BlockSize, z + _BlockSize),
				new Vector3(x, y + _BlockSize, z),
				new Vector3(x, y, z)
			};
		}

		private List<int> CreateCubeFace()
		{
			List<int> result = new List<int>
			{
				renderFaceCount * 4,
				renderFaceCount * 4 + 1,
				renderFaceCount * 4 + 2,
				renderFaceCount * 4,
				renderFaceCount * 4 + 2,
				renderFaceCount * 4 + 3
			};
			renderFaceCount++;
			return result;
		}
	}
}
