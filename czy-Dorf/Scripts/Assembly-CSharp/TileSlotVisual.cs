using UnityEngine;

public class TileSlotVisual : MonoBehaviour
{
	private MeshRenderer tileSlotRenderer;

	[SerializeField]
	private Color validColor;

	[SerializeField]
	private Color invalidColor;

	[SerializeField]
	private Material standardMaterial;

	[SerializeField]
	private Material invalidMaterial;

	public bool IsVisible => tileSlotRenderer.isVisible;

	private void Awake()
	{
		tileSlotRenderer = GetComponentInChildren<MeshRenderer>();
	}

	public void ChangeState(TileSlotState state)
	{
		tileSlotRenderer.enabled = state != TileSlotState.Invalid;
		tileSlotRenderer.sharedMaterial = ((state == TileSlotState.InvalidButVisible) ? invalidMaterial : standardMaterial);
	}

	public void ApplyBiomeConfiguration(BiomeObjectConfiguration biomeConfiguration)
	{
		foreach (BiomeEffectValue biomeEffectValue in biomeConfiguration.biomeEffectValues)
		{
			if (biomeEffectValue.value is Color value)
			{
				tileSlotRenderer.material.SetColor(biomeEffectValue.key, value);
			}
			else if (biomeEffectValue.value is Texture2D value2)
			{
				tileSlotRenderer.material.SetTexture(biomeEffectValue.key, value2);
			}
		}
	}
}
