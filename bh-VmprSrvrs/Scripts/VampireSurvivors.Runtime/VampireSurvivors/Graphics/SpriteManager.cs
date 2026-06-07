using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using UnityEngine;
using VampireSurvivors.Framework;
using Zenject;

namespace VampireSurvivors.Graphics
{
	public class SpriteManager : IInitializable
	{
		public class StringHashCaseIComparer : IEqualityComparer<StringHashCaseI>
		{
			public static readonly StringHashCaseIComparer Instance;

			public bool Equals(StringHashCaseI x, StringHashCaseI y)
			{
				return false;
			}

			public int GetHashCode(StringHashCaseI obj)
			{
				return 0;
			}
		}

		public struct StringHashCaseI : IEquatable<StringHashCaseI>
		{
			public readonly int _Hash;

			public StringHashCaseI(string str)
			{
				_Hash = 0;
			}

			public StringHashCaseI(string str, bool ignoreExtension)
			{
				_Hash = 0;
			}

			public static implicit operator StringHashCaseI(string str)
			{
				return default(StringHashCaseI);
			}

			public static int GetStrHashCode(string str, int lenght = -1)
			{
				return 0;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}

			public bool Equals(StringHashCaseI other)
			{
				return false;
			}
		}

		public static bool HighlightMissingAssetErrors;

		private Sprite[] _rawSprites;

		private static readonly Dictionary<StringHashCaseI, Sprite> Sprites;

		private static readonly Dictionary<StringHashCaseI, string> AnimationsTextureReferences;

		private static readonly Dictionary<StringHashCaseI, List<Sprite>> Animations;

		private static readonly Dictionary<StringHashCaseI, Texture2D> SpritesAsTextures;

		private static readonly Dictionary<StringHashCaseI, Dictionary<StringHashCaseI, Sprite>> SpriteTextureReference;

		private static readonly Dictionary<int, string> FastAnimationsTextureReferences;

		private static readonly Dictionary<int, List<Sprite>> FastAnimations;

		private static readonly bool LogWarnings;

		private static readonly Dictionary<string, Dictionary<string, Sprite>> SpriteTextureCache;

		private static readonly ProfilerMarker MarkerGetSprite1;

		private static readonly ProfilerMarker MarkerGetSprite2;

		private static readonly ProfilerMarker _markerGetAnimationFrames;

		private static readonly ProfilerMarker MarkerGetAnimationFramesFast;

		public void Initialize()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Sprite GetSpriteFast(string spriteName, string textureName)
		{
			return null;
		}

		public static Sprite GetSprite(string spriteName, bool ignoreExtension = true)
		{
			return null;
		}

		public static Sprite GetUnpackedSprite(string spriteName, bool ignoreExtension = true)
		{
			return null;
		}

		public static bool TextureExists(string textureName)
		{
			return false;
		}

		public static Sprite GetSprite(SpriteTextureData sprite)
		{
			return null;
		}

		[Obsolete("Use \"SpriteTextures.\" instead of strings", false)]
		public static Sprite GetSprite(string spriteName, string textureName, bool ignoreExtension = true)
		{
			return null;
		}

		public static bool DoesSpriteExistInTexture(string spriteName, string textureName, bool ignoreExtension = true)
		{
			return false;
		}

		public static Sprite GetUnpackedSprite(string spriteName, Vector2 newPivot)
		{
			return null;
		}

		[Obsolete("Use \"SpriteTextures.\" instead of strings", false)]
		public static Sprite GetSprite(string spriteName, Vector2 newPivot, string textureName, bool respectOriginalXPivot = false)
		{
			return null;
		}

		public static Sprite GetSprite(SpriteTextureData sprite, Vector2 newPivot, bool respectOriginalXPivot = false)
		{
			return null;
		}

		public static Texture2D GetSpriteAsTexture(string spriteName, string textureName, bool generateMipMaps = false)
		{
			return null;
		}

		public static List<Sprite> GetAnimation(string animName, int startValue, int frameCount, string textureName, bool addLeadingZeros = true)
		{
			return null;
		}

		public static List<Sprite> GetAnimationFrames(SpriteAnimationData spriteAnimation, int zeroPad = 0)
		{
			return null;
		}

		public static List<Sprite> GetAnimationFrames(string animName, int start, int end, string textureName, int zeroPad = 0)
		{
			return null;
		}

		public static List<Sprite> GetAnimationFrames(SpriteAnimationData spriteAnimation, Vector2 pivot, int zeroPad = 0, bool respectOriginalXPivot = false)
		{
			return null;
		}

		public static List<Sprite> GetAnimationFrames(string animName, int start, int end, Vector2 pivot, string textureName, int zeroPad = 0, bool respectOriginalXPivot = false)
		{
			return null;
		}

		public static List<Sprite> GetAnimationFrames(List<string> frameNames, string textureName)
		{
			return null;
		}

		public static List<Sprite> GetAnimationFrames(List<string> frameNames, string textureName, Vector2 pivot)
		{
			return null;
		}

		public static List<Sprite> GetAnimationFramesFast(List<string> frameNames, string textureName, bool skipCache = false)
		{
			return null;
		}

		public static List<string> GenerateFrameNames(int start, int end, int zeroPad = 0, string prefix = null)
		{
			return null;
		}

		private void LoadAllSpriteSheets()
		{
		}

		public static void RegisterSprites(Sprite[] rawSprites)
		{
		}

		public static void RegisterSprite(Sprite s)
		{
		}

		public static Sprite UnregisterSprite(string spriteName)
		{
			return null;
		}

		public static void UnregisterTexture(string textureName)
		{
		}

		private static string RemoveExtension(string name)
		{
			return null;
		}

		private static bool CheckIfAnimationExists(string name)
		{
			return false;
		}

		private static void AddCustomPhaserMappings()
		{
		}

		private static List<string> FramesNumberArray(int start, int end, string prefix = null, string suffix = null)
		{
			return null;
		}
	}
}
