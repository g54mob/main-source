using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class FogOnOff : MonoBehaviour
{
	public bool fogOnOff;

	private Toggle m_Toggle;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	private void ToggleValueChanged(Toggle change)
	{
	}
}
