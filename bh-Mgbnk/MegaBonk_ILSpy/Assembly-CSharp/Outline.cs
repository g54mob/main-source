using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using UnityEngine;

public class Outline : MonoBehaviour
{
	public enum Mode
	{
		OutlineAll,
		OutlineVisible,
		OutlineHidden,
		OutlineAndSilhouette,
		SilhouetteOnly
	}

	[Serializable]
	private class ListVector3
	{
		public List<Vector3> data;
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Vector3, int, KeyValuePair<Vector3, int>> _003C_003E9__30_0;

		public static Func<KeyValuePair<Vector3, int>, Vector3> _003C_003E9__30_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal unsafe KeyValuePair<Vector3, int> _003CSmoothNormals_003Eb__30_0(Vector3 vertex, int index)
		{
			//IL_000e: Expected O, but got I4
			//IL_001c: Expected O, but got Ref
			//IL_0017: Expected native int or pointer, but got O
			_003C_003Ec obj = (_003C_003Ec)0;
			object obj2 = default(object);
			IntPtr intPtr = default(IntPtr);
			*(KeyValuePair<Vector3, int>*)(nint)this = new KeyValuePair<Vector3, int>((Vector3)(&obj2), (int)(nint)intPtr);
			return (KeyValuePair<Vector3, int>)this;
		}

		internal unsafe Vector3 _003CSmoothNormals_003Eb__30_1(KeyValuePair<Vector3, int> pair)
		{
			//IL_0012: Expected F4, but got O
			//IL_000d: Expected native int or pointer, but got O
			//IL_0027: Expected F4, but got I
			//IL_0022: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = (float)pair;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pair @ r8 (System.Collections.Generic.KeyValuePair`2<UnityEngine.Vector3, System.Int32>)+8]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
	}

	private static HashSet<Mesh> registeredMeshes;

	private Mode outlineMode;

	private Color outlineColor;

	private float outlineWidth;

	private bool precomputeOutline;

	private List<Mesh> bakeKeys;

	private List<ListVector3> bakeValues;

	private Renderer[] renderers;

	private Material outlineMaskMaterial;

	private Material outlineFillMaterial;

	private bool needsUpdate;

	public Mode OutlineMode
	{
		get
		{
			return outlineMode;
		}
		set
		{
			outlineMode = value;
			needsUpdate = true;
		}
	}

