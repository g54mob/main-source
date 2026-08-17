using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Rendering;

public class GrassChunkManager : MonoBehaviour
{
	private struct GrassInstance
	{
		public Vector3 position;

		public float rotationY;
	}

	private struct GrassData
	{
		public Matrix4x4 transform;
	}

	public Mesh grassMesh;

	public Material grassMaterial;

	public int grassPerChunk = 500;

	public int chunkSize = 16;

	public int renderDistance = 3;

	public float yThreshold = 7f;

	public LayerMask layerMask;

	public bool testWithoutPlayer;

	private int currentGrassPerChunk;

	private Vector2Int currentChunk;

	private Dictionary<Vector2Int, List<GrassInstance>> precomputedGrassPositions;

	private List<GrassData> allGrassDataList;

	private ComputeBuffer allGrassBuffer;

	private ComputeBuffer argsBuffer;

	private readonly uint[] args;

	public void Set(Material material, int grassPerChunk)
	{
		grassMaterial = material;
		this.grassPerChunk = grassPerChunk;
	}

	private void Awake()
	{
		//IL_0124: Expected I, but got O
		//IL_008a: Expected I, but got O
		//IL_00a2: Expected I, but got O
		Action<string, object, object> b = OnSettingUpdated;
		Delegate obj = Delegate.Combine(CurrentSettings.A_SettingUpdated, b);
		nint num;
		if ((object)obj == null)
		{
			CurrentSettings.A_SettingUpdated = (Action<string, object, object>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string, object, object> action = default(Action<string, object, object>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<string, object, object>);
				goto IL_0139;
			}
			CurrentSettings.A_SettingUpdated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			num = (nint)typeof(Action<string, object, object>);
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				return;
			}
		}
		num = (nint)args;
		currentGrassPerChunk = grassPerChunk;
		if (args != null)
		{
			int stride = default(int);
			ComputeBuffer computeBuffer = new ComputeBuffer(1, stride, ComputeBufferType.DrawIndirect);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rdi_v3 (Il2CppClass<System.Action`3<System.String, System.Object, System.Object>>)+18]");
			stride = (int)((nint)0 << 2);
			argsBuffer = computeBuffer;
			return;
		}
		goto IL_0139;
		IL_0139:
		throw new NullReferenceException();
	}

	private void Start()
	{
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null && saveManager.config != null)
		{
			SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager2.config;
			CFVideoSettings cfVideoSettings = config.cfVideoSettings;
			UpdateGrassQuality(cfVideoSettings.grass_quality);
		}
	}

	private unsafe void Update()
	{
		//IL_0202: Expected O, but got Ref
		//IL_0068: Expected O, but got Ref
		//IL_01ca: Expected I4, but got O
		//IL_01ca: Expected O, but got Ref
		float x = default(float);
		if (!testWithoutPlayer)
		{
			if (!(PlayerCamera.Instance != null))
			{
				return;
			}
			Transform transform = base.transform;
			Transform transform2 = PlayerCamera.Instance.transform;
			Vector3 position = transform2.position;
			transform.position = (Vector3)(&x);
			x = position.x;
		}
		Vector2Int playerChunk = GetPlayerChunk();
		if ((object)playerChunk == (object)currentChunk)
		{
			object obj = (object)currentChunk >> 32;
			object obj2 = (object)playerChunk >> 32;
			if (obj2 == obj)
			{
				goto IL_0256;
			}
		}
		currentChunk = playerChunk;
		UpdateChunks();
		goto IL_0256;
		IL_0256:
		if (allGrassBuffer != null)
		{
			List<GrassData> list = allGrassDataList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ rax_v16 (System.Collections.Generic.List`1<GrassChunkManager+GrassData>)+18]");
			if ((nint)0 != 0)
			{
				MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
				materialPropertyBlock.SetBuffer("_GrassBuffer", allGrassBuffer);
				grassMaterial.SetBuffer("_GrassBuffer", allGrassBuffer);
				Transform transform3 = base.transform;
				Vector3 position2 = transform3.position;
				object obj3 = default(object);
				ComputeBuffer bufferWithArgs = default(ComputeBuffer);
				int argsOffset = default(int);
				MaterialPropertyBlock properties = default(MaterialPropertyBlock);
				ShadowCastingMode castShadows = default(ShadowCastingMode);
				Graphics.DrawMeshInstancedIndirect(grassMesh, 0, grassMaterial, (Bounds)(&obj3), bufferWithArgs, argsOffset, properties, castShadows, (byte)(int)argsBuffer != 0, 0, (Camera)(object)materialPropertyBlock);
				x = position2.x;
			}
		}
		Transform transform4 = base.transform;
		Vector3 position3 = transform4.position;
		grassMaterial.SetVector("_PlayerPos", (Vector4)(&x));
		float value = (float)renderDistance * (float)chunkSize;
		grassMaterial.SetFloat("_RenderDistance", value);
	}

	private Vector2Int GetPlayerChunk()
	{
		//IL_0061: Expected O, but got F8
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Vector3 position = transform.position;
			float num = position.x / (float)chunkSize;
			double num2 = Math.Floor(num);
			float num3 = position.z / (float)chunkSize;
			double num4 = Math.Floor(num3);
			return (Vector2Int)num2;
		}
		return (Vector2Int)new NullReferenceException();
	}

	private void UpdateChunks()
	{
		//IL_029a: Expected I, but got O
		//IL_0132: Expected I, but got O
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Expected O, but got Unknown
		List<Vector2Int> list = new List<Vector2Int>();
		if (precomputedGrassPositions != null)
		{
			Dictionary<Vector2Int, List<GrassInstance>>.KeyCollection keys = precomputedGrassPositions.Keys;
			if (keys != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
				Dictionary<Vector2Int, List<GrassInstance>>.KeyCollection.Enumerator enumerator = default(Dictionary<Vector2Int, List<GrassInstance>>.KeyCollection.Enumerator);
				Vector2Int vector2Int = default(Vector2Int);
				object obj4 = default(object);
				while (enumerator.MoveNext())
				{
					object obj = (object)vector2Int >> 32;
					nint num = (nint)typeof(Math);
					object obj2 = vector2Int - currentChunk;
					object obj3 = obj - obj4;
					object obj5 = obj3 * obj3;
					object obj6 = obj2 * obj2;
					double d = (double)obj6 + (double)obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm2\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rcx_v27 (Il2CppClass<System.Math>)+E4]");
					if ((nint)0 <= (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm2\"");
					}
					else
					{
						double num2 = Math.Sqrt(d);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
					if (0 > renderDistance)
					{
						bool flag = list == null;
						nint num3 = (nint)typeof(Math);
						if (flag)
						{
							throw new NullReferenceException();
						}
						list.Add(vector2Int);
					}
				}
				enumerator.Dispose();
				if (list != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
					List<Vector2Int>.Enumerator enumerator2 = default(List<Vector2Int>.Enumerator);
					while (enumerator2.MoveNext())
					{
						if (precomputedGrassPositions != null)
						{
							bool flag2 = ((Dictionary<Vector2Int, object>)(object)precomputedGrassPositions).Remove(vector2Int);
							continue;
						}
						throw new NullReferenceException();
					}
					enumerator2.Dispose();
					int num4 = -renderDistance;
					if (num4 > renderDistance)
					{
						goto IL_024f;
					}
					bool flag4 = default(bool);
					while (true)
					{
						int num5 = -renderDistance;
						if (num5 <= renderDistance)
						{
							while (true)
							{
								GrassChunkManager grassChunkManager = (GrassChunkManager)(currentChunk + num4);
								if (precomputedGrassPositions == null)
								{
									break;
								}
								if (!((Dictionary<Vector2Int, object>)(object)precomputedGrassPositions).ContainsKey((Vector2Int)grassChunkManager))
								{
									GenerateGrassForChunk((Vector2Int)grassChunkManager);
									bool flag3 = flag4;
								}
								num5++;
								if (num5 <= renderDistance)
								{
									continue;
								}
								goto IL_0220;
							}
							break;
						}
						goto IL_0220;
						IL_0220:
						num4++;
						if (num4 <= renderDistance)
						{
							continue;
						}
						goto IL_024f;
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_024f:
		RebuildGrassBuffer();
	}

	private unsafe void GenerateGrassForChunk(Vector2Int chunkCoord)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0016: Expected O, but got I4
		//IL_02ac: Expected F4, but got I4
		//IL_02c2: Expected F4, but got I4
		//IL_0035: Expected O, but got Ref
		//IL_0035: Expected O, but got Ref
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Expected O, but got Unknown
		//IL_00c3: Expected O, but got Ref
		//IL_00ed: Invalid comparison between F4 and I
		//IL_011d: Invalid comparison between F4 and I
		//IL_0177: Expected O, but got I
		//IL_01d0: Expected O, but got I
		//IL_01f0: Expected O, but got I
		//IL_01b5: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		List<GrassInstance> list = new List<GrassInstance>();
		if (currentGrassPerChunk > 0)
		{
			object obj3 = 0;
			float num3 = default(float);
			Vector3 downVector = default(Vector3);
			int num4 = default(int);
			float num9 = default(float);
			bool flag;
			do
			{
				float num = UnityEngine.Random.Range(0f, chunkSize);
				float num2 = UnityEngine.Random.Range(0f, chunkSize);
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
				if (Physics.Raycast((Vector3)(&num3), (Vector3)(&downVector), out var hitInfo, 9999f, num4))
				{
					Collider collider = hitInfo.collider;
					GameObject gameObject = collider.gameObject;
					int layer = gameObject.layer;
					int num5 = LayerMask.NameToLayer("Ground");
					if (layer == num5)
					{
						object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE090");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v29+4]");
						if (!((float)Math.PI * 29f / 180f > 0f))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
							float num6 = yThreshold;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v622 @ rax_v31+4]");
							if (!(num6 > 0f))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
								float num7 = UnityEngine.Random.Range(0f, 360f);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v2 (System.Collections.Generic.List`1<GrassChunkManager+GrassInstance>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v2 (System.Collections.Generic.List`1<GrassChunkManager+GrassInstance>)+10]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v2 (System.Collections.Generic.List`1<GrassChunkManager+GrassInstance>)+18]");
								nint num8 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rcx_v24+18]");
								if (num8 >= 0)
								{
									list.AddWithResize((GrassInstance)(&num9));
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v2 (System.Collections.Generic.List`1<GrassChunkManager+GrassInstance>)+18]");
									object obj6 = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v2 (System.Collections.Generic.List`1<GrassChunkManager+GrassInstance>)+18]");
									object obj7 = (nint)0 + (nint)2;
									object obj8 = obj7 + obj7;
								}
							}
						}
					}
				}
				obj3++;
				flag = (nint)obj3 < currentGrassPerChunk;
				downVector = Vector3.downVector;
			}
			while (flag);
		}
		((Dictionary<Vector2Int, object>)(object)precomputedGrassPositions).set_Item(chunkCoord, (object)list);
	}

	private unsafe void RebuildGrassBuffer()
	{
		//IL_0559: Expected O, but got Ref
		//IL_00b5: Expected O, but got Ref
		//IL_00e5: Expected O, but got Ref
		//IL_04bb: Expected O, but got Ref
		//IL_04bb: Expected O, but got Ref
		//IL_04bb: Expected O, but got Ref
		//IL_010d: Expected O, but got Ref
		//IL_0136: Expected O, but got I4
		Dictionary<Vector2Int, List<GrassInstance>> dictionary = (Dictionary<Vector2Int, List<GrassInstance>>)(object)allGrassDataList;
		if (allGrassDataList != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rcx_v6 (System.Collections.Generic.Dictionary`2<UnityEngine.Vector2Int, System.Collections.Generic.List`1<GrassChunkManager+GrassInstance>>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			dictionary = precomputedGrassPositions;
			if (precomputedGrassPositions != null)
			{
				Dictionary<Vector2Int, List<GrassInstance>>.ValueCollection values = precomputedGrassPositions.Values;
				if (values != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
					Dictionary<Vector2Int, List<GrassInstance>>.ValueCollection.Enumerator enumerator = default(Dictionary<Vector2Int, List<GrassInstance>>.ValueCollection.Enumerator);
					object obj = default(object);
					float num = default(float);
					List<GrassInstance>.Enumerator enumerator2 = default(List<GrassInstance>.Enumerator);
					object obj2 = default(object);
					float num2 = default(float);
					float num3 = default(float);
					Vector3 oneVector = default(Vector3);
					List<GrassInstance>.Enumerator enumerator3 = default(List<GrassInstance>.Enumerator);
					while (enumerator.MoveNext())
					{
						bool flag = obj == null;
						List<GrassData> list = (List<GrassData>)(&enumerator);
						if (!flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126FB0");
							num = num;
							while (enumerator2.MoveNext())
							{
								float x = Quaternion.Internal_FromEulerRad((Vector3)(&obj2)).x;
								Matrix4x4 matrix4x = Matrix4x4.TRS((Vector3)(&num2), (Quaternion)(&num3), (Vector3)(&oneVector));
								if (allGrassDataList != null)
								{
									allGrassDataList.Add((GrassData)(&enumerator3));
									num2 = num;
									oneVector = Vector3.oneVector;
									num = matrix4x.m01;
									obj2 = 0;
									continue;
								}
								throw new NullReferenceException();
							}
							enumerator2.Dispose();
							continue;
						}
						throw new NullReferenceException();
					}
					enumerator.Dispose();
					bool flag2 = allGrassBuffer == null;
					dictionary = (Dictionary<Vector2Int, List<GrassInstance>>)(&enumerator);
					if (!flag2)
					{
						allGrassBuffer.Dispose();
						dictionary = (Dictionary<Vector2Int, List<GrassInstance>>)(object)allGrassBuffer;
					}
					List<GrassData> list2 = allGrassDataList;
					if (allGrassDataList != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ rax_v20 (System.Collections.Generic.List`1<GrassChunkManager+GrassData>)+18]");
						if ((nint)0 == 0)
						{
							return;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ rax_v20 (System.Collections.Generic.List`1<GrassChunkManager+GrassData>)+18]");
						ComputeBuffer computeBuffer = new ComputeBuffer(0, 64);
						allGrassBuffer = computeBuffer;
						bool flag3 = allGrassBuffer == null;
						dictionary = (Dictionary<Vector2Int, List<GrassInstance>>)(object)allGrassBuffer;
						if (!flag3)
						{
							allGrassBuffer.SetData(allGrassDataList);
							bool flag4 = (object)grassMesh == null;
							dictionary = (Dictionary<Vector2Int, List<GrassInstance>>)(object)grassMesh;
							if (!flag4)
							{
								uint[] array = args;
								uint indexCount = grassMesh.GetIndexCount(0);
								bool flag5 = args == null;
								dictionary = (Dictionary<Vector2Int, List<GrassInstance>>)(object)grassMesh;
								if (!flag5)
								{
									array[0] = indexCount;
									List<GrassData> list3 = allGrassDataList;
									bool flag6 = allGrassDataList == null;
									dictionary = (Dictionary<Vector2Int, List<GrassInstance>>)(object)grassMesh;
									if (!flag6)
									{
										dictionary = (Dictionary<Vector2Int, List<GrassInstance>>)(object)args;
										if (args != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rax_v27 (System.Collections.Generic.List`1<GrassChunkManager+GrassData>)+18]");
											_ = 0;
											if ((object)grassMesh != null)
											{
												uint[] array2 = args;
												uint indexStart = grassMesh.GetIndexStart(0);
												if (args != null)
												{
													array2[2] = indexStart;
													if ((object)grassMesh != null)
													{
														uint[] array3 = args;
														uint baseVertex = grassMesh.GetBaseVertex(0);
														if (args != null)
														{
															array3[3] = baseVertex;
															uint[] array4 = args;
															if (args != null)
															{
																array4[4] = 0u;
																if (argsBuffer != null)
																{
																	argsBuffer.SetData(args);
																	return;
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void RenderGrass()
	{
		//IL_00d7: Expected I4, but got O
		//IL_00d7: Expected O, but got Ref
		if (allGrassBuffer != null)
		{
			List<GrassData> list = allGrassDataList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v3 (System.Collections.Generic.List`1<GrassChunkManager+GrassData>)+18]");
			if ((nint)0 != 0)
			{
				MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
				materialPropertyBlock.SetBuffer("_GrassBuffer", allGrassBuffer);
				grassMaterial.SetBuffer("_GrassBuffer", allGrassBuffer);
				Transform transform = base.transform;
				Vector3 position = transform.position;
				float num = default(float);
				ComputeBuffer bufferWithArgs = default(ComputeBuffer);
				int argsOffset = default(int);
				MaterialPropertyBlock properties = default(MaterialPropertyBlock);
				ShadowCastingMode castShadows = default(ShadowCastingMode);
				Graphics.DrawMeshInstancedIndirect(grassMesh, 0, grassMaterial, (Bounds)(&num), bufferWithArgs, argsOffset, properties, castShadows, (byte)(int)argsBuffer != 0, 0, (Camera)(object)materialPropertyBlock);
			}
		}
	}

	private unsafe bool GetTerrainHeight(float x, float z, out float height)
	{
		//IL_002e: Expected O, but got Ref
		//IL_002e: Expected O, but got Ref
		//IL_0190: Expected I4, but got O
		//IL_0108: Invalid comparison between F4 and I
		//IL_0138: Invalid comparison between F4 and I
		ref float reference = ref *(float*)null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		object obj = default(object);
		Vector3 vector = default(Vector3);
		int num = default(int);
		if (Physics.Raycast((Vector3)(&obj), (Vector3)(&vector), out var hitInfo, 9999f, num))
		{
			Collider collider = hitInfo.collider;
			if ((object)collider != null)
			{
				GameObject gameObject = collider.gameObject;
				if ((object)gameObject != null)
				{
					int layer = gameObject.layer;
					int num2 = LayerMask.NameToLayer("Ground");
					if (layer == num2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE090");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rax_v18+4]");
						if (!((float)Math.PI * 29f / 180f > 0f))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
							float num3 = yThreshold;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v20+4]");
							if (!(num3 > 0f))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v21+4]");
								reference = ref *(float*)null;
								return true;
							}
						}
					}
					goto IL_0174;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		goto IL_0174;
		IL_0174:
		return false;
	}

	private void UpdateGrassQuality(int quality)
	{
		int num = default(int);
		if (quality != 0)
		{
			if (quality != 1)
			{
				if (quality == 2)
				{
					num = grassPerChunk;
					goto IL_007f;
				}
				goto IL_008e;
			}
			float num2 = (float)grassPerChunk * 0.35f;
		}
		else
		{
			float num2 = (float)grassPerChunk * 0.05f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		goto IL_007f;
		IL_008e:
		precomputedGrassPositions.Clear();
		UpdateChunks();
		return;
		IL_007f:
		currentGrassPerChunk = num;
		goto IL_008e;
	}

	private void OnSettingUpdated(string setting, object oldValue, object newValue)
	{
		//IL_003b: Expected I, but got O
		//IL_004b: Expected O, but got I
		//IL_008e: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183171F12]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (setting == "grass_quality")
		{
			nint num = (nint)newValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
			string text = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rcx_v5 (Il2CppClass<System.Object>)+40]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdx_v4 (System.String)+40]");
			if (num2 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
				object obj = default(object);
				UpdateGrassQuality((int)obj);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			}
		}
	}

	private void OnDestroy()
	{
		//IL_0110: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<string, object, object> value = OnSettingUpdated;
		Delegate obj = Delegate.Remove(CurrentSettings.A_SettingUpdated, value);
		if ((object)obj == null)
		{
			CurrentSettings.A_SettingUpdated = (Action<string, object, object>)obj;
			goto IL_0098;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<string, object, object> action = default(Action<string, object, object>);
		if (action != null)
		{
			CurrentSettings.A_SettingUpdated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<string, object, object>);
			if (!flag)
			{
				goto IL_0098;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<string, object, object>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0098:
		if (allGrassBuffer != null)
		{
			allGrassBuffer.Dispose();
		}
		if (argsBuffer != null)
		{
			argsBuffer.Dispose();
		}
	}

	private unsafe void OnDrawGizmosSelected()
	{
		//IL_0030: Expected O, but got Ref
		//IL_00b4: Expected O, but got Ref
		//IL_00cf: Expected O, but got Ref
		//IL_00cf: Expected O, but got Ref
		//IL_006a: Expected O, but got Ref
		//IL_006a: Expected O, but got Ref
		if (Application.isPlaying)
		{
			Dictionary<Vector2Int, List<GrassInstance>>.KeyCollection.Enumerator enumerator = default(Dictionary<Vector2Int, List<GrassInstance>>.KeyCollection.Enumerator);
			Gizmos.color = (Color)(&enumerator);
			Dictionary<Vector2Int, List<GrassInstance>>.KeyCollection keys = precomputedGrassPositions.Keys;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
			Dictionary<Vector2Int, List<GrassInstance>>.KeyCollection.Enumerator enumerator2 = default(Dictionary<Vector2Int, List<GrassInstance>>.KeyCollection.Enumerator);
			float num = default(float);
			int num2 = default(int);
			while (enumerator2.MoveNext())
			{
				Gizmos.DrawWireCube((Vector3)(&num), (Vector3)(&num2));
			}
			enumerator2.Dispose();
			Gizmos.color = (Color)(&enumerator);
			Vector2Int playerChunk = GetPlayerChunk();
			float num3 = default(float);
			int num4 = default(int);
			Gizmos.DrawWireCube((Vector3)(&num3), (Vector3)(&num4));
		}
	}

	public GrassChunkManager()
	{
		Dictionary<Vector2Int, List<GrassInstance>> dictionary = new Dictionary<Vector2Int, List<GrassInstance>>();
		precomputedGrassPositions = dictionary;
		allGrassDataList = new List<GrassData>();
		args = new uint[5];
		base._002Ector();
	}
}
