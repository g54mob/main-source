using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class AchievementItemButton : MonoBehaviour
	{
		[SerializeField]
		private Image itemIcon;

		[SerializeField]
		private Button buttonComponent;

		[SerializeField]
		private Image selectedCursor;

		[SerializeField]
		private GameObject unknownImageObj;

		private UnityAction<eSteamAchivementId> onPointerOverAction;

		private UnityAction onPointerExitAction;

		private eSteamAchivementId achievementId;

		public void InitComponent(eSteamAchivementId achieveId, UnityAction<eSteamAchivementId> onPointerOverAction, UnityAction onPointerExitAction)
		{
		}

		public void UpdateUI()
		{
		}

		public void ResetEvent()
		{
		}

		public void OnPointerOver()
		{
		}

		public void OnPointerExit()
		{
		}
	}
}
