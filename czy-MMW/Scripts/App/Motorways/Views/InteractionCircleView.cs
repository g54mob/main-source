using Client;
using Motorways.Themes;
using UnityEngine;

namespace Motorways.Views
{
	public class InteractionCircleView : MonoBehaviour, IThemeComponent
	{
		[SerializeField]
		private SpriteRenderer _sprite;

		[SerializeField]
		private Animator _animator;

		private static readonly int InteractionCircleProgressPropertyId = Shader.PropertyToID("_Progress");

		private static readonly int MainTexturePropertyId = Shader.PropertyToID("_MainTex");

		private static readonly int InteractionCircleProgressCompleteAnimatorTrigger = Animator.StringToHash("Bounce");

		private float _previousProgress;

		private MotorwaysThemeDatabase _database;

		private MaterialPropertyBlock _spritePropertyBlock;

		[SerializeField]
		[StringEnumSearch(typeof(ThemedMaterialType))]
		private string type;

		private ThemedMaterialType _typeEnum = ThemedMaterialType.Count;

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
		}

		private void Awake()
		{
			_spritePropertyBlock = new MaterialPropertyBlock();
		}

		public void SetPermanenceProgress(float modelProgress)
		{
			float value = modelProgress;
			if (modelProgress >= 1f)
			{
				value = 1.1f;
			}
			_sprite.GetPropertyBlock(_spritePropertyBlock);
			_spritePropertyBlock.SetFloat(InteractionCircleProgressPropertyId, value);
			_sprite.SetPropertyBlock(_spritePropertyBlock);
			if (_previousProgress < 1f && modelProgress >= 1f && _previousProgress != 0f)
			{
				PlayPermanenceCompleteAnimation();
			}
			_previousProgress = modelProgress;
		}

		private void PlayPermanenceCompleteAnimation()
		{
			_animator.SetTrigger(InteractionCircleProgressCompleteAnimatorTrigger);
		}

		public void InitializeTheme(IThemeDatabase themeDatabase)
		{
			_database = (MotorwaysThemeDatabase)themeDatabase;
			_database.materialCollection.BindRendererToThemeTarget(_sprite, MaterialType);
			_sprite.GetPropertyBlock(_spritePropertyBlock);
			_spritePropertyBlock.SetTexture(MainTexturePropertyId, _sprite.sprite.texture);
			_sprite.SetPropertyBlock(_spritePropertyBlock);
		}

		public void ApplyTheme(ITheme theme)
		{
			SetPermanenceProgress(_previousProgress);
		}

		public ThemeBlendingResult ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
		{
			SetPermanenceProgress(_previousProgress);
			return ThemeBlendingResult.ContinueBlending;
		}

		public void ReleaseTheme(IThemeDatabase themeDatabase)
		{
			((MotorwaysThemeDatabase)themeDatabase).materialCollection.UnbindRendererFromThemeTarget(_sprite, MaterialType);
		}
	}
}
