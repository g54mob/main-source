using System;
using UnityEngine;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	[ExecuteAlways]
	public class BetterImage : Image, IResolutionDependency, IImageAppearanceProvider
	{
		[Serializable]
		public class SpriteSettings : IScreenConfigConnection
		{
			public Sprite Sprite;

			public ColorMode ColorMode;

			public Color PrimaryColor;

			public Color SecondaryColor;

			[SerializeField]
			private string screenConfigName;

			public string ScreenConfigName
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public SpriteSettings(Sprite sprite, ColorMode colorMode, Color primary, Color secondary)
			{
			}
		}

		[Serializable]
		public class SpriteSettingsConfigCollection : SizeConfigCollection<SpriteSettings>
		{
		}

		private static readonly Vector2[] vertScratch;

		private static readonly Vector2[] uvScratch;

		[SerializeField]
		private ColorMode colorMode;

		[SerializeField]
		private Color secondColor;

		[SerializeField]
		private VertexMaterialData materialProperties;

		[SerializeField]
		private string materialType;

		[SerializeField]
		private MaterialEffect materialEffect;

		[SerializeField]
		private float materialProperty1;

		[SerializeField]
		private float materialProperty2;

		[SerializeField]
		private float materialProperty3;

		[SerializeField]
		private bool keepBorderAspectRatio;

		[SerializeField]
		private Vector2SizeModifier spriteBorderScaleFallback;

		[SerializeField]
		private Vector2SizeConfigCollection customBorderScales;

		[SerializeField]
		private SpriteSettings fallbackSpriteSettings;

		[SerializeField]
		private SpriteSettingsConfigCollection customSpriteSettings;

		private Animator animator;

		public bool KeepBorderAspectRatio
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Vector2SizeModifier SpriteBorderScale => null;

		public string MaterialType
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public MaterialEffect MaterialEffect
		{
			get
			{
				return default(MaterialEffect);
			}
			set
			{
			}
		}

		public VertexMaterialData MaterialProperties => null;

		public ColorMode ColoringMode
		{
			get
			{
				return default(ColorMode);
			}
			set
			{
			}
		}

		public Color SecondColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public SpriteSettings CurrentSpriteSettings => null;

		protected override void OnEnable()
		{
		}

		public float GetMaterialPropertyValue(int propertyIndex)
		{
			return 0f;
		}

		public void SetMaterialProperty(int propertyIndex, float value)
		{
		}

		protected override void OnPopulateMesh(VertexHelper toFill)
		{
		}

		private void GenerateSimpleSprite(VertexHelper vh, bool preserveAspect)
		{
		}

		private Rect GetDrawingRect(bool shouldPreserveAspect)
		{
			return default(Rect);
		}

		private void GenerateSlicedSprite(VertexHelper toFill)
		{
		}

		private void GenerateTiledSprite(VertexHelper toFill)
		{
		}

		private void AddQuad(VertexHelper vertexHelper, Rect bounds, Vector2 posMin, Vector2 posMax, ColorMode mode, Color colorA, Color colorB, Vector2 uvMin, Vector2 uvMax)
		{
		}

		private Vector4 GetAdjustedBorders(Vector4 border, Rect rect, bool keepAspect, Vector2 texSize)
		{
			return default(Vector4);
		}

		public void OnResolutionChanged()
		{
		}

		private void AssignSpriteSettings()
		{
		}

		private void DoValidation()
		{
		}
	}
}
