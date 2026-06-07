using Data.Buildings;
using Data.FactoryFloor;
using Data.Operator;
using Data.SaveData.PersistentSOs;
using Events.Generic;
using Presentation.UI;
using UI.Breadcrumbs;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.Toolbar
{
	public class PlaceBuildingButton : FancyToolBarButton
	{
		[SerializeField]
		private BuildingFamilyDatabase _buildingFamilyDatabase;

		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[SerializeField]
		private IntEvent _placeBuildingButtonPressedEvent;

		[SerializeField]
		private Image _icon;

		[SerializeField]
		private FactoryObjectBlockedInDemoDatabase _factoryObjectBlockedInDemoDatabase;

		[SerializeField]
		private TextInfoPanelContent _demoTextInfoPanelContent;

		[Header("Breadcrumb")]
		[SerializeField]
		private BreadcrumbsPersistentSO _breadcrumbsPersistentSO;

		[SerializeField]
		private BreadcrumbUI _breadcrumbUI;

		[SerializeField]
		private BreadcrumbStateSO _clearBreadcrumbStateOnClick;

		private string _breadcrumbId;

		public BuildingObjectData BuildingObjectData { get; private set; }

		public bool IsLocked
		{
			get
			{
				if (!_deactivated)
				{
					if ((bool)_lockedView)
					{
						return _lockedView.IsLocked;
					}
					return false;
				}
				return true;
			}
		}

		public void Setup(BuildingObjectData buildingData, Sprite buildingPreview)
		{
			base.ID = buildingData.ID;
			BuildingFamilyData buildingFamilyDataWithId = _buildingFamilyDatabase.GetBuildingFamilyDataWithId(buildingData.FamilyID);
			AccentColor = buildingFamilyDataWithId.Color;
			_icon.sprite = buildingPreview;
			(_lockedView as FactoryObjectLockedView).StartWithBuildingData(buildingData);
			BuildingObjectData = buildingData;
			if (_breadcrumbsPersistentSO != null)
			{
				_breadcrumbId = buildingData.BreadcrumbId;
				_breadcrumbUI.SetBreadcrumbId(_breadcrumbId);
				_breadcrumbsPersistentSO.SetBreadcrumbTags(_breadcrumbId, BreadcrumbUtilities.BuildBarTabToTag(buildingFamilyDataWithId.ID));
			}
			if (_factoryObjectBlockedInDemoDatabase.IsFactoryObjectDataBlockedInDemo(buildingData))
			{
				_demoTextInfoPanelContent.enabled = true;
			}
		}

		protected override void ButtonPressed()
		{
			if (!_deactivated && (!_lockedView || !_lockedView.IsLocked))
			{
				if (_breadcrumbsPersistentSO != null)
				{
					_breadcrumbsPersistentSO.RemoveBreadcrumbState(_breadcrumbId, _clearBreadcrumbStateOnClick);
				}
				_placeBuildingButtonPressedEvent.Fire(base.ID);
				base.ButtonPressed();
			}
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			if (BuildingObjectData != null && !_factoryObjectBlockedInDemoDatabase.IsFactoryObjectDataBlockedInDemo(BuildingObjectData))
			{
				base.OnPointerEnter(eventData);
			}
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			if (BuildingObjectData != null && !_factoryObjectBlockedInDemoDatabase.IsFactoryObjectDataBlockedInDemo(BuildingObjectData))
			{
				base.OnPointerExit(eventData);
			}
		}
	}
}
