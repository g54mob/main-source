using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EnergyGridConnectionPanel : MonoBehaviour, IBuildablePanelElement, IDecorationPanelElement
{
	[SerializeField]
	private ChildBehaviourCache<EnergyGridConnectionEntry> _entryPrefab;

	[SerializeField]
	private ChildGameObjectCache _emptyPrefab;

	[SerializeField]
	private EnergyGridConnectCursorProperties _cursorProperties;

	[SerializeField]
	[FormerlySerializedAs("_linkButton")]
	private Button _connectButton;

	private EnergyGridConnector _component;

	BuildablePanelElementId IBuildablePanelElement.Id => BuildablePanelElementId.EnergyGridLink;

	DecorationPanelElementId IDecorationPanelElement.Id => DecorationPanelElementId.EnergyGridLink;

	public bool Activate(Buildable buildable, bool finished)
	{
		if (buildable.TryReturnBuildableExtendable<EnergyGridBuildableComponent>(out var buildableExtendable))
		{
			Activate(buildableExtendable);
			return true;
		}
		return false;
	}

	public void Activate(Decoration decoration)
	{
		Activate(decoration.GetExtendable<EnergyGridDecorationComponent>());
	}

	private void Activate(EnergyGridConnector component)
	{
		if (!(component == _component))
		{
			_component = component;
			base.gameObject.SetActive(value: true);
			GameEventDispatcher.AddListener(GameEventType.EnergyGridConnectionAdded, OnConnectionsUpdate);
			GameEventDispatcher.AddListener(GameEventType.EnergyGridConnectionRemoved, OnConnectionsUpdate);
			UpdateConnections();
		}
	}

	public void Deactivate()
	{
		GameEventDispatcher.RemoveListener(GameEventType.EnergyGridConnectionAdded, OnConnectionsUpdate);
		GameEventDispatcher.RemoveListener(GameEventType.EnergyGridConnectionRemoved, OnConnectionsUpdate);
		_component = null;
		base.gameObject.SetActive(value: false);
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.EnergyGridConnectionAdded, OnConnectionsUpdate);
		GameEventDispatcher.RemoveListener(GameEventType.EnergyGridConnectionRemoved, OnConnectionsUpdate);
	}

	public void Connect()
	{
		_cursorProperties.Initialize(_component);
		GameManager.CursorManager.Activate(_cursorProperties);
	}

	private void OnConnectionsUpdate(GameEvent gameEvent)
	{
		EnergyGridConnectionEvent energyGridConnectionEvent = gameEvent as EnergyGridConnectionEvent;
		if (energyGridConnectionEvent.ComponentA == _component || energyGridConnectionEvent.ComponentB == _component)
		{
			UpdateConnections();
		}
	}

	private void UpdateConnections()
	{
		EnergyGridConnector[] connections = _component.Connections;
		_entryPrefab.Reset();
		_emptyPrefab.Reset();
		for (int i = 0; i < connections.Length; i++)
		{
			EnergyGridConnector energyGridConnector = connections[i];
			if (energyGridConnector == null)
			{
				_emptyPrefab.Get(active: true).transform.SetSiblingIndex(i);
			}
			else if (energyGridConnector.IsConnected(_component))
			{
				EnergyGridConnectionEntry energyGridConnectionEntry = _entryPrefab.Get(active: true);
				energyGridConnectionEntry.transform.SetSiblingIndex(i);
				energyGridConnectionEntry.Initialize(icon: energyGridConnector.IconSprite, name: energyGridConnector.Name, current: _component, connected: energyGridConnector);
			}
			else
			{
				Debug.LogError("Component " + _component.name + " returned a connector that it was not connected in.");
			}
		}
		_entryPrefab.Trim();
		_emptyPrefab.Trim();
		_connectButton.interactable = _component.CanConnect();
	}
}
