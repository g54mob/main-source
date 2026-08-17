using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;

namespace VampireSurvivors.Graphics.Blitters;

public class Blitter : GameMonoBehaviour
{
	[StructLayout((LayoutKind)0, Pack = 2, Size = 12)]
	private struct Index
	{
		public ushort b1;

		public ushort b2;

		public ushort b3;

		public ushort b4;

		public ushort b5;

		public ushort b6;

		public void Setup()
		{
			b1 = 0;
			b3 = 1;
			b5 = 3;
		}

		public void Increment()
		{
			ushort num = (ushort)(b1 + 4);
			b1 = num;
			ushort num2 = (ushort)(b2 + 4);
			b2 = num2;
			ushort num3 = (ushort)(b3 + 4);
			b3 = num3;
			ushort num4 = (ushort)(b4 + 4);
			b4 = num4;
			ushort num5 = (ushort)(b5 + 4);
			b5 = num5;
			ushort num6 = (ushort)(b6 + 4);
			b6 = num6;
		}
	}

	private MeshFilter _meshFilter;

	private MeshRenderer _meshRenderer;

	private BlitterRenderMode _renderMode;

	private readonly List<Bob> _bobs;

	private Texture2D _atlasTexture;

	private Mesh _mesh;

	private static Transform _blittersSceneParent;

	private NativeArray<BobFullVertex> vertices;

	private NativeArray<ushort> indices;

	private VertexAttributeDescriptor[] meshDescriptor;

	private static readonly ProfilerMarker s_updateMarker;

	private static readonly ProfilerMarker s_updateClearMarker;

	private static readonly ProfilerMarker s_updateApplyMeshMarker;

	public List<Bob> Children => _bobs;

	public Mesh Mesh => _mesh;

	public Material Material
	{
		get
		{
			if ((object)_meshRenderer != null)
			{
				return ((Renderer)_meshRenderer).GetMaterial();
			}
			return (Material)(object)new NullReferenceException();
		}
	}

	private void Awake()
	{
		MeshFilter component = GetComponent<MeshFilter>();
		_meshFilter = component;
		MeshRenderer component2 = GetComponent<MeshRenderer>();
		_meshRenderer = component2;
		Init();
		UpdateBobs();
	}

	private void Start()
	{
		if (_renderMode == BlitterRenderMode.ONCE)
		{
			UpdateBobs();
		}
	}

	protected override void OnUpdate()
	{
		if (_renderMode == BlitterRenderMode.DEFAULT)
		{
			UpdateBobs();
		}
	}

