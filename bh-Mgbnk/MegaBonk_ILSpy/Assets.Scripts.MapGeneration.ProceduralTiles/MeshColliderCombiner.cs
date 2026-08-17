using System;
using System.Collections.Generic;
using System.Diagnostics;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.MapGeneration.ProceduralTiles;

public class MeshColliderCombiner
{
	public unsafe static GameObject CombineMeshes(List<GameObject> pieces)
	{
		//IL_047c: Expected O, but got I4
		//IL_00f7: Expected O, but got I4
		//IL_01d0: Expected O, but got Ref
		//IL_0200: Expected O, but got Ref
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected O, but got Unknown
		List<MeshCollider> list = new List<MeshCollider>();
		if (pieces != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			GameObject gameObject = default(GameObject);
			while (enumerator.MoveNext())
			{
				if ((object)gameObject != null)
				{
					MeshCollider component = gameObject.GetComponent<MeshCollider>();
					if (component != null)
					{
						if (list == null)
						{
							throw new NullReferenceException();
						}
						list.Add(component);
					}
					continue;
				}
				throw new NullReferenceException();
			}
			((List<GameObject>.Enumerator*)(&enumerator))->Dispose();
			List<CombineInstance> list2 = new List<CombineInstance>();
			bool flag = list == null;
			CombineInstance combineInstance = (CombineInstance)0;
			int num = 0;
			int num2 = 0;
			if (!flag)
			{
				float m = default(float);
				CombineInstance combineInstance2 = default(CombineInstance);
				List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
				while (true)
				{
					if (num2 < list._size)
					{
						MeshCollider meshCollider = list.get_Item(num);
						bool flag2 = (object)meshCollider == null;
						object obj = 0;
						if (flag2)
						{
							break;
						}
						while (true)
						{
							Mesh sharedMesh = meshCollider.sharedMesh;
							if ((object)sharedMesh == null)
							{
								break;
							}
							int subMeshCount = sharedMesh.subMeshCount;
							if ((nint)obj < subMeshCount)
							{
								Mesh sharedMesh2 = meshCollider.sharedMesh;
								combineInstance.mesh = sharedMesh2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805F68E0");
								Transform transform = meshCollider.transform;
								if ((object)transform == null)
								{
									break;
								}
								Matrix4x4 localToWorldMatrix = transform.localToWorldMatrix;
								combineInstance.transform = (Matrix4x4)(&m);
								if (list2 == null)
								{
									break;
								}
								list2.Add((CombineInstance)(&combineInstance2));
								obj++;
								m = localToWorldMatrix.m00;
								continue;
							}
							goto IL_022e;
						}
						break;
					}
					GameObject gameObject2 = new GameObject();
					if ((object)gameObject2 == null)
					{
						break;
					}
					gameObject2.name = "CombinedCollisionMesh";
					MeshFilter meshFilter = gameObject2.AddComponent<MeshFilter>();
					Mesh mesh = new Mesh();
					if (list2 == null)
					{
						break;
					}
					CombineInstance[] combine = list2.ToArray();
					if ((object)mesh == null)
					{
						break;
					}
					mesh.CombineMeshes(combine, mergeSubMeshes: true);
					AutoWeld(mesh, 0.25f);
					if ((object)meshFilter == null)
					{
						break;
					}
					meshFilter.mesh = mesh;
					MeshCollider meshCollider2 = gameObject2.AddComponent<MeshCollider>();
					if ((object)meshCollider2 == null)
					{
						break;
					}
					meshCollider2.sharedMesh = mesh;
					gameObject2.SetActive(value: true);
					int layer = LayerMask.NameToLayer("Ground");
					gameObject2.layer = layer;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
					while (enumerator2.MoveNext())
					{
						UnityEngine.Object.Destroy(gameObject);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
					return gameObject2;
					IL_022e:
					num++;
					num2 = num;
				}
			}
		}
		throw new NullReferenceException();
	}

	private static void AutoWeld(Mesh mesh, float threshold)
	{
		//IL_0063: Expected O, but got I4
		//IL_0068: Expected I, but got O
		//IL_0071: Expected O, but got I4
		//IL_02d7: Expected O, but got I4
		//IL_02e0: Expected O, but got I4
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01e5: Expected O, but got I
		//IL_01f3: Expected O, but got I
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_009b: Expected I, but got O
		//IL_00ae: Expected O, but got I
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00f3: Expected O, but got I
		//IL_0110: Expected O, but got I
		//IL_012d: Expected O, but got I
		//IL_0374: Expected O, but got I4
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Expected O, but got Unknown
		//IL_0391: Expected O, but got I4
		//IL_03a0: Expected O, but got I4
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ae: Expected O, but got Unknown
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		Stopwatch stopwatch = Stopwatch.StartNew();
		Vector3[] vertices = mesh.vertices;
		Vector3[] array = new Vector3[vertices.Length];
		int[] array2 = new int[vertices.Length];
		float num = threshold;
		int num2 = 0;
		object obj = 0;
		nint num3 = unchecked((nint)null);
		object obj2 = 0;
		while ((nint)obj2 < vertices.Length)
		{
			Vector3 vector;
			nint num4;
			if (num3 > 0)
			{
				num4 = unchecked((nint)null);
				while (true)
				{
					object obj3 = num4 * 2;
					object obj4 = num4 + obj3;
					object obj5 = obj * 2;
					object obj6 = obj + obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v9 (UnityEngine.Vector3[])+20+v128 @ rdx_v33*4]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v8 (UnityEngine.Vector3[])+20+v149 @ rcx_v39*4]");
					object obj7 = num5 - 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v9 (UnityEngine.Vector3[])+24+v128 @ rdx_v33*4]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v8 (UnityEngine.Vector3[])+24+v149 @ rcx_v39*4]");
					object obj8 = num6 - 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v9 (UnityEngine.Vector3[])+28+v128 @ rdx_v33*4]");
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v8 (UnityEngine.Vector3[])+28+v149 @ rcx_v39*4]");
					object obj9 = num7 - 0;
					object obj10 = obj8 * obj8;
					num = (float)obj7 * (float)obj7;
					vector = (Vector3)(obj9 * obj9);
					float num8 = (float)obj10 + num;
					float num9 = num8 + (float)vector;
					if (threshold > num9)
					{
						break;
					}
					num4++;
					if (num4 < num3)
					{
						continue;
					}
					goto IL_01ba;
				}
				object obj11 = obj + 1;
				array2[obj] = (int)num4;
				obj = obj11;
				num3 = num2;
				obj2 = obj11;
				continue;
			}
			goto IL_01ba;
			IL_01ba:
			object obj12 = obj * 2;
			object obj13 = obj + obj12;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v8 (UnityEngine.Vector3[])+20+v148 @ rcx_v36*4]");
			vector = (Vector3)0;
			object obj14 = num3 * 2;
			object obj15 = num3 + obj14;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v8 (UnityEngine.Vector3[])+20+v148 @ rcx_v36*4]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v8 (UnityEngine.Vector3[])+28+v148 @ rcx_v36*4]");
			_ = 0;
			array2[obj] = num2;
			int num10 = num2 + 1;
			obj++;
			num4 = num3;
			num2 = num10;
			num3 = num10;
			obj2 = obj;
		}
		int[] triangles = mesh.triangles;
		int[] array3 = new int[triangles.Length];
		object obj16 = 0;
		object obj17 = 0;
		while ((nint)obj17 < triangles.Length)
		{
			int num11 = triangles[obj16];
			object obj18 = obj16 + 1;
			array3[obj16] = array2[num11];
			obj16 = obj18;
			obj17 = obj18;
		}
		Vector3[] vertices2 = new Vector3[num2];
		if (num2 > 0)
		{
			object obj21;
			do
			{
				object obj19 = 0 * 2;
				object obj20 = 0 + obj19;
				obj21 = 0 + 1;
				object obj22 = 0 * 2;
				object obj23 = 0 + obj22;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v9 (UnityEngine.Vector3[])+20+v696 @ rcx_v31*4]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v9 (UnityEngine.Vector3[])+28+v696 @ rcx_v31*4]");
				_ = 0;
			}
			while ((nint)obj21 < num2);
		}
		mesh.Clear();
		mesh.vertices = vertices2;
		mesh.triangles = array3;
		mesh.RecalculateNormals();
		mesh.Optimize();
		stopwatch.Stop();
		int num12 = default(int);
		string text = num12.ToString();
		string text2 = num2.ToString();
		string text3 = "oldverts: " + text + ", new size: " + text2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
		long num13 = default(long);
		string text4 = num13.ToString();
		string text5 = "Optimizing mesh time: " + text4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}

	private unsafe static void SimplifyMesh(Mesh mesh)
	{
		//IL_0541: Expected O, but got Ref
		//IL_012e: Expected O, but got I4
		//IL_057a: Expected O, but got Ref
		//IL_0186: Expected O, but got I4
		//IL_059f: Expected O, but got Ref
		//IL_05be: Expected O, but got I4
		//IL_01e7: Expected O, but got I4
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected O, but got Unknown
		//IL_0213: Expected O, but got I
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Expected O, but got Unknown
		//IL_023e: Expected O, but got I
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_0270: Expected O, but got I
		//IL_028d: Expected O, but got I
		//IL_02aa: Expected O, but got I
		//IL_02c7: Expected O, but got I
		//IL_02e4: Expected O, but got I
		//IL_0301: Expected O, but got I
		//IL_0924: Expected I, but got O
		//IL_061c: Expected O, but got I4
		//IL_062d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0632: Expected O, but got Unknown
		//IL_0640: Expected O, but got Ref
		//IL_0649: Unknown result type (might be due to invalid IL or missing references)
		//IL_064e: Expected O, but got Unknown
		//IL_0400: Expected F8, but got I4
		//IL_0687: Expected O, but got I
		//IL_06c0: Expected O, but got Ref
		//IL_06c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ce: Expected O, but got Unknown
		//IL_0460: Expected O, but got Ref
		//IL_0707: Expected O, but got I
		//IL_04ac: Expected O, but got Ref
		//IL_0755: Expected O, but got Ref
		//IL_0492: Expected O, but got Ref
		//IL_07f8: Expected O, but got I
		Mesh mesh2 = default(Mesh);
		if ((object)mesh2 != null)
		{
			Vector3[] vertices = mesh2.vertices;
			int[] triangles = mesh2.triangles;
			Vector3[] normals = mesh2.normals;
			List<Vector3> list = new List<Vector3>();
			List<int> list2 = new List<int>();
			Dictionary<Vector3, List<int>> dictionary = (Dictionary<Vector3, List<int>>)(object)new Dictionary<Vector3, object>();
			if (triangles != null)
			{
				int num = 0;
				Dictionary<Vector3, List<int>> dictionary2 = dictionary;
				int num2 = 0;
				Vector3 vector2 = default(Vector3);
				object obj28 = default(object);
				object obj29 = default(object);
				Vector3 vector3 = default(Vector3);
				Dictionary<Vector3, List<int>>.Enumerator enumerator = default(Dictionary<Vector3, List<int>>.Enumerator);
				object obj31 = default(object);
				List<int>.Enumerator enumerator3 = default(List<int>.Enumerator);
				object obj32 = default(object);
				Mesh mesh3 = default(Mesh);
				while (true)
				{
					if (num2 < triangles.Length)
					{
						if (num < triangles.Length)
						{
							if (vertices == null)
							{
								break;
							}
							if (triangles[num] < vertices.Length)
							{
								object obj = num + 1;
								if ((nint)obj < triangles.Length)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rax_v31 (System.Int32[])+24+v1287 @ r14_v17 (System.Int32)*4]");
									if ((nint)0 < (nint)vertices.Length)
									{
										object obj2 = num + 2;
										if ((nint)obj2 < triangles.Length)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rax_v31 (System.Int32[])+28+v1287 @ r14_v17 (System.Int32)*4]");
											if ((nint)0 < (nint)vertices.Length)
											{
												object obj3 = triangles[num] * 2;
												object obj4 = triangles[num] + obj3;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rax_v31 (System.Int32[])+24+v1287 @ r14_v17 (System.Int32)*4]");
												object obj5 = (nint)0 * (nint)2;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rax_v31 (System.Int32[])+24+v1287 @ r14_v17 (System.Int32)*4]");
												object obj6 = 0 + obj5;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rax_v31 (System.Int32[])+28+v1287 @ r14_v17 (System.Int32)*4]");
												object obj7 = (nint)0 * (nint)2;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rax_v31 (System.Int32[])+28+v1287 @ r14_v17 (System.Int32)*4]");
												object obj8 = 0 + obj7;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v30 (UnityEngine.Vector3[])+20+v1425 @ rcx_v49*4]");
												nint num3 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v30 (UnityEngine.Vector3[])+20+v1420 @ rcx_v48*4]");
												object obj9 = num3 - 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v30 (UnityEngine.Vector3[])+24+v1425 @ rcx_v49*4]");
												nint num4 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v30 (UnityEngine.Vector3[])+24+v1420 @ rcx_v48*4]");
												object obj10 = num4 - 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v30 (UnityEngine.Vector3[])+28+v1425 @ rcx_v49*4]");
												nint num5 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v30 (UnityEngine.Vector3[])+28+v1420 @ rcx_v48*4]");
												object obj11 = num5 - 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v30 (UnityEngine.Vector3[])+20+v217 @ rdx_v41*4]");
												nint num6 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v30 (UnityEngine.Vector3[])+20+v1420 @ rcx_v48*4]");
												object obj12 = num6 - 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v30 (UnityEngine.Vector3[])+24+v217 @ rdx_v41*4]");
												nint num7 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v30 (UnityEngine.Vector3[])+24+v1420 @ rcx_v48*4]");
												object obj13 = num7 - 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v30 (UnityEngine.Vector3[])+28+v217 @ rdx_v41*4]");
												nint num8 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v30 (UnityEngine.Vector3[])+28+v1420 @ rcx_v48*4]");
												object obj14 = num8 - 0;
												object obj15 = obj14 * obj10;
												object obj16 = obj13 * obj11;
												object obj17 = obj15 - obj16;
												object obj18 = obj12 * obj11;
												object obj19 = obj14 * obj9;
												object obj20 = obj18 - obj19;
												object obj21 = obj13 * obj9;
												object obj22 = obj12 * obj10;
												object obj23 = obj21 - obj22;
												nint num9 = (nint)typeof(Math);
												object obj24 = obj20 * obj20;
												object obj25 = obj17 * obj17;
												object obj26 = obj24 + obj25;
												object obj27 = obj23 * obj23;
												double d = (double)obj26 + (double)obj27;
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm3\"");
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1467 @ rcx_v51 (Il2CppClass<System.Math>)+E4]");
												double num10;
												if ((nint)0 <= (nint)0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm3\"");
													num10 = 0.0;
												}
												else
												{
													num10 = Math.Sqrt(d);
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
												Vector3 vector = ((!(num10 > 9.999999747378752E-06)) ? Vector3.zeroVector : vector2);
												if (dictionary2 == null)
												{
													break;
												}
												if (!((Dictionary<Vector3, object>)(object)dictionary2).ContainsKey((Vector3)(&obj28)))
												{
													List<int> value = new List<int>();
													((Dictionary<Vector3, object>)(object)dictionary).set_Item((Vector3)(&obj29), (object)value);
													dictionary2 = dictionary;
												}
												object obj30 = ((Dictionary<Vector3, object>)(object)dictionary2).get_Item((Vector3)(&vector3));
												if (obj30 == null)
												{
													break;
												}
												((List<int>)obj30).Add(num);
												num += 3;
												vector3 = vector;
												num2 = num;
												continue;
											}
										}
									}
								}
							}
						}
						throw new IndexOutOfRangeException();
					}
					if (dictionary2 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D4D7E0");
					while (enumerator.MoveNext())
					{
						bool flag = obj31 == null;
						List<int>.Enumerator enumerator2 = (List<int>.Enumerator)(&enumerator);
						if (!flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18115DC70");
							while (enumerator3.MoveNext())
							{
								bool flag2 = (nint)obj32 >= triangles.Length;
								enumerator2 = (List<int>.Enumerator)(&enumerator3);
								if (!flag2)
								{
									bool flag3 = vertices == null;
									enumerator2 = (List<int>.Enumerator)(&enumerator3);
									if (!flag3)
									{
										enumerator2 = (List<int>.Enumerator)triangles[obj32];
										if (triangles[obj32] < vertices.Length)
										{
											if (list != null)
											{
												object obj33 = triangles[obj32] * 2;
												object obj34 = triangles[obj32] + obj33;
												list.Add((Vector3)(&vector3));
												object obj35 = obj32 + 1;
												bool flag4 = (nint)obj35 >= triangles.Length;
												enumerator2 = (List<int>.Enumerator)list;
												if (!flag4)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rax_v31 (System.Int32[])+24+v1280 @ stack_-C0*4]");
													enumerator2 = (List<int>.Enumerator)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rax_v31 (System.Int32[])+24+v1280 @ stack_-C0*4]");
													if ((nint)0 < (nint)vertices.Length)
													{
														list.Add((Vector3)(&obj29));
														object obj36 = obj32 + 2;
														bool flag5 = (nint)obj36 >= triangles.Length;
														enumerator2 = (List<int>.Enumerator)list;
														if (!flag5)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rax_v31 (System.Int32[])+28+v1280 @ stack_-C0*4]");
															enumerator2 = (List<int>.Enumerator)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rax_v31 (System.Int32[])+28+v1280 @ stack_-C0*4]");
															if ((nint)0 < (nint)vertices.Length)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rax_v31 (System.Int32[])+28+v1280 @ stack_-C0*4]");
																bool flag6 = (byte)((nuint)0u * (nuint)2u) != 0;
																list.Add((Vector3)(&obj28));
																bool flag7 = list2 == null;
																enumerator2 = (List<int>.Enumerator)list;
																if (!flag7)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v470 @ rax_v33 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
																	int item = (int)(-3);
																	list2.Add(item);
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v470 @ rax_v33 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
																	int item2 = (int)(-2);
																	list2.Add(item2);
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v470 @ rax_v33 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
																	int item3 = (int)(-1);
																	list2.Add(item3);
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v30 (UnityEngine.Vector3[])+20+v1581 @ rax_v56*4]");
																	vector3 = (Vector3)0;
																	continue;
																}
																throw new NullReferenceException();
															}
															throw new IndexOutOfRangeException();
														}
														throw new IndexOutOfRangeException();
													}
													throw new IndexOutOfRangeException();
												}
												throw new IndexOutOfRangeException();
											}
											throw new NullReferenceException();
										}
										throw new IndexOutOfRangeException();
									}
									throw new NullReferenceException();
								}
								throw new IndexOutOfRangeException();
							}
							enumerator3.Dispose();
							continue;
						}
						throw new NullReferenceException();
					}
					enumerator.Dispose();
					mesh3.Clear();
					if (list == null)
					{
						break;
					}
					Vector3[] vertices2 = list.ToArray();
					mesh3.vertices = vertices2;
					if (list2 == null)
					{
						break;
					}
					int[] triangles2 = list2.ToArray();
					mesh3.triangles = triangles2;
					mesh3.RecalculateNormals();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}
}
