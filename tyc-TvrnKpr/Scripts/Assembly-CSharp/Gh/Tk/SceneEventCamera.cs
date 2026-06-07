using UnityEngine;

namespace Gh.Tk
{
	public class SceneEventCamera : EventCamera
	{
		public override float RenderFPS { get; set; }

		protected override void Awake()
		{
		}

		protected override void Update()
		{
		}

		public override void EnableCamera()
		{
		}

		public override void DisableCamera()
		{
		}

		public override bool IsCameraUpdating()
		{
			return false;
		}

		public override void SetFollowTarget(Transform target)
		{
		}
	}
}
