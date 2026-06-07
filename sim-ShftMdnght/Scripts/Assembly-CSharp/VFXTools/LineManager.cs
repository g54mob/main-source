using UnityEngine;

namespace VFXTools
{
	[ExecuteInEditMode]
	public class LineManager : MonoBehaviour
	{
		public LineRenderer line;

		public Transform pos1;

		public Transform pos2;

		private void Start()
		{
			line.positionCount = 2;
		}

		private void Update()
		{
			line.SetPosition(0, pos1.position);
			line.SetPosition(1, pos2.position);
		}
	}
}
