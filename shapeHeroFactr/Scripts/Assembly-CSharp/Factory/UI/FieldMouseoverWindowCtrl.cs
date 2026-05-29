using System.Collections.Generic;
using Factory.FieldData;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Factory.UI
{
	[RequireComponent(typeof(Image))]
	public class FieldMouseoverWindowCtrl : MonoBehaviour
	{
		public Image icon;

		public TMP_Text title;

		public TMP_Text productionTime;

		public TMP_Text conversionTime;

		public TMP_Text productionSpeed;

		public TMP_Text productionQuantity;

		public TMP_Text sourceCorrection;

		public GameObject productGroup;

		public TMP_Text inOperation;

		public TMP_Text cantTakeOut;

		public Image product;

		public TMP_Text deliverySpeed;

		public TMP_Text utilization;

		public TMP_Text outputPortUtilization;

		public TMP_Text humanUtilization;

		public TMP_Text buffRate;

		public List<TMP_Text> measureItems;

		public RectTransform measureItemArea;

		public TMP_Text conversionRate;

		public TMP_Text extractorSpeed;

		public TMP_Text efficiency;

		public List<TMP_Text> liquidConsumptionItems;

		[FormerlySerializedAs("connectDrawmotief")]
		public TMP_Text connectExtractor;

		public List<TMP_Text> collectItems;

		public RectTransform collectItemArea;

		public TMP_Text collectionEfficiency;

		public TMP_Text sweetsEffectiveTime;

		[SerializeField]
		private RectTransform window;

		[SerializeField]
		private ContentSizeFitter windowGroup;

		[SerializeField]
		private ContentSizeFitter elementsGroup;

		[SerializeField]
		private ContentSizeFitter collectItemGroup;

		[SerializeField]
		private ContentSizeFitter measureItemGroup;

		[SerializeField]
		private ContentSizeFitter liquidConsumptionItemGroup;

		private MachineInformation machineInformation;

		private MstMachineDataEntities machineDataEntities;

		private MstLuggageDataEntities luggageDataEntities;

		private MstMouseOverDetailCategoryEntities mouseOverDetailCategoryEntities;

		private const string defaultValueColor = "#92F053";

		private const string timeValueColor = "#6BF6D2";

		private const string speedValueColor = "#FFCE22";

		private float utilizationRoundUpValue;

		private float outputPortUtilizationRoundDownValue;

		private Dictionary<eMessageId, string> itemNameDic;

		private void Awake()
		{
		}

		private void InitItemName()
		{
		}

		private string GetItemName(eMessageId messageId)
		{
			return null;
		}

		private string GetItemText(eMessageId messageId, string itemValue, string colorCode = "", string[] spriteFonts = null, params string[] args)
		{
			return null;
		}

		private string GetItemTextWithoutValueText(eMessageId messageId, params string[] args)
		{
			return null;
		}

		private string GetMotifSourceSpriteFont(eMachine source)
		{
			return null;
		}

		public bool SetMachineInformation(MachineInformation info)
		{
			return false;
		}

		private bool IsDetailMode()
		{
			return false;
		}

		private bool SwitchCategory()
		{
			return false;
		}
	}
}
