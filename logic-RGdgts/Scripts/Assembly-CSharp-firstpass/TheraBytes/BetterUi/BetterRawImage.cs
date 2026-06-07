using System;
using UnityEngine;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	public class BetterRawImage : RawImage, IImageAppearanceProvider, IResolutionDependency
	{
		[Serializable]
		public class TextureSettings : IScreenConfigConnection
		{
			public Texture Texture;

			public ColorMode ColorMode;

			public Color PrimaryColor;

			public Color SecondaryColor;

			public Rect UvRect;

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

			public TextureSettings(Texture texture, ColorMode colorMode, Color primary, Color secondary, Rect uvRect)
			{
			}
		}

		[Serializable]
		public class TextureSettingsConfigCollection : SizeConfigCollection<TextureSettings>
		{
		}

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
		private TextureSettings fallbackTextureSettings;

		[SerializeField]
		private TextureSettingsConfigCollection customTextureSettings;

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

		public TextureSettings CurrentTextureSettings => null;

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

		protected override void OnPopulateMesh(VertexHelper vh)
		{
		}

		public void OnResolutionChanged()
		{
		}

		private void AssignTextureSettings()
		{
		}

		private void DoValidation()
		{
		}
	}
}
