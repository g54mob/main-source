using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet
{
	public class OldEngineComponentScript : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("Adjusts the bottom local y coordinate.")]
		private float _bottomAdjustment;

		[SerializeField]
		[Tooltip("The end offset.")]
		private float _bottomLocalY;

		[SerializeField]
		[Tooltip("The bounds size.")]
		private Vector3 _boundsSize;

		[SerializeField]
		[Tooltip("The start offset.")]
		private float _startLocalY;

		private Transform _transform;

		public Vector3 EndPosition => base.transform.localPosition + new Vector3(0f, _bottomLocalY * LengthScale, 0f);

		public float Length => _boundsSize.y;

		public float LengthScale => base.transform.localScale.z;

		public Transform Transform => _transform ?? (_transform = base.transform);

		public Vector3 SetStartPosition(Vector3 startPosition)
		{
			base.transform.localPosition = startPosition - new Vector3(0f, _startLocalY * LengthScale, 0f);
			return EndPosition;
		}

		[ContextMenu("Calculate Bounds")]
		private void CalculateBounds()
		{
			Bounds bounds = Utilities.CalculateRendererBounds(base.gameObject);
			_startLocalY = (bounds.max - base.transform.position).y;
			_bottomLocalY = (bounds.min - base.transform.position).y + _bottomAdjustment;
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
