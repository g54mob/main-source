using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews.Arrows
{
	public class InputOutputArrow : MonoBehaviour
	{
		public enum EArrowType
		{
			Input = 0,
			Output = 1
		}

		[SerializeField]
		private EArrowType _arrowType;

		[SerializeField]
		private Vector3Int _relativePosition;

		public EArrowType ArrowType => _arrowType;

		public Vector3Int RelativePosition => _relativePosition;

		public void SetArrow(EArrowType arrowType, Vector3Int relativePos)
		{
			_arrowType = arrowType;
			_relativePosition = relativePos;
		}
	}
}
