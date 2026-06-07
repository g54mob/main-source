using UnityEngine;

namespace Presentation.UI.ErrorPopUps
{
	public class OperatorStateOffset : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _offset;

		public Vector3 Offset => _offset;
	}
}
