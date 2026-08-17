using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.UI;
using UnityEngine;

namespace Doozy.Examples;

public class E12PopupManagerScript : MonoBehaviour
{
	public string PopupName = "AchievementPopup";

	public List<AchievementData> Achievements;

	private UIPopup m_popup;

	public void ShowAchievement(int achievementId)
	{
		//IL_003f: Expected O, but got I4
		if (Achievements == null || achievementId < 0)
		{
			return;
		}
		List<AchievementData> achievements = Achievements;
		object obj = achievements._size - 1;
		if (achievementId > (nint)obj)
		{
			return;
		}
		if (achievementId < achievements._size)
		{
			AchievementData[] items = achievements._items;
			AchievementData achievementData = items[achievementId];
			if (items[achievementId] == null)
			{
				return;
			}
			UIPopup popup = UIPopupManager.GetPopup(PopupName);
			m_popup = popup;
			UIPopup popup2 = m_popup;
			if ((object)m_popup != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rdi_v7 (Doozy.Engine.UI.UIPopup)+10]");
				if ((nint)0 != 0)
				{
					UIPopup popup3 = m_popup;
					Sprite[] imagesSprites = new Sprite[1];
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					popup3.Data.SetImagesSprites(imagesSprites);
					UIPopup popup4 = m_popup;
					string[] labelsTexts = new string[2];
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					popup4.Data.SetLabelsTexts(labelsTexts);
					UIPopup popup5 = m_popup;
					UIPopupManager.ShowPopup(m_popup, popup5.AddToPopupQueue, instantAction: false);
				}
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new IndexOutOfRangeException();
	}

	public void ClearPopupQueue()
	{
		UIPopupManager.ClearQueue();
	}

	public E12PopupManagerScript()
	{
		List<AchievementData> achievements = new List<AchievementData>();
		Achievements = achievements;
	}
}
