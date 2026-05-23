using UnityEngine;

[CreateAssetMenu(fileName = "OneBitAssets.asset", menuName = "OneBitAssets", order = 42)]
public class OneBitAssets : ScriptableObject
{
	public Shader finalizeBasicShader;

	public Shader finalizeLinedShader;

	public Shader warpDefaultShader;

	public Shader warpNetherShader;

	public Shader wernessClassicShader;

	public Shader curtainShader;

	public Shader lineScale2xShader;

	public Shader thickenShader;

	public Shader distortVignetteShader;

	public Shader ditherShader;

	public Shader downscaleShader;

	public Shader sharpenOverlayShader;

	public Shader watchHandOnlyShader;

	public Shader examinerPostShader;

	public Shader glowShader;

	public Shader sparkleShader;

	public Shader shipEnder;

	public Texture2D curtainTexture;

	public Texture2D ditherTexture;

	public Texture2D warpDefaultTexture;

	public Texture2D warpNetherTexture;

	public RenderTexture overlayTexture;

	public Mesh ditherSphereMesh;

	public Material ditherSphereMaterial;

	public Supersampler supersampler;
}
