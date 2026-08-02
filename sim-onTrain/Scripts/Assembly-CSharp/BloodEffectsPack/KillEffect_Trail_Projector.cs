using System.Collections;
using UnityEngine;

namespace BloodEffectsPack
{
	public class KillEffect_Trail_Projector : MonoBehaviour
	{
		private void Start()
		{
			StartCoroutine(CheckForChildrenAndDestroy());
		}

		private IEnumerator CheckForChildrenAndDestroy()
		{
			do
			{
				yield return new WaitForSeconds(3f);
			}
			while (base.transform.childCount != 0);
			Object.Destroy(base.gameObject);
		}
	}
}
