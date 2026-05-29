using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.UtilityScripts
{
	public class PointedAtGameObjectInfo : MonoBehaviour
	{
		public static PointedAtGameObjectInfo Instance;

		public Text text;

		private Transform focus;

		private void Start()
		{
		}

		public void SetFocus(PhotonView pv)
		{
		}

		public void RemoveFocus(PhotonView pv)
		{
		}

		private void LateUpdate()
		{
		}
	}
}
