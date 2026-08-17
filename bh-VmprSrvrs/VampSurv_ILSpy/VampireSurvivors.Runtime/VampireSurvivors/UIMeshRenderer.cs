using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace VampireSurvivors;

public class UIMeshRenderer : MonoBehaviour
{
	public Material Material;

	private Mesh mesh;

	private bool mask;

	private bool showMaskGraphic;

	private bool maskable;

	private bool preserveAspect;

	private CanvasRenderer canvasRenderer;

	private Image[] childImage;

	private Vector3[] baseVertices;

	private RectTransform rect;

	private float cachedHeight;

	private float cachedWidth;

	private void Start()
	{
		SetupMesh();
	}

	private void SetupMesh()
	{
		CanvasRenderer canvasRenderer = this.canvasRenderer;
		if ((object)this.canvasRenderer == null || ((UnityEngine.Object)canvasRenderer).m_CachedPtr == (IntPtr)0)
		{
			CanvasRenderer component = GetComponent<CanvasRenderer>();
			this.canvasRenderer = component;
		}
		RectTransform rectTransform = rect;
		if ((object)rect == null || ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0)
		{
			RectTransform component2 = GetComponent<RectTransform>();
			rect = component2;
		}
		this.canvasRenderer.SetMaterial(Material, null);
		Mesh mesh = CreateNewMesh();
		this.canvasRenderer.SetMesh(mesh);
		if (!mask)
		{
			if (maskable)
			{
				SetMaskableSelf();
			}
			return;
		}
		SetStencilSelf();
		Image[] componentsInChildren = GetComponentsInChildren<Image>();
		childImage = componentsInChildren;
		Image[] array = childImage;
		if (array.Length != 0)
		{
			SetStencilChildren(array);
		}
	}

