using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class DEMO_LegsAnim_SinusMove : MonoBehaviour
	{
		public Vector3 Offset = Vector3.right;

		public float Speed = 1f;

		private Vector3 startPos;

		private float elapsed;

		private void Start()
		{
			startPos = base.transform.position;
		}

		private void Update()
		{
			elapsed += Time.deltaTime * Speed;
			base.transform.position = startPos + Offset * Mathf.Sin(elapsed);
		}
	}
}
