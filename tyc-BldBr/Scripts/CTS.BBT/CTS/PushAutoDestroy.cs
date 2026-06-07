using System.Collections;
using UnityEngine;

namespace CTS
{
	public class PushAutoDestroy : MonoBehaviour
	{
		private float _timer = 30f;

		private void Start()
		{
			StartCoroutine(Timer());
		}

		private IEnumerator Timer()
		{
			yield return new WaitForSeconds(_timer);
			Object.Destroy(base.gameObject);
			yield return null;
		}
	}
}
