using System.Collections.Generic;
using UnityEngine;

public class ModuleVisual : MonoBehaviour
{
	[SerializeField]
	private ModuleProperties _properties;

	private Buildable _buildable;

	public ModuleProperties Properties => _properties;

	private void Update()
	{
	}

	public void Initialize(Buildable buildable, List<ModuleProperties> activeModules)
	{
		_buildable = buildable;
		base.gameObject.SetActive(activeModules.Contains(_properties));
	}

	public bool Activate(Buildable buildable, ModuleProperties properties)
	{
		if (_properties == properties)
		{
			base.gameObject.SetActive(value: true);
			return true;
		}
		return false;
	}

	public bool Deactivate(ModuleProperties properties)
	{
		if (_properties == properties)
		{
			base.gameObject.SetActive(value: false);
			return true;
		}
		return false;
	}
}
