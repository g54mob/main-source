using DV.Common;
using DV.JObjectExtstensions;
using DV.UserManagement;
using DV.Utils;
using UnityEngine;

namespace DV.Tutorial
{
	public class PostTutorialActivator : MonoBehaviour
	{
		public GameObject tutorialObject;

		public string saveKey = "Tutorial_03_completed";

		public bool enableInCareer;

		public bool enableInFreeRoam;

		public bool perUser;

		public bool onlyInNewSessions;

		private bool CheckKey()
		{
			bool? flag = (perUser ? SingletonBehaviour<UserManager>.Instance.CurrentUser.GameData.GetBool(saveKey) : SingletonBehaviour<SaveGameManager>.Instance.data.GetBool(saveKey));
			if (flag.HasValue)
			{
				return flag.Value;
			}
			return false;
		}

		private void SetKey()
		{
			if (perUser)
			{
				SingletonBehaviour<UserManager>.Instance.CurrentUser.GameData.SetBool(saveKey, value: true);
				SingletonBehaviour<UserManager>.Instance.CurrentUser.Save(UserSavingMode.JustUser);
			}
			else
			{
				SingletonBehaviour<SaveGameManager>.Instance.data.SetBool(saveKey, value: true);
			}
		}

		private void Start()
		{
			bool flag = false;
			bool? flag2 = SingletonBehaviour<SaveGameManager>.Instance.data.GetBool("Tutorial_01_completed");
			bool? flag3 = SingletonBehaviour<SaveGameManager>.Instance.data.GetBool("Tutorial_02_completed");
			if ((flag2.HasValue && !flag2.Value) || (flag3.HasValue && !flag3.Value) || (onlyInNewSessions && !SingletonBehaviour<SaveGameManager>.Instance.IsNewSession))
			{
				flag = true;
			}
			if (flag || TutorialHelper.InRestrictedMode || (SingletonBehaviour<UserManager>.Instance.CurrentUser.CurrentSession.GameMode == "Career" && !enableInCareer) || (SingletonBehaviour<UserManager>.Instance.CurrentUser.CurrentSession.GameMode == "FreeRoam" && !enableInFreeRoam))
			{
				Object.Destroy(tutorialObject);
				Object.Destroy(this);
				return;
			}
			bool flag4 = false;
			if ((bool)SingletonBehaviour<SaveGameManager>.Instance && !CheckKey())
			{
				SetKey();
				flag4 = true;
				tutorialObject.SetActive(value: true);
			}
			if (!flag4)
			{
				Object.Destroy(tutorialObject);
				Object.Destroy(this);
			}
		}
	}
}
