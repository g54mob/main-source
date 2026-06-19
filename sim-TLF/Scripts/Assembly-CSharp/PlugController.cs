using Energy;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnergyConsumerComponent))]
public class PlugController : MonoBehaviour
{
	public bool isConected;

	public UnityEvent OnWirePlugged;

	public UnityEvent OnWireUnplugged;

	public Transform plugPosition;

	[HideInInspector]
	public Transform endAnchor;

	[HideInInspector]
	public Rigidbody endAnchorRB;

	[HideInInspector]
	public WireController wireController;

	[SerializeField]
	private bool _canConnectAnyWire;

	[SerializeField]
	private EnergyConsumerComponent _consumerComponent;

	private MaleWire _connectedWire;

	private Vector3 _lastFramePos;

	private void Awake()
	{
		_consumerComponent = GetComponent<EnergyConsumerComponent>();
	}

	public void OnPlugged()
	{
		OnWirePlugged.Invoke();
	}

	public void OnUnplagged()
	{
		OnWireUnplugged.Invoke();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (_canConnectAnyWire)
		{
			if (other.TryGetComponent<MaleWire>(out var component))
			{
				component.RB.isKinematic = true;
				component.transform.position = plugPosition.position;
				component.transform.rotation = base.transform.rotation;
				isConected = true;
				_connectedWire = component;
				component.ConnectedPlug = this;
				OnPlugged();
				component.OnConnected?.Invoke(_consumerComponent.EnergyConsumer);
			}
		}
		else
		{
			Debug.Log(other.name);
			if (other.gameObject == endAnchor.gameObject)
			{
				isConected = true;
				endAnchorRB.isKinematic = true;
				endAnchor.transform.position = plugPosition.position;
				endAnchor.transform.rotation = base.transform.rotation;
				OnPlugged();
			}
		}
	}

	private void Update()
	{
		if (isConected)
		{
			if (_canConnectAnyWire)
			{
				_connectedWire.RB.isKinematic = true;
				_connectedWire.transform.position = plugPosition.position;
				Vector3 euler = new Vector3(base.transform.eulerAngles.x + 90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
				_connectedWire.transform.rotation = Quaternion.Euler(euler);
			}
			else
			{
				endAnchorRB.isKinematic = true;
				endAnchor.transform.position = plugPosition.position;
				Vector3 euler2 = new Vector3(base.transform.eulerAngles.x + 90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
				endAnchor.transform.rotation = Quaternion.Euler(euler2);
			}
		}
	}

	private void FixedUpdate()
	{
		if (isConected && Vector3.Distance(plugPosition.position, _connectedWire.transform.position) > 0.005f)
		{
			isConected = false;
			_connectedWire.RB.isKinematic = false;
			OnUnplagged();
			_connectedWire.OnDisconnected?.Invoke(_connectedWire.ConnectedConsumer);
			_connectedWire.ConnectedPlug = null;
			_connectedWire = null;
		}
	}
}
