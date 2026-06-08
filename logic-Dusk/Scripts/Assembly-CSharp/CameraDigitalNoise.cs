using UnityEngine;

[ExecuteInEditMode]
public class CameraDigitalNoise : ImageEffectBase
{
	[Header("Grain Texture")]
	[Tooltip("The texture used to 'decide' when distortion appears.\n\nTwo reads are done at different uv coords (based on UV Scale and Scrool Speed).\r\n\r\nOnly when both reads have a dark area overlap does distorion occur.")]
	public Texture2D grainTexture;

	[Tooltip("The UV scale of the first pass read of the grain texture.\r\n\r\nThe smaller the scale, the more likely a) distortion, b) larger distortion, and c) more fluid (less \"pop\") static.\r\n\r\nToo high and there will be no distortion.\r\n\r\nBoth grain uv scales can be the same.")]
	public float grainUVScale1 = 0.5f;

	[Tooltip("The UV scale of the second pass read of the grain texture.\r\n\r\nThe smaller the scale, the more likely a) distortion, b) larger distortion, and c) more fluid (less \"pop\") static.\r\n\r\nToo high and there will be no distortion.\r\n\r\nBoth grain uv scales can be the same.")]
	public float grainUVScale2 = 0.5f;

	[Tooltip("The scroll speed of the first pass read of the grain texture.\r\n\r\nGrain #1 scrolls diagnally from upper left to lower right.\r\n\r\nThe overal effect of this one depends heavily on the grain image and it's UV scale, however, in general, the slower the scroll rate, the less frequent the distorion but the longer it will remain visible.\r\n\r\nThe larger the number, the slower the speed.\r\n\r\nEffective formula:\r\nspeed = time / speedValue")]
	public float grainScrollSpeed1 = 1f / 12f;

	[Tooltip("The scroll speed of the second pass read of the grain texture.\r\n\r\nGrain #2 scrolls diagnally from upper right to lower left.\r\n\r\nThe overal effect of this one depends heavily on the grain image and it's UV scale, however, in general, the slower the scroll rate, the less frequent the distorion but the longer it will remain visible.\r\n\r\nThe larger the number, the slower the speed.\r\n\r\nEffective formula:\r\nspeed = time / speedValue")]
	public float grainScrollSpeed2 = 1f / 12f;

	[Tooltip("The 'tile count' of pixelated (distored) area\r\n\r\nThe smaller the grain UV scales, the less likely this will be noticable.")]
	[Header("Distortation Options")]
	public float pixelatedTileCount = 100f;

	[Tooltip("The cut off for an area being \"dark enough\" to be made distorted.")]
	public float sensitivity = 0.05f;

	[Tooltip("A 'clipping' value to throw out some distortion.\r\n\r\nIt's an odd formula:\r\nclip = if time % clip 0.005 < sensitivityClip.\r\n\r\nSet to 0 to not clip at all.\r\n\r\nWarning: setting to the hardcoded 0.005 or higher will stop distortion, all together (all will be clipped).")]
	public float sensitivityClip = 0.004f;

	[Tooltip("This color is ADDED to the final, distorted color.\r\n\r\nUse the ALPHA channel to control it's influence.\r\n\r\nSet a = 0 to disable.\r\n\r\nEffective formula:\r\nfinalColor = finalColor.rgb + ( tintColor.rgb * tintColor.a )")]
	[Header("Other Settings")]
	public Color distortedTint = Color.red;

	[Tooltip("The tint multiplier.\r\n\r\nNote that this brightens the color AFTER the tint alpha has been applied (so it a = 0, there's no net effect whereas if a = 1, this value is applied at full strength)")]
	public float distortedTintBrightness = 1f;

	[Tooltip("Build around distorting 3D objects, but enable this to include the floor")]
	public bool distortFloor;

	[Header("External Render Textures")]
	public RenderTexture depthTexture;

	public RenderTexture lightMaskTexture;

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		if (grainTexture != null)
		{
			base.material.SetTexture("_GrainTex", grainTexture);
		}
		if (depthTexture != null)
		{
			base.material.SetTexture("_DepthTex", depthTexture);
		}
		if (lightMaskTexture != null)
		{
			base.material.SetTexture("_LightMaskTex", lightMaskTexture);
		}
		base.material.SetFloat("_GrainUVScale1", grainUVScale1);
		base.material.SetFloat("_GrainUVScale2", grainUVScale2);
		base.material.SetFloat("_GrainScrollSpeed1", grainScrollSpeed1);
		base.material.SetFloat("_GrainScrollSpeed2", grainScrollSpeed2);
		base.material.SetFloat("_Sensitivity", sensitivity);
		base.material.SetFloat("_SensitivityClip", sensitivityClip);
		base.material.SetFloat("_TileCount", pixelatedTileCount);
		base.material.SetColor("_TintColor", distortedTint);
		base.material.SetFloat("_TintBrightness", distortedTintBrightness);
		if (distortFloor)
		{
			base.material.SetFloat("_IncludeFloor", 1f);
		}
		else
		{
			base.material.SetFloat("_IncludeFloor", 0f);
		}
		Graphics.Blit(src, dest, base.material);
	}
}
