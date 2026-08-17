using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coffee.UIParticleExtensions;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace Coffee.UIExtensions;

public class UIParticleAttractor : MonoBehaviour
{
	public enum Movement
	{
		Linear,
		Smooth,
		Sphere
	}

	private ParticleSystem m_ParticleSystem;

	private float m_DestinationRadius;

	private float m_DelayRate;

	private float m_MaxSpeed;

	private Movement m_Movement;

	private UnityEvent m_OnAttracted;

	private UIParticle _uiParticle;

	public float delay
	{
		get
		{
			return m_DelayRate;
		}
		set
		{
			m_DelayRate = value;
		}
	}

	public float maxSpeed
	{
		get
		{
			return m_MaxSpeed;
		}
		set
		{
			m_MaxSpeed = value;
		}
	}

	public Movement movement
	{
		get
		{
			return m_Movement;
		}
		set
		{
			m_Movement = value;
		}
	}

	private void OnEnable()
	{
		ParticleSystem particleSystem = m_ParticleSystem;
		if ((object)m_ParticleSystem != null && ((UnityEngine.Object)particleSystem).m_CachedPtr != (IntPtr)0)
		{
			UIParticle componentInParent = m_ParticleSystem.GetComponentInParent<UIParticle>();
			_uiParticle = componentInParent;
			UIParticle uiParticle = _uiParticle;
			if ((object)_uiParticle != null && ((UnityEngine.Object)uiParticle).m_CachedPtr != (IntPtr)0)
			{
				UIParticle uiParticle2 = _uiParticle;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004A40");
				object obj = default(object);
				if (obj == null)
				{
					_uiParticle = null;
				}
			}
			if (((UnityEngine.Object)this).m_CachedPtr != (IntPtr)0)
			{
				List<object> s_ActiveAttractors = (List<object>)(object)UIParticleUpdater.s_ActiveAttractors;
				int version = s_ActiveAttractors._version + 1;
				s_ActiveAttractors._version = version;
				object[] items = s_ActiveAttractors._items;
				if (s_ActiveAttractors._size >= items.Length)
				{
					s_ActiveAttractors.AddWithResize((object)this);
					return;
				}
				int size = s_ActiveAttractors._size + 1;
				s_ActiveAttractors._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
		}
		else
		{
			Debug.LogError("No particle system attached to particle attractor script", this);
			base.enabled = false;
		}
	}

	private void OnDisable()
	{
		_uiParticle = null;
		if (((UnityEngine.Object)this).m_CachedPtr != (IntPtr)0)
		{
			bool flag = ((List<object>)(object)UIParticleUpdater.s_ActiveAttractors).Remove((object)this);
		}
	}

	internal unsafe void Attract()
	{
		//IL_00e7: Expected O, but got I4
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Expected O, but got Unknown
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Expected O, but got Unknown
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Expected O, but got Unknown
		//IL_014f: Invalid comparison between F4 and I
		//IL_0169: Expected F4, but got I
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Expected O, but got Unknown
		//IL_027d: Expected O, but got I4
		//IL_01b2: Expected F4, but got I
		//IL_01c3: Expected O, but got I
		//IL_01d3: Expected F4, but got I
		//IL_01e8: Expected O, but got Ref
		//IL_0298: Expected O, but got Ref
		//IL_0298: Expected O, but got Ref
		//IL_02e2: Expected O, but got I
		//IL_02ea: Expected O, but got Ref
		//IL_0211: Expected F4, but got I
		//IL_0222: Expected O, but got I
		//IL_0232: Expected F4, but got I
		//IL_0247: Expected O, but got Ref
		ParticleSystem particleSystem = m_ParticleSystem;
		if ((object)m_ParticleSystem == null || ((UnityEngine.Object)particleSystem).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		int particleCount = m_ParticleSystem.particleCount;
		if (particleCount == 0)
		{
			return;
		}
		ParticleSystem.Particle[] particleArray = ParticleSystemExtensions.GetParticleArray(particleCount);
		int particles = m_ParticleSystem.GetParticles(particleArray, particleCount, 0);
		Vector3 destinationPosition = GetDestinationPosition();
		UIParticleAttractor uIParticleAttractor = null;
		object obj = 0;
		int num = 0;
		object obj3 = default(object);
		float num6 = default(float);
		float x2 = default(float);
		float duration = default(float);
		float time = default(float);
		float num7 = default(float);
		for (; (nint)uIParticleAttractor < particleCount; uIParticleAttractor = (UIParticleAttractor)(uIParticleAttractor + 1))
		{
			object obj2 = uIParticleAttractor * 132;
			float num3;
			object obj4;
			if ((nint)obj3 > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2DA0");
				float destinationRadius = m_DestinationRadius;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v23+20+v648 @ rax_v17 (Particle[])]");
				bool flag = !(destinationRadius > 0f);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v23+20+v648 @ rax_v17 (Particle[])]");
				float num2 = 0f;
				float x = destinationPosition.x;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004930");
					bool flag2 = m_OnAttracted == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v23+20+v648 @ rax_v17 (Particle[])]");
					num3 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v23+70+v648 @ rax_v17 (Particle[])]");
					obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v23+20+v648 @ rax_v17 (Particle[])]");
					num2 = 0f;
					x = destinationPosition.x;
					obj = (object)(&num3);
					if (!flag2)
					{
						m_OnAttracted.Invoke();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v23+20+v648 @ rax_v17 (Particle[])]");
						num3 = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v23+70+v648 @ rax_v17 (Particle[])]");
						obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v23+20+v648 @ rax_v17 (Particle[])]");
						num2 = 0f;
						x = destinationPosition.x;
						obj = (object)(&num3);
					}
					continue;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v23+90+v648 @ rax_v17 (Particle[])]");
			object obj5 = 0 * m_DelayRate;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v23+90+v648 @ rax_v17 (Particle[])]");
			float num4 = 0f - (float)obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v23+90+v648 @ rax_v17 (Particle[])]");
			object obj6 = 0 - obj3;
			obj4 = obj6 - obj5;
			object obj7 = 0 - obj4;
			object obj8 = obj4 & obj7;
			bool flag3 = (nint)obj8 < 0;
			bool flag4 = (nint)obj7 < 0;
			if (0 > (nint)obj4)
			{
				flag3 = 0 < 0;
				flag4 = 0 < 0;
				obj4 = 0;
			}
			bool flag5 = flag4 == flag3;
			float num5 = num4;
			if (!flag5)
			{
				Vector3 attractedPosition = GetAttractedPosition((Vector3)(&num6), (Vector3)(&x2), duration, time);
				num5 = num7 * 0.5f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004930");
				x2 = destinationPosition.x;
				num3 = attractedPosition.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v23+70+v648 @ rax_v17 (Particle[])]");
				obj4 = 0;
				obj = (object)(&num3);
				num = (int)(&x2);
			}
		}
		m_ParticleSystem.SetParticles(particleArray, particleCount, 0);
	}

	private unsafe Vector3 GetDestinationPosition()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0323: Expected native int or pointer, but got O
		//IL_0331: Expected native int or pointer, but got O
		//IL_03b6: Expected O, but got Ref
		//IL_0427: Expected O, but got Ref
		//IL_044e: Expected F4, but got I
		//IL_0449: Expected native int or pointer, but got O
		//IL_0463: Expected F4, but got I
		//IL_045e: Expected native int or pointer, but got O
		//IL_0499: Expected O, but got I
		//IL_0845: Expected O, but got Ref
		//IL_06ba: Expected O, but got Ref
		//IL_06c8: Expected O, but got Ref
		//IL_06f3: Expected F4, but got I
		//IL_06ee: Expected native int or pointer, but got O
		//IL_0708: Expected F4, but got I
		//IL_0703: Expected native int or pointer, but got O
		//IL_04fe: Expected O, but got Ref
		//IL_055a: Expected native int or pointer, but got O
		//IL_0583: Expected native int or pointer, but got O
		//IL_0590: Expected native int or pointer, but got O
		//IL_065e: Expected native int or pointer, but got O
		//IL_066b: Expected native int or pointer, but got O
		//IL_0678: Expected native int or pointer, but got O
		//IL_0759: Expected O, but got Ref
		//IL_0809: Expected O, but got I
		//IL_0820: Expected native int or pointer, but got O
		//IL_082d: Expected native int or pointer, but got O
		//IL_03ea->IL0309: Incompatible stack heights: 1 vs 0
		//IL_047d->IL0309: Incompatible stack heights: 2 vs 0
		//IL_0219->IL0309: Incompatible stack heights: 2 vs 0
		//IL_0100->IL0837: Incompatible stack heights: 3 vs 2
		//IL_0245->IL0309: Incompatible stack heights: 2 vs 0
		//IL_0133->IL0309: Incompatible stack heights: 2 vs 0
		//IL_015f->IL0309: Incompatible stack heights: 2 vs 0
		//IL_071c->IL04c1: Incompatible stack heights: 3 vs 2
		//IL_0282->IL0309: Incompatible stack heights: 3 vs 0
		//IL_05af->IL0309: Incompatible stack heights: 3 vs 0
		//IL_02ae->IL0309: Incompatible stack heights: 3 vs 0
		//IL_0682->IL04c1: Incompatible stack heights: 3 vs 2
		//IL_078f->IL0309: Incompatible stack heights: 4 vs 0
		//IL_0837->IL04c1: Incompatible stack heights: 4 vs 2
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Transform uiParticle = (Transform)(object)_uiParticle;
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = 0f;
		((Vector3*)(nint)vector)->z = 0f;
		bool flag2;
		if ((object)_uiParticle != null && ((UnityEngine.Object)uiParticle).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_uiParticle == null)
			{
				goto IL_0309;
			}
			bool flag = _uiParticle.enabled;
			flag2 = flag;
		}
		else
		{
			flag2 = false;
		}
		float num6;
		if ((object)m_ParticleSystem != null)
		{
			Transform transform = m_ParticleSystem.transform;
			if ((object)transform != null)
			{
				_ = 0;
				_ = 0;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj3);
				Transform transform2 = base.transform;
				if ((object)transform2 != null)
				{
					_ = 0;
					_ = 0;
					bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj4);
					Vector3 vector2 = vector;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
					((Vector3*)(nint)vector2)->x = 0f;
					Vector3 vector3 = vector;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-21]");
					((Vector3*)(nint)vector3)->z = 0f;
					if ((object)m_ParticleSystem != null)
					{
						_ = m_ParticleSystem;
						_ = m_ParticleSystem;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B970]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B970]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							bool flag5 = obj5 == null;
						}
						object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v869 @ rax_v52 (should have been resolved before IL gen)");
						object obj7 = default(object);
						if (obj7 != null)
						{
							if (!flag2)
							{
								goto IL_04c1;
							}
							if ((object)_uiParticle != null)
							{
								Transform transform3 = _uiParticle.transform;
								if ((object)transform3 != null)
								{
									_ = 0;
									_ = 0;
									bool flag6 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
									object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
									Transform.get_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)obj8);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
									float x = 0f * vector.x;
									UIParticle uiParticle2 = _uiParticle;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-35]");
									float y = 0f * vector.y;
									((Vector3*)(nint)vector)->x = x;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-31]");
									float z = 0f * vector.z;
									((Vector3*)(nint)vector)->y = y;
									((Vector3*)(nint)vector)->z = z;
									if ((object)_uiParticle != null)
									{
										_ = uiParticle2.m_Scale3D;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
										object obj9 = default(object);
										bool flag7 = obj9 != null;
										float num = 1f;
										if (!flag7)
										{
											num = 1f / (float)uiParticle2.m_Scale3D;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
										object obj10 = default(object);
										bool flag8 = obj10 != null;
										float num2 = 1f;
										if (!flag8)
										{
											float num3 = 1f;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-25]");
											num2 = num3 / 0f;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
										object obj11 = default(object);
										bool flag9 = obj11 != null;
										float num4 = 1f;
										if (!flag9)
										{
											float num5 = 1f;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rax_v83 (Coffee.UIExtensions.UIParticle)+EC]");
											num4 = num5 / 0f;
										}
										float x2 = num * vector.x;
										float y2 = num2 * vector.y;
										float z2 = num4 * vector.z;
										((Vector3*)(nint)vector)->x = x2;
										((Vector3*)(nint)vector)->y = y2;
										((Vector3*)(nint)vector)->z = z2;
										goto IL_04c1;
									}
								}
							}
						}
						else if ((object)m_ParticleSystem != null)
						{
							Transform transform4 = m_ParticleSystem.transform;
							if ((object)transform4 != null)
							{
								_ = vector.x;
								_ = vector.z;
								_ = 0;
								_ = 0;
								bool flag10 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
								object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
								object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
								Transform.InverseTransformPoint_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Vector3*)obj13, out *(Vector3*)obj12);
								Vector3 vector4 = vector;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
								((Vector3*)(nint)vector4)->x = 0f;
								Vector3 vector5 = vector;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-31]");
								((Vector3*)(nint)vector5)->z = 0f;
								if (!flag2)
								{
									goto IL_04c1;
								}
								if ((object)_uiParticle != null)
								{
									Transform transform5 = _uiParticle.transform;
									if ((object)transform5 != null)
									{
										_ = 0;
										_ = 0;
										bool flag11 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
										object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
										Transform.get_localScale_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out *(Vector3*)obj14);
										UIParticle uiParticle3 = _uiParticle;
										if ((object)_uiParticle != null)
										{
											_ = uiParticle3.m_Scale3D;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
											object obj15 = default(object);
											if (obj15 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
												object obj16 = default(object);
												if (obj16 == null)
												{
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
												object obj17 = default(object);
												bool flag12 = obj17 != null;
												num6 = 1f;
												if (flag12)
												{
													goto IL_07ec;
												}
											}
											float num7 = 1f;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rax_v69 (Coffee.UIExtensions.UIParticle)+EC]");
											num6 = num7 / 0f;
											goto IL_07ec;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0309;
		IL_07ec:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-21]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-31]");
		object obj18 = num8 * 0;
		float z3 = (float)obj18 * num6;
		float x3 = default(float);
		((Vector3*)(nint)vector)->x = x3;
		((Vector3*)(nint)vector)->z = z3;
		goto IL_04c1;
		IL_0309:
		throw new NullReferenceException();
		IL_04c1:
		return vector;
	}

	private unsafe Vector3 GetAttractedPosition(Vector3 current, Vector3 target, float duration, float time)
	{
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01d8: Expected F4, but got O
		//IL_01d3: Expected native int or pointer, but got O
		//IL_01ed: Expected F4, but got I
		//IL_01e8: Expected native int or pointer, but got O
		//IL_0103: Invalid comparison between I4 and F4
		//IL_014e: Expected F4, but got I4
		//IL_0285: Expected O, but got I
		//IL_02ef: Expected native int or pointer, but got O
		//IL_02fc: Expected native int or pointer, but got O
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected I4, but got Unknown
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected O, but got Unknown
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Expected O, but got Unknown
		//IL_0231: Expected F4, but got O
		//IL_0246: Expected F4, but got I
		//IL_0241: Expected native int or pointer, but got O
		//IL_025b: Expected F4, but got I
		//IL_0256: Expected native int or pointer, but got O
		Movement movement = m_Movement;
		float num = m_MaxSpeed;
		bool flag = m_Movement == Movement.Linear;
		object obj = default(object);
		if (!flag)
		{
			movement--;
			if (!flag)
			{
				if (movement == Movement.Smooth)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+38]");
					float num2 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
					float num3 = num2 / 0f;
					_ = target.z;
					_ = current.z;
					_ = 0;
					_ = 0;
					_ = target.x;
					_ = current.x;
					movement = (Movement)(obj - 80);
					object obj2 = obj - 64;
					object obj3 = obj - 48;
					Vector3.Slerp_Injected(ref *(Vector3*)obj3, ref *(Vector3*)obj2, (float)current, out *(Vector3*)(int)movement);
					Vector3 vector = target;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-50]");
					((Vector3*)(nint)vector)->x = 0f;
					Vector3 vector2 = target;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-48]");
					((Vector3*)(nint)vector2)->z = 0f;
					float num4 = num3;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+38]");
				float num5 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
				float num6 = num5 / 0f;
				_ = target.x;
				_ = current.x;
				if (!(0f > num6))
				{
					if (num6 > 1f)
					{
						num6 = 1f;
					}
				}
				else
				{
					num6 = 0f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-2C]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-3C]");
				object obj4 = num7 - 0;
				float num8 = target.z - current.z;
				float num9 = (float)obj4 * num6;
				float num10 = num8 * num6;
				float num11 = num9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-3C]");
				float num12 = num11 + 0f;
				float num4 = num10 + current.z;
				float x = default(float);
				((Vector3*)(nint)target)->x = x;
				((Vector3*)(nint)target)->z = num4;
			}
		}
		else
		{
			float num13 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
			num = num13 / 0f;
		}
		object obj5 = obj - 48;
		object obj6 = obj - 64;
		_ = target.x;
		object obj7 = obj - 80;
		_ = target.z;
		_ = current.x;
		_ = current.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2E70");
		Vector3 vector3 = default(Vector3);
		object obj8 = default(object);
		((Vector3*)(nint)vector3)->x = (float)obj8;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v4+8]");
		((Vector3*)(nint)vector3)->z = 0f;
		return vector3;
	}

	public UIParticleAttractor()
	{
		//IL_002b: Expected I, but got O
		m_DestinationRadius = 1f;
		m_MaxSpeed = 1f;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
