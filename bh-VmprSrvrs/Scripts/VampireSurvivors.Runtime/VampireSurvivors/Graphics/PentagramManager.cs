using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using VampireSurvivors.Data;
using Zenject;

namespace VampireSurvivors.Graphics
{
	public class PentagramManager : IInitializable, IDisposable
	{
		private static readonly Dictionary<PentagramType, Texture2D> PentagramTextures;

		private static readonly Dictionary<PentagramType, Sprite> PentagramSprites;

		private const int RTDepth = 0;

		private const int RTWidth = 256;

		private const int RTHeight = 256;

		private Texture2D _circle;

		private Color _goodTint;

		private Color _badTint;

		private Color _sireTint;

		private Color[] _tints;

		private bool _hasBeenGenerated;

		private SignalBus _signalBus;

		private Material _pentagramMaterial;

		private CommandBuffer _commandBuffer;

		[Inject]
		private void Construct(SignalBus signalBus)
		{
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public static Texture2D GetTexture(PentagramType pentagram)
		{
			return null;
		}

		public static Sprite GetSprite(PentagramType pentagram)
		{
			return null;
		}

		private void GenerateTextures()
		{
		}

		private Texture2D DoBlitter(Sprite[] sprites, Color[] tints, PentagramType type)
		{
			return null;
		}

		private Texture2D PadTexture(Texture2D texture, int width, int height)
		{
			return null;
		}

		private void CopyToRT(Texture2D texture, RenderTexture renderTexture, MaterialType matType = MaterialType.Vfx)
		{
		}

		private void RenderCircle(Texture2D texture, RenderTexture renderTexture, int width, int height, float circleScale, Color circleTint)
		{
		}

		private void MergeAndSaveTexture(Sprite[] sprites, Color[] tints, PentagramType key, float circleScale, Color circleTint, MaterialType matType)
		{
		}

		private void SaveMergedTexture(Texture2D texture, PentagramType key)
		{
		}

		private void SaveMergedSprite(Sprite sprite, PentagramType key)
		{
		}
	}
}
