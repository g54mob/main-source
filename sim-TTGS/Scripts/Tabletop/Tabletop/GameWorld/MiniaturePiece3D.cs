using Simulator.Preview3D;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class MiniaturePiece3D : MonoBehaviour, IPreview3DObject
	{
		[SerializeField]
		private Renderer[] m_renderers;

		public Vector2 NormalizedAnchor => Vector2.zero;

		Transform IPreview3DObject.transform => base.transform;

		public void Init(bool inUI)
		{
			if (!inUI)
			{
				return;
			}
			int preview3DLayer = MiniatureSettings.Preview3DLayer;
			Renderer[] renderers = m_renderers;
			foreach (Renderer renderer in renderers)
			{
				if (renderer != null)
				{
					renderer.gameObject.layer = preview3DLayer;
				}
			}
		}

		public void ResetRotation()
		{
			base.transform.rotation = Quaternion.identity;
		}

		public void Rotate(Vector2 delta)
		{
			if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
			{
				base.transform.Rotate(Vector3.up, delta.x);
			}
			else
			{
				base.transform.Rotate(Vector3.right, delta.y);
			}
		}
	}
}
