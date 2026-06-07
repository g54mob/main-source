using System;
using System.Collections.Generic;
using UnityEngine;

namespace MagicaCloth2
{
	[Serializable]
	public class ClothSerializeData2 : IDataValidate, IValid, ITransform
	{
		[SerializeField]
		public ClothInitSerializeData initData;

		[SerializeField]
		public SelectionData selectionData;

		[NonSerialized]
		public Dictionary<Transform, VertexAttribute> boneAttributeDict;

		[NonSerialized]
		public List<VertexAttribute[]> vertexAttributeList;

		public PreBuildSerializeData preBuildData;

		public bool IsValid()
		{
			return false;
		}

		public void DataValidate()
		{
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public void GetUsedTransform(HashSet<Transform> transformSet)
		{
		}

		public void ReplaceTransform(Dictionary<MagicaObjectId, Transform> replaceDict)
		{
		}
	}
}
