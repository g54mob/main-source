using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_SetParent : FimpossibleComponent
	{
		public Transform TargetParent;

		public bool InitPositionIsLocal;

		public Vector3 LocalPosition;

		public Vector3 LocalRotation;

		public override string HeaderInfo => "Simply assigning new parent to this object. It's purpose is to show this object on the scene for quick check what kind of components will be used in playmode.";

		private void Start()
		{
			if (!(TargetParent == null))
			{
				base.transform.SetParent(TargetParent, worldPositionStays: true);
				if (InitPositionIsLocal)
				{
					ReadCoords();
				}
				base.transform.localPosition = LocalPosition;
				base.transform.localRotation = Quaternion.Euler(LocalRotation);
			}
		}

		private void ReadCoords()
		{
			LocalPosition = TargetParent.InverseTransformPoint(base.transform.position);
			LocalRotation = TargetParent.rotation.QToLocal(base.transform.rotation).eulerAngles;
		}
	}
}
