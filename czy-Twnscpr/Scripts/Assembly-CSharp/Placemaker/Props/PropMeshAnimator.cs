using UnityEngine;

namespace Placemaker.Props
{
	public class PropMeshAnimator : MonoBehaviour
	{
		[SerializeField]
		private WorldMaster master;

		public void OnLateUpdate()
		{
		}

		public void OnReset()
		{
		}

		public void OnTurnedOff(PropMeshReference propMeshReference)
		{
		}

		private bool PosInView(PropMeshReference propMeshReference)
		{
			return false;
		}

		public void OnTurnedOn(PropMeshReference propMeshReference)
		{
		}

		public void OnDone(PropMeshReference propMeshReference)
		{
		}
	}
}
