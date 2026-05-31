using System.Collections;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class VFXFlyDeadBody : MonoBehaviour
	{
		[SerializeField]
		[BoxGroup("Base Settings")]
		private float _vfxMaxDuration;

		public void InitDestroy()
		{
			base.gameObject.GetComponent<ParticleSystem>().Stop();
			StartCoroutine(LaunchDestroy());
		}

		private IEnumerator LaunchDestroy()
		{
			yield return Coroutines.WaitForSeconds(_vfxMaxDuration);
			Object.Destroy(base.gameObject);
			yield return null;
		}
	}
}
