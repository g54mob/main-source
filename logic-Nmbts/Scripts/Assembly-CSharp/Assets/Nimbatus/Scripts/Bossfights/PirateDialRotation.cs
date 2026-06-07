using System.Collections;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Bossfights
{
	public class PirateDialRotation : MonoBehaviour
	{
		public class PiratePart
		{
			public Transform Part;

			public float RotSpeed;

			public float RotTime;
		}

		public float MaxRotationSpeed;

		public float MaxRotationTime;

		public void Start()
		{
			foreach (Transform item in base.transform)
			{
				PiratePart piratePart = new PiratePart();
				piratePart.Part = item;
				piratePart.RotSpeed = Random.Range(0f - MaxRotationSpeed, MaxRotationSpeed);
				piratePart.RotTime = Random.Range(0f, MaxRotationTime);
				StartCoroutine(RotatePart(piratePart));
			}
		}

		private IEnumerator RotatePart(PiratePart part)
		{
			float t = 0f;
			while (true)
			{
				t += Time.deltaTime;
				if (t < part.RotTime)
				{
					part.Part.Rotate(0f, 0f, part.RotSpeed * (Mathf.Cos(t * 3.1415f) + 1f) / 2f);
				}
				else
				{
					t = 0f;
					part.RotSpeed = Random.Range(0f - MaxRotationSpeed, MaxRotationSpeed);
					part.RotTime = Random.Range(0f, MaxRotationTime);
				}
				yield return null;
			}
		}
	}
}
