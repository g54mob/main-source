using Data.Operator;
using Data.Variables;
using Events.FactoryFloor;
using Events.UI;
using Logic.FactoryTools;
using Presentation.FactoryFloor;
using Presentation.FactoryFloor.Toolbar;
using Presentation.Locators;
using Presentation.UI.OperatorUIs.OperatorHoverUIs;
using Presentation.UI.OperatorUIs.OperatorPanelUIs;
using TMPro;
using UnityEngine;

namespace Presentation.UI
{
	public class OperatorInfoPanelView : InfoPanelView
	{
		[SerializeField]
		private TextMeshProUGUI _titleText;

		[SerializeField]
		private SpeedInfo _speedInfo;

		[SerializeField]
		private ShapesOutputView _shapesOutputView;

		[SerializeField]
		private OperatorCoolantInfoView _coolantInfoView;

		[Header("Events")]
		[SerializeField]
		private OperatorHoverEvent _operatorHoverEvent;

		[SerializeField]
		private OperatorHoverEndEvent _operatorHoverEndEvent;

		[Header("Can Show")]
		[SerializeField]
		private BoolVariableSO _operatorUIIsOpen;

		[SerializeField]
		private ToolSystemLocator _toolSystemLocator;

		[SerializeField]
		private PlaceCraneFromBuildingTool _placeCraneFromBuildingTool;

		private FactoryObjectView _factoryObjectView;

		protected override void Awake()
		{
			if (Application.isPlaying)
			{
				_operatorHoverEvent.Register(OnOperatorHover);
				_operatorHoverEndEvent.Register(OnOperatorHoverEnd);
				Hide();
			}
		}

		protected override void OnDestroy()
		{
			_operatorHoverEvent.UnRegister(OnOperatorHover);
			_operatorHoverEndEvent.UnRegister(OnOperatorHoverEnd);
		}

		private void OnOperatorHover(OperatorHoverDto hoverDto)
		{
			_factoryObjectView = hoverDto.FactoryObjectView;
			if (_toolSystemLocator.ToolSystem.SelectedTool != _placeCraneFromBuildingTool)
			{
				Show(hoverDto);
			}
		}

		private void OnOperatorHoverEnd(OperatorHoverDto hoverDto)
		{
			if (!(_factoryObjectView != hoverDto.FactoryObjectView))
			{
				_factoryObjectView = null;
				_shapesOutputView.CleanUp();
				Hide();
			}
		}

		protected override void SetContent(InfoPanelDto dto)
		{
			OperatorHoverDto operatorHoverDto = dto as OperatorHoverDto;
			SetText(operatorHoverDto.FactoryObjectUIData);
			_shapesOutputView.SetContent(operatorHoverDto.FactoryObjectView.FactoryObject, out var uniqueInputsCount, out var uniqueOutputsCount, out var totalOutputsCount);
			_coolantInfoView.SetContent(operatorHoverDto.FactoryObjectView.FactoryObject);
			_speedInfo.SetSpeedsFromConfiguredOperator(operatorHoverDto.FactoryObjectUIData, totalOutputsCount, uniqueInputsCount, uniqueOutputsCount, operatorHoverDto.FactoryObjectView.FactoryObject);
		}

		private void SetText(FactoryObjectUIData objectUIData)
		{
			_titleText.SetText((objectUIData != null) ? LocalizationUtility.GetLocalizedText(objectUIData.NameLocKey) : null);
		}
	}
}
