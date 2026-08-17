using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class EME_CharacterControllerDiva : EME_CharacterControllerShowstopper
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<KeyValuePair<CharacterType, List<CharacterData>>, bool> _003C_003E9__39_0;

		public static Predicate<Equipment> _003C_003E9__43_0;

		public static Predicate<Equipment> _003C_003E9__43_1;

		public static Predicate<Equipment> _003C_003E9__67_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CMakeLevelOne_003Eb__39_0(KeyValuePair<CharacterType, List<CharacterData>> characterData)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Expected O, but got Unknown
			object obj = characterData - 151;
			return obj == null;
		}

		internal bool _003CLevelUp_003Eb__43_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 415;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CLevelUp_003Eb__43_1(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 416;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CTriggerChargeSkill_003Eb__67_1(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 416;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass39_0
	{
		public EME_CharacterControllerDiva _003C_003E4__this;

		public Skin divaSkin;

		internal void _003CMakeLevelOne_003Eb__1(bool _)
		{
			//IL_010e: Expected O, but got I
			//IL_0168: Expected O, but got I
			//IL_07fa: Expected O, but got I
			//IL_01d2: Expected O, but got I
			//IL_0822: Expected O, but got I
			//IL_023c: Expected O, but got I
			//IL_084a: Expected O, but got I
			//IL_02a6: Expected O, but got I
			//IL_0872: Expected O, but got I
			//IL_0310: Expected O, but got I
			//IL_089a: Expected O, but got I
			//IL_037a: Expected O, but got I
			//IL_08c2: Expected O, but got I
			//IL_03e4: Expected O, but got I
			//IL_08ea: Expected O, but got I
			//IL_044e: Expected O, but got I
			//IL_04bb: Expected O, but got I
			//IL_0515: Expected O, but got I
			//IL_0921: Expected O, but got I
			//IL_057f: Expected O, but got I
			//IL_0949: Expected O, but got I
			//IL_05e9: Expected O, but got I
			//IL_0971: Expected O, but got I
			//IL_0653: Expected O, but got I
			//IL_0999: Expected O, but got I
			//IL_06bd: Expected O, but got I
			//IL_09c1: Expected O, but got I
			//IL_0727: Expected O, but got I
			//IL_09e9: Expected O, but got I
			//IL_0791: Expected O, but got I
			Skin skin = divaSkin;
			_003C_003E4__this.AddScatteredPetalsAnimStage("EME_divano5_scatteredpetals_upwardslash", skin._003CtextureName_003Ek__BackingField, 2);
			Skin skin2 = divaSkin;
			_003C_003E4__this.AddScatteredPetalsAnimStage("EME_divano5_scatteredpetals_midairpose", skin2._003CtextureName_003Ek__BackingField, 2);
			Skin skin3 = divaSkin;
			_003C_003E4__this.AddScatteredPetalsAnimStage("EME_divano5_scatteredpetals_downwardslash", skin3._003CtextureName_003Ek__BackingField, 2);
			Skin skin4 = divaSkin;
			_003C_003E4__this.AddScatteredPetalsAnimStage("EME_divano5_scatteredpetals_land", skin4._003CtextureName_003Ek__BackingField, 2);
			Skin skin5 = divaSkin;
			_003C_003E4__this.AddScatteredPetalsAnimStage("EME_divano5_sword", skin5._003CtextureName_003Ek__BackingField, 5);
			List<int> list = new List<int>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			nint num16 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rdx_v9+18]");
			if (num >= 0)
			{
				list.AddWithResize(1);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj2 = (nint)0 + (nint)1;
				int num17 = 1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			nint num18 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v11+18]");
			if (num2 >= 0)
			{
				list.AddWithResize(2);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj4 = (nint)0 + (nint)1;
				int num19 = 2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			nint num20 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdx_v13+18]");
			if (num3 >= 0)
			{
				list.AddWithResize(3);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj6 = (nint)0 + (nint)1;
				int num21 = 3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			nint num22 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v15+18]");
			if (num4 >= 0)
			{
				list.AddWithResize(3);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj8 = (nint)0 + (nint)1;
				int num23 = 3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			nint num24 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdx_v17+18]");
			if (num5 >= 0)
			{
				list.AddWithResize(5);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj10 = (nint)0 + (nint)1;
				int num25 = 5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			nint num26 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdx_v19+18]");
			if (num6 >= 0)
			{
				list.AddWithResize(5);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj12 = (nint)0 + (nint)1;
				int num27 = 5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			nint num28 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdx_v21+18]");
			if (num7 >= 0)
			{
				list.AddWithResize(6);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj14 = (nint)0 + (nint)1;
				int num29 = 6;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			nint num30 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v23+18]");
			if (num8 >= 0)
			{
				list.AddWithResize(1);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj16 = (nint)0 + (nint)1;
				int num31 = 1;
			}
			Skin skin6 = divaSkin;
			int fps = default(int);
			_003C_003E4__this.AddCustomWalkAnim("EME_divano5_hop", skin6._003CtextureName_003Ek__BackingField, list, fps);
			List<int> list2 = new List<int>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			nint num32 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdx_v27+18]");
			if (num9 >= 0)
			{
				list2.AddWithResize(1);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj18 = (nint)0 + (nint)1;
				int num33 = 1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			nint num34 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v29+18]");
			if (num10 >= 0)
			{
				list2.AddWithResize(2);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj20 = (nint)0 + (nint)1;
				int num35 = 2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			nint num36 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v31+18]");
			if (num11 >= 0)
			{
				list2.AddWithResize(3);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj22 = (nint)0 + (nint)1;
				int num37 = 3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			nint num38 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj23 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v33+18]");
			if (num12 >= 0)
			{
				list2.AddWithResize(4);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj24 = (nint)0 + (nint)1;
				int num39 = 4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			nint num40 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v35+18]");
			if (num13 >= 0)
			{
				list2.AddWithResize(3);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj26 = (nint)0 + (nint)1;
				int num41 = 3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			nint num42 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj27 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ r8_v39+18]");
			if (num14 >= 0)
			{
				list2.AddWithResize(2);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj28 = (nint)0 + (nint)1;
				int num43 = 2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			nint num44 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj29 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r8_v41+18]");
			if (num15 >= 0)
			{
				list2.AddWithResize(1);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ rax_v25 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj30 = (nint)0 + (nint)1;
				int num45 = 1;
			}
			Skin skin7 = divaSkin;
			_003C_003E4__this.AddCustomWalkAnim("EME_divano5_splits", skin7._003CtextureName_003Ek__BackingField, list2, fps);
		}

		internal void _003CMakeLevelOne_003Eb__2()
		{
			EME_CharacterControllerDiva eME_CharacterControllerDiva = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5ECD]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (eME_CharacterControllerDiva._isUsingDivaKatanaSkin)
			{
				((CharacterController)eME_CharacterControllerDiva)._isAnimForced = true;
				eME_CharacterControllerDiva._currentAnimation = CharAnimationType.special;
				SpriteAnimation spriteAnimation = eME_CharacterControllerDiva._spriteAnimation;
				((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
				eME_CharacterControllerDiva._spriteAnimation.Play("EME_divano5_scatteredpetals_midairpose", eME_CharacterControllerDiva._scatteredPetalsFps);
			}
		}

		internal void _003CMakeLevelOne_003Eb__3()
		{
			EME_CharacterControllerDiva eME_CharacterControllerDiva = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5ECD]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (eME_CharacterControllerDiva._isUsingDivaKatanaSkin)
			{
				((CharacterController)eME_CharacterControllerDiva)._isAnimForced = true;
				eME_CharacterControllerDiva._currentAnimation = CharAnimationType.special;
				SpriteAnimation spriteAnimation = eME_CharacterControllerDiva._spriteAnimation;
				((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
				eME_CharacterControllerDiva._spriteAnimation.Play("EME_divano5_scatteredpetals_land", eME_CharacterControllerDiva._scatteredPetalsFps);
			}
		}

		internal void _003CMakeLevelOne_003Eb__4()
		{
			_003C_003E4__this.ReturnToNormalWalkAnim();
		}

		internal void _003CMakeLevelOne_003Eb__5()
		{
			_003C_003E4__this.ReturnToNormalWalkAnim();
		}
	}

	private float _glPower;

	private float _glArea;

	private float _glSpeed;

	private float _glDuration;

	private float _glCooldown;

	private float _glRecovery;

	private float _timeSinceLastAltWalk;

	private float _timeUntilNextAltWalk;

	private float _minTimeBetweenAltWalk;

	private float _maxTimeBetweenAltWalk;

	private SpriteAnimation _scatteredPetalsSlashUp;

	private SpriteAnimation _scatteredPetalsMidAir;

	private SpriteAnimation _scatteredPetalsSlashDown;

	private SpriteAnimation _scatteredPetalsLand;

	private SpriteAnimation _scatteredPetalsGroundedSlash;

	private bool _isUsingDivaKatanaSkin;

	private const string WalkAnimName = "walk";

	private const string AltWalk1AnimName = "EME_divano5_hop";

	private const string AltWalk2AnimName = "EME_divano5_splits";

	private const string UpSlashAnimName = "EME_divano5_scatteredpetals_upwardslash";

	private const string MidAirAnimName = "EME_divano5_scatteredpetals_midairpose";

	private const string DownSlashName = "EME_divano5_scatteredpetals_downwardslash";

	private const string LandAnimName = "EME_divano5_scatteredpetals_land";

	private const string GroundSlashAnimName = "EME_divano5_sword";

	private bool HasHiddenRave;

	private bool HasTechniqueBonuses;

	private bool HasBallisticMissile;

	private bool HasBigMissile;

	private List<WeaponType> missiles;

	private Weapon _HiddenWeapon;

	private int _scatteredPetalsFps;

	private int _walkFps;

	private int _altWalkFps;

	private float RingLevelUpEveyXLevels;

	private Image _ChargeBar;

	private Image _ChargeBarFill;

	private bool _isCharging;

	private float _chargeTime;

	private float _maxChargeTimeMS;

	private float _defaultChargeTimeMS;

	private Color ChargeColor;

	private Color ReadyColor;

	private Timer nextTriggeredSkillTimer;

	public override float PPower()
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + _glPower;
		float num = eggFloat2._eggVal + eggFloat2._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018764E226h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				return num;
			}
		}
		return 3.4028235E+38f;
	}

	public override float PArea()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CArea_003Ek__BackingField;
		float num = eggFloat._eggVal + eggFloat._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018764E2C0h\"");
				if (num == -1f / 0f)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					object obj3 = -3.4028235E+38f & 0;
					return (float)obj3 + _glArea;
				}
				goto IL_00fc;
			}
		}
		num = 3.4028235E+38f;
		goto IL_00fc;
		IL_00fc:
		float num2 = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj4 = num2 & 0;
		return (float)obj4 + _glArea;
	}

	public override float PSpeed()
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CSpeed_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + _glSpeed;
		float num = eggFloat2._eggVal + eggFloat2._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018764E3B6h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				return num;
			}
		}
		return 3.4028235E+38f;
	}

	public override float PDuration()
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CDuration_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + _glDuration;
		float num = eggFloat2._eggVal + eggFloat2._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018764E4B6h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				return num;
			}
		}
		return 3.4028235E+38f;
	}

	public override float PCooldown()
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val - _glCooldown;
		float num = eggFloat2._eggVal + eggFloat2._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018764E5B6h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				return num;
			}
		}
		return 3.4028235E+38f;
	}

	public override float PRegen()
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CRegen_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + _glRecovery;
		float num = eggFloat2._eggVal + eggFloat2._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018764E6B6h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				return num;
			}
		}
		return 3.4028235E+38f;
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		//IL_0230: Expected I4, but got O
		_003C_003Ec__DisplayClass39_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass39_0();
		CS_0024_003C_003E8__locals8._003C_003E4__this = this;
		((CharacterController)this).MakeLevelOne(false);
		CharacterData currentCharacterData = _currentCharacterData;
		base._isMorphed = false;
		base._mightBonus = 0f;
		base._luckBonus = 0f;
		if (currentCharacterData._003CcurrentSkin_003Ek__BackingField != SkinType.SKIN_EME_D_TANK)
		{
			if (currentCharacterData._003CcurrentSkin_003Ek__BackingField != SkinType.SKIN_EME_D_SHAN)
			{
				GameObject gameObject = _ChargeBar.gameObject;
				gameObject.SetActive(value: false);
				GameObject gameObject2 = _ChargeBarFill.gameObject;
				gameObject2.SetActive(value: false);
				CharacterData currentCharacterData2 = _currentCharacterData;
				if (currentCharacterData2._003CcurrentSkin_003Ek__BackingField != SkinType.SKIN_EME_D_MOVE)
				{
					if (currentCharacterData2._003CcurrentSkin_003Ek__BackingField != SkinType.SKIN_EME_D_PARA)
					{
						if (currentCharacterData2._003CcurrentSkin_003Ek__BackingField == SkinType.SKIN_EME_D_KATANA)
						{
							HasTechniqueBonuses = true;
						}
						SkinType skinTypeForCharacter = _playerOptions.GetSkinTypeForCharacter(CharacterType.EME_MECHKATANA);
						if (skinTypeForCharacter != SkinType.SKIN_EME_D_KATANA)
						{
							return;
						}
						_isUsingDivaKatanaSkin = true;
						GameManager core = GM.Core;
						Dictionary<CharacterType, List<CharacterData>> convertedDlcCharacterData = core._dataManager.GetConvertedDlcCharacterData(DlcType.Emeralds);
						Func<KeyValuePair<CharacterType, List<CharacterData>>, bool> func = _003C_003Ec._003C_003E9__39_0;
						if (_003C_003Ec._003C_003E9__39_0 == null)
						{
							func = (_003C_003Ec._003C_003E9__39_0 = delegate(KeyValuePair<CharacterType, List<CharacterData>> characterData)
							{
								//IL_000e: Unknown result type (might be due to invalid IL or missing references)
								//IL_0013: Expected O, but got Unknown
								object obj = characterData - 151;
								return obj == null;
							});
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182FF4130");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96630");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Skin divaSkin = default(Skin);
						CS_0024_003C_003E8__locals8.divaSkin = divaSkin;
						Skin divaSkin2 = CS_0024_003C_003E8__locals8.divaSkin;
						Action<bool> action = null;
						((_003C_003Ec__DisplayClass39_0)(object)action)._003CMakeLevelOne_003Eb__1((byte)(int)CS_0024_003C_003E8__locals8 != 0);
						GameManager core2 = GM.Core;
						string customCacheGroup = default(string);
						CharacterLoader.LoadCharacterTextureAsync(divaSkin2._003CtextureName_003Ek__BackingField, CharacterType.EME_MECHKATANA, action, core2._dataManager, customCacheGroup);
						Action action2 = delegate
						{
							EME_CharacterControllerDiva eME_CharacterControllerDiva = CS_0024_003C_003E8__locals8._003C_003E4__this;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5ECD]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if (eME_CharacterControllerDiva._isUsingDivaKatanaSkin)
							{
								((CharacterController)eME_CharacterControllerDiva)._isAnimForced = true;
								eME_CharacterControllerDiva._currentAnimation = CharAnimationType.special;
								SpriteAnimation spriteAnimation = eME_CharacterControllerDiva._spriteAnimation;
								((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
								eME_CharacterControllerDiva._spriteAnimation.Play("EME_divano5_scatteredpetals_midairpose", eME_CharacterControllerDiva._scatteredPetalsFps);
							}
						};
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186DD0180");
						Action action3 = delegate
						{
							EME_CharacterControllerDiva eME_CharacterControllerDiva = CS_0024_003C_003E8__locals8._003C_003E4__this;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5ECD]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if (eME_CharacterControllerDiva._isUsingDivaKatanaSkin)
							{
								((CharacterController)eME_CharacterControllerDiva)._isAnimForced = true;
								eME_CharacterControllerDiva._currentAnimation = CharAnimationType.special;
								SpriteAnimation spriteAnimation = eME_CharacterControllerDiva._spriteAnimation;
								((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
								eME_CharacterControllerDiva._spriteAnimation.Play("EME_divano5_scatteredpetals_land", eME_CharacterControllerDiva._scatteredPetalsFps);
							}
						};
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186DD0180");
						Action action4 = delegate
						{
							CS_0024_003C_003E8__locals8._003C_003E4__this.ReturnToNormalWalkAnim();
						};
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186DD0180");
						Action action5 = delegate
						{
							CS_0024_003C_003E8__locals8._003C_003E4__this.ReturnToNormalWalkAnim();
						};
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186DD0180");
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD570");
						SetAsFlying();
						HasHiddenRave = true;
					}
				}
				else
				{
					SetAsFlying();
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD570");
				HasBallisticMissile = true;
			}
		}
		else
		{
			HasBigMissile = true;
		}
	}

	private void SetAsFlying()
	{
		GameManager core = GM.Core;
		PhysicsManager physicsManager = core._physicsManager;
		physicsManager._playersWithWallCollisionGroup.remove(this);
	}

	private void LateUpdate()
	{
		if (HasTechniqueBonuses)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,eax\"");
			float glPower = 0f * 0.05f;
			_glPower = glPower;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,eax\"");
			float num = 0f * 0.025f;
			bool flag = !(0.5f > num);
			float glArea = 0.5f;
			if (!flag)
			{
				glArea = num;
			}
			_glArea = glArea;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,eax\"");
			float num2 = 0f * 0.05f;
			bool flag2 = !(1f > num2);
			float glSpeed = 1f;
			if (!flag2)
			{
				glSpeed = num2;
			}
			_glSpeed = glSpeed;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,eax\"");
			float num3 = 0f * 0.05f;
			bool flag3 = !(1f > num3);
			float glDuration = 1f;
			if (!flag3)
			{
				glDuration = num3;
			}
			_glDuration = glDuration;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,eax\"");
			float num4 = 0f * 0.01f;
			bool flag4 = !(0.1f > num4);
			float glCooldown = 0.1f;
			if (!flag4)
			{
				glCooldown = num4;
			}
			_glCooldown = glCooldown;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,eax\"");
			float num5 = 0f * 0.02f;
			bool flag5 = !(1f > num5);
			float glRecovery = 1f;
			if (!flag5)
			{
				glRecovery = num5;
			}
			_glRecovery = glRecovery;
		}
	}

	public override void LevelUp()
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected I4, but got Unknown
		//IL_00bb: Expected O, but got I4
		//IL_00c4: Expected O, but got I4
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected I4, but got Unknown
		//IL_032f: Expected O, but got I4
		//IL_0338: Expected O, but got I4
		//IL_0147: Expected I, but got O
		//IL_014f: Expected I, but got O
		//IL_015f: Expected O, but got I
		//IL_03bb: Expected I, but got O
		//IL_03c3: Expected I, but got O
		//IL_03d3: Expected O, but got I
		//IL_019b: Expected O, but got I
		//IL_040f: Expected O, but got I
		//IL_01d8: Expected O, but got I
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected O, but got Unknown
		//IL_044c: Expected O, but got I
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Expected O, but got Unknown
		//IL_0571: Invalid comparison between F4 and I
		//IL_060e: Invalid comparison between F4 and I
		//IL_0591: Unknown result type (might be due to invalid IL or missing references)
		//IL_0596: Expected O, but got Unknown
		//IL_062e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0633: Expected O, but got Unknown
		//IL_024b: Expected I, but got O
		//IL_04bf: Expected I, but got O
		base.LevelUp();
		if (HasHiddenRave)
		{
			CharacterWeaponsManager weaponsManager = ((CharacterController)this)._weaponsManager;
			Predicate<object> match = (Predicate<object>)_003C_003Ec._003C_003E9__43_0;
			if (_003C_003Ec._003C_003E9__43_0 == null)
			{
				match = (Predicate<object>)(_003C_003Ec._003C_003E9__43_0 = delegate(Equipment x)
				{
					//IL_0052: Expected I4, but got O
					//IL_0030: Expected O, but got I4
					if ((object)x == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					object obj17 = x._equipmentType - 415;
					return obj17 == null;
				});
			}
			List<object> list = ((List<object>)(object)((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField).FindAll(match);
			List<Equipment> list2 = ((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField.FindAll(match);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018764F28Fh\"");
			if (((CharacterController)this)._level == 0)
			{
				int num = (int)(((CharacterController)this)._level / RingLevelUpEveyXLevels);
				List<Equipment> list3 = ((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField.FindAll(match);
				float num2 = (float)num + 1f;
				object obj = 0;
				for (object obj2 = 0; (nint)obj2 < list._size; obj++, obj2 = obj)
				{
					if ((nint)obj < list._size)
					{
						object[] items = list._items;
						object obj3 = items[obj];
						nint num3 = (nint)typeof(Weapon);
						nint num4 = (nint)obj3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ r8_v19 (Il2CppClass<System.Object>)+130]");
						nint num5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
						if (num5 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ r8_v19 (Il2CppClass<System.Object>)+C8]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v51+FFFFFFF8+v222 @ rax_v50*8]");
							if (0 == (nint)typeof(Weapon))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
								object obj6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v51+FFFFFFF8+v849 @ rcx_v30*8]");
								object obj7 = 0 - typeof(Weapon);
								bool flag = obj7 == null;
								bool flag2 = !flag;
								object obj8 = null;
								if (flag2)
								{
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ r9_v16 (System.Object)+4C]");
									if (!(num2 > 0f))
									{
										continue;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ r9_v16 (System.Object)+4C]");
								if ((nint)0 < (nint)8)
								{
									nint num6 = (nint)obj3;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v943 @ rax_v55 (Il2CppClass<System.Object>)+208] (should have been resolved before IL gen)");
								}
								continue;
							}
						}
						goto IL_04f4;
					}
					goto IL_0550;
				}
			}
		}
		if (!HasBallisticMissile)
		{
			return;
		}
		CharacterWeaponsManager weaponsManager2 = ((CharacterController)this)._weaponsManager;
		Predicate<object> match2 = (Predicate<object>)_003C_003Ec._003C_003E9__43_1;
		if (_003C_003Ec._003C_003E9__43_1 == null)
		{
			match2 = (Predicate<object>)(_003C_003Ec._003C_003E9__43_1 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj17 = x._equipmentType - 416;
				return obj17 == null;
			});
		}
		List<object> list4 = ((List<object>)(object)((EquipmentManager)weaponsManager2)._003CHiddenEquipment_003Ek__BackingField).FindAll(match2);
		List<Equipment> list5 = ((EquipmentManager)weaponsManager2)._003CHiddenEquipment_003Ek__BackingField.FindAll(match2);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018764F4BFh\"");
		if (((CharacterController)this)._level != 0)
		{
			return;
		}
		int num7 = (int)(((CharacterController)this)._level / RingLevelUpEveyXLevels);
		List<Equipment> list6 = ((EquipmentManager)weaponsManager2)._003CHiddenEquipment_003Ek__BackingField.FindAll(match2);
		float num8 = (float)num7 + 1f;
		object obj9 = 0;
		object obj10 = 0;
		while (true)
		{
			if ((nint)obj10 >= list4._size)
			{
				return;
			}
			if ((nint)obj9 >= list4._size)
			{
				break;
			}
			object[] items2 = list4._items;
			object obj11 = items2[obj9];
			nint num9 = (nint)typeof(Weapon);
			nint num10 = (nint)obj11;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ r8_v9 (Il2CppClass<System.Object>)+130]");
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			if (num11 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ r8_v9 (Il2CppClass<System.Object>)+C8]");
				object obj13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rax_v22+FFFFFFF8+v229 @ rax_v21*8]");
				if (0 == (nint)typeof(Weapon))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
					object obj14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rax_v22+FFFFFFF8+v888 @ rcx_v15*8]");
					object obj15 = 0 - typeof(Weapon);
					bool flag3 = obj15 == null;
					bool flag4 = !flag3;
					object obj16 = null;
					if (flag4)
					{
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ r9_v9 (System.Object)+4C]");
						if (!(num8 > 0f))
						{
							goto IL_0625;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ r9_v9 (System.Object)+4C]");
					if ((nint)0 < (nint)8)
					{
						nint num12 = (nint)obj11;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v960 @ rax_v26 (Il2CppClass<System.Object>)+208] (should have been resolved before IL gen)");
					}
					goto IL_0625;
				}
			}
			goto IL_04f4;
			IL_0625:
			obj9++;
			obj10 = obj9;
		}
		goto IL_0550;
		IL_0550:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_04f4;
		IL_04f4:
		throw new NullReferenceException();
	}

	public void EnterScatteredPetalsStage(ScatteredPetalsStage stage)
	{
		//IL_0066: Expected O, but got I8
		//IL_0080: Expected O, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5ECD]");
		if ((nint)0 == 0)
		{
			_ = 1;
			object obj = "walk";
		}
		if (_isUsingDivaKatanaSkin)
		{
			if (stage > ScatteredPetalsStage.End)
			{
				ScatteredPetalsStage scatteredPetalsStage = default(ScatteredPetalsStage);
				object actualValue = scatteredPetalsStage;
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("stage", actualValue, null);
				throw ex;
			}
			object obj2 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r8_v2+764F6BC+stage @ rdx (VampireSurvivors.Objects.Characters.ScatteredPetalsStage)*4]");
			object obj3 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v69 @ rcx_v11 (should have been resolved before IL gen)");
		}
	}

	private unsafe void AddScatteredPetalsAnimStage(string animName, string textureName, int frameCount)
	{
		//IL_0199: Expected O, but got I4
		//IL_0035: Expected O, but got Ref
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_0107: Expected O, but got I4
		//IL_0110: Expected O, but got I4
		//IL_00a6: Expected O, but got I
		List<string> list = new List<string>();
		bool flag = frameCount <= 0;
		string text = textureName;
		object obj = 0;
		if (!flag)
		{
			object arg = default(object);
			System.ParamsArray paramsArray2 = default(System.ParamsArray);
			bool flag2;
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				System.ParamsArray paramsArray = new System.ParamsArray(animName, arg);
				string text2 = string.FormatHelper((IFormatProvider)null, "{0}{1}", (System.ParamsArray)(&paramsArray2));
				int version = list._version + 1;
				list._version = version;
				string[] items = list._items;
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)text2);
					text = (string)0;
				}
				else
				{
					int num = list._size + 1;
					list._size = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					text = text2;
				}
				obj++;
				flag2 = (nint)obj < frameCount;
				paramsArray2 = (System.ParamsArray)0;
				paramsArray = (System.ParamsArray)0;
			}
			while (flag2);
		}
		Vector2 pivot = default(Vector2);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(list, textureName, pivot);
		bool shouldLoop = default(bool);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation(animName, animationFrames, _scatteredPetalsFps, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
	}

	private void AddCustomWalkAnim(string animName, string textureName, List<int> frameOrder, int fps)
	{
		List<string> frameNames = SpecifyOrderAnimFrameList(animName, frameOrder);
		Vector2 pivot = default(Vector2);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(frameNames, textureName, pivot);
		int fps2 = default(int);
		bool shouldLoop = default(bool);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation(animName, animationFrames, fps2, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
	}

	private unsafe List<string> SpecifyOrderAnimFrameList(string animName, List<int> frameOrder)
	{
		//IL_01af: Expected I, but got O
		//IL_01b8: Expected O, but got I4
		//IL_01c1: Expected O, but got I4
		//IL_003c: Expected O, but got I
		//IL_0070: Expected O, but got Ref
		//IL_0153: Expected O, but got I4
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_016a: Expected O, but got I4
		//IL_0173: Expected O, but got I4
		//IL_017b: Expected I, but got O
		//IL_018b: Expected O, but got I
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f5: Expected O, but got I4
		//IL_00fe: Expected O, but got I4
		//IL_0114: Expected O, but got I
		List<string> list = new List<string>();
		nint num = (nint)frameOrder;
		object obj = 0;
		object obj2 = 0;
		object arg = default(object);
		System.ParamsArray paramsArray2 = default(System.ParamsArray);
		while (true)
		{
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [frameOrder @ r8 (System.Collections.Generic.List`1<System.Int32>)+18]");
			if ((nint)obj3 < 0)
			{
				object obj4 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [frameOrder @ r8 (System.Collections.Generic.List`1<System.Int32>)+18]");
				if ((nint)obj4 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [frameOrder @ r8 (System.Collections.Generic.List`1<System.Int32>)+10]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				System.ParamsArray paramsArray = new System.ParamsArray(animName, arg);
				string text = string.FormatHelper((IFormatProvider)null, "{0}{1}", (System.ParamsArray)(&paramsArray2));
				int version = list._version + 1;
				list._version = version;
				List<string> items = (List<string>)(object)list._items;
				if (list._size >= items._size)
				{
					((List<object>)(object)list).AddWithResize((object)text);
					obj++;
					paramsArray2 = (System.ParamsArray)0;
					paramsArray = (System.ParamsArray)0;
					num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rcx_v5+20+v103 @ rsi_v2*4]");
					object obj6 = 0;
					obj2 = obj;
				}
				else
				{
					int num2 = list._size + 1;
					list._size = num2;
					items.AddWithResize((string)list._size);
					obj++;
					paramsArray2 = (System.ParamsArray)0;
					paramsArray = (System.ParamsArray)0;
					num = (nint)text;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rcx_v5+20+v103 @ rsi_v2*4]");
					object obj6 = 0;
					obj2 = obj;
				}
				continue;
			}
			return list;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		List<string> result = default(List<string>);
		return result;
	}

	private void AltWalkUpdate()
	{
		//IL_0194: Expected O, but got I4
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		if ((_timeSinceLastAltWalk = num + _timeSinceLastAltWalk) < _timeUntilNextAltWalk)
		{
			return;
		}
		_timeSinceLastAltWalk = 0f;
		float timeUntilNextAltWalk = UnityEngine.Random.Range(_minTimeBetweenAltWalk, _maxTimeBetweenAltWalk);
		_timeUntilNextAltWalk = timeUntilNextAltWalk;
		if (_currentAnimation != CharAnimationType.walk)
		{
			return;
		}
		object obj = UnityEngine.Random.RandomRangeInt(0, 2);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5ED1]");
			if (0 == (nint)obj)
			{
				_ = 1;
			}
			SpriteAnimation spriteAnimation = _spriteAnimation;
			((CharacterController)this)._isAnimForced = true;
			_currentAnimation = CharAnimationType.special;
			((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
			_spriteAnimation.Play("EME_divano5_hop", _altWalkFps);
		}
		else if ((nint)obj == 1)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5ED2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			SpriteAnimation spriteAnimation2 = _spriteAnimation;
			((CharacterController)this)._isAnimForced = true;
			_currentAnimation = CharAnimationType.special;
			((BaseSpriteAnimation)spriteAnimation2)._003CIsPaused_003Ek__BackingField = false;
			_spriteAnimation.Play("EME_divano5_splits", _altWalkFps);
		}
	}

	private void DoAltWalk1()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5ED1]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SpriteAnimation spriteAnimation = _spriteAnimation;
		((CharacterController)this)._isAnimForced = true;
		_currentAnimation = CharAnimationType.special;
		((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
		_spriteAnimation.Play("EME_divano5_hop", _altWalkFps);
	}

	private void DoAltWalk2()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5ED2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SpriteAnimation spriteAnimation = _spriteAnimation;
		((CharacterController)this)._isAnimForced = true;
		_currentAnimation = CharAnimationType.special;
		((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
		_spriteAnimation.Play("EME_divano5_splits", _altWalkFps);
	}

	public void ReturnToNormalWalkAnim()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5ED3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_isUsingDivaKatanaSkin)
		{
			SpriteAnimation spriteAnimation = _spriteAnimation;
			((CharacterController)this)._isAnimForced = false;
			_currentAnimation = CharAnimationType.walk;
			((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = true;
			_spriteAnimation.Play("walk", _walkFps);
		}
	}

	private unsafe List<string> MakeAnimFrameList(string animName, int frameCount)
	{
		//IL_0167: Expected O, but got I4
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		//IL_01ad: Expected O, but got Ref
		//IL_00de: Expected I4, but got O
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_0110: Expected O, but got I4
		//IL_0119: Expected O, but got I4
		List<string> list = new List<string>();
		bool flag = frameCount <= 0;
		int num = frameCount;
		object obj = 0;
		if (!flag)
		{
			object arg = default(object);
			System.ParamsArray paramsArray2 = default(System.ParamsArray);
			while (true)
			{
				object obj2 = obj + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				System.ParamsArray paramsArray = new System.ParamsArray(animName, arg);
				string text = string.FormatHelper((IFormatProvider)null, "{0}{1}", (System.ParamsArray)(&paramsArray2));
				if (list != null)
				{
					int version = list._version + 1;
					list._version = version;
					string[] items = list._items;
					if (list._items != null)
					{
						if (list._size >= items.Length)
						{
							((List<object>)(object)list).AddWithResize((object)text);
							num = 0;
						}
						else
						{
							int num2 = list._size + 1;
							list._size = num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							num = (int)text;
						}
						obj++;
						bool flag2 = (nint)obj < frameCount;
						object obj3 = obj2;
						paramsArray2 = (System.ParamsArray)0;
						paramsArray = (System.ParamsArray)0;
						if (!flag2)
						{
							break;
						}
						continue;
					}
				}
				return (List<string>)(object)new NullReferenceException();
			}
		}
		return list;
	}

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		Sprite unpackedSprite = SpriteManager.GetUnpackedSprite("UISquare");
		_ChargeBarFill.sprite = unpackedSprite;
		_ChargeBar.sprite = unpackedSprite;
		_chargeTime = 0f;
		_isCharging = false;
		SetMechaDamageEmitter();
	}

	private unsafe void HideCharge()
	{
		//IL_0014: Expected O, but got Ref
		//IL_0037: Expected O, but got Ref
		//IL_005a: Expected O, but got Ref
		object obj = default(object);
		_ChargeBarFill.color = (Color)(&obj);
		Color color = _ChargeBar.color;
		_ChargeBar.color = (Color)(&obj);
		Color color2 = _ChargeBarFill.color;
		_ChargeBarFill.color = (Color)(&obj);
		_isCharging = false;
	}

	private unsafe void ShowCharge()
	{
		//IL_0014: Expected O, but got Ref
		//IL_0037: Expected O, but got Ref
		//IL_005a: Expected O, but got Ref
		object obj = default(object);
		_ChargeBarFill.color = (Color)(&obj);
		Color color = _ChargeBar.color;
		_ChargeBar.color = (Color)(&obj);
		Color color2 = _ChargeBarFill.color;
		_ChargeBarFill.color = (Color)(&obj);
		if (!_isCharging)
		{
			_isCharging = true;
		}
	}

	private unsafe void HighlightCharge()
	{
		//IL_0014: Expected O, but got Ref
		//IL_0037: Expected O, but got Ref
		//IL_005a: Expected O, but got Ref
		object obj = default(object);
		_ChargeBarFill.color = (Color)(&obj);
		Color color = _ChargeBar.color;
		_ChargeBar.color = (Color)(&obj);
		Color color2 = _ChargeBarFill.color;
		_ChargeBarFill.color = (Color)(&obj);
		if (!_isCharging)
		{
			_isCharging = true;
		}
	}

	protected override void OnUpdate()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_04b5: Invalid comparison between F4 and I4
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0567: Unknown result type (might be due to invalid IL or missing references)
		//IL_056c: Expected O, but got Unknown
		//IL_04d2: Expected O, but got F4
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected O, but got Unknown
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Expected O, but got Unknown
		//IL_05c4: Expected O, but got I4
		object obj2 = default(object);
		object obj = obj2 - 95;
		base.OnUpdate();
		if (!(((CharacterController)this)._walked > 0f))
		{
			if (!(_chargeTime < _maxChargeTimeMS))
			{
				_chargeTime = 0f;
				Action onComplete = TriggerChargeSkill;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer timer = Timers.Register(0.060000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				nextTriggeredSkillTimer = timer;
				_maxChargeTimeMS = _defaultChargeTimeMS;
				object obj3 = UnityEngine.Random.value;
				float num = base.PLuck();
				float num2 = 0.060000002f * 0.1f;
				if (!(num2 < 0.060000002f))
				{
					float maxChargeTimeMS = _defaultChargeTimeMS * 0.1f;
					_maxChargeTimeMS = maxChargeTimeMS;
				}
				_ChargeBarFill.fillAmount = 0f;
			}
			Color color = (Color)(obj + 39);
			_ = ChargeColor;
			_ChargeBarFill.color = color;
			Color color2 = _ChargeBar.color;
			Color color3 = (Color)(obj + 39);
			_ = 1051931443;
			_ChargeBar.color = color3;
			Color color4 = _ChargeBarFill.color;
			Color color5 = (Color)(obj + 39);
			_ = 1051931443;
			_ChargeBarFill.color = color5;
			_isCharging = false;
			return;
		}
		float num3 = PauseSystem.DeltaTime;
		float num4 = num3 * 1000f;
		float num5 = base.PLuck();
		if (!(2.5f > num3))
		{
			num3 = 2.5f;
		}
		float num6 = num3 * num4;
		float fillAmount = (_chargeTime = num6 + _chargeTime) / _maxChargeTimeMS;
		_ChargeBarFill.fillAmount = fillAmount;
		Image chargeBarFill;
		if (!(_chargeTime < _maxChargeTimeMS))
		{
			chargeBarFill = _ChargeBarFill;
			Color readyColor = ReadyColor;
		}
		else
		{
			chargeBarFill = _ChargeBarFill;
			Color readyColor = ChargeColor;
		}
		Color color6 = (Color)(obj + 39);
		chargeBarFill.color = color6;
		Color color7 = _ChargeBar.color;
		Color color8 = (Color)(obj + 39);
		_ = 1065353216;
		_ChargeBar.color = color8;
		Color color9 = _ChargeBarFill.color;
		Color color10 = (Color)(obj + 39);
		_ = 1065353216;
		_ChargeBarFill.color = color10;
		if (!_isCharging)
		{
			_isCharging = true;
		}
		if (!_isUsingDivaKatanaSkin)
		{
			return;
		}
		float deltaTime = PauseSystem.DeltaTime;
		float num7 = deltaTime * 1000f;
		if ((_timeSinceLastAltWalk = num7 + _timeSinceLastAltWalk) < _timeUntilNextAltWalk)
		{
			return;
		}
		_timeSinceLastAltWalk = 0f;
		float timeUntilNextAltWalk = UnityEngine.Random.Range(_minTimeBetweenAltWalk, _maxTimeBetweenAltWalk);
		_timeUntilNextAltWalk = timeUntilNextAltWalk;
		if (_currentAnimation != CharAnimationType.walk)
		{
			return;
		}
		object obj4 = UnityEngine.Random.RandomRangeInt(0, 2);
		BaseSpriteAnimation spriteAnimation2;
		int altWalkFps;
		string animName;
		if (obj4 == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5ED1]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			SpriteAnimation spriteAnimation = _spriteAnimation;
			((CharacterController)this)._isAnimForced = true;
			_currentAnimation = CharAnimationType.special;
			((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
			spriteAnimation2 = _spriteAnimation;
			altWalkFps = _altWalkFps;
			animName = "EME_divano5_hop";
		}
		else
		{
			if ((nint)obj4 != 1)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5ED2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			SpriteAnimation spriteAnimation3 = _spriteAnimation;
			((CharacterController)this)._isAnimForced = true;
			_currentAnimation = CharAnimationType.special;
			((BaseSpriteAnimation)spriteAnimation3)._003CIsPaused_003Ek__BackingField = false;
			spriteAnimation2 = _spriteAnimation;
			altWalkFps = _altWalkFps;
			animName = "EME_divano5_splits";
		}
		spriteAnimation2.Play(animName, altWalkFps);
	}

	private unsafe void TriggerChargeSkill()
	{
		//IL_0477: Expected I, but got O
		//IL_04aa: Expected I, but got O
		//IL_029b: Expected I, but got O
		//IL_02a9: Expected I, but got O
		//IL_02b9: Expected O, but got I
		//IL_0205: Expected O, but got Ref
		//IL_0339: Expected O, but got I4
		//IL_02f5: Expected O, but got I
		//IL_032b: Expected O, but got I4
		//IL_0384: Expected I, but got O
		List<object> list3 = default(List<object>);
		Equipment equipment;
		List<object> list2;
		if (HasBigMissile)
		{
			CharacterWeaponsManager weaponsManager = ((CharacterController)this)._weaponsManager;
			if ((object)((CharacterController)this)._weaponsManager != null)
			{
				Predicate<Equipment> match = delegate(Equipment x)
				{
					//IL_0067: Expected I4, but got O
					//IL_004f: Unknown result type (might be due to invalid IL or missing references)
					//IL_0054: Expected I4, but got Unknown
					if ((object)x != null)
					{
						List<WeaponType> list5 = missiles;
						if (missiles != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
							object obj5 = default(object);
							object obj4 = obj5 >> 31;
							return (byte)(obj4 ^ 1) != 0;
						}
					}
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				};
				if (((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField != null)
				{
					List<object> list = ((List<object>)(object)((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField).FindAll((Predicate<object>)match);
					if (list != null)
					{
						EME_Mech1Weapon eME_Mech1Weapon = null;
						list2 = list;
						list3 = list;
						List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
						List<object> list4 = default(List<object>);
						EME_Mech1Weapon eME_Mech1Weapon4 = default(EME_Mech1Weapon);
						while (enumerator.MoveNext())
						{
							EME_Mech1Weapon eME_Mech1Weapon2 = null;
							EME_Mech1Weapon eME_Mech1Weapon3 = null;
							if ((object)eME_Mech1Weapon3 != null && ((UnityEngine.Object)eME_Mech1Weapon3).m_CachedPtr != (IntPtr)0)
							{
								base.OnRangedAttackAnim();
								float2 float5 = base.position;
								eME_Mech1Weapon3.FireVolley((Vector2)list4, 7);
								eME_Mech1Weapon = eME_Mech1Weapon4;
								list2 = list4;
								list3 = null;
							}
						}
						equipment = null;
						EME_CharacterControllerDiva eME_CharacterControllerDiva = (EME_CharacterControllerDiva)(&enumerator);
						goto IL_042e;
					}
				}
			}
			goto IL_0393;
		}
		list2 = null;
		equipment = null;
		goto IL_042e;
		IL_0393:
		throw new NullReferenceException();
		IL_04bc:
		object obj;
		Equipment equipment2;
		if (obj != null)
		{
			equipment = equipment2;
		}
		goto IL_04de;
		IL_04de:
		if ((object)equipment != null && ((UnityEngine.Object)equipment).m_CachedPtr != (IntPtr)0)
		{
			nint num = (nint)equipment;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v955 @ rax_v16 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+4B8] (should have been resolved before IL gen)");
		}
		return;
		IL_042e:
		if (!HasBallisticMissile)
		{
			return;
		}
		CharacterWeaponsManager weaponsManager2 = ((CharacterController)this)._weaponsManager;
		if ((object)((CharacterController)this)._weaponsManager != null)
		{
			Predicate<Equipment> match2 = _003C_003Ec._003C_003E9__67_1;
			bool flag = _003C_003Ec._003C_003E9__67_1 != null;
			nint num2 = (nint)list3;
			if (!flag)
			{
				Predicate<Equipment> predicate = (_003C_003Ec._003C_003E9__67_1 = delegate(Equipment x)
				{
					//IL_0052: Expected I4, but got O
					//IL_0030: Expected O, but got I4
					if ((object)x == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					object obj4 = x._equipmentType - 416;
					return obj4 == null;
				});
				num2 = unchecked((nint)null);
				match2 = predicate;
			}
			if (((EquipmentManager)weaponsManager2)._003CHiddenEquipment_003Ek__BackingField != null)
			{
				equipment2 = ((EquipmentManager)weaponsManager2)._003CHiddenEquipment_003Ek__BackingField.Find(match2);
				if ((object)equipment2 != null)
				{
					num2 = (nint)equipment2;
					nint num3 = (nint)typeof(EME_Mech_BallisticMissile_Weapon);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v625 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Mech_BallisticMissile_Weapon>)+130]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v625 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Mech_BallisticMissile_Weapon>)+130]");
					if (num4 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v27+FFFFFFF8+v626 @ rax_v23*8]");
						if (0 == (nint)typeof(EME_Mech_BallisticMissile_Weapon))
						{
							obj = 1;
							goto IL_04bc;
						}
					}
					obj = 0;
					goto IL_04bc;
				}
				goto IL_04de;
			}
		}
		goto IL_0393;
	}

	public unsafe void SetMechaDamageEmitter()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0353: Expected O, but got Ref
		//IL_0374: Expected native int or pointer, but got O
		//IL_0387: Expected O, but got Ref
		//IL_0395: Expected O, but got Ref
		//IL_03ca: Expected O, but got Ref
		//IL_03e4: Expected native int or pointer, but got O
		//IL_0027: Expected O, but got Ref
		//IL_0035: Expected O, but got Ref
		//IL_01ca: Expected O, but got Ref
		//IL_01e4: Expected native int or pointer, but got O
		//IL_01fc: Expected O, but got Ref
		//IL_0255: Expected O, but got Ref
		//IL_026f: Expected native int or pointer, but got O
		//IL_0282: Expected O, but got Ref
		//IL_02f0: Expected O, but got I
		//IL_0305: Expected O, but got I
		//IL_031a: Expected O, but got I
		//IL_0335: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = _damageVfx;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		_ = _damageVfx;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0.5f, 1f));
		ParticleSystem.MinMaxCurve startLifetime = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
		_ = 0;
		((ParticleSystem.MainModule*)mainModule)->startLifetime = startLifetime;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		ParticleSystem.MinMaxCurve startRotation = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		ParticleSystem.MainModule mainModule2 = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-9]");
		_ = 0;
		((ParticleSystem.MainModule*)mainModule2)->startRotation = startRotation;
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxYellow");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxLine");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int cycleCount = default(int);
		RenderingExtensions.SetFrames(_damageVfx, list, null, clearExistingFrames: false, cycleCount);
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(225f, 315f));
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+17]");
		_ = 0;
		ParticleSystem particleSystem = RenderingExtensions.SetAngle(_damageVfx, minMaxCurve4);
		ParticleSystem particleSystem2 = RenderingExtensions.SetTint(_damageVfx, 16777215u);
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(4f, 2f));
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+27]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+37]");
		_ = 0;
		RenderingExtensions.SetScale(_damageVfx, minMaxCurve6);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		_ = 1;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
		particleSystemConfig._collideLeft = (bool?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
		particleSystemConfig._collideTop = (bool?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
		particleSystemConfig._collideBottom = (bool?)(object)0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
		particleSystemConfig._collideRight = (bool?)(object)0;
		RenderingExtensions.SetCollisionBounds(_damageVfx, particleSystemConfig);
	}

	public EME_CharacterControllerDiva()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0246: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_026e: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_01ca: Expected O, but got F4
		//IL_01f7: Expected O, but got F4
		_minTimeBetweenAltWalk = 500f;
		_maxTimeBetweenAltWalk = 1000f;
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)382);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 382;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)383);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 383;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)384);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 384;
		}
		missiles = list;
		_scatteredPetalsFps = 8;
		_walkFps = 8;
		_altWalkFps = 8;
		RingLevelUpEveyXLevels = 7f;
		_maxChargeTimeMS = 10000f;
		_defaultChargeTimeMS = 10000f;
		ChargeColor = (Color)ColourHelper.HexToColor("FF8C00").r;
		Color color = ColourHelper.HexToColor("FFFF00");
		base._morphDuration = 13000f;
		ReadyColor = (Color)color.r;
		((CharacterController)this)._002Ector();
	}

	private bool _003CTriggerChargeSkill_003Eb__67_0(Equipment x)
	{
		//IL_0067: Expected I4, but got O
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected I4, but got Unknown
		if ((object)x != null)
		{
			List<WeaponType> list = missiles;
			if (missiles != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj2 = default(object);
				object obj = obj2 >> 31;
				return (byte)(obj ^ 1) != 0;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
