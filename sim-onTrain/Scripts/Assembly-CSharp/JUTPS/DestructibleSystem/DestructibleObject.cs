using System.Collections;
using JUTPS.FX;
using UnityEngine;

namespace JUTPS.DestructibleSystem
{
	[AddComponentMenu("JU TPS/Physics/Destructible")]
	public class DestructibleObject : MonoBehaviour
	{
		[Header("Destructible Settings")]
		[Range(0f, 50f)]
		public float Strength;

		public GameObject FracturedObject;

		public Vector3 PositionOffset;

		public float TimeToDestroy = 15f;

		private bool IsFractured;

		[Header("Destroy Events")]
		public bool DoSlowmotionWhenDestroy;

		public bool DoSlowmotionWhenPlayerIsJumping;

		[Header("FX")]
		public float TimeToFracture;

		public GameObject DestructionFX;

		private IEnumerator _DestroyObject()
		{
			if (!IsFractured)
			{
				if (FracturedObject != null)
				{
					Invoke("FractureThisObject", TimeToFracture);
					if (DestructionFX != null)
					{
						Object.Instantiate(DestructionFX, base.transform.position, base.transform.rotation, base.transform);
					}
				}
				else
				{
					Debug.LogWarning("There is no 'Fractured Object' linked in " + base.gameObject.name);
				}
				if (DoSlowmotionWhenDestroy)
				{
					JUSlowmotion.DoSlowMotion(0.1f, 5f);
				}
				if (DoSlowmotionWhenPlayerIsJumping && Object.FindObjectOfType<JUCharacterController>().IsJumping)
				{
					JUSlowmotion.DoSlowMotion(0.1f, 5f);
				}
			}
			yield return new WaitForEndOfFrame();
		}

		public void FractureThisObject()
		{
			if (!IsFractured)
			{
				GameObject obj = Object.Instantiate(FracturedObject, base.transform.position + PositionOffset, base.transform.rotation);
				Object.Destroy(base.gameObject, 0.01f);
				Object.Destroy(obj, TimeToDestroy);
				IsFractured = true;
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag == "Bullet")
			{
				StartCoroutine(_DestroyObject());
			}
		}

		private void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.tag == "Bullet")
			{
				StartCoroutine(_DestroyObject());
			}
			if (other.gameObject.TryGetComponent<Rigidbody>(out var component) && component.velocity.magnitude > 5f)
			{
				StartCoroutine(_DestroyObject());
			}
		}

		private void OnCollisionStay(Collision other)
		{
			if (other.gameObject.tag == "Bullet")
			{
				StartCoroutine(_DestroyObject());
			}
		}
	}
}
