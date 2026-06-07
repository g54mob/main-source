using System.Collections;
using UnityEngine;

namespace DV.TestScenes.TunnelCollisionIgnore
{
	public class EnableAfterOneFrame : MonoBehaviour
	{
		public GameObject target;

		private IEnumerator Start()
		{
			yield return WaitFor.EndOfFrame;
			target.SetActive(value: true);
			Object.Destroy(this);
		}
	}
}
