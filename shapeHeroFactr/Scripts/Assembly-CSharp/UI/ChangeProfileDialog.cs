using System.Collections.Generic;
using SaveData;
using UnityEngine;

namespace UI
{
	public class ChangeProfileDialog : BaseDialog
	{
		[SerializeField]
		private List<ChangeProfileItem> profileItems;

		[SerializeField]
		private List<GameObject> deleteButtons;

		private static int ProfileCountMax => 0;

		public override void Init()
		{
		}

		public override void Open()
		{
		}

		private void InitItems()
		{
		}

		private void Reflesh()
		{
		}

		public void OnClickItem(int index)
		{
		}

		private void ChangeProfile(int profileNumber)
		{
		}

		private ProfileSummaryData GetProfileSummary(int profileNumber)
		{
			return null;
		}

		private ProfileSummaryData CheckSummaryData(ProfileSummaryData summaryData, int profileNumber)
		{
			return null;
		}

		public override void PlayOpenSound()
		{
		}

		public override void PlayCloseSound()
		{
		}

		public void OnClickDeleteButton(int index)
		{
		}

		private void LoadDatas()
		{
		}

		public static void ResetSaveData(bool keepRecord = false)
		{
		}

		private static void SaveOutGame(bool withSave = true)
		{
		}

		private static void SaveInGame(bool withSave = true)
		{
		}
	}
}
