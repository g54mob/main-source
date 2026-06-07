using UnityEngine;
using UnityEngine.UI;

namespace Xamin
{
	[RequireComponent(typeof(Image))]
	public class Button : MonoBehaviour
	{
		public bool isUnlocked;

		public bool isEquipment;

		public string id;

		public ItemType itemType;

		[Header("Building Category")]
		[Tooltip("Bu buton bir building kategorisi mi?")]
		public bool isBuildingCategory;

		[Tooltip("Building kategorisi - isBuildingCategory true ise kullanılır")]
		public T_BuildingCategorySO buildingCategory;

		[Tooltip("Bu buton belt butonu mu?")]
		public bool beltButton;

		[Tooltip("Bu buton pallet butonu mu?")]
		public bool palletButton;

		public Color customColor;

		public bool useCustomColor;

		public string localizationName;

		public string localizationDesc;

		[Header("References")]
		public Image icon;

		[Header("Lock")]
		[Tooltip("Equipment kilitli olduğunda gösterilecek kilit ikonu")]
		public GameObject lockIcon;

		public Color currentColor => icon.color;

		public void SetColor(Color c)
		{
			icon.color = c;
		}

		public void ExecuteAction()
		{
			if (isBuildingCategory && isUnlocked && buildingCategory != null)
			{
				if (RadialBuildingManager.Instance != null)
				{
					RadialBuildingManager.Instance.StartBuildingFromCategory(buildingCategory);
					if (palletButton && TutorialManager.Instance != null)
					{
						TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.Production, TutorialStepType.PlacePallet, TutorialSubStepType.EnterPalletMode);
					}
				}
				else
				{
					Debug.LogWarning("[Button] ExecuteAction: RadialBuildingManager.Instance null! Building kategorisi başlatılamadı.");
				}
				return;
			}
			if (isEquipment && itemType != ItemType.Hammer)
			{
				int num = 0;
				if (PlayerProgressManager.Instance != null)
				{
					num = PlayerProgressManager.Instance.GetLevel(itemType);
				}
				bool flag = num >= 1;
				isUnlocked = flag;
			}
			if (isEquipment && isUnlocked && GameManager.Instance != null && GameManager.Instance.localEquipments != null && itemType != ItemType.None)
			{
				GameManager.Instance.localEquipments.TryEquipByItemType(itemType);
				if (itemType == ItemType.Shovel)
				{
					TutorialManager.Instance?.TryCompleteSubStep(TutorialConfigType.Equipments, TutorialStepType.UseEquipments, TutorialSubStepType.UseShovel);
				}
			}
			else if (isEquipment && isUnlocked && GameManager.Instance != null && GameManager.Instance.localEquipments != null)
			{
				int.TryParse(id, out var result);
				GameManager.Instance.localEquipments.TryEquipByIndex(result);
			}
		}

		public void UpdateLockStatus()
		{
			if (isEquipment && itemType != ItemType.None)
			{
				int num = 0;
				if (PlayerProgressManager.Instance != null)
				{
					num = PlayerProgressManager.Instance.GetLevel(itemType);
				}
				if (itemType == ItemType.Hammer)
				{
					num = 1;
				}
				bool flag = (isUnlocked = num >= 1);
				if (lockIcon != null)
				{
					lockIcon.SetActive(!flag);
				}
			}
		}
	}
}
