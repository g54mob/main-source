using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Lights
{
	public class LightMeshData : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("The mount X/Z size. This will be the XZ scale applied to the mount mesh.")]
		private Vector2 _mountSize = Vector2.zero;

		[SerializeField]
		[Tooltip("The sample points used to determine the bounds of the light mesh when rotated.")]
		private Vector3[] _samplePoints;

		[SerializeField]
		[Tooltip("The total width of the light mesh.")]
		private float _width;

		public Vector2 MountSize => _mountSize;

		public Vector3[] SamplePoints => _samplePoints;

		public float Width => _width;

		protected virtual void OnDrawGizmosSelected()
		{
			Gizmos.matrix = Matrix4x4.TRS(base.transform.position, base.transform.rotation, (base.transform.parent == null) ? Vector3.one : base.transform.parent.lossyScale);
			Gizmos.color = Color.blue;
			Gizmos.DrawWireCube(Vector3.zero, new Vector3(_width, 0.025f, 0.025f));
			Gizmos.color = Color.black;
			Gizmos.DrawWireCube(new Vector3(0f, (SamplePoints?.Min((Vector3 p) => p.y) ?? 0f) - 0.1f, 0f), new Vector3(_mountSize.x, 0.2f, _mountSize.y));
			Gizmos.color = Color.red;
			Vector3[] samplePoints = _samplePoints;
			for (int num = 0; num < samplePoints.Length; num++)
			{
				Gizmos.DrawWireSphere(samplePoints[num], 0.025f);
			}
		}
	}
}
