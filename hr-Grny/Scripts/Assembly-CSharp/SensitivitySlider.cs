using System;
using UnityEngine;

[Serializable]
public class SensitivitySlider : MonoBehaviour
{
	public float hSliderValue;

	public GUIStyle style;

	public GUIStyle style1;

	private Rect defaultRect;

	public saveSensitivityData scriptC;

	public GameObject savedValue;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void OnGUI()
	{
	}
}
