using System.Collections;
using DV.Common;
using DV.JObjectExtstensions;
using DV.UI;
using DV.UIFramework;
using DV.UserManagement;
using DV.Utils;
using UnityEngine;

namespace DV.Shops
{
	public class BoomboxLegalInfoTrigger : APurchaseTrigger
	{
		public Popup dialogPrefab;

		public override void OnPurchased(GameObject instantiatedItem)
		{
			if (DevSceneUtil.IsGameScene())
			{
				bool? flag = SingletonBehaviour<UserManager>.Instance.CurrentUser.GameData.GetBool("Boombox_info_displayed");
				if (!flag.HasValue || !flag.Value)
				{
					SingletonBehaviour<CoroutineManager>.Instance.Run(BoomboxDisclaimerPopUp());
				}
			}
			Object.Destroy(this);
		}

		private IEnumerator BoomboxDisclaimerPopUp()
		{
			yield return WaitFor.Seconds(3f);
			while (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Blockers))
			{
				yield return null;
			}
			SingletonBehaviour<UserManager>.Instance.CurrentUser.GameData.SetBool("Boombox_info_displayed", value: true);
			SingletonBehaviour<UserManager>.Instance.CurrentUser.Save(UserSavingMode.JustUser);
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.PopupManager.ShowPopup(dialogPrefab);
		}
	}
}
