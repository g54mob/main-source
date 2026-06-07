using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Mesh/Material Lerp")]
	public class MaterialLerp : MonoBehaviour
	{
		public bool LerpOnEnable = true;

		public List<InternalMaterialLerp> materials;

		private void OnEnable()
		{
			if (LerpOnEnable)
			{
				Lerp();
			}
		}

		public virtual void Lerp()
		{
			StartCoroutine(Lerper());
		}

		private IEnumerator Lerper()
		{
			yield return null;
		}
	}
}
