using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class FlexibleAttachment : ElementAttachmentBase
	{
		[SerializeField]
		private GameObject pinnedModel;

		[SerializeField]
		private GameObject unpinnedModel;

		public override void ChangeState(bool inSocket)
		{
			if (inSocket)
			{
				Pin();
			}
			else
			{
				Unpin();
			}
		}

		private void Pin()
		{
			pinnedModel.SetActive(value: true);
			unpinnedModel.SetActive(value: false);
		}

		private void Unpin()
		{
			pinnedModel.SetActive(value: false);
			unpinnedModel.SetActive(value: true);
		}
	}
}
