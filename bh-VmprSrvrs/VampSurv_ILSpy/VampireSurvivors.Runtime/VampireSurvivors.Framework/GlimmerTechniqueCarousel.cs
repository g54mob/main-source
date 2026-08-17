using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;

namespace VampireSurvivors.Framework;

public class GlimmerTechniqueCarousel : MonoBehaviour
{
	private GlimmerTechniqueCarouselItem m_GlimmerTechniqueCarouselItemPrefab;

	private Transform m_OffScreenTransform;

	private List<GlimmerTechniqueCarouselItem> m_CurrentlyShowingGlimmmerTechniques;

	private List<GlimmerTechniqueCarouselItem> m_GlimmmerTechniquesToBeReturnedToPool;

	private List<GlimmerTechniqueCarouselItem> m_GlimmmerTechniquePool;

	private float m_SlideToFillGapSpeed;

	private int m_TechniquePoolSize;

	private float m_GapBetweenTechniques;

	private float m_MaximumHeight;

	private float m_AgeToEndIntroSwish;

	private float m_AgeToStartExit;

	private float m_AgeToDie;

	private void Start()
	{
		//IL_006d: Expected O, but got I4
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_02b2->IL017c: Incompatible stack heights: 1 vs 0
		//IL_02d1->IL017c: Incompatible stack heights: 2 vs 0
		//IL_0177->IL0289: Incompatible stack heights: 2 vs 0
		//IL_017c->IL019c: Incompatible stack heights: 2 vs 0
		object item = default(object);
		while (true)
		{
			List<GlimmerTechniqueCarouselItem> currentlyShowingGlimmmerTechniques = new List<GlimmerTechniqueCarouselItem>();
			m_CurrentlyShowingGlimmmerTechniques = currentlyShowingGlimmmerTechniques;
			List<GlimmerTechniqueCarouselItem> glimmmerTechniquesToBeReturnedToPool = new List<GlimmerTechniqueCarouselItem>();
			m_GlimmmerTechniquesToBeReturnedToPool = glimmmerTechniquesToBeReturnedToPool;
			List<GlimmerTechniqueCarouselItem> glimmmerTechniquePool = new List<GlimmerTechniqueCarouselItem>();
			m_GlimmmerTechniquePool = glimmmerTechniquePool;
			if (m_TechniquePoolSize <= 0)
			{
				break;
			}
			object obj = 0;
			while (true)
			{
				List<object> glimmmerTechniquePool2 = (List<object>)(object)m_GlimmmerTechniquePool;
				if (((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0)
				{
					break;
				}
				IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
				Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if (((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0)
				{
					break;
				}
				IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
				Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
				bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Quaternion ret2);
				if (((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0)
				{
					break;
				}
				IntPtr gcHandlePtr3 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
				Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830B46D0");
				int version = glimmmerTechniquePool2._version + 1;
				glimmmerTechniquePool2._version = version;
				List<GlimmerTechniqueCarouselItem> items = (List<GlimmerTechniqueCarouselItem>)(object)glimmmerTechniquePool2._items;
				if (glimmmerTechniquePool2._size >= items._size)
				{
					glimmmerTechniquePool2.AddWithResize(item);
				}
				else
				{
					int size = glimmmerTechniquePool2._size + 1;
					glimmmerTechniquePool2._size = size;
					items._002Ector();
				}
				obj++;
				bool flag3 = (nint)obj < m_TechniquePoolSize;
				object obj2 = ret;
				object obj3 = ret2;
				if (!flag3)
				{
					return;
				}
			}
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(this);
		}
	}

	private unsafe void Update()
	{
		//IL_0061: Invalid comparison between F4 and I4
		//IL_00b1: Expected O, but got I4
		//IL_00c2: Expected O, but got I4
		//IL_074a: Unknown result type (might be due to invalid IL or missing references)
		//IL_074f: Expected O, but got Unknown
		//IL_0660: Invalid comparison between I4 and F4
		//IL_06ab: Expected F4, but got I4
		//IL_05c0: Expected I, but got O
		//IL_08e3: Expected O, but got I
		//IL_06bb: Expected O, but got I
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_0916: Expected O, but got I4
		//IL_02e2: Invalid comparison between I4 and F4
		//IL_042e: Invalid comparison between I4 and F4
		//IL_032d: Expected F4, but got I4
		//IL_0479: Expected F4, but got I4
		//IL_07da: Expected O, but got I
		//IL_033d: Expected O, but got I
		//IL_080d: Expected O, but got I4
		//IL_0865: Expected O, but got I
		//IL_0563: Expected O, but got I
		//IL_0898: Expected O, but got I4
		//IL_013a->IL0705: Incompatible stack heights: 1 vs 0
		//IL_0769->IL0705: Incompatible stack heights: 1 vs 0
		//IL_06cd->IL092b: Incompatible stack heights: 1 vs 0
		//IL_05f3->IL0705: Incompatible stack heights: 1 vs 0
		//IL_061d->IL0705: Incompatible stack heights: 1 vs 0
		//IL_05a0->IL0705: Incompatible stack heights: 1 vs 0
		//IL_0241->IL0705: Incompatible stack heights: 1 vs 0
		//IL_03b9->IL0705: Incompatible stack heights: 1 vs 0
		//IL_026b->IL0705: Incompatible stack heights: 1 vs 0
		//IL_03e3->IL0705: Incompatible stack heights: 1 vs 0
		//IL_0966->IL0737: Incompatible stack heights: 2 vs 1
		//IL_0850->IL0705: Incompatible stack heights: 1 vs 0
		//IL_04b2->IL0705: Incompatible stack heights: 1 vs 0
		//IL_0822->IL094f: Incompatible stack heights: 3 vs 2
		//IL_08b5->IL094f: Incompatible stack heights: 3 vs 2
		List<GlimmerTechniqueCarouselItem> currentlyShowingGlimmmerTechniques = m_CurrentlyShowingGlimmmerTechniques;
		if (m_CurrentlyShowingGlimmmerTechniques != null)
		{
			float num = (float)currentlyShowingGlimmmerTechniques._size * 0.1f;
			float deltaTime = PauseSystem.DeltaTime;
			float deltaTime2 = PauseSystem.DeltaTime;
			float num2 = deltaTime2 * num;
			float num3 = num2 + deltaTime;
			float deltaTime3 = PauseSystem.DeltaTime;
			bool flag = deltaTime3 == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001877DBA7Dh\"");
			if (!flag)
			{
				List<GlimmerTechniqueCarouselItem> currentlyShowingGlimmmerTechniques2 = m_CurrentlyShowingGlimmmerTechniques;
				if (m_CurrentlyShowingGlimmmerTechniques == null)
				{
					goto IL_0705;
				}
				object obj = 0;
				float num4 = num3;
				object obj2 = 0;
				float num9 = default(float);
				while ((nint)obj2 < currentlyShowingGlimmmerTechniques2._size)
				{
					List<GlimmerTechniqueCarouselItem> currentlyShowingGlimmmerTechniques3 = m_CurrentlyShowingGlimmmerTechniques;
					if (m_CurrentlyShowingGlimmmerTechniques != null)
					{
						bool flag2 = (nint)obj >= currentlyShowingGlimmmerTechniques3._size;
						GlimmerTechniqueCarouselItem[] items = currentlyShowingGlimmmerTechniques3._items;
						if (currentlyShowingGlimmmerTechniques3._items != null)
						{
							Component component = items[obj];
							if ((object)items[obj] != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
							{
								float num5 = num4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rdi_v17 (UnityEngine.Component)+30]");
								float num6 = num5 + 0f;
								deltaTime3 = m_AgeToEndIntroSwish;
								if (m_AgeToEndIntroSwish > num6)
								{
									Transform transform = items[obj].transform;
									if ((object)transform != null)
									{
										Transform transform2 = transform.transform;
										if ((object)transform2 != null)
										{
											Vector3 localPosition = transform2.localPosition;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rdi_v17 (UnityEngine.Component)+30]");
											float num7 = 0f / m_AgeToEndIntroSwish;
											float y = localPosition.y;
											if (!(0f > num7))
											{
												if (num7 > 1f)
												{
													num7 = 1f;
												}
											}
											else
											{
												num7 = 0f;
											}
											Transform transform3 = items[obj].transform;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1406 @ rax_v47 (UnityEngine.Transform)+10]");
											object obj3 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1406 @ rax_v47 (UnityEngine.Transform)+10]");
											bool flag3 = (nint)0 == 0;
											object obj4 = 0;
											float num8 = num9;
											object obj5 = 0;
											nint num10 = (nint)(&num8);
											deltaTime3 = num9;
											goto IL_094f;
										}
									}
									goto IL_0705;
								}
								if (!(num6 < m_AgeToEndIntroSwish))
								{
									deltaTime3 = m_AgeToStartExit;
									if (m_AgeToStartExit > num6)
									{
										Transform transform4 = items[obj].transform;
										if ((object)transform4 != null)
										{
											Transform transform5 = transform4.transform;
											if ((object)transform5 != null)
											{
												float y2 = transform5.localPosition.y;
												object obj6 = obj * m_GapBetweenTechniques;
												float num11 = m_MaximumHeight - (float)obj6;
												float deltaTime4 = PauseSystem.DeltaTime;
												float num12 = deltaTime4 * m_SlideToFillGapSpeed;
												float num13 = num12 * num;
												if (!(0f > num13))
												{
													if (num13 > 1f)
													{
														num13 = 1f;
													}
												}
												else
												{
													num13 = 0f;
												}
												Transform transform6 = items[obj].transform;
												float num14 = num11 - y2;
												float num15 = num14 * num13;
												float y = num15 + y2;
												bool flag4 = (object)transform6 == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v645 @ rax_v70 (UnityEngine.Transform)+10]");
												object obj3 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v645 @ rax_v70 (UnityEngine.Transform)+10]");
												bool flag5 = (nint)0 == 0;
												object obj4 = 0;
												float num16 = num9;
												object obj5 = 0;
												nint num10 = (nint)(&num16);
												deltaTime3 = num9;
												goto IL_094f;
											}
										}
										goto IL_0705;
									}
								}
								if (!(num6 < m_AgeToStartExit))
								{
									deltaTime3 = m_AgeToDie;
									if (m_AgeToDie > num6)
									{
										Transform transform7 = items[obj].transform;
										if ((object)transform7 != null)
										{
											Transform transform8 = transform7.transform;
											if ((object)transform8 != null)
											{
												Vector3 localPosition2 = transform8.localPosition;
												float deltaTime5 = PauseSystem.DeltaTime;
												float num17 = deltaTime5 * m_SlideToFillGapSpeed;
												float y2 = num17 * num;
												if (!(0f > y2))
												{
													if (y2 > 1f)
													{
														y2 = 1f;
													}
												}
												else
												{
													y2 = 0f;
												}
												Transform transform9 = items[obj].transform;
												if ((object)transform9 != null)
												{
													Vector3 localPosition3 = transform9.localPosition;
													Transform transform10 = base.transform;
													if ((object)transform10 != null)
													{
														Vector3 position = transform10.position;
														float deltaTime6 = PauseSystem.DeltaTime;
														float num18 = deltaTime6 * m_SlideToFillGapSpeed;
														float t = num18 * num;
														Transform transform11 = items[obj].transform;
														float y = position.x + 400f;
														float num19 = Mathf.Lerp(localPosition3.x, y, t);
														bool flag6 = (object)transform11 == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1056 @ rax_v61 (UnityEngine.Transform)+10]");
														object obj3 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1056 @ rax_v61 (UnityEngine.Transform)+10]");
														bool flag7 = (nint)0 == 0;
														object obj4 = 0;
														float num20 = num9;
														object obj5 = 0;
														nint num10 = (nint)(&num20);
														num6 = y;
														deltaTime3 = num9;
														goto IL_094f;
													}
												}
											}
										}
										goto IL_0705;
									}
								}
								if (!(num6 < m_AgeToDie))
								{
									if (m_GlimmmerTechniquesToBeReturnedToPool == null)
									{
										goto IL_0705;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4650");
									nint num10 = (nint)items[obj];
								}
							}
							goto IL_0737;
						}
					}
					goto IL_0705;
					IL_094f:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1638 @ rax_v42 (should have been resolved before IL gen)");
					num4 = num3;
					goto IL_0737;
					IL_0737:
					currentlyShowingGlimmmerTechniques2 = m_CurrentlyShowingGlimmmerTechniques;
					obj++;
					if (m_CurrentlyShowingGlimmmerTechniques != null)
					{
						obj2 = obj;
						continue;
					}
					goto IL_0705;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 909 Invalid \"Jump target not found in method: 0x1877DC0D0\"");
		}
		goto IL_0705;
		IL_0705:
		throw new NullReferenceException();
	}

	private void ProcessReturningGlimmmerTechniquesToPool()
	{
		//IL_01f9: Expected I4, but got O
		//IL_01f9: Expected O, but got I
		bool flag = m_GlimmmerTechniquesToBeReturnedToPool == null;
		GlimmerTechniqueCarousel glimmerTechniqueCarousel = this;
		if (!flag)
		{
			List<GlimmerTechniqueCarouselItem>.Enumerator enumerator = default(List<GlimmerTechniqueCarouselItem>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = null;
				if (m_CurrentlyShowingGlimmmerTechniques != null)
				{
					bool flag2 = ((List<object>)(object)m_CurrentlyShowingGlimmmerTechniques).Remove((object)null);
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			glimmerTechniqueCarousel = (GlimmerTechniqueCarousel)(object)m_GlimmmerTechniquesToBeReturnedToPool;
			if (m_GlimmmerTechniquesToBeReturnedToPool != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rcx_v7 (VampireSurvivors.Framework.GlimmerTechniqueCarousel)+1C]");
				_ = (nint)0 + (nint)1;
				((MonoBehaviour)glimmerTechniqueCarousel).m_CancellationTokenSource = null;
				if ((nint)((MonoBehaviour)glimmerTechniqueCarousel).m_CancellationTokenSource > 0)
				{
					Array.Clear((Array)(nint)((UnityEngine.Object)glimmerTechniqueCarousel).m_CachedPtr, 0, (int)((MonoBehaviour)glimmerTechniqueCarousel).m_CancellationTokenSource);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void SpawnNewTestTechnique()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6602]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 26 Invalid \"Jump target not found in method: 0x1877DC410\"");
	}

	public void SpawnGlimmerTechnique(string techniqueText)
	{
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_036f: Expected O, but got I
		//IL_01d6: Expected O, but got I
		//IL_020e: Invalid comparison between I and F4
		//IL_0265: Expected O, but got I
		//IL_0075->IL0293: Incompatible stack heights: 1 vs 0
		//IL_00c8->IL0293: Incompatible stack heights: 1 vs 0
		//IL_0101->IL0293: Incompatible stack heights: 1 vs 0
		//IL_0293->IL02c8: Incompatible stack heights: 10 vs 0
		List<GlimmerTechniqueCarouselItem> glimmmerTechniquePool = m_GlimmmerTechniquePool;
		if (m_GlimmmerTechniquePool != null)
		{
			if (glimmmerTechniquePool._size <= 0)
			{
				return;
			}
			bool flag = glimmmerTechniquePool._size <= 0;
			GlimmerTechniqueCarouselItem[] items = glimmmerTechniquePool._items;
			if (glimmmerTechniquePool._items != null)
			{
				if (items.Length <= 0)
				{
					throw new IndexOutOfRangeException();
				}
				Component component = items[0];
				if (m_GlimmmerTechniquePool != null)
				{
					m_GlimmmerTechniquePool.RemoveAt(0);
					Transform offScreenTransform = m_OffScreenTransform;
					if ((object)m_OffScreenTransform != null)
					{
						bool flag2 = ((UnityEngine.Object)offScreenTransform).m_CachedPtr == (IntPtr)0;
						Transform.get_localPosition_Injected(((UnityEngine.Object)offScreenTransform).m_CachedPtr, out Vector3 _);
						List<GlimmerTechniqueCarouselItem> currentlyShowingGlimmmerTechniques = m_CurrentlyShowingGlimmmerTechniques;
						bool flag3 = m_CurrentlyShowingGlimmmerTechniques == null;
						object obj = currentlyShowingGlimmmerTechniques._size * m_GapBetweenTechniques;
						bool flag4 = (object)items[0] == null;
						Transform transform = items[0].transform;
						bool flag5 = (object)transform == null;
						Transform transform2 = transform.transform;
						object obj3 = default(object);
						object obj2 = obj3 - obj;
						bool flag6 = (object)transform2 == null;
						bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdi_v12 (UnityEngine.Component)+20]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdi_v12 (UnityEngine.Component)+20]");
						bool flag8 = (nint)0 == 0;
						object obj5 = obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v720 @ rax_v36+558] (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdi_v12 (UnityEngine.Component)+20]");
						object obj6 = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdi_v12 (UnityEngine.Component)+20]");
						bool flag9 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v618 @ rcx_v29+15C]");
						bool flag10 = 0f == 1f;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001877DC686h\"");
						if (!flag10)
						{
							_ = 1065353216;
							object obj7 = obj6;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v731 @ rax_v43+2F8] (should have been resolved before IL gen)");
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdi_v12 (UnityEngine.Component)+28]");
						SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha((SpriteRenderer)0, 0.65f);
						bool flag11 = m_CurrentlyShowingGlimmmerTechniques == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4650");
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public GlimmerTechniqueCarousel()
	{
		//IL_0057: Expected I, but got O
		m_SlideToFillGapSpeed = 100f;
		m_TechniquePoolSize = 15;
		m_GapBetweenTechniques = 40f;
		m_AgeToEndIntroSwish = 0.5f;
		m_AgeToStartExit = 0.9f;
		m_AgeToDie = 1f;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
