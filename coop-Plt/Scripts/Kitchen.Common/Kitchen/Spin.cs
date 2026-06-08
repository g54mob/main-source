using UnityEngine;

namespace Kitchen
{
	public class Spin : MonoBehaviour
	{
		public bool SpinDuringGameplay;

		public float SpinRate;

		protected float Rotation;

		private void Start()
		{
			Rotation = Random.Range(0, 360);
			base.transform.localRotation = Quaternion.AngleAxis(Rotation, Vector3.up);
		}

		protected virtual void Update()
		{
			if (SpinDuringGameplay)
			{
				base.transform.localRotation = Quaternion.AngleAxis(Rotation += SpinRate * Time.deltaTime, Vector3.up);
			}
		}
	}
}
