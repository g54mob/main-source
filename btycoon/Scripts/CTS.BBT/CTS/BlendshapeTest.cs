using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	public class BlendshapeTest : MonoBehaviour
	{
		public float range;

		private Mesh m;

		private SkinnedMeshRenderer skm;

		private int nBs;

		public int iBSToChange;

		public List<string> bsNames;

		public List<float> bsValues;

		private void Start()
		{
			skm = GetComponent<SkinnedMeshRenderer>();
			m = skm.sharedMesh;
			nBs = m.blendShapeCount;
			for (int i = 0; i < nBs; i++)
			{
				MonoBehaviour.print("BS[" + i + "] " + m.GetBlendShapeName(i) + " : " + skm.GetBlendShapeWeight(i));
				bsValues.Add(skm.GetBlendShapeWeight(i));
			}
		}

		private void LateUpdate()
		{
			for (int i = 0; i < bsValues.Count; i++)
			{
				skm.SetBlendShapeWeight(i, bsValues[i]);
			}
		}
	}
}
