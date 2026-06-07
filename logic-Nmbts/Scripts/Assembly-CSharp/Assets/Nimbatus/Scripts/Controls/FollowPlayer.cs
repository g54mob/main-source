using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Controls
{
	public class FollowPlayer : MonoBehaviour
	{
		internal void LateUpdate()
		{
			if (RuntimeGlobals.Camera != null)
			{
				Vector3 position = RuntimeGlobals.Camera.transform.position;
				position.z = base.transform.position.z;
				base.transform.rotation = RuntimeGlobals.Camera.transform.rotation;
				base.transform.position = position;
			}
		}
	}
}