	protected unsafe override void OnDestroy()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		if ((object)vertices != null)
		{
			NativeArray<BobFullVertex> nativeArray = (NativeArray<BobFullVertex>)(this + 88);
			((NativeArray<BobFullVertex>*)nativeArray)->Dispose();
		}
		if ((object)indices != null)
		{
			NativeArray<ushort> nativeArray2 = (NativeArray<ushort>)(this + 104);
			((NativeArray<ushort>*)nativeArray2)->Dispose();
		}
	}

	private void OnDrawGizmosSelected()
	{
	}

	public static Blitter CreateBlitter(VampireSurvivors.Framework.Particles.BlendMode blendMode = VampireSurvivors.Framework.Particles.BlendMode.Normal, Texture2D atlasTexture = null)
	{
		EnsureSceneParent();
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "Blitter");
		if ((object)gameObject != null)
		{
			Transform transform = gameObject.transform;
			if ((object)transform != null)
			{
				transform.SetParent(_blittersSceneParent, worldPositionStays: true);
				Blitter blitter = gameObject.AddComponent<Blitter>();
				if ((object)blitter != null)
				{
					Renderer component = blitter.GetComponent<Renderer>();
					bool flag = blendMode == VampireSurvivors.Framework.Particles.BlendMode.Normal;
					bool flag2 = !flag;
					MaterialType type = (MaterialType)((flag2 ? 1 : 0) + 6);
					Material material = MaterialManager.GetMaterial(type);
					if ((object)component != null)
					{
						component.SetMaterial(material);
						if ((object)atlasTexture != null && ((UnityEngine.Object)atlasTexture).m_CachedPtr != (IntPtr)0)
						{
							blitter.SetAtlasTexture(atlasTexture);
						}
						return blitter;
					}
				}
			}
		}
		return (Blitter)(object)new NullReferenceException();
	}

	public Bob CreateBob(Vector2 pos, Sprite sprite)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @187623360");
		if (_bobs != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA20D0");
			Bob result = default(Bob);
			return result;
		}
		return (Bob)(object)new NullReferenceException();
	}

	public void RemoveBob(Bob bob)
	{
		if (bob != null && !bob._disposed)
		{
			bob._disposed = true;
			((Stack<object>)(object)Bob.emptyBobs).Push((object)bob);
		}
		bool flag = ((List<object>)(object)_bobs).Remove((object)bob);
	}

	public void SetAtlasTexture(Texture2D atlasTexture)
	{
		_atlasTexture = atlasTexture;
		Material material = ((Renderer)_meshRenderer).GetMaterial();
		material.mainTexture = _atlasTexture;
	}

	public void SetRenderMode(BlitterRenderMode renderMode)
	{
		_renderMode = renderMode;
	}

	public void SetBlendMode(VampireSurvivors.Framework.Particles.BlendMode blendMode)
	{
		//IL_0043: Expected O, but got I4
		object obj = blendMode - 1;
		bool flag = obj == null;
		MaterialType type = (MaterialType)((flag ? 1 : 0) + 6);
		Material material = MaterialManager.GetMaterial(type);
		((Renderer)_meshRenderer).SetMaterial(material);
	}

	public void SetDepth(int depth)
	{
		_meshRenderer.sortingOrder = depth;
	}

	public void ForceUpdate()
	{
		UpdateBobs();
	}

	private void GrabComponents()
	{
		MeshFilter component = GetComponent<MeshFilter>();
		_meshFilter = component;
		MeshRenderer component2 = GetComponent<MeshRenderer>();
		_meshRenderer = component2;
	}

	private unsafe void EnsureArraySizes(int numQuads)
	{
		//IL_02b2: Expected O, but got I4
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Expected O, but got Unknown
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Expected O, but got Unknown
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Expected O, but got Unknown
		//IL_0363: Expected O, but got I4
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected O, but got Unknown
		//IL_002c: Expected O, but got I4
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_00c3: Expected O, but got I4
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_0441: Expected I, but got O
		//IL_045b: Expected F4, but got O
		//IL_047d: Expected F4, but got I
		//IL_0413: Expected O, but got I4
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected O, but got Unknown
		//IL_0184: Expected I4, but got O
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_022a: Expected O, but got I4
		//IL_0237: Expected O, but got I4
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Expected O, but got Unknown
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_0193->IL03a9: Incompatible stack heights: 1 vs 0
		object obj = numQuads * 2;
		object obj2 = numQuads + obj;
		object obj3 = obj2 + obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Graphics.Blitters.Blitter)+70]");
		object obj4 = 0 - obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Graphics.Blitters.Blitter)+70]");
		object obj5 = 0 ^ obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Graphics.Blitters.Blitter)+70]");
		object obj6 = 0 ^ obj4;
		object obj7 = obj5 & obj6;
		bool flag = (nint)obj7 < 0;
		bool flag2 = (nint)obj4 < 0;
		bool flag3 = obj4 == null;
		bool flag4 = flag2 != flag;
		object obj8 = flag4 | flag3;
		bool flag5 = (object)indices == null;
		bool flag6 = !flag5;
		object obj9 = flag6 & obj8;
		if (obj9 != null)
		{
			NativeArray<ushort> nativeArray = (NativeArray<ushort>)(this + 104);
			((NativeArray<ushort>*)nativeArray)->Dispose();
		}
		object obj10 = numQuads * 4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Graphics.Blitters.Blitter)+60]");
		object obj11 = 0 - obj10;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Graphics.Blitters.Blitter)+60]");
		object obj12 = 0 ^ obj10;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Graphics.Blitters.Blitter)+60]");
		object obj13 = 0 ^ obj11;
		object obj14 = obj12 & obj13;
		bool flag7 = (nint)obj14 < 0;
		bool flag8 = (nint)obj11 < 0;
		bool flag9 = obj11 == null;
		bool flag10 = flag8 != flag7;
		object obj15 = flag10 | flag9;
		bool flag11 = (object)vertices == null;
		bool flag12 = !flag11;
		object obj16 = flag12 & obj15;
		if (obj16 != null)
		{
			NativeArray<BobFullVertex> nativeArray2 = (NativeArray<BobFullVertex>)(this + 88);
			((NativeArray<BobFullVertex>*)nativeArray2)->Dispose();
		}
		if ((object)indices == null)
		{
			_mesh.SetIndexBufferParams(0, IndexFormat.UInt16);
			Mesh mesh = _mesh;
			bool flag13 = ((UnityEngine.Object)mesh).m_CachedPtr == (IntPtr)0;
			SubMeshDescriptor desc = default(SubMeshDescriptor);
			Mesh.SetSubMesh_Injected(((UnityEngine.Object)mesh).m_CachedPtr, 0, ref desc, MeshUpdateFlags.Default);
			object obj17 = numQuads * 2;
			object obj18 = numQuads + obj17;
			object obj19 = obj18 << 2;
			NativeArray<ushort>.Allocate((int)obj19, Allocator.Persistent, out NativeArray<ushort> array);
			indices = array;
		}
		if ((object)vertices != null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186436CF0");
		int length = numQuads * 8;
		NativeArray<BobFullVertex>.Allocate(length, Allocator.Persistent, out NativeArray<BobFullVertex> array2);
		vertices = array2;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v719 @ rax_v28 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		uint num3 = math.f32tof16((float)Vector3.backVector);
		float x = default(float);
		uint num4 = math.f32tof16(x);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v720 @ rcx_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+5C]");
		uint num5 = math.f32tof16(0f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Graphics.Blitters.Blitter)+60]");
		bool flag14 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Graphics.Blitters.Blitter)+60]");
		if ((nint)0 <= (nint)0)
		{
			return;
		}
		object obj20 = vertices + 12;
		object obj21 = 0;
		while (!flag14)
		{
			obj20 = num3;
			obj20 += 32;
			obj21++;
			object obj22 = obj21;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Graphics.Blitters.Blitter)+60]");
			object obj23 = obj22 - 0;
			flag14 = obj23 == null;
			object obj24 = obj21;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Graphics.Blitters.Blitter)+60]");
			if ((nint)obj24 >= 0)
			{
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void Init()
	{
		//IL_0178->IL0107: Incompatible stack heights: 1 vs 0
		if ((object)_meshRenderer != null)
		{
			Material material = ((Renderer)_meshRenderer).GetMaterial();
			Material material2 = UnityEngine.Object.Instantiate(material);
			((Renderer)_meshRenderer).SetMaterial(material2);
			if ((object)_meshRenderer != null)
			{
				Material material3 = ((Renderer)_meshRenderer).GetMaterial();
				if ((object)material3 != null)
				{
					material3.mainTexture = _atlasTexture;
					Mesh mesh = new Mesh();
					_mesh = mesh;
					Material mesh2 = (Material)(object)_mesh;
					if ((object)_mesh != null)
					{
						bool flag = ((UnityEngine.Object)mesh2).m_CachedPtr == (IntPtr)0;
						Mesh.set_subMeshCount_Injected(((UnityEngine.Object)mesh2).m_CachedPtr, 1);
						if ((object)_meshFilter != null)
						{
							_meshFilter.mesh = _mesh;
							EnsureArraySizes(512);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	[MethodImpl((MethodImplOptions)256)]
	private unsafe ref BobVertexData GetBobVertexData(Bob bob, int idx)
	{
		//IL_000e: Expected O, but got I4
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected Ref, but got Unknown
		object obj = idx * 2;
		object obj2 = idx + obj;
		object obj3 = obj2 * 4;
		object obj4 = (object)bob.vertexData + obj3;
		return ref *(BobVertexData*)(obj4 + 32);
	}

	public void ManualUpdate()
	{
		UpdateBobs();
	}

	private unsafe void UpdateBobs()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00ba: Expected O, but got I4
		//IL_00c3: Expected O, but got I4
		//IL_00cc: Expected O, but got I4
		//IL_00d5: Expected O, but got I4
		//IL_00de: Expected O, but got I4
		//IL_00e7: Expected O, but got I4
		//IL_00f0: Expected O, but got I4
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Expected O, but got Unknown
		//IL_0497: Expected O, but got Ref
		//IL_04da: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Expected O, but got Unknown
		//IL_095b: Expected I4, but got O
		//IL_08d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08dd: Expected O, but got Unknown
		//IL_0511: Expected O, but got Ref
		//IL_054c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0551: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_09a9: Expected O, but got Ref
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Expected O, but got Unknown
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Expected O, but got Unknown
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Expected O, but got Unknown
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Expected O, but got Unknown
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_036f: Expected O, but got Unknown
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Expected O, but got Unknown
		//IL_03bf: Expected O, but got I
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03da: Expected O, but got Unknown
		//IL_03f0: Expected O, but got I
		//IL_0643: Expected O, but got I4
		//IL_064c: Expected O, but got I4
		//IL_0677: Unknown result type (might be due to invalid IL or missing references)
		//IL_067c: Expected O, but got Unknown
		//IL_06b0: Expected O, but got I8
		//IL_06eb: Expected O, but got I8
		//IL_0726: Expected O, but got I8
		//IL_0760: Expected O, but got I8
		//IL_0797: Expected O, but got I8
		//IL_07ce: Expected O, but got I8
		//IL_07f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f9: Expected O, but got Unknown
		//IL_0975->IL087c: Incompatible stack heights: 1 vs 0
		//IL_05af->IL087c: Incompatible stack heights: 1 vs 0
		//IL_09e2->IL087c: Incompatible stack heights: 2 vs 0
		//IL_0609->IL087c: Incompatible stack heights: 2 vs 0
		//IL_0635->IL087c: Incompatible stack heights: 2 vs 0
		//IL_0862->IL08a7: Incompatible stack heights: 2 vs 0
		//IL_0a57->IL08a7: Incompatible stack heights: 4 vs 0
		//IL_0847->IL0847: Incompatible stack heights: 4 vs 2
		//IL_0806->IL09e7: Incompatible stack heights: 3 vs 2
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((object)_mesh != null)
		{
			_mesh.ClearImpl(true);
			List<Bob> bobs = _bobs;
			_ = 131072;
			_ = 131073;
			_ = 3;
			_ = 65539;
			if (_bobs != null)
			{
				EnsureArraySizes(bobs._size);
				List<Bob> bobs2 = _bobs;
				NativeArray<ushort> nativeArray = indices;
				if (_bobs != null)
				{
					object obj3 = vertices + 32;
					object obj4 = 2;
					object obj5 = 1;
					object obj6 = 0;
					object obj7 = 0;
					object obj8 = 2;
					object obj9 = 0;
					object obj10 = 0;
					object obj12 = default(object);
					int count = default(int);
					MeshUpdateFlags flags = default(MeshUpdateFlags);
					while (true)
					{
						if ((nint)obj9 < bobs2._size)
						{
							List<Bob> bobs3 = _bobs;
							if (_bobs == null)
							{
								break;
							}
							if ((nint)obj10 < bobs3._size)
							{
								Bob[] items = bobs3._items;
								if (bobs3._items == null)
								{
									break;
								}
								if ((nint)obj10 < items.Length)
								{
									Bob bob = items[obj10];
									if (items[obj10] != null && (object)bob._sprite != null)
									{
										object obj11 = obj3 - 32;
										if (obj11 == null)
										{
											break;
										}
										_ = 0;
										BobVertexData[] vertexData = bob.vertexData;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rax_v89 (BobVertexData[])+20]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rax_v89 (BobVertexData[])+28]");
										_ = 0;
										if (obj3 == null)
										{
											break;
										}
										obj3 = obj12;
										_ = 0;
										BobVertexData[] vertexData2 = bob.vertexData;
										object obj13 = obj3 + 32;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v994 @ rax_v90 (BobVertexData[])+2C]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v994 @ rax_v90 (BobVertexData[])+34]");
										_ = 0;
										if (obj13 == null)
										{
											break;
										}
										_ = 0;
										BobVertexData[] vertexData3 = bob.vertexData;
										object obj14 = obj3 + 64;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v92 (BobVertexData[])+38]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v92 (BobVertexData[])+40]");
										_ = 0;
										if (obj14 == null)
										{
											break;
										}
										obj6 += 4;
										obj8 += 4;
										obj5 += 4;
										obj4 += 4;
										obj7++;
										_ = 0;
										BobVertexData[] vertexData4 = bob.vertexData;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1145 @ rax_v94 (BobVertexData[])+44]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1145 @ rax_v94 (BobVertexData[])+4C]");
										_ = 0;
										obj3 -= -128;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-59]");
										nativeArray = (NativeArray<ushort>)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-51]");
										_ = 0;
										nativeArray = (NativeArray<ushort>)(nativeArray + 12);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
										object obj15 = (nint)0 + (nint)4;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-4F]");
										_ = (nint)0 + (nint)4;
									}
									bobs2 = _bobs;
									obj10++;
									if (_bobs == null)
									{
										break;
									}
									obj9 = obj10;
									continue;
								}
							}
							else
							{
								System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
							}
							throw new IndexOutOfRangeException();
						}
						if ((object)_mesh != null)
						{
							object obj16 = obj7 * 4;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186436CF0");
							if ((object)_mesh != null)
							{
								object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
								_ = vertices;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18309DB90");
								object mesh = _mesh;
								if ((object)_mesh != null)
								{
									object obj18 = obj7 * 2;
									object obj19 = obj7 + obj18;
									object obj20 = obj19 + obj19;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ r14_v14 (System.Object)+10]");
									bool flag = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ r14_v14 (System.Object)+10]");
									Mesh.SetIndexBufferParams_Injected((IntPtr)0, (int)obj20, IndexFormat.UInt16);
									if ((object)_mesh != null)
									{
										NativeArray<ushort> data = (NativeArray<ushort>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
										_ = indices;
										_mesh.SetIndexBufferData(data, 0, 0, count, flags);
										object mesh2 = _mesh;
										object obj21 = obj7 * 2;
										object obj22 = obj7 + obj21;
										object obj23 = obj22 + obj22;
										_ = 0;
										_ = 0;
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
										_ = 0;
										_ = 0;
										if ((object)_mesh != null)
										{
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ r14_v15 (System.Object)+10]");
											bool flag2 = (nint)0 == 0;
											object obj24 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ r14_v15 (System.Object)+10]");
											Mesh.SetSubMesh_Injected((IntPtr)0, 0, ref *(SubMeshDescriptor*)obj24, MeshUpdateFlags.Default);
											if ((object)_mesh != null)
											{
												_mesh.RecalculateBounds(MeshUpdateFlags.Default);
												if ((object)_mesh != null)
												{
													Vector3[] array = _mesh.vertices;
													if (array != null)
													{
														object obj25 = 0;
														object obj26 = 0;
														while (true)
														{
															if ((nint)obj26 < array.Length)
															{
																bool flag3 = (nint)obj25 >= array.Length;
																object obj27 = obj25 * 2;
																object obj28 = obj25 + obj27;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1258 @ rax_v48 (UnityEngine.Vector3[])+20+v1263 @ rcx_v41*4]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1258 @ rax_v48 (UnityEngine.Vector3[])+20+v1263 @ rcx_v41*4]");
																object obj29 = 0 & -2147483649L;
																if ((nint)obj29 < 2139095040)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-55]");
																	object obj30 = 0 & -2147483649L;
																	if ((nint)obj30 < 2139095040)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1258 @ rax_v48 (UnityEngine.Vector3[])+28+v1263 @ rcx_v41*4]");
																		object obj31 = 0 & -2147483649L;
																		if ((nint)obj31 < 2139095040)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1258 @ rax_v48 (UnityEngine.Vector3[])+20+v1263 @ rcx_v41*4]");
																			object obj32 = 0 & -2147483649L;
																			if ((nint)obj32 <= 2139095040)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-55]");
																				object obj33 = 0 & -2147483649L;
																				if ((nint)obj33 <= 2139095040)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1258 @ rax_v48 (UnityEngine.Vector3[])+28+v1263 @ rcx_v41*4]");
																					object obj34 = 0 & -2147483649L;
																					if ((nint)obj34 <= 2139095040)
																					{
																						obj25++;
																						obj26 = obj25;
																						continue;
																					}
																				}
																			}
																		}
																	}
																}
																bool flag4 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
																IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)this).m_CachedPtr);
																GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
																if ((object)gameObject == null)
																{
																	break;
																}
																string text = ((UnityEngine.Object)gameObject).GetName();
																string message = "Mesh vertices are not valid, returning out - GameObject: " + text;
																Debug.LogError(message);
															}
															else
															{
																if ((object)_mesh == null)
																{
																	break;
																}
																_mesh.UploadMeshData(markNoLongerReadable: false);
															}
															return;
														}
														break;
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
				}
			}
		}
		throw new NullReferenceException();
	}

	private bool IsMeshOk(Mesh mesh)
	{
		//IL_001b: Expected O, but got I4
		//IL_0024: Expected O, but got I4
		//IL_01dd: Expected I4, but got O
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_007f: Expected O, but got I8
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00eb: Expected O, but got I8
		//IL_0125: Expected O, but got I8
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected O, but got Unknown
		//IL_018b: Expected O, but got I8
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected O, but got Unknown
		Vector3[] array = mesh.vertices;
		object obj = 0;
		object obj2 = 0;
		object obj7 = default(object);
		while (true)
		{
			if ((nint)obj < array.Length)
			{
				if ((nint)obj2 >= array.Length)
				{
					break;
				}
				object obj3 = obj2 * 2;
				object obj4 = obj2 + obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rax_v6 (UnityEngine.Vector3[])+20+v144 @ rcx_v6*4]");
				object obj5 = 0 & -2147483649L;
				if ((nint)obj5 < 2139095040)
				{
					object obj6 = obj7 & -2147483649L;
					if ((nint)obj6 < 2139095040)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rax_v6 (UnityEngine.Vector3[])+28+v144 @ rcx_v6*4]");
						object obj8 = 0 & -2147483649L;
						if ((nint)obj8 < 2139095040)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rax_v6 (UnityEngine.Vector3[])+20+v144 @ rcx_v6*4]");
							object obj9 = 0 & -2147483649L;
							if ((nint)obj9 <= 2139095040)
							{
								object obj10 = obj7 & -2147483649L;
								if ((nint)obj10 <= 2139095040)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rax_v6 (UnityEngine.Vector3[])+28+v144 @ rcx_v6*4]");
									object obj11 = 0 & -2147483649L;
									if ((nint)obj11 <= 2139095040)
									{
										obj2++;
										obj = obj2;
										continue;
									}
								}
							}
						}
					}
				}
				return false;
			}
			return true;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	private static void EnsureSceneParent()
	{
		Transform blittersSceneParent = _blittersSceneParent;
		if ((object)_blittersSceneParent == null || ((UnityEngine.Object)blittersSceneParent).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = new GameObject();
			GameObject.Internal_CreateGameObject(gameObject, "BlittersSceneParent");
			Transform blittersSceneParent2 = gameObject.transform;
			_blittersSceneParent = blittersSceneParent2;
		}
	}

	public Blitter()
	{
		List<Bob> bobs = new List<Bob>();
		_bobs = bobs;
		VertexAttributeDescriptor[] array = new VertexAttributeDescriptor[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11970]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A119B0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A119C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11960]");
		_ = 0;
		meshDescriptor = array;
		base._onResumeSent = true;
	}

	static Blitter()
	{
		//IL_0035: Expected O, but got I
		//IL_005b: Expected O, but got I
		//IL_000e: Expected O, but got I
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("Blitter.UpdateBobs", 0, MarkerFlags.Default, 0);
		s_updateMarker = (ProfilerMarker)(nint)intPtr;
		IntPtr intPtr2 = ProfilerUnsafeUtility.CreateMarker("Clear", 0, MarkerFlags.Default, 0);
		s_updateClearMarker = (ProfilerMarker)(nint)intPtr2;
		IntPtr intPtr3 = ProfilerUnsafeUtility.CreateMarker("ApplyMesh", 0, MarkerFlags.Default, 0);
		s_updateApplyMeshMarker = (ProfilerMarker)(nint)intPtr3;
	}
}
