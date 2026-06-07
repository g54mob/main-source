using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.App.Scripts.UI;
using VampireSurvivors.Data;

namespace VampireSurvivors.App.UI
{
	public class AdventureItemUI : MonoBehaviour, ISelectHandler, IEventSystemHandler
	{
		[SerializeField]
		private Image _Icon;

		[SerializeField]
		private Image _Selection;

		[SerializeField]
		private TextMeshProUGUI _Title;

		[SerializeField]
		private TextMeshProUGUI _CoinCount;

		[SerializeField]
		private TextMeshProUGUI _ProgressCount;

		[SerializeField]
		private Image _ProgressFill;

		[SerializeField]
		private GameObject _AvailableGroup;

		[SerializeField]
		private GameObject _RequiresDlcPurchaseGroup;

		[SerializeField]
		private GameObject _CompletedGroup;

		[SerializeField]
		private GameObject _LockedGroup;

		[SerializeField]
		private Button _AscendAdventureButton;

		[SerializeField]
		private Image _Flash;

		[SerializeField]
		private RectTransform _BackgroundContainer;

		[SerializeField]
		private Image _CompletionStar;

		private AdventureType _type;

		private AdventureData _data;

		private SelectAdventuresPage _page;

		private GameObject _background;

		private bool _isUnlockedViaAtlas;

		private bool _ownsRequiredDlc;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public Button GetAscendButton()
		{
			return null;
		}

		public void SetData(SelectAdventuresPage page, AdventureType type, AdventureData adventureData)
		{
		}

		public void OpenDLC()
		{
		}

		public void OnClick()
		{
		}

		public GameObject GetBackground()
		{
			return null;
		}

		public AdventureType GetAdventureType()
		{
			return default(AdventureType);
		}

		public AdventureData GetAdventureData()
		{
			return null;
		}

		public void SetAscendingItem()
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		public void Deselect()
		{
		}

		private float CurrentAdventureCompletionProgress(PlayerOptionsData pod, AdventureData adventureData, AdventureType adventureType)
		{
			return 0f;
		}

		public void DoAscenscionFeedback()
		{
		}
	}
}
