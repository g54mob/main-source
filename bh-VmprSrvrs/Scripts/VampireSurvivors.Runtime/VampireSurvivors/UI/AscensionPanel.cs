using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class AscensionPanel : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _CompletionText;

		[SerializeField]
		private TextMeshProUGUI _PortraitCompletionText;

		[SerializeField]
		private AdjustValuePanel _LuckPanel;

		[SerializeField]
		private AdjustValuePanel _GrowthPanel;

		[SerializeField]
		private AdjustValuePanel _GreedPanel;

		[SerializeField]
		private AdjustValuePanel _CursePanel;

		[SerializeField]
		private List<AdjustValuePanel> _NavigationPanels;

		[SerializeField]
		private Button _AscendAdventureButton;

		[SerializeField]
		private UISpriteAnimation _Sheen;

		private PlayerOptions _playerOptions;

		private AdventureManager _adventureManager;

		private int _completionCount;

		private int _currentSpend;

		private bool _shouldGenerateNavigation;

		private PlayerOptionsData _adventurePod;

		private Selectable _selectableToReturnTo;

		private AdventureType _adventureType;

		private Transform _ascendSender;

		[Inject]
		private void Construct(PlayerOptions player, AdventureManager adventureManager)
		{
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void LateUpdate()
		{
		}

		private void OnEnable()
		{
		}

		private void OnAdventureAscended(bool obj)
		{
		}

		private void OnDisable()
		{
		}

		public void SetData(PlayerOptionsData adventurePod, AdventureType adventureType)
		{
		}

		public void RefreshData()
		{
		}

		public void SetRegenerateNavigation()
		{
		}

		public void SetSelected(Selectable selectedItem)
		{
		}

		public Selectable GetFirstSelectable()
		{
			return null;
		}

		public Selectable GetLastSelectable()
		{
			return null;
		}

		public void GenerateNavigation()
		{
		}

		public void Apply()
		{
		}

		private void ValueChanged(AdjustValuePanel panel, bool positive)
		{
		}

		private void SetInteractionsFromSpend()
		{
		}

		private void SetPanelsInteractionUp(bool enabled)
		{
		}
	}
}
