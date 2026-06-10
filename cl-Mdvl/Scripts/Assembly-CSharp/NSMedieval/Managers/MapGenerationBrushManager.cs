using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Model.MapNew;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.Managers
{
	public class MapGenerationBrushManager : MonoSingleton<MapGenerationBrushManager>
	{
		private readonly Dictionary<string, float[]> brushesThreaded = new Dictionary<string, float[]>();

		private readonly Dictionary<string, Vector2Int> brushesSize = new Dictionary<string, Vector2Int>();

		public float[] GetBrushData(string brushId)
		{
			return brushesThreaded.GetValueOrDefault(brushId);
		}

		public Vector2Int GetBrushSize(string brushId)
		{
			return brushesSize[brushId];
		}

		public void TryCacheBrushData(NSMedieval.Model.MapNew.Map mapType)
		{
			foreach (MapGenerationStep2 mapGenerationStep in mapType.MapGenerationSteps)
			{
				foreach (string brushID in mapGenerationStep.BrushIDs)
				{
					if (!brushesThreaded.ContainsKey(brushID))
					{
						Texture2D texture2D = AssetUtils.GetTexture2D(brushID);
						Color32[] pixels = texture2D.GetPixels32();
						float[] array = new float[pixels.Length];
						int i = 0;
						for (int num = pixels.Length; i < num; i++)
						{
							array[i] = (float)(int)pixels[i].r / 255f;
						}
						brushesThreaded.Add(brushID, array);
						brushesSize.Add(brushID, new Vector2Int(texture2D.width, texture2D.height));
					}
				}
				foreach (string item in mapGenerationStep.BrushIDsLarge)
				{
					if (!brushesThreaded.ContainsKey(item))
					{
						Texture2D texture2D2 = AssetUtils.GetTexture2D(item);
						Color32[] pixels2 = texture2D2.GetPixels32();
						float[] array2 = new float[pixels2.Length];
						int j = 0;
						for (int num2 = pixels2.Length; j < num2; j++)
						{
							array2[j] = (float)(int)pixels2[j].r / 255f;
						}
						brushesThreaded.Add(item, array2);
						brushesSize.Add(item, new Vector2Int(texture2D2.width, texture2D2.height));
					}
				}
			}
		}
	}
}
