using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coffee.UIParticleExtensions;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Coffee.UIExtensions;

internal class UIParticleRenderer : MaskableGraphic
{
	private static readonly CombineInstance[] s_CombineInstances;

	private static readonly List<Material> s_Materials;

	private static MaterialPropertyBlock s_Mpb;

	private static readonly List<UIParticleRenderer> s_Renderers;

	private static readonly Vector3[] s_Corners;

	private ParticleSystemRenderer _renderer;

	private ParticleSystem _particleSystem;

	private int _prevParticleCount;

	private UIParticle _parent;

	private int _index;

	private bool _isTrail;

	private Material _modifiedMaterial;

	private Vector3 _prevScale;

	private Vector3 _prevPsPos;

	private Vector2Int _prevScreenSize;

	private bool _delay;

	private bool _prewarm;

	private Material _currentMaterialForRendering;

	private Bounds _lastBounds;

	public override Texture mainTexture
	{
		get
		{
			if (_isTrail)
			{
				return null;
			}
			return ParticleSystemExtensions.GetTextureForSprite(_particleSystem);
		}
	}

	public override bool raycastTarget => false;

	private unsafe Rect rootCanvasRect
	{
		get
		{
			//IL_03db: Expected O, but got I
			//IL_0430: Expected O, but got I
			//IL_0449: Expected O, but got I4
			//IL_0474: Unknown result type (might be due to invalid IL or missing references)
			//IL_0479: Expected O, but got Unknown
			//IL_059c: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a1: Expected O, but got Unknown
			//IL_05be: Expected F4, but got I
			//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_04da: Expected O, but got Unknown
			//IL_0509: Expected F4, but got O
			//IL_0252: Unknown result type (might be due to invalid IL or missing references)
			//IL_0257: Expected O, but got Unknown
			//IL_0292: Unknown result type (might be due to invalid IL or missing references)
			//IL_0297: Expected O, but got Unknown
			//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ac: Expected O, but got Unknown
			//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d0: Expected O, but got Unknown
			//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0303: Expected O, but got Unknown
			//IL_0358: Unknown result type (might be due to invalid IL or missing references)
			//IL_035d: Expected O, but got Unknown
			//IL_0366: Unknown result type (might be due to invalid IL or missing references)
			//IL_036b: Expected O, but got Unknown
			//IL_05e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ee: Expected O, but got Unknown
			//IL_05f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_05fc: Expected O, but got Unknown
			//IL_0619: Invalid comparison between F4 and I
			//IL_0542: Unknown result type (might be due to invalid IL or missing references)
			//IL_0547: Expected O, but got Unknown
			//IL_0564: Expected O, but got I
			//IL_056c: Expected F4, but got O
			//IL_072a: Unknown result type (might be due to invalid IL or missing references)
			//IL_072f: Expected O, but got Unknown
			//IL_0738: Unknown result type (might be due to invalid IL or missing references)
			//IL_073d: Expected O, but got Unknown
			//IL_075a: Expected F4, but got I
			//IL_0a63: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a68: Expected O, but got Unknown
			//IL_0a7f: Expected O, but got F4
			//IL_0658: Unknown result type (might be due to invalid IL or missing references)
			//IL_065d: Expected O, but got Unknown
			//IL_0666: Unknown result type (might be due to invalid IL or missing references)
			//IL_066b: Expected O, but got Unknown
			//IL_0688: Invalid comparison between I and F4
			//IL_0785: Expected native int or pointer, but got O
			//IL_0792: Expected native int or pointer, but got O
			//IL_079f: Expected native int or pointer, but got O
			//IL_07ac: Expected native int or pointer, but got O
			//IL_06ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_06cf: Expected O, but got Unknown
			//IL_06d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_06dd: Expected O, but got Unknown
			//IL_06fa: Expected F4, but got I
			//IL_080f->IL07b6: Incompatible stack heights: 1 vs 0
			//IL_0065->IL07b6: Incompatible stack heights: 2 vs 0
			//IL_0861->IL07b6: Incompatible stack heights: 3 vs 0
			//IL_00ca->IL07b6: Incompatible stack heights: 4 vs 0
			//IL_08b3->IL07b6: Incompatible stack heights: 5 vs 0
			//IL_012f->IL07b6: Incompatible stack heights: 6 vs 0
			//IL_0905->IL07b6: Incompatible stack heights: 7 vs 0
			//IL_098d->IL07b6: Incompatible stack heights: 8 vs 0
			//IL_03fd->IL07b6: Incompatible stack heights: 9 vs 0
			//IL_01c9->IL07b6: Incompatible stack heights: 8 vs 0
			//IL_01f3->IL07b6: Incompatible stack heights: 8 vs 0
			//IL_021d->IL07b6: Incompatible stack heights: 8 vs 0
			//IL_09b4->IL07b6: Incompatible stack heights: 10 vs 0
			//IL_0a2e->IL07b6: Incompatible stack heights: 11 vs 0
			//IL_09db->IL07b6: Incompatible stack heights: 11 vs 0
			//IL_0b2f->IL07b6: Incompatible stack heights: 9 vs 0
			//IL_03a2->IL0966: Incompatible stack heights: 10 vs 9
			//IL_0b56->IL07b6: Incompatible stack heights: 12 vs 0
			//IL_03a7->IL03a7: Incompatible stack heights: 10 vs 8
			//IL_0a07->IL07b6: Incompatible stack heights: 12 vs 0
			//IL_0ad6->IL07b6: Incompatible stack heights: 13 vs 0
			//IL_0571->IL09e0: Incompatible stack heights: 13 vs 12
			//IL_0a55->IL07b6: Incompatible stack heights: 13 vs 0
			//IL_0a88->IL0b5b: Incompatible stack heights: 14 vs 10
			//IL_0aaf->IL07b6: Incompatible stack heights: 14 vs 0
			//IL_06ff->IL0a5a: Incompatible stack heights: 15 vs 14
			Vector3[] array = s_Corners;
			Transform transform = base.transform;
			float num2 = default(float);
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				float position = default(float);
				Transform.TransformPoint_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&position), out Vector3 ret);
				if (s_Corners != null)
				{
					bool flag2 = array.Length <= 0;
					_ = 0;
					Vector3[] array2 = s_Corners;
					Transform transform2 = base.transform;
					if ((object)transform2 != null)
					{
						bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.TransformPoint_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&position), out ret);
						if (s_Corners != null)
						{
							bool flag4 = array2.Length <= 1;
							_ = 0;
							Vector3[] array3 = s_Corners;
							Transform transform3 = base.transform;
							if ((object)transform3 != null)
							{
								bool flag5 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								Transform.TransformPoint_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)(&position), out ret);
								if (s_Corners != null)
								{
									bool flag6 = array3.Length <= 2;
									_ = 0;
									Vector3[] array4 = s_Corners;
									Transform transform4 = base.transform;
									if ((object)transform4 != null)
									{
										bool flag7 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
										Transform.TransformPoint_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Vector3*)(&position), out ret);
										if (s_Corners != null)
										{
											bool flag8 = array4.Length <= 3;
											_ = 0;
											Canvas canvas = base.canvas;
											if ((object)canvas == null || ((UnityEngine.Object)canvas).m_CachedPtr == (IntPtr)0)
											{
												goto IL_096b;
											}
											Canvas canvas2 = base.canvas;
											if ((object)canvas2 != null)
											{
												Canvas rootCanvas = canvas2.rootCanvas;
												if ((object)rootCanvas != null)
												{
													Transform transform5 = rootCanvas.transform;
													if ((object)transform5 != null)
													{
														bool flag9 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
														Transform.get_worldToLocalMatrix_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out Matrix4x4 _);
														UIParticleRenderer uIParticleRenderer = null;
														object obj3 = default(object);
														object obj4 = default(object);
														object obj6 = default(object);
														object obj8 = default(object);
														object obj10 = default(object);
														object obj12 = default(object);
														object obj13 = default(object);
														object obj14 = default(object);
														while (true)
														{
															Vector3[] array5 = s_Corners;
															if (s_Corners == null)
															{
																break;
															}
															bool flag10 = (nint)uIParticleRenderer >= array5.Length;
															object obj = uIParticleRenderer * 2;
															object obj2 = (object)uIParticleRenderer + obj;
															float num = (float)obj3 * num2;
															float num3 = (float)obj4 * num2;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ r8_v25 (UnityEngine.Vector3[])+20+v2213 @ rcx_v102*4]");
															object obj5 = obj6 * 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ r8_v25 (UnityEngine.Vector3[])+28+v2213 @ rcx_v102*4]");
															object obj7 = obj8 * 0;
															float num4 = num + (float)obj5;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ r8_v25 (UnityEngine.Vector3[])+20+v2213 @ rcx_v102*4]");
															object obj9 = obj10 * 0;
															float num5 = num4 + (float)obj7;
															float num6 = num3 + (float)obj9;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ r8_v25 (UnityEngine.Vector3[])+28+v2213 @ rcx_v102*4]");
															object obj11 = obj12 * 0;
															float num7 = num5 + (float)obj13;
															float num8 = num6 + (float)obj11;
															float num9 = num8 + (float)obj14;
															float num10 = 1f / num9;
															float num11 = num7 * num10;
															UIParticleRenderer uIParticleRenderer2 = (UIParticleRenderer)(uIParticleRenderer + 1);
															object obj15 = uIParticleRenderer * 2;
															object obj16 = (object)uIParticleRenderer + obj15;
															bool flag11 = (nint)uIParticleRenderer2 < 4;
															uIParticleRenderer = uIParticleRenderer2;
															if (!flag11)
															{
																goto IL_096b;
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
			goto IL_07b6;
			IL_07b6:
			throw new NullReferenceException();
			IL_096b:
			Vector3[] array6 = s_Corners;
			if (s_Corners != null)
			{
				bool flag12 = array6.Length <= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v389 @ rax_v77 (UnityEngine.Vector3[])+20]");
				Vector3 vector = (Vector3)0;
				Vector3[] array7 = s_Corners;
				if (s_Corners != null)
				{
					bool flag13 = array7.Length <= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ rax_v79 (UnityEngine.Vector3[])+20]");
					Vector3 vector2 = (Vector3)0;
					float num12 = num2;
					float num13 = num2;
					UIParticleRenderer uIParticleRenderer3 = (UIParticleRenderer)1;
					Rect rect = default(Rect);
					while (true)
					{
						Vector3[] array8 = s_Corners;
						if (s_Corners == null)
						{
							break;
						}
						bool flag14 = (nint)uIParticleRenderer3 >= array8.Length;
						object obj17 = uIParticleRenderer3 * 2;
						object obj18 = (object)uIParticleRenderer3 + obj17;
						Vector3 vector3 = vector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ r8_v19 (UnityEngine.Vector3[])+20+v2044 @ rcx_v66*4]");
						bool num14;
						float num15;
						if ((nint)vector3 > 0)
						{
							Vector3[] array9 = s_Corners;
							if (s_Corners == null)
							{
								break;
							}
							bool flag15 = (nint)uIParticleRenderer3 >= array9.Length;
							num14 = flag15;
							object obj19 = uIParticleRenderer3 * 2;
							object obj20 = (object)uIParticleRenderer3 + obj19;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ r8_v21 (UnityEngine.Vector3[])+20+v2163 @ rcx_v82*4]");
							num15 = 0f;
						}
						else
						{
							Vector3[] array10 = s_Corners;
							if (s_Corners == null)
							{
								break;
							}
							bool flag16 = (nint)uIParticleRenderer3 >= array10.Length;
							num14 = flag16;
							object obj21 = uIParticleRenderer3 * 2;
							object obj22 = (object)uIParticleRenderer3 + obj21;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ r8_v22 (UnityEngine.Vector3[])+20+v2147 @ rcx_v85*4]");
							bool flag17 = 0 <= (nint)vector2;
							num15 = (float)vector;
							if (!flag17)
							{
								Vector3[] array11 = s_Corners;
								if (s_Corners == null)
								{
									break;
								}
								bool flag18 = (nint)uIParticleRenderer3 >= array11.Length;
								object obj23 = uIParticleRenderer3 * 2;
								object obj24 = (object)uIParticleRenderer3 + obj23;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ r8_v23 (UnityEngine.Vector3[])+20+v2180 @ rcx_v87*4]");
								vector2 = (Vector3)0;
								num15 = (float)vector;
							}
						}
						Vector3[] array12 = s_Corners;
						if (s_Corners == null)
						{
							break;
						}
						bool flag19 = (nint)uIParticleRenderer3 >= array12.Length;
						object obj25 = uIParticleRenderer3 + 3;
						object obj26 = obj25 * 2;
						object obj27 = obj25 + obj26;
						float num16 = num12;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v69 (UnityEngine.Vector3[])+v2273 @ rax_v89*4]");
						bool num17;
						if (num16 > 0f)
						{
							Vector3[] array13 = s_Corners;
							if (s_Corners == null)
							{
								break;
							}
							bool flag20 = (nint)uIParticleRenderer3 >= array13.Length;
							num17 = flag20;
							object obj28 = uIParticleRenderer3 + 3;
							object obj29 = obj28 * 2;
							object obj30 = obj28 + obj29;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ rcx_v72 (UnityEngine.Vector3[])+v2337 @ rax_v96*4]");
							num12 = 0f;
						}
						else
						{
							Vector3[] array14 = s_Corners;
							if (s_Corners == null)
							{
								break;
							}
							bool flag21 = (nint)uIParticleRenderer3 >= array14.Length;
							num17 = flag21;
							object obj31 = uIParticleRenderer3 + 3;
							object obj32 = obj31 * 2;
							object obj33 = obj31 + obj32;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rcx_v75 (UnityEngine.Vector3[])+v2320 @ rax_v102*4]");
							if (0f > num13)
							{
								Vector3[] array15 = s_Corners;
								if (s_Corners == null)
								{
									break;
								}
								bool flag22 = (nint)uIParticleRenderer3 >= array15.Length;
								object obj34 = uIParticleRenderer3 + 3;
								object obj35 = obj34 * 2;
								object obj36 = obj34 + obj35;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rcx_v77 (UnityEngine.Vector3[])+v2350 @ rax_v107*4]");
								num13 = 0f;
							}
						}
						uIParticleRenderer3 = (UIParticleRenderer)(uIParticleRenderer3 + 1);
						bool flag23 = (nint)uIParticleRenderer3 < 4;
						vector = (Vector3)num15;
						if (!flag23)
						{
							float width = (float)vector2 - num15;
							float height = num13 - num12;
							((Rect*)(nint)rect)->m_XMin = num15;
							((Rect*)(nint)rect)->m_YMin = num12;
							((Rect*)(nint)rect)->m_Width = width;
							((Rect*)(nint)rect)->m_Height = height;
							return rect;
						}
					}
				}
			}
			goto IL_07b6;
		}
	}

	public static UIParticleRenderer AddRenderer(UIParticle parent, int index)
	{
		//IL_01bc: Expected I, but got O
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0063: Expected I, but got O
		//IL_0140->IL018f: Incompatible stack heights: 1 vs 0
		Type[] array = new Type[1];
		nint num = (nint)typeof(UIParticleRenderer);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		if (array != null)
		{
			if (num != 0)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			GameObject gameObject = new GameObject("UIParticleRenderer", array);
			if ((object)gameObject != null)
			{
				gameObject.hideFlags = HideFlags.DontSave;
				if ((object)parent != null)
				{
					GameObject gameObject2 = parent.gameObject;
					if ((object)gameObject2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v37 (UnityEngine.GameObject)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v37 (UnityEngine.GameObject)+10]");
						int layer = GameObject.get_layer_Injected((IntPtr)0);
						gameObject.layer = layer;
						Transform transform = gameObject.transform;
						Transform parent2 = parent.transform;
						if ((object)transform != null)
						{
							transform.SetParent(parent2, worldPositionStays: false);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rax_v43 (UnityEngine.Transform)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rax_v43 (UnityEngine.Transform)+10]");
							Vector3 value = default(Vector3);
							Transform.set_localPosition_Injected((IntPtr)0, ref value);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rax_v43 (UnityEngine.Transform)+10]");
							bool flag3 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rax_v43 (UnityEngine.Transform)+10]");
							Quaternion value2 = default(Quaternion);
							Transform.set_localRotation_Injected((IntPtr)0, ref value2);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rax_v43 (UnityEngine.Transform)+10]");
							bool flag4 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rax_v43 (UnityEngine.Transform)+10]");
							Transform.set_localScale_Injected((IntPtr)0, ref value);
							UIParticleRenderer component = gameObject.GetComponent<UIParticleRenderer>();
							bool flag5 = (object)component == null;
							component._parent = parent;
							component._index = index;
							return component;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override Material GetModifiedMaterial(Material baseMaterial)
	{
		_currentMaterialForRendering = null;
		if (!base.IsActive())
		{
			return baseMaterial;
		}
		if (m_ShouldRecalculateStencil)
		{
			int stencilValue;
			if (!base.m_Maskable)
			{
				stencilValue = 0;
			}
			else
			{
				Transform start = base.transform;
				Transform stopAfter = MaskUtilities.FindRootSortOverrideCanvas(start);
				Transform transform = base.transform;
				stencilValue = MaskUtilities.GetStencilDepth(transform, stopAfter);
			}
			m_StencilValue = stencilValue;
			m_ShouldRecalculateStencil = false;
		}
		bool flag = m_StencilValue <= 0;
		Material material = baseMaterial;
		if (!flag)
		{
			bool flag2 = base.m_IsMaskingGraphic;
			material = baseMaterial;
			if (!flag2)
			{
				int num = m_StencilValue & 0x1F;
				int num2 = 1 << num;
				int stencilID = num2 - 1;
				ColorWriteMask colorWriteMask = default(ColorWriteMask);
				int readMask = default(int);
				int writeMask = default(int);
				Material maskMaterial = StencilMaterial.Add(baseMaterial, stencilID, StencilOp.Keep, CompareFunction.Equal, colorWriteMask, readMask, writeMask);
				StencilMaterial.Remove(m_MaskMaterial);
				m_MaskMaterial = maskMaterial;
				material = m_MaskMaterial;
			}
		}
		Texture texture = mainTexture;
		if ((object)texture != null && ((UnityEngine.Object)texture).m_CachedPtr != (IntPtr)0)
		{
			goto IL_020e;
		}
		UIParticle parent = _parent;
		Material material2;
		if ((object)_parent != null)
		{
			AnimatableProperty[] animatableProperties = parent.m_AnimatableProperties;
			if (parent.m_AnimatableProperties != null)
			{
				if (animatableProperties.Length != 0)
				{
					goto IL_020e;
				}
				ModifiedMaterial.Remove(_modifiedMaterial);
				_modifiedMaterial = null;
				material2 = material;
				goto IL_0376;
			}
		}
		goto IL_0307;
		IL_020e:
		UIParticle parent2 = _parent;
		if ((object)_parent != null)
		{
			AnimatableProperty[] animatableProperties2 = parent2.m_AnimatableProperties;
			if (parent2.m_AnimatableProperties != null)
			{
				bool flag3 = animatableProperties2.Length == 0;
				int id = 0;
				if (!flag3)
				{
					int instanceID = GetInstanceID();
					id = instanceID;
				}
				material2 = ModifiedMaterial.Add(material, texture, id);
				ModifiedMaterial.Remove(_modifiedMaterial);
				_modifiedMaterial = material2;
				goto IL_0376;
			}
		}
		goto IL_0307;
		IL_0307:
		return (Material)(object)new NullReferenceException();
		IL_0376:
		return material2;
	}

	public void Clear(int index = -1)
	{
		//IL_0137: Expected O, but got I4
		ParticleSystemRenderer renderer = _renderer;
		if ((object)_renderer != null && ((UnityEngine.Object)renderer).m_CachedPtr != (IntPtr)0)
		{
			_renderer.enabled = true;
		}
		_parent = null;
		_particleSystem = null;
		_renderer = null;
		_prevParticleCount = 0;
		if (index >= 0)
		{
			_index = index;
		}
		if (((UnityEngine.Object)this).m_CachedPtr != (IntPtr)0 && base.IsActive())
		{
			base.material = null;
			Mesh mesh = Graphic.workerMesh;
			mesh.ClearImpl(true);
			CanvasRenderer canvasRenderer = base.canvasRenderer;
			Mesh mesh2 = Graphic.workerMesh;
			canvasRenderer.SetMesh(mesh2);
			_lastBounds = (Bounds)0;
			_ = 0;
			base.enabled = false;
		}
	}

	public void Set(UIParticle parent, ParticleSystem particleSystem, bool isTrail)
	{
		//IL_009c: Expected O, but got I4
		//IL_0578: Expected O, but got I4
		//IL_05a5: Expected O, but got I
		//IL_013f: Expected O, but got I4
		//IL_02a3: Expected I4, but got O
		//IL_0623: Expected O, but got I
		//IL_0664: Expected O, but got F4
		//IL_037a: Expected O, but got I
		//IL_03df: Expected O, but got I
		//IL_07fc: Expected O, but got I4
		//IL_0714: Expected O, but got I4
		//IL_0543->IL04b1: Incompatible stack heights: 1 vs 0
		//IL_00c5->IL04b1: Incompatible stack heights: 1 vs 0
		//IL_015e->IL04b1: Incompatible stack heights: 2 vs 0
		//IL_00ee->IL04b1: Incompatible stack heights: 2 vs 0
		//IL_011d->IL04b1: Incompatible stack heights: 2 vs 0
		//IL_07c4->IL04b1: Incompatible stack heights: 2 vs 0
		//IL_0195->IL0798: Incompatible stack heights: 3 vs 2
		//IL_01cb->IL04b1: Incompatible stack heights: 2 vs 0
		//IL_05e7->IL04b1: Incompatible stack heights: 2 vs 0
		//IL_0221->IL04b1: Incompatible stack heights: 2 vs 0
		//IL_0270->IL04b1: Incompatible stack heights: 3 vs 0
		//IL_060e->IL04b1: Incompatible stack heights: 4 vs 0
		//IL_0688->IL04b1: Incompatible stack heights: 4 vs 0
		//IL_036a->IL07c9: Incompatible stack heights: 5 vs 4
		//IL_045b->IL04b1: Incompatible stack heights: 4 vs 0
		//IL_03cf->IL068d: Incompatible stack heights: 5 vs 4
		//IL_0434->IL06b7: Incompatible stack heights: 5 vs 4
		//IL_0756->IL04b1: Incompatible stack heights: 5 vs 0
		_parent = parent;
		ParticleSystem particleSystem2 = default(ParticleSystem);
		if ((object)parent != null)
		{
			if (((MaskableGraphic)parent).m_Maskable != base.m_Maskable)
			{
				base.m_Maskable = ((MaskableGraphic)parent).m_Maskable;
				m_ShouldRecalculateStencil = true;
				base.SetMaterialDirty();
			}
			GameObject gameObject = base.gameObject;
			GameObject gameObject2 = parent.gameObject;
			if ((object)gameObject2 != null)
			{
				bool flag = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
				int num = GameObject.get_layer_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr);
				if ((object)gameObject != null)
				{
					gameObject.layer = num;
					_particleSystem = particleSystem2;
					int num2 = num;
					object obj = 0;
					UIParticle particleSystem3 = (UIParticle)(object)_particleSystem;
					if ((object)_particleSystem != null)
					{
						bool flag2 = ((UnityEngine.Object)particleSystem3).m_CachedPtr == (IntPtr)0;
						object obj2 = ParticleSystem.get_isPlaying_Injected(((UnityEngine.Object)particleSystem3).m_CachedPtr);
						if (obj2 == null)
						{
							goto IL_0144;
						}
						if ((object)_particleSystem != null)
						{
							_particleSystem.Clear(withChildren: true);
							if ((object)_particleSystem != null)
							{
								_particleSystem.Pause();
								num2 = 0;
								obj = 0;
								goto IL_0144;
							}
						}
					}
				}
			}
		}
		goto IL_04b1;
		IL_0144:
		if ((object)_particleSystem != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8D0]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8D0]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag3 = obj3 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1098 @ rax_v65 (should have been resolved before IL gen)");
			bool prewarm = default(bool);
			_prewarm = prewarm;
			if ((object)particleSystem2 != null)
			{
				ParticleSystemRenderer component = particleSystem2.GetComponent<ParticleSystemRenderer>();
				_renderer = component;
				if ((object)_renderer != null)
				{
					_renderer.enabled = false;
					bool flag4 = default(bool);
					_isTrail = flag4;
					if ((object)_renderer != null)
					{
						_renderer.GetSharedMaterials(s_Materials);
						List<Material> list = s_Materials;
						if (s_Materials != null)
						{
							bool flag5 = (flag4 ? 1 : 0) >= list._size;
							Material[] items = list._items;
							if (list._items != null)
							{
								bool flag6 = (flag4 ? 1 : 0) >= items.Length;
								int num3 = (int)items[flag4 ? 1u : 0u];
								base.material = items[flag4 ? 1u : 0u];
								List<Material> list2 = s_Materials;
								if (s_Materials != null)
								{
									int version = list2._version + 1;
									list2._version = version;
									list2._size = 0;
									if (list2._size > 0)
									{
										Array.Clear(list2._items, 0, list2._size);
										num3 = 0;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB70]");
									object obj4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB70]");
									if ((nint)0 == 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
										bool flag7 = obj4 == null;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1627 @ rax_v81 (should have been resolved before IL gen)");
									object obj5 = default(object);
									if ((nint)obj5 == 1)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB98]");
										object obj6 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB98]");
										if ((nint)0 == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
											bool flag8 = obj6 == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1721 @ rax_v115 (should have been resolved before IL gen)");
										object obj7 = default(object);
										if (obj7 == null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBA0]");
											object obj8 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBA0]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
												bool flag9 = obj8 == null;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1745 @ rax_v118 (should have been resolved before IL gen)");
										}
									}
									Vector3 worldScale = GetWorldScale();
									_prevScale = (Vector3)worldScale.x;
									_ = worldScale.z;
									if ((object)_particleSystem != null)
									{
										Transform transform = _particleSystem.transform;
										if ((object)transform != null)
										{
											bool flag10 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
											Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
											_prevPsPos = ret;
											_ = 0;
											ParticleSystem prevScreenSize = (ParticleSystem)Screen.width;
											object obj9 = Screen.height;
											_prevScreenSize = (Vector2Int)prevScreenSize;
											_delay = true;
											_prevParticleCount = 0;
											CanvasRenderer canvasRenderer = base.canvasRenderer;
											if ((object)canvasRenderer != null)
											{
												bool flag11 = ((UnityEngine.Object)canvasRenderer).m_CachedPtr == (IntPtr)0;
												nint num4 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1852 @ rcx_v86 (Il2CppMethodInfo)+38]");
												if ((nint)0 == 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
												}
												CanvasRenderer.SetTexture_Injected(((UnityEngine.Object)canvasRenderer).m_CachedPtr, (IntPtr)0);
												base.enabled = true;
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
		goto IL_04b1;
		IL_04b1:
		throw new NullReferenceException();
	}

	public unsafe void UpdateMesh(Camera bakeCamera)
	{
		//IL_0008: Expected O, but got Ref
		//IL_19d7: Expected O, but got I4
		//IL_19ab: Expected O, but got I4
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected F4, but got Unknown
		//IL_026a: Invalid comparison between F4 and I4
		//IL_0361: Expected O, but got I
		//IL_1a26: Expected O, but got Ref
		//IL_1a83: Expected O, but got F4
		//IL_057a: Expected O, but got Ref
		//IL_0592: Expected O, but got Ref
		//IL_0952: Unknown result type (might be due to invalid IL or missing references)
		//IL_0957: Expected O, but got Unknown
		//IL_1aff: Expected O, but got Ref
		//IL_1b2e: Expected O, but got Ref
		//IL_06b7: Expected O, but got I
		//IL_1b4a: Expected O, but got Ref
		//IL_1bc2: Expected O, but got F4
		//IL_1bd1: Expected O, but got F4
		//IL_071c: Expected O, but got I
		//IL_0656: Expected O, but got Ref
		//IL_1b8a: Expected O, but got Ref
		//IL_0684: Expected O, but got Ref
		//IL_06a2: Expected O, but got Ref
		//IL_0a77: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7c: Expected O, but got Unknown
		//IL_09f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fd: Expected O, but got Unknown
		//IL_0d60: Expected O, but got Ref
		//IL_0d60: Expected O, but got Ref
		//IL_0d77: Expected O, but got Ref
		//IL_0dac: Expected O, but got F4
		//IL_0dc3: Expected O, but got Ref
		//IL_1cfd: Expected O, but got Ref
		//IL_1d2d: Expected O, but got F4
		//IL_1d44: Expected O, but got Ref
		//IL_1d56: Expected O, but got Ref
		//IL_1d56: Expected O, but got Ref
		//IL_1d68: Expected O, but got Ref
		//IL_1d9d: Expected O, but got F4
		//IL_1db4: Expected O, but got Ref
		//IL_0ed5: Expected F4, but got I
		//IL_1e49: Expected O, but got I
		//IL_1150: Expected I4, but got O
		//IL_1162: Expected I4, but got O
		//IL_1fcc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd1: Expected O, but got Unknown
		//IL_1ef7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1efc: Expected O, but got Unknown
		//IL_1403: Expected F4, but got I
		//IL_140d: Expected F4, but got O
		//IL_187a: Unknown result type (might be due to invalid IL or missing references)
		//IL_187f: Expected O, but got Unknown
		//IL_194b->IL19b6: Incompatible stack heights: 1 vs 0
		//IL_198e->IL19b6: Incompatible stack heights: 1 vs 0
		//IL_0153->IL19b6: Incompatible stack heights: 1 vs 0
		//IL_019c->IL19b6: Incompatible stack heights: 1 vs 0
		//IL_01dc->IL19b6: Incompatible stack heights: 1 vs 0
		//IL_029b->IL19b6: Incompatible stack heights: 1 vs 0
		//IL_03d8->IL19b6: Incompatible stack heights: 1 vs 0
		//IL_02d7->IL19b6: Incompatible stack heights: 1 vs 0
		//IL_033d->IL19b6: Incompatible stack heights: 1 vs 0
		//IL_1a9b->IL1925: Incompatible stack heights: 2 vs 1
		//IL_03b6->IL1a18: Incompatible stack heights: 2 vs 1
		//IL_0401->IL19b6: Incompatible stack heights: 2 vs 0
		//IL_043e->IL19b6: Incompatible stack heights: 2 vs 0
		//IL_046a->IL19b6: Incompatible stack heights: 2 vs 0
		//IL_087d->IL19b6: Incompatible stack heights: 2 vs 0
		//IL_04ca->IL19b6: Incompatible stack heights: 2 vs 0
		//IL_1c58->IL19b6: Incompatible stack heights: 2 vs 0
		//IL_05b6->IL19b6: Incompatible stack heights: 2 vs 0
		//IL_097e->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_061c->IL19b6: Incompatible stack heights: 2 vs 0
		//IL_0b02->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_070c->IL1b3c: Incompatible stack heights: 3 vs 2
		//IL_1ca6->IL19b6: Incompatible stack heights: 2 vs 0
		//IL_1bae->IL19b6: Incompatible stack heights: 2 vs 0
		//IL_1c7f->IL19b6: Incompatible stack heights: 2 vs 0
		//IL_0771->IL1b7c: Incompatible stack heights: 3 vs 2
		//IL_1ddf->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_0bec->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_0aa3->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_0a22->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_07b6->IL19b6: Incompatible stack heights: 2 vs 0
		//IL_0d16->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_0c18->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_0d40->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_0c44->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_084a->IL19b6: Incompatible stack heights: 2 vs 0
		//IL_1fb9->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_07f2->IL19b6: Incompatible stack heights: 2 vs 0
		//IL_0c70->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_0fe1->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_1cd2->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_1c36->IL1bb3: Incompatible stack heights: 3 vs 2
		//IL_1dfc->IL19b6: Incompatible stack heights: 4 vs 0
		//IL_0ca9->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_0cd3->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_122a->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_0e7a->IL19b6: Incompatible stack heights: 4 vs 0
		//IL_1e9b->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_1470->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_0eb3->IL19b6: Incompatible stack heights: 4 vs 0
		//IL_127a->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_156b->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_1ec2->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_12c9->IL19b6: Incompatible stack heights: 4 vs 0
		//IL_15ac->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_1e74->IL1cab: Incompatible stack heights: 6 vs 3
		//IL_1ee9->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_18ab->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_1523->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_111d->IL19b6: Incompatible stack heights: 4 vs 0
		//IL_18fe->IL1924: Incompatible stack heights: 3 vs 1
		//IL_1924->IL1924: Incompatible stack heights: 3 vs 1
		//IL_1643->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_116b->IL19b6: Incompatible stack heights: 5 vs 0
		//IL_1fd6->IL1f3a: Incompatible stack heights: 5 vs 3
		//IL_135a->IL19b6: Incompatible stack heights: 5 vs 0
		//IL_1f01->IL1fbe: Incompatible stack heights: 5 vs 3
		//IL_1693->IL19b6: Incompatible stack heights: 3 vs 0
		//IL_1381->IL19b6: Incompatible stack heights: 5 vs 0
		//IL_16e2->IL19b6: Incompatible stack heights: 4 vs 0
		//IL_13b9->IL19b6: Incompatible stack heights: 5 vs 0
		//IL_13e4->IL19b6: Incompatible stack heights: 5 vs 0
		//IL_1425->IL19b6: Incompatible stack heights: 5 vs 0
		//IL_1884->IL1f78: Incompatible stack heights: 5 vs 3
		//IL_1773->IL19b6: Incompatible stack heights: 5 vs 0
		//IL_179a->IL19b6: Incompatible stack heights: 5 vs 0
		//IL_17c4->IL19b6: Incompatible stack heights: 5 vs 0
		//IL_17f0->IL19b6: Incompatible stack heights: 5 vs 0
		//IL_1817->IL19b6: Incompatible stack heights: 5 vs 0
		//IL_1841->IL19b6: Incompatible stack heights: 5 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		float num2 = default(float);
		Vector3 worldScale;
		Vector3 position;
		float x = default(float);
		ParticleSystemBakeMeshOptions particleSystemBakeMeshOptions = default(ParticleSystemBakeMeshOptions);
		float num7;
		float num8;
		if ((object)this != null)
		{
			bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			object obj3 = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
			if (obj3 != null)
			{
				ParticleSystem particleSystem = _particleSystem;
				if ((object)_particleSystem != null && ((UnityEngine.Object)particleSystem).m_CachedPtr != (IntPtr)0 && (bool)_parent)
				{
					CanvasRenderer canvasRenderer = base.canvasRenderer;
					if ((bool)canvasRenderer)
					{
						Canvas canvas = base.canvas;
						if ((bool)canvas && (bool)bakeCamera)
						{
							UIParticle parent = _parent;
							if ((object)_parent != null)
							{
								if (parent.m_MeshSharing == UIParticle.MeshSharing.Reprica)
								{
									goto IL_192a;
								}
								Transform transform = base.transform;
								if ((object)transform != null)
								{
									Vector3 lossyScale = transform.lossyScale;
									UIParticle parent2 = _parent;
									_ = lossyScale.x;
									if ((object)_parent != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
										object obj4 = 0 * parent2.m_Scale3D;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-3C]");
										float num = 0f * num2;
										float num3 = lossyScale.z;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ rax_v71 (Coffee.UIExtensions.UIParticle)+EC]");
										float num4 = num3 * 0f;
										float num5 = (float)obj4 * num;
										float num6 = num5 * num4;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
										num7 = num6 & 0;
										if (!(num7 > 0f))
										{
											goto IL_192a;
										}
										if ((object)_particleSystem != null)
										{
											if (!_particleSystem.IsAlive())
											{
												if ((object)_particleSystem == null)
												{
													goto IL_19b6;
												}
												if (!_particleSystem.isPlaying)
												{
													goto IL_192a;
												}
											}
											if (_isTrail)
											{
												if ((object)_particleSystem == null)
												{
													goto IL_19b6;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCF8]");
												object obj5 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCF8]");
												if ((nint)0 == 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
													bool flag2 = obj5 == null;
												}
												object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 304));
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2976 @ rax_v317 (should have been resolved before IL gen)");
												object obj7 = default(object);
												if (obj7 == null)
												{
													goto IL_192a;
												}
											}
											CanvasRenderer canvasRenderer2 = base.canvasRenderer;
											if ((object)canvasRenderer2 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ rax_v75 (UnityEngine.CanvasRenderer)+10]");
												bool flag3 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ rax_v75 (UnityEngine.CanvasRenderer)+10]");
												object obj8 = CanvasRenderer.GetInheritedAlpha_Injected((IntPtr)0);
												if (0.01f > num2)
												{
													goto IL_192a;
												}
												if ((object)_particleSystem != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
													worldScale = GetWorldScale();
													if ((object)_particleSystem != null)
													{
														Transform transform2 = _particleSystem.transform;
														if ((object)transform2 != null)
														{
															position = transform2.position;
															bool flag4 = _isTrail;
															num8 = num2;
															if (flag4)
															{
																goto IL_0859;
															}
															UIParticle parent3 = _parent;
															if ((object)_parent != null)
															{
																if (parent3.m_MeshSharing != UIParticle.MeshSharing.None && parent3.m_MeshSharing != UIParticle.MeshSharing.Auto && parent3.m_MeshSharing != UIParticle.MeshSharing.Primary)
																{
																	bool flag5 = parent3.m_MeshSharing != UIParticle.MeshSharing.PrimarySimulator;
																	num8 = num2;
																	if (flag5)
																	{
																		goto IL_1aa0;
																	}
																}
																_ = worldScale.x;
																Vector3 scale = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
																_ = worldScale.z;
																ResolveResolutionChange((Vector3)(&x), scale);
																UIParticle parent4 = _parent;
																if ((object)_parent != null)
																{
																	bool flag6 = parent4._003CisPaused_003Ek__BackingField;
																	bool flag7 = true;
																	if (!flag6)
																	{
																		flag7 = _delay;
																	}
																	bool flag8 = !flag7;
																	bool paused = !flag8;
																	Simulate((Vector3)(&x), paused);
																	bool flag9 = !_delay;
																	x = worldScale.x;
																	particleSystemBakeMeshOptions = ParticleSystemBakeMeshOptions.Default;
																	Vector3 vector = (Vector3)(&x);
																	if (!flag9)
																	{
																		UIParticle parent5 = _parent;
																		if ((object)_parent == null)
																		{
																			goto IL_19b6;
																		}
																		bool flag10 = parent5._003CisPaused_003Ek__BackingField;
																		x = worldScale.x;
																		particleSystemBakeMeshOptions = ParticleSystemBakeMeshOptions.Default;
																		vector = (Vector3)(&x);
																		if (!flag10)
																		{
																			paused = parent5._003CisPaused_003Ek__BackingField;
																			Simulate((Vector3)(&x), parent5._003CisPaused_003Ek__BackingField);
																			x = worldScale.x;
																			particleSystemBakeMeshOptions = ParticleSystemBakeMeshOptions.Default;
																			vector = (Vector3)(&x);
																		}
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8C0]");
																	object obj9 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8C0]");
																	if ((nint)0 == 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
																		bool flag11 = obj9 == null;
																	}
																	object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 328));
																	Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3338 @ rax_v293 (should have been resolved before IL gen)");
																	object obj11 = default(object);
																	bool flag12 = obj11 != null;
																	num8 = num2;
																	if (flag12)
																	{
																		goto IL_1bb3;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8B0]");
																	object obj12 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8B0]");
																	if ((nint)0 == 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
																		bool flag13 = obj12 == null;
																	}
																	object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 328));
																	Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3462 @ rax_v297 (should have been resolved before IL gen)");
																	if ((object)_particleSystem != null)
																	{
																		num8 = _particleSystem.time;
																		if (num8 < num2)
																		{
																			goto IL_1bb3;
																		}
																		if ((object)_particleSystem != null)
																		{
																			if (!_particleSystem.IsAlive())
																			{
																				if ((object)_particleSystem == null)
																				{
																					goto IL_19b6;
																				}
																				if (_particleSystem.particleCount != 0)
																				{
																					goto IL_1bb3;
																				}
																			}
																			object particleSystem2 = _particleSystem;
																			if ((object)_particleSystem != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ rdi_v54 (System.Object)+10]");
																				bool flag14 = (nint)0 == 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ rdi_v54 (System.Object)+10]");
																				ParticleSystem.Stop_Injected((IntPtr)0, false, ParticleSystemStopBehavior.StopEmitting);
																				goto IL_1bb3;
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
							goto IL_19b6;
						}
					}
				}
			}
			goto IL_192a;
		}
		goto IL_19b6;
		IL_0dcc:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2802 @ rdi_v41 (System.Object)+18]");
		bool flag15 = (nint)0 <= (nint)0;
		Matrix4x4 matrix4x;
		num7 = matrix4x.m03;
		_ = matrix4x.m00;
		_ = matrix4x.m01;
		_ = matrix4x.m02;
		_ = matrix4x.m03;
		Mesh mesh = Graphic.workerMesh;
		bool flag16 = default(bool);
		if ((object)mesh != null)
		{
			mesh.CombineMeshesImpl(s_CombineInstances, true, true, flag16);
			Mesh mesh2 = Graphic.workerMesh;
			if ((object)mesh2 != null)
			{
				mesh2.RecalculateBounds(MeshUpdateFlags.Default);
				Mesh mesh3 = Graphic.workerMesh;
				if ((object)mesh3 != null)
				{
					Bounds bounds = mesh3.bounds;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4293 @ rax_v221 (UnityEngine.Bounds)+10]");
					float num = 0f;
					_ = bounds.m_Center;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4293 @ rax_v221 (UnityEngine.Bounds)+10]");
					_ = 0;
					_ = 0;
					Mesh mesh4 = Graphic.workerMesh;
					bool flag17 = (object)mesh4 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2719 @ rax_v222 (UnityEngine.Mesh)+10]");
					bool flag18 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2719 @ rax_v222 (UnityEngine.Mesh)+10]");
					Bounds value = default(Bounds);
					Mesh.set_bounds_Injected((IntPtr)0, ref value);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
					_lastBounds = (Bounds)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
					_ = 0;
					bool flag19 = true;
					float num9 = num2;
					num8 = num2;
					goto IL_1f97;
				}
			}
		}
		goto IL_19b6;
		IL_0ade:
		UIParticle parent6 = _parent;
		ParticleSystemBakeMeshOptions particleSystemBakeMeshOptions2;
		if ((object)_parent != null)
		{
			if (parent6.m_MeshSharing != UIParticle.MeshSharing.None && parent6.m_MeshSharing != UIParticle.MeshSharing.Auto && parent6.m_MeshSharing != UIParticle.MeshSharing.Primary)
			{
				bool flag20 = parent6.m_MeshSharing != UIParticle.MeshSharing.PrimarySimulator;
				bool flag19 = (byte)particleSystemBakeMeshOptions2 != 0;
				float num9 = 0.01f;
				if (flag20)
				{
					goto IL_1f97;
				}
			}
			UIParticle parent7 = _parent;
			float num10 = default(float);
			float num11 = default(float);
			if (!parent7.m_AbsoluteMode)
			{
				if ((object)_particleSystem != null)
				{
					Transform transform3 = _particleSystem.transform;
					if ((object)transform3 != null)
					{
						Vector3 position2 = transform3.position;
						if ((object)_parent != null)
						{
							Transform transform4 = _parent.transform;
							if ((object)transform4 != null)
							{
								Vector3 position3 = transform4.position;
								object obj14 = s_CombineInstances;
								if (s_CombineInstances != null)
								{
									CanvasRenderer canvasRenderer3 = base.canvasRenderer;
									if ((object)canvasRenderer3 != null)
									{
										Transform transform5 = canvasRenderer3.transform;
										if ((object)transform5 != null)
										{
											Matrix4x4 worldToLocalMatrix = transform5.worldToLocalMatrix;
											_ = Vector3.oneVector;
											_ = 0;
											_ = 1065353216;
											_ = 1065353216;
											Matrix4x4 matrix4x2 = (Matrix4x4)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
											_ = 0;
											_ = 1065353216;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-80]");
											_ = 0;
											_ = worldToLocalMatrix.m03;
											obj = num2;
											_ = worldToLocalMatrix.m02;
											Matrix4x4 matrix4x3 = (Matrix4x4)(&num10) * matrix4x2;
											Matrix4x4 worldMatrix = GetWorldMatrix((Vector3)(&x), (Vector3)(&num11));
											Matrix4x4 matrix4x4 = (Matrix4x4)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
											_ = matrix4x3.m02;
											_ = worldMatrix.m00;
											_ = worldMatrix.m01;
											_ = worldMatrix.m02;
											obj = worldMatrix.m03;
											_ = matrix4x3.m03;
											matrix4x = (Matrix4x4)(&num10) * matrix4x4;
											goto IL_0dcc;
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				object obj14 = s_CombineInstances;
				if (s_CombineInstances != null)
				{
					CanvasRenderer canvasRenderer4 = base.canvasRenderer;
					if ((object)canvasRenderer4 != null)
					{
						Transform transform6 = canvasRenderer4.transform;
						if ((object)transform6 != null)
						{
							Matrix4x4 worldToLocalMatrix2 = transform6.worldToLocalMatrix;
							Matrix4x4 worldMatrix2 = GetWorldMatrix((Vector3)(&x), (Vector3)(&num11));
							Matrix4x4 matrix4x5 = (Matrix4x4)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
							_ = worldToLocalMatrix2.m02;
							_ = worldMatrix2.m00;
							_ = worldMatrix2.m01;
							_ = worldMatrix2.m02;
							obj = worldMatrix2.m03;
							_ = worldToLocalMatrix2.m03;
							matrix4x = (Matrix4x4)(&num10) * matrix4x5;
							goto IL_0dcc;
						}
					}
				}
			}
		}
		goto IL_19b6;
		IL_1bb3:
		_prevScale = (Vector3)worldScale.x;
		_prevPsPos = (Vector3)position.x;
		_ = worldScale.z;
		_ = position.z;
		_delay = false;
		goto IL_1aa0;
		IL_192a:
		Mesh mesh5 = Graphic.workerMesh;
		if ((object)mesh5 != null)
		{
			mesh5.ClearImpl(true);
			CanvasRenderer canvasRenderer5 = base.canvasRenderer;
			Mesh mesh6 = Graphic.workerMesh;
			if ((object)canvasRenderer5 != null)
			{
				canvasRenderer5.SetMesh(mesh6);
				_lastBounds = (Bounds)0;
				_ = 0;
				return;
			}
		}
		goto IL_19b6;
		IL_19b6:
		throw new NullReferenceException();
		IL_1aa0:
		bool flag21 = !_isTrail;
		particleSystemBakeMeshOptions2 = particleSystemBakeMeshOptions;
		float num12 = num8;
		bool flag22 = flag16;
		if (flag21)
		{
			goto IL_09ae;
		}
		goto IL_0859;
		IL_11fe:
		object obj15 = null;
		Graphic graphic = default(Graphic);
		object obj17 = default(object);
		Graphic graphic2 = default(Graphic);
		Graphic graphic3 = default(Graphic);
		while (true)
		{
			List<UIParticleRenderer> list = s_Renderers;
			if (s_Renderers == null)
			{
				break;
			}
			if ((nint)obj15 < list._size)
			{
				List<UIParticleRenderer> list2 = s_Renderers;
				if (s_Renderers == null)
				{
					break;
				}
				bool flag23 = (nint)obj15 >= list2._size;
				UIParticleRenderer[] items = list2._items;
				if (list2._items == null)
				{
					break;
				}
				bool flag24 = (nint)obj15 >= items.Length;
				bool flag25;
				if ((object)items[obj15] != null)
				{
					object obj16 = (object)items[obj15] - (object)this;
					flag25 = obj16 == null;
				}
				else
				{
					flag25 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
				}
				if (!flag25)
				{
					if (s_Renderers == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					if ((object)graphic == null)
					{
						break;
					}
					CanvasRenderer canvasRenderer6 = graphic.canvasRenderer;
					Mesh mesh7 = Graphic.workerMesh;
					if ((object)canvasRenderer6 == null)
					{
						break;
					}
					canvasRenderer6.SetMesh(mesh7);
					if (s_Renderers == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coffee.UIExtensions.UIParticleRenderer)+150]");
					float num9 = 0f;
					num8 = (float)_lastBounds;
					if (obj17 == null)
					{
						break;
					}
					_ = _lastBounds;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coffee.UIExtensions.UIParticleRenderer)+150]");
					_ = 0;
					int num13 = 0;
				}
				obj15++;
				continue;
			}
			UIParticle parent8 = _parent;
			if ((object)_parent == null)
			{
				break;
			}
			if (parent8.m_MeshSharing != UIParticle.MeshSharing.None && parent8.m_MeshSharing != UIParticle.MeshSharing.Auto && parent8.m_MeshSharing != UIParticle.MeshSharing.Primary && parent8.m_MeshSharing != UIParticle.MeshSharing.Reprica)
			{
				Mesh mesh8 = Graphic.workerMesh;
				if ((object)mesh8 == null)
				{
					break;
				}
				mesh8.ClearImpl(true);
			}
			CanvasRenderer canvasRenderer7 = base.canvasRenderer;
			Mesh mesh9 = Graphic.workerMesh;
			if ((object)canvasRenderer7 == null)
			{
				break;
			}
			canvasRenderer7.SetMesh(mesh9);
			UpdateMaterialProperties();
			UIParticle parent9 = _parent;
			if ((object)_parent == null)
			{
				break;
			}
			if (parent9.m_MeshSharing <= UIParticle.MeshSharing.None)
			{
				if (!_currentMaterialForRendering)
				{
					Material currentMaterialForRendering = base.materialForRendering;
					_currentMaterialForRendering = currentMaterialForRendering;
				}
				int num14 = 0;
				object obj18 = null;
				while (true)
				{
					List<UIParticleRenderer> list3 = s_Renderers;
					if (s_Renderers == null)
					{
						break;
					}
					if ((nint)obj18 < list3._size)
					{
						List<UIParticleRenderer> list4 = s_Renderers;
						if (s_Renderers == null)
						{
							break;
						}
						bool flag26 = (nint)obj18 >= list4._size;
						UIParticleRenderer[] items2 = list4._items;
						if (list4._items == null)
						{
							break;
						}
						bool flag27 = (nint)obj18 >= items2.Length;
						bool flag28;
						if ((object)items2[obj18] != null)
						{
							object obj19 = (object)items2[obj18] - (object)this;
							flag28 = obj19 == null;
						}
						else
						{
							flag28 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
						}
						if (!flag28)
						{
							if (s_Renderers == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							if ((object)graphic2 == null)
							{
								break;
							}
							CanvasRenderer canvasRenderer8 = graphic2.canvasRenderer;
							if ((object)canvasRenderer8 == null)
							{
								break;
							}
							canvasRenderer8.materialCount = 1;
							if (s_Renderers == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							if ((object)graphic3 == null)
							{
								break;
							}
							CanvasRenderer canvasRenderer9 = graphic3.canvasRenderer;
							if ((object)canvasRenderer9 == null)
							{
								break;
							}
							canvasRenderer9.SetMaterial(_currentMaterialForRendering, 0);
							bool flag19 = false;
							num14 = 0;
						}
						obj18++;
						continue;
					}
					goto IL_1889;
				}
				break;
			}
			goto IL_1889;
			IL_1889:
			List<UIParticleRenderer> list5 = s_Renderers;
			if (s_Renderers == null)
			{
				break;
			}
			int version = list5._version + 1;
			list5._version = version;
			list5._size = 0;
			if (list5._size > 0)
			{
				Array.Clear(list5._items, 0, list5._size);
			}
			return;
		}
		goto IL_19b6;
		IL_09ae:
		bool num15;
		if (!ParticleSystemExtensions.CanBakeMesh(_renderer))
		{
			CombineInstance[] array = s_CombineInstances;
			if (s_CombineInstances != null)
			{
				bool flag29 = array.Length <= 0;
				num15 = flag29;
				CombineInstance combineInstance = (CombineInstance)(s_CombineInstances + 32);
				Mesh mesh10 = ((CombineInstance*)combineInstance)->mesh;
				if ((object)mesh10 != null)
				{
					mesh10.ClearImpl(false);
					num8 = num12;
					flag16 = flag22;
					goto IL_0ade;
				}
			}
		}
		else
		{
			CombineInstance[] array2 = s_CombineInstances;
			if (s_CombineInstances != null)
			{
				bool flag30 = array2.Length <= 0;
				num15 = flag30;
				CombineInstance combineInstance2 = (CombineInstance)(s_CombineInstances + 32);
				Mesh mesh11 = ((CombineInstance*)combineInstance2)->mesh;
				if ((object)_renderer != null)
				{
					_renderer.BakeMesh(mesh11, bakeCamera, ParticleSystemBakeMeshOptions.BakeRotationAndScale);
					particleSystemBakeMeshOptions2 = ParticleSystemBakeMeshOptions.BakeRotationAndScale;
					num8 = num12;
					flag16 = flag22;
					goto IL_0ade;
				}
			}
		}
		goto IL_19b6;
		IL_1f97:
		List<UIParticleRenderer> list6 = s_Renderers;
		if (s_Renderers != null)
		{
			int num13 = list6._size;
			int version2 = list6._version + 1;
			list6._version = version2;
			list6._size = 0;
			if (list6._size > 0)
			{
				Array.Clear(list6._items, 0, list6._size);
				bool flag19 = false;
			}
			UIParticle parent10 = _parent;
			if ((object)_parent != null)
			{
				if (parent10.m_MeshSharing <= UIParticle.MeshSharing.None)
				{
					goto IL_11fe;
				}
				List<UIParticleRenderer> list7 = s_Renderers;
				if (s_Renderers != null)
				{
					num13 = list7._size;
					int version3 = list7._version + 1;
					list7._version = version3;
					list7._size = 0;
					if (list7._size > 0)
					{
						Array.Clear(list7._items, 0, list7._size);
						bool flag19 = false;
					}
					object obj20 = null;
					while (true)
					{
						List<UIParticle> s_ActiveParticles = UIParticleUpdater.s_ActiveParticles;
						if (UIParticleUpdater.s_ActiveParticles == null)
						{
							break;
						}
						if ((nint)obj20 < s_ActiveParticles._size)
						{
							List<UIParticle> s_ActiveParticles2 = UIParticleUpdater.s_ActiveParticles;
							if (UIParticleUpdater.s_ActiveParticles == null)
							{
								break;
							}
							bool flag31 = (nint)obj20 >= s_ActiveParticles2._size;
							UIParticle[] items3 = s_ActiveParticles2._items;
							if (s_ActiveParticles2._items == null)
							{
								break;
							}
							bool flag32 = (nint)obj20 >= items3.Length;
							bool flag19 = (byte)(int)items3[obj20] != 0;
							if ((int)(~items3[obj20]) != 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4507 @ r9_v24 (System.Boolean)+100]");
							if ((nint)0 > (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4507 @ r9_v24 (System.Boolean)+128]");
								if ((nint)0 == parent10._groupId)
								{
									UIParticleRenderer renderer = items3[obj20].GetRenderer(_index);
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800049E0");
									num13 = 0;
								}
							}
							obj20++;
							continue;
						}
						goto IL_11fe;
					}
				}
			}
		}
		goto IL_19b6;
		IL_0859:
		UIParticle parent11 = _parent;
		if ((object)_parent != null)
		{
			if (parent11.m_MeshSharing != UIParticle.MeshSharing.None && parent11.m_MeshSharing != UIParticle.MeshSharing.Auto && parent11.m_MeshSharing != UIParticle.MeshSharing.Primary)
			{
				bool flag33 = parent11.m_MeshSharing != UIParticle.MeshSharing.PrimarySimulator;
				particleSystemBakeMeshOptions2 = particleSystemBakeMeshOptions;
				num12 = num8;
				flag22 = flag16;
				if (flag33)
				{
					goto IL_09ae;
				}
			}
			CombineInstance[] array3 = s_CombineInstances;
			if (s_CombineInstances != null)
			{
				bool flag34 = array3.Length <= 0;
				num15 = flag34;
				CombineInstance combineInstance3 = (CombineInstance)(s_CombineInstances + 32);
				Mesh mesh12 = ((CombineInstance*)combineInstance3)->mesh;
				if ((object)_renderer != null)
				{
					_renderer.BakeTrailsMesh(mesh12, bakeCamera, ParticleSystemBakeMeshOptions.BakeRotationAndScale);
					particleSystemBakeMeshOptions2 = ParticleSystemBakeMeshOptions.BakeRotationAndScale;
					goto IL_0ade;
				}
			}
		}
		goto IL_19b6;
	}

	internal void UpdateParticleCount()
	{
		ParticleSystem particleSystem = _particleSystem;
		if ((object)_particleSystem != null && ((UnityEngine.Object)particleSystem).m_CachedPtr != (IntPtr)0)
		{
			int particleCount = _particleSystem.particleCount;
			_prevParticleCount = particleCount;
		}
	}

	protected unsafe override void OnEnable()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		OnEnable();
		m_ShouldRecalculateStencil = true;
		UpdateClipParent();
		base.SetMaterialDirty();
		if (base.m_IsMaskingGraphic)
		{
			MaskUtilities.NotifyStencilStateChanged(this);
		}
		CombineInstance combineInstance = (CombineInstance)(s_CombineInstances + 32);
		Mesh mesh = ((CombineInstance*)combineInstance)->mesh;
		if ((object)mesh == null || ((UnityEngine.Object)mesh).m_CachedPtr == (IntPtr)0)
		{
			Mesh mesh2 = new Mesh();
			((UnityEngine.Object)mesh2).SetName("[UIParticleRenderer] Combine Instance Mesh");
			mesh2.hideFlags = HideFlags.HideAndDontSave;
			CombineInstance combineInstance2 = (CombineInstance)(s_CombineInstances + 32);
			((CombineInstance*)combineInstance2)->mesh = mesh2;
		}
		_currentMaterialForRendering = null;
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		ModifiedMaterial.Remove(_modifiedMaterial);
		_modifiedMaterial = null;
		_currentMaterialForRendering = null;
	}

	protected override void UpdateGeometry()
	{
	}

	public override void Cull(Rect clipRect, bool validRect)
	{
		//IL_0118: Expected I, but got O
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected O, but got Unknown
		//IL_0168: Expected O, but got I
		//IL_01b2: Invalid comparison between F4 and O
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected I4, but got Unknown
		//IL_00ee: Expected O, but got I4
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coffee.UIExtensions.UIParticleRenderer)+14C]");
		object obj = 0 - Vector3.zeroVector;
		object obj3 = default(object);
		object obj4 = default(object);
		object obj2 = obj3 - obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coffee.UIExtensions.UIParticleRenderer)+154]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		object obj5 = num3 - 0;
		object obj6 = obj2 * obj2;
		object obj7 = obj * obj;
		object obj8 = obj5 * obj5;
		object obj9 = obj6 + obj7;
		object obj10 = obj9 + obj8;
		bool flag = default(bool);
		bool flag2;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10) && flag)
		{
			Rect rect = rootCanvasRect;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA3070");
			object obj11 = default(object);
			flag2 = (byte)(obj11 ^ 1) != 0;
		}
		else
		{
			flag2 = true;
		}
		CanvasRenderer canvasRenderer = base.canvasRenderer;
		bool flag3 = ((UnityEngine.Object)canvasRenderer).m_CachedPtr == (IntPtr)0;
		object obj12 = CanvasRenderer.get_cull_Injected(((UnityEngine.Object)canvasRenderer).m_CachedPtr);
		if ((nint)obj12 != (flag2 ? 1 : 0))
		{
			CanvasRenderer canvasRenderer2 = base.canvasRenderer;
			canvasRenderer2.cull = flag2;
			UISystemProfilerApi.AddMarker("MaskableGraphic.cullingChanged", this);
			base.m_OnCullStateChanged.Invoke(flag2);
			base.OnCullingChanged();
		}
	}

	private unsafe Vector3 GetWorldScale()
	{
		//IL_0009: Expected native int or pointer, but got O
		//IL_0017: Expected native int or pointer, but got O
		//IL_0057: Expected F4, but got O
		//IL_0052: Expected native int or pointer, but got O
		//IL_006c: Expected F4, but got I
		//IL_0067: Expected native int or pointer, but got O
		//IL_0215: Expected native int or pointer, but got O
		//IL_0222: Expected native int or pointer, but got O
		//IL_022f: Expected native int or pointer, but got O
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = 0f;
		((Vector3*)(nint)vector)->z = 0f;
		UIParticle parent = _parent;
		if ((object)_parent != null)
		{
			((Vector3*)(nint)vector)->x = (float)parent.m_Scale3D;
			Vector3 vector2 = vector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rax_v2 (Coffee.UIExtensions.UIParticle)+EC]");
			((Vector3*)(nint)vector2)->z = 0f;
			if ((object)_parent != null)
			{
				Transform transform = _parent.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
					object obj = default(object);
					bool flag2 = obj != null;
					float num = 1f;
					if (!flag2)
					{
						num = 1f / (float)ret;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
					object obj2 = default(object);
					bool flag3 = obj2 != null;
					float num2 = 1f;
					if (!flag3)
					{
						object obj3 = default(object);
						num2 = 1f / (float)obj3;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
					object obj4 = default(object);
					bool flag4 = obj4 != null;
					float num3 = 1f;
					if (!flag4)
					{
						num3 = 1f / 0f;
					}
					float x = num * vector.x;
					float y = num2 * vector.y;
					float z = num3 * vector.z;
					((Vector3*)(nint)vector)->x = x;
					((Vector3*)(nint)vector)->y = y;
					((Vector3*)(nint)vector)->z = z;
					return vector;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe Matrix4x4 GetWorldMatrix(Vector3 psPos, Vector3 scale)
	{
		//IL_0008: Expected O, but got Ref
		//IL_01c7: Expected O, but got I4
		//IL_01d4: Expected O, but got Ref
		//IL_03e9: Expected O, but got Ref
		//IL_0407: Expected native int or pointer, but got O
		//IL_0419: Expected native int or pointer, but got O
		//IL_042b: Expected native int or pointer, but got O
		//IL_043d: Expected native int or pointer, but got O
		//IL_00c6: Expected O, but got I4
		//IL_016b: Expected native int or pointer, but got O
		//IL_0178: Expected native int or pointer, but got O
		//IL_0185: Expected native int or pointer, but got O
		//IL_0193: Expected native int or pointer, but got O
		//IL_021d: Expected O, but got I
		//IL_036b: Expected O, but got Ref
		//IL_026b: Expected O, but got I
		//IL_03ab: Expected O, but got Ref
		//IL_02da: Expected O, but got Ref
		//IL_033b: Expected O, but got I
		//IL_0353: Expected O, but got Ref
		//IL_0398->IL015e: Incompatible stack heights: 1 vs 0
		//IL_039d->IL009b: Incompatible stack heights: 1 vs 0
		//IL_0358->IL03db: Incompatible stack heights: 3 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		ParticleSystemSimulationSpace actualSimulationSpace = ParticleSystemExtensions.GetActualSimulationSpace(_particleSystem);
		bool flag = !_isTrail;
		Vector3 vector2 = default(Vector3);
		Vector3 vector = vector2;
		if (!flag)
		{
			bool flag2 = (object)_particleSystem == null;
			_ = _particleSystem;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BD00]");
			object obj3 = 0;
			_ = _particleSystem;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BD00]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj3 == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
			}
			object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v553 @ rax_v43 (should have been resolved before IL gen)");
			object obj5 = default(object);
			bool flag3 = obj5 != null;
			vector = vector2;
			if (flag3)
			{
				goto IL_015e;
			}
		}
		bool flag4 = actualSimulationSpace == ParticleSystemSimulationSpace.Local;
		Matrix4x4 matrix4x;
		if (!flag4)
		{
			NotSupportedException ex2 = (NotSupportedException)(actualSimulationSpace - 1);
			if (flag4)
			{
				goto IL_015e;
			}
			if ((nint)ex2 != 1)
			{
				NotSupportedException ex3 = new NotSupportedException();
				throw ex3;
			}
			bool flag5 = (object)_particleSystem == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA40]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA40]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj6 == null)
				{
					MissingMethodException ex4 = new MissingMethodException();
					throw ex4;
				}
			}
			object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v768 @ rax_v29 (should have been resolved before IL gen)");
			IntPtr gcHandlePtr = default(IntPtr);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag6 = (object)transform == null;
			_ = 0;
			_ = 0;
			bool flag7 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj8);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-60]");
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 1065353216;
			_ = vector2.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-70]");
			obj = 0;
			_ = 0;
			object obj9 = default(object);
			matrix4x = (Matrix4x4)(&obj9);
		}
		else
		{
			_ = 0;
			_ = 1065353216;
			_ = 1065353216;
			_ = vector2.x;
			obj = 0;
			object obj10 = default(object);
			matrix4x = (Matrix4x4)(&obj10);
		}
		Matrix4x4 matrix4x2 = (Matrix4x4)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
		Matrix4x4 matrix4x3 = matrix4x * matrix4x2;
		Matrix4x4 matrix4x4 = default(Matrix4x4);
		((Matrix4x4*)(nint)matrix4x4)->m00 = matrix4x3.m00;
		((Matrix4x4*)(nint)matrix4x4)->m01 = matrix4x3.m01;
		((Matrix4x4*)(nint)matrix4x4)->m02 = matrix4x3.m02;
		((Matrix4x4*)(nint)matrix4x4)->m03 = matrix4x3.m03;
		goto IL_0358;
		IL_015e:
		((Matrix4x4*)(nint)matrix4x4)->m00 = vector2.x;
		float num = default(float);
		((Matrix4x4*)(nint)matrix4x4)->m01 = num;
		((Matrix4x4*)(nint)matrix4x4)->m02 = num;
		((Matrix4x4*)(nint)matrix4x4)->m03 = 0f;
		goto IL_0358;
		IL_0358:
		return matrix4x4;
	}

	private void ResolveResolutionChange(Vector3 psPos, Vector3 scale)
	{
		//IL_03f8: Expected O, but got I4
		//IL_02a9: Expected O, but got I4
		//IL_02e5: Expected O, but got I
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		//IL_0268: Expected O, but got F4
		//IL_0281: Expected O, but got F4
		//IL_03e1: Expected O, but got I4
		//IL_0115->IL03fd: Incompatible stack heights: 1 vs 0
		Vector2Int vector2Int = (Vector2Int)Screen.width;
		object obj = Screen.height;
		Vector3 vector = default(Vector3);
		if ((object)_prevScreenSize == (object)vector2Int)
		{
			object obj2 = (object)_prevScreenSize >> 32;
			object obj3 = (object)vector2Int >> 32;
			if (obj2 == obj3)
			{
				float num = (float)_prevScale - vector.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v1 (Coffee.UIExtensions.UIParticleRenderer)+118]");
				object obj4 = 0 - vector.z;
				object obj6 = default(object);
				object obj5 = obj6 - obj6;
				object obj7 = obj5 * obj5;
				float num2 = num * num;
				object obj8 = obj4 * obj4;
				float num3 = (float)obj7 + num2;
				float num4 = num3 + (float)obj8;
				if (9.9999994E-11f > num4)
				{
					goto IL_02ca;
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B970]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B970]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag = obj9 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v811 @ rax_v16 (should have been resolved before IL gen)");
		object obj10 = default(object);
		int particleCount;
		ParticleSystem.Particle[] particleArray;
		if ((nint)obj10 == 1)
		{
			particleCount = _particleSystem.particleCount;
			particleArray = ParticleSystemExtensions.GetParticleArray(particleCount);
			int particles = _particleSystem.GetParticles(particleArray, particleCount, 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
			object obj11 = default(object);
			object obj17 = default(object);
			if (obj11 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
				object obj12 = default(object);
				if (obj12 == null)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
				object obj13 = default(object);
				if (obj13 == null)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
				object obj14 = default(object);
				if (obj14 == null)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
				object obj15 = default(object);
				if (obj15 == null)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
				object obj16 = default(object);
				if (obj16 == null)
				{
				}
				bool flag2 = particleCount <= 0;
				obj17 = 0;
				if (flag2)
				{
					goto IL_0241;
				}
			}
			bool flag3;
			do
			{
				object obj18 = obj17 * 132;
				object obj19 = obj17 + 1;
				object obj20 = obj17 * 132;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ rcx_v15+30+v497 @ rax_v20 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ rcx_v15+40+v497 @ rax_v20 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ rcx_v15+50+v497 @ rax_v20 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ rcx_v15+60+v497 @ rax_v20 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ rcx_v15+70+v497 @ rax_v20 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ rcx_v15+80+v497 @ rax_v20 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ rcx_v15+90+v497 @ rax_v20 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ rcx_v15+A0+v497 @ rax_v20 (Particle[])]");
				_ = 0;
				flag3 = (nint)obj19 < particleCount;
				obj17 = obj19;
			}
			while (flag3);
			goto IL_0241;
		}
		goto IL_02ca;
		IL_02ca:
		_prevScreenSize = vector2Int;
		return;
		IL_0241:
		_particleSystem.SetParticles(particleArray, particleCount, 0);
		_prevScale = (Vector3)vector.x;
		_ = vector.z;
		Vector3 vector2 = default(Vector3);
		_prevPsPos = (Vector3)vector2.x;
		_ = vector2.z;
		_delay = true;
		goto IL_02ca;
	}

	private unsafe void Simulate(Vector3 scale, bool paused)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0037: Expected O, but got I
		//IL_0022: Expected O, but got I4
		//IL_00a9: Expected O, but got I
		//IL_00b1: Expected O, but got Ref
		//IL_0096: Expected O, but got I
		//IL_009e: Expected O, but got Ref
		//IL_0642: Expected I4, but got O
		//IL_064d: Expected I4, but got O
		//IL_00e5: Expected O, but got I
		//IL_06c5: Expected O, but got I4
		//IL_03b3: Expected I4, but got O
		//IL_03be: Expected I4, but got O
		//IL_0203: Expected I4, but got O
		//IL_023c: Expected O, but got I4
		//IL_0259: Expected O, but got I
		//IL_02b4: Expected O, but got I4
		//IL_0888: Expected O, but got I
		//IL_0355: Expected O, but got I
		//IL_0c93: Expected O, but got Ref
		//IL_08e3: Expected O, but got Ref
		//IL_0909: Expected O, but got Ref
		//IL_0948: Invalid comparison between F4 and I4
		//IL_0436: Expected O, but got I
		//IL_04a7: Expected O, but got I
		//IL_09bd: Expected O, but got I4
		//IL_09dd: Expected O, but got Ref
		//IL_0b9d: Expected O, but got Ref
		//IL_0c1f: Expected I4, but got O
		//IL_0c1f: Expected F4, but got Ref
		//IL_0c37: Expected O, but got Ref
		//IL_0afe: Expected I4, but got O
		//IL_0afe: Expected F4, but got Ref
		//IL_0b28: Expected O, but got I
		//IL_03c7->IL0582: Incompatible stack heights: 1 vs 0
		//IL_013a->IL065b: Incompatible stack heights: 1 vs 0
		//IL_015e->IL0582: Incompatible stack heights: 1 vs 0
		//IL_019e->IL0582: Incompatible stack heights: 1 vs 0
		//IL_0804->IL0582: Incompatible stack heights: 2 vs 0
		//IL_070e->IL0582: Incompatible stack heights: 1 vs 0
		//IL_020c->IL0582: Incompatible stack heights: 1 vs 0
		//IL_0873->IL0582: Incompatible stack heights: 4 vs 0
		//IL_0340->IL01fa: Incompatible stack heights: 3 vs 1
		//IL_036a->IL06f4: Incompatible stack heights: 3 vs 1
		//IL_0426->IL0c72: Incompatible stack heights: 5 vs 4
		//IL_0497->IL08d5: Incompatible stack heights: 5 vs 4
		//IL_04fc->IL0968: Incompatible stack heights: 5 vs 4
		//IL_0b2d->IL08b0: Incompatible stack heights: 7 vs 4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		int particleCount;
		ParticleSystem.Particle[] particleArray;
		float num4;
		float num6;
		object obj3;
		float num5 = default(float);
		float num7 = default(float);
		int num;
		int num2;
		if ((object)_particleSystem != null)
		{
			_ = _particleSystem;
			bool flag = default(bool);
			object obj8 = default(object);
			if (flag)
			{
				obj3 = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B998]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B998]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj4 == null)
					{
						MissingMethodException ex = new MissingMethodException();
						throw ex;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v526 @ rax_v182 (should have been resolved before IL gen)");
				object obj5 = default(object);
				ParticleSystem particleSystem = default(ParticleSystem);
				if (obj5 != null)
				{
					object obj6 = 0;
					object obj7 = (object)(&particleSystem);
				}
				else
				{
					object obj6 = 0;
					object obj7 = (object)(&particleSystem);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v636 @ rax_v184 (should have been resolved before IL gen)");
				obj3 = obj8;
			}
			if ((nint)obj3 > 0 && _prewarm)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8B0]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8B0]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					bool flag2 = obj9 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v708 @ rax_v178 (should have been resolved before IL gen)");
				obj8 += obj3;
				_prewarm = false;
				obj3 = obj8;
			}
			bool flag3 = (byte)(int)_particleSystem != 0;
			if ((int)(~_particleSystem) == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rbx_v30 (System.Boolean)+10]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rbx_v30 (System.Boolean)+10]");
				object obj10 = ParticleSystem.get_particleCount_Injected((IntPtr)0);
				bool flag5 = _prevParticleCount == (nint)obj10;
				IntPtr intPtr = default(IntPtr);
				num = (int)(nint)intPtr;
				num2 = (flag ? 1 : 0);
				if (flag5)
				{
					goto IL_03a9;
				}
				if ((object)_particleSystem != null)
				{
					particleCount = _particleSystem.particleCount;
					particleArray = ParticleSystemExtensions.GetParticleArray(particleCount);
					if ((object)_particleSystem != null)
					{
						int particles = _particleSystem.GetParticles(particleArray, particleCount, 0);
						int num3 = _prevParticleCount;
						bool flag6 = _prevParticleCount >= particleCount;
						num4 = num5;
						num6 = num7;
						if (flag6)
						{
							goto IL_06f4;
						}
						object obj12 = default(object);
						object obj13 = default(object);
						object obj14 = default(object);
						Vector3 vector = default(Vector3);
						while ((int)(~particleArray) == 0)
						{
							bool flag7 = num3 >= particleArray.Length;
							object obj11 = num3 * 132;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1424 @ rcx_v141+20+v229 @ rax_v164 (Particle[])]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1424 @ rcx_v141+80+v229 @ rax_v164 (Particle[])]");
							obj8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
							if (obj12 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
								if (obj13 == null)
								{
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
								bool flag8 = obj14 != null;
								num7 = 1f;
								if (flag8)
								{
									goto IL_076b;
								}
							}
							num7 = 1f / vector.z;
							goto IL_076b;
							IL_076b:
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-38]");
							num5 = 0f * num7;
							bool flag9 = num3 >= particleArray.Length;
							int num8 = num3 + 1;
							object obj15 = num3 * 132;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1424 @ rcx_v141+30+v229 @ rax_v164 (Particle[])]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1424 @ rcx_v141+40+v229 @ rax_v164 (Particle[])]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1424 @ rcx_v141+50+v229 @ rax_v164 (Particle[])]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1424 @ rcx_v141+60+v229 @ rax_v164 (Particle[])]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1424 @ rcx_v141+70+v229 @ rax_v164 (Particle[])]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1424 @ rcx_v141+90+v229 @ rax_v164 (Particle[])]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1424 @ rcx_v141+A0+v229 @ rax_v164 (Particle[])]");
							_ = 0;
							bool flag10 = num8 < particleCount;
							num3 = num8;
							if (flag10)
							{
								continue;
							}
							goto IL_0345;
						}
					}
				}
			}
		}
		goto IL_0582;
		IL_0a1e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
		object obj16 = default(object);
		bool flag11 = obj16 != null;
		float num9 = 1f;
		if (!flag11)
		{
			float num10 = 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coffee.UIExtensions.UIParticleRenderer)+118]");
			num9 = num10 / 0f;
		}
		object obj17 = default(object);
		float num11;
		num5 = (float)obj17 * num11;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coffee.UIExtensions.UIParticleRenderer)+124]");
		num7 = 0f * num9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v87 (UnityEngine.Transform)+10]");
		bool flag12 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v87 (UnityEngine.Transform)+10]");
		Vector3 position = default(Vector3);
		Quaternion rotation = default(Quaternion);
		Transform.SetPositionAndRotation_Injected((IntPtr)0, ref position, ref rotation);
		object particleSystem2 = _particleSystem;
		bool flag13 = (object)_particleSystem == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2103 @ rdi_v41 (System.Object)+10]");
		bool flag14 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2103 @ rdi_v41 (System.Object)+10]");
		Quaternion ret;
		ParticleSystem.Simulate_Injected((IntPtr)0, (float)(nint)(&position), false, false, (byte)(int)ret != 0);
		num = 0;
		ref ParticleSystem.MinMaxCurveBlittable reference = ref *(ParticleSystem.MinMaxCurveBlittable*)(&position);
		num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2103 @ rdi_v41 (System.Object)+10]");
		object obj18 = 0;
		goto IL_08b0;
		IL_0345:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+120]");
		obj3 = 0;
		num4 = num5;
		num6 = num7;
		goto IL_06f4;
		IL_0582:
		throw new NullReferenceException();
		IL_08d5:
		object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2177 @ rax_v126 (should have been resolved before IL gen)");
		reference = ref System.Runtime.CompilerServices.Unsafe.As<object, ParticleSystem.MinMaxCurveBlittable>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
		obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve = ParticleSystem.MinMaxCurveBlittable.ToMinMaxCurve(ref reference);
		_ = minMaxCurve.m_Mode;
		bool flag15 = !(minMaxCurve.m_ConstantMax > 0f);
		num2 = 0;
		ParticleSystem particleSystem3 = default(ParticleSystem);
		if (!flag15)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA68]");
			object obj20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA68]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag16 = obj20 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2301 @ rax_v130 (should have been resolved before IL gen)");
			bool flag17 = minMaxCurve.m_Mode < ParticleSystemCurveMode.Constant;
			bool flag18 = minMaxCurve.m_Mode == ParticleSystemCurveMode.Constant;
			bool flag19 = !flag17;
			bool flag20 = !flag18;
			object obj21 = flag20 & flag19;
			bool flag21 = obj21 == null;
			num2 = 0;
			obj18 = (object)(&particleSystem3);
			if (!flag21)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
				object obj22 = default(object);
				if (obj22 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
					object obj23 = default(object);
					bool flag22 = obj23 != null;
					num11 = 1f;
					if (flag22)
					{
						goto IL_0a1e;
					}
				}
				object obj24 = default(object);
				num11 = 1f / (float)obj24;
				goto IL_0a1e;
			}
		}
		goto IL_08b0;
		IL_06f4:
		if ((object)_particleSystem != null)
		{
			_particleSystem.SetParticles(particleArray, particleCount, 0);
			num5 = num4;
			num7 = num6;
			num = 0;
			num2 = particleCount;
			goto IL_03a9;
		}
		goto IL_0582;
		IL_08b0:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
		object obj25 = default(object);
		if (obj25 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
			object obj26 = default(object);
			if (obj26 == null)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
			object obj27 = default(object);
			if (obj27 == null)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v87 (UnityEngine.Transform)+10]");
			bool flag23 = (nint)0 == 0;
			object obj28 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v87 (UnityEngine.Transform)+10]");
			Transform.SetPositionAndRotation_Injected((IntPtr)0, ref position, ref *(Quaternion*)obj28);
			object particleSystem4 = _particleSystem;
			bool flag24 = (object)_particleSystem == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2663 @ rdi_v36 (System.Object)+10]");
			bool flag25 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2663 @ rdi_v36 (System.Object)+10]");
			ParticleSystem.Simulate_Injected((IntPtr)0, (float)(nint)(&position), false, false, (byte)(int)ret != 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v87 (UnityEngine.Transform)+10]");
			bool flag26 = (nint)0 == 0;
			object obj29 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v87 (UnityEngine.Transform)+10]");
			Transform.SetPositionAndRotation_Injected((IntPtr)0, ref *(Vector3*)(&rotation), ref *(Quaternion*)obj29);
			return;
		}
		goto IL_08d5;
		IL_03a9:
		bool flag27 = (byte)(int)_particleSystem != 0;
		if ((int)(~_particleSystem) == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rbx_v32 (System.Boolean)+10]");
			bool flag28 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rbx_v32 (System.Boolean)+10]");
			IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			if ((object)transform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v87 (UnityEngine.Transform)+10]");
				bool flag29 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v87 (UnityEngine.Transform)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 _);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v87 (UnityEngine.Transform)+10]");
				bool flag30 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v87 (UnityEngine.Transform)+10]");
				Transform.get_rotation_Injected((IntPtr)0, out ret);
				if ((object)_particleSystem != null)
				{
					_ = _particleSystem;
					reference = ref *(ParticleSystem.MinMaxCurveBlittable*)(&ret);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA50]");
					object obj30 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA50]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						bool flag31 = obj30 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2027 @ rax_v100 (should have been resolved before IL gen)");
					object obj31 = default(object);
					bool flag32 = obj31 == null;
					obj18 = (object)(&particleSystem3);
					if (flag32)
					{
						goto IL_08b0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA90]");
					object obj32 = 0;
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA90]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						bool flag33 = obj32 == null;
					}
					goto IL_08d5;
				}
			}
		}
		goto IL_0582;
	}

	private void UpdateMaterialProperties()
	{
		//IL_01de: Expected O, but got I4
		//IL_0106: Expected O, but got I4
		//IL_010f: Expected O, but got I4
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_01f9->IL01ad: Incompatible stack heights: 1 vs 0
		//IL_00db->IL01ad: Incompatible stack heights: 1 vs 0
		//IL_0227->IL01ad: Incompatible stack heights: 2 vs 0
		UIParticle parent = _parent;
		AnimatableProperty[] animatableProperties = parent.m_AnimatableProperties;
		if (animatableProperties.Length == 0)
		{
			return;
		}
		if (s_Mpb == null)
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			IntPtr ptr = MaterialPropertyBlock.CreateImpl();
			materialPropertyBlock.m_Ptr = ptr;
			s_Mpb = materialPropertyBlock;
		}
		((Renderer)_renderer).Internal_GetPropertyBlock(s_Mpb);
		object obj = s_Mpb;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rcx_v23 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rcx_v23 (System.Object)+10]");
		object obj2 = MaterialPropertyBlock.get_isEmpty_Injected((IntPtr)0);
		if (obj2 == null && (bool)_modifiedMaterial)
		{
			UIParticle parent2 = _parent;
			AnimatableProperty[] animatableProperties2 = parent2.m_AnimatableProperties;
			object obj3 = 0;
			object obj4 = 0;
			while ((nint)obj4 < animatableProperties2.Length)
			{
				animatableProperties2[obj3].UpdateMaterialProperties(_modifiedMaterial, s_Mpb);
				obj3++;
				obj4 = obj3;
			}
			object obj5 = s_Mpb;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rcx_v30 (System.Object)+10]");
			bool flag2 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rcx_v30 (System.Object)+10]");
			MaterialPropertyBlock.Clear_Injected((IntPtr)0, true);
		}
	}

	static UIParticleRenderer()
	{
		CombineInstance[] array = new CombineInstance[1];
		s_CombineInstances = array;
		List<Material> list = null;
		Material[] items = null;
		list._items = items;
		s_Materials = list;
		List<UIParticleRenderer> list2 = new List<UIParticleRenderer>();
		s_Renderers = list2;
		Vector3[] array2 = new Vector3[4];
		s_Corners = array2;
	}
}
