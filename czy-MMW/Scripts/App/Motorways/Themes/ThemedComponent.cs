using Client;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.Themes
{
	[DisallowMultipleComponent]
	public class ThemedComponent : MonoBehaviour, IThemeComponent
	{
		public enum ComponentType
		{
			Image = 0,
			Material = 1,
			Text = 2,
			ParticleSystem = 3,
			SpriteRenderer = 4
		}

		private MotorwaysThemeDatabase _database;

		[SerializeField]
		[StringEnumSearch(typeof(ThemedMaterialType))]
		private string type;

		private ThemedMaterialType _typeEnum = ThemedMaterialType.Count;

		public ComponentType componentType;

		private Image _image;

		private TMP_Text _textField;

		private Renderer _particleSystemRenderer;

		private SpriteRenderer _sprite;

		private bool _areComponentsAssigned;

		[ShowIf("IsImage")]
		public bool maintainAlpha;

		public ThemedMaterialType MaterialType
		{
			get
			{
				if (_typeEnum == ThemedMaterialType.Count && !Diagnostics.Verify(type.TryParse(out _typeEnum), "{0} isn't a valid ThemedMaterialType!", type))
				{
					_typeEnum = ThemedMaterialType.Land;
				}
				return _typeEnum;
			}
			set
			{
				_typeEnum = value;
			}
		}

		private void Awake()
		{
			AssignComponents();
		}

		private bool AssignComponents()
		{
			if (componentType == ComponentType.Image)
			{
				if ((object)_image == null)
				{
					_image = GetComponent<Image>();
				}
				_areComponentsAssigned = _image != null;
				if (!_areComponentsAssigned)
				{
					Diagnostics.FailAssert("Image hasn't been set on " + base.name + "!");
					return false;
				}
			}
			else if (componentType == ComponentType.Text)
			{
				if ((object)_textField == null)
				{
					_textField = GetComponent<TMP_Text>();
				}
				_areComponentsAssigned = _textField != null;
				if (!_areComponentsAssigned)
				{
					Diagnostics.FailAssert("Text field hasn't been set on " + base.name + "!");
					return false;
				}
			}
			else if (componentType == ComponentType.ParticleSystem)
			{
				ParticleSystem component = GetComponent<ParticleSystem>();
				if (component != null && (object)_particleSystemRenderer == null)
				{
					_particleSystemRenderer = component.GetComponent<Renderer>();
				}
				_areComponentsAssigned = _particleSystemRenderer != null;
				if (!_areComponentsAssigned)
				{
					Diagnostics.FailAssert("Particle system hasn't been set on " + base.name + "!");
					return false;
				}
			}
			else if (componentType == ComponentType.SpriteRenderer)
			{
				if ((object)_sprite == null)
				{
					_sprite = GetComponent<SpriteRenderer>();
				}
				_areComponentsAssigned = _sprite != null;
				if (!_areComponentsAssigned)
				{
					Diagnostics.FailAssert("SpriteRenderer hasn't been set on " + base.name + "!");
					return false;
				}
			}
			else
			{
				_areComponentsAssigned = true;
			}
			return true;
		}

		public void InitializeTheme(IThemeDatabase themeDatabase)
		{
			_database = (MotorwaysThemeDatabase)themeDatabase;
			if (componentType == ComponentType.Material)
			{
				Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>();
				foreach (Renderer renderer in componentsInChildren)
				{
					_database.materialCollection.BindRendererToThemeTarget(renderer, MaterialType);
				}
			}
		}

		public void ApplyTheme(ITheme theme)
		{
			if (componentType != ComponentType.Material)
			{
				Color color = ((_database != null && _database.ApplyThemeOverrides) ? (theme as Theme).GetDeleteModeColor(MaterialType) : (theme as Theme).GetColor(MaterialType));
				SetColor(color);
			}
		}

		public ThemeBlendingResult ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
		{
			if (componentType == ComponentType.Material)
			{
				return ThemeBlendingResult.StopBlending;
			}
			Color obj = ((_database != null && _database.IsBlendingOverrides && !_database.ApplyThemeOverrides) ? (oldTheme as Theme).GetDeleteModeColor(MaterialType) : (oldTheme as Theme).GetColor(MaterialType));
			Color color = ((_database != null && _database.ApplyThemeOverrides) ? (newTheme as Theme).GetDeleteModeColor(MaterialType) : (newTheme as Theme).GetColor(MaterialType));
			Color color2 = Color.Lerp(obj, color, progress);
			SetColor(color2);
			if (!(obj == color))
			{
				return ThemeBlendingResult.ContinueBlending;
			}
			return ThemeBlendingResult.StopBlending;
		}

		public void SetColor(Color color)
		{
			if (!_areComponentsAssigned && !AssignComponents())
			{
				return;
			}
			if (componentType == ComponentType.Image)
			{
				if (maintainAlpha)
				{
					color.a = _image.color.a;
				}
				_image.color = color;
			}
			else if (componentType == ComponentType.Text)
			{
				_textField.color = color;
			}
			else if (componentType == ComponentType.ParticleSystem)
			{
				_particleSystemRenderer.sharedMaterial.color = color;
			}
			else if (componentType == ComponentType.SpriteRenderer)
			{
				_sprite.color = color;
			}
		}

		public void ReleaseTheme(IThemeDatabase themeDatabase)
		{
			MotorwaysThemeDatabase motorwaysThemeDatabase = (MotorwaysThemeDatabase)themeDatabase;
			if (componentType == ComponentType.Material)
			{
				Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>();
				foreach (Renderer renderer in componentsInChildren)
				{
					motorwaysThemeDatabase.materialCollection.UnbindRendererFromThemeTarget(renderer, MaterialType);
				}
			}
		}

		public bool IsImage()
		{
			return componentType == ComponentType.Image;
		}

		public void SetMaterialType(ThemedMaterialType materialType)
		{
			type = materialType.ToString();
		}
	}
}
