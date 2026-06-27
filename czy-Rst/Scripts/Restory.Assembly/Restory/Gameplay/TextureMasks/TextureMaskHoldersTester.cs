using System.Linq;
using Mandragora.PWS;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.TextureMasks
{
	public class TextureMaskHoldersTester : MonoBehaviour
	{
		private TextureMaskCreationService textureMaskCreator;

		private TextureMaskHolder[] textureMaskHolders = new TextureMaskHolder[0];

		[Inject]
		private void Construct(TextureMaskCreationService textureMaskCreator)
		{
			this.textureMaskCreator = textureMaskCreator;
		}

		private void Awake()
		{
			textureMaskHolders = GetComponentsInChildren<TextureMaskHolder>().ToArray();
		}

		private void GenerateNewRandomDirtTextureMask(MaskPresetInfoBase preset)
		{
			float resultingNoiseSeed;
			Texture2D restoredTexture = textureMaskCreator.CreateTextureMask(new Vector2Int(textureMaskHolders[0].WorkTexture.width, textureMaskHolders[0].WorkTexture.height), preset, out resultingNoiseSeed);
			TextureMaskHolder[] array = textureMaskHolders;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RestoreWorkTexture(restoredTexture);
			}
		}

		private void GenerateNewDirtTextureMask(MaskPresetInfoBase preset, float noiseSeed)
		{
			Texture2D restoredTexture = textureMaskCreator.CreateTextureMask(new Vector2Int(textureMaskHolders[0].WorkTexture.width, textureMaskHolders[0].WorkTexture.height), preset, noiseSeed);
			TextureMaskHolder[] array = textureMaskHolders;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RestoreWorkTexture(restoredTexture);
			}
		}

		private void TestTriangleBasedGeneration(MaskPresetInfoBase preset, float noiseSeed)
		{
			TextureMaskHolder[] array = textureMaskHolders;
			foreach (TextureMaskHolder textureMaskHolder in array)
			{
				Mesh sharedMesh = textureMaskHolder.SharedMesh;
				if ((bool)sharedMesh)
				{
					if (!textureMaskHolder.WorkTexture)
					{
						textureMaskHolder.Initialize();
					}
					MeshUVProcessor.ProcessingSettings meshSettings = new MeshUVProcessor.ProcessingSettings
					{
						enableWireframe = false,
						wireThickness = 0.5f,
						wrapUV = false,
						enableDebugOutput = true
					};
					textureMaskCreator.CreateTextureMaskWithMesh(textureMaskHolder.WorkTexture, preset, sharedMesh, meshSettings, noiseSeed, out var pixelsOnMeshCount);
					Debug.Log("✅ Треугольная генерация завершена! Меш: " + sharedMesh.name + ", " + $"треугольников: {sharedMesh.triangles.Length / 3}, " + $"пикселей всего на меше: {pixelsOnMeshCount}");
				}
			}
		}
	}
}
