using System;
using Placemaker.SceneProcessing;
using UnityEngine;

namespace Placemaker
{
	public class TexturePngMaster : MonoBehaviour, WorldMaster.IOnOnEnable, IOnScenePostProcess
	{
		[Serializable]
		public class PngTexture
		{
			public Texture2D srcTex;

			public Texture2D gameTex;

			public DateTime lastReadTime;

			public string diskName;

			public string shaderName;

			public Texture2D tex => null;
		}

		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		public PngTexture houseTex;

		[SerializeField]
		public PngTexture typeTex;

		[SerializeField]
		public PngTexture paletteTex;

		[SerializeField]
		public Shader bakeShader;

		public RenderTexture bakedTex;

		private Material bakeMaterial;

		private bool bakeDirty;

		private void BakePalette()
		{
		}

		void WorldMaster.IOnOnEnable.OnOnEnable(WorldMaster worldMaster)
		{
		}

		private void OnApplicationFocus(bool focus)
		{
		}

		private void ReadAllFromDisk()
		{
		}

		private bool ReadOrWriteTexture(PngTexture pngTexture)
		{
			return false;
		}

		public void ResetColorAndMaterial()
		{
		}

		private void CleanTexture(PngTexture pngTexture)
		{
		}

		void IOnScenePostProcess.OnScenePostProcess(bool isBuild, TargetPlatformFlags platform)
		{
		}
	}
}
