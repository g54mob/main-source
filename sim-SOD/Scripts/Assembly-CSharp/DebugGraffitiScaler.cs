using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class DebugGraffitiScaler : MonoBehaviour
{
	public ArtPreset art;

	public DecalProjector decal;

	public float pixelScaleMultiplier;

	[Button(null, EButtonEnableMode.Always)]
	public void LoadArt()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void SetScale()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void SavePixelScale()
	{
	}
}
