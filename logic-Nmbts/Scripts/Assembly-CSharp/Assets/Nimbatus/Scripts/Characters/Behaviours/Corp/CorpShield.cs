using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Characters.Behaviours.Corp
{
	[RequireComponent(typeof(Collider))]
	public class CorpShield : MonoBehaviour
	{
		public float ScaleTime;

		private Vector3 _targetScale;

		[HideInInspector]
		public Collider ShieldCollider;

		public List<Collider> IgnoreColliders = new List<Collider>();

		public void Init()
		{
			_targetScale = base.transform.localScale;
			base.transform.localScale = Vector3.zero;
			ShieldCollider = GetComponent<Collider>();
			foreach (Collider ignoreCollider in IgnoreColliders)
			{
				Physics.IgnoreCollision(ShieldCollider, ignoreCollider);
			}
		}

		public void EngageShield()
		{
			StartCoroutine(GrowShield(ScaleTime));
		}

		public void DisengageShield()
		{
			StartCoroutine(ShrinkShield(ScaleTime));
		}

		private IEnumerator GrowShield(float time)
		{
			float t = 0f;
			while (t < 1f)
			{
				t += Time.deltaTime / time;
				base.transform.localScale = new Vector3(_targetScale.x * t, _targetScale.y * t, _targetScale.z * t);
				yield return null;
			}
			base.transform.localScale = _targetScale;
		}

		private IEnumerator ShrinkShield(float time)
		{
			float t = 1f;
			while (t > 0f)
			{
				t -= Time.deltaTime / time;
				base.transform.localScale = new Vector3(_targetScale.x * t, _targetScale.y * t, _targetScale.z * t);
				yield return null;
			}
			base.transform.localScale = Vector3.zero;
		}
	}
}
