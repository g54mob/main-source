using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;

namespace VampireSurvivors.Tools;

public class VertexReplacer : MonoBehaviour
{
	private Mesh _MeshToReplace;

	private SpriteRenderer _sprite;

	private void Replace()
	{
		//IL_005c: Expected I, but got O
		//IL_0065: Expected O, but got I4
		//IL_006a: Expected I, but got O
		//IL_007b: Expected O, but got I4
		//IL_02a6: Expected O, but got I4
		//IL_02ab: Expected I, but got O
		//IL_02b4: Expected O, but got I4
		//IL_02b9: Expected I, but got O
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_0116: Expected O, but got I
		//IL_01cb: Expected O, but got I
		//IL_018a: Expected O, but got I
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected O, but got Unknown
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Expected O, but got Unknown
		//IL_066c: Expected O, but got I
		//IL_04ef: Expected I, but got O
		//IL_037b: Expected O, but got I
		//IL_0430: Expected O, but got I
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f6: Expected O, but got Unknown
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0472: Expected O, but got Unknown
		//IL_0654->IL0568: Incompatible stack heights: 1 vs 0
		//IL_0519->IL0568: Incompatible stack heights: 1 vs 0
		//IL_0551->IL0568: Incompatible stack heights: 1 vs 0
		SpriteRenderer component = GetComponent<SpriteRenderer>();
		_sprite = component;
		List<Vector2> list = new List<Vector2>();
		bool flag = (object)_MeshToReplace == null;
		nint num = 0;
		if (!flag)
		{
			Vector3[] vertices = _MeshToReplace.vertices;
			bool flag2 = vertices == null;
			num = unchecked((nint)null);
			object obj = 0;
			nint num2 = unchecked((nint)null);
			nint num4 = default(nint);
			nint num3 = num4;
			object obj2 = 0;
			if (!flag2)
			{
				IntPtr intPtr = default(IntPtr);
				while (true)
				{
					if ((nint)obj2 < vertices.Length)
					{
						if ((nint)obj < vertices.Length)
						{
							object obj3 = obj * 2;
							object obj4 = obj + obj3;
							bool flag3 = list == null;
							num = num2;
							num4 = num3;
							if (flag3)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
							num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
							bool flag4 = (nint)0 == 0;
							num4 = 0;
							if (flag4)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
							nint num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rcx_v40+18]");
							if (num5 >= 0)
							{
								list.AddWithResize((Vector2)(nint)intPtr);
								obj++;
								num2 = intPtr;
								num3 = 0;
								obj2 = obj;
								continue;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
							object obj6 = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rcx_v40+18]");
							if (num6 < 0)
							{
								obj++;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v18 (UnityEngine.Vector3[])+20+v204 @ rax_v45*4]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v4 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
								num2 = 0;
								num3 = 0;
								obj2 = obj;
								continue;
							}
						}
					}
					else
					{
						List<ushort> list2 = new List<ushort>();
						bool flag5 = (object)_MeshToReplace == null;
						num = 0;
						num4 = num3;
						if (flag5)
						{
							break;
						}
						int[] triangles = _MeshToReplace.triangles;
						bool flag6 = triangles == null;
						object obj7 = 0;
						nint num7 = unchecked((nint)null);
						object obj8 = 0;
						num = unchecked((nint)null);
						num4 = num3;
						if (flag6)
						{
							break;
						}
						while (true)
						{
							if ((nint)obj8 < triangles.Length)
							{
								if ((nint)obj7 >= triangles.Length)
								{
									break;
								}
								bool flag7 = triangles[obj7] > 65535;
								num = num7;
								num4 = num3;
								if (!flag7)
								{
									bool flag8 = list2 == null;
									num = num7;
									num4 = num3;
									if (flag8)
									{
										goto end_IL_0594;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rax_v21 (System.Collections.Generic.List`1<System.UInt16>)+1C]");
									_ = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rax_v21 (System.Collections.Generic.List`1<System.UInt16>)+10]");
									num4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rax_v21 (System.Collections.Generic.List`1<System.UInt16>)+18]");
									object obj9 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rax_v21 (System.Collections.Generic.List`1<System.UInt16>)+10]");
									bool flag9 = (nint)0 == 0;
									num = 0;
									if (flag9)
									{
										goto end_IL_0594;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rax_v21 (System.Collections.Generic.List`1<System.UInt16>)+18]");
									nint num8 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ r8_v3 (Il2CppMethodInfo)+18]");
									if (num8 >= 0)
									{
										list2.AddWithResize((ushort)triangles[obj7]);
										obj7++;
										num7 = triangles[obj7];
										num3 = 0;
										obj8 = obj7;
										continue;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rax_v21 (System.Collections.Generic.List`1<System.UInt16>)+18]");
									object obj10 = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rax_v21 (System.Collections.Generic.List`1<System.UInt16>)+18]");
									nint num9 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ r8_v3 (Il2CppMethodInfo)+18]");
									if (num9 >= 0)
									{
										break;
									}
									obj7++;
									_ = triangles[obj7];
									num7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rax_v21 (System.Collections.Generic.List`1<System.UInt16>)+10]");
									num3 = 0;
									obj8 = obj7;
									continue;
								}
								((List<Vector2>)(object)typeof(Convert)).Add((Vector2)num);
								Convert.ThrowUInt16OverflowException();
								break;
							}
							Vector3[] sprite = (Vector3[])(object)_sprite;
							bool flag10 = (object)_sprite == null;
							num = num7;
							num4 = num3;
							if (flag10)
							{
								goto end_IL_0594;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rdi_v8 (UnityEngine.Vector3[])+10]");
							bool flag11 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rdi_v8 (UnityEngine.Vector3[])+10]");
							IntPtr gcHandlePtr = SpriteRenderer.get_sprite_Injected((IntPtr)0);
							Sprite sprite2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Sprite>(gcHandlePtr);
							bool flag12 = list == null;
							num = 0;
							num4 = num3;
							if (flag12)
							{
								goto end_IL_0594;
							}
							Sprite vertices2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Sprite>((IntPtr)list);
							bool flag13 = list2 == null;
							num = 0;
							num4 = num3;
							if (flag13)
							{
								goto end_IL_0594;
							}
							ushort[] triangles2 = list2.ToArray();
							bool flag14 = (object)sprite2 == null;
							num = 0;
							num4 = num3;
							if (flag14)
							{
								goto end_IL_0594;
							}
							sprite2.OverrideGeometry((Vector2[])(object)vertices2, triangles2);
							return;
						}
					}
					throw new IndexOutOfRangeException();
					continue;
					end_IL_0594:
					break;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void Start()
	{
		Replace();
	}

	private void Update()
	{
	}

	public VertexReplacer()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
