using System.Collections;
using UnityEngine;

namespace Assets.Nimbatus.GUI.TravelEvents
{
	public class DistressSignalEffect : MonoBehaviour
	{
		public string SignalSound;

		private ParticleSystem _particleSystem;

		public void OnEnable()
		{
			StartCoroutine(EmitDistressSignal());
		}

		public void OnDisable()
		{
			StopCoroutine(EmitDistressSignal());
		}

		private IEnumerator EmitDistressSignal()
		{
			if (_particleSystem == null)
			{
				_particleSystem = GetComponent<ParticleSystem>();
			}
			while (true)
			{
				_particleSystem.Emit(1);
				yield return new WaitForSeconds(1f);
			}
		}
	}
}
