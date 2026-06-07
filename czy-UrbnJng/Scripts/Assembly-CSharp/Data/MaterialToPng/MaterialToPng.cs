using System.IO;
using UnityEngine;

namespace Data.MaterialToPng
{
	public class MaterialToPng : MonoBehaviour
	{
		public Renderer targetRenderer;

		public int squareSize = 32;

		public void GenerateColorTexture()
		{
			if (targetRenderer == null)
			{
				Debug.LogError("Target Renderer is not set.");
				return;
			}
			Material[] sharedMaterials = targetRenderer.sharedMaterials;
			if (sharedMaterials == null || sharedMaterials.Length == 0)
			{
				Debug.LogError("No materials found on the target renderer.");
				return;
			}
			int num = Mathf.CeilToInt(Mathf.Sqrt(sharedMaterials.Length));
			int width = num * squareSize;
			int height = num * squareSize;
			Texture2D texture2D = new Texture2D(width, height);
			for (int i = 0; i < sharedMaterials.Length; i++)
			{
				Color color = sharedMaterials[i].color;
				int num2 = i / num;
				int num3 = i % num * squareSize;
				int num4 = num2 * squareSize;
				for (int j = num3; j < num3 + squareSize; j++)
				{
					for (int k = num4; k < num4 + squareSize; k++)
					{
						texture2D.SetPixel(j, k, color);
					}
				}
			}
			texture2D.Apply();
			byte[] array = texture2D.EncodeToPNG();
			if (array != null)
			{
				string path = targetRenderer.gameObject.name + ".png";
				string text = Path.Combine(Application.dataPath, "Materials/Plants/Pallets");
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				string text2 = Path.Combine(text, path);
				File.WriteAllBytes(text2, array);
				Debug.Log("Texture saved to: " + text2);
			}
			else
			{
				Debug.LogError("Failed to encode texture to PNG.");
			}
		}

		private void OnValidate()
		{
			if (targetRenderer != null)
			{
				GenerateColorTexture();
			}
		}
	}
}
