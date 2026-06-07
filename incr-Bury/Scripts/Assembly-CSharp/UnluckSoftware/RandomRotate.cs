using UnityEngine;

namespace UnluckSoftware
{
	public class RandomRotate : MonoBehaviour
	{
		private Quaternion rotTarget;

		public float rotateEverySecond = 1f;

		private float lerpCounter;

		public void Start()
		{
			randomRot();
			InvokeRepeating("randomRot", 0f, rotateEverySecond);
		}

		public void Update()
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, rotTarget, lerpCounter * Time.deltaTime);
			lerpCounter += 1f;
		}

		public void randomRot()
		{
			rotTarget = Random.rotation;
			lerpCounter = 0f;
		}
	}
}
