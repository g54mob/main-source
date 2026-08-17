using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics.Blitters;

namespace VampireSurvivors;

public class TestBobs : MonoBehaviour
{
	protected int count;

	private Sprite sprite;

	protected Vector2 spawnRange;

	private Blitter _blitter;

	protected unsafe void Start()
	{
		//IL_00a7: Expected O, but got I4
		//IL_00af: Expected F4, but got O
		//IL_00c0: Expected O, but got Ref
		//IL_00c9: Expected O, but got I4
		//IL_0583: Expected O, but got I
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0431: Expected O, but got Unknown
		//IL_044b: Expected O, but got I
		//IL_05e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ed: Expected O, but got Unknown
		//IL_0103: Expected O, but got I8
		//IL_01a5: Invalid comparison between I4 and F4
		//IL_013d: Expected O, but got I8
		//IL_0204: Expected F4, but got I4
		//IL_0248: Expected F4, but got I4
		//IL_0212: Invalid comparison between O and F4
		//IL_0223: Expected F4, but got O
		//IL_028c: Expected F4, but got I4
		//IL_0256: Invalid comparison between O and F4
		//IL_0267: Expected F4, but got O
		//IL_02d0: Expected F4, but got I4
		//IL_029a: Invalid comparison between O and F4
		//IL_02ab: Expected F4, but got O
		//IL_02e5: Expected O, but got I
		//IL_02fa: Expected O, but got I
		//IL_030f: Expected O, but got I
		//IL_0324: Expected O, but got I
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Expected O, but got Unknown
		//IL_0358: Expected F4, but got I4
		//IL_03e6->IL036e: Incompatible stack heights: 1 vs 0
		//IL_0108->IL0421: Incompatible stack heights: 3 vs 2
		//IL_0142->IL05d7: Incompatible stack heights: 3 vs 2
		//IL_0369->IL0573: Incompatible stack heights: 4 vs 2
		//IL_036e->IL0420: Incompatible stack heights: 4 vs 2
		if ((object)this.sprite != null)
		{
			Texture2D texture = this.sprite.texture;
			Blitter blitter = Blitter.CreateBlitter(BlendMode.Normal, texture);
			_blitter = blitter;
			Sprite sprite = null;
			if ((object)_blitter != null)
			{
				Transform transform = _blitter.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					float value = default(float);
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
					Transform transform2 = base.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret);
						UnityEngine.Random.InitState(999);
						if (count <= 0)
						{
							return;
						}
						object obj = 0;
						Vector2 vector = default(Vector2);
						float num = (float)vector;
						float num2 = -9.66f;
						Vector2 vector2 = (Vector2)(&ret);
						object obj2 = 999;
						float saturationMax = default(float);
						float valueMin = default(float);
						float valueMax = default(float);
						float alphaMin = default(float);
						bool flag10;
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
								bool flag3 = obj3 == null;
								obj2 = 6573110936L;
							}
							object obj4 = spawnRange ^ -0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1216 @ rax_v46 (should have been resolved before IL gen)");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
								bool flag4 = obj5 == null;
								obj2 = 6573110936L;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.TestBobs)+34]");
							object obj6 = 0 ^ -0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1241 @ rax_v49 (should have been resolved before IL gen)");
							bool flag5 = (object)_blitter == null;
							sprite = this.sprite;
							Bob bob = _blitter.CreateBob(vector, this.sprite);
							Color color = UnityEngine.Random.ColorHSV(0f, 1f, 0.5f, saturationMax, valueMin, valueMax, alphaMin, 1f);
							float num3 = ((0f > color.r) ? 0f : ((color.r > 1f) ? 1f : color.r));
							float num4 = num3 * 255f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
							float num5;
							if (0 <= (nint)vector)
							{
								bool flag6 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
								num5 = (float)vector;
								if (!flag6)
								{
									num5 = 1f;
								}
							}
							else
							{
								num5 = 0f;
							}
							float num6 = num5 * 255f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
							float num7;
							if (0 <= (nint)vector)
							{
								bool flag7 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
								num7 = (float)vector;
								if (!flag7)
								{
									num7 = 1f;
								}
							}
							else
							{
								num7 = 0f;
							}
							float num8 = num7 * 255f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
							float num9;
							if (0 <= (nint)vector)
							{
								bool flag8 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
								num9 = (float)vector;
								if (!flag8)
								{
									num9 = 1f;
								}
							}
							else
							{
								num9 = 0f;
							}
							float num10 = num9 * 255f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm9\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm10\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm11\"");
							bool flag9 = bob == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v51 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v51 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
							object obj8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v51 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
							object obj9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1265 @ rax_v51 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
							obj2 = 0;
							obj++;
							flag10 = (nint)obj < count;
							num = num10;
							num2 = 0f;
							vector2 = vector;
						}
						while (flag10);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected void OnDestroy()
	{
		GameObject obj = _blitter.gameObject;
		UnityEngine.Object.Destroy(obj, 0f);
	}

	public TestBobs()
	{
		//IL_0016: Expected O, but got I4
		//IL_0031: Expected I, but got O
		count = 1000;
		spawnRange = (Vector2)1073741824;
		_ = 1073741824;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
