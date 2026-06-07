using System.Collections.Generic;
using UnityEngine;

public class QuickConnecting : MonoBehaviour
{
	[SerializeField]
	private EnergyGridConnectCursorProperties _cursorProperties;

	private static readonly List<QuickConnecting> _quickConnectors = new List<QuickConnecting>();

	private GameObject _connectingParticle;

	public EnergyGridConnector Component { get; private set; }

	public static IReadOnlyList<QuickConnecting> QuickConnectors => _quickConnectors;

	private void Awake()
	{
		Component = base.transform.GetComponentInParent<EnergyGridConnector>();
		_connectingParticle = base.transform.GetComponentInChildren<ParticleSystem>().gameObject;
		_quickConnectors.Add(this);
		DisableParticle();
	}

	private void OnDestroy()
	{
		_quickConnectors.Remove(this);
	}

	public void EnableParticle()
	{
		if (Component.CanConnect())
		{
			_connectingParticle.SetActive(value: true);
		}
	}

	public void DisableParticle()
	{
		_connectingParticle.SetActive(value: false);
	}

	public void StartLinking()
	{
		if (Component.CanConnect() && !(GameManager.CursorManager.Properties == _cursorProperties))
		{
			_cursorProperties.Initialize(Component);
			GameManager.CursorManager.Activate(_cursorProperties);
		}
	}
}
