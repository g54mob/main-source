using System;
using Cpp2ILInjected;

namespace VampireSurvivors.Framework.PhaserTweens;

public class StaggerUtils
{
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public float value;

		public StaggerConfig config;

		internal float _003CGetStaggerFunc_003Eb__0(int i)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			StaggerConfig staggerConfig = config;
			object obj = i * value;
			return (float)obj + staggerConfig.start;
		}

		internal float _003CGetStaggerFunc_003Eb__1(int i)
		{
			return (float)i * value;
		}
	}

	private static Type StaggerType;

	public static Func<int, float> GetStaggerFunc(float value, StaggerConfig config)
	{
		//IL_00e6: Expected I4, but got O
		//IL_0061: Invalid comparison between F4 and I4
		_003C_003Ec__DisplayClass1_0 obj = new _003C_003Ec__DisplayClass1_0();
		Func<int, float> func;
		Func<int, float> result;
		if (obj != null)
		{
			obj.value = value;
			obj.config = config;
			if (obj.config != null)
			{
				StaggerConfig config2 = obj.config;
				bool flag = config2.start == 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B17BDDh\"");
				if (!flag)
				{
					func = null;
					result = func;
					goto IL_00d9;
				}
			}
			func = null;
			result = func;
			goto IL_00d9;
		}
		return (Func<int, float>)(object)new NullReferenceException();
		IL_00d9:
		float num = ((_003C_003Ec__DisplayClass1_0)(object)func)._003CGetStaggerFunc_003Eb__0((int)obj);
		return result;
	}

	public static bool IsStaggered(object property)
	{
		//IL_0052: Expected I4, but got O
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		if (property != null)
		{
			object obj = property + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj3 = default(object);
			object obj2 = obj3 - (object)StaggerType;
			return obj2 == null;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static float GetDuration(TweenConfig config, int index)
	{
		Func<int, float> staggerDuration = config.staggerDuration;
		if (config.staggerDuration != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v11 @ r9_v1 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			object obj = default(object);
			return (float)obj * 0.001f;
		}
		return config.duration * 0.001f;
	}

	public static float GetDelay(TweenConfig config, int index)
	{
		Func<int, float> staggerDelay = config.staggerDelay;
		if (config.staggerDelay != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v11 @ r9_v1 (System.Func`2<System.Int32, System.Single>)+18] (should have been resolved before IL gen)");
			object obj = default(object);
			return (float)obj * 0.001f;
		}
		return config.delay * 0.001f;
	}

	public static float GetX(TweenConfig config, int index)
	{
		//IL_0044: Expected O, but got I
		//IL_0054: Expected O, but got I
		//IL_0064: Expected O, but got I
		//IL_009d: Expected F4, but got I
		Func<int, float> staggerX = config.staggerX;
		if (config.staggerX != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+28]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+40]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v55 @ rax_v5 (should have been resolved before IL gen)");
		}
		if ((object)config.x != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+64]");
			return 0f;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		float result = default(float);
		return result;
	}

	public static float GetY(TweenConfig config, int index)
	{
		//IL_0044: Expected O, but got I
		//IL_0054: Expected O, but got I
		//IL_0064: Expected O, but got I
		//IL_009d: Expected F4, but got I
		Func<int, float> staggerY = config.staggerY;
		if (config.staggerY != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+28]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+40]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v55 @ rax_v5 (should have been resolved before IL gen)");
		}
		if ((object)config.y != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+6C]");
			return 0f;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		float result = default(float);
		return result;
	}

	public static float GetLocalX(TweenConfig config, int index)
	{
		//IL_0044: Expected O, but got I
		//IL_0054: Expected O, but got I
		//IL_0064: Expected O, but got I
		//IL_009d: Expected F4, but got I
		Func<int, float> staggerLocalX = config.staggerLocalX;
		if (config.staggerLocalX != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+28]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+40]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v55 @ rax_v5 (should have been resolved before IL gen)");
		}
		if ((object)config.localX != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+74]");
			return 0f;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		float result = default(float);
		return result;
	}

	public static float GetLocalY(TweenConfig config, int index)
	{
		//IL_0044: Expected O, but got I
		//IL_0054: Expected O, but got I
		//IL_0064: Expected O, but got I
		//IL_009d: Expected F4, but got I
		Func<int, float> staggerLocalY = config.staggerLocalY;
		if (config.staggerLocalY != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+28]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+40]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v55 @ rax_v5 (should have been resolved before IL gen)");
		}
		if ((object)config.localY != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+7C]");
			return 0f;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		float result = default(float);
		return result;
	}

	public static float GetScale(TweenConfig config, int index)
	{
		//IL_0044: Expected O, but got I
		//IL_0054: Expected O, but got I
		//IL_0064: Expected O, but got I
		//IL_009d: Expected F4, but got I
		Func<int, float> staggerScale = config.staggerScale;
		if (config.staggerScale != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+28]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+40]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v55 @ rax_v5 (should have been resolved before IL gen)");
		}
		if ((object)config.scale != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+84]");
			return 0f;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		float result = default(float);
		return result;
	}

	public static float GetScaleX(TweenConfig config, int index)
	{
		//IL_0044: Expected O, but got I
		//IL_0054: Expected O, but got I
		//IL_0064: Expected O, but got I
		//IL_009d: Expected F4, but got I
		Func<int, float> staggerScaleX = config.staggerScaleX;
		if (config.staggerScaleX != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+28]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+40]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v55 @ rax_v5 (should have been resolved before IL gen)");
		}
		if ((object)config.scaleX != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+8C]");
			return 0f;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		float result = default(float);
		return result;
	}

	public static float GetScaleY(TweenConfig config, int index)
	{
		//IL_0044: Expected O, but got I
		//IL_0054: Expected O, but got I
		//IL_0064: Expected O, but got I
		//IL_009d: Expected F4, but got I
		Func<int, float> staggerScaleY = config.staggerScaleY;
		if (config.staggerScaleY != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+28]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+40]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v55 @ rax_v5 (should have been resolved before IL gen)");
		}
		if ((object)config.scaleY != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+94]");
			return 0f;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		float result = default(float);
		return result;
	}

	public static float GetAngle(TweenConfig config, int index)
	{
		//IL_0044: Expected O, but got I
		//IL_0054: Expected O, but got I
		//IL_0064: Expected O, but got I
		//IL_009d: Expected F4, but got I
		Func<int, float> staggerAngle = config.staggerAngle;
		if (config.staggerAngle != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+28]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+40]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v55 @ rax_v5 (should have been resolved before IL gen)");
		}
		if ((object)config.angle != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+AC]");
			return 0f;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		float result = default(float);
		return result;
	}

	public static float GetLocalAngle(TweenConfig config, int index)
	{
		//IL_0044: Expected O, but got I
		//IL_0054: Expected O, but got I
		//IL_0064: Expected O, but got I
		//IL_009d: Expected F4, but got I
		Func<int, float> staggerLocalAngle = config.staggerLocalAngle;
		if (config.staggerLocalAngle != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+28]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+40]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v55 @ rax_v5 (should have been resolved before IL gen)");
		}
		if ((object)config.localAngle != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+B4]");
			return 0f;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		float result = default(float);
		return result;
	}

	public static float GetAlpha(TweenConfig config, int index)
	{
		//IL_0044: Expected O, but got I
		//IL_0054: Expected O, but got I
		//IL_0064: Expected O, but got I
		//IL_009d: Expected F4, but got I
		Func<int, float> staggerAlpha = config.staggerAlpha;
		if (config.staggerAlpha != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+28]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v4 (System.Func`2<System.Int32, System.Single>)+40]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v55 @ rax_v5 (should have been resolved before IL gen)");
		}
		if ((object)config.alpha != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.PhaserTweens.TweenConfig)+C0]");
			return 0f;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		float result = default(float);
		return result;
	}

	static StaggerUtils()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type = default(Type);
		Type staggerType = type;
		StaggerType = staggerType;
	}
}
