using UnityEngine;

namespace CTS
{
	public class LateAnimFixer : MonoBehaviour
	{
		private Transform bone;

		public bool usePos;

		private Vector3 originPos;

		public Vector3 pos;

		public Vector3 eulerRot;

		private Quaternion quatRotation;

		private Quaternion originRot;

		private void Start()
		{
			bone = base.gameObject.transform;
			originRot = base.transform.rotation;
			MonoBehaviour.print(originRot);
		}

		public void LateUpdate()
		{
			if (usePos)
			{
				if (originPos == Vector3.zero)
				{
					originPos = base.transform.position;
				}
				bone.transform.position = pos + originPos;
			}
			quatRotation.eulerAngles = eulerRot;
			bone.transform.rotation = originRot * quatRotation;
		}
	}
}
