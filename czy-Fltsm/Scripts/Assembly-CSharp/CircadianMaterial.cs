using System;
using UnityEngine;

public class CircadianMaterial : SceneBehaviour
{
	[Serializable]
	public struct Color
	{
		public string Property;

		public Gradient Gradient;

		public void Apply(Material material, float dayTimeBlend)
		{
			material.SetColor(Property, Gradient.Evaluate(dayTimeBlend));
		}
	}

	[SerializeField]
	private Color[] _colorProperties;

	private Renderer _renderer;

	protected override void Awake()
	{
		base.Awake();
		_renderer = GetComponent<Renderer>();
	}

	private void OnEnable()
	{
		UpdateProperties();
	}

	private void LateUpdate()
	{
		UpdateProperties();
	}

	private void UpdateProperties()
	{
		float dayTimeBlend = GameManager.TimeManager.ReturnDayNightBlend();
		Color[] colorProperties = _colorProperties;
		foreach (Color color in colorProperties)
		{
			color.Apply(_renderer.material, dayTimeBlend);
		}
	}
}
