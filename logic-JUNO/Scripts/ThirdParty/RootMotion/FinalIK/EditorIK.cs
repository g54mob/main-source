using UnityEngine;

namespace RootMotion.FinalIK
{
	[ExecuteInEditMode]
	public class EditorIK : MonoBehaviour
	{
		private IK ik;

		private void Start()
		{
			ik = GetComponent<IK>();
			ik.GetIKSolver().Initiate(ik.transform);
		}

		private void Update()
		{
			if (!(ik == null))
			{
				if (ik.fixTransforms)
				{
					ik.GetIKSolver().FixTransforms();
				}
				ik.GetIKSolver().Update();
			}
		}
	}
}
