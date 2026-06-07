using System;
using System.Collections.Generic;
using System.Reflection;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Framework.PhaserTweens
{
	public class Tweens
	{
		private static Dictionary<Type, Action<int, TweenConfig, Sequence>> targetTypeSwitch;

		private static Dictionary<Type, Func<Action<object, object>, Func<object, object>, object, object, TweenConfig, int, Tween>> fieldTypeSwitch;

		private static Dictionary<(Type, string), CachedCustomField> customFieldCache;

		public static Func<int, float> Stagger(float value, StaggerConfig config = null)
		{
			return null;
		}

		public static MultiTargetTween Add(TweenConfig config)
		{
			return null;
		}

		private static Action<object, object> CompileFieldSetter(Type type, FieldInfo fieldInfo)
		{
			return null;
		}

		private static Func<object, object> CompileFieldGetter(Type type, FieldInfo fieldInfo)
		{
			return null;
		}

		private static Action<object, object> CompilePropertySetter(Type type, PropertyInfo fieldInfo)
		{
			return null;
		}

		private static Func<object, object> CompilePropertyGetter(Type type, PropertyInfo fieldInfo)
		{
			return null;
		}

		private static void HandleYoyo(TweenConfig config)
		{
		}

		private static void AddOnComplete(TweenConfig config, Sequence sequence)
		{
		}

		private static void AddOnStart(TweenConfig config, Sequence sequence)
		{
		}

		private static void AddOnStop(TweenConfig config, Sequence sequence)
		{
		}

		private static void AddOnYoyo(TweenConfig config, Sequence sequence)
		{
		}

		private static void AddOnRepeat(TweenConfig config, Sequence sequence)
		{
		}

		private static void AddOnUpdate(TweenConfig config, Sequence sequence, MultiTargetTween multiTargetTween)
		{
		}

		private static void AddDelay(int targetIndex, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddRepeatDelay(TweenConfig config, Sequence sequence)
		{
		}

		private static void AddRepeat(TweenConfig config, Sequence sequence)
		{
		}

		private static void AddDelaysAndRepeats(int targetIndex, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddTransformTweens(int targetIndex, Transform target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddMoveX(int targetIndex, Transform target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddMoveY(int targetIndex, Transform target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddLocalMoveX(int targetIndex, Transform target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddLocalMoveY(int targetIndex, Transform target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddScale(int targetIndex, Transform target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddScaleX(int targetIndex, Transform target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddScaleY(int targetIndex, Transform target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddAngle(int targetIndex, Transform target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddLocalAngle(int targetIndex, Transform target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddSpriteTweens(int targetIndex, SpriteRenderer target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddAlphaAndTint(int targetIndex, SpriteRenderer target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddTileSpriteTweens(int targetIndex, TileSprite target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddAlpha(int targetIndex, TileSprite target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddTileScaleTweens(int targetIndex, TileSprite target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddTilemapTweens(int targetIndex, Tilemap target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddAlpha(int targetIndex, Tilemap target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddTextMeshProTweens(int targetIndex, TextMeshPro target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddTextMeshProUGUITweens(int targetIndex, TextMeshProUGUI target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddAlpha(int targetIndex, TextMeshPro target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddAlphaUGUI(int targetIndex, TextMeshProUGUI target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddTextMeshTweens(int targetIndex, TextMesh target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddAlpha(int targetIndex, TextMesh target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddMaterialTweens(int targetIndex, Material target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddAlpha(int targetIndex, Material target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddArcadeSpriteTweens(int targetIndex, ArcadeSprite target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddPhaserSpriteTweens(int targetIndex, PhaserSprite target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddPhaserTextTweens(int targetIndex, PhaserText target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddBitmapTextTweens(int targetIndex, BitmapText target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddCustomTweens(int targetIndex, object target, TweenConfig config, Sequence sequence)
		{
		}

		private static Tween CustomTweenInt(int targetIndex, Action<object, object> setter, Func<object, object> getter, object target, object value, TweenConfig config)
		{
			return null;
		}

		private static Tween CustomTweenFloat(int targetIndex, Action<object, object> setter, Func<object, object> getter, object target, object value, TweenConfig config)
		{
			return null;
		}

		private static Tween CustomTweenDouble(int targetIndex, Action<object, object> setter, Func<object, object> getter, object target, object value, TweenConfig config)
		{
			return null;
		}

		private static void CustomTweenEggFloat(int targetIndex, object target, FieldInfo field, TweenConfig config, EggFloat value, Sequence sequence)
		{
		}

		private static void CustomTweenEggDouble(int targetIndex, object target, FieldInfo field, TweenConfig config, EggDouble value, Sequence sequence)
		{
		}

		private static void CustomTweenEggFloat(int targetIndex, object target, PropertyInfo field, TweenConfig config, EggFloat value, Sequence sequence)
		{
		}

		private static void CustomTweenEggDouble(int targetIndex, object target, PropertyInfo field, TweenConfig config, EggDouble value, Sequence sequence)
		{
		}

		private static void AddBoxedVector2Tweens(int targetIndex, PhaserScene.BoxedVector2 target, TweenConfig config, Sequence sequence)
		{
		}

		private static void AddUiImageTweens(int targetIndex, Image target, TweenConfig config, Sequence sequence)
		{
		}
	}
}
