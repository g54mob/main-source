using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.UI
{
	public class WorkerIconCamera : MonoSingleton<WorkerIconCamera>
	{
		[SerializeField]
		private GameObject renderCamera;

		public GameObject Camera => renderCamera;
	}
}
