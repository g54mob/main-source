using System;
using System.Collections.Generic;
using UnityEngine;

namespace MagicaCloth2
{
	[Serializable]
	public class NormalAlignmentSettings : IValid, IDataValidate, ITransform
	{
		public enum AlignmentMode
		{
			None = 0,
			BoundingBoxCenter = 1,
			Transform = 2
		}

		public AlignmentMode alignmentMode;

		public Transform adjustmentTransform;

		public void DataValidate()
		{
		}

		public bool IsValid()
		{
			return false;
		}

		public NormalAlignmentSettings Clone()
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
