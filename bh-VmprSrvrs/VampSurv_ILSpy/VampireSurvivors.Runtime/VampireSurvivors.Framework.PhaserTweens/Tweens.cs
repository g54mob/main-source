using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using ModestTree;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Framework.PhaserTweens;

public class Tweens
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003C_002Ecctor_003Eb__60_0(int i, TweenConfig conf, Sequence sequence)
		{
			//IL_003b: Expected I, but got O
			//IL_0069: Expected I, but got O
			//IL_0079: Expected O, but got I
			//IL_00b5: Expected O, but got I
			object[] targets = conf.targets;
			Transform transform = (Transform)targets[i];
			nint num = (nint)typeof(Transform);
			if (targets[i] != null)
			{
				nint num2 = (nint)transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rdx_v2 (Il2CppClass<UnityEngine.Transform>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r8_v4 (Il2CppClass<UnityEngine.Transform>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rdx_v2 (Il2CppClass<UnityEngine.Transform>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r8_v4 (Il2CppClass<UnityEngine.Transform>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v11+FFFFFFF8+v126 @ rax_v10*8]");
					if (0 == (nint)typeof(Transform))
					{
						goto IL_00e2;
					}
				}
				throw new InvalidCastException();
			}
			goto IL_00e2;
			IL_00e2:
			AddTransformTweens(i, (Transform)targets[i], conf, sequence);
		}

		internal void _003C_002Ecctor_003Eb__60_1(int i, TweenConfig conf, Sequence sequence)
		{
			object[] targets = conf.targets;
			object obj = targets[i];
			bool flag = targets[i] == null;
			SpriteRenderer spriteRenderer = null;
			if (!flag)
			{
				bool flag2 = (object)obj.GetType() != typeof(SpriteRenderer);
				spriteRenderer = null;
				if (!flag2)
				{
					spriteRenderer = (SpriteRenderer)targets[i];
				}
				if ((object)spriteRenderer == null)
				{
					throw new InvalidCastException();
				}
			}
			AddAlphaAndTint(i, spriteRenderer, conf, sequence);
		}

		internal void _003C_002Ecctor_003Eb__60_2(int i, TweenConfig conf, Sequence sequence)
		{
			//IL_003b: Expected I, but got O
			//IL_0069: Expected I, but got O
			//IL_0079: Expected O, but got I
			//IL_00b5: Expected O, but got I
			object[] targets = conf.targets;
			Material material = (Material)targets[i];
			nint num = (nint)typeof(Material);
			if (targets[i] != null)
			{
				nint num2 = (nint)material;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v5 (Il2CppClass<UnityEngine.Material>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r8_v4 (Il2CppClass<UnityEngine.Material>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v5 (Il2CppClass<UnityEngine.Material>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r8_v4 (Il2CppClass<UnityEngine.Material>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v15+FFFFFFF8+v126 @ rax_v14*8]");
					if (0 == (nint)typeof(Material))
					{
						goto IL_00e7;
					}
				}
				throw new InvalidCastException();
			}
			goto IL_00e7;
			IL_00e7:
			AddAlpha(i, (Material)targets[i], conf, sequence);
		}

		internal void _003C_002Ecctor_003Eb__60_3(int i, TweenConfig conf, Sequence sequence)
		{
			//IL_003b: Expected I, but got O
			//IL_0069: Expected I, but got O
			//IL_0079: Expected O, but got I
			//IL_014b: Expected O, but got I
			//IL_00b5: Expected O, but got I
			object[] targets = conf.targets;
			Component component = (Component)targets[i];
			nint num = (nint)typeof(ArcadeSprite);
			if (targets[i] != null)
			{
				nint num2 = (nint)component;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rcx_v7 (Il2CppClass<ArcadeSprite>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ r8_v7 (Il2CppClass<UnityEngine.Component>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rcx_v7 (Il2CppClass<ArcadeSprite>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ r8_v7 (Il2CppClass<UnityEngine.Component>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v19+FFFFFFF8+v152 @ rax_v18*8]");
					if (0 == (nint)typeof(ArcadeSprite))
					{
						goto IL_00e7;
					}
				}
				throw new InvalidCastException();
			}
			goto IL_00e7;
			IL_00e7:
			Transform transform = ((Component)targets[i]).transform;
			AddTransformTweens(i, transform, conf, sequence);
			((ArcadeSprite)targets[i]).CheckRenderer();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rbx_v5 (UnityEngine.Component)+48]");
			AddAlphaAndTint(i, (SpriteRenderer)0, conf, sequence);
		}

		internal void _003C_002Ecctor_003Eb__60_4(int i, TweenConfig conf, Sequence sequence)
		{
			//IL_003b: Expected I, but got O
			//IL_0069: Expected I, but got O
			//IL_0079: Expected O, but got I
			//IL_0134: Expected O, but got I
			//IL_00b5: Expected O, but got I
			object[] targets = conf.targets;
			Component component = (Component)targets[i];
			nint num = (nint)typeof(PhaserSprite);
			if (targets[i] != null)
			{
				nint num2 = (nint)component;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rcx_v7 (Il2CppClass<VampireSurvivors.Framework.Phaser.PhaserSprite>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ r8_v7 (Il2CppClass<UnityEngine.Component>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rcx_v7 (Il2CppClass<VampireSurvivors.Framework.Phaser.PhaserSprite>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ r8_v7 (Il2CppClass<UnityEngine.Component>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v18+FFFFFFF8+v152 @ rax_v17*8]");
					if (0 == (nint)typeof(PhaserSprite))
					{
						goto IL_00e7;
					}
				}
				throw new InvalidCastException();
			}
			goto IL_00e7;
			IL_00e7:
			Transform transform = ((Component)targets[i]).transform;
			AddTransformTweens(i, transform, conf, sequence);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rbx_v5 (UnityEngine.Component)+28]");
			AddAlphaAndTint(i, (SpriteRenderer)0, conf, sequence);
		}

		internal void _003C_002Ecctor_003Eb__60_5(int i, TweenConfig conf, Sequence sequence)
		{
			//IL_003b: Expected I, but got O
			//IL_0069: Expected I, but got O
			//IL_0079: Expected O, but got I
			//IL_0134: Expected O, but got I
			//IL_00b5: Expected O, but got I
			object[] targets = conf.targets;
			Component component = (Component)targets[i];
			nint num = (nint)typeof(PhaserText);
			if (targets[i] != null)
			{
				nint num2 = (nint)component;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rcx_v7 (Il2CppClass<VampireSurvivors.Framework.Phaser.PhaserText>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ r8_v7 (Il2CppClass<UnityEngine.Component>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rcx_v7 (Il2CppClass<VampireSurvivors.Framework.Phaser.PhaserText>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ r8_v7 (Il2CppClass<UnityEngine.Component>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v18+FFFFFFF8+v152 @ rax_v17*8]");
					if (0 == (nint)typeof(PhaserText))
					{
						goto IL_00e7;
					}
				}
				throw new InvalidCastException();
			}
			goto IL_00e7;
			IL_00e7:
			Transform transform = ((Component)targets[i]).transform;
			AddTransformTweens(i, transform, conf, sequence);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rbx_v5 (UnityEngine.Component)+28]");
			AddAlpha(i, (TextMeshPro)0, conf, sequence);
		}

		internal void _003C_002Ecctor_003Eb__60_6(int i, TweenConfig conf, Sequence sequence)
		{
			//IL_003b: Expected I, but got O
			//IL_0069: Expected I, but got O
			//IL_0079: Expected O, but got I
			//IL_0134: Expected O, but got I
			//IL_00b5: Expected O, but got I
			object[] targets = conf.targets;
			Component component = (Component)targets[i];
			nint num = (nint)typeof(BitmapText);
			if (targets[i] != null)
			{
				nint num2 = (nint)component;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rcx_v7 (Il2CppClass<VampireSurvivors.Framework.Phaser.BitmapText>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ r8_v7 (Il2CppClass<UnityEngine.Component>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rcx_v7 (Il2CppClass<VampireSurvivors.Framework.Phaser.BitmapText>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ r8_v7 (Il2CppClass<UnityEngine.Component>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v18+FFFFFFF8+v152 @ rax_v17*8]");
					if (0 == (nint)typeof(BitmapText))
					{
						goto IL_00e7;
					}
				}
				throw new InvalidCastException();
			}
			goto IL_00e7;
			IL_00e7:
			Transform transform = ((Component)targets[i]).transform;
			AddTransformTweens(i, transform, conf, sequence);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rbx_v5 (UnityEngine.Component)+28]");
			AddAlpha(i, (TextMesh)0, conf, sequence);
		}

		internal void _003C_002Ecctor_003Eb__60_7(int i, TweenConfig conf, Sequence sequence)
		{
			//IL_003b: Expected I, but got O
			//IL_0069: Expected I, but got O
			//IL_0079: Expected O, but got I
			//IL_00b5: Expected O, but got I
			object[] targets = conf.targets;
			TextMeshPro textMeshPro = (TextMeshPro)targets[i];
			nint num = (nint)typeof(TextMeshPro);
			if (targets[i] != null)
			{
				nint num2 = (nint)textMeshPro;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v5 (Il2CppClass<TMPro.TextMeshPro>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r8_v4 (Il2CppClass<TMPro.TextMeshPro>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v5 (Il2CppClass<TMPro.TextMeshPro>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r8_v4 (Il2CppClass<TMPro.TextMeshPro>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v15+FFFFFFF8+v126 @ rax_v14*8]");
					if (0 == (nint)typeof(TextMeshPro))
					{
						goto IL_00e7;
					}
				}
				throw new InvalidCastException();
			}
			goto IL_00e7;
			IL_00e7:
			AddAlpha(i, (TextMeshPro)targets[i], conf, sequence);
		}

		internal void _003C_002Ecctor_003Eb__60_8(int i, TweenConfig conf, Sequence sequence)
		{
			//IL_003b: Expected I, but got O
			//IL_0069: Expected I, but got O
			//IL_0079: Expected O, but got I
			//IL_00b5: Expected O, but got I
			object[] targets = conf.targets;
			TextMeshProUGUI textMeshProUGUI = (TextMeshProUGUI)targets[i];
			nint num = (nint)typeof(TextMeshProUGUI);
			if (targets[i] != null)
			{
				nint num2 = (nint)textMeshProUGUI;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v5 (Il2CppClass<TMPro.TextMeshProUGUI>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r8_v4 (Il2CppClass<TMPro.TextMeshProUGUI>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v5 (Il2CppClass<TMPro.TextMeshProUGUI>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r8_v4 (Il2CppClass<TMPro.TextMeshProUGUI>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v15+FFFFFFF8+v126 @ rax_v14*8]");
					if (0 == (nint)typeof(TextMeshProUGUI))
					{
						goto IL_00e7;
					}
				}
				throw new InvalidCastException();
			}
			goto IL_00e7;
			IL_00e7:
			AddAlphaUGUI(i, (TextMeshProUGUI)targets[i], conf, sequence);
		}

		internal void _003C_002Ecctor_003Eb__60_9(int i, TweenConfig conf, Sequence sequence)
		{
			object[] targets = conf.targets;
			object obj = targets[i];
			bool flag = targets[i] == null;
			TextMesh textMesh = null;
			if (!flag)
			{
				bool flag2 = (object)obj.GetType() != typeof(TextMesh);
				textMesh = null;
				if (!flag2)
				{
					textMesh = (TextMesh)targets[i];
				}
				if ((object)textMesh == null)
				{
					throw new InvalidCastException();
				}
			}
			AddAlpha(i, textMesh, conf, sequence);
		}

		internal void _003C_002Ecctor_003Eb__60_10(int i, TweenConfig conf, Sequence sequence)
		{
			object[] targets = conf.targets;
			object obj = targets[i];
			bool flag = targets[i] == null;
			Tilemap tilemap = null;
			if (!flag)
			{
				bool flag2 = (object)obj.GetType() != typeof(Tilemap);
				tilemap = null;
				if (!flag2)
				{
					tilemap = (Tilemap)targets[i];
				}
				if ((object)tilemap == null)
				{
					throw new InvalidCastException();
				}
			}
			AddAlpha(i, tilemap, conf, sequence);
		}

		internal void _003C_002Ecctor_003Eb__60_11(int i, TweenConfig conf, Sequence sequence)
		{
			//IL_003b: Expected I, but got O
			//IL_0069: Expected I, but got O
			//IL_0079: Expected O, but got I
			//IL_00b5: Expected O, but got I
			object[] targets = conf.targets;
			TileSprite tileSprite = (TileSprite)targets[i];
			nint num = (nint)typeof(TileSprite);
			if (targets[i] != null)
			{
				nint num2 = (nint)tileSprite;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v5 (Il2CppClass<VampireSurvivors.Graphics.TileSprite>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r8_v5 (Il2CppClass<VampireSurvivors.Graphics.TileSprite>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v5 (Il2CppClass<VampireSurvivors.Graphics.TileSprite>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r8_v5 (Il2CppClass<VampireSurvivors.Graphics.TileSprite>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v16+FFFFFFF8+v126 @ rax_v15*8]");
					if (0 == (nint)typeof(TileSprite))
					{
						goto IL_00e7;
					}
				}
				throw new InvalidCastException();
			}
			goto IL_00e7;
			IL_00e7:
			AddAlpha(i, (TileSprite)targets[i], conf, sequence);
			AddTileScaleTweens(i, (TileSprite)targets[i], conf, sequence);
		}

		internal void _003C_002Ecctor_003Eb__60_12(int i, TweenConfig conf, Sequence sequence)
		{
			//IL_003b: Expected I, but got O
			//IL_0069: Expected I, but got O
			//IL_0079: Expected O, but got I
			//IL_00b5: Expected O, but got I
			object[] targets = conf.targets;
			PhaserScene.BoxedVector2 boxedVector = (PhaserScene.BoxedVector2)targets[i];
			nint num = (nint)typeof(PhaserScene.BoxedVector2);
			if (targets[i] != null)
			{
				nint num2 = (nint)boxedVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rdx_v2 (Il2CppClass<PhaserScene+BoxedVector2>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r8_v4 (Il2CppClass<PhaserScene+BoxedVector2>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rdx_v2 (Il2CppClass<PhaserScene+BoxedVector2>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r8_v4 (Il2CppClass<PhaserScene+BoxedVector2>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v11+FFFFFFF8+v126 @ rax_v10*8]");
					if (0 == (nint)typeof(PhaserScene.BoxedVector2))
					{
						goto IL_00e2;
					}
				}
				throw new InvalidCastException();
			}
			goto IL_00e2;
			IL_00e2:
			AddBoxedVector2Tweens(i, (PhaserScene.BoxedVector2)targets[i], conf, sequence);
		}

		internal void _003C_002Ecctor_003Eb__60_13(int i, TweenConfig conf, Sequence sequence)
		{
			//IL_003b: Expected I, but got O
			//IL_0069: Expected I, but got O
			//IL_0079: Expected O, but got I
			//IL_00b5: Expected O, but got I
			object[] targets = conf.targets;
			Image image = (Image)targets[i];
			nint num = (nint)typeof(Image);
			if (targets[i] != null)
			{
				nint num2 = (nint)image;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rdx_v2 (Il2CppClass<UnityEngine.UI.Image>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r8_v4 (Il2CppClass<UnityEngine.UI.Image>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rdx_v2 (Il2CppClass<UnityEngine.UI.Image>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r8_v4 (Il2CppClass<UnityEngine.UI.Image>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v11+FFFFFFF8+v126 @ rax_v10*8]");
					if (0 == (nint)typeof(Image))
					{
						goto IL_00e2;
					}
				}
				throw new InvalidCastException();
			}
			goto IL_00e2;
			IL_00e2:
			AddUiImageTweens(i, (Image)targets[i], conf, sequence);
		}

		internal Tween _003C_002Ecctor_003Eb__60_14(Action<object, object> setter, Func<object, object> getter, object target, object value, TweenConfig config, int i)
		{
			int targetIndex = default(int);
			TweenConfig config2 = default(TweenConfig);
			return CustomTweenInt(targetIndex, setter, getter, target, value, config2);
		}

		internal Tween _003C_002Ecctor_003Eb__60_15(Action<object, object> setter, Func<object, object> getter, object target, object value, TweenConfig config, int i)
		{
			int targetIndex = default(int);
			TweenConfig config2 = default(TweenConfig);
			return CustomTweenFloat(targetIndex, setter, getter, target, value, config2);
		}

		internal Tween _003C_002Ecctor_003Eb__60_16(Action<object, object> setter, Func<object, object> getter, object target, object value, TweenConfig config, int i)
		{
			int targetIndex = default(int);
			TweenConfig config2 = default(TweenConfig);
			return CustomTweenDouble(targetIndex, setter, getter, target, value, config2);
		}
	}

	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public TweenConfig config;

		internal void _003CAddOnYoyo_003Eb__0()
		{
			TweenConfig tweenConfig = config;
			if (tweenConfig.yoyo)
			{
				TweenCallback onYoyo = tweenConfig.onYoyo;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v24.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public TweenConfig config;

		public Sequence sequence;

		internal void _003CAddOnRepeat_003Eb__0()
		{
			//IL_00b0: Expected O, but got I4
			TweenConfig tweenConfig = config;
			if (!tweenConfig.yoyo)
			{
				TweenCallback onRepeat = tweenConfig.onRepeat;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v36.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				return;
			}
			Sequence sequence = this.sequence;
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				int num = ((Tween)sequence).completedLoops & 1;
				bool flag = num == 0;
				object obj = !flag;
				if (obj != null)
				{
					return;
				}
			}
			else if (Debugger._logPriority > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DAF]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				Debugger.LogWarning("This Tween has been killed and is now invalid");
			}
			TweenConfig tweenConfig2 = config;
			TweenCallback onRepeat2 = tweenConfig2.onRepeat;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v94.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public Sequence sequence;

		internal void _003CAddDelay_003Eb__0()
		{
			Sequence sequence = this.sequence;
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				Sequence sequence2 = TweenExtensions.Play(sequence);
				Sequence sequence3 = this.sequence;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				sequence3.stringId = "DefaultGameTweenId";
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass16_1
	{
		public Tween delayTween;

		internal void _003CAddDelay_003Eb__1()
		{
			Tween tween = delayTween;
			if (delayTween != null && tween._003Cactive_003Ek__BackingField)
			{
				TweenExtensions.Kill(delayTween);
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass34_0
	{
		public TileSprite target;

		internal float _003CAddTileScaleTweens_003Eb__0()
		{
			TileSprite tileSprite = target;
			return tileSprite._tileScaleX;
		}

		internal void _003CAddTileScaleTweens_003Eb__1(float value)
		{
			target.TileScaleX = value;
		}

		internal float _003CAddTileScaleTweens_003Eb__2()
		{
			TileSprite tileSprite = target;
			return tileSprite._tileScaleY;
		}

		internal void _003CAddTileScaleTweens_003Eb__3(float value)
		{
			target.TileScaleY = value;
		}
	}

	private sealed class _003C_003Ec__DisplayClass36_0
	{
		public Tilemap target;

		internal unsafe Color _003CAddAlpha_003Eb__0()
		{
			//IL_0051: Expected native int or pointer, but got O
			Tilemap tilemap = target;
			bool flag = ((UnityEngine.Object)tilemap).m_CachedPtr == (IntPtr)0;
			float ret;
			Tilemap.get_color_Injected(((UnityEngine.Object)tilemap).m_CachedPtr, out *(Color*)(&ret));
			Color color = default(Color);
			((Color*)(nint)color)->r = ret;
			return color;
		}

		internal unsafe void _003CAddAlpha_003Eb__1(Color x)
		{
			Tilemap tilemap = target;
			bool flag = ((UnityEngine.Object)tilemap).m_CachedPtr == (IntPtr)0;
			float value = default(float);
			Tilemap.set_color_Injected(((UnityEngine.Object)tilemap).m_CachedPtr, ref *(Color*)(&value));
		}
	}

	private sealed class _003C_003Ec__DisplayClass42_0
	{
		public TextMesh target;

		public Color col;

		internal float _003CAddAlpha_003Eb__0()
		{
			//IL_000d: Expected F4, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.PhaserTweens.Tweens+<>c__DisplayClass42_0)+24]");
			return 0f;
		}

		internal void _003CAddAlpha_003Eb__1(float x)
		{
		}

		internal void _003CAddAlpha_003Eb__2()
		{
			TextMesh textMesh = target;
			bool flag = ((UnityEngine.Object)textMesh).m_CachedPtr == (IntPtr)0;
			Color value = default(Color);
			TextMesh.set_color_Injected(((UnityEngine.Object)textMesh).m_CachedPtr, ref value);
		}
	}

	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public GameObject go;

		internal bool _003CAdd_003Eb__0(object c)
		{
			//IL_0013: Expected I, but got O
			//IL_001b: Expected I, but got O
			//IL_002b: Expected O, but got I
			//IL_00ab: Expected O, but got I4
			//IL_0067: Expected O, but got I
			//IL_0232: Expected O, but got I4
			//IL_024c: Expected O, but got I4
			//IL_009d: Expected O, but got I4
			//IL_01ad: Expected I4, but got O
			bool flag = c == null;
			GameObject gameObject = null;
			object obj3;
			if (!flag)
			{
				nint num = (nint)typeof(Component);
				nint num2 = (nint)c;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v2 (Il2CppClass<UnityEngine.Component>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ r8_v2 (Il2CppClass<System.Object>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v2 (Il2CppClass<UnityEngine.Component>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ r8_v2 (Il2CppClass<System.Object>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v27+FFFFFFF8+v51 @ rax_v22*8]");
					if (0 == (nint)typeof(Component))
					{
						obj3 = 1;
						goto IL_01cf;
					}
				}
				obj3 = 0;
				goto IL_01cf;
			}
			goto IL_01f1;
			IL_01f1:
			GameObject gameObject2 = go;
			bool flag2 = (object)go == null;
			bool flag3 = (object)gameObject == null;
			object obj4 = flag3 & flag2;
			bool flag4 = obj4 == null;
			object obj5 = !flag4;
			if (obj5 == null)
			{
				if ((object)go != null)
				{
					if ((object)gameObject != null)
					{
						object obj6 = (object)gameObject - (object)go;
						return obj6 == null;
					}
					return ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
				}
				if ((object)gameObject != null)
				{
					return ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return true;
			IL_01cf:
			bool flag5 = obj3 == null;
			Component component = null;
			if (!flag5)
			{
				component = (Component)c;
			}
			bool flag6 = (object)component == null;
			gameObject = null;
			if (!flag6)
			{
				GameObject gameObject3 = component.gameObject;
				gameObject = gameObject3;
			}
			goto IL_01f1;
		}
	}

	private sealed class _003C_003Ec__DisplayClass50_0
	{
		public Func<object, object> getter;

		public object target;

		public Action<object, object> setter;

		internal int _003CCustomTweenInt_003Eb__0()
		{
			//IL_00c1: Expected I4, but got O
			//IL_0043: Expected O, but got I
			Func<object, object> func = getter;
			if (getter != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2 @ rcx_v1 (System.Func`2<System.Object, System.Object>)+18] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEB8]");
				object obj = 0;
				object obj2 = default(object);
				if (obj2 != null)
				{
					object obj3 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rdx_v6+40]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ r8_v4+40]");
					if (num == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ rax_v6+10]");
						return 0;
					}
					goto IL_00b3;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			goto IL_00b3;
			IL_00b3:
			InvalidCastException ex2 = new InvalidCastException();
			return (int)ex2;
		}

		internal void _003CCustomTweenInt_003Eb__1(int x)
		{
			//IL_0033: Expected O, but got I
			//IL_0043: Expected O, but got I
			//IL_0053: Expected O, but got I
			Action<object, object> action = setter;
			object obj = target;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbx_v1 (System.Action`2<System.Object, System.Object>)+28]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbx_v1 (System.Action`2<System.Object, System.Object>)+40]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbx_v1 (System.Action`2<System.Object, System.Object>)+18]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v27 @ rax_v3 (should have been resolved before IL gen)");
			/*Error: End of method reached without returning.*/;
		}
	}

	private sealed class _003C_003Ec__DisplayClass51_0
	{
		public Func<object, object> getter;

		public object target;

		public Action<object, object> setter;

		internal float _003CCustomTweenFloat_003Eb__0()
		{
			//IL_0043: Expected O, but got I
			//IL_00a4: Expected F4, but got I
			Func<object, object> func = getter;
			if (getter != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2 @ rcx_v1 (System.Func`2<System.Object, System.Object>)+18] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEE8]");
				object obj = 0;
				object obj2 = default(object);
				if (obj2 != null)
				{
					object obj3 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rdx_v6+40]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ r8_v4+40]");
					if (num == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ rax_v6+10]");
						return 0f;
					}
					goto IL_00b3;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			goto IL_00b3;
			IL_00b3:
			throw new InvalidCastException();
		}

		internal void _003CCustomTweenFloat_003Eb__1(float x)
		{
			//IL_0033: Expected O, but got I
			//IL_0043: Expected O, but got I
			//IL_0053: Expected O, but got I
			Action<object, object> action = setter;
			object obj = target;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbx_v1 (System.Action`2<System.Object, System.Object>)+28]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbx_v1 (System.Action`2<System.Object, System.Object>)+40]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbx_v1 (System.Action`2<System.Object, System.Object>)+18]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v28 @ rax_v3 (should have been resolved before IL gen)");
			/*Error: End of method reached without returning.*/;
		}
	}

	private sealed class _003C_003Ec__DisplayClass52_0
	{
		public Func<object, object> getter;

		public object target;

		public Action<object, object> setter;

		internal double _003CCustomTweenDouble_003Eb__0()
		{
			//IL_0043: Expected O, but got I
			//IL_00a4: Expected F8, but got I
			Func<object, object> func = getter;
			if (getter != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2 @ rcx_v1 (System.Func`2<System.Object, System.Object>)+18] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEF0]");
				object obj = 0;
				object obj2 = default(object);
				if (obj2 != null)
				{
					object obj3 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rdx_v6+40]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ r8_v4+40]");
					if (num == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ rax_v6+10]");
						return 0.0;
					}
					goto IL_00b3;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			goto IL_00b3;
			IL_00b3:
			throw new InvalidCastException();
		}

		internal void _003CCustomTweenDouble_003Eb__1(double x)
		{
			//IL_0033: Expected O, but got I
			//IL_0043: Expected O, but got I
			//IL_0053: Expected O, but got I
			Action<object, object> action = setter;
			object obj = target;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbx_v1 (System.Action`2<System.Object, System.Object>)+28]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbx_v1 (System.Action`2<System.Object, System.Object>)+40]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbx_v1 (System.Action`2<System.Object, System.Object>)+18]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v28 @ rax_v3 (should have been resolved before IL gen)");
			/*Error: End of method reached without returning.*/;
		}
	}

	private sealed class _003C_003Ec__DisplayClass53_0
	{
		public EggFloat eggNum;

		internal float _003CCustomTweenEggFloat_003Eb__0()
		{
			EggFloat eggFloat = eggNum;
			return eggFloat._val;
		}

		internal void _003CCustomTweenEggFloat_003Eb__1(float x)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			EggFloat eggFloat = eggNum;
			float num = default(float);
			object obj = num & -2147483649L;
			if ((nint)obj != 2139095040)
			{
				object obj2 = num & -2147483649L;
				if ((nint)obj2 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B24350h\"");
					if (num == -1f / 0f)
					{
						eggFloat._val = -3.4028235E+38f;
						return;
					}
				}
			}
			eggFloat._val = 3.4028235E+38f;
		}

		internal float _003CCustomTweenEggFloat_003Eb__2()
		{
			EggFloat eggFloat = eggNum;
			return eggFloat._eggVal;
		}

		internal void _003CCustomTweenEggFloat_003Eb__3(float x)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			EggFloat eggFloat = eggNum;
			float num = default(float);
			object obj = num & -2147483649L;
			if ((nint)obj != 2139095040)
			{
				object obj2 = num & -2147483649L;
				if ((nint)obj2 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B243B0h\"");
					if (num == -1f / 0f)
					{
						eggFloat._eggVal = -3.4028235E+38f;
						return;
					}
				}
			}
			eggFloat._eggVal = 3.4028235E+38f;
		}
	}

	private sealed class _003C_003Ec__DisplayClass54_0
	{
		public EggDouble eggNum;

		internal double _003CCustomTweenEggDouble_003Eb__0()
		{
			EggDouble eggDouble = eggNum;
			return eggDouble._val;
		}

		internal void _003CCustomTweenEggDouble_003Eb__1(double x)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			EggDouble eggDouble = eggNum;
			double num = default(double);
			object obj = num & 0x7FFFFFFFFFFFFFFFL;
			if ((long)obj != 9218868437227405312L)
			{
				object obj2 = num & 0x7FFFFFFFFFFFFFFFL;
				if ((long)obj2 <= 9218868437227405312L)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm1,qword ptr [188A11860h]\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B24441h\"");
					if ((long)obj2 == 9218868437227405312L)
					{
						eggDouble._val = -1.7976931348623157E+308;
						return;
					}
				}
			}
			eggDouble._val = 1.7976931348623157E+308;
		}

		internal double _003CCustomTweenEggDouble_003Eb__2()
		{
			EggDouble eggDouble = eggNum;
			return eggDouble._eggVal;
		}

		internal void _003CCustomTweenEggDouble_003Eb__3(double x)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			EggDouble eggDouble = eggNum;
			double num = default(double);
			object obj = num & 0x7FFFFFFFFFFFFFFFL;
			if ((long)obj != 9218868437227405312L)
			{
				object obj2 = num & 0x7FFFFFFFFFFFFFFFL;
				if ((long)obj2 <= 9218868437227405312L)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm1,qword ptr [188A11860h]\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B244E1h\"");
					if ((long)obj2 == 9218868437227405312L)
					{
						eggDouble._eggVal = -1.7976931348623157E+308;
						return;
					}
				}
			}
			eggDouble._eggVal = 1.7976931348623157E+308;
		}
	}

	private sealed class _003C_003Ec__DisplayClass55_0
	{
		public EggFloat eggNum;

		internal float _003CCustomTweenEggFloat_003Eb__0()
		{
			EggFloat eggFloat = eggNum;
			return eggFloat._val;
		}

		internal void _003CCustomTweenEggFloat_003Eb__1(float x)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			EggFloat eggFloat = eggNum;
			float num = default(float);
			object obj = num & -2147483649L;
			if ((nint)obj != 2139095040)
			{
				object obj2 = num & -2147483649L;
				if ((nint)obj2 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B24350h\"");
					if (num == -1f / 0f)
					{
						eggFloat._val = -3.4028235E+38f;
						return;
					}
				}
			}
			eggFloat._val = 3.4028235E+38f;
		}

		internal float _003CCustomTweenEggFloat_003Eb__2()
		{
			EggFloat eggFloat = eggNum;
			return eggFloat._eggVal;
		}

		internal void _003CCustomTweenEggFloat_003Eb__3(float x)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			EggFloat eggFloat = eggNum;
			float num = default(float);
			object obj = num & -2147483649L;
			if ((nint)obj != 2139095040)
			{
				object obj2 = num & -2147483649L;
				if ((nint)obj2 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B243B0h\"");
					if (num == -1f / 0f)
					{
						eggFloat._eggVal = -3.4028235E+38f;
						return;
					}
				}
			}
			eggFloat._eggVal = 3.4028235E+38f;
		}
	}

	private sealed class _003C_003Ec__DisplayClass56_0
	{
		public EggDouble eggNum;

		internal double _003CCustomTweenEggDouble_003Eb__0()
		{
			EggDouble eggDouble = eggNum;
			return eggDouble._val;
		}

		internal void _003CCustomTweenEggDouble_003Eb__1(double x)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			EggDouble eggDouble = eggNum;
			double num = default(double);
			object obj = num & 0x7FFFFFFFFFFFFFFFL;
			if ((long)obj != 9218868437227405312L)
			{
				object obj2 = num & 0x7FFFFFFFFFFFFFFFL;
				if ((long)obj2 <= 9218868437227405312L)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm1,qword ptr [188A11860h]\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B24441h\"");
					if ((long)obj2 == 9218868437227405312L)
					{
						eggDouble._val = -1.7976931348623157E+308;
						return;
					}
				}
			}
			eggDouble._val = 1.7976931348623157E+308;
		}

		internal double _003CCustomTweenEggDouble_003Eb__2()
		{
			EggDouble eggDouble = eggNum;
			return eggDouble._eggVal;
		}

		internal void _003CCustomTweenEggDouble_003Eb__3(double x)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			EggDouble eggDouble = eggNum;
			double num = default(double);
			object obj = num & 0x7FFFFFFFFFFFFFFFL;
			if ((long)obj != 9218868437227405312L)
			{
				object obj2 = num & 0x7FFFFFFFFFFFFFFFL;
				if ((long)obj2 <= 9218868437227405312L)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm1,qword ptr [188A11860h]\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B244E1h\"");
					if ((long)obj2 == 9218868437227405312L)
					{
						eggDouble._eggVal = -1.7976931348623157E+308;
						return;
					}
				}
			}
			eggDouble._eggVal = 1.7976931348623157E+308;
		}
	}

	private sealed class _003C_003Ec__DisplayClass57_0
	{
		public PhaserScene.BoxedVector2 target;

		internal float _003CAddBoxedVector2Tweens_003Eb__0()
		{
			PhaserScene.BoxedVector2 boxedVector = target;
			return boxedVector.x;
		}

		internal void _003CAddBoxedVector2Tweens_003Eb__1(float x)
		{
			PhaserScene.BoxedVector2 boxedVector = target;
			boxedVector.x = x;
		}

		internal float _003CAddBoxedVector2Tweens_003Eb__2()
		{
			PhaserScene.BoxedVector2 boxedVector = target;
			return boxedVector.y;
		}

		internal void _003CAddBoxedVector2Tweens_003Eb__3(float y)
		{
			PhaserScene.BoxedVector2 boxedVector = target;
			boxedVector.y = y;
		}
	}

	private static Dictionary<Type, Action<int, TweenConfig, Sequence>> targetTypeSwitch;

	private static Dictionary<Type, Func<Action<object, object>, Func<object, object>, object, object, TweenConfig, int, Tween>> fieldTypeSwitch;

	private static Dictionary<(Type, string), CachedCustomField> customFieldCache;

	public static Func<int, float> Stagger(float value, StaggerConfig config = null)
	{
		//IL_00e0: Expected I4, but got O
		//IL_0066: Invalid comparison between F4 and I4
		StaggerUtils._003C_003Ec__DisplayClass1_0 obj = new StaggerUtils._003C_003Ec__DisplayClass1_0();
		Func<int, float> func;
		if (obj != null)
		{
			obj.value = value;
			obj.config = config;
			if (obj.config != null)
			{
				StaggerConfig config2 = obj.config;
				bool flag = config2.start == 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B185DDh\"");
				if (!flag)
				{
					func = null;
					goto IL_00d3;
				}
			}
			func = null;
			goto IL_00d3;
		}
		return (Func<int, float>)(object)new NullReferenceException();
		IL_00d3:
		float num = ((StaggerUtils._003C_003Ec__DisplayClass1_0)(object)func)._003CGetStaggerFunc_003Eb__1((int)obj);
		return func;
	}

	public static MultiTargetTween Add(TweenConfig config)
	{
		//IL_02bc: Expected I, but got O
		//IL_02c9: Expected I, but got O
		//IL_010a: Expected O, but got I
		//IL_013d: Expected I, but got O
		//IL_0145: Expected I, but got O
		//IL_0155: Expected O, but got I
		//IL_01d5: Expected O, but got I4
		//IL_0252: Expected O, but got I
		//IL_0191: Expected O, but got I
		//IL_0289: Expected O, but got I
		//IL_01ea: Expected O, but got I
		//IL_01c7: Expected O, but got I4
		//IL_029b: Expected O, but got I4
		//IL_0393: Expected O, but got I4
		//IL_099d: Expected O, but got I4
		//IL_09ad: Expected I, but got O
		//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Expected O, but got Unknown
		//IL_095a: Expected I, but got O
		//IL_05c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c9: Expected O, but got Unknown
		//IL_05d2: Expected O, but got I4
		//IL_05da: Expected I, but got O
		//IL_04d8: Expected I, but got O
		//IL_04f9: Expected O, but got I
		//IL_0947: Expected I, but got O
		float num2 = default(float);
		if (config.yoyo)
		{
			if (config.repeat == 0 || config.repeat == 1)
			{
				config.repeat = 2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			float num = default(float);
			config.repeatDelay = num;
			num2 = num;
		}
		MultiTargetTween multiTargetTween = new MultiTargetTween();
		List<Sequence> tweens = new List<Sequence>();
		multiTargetTween.tweens = tweens;
		List<float> delays = new List<float>();
		multiTargetTween.delays = delays;
		List<object[]> list = new List<object[]>();
		IEnumerable<object> enumerable = config.targets;
		nint num3 = 0;
		Type type = default(Type);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdi_v7 (System.Collections.Generic.IEnumerable`1<System.Object>)+18]");
			_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals5;
			object obj3;
			if ((nint)0 != 0)
			{
				CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass4_0();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdi_v7 (System.Collections.Generic.IEnumerable`1<System.Object>)+18]");
				if ((nint)0 <= (nint)0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdi_v7 (System.Collections.Generic.IEnumerable`1<System.Object>)+20]");
				Component component = (Component)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdi_v7 (System.Collections.Generic.IEnumerable`1<System.Object>)+20]");
				if ((nint)0 == 0)
				{
					goto IL_0201;
				}
				nint num4 = (nint)typeof(Component);
				nint num5 = (nint)component;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v963 @ r8_v53 (Il2CppClass<UnityEngine.Component>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v964 @ rax_v136 (Il2CppClass<UnityEngine.Component>)+130]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v963 @ r8_v53 (Il2CppClass<UnityEngine.Component>)+130]");
				if (num6 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v964 @ rax_v136 (Il2CppClass<UnityEngine.Component>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ rax_v141+FFFFFFF8+v965 @ rcx_v104*8]");
					if (0 == (nint)typeof(Component))
					{
						obj3 = 1;
						goto IL_08d0;
					}
				}
				obj3 = 0;
				goto IL_08d0;
			}
			List<object[]> list2 = list;
			nint num7 = unchecked((nint)null);
			MultiTargetTween multiTargetTween2 = multiTargetTween;
			nint num8 = unchecked((nint)null);
			object obj7;
			while (true)
			{
				if (num8 < list2._size)
				{
					Sequence sequence = DOTween.Sequence();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					sequence.stringId = "DefaultGameTweenId";
					if (num7 < list2._size)
					{
						object[][] items = list2._items;
						if (num7 >= items.Length)
						{
							break;
						}
						object[] array = items[num7];
						int targetIndex;
						for (object obj4 = 0; (nint)obj4 < array.Length; AddDelaysAndRepeats(targetIndex, config, sequence), AddOnYoyo(config, sequence), AddOnRepeat(config, sequence), AddOnUpdate(config, sequence, multiTargetTween), obj4++, obj7 = 0, num3 = (nint)sequence, multiTargetTween2 = multiTargetTween)
						{
							if ((nint)obj4 >= array.Length)
							{
								goto end_IL_08f2;
							}
							object obj5 = array[obj4];
							object obj6 = obj5 + 32;
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
							targetIndex = MiscExtensions.IndexOf(config.targets, obj5);
							int num9 = targetTypeSwitch.FindEntry(type);
							if (num9 < 0)
							{
								Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(ArcadeSprite));
								if (!type.IsSubclassOf(typeFromHandle))
								{
									Type typeFromHandle2 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(PhaserSprite));
									bool flag = type.IsSubclassOf(typeFromHandle2);
									bool flag2 = !flag;
									num7 = (nint)typeof(PhaserSprite);
									if (flag2)
									{
										goto IL_0917;
									}
									num7 = (nint)typeof(PhaserSprite);
								}
								else
								{
									num7 = (nint)typeof(ArcadeSprite);
								}
								Type typeFromHandle3 = Type.GetTypeFromHandle((RuntimeTypeHandle)num7);
								Action<int, TweenConfig, Sequence> action = targetTypeSwitch.get_Item(typeFromHandle3);
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v211 @ rax_v97 (System.Action`3<System.Int32, VampireSurvivors.Framework.PhaserTweens.TweenConfig, DG.Tweening.Sequence>)+18] (should have been resolved before IL gen)");
								goto IL_0917;
							}
							Action<int, TweenConfig, Sequence> action2 = targetTypeSwitch.get_Item(type);
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v212 @ rax_v86 (System.Action`3<System.Int32, VampireSurvivors.Framework.PhaserTweens.TweenConfig, DG.Tweening.Sequence>)+18] (should have been resolved before IL gen)");
							continue;
							IL_0917:
							if (config.custom != null)
							{
								AddCustomTweens(targetIndex, obj5, config, sequence);
							}
						}
						Func<int, float> staggerDelay = config.staggerDelay;
						if (config.staggerDelay != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1393 @ rcx_v47 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
						}
						else
						{
							num2 = config.delay;
						}
						num2 *= 0.001f;
						multiTargetTween2.Add(sequence, num2);
						num7 = 1;
						obj7 = 0;
						list2 = list;
						num3 = (nint)sequence;
						num8 = num7;
						continue;
					}
				}
				else
				{
					List<Sequence> tweens2 = multiTargetTween2.tweens;
					if (tweens2._size > 0)
					{
						Sequence[] items2 = tweens2._items;
						if (items2.Length <= 0)
						{
							break;
						}
						Sequence sequence2 = items2[0];
						if (config.onStart != null && items2[0] != null && ((Tween)sequence2)._003Cactive_003Ek__BackingField)
						{
							((ABSSequentiable)sequence2).onStart = config.onStart;
						}
						List<Sequence> tweens3 = multiTargetTween2.tweens;
						if (tweens3._size > 0)
						{
							Sequence[] items3 = tweens3._items;
							if (items3.Length <= 0)
							{
								break;
							}
							Sequence sequence3 = items3[0];
							if (config.onStop != null && items3[0] != null && ((Tween)sequence3)._003Cactive_003Ek__BackingField)
							{
								sequence3.onKill = config.onStop;
							}
							Sequence longestTween = multiTargetTween2.GetLongestTween();
							if (config.onComplete != null && longestTween != null && ((Tween)longestTween)._003Cactive_003Ek__BackingField)
							{
								longestTween.onComplete = config.onComplete;
							}
							return multiTargetTween2;
						}
					}
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new NullReferenceException();
			}
			break;
			IL_0201:
			GameObject go = null;
			goto IL_020b;
			IL_020b:
			CS_0024_003C_003E8__locals5.go = go;
			Func<object, bool> predicate = delegate(object c)
			{
				//IL_0013: Expected I, but got O
				//IL_001b: Expected I, but got O
				//IL_002b: Expected O, but got I
				//IL_00ab: Expected O, but got I4
				//IL_0067: Expected O, but got I
				//IL_0232: Expected O, but got I4
				//IL_024c: Expected O, but got I4
				//IL_009d: Expected O, but got I4
				//IL_01ad: Expected I4, but got O
				bool flag4 = c == null;
				GameObject gameObject = null;
				object obj10;
				if (!flag4)
				{
					nint num10 = (nint)typeof(Component);
					nint num11 = (nint)c;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v2 (Il2CppClass<UnityEngine.Component>)+130]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ r8_v2 (Il2CppClass<System.Object>)+130]");
					nint num12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v2 (Il2CppClass<UnityEngine.Component>)+130]");
					if (num12 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ r8_v2 (Il2CppClass<System.Object>)+C8]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v27+FFFFFFF8+v51 @ rax_v22*8]");
						if (0 == (nint)typeof(Component))
						{
							obj10 = 1;
							goto IL_01cf;
						}
					}
					obj10 = 0;
					goto IL_01cf;
				}
				goto IL_01f1;
				IL_01f1:
				GameObject go2 = CS_0024_003C_003E8__locals5.go;
				bool flag5 = (object)CS_0024_003C_003E8__locals5.go == null;
				bool flag6 = (object)gameObject == null;
				object obj11 = flag6 & flag5;
				bool flag7 = obj11 == null;
				object obj12 = !flag7;
				if (obj12 == null)
				{
					if ((object)CS_0024_003C_003E8__locals5.go != null)
					{
						if ((object)gameObject != null)
						{
							object obj13 = (object)gameObject - (object)CS_0024_003C_003E8__locals5.go;
							return obj13 == null;
						}
						return ((UnityEngine.Object)go2).m_CachedPtr == (IntPtr)0;
					}
					if ((object)gameObject == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					return ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				}
				return true;
				IL_01cf:
				bool flag8 = obj10 == null;
				Component component3 = null;
				if (!flag8)
				{
					component3 = (Component)c;
				}
				bool flag9 = (object)component3 == null;
				gameObject = null;
				if (!flag9)
				{
					GameObject gameObject2 = component3.gameObject;
					gameObject = gameObject2;
				}
				goto IL_01f1;
			};
			IEnumerable<object> source = Enumerable.Where(enumerable, predicate);
			IEnumerable<object> enumerable2 = Enumerable.Where(source, (Func<object, bool>)0);
			list.Add((object[])enumerable2);
			IEnumerable<object> first = Enumerable.Except(enumerable, enumerable2);
			IEnumerable<object> enumerable3 = Enumerable.Except(first, (IEnumerable<object>)0);
			obj7 = 0;
			enumerable = enumerable3;
			num3 = 0;
			continue;
			IL_08d0:
			bool flag3 = obj3 == null;
			Component component2 = null;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdi_v7 (System.Collections.Generic.IEnumerable`1<System.Object>)+20]");
				component2 = (Component)0;
			}
			if ((object)component2 != null)
			{
				go = component2.gameObject;
				goto IL_020b;
			}
			goto IL_0201;
			continue;
			end_IL_08f2:
			break;
		}
		return (MultiTargetTween)(object)new IndexOutOfRangeException();
	}

	private static Action<object, object> CompileFieldSetter(Type type, FieldInfo fieldInfo)
	{
		//IL_022f: Expected O, but got I
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0247: Expected I, but got O
		//IL_0071: Expected O, but got I
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_016a: Expected I, but got O
		//IL_01c0: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AE80]");
		object obj = (nint)0 + (nint)32;
		Type type2;
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj3 = default(object);
			object obj2 = obj3 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type type3 = default(Type);
			type2 = type3;
		}
		else
		{
			type2 = null;
		}
		nint num = (nint)typeof(Expression);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v7 (Il2CppClass<System.Linq.Expressions.Expression>)+E4]");
		bool flag = (nint)0 == 0;
		ParameterExpression parameterExpression = Expression.Parameter(type2, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AE80]");
		object obj4 = (nint)0 + (nint)32;
		Type type4 = null;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj6 = default(object);
			object obj5 = obj6 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type type5 = default(Type);
			type4 = type5;
		}
		ParameterExpression parameterExpression2 = Expression.Parameter(type4, null);
		UnaryExpression expression = Expression.Convert(parameterExpression, type, null);
		MemberExpression left = Expression.Field(expression, fieldInfo);
		Type fieldType = fieldInfo.FieldType;
		UnaryExpression right = Expression.Convert(parameterExpression2, fieldType, null);
		BinaryExpression body = Expression.Assign(left, right);
		ParameterExpression[] array = new ParameterExpression[2];
		if (parameterExpression != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			if (obj7 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if (parameterExpression2 != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj8 = default(object);
			if (obj8 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Expression<Action<object, object>> expression2 = Expression.Lambda<Action<object, object>>(body, array);
		return expression2.Compile();
	}

	private static Func<object, object> CompileFieldGetter(Type type, FieldInfo fieldInfo)
	{
		//IL_01a3: Expected O, but got I
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_01c0: Expected I, but got O
		//IL_009e: Expected O, but got I
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_0134: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AE80]");
		object obj = (nint)0 + (nint)32;
		Type type2;
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj3 = default(object);
			object obj2 = obj3 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type type3 = default(Type);
			type2 = type3;
		}
		else
		{
			type2 = null;
		}
		ParameterExpression parameterExpression = Expression.Parameter(type2, null);
		nint num = (nint)typeof(Expression);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rcx_v10 (Il2CppClass<System.Linq.Expressions.Expression>)+E4]");
		bool flag = (nint)0 == 0;
		UnaryExpression expression = Expression.Convert(parameterExpression, type, null);
		MemberExpression expression2 = Expression.Field(expression, fieldInfo);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AE80]");
		object obj4 = (nint)0 + (nint)32;
		Type type4 = null;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj6 = default(object);
			object obj5 = obj6 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type type5 = default(Type);
			type4 = type5;
		}
		UnaryExpression body = Expression.Convert(expression2, type4, null);
		ParameterExpression[] array = new ParameterExpression[1];
		if (parameterExpression != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			if (obj7 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Expression<Func<object, object>> expression3 = Expression.Lambda<Func<object, object>>(body, array);
		return expression3.Compile();
	}

	private static Action<object, object> CompilePropertySetter(Type type, PropertyInfo fieldInfo)
	{
		//IL_022f: Expected O, but got I
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0247: Expected I, but got O
		//IL_0071: Expected O, but got I
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_016a: Expected I, but got O
		//IL_01c0: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AE80]");
		object obj = (nint)0 + (nint)32;
		Type type2;
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj3 = default(object);
			object obj2 = obj3 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type type3 = default(Type);
			type2 = type3;
		}
		else
		{
			type2 = null;
		}
		nint num = (nint)typeof(Expression);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v7 (Il2CppClass<System.Linq.Expressions.Expression>)+E4]");
		bool flag = (nint)0 == 0;
		ParameterExpression parameterExpression = Expression.Parameter(type2, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AE80]");
		object obj4 = (nint)0 + (nint)32;
		Type type4 = null;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj6 = default(object);
			object obj5 = obj6 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type type5 = default(Type);
			type4 = type5;
		}
		ParameterExpression parameterExpression2 = Expression.Parameter(type4, null);
		UnaryExpression expression = Expression.Convert(parameterExpression, type, null);
		MemberExpression left = Expression.Property(expression, fieldInfo);
		Type propertyType = fieldInfo.PropertyType;
		UnaryExpression right = Expression.Convert(parameterExpression2, propertyType, null);
		BinaryExpression body = Expression.Assign(left, right);
		ParameterExpression[] array = new ParameterExpression[2];
		if (parameterExpression != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			if (obj7 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if (parameterExpression2 != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj8 = default(object);
			if (obj8 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Expression<Action<object, object>> expression2 = Expression.Lambda<Action<object, object>>(body, array);
		return expression2.Compile();
	}

	private static Func<object, object> CompilePropertyGetter(Type type, PropertyInfo fieldInfo)
	{
		//IL_01a3: Expected O, but got I
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_01c0: Expected I, but got O
		//IL_009e: Expected O, but got I
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_0134: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AE80]");
		object obj = (nint)0 + (nint)32;
		Type type2;
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj3 = default(object);
			object obj2 = obj3 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type type3 = default(Type);
			type2 = type3;
		}
		else
		{
			type2 = null;
		}
		ParameterExpression parameterExpression = Expression.Parameter(type2, null);
		nint num = (nint)typeof(Expression);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rcx_v10 (Il2CppClass<System.Linq.Expressions.Expression>)+E4]");
		bool flag = (nint)0 == 0;
		UnaryExpression expression = Expression.Convert(parameterExpression, type, null);
		MemberExpression expression2 = Expression.Property(expression, fieldInfo);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AE80]");
		object obj4 = (nint)0 + (nint)32;
		Type type4 = null;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj6 = default(object);
			object obj5 = obj6 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type type5 = default(Type);
			type4 = type5;
		}
		UnaryExpression body = Expression.Convert(expression2, type4, null);
		ParameterExpression[] array = new ParameterExpression[1];
		if (parameterExpression != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			if (obj7 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Expression<Func<object, object>> expression3 = Expression.Lambda<Func<object, object>>(body, array);
		return expression3.Compile();
	}

	private static void HandleYoyo(TweenConfig config)
	{
		if (config.yoyo)
		{
			if (config.repeat == 0 || config.repeat == 1)
			{
				config.repeat = 2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			float repeatDelay = default(float);
			config.repeatDelay = repeatDelay;
		}
	}

	private static void AddOnComplete(TweenConfig config, Sequence sequence)
	{
		if (config.onComplete != null && sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.onComplete = config.onComplete;
		}
	}

	private static void AddOnStart(TweenConfig config, Sequence sequence)
	{
		if (config.onStart != null && sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			((ABSSequentiable)sequence).onStart = config.onStart;
		}
	}

	private static void AddOnStop(TweenConfig config, Sequence sequence)
	{
		if (config.onStop != null && sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.onKill = config.onStop;
		}
	}

	private static void AddOnYoyo(TweenConfig config, Sequence sequence)
	{
		_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass13_0();
		CS_0024_003C_003E8__locals3.config = config;
		TweenConfig config2 = CS_0024_003C_003E8__locals3.config;
		if (config2.onYoyo == null)
		{
			return;
		}
		TweenCallback onStepComplete = delegate
		{
			TweenConfig config3 = CS_0024_003C_003E8__locals3.config;
			if (config3.yoyo)
			{
				TweenCallback onYoyo = config3.onYoyo;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v24.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.onStepComplete = onStepComplete;
		}
	}

	private static void AddOnRepeat(TweenConfig config, Sequence sequence)
	{
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass14_0();
		CS_0024_003C_003E8__locals8.config = config;
		CS_0024_003C_003E8__locals8.sequence = sequence;
		TweenConfig config2 = CS_0024_003C_003E8__locals8.config;
		if (config2.onRepeat == null)
		{
			return;
		}
		Sequence sequence2 = CS_0024_003C_003E8__locals8.sequence;
		TweenCallback onStepComplete = delegate
		{
			//IL_00b0: Expected O, but got I4
			TweenConfig config3 = CS_0024_003C_003E8__locals8.config;
			if (!config3.yoyo)
			{
				TweenCallback onRepeat = config3.onRepeat;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v36.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			else
			{
				Sequence sequence3 = CS_0024_003C_003E8__locals8.sequence;
				if (((Tween)sequence3)._003Cactive_003Ek__BackingField)
				{
					int num = ((Tween)sequence3).completedLoops & 1;
					bool flag = num == 0;
					object obj = !flag;
					if (obj != null)
					{
						return;
					}
				}
				else if (Debugger._logPriority > 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DAF]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					Debugger.LogWarning("This Tween has been killed and is now invalid");
				}
				TweenConfig config4 = CS_0024_003C_003E8__locals8.config;
				TweenCallback onRepeat2 = config4.onRepeat;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v94.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		if (CS_0024_003C_003E8__locals8.sequence != null && ((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			sequence2.onStepComplete = onStepComplete;
		}
	}

	private static void AddOnUpdate(TweenConfig config, Sequence sequence, MultiTargetTween multiTargetTween)
	{
		if (config.onUpdate != null)
		{
			multiTargetTween._onUpdate = config.onUpdate;
			TweenCallback onUpdate = multiTargetTween.OnUpdate;
			if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				sequence.onUpdate = onUpdate;
			}
		}
	}

	private static void AddDelay(int targetIndex, TweenConfig config, Sequence sequence)
	{
		//IL_0212: Invalid comparison between F4 and I4
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals9.sequence = sequence;
		Func<int, float> staggerDelay = config.staggerDelay;
		float num;
		if (config.staggerDelay != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v286 @ rcx_v6 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			float num2 = default(float);
			num = num2;
		}
		else
		{
			num = config.delay;
		}
		float num3 = num * 0.001f;
		if (!(num3 > 0f))
		{
			return;
		}
		_003C_003Ec__DisplayClass16_1 CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass16_1();
		Sequence sequence2 = TweenExtensions.Pause(CS_0024_003C_003E8__locals9.sequence);
		Sequence sequence3 = CS_0024_003C_003E8__locals9.sequence;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		sequence3.stringId = "PausedGameTweenId";
		TweenCallback callback = delegate
		{
			Sequence sequence5 = CS_0024_003C_003E8__locals9.sequence;
			if (((Tween)sequence5)._003Cactive_003Ek__BackingField)
			{
				Sequence sequence6 = TweenExtensions.Play(sequence5);
				Sequence sequence7 = CS_0024_003C_003E8__locals9.sequence;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				sequence7.stringId = "DefaultGameTweenId";
			}
		};
		Tween tween = DOVirtual.DelayedCall(num3, callback, ignoreTimeScale: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		tween.stringId = "DefaultGameTweenId";
		CS_0024_003C_003E8__locals12.delayTween = tween;
		Sequence sequence4 = CS_0024_003C_003E8__locals9.sequence;
		TweenCallback onKill = delegate
		{
			Tween delayTween = CS_0024_003C_003E8__locals12.delayTween;
			if (CS_0024_003C_003E8__locals12.delayTween != null && delayTween._003Cactive_003Ek__BackingField)
			{
				TweenExtensions.Kill(CS_0024_003C_003E8__locals12.delayTween);
			}
		};
		if (CS_0024_003C_003E8__locals9.sequence != null && ((Tween)sequence4)._003Cactive_003Ek__BackingField)
		{
			sequence4.onKill = onKill;
		}
	}

	private static void AddRepeatDelay(TweenConfig config, Sequence sequence)
	{
		//IL_0013: Invalid comparison between F4 and I4
		if (config.repeatDelay > 0f)
		{
			float delay = config.repeatDelay * 0.001f;
			Sequence sequence2 = TweenSettingsExtensions.SetDelay(sequence, delay);
		}
	}

	private static void AddRepeat(TweenConfig config, Sequence sequence)
	{
		//IL_00ed: Expected I4, but got I8
		if (config.repeat == 0)
		{
			return;
		}
		int num = config.repeat;
		bool flag = !config.yoyo;
		bool loopType = !flag;
		if (sequence == null || !((Tween)sequence)._003Cactive_003Ek__BackingField || ((Tween)sequence).creationLocked)
		{
			return;
		}
		if (config.repeat < 4294967295L)
		{
			num = -1;
		}
		((Tween)sequence).loops = num;
		((Tween)sequence).loopType = (loopType ? LoopType.Yoyo : LoopType.Restart);
		if (((ABSSequentiable)sequence).tweenType == TweenType.Tweener)
		{
			if (num <= 4294967295L)
			{
				((Tween)sequence).fullDuration = 1f / 0f;
				return;
			}
			float fullDuration = (float)num * ((Tween)sequence).duration;
			((Tween)sequence).fullDuration = fullDuration;
		}
	}

	private static void AddDelaysAndRepeats(int targetIndex, TweenConfig config, Sequence sequence)
	{
		//IL_0029: Invalid comparison between F4 and I4
		//IL_0136: Expected I4, but got I8
		AddDelay(targetIndex, config, sequence);
		if (config.repeatDelay > 0f)
		{
			float delay = config.repeatDelay * 0.001f;
			Sequence sequence2 = TweenSettingsExtensions.SetDelay(sequence, delay);
		}
		if (config.repeat == 0)
		{
			return;
		}
		int num = config.repeat;
		bool flag = !config.yoyo;
		bool loopType = !flag;
		if (sequence == null || !((Tween)sequence)._003Cactive_003Ek__BackingField || ((Tween)sequence).creationLocked)
		{
			return;
		}
		if (config.repeat < 4294967295L)
		{
			num = -1;
		}
		((Tween)sequence).loops = num;
		((Tween)sequence).loopType = (loopType ? LoopType.Yoyo : LoopType.Restart);
		if (((ABSSequentiable)sequence).tweenType == TweenType.Tweener)
		{
			if (num <= 4294967295L)
			{
				((Tween)sequence).fullDuration = 1f / 0f;
				return;
			}
			float fullDuration = (float)num * ((Tween)sequence).duration;
			((Tween)sequence).fullDuration = fullDuration;
		}
	}

	private static void AddTransformTweens(int targetIndex, Transform target, TweenConfig config, Sequence sequence)
	{
		Transform transform = target.transform;
		AddMoveX(targetIndex, transform, config, sequence);
		Transform transform2 = target.transform;
		AddMoveY(targetIndex, transform2, config, sequence);
		Transform transform3 = target.transform;
		AddLocalMoveX(targetIndex, transform3, config, sequence);
		Transform transform4 = target.transform;
		AddLocalMoveY(targetIndex, transform4, config, sequence);
		Transform transform5 = target.transform;
		AddScale(targetIndex, transform5, config, sequence);
		Transform transform6 = target.transform;
		AddScaleX(targetIndex, transform6, config, sequence);
		Transform transform7 = target.transform;
		AddScaleY(targetIndex, transform7, config, sequence);
		Transform transform8 = target.transform;
		AddAngle(targetIndex, transform8, config, sequence);
		Transform transform9 = target.transform;
		AddLocalAngle(targetIndex, transform9, config, sequence);
	}

	private static void AddMoveX(int targetIndex, Transform target, TweenConfig config, Sequence sequence)
	{
		//IL_009f: Expected F4, but got I
		//IL_00f5: Expected O, but got I4
		if ((object)config.x == null && config.staggerX == null)
		{
			return;
		}
		Func<int, float> staggerX = config.staggerX;
		float endValue;
		if (config.staggerX != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v172 @ rcx_v7 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			float num = default(float);
			endValue = num;
		}
		else
		{
			if ((object)config.x == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+64]");
			endValue = 0f;
		}
		Func<int, float> staggerDuration = config.staggerDuration;
		if (config.staggerDuration != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v259 @ rcx_v9 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
		}
		float duration = config.duration * 0.001f;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMoveX(target, endValue, duration);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj = config.ease + -32;
				if ((nint)obj <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore, 0f);
		}
	}

	private static void AddMoveY(int targetIndex, Transform target, TweenConfig config, Sequence sequence)
	{
		//IL_009f: Expected F4, but got I
		//IL_00f5: Expected O, but got I4
		if ((object)config.y == null && config.staggerY == null)
		{
			return;
		}
		Func<int, float> staggerY = config.staggerY;
		float endValue;
		if (config.staggerY != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v172 @ rcx_v7 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			float num = default(float);
			endValue = num;
		}
		else
		{
			if ((object)config.y == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+6C]");
			endValue = 0f;
		}
		Func<int, float> staggerDuration = config.staggerDuration;
		if (config.staggerDuration != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v259 @ rcx_v9 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
		}
		float duration = config.duration * 0.001f;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMoveY(target, endValue, duration);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj = config.ease + -32;
				if ((nint)obj <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore, 0f);
		}
	}

	private static void AddLocalMoveX(int targetIndex, Transform target, TweenConfig config, Sequence sequence)
	{
		//IL_009f: Expected F4, but got I
		//IL_00f5: Expected O, but got I4
		if ((object)config.localX == null && config.staggerLocalX == null)
		{
			return;
		}
		Func<int, float> staggerLocalX = config.staggerLocalX;
		float endValue;
		if (config.staggerLocalX != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v172 @ rcx_v7 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			float num = default(float);
			endValue = num;
		}
		else
		{
			if ((object)config.localX == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+74]");
			endValue = 0f;
		}
		Func<int, float> staggerDuration = config.staggerDuration;
		if (config.staggerDuration != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v259 @ rcx_v9 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
		}
		float duration = config.duration * 0.001f;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOLocalMoveX(target, endValue, duration);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj = config.ease + -32;
				if ((nint)obj <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore, 0f);
		}
	}

	private static void AddLocalMoveY(int targetIndex, Transform target, TweenConfig config, Sequence sequence)
	{
		//IL_009f: Expected F4, but got I
		//IL_00f5: Expected O, but got I4
		if ((object)config.localY == null && config.staggerLocalY == null)
		{
			return;
		}
		Func<int, float> staggerLocalY = config.staggerLocalY;
		float endValue;
		if (config.staggerLocalY != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v172 @ rcx_v7 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			float num = default(float);
			endValue = num;
		}
		else
		{
			if ((object)config.localY == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+7C]");
			endValue = 0f;
		}
		Func<int, float> staggerDuration = config.staggerDuration;
		if (config.staggerDuration != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v259 @ rcx_v9 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
		}
		float duration = config.duration * 0.001f;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOLocalMoveY(target, endValue, duration);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj = config.ease + -32;
				if ((nint)obj <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore, 0f);
		}
	}

	private static void AddScale(int targetIndex, Transform target, TweenConfig config, Sequence sequence)
	{
		//IL_009f: Expected F4, but got I
		//IL_00f5: Expected O, but got I4
		if ((object)config.scale == null && config.staggerScale == null)
		{
			return;
		}
		Func<int, float> staggerScale = config.staggerScale;
		float endValue;
		if (config.staggerScale != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v169 @ rcx_v7 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			float num = default(float);
			endValue = num;
		}
		else
		{
			if ((object)config.scale == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+84]");
			endValue = 0f;
		}
		Func<int, float> staggerDuration = config.staggerDuration;
		if (config.staggerDuration != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v255 @ rcx_v9 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
		}
		float duration = config.duration * 0.001f;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, endValue, duration);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj = config.ease + -32;
				if ((nint)obj <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore, 0f);
		}
	}

	private static void AddScaleX(int targetIndex, Transform target, TweenConfig config, Sequence sequence)
	{
		//IL_009f: Expected F4, but got I
		//IL_00f5: Expected O, but got I4
		if ((object)config.scaleX == null && config.staggerScaleX == null)
		{
			return;
		}
		Func<int, float> staggerScaleX = config.staggerScaleX;
		float endValue;
		if (config.staggerScaleX != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v169 @ rcx_v7 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			float num = default(float);
			endValue = num;
		}
		else
		{
			if ((object)config.scaleX == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+8C]");
			endValue = 0f;
		}
		Func<int, float> staggerDuration = config.staggerDuration;
		if (config.staggerDuration != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v255 @ rcx_v9 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
		}
		float duration = config.duration * 0.001f;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScaleX(target, endValue, duration);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj = config.ease + -32;
				if ((nint)obj <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore, 0f);
		}
	}

	private static void AddScaleY(int targetIndex, Transform target, TweenConfig config, Sequence sequence)
	{
		//IL_009f: Expected F4, but got I
		//IL_00f5: Expected O, but got I4
		if ((object)config.scaleY == null && config.staggerScaleY == null)
		{
			return;
		}
		Func<int, float> staggerScaleY = config.staggerScaleY;
		float endValue;
		if (config.staggerScaleY != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v169 @ rcx_v7 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			float num = default(float);
			endValue = num;
		}
		else
		{
			if ((object)config.scaleY == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+94]");
			endValue = 0f;
		}
		Func<int, float> staggerDuration = config.staggerDuration;
		if (config.staggerDuration != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v255 @ rcx_v9 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
		}
		float duration = config.duration * 0.001f;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScaleY(target, endValue, duration);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj = config.ease + -32;
				if ((nint)obj <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore, 0f);
		}
	}

	private unsafe static void AddAngle(int targetIndex, Transform target, TweenConfig config, Sequence sequence)
	{
		//IL_01fc: Expected O, but got Ref
		//IL_00f2: Expected O, but got I4
		if ((object)config.angle == null && config.staggerAngle == null)
		{
			return;
		}
		Func<int, float> staggerAngle = config.staggerAngle;
		if (config.staggerAngle != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v194 @ rcx_v7 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
		}
		else if ((object)config.angle == null)
		{
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
			return;
		}
		Func<int, float> staggerDuration = config.staggerDuration;
		float num;
		if (config.staggerDuration != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v288 @ rcx_v9 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			float num2 = default(float);
			num = num2;
		}
		else
		{
			num = config.duration;
		}
		float duration = num * 0.001f;
		object obj = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DORotate(target, (Vector3)(&obj), duration, config.rotateMode);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj2 = config.ease + -32;
				if ((nint)obj2 <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore, 0f);
		}
	}

	private unsafe static void AddLocalAngle(int targetIndex, Transform target, TweenConfig config, Sequence sequence)
	{
		//IL_01fc: Expected O, but got Ref
		//IL_00f2: Expected O, but got I4
		if ((object)config.localAngle == null && config.staggerLocalAngle == null)
		{
			return;
		}
		Func<int, float> staggerLocalAngle = config.staggerLocalAngle;
		if (config.staggerLocalAngle != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v194 @ rcx_v7 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
		}
		else if ((object)config.localAngle == null)
		{
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
			return;
		}
		Func<int, float> staggerDuration = config.staggerDuration;
		float num;
		if (config.staggerDuration != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v288 @ rcx_v9 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			float num2 = default(float);
			num = num2;
		}
		else
		{
			num = config.duration;
		}
		float duration = num * 0.001f;
		object obj = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&obj), duration, config.rotateMode);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj2 = config.ease + -32;
				if ((nint)obj2 <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore, 0f);
		}
	}

	private static void AddSpriteTweens(int targetIndex, SpriteRenderer target, TweenConfig config, Sequence sequence)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 51 Invalid \"Jump target not found in method: 0x186B1C1F0\"");
	}

	private unsafe static void AddAlphaAndTint(int targetIndex, SpriteRenderer target, TweenConfig config, Sequence sequence)
	{
		//IL_004e: Expected I4, but got O
		//IL_00ca: Expected I4, but got O
		//IL_02c8: Expected O, but got I
		//IL_00f2: Expected O, but got I
		//IL_0477: Expected O, but got I
		//IL_04b0: Expected O, but got Ref
		//IL_013b: Expected F4, but got I
		//IL_054b: Expected O, but got Ref
		//IL_0345: Expected O, but got I
		//IL_0158: Expected O, but got I
		//IL_01d7: Expected F4, but got I4
		if ((object)config.alpha == null)
		{
			bool flag = config.staggerAlpha == null;
			Sequence sequence2 = sequence;
			bool flag2 = (byte)(int)config != 0;
			if (flag)
			{
				goto IL_01ea;
			}
		}
		float num2 = default(float);
		if ((object)config.tint == null)
		{
			Sequence sequence2;
			bool flag2;
			if ((object)config.alpha == null)
			{
				bool flag3 = config.staggerAlpha == null;
				sequence2 = sequence;
				flag2 = (byte)(int)config != 0;
				if (flag3)
				{
					goto IL_01ea;
				}
			}
			Func<int, float> staggerAlpha = config.staggerAlpha;
			float num;
			if (config.staggerAlpha != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rcx_v30 (System.Func`2<System.Int32, System.Single>)+28]");
				TweenConfig tweenConfig = (TweenConfig)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v220 @ rcx_v30 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
				num = num2;
			}
			else
			{
				if ((object)config.alpha == null)
				{
					goto IL_0401;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+C0]");
				num = 0f;
				TweenConfig tweenConfig = config;
			}
			Func<int, float> staggerDuration = config.staggerDuration;
			if (config.staggerDuration != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v639 @ rcx_v32 (System.Func`2<System.Int32, System.Single>)+28]");
				TweenConfig tweenConfig = (TweenConfig)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v639 @ rcx_v32 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			}
			else
			{
				num2 = config.duration;
			}
			num2 *= 0.001f;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(target, num, num2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
			Tween t = default(Tween);
			bool flag4 = TweenSettingsExtensions.ValidateAddToSequence(sequence, t, false);
			bool flag5 = !flag4;
			float num3 = num;
			float num4 = num2;
			sequence2 = null;
			flag2 = false;
			if (!flag5)
			{
				Sequence sequence3 = Sequence.DoInsert(sequence, t, 0f);
				num3 = num;
				num4 = 0f;
				sequence2 = null;
				flag2 = false;
			}
			goto IL_01ea;
		}
		Func<int, float> staggerAlpha2 = config.staggerAlpha;
		if (config.staggerAlpha != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rcx_v16 (System.Func`2<System.Int32, System.Single>)+28]");
			TweenConfig tweenConfig2 = (TweenConfig)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v221 @ rcx_v16 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
		}
		else
		{
			if ((object)config.alpha == null)
			{
				goto IL_0401;
			}
			TweenConfig tweenConfig2 = config;
		}
		object obj = default(object);
		if ((object)config.tint != null)
		{
			Func<int, float> staggerDuration2 = config.staggerDuration;
			float num5;
			if (config.staggerDuration != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v662 @ rcx_v19 (System.Func`2<System.Int32, System.Single>)+28]");
				TweenConfig tweenConfig2 = (TweenConfig)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v662 @ rcx_v19 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
				num5 = 255f;
			}
			else
			{
				num5 = config.duration;
			}
			float duration = num5 * 0.001f;
			Tweener tweener = DOTweenModuleSprite.DOBlendableColor(target, (Color)(&obj), duration);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
			Tween t2 = default(Tween);
			if (TweenSettingsExtensions.ValidateAddToSequence(sequence, t2, false))
			{
				Sequence sequence4 = Sequence.DoInsert(sequence, t2, 0f);
			}
			return;
		}
		goto IL_0401;
		IL_0401:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		return;
		IL_01ea:
		if ((object)config.tint != null)
		{
			Func<int, float> staggerDuration3 = config.staggerDuration;
			float num6;
			if (config.staggerDuration != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ rcx_v7 (System.Func`2<System.Int32, System.Single>)+28]");
				bool flag2 = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v446 @ rcx_v7 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
				num6 = num2;
			}
			else
			{
				num6 = config.duration;
			}
			float duration2 = num6 * 0.001f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+C8]");
			object obj2 = (nint)0 >> 8;
			float num7 = (float)obj2 / 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+C8]");
			float num8 = 0f / 255f;
			Tweener tweener2 = DOTweenModuleSprite.DOBlendableColor(target, (Color)(&obj), duration2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
			Tween t3 = default(Tween);
			if (TweenSettingsExtensions.ValidateAddToSequence(sequence, t3, false))
			{
				Sequence sequence5 = Sequence.DoInsert(sequence, t3, 0f);
			}
		}
	}

	private static void AddTileSpriteTweens(int targetIndex, TileSprite target, TweenConfig config, Sequence sequence)
	{
		AddAlpha(targetIndex, target, config, sequence);
		AddTileScaleTweens(targetIndex, target, config, sequence);
	}

	private static void AddAlpha(int targetIndex, TileSprite target, TweenConfig config, Sequence sequence)
	{
		//IL_009f: Expected F4, but got I
		//IL_0141: Expected O, but got I4
		if ((object)config.alpha == null && config.staggerAlpha == null)
		{
			return;
		}
		Func<int, float> staggerAlpha = config.staggerAlpha;
		float endValue;
		if (config.staggerAlpha != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v209 @ rcx_v8 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			float num = default(float);
			endValue = num;
		}
		else
		{
			if ((object)config.alpha == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+C0]");
			endValue = 0f;
		}
		Func<int, float> staggerDuration = config.staggerDuration;
		if (config.staggerDuration != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v293 @ rcx_v10 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
		}
		float duration = config.duration * 0.001f;
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(target._spriteRenderer, endValue, duration);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj = config.ease + -32;
				if ((nint)obj <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore, 0f);
		}
	}

	private static void AddTileScaleTweens(int targetIndex, TileSprite target, TweenConfig config, Sequence sequence)
	{
		//IL_0124: Expected F4, but got I
		//IL_0275: Expected F4, but got I
		//IL_016b: Expected F4, but got I
		//IL_01a5: Expected F4, but got I4
		_003C_003Ec__DisplayClass34_0 obj = new _003C_003Ec__DisplayClass34_0();
		obj.target = target;
		if ((object)config.tileScaleX == null && (object)config.tileScaleY == null)
		{
			return;
		}
		bool flag = (object)config.tileScaleX == null;
		Sequence sequence3 = default(Sequence);
		Sequence sequence2 = sequence3;
		float num2 = default(float);
		float value = default(float);
		if (!flag)
		{
			Func<int, float> staggerDuration = config.staggerDuration;
			float num;
			if (config.staggerDuration != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v392 @ rcx_v22 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
				num = num2;
			}
			else
			{
				num = config.duration;
			}
			DOGetter<float> getter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter = null;
			((_003C_003Ec__DisplayClass34_0)(object)dOSetter)._003CAddTileScaleTweens_003Eb__1(value);
			float num3 = num * 0.001f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+9C]");
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 0f, num3);
			((_003C_003Ec__DisplayClass34_0)(object)tweenerCore)._003CAddTileScaleTweens_003Eb__1(value);
			Tween t = default(Tween);
			bool flag2 = TweenSettingsExtensions.ValidateAddToSequence(sequence3, t, false);
			bool flag3 = !flag2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+9C]");
			float num4 = 0f;
			float num5 = num3;
			sequence2 = null;
			if (!flag3)
			{
				Sequence sequence4 = Sequence.DoInsert(sequence3, t, 0f);
				num4 = 0f;
				num5 = num3;
				sequence2 = null;
			}
		}
		if ((object)config.tileScaleY != null)
		{
			Func<int, float> staggerDuration2 = config.staggerDuration;
			float num6;
			if (config.staggerDuration != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v458 @ rcx_v9 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
				num6 = num2;
			}
			else
			{
				num6 = config.duration;
			}
			DOGetter<float> getter2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter2 = null;
			((_003C_003Ec__DisplayClass34_0)(object)dOSetter2)._003CAddTileScaleTweens_003Eb__3(value);
			float duration = num6 * 0.001f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+A4]");
			TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter2, dOSetter2, 0f, duration);
			((_003C_003Ec__DisplayClass34_0)(object)tweenerCore2)._003CAddTileScaleTweens_003Eb__3(value);
			Tween t2 = default(Tween);
			if (TweenSettingsExtensions.ValidateAddToSequence(sequence3, t2, false))
			{
				Sequence sequence5 = Sequence.DoInsert(sequence3, t2, 0f);
			}
		}
	}

	private static void AddTilemapTweens(int targetIndex, Tilemap target, TweenConfig config, Sequence sequence)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 51 Invalid \"Jump target not found in method: 0x186B1CD80\"");
	}

	private static void AddAlpha(int targetIndex, Tilemap target, TweenConfig config, Sequence sequence)
	{
		//IL_00b1: Expected F4, but got I
		//IL_0179: Expected O, but got I4
		_003C_003Ec__DisplayClass36_0 obj = new _003C_003Ec__DisplayClass36_0();
		obj.target = target;
		if ((object)config.alpha == null && config.staggerAlpha == null)
		{
			return;
		}
		Func<int, float> staggerAlpha = config.staggerAlpha;
		float endValue;
		float num = default(float);
		if (config.staggerAlpha != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v183 @ rcx_v10 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			endValue = num;
		}
		else
		{
			if ((object)config.alpha == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+C0]");
			endValue = 0f;
		}
		Func<int, float> staggerDuration = config.staggerDuration;
		float num2;
		if (config.staggerDuration != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v403 @ rcx_v12 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			num2 = num;
		}
		else
		{
			num2 = config.duration;
		}
		DOGetter<Color> getter = null;
		Color color = obj._003CAddAlpha_003Eb__0();
		DOSetter<Color> dOSetter = null;
		((_003C_003Ec__DisplayClass36_0)(object)dOSetter)._003CAddAlpha_003Eb__1((Color)obj);
		float duration = num2 * 0.001f;
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.ToAlpha(getter, dOSetter, endValue, duration);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj2 = config.ease + -32;
				if ((nint)obj2 <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = TweenSettingsExtensions.SetTarget(tweenerCore, obj.target);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore, 0f);
		}
	}

	private static void AddTextMeshProTweens(int targetIndex, TextMeshPro target, TweenConfig config, Sequence sequence)
	{
		AddAlpha(targetIndex, target, config, sequence);
	}

	private static void AddTextMeshProUGUITweens(int targetIndex, TextMeshProUGUI target, TweenConfig config, Sequence sequence)
	{
		AddAlphaUGUI(targetIndex, target, config, sequence);
	}

	private static void AddAlpha(int targetIndex, TextMeshPro target, TweenConfig config, Sequence sequence)
	{
		//IL_009f: Expected F4, but got I
		//IL_00f5: Expected O, but got I4
		if ((object)config.alpha == null && config.staggerAlpha == null)
		{
			return;
		}
		Func<int, float> staggerAlpha = config.staggerAlpha;
		float endValue;
		if (config.staggerAlpha != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v169 @ rcx_v7 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			float num = default(float);
			endValue = num;
		}
		else
		{
			if ((object)config.alpha == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+C0]");
			endValue = 0f;
		}
		Func<int, float> staggerDuration = config.staggerDuration;
		if (config.staggerDuration != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v255 @ rcx_v9 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
		}
		float duration = config.duration * 0.001f;
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(target, endValue, duration);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj = config.ease + -32;
				if ((nint)obj <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore, 0f);
		}
	}

	private static void AddAlphaUGUI(int targetIndex, TextMeshProUGUI target, TweenConfig config, Sequence sequence)
	{
		//IL_009f: Expected F4, but got I
		//IL_00f5: Expected O, but got I4
		if ((object)config.alpha == null && config.staggerAlpha == null)
		{
			return;
		}
		Func<int, float> staggerAlpha = config.staggerAlpha;
		float endValue;
		if (config.staggerAlpha != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v169 @ rcx_v7 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			float num = default(float);
			endValue = num;
		}
		else
		{
			if ((object)config.alpha == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+C0]");
			endValue = 0f;
		}
		Func<int, float> staggerDuration = config.staggerDuration;
		if (config.staggerDuration != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v255 @ rcx_v9 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
		}
		float duration = config.duration * 0.001f;
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(target, endValue, duration);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj = config.ease + -32;
				if ((nint)obj <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore, 0f);
		}
	}

	private static void AddTextMeshTweens(int targetIndex, TextMesh target, TweenConfig config, Sequence sequence)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 51 Invalid \"Jump target not found in method: 0x186B1D700\"");
	}

	private static void AddAlpha(int targetIndex, TextMesh target, TweenConfig config, Sequence sequence)
	{
		//IL_0012: Expected O, but got I8
		//IL_00d8: Expected F4, but got I
		//IL_028b: Expected O, but got I4
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected O, but got Unknown
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Expected O, but got Unknown
		//IL_046f: Expected O, but got I4
		//IL_047f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0484: Expected O, but got Unknown
		//IL_00aa->IL0363: Incompatible stack heights: 0 vs 1
		//IL_03cc->IL0307: Incompatible stack heights: 1 vs 0
		//IL_02e6->IL0306: Incompatible stack heights: 2 vs 0
		//IL_0306->IL0306: Incompatible stack heights: 2 vs 0
		_003C_003Ec__DisplayClass42_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass42_0();
		TweenerCore<float, float, FloatOptions> tweenerCore;
		Ease ease;
		if (CS_0024_003C_003E8__locals6 != null)
		{
			object obj = 6603577472L;
			CS_0024_003C_003E8__locals6.target = target;
			TweenConfig tweenConfig = default(TweenConfig);
			if (tweenConfig != null)
			{
				if ((object)tweenConfig.alpha == null && tweenConfig.staggerAlpha == null)
				{
					return;
				}
				Func<int, float> staggerAlpha = tweenConfig.staggerAlpha;
				float endValue;
				float num = default(float);
				if (tweenConfig.staggerAlpha != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v428 @ rcx_v15 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
					endValue = num;
				}
				else
				{
					bool flag = (object)tweenConfig.alpha == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ r8_v5 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+C0]");
					endValue = 0f;
				}
				Func<int, float> staggerDuration = tweenConfig.staggerDuration;
				float num2;
				if (tweenConfig.staggerDuration != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v514 @ rcx_v17 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
					num2 = num;
				}
				else
				{
					num2 = tweenConfig.duration;
				}
				TextMesh target2 = CS_0024_003C_003E8__locals6.target;
				float duration = num2 * 0.001f;
				if ((object)CS_0024_003C_003E8__locals6.target != null)
				{
					bool flag2 = ((UnityEngine.Object)target2).m_CachedPtr == (IntPtr)0;
					TextMesh.get_color_Injected(((UnityEngine.Object)target2).m_CachedPtr, out Color ret);
					CS_0024_003C_003E8__locals6.col = ret;
					DOGetter<float> getter = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
					DOSetter<float> dOSetter = null;
					float x = default(float);
					((_003C_003Ec__DisplayClass42_0)(object)dOSetter)._003CAddAlpha_003Eb__1(x);
					tweenerCore = DOTween.To(getter, dOSetter, endValue, duration);
					TweenCallback tweenCallback = delegate
					{
						TextMesh target3 = CS_0024_003C_003E8__locals6.target;
						bool flag3 = ((UnityEngine.Object)target3).m_CachedPtr == (IntPtr)0;
						Color value = default(Color);
						TextMesh.set_color_Injected(((UnityEngine.Object)target3).m_CachedPtr, ref value);
					};
					if (tweenerCore != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v27 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
							if ((nint)0 != 0)
							{
								object obj2 = tweenerCore + 112;
								object obj3 = obj2 >> 12;
								object obj4 = obj3 & 0x1FFFFF;
								object obj5 = obj4 >> 6;
								object obj6 = obj4 & 0x3F;
								nint num4;
								do
								{
									object obj7 = 1 << (int)obj6;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r15_v5+462E0+v670 @ rdx_v23*8]");
									object obj8 = 0 | obj7;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r15_v5+462E0+v670 @ rdx_v23*8]");
									nint num3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r15_v5+462E0+v670 @ rdx_v23*8]");
									if (num3 == 0)
									{
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r15_v5+462E0+v670 @ rdx_v23*8]");
									num4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r15_v5+462E0+v670 @ rdx_v23*8]");
								}
								while (num4 != 0);
								ease = tweenConfig.ease;
								goto IL_0253;
							}
						}
					}
					ease = tweenConfig.ease;
					if (tweenerCore != null)
					{
						goto IL_0253;
					}
					goto IL_02bc;
				}
			}
		}
		throw new NullReferenceException();
		IL_0253:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rax_v27 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 != 0)
		{
			object obj9 = ease + -32;
			if ((nint)obj9 <= 3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rbx+0C0h]\"");
			}
			_ = 0;
		}
		goto IL_02bc;
		IL_02bc:
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore, 0f);
		}
	}

	private static void AddMaterialTweens(int targetIndex, Material target, TweenConfig config, Sequence sequence)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 51 Invalid \"Jump target not found in method: 0x186B1DC50\"");
	}

	private static void AddAlpha(int targetIndex, Material target, TweenConfig config, Sequence sequence)
	{
		//IL_009f: Expected F4, but got I
		//IL_00f5: Expected O, but got I4
		if ((object)config.alpha == null && config.staggerAlpha == null)
		{
			return;
		}
		Func<int, float> staggerAlpha = config.staggerAlpha;
		float endValue;
		if (config.staggerAlpha != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v169 @ rcx_v7 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			float num = default(float);
			endValue = num;
		}
		else
		{
			if ((object)config.alpha == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+C0]");
			endValue = 0f;
		}
		Func<int, float> staggerDuration = config.staggerDuration;
		if (config.staggerDuration != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v255 @ rcx_v9 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
		}
		float duration = config.duration * 0.001f;
		TweenerCore<Color, Color, ColorOptions> tweenerCore = ShortcutExtensions.DOFade(target, endValue, duration);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj = config.ease + -32;
				if ((nint)obj <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore, 0f);
		}
	}

	private static void AddArcadeSpriteTweens(int targetIndex, ArcadeSprite target, TweenConfig config, Sequence sequence)
	{
		Transform transform = target.transform;
		AddTransformTweens(targetIndex, transform, config, sequence);
		target.CheckRenderer();
		AddAlphaAndTint(targetIndex, target._spriteRenderer, config, sequence);
	}

	private static void AddPhaserSpriteTweens(int targetIndex, PhaserSprite target, TweenConfig config, Sequence sequence)
	{
		Transform transform = target.transform;
		AddTransformTweens(targetIndex, transform, config, sequence);
		AddAlphaAndTint(targetIndex, target._spriteRenderer, config, sequence);
	}

	private static void AddPhaserTextTweens(int targetIndex, PhaserText target, TweenConfig config, Sequence sequence)
	{
		Transform transform = target.transform;
		AddTransformTweens(targetIndex, transform, config, sequence);
		AddAlpha(targetIndex, target._textRenderer, config, sequence);
	}

	private static void AddBitmapTextTweens(int targetIndex, BitmapText target, TweenConfig config, Sequence sequence)
	{
		Transform transform = target.transform;
		AddTransformTweens(targetIndex, transform, config, sequence);
		AddAlpha(targetIndex, target._textRenderer, config, sequence);
	}

	private unsafe static void AddCustomTweens(int targetIndex, object target, TweenConfig config, Sequence sequence)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_004b: Expected F4, but got I4
		//IL_0075: Expected O, but got Ref
		//IL_03bd: Expected I, but got O
		//IL_03d0: Expected F4, but got I4
		//IL_02dc: Expected I, but got O
		//IL_02ef: Expected F4, but got I4
		//IL_014c: Expected O, but got Ref
		//IL_0258: Expected O, but got I
		//IL_01f0: Expected O, but got Ref
		//IL_0286: Expected O, but got I
		//IL_02c4: Expected F4, but got I4
		object obj = target + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		float num = 0f;
		Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
		Type type = default(Type);
		(Type, string) tuple3 = default((Type, string));
		CachedCustomField cachedCustomField = default(CachedCustomField);
		Tween t = default(Tween);
		int targetIndex2 = default(int);
		EggFloat value2 = default(EggFloat);
		Sequence sequence3 = default(Sequence);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			(Type, string) tuple = (type, null);
			bool flag = (object)type == null;
			(Type, string) tuple2 = ((Type, string))(&tuple);
			if (flag)
			{
				break;
			}
			FieldInfo field = type.GetField(null, (BindingFlags)28);
			if ((object)field != null)
			{
				Type fieldType = field.FieldType;
				Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(EggFloat));
				if ((object)fieldType != typeFromHandle)
				{
					Type fieldType2 = field.FieldType;
					Type typeFromHandle2 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(EggDouble));
					if ((object)fieldType2 != typeFromHandle2)
					{
						bool flag2 = ((Dictionary<(object, object), object>)(object)customFieldCache).TryGetValue(((object, object))(&tuple3), out object value);
						(Type, string) tuple4 = tuple;
						if (!flag2)
						{
							cachedCustomField = new CachedCustomField();
							Func<object, object> getter = CompileFieldGetter(type, field);
							cachedCustomField.getter = getter;
							Action<object, object> setter = CompileFieldSetter(type, field);
							cachedCustomField.setter = setter;
							Type fieldType3 = field.FieldType;
							cachedCustomField.type = fieldType3;
							bool flag3 = ((Dictionary<(object, object), object>)(object)customFieldCache).TryInsert(((object, object))(&tuple3), (object)cachedCustomField, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							value = cachedCustomField;
							tuple4 = tuple;
						}
						if (cachedCustomField != null)
						{
							bool flag4 = fieldTypeSwitch == null;
							Dictionary<Type, Func<Action<object, object>, Func<object, object>, object, object, TweenConfig, int, Tween>> dictionary = fieldTypeSwitch;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1450 @ rax_v185 (VampireSurvivors.Framework.PhaserTweens.CachedCustomField)+20]");
							int num2 = dictionary.FindEntry((Type)0);
							if (!flag4)
							{
								Dictionary<Type, Func<Action<object, object>, Func<object, object>, object, object, TweenConfig, int, Tween>> dictionary2 = fieldTypeSwitch;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1450 @ rax_v185 (VampireSurvivors.Framework.PhaserTweens.CachedCustomField)+20]");
								Func<Action<object, object>, Func<object, object>, object, object, TweenConfig, int, Tween> func = dictionary2.get_Item((Type)0);
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2102 @ rax_v175 (System.Func`7<System.Action`2<System.Object, System.Object>, System.Func`2<System.Object, System.Object>, System.Object, System.Object, VampireSurvivors.Framework.PhaserTweens.TweenConfig, System.Int32, DG.Tweening.T…");
								Sequence sequence2 = TweenSettingsExtensions.Insert(sequence, 0f, t);
								num = 0f;
							}
						}
					}
					else
					{
						nint num3 = (nint)typeof(EggDouble);
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
						float num4 = 0f;
						CustomTweenEggDouble(targetIndex2, target, field, config, (EggDouble)(object)value2, sequence3);
					}
				}
				else
				{
					nint num5 = (nint)typeof(EggFloat);
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
					float num6 = 0f;
					CustomTweenEggFloat(targetIndex2, target, field, config, value2, sequence3);
				}
				continue;
			}
			ArgumentNullException ex = new ArgumentNullException("name");
			throw ex;
		}
		throw new NullReferenceException();
	}

	private static Tween CustomTweenInt(int targetIndex, Action<object, object> setter, Func<object, object> getter, object target, object value, TweenConfig config)
	{
		//IL_002c: Expected O, but got I
		//IL_0078: Expected O, but got I
		//IL_008a: Expected I4, but got O
		//IL_00af: Expected O, but got I
		//IL_0171: Expected O, but got I
		_003C_003Ec__DisplayClass50_0 obj = new _003C_003Ec__DisplayClass50_0();
		obj.getter = getter;
		obj.target = target;
		obj.setter = setter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ stack_30+D8]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ stack_30+D8]");
		object obj3;
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v428 @ rcx_v11+18] (should have been resolved before IL gen)");
			object obj4 = default(object);
			obj3 = obj4;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ stack_30+18]");
			obj3 = 0;
		}
		DOGetter<int> getter2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003B10");
		DOSetter<int> dOSetter = null;
		((_003C_003Ec__DisplayClass50_0)(object)dOSetter)._003CCustomTweenInt_003Eb__1((int)obj);
		float duration = (float)obj3 * 0.001f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEB8]");
		object obj5 = 0;
		object obj7 = default(object);
		object obj6 = obj7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rcx_v18+40]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v9+40]");
		if (num == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ stack_28+10]");
			TweenerCore<int, int, NoOptions> tweenerCore = DOTween.To(getter2, dOSetter, 0, duration);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<System.Int32, System.Int32, DG.Tweening.Plugins.Options.NoOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ stack_30+20]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ stack_30+20]");
					object obj8 = (nint)0 + (nint)(-32);
					if ((nint)obj8 <= 3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
					}
					_ = 0;
				}
			}
			return tweenerCore;
		}
		return (Tween)(object)new InvalidCastException();
	}

	private static Tween CustomTweenFloat(int targetIndex, Action<object, object> setter, Func<object, object> getter, object target, object value, TweenConfig config)
	{
		//IL_002c: Expected O, but got I
		//IL_0078: Expected O, but got I
		//IL_00af: Expected O, but got I
		//IL_0108: Expected F4, but got I
		//IL_0171: Expected O, but got I
		_003C_003Ec__DisplayClass51_0 obj = new _003C_003Ec__DisplayClass51_0();
		obj.getter = getter;
		obj.target = target;
		obj.setter = setter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ stack_30+D8]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ stack_30+D8]");
		object obj3;
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v430 @ rcx_v11+18] (should have been resolved before IL gen)");
			object obj4 = default(object);
			obj3 = obj4;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ stack_30+18]");
			obj3 = 0;
		}
		DOGetter<float> getter2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float x = default(float);
		((_003C_003Ec__DisplayClass51_0)(object)dOSetter)._003CCustomTweenFloat_003Eb__1(x);
		float duration = (float)obj3 * 0.001f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEE8]");
		object obj5 = 0;
		object obj7 = default(object);
		object obj6 = obj7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rcx_v18+40]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v9+40]");
		if (num == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v476 @ stack_28+10]");
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter2, dOSetter, 0f, duration);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ stack_30+20]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ stack_30+20]");
					object obj8 = (nint)0 + (nint)(-32);
					if ((nint)obj8 <= 3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
					}
					_ = 0;
				}
			}
			return tweenerCore;
		}
		return (Tween)(object)new InvalidCastException();
	}

	private static Tween CustomTweenDouble(int targetIndex, Action<object, object> setter, Func<object, object> getter, object target, object value, TweenConfig config)
	{
		//IL_002c: Expected O, but got I
		//IL_0078: Expected O, but got I
		//IL_00af: Expected O, but got I
		//IL_0108: Expected F8, but got I
		//IL_0171: Expected O, but got I
		_003C_003Ec__DisplayClass52_0 obj = new _003C_003Ec__DisplayClass52_0();
		obj.getter = getter;
		obj.target = target;
		obj.setter = setter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ stack_30+D8]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ stack_30+D8]");
		object obj3;
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v430 @ rcx_v11+18] (should have been resolved before IL gen)");
			object obj4 = default(object);
			obj3 = obj4;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ stack_30+18]");
			obj3 = 0;
		}
		DOGetter<double> getter2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<double> dOSetter = null;
		double x = default(double);
		((_003C_003Ec__DisplayClass52_0)(object)dOSetter)._003CCustomTweenDouble_003Eb__1(x);
		float duration = (float)obj3 * 0.001f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEF0]");
		object obj5 = 0;
		object obj7 = default(object);
		object obj6 = obj7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rcx_v18+40]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v9+40]");
		if (num == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v476 @ stack_28+10]");
			TweenerCore<double, double, NoOptions> tweenerCore = DOTween.To(getter2, dOSetter, 0.0, duration);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<System.Double, System.Double, DG.Tweening.Plugins.Options.NoOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ stack_30+20]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ stack_30+20]");
					object obj8 = (nint)0 + (nint)(-32);
					if ((nint)obj8 <= 3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
					}
					_ = 0;
				}
			}
			return tweenerCore;
		}
		return (Tween)(object)new InvalidCastException();
	}

	private static void CustomTweenEggFloat(int targetIndex, object target, FieldInfo field, TweenConfig config, EggFloat value, Sequence sequence)
	{
		//IL_0046: Expected F4, but got O
		//IL_0081: Expected I, but got O
		//IL_00c0: Expected I, but got O
		//IL_00d0: Expected O, but got I
		//IL_010c: Expected O, but got I
		//IL_0154: Expected I, but got O
		//IL_016c: Expected O, but got I
		//IL_01a5: Expected O, but got I
		//IL_0224: Expected F4, but got I
		//IL_02e9: Expected F4, but got I
		//IL_02f2: Expected O, but got I4
		//IL_031f: Expected F4, but got I4
		//IL_0328: Expected O, but got I4
		//IL_0375: Expected F4, but got I
		//IL_0287: Expected O, but got I4
		//IL_03d8: Expected O, but got I4
		_003C_003Ec__DisplayClass53_0 obj = new _003C_003Ec__DisplayClass53_0();
		Func<int, float> staggerDuration = config.staggerDuration;
		float num;
		if (config.staggerDuration != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v87 @ rcx_v9 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			TweenerCore<float, float, FloatOptions> tweenerCore = default(TweenerCore<float, float, FloatOptions>);
			num = (float)tweenerCore;
		}
		else
		{
			num = config.duration;
		}
		float duration = num * 0.001f;
		object value2 = field.GetValue(target);
		nint num2 = (nint)typeof(EggFloat);
		if (value2 == null)
		{
			obj.eggNum = null;
			TweenConfig tweenConfig = config;
			goto IL_01d7;
		}
		nint num3 = (nint)value2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rdx_v6 (Il2CppClass<VampireSurvivors.Framework.NumberTypes.EggFloat>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ r9_v11 (Il2CppClass<System.Object>)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rdx_v6 (Il2CppClass<VampireSurvivors.Framework.NumberTypes.EggFloat>)+130]");
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ r9_v11 (Il2CppClass<System.Object>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v48+FFFFFFF8+v267 @ rax_v47*8]");
			if (0 == (nint)typeof(EggFloat))
			{
				obj.eggNum = (EggFloat)value2;
				nint num5 = (nint)typeof(EggFloat);
				TweenConfig tweenConfig = (TweenConfig)value2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdx_v29 (Il2CppClass<VampireSurvivors.Framework.NumberTypes.EggFloat>)+130]");
				object obj4 = 0;
				Func<int, float> staggerAlpha = tweenConfig.staggerAlpha;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdx_v29 (Il2CppClass<VampireSurvivors.Framework.NumberTypes.EggFloat>)+130]");
				if ((nint)staggerAlpha >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r9_v4 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v50+FFFFFFF8+v195 @ rax_v49*8]");
					if (0 == (nint)typeof(EggFloat))
					{
						goto IL_01d7;
					}
				}
				throw new InvalidCastException();
			}
		}
		throw new InvalidCastException();
		IL_01d7:
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float x = default(float);
		((_003C_003Ec__DisplayClass53_0)(object)dOSetter)._003CCustomTweenEggFloat_003Eb__1(x);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ stack_28+10]");
		TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter, dOSetter, 0f, duration);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v487 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj6 = config.ease + -32;
				if ((nint)obj6 <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		Sequence sequence2 = default(Sequence);
		bool flag = TweenSettingsExtensions.ValidateAddToSequence(sequence2, (Tween)tweenerCore2, false);
		bool flag2 = !flag;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ stack_28+10]");
		float num6 = 0f;
		object obj7 = 0;
		if (!flag2)
		{
			Sequence sequence3 = Sequence.DoInsert(sequence2, (Tween)tweenerCore2, 0f);
			num6 = 0f;
			obj7 = 0;
		}
		DOGetter<float> getter2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter2 = null;
		((_003C_003Ec__DisplayClass53_0)(object)dOSetter2)._003CCustomTweenEggFloat_003Eb__3(x);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ stack_28+14]");
		TweenerCore<float, float, FloatOptions> tweenerCore3 = DOTween.To(getter2, dOSetter2, 0f, duration);
		if (tweenerCore3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ rax_v28 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj8 = config.ease + -32;
				if ((nint)obj8 <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence2, (Tween)tweenerCore3, false))
		{
			Sequence sequence4 = Sequence.DoInsert(sequence2, (Tween)tweenerCore3, 0f);
		}
	}

	private static void CustomTweenEggDouble(int targetIndex, object target, FieldInfo field, TweenConfig config, EggDouble value, Sequence sequence)
	{
		//IL_0046: Expected F4, but got O
		//IL_0081: Expected I, but got O
		//IL_00c0: Expected I, but got O
		//IL_00d0: Expected O, but got I
		//IL_010c: Expected O, but got I
		//IL_0154: Expected I, but got O
		//IL_016c: Expected O, but got I
		//IL_01a5: Expected O, but got I
		//IL_0224: Expected F8, but got I
		//IL_02e9: Expected F4, but got I
		//IL_02f2: Expected O, but got I4
		//IL_031f: Expected F4, but got I4
		//IL_0328: Expected O, but got I4
		//IL_0375: Expected F8, but got I
		//IL_0287: Expected O, but got I4
		//IL_03d8: Expected O, but got I4
		_003C_003Ec__DisplayClass54_0 obj = new _003C_003Ec__DisplayClass54_0();
		Func<int, float> staggerDuration = config.staggerDuration;
		float num;
		if (config.staggerDuration != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v87 @ rcx_v9 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			TweenerCore<double, double, NoOptions> tweenerCore = default(TweenerCore<double, double, NoOptions>);
			num = (float)tweenerCore;
		}
		else
		{
			num = config.duration;
		}
		float duration = num * 0.001f;
		object value2 = field.GetValue(target);
		nint num2 = (nint)typeof(EggDouble);
		if (value2 == null)
		{
			obj.eggNum = null;
			TweenConfig tweenConfig = config;
			goto IL_01d7;
		}
		nint num3 = (nint)value2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rdx_v6 (Il2CppClass<VampireSurvivors.Framework.NumberTypes.EggDouble>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ r9_v11 (Il2CppClass<System.Object>)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rdx_v6 (Il2CppClass<VampireSurvivors.Framework.NumberTypes.EggDouble>)+130]");
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ r9_v11 (Il2CppClass<System.Object>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v48+FFFFFFF8+v267 @ rax_v47*8]");
			if (0 == (nint)typeof(EggDouble))
			{
				obj.eggNum = (EggDouble)value2;
				nint num5 = (nint)typeof(EggDouble);
				TweenConfig tweenConfig = (TweenConfig)value2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdx_v29 (Il2CppClass<VampireSurvivors.Framework.NumberTypes.EggDouble>)+130]");
				object obj4 = 0;
				Func<int, float> staggerAlpha = tweenConfig.staggerAlpha;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdx_v29 (Il2CppClass<VampireSurvivors.Framework.NumberTypes.EggDouble>)+130]");
				if ((nint)staggerAlpha >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r9_v4 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v50+FFFFFFF8+v195 @ rax_v49*8]");
					if (0 == (nint)typeof(EggDouble))
					{
						goto IL_01d7;
					}
				}
				throw new InvalidCastException();
			}
		}
		throw new InvalidCastException();
		IL_01d7:
		DOGetter<double> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<double> dOSetter = null;
		double x = default(double);
		((_003C_003Ec__DisplayClass54_0)(object)dOSetter)._003CCustomTweenEggDouble_003Eb__1(x);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ stack_28+10]");
		TweenerCore<double, double, NoOptions> tweenerCore2 = DOTween.To(getter, dOSetter, 0.0, duration);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v487 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<System.Double, System.Double, DG.Tweening.Plugins.Options.NoOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj6 = config.ease + -32;
				if ((nint)obj6 <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		Sequence sequence2 = default(Sequence);
		bool flag = TweenSettingsExtensions.ValidateAddToSequence(sequence2, (Tween)tweenerCore2, false);
		bool flag2 = !flag;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ stack_28+10]");
		float num6 = 0f;
		object obj7 = 0;
		if (!flag2)
		{
			Sequence sequence3 = Sequence.DoInsert(sequence2, (Tween)tweenerCore2, 0f);
			num6 = 0f;
			obj7 = 0;
		}
		DOGetter<double> getter2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<double> dOSetter2 = null;
		((_003C_003Ec__DisplayClass54_0)(object)dOSetter2)._003CCustomTweenEggDouble_003Eb__3(x);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ stack_28+18]");
		TweenerCore<double, double, NoOptions> tweenerCore3 = DOTween.To(getter2, dOSetter2, 0.0, duration);
		if (tweenerCore3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ rax_v28 (DG.Tweening.Core.TweenerCore`3<System.Double, System.Double, DG.Tweening.Plugins.Options.NoOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj8 = config.ease + -32;
				if ((nint)obj8 <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence2, (Tween)tweenerCore3, false))
		{
			Sequence sequence4 = Sequence.DoInsert(sequence2, (Tween)tweenerCore3, 0f);
		}
	}

	private static void CustomTweenEggFloat(int targetIndex, object target, PropertyInfo field, TweenConfig config, EggFloat value, Sequence sequence)
	{
		//IL_0046: Expected F4, but got O
		//IL_0065: Expected I, but got O
		//IL_009a: Expected I, but got O
		//IL_00d1: Expected I, but got O
		//IL_00e1: Expected O, but got I
		//IL_011d: Expected O, but got I
		//IL_0165: Expected I, but got O
		//IL_016d: Expected I, but got O
		//IL_017d: Expected O, but got I
		//IL_01b9: Expected O, but got I
		//IL_0238: Expected F4, but got I
		//IL_02fd: Expected F4, but got I
		//IL_0306: Expected O, but got I4
		//IL_0333: Expected F4, but got I4
		//IL_033c: Expected O, but got I4
		//IL_0389: Expected F4, but got I
		//IL_029b: Expected O, but got I4
		//IL_03ec: Expected O, but got I4
		_003C_003Ec__DisplayClass55_0 obj = new _003C_003Ec__DisplayClass55_0();
		Func<int, float> staggerDuration = config.staggerDuration;
		float num;
		if (config.staggerDuration != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v87 @ rcx_v9 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			TweenerCore<float, float, FloatOptions> tweenerCore = default(TweenerCore<float, float, FloatOptions>);
			num = (float)tweenerCore;
		}
		else
		{
			num = config.duration;
		}
		float duration = num * 0.001f;
		nint num2 = (nint)field;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ r9_v4 (Il2CppClass<System.Reflection.PropertyInfo>)+300]");
		nint num3 = 0;
		object value2 = field.GetValue(target, null);
		nint num4 = (nint)typeof(EggFloat);
		if (value2 == null)
		{
			obj.eggNum = null;
			goto IL_01eb;
		}
		nint num5 = (nint)value2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rdx_v6 (Il2CppClass<VampireSurvivors.Framework.NumberTypes.EggFloat>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ r9_v13 (Il2CppClass<System.Object>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rdx_v6 (Il2CppClass<VampireSurvivors.Framework.NumberTypes.EggFloat>)+130]");
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ r9_v13 (Il2CppClass<System.Object>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rax_v48+FFFFFFF8+v268 @ rax_v47*8]");
			if (0 == (nint)typeof(EggFloat))
			{
				obj.eggNum = (EggFloat)value2;
				nint num7 = (nint)typeof(EggFloat);
				num3 = (nint)value2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdx_v29 (Il2CppClass<VampireSurvivors.Framework.NumberTypes.EggFloat>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ r9_v6 (Il2CppClass<System.Object>)+130]");
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdx_v29 (Il2CppClass<VampireSurvivors.Framework.NumberTypes.EggFloat>)+130]");
				if (num8 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ r9_v6 (Il2CppClass<System.Object>)+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rax_v50+FFFFFFF8+v196 @ rax_v49*8]");
					if (0 == (nint)typeof(EggFloat))
					{
						goto IL_01eb;
					}
				}
				throw new InvalidCastException();
			}
		}
		throw new InvalidCastException();
		IL_01eb:
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float x = default(float);
		((_003C_003Ec__DisplayClass55_0)(object)dOSetter)._003CCustomTweenEggFloat_003Eb__1(x);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ stack_28+10]");
		TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter, dOSetter, 0f, duration);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj6 = config.ease + -32;
				if ((nint)obj6 <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		Sequence sequence2 = default(Sequence);
		bool flag = TweenSettingsExtensions.ValidateAddToSequence(sequence2, (Tween)tweenerCore2, false);
		bool flag2 = !flag;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ stack_28+10]");
		float num9 = 0f;
		object obj7 = 0;
		if (!flag2)
		{
			Sequence sequence3 = Sequence.DoInsert(sequence2, (Tween)tweenerCore2, 0f);
			num9 = 0f;
			obj7 = 0;
		}
		DOGetter<float> getter2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter2 = null;
		((_003C_003Ec__DisplayClass55_0)(object)dOSetter2)._003CCustomTweenEggFloat_003Eb__3(x);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ stack_28+14]");
		TweenerCore<float, float, FloatOptions> tweenerCore3 = DOTween.To(getter2, dOSetter2, 0f, duration);
		if (tweenerCore3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rax_v28 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj8 = config.ease + -32;
				if ((nint)obj8 <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence2, (Tween)tweenerCore3, false))
		{
			Sequence sequence4 = Sequence.DoInsert(sequence2, (Tween)tweenerCore3, 0f);
		}
	}

	private static void CustomTweenEggDouble(int targetIndex, object target, PropertyInfo field, TweenConfig config, EggDouble value, Sequence sequence)
	{
		//IL_0046: Expected F4, but got O
		//IL_0065: Expected I, but got O
		//IL_009a: Expected I, but got O
		//IL_00d1: Expected I, but got O
		//IL_00e1: Expected O, but got I
		//IL_011d: Expected O, but got I
		//IL_0165: Expected I, but got O
		//IL_016d: Expected I, but got O
		//IL_017d: Expected O, but got I
		//IL_01b9: Expected O, but got I
		//IL_0238: Expected F8, but got I
		//IL_02fd: Expected F4, but got I
		//IL_0306: Expected O, but got I4
		//IL_0333: Expected F4, but got I4
		//IL_033c: Expected O, but got I4
		//IL_0389: Expected F8, but got I
		//IL_029b: Expected O, but got I4
		//IL_03ec: Expected O, but got I4
		_003C_003Ec__DisplayClass56_0 obj = new _003C_003Ec__DisplayClass56_0();
		Func<int, float> staggerDuration = config.staggerDuration;
		float num;
		if (config.staggerDuration != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v87 @ rcx_v9 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			TweenerCore<double, double, NoOptions> tweenerCore = default(TweenerCore<double, double, NoOptions>);
			num = (float)tweenerCore;
		}
		else
		{
			num = config.duration;
		}
		float duration = num * 0.001f;
		nint num2 = (nint)field;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ r9_v4 (Il2CppClass<System.Reflection.PropertyInfo>)+300]");
		nint num3 = 0;
		object value2 = field.GetValue(target, null);
		nint num4 = (nint)typeof(EggDouble);
		if (value2 == null)
		{
			obj.eggNum = null;
			goto IL_01eb;
		}
		nint num5 = (nint)value2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rdx_v6 (Il2CppClass<VampireSurvivors.Framework.NumberTypes.EggDouble>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ r9_v13 (Il2CppClass<System.Object>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rdx_v6 (Il2CppClass<VampireSurvivors.Framework.NumberTypes.EggDouble>)+130]");
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ r9_v13 (Il2CppClass<System.Object>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rax_v48+FFFFFFF8+v268 @ rax_v47*8]");
			if (0 == (nint)typeof(EggDouble))
			{
				obj.eggNum = (EggDouble)value2;
				nint num7 = (nint)typeof(EggDouble);
				num3 = (nint)value2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdx_v29 (Il2CppClass<VampireSurvivors.Framework.NumberTypes.EggDouble>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ r9_v6 (Il2CppClass<System.Object>)+130]");
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdx_v29 (Il2CppClass<VampireSurvivors.Framework.NumberTypes.EggDouble>)+130]");
				if (num8 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ r9_v6 (Il2CppClass<System.Object>)+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rax_v50+FFFFFFF8+v196 @ rax_v49*8]");
					if (0 == (nint)typeof(EggDouble))
					{
						goto IL_01eb;
					}
				}
				throw new InvalidCastException();
			}
		}
		throw new InvalidCastException();
		IL_01eb:
		DOGetter<double> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<double> dOSetter = null;
		double x = default(double);
		((_003C_003Ec__DisplayClass56_0)(object)dOSetter)._003CCustomTweenEggDouble_003Eb__1(x);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ stack_28+10]");
		TweenerCore<double, double, NoOptions> tweenerCore2 = DOTween.To(getter, dOSetter, 0.0, duration);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<System.Double, System.Double, DG.Tweening.Plugins.Options.NoOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj6 = config.ease + -32;
				if ((nint)obj6 <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		Sequence sequence2 = default(Sequence);
		bool flag = TweenSettingsExtensions.ValidateAddToSequence(sequence2, (Tween)tweenerCore2, false);
		bool flag2 = !flag;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ stack_28+10]");
		float num9 = 0f;
		object obj7 = 0;
		if (!flag2)
		{
			Sequence sequence3 = Sequence.DoInsert(sequence2, (Tween)tweenerCore2, 0f);
			num9 = 0f;
			obj7 = 0;
		}
		DOGetter<double> getter2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<double> dOSetter2 = null;
		((_003C_003Ec__DisplayClass56_0)(object)dOSetter2)._003CCustomTweenEggDouble_003Eb__3(x);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ stack_28+18]");
		TweenerCore<double, double, NoOptions> tweenerCore3 = DOTween.To(getter2, dOSetter2, 0.0, duration);
		if (tweenerCore3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rax_v28 (DG.Tweening.Core.TweenerCore`3<System.Double, System.Double, DG.Tweening.Plugins.Options.NoOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj8 = config.ease + -32;
				if ((nint)obj8 <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence2, (Tween)tweenerCore3, false))
		{
			Sequence sequence4 = Sequence.DoInsert(sequence2, (Tween)tweenerCore3, 0f);
		}
	}

	private static void AddBoxedVector2Tweens(int targetIndex, PhaserScene.BoxedVector2 target, TweenConfig config, Sequence sequence)
	{
		//IL_005d: Expected F4, but got O
		//IL_00ba: Expected F4, but got O
		//IL_00f1: Expected F4, but got I
		//IL_0289: Expected F4, but got O
		//IL_02c0: Expected F4, but got I
		//IL_0219: Expected F4, but got I4
		//IL_0180: Expected O, but got I4
		//IL_034f: Expected O, but got I4
		_003C_003Ec__DisplayClass57_0 obj = new _003C_003Ec__DisplayClass57_0();
		obj.target = target;
		Func<int, float> staggerDuration = config.staggerDuration;
		float num;
		TweenerCore<float, float, FloatOptions> tweenerCore = default(TweenerCore<float, float, FloatOptions>);
		if (config.staggerDuration != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v266 @ rcx_v8 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			num = (float)tweenerCore;
		}
		else
		{
			num = config.duration;
		}
		float num2 = num * 0.001f;
		Sequence sequence2;
		if ((object)config.x == null)
		{
			bool flag = config.staggerX == null;
			sequence2 = sequence;
			if (flag)
			{
				goto IL_0226;
			}
		}
		Func<int, float> staggerX = config.staggerX;
		float num3;
		if (config.staggerX != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v224 @ rcx_v34 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			num3 = (float)tweenerCore;
		}
		else
		{
			if ((object)config.x == null)
			{
				goto IL_0456;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+64]");
			num3 = 0f;
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float num4 = default(float);
		((_003C_003Ec__DisplayClass57_0)(object)dOSetter)._003CAddBoxedVector2Tweens_003Eb__1(num4);
		TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter, dOSetter, num3, num2);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v662 @ rax_v41 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj2 = config.ease + -32;
				if ((nint)obj2 <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		bool flag2 = TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore2, false);
		bool flag3 = !flag2;
		sequence2 = null;
		float num5 = num3;
		float num6 = num2;
		if (!flag3)
		{
			Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)tweenerCore2, 0f);
			sequence2 = null;
			num5 = 0f;
			num6 = num2;
		}
		goto IL_0226;
		IL_0456:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		return;
		IL_0226:
		if ((object)config.y == null && config.staggerY == null)
		{
			return;
		}
		Func<int, float> staggerY = config.staggerY;
		float endValue;
		if (config.staggerY != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v225 @ rcx_v14 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			endValue = (float)tweenerCore2;
		}
		else
		{
			if ((object)config.y == null)
			{
				goto IL_0456;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+6C]");
			endValue = 0f;
		}
		DOGetter<float> getter2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter2 = null;
		((_003C_003Ec__DisplayClass57_0)(object)dOSetter2)._003CAddBoxedVector2Tweens_003Eb__3(num4);
		TweenerCore<float, float, FloatOptions> tweenerCore3 = DOTween.To(getter2, dOSetter2, endValue, num2);
		if (tweenerCore3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = config.ease;
				object obj3 = config.ease + -32;
				if ((nint)obj3 <= 3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0C0h]\"");
				}
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore3, false))
		{
			Sequence sequence4 = Sequence.DoInsert(sequence, (Tween)tweenerCore3, 0f);
		}
	}

	private unsafe static void AddUiImageTweens(int targetIndex, Image target, TweenConfig config, Sequence sequence)
	{
		//IL_004e: Expected I4, but got O
		//IL_00ca: Expected I4, but got O
		//IL_02c8: Expected O, but got I
		//IL_00f2: Expected O, but got I
		//IL_0477: Expected O, but got I
		//IL_04b0: Expected O, but got Ref
		//IL_013b: Expected F4, but got I
		//IL_054b: Expected O, but got Ref
		//IL_0345: Expected O, but got I
		//IL_0158: Expected O, but got I
		//IL_01d7: Expected F4, but got I4
		if ((object)config.alpha == null)
		{
			bool flag = config.staggerAlpha == null;
			Sequence sequence2 = sequence;
			bool flag2 = (byte)(int)config != 0;
			if (flag)
			{
				goto IL_01ea;
			}
		}
		float num2 = default(float);
		if ((object)config.tint == null)
		{
			Sequence sequence2;
			bool flag2;
			if ((object)config.alpha == null)
			{
				bool flag3 = config.staggerAlpha == null;
				sequence2 = sequence;
				flag2 = (byte)(int)config != 0;
				if (flag3)
				{
					goto IL_01ea;
				}
			}
			Func<int, float> staggerAlpha = config.staggerAlpha;
			float num;
			if (config.staggerAlpha != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rcx_v30 (System.Func`2<System.Int32, System.Single>)+28]");
				TweenConfig tweenConfig = (TweenConfig)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v220 @ rcx_v30 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
				num = num2;
			}
			else
			{
				if ((object)config.alpha == null)
				{
					goto IL_0401;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+C0]");
				num = 0f;
				TweenConfig tweenConfig = config;
			}
			Func<int, float> staggerDuration = config.staggerDuration;
			if (config.staggerDuration != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v639 @ rcx_v32 (System.Func`2<System.Int32, System.Single>)+28]");
				TweenConfig tweenConfig = (TweenConfig)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v639 @ rcx_v32 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			}
			else
			{
				num2 = config.duration;
			}
			num2 *= 0.001f;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(target, num, num2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
			Tween t = default(Tween);
			bool flag4 = TweenSettingsExtensions.ValidateAddToSequence(sequence, t, false);
			bool flag5 = !flag4;
			float num3 = num;
			float num4 = num2;
			sequence2 = null;
			flag2 = false;
			if (!flag5)
			{
				Sequence sequence3 = Sequence.DoInsert(sequence, t, 0f);
				num3 = num;
				num4 = 0f;
				sequence2 = null;
				flag2 = false;
			}
			goto IL_01ea;
		}
		Func<int, float> staggerAlpha2 = config.staggerAlpha;
		if (config.staggerAlpha != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rcx_v16 (System.Func`2<System.Int32, System.Single>)+28]");
			TweenConfig tweenConfig2 = (TweenConfig)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v221 @ rcx_v16 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
		}
		else
		{
			if ((object)config.alpha == null)
			{
				goto IL_0401;
			}
			TweenConfig tweenConfig2 = config;
		}
		object obj = default(object);
		if ((object)config.tint != null)
		{
			Func<int, float> staggerDuration2 = config.staggerDuration;
			float num5;
			if (config.staggerDuration != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v662 @ rcx_v19 (System.Func`2<System.Int32, System.Single>)+28]");
				TweenConfig tweenConfig2 = (TweenConfig)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v662 @ rcx_v19 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
				num5 = 255f;
			}
			else
			{
				num5 = config.duration;
			}
			float duration = num5 * 0.001f;
			Tweener tweener = DOTweenModuleUI.DOBlendableColor(target, (Color)(&obj), duration);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
			Tween t2 = default(Tween);
			if (TweenSettingsExtensions.ValidateAddToSequence(sequence, t2, false))
			{
				Sequence sequence4 = Sequence.DoInsert(sequence, t2, 0f);
			}
			return;
		}
		goto IL_0401;
		IL_0401:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		return;
		IL_01ea:
		if ((object)config.tint != null)
		{
			Func<int, float> staggerDuration3 = config.staggerDuration;
			float num6;
			if (config.staggerDuration != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ rcx_v7 (System.Func`2<System.Int32, System.Single>)+28]");
				bool flag2 = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v446 @ rcx_v7 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
				num6 = num2;
			}
			else
			{
				num6 = config.duration;
			}
			float duration2 = num6 * 0.001f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+C8]");
			object obj2 = (nint)0 >> 8;
			float num7 = (float)obj2 / 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ r8 (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+C8]");
			float num8 = 0f / 255f;
			Tweener tweener2 = DOTweenModuleUI.DOBlendableColor(target, (Color)(&obj), duration2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
			Tween t3 = default(Tween);
			if (TweenSettingsExtensions.ValidateAddToSequence(sequence, t3, false))
			{
				Sequence sequence5 = Sequence.DoInsert(sequence, t3, 0f);
			}
		}
	}

	static Tweens()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected O, but got Unknown
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected O, but got Unknown
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected O, but got Unknown
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected O, but got Unknown
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected O, but got Unknown
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Expected O, but got Unknown
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Expected O, but got Unknown
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Expected O, but got Unknown
		//IL_03df: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Expected O, but got Unknown
		//IL_0454: Expected O, but got I
		//IL_04d5: Expected O, but got I
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_047f: Expected O, but got Unknown
		//IL_04f3: Expected O, but got I
		//IL_0563: Expected O, but got I
		//IL_0522: Unknown result type (might be due to invalid IL or missing references)
		//IL_0527: Expected O, but got Unknown
		//IL_058e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0593: Expected O, but got Unknown
		Dictionary<Type, Action<int, TweenConfig, Sequence>> dictionary = new Dictionary<Type, Action<int, TweenConfig, Sequence>>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj3 = default(object);
		object key = obj3;
		Action<int, TweenConfig, Sequence> value = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97980");
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert(key, (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj5 = default(object);
		object obj4 = obj5 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj6 = default(object);
		object key2 = obj6;
		Action<int, TweenConfig, Sequence> value2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97980");
		bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key2, (object)value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj8 = default(object);
		object obj7 = obj8 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj9 = default(object);
		object key3 = obj9;
		Action<int, TweenConfig, Sequence> value3 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97980");
		bool flag3 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key3, (object)value3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj11 = default(object);
		object obj10 = obj11 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj12 = default(object);
		object key4 = obj12;
		Action<int, TweenConfig, Sequence> value4 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97980");
		bool flag4 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key4, (object)value4, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj14 = default(object);
		object obj13 = obj14 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj15 = default(object);
		object key5 = obj15;
		Action<int, TweenConfig, Sequence> value5 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97980");
		bool flag5 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key5, (object)value5, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj17 = default(object);
		object obj16 = obj17 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj18 = default(object);
		object key6 = obj18;
		Action<int, TweenConfig, Sequence> value6 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97980");
		bool flag6 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key6, (object)value6, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj20 = default(object);
		object obj19 = obj20 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj21 = default(object);
		object key7 = obj21;
		Action<int, TweenConfig, Sequence> value7 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97980");
		bool flag7 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key7, (object)value7, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj23 = default(object);
		object obj22 = obj23 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj24 = default(object);
		object key8 = obj24;
		Action<int, TweenConfig, Sequence> value8 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97980");
		bool flag8 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key8, (object)value8, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj26 = default(object);
		object obj25 = obj26 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj27 = default(object);
		object key9 = obj27;
		Action<int, TweenConfig, Sequence> value9 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97980");
		bool flag9 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key9, (object)value9, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj29 = default(object);
		object obj28 = obj29 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj30 = default(object);
		object key10 = obj30;
		Action<int, TweenConfig, Sequence> value10 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97980");
		bool flag10 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key10, (object)value10, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj32 = default(object);
		object obj31 = obj32 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj33 = default(object);
		object key11 = obj33;
		Action<int, TweenConfig, Sequence> value11 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97980");
		bool flag11 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key11, (object)value11, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj35 = default(object);
		object obj34 = obj35 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj36 = default(object);
		object key12 = obj36;
		Action<int, TweenConfig, Sequence> value12 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97980");
		bool flag12 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key12, (object)value12, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj38 = default(object);
		object obj37 = obj38 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj39 = default(object);
		object key13 = obj39;
		Action<int, TweenConfig, Sequence> value13 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97980");
		bool flag13 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key13, (object)value13, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj41 = default(object);
		object obj40 = obj41 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj42 = default(object);
		object key14 = obj42;
		Action<int, TweenConfig, Sequence> value14 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97980");
		bool flag14 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key14, (object)value14, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		targetTypeSwitch = dictionary;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag15 = (nint)0 == 0;
		Dictionary<Type, Func<Action<object, object>, Func<object, object>, object, object, TweenConfig, int, Tween>> dictionary2 = new Dictionary<Type, Func<Action<object, object>, Func<object, object>, object, object, TweenConfig, int, Tween>>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEB8]");
		object obj43 = (nint)0 + (nint)32;
		object key15;
		if (!flag15)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj45 = default(object);
			object obj44 = obj45 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj46 = default(object);
			key15 = obj46;
		}
		else
		{
			key15 = null;
		}
		Func<Action<object, object>, Func<object, object>, object, object, TweenConfig, int, Tween> value15 = (Action<object, object> setter, Func<object, object> getter, object target, object value18, TweenConfig config, int i) =>
		{
			int targetIndex = default(int);
			TweenConfig config2 = default(TweenConfig);
			return CustomTweenInt(targetIndex, setter, getter, target, value18, config2);
		};
		bool flag16 = dictionary2 == null;
		bool flag17 = ((Dictionary<object, object>)(object)dictionary2).TryInsert(key15, (object)value15, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEE8]");
		object obj47 = (nint)0 + (nint)32;
		object key16;
		if (!flag16)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF50]");
			object obj48 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rcx_v145+E4]");
			flag16 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj50 = default(object);
			object obj49 = obj50 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj51 = default(object);
			key16 = obj51;
		}
		else
		{
			key16 = null;
		}
		Func<Action<object, object>, Func<object, object>, object, object, TweenConfig, int, Tween> value16 = (Action<object, object> setter, Func<object, object> getter, object target, object value18, TweenConfig config, int i) =>
		{
			int targetIndex = default(int);
			TweenConfig config2 = default(TweenConfig);
			return CustomTweenFloat(targetIndex, setter, getter, target, value18, config2);
		};
		bool flag18 = ((Dictionary<object, object>)(object)dictionary2).TryInsert(key16, (object)value16, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEF0]");
		object obj52 = (nint)0 + (nint)32;
		object key17 = null;
		if (!flag16)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj54 = default(object);
			object obj53 = obj54 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj55 = default(object);
			key17 = obj55;
		}
		Func<Action<object, object>, Func<object, object>, object, object, TweenConfig, int, Tween> value17 = (Action<object, object> setter, Func<object, object> getter, object target, object value18, TweenConfig config, int i) =>
		{
			int targetIndex = default(int);
			TweenConfig config2 = default(TweenConfig);
			return CustomTweenDouble(targetIndex, setter, getter, target, value18, config2);
		};
		bool flag19 = ((Dictionary<object, object>)(object)dictionary2).TryInsert(key17, (object)value17, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		fieldTypeSwitch = dictionary2;
		Dictionary<(Type, string), CachedCustomField> dictionary3 = new Dictionary<(Type, string), CachedCustomField>();
		customFieldCache = dictionary3;
	}
}
