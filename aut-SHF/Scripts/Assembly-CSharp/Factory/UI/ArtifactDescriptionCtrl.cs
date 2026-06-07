using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Factory.UI
{
	public class ArtifactDescriptionCtrl : MonoBehaviour
	{
		public enum SpecTextType
		{
			None = 0,
			ProductionEfficiency = 1,
			ProductionTime = 2,
			DeliverySpeed = 3
		}

		[SerializeField]
		private TMP_Text nameText;

		[SerializeField]
		protected TMP_Text descriptionText;

		[SerializeField]
		protected Image tipsImage;

		[SerializeField]
		protected SimpleSpriteAnimator spriteAnimator;

		[SerializeField]
		private Image icon;

		[SerializeField]
		protected GameObject manaObj;

		[SerializeField]
		protected TMP_Text mana;

		[SerializeField]
		protected GameObject stockObj;

		[SerializeField]
		protected TMP_Text stock;

		[SerializeField]
		private TMP_Text specText;

		[SerializeField]
		private bool showSpecText;

		[SerializeField]
		private bool specTextFullDisplay;

		[SerializeField]
		private Image[] usableMachineIcons;

		private const string defaultValueColor = "#92F053";

		private const string timeValueColor = "#6BF6D2";

		private const string speedValueColor = "#FFCE22";

		private Color usableIconDisableColor;

		protected bool isLoadWaiting;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		protected void UpdateUsableMachineIcons(MstMachineDataEntities machineData)
		{
		}

		protected virtual bool IsActiveUsableMachine(eMachine machine)
		{
			return false;
		}

		public virtual void ShowMachineDescription(eMachine machineId)
		{
		}

		public void HideMachineDescription()
		{
		}

		private static string GetItemText(eMessageId messageId, string itemValue, string colorCode = "", string spriteFontName = "", params string[] args)
		{
			return null;
		}

		private static string GetItemText(MstMachineDescSpecTextTypeEntities machineDescSpecTextTypeEntity, string specText, string overrideColor = null, bool isFullDisplay = true)
		{
			return null;
		}

		private static string GetItemName(eMessageId messageId)
		{
			return null;
		}

		private void UpdateSpecText(MstMachineDataEntities machineData)
		{
		}

		private static double GetProductionSpeed(MstMachineDataEntities machineData)
		{
			return 0.0;
		}

		private static double GetProductionEfficiency(MstMachineDataEntities machineData)
		{
			return 0.0;
		}

		private static double GetProductionTime(MstMachineDataEntities machineData)
		{
			return 0.0;
		}

		private static double GetDeliverySpeed(MstMachineDataEntities machineData)
		{
			return 0.0;
		}

		public static string GetSpecText(eMachine machine, string overrideColor = null)
		{
			return null;
		}

		private static string GetSpecText(MstMachineDataEntities machineData, string overrideColor = null, bool isFullDisplay = true)
		{
			return null;
		}
	}
}
