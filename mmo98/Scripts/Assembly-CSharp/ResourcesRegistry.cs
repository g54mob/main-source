using System;
using UnityEngine;

[Serializable]
public struct ResourcesRegistry
{
	public ValueNumericDisplay player;

	public ValueNumericDisplay money;

	public SliderNumericDisplay load;

	public ValueNumericDisplay ping;

	public ValueNumericDisplay hype;

	public ValueNumericDisplay bugs;

	public ValueNumericDisplay uptime;

	public ValueNumericDisplay fans;

	public ValueNumericDisplay data;

	public ValueNumericDisplay dataMax;

	public GameObject warningTicker;

	public GameObject criticalTicker;

	public GameObject pausedTicker;

	public GameObject pingUnreleased;

	public GameObject pingReleased;
}
