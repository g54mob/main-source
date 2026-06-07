using System;
using UnityEngine;

[Serializable]
public class EnabledValue<T>
{
	[SerializeField]
	private bool m_enabled;

	[SerializeField]
	private T m_value;

	public bool IsEnabled(out T value)
	{
		value = m_value;
		return m_enabled;
	}

	public void SetValue(bool enabled, T value)
	{
		m_enabled = enabled;
		m_value = value;
	}
}
