using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet
{
	public class JetEngineComponentScript : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("The bounds size.")]
		private Vector3 _boundsSize;

		[SerializeField]
		[Tooltip("The end offset.")]
		private float _length;

		private Transform _transform;

		public Vector3 EndPosition => base.transform.localPosition - new Vector3(0f, 0f, _length * LengthScale);

		public float Length => _boundsSize.y;

		public float LengthScale => base.transform.localScale.z;

		public Transform Transform => _transform ?? (_transform = base.transform);

		public Vector3 SetStartPosition(Vector3 startPosition)
		{
			base.transform.localPosition = startPosition;
			return EndPosition;
		}

		[ContextMenu("Calculate Bounds")]
		private void CalculateBounds()
		{
			Bounds bounds = Utilities.CalculateRendererBounds(base.gameObject);
			_length = bounds.size.z;
			_boundsSize = bounds.size;
			if (base.transform.parent != null)
			{
				int num = base.transform.GetSiblingIndex() - 1;
				if (num >= 0)
				{
					OldEngineComponentScript component = base.transform.parent.GetChild(num).GetComponent<OldEngineComponentScript>();
					SetStartPosition(component.EndPosition);
				}
				else
				{
					SetStartPosition(Vector3.zero);
				}
			}
		}
	}
}
