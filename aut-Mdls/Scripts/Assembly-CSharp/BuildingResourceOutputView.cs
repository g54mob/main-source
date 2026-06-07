using Data.Buildings;
using Data.FactoryFloor.Resources;
using Events.FactoryFloor.Buildings;
using Presentation.FactoryFloor;
using UnityEngine;
using UnityEngine.UI;

public class BuildingResourceOutputView : FactoryBehaviorView<BuildingBehaviour>
{
	[SerializeField]
	private Canvas _canvas;

	[SerializeField]
	private Image _icon;

	[SerializeField]
	private BuildingResourceEvent _showBuildingResources;

	[SerializeField]
	private BuildingResourceEvent _hideBuildingResources;

	[SerializeField]
	private GameObject _selectedVFX;

	protected override void Init()
	{
		base.Init();
		_showBuildingResources.Register(ShowUI);
		_hideBuildingResources.Register(HideUI);
	}

	protected override void ResetFactoryObject()
	{
		base.ResetFactoryObject();
		_showBuildingResources.UnRegister(ShowUI);
		_hideBuildingResources.UnRegister(HideUI);
	}

	protected override void OnDestroy()
	{
		_showBuildingResources.UnRegister(ShowUI);
		_hideBuildingResources.UnRegister(HideUI);
		base.OnDestroy();
	}

	private void ShowUI(ResourceDataSO resourceData)
	{
		if (!_behaviour || _behaviour.BuildingObjectData.ResourceOutputs.Count < 1 || _behaviour.BuildingLandingPad.Exists)
		{
			return;
		}
		bool flag = false;
		foreach (BuildingObjectData.BuildingResourceData resourceOutput in _behaviour.BuildingObjectData.ResourceOutputs)
		{
			if (resourceOutput.ResourceData == resourceData)
			{
				flag = true;
				break;
			}
		}
		if (!(resourceData != null) || flag)
		{
			_canvas.gameObject.SetActive(value: true);
			_selectedVFX.gameObject.SetActive(value: true);
			_icon.sprite = (_behaviour.BuildingObjectData.ResourceOutputs[0].ResourceData as NonShapeResourceDataSO).Sprite;
		}
	}

	private void HideUI(ResourceDataSO resourceData)
	{
		if ((bool)base.gameObject && (bool)_canvas && (bool)_selectedVFX)
		{
			_canvas.gameObject.SetActive(value: false);
			_selectedVFX.gameObject.SetActive(value: false);
		}
	}
}
