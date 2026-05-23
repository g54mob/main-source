using UnityEngine;

namespace Battle
{
	public class UnitController : MonoBehaviour
	{
		[Tooltip("ONにすることで親の回転を無視してカメラ方向.OFFなら親の回転を継承してカメラ方向.")]
		public bool ignoreParentRotation;

		public bool inheritanceParentRotation;

		private Quaternion quaternion;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
