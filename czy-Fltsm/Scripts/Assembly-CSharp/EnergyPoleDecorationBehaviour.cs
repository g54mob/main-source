using System;
using UnityEngine;

[RequireComponent(typeof(Decoration))]
public class EnergyPoleDecorationBehaviour : SceneBehaviour, IDecorationBehaviour, ITooltipProvider
{
	[Serializable]
	public class PersistentData : IDecoBehaviourPersistentData
	{
		private readonly EnergyGridConnectorPersistentData _gridConnectorData;

		private readonly EnergyGridDecorationComponentPersistentData _gridComponentData;

		public PersistentData(EnergyPoleDecorationBehaviour behaviour)
		{
			if (behaviour.TryGetComponent<EnergyGridDecorationComponent>(out var component))
			{
				_gridConnectorData = new EnergyGridConnectorPersistentData(component);
			}
		}

		void IDecoBehaviourPersistentData.PopulateReferences()
		{
			_gridConnectorData?.PopulateReferences();
		}

		void IDecoBehaviourPersistentData.Restore(IDecorationBehaviour behaviour, DecorationProperties decorationProperties)
		{
			if (behaviour is EnergyPoleDecorationBehaviour energyPoleDecorationBehaviour)
			{
				if (_gridConnectorData != null)
				{
					_gridConnectorData.Restore();
					_gridConnectorData.RestoreData(energyPoleDecorationBehaviour._decoration);
				}
				else
				{
					_gridComponentData.Restore();
					_gridComponentData.RestoreData(energyPoleDecorationBehaviour._decoration);
				}
			}
		}

		void IDecoBehaviourPersistentData.RestoreReferences()
		{
			if (_gridConnectorData != null)
			{
				_gridConnectorData.RestoreReferences();
			}
			else if (_gridComponentData != null)
			{
				_gridComponentData.RestoreReferences();
			}
		}
	}

	[SerializeField]
	private Decoration _decoration;

	[SerializeField]
	private BuildableColliders _poleColliders;

	[SerializeField]
	private SelectionLink _selectionLink;

	[SerializeField]
	private SelectionLink _quickConnectSelectionLink;

	private bool _hasBeenInitialized;

	public Decoration Deco => _decoration;

	protected override void Awake()
	{
		base.Awake();
		if (_selectionLink != null)
		{
			_selectionLink.SetObjectToSelect(base.gameObject, ObjectType.Decoration);
			_selectionLink.SetOnShowTooltipListener(OnShowTooltip);
			_selectionLink.SetOnSelectedListener(OnSelected);
			_selectionLink.SetOnDeselectedListener(OnDeselected);
		}
		if (_quickConnectSelectionLink != null)
		{
			_quickConnectSelectionLink.SetObjectToSelect(base.gameObject, ObjectType.Decoration);
			_selectionLink.SetOnShowTooltipListener(OnShowQuickConnectTooltip);
			_selectionLink.SetOnSelectedListener(OnQuickConnectSelected);
			_selectionLink.SetOnDeselectedListener(OnQuickConnectDeselected);
		}
	}

	public void Initialize()
	{
		if (!_hasBeenInitialized)
		{
			_hasBeenInitialized = true;
			if (_poleColliders != null)
			{
				_poleColliders.ActivateColliders();
			}
		}
	}

	string ITooltipProvider.GetTooltip(TooltipBuilder tooltipBuilder)
	{
		return _decoration.Name;
	}

	public void OnShowTooltip()
	{
		TooltipPanel.ShowTooltip(this);
	}

	public void OnSelected(bool playSelectionSound)
	{
		_decoration.Select();
	}

	public void OnDeselected()
	{
		_decoration.Deselect();
	}

	public void OnShowQuickConnectTooltip()
	{
		if (!_decoration.TryGetExtendable<EnergyGridDecorationComponent>(out var extendable) || !extendable.CanConnect())
		{
			OnShowTooltip();
		}
	}

	public void OnQuickConnectSelected(bool playSelectionSound)
	{
		if (!_decoration.TryGetExtendable<EnergyGridDecorationComponent>(out var extendable) || !extendable.CanConnect())
		{
			OnSelected(playSelectionSound);
		}
	}

	public void OnQuickConnectDeselected()
	{
		if (!_decoration.TryGetExtendable<EnergyGridDecorationComponent>(out var extendable) || !extendable.CanConnect())
		{
			OnDeselected();
		}
	}

	IDecoBehaviourPersistentData IDecorationBehaviour.GetPersistentData()
	{
		return new PersistentData(this);
	}
}
