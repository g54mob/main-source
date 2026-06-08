using UnityEngine;

public class TileGround : MonoBehaviour, IBiomeAffectedObject, ITileStateReceiver
{
	[SerializeField]
	protected MeshRenderer tileGroundRenderer;

	[SerializeField]
	protected Tile tile;

	[SerializeField]
	private bool ignoreBiomeEffect;

	protected BiomeObjectConfiguration currentBiomeConfiguration;

	public GroupType GroupType => null;

	public ElementType ElementType => null;

	public ElementSubType SubType => null;

	public int Seed => tile.Seed;

	public float VariationAlpha => 0.5f;

	private void Awake()
	{
		InitializeTileReferences();
	}

	protected virtual void InitializeTileReferences()
	{
		tileGroundRenderer = GetComponentInChildren<MeshRenderer>();
	}

	public void ApplyBiomeConfiguration(BiomeObjectConfiguration biomeConfiguration)
	{
		if (ignoreBiomeEffect)
		{
			return;
		}
		if (!tileGroundRenderer)
		{
			InitializeTileReferences();
		}
		foreach (BiomeEffectValue biomeEffectValue in biomeConfiguration.biomeEffectValues)
		{
			if (biomeEffectValue.value is Color value)
			{
				tileGroundRenderer.material.SetColor(biomeEffectValue.key, value);
			}
			else if (biomeEffectValue.value is Texture2D value2)
			{
				tileGroundRenderer.material.SetTexture(biomeEffectValue.key, value2);
			}
		}
		currentBiomeConfiguration = new BiomeObjectConfiguration(biomeConfiguration);
	}

	public void ChangeTileState(TileState targetState)
	{
	}

	public void SetRendererLayer(int targetLayer)
	{
		if (!tileGroundRenderer)
		{
			InitializeTileReferences();
		}
		tileGroundRenderer.gameObject.layer = targetLayer;
	}

	public void SetAnimationsRunning(bool animationsRunning)
	{
	}

	public void SetTileReference(Tile tile)
	{
		this.tile = tile;
	}
}
