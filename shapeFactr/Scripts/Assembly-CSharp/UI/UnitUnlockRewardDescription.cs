using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class UnitUnlockRewardDescription : MonoBehaviour
	{
		[Header("アンロック用説明")]
		public TMP_Text unitName;

		public GameObject needResourceGroup;

		public RectTransform needResourceContent;

		public RectTransform needMachineContent;

		public GameObject unlockDescription;

		public TMP_Text createSpeedText;

		public TMP_Text createCountText;

		public Image needMachinePrefab;

		[Header("レベルアップ時説明")]
		public GameObject levelUpDescription;

		public TMP_Text abilityTextPrefab;

		public StarCounter nowStarCounter;

		public TMP_Text nowSpeedIncreaseText;

		public RectTransform nowAbilityContent;

		public StarCounter nextStarCounter;

		public TMP_Text nextSpeedIncreaseText;

		public RectTransform nextAbilityContent;

		public AnimatedImage gifPlayer;

		public void InitComponent(eLuggage luggage, bool isUnlock)
		{
		}

		private void CreateNeedResourceIcon(PlayUnlockData targetLuggage)
		{
		}

		private void CreateNeedMachineIcon(PlayUnlockData targetLuggage)
		{
		}
	}
}
