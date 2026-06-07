using System;
using SteamIntegrations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIScripts.UIReferences
{
	public class AchievementItem : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		private Achievement achievement;

		public Image image;

		public TooltipTrigger tooltip;

		public Sprite secretIcon;

		private bool isSecret;

		[NonSerialized]
		public bool unachievedSecret;

		public void InitializeItem(Achievement target)
		{
			achievement = target;
			isSecret = achievement.isSecret;
			UpdateAchieved();
		}

		public void UpdateAchieved()
		{
			bool achieved = achievement.achieved;
			unachievedSecret = isSecret && !achieved;
			tooltip.UpdateText(achievement.title, unachievedSecret ? "???" : achievement.desc);
			Sprite sprite = (achieved ? achievement.spriteAchieved : (isSecret ? secretIcon : achievement.spriteNotAchieved));
			image.sprite = ((sprite != null) ? sprite : secretIcon);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
		}
	}
}
