using UnityEngine;

[ExecuteInEditMode]
public class CameraPixelated : ImageEffectBase
{
	public float TileCount = 100f;

	public bool IncludeNoise = true;

	public float NoiseScale = 1f;

	public Texture NoiseTexture;

	public bool DecreaseQualityOnDistance = true;

	public float OuterQualityScale = 10f;

	public bool UseBandedQuality = true;

	public float BandSize = 0.1f;

	public Texture RandomTexture;

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		if (NoiseTexture != null)
		{
			base.material.SetTexture("_NoiseTex", NoiseTexture);
		}
		else
		{
			Debug.Log("No/Invalid Noise Texture!");
		}
		if (RandomTexture != null)
		{
			base.material.SetTexture("_RandomTex", RandomTexture);
		}
		base.material.SetFloat("_TileCount", TileCount);
		if (IncludeNoise)
		{
			base.material.SetFloat("_IncludeNoise", 1f);
		}
		else
		{
			base.material.SetFloat("_IncludeNoise", 0f);
		}
		base.material.SetFloat("_NoiseScale", NoiseScale);
		if (DroneManager.Instance != null && DroneManager.Instance.CurrentDrone != null)
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag("DroneMainCamera");
			if (gameObject != null)
			{
				Transform transform = gameObject.transform;
				Vector3 vector = transform.InverseTransformPoint(DroneManager.Instance.CurrentDrone.gameObject.transform.position);
				Vector4 vector2 = new Vector4(vector.x, vector.y, vector.z, 1f);
				vector2.x += 0.5f;
				vector2.y += 0.5f;
				base.material.SetVector("_ObjectPos", vector2);
			}
		}
		if (DecreaseQualityOnDistance)
		{
			base.material.SetFloat("_DecreaseQualityOnDistance", 1f);
		}
		else
		{
			base.material.SetFloat("_DecreaseQualityOnDistance", 0f);
		}
		base.material.SetFloat("_OuterQualityScale", OuterQualityScale);
		if (UseBandedQuality)
		{
			base.material.SetFloat("_UseBandedQuality", 1f);
		}
		else
		{
			base.material.SetFloat("_UseBandedQuality", 0f);
		}
		base.material.SetFloat("_BandSize", BandSize);
		Graphics.Blit(src, dest, base.material);
	}
}
