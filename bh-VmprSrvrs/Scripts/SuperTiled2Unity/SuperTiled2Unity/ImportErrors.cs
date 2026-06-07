using System;
using System.Collections.Generic;
using UnityEngine;

namespace SuperTiled2Unity
{
	public class ImportErrors : ScriptableObject
	{
		[Serializable]
		public class MissingTileSprites
		{
			[Serializable]
			public class MissingSprite
			{
				public int m_SpriteId;

				public Rect m_Rect;
			}

			public string m_TextureAssetPath;

			public List<MissingSprite> m_MissingSprites;

			public void AddMissingSprite(int spriteId, int x, int y, int w, int h)
			{
			}
		}

		[Serializable]
		public class WrongPixelsPerUnit
		{
			public string m_DependencyAssetPath;

			public float m_DependencyPPU;

			public float m_ExpectingPPU;
		}

		[Serializable]
		public class WrongTextureSize
		{
			public string m_TextureAssetPath;

			public int m_ExpectedWidth;

			public int m_ExpectedHeight;

			public int m_ActualWidth;

			public int m_ActualHeight;
		}

		public List<string> m_MissingDependencies;

		public List<string> m_ErrorsInAssetDependencies;

		public List<MissingTileSprites> m_MissingTileSprites;

		public List<WrongPixelsPerUnit> m_WrongPixelsPerUnits;

		public List<WrongTextureSize> m_WrongTextureSizes;

		public List<string> m_MissingTags;

		public List<string> m_MissingLayers;

		public List<string> m_MissingSortingLayers;

		public List<string> m_GenericErrors;

		public void ReportMissingDependency(string assetPath)
		{
		}

		public void ReportErrorsInDependency(string assetPath)
		{
		}

		public void ReportMissingSprite(string textureAssetPath, int spriteId, int x, int y, int w, int h)
		{
		}

		public void ReportWrongTextureSize(string textureAssetPath, int expected_w, int expected_h, int actual_w, int actual_h)
		{
		}

		public void ReportWrongPixelsPerUnit(string dependencyAssetPath, float dependencyPPU, float ourPPU)
		{
		}

		public void ReportMissingTag(string tag)
		{
		}

		public void ReportMissingLayer(string layer)
		{
		}

		public void ReportMissingSortingLayer(string sortingLayer)
		{
		}

		public void ReportGenericError(string error)
		{
		}
	}
}
