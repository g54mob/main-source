using UnityEngine;

namespace Assets.Behaviour.Frame
{
	public class FrameUpgradeInfo : MonoBehaviour
	{
		[SerializeField]
		private GameObject _infoContent;

		private void Update()
		{
			_infoContent.SetActive(FrameUI.InfoActive);
		}
	}
}
