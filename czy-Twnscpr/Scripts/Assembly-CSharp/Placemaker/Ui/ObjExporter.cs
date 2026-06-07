using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Placemaker.Ui
{
	public class ObjExporter : MonoBehaviour
	{
		[Serializable]
		private class MaterialToExport
		{
			public string exportName;

			public bool canBeProp;

			public bool canBeModule;

			public List<Material> materials;
		}

		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		private MaterialToExport[] materialsToExport;

		private string outputString;

		private string mtlString;

		private Texture2D textureToExport;

		public void Export()
		{
		}

		private void Action(string objPath)
		{
		}

		private void Do(string mtlName)
		{
		}

		private void AddMesh(string materialName, MeshFilter mf, Matrix4x4 matrix, List<Vector3> srcVerts, List<Vector2> srcUvs, List<Vector3> srcNormals, List<Vector4> srcTangents, List<int> srcTris, List<int> dstTris, List<string> vertStrings, List<string> uvStrings, List<string> normalstrings, Dictionary<Vector3, int> vertDict, Dictionary<Vector2, int> uvDict, Dictionary<Vector3, int> normalDict, ref int vertCount, ref int normalCount, ref int uvCount, ref string outputString, CultureInfo format)
		{
		}
	}
}
