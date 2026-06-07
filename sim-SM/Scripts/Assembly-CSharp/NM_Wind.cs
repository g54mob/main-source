using UnityEngine;

[ExecuteInEditMode]
public class NM_Wind : MonoBehaviour
{
	[Header("General Parameters")]
	[Tooltip("Wind Speed in Kilometers per hour")]
	public float WindSpeed;

	[Range(0f, 2f)]
	[Tooltip("Wind Turbulence in percentage of wind Speed")]
	public float Turbulence;

	[Header("Noise Parameters")]
	[Tooltip("Texture used for wind turbulence")]
	public Texture2D NoiseTexture;

	[Tooltip("Size of one world tiling patch of the Noise Texture, for bending trees")]
	public float FlexNoiseWorldSize;

	[Tooltip("Size of one world tiling patch of the Noise Texture, for leaf shivering")]
	public float ShiverNoiseWorldSize;

	[Header("Gust Parameters")]
	[Tooltip("Texture used for wind gusts")]
	public Texture2D GustMaskTexture;

	[Tooltip("Size of one world tiling patch of the Gust Texture, for leaf shivering")]
	public float GustWorldSize;

	[Tooltip("Wind Gust Speed in Kilometers per hour")]
	public float GustSpeed;

	[Tooltip("Wind Gust Influence on trees")]
	public float GustScale;

	[Header("Wind Sherical")]
	[Tooltip("Wind Gust Influence on trees")]
	public WindZone point1;

	public WindZone point2;

	public WindZone point3;

	public WindZone point4;

	private Vector4 pos1;

	private Vector4 pos2;

	private Vector4 pos3;

	private Vector4 pos4;

	private Vector4 radius;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnValidate()
	{
	}

	private void ApplySettings()
	{
	}

	private Vector4 GetDirectionAndSpeed()
	{
		return default(Vector4);
	}
}
