using System.Collections;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MeleeWeapons
{
	public class Bumper : MeleeWeapon
	{
		public float BumpForce;

		public const float SpeedFactor = 0.25f;

		public Renderer BumpSprite;

		public float AnimTime;

		public AnimationCurve XScale;

		public AnimationCurve YScale;

		public string HitSound;

		private Coroutine _coroutine;

		public override void OnCollisionEnter(Collision col)
		{
			ContactPoint contactPoint = col.contacts[0];
			Collider otherCollider = contactPoint.otherCollider;
			if (DealDamage(otherCollider.gameObject, Damage))
			{
				Vector3 velocity = Rigidbody.velocity;
				Vector3 vector = ((otherCollider.attachedRigidbody != null) ? otherCollider.attachedRigidbody.velocity : Vector3.zero);
				float num = Mathf.Sqrt((velocity - vector).magnitude) * 0.25f;
				Vector3 vector2 = (contactPoint.point - base.transform.position).normalized * BumpForce;
				if (num >= 1f)
				{
					vector2 *= num;
				}
				if (IsBroken)
				{
					vector2 *= 0.1f;
				}
				if (otherCollider.attachedRigidbody != null)
				{
					otherCollider.attachedRigidbody.AddForceAtPosition(vector2, contactPoint.point, ForceMode.Impulse);
				}
				Rigidbody.AddForceAtPosition(-vector2 * 0.25f, contactPoint.point, ForceMode.Impulse);
				if (!string.IsNullOrEmpty(HitSound))
				{
					AudioController.Play(HitSound);
				}
				if (_coroutine != null)
				{
					StopCoroutine(_coroutine);
				}
				_coroutine = StartCoroutine(_Bump());
			}
		}

		private IEnumerator _Bump()
		{
			float t = 0f;
			while (t < 1f)
			{
				t += Time.deltaTime / AnimTime;
				BumpSprite.transform.localScale = new Vector3(XScale.Evaluate(t), YScale.Evaluate(t), 1f);
				yield return null;
			}
			BumpSprite.transform.localScale = Vector3.one;
		}
	}
}
