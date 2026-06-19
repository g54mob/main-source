using System.Collections;
using UnityEngine;

namespace Utilities
{
	public class SetParentAfterFrames : MonoBehaviour
	{
		[SerializeField]
		private int _frames = 1;

		public void SetParentAfter(Transform parent)
		{
			StartCoroutine(SetParentAfterCoroutine(_frames, parent));
		}

		private IEnumerator SetParentAfterCoroutine(int frames, Transform parent)
		{
			for (int i = 0; i < frames; i++)
			{
				yield return new WaitForEndOfFrame();
			}
			base.transform.SetParent(parent);
		}
	}
}
