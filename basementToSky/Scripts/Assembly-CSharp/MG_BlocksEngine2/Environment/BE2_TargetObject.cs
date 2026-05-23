using UnityEngine;

namespace MG_BlocksEngine2.Environment
{
	public class BE2_TargetObject : MonoBehaviour, I_BE2_TargetObject
	{
		public Transform Transform => base.transform;

		public I_BE2_ProgrammingEnv ProgrammingEnv { get; set; }
	}
}