	private void Update()
	{
		//IL_0126: Invalid comparison between F4 and O
		//IL_0177: Invalid comparison between F4 and O
		//IL_008a->IL00db: Incompatible stack heights: 1 vs 0
		//IL_0057->IL00db: Incompatible stack heights: 1 vs 0
		//IL_00c2->IL00db: Incompatible stack heights: 1 vs 0
		//IL_01f3->IL00db: Incompatible stack heights: 2 vs 0
		//IL_0195->IL0066: Incompatible stack heights: 2 vs 1
		//IL_0237->IL0237: Incompatible stack heights: 3 vs 2
		RectTransform rectTransform = rect;
		if ((object)rect != null)
		{
			bool flag = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
			RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out Rect ret);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018736F799h\"");
			object obj = default(object);
			Rect ret2;
			if ((object)cachedWidth == obj)
			{
				RectTransform rectTransform2 = rect;
				if ((object)rect == null)
				{
					goto IL_00db;
				}
				bool flag2 = ((UnityEngine.Object)rectTransform2).m_CachedPtr == (IntPtr)0;
				RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform2).m_CachedPtr, out ret2);
				object obj2 = default(object);
				bool flag3 = (object)cachedHeight == obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018736F799h\"");
				if (flag3)
				{
					return;
				}
			}
			Mesh mesh = CreateNewMesh();
			if ((object)canvasRenderer != null)
			{
				canvasRenderer.SetMesh(mesh);
				RectTransform rectTransform3 = rect;
				if ((object)rect != null)
				{
					bool flag4 = ((UnityEngine.Object)rectTransform3).m_CachedPtr == (IntPtr)0;
					RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform3).m_CachedPtr, out ret2);
					RectTransform rectTransform4 = rect;
					float num = default(float);
					cachedWidth = num;
					if ((object)rect != null)
					{
						bool flag5 = ((UnityEngine.Object)rectTransform4).m_CachedPtr == (IntPtr)0;
						RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform4).m_CachedPtr, out ret);
						float num2 = default(float);
						cachedHeight = num2;
						return;
					}
				}
			}
		}
		goto IL_00db;
		IL_00db:
		throw new NullReferenceException();
	}

	private void OnEnable()
	{
		SetupMesh();
		canvasRenderer.cull = false;
	}

	private void OnDisable()
	{
		CanvasRenderer canvasRenderer = this.canvasRenderer;
		bool flag = ((UnityEngine.Object)canvasRenderer).m_CachedPtr == (IntPtr)0;
		CanvasRenderer.Clear_Injected(((UnityEngine.Object)canvasRenderer).m_CachedPtr);
		this.canvasRenderer.cull = true;
	}

	private unsafe Mesh CreateNewMesh()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0353: Expected O, but got Ref
		//IL_0378: Expected O, but got Ref
		//IL_03e5: Expected O, but got Ref
		//IL_01fe: Expected O, but got I
		//IL_00b6: Expected O, but got I
		//IL_00d3: Expected O, but got I
		//IL_00f0: Expected O, but got I
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_0436: Expected O, but got Ref
		//IL_01e1: Expected O, but got I
		//IL_045b: Expected O, but got Ref
		//IL_048a: Expected O, but got I
		//IL_0528: Expected I4, but got O
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_03ae->IL030f: Incompatible stack heights: 2 vs 0
		//IL_01bd->IL030f: Incompatible stack heights: 3 vs 0
		//IL_0182->IL030f: Incompatible stack heights: 3 vs 0
		//IL_04c9->IL030f: Incompatible stack heights: 5 vs 0
		//IL_0231->IL030f: Incompatible stack heights: 5 vs 0
		//IL_02f7->IL04ce: Incompatible stack heights: 7 vs 5
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Mesh mesh = UnityEngine.Object.Instantiate(this.mesh);
		Vector3[] array2;
		object obj13;
		if ((object)mesh != null)
		{
			Vector3[] vertices = mesh.vertices;
			baseVertices = vertices;
			Vector3[] array = baseVertices;
			if (baseVertices != null)
			{
				array2 = new Vector3[array.Length];
				_ = 0;
				_ = 0;
				bool flag = ((UnityEngine.Object)mesh).m_CachedPtr == (IntPtr)0;
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 15));
				Mesh.get_bounds_Injected(((UnityEngine.Object)mesh).m_CachedPtr, out *(Bounds*)obj3);
				_ = 0;
				_ = 0;
				bool flag2 = ((UnityEngine.Object)mesh).m_CachedPtr == (IntPtr)0;
				object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				Mesh.get_bounds_Injected(((UnityEngine.Object)mesh).m_CachedPtr, out *(Bounds*)obj4);
				RectTransform rectTransform = rect;
				if ((object)rect != null)
				{
					_ = 0;
					bool flag3 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
					object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
					RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out *(Rect*)obj5);
					bool flag4 = !preserveAspect;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-21]");
					_ = 0;
					if (!flag4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7]");
						object obj7 = num * 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B]");
						object obj8 = num2 * 0;
						object obj9 = obj7 + obj8;
						if ((nint)obj9 > 0)
						{
							object obj10 = obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7]");
							obj6 = obj10 / 0;
							object obj12 = default(object);
							object obj11 = obj12 / obj12;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11))
							{
								obj13 = obj12 * obj6;
								if ((object)rect == null)
								{
									goto IL_030f;
								}
								Vector2 pivot = rect.pivot;
								obj9 = obj12;
							}
							else
							{
								if ((object)rect == null)
								{
									goto IL_030f;
								}
								Vector2 pivot2 = rect.pivot;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-31]");
								obj13 = 0;
								obj9 = obj12;
							}
							goto IL_0565;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-31]");
					obj13 = 0;
					goto IL_0565;
				}
			}
		}
		goto IL_030f;
		IL_030f:
		throw new NullReferenceException();
		IL_0565:
		_ = 0;
		_ = 0;
		bool flag5 = ((UnityEngine.Object)mesh).m_CachedPtr == (IntPtr)0;
		object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		Mesh.get_bounds_Injected(((UnityEngine.Object)mesh).m_CachedPtr, out *(Bounds*)obj14);
		_ = 0;
		_ = 0;
		bool flag6 = ((UnityEngine.Object)mesh).m_CachedPtr == (IntPtr)0;
		object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
		Mesh.get_bounds_Injected(((UnityEngine.Object)mesh).m_CachedPtr, out *(Bounds*)obj15);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-21]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-15]");
		object obj16 = num3 + 0;
		object obj17 = obj13 / obj16;
		float num4 = (float)obj17 * 0.5f;
		bool flag7 = array2 == null;
		RectTransform rectTransform2 = null;
		RectTransform rectTransform3 = null;
		if (!flag7)
		{
			Array values = default(Array);
			int valuesArrayLength = default(int);
			int valuesStart = default(int);
			int valuesCount = default(int);
			while (true)
			{
				if ((nint)rectTransform3 < array2.Length)
				{
					Vector3[] array3 = baseVertices;
					if (baseVertices == null)
					{
						break;
					}
					bool flag8 = (nint)rectTransform2 >= array3.Length;
					object obj18 = rectTransform2 * 2;
					object obj19 = (object)rectTransform2 + obj18;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rdx_v38 (UnityEngine.Vector3[])+20+v1061 @ rcx_v57*4]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rdx_v38 (UnityEngine.Vector3[])+28+v1061 @ rcx_v57*4]");
					float num5 = 0f * num4;
					bool flag9 = (nint)rectTransform2 >= array2.Length;
					RectTransform rectTransform4 = (RectTransform)(rectTransform2 + 1);
					object obj20 = rectTransform2 * 2;
					object obj21 = (object)rectTransform2 + obj20;
					rectTransform2 = rectTransform4;
					rectTransform3 = rectTransform4;
					continue;
				}
				int length = array2.Length;
				mesh.SetSizedArrayForChannel(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, values, valuesArrayLength, valuesStart, valuesCount, (MeshUpdateFlags)array2);
				mesh.RecalculateNormals(MeshUpdateFlags.Default);
				mesh.RecalculateBounds(MeshUpdateFlags.Default);
				return mesh;
			}
		}
		goto IL_030f;
	}

	private void SetStencilSelf()
	{
		//IL_0126: Expected F4, but got I4
		Material material = UnityEngine.Object.Instantiate(Material);
		canvasRenderer.SetMaterial(material, null);
		Material material2 = canvasRenderer.GetMaterial();
		int num = Shader.PropertyToID("_Stencil");
		material2.SetFloatImpl(num, 1f);
		Material material3 = canvasRenderer.GetMaterial();
		int num2 = Shader.PropertyToID("_StencilComp");
		material3.SetFloatImpl(num2, 8f);
		Material material4 = canvasRenderer.GetMaterial();
		int num3 = Shader.PropertyToID("_StencilOp");
		material4.SetFloatImpl(num3, 2f);
		int num4;
		float value;
		Material material6;
		if (!showMaskGraphic)
		{
			Material material5 = canvasRenderer.GetMaterial();
			num4 = Shader.PropertyToID("_ColorMask");
			value = 0f;
			material6 = material5;
		}
		else
		{
			Material material7 = canvasRenderer.GetMaterial();
			num4 = Shader.PropertyToID("_ColorMask");
			value = 15f;
			material6 = material7;
		}
		material6.SetFloatImpl(num4, value);
	}

	private void SetMaskableSelf()
	{
		Material material = UnityEngine.Object.Instantiate(Material);
		canvasRenderer.SetMaterial(material, null);
		Material material2 = canvasRenderer.GetMaterial();
		int num = Shader.PropertyToID("_Stencil");
		material2.SetFloatImpl(num, 1f);
		Material material3 = canvasRenderer.GetMaterial();
		int num2 = Shader.PropertyToID("_StencilComp");
		material3.SetFloatImpl(num2, 3f);
		Material material4 = canvasRenderer.GetMaterial();
		int num3 = Shader.PropertyToID("_StencilOp");
		material4.SetFloatImpl(num3, 0f);
		Material material5 = canvasRenderer.GetMaterial();
		int num4 = Shader.PropertyToID("_StencilReadMask");
		material5.SetFloatImpl(num4, 1f);
		Material material6 = canvasRenderer.GetMaterial();
		int num5 = Shader.PropertyToID("_StencilWriteMask");
		material6.SetFloatImpl(num5, 0f);
	}

	private void SetStencilChildren(Image[] images)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < images.Length)
		{
			Image image = images[obj];
			if (((MaskableGraphic)image).m_Maskable)
			{
				Shader shader = Shader.Find("VampireSurvivors/WaveDeformShader");
				Material material = new Material(shader);
				Image image2 = images[obj];
				image2.material = material;
				Material material2 = images[obj].material;
				int num = Shader.PropertyToID("_Stencil");
				material2.SetFloatImpl(num, 1f);
				Material material3 = images[obj].material;
				int num2 = Shader.PropertyToID("_StencilComp");
				material3.SetFloatImpl(num2, 3f);
				Material material4 = images[obj].material;
				int num3 = Shader.PropertyToID("_StencilOp");
				material4.SetFloatImpl(num3, 0f);
				Material material5 = images[obj].material;
				int num4 = Shader.PropertyToID("_StencilReadMask");
				material5.SetFloatImpl(num4, 1f);
				Material material6 = images[obj].material;
				int num5 = Shader.PropertyToID("_StencilWriteMask");
				material6.SetFloatImpl(num5, 0f);
			}
			obj++;
			obj2 = obj;
		}
	}

	private void OnValidate()
	{
		//IL_0020: Expected O, but got I4
		object obj = Application.isPlaying;
		if (obj == null)
		{
			SetupMesh();
		}
	}

	public UIMeshRenderer()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
