using System.Collections;
using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Characters.Behaviours.Bossfights
{
	public class Crusher : MonoBehaviour
	{
		public GameObject Pillar;

		public Vector3 EndPos;

		public float Delay;

		public float Duration;

		public string CloseSfx;

		public string OpenSfx;

		public bool Return;

		[ShowIf("Return", true)]
		public float Pause;

		private Vector3 _startPos;

		[HideInInspector]
		public bool IsReady;

		public void Start()
		{
			_startPos = Pillar.transform.localPosition;
			IsReady = true;
		}

		public void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.layer == RuntimeGlobals.NimbatusPlayer.gameObject.layer && IsReady)
			{
				StartCoroutine(Crush());
			}
		}

		private IEnumerator Crush()
		{
			IsReady = false;
			yield return new WaitForSeconds(Delay);
			if (!string.IsNullOrEmpty(CloseSfx))
			{
				AudioController.Play(CloseSfx);
			}
			float t = 0f;
			while (t < Duration)
			{
				t += Time.deltaTime;
				Pillar.transform.localPosition = Vector3.Lerp(_startPos, EndPos, t / Duration);
				yield return null;
			}
			if (Return)
			{
				yield return new WaitForSeconds(Pause);
				if (!string.IsNullOrEmpty(OpenSfx))
				{
					AudioController.Play(OpenSfx);
				}
				t = 0f;
				while (t < Duration)
				{
					t += Time.deltaTime;
					Pillar.transform.localPosition = Vector3.Lerp(EndPos, _startPos, t / Duration);
					yield return null;
				}
				IsReady = true;
			}
		}
	}
}
