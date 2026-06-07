using System;
using System.Collections.Generic;
using UnityEngine;

namespace MagicaCloth2
{
	[Serializable]
	public class CustomSkinningSettings : IValid, IDataValidate, ITransform
	{
		public bool enable;

		public List<Transform> skinningBones;

		public void DataValidate()
		{
		}

		public bool IsValid()
		{
			return false;
		}

		public CustomSkinningSettings Clone()
		{
			return null;
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
