using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;

namespace Coffee.UIParticleExtensions;

public static class ParticleSystemExtensions
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<ParticleSystem> _003C_003E9__7_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CExec_003Eb__7_0(ParticleSystem p)
		{
			if ((object)p != null)
			{
				return ((UnityEngine.Object)p).m_CachedPtr == (IntPtr)0;
			}
			return true;
		}
	}

	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public Transform transform;

		public bool sortByMaterial;

		public List<ParticleSystem> self;

		internal unsafe int _003CSortForRendering_003Eb__0(ParticleSystem a, ParticleSystem b)
		{
			//IL_046e: Expected I4, but got I8
			//IL_0337: Invalid comparison between F4 and I4
			//IL_02fd: Expected O, but got I4
			//IL_05c4->IL05c4: Incompatible stack heights: 2 vs 0
			object obj = this.transform;
			ParticleSystemRenderer component = a.GetComponent<ParticleSystemRenderer>();
			ParticleSystemRenderer component2 = b.GetComponent<ParticleSystemRenderer>();
			Material sharedMaterial = ((Renderer)component).GetSharedMaterial();
			bool flag = (object)sharedMaterial != null;
			Material material = sharedMaterial;
			if (!flag)
			{
				Material trailMaterial = component.trailMaterial;
				material = trailMaterial;
			}
			Material sharedMaterial2 = ((Renderer)component2).GetSharedMaterial();
			bool flag2 = (object)sharedMaterial2 != null;
			Material material2 = sharedMaterial2;
			if (!flag2)
			{
				Material trailMaterial2 = component2.trailMaterial;
				material2 = trailMaterial2;
			}
			int num = default(int);
			if (((object)material == null || ((UnityEngine.Object)material).m_CachedPtr == (IntPtr)0) && ((object)material2 == null || ((UnityEngine.Object)material2).m_CachedPtr == (IntPtr)0))
			{
				num = 0;
			}
			else if ((object)material != null && ((UnityEngine.Object)material).m_CachedPtr != (IntPtr)0)
			{
				if ((bool)material2)
				{
					if (!sortByMaterial)
					{
						int renderQueue = material.renderQueue;
						int renderQueue2 = material2.renderQueue;
						if (renderQueue == renderQueue2)
						{
							int sortingLayerID = component.sortingLayerID;
							int sortingLayerID2 = component2.sortingLayerID;
							if (sortingLayerID == sortingLayerID2)
							{
								int sortingOrder = component.sortingOrder;
								int sortingOrder2 = component2.sortingOrder;
								if (sortingOrder == sortingOrder2)
								{
									Transform transform = a.transform;
									Transform transform2 = b.transform;
									Vector3 position = transform.position;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r14_v1 (System.Object)+10]");
									bool flag3 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r14_v1 (System.Object)+10]");
									float position2 = default(float);
									Transform.InverseTransformPoint_Injected((IntPtr)0, ref *(Vector3*)(&position2), out Vector3 ret);
									float sortingFudge = component.sortingFudge;
									Vector3 position3 = transform2.position;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r14_v1 (System.Object)+10]");
									bool flag4 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r14_v1 (System.Object)+10]");
									Transform.InverseTransformPoint_Injected((IntPtr)0, ref *(Vector3*)(&position2), out ret);
									float sortingFudge2 = component2.sortingFudge;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
									if (num != 0)
									{
										int index = GetIndex(self, a);
										num = GetIndex(self, b);
										object obj2 = index - num;
										if ((nint)obj2 < 0)
										{
										}
									}
									else
									{
										float num2 = sortingFudge2 - sortingFudge;
										if (num2 < 0f)
										{
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
								}
								else
								{
									int sortingOrder3 = component.sortingOrder;
									int sortingOrder4 = component2.sortingOrder;
									int num3 = sortingOrder3 - sortingOrder4;
									num = num3;
								}
							}
							else
							{
								int sortingLayerID3 = component.sortingLayerID;
								int layerValueFromID = SortingLayer.GetLayerValueFromID(sortingLayerID3);
								int sortingLayerID4 = component2.sortingLayerID;
								int layerValueFromID2 = SortingLayer.GetLayerValueFromID(sortingLayerID4);
								int num4 = layerValueFromID - layerValueFromID2;
								num = num4;
							}
						}
						else
						{
							int renderQueue3 = material.renderQueue;
							int renderQueue4 = material2.renderQueue;
							int num5 = renderQueue3 - renderQueue4;
							num = num5;
						}
					}
					else
					{
						int instanceID = material.GetInstanceID();
						int instanceID2 = material2.GetInstanceID();
						int num6 = instanceID - instanceID2;
						num = num6;
					}
				}
				else
				{
					num = 1;
				}
			}
			else
			{
				num = -1;
			}
			return num;
		}
	}

	private static ParticleSystem.Particle[] s_TmpParticles;

	public static ParticleSystem.Particle[] GetParticleArray(int size)
	{
		//IL_0062: Expected O, but got I4
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected I4, but got Unknown
		ParticleSystem.Particle[] array = s_TmpParticles;
		int num;
		if (s_TmpParticles != null)
		{
			bool flag = array.Length >= size;
			num = size;
			if (flag)
			{
				goto IL_0183;
			}
			while (true)
			{
				ParticleSystem.Particle[] array2 = s_TmpParticles;
				if (s_TmpParticles == null)
				{
					break;
				}
				if (array2.Length < num)
				{
					object obj = num - 1;
					object obj2 = obj >> 16;
					object obj3 = obj | obj2;
					object obj4 = obj3 >> 8;
					object obj5 = obj3 | obj4;
					object obj6 = obj5 >> 4;
					object obj7 = obj5 | obj6;
					object obj8 = obj7 >> 2;
					object obj9 = obj7 | obj8;
					object obj10 = obj9 >> 1;
					object obj11 = obj10 | obj9;
					num = obj11 + 1;
					continue;
				}
				goto IL_00fc;
			}
		}
		return (ParticleSystem.Particle[])(object)new NullReferenceException();
		IL_0183:
		return s_TmpParticles;
		IL_00fc:
		ParticleSystem.Particle[] array3 = new ParticleSystem.Particle[num];
		s_TmpParticles = array3;
		goto IL_0183;
	}

	public static bool CanBakeMesh(ParticleSystemRenderer self)
	{
		//IL_0091: Expected O, but got I4
		//IL_0146: Expected O, but got I4
		//IL_004b->IL004b: Incompatible stack heights: 2 vs 1
		bool flag = ((UnityEngine.Object)self).m_CachedPtr == (IntPtr)0;
		object obj = ParticleSystemRenderer.get_renderMode_Injected(((UnityEngine.Object)self).m_CachedPtr);
		bool num;
		if ((nint)obj == 4)
		{
			bool flag2 = ((UnityEngine.Object)self).m_CachedPtr == (IntPtr)0;
			num = flag2;
			IntPtr gcHandlePtr = ParticleSystemRenderer.get_mesh_Injected(((UnityEngine.Object)self).m_CachedPtr);
			Mesh mesh = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Mesh>(gcHandlePtr);
			if ((object)mesh == null || ((UnityEngine.Object)mesh).m_CachedPtr == (IntPtr)0)
			{
				goto IL_005b;
			}
		}
		bool flag3 = ((UnityEngine.Object)self).m_CachedPtr == (IntPtr)0;
		num = flag3;
		object obj2 = ParticleSystemRenderer.get_renderMode_Injected(((UnityEngine.Object)self).m_CachedPtr);
		if ((nint)obj2 != 5)
		{
			return true;
		}
		goto IL_005b;
		IL_005b:
		return false;
	}

	public static ParticleSystemSimulationSpace GetActualSimulationSpace(ParticleSystem self)
	{
		//IL_00cb: Expected O, but got I
		//IL_011c: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B970]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B970]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v127 @ rax_v11 (should have been resolved before IL gen)");
		ParticleSystemSimulationSpace particleSystemSimulationSpace = default(ParticleSystemSimulationSpace);
		bool flag = particleSystemSimulationSpace != ParticleSystemSimulationSpace.Custom;
		ParticleSystemSimulationSpace result = particleSystemSimulationSpace;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA40]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA40]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj2 == null)
				{
					MissingMethodException ex2 = new MissingMethodException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v300 @ rax_v17 (should have been resolved before IL gen)");
			IntPtr gcHandlePtr = default(IntPtr);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			if ((object)transform != null)
			{
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0;
				result = particleSystemSimulationSpace;
				if (flag2)
				{
					goto IL_0107;
				}
			}
			result = ParticleSystemSimulationSpace.Local;
		}
		goto IL_0107;
		IL_0107:
		return result;
	}

	public unsafe static void SortForRendering(List<ParticleSystem> self, Transform transform, bool sortByMaterial)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals8.transform = transform;
		CS_0024_003C_003E8__locals8.sortByMaterial = sortByMaterial;
		CS_0024_003C_003E8__locals8.self = self;
		Comparison<ParticleSystem> comparison = delegate(ParticleSystem a, ParticleSystem b)
		{
			//IL_046e: Expected I4, but got I8
			//IL_0337: Invalid comparison between F4 and I4
			//IL_02fd: Expected O, but got I4
			//IL_05c4->IL05c4: Incompatible stack heights: 2 vs 0
			object transform2 = CS_0024_003C_003E8__locals8.transform;
			ParticleSystemRenderer component = a.GetComponent<ParticleSystemRenderer>();
			ParticleSystemRenderer component2 = b.GetComponent<ParticleSystemRenderer>();
			Material sharedMaterial = ((Renderer)component).GetSharedMaterial();
			bool flag = (object)sharedMaterial != null;
			Material material = sharedMaterial;
			if (!flag)
			{
				Material trailMaterial = component.trailMaterial;
				material = trailMaterial;
			}
			Material sharedMaterial2 = ((Renderer)component2).GetSharedMaterial();
			bool flag2 = (object)sharedMaterial2 != null;
			Material material2 = sharedMaterial2;
			if (!flag2)
			{
				Material trailMaterial2 = component2.trailMaterial;
				material2 = trailMaterial2;
			}
			int num = default(int);
			if (((object)material == null || ((UnityEngine.Object)material).m_CachedPtr == (IntPtr)0) && ((object)material2 == null || ((UnityEngine.Object)material2).m_CachedPtr == (IntPtr)0))
			{
				num = 0;
			}
			else if ((object)material != null && ((UnityEngine.Object)material).m_CachedPtr != (IntPtr)0)
			{
				if ((bool)material2)
				{
					if (!CS_0024_003C_003E8__locals8.sortByMaterial)
					{
						int renderQueue = material.renderQueue;
						int renderQueue2 = material2.renderQueue;
						if (renderQueue == renderQueue2)
						{
							int sortingLayerID = component.sortingLayerID;
							int sortingLayerID2 = component2.sortingLayerID;
							if (sortingLayerID == sortingLayerID2)
							{
								int sortingOrder = component.sortingOrder;
								int sortingOrder2 = component2.sortingOrder;
								if (sortingOrder == sortingOrder2)
								{
									Transform transform3 = a.transform;
									Transform transform4 = b.transform;
									Vector3 position = transform3.position;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r14_v1 (System.Object)+10]");
									bool flag3 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r14_v1 (System.Object)+10]");
									float position2 = default(float);
									Transform.InverseTransformPoint_Injected((IntPtr)0, ref *(Vector3*)(&position2), out Vector3 ret);
									float sortingFudge = component.sortingFudge;
									Vector3 position3 = transform4.position;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r14_v1 (System.Object)+10]");
									bool flag4 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r14_v1 (System.Object)+10]");
									Transform.InverseTransformPoint_Injected((IntPtr)0, ref *(Vector3*)(&position2), out ret);
									float sortingFudge2 = component2.sortingFudge;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
									if (num != 0)
									{
										int index = GetIndex(CS_0024_003C_003E8__locals8.self, a);
										num = GetIndex(CS_0024_003C_003E8__locals8.self, b);
										object obj = index - num;
										if ((nint)obj < 0)
										{
										}
									}
									else
									{
										float num2 = sortingFudge2 - sortingFudge;
										if (num2 < 0f)
										{
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
								}
								else
								{
									int sortingOrder3 = component.sortingOrder;
									int sortingOrder4 = component2.sortingOrder;
									int num3 = sortingOrder3 - sortingOrder4;
									num = num3;
								}
							}
							else
							{
								int sortingLayerID3 = component.sortingLayerID;
								int layerValueFromID = SortingLayer.GetLayerValueFromID(sortingLayerID3);
								int sortingLayerID4 = component2.sortingLayerID;
								int layerValueFromID2 = SortingLayer.GetLayerValueFromID(sortingLayerID4);
								int num4 = layerValueFromID - layerValueFromID2;
								num = num4;
							}
						}
						else
						{
							int renderQueue3 = material.renderQueue;
							int renderQueue4 = material2.renderQueue;
							int num5 = renderQueue3 - renderQueue4;
							num = num5;
						}
					}
					else
					{
						int instanceID = material.GetInstanceID();
						int instanceID2 = material2.GetInstanceID();
						int num6 = instanceID - instanceID2;
						num = num6;
					}
				}
				else
				{
					num = 1;
				}
			}
			else
			{
				num = -1;
			}
			return num;
		};
		((List<object>)(object)CS_0024_003C_003E8__locals8.self).Sort((Comparison<object>)comparison);
	}

	private static int GetIndex(IList<ParticleSystem> list, UnityEngine.Object ps)
	{
		//IL_01c5: Expected I4, but got O
		//IL_0036: Expected I, but got O
		//IL_006e: Expected O, but got I
		//IL_0201: Expected O, but got I4
		//IL_0166: Expected O, but got I4
		//IL_017c: Expected O, but got I
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		bool flag = list == null;
		int num = 0;
		int num2 = 0;
		if (!flag)
		{
			object obj = default(object);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (num2 < (nint)obj)
				{
					nint num3 = (nint)list;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ r10_v4 (Il2CppClass<System.Collections.Generic.IList`1<UnityEngine.ParticleSystem>>)+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_00ae;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ r10_v4 (Il2CppClass<System.Collections.Generic.IList`1<UnityEngine.ParticleSystem>>)+B0]");
					object obj2 = 0;
					int num4 = 0;
					while (true)
					{
						object obj3 = num4 + num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ r8_v9+v220 @ rcx_v14*8]");
						if (0 == (nint)typeof(IList<ParticleSystem>))
						{
							break;
						}
						num4++;
						int num5 = num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ r10_v4 (Il2CppClass<System.Collections.Generic.IList`1<UnityEngine.ParticleSystem>>)+12E]");
						if ((nint)num5 < (nint)0)
						{
							continue;
						}
						goto IL_00ae;
					}
					object obj4 = num4 + num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ r8_v9+8+v278 @ rcx_v16*8]");
					object obj5 = (nint)0 << 4;
					object obj6 = obj5 + 312;
					object obj7 = obj6 + num3;
					goto IL_00bd;
				}
				return 0;
				IL_00bd:
				ParticleSystem particleSystem = list.get_Item(num);
				if ((object)particleSystem == null)
				{
					break;
				}
				int instanceID = particleSystem.GetInstanceID();
				if ((object)ps == null)
				{
					break;
				}
				int instanceID2 = ps.GetInstanceID();
				if (instanceID != instanceID2)
				{
					num++;
					num2 = num;
					continue;
				}
				return num;
				IL_00ae:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				goto IL_00bd;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public static Texture2D GetTextureForSprite(ParticleSystem self)
	{
		//IL_01f5: Expected O, but got I
		//IL_007c: Expected O, but got I
		//IL_00de: Expected O, but got I4
		//IL_0315: Expected O, but got I
		//IL_02a8: Expected O, but got I
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		if ((object)self != null && ((UnityEngine.Object)self).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB60]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB60]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v335 @ rax_v11 (should have been resolved before IL gen)");
			object obj2 = default(object);
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB70]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB70]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj3 == null)
					{
						MissingMethodException ex2 = new MissingMethodException();
						throw ex2;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v374 @ rax_v14 (should have been resolved before IL gen)");
				object obj4 = default(object);
				if ((nint)obj4 == 1)
				{
					object obj5 = 0;
					object obj7 = default(object);
					IntPtr gcHandlePtr = default(IntPtr);
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBA8]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBA8]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							if (obj6 == null)
							{
								MissingMethodException ex3 = new MissingMethodException();
								throw ex3;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v462 @ rax_v18 (should have been resolved before IL gen)");
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBE0]");
						object obj8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBE0]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							if (obj8 == null)
							{
								MissingMethodException ex4 = new MissingMethodException();
								throw ex4;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v537 @ rax_v22 (should have been resolved before IL gen)");
						Sprite sprite = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Sprite>(gcHandlePtr);
						if ((object)sprite == null || ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0)
						{
							obj5++;
							continue;
						}
						return SpriteExtensions.GetActualTexture(sprite);
					}
				}
			}
		}
		return null;
	}

	public static void Exec(List<ParticleSystem> self, Action<ParticleSystem> action)
	{
		//IL_0058: Expected O, but got I4
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		Predicate<object> match = (Predicate<object>)_003C_003Ec._003C_003E9__7_0;
		if (_003C_003Ec._003C_003E9__7_0 == null)
		{
			match = (Predicate<object>)(_003C_003Ec._003C_003E9__7_0 = (ParticleSystem p) => (object)p == null || ((UnityEngine.Object)p).m_CachedPtr == (IntPtr)0);
		}
		int num = ((List<object>)(object)self).RemoveAll(match);
		if (action != null)
		{
			bool flag = self._size <= 0;
			object obj = 0;
			if (flag)
			{
				goto IL_00b1;
			}
			while (self._version == self._version)
			{
				ParticleSystem[] items = self._items;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [action @ rdx (System.Action`1<UnityEngine.ParticleSystem>)+18] (should have been resolved before IL gen)");
				obj++;
				if ((nint)obj < self._size)
				{
					continue;
				}
				goto IL_00b1;
			}
			goto IL_00db;
		}
		System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.action);
		throw new NullReferenceException();
		IL_00b1:
		if (self._version == self._version)
		{
			return;
		}
		goto IL_00db;
		IL_00db:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
		throw new IndexOutOfRangeException();
	}

	static ParticleSystemExtensions()
	{
		ParticleSystem.Particle[] array = new ParticleSystem.Particle[2048];
		s_TmpParticles = array;
	}
}