	public unsafe Color OutlineColor
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			Color color = default(Color);
			((Color*)(nint)color)->r = (float)outlineColor;
			return color;
		}
		set
		{
			//IL_001a: Expected O, but got F4
			needsUpdate = true;
			outlineColor = (Color)value.r;
		}
	}

	public float OutlineWidth
	{
		get
		{
			return outlineWidth;
		}
		set
		{
			outlineWidth = value;
			needsUpdate = true;
		}
	}

	private void Awake()
	{
		GameObject gameObject = base.gameObject;
		bool flag = (object)gameObject == null;
		Component component = this;
		if (!flag)
		{
			if (gameObject.CompareTag("NoOutline"))
			{
				base.enabled = false;
				return;
			}
			Renderer[] array = new Renderer[1];
			Renderer component2 = GetComponent<Renderer>();
			bool flag2 = array == null;
			component = this;
			if (!flag2)
			{
				if ((object)component2 != null)
				{
					Renderer component3 = component2.GetComponent<Renderer>();
					bool flag3 = (object)component3 == null;
					component = component2;
					if (flag3)
					{
						Renderer component4 = component.GetComponent<Renderer>();
						throw component4;
					}
				}
				array[0] = component2;
				renderers = array;
				Material original = Resources.Load<Material>("Materials/OutlineMask");
				Material material = UnityEngine.Object.Instantiate(original);
				outlineMaskMaterial = material;
				Material original2 = Resources.Load<Material>("Materials/OutlineFill");
				Material material2 = UnityEngine.Object.Instantiate(original2);
				outlineFillMaterial = material2;
				bool flag4 = (object)outlineMaskMaterial == null;
				component = (Component)(object)outlineMaskMaterial;
				if (!flag4)
				{
					outlineMaskMaterial.name = "OutlineMask (Instance)";
					bool flag5 = (object)outlineFillMaterial == null;
					component = (Component)(object)outlineFillMaterial;
					if (!flag5)
					{
						outlineFillMaterial.name = "OutlineFill (Instance)";
						LoadSmoothNormals();
						needsUpdate = true;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnEnable()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		Renderer[] array = renderers;
		object obj = 0;
		object obj2 = 0;
		IEnumerable<object> source = default(IEnumerable<object>);
		while ((nint)obj2 < array.Length)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822873E0");
			List<object> list = Enumerable.ToList(source);
			int version = list._version + 1;
			list._version = version;
			object[] items = list._items;
			int size = list._size;
			if (list._size >= items.Length)
			{
				list.AddWithResize((object)outlineMaskMaterial);
			}
			else
			{
				int size2 = list._size + 1;
				list._size = size2;
				items[size] = outlineMaskMaterial;
			}
			int version2 = list._version + 1;
			list._version = version2;
			object[] items2 = list._items;
			int size3 = list._size;
			if (list._size >= items2.Length)
			{
				list.AddWithResize((object)outlineFillMaterial);
			}
			else
			{
				int size4 = list._size + 1;
				list._size = size4;
				items2[size3] = outlineFillMaterial;
			}
			Material[] array2 = ((List<Material>)(object)list).ToArray();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182287AC0");
			obj++;
			obj2 = obj;
		}
	}

	private void OnValidate()
	{
		needsUpdate = true;
		if (!precomputeOutline)
		{
			List<Mesh> list = bakeKeys;
			if (list._size != 0)
			{
				goto IL_007d;
			}
		}
		List<Mesh> list2 = bakeKeys;
		List<ListVector3> list3 = bakeValues;
		if (list2._size != list3._size)
		{
			goto IL_007d;
		}
		goto IL_0183;
		IL_0183:
		if (precomputeOutline)
		{
			List<Mesh> list4 = bakeKeys;
			if (list4._size == 0)
			{
				Bake();
			}
		}
		return;
		IL_007d:
		List<Mesh> list5 = bakeKeys;
		int version = list5._version + 1;
		list5._version = version;
		list5._size = 0;
		if (list5._size > 0)
		{
			Array.Clear(list5._items, 0, list5._size);
		}
		List<ListVector3> list6 = bakeValues;
		int version2 = list6._version + 1;
		list6._version = version2;
		list6._size = 0;
		if (list6._size > 0)
		{
			Array.Clear(list6._items, 0, list6._size);
		}
		goto IL_0183;
	}

	private void Update()
	{
		if (needsUpdate)
		{
			needsUpdate = false;
			UpdateMaterialProperties();
		}
	}

	private void OnDisable()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		Renderer[] array = renderers;
		object obj = 0;
		object obj2 = 0;
		IEnumerable<object> source = default(IEnumerable<object>);
		while ((nint)obj2 < array.Length)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822873E0");
			List<object> list = Enumerable.ToList(source);
			bool flag = list.Remove(outlineMaskMaterial);
			bool flag2 = list.Remove(outlineFillMaterial);
			Material[] array2 = ((List<Material>)(object)list).ToArray();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182287AC0");
			obj++;
			obj2 = obj;
		}
	}

	private void OnDestroy()
	{
		UnityEngine.Object.Destroy(outlineMaskMaterial);
		UnityEngine.Object.Destroy(outlineFillMaterial);
	}

	private void Bake()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
		HashSet<Mesh> hashSet = (HashSet<Mesh>)(object)new HashSet<object>();
		MeshFilter[] componentsInChildren = GetComponentsInChildren<MeshFilter>();
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < componentsInChildren.Length)
		{
			GameObject gameObject = componentsInChildren[obj].gameObject;
			if (!gameObject.CompareTag("NoOutline"))
			{
				Mesh sharedMesh = componentsInChildren[obj].sharedMesh;
				if (hashSet.Add(sharedMesh))
				{
					Mesh sharedMesh2 = componentsInChildren[obj].sharedMesh;
					List<Vector3> data = SmoothNormals(sharedMesh2);
					Mesh sharedMesh3 = componentsInChildren[obj].sharedMesh;
					bakeKeys.Add(sharedMesh3);
					ListVector3 listVector = new ListVector3();
					listVector.data = data;
					bakeValues.Add(listVector);
				}
			}
			obj++;
			obj2 = obj;
		}
	}

	public void LoadSmoothNormals()
	{
		//IL_02b4: Expected O, but got I4
		//IL_02bd: Expected O, but got I4
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Expected O, but got Unknown
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0493: Expected O, but got Unknown
		MeshFilter[] componentsInChildren = GetComponentsInChildren<MeshFilter>();
		Mesh mesh = null;
		Mesh mesh2 = null;
		while ((nint)mesh2 < componentsInChildren.Length)
		{
			GameObject gameObject = componentsInChildren[(object)mesh].gameObject;
			if (!gameObject.CompareTag("NoOutline"))
			{
				Mesh sharedMesh = componentsInChildren[(object)mesh].sharedMesh;
				if (registeredMeshes.Add(sharedMesh))
				{
					Mesh sharedMesh2 = componentsInChildren[(object)mesh].sharedMesh;
					int num = ((List<object>)(object)bakeKeys).IndexOf((object)sharedMesh2);
					List<Vector3> uvs;
					if (num >= 0)
					{
						ListVector3 listVector = bakeValues.get_Item(num);
						uvs = listVector.data;
					}
					else
					{
						Mesh sharedMesh3 = componentsInChildren[(object)mesh].sharedMesh;
						List<Vector3> list = SmoothNormals(sharedMesh3);
						uvs = list;
					}
					Mesh sharedMesh4 = componentsInChildren[(object)mesh].sharedMesh;
					sharedMesh4.SetUVs(3, uvs);
					Renderer component = componentsInChildren[(object)mesh].GetComponent<Renderer>();
					if (component != null)
					{
						Mesh sharedMesh5 = componentsInChildren[(object)mesh].sharedMesh;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822873E0");
						int subMeshCount = sharedMesh5.subMeshCount;
						if (subMeshCount != 1)
						{
							int subMeshCount2 = sharedMesh5.subMeshCount;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rax_v55+18]");
							if ((nint)subMeshCount2 <= (nint)0)
							{
								int subMeshCount3 = sharedMesh5.subMeshCount;
								int subMeshCount4 = subMeshCount3 + 1;
								sharedMesh5.subMeshCount = subMeshCount4;
								int[] triangles = sharedMesh5.triangles;
								int subMeshCount5 = sharedMesh5.subMeshCount;
								int submesh = subMeshCount5 - 1;
								sharedMesh5.SetTriangles(triangles, submesh);
							}
						}
					}
				}
			}
			mesh = (Mesh)(mesh + 1);
			mesh2 = mesh;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = GetComponentsInChildren<SkinnedMeshRenderer>();
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < componentsInChildren2.Length)
		{
			GameObject gameObject2 = componentsInChildren2[obj].gameObject;
			if (!gameObject2.CompareTag("NoOutline"))
			{
				Mesh sharedMesh6 = componentsInChildren2[obj].sharedMesh;
				if (registeredMeshes.Add(sharedMesh6))
				{
					Mesh sharedMesh7 = componentsInChildren2[obj].sharedMesh;
					Mesh sharedMesh8 = componentsInChildren2[obj].sharedMesh;
					int vertexCount = sharedMesh8.vertexCount;
					Vector2[] uv = new Vector2[vertexCount];
					sharedMesh7.uv4 = uv;
					Mesh sharedMesh9 = componentsInChildren2[obj].sharedMesh;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822873E0");
					int subMeshCount6 = sharedMesh9.subMeshCount;
					if (subMeshCount6 != 1)
					{
						int subMeshCount7 = sharedMesh9.subMeshCount;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rax_v27+18]");
						if ((nint)subMeshCount7 <= (nint)0)
						{
							int subMeshCount8 = sharedMesh9.subMeshCount;
							int subMeshCount9 = subMeshCount8 + 1;
							sharedMesh9.subMeshCount = subMeshCount9;
							int[] triangles2 = sharedMesh9.triangles;
							int subMeshCount10 = sharedMesh9.subMeshCount;
							int submesh2 = subMeshCount10 - 1;
							sharedMesh9.SetTriangles(triangles2, submesh2);
						}
					}
				}
			}
			obj++;
			obj2 = obj;
		}
	}

	private unsafe List<Vector3> SmoothNormals(Mesh mesh)
	{
		//IL_00b6: Expected I4, but got O
		//IL_0360: Expected O, but got Ref
		//IL_0390: Expected I4, but got O
		//IL_0174: Expected I4, but got O
		//IL_0180: Expected O, but got Ref
		//IL_0553: Expected I4, but got O
		//IL_055f: Expected O, but got Ref
		//IL_0266: Expected I4, but got O
		//IL_0205: Expected O, but got Ref
		//IL_0220: Expected I4, but got O
		//IL_0220: Expected O, but got Ref
		//IL_0231: Expected O, but got Ref
		//IL_0349: Expected I4, but got O
		//IL_02eb: Expected O, but got Ref
		//IL_0312: Expected O, but got Ref
		if ((object)mesh != null)
		{
			Vector3[] vertices = mesh.vertices;
			Func<Vector3, int, KeyValuePair<Vector3, int>> selector = _003C_003Ec._003C_003E9__30_0;
			if (_003C_003Ec._003C_003E9__30_0 == null)
			{
				selector = (_003C_003Ec._003C_003E9__30_0 = delegate
				{
					//IL_000e: Expected O, but got I4
					//IL_001c: Expected O, but got Ref
					//IL_0017: Expected native int or pointer, but got O
					_003C_003Ec obj7 = (_003C_003Ec)0;
					object obj8 = default(object);
					IntPtr intPtr = default(IntPtr);
					*(KeyValuePair<Vector3, int>*)(nint)_003C_003Ec._003C_003E9 = new KeyValuePair<Vector3, int>((Vector3)(&obj8), (int)(nint)intPtr);
					return (KeyValuePair<Vector3, int>)_003C_003Ec._003C_003E9;
				});
			}
			IEnumerable<KeyValuePair<Vector3, int>> source = Enumerable.Select(vertices, selector);
			Func<KeyValuePair<Vector3, int>, Vector3> keySelector = _003C_003Ec._003C_003E9__30_1;
			if (_003C_003Ec._003C_003E9__30_1 == null)
			{
				keySelector = (_003C_003Ec._003C_003E9__30_1 = delegate(KeyValuePair<Vector3, int> pair)
				{
					//IL_0012: Expected F4, but got O
					//IL_000d: Expected native int or pointer, but got O
					//IL_0027: Expected F4, but got I
					//IL_0022: Expected native int or pointer, but got O
					Vector3 vector13 = default(Vector3);
					((Vector3*)(nint)vector13)->x = (float)pair;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pair @ r8 (System.Collections.Generic.KeyValuePair`2<UnityEngine.Vector3, System.Int32>)+8]");
					((Vector3*)(nint)vector13)->z = 0f;
					return vector13;
				});
			}
			IEnumerable<IGrouping<Vector3, KeyValuePair<Vector3, int>>> enumerable = Enumerable.GroupBy(source, keySelector);
			Vector3[] normals = mesh.normals;
			List<Vector3> list = new List<Vector3>(normals);
			if (enumerable != null)
			{
				Vector3 vector = ((List<Vector3>)(object)typeof(IEnumerable<IGrouping<Vector3, KeyValuePair<Vector3, int>>>)).get_Item((int)enumerable);
				int num = default(int);
				int num3 = default(int);
				object obj2 = default(object);
				object obj3 = default(object);
				Vector3 vector7 = default(Vector3);
				object obj5 = default(object);
				Vector3 vector10 = default(Vector3);
				while (true)
				{
					if (num != 0)
					{
						Vector3 vector2 = ((List<Vector3>)(object)typeof(IEnumerator)).get_Item(num);
						if ((object)vector2 != null)
						{
							bool flag = num == 0;
							List<Vector3> list2 = null;
							if (!flag)
							{
								IEnumerable<KeyValuePair<Vector3, int>> enumerable2 = (IEnumerable<KeyValuePair<Vector3, int>>)((List<Vector3>)(object)typeof(IEnumerator<IGrouping<Vector3, KeyValuePair<Vector3, int>>>)).get_Item(num);
								int num2 = Enumerable.Count(enumerable2);
								if (num2 == 1)
								{
									continue;
								}
								if (enumerable2 != null)
								{
									Vector3 vector3 = ((List<Vector3>)(object)typeof(IEnumerable<KeyValuePair<Vector3, int>>)).get_Item((int)enumerable2);
									object obj = (object)(&num3);
									list2 = null;
									while (true)
									{
										if (num3 != 0)
										{
											Vector3 vector4 = ((List<Vector3>)(object)typeof(IEnumerator)).get_Item(num3);
											if ((object)vector4 == null)
											{
												break;
											}
											bool flag2 = num3 == 0;
											list2 = null;
											if (!flag2)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002FD0");
												bool flag3 = list == null;
												list2 = (List<Vector3>)(&obj2);
												if (!flag3)
												{
													Vector3 vector5 = ((List<Vector3>)(&obj3)).get_Item((int)list);
													list2 = (List<Vector3>)(&obj3);
													continue;
												}
												throw new NullReferenceException();
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									if (obj != null)
									{
										Vector3 vector6 = ((List<Vector3>)(object)typeof(IDisposable)).get_Item((int)obj);
									}
									vector7.Normalize();
									Vector3 vector8 = ((List<Vector3>)(object)typeof(IEnumerable<KeyValuePair<Vector3, int>>)).get_Item((int)enumerable2);
									object obj4 = (object)(&num3);
									list2 = null;
									while (true)
									{
										if (num3 != 0)
										{
											Vector3 vector9 = ((List<Vector3>)(object)typeof(IEnumerator)).get_Item(num3);
											if ((object)vector9 == null)
											{
												break;
											}
											bool flag4 = num3 == 0;
											list2 = null;
											if (!flag4)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002FD0");
												bool flag5 = list == null;
												list2 = (List<Vector3>)(&obj5);
												if (!flag5)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ rax_v61+C]");
													list.set_Item(0, (Vector3)(&vector10));
													continue;
												}
												throw new NullReferenceException();
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									if (obj4 != null)
									{
										Vector3 vector11 = ((List<Vector3>)(object)typeof(IDisposable)).get_Item((int)obj4);
									}
									continue;
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						object obj6 = (object)(&num);
						if (obj6 != null)
						{
							Vector3 vector12 = ((List<Vector3>)(object)typeof(IDisposable)).get_Item((int)obj6);
						}
						break;
					}
					throw new NullReferenceException();
				}
				return list;
			}
		}
		throw new NullReferenceException();
	}

	private void CombineSubmeshes(Mesh mesh, Material[] materials)
	{
		int subMeshCount = mesh.subMeshCount;
		if (subMeshCount != 1)
		{
			int subMeshCount2 = mesh.subMeshCount;
			if (subMeshCount2 <= materials.Length)
			{
				int subMeshCount3 = mesh.subMeshCount;
				int subMeshCount4 = subMeshCount3 + 1;
				mesh.subMeshCount = subMeshCount4;
				int[] triangles = mesh.triangles;
				int subMeshCount5 = mesh.subMeshCount;
				int submesh = subMeshCount5 - 1;
				mesh.SetTriangles(triangles, submesh);
			}
		}
	}

	private unsafe void UpdateMaterialProperties()
	{
		//IL_0047: Expected O, but got Ref
		//IL_0076: Expected O, but got I4
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_0123: Expected F4, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831721B5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = default(object);
		outlineFillMaterial.SetColor("_OutlineColor", (Color)(&obj));
		bool flag = outlineMode == Mode.OutlineAll;
		Material material;
		float value;
		Material material2;
		float value2;
		Material material3;
		float value3;
		if (!flag)
		{
			object obj2 = outlineMode - 1;
			if (!flag)
			{
				object obj3 = obj2 - 1;
				if (!flag)
				{
					object obj4 = obj3 - 1;
					if (!flag)
					{
						if ((nint)obj4 == 1)
						{
							outlineMaskMaterial.SetFloat("_ZTest", 4f);
							outlineFillMaterial.SetFloat("_ZTest", 5f);
							material = outlineFillMaterial;
							value = 0f;
							goto IL_01e4;
						}
						return;
					}
					material2 = outlineMaskMaterial;
					value2 = 4f;
					goto IL_01f7;
				}
				outlineMaskMaterial.SetFloat("_ZTest", 8f);
				material3 = outlineFillMaterial;
				value3 = 5f;
			}
			else
			{
				outlineMaskMaterial.SetFloat("_ZTest", 8f);
				material3 = outlineFillMaterial;
				value3 = 4f;
			}
			goto IL_0218;
		}
		material2 = outlineMaskMaterial;
		value2 = 8f;
		goto IL_01f7;
		IL_01e4:
		material.SetFloat("_OutlineWidth", value);
		return;
		IL_01f7:
		material2.SetFloat("_ZTest", value2);
		material3 = outlineFillMaterial;
		value3 = 8f;
		goto IL_0218;
		IL_0218:
		material3.SetFloat("_ZTest", value3);
		material = outlineFillMaterial;
		value = outlineWidth;
		goto IL_01e4;
	}

	public Outline()
	{
		//IL_0035: Expected O, but got I4
		outlineColor = (Color)1065353216;
		_ = 1065353216;
		_ = 1065353216;
		_ = 1065353216;
		outlineWidth = 2f;
		List<Mesh> list = new List<Mesh>();
		bakeKeys = list;
		bakeValues = new List<ListVector3>();
		base._002Ector();
	}

	static Outline()
	{
		HashSet<Mesh> hashSet = (HashSet<Mesh>)(object)new HashSet<object>();
		registeredMeshes = hashSet;
	}
}
