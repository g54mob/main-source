using System.IO;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class SplineBaker : MonoBehaviour
{
	[Tooltip("The spline to bake into a texture.")]
	public SplineContainer targetSpline;

	[Header("Output Settings")]
	[Tooltip("The width of the texture. Higher values provide more points along the spline.")]
	public int textureWidth = 1024;

	[Tooltip("The path within the Assets folder to save the generated position map texture.")]
	public string savePath = "Assets/Generated/SplinePositionMap.exr";

	public void BakeSpline()
	{
		if (targetSpline == null)
		{
			Debug.LogError("Target Spline is not assigned. Aborting bake.");
			return;
		}
		Debug.Log($"Baking spline data to a {textureWidth}x1 texture...");
		Texture2D texture2D = new Texture2D(textureWidth, 1, TextureFormat.RGBAFloat, mipChain: false);
		for (int i = 0; i < textureWidth; i++)
		{
			float t = (float)i / (float)(textureWidth - 1);
			float3 float5 = targetSpline.EvaluatePosition(t);
			texture2D.SetPixel(i, 0, new Color(float5.x, float5.y, float5.z, 1f));
		}
		texture2D.Apply();
		byte[] bytes = texture2D.EncodeToEXR();
		string directoryName = Path.GetDirectoryName(savePath);
		if (!Directory.Exists(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
		File.WriteAllBytes(savePath, bytes);
		Debug.Log("Texture data saved. Re-importing and configuring asset...");
		Debug.Log("Spline bake complete! Saved to " + savePath);
	}
}
