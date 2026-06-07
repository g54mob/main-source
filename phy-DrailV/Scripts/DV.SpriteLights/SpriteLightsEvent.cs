using System;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLightsEvent : TimeBasedEvent
{
	[Serializable]
	public class SpriteLightMaterial
	{
		public float fromTime;

		public float toTime;

		public Material material;

		public SpriteLightType lightType;

		[NonSerialized]
		public List<MeshRenderer> renderers;

		[NonSerialized]
		public bool isOn;
	}

	public const int STROBE_TICKS = 5;

	public const int FOV = 50;

	public const int SCREEN_HEIGHT = 520;

	public List<SpriteLightMaterial> materials = new List<SpriteLightMaterial>();

	public bool[] LightTypeOn { get; private set; } = new bool[Enum.GetValues(typeof(SpriteLightType)).Length];

	public event Action<SpriteLightMaterial> MaterialUpdated;

	public override void Initialize()
	{
		SpriteLights.Init(0.2f, 0f, 50f, 520f);
		SpriteLightRenderer[] array = UnityEngine.Object.FindObjectsOfType<SpriteLightRenderer>();
		for (int i = 0; i < LightTypeOn.Length; i++)
		{
			LightTypeOn[i] = true;
		}
		foreach (SpriteLightMaterial material in materials)
		{
			material.renderers = new List<MeshRenderer>();
			SpriteLightRenderer[] array2 = array;
			foreach (SpriteLightRenderer spriteLightRenderer in array2)
			{
				if (spriteLightRenderer.meshRenderer.sharedMaterial.Equals(material.material))
				{
					material.renderers.Add(spriteLightRenderer.meshRenderer);
				}
			}
		}
	}

	public override void UpdateTime(float time)
	{
		for (int i = 0; i < materials.Count; i++)
		{
			bool isOn = materials[i].isOn;
			materials[i].isOn = !(materials[i].fromTime < time) || !(materials[i].toTime > time);
			for (int j = 0; j < materials[i].renderers.Count; j++)
			{
				MeshRenderer meshRenderer = materials[i].renderers[j];
				if (meshRenderer.enabled != materials[i].isOn)
				{
					meshRenderer.enabled = materials[i].isOn;
				}
			}
			if (isOn != materials[i].isOn)
			{
				this.MaterialUpdated?.Invoke(materials[i]);
			}
			LightTypeOn[(int)materials[i].lightType] = materials[i].isOn;
		}
	}
}
