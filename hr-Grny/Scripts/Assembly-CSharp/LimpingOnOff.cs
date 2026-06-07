using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class LimpingOnOff : MonoBehaviour
{
	public bool limpingOnOff;

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
