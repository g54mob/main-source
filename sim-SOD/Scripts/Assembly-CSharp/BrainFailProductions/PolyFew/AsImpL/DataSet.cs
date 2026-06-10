using System.Collections.Generic;
using UnityEngine;

namespace BrainFailProductions.PolyFew.AsImpL
{
	public class DataSet
	{
		public struct FaceIndices
		{
			public int vertIdx;

			public int uvIdx;

			public int normIdx;
		}

		public class ObjectData
		{
			public string name;

			public List<FaceGroupData> faceGroups;

			public List<FaceIndices> allFaces;

			public bool hasNormals;

			public bool hasColors;
		}

		public class FaceGroupData
		{
			public string name;

			public string materialName;

			public List<FaceIndices> faces;

			public bool IsEmpty => false;
		}

		public List<ObjectData> objectList;

		public List<Vector3> vertList;

		public List<Vector2> uvList;

		public List<Vector3> normalList;

		public List<Color> colorList;

		private int unnamedGroupIndex;

		private ObjectData currObjData;

		private FaceGroupData currGroup;

		private bool noFaceDefined;

		public string CurrGroupName => null;

		public bool IsEmpty => false;

		public static string GetFaceIndicesKey(FaceIndices fi)
		{
			return null;
		}

		public static string FixMaterialName(string mtlName)
		{
			return null;
		}

		public void AddObject(string objectName)
		{
		}

		public void AddGroup(string groupName)
		{
		}

		public void AddMaterialName(string matName)
		{
		}

		public void AddVertex(Vector3 vertex)
		{
		}

		public void AddUV(Vector2 uv)
		{
		}

		public void AddNormal(Vector3 normal)
		{
		}

		public void AddColor(Color color)
		{
		}

		public void AddFaceIndices(FaceIndices faceIdx)
		{
		}

		public void PrintSummary()
		{
		}
	}
}
