using System;
using Energy;
using Items;
using UnityEngine;

public class MaleWire : MonoBehaviour, IGrabable
{
	public Action<IEnergyConsumer> OnConnected;

	public Action<IEnergyConsumer> OnDisconnected;

	public IEnergyConsumer ConnectedConsumer;

	public PlugController ConnectedPlug;

	[SerializeField]
	private Rigidbody _rigidbody;

	public Rigidbody RB => _rigidbody;

	Rigidbody IGrabable.Rigidbody => _rigidbody;

	private void Awake()
	{
		OnConnected = (Action<IEnergyConsumer>)Delegate.Combine(OnConnected, (Action<IEnergyConsumer>)delegate(IEnergyConsumer consumer)
		{
			ConnectedConsumer = consumer;
		});
	}

	void IGrabable.Grab()
	{
		_rigidbody.isKinematic = true;
	}

	void IGrabable.Ungrab()
	{
		_rigidbody.isKinematic = false;
	}
}
