using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	[CGDataInfo("#FFF59D")]
	public class CGGameObject : CGBounds
	{
		public GameObject Object;

		public Vector3 Translate;

		public Vector3 Rotate;

		public Vector3 Scale;

		public Matrix4x4 Matrix => default(Matrix4x4);

		public CGGameObject()
		{
		}

		public CGGameObject(CGGameObjectProperties properties)
		{
		}

		public CGGameObject(GameObject obj)
		{
		}

		public CGGameObject(GameObject obj, Vector3 translate, Vector3 rotate, Vector3 scale)
		{
		}

		public CGGameObject(CGGameObject source)
		{
		}

		public override T Clone<T>()
		{
			return null;
		}

		public override void RecalculateBounds()
		{
		}
	}
}
