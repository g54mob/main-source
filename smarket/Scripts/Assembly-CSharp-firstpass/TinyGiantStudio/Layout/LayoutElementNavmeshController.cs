using TinyGiantStudio.Modules;
using UnityEngine;

namespace TinyGiantStudio.Layout
{
	[DisallowMultipleComponent]
	public class LayoutElementNavmeshController : MonoBehaviour
	{
		public Vector3 startingPosition;

		public Vector3 targetPosition;

		public float gravitationalAcceleration;

		private void Update()
		{
		}

		public void NewTargetLocalPosition(VariableHolder[] variableHolders, Vector3 target)
		{
		}

		public void NewTargetLocalRotation(VariableHolder[] variableHolders, Quaternion target)
		{
		}

		private bool IsNaN(Quaternion q)
		{
			return false;
		}
	}
}
