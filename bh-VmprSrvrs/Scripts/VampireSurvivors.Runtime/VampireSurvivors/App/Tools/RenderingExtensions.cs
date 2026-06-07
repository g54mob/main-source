using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.App.Tools
{
	public static class RenderingExtensions
	{
		private static ParticleSystem.Particle[] _cachedParticles;

		private static readonly int ApplyTint;

		private static readonly int TintColor;

		private static readonly int ApplyTintFill;

		private static readonly int TintFillColor;

		private static Dictionary<int, Sprite> s_circleCache;

		private static Shader s_atlasRectTrailShader;

		private static Shader s_atlasRectTrailAdditiveShader;

		private static int s_atlasRectTrailRectPropertyID;

		public static T SetAngle<T>(this T component, float angle, bool phaserSpace = true) where T : Component
		{
			return null;
		}

		public static T SetScale<T>(this T component, float scale) where T : Component
		{
			return null;
		}

		public static T SetScale<T>(this T component, float xScale, float yScale) where T : Component
		{
			return null;
		}

		public static void SetAlpha(this Image image, float alpha)
		{
		}

		public static TrailRenderer SetAlpha(this TrailRenderer trail, float alpha)
		{
			return null;
		}

		public static TrailRenderer SetTint(this TrailRenderer trail, uint tint)
		{
			return null;
		}

		public static string ToHex(this Color color)
		{
			return null;
		}

		public static void SetTintEnabled(this MaterialPropertyBlock propBlock, bool isEnabled)
		{
		}

		public static void SetTintColor(this MaterialPropertyBlock propBlock, Color tintColor)
		{
		}

		public static void SetTintColor(this Material material, Color tintColor)
		{
		}

		public static void SetTintFillEnabled(this MaterialPropertyBlock propBlock, bool isEnabled)
		{
		}

		public static void SetTintFillEnabled(this Material material, bool isEnabled)
		{
		}

		public static void SetTintFillColor(this MaterialPropertyBlock propBlock, Color tintColor)
		{
		}

		public static void SetTintFillColor(this Material material, Color tintColor)
		{
		}

		public static ParticleEmitterManager particles(this Factory behaviour, string texture = null)
		{
			return null;
		}

		public static ParticleSystem SetAngle(this ParticleSystem component, ParticleSystem.MinMaxCurve angle, int angleSteps = 0)
		{
			return null;
		}

		public static ParticleSystem SetTint(this ParticleSystem component, uint tint)
		{
			return null;
		}

		public static ParticleSystem SetTint(this ParticleSystem component, uint startTint, uint endTint)
		{
			return null;
		}

		private static Color32 HexToColor(uint hexVal)
		{
			return default(Color32);
		}

		public static ParticleSystem SetGravity(this ParticleSystem component, ParticleSystem.MinMaxCurve gravity)
		{
			return null;
		}

		public static ParticleSystem SetScale(this ParticleSystem component, float scale)
		{
			return null;
		}

		public static void SetScale(this ParticleSystem pfx, ParticleSystem.MinMaxCurve scale)
		{
		}

		public static void SetScaleX(this ParticleSystem pfx, ParticleSystem.MinMaxCurve scale)
		{
		}

		public static void SetScaleY(this ParticleSystem pfx, ParticleSystem.MinMaxCurve scale)
		{
		}

		public static void SetEmitZone(this ParticleSystem pfx, EmitZone emitZone)
		{
		}

		public static void SetQuantity(this ParticleSystem pfx, int quantity)
		{
		}

		public static void SetFrame(this ParticleSystem pfx, int frame)
		{
		}

		public static void SetFrames(this ParticleSystem pfx, List<string> frames, string spritesheet = null, bool clearExistingFrames = false, int cycleCount = 0)
		{
		}

		public static void SetSpeed(this ParticleSystem pfx, float min = 0f, float max = 0f)
		{
		}

		public static void SetSpeedX(this ParticleSystem pfx, ParticleSystem.MinMaxCurve value)
		{
		}

		public static void SetSpeedY(this ParticleSystem pfx, ParticleSystem.MinMaxCurve value)
		{
		}

		public static void SetCollisionBounds(this ParticleSystem particleSystem, ParticleSystemConfig config)
		{
		}

		public static void SetCollisionBoundsWorld(this ParticleSystem particleSystem, ParticleSystemConfig config)
		{
		}

		public static void SetCollisionBoundsCircle(this ParticleSystem particleSystem, ParticleSystemConfig config)
		{
		}

		public static void Start(this ParticleSystem pfx)
		{
		}

		public static void StopEmitting(this ParticleSystem pfx)
		{
		}

		public static void ForceClear(this ParticleSystem pfx)
		{
		}

		public static float GetRemainingLifetime(this ParticleSystem pfx)
		{
			return 0f;
		}

		public static void EmitParticleAt(this ParticleSystem system, Vector2 pos, int count = -1)
		{
		}

		public static void SetAlpha(this ParticleSystem system, ParticleSystem.MinMaxCurve value, Easing easing = Easing.Linear)
		{
		}

		public static void SetMaxParticles(this ParticleSystem ps, int maxParticles = 1000)
		{
		}

		public static Texture2D ConvertToTexture(this Sprite sprite, bool generateMipMaps = false)
		{
			return null;
		}

		public static void SetAlpha(this Material material, float alpha)
		{
		}

		public static TextMeshPro AddText(this MonoBehaviour monoBehaviour, Vector2 pos, string text)
		{
			return null;
		}

		public static TextMeshPro AddText(this GameObject gameObject, Vector2 pos, string text)
		{
			return null;
		}

		public static TextMeshPro SetAlpha(this TextMeshPro textMeshPro, float alpha)
		{
			return null;
		}

		public static TextMeshProUGUI SetAlpha(this TextMeshProUGUI textMeshPro, float alpha)
		{
			return null;
		}

		public static TextMeshPro SetTint(this TextMeshPro textMeshPro, params uint[] tints)
		{
			return null;
		}

		public static TextMeshPro SetTint(this TextMeshPro textMeshPro, uint tint)
		{
			return null;
		}

		public static TextMeshProUGUI SetTint(this TextMeshProUGUI textMeshPro, uint tint)
		{
			return null;
		}

		public static SpriteRenderer SetFlipX(this SpriteRenderer spriteRenderer, bool flipX)
		{
			return null;
		}

		public static SpriteRenderer SetFlipY(this SpriteRenderer spriteRenderer, bool flipY)
		{
			return null;
		}

		public static SpriteRenderer SetX(this SpriteRenderer spriteRenderer, float x)
		{
			return null;
		}

		public static SpriteRenderer SetY(this SpriteRenderer spriteRenderer, float y)
		{
			return null;
		}

		public static SpriteRenderer SetVisible(this SpriteRenderer spriteRenderer, bool visible)
		{
			return null;
		}

		public static SpriteRenderer SetName(this SpriteRenderer spriteRenderer, string name)
		{
			return null;
		}

		public static SpriteRenderer SetParent(this SpriteRenderer spriteRenderer, Transform parent, bool keepWorldPos = true)
		{
			return null;
		}

		public static SpriteRenderer SetAlpha(this SpriteRenderer spriteRenderer, float alpha)
		{
			return null;
		}

		public static SpriteRenderer SetBlendMode(this SpriteRenderer spriteRenderer, BlendMode blendMode)
		{
			return null;
		}

		public static SpriteRenderer SetTileMode(this SpriteRenderer spriteRenderer)
		{
			return null;
		}

		public static SpriteRenderer SetTintFill(this SpriteRenderer spriteRenderer, bool isEnabled, Color? tintColor = null)
		{
			return null;
		}

		public static SpriteRenderer SetTint(this SpriteRenderer spriteRenderer, params uint[] tints)
		{
			return null;
		}

		public static PhaserSprite SetTint(this PhaserSprite target, Color topLeft, Color topRight, Color bottomLeft, Color bottomRight, BlendMode blendMode = BlendMode.Normal)
		{
			return null;
		}

		public static PhaserSprite SetTint(this PhaserSprite target, uint topLeft, uint topRight, uint bottomLeft, uint bottomRight, BlendMode blendMode = BlendMode.Normal)
		{
			return null;
		}

		public static SpriteRenderer SetTint(this SpriteRenderer spriteRenderer, Color topLeft, Color topRight, Color bottomLeft, Color bottomRight, BlendMode blendMode)
		{
			return null;
		}

		public static SpriteRenderer FillStyle(this SpriteRenderer spriteRenderer, uint tint, float alpha)
		{
			return null;
		}

		public static SpriteRenderer FillCircle(this SpriteRenderer spriteRenderer, int radius, uint colourHex = 16777215u)
		{
			return null;
		}

		private static Texture2D GenerateCircle(this Texture2D tex, int x, int y, int r, Color color)
		{
			return null;
		}

		public static SpriteRenderer SetTint(this SpriteRenderer spriteRenderer, uint tint)
		{
			return null;
		}

		public static SpriteRenderer SetTint(this SpriteRenderer spriteRenderer, string tintString)
		{
			return null;
		}

		public static void SetTint(this SpriteRenderer spriteRenderer, Color? tint)
		{
		}

		[Obsolete("Use \"SpriteTextures.\" instead of strings", false)]
		public static SpriteRenderer AddSprite(this MonoBehaviour behaviour, float x, float y, string textureName = null, string spriteName = null)
		{
			return null;
		}

		public static SpriteRenderer AddSprite(this MonoBehaviour behaviour, float x, float y, SpriteTextureData sprite)
		{
			return null;
		}

		[Obsolete("Use \"SpriteTextures.\" instead of strings", false)]
		public static SpriteRenderer AddSprite(this MonoBehaviour behaviour, Vector2 pos, string textureName = null, string spriteName = null)
		{
			return null;
		}

		public static SpriteRenderer AddSprite(this MonoBehaviour behaviour, Vector2 pos, SpriteTextureData sprite)
		{
			return null;
		}

		[Obsolete("Use \"SpriteTextures.\" instead of strings", false)]
		public static SpriteRenderer AddSprite(this GameObject gameObject, float x, float y, string textureName = null, string spriteName = null)
		{
			return null;
		}

		public static SpriteRenderer AddSprite(this GameObject gameObject, float x, float y, SpriteTextureData sprite)
		{
			return null;
		}

		public static SpriteRenderer AddSprite(this GameObject gameObject, Vector2 pos, string textureName, string spriteName)
		{
			return null;
		}

		[Obsolete("Use \"SpriteTextures.\" instead of strings", false)]
		public static SpriteRenderer AddSprite(this MonoBehaviour behaviour, float x, float y, Vector2 pivot, string textureName = null, string spriteName = null)
		{
			return null;
		}

		public static SpriteRenderer AddSprite(this MonoBehaviour behaviour, float x, float y, Vector2 pivot, SpriteTextureData sprite)
		{
			return null;
		}

		[Obsolete("Use \"SpriteTextures.\" instead of strings", false)]
		public static SpriteRenderer AddSprite(this GameObject gameObject, float x, float y, Vector2 pivot, string textureName = null, string spriteName = null)
		{
			return null;
		}

		public static SpriteRenderer AddSprite(this GameObject gameObject, float x, float y, Vector2 pivot, SpriteTextureData sprite)
		{
			return null;
		}

		[Obsolete("Use \"SpriteTextures.\" instead of strings", false)]
		public static SpriteRenderer AddSprite(this MonoBehaviour behaviour, Vector2 pos, Vector2 pivot, string textureName = null, string spriteName = null)
		{
			return null;
		}

		public static SpriteRenderer AddSprite(this MonoBehaviour behaviour, Vector2 pos, Vector2 pivot, SpriteTextureData sprite)
		{
			return null;
		}

		public static SpriteRenderer AddSprite(this GameObject gameObject, Vector2 pos, Vector2 pivot, SpriteTextureData sprite)
		{
			return null;
		}

		[Obsolete("Use \"SpriteTextures.\" instead of strings", false)]
		public static SpriteRenderer AddSprite(this GameObject gameObject, Vector2 pos, Vector2 pivot, string textureName = null, string spriteName = null)
		{
			return null;
		}

		public static ArcadeSprite SetParent(this ArcadeSprite arcadeSprite, Transform parent, bool keepWorldPos = true)
		{
			return null;
		}

		[Obsolete("Use \"SpriteTextures.\" instead of strings", false)]
		public static ArcadeSprite AddArcadeSprite(this MonoBehaviour behaviour, Vector2 pos, string textureName = null, string spriteName = null)
		{
			return null;
		}

		public static ArcadeSprite AddArcadeSprite(this MonoBehaviour behaviour, Vector2 pos, SpriteTextureData sprite)
		{
			return null;
		}

		public static ArcadeSprite AddArcadeSprite(this GameObject gameObject, Vector2 pos, SpriteTextureData sprite)
		{
			return null;
		}

		[Obsolete("Use \"SpriteTextures.\" instead of strings", false)]
		public static ArcadeSprite AddArcadeSprite(this GameObject gameObject, Vector2 pos, string textureName, string spriteName)
		{
			return null;
		}

		public static PhaserText text(this Factory behaviour, Vector2 pos, string text, Color color, float fontSize = 12f)
		{
			return null;
		}

		public static BitmapText bitmapText(this Factory behaviour, Vector2 pos, string text, Color color, int fontSize = 12)
		{
			return null;
		}

		[Obsolete("Use \"SpriteTextures.\" instead of strings", false)]
		public static PhaserSprite sprite(this Factory behaviour, Vector2 pos, string textureName, string spriteName)
		{
			return null;
		}

		public static PhaserSprite sprite(this Factory behaviour, Vector2 pos, SpriteTextureData spriteData)
		{
			return null;
		}

		public static PhaserSprite circle(this Factory behaviour, Vector2 pos, int radius, uint colour)
		{
			return null;
		}

		[Obsolete("Use \"SpriteTextures.\" instead of strings", false)]
		public static PhaserSprite AddPhaserSprite(this MonoBehaviour behaviour, Vector2 pos, string textureName, string spriteName)
		{
			return null;
		}

		public static PhaserSprite AddPhaserSprite(this MonoBehaviour behaviour, Vector2 pos, SpriteTextureData sprite)
		{
			return null;
		}

		public static PhaserSprite AddPhaserSprite(this GameObject gameObject, Vector2 pos, SpriteTextureData sprite)
		{
			return null;
		}

		[Obsolete("Use \"SpriteTextures.\" instead of strings", false)]
		public static PhaserSprite AddPhaserSprite(this GameObject gameObject, Vector2 pos, string textureName, string spriteName)
		{
			return null;
		}

		public static PhaserSprite AddPhaserSpriteOfType<T>(this MonoBehaviour behaviour, Vector2 pos, string textureName, string spriteName) where T : PhaserSprite
		{
			return null;
		}

		public static T AddPhaserSpriteOfType<T>(this GameObject gameObject, Vector2 pos, string textureName, string spriteName) where T : PhaserSprite
		{
			return null;
		}

		public static SpriteRenderer AddGraphic(this MonoBehaviour behaviour)
		{
			return null;
		}

		public static SpriteRenderer AddGraphic(this MonoBehaviour behaviour, Vector2 pos)
		{
			return null;
		}

		public static SpriteRenderer AddGraphic(this GameObject gameObject, Vector2 pos)
		{
			return null;
		}

		public static TileSprite AddTileSprite(this MonoBehaviour behaviour, float x, float y, float width, float height, string textureName, string spriteName)
		{
			return null;
		}

		public static TileSpriteBuilder AddTileSprite(this MonoBehaviour behaviour, float x, float y, string textureName = null, string spriteName = null)
		{
			return null;
		}

		public static TileSpriteBuilder AddTileSprite(this GameObject go, float x, float y, string textureName, string spriteName)
		{
			return null;
		}

		public static TileSprite SetTexture(this TileSprite tileSprite, string texture)
		{
			return null;
		}

		public static TileSprite SetAlpha(this TileSprite tileSprite, float alpha)
		{
			return null;
		}

		public static TileSprite SetTint(this TileSprite tileSprite, uint tint)
		{
			return null;
		}

		public static TileSprite SetTint(this TileSprite tileSprite, Color32 tint)
		{
			return null;
		}

		public static TileSprite SetBlendMode(this TileSprite tileSprite, BlendMode blendMode)
		{
			return null;
		}

		public static TextMesh SetAlpha(this TextMesh textMesh, float alpha)
		{
			return null;
		}

		public static TextMesh SetTint(this TextMesh textMesh, uint tint)
		{
			return null;
		}

		public static TextMesh SetDepth(this TextMesh textMesh, int depth)
		{
			return null;
		}

		public static void SetDepth(this TrailRenderer trailRenderer, int depth)
		{
		}

		public static void SetVisible(this TrailRenderer trailRenderer, bool visible)
		{
		}

		public static void SetDepthMultiplied(this TrailRenderer trailRenderer, float depth, float mul = 100f)
		{
		}

		public static void SetDepth(this TilemapRenderer tilemapRenderer, int depth)
		{
		}

		public static void SetBlendMode(this ParticleSystem pfx, BlendMode blendMode)
		{
		}

		public static void SetDepth(this ParticleSystem pfx, int depth)
		{
		}

		public static void SetDepthMultiplied(this ParticleSystem pfx, float depth, float multiplier = 100f)
		{
		}

		public static TextMeshPro SetDepth(this TextMeshPro textMeshPro, int depth)
		{
			return null;
		}

		public static TextMeshPro SetDepthMultiplied(this TextMeshPro textMeshPro, float depth, float multiplier = 100f)
		{
			return null;
		}

		public static SpriteRenderer SetDepth(this SpriteRenderer spriteRenderer, int depth)
		{
			return null;
		}

		public static SpriteRenderer SetDepthMultiplied(this SpriteRenderer spriteRenderer, float depth, float multiplier = 100f)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		public static void SetDepthCached(this SpriteRenderer spriteRenderer, int newDepth, ref int currentDepth)
		{
		}

		public static T SetScrollFactor<T>(this T component, float scrollFactor, bool fullscreen = false) where T : Component
		{
			return null;
		}

		public static T setPositionPixelsScrollFactor0<T>(this T component, float x, float y) where T : Component
		{
			return null;
		}

		public static TrailRendererPauseController AddPauseController(this TrailRenderer trailRenderer)
		{
			return null;
		}

		public static void SetMaterialToPackedSprite(this TrailRenderer trailRenderer, Sprite sprite, bool autoSetTrailWidth = true, bool additive = false)
		{
		}

		public static void SetMaterialToPackedSprite(this LineRenderer lineRenderer, Sprite sprite, bool autoSetTrailWidth = true, bool additive = false)
		{
		}

		private static void SetMaterialToPackedSpriteInternal(this Renderer trailRenderer, Sprite sprite, bool additive)
		{
		}

		public static void ClearRenderTexture(this RenderTexture renderTexture)
		{
		}

		public static Image AddImage(this MonoBehaviour behaviour, float x, float y, string textureName = null, string spriteName = null)
		{
			return null;
		}

		public static Image AddImage(this GameObject gameObject, float x, float y, string textureName = null, string spriteName = null)
		{
			return null;
		}

		public static Image AddImage(this GameObject gameObject, Vector2 pos, string textureName, string spriteName)
		{
			return null;
		}

		public static Image SetTint(this Image image, uint tint)
		{
			return null;
		}
	}
}
