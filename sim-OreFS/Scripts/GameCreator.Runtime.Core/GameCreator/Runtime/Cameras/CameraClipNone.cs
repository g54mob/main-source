using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	[Title("None")]
	[Category("None")]
	[Image(typeof(IconNull), ColorTheme.Type.TextLight)]
	[Description("Does not use any avoid clipping mechanism")]
	public class CameraClipNone : TCameraClip
	{
		public override Vector3 Update(TCamera camera, Vector3 point, Transform[] ignore)
		{
			return camera.transform.position;
		}

		public override void OnDrawGizmos(TCamera camera)
		{
		}
	}
}
