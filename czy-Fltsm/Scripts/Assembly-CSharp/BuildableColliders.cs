using PajamaLlama.Debugs;
using UnityEngine;

public class BuildableColliders : MonoBehaviour
{
	private Collider[] _buildableColliders;

	private void Awake()
	{
		_buildableColliders = GetComponentsInChildren<Collider>();
		for (int i = 0; i < _buildableColliders.Length; i++)
		{
			_buildableColliders[i].enabled = false;
		}
	}

	public void ActivateColliders()
	{
		if (_buildableColliders.Length == 0)
		{
			Debugger.Log("No extra colliders found on " + base.transform.parent.name, this, 3);
			return;
		}
		for (int i = 0; i < _buildableColliders.Length; i++)
		{
			_buildableColliders[i].enabled = true;
		}
	}
}
