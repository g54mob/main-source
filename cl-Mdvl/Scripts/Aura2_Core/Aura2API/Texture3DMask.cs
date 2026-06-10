using System;
using UnityEngine;

namespace Aura2API
{
	[Serializable]
	public struct Texture3DMask
	{
		public bool enable;

		[Texture3DPreview(true)]
		public Texture3D texture;

		public int textureIndex;

		public TransformParameters transform;

		public void SetDefaultValues()
		{
			transform.space = Space.Self;
			transform.position = Vector3.zero;
			transform.rotation = Vector3.zero;
			transform.scale = Vector3.one;
			textureIndex = -1;
		}
	}
}
