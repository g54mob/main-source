using DV.Utils;
using UnityEngine;

namespace DV.UI
{
	[ExecuteAfter(typeof(RotatePlayer))]
	public class FloatiePlayerCameraFollower : MonoBehaviour
	{
		private void LateUpdate()
		{
			RefreshPosition();
		}

		public void RefreshPosition()
		{
			Camera playerCamera = PlayerManager.PlayerCamera;
			if ((bool)playerCamera)
			{
				Transform parent = playerCamera.transform.parent;
				if ((bool)parent)
				{
					base.transform.position = parent.position;
					base.transform.rotation = parent.rotation;
				}
			}
		}
	}
}
