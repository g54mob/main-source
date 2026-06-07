using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class AutoUpdateUiLayout : MonoBehaviour
	{
		public List<UIRect> Rects;

		public void OnEnable()
		{
			StartCoroutine(UpdateLayout());
		}

		public void OnDisable()
		{
			StopAllCoroutines();
		}

		private IEnumerator UpdateLayout()
		{
			while (true)
			{
				Rects.ForEach(delegate(UIRect r)
				{
					r.ResetAndUpdateAnchors();
				});
				yield return new WaitForSeconds(0.1f);
			}
		}
	}
}
