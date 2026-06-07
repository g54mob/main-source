using UnityEngine;

namespace Assets.Scripts.XR.UI
{
	[RequireComponent(typeof(LineRenderer))]
	public class LaserRenderingScript : MonoBehaviour
	{
		public float dotSize;

		public Transform dotTransform;

		private Vector3? _customNormal;

		private MeshRenderer _dotMeshRenderer;

		private LineRenderer _lineRenderer;

		[SerializeField]
		private int _sortingOrder;

		public void SetLength(float length)
		{
			Vector3 vector = Vector3.forward * length;
			_lineRenderer.SetPosition(1, vector);
			dotTransform.localPosition = vector;
			UpdateDotScale();
			_lineRenderer.sortingOrder = _sortingOrder;
			if ((object)_dotMeshRenderer != null)
			{
				_dotMeshRenderer.sortingOrder = _sortingOrder;
			}
		}

		public void SetNormal(Vector3? normal)
		{
			_customNormal = normal;
			if (_customNormal.HasValue)
			{
				dotTransform.rotation = Quaternion.LookRotation(-normal.Value);
			}
		}

		protected virtual void Awake()
		{
			_lineRenderer = GetComponent<LineRenderer>();
			dotTransform.TryGetComponent<MeshRenderer>(out _dotMeshRenderer);
		}

		private void UpdateDotScale()
		{
			Vector3 forward = dotTransform.position - Camera.main.transform.position;
			dotTransform.localScale = Vector3.one * (dotSize * forward.magnitude);
			if (!_customNormal.HasValue)
			{
				dotTransform.rotation = Quaternion.LookRotation(forward);
			}
		}
	}
}
