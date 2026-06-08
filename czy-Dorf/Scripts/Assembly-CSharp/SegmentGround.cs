using UnityEngine;

public class SegmentGround : MonoBehaviour, IBiomeAffectedObject
{
	private MeshRenderer segmentRenderer;

	private ElementGroupSegment groupSegment;

	public GroupType GroupType => groupSegment.GroupType;

	public ElementType ElementType => null;

	public ElementSubType SubType => groupSegment.GroupType.SegmentGroundSubType;

	public int Seed => groupSegment.Tile.Seed;

	public float VariationAlpha => 0.5f;

	public void Awake()
	{
		segmentRenderer = GetComponentInChildren<MeshRenderer>();
		groupSegment = GetComponentInParent<ElementGroupSegment>();
	}

	public void SetLayer(int targetLayer)
	{
		segmentRenderer.gameObject.layer = targetLayer;
	}

	public void ApplyBiomeConfiguration(BiomeObjectConfiguration biomeConfiguration)
	{
		foreach (BiomeEffectValue biomeEffectValue in biomeConfiguration.biomeEffectValues)
		{
			if (biomeEffectValue.value is Color value)
			{
				segmentRenderer.material.SetColor(biomeEffectValue.key, value);
			}
			else if (biomeEffectValue.value is Texture2D value2)
			{
				segmentRenderer.material.SetTexture(biomeEffectValue.key, value2);
			}
		}
	}
}
