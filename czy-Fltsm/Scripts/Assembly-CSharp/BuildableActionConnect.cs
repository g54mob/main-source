using System;
using I2.Loc;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "BuildableActionConnect", menuName = "Flotsam/Actions/Buildable/Connect")]
public class BuildableActionConnect : ISelectableActionBase<Buildable>
{
	[SerializeField]
	private uint _index;

	[SerializeField]
	[FormerlySerializedAs("_canLink")]
	private ActionData _canConnect;

	[SerializeField]
	[FormerlySerializedAs("_cannotLink")]
	private ActionData _cannotConnect;

	[SerializeField]
	private EnergyGridConnectCursorProperties _cursorProperties;

	[NonSerialized]
	private EnergyGridBuildableComponent _energyGridComponent;

	public override bool IsEnabled
	{
		get
		{
			if ((bool)_energyGridComponent)
			{
				return _index < _energyGridComponent.ConnectionsCapacity;
			}
			return false;
		}
	}

	public override bool IsInteractable => IsEnabled;

	public override void SetSelectable(Buildable selectable)
	{
		base.SetSelectable(selectable);
		selectable.TryReturnBuildableExtendable<EnergyGridBuildableComponent>(out _energyGridComponent);
	}

	public override void Trigger()
	{
		if (_energyGridComponent.CanConnect(_index))
		{
			_cursorProperties.Initialize(_energyGridComponent, _index);
			GameManager.CursorManager.Activate(_cursorProperties);
		}
		else
		{
			EnergyGrid.DisconnectWithIndex(_energyGridComponent, _index);
		}
	}

	public override Sprite GetIcon()
	{
		if (!_energyGridComponent.CanConnect(_index))
		{
			return _cannotConnect.Icon;
		}
		return _canConnect.Icon;
	}

	public override LocalizedString GetLabel()
	{
		if (!_energyGridComponent.CanConnect(_index))
		{
			return _cannotConnect.Label;
		}
		return _canConnect.Label;
	}

	public override LocalizedString GetDescription()
	{
		if (!_energyGridComponent.CanConnect(_index))
		{
			return _cannotConnect.Description;
		}
		return _canConnect.Description;
	}
}
