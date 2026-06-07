using System.Collections;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Characters.Behaviours.Bossfights
{
	public class SnakeBossfightSpike : MonoBehaviour
	{
		public GameObject Spike;

		public Vector3 EndPos;

		public float Duration;

		public float ShakeAmplitude;

		public float ShakeSpeed;

		public string ShakeSound;

		public ParticleSystem ShakeParticleSystem;

		private Vector3 _initPos;

		private Vector3 _startPos;

		public void Start()
		{
			_initPos = Spike.transform.localPosition;
		}

		public void Activate(bool up)
		{
			_startPos = Spike.transform.localPosition;
			StartCoroutine(Move(up));
		}

		private IEnumerator Move(bool up)
		{
			Vector3 endPos = (up ? EndPos : _initPos);
			ShakeParticleSystem.Play();
			AudioController.Play(ShakeSound);
			float t = 0f;
			while (t < Duration)
			{
				t += Time.deltaTime;
				Spike.transform.localPosition = Vector3.Lerp(_startPos, endPos, t / Duration);
				float num = Mathf.PingPong(Time.time * (ShakeSpeed * (t / Duration)), 2f) - 1f;
				Spike.transform.localPosition += new Vector3(ShakeAmplitude * num, 0f, 0f);
				yield return null;
			}
			ShakeParticleSystem.Stop();
		}
	}
}
