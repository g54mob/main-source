using UnityEngine;

namespace MagicaCloth2
{
	public class AutoRotate : MonoBehaviour
	{
		public enum UpdateMode
		{
			Update = 0,
			FixedUpdate = 1
		}

		public Vector3 eulers;

		public Space space;

		[SerializeField]
		private UpdateMode updateMode;

		[SerializeField]
		[Range(0.1f, 5f)]
		private float interval;

		public bool useSin;

		private float time;

		protected void FixedUpdate()
		{
		}

		protected void Update()
		{
		}

		private void UpdatePosition(float dtime)
		{
		}
	}
}
