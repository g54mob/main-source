using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters.Enemies;

namespace VampireSurvivors.Objects.Characters;

public class MazerellaDancerAnimation
{
	private struct DanceAnimationStage(string animationName, bool flipX)
	{
		public readonly string AnimationName = animationName;

		public readonly bool FlipX = flipX;
	}

	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public MazerellaDancerAnimation _003C_003E4__this;

		public string kickAnimation;

		public string spinAnimation;

		public string tambourineAnimation;

		internal unsafe void _003CInitAnims_003Eb__0(bool success)
		{
			//IL_0008: Expected O, but got Ref
			//IL_00e3: Expected O, but got Ref
			//IL_013c: Expected O, but got Ref
			//IL_0195: Expected O, but got Ref
			//IL_01ee: Expected O, but got Ref
			//IL_0247: Expected O, but got Ref
			//IL_02a0: Expected O, but got Ref
			//IL_02f9: Expected O, but got Ref
			//IL_0352: Expected O, but got Ref
			//IL_03ab: Expected O, but got Ref
			//IL_0404: Expected O, but got Ref
			object obj2 = default(object);
			object obj = (object)(&obj2);
			if (!success && !SpriteManager.TextureExists("character_tarantella"))
			{
				Debug.LogError("Couldn't load texture character_tarantella");
				return;
			}
			int fps = default(int);
			_003C_003E4__this.AddDanceAnim(kickAnimation, "character_tarantella", 6, fps);
			_003C_003E4__this.AddDanceAnim(spinAnimation, "character_tarantella", 5, fps);
			_003C_003E4__this.AddDanceAnim(tambourineAnimation, "character_tarantella", 4, fps);
			MazerellaDancerAnimation mazerellaDancerAnimation = _003C_003E4__this;
			_ = kickAnimation;
			_ = 0;
			_ = 0;
			DanceAnimationStage item = (DanceAnimationStage)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
			_ = 0;
			mazerellaDancerAnimation._danceAnimationStages.Add(item);
			MazerellaDancerAnimation mazerellaDancerAnimation2 = _003C_003E4__this;
			_ = kickAnimation;
			_ = 0;
			_ = 1;
			DanceAnimationStage item2 = (DanceAnimationStage)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-39]");
			_ = 0;
			mazerellaDancerAnimation2._danceAnimationStages.Add(item2);
			MazerellaDancerAnimation mazerellaDancerAnimation3 = _003C_003E4__this;
			_ = spinAnimation;
			_ = 0;
			_ = 0;
			DanceAnimationStage item3 = (DanceAnimationStage)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-29]");
			_ = 0;
			mazerellaDancerAnimation3._danceAnimationStages.Add(item3);
			MazerellaDancerAnimation mazerellaDancerAnimation4 = _003C_003E4__this;
			_ = spinAnimation;
			_ = 0;
			_ = 1;
			DanceAnimationStage item4 = (DanceAnimationStage)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
			_ = 0;
			mazerellaDancerAnimation4._danceAnimationStages.Add(item4);
			MazerellaDancerAnimation mazerellaDancerAnimation5 = _003C_003E4__this;
			_ = tambourineAnimation;
			_ = 0;
			_ = 0;
			DanceAnimationStage item5 = (DanceAnimationStage)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
			_ = 0;
			mazerellaDancerAnimation5._danceAnimationStages.Add(item5);
			MazerellaDancerAnimation mazerellaDancerAnimation6 = _003C_003E4__this;
			_ = kickAnimation;
			_ = 0;
			_ = 1;
			DanceAnimationStage item6 = (DanceAnimationStage)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7]");
			_ = 0;
			mazerellaDancerAnimation6._danceAnimationStages.Add(item6);
			MazerellaDancerAnimation mazerellaDancerAnimation7 = _003C_003E4__this;
			_ = kickAnimation;
			_ = 0;
			_ = 0;
			DanceAnimationStage item7 = (DanceAnimationStage)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+17]");
			_ = 0;
			mazerellaDancerAnimation7._danceAnimationStages.Add(item7);
			MazerellaDancerAnimation mazerellaDancerAnimation8 = _003C_003E4__this;
			_ = spinAnimation;
			_ = 0;
			_ = 1;
			DanceAnimationStage item8 = (DanceAnimationStage)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+27]");
			_ = 0;
			mazerellaDancerAnimation8._danceAnimationStages.Add(item8);
			MazerellaDancerAnimation mazerellaDancerAnimation9 = _003C_003E4__this;
			_ = spinAnimation;
			_ = 0;
			_ = 0;
			DanceAnimationStage item9 = (DanceAnimationStage)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+37]");
			_ = 0;
			mazerellaDancerAnimation9._danceAnimationStages.Add(item9);
			MazerellaDancerAnimation mazerellaDancerAnimation10 = _003C_003E4__this;
			_ = tambourineAnimation;
			_ = 0;
			_ = 1;
			DanceAnimationStage item10 = (DanceAnimationStage)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+47]");
			_ = 0;
			mazerellaDancerAnimation10._danceAnimationStages.Add(item10);
			_003C_003E4__this.PlayAnimationStage(0);
		}
	}

	private const string TarantellaTextureName = "character_tarantella";

	private const string CharacterCacheGroupName = "CharacterTextures";

	private const string FemaleCharacterName = "Tarantella_F_";

	private const string MaleCharacterName = "Tarantella_M_";

	private const string KickAnimName = "kick_i0";

	private const string SpinAnimName = "spin_i0";

	private const string FemaleTambourineAnimName = "tamborine_i0";

	private const string MaleTambourineAnimName = "tamborin_i0";

	private const string MaleKick = "Tarantella_M_kick_i0";

	private const string MaleSpin = "Tarantella_M_spin_i0";

	private const string MaleTambourine = "Tarantella_M_tamborin_i0";

	private const string FemaleKick = "Tarantella_F_kick_i0";

	private const string FemaleSpin = "Tarantella_F_spin_i0";

	private const string FemaleTambourine = "Tarantella_F_tamborine_i0";

	private SpriteRenderer _spriteRenderer;

	private SpriteAnimation _spriteAnimation;

	private int _currentAnimationStageIndex;

	private readonly List<DanceAnimationStage> _danceAnimationStages;

	private static string KickAnimationName(EnemyMazerellaDancer.DancerSide dancerSide)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5FE1]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = dancerSide != EnemyMazerellaDancer.DancerSide.Right;
		string result = "Tarantella_F_kick_i0";
		if (!flag)
		{
			result = "Tarantella_M_kick_i0";
		}
		return result;
	}

	private static string SpinAnimationName(EnemyMazerellaDancer.DancerSide dancerSide)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5FE2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = dancerSide != EnemyMazerellaDancer.DancerSide.Right;
		string result = "Tarantella_F_spin_i0";
		if (!flag)
		{
			result = "Tarantella_M_spin_i0";
		}
		return result;
	}

	private static string TambourineAnimationName(EnemyMazerellaDancer.DancerSide dancerSide)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5FE3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = dancerSide != EnemyMazerellaDancer.DancerSide.Right;
		string result = "Tarantella_F_tamborine_i0";
		if (!flag)
		{
			result = "Tarantella_M_tamborin_i0";
		}
		return result;
	}

	public void InitAnims(SpriteRenderer spriteRenderer, SpriteAnimation spriteAnimation, EnemyMazerellaDancer.DancerSide dancerSide)
	{
		//IL_0107: Expected I4, but got O
		//IL_0124: Expected O, but got I4
		_003C_003Ec__DisplayClass22_0 obj = new _003C_003Ec__DisplayClass22_0();
		obj._003C_003E4__this = this;
		_spriteRenderer = spriteRenderer;
		_spriteAnimation = spriteAnimation;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5FE1]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = dancerSide != EnemyMazerellaDancer.DancerSide.Right;
		string kickAnimation = "Tarantella_F_kick_i0";
		if (!flag)
		{
			kickAnimation = "Tarantella_M_kick_i0";
		}
		obj.kickAnimation = kickAnimation;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5FE2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag2 = dancerSide != EnemyMazerellaDancer.DancerSide.Right;
		string spinAnimation = "Tarantella_F_spin_i0";
		if (!flag2)
		{
			spinAnimation = "Tarantella_M_spin_i0";
		}
		obj.spinAnimation = spinAnimation;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5FE3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag3 = dancerSide != EnemyMazerellaDancer.DancerSide.Right;
		string tambourineAnimation = "Tarantella_F_tamborine_i0";
		if (!flag3)
		{
			tambourineAnimation = "Tarantella_M_tamborin_i0";
		}
		obj.tambourineAnimation = tambourineAnimation;
		Action<bool> action = null;
		((_003C_003Ec__DisplayClass22_0)(object)action)._003CInitAnims_003Eb__0((byte)(int)obj != 0);
		bool flag4 = SpriteLoader.LoadTexture("character_tarantella", "CharacterTextures", (DlcType?)(object)0, action);
	}

	private unsafe void AddDanceAnim(string animName, string textureName, int frameCount, int fps)
	{
		//IL_01a8: Expected O, but got I4
		//IL_0172: Expected O, but got Ref
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_00ce: Expected O, but got I4
		//IL_00d7: Expected O, but got I4
		//IL_006d: Expected O, but got I
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
					int size = list._size + 1;
					list._size = size;
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
		Action action = PlayNextAnimationStage;
		int fps2 = default(int);
		bool shouldLoop = default(bool);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation(animName, animationFrames, fps2, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
	}

	private void PlayNextAnimationStage()
	{
		List<DanceAnimationStage> danceAnimationStages = _danceAnimationStages;
		int num = ++_currentAnimationStageIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rcx_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerAnimation+DanceAnimationStage>)+18]");
		if ((nint)num == 0)
		{
			_currentAnimationStageIndex = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 54 Invalid \"Jump target not found in method: 0x1876895C0\"");
		throw new NullReferenceException();
	}

	private void PlayAnimationStage(int stageIndex)
	{
		//IL_003c: Expected O, but got I
		//IL_004f: Expected O, but got I4
		//IL_0078: Expected O, but got I
		List<DanceAnimationStage> danceAnimationStages = _danceAnimationStages;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerAnimation+DanceAnimationStage>)+18]");
		if ((nint)stageIndex < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.MazerellaDancerAnimation+DanceAnimationStage>)+10]");
			object obj = 0;
			object obj2 = stageIndex + 2;
			object obj3 = obj2 + obj2;
			SpriteAnimation spriteAnimation = _spriteAnimation;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v6+v65 @ rax_v10*8]");
			spriteAnimation.SetAnimation((string)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			SpriteRenderer spriteRenderer = _spriteRenderer;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v6+v65 @ rax_v10*8]");
			spriteRenderer.flipX = false;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
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
							int size = list._size + 1;
							list._size = size;
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

	public MazerellaDancerAnimation()
	{
		List<DanceAnimationStage> danceAnimationStages = new List<DanceAnimationStage>();
		_danceAnimationStages = danceAnimationStages;
	}
}
