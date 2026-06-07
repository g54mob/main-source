using UnityEngine;

namespace FractureField
{
	[ExecuteAlways]
	[RequireComponent(typeof(Camera))]
	public class FixedAspectViewport : MonoBehaviour
	{
		[Tooltip("Desired aspect ratio as W:H")]
		public Vector2 targetAspect;

		private Camera cam;

		private int lastW;

		private int lastH;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void Apply()
		{
		}
	}
}
