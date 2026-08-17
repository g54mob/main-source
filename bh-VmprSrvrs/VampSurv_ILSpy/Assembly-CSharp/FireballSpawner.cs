using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;

public class FireballSpawner : MonoBehaviour
{
	private sealed class _003CSpawnFireball_003Ed__16(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public float waitTime;

		public FireballSpawner _003C_003E4__this;

		public bool lastFireball;

		private GameObject _003Cfireball_003E5__2;

		private float _003Ctimer_003E5__3;

		private ParticleSystem _003Cexplosion_003E5__4;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0008: Expected O, but got Ref
			//IL_08f1: Expected I4, but got I8
			//IL_001d: Expected O, but got I4
			//IL_0192: Expected I4, but got I8
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Expected O, but got Unknown
			//IL_015f: Expected I4, but got I8
			//IL_09da: Invalid comparison between I and F4
			//IL_0076: Expected I4, but got I8
			//IL_0378: Invalid comparison between I4 and F4
			//IL_0a2d: Expected O, but got Ref
			//IL_0a4f: Expected O, but got I
			//IL_0a5f: Expected O, but got I
			//IL_03c3: Expected F4, but got I4
			//IL_0cf4: Invalid comparison between I4 and F4
			//IL_1040: Expected O, but got Ref
			//IL_104e: Expected O, but got Ref
			//IL_0212: Expected O, but got I
			//IL_03ff: Expected F4, but got I4
			//IL_02af: Expected O, but got Ref
			//IL_02bd: Expected O, but got Ref
			//IL_0a92: Expected I, but got O
			//IL_0ab9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0abe: Expected O, but got Unknown
			//IL_0ace: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ad3: Expected O, but got Unknown
			//IL_0af0: Expected O, but got I
			//IL_0b3a: Invalid comparison between F4 and O
			//IL_00f1: Expected O, but got I
			//IL_0cd1: Expected O, but got F4
			//IL_023f: Expected I, but got O
			//IL_0430: Expected O, but got I
			//IL_0b75: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b7a: Expected O, but got Unknown
			//IL_0b8a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b8f: Expected O, but got Unknown
			//IL_0bac: Expected O, but got I
			//IL_0bf6: Invalid comparison between F4 and O
			//IL_027b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0280: Expected O, but got Unknown
			//IL_04c8: Expected O, but got Ref
			//IL_09ab: Expected O, but got I4
			//IL_0c31: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c36: Expected O, but got Unknown
			//IL_0c46: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c4b: Expected O, but got Unknown
			//IL_0c68: Expected O, but got I
			//IL_0cb2: Invalid comparison between F4 and O
			//IL_0266: Expected F4, but got I
			//IL_0d99: Expected O, but got I
			//IL_0ff1: Expected O, but got Ref
			//IL_1016: Invalid comparison between I and F4
			//IL_06a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ae: Expected O, but got Unknown
			//IL_065a: Expected O, but got I
			//IL_0e7a: Expected O, but got Ref
			//IL_0706: Expected O, but got Ref
			//IL_0714: Expected O, but got Ref
			//IL_0f23: Expected O, but got Ref
			//IL_0fa8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0fad: Expected O, but got Unknown
			//IL_0d77->IL096b: Incompatible stack heights: 1 vs 0
			//IL_059c->IL096b: Incompatible stack heights: 1 vs 0
			//IL_06df->IL096b: Incompatible stack heights: 1 vs 0
			//IL_0605->IL096b: Incompatible stack heights: 2 vs 0
			//IL_0e3d->IL096b: Incompatible stack heights: 2 vs 0
			//IL_06bb->IL0dc1: Incompatible stack heights: 2 vs 1
			//IL_0676->IL096b: Incompatible stack heights: 2 vs 0
			//IL_0649->IL0fe3: Incompatible stack heights: 3 vs 2
			//IL_0767->IL096b: Incompatible stack heights: 3 vs 0
			//IL_07a0->IL096b: Incompatible stack heights: 3 vs 0
			//IL_0ee6->IL096b: Incompatible stack heights: 4 vs 0
			//IL_0f69->IL096b: Incompatible stack heights: 5 vs 0
			//IL_082c->IL096b: Incompatible stack heights: 5 vs 0
			//IL_08e2->IL0fba: Incompatible stack heights: 5 vs 0
			//IL_08a1->IL096b: Incompatible stack heights: 6 vs 0
			//IL_0fba->IL0831: Incompatible stack heights: 7 vs 5
			object obj2 = default(object);
			object obj = (object)(&obj2);
			Component component = _003C_003E4__this;
			_ = 0;
			bool flag = _003C_003E1__state == 0;
			object obj12 = default(object);
			Transform transform3;
			object obj8;
			Transform transform2;
			if (!flag)
			{
				object obj3 = _003C_003E1__state - 1;
				if (!flag)
				{
					object obj4 = obj3 - 1;
					if (!flag)
					{
						if ((nint)obj4 != 1)
						{
							goto IL_0142;
						}
						_003C_003E1__state = -1;
						if ((object)_003Cexplosion_003E5__4 != null)
						{
							GameObject gameObject = _003Cexplosion_003E5__4.gameObject;
							UnityEngine.Object.Destroy(gameObject);
							UnityEngine.Object.Destroy(_003Cfireball_003E5__2);
							if ((object)_003C_003E4__this != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r15_v1 (UnityEngine.Component)+38]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r15_v1 (UnityEngine.Component)+38]");
								bool flag3;
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rbx_v26+10]");
									bool flag2 = (nint)0 == 0;
									flag3 = flag2;
								}
								else
								{
									flag3 = true;
								}
								object obj6 = lastFireball & flag3;
								if (obj6 != null)
								{
									_003C_003E4__this.FireballSequence();
								}
								goto IL_0142;
							}
						}
					}
					else
					{
						_003C_003E1__state = -1;
						if ((object)_003C_003E4__this != null)
						{
							goto IL_09c8;
						}
					}
				}
				else
				{
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null)
					{
						Transform transform = _003C_003E4__this.transform;
						if ((object)transform != null)
						{
							_ = 0;
							_ = 0;
							if (((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
							{
								object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
								Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj7);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
								obj8 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-51]");
								transform2 = (Transform)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r15_v1 (UnityEngine.Component)+60]");
								if ((nint)0 != 0)
								{
									Vector2 insideUnitCircle = UnityEngine.Random.insideUnitCircle;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6B]");
									nint num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r15_v1 (UnityEngine.Component)+70]");
									object obj9 = num * 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r15_v1 (UnityEngine.Component)+64]");
									_ = 0;
									nint num2 = (nint)typeof(Vector3);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1371 @ rcx_v147 (Il2CppClass<UnityEngine.Vector3>)+B8]");
									nint num3 = 0;
									_ = Vector3.upVector;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
									object obj10 = 0 - Vector3.upVector;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-45]");
									object obj11 = 0 - obj12;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r15_v1 (UnityEngine.Component)+6C]");
									nint num4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1372 @ rax_v178 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
									object obj13 = num4 - 0;
									object obj14 = obj11 * obj11;
									object obj15 = obj10 * obj10;
									object obj16 = obj13 * obj13;
									object obj17 = obj14 + obj15;
									object obj18 = obj17 + obj16;
									float num10;
									if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj18))
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r15_v1 (UnityEngine.Component)+64]");
										_ = 0;
										nint num5 = (nint)typeof(Vector3);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1604 @ rcx_v152 (Il2CppClass<UnityEngine.Vector3>)+B8]");
										nint num6 = 0;
										_ = Vector3.rightVector;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
										object obj19 = 0 - Vector3.rightVector;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-45]");
										object obj20 = 0 - obj12;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r15_v1 (UnityEngine.Component)+6C]");
										nint num7 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1549 @ rax_v183 (Il2CppStaticFields<UnityEngine.Vector3>)+44]");
										object obj21 = num7 - 0;
										object obj22 = obj20 * obj20;
										object obj23 = obj19 * obj19;
										object obj24 = obj21 * obj21;
										object obj25 = obj22 + obj23;
										obj18 = obj25 + obj24;
										if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj18))
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-51]");
											transform3 = (Transform)(0 + obj9);
											goto IL_0cd6;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r15_v1 (UnityEngine.Component)+64]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1604 @ rcx_v152 (Il2CppClass<UnityEngine.Vector3>)+B8]");
										nint num8 = 0;
										_ = Vector3.forwardVector;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
										object obj26 = 0 - Vector3.forwardVector;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-45]");
										object obj27 = 0 - obj12;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r15_v1 (UnityEngine.Component)+6C]");
										nint num9 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1602 @ rax_v185 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
										object obj28 = num9 - 0;
										object obj29 = obj27 * obj27;
										transform3 = (Transform)(obj26 * obj26);
										object obj30 = obj28 * obj28;
										object obj31 = obj29 + (object)transform3;
										obj18 = obj31 + obj30;
										if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj18))
										{
											goto IL_0fcd;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-51]");
										num10 = 0f;
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-51]");
										num10 = 0f + (float)obj9;
									}
									transform3 = (Transform)num10;
									goto IL_0cd6;
								}
								goto IL_0fcd;
							}
							UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
						}
					}
				}
				goto IL_096b;
			}
			_003C_003E1__state = -1;
			WaitForSeconds waitForSeconds = null;
			waitForSeconds.m_Seconds = waitTime;
			_003C_003E2__current = waitForSeconds;
			_003C_003E1__state = 1;
			return true;
			IL_0cd6:
			obj8 = obj12;
			transform2 = transform3;
			goto IL_0fcd;
			IL_0142:
			return false;
			IL_0fcd:
			_ = 0;
			_ = 0;
			object obj32 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			object obj33 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
			Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)obj33, out *(Quaternion*)obj32);
			object obj34 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			object obj35 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002C10");
			GameObject gameObject2 = default(GameObject);
			_003Cfireball_003E5__2 = gameObject2;
			if ((object)_003Cfireball_003E5__2 != null)
			{
				ParticleSystem component2 = _003Cfireball_003E5__2.GetComponent<ParticleSystem>();
				if ((object)component2 != null)
				{
					component2.Play(withChildren: true);
					_003Ctimer_003E5__3 = 0f;
					goto IL_09c8;
				}
			}
			goto IL_096b;
			IL_0fba:
			return true;
			IL_09c8:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r15_v1 (UnityEngine.Component)+5C]");
			if (0f > _003Ctimer_003E5__3)
			{
				float num11 = _003Ctimer_003E5__3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r15_v1 (UnityEngine.Component)+58]");
				float num12 = num11 / 0f;
				if (!(0f > num12))
				{
					if (num12 > 1f)
					{
						num12 = 1f;
					}
				}
				else
				{
					num12 = 0f;
				}
				if (!(0f > num12))
				{
					if (num12 > 1f)
					{
						num12 = 1f;
					}
				}
				else
				{
					num12 = 0f;
				}
				if ((object)_003Cfireball_003E5__2 != null)
				{
					Transform transform4 = _003Cfireball_003E5__2.transform;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r15_v1 (UnityEngine.Component)+54]");
					nint num13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r15_v1 (UnityEngine.Component)+50]");
					object obj36 = num13 - 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r15_v1 (UnityEngine.Component)+44]");
					_ = 0;
					float num14 = (float)obj36 * num12;
					float num15 = num14;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r15_v1 (UnityEngine.Component)+50]");
					float num16 = num15 + 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r15_v1 (UnityEngine.Component)+4C]");
					float num17 = 0f * num16;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
					object obj37 = default(object);
					float num18 = num17 * (float)obj37;
					if ((object)transform4 != null)
					{
						Vector3 translation = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
						transform4.Translate(translation, Space.World);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
						object obj38 = default(object);
						float num19 = (float)obj38 + _003Ctimer_003E5__3;
						_003C_003E2__current = null;
						_003Ctimer_003E5__3 = num19;
						_003C_003E1__state = 2;
						goto IL_0fba;
					}
				}
			}
			else if ((object)_003Cfireball_003E5__2 != null)
			{
				ParticleSystem component3 = _003Cfireball_003E5__2.GetComponent<ParticleSystem>();
				if ((object)component3 != null)
				{
					bool flag4 = ((UnityEngine.Object)component3).m_CachedPtr == (IntPtr)0;
					ParticleSystem.Stop_Injected(((UnityEngine.Object)component3).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
					if ((object)_003Cfireball_003E5__2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002D00");
						object obj39 = default(object);
						if (obj39 != null)
						{
							bool flag5 = true;
							Transform transform5 = null;
							bool flag6 = true;
							Transform transform6 = null;
							while (true)
							{
								Transform transform7 = transform6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1541 @ rax_v59+18]");
								if ((nint)transform7 >= 0)
								{
									break;
								}
								Transform transform8 = transform5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1541 @ rax_v59+18]");
								bool flag7 = (nint)transform8 >= 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1541 @ rax_v59+20+v226 @ rsi_v22 (UnityEngine.Transform)*8]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1541 @ rax_v59+20+v226 @ rsi_v22 (UnityEngine.Transform)*8]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1541 @ rax_v59+20+v226 @ rsi_v22 (UnityEngine.Transform)*8]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8E8]");
									object obj40 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8E8]");
									if ((nint)0 == 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
										bool flag8 = obj40 == null;
									}
									object obj41 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2375 @ rax_v130 (should have been resolved before IL gen)");
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000180B80958h\"");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r15_v1 (UnityEngine.Component)+5C]");
									if (0f != 1f / 0f)
									{
										goto IL_06a0;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1541 @ rax_v59+20+v226 @ rsi_v22 (UnityEngine.Transform)*8]");
									GameObject gameObject3 = ((Component)0).gameObject;
									if ((object)gameObject3 != null)
									{
										gameObject3.SetActive(value: false);
										flag5 = false;
										flag6 = false;
										goto IL_06a0;
									}
								}
								goto IL_096b;
								IL_06a0:
								transform5 = (Transform)(transform5 + 1);
								transform6 = transform5;
							}
							Transform transform9 = (Transform)(object)_003Cfireball_003E5__2;
							if ((object)_003Cfireball_003E5__2 != null)
							{
								bool flag9 = ((UnityEngine.Object)transform9).m_CachedPtr == (IntPtr)0;
								IntPtr gcHandlePtr = GameObject.get_transform_Injected(((UnityEngine.Object)transform9).m_CachedPtr);
								Transform transform10 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
								if ((object)transform10 != null)
								{
									_ = 0;
									_ = 0;
									bool flag10 = ((UnityEngine.Object)transform10).m_CachedPtr == (IntPtr)0;
									object obj42 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
									Transform.get_position_Injected(((UnityEngine.Object)transform10).m_CachedPtr, out *(Vector3*)obj42);
									object obj43 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
									object obj44 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
									_ = 0;
									_ = Quaternion.identityQuaternion;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-51]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002D40");
									ParticleSystem particleSystem = default(ParticleSystem);
									_003Cexplosion_003E5__4 = particleSystem;
									if ((object)_003Cexplosion_003E5__4 != null)
									{
										_003Cexplosion_003E5__4.Play(withChildren: true);
										Transform transform11 = (Transform)(object)_003Cfireball_003E5__2;
										if ((object)_003Cfireball_003E5__2 != null)
										{
											bool flag11 = ((UnityEngine.Object)transform11).m_CachedPtr == (IntPtr)0;
											IntPtr gcHandlePtr2 = GameObject.get_transform_Injected(((UnityEngine.Object)transform11).m_CachedPtr);
											Transform transform12 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
											if ((object)transform12 != null)
											{
												_ = 0;
												_ = 0;
												bool flag12 = ((UnityEngine.Object)transform12).m_CachedPtr == (IntPtr)0;
												object obj45 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
												Transform.get_position_Injected(((UnityEngine.Object)transform12).m_CachedPtr, out *(Vector3*)obj45);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-51]");
												_ = 0;
												if ((object)_003Cfireball_003E5__2 != null)
												{
													nint num20 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rsi_v27 (Il2CppMethodInfo)+38]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
													}
													MeshRenderer[] componentsInChildren = _003Cfireball_003E5__2.GetComponentsInChildren<MeshRenderer>(includeInactive: false);
													bool flag13 = componentsInChildren == null;
													Transform transform13 = null;
													Transform transform14 = null;
													if (!flag13)
													{
														while ((nint)transform14 < componentsInChildren.Length)
														{
															bool flag14 = (nint)transform13 >= componentsInChildren.Length;
															Transform transform15 = (Transform)(object)componentsInChildren[(object)transform13];
															if ((object)componentsInChildren[(object)transform13] != null)
															{
																bool flag15 = ((UnityEngine.Object)transform15).m_CachedPtr == (IntPtr)0;
																Renderer.set_enabled_Injected(((UnityEngine.Object)transform15).m_CachedPtr, false);
																transform13 = (Transform)(transform13 + 1);
																transform14 = transform13;
																continue;
															}
															goto IL_096b;
														}
														WaitForSeconds waitForSeconds2 = null;
														waitForSeconds2.m_Seconds = 1.5f;
														_003C_003E2__current = waitForSeconds2;
														_003C_003E1__state = 3;
														goto IL_0fba;
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
			goto IL_096b;
			IL_096b:
			throw new NullReferenceException();
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CSpawnUppercut_003Ed__17(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public float waitTime;

		public FireballSpawner _003C_003E4__this;

		private ParticleSystem _003CuppercutFX_003E5__2;

		private GameObject _003CfireballUppercutFX_003E5__3;

		private float _003Ctimer_003E5__4;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0310: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_0066: Expected I4, but got I8
			//IL_0052: Expected I4, but got I8
			//IL_01b8: Invalid comparison between I4 and F4
			//IL_0203: Expected F4, but got I4
			//IL_03ee: Invalid comparison between I4 and F4
			//IL_046c: Expected O, but got F4
			//IL_0253: Expected O, but got Ref
			//IL_042d: Expected O, but got F4
			//IL_02f3->IL02f3: Incompatible stack heights: 2 vs 0
			//IL_017e->IL0375: Incompatible stack heights: 7 vs 0
			//IL_0271->IL045e: Incompatible stack heights: 3 vs 0
			FireballSpawner fireballSpawner = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				Vector3 ret = default(Vector3);
				if (!flag)
				{
					if ((nint)obj != 1)
					{
						goto IL_02f3;
					}
					_003C_003E1__state = -1;
				}
				else
				{
					_003C_003E1__state = -1;
					bool flag2 = (object)_003C_003E4__this == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002D40");
					ParticleSystem particleSystem = default(ParticleSystem);
					_003CuppercutFX_003E5__2 = particleSystem;
					bool flag3 = (object)_003CuppercutFX_003E5__2 == null;
					_003CuppercutFX_003E5__2.Play(withChildren: true);
					bool flag4 = (object)fireballSpawner.UpperCutFireballPrefab == null;
					Transform transform = fireballSpawner.UpperCutFireballPrefab.transform;
					bool flag5 = (object)transform == null;
					bool flag6 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Quaternion*)(&ret));
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002C10");
					GameObject gameObject = default(GameObject);
					_003CfireballUppercutFX_003E5__3 = gameObject;
					bool flag7 = (object)_003CfireballUppercutFX_003E5__3 == null;
					ParticleSystem component = _003CfireballUppercutFX_003E5__3.GetComponent<ParticleSystem>();
					bool flag8 = (object)component == null;
					component.Play(withChildren: true);
					_003Ctimer_003E5__4 = 0f;
				}
				if (2f > _003Ctimer_003E5__4)
				{
					bool flag9 = (object)_003C_003E4__this == null;
					float num = _003Ctimer_003E5__4 / fireballSpawner.speedChangeDuration;
					if (!(0f > num))
					{
						if (num > 1f)
						{
							num = 1f;
						}
					}
					else
					{
						num = 0f;
					}
					if (0f > num || num > 1f)
					{
					}
					bool flag10 = (object)_003CfireballUppercutFX_003E5__3 == null;
					Transform transform2 = _003CfireballUppercutFX_003E5__3.transform;
					object obj2 = Time.deltaTime;
					bool flag11 = (object)transform2 == null;
					transform2.Translate((Vector3)(&ret), Space.World);
					object obj3 = Time.deltaTime;
					object obj4 = default(object);
					float num2 = (float)obj4 + _003Ctimer_003E5__4;
					_003C_003E2__current = null;
					_003Ctimer_003E5__4 = num2;
					_003C_003E1__state = 2;
					return true;
				}
				bool flag12 = (object)_003CuppercutFX_003E5__2 == null;
				GameObject gameObject2 = _003CuppercutFX_003E5__2.gameObject;
				UnityEngine.Object.Destroy(gameObject2, 0f);
				UnityEngine.Object.Destroy(_003CfireballUppercutFX_003E5__3, 0f);
				bool flag13 = (object)_003C_003E4__this == null;
				_003C_003E4__this.FireballSequence();
				goto IL_02f3;
			}
			_003C_003E1__state = -1;
			WaitForSeconds waitForSeconds = null;
			waitForSeconds.m_Seconds = waitTime;
			_003C_003E2__current = waitForSeconds;
			_003C_003E1__state = 1;
			return true;
			IL_02f3:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	public GameObject fireballPrefab;

	public ParticleSystem explosionEffect;

	public ParticleSystem UpperCutPrefab;

	public GameObject UpperCutFireballPrefab;

	public float WaitTime;

	public Vector3 movementAxis;

	public float startSpeed;

	public float endSpeed;

	public float speedChangeDuration;

	public float moveDuration;

	public bool spawnInCircleArea;

	public Vector3 circleAxis;

	public float circleRadius;

	private Vector3 endPosition;

	private void Start()
	{
		FireballSequence();
	}

	private void FireballSequence()
	{
		IEnumerator routine = SpawnFireball(0f);
		Coroutine coroutine = StartCoroutine(routine);
		IEnumerator routine2 = SpawnFireball(WaitTime);
		Coroutine coroutine2 = StartCoroutine(routine2);
		float waitTime = WaitTime + WaitTime;
		IEnumerator routine3 = SpawnFireball(waitTime);
		Coroutine coroutine3 = StartCoroutine(routine3);
		float waitTime2 = WaitTime * 3f;
		IEnumerator routine4 = SpawnFireball(waitTime2, lastFireball: true);
		Coroutine coroutine4 = StartCoroutine(routine4);
		GameObject upperCutFireballPrefab = UpperCutFireballPrefab;
		if ((object)UpperCutFireballPrefab != null && ((UnityEngine.Object)upperCutFireballPrefab).m_CachedPtr != (IntPtr)0)
		{
			float waitTime3 = WaitTime * 4f;
			_003CSpawnUppercut_003Ed__17 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			obj.waitTime = waitTime3;
			Coroutine coroutine5 = StartCoroutine(obj);
		}
	}

	private IEnumerator SpawnFireball(float waitTime, bool lastFireball = false)
	{
		_003CSpawnFireball_003Ed__16 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.waitTime = waitTime;
		obj.lastFireball = lastFireball;
		return obj;
	}

	private IEnumerator SpawnUppercut(float waitTime)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002e: Expected O, but got I8
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_010a: Expected O, but got I4
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		_003CSpawnUppercut_003Ed__17 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		if (!flag)
		{
			object obj2 = obj + 40;
			object obj3 = obj2 >> 12;
			object obj4 = 6603864928L;
			object obj5 = obj3 & 0x1FFFFF;
			object obj6 = obj5 >> 6;
			object obj7 = obj5 & 0x3F;
			nint num2;
			do
			{
				object obj8 = 1 << (int)obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				object obj9 = 0 | obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				if (num == 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
			}
			while (num2 != 0);
			obj.waitTime = waitTime;
			return obj;
		}
		obj.waitTime = waitTime;
		return obj;
	}

	private unsafe void OnDrawGizmos()
	{
		//IL_0008: Expected O, but got Ref
		//IL_011e: Expected O, but got Ref
		//IL_05b3: Expected I, but got O
		//IL_0603: Expected O, but got I
		//IL_0047: Expected I, but got O
		//IL_017c: Expected O, but got I
		//IL_0230: Expected O, but got I
		//IL_045b: Expected O, but got Ref
		//IL_0469: Expected O, but got Ref
		//IL_0477: Expected O, but got Ref
		//IL_0485: Expected O, but got Ref
		//IL_0563: Expected I, but got O
		//IL_07ed: Expected O, but got Ref
		//IL_0827: Expected O, but got Ref
		//IL_0351: Expected O, but got Ref
		//IL_035f: Expected O, but got Ref
		//IL_037b: Expected O, but got Ref
		//IL_0785: Expected O, but got Ref
		//IL_0676: Expected O, but got Ref
		//IL_0692: Expected O, but got Ref
		//IL_0519: Expected O, but got I
		//IL_03d7: Expected I, but got O
		//IL_040d: Expected O, but got I
		//IL_02dc: Expected O, but got Ref
		//IL_07a1: Expected O, but got Ref
		//IL_06ee: Expected I, but got O
		//IL_0724: Expected O, but got I
		//IL_02f8: Expected O, but got Ref
		//IL_0301: Expected F4, but got I4
		//IL_0309: Expected O, but got Ref
		//IL_0418->IL0793: Incompatible stack heights: 1 vs 3
		//IL_073e->IL0663: Incompatible stack heights: 3 vs 0
		//IL_0108->IL0108: Incompatible stack heights: 4 vs 0
		//IL_030e->IL072f: Incompatible stack heights: 0 vs 3
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (!spawnInCircleArea)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
		_ = 0;
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 55));
		Gizmos.set_color_Injected(ref *(Color*)obj3);
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rcx_v54 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		_ = Vector3.upVector;
		object obj4 = circleAxis - Vector3.upVector;
		object obj6 = default(object);
		object obj7 = default(object);
		object obj5 = obj6 - obj7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (FireballSpawner)+6C]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rax_v56 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		object obj8 = num3 - 0;
		object obj9 = obj5 * obj5;
		object obj10 = obj4 * obj4;
		object obj11 = obj8 * obj8;
		object obj12 = obj9 + obj10;
		float num4 = (float)obj12 + (float)obj11;
		Vector3 s = default(Vector3);
		object obj30;
		if (!(9.9999994E-11f > num4))
		{
			nint num5 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rcx_v108 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num6 = 0;
			_ = Vector3.rightVector;
			object obj13 = circleAxis - Vector3.rightVector;
			object obj14 = obj6 - obj7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (FireballSpawner)+6C]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rax_v103 (Il2CppStaticFields<UnityEngine.Vector3>)+44]");
			object obj15 = num7 - 0;
			object obj16 = obj14 * obj14;
			float num8 = (float)obj13 * (float)obj13;
			object obj17 = obj15 * obj15;
			float num9 = (float)obj16 + num8;
			num4 = num9 + (float)obj17;
			if (9.9999994E-11f > num4)
			{
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out s);
					_ = 0;
					_ = 1f;
					_ = Quaternion.identityQuaternion;
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 0;
					object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
					object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
					nint num10 = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
					Matrix4x4.TRS_Injected(ref *(Vector3*)obj20, ref *(Quaternion*)num10, ref *(Vector3*)obj19, out *(Matrix4x4*)obj18);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-59]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
					_ = 0;
					object obj21 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					Gizmos.set_matrix_Injected(ref *(Matrix4x4*)obj21);
					nint num11 = (nint)typeof(Vector3);
					float num12 = circleRadius;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1676 @ rax_v120 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num13 = 0;
					Vector3 zeroVector = Vector3.zeroVector;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1678 @ rax_v121 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
					_ = 0;
					object obj22 = 0;
					_ = Vector3.zeroVector;
					goto IL_0793;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rcx_v108 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num14 = 0;
				_ = Vector3.forwardVector;
				object obj23 = circleAxis - Vector3.forwardVector;
				object obj24 = obj6 - obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (FireballSpawner)+6C]");
				nint num15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ rax_v132 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
				object obj25 = num15 - 0;
				object obj26 = obj24 * obj24;
				float num16 = (float)obj23 * (float)obj23;
				object obj27 = obj25 * obj25;
				float num17 = (float)obj26 + num16;
				num4 = num17 + (float)obj27;
				if (!(9.9999994E-11f > num4))
				{
					goto IL_0555;
				}
				Transform transform2 = base.transform;
				if ((object)transform2 != null)
				{
					Vector3 position = transform2.position;
					_ = position.x;
					_ = position.z;
					_ = Quaternion.identityQuaternion;
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 0;
					object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
					nint num10 = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					object obj28 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
					Matrix4x4.TRS_Injected(ref *(Vector3*)obj28, ref *(Quaternion*)num10, ref s, out *(Matrix4x4*)obj18);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-59]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
					_ = 0;
					object obj29 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					Gizmos.set_matrix_Injected(ref *(Matrix4x4*)obj29);
					nint num18 = (nint)typeof(Vector3);
					float num12 = circleRadius;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1602 @ rax_v144 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num19 = 0;
					Vector3 zeroVector = Vector3.zeroVector;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1603 @ rax_v145 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
					_ = 0;
					object obj22 = 0;
					_ = Vector3.zeroVector;
					obj30 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
					num8 = 0f;
					object obj19 = (object)(&s);
					goto IL_072f;
				}
			}
		}
		else
		{
			Transform transform3 = base.transform;
			if ((object)transform3 != null)
			{
				bool flag2 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out s);
				_ = 1f;
				_ = 0;
				_ = Quaternion.identityQuaternion;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
				object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
				object obj31 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				object obj32 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
				Matrix4x4.TRS_Injected(ref *(Vector3*)obj32, ref *(Quaternion*)obj31, ref *(Vector3*)obj19, out *(Matrix4x4*)obj18);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-59]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
				_ = 0;
				object obj33 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				Gizmos.set_matrix_Injected(ref *(Matrix4x4*)obj33);
				Transform transform4 = base.transform;
				bool flag3 = (object)transform4 == null;
				bool flag4 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out s);
				float num12 = circleRadius;
				_ = 0;
				object obj22 = 0;
				bool flag5 = (nint)0 != 0;
				float num8 = 1f;
				nint num10 = (nint)(&s);
				Vector3 zeroVector = s;
				if (flag5)
				{
					goto IL_0793;
				}
				bool flag6 = (nint)0 == 0;
			}
		}
		throw new NullReferenceException();
		IL_0555:
		nint num20 = (nint)typeof(Matrix4x4);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v697 @ rax_v62 (Il2CppClass<UnityEngine.Matrix4x4>)+B8]");
		nint num21 = 0;
		_ = Matrix4x4.identityMatrix;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ rcx_v60 (Il2CppStaticFields<UnityEngine.Matrix4x4>)+50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ rcx_v60 (Il2CppStaticFields<UnityEngine.Matrix4x4>)+60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ rcx_v60 (Il2CppStaticFields<UnityEngine.Matrix4x4>)+70]");
		_ = 0;
		object obj34 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		Gizmos.set_matrix_Injected(ref *(Matrix4x4*)obj34);
		return;
		IL_0793:
		obj30 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		goto IL_072f;
		IL_072f:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1844 @ rax_v58 (should have been resolved before IL gen)");
		goto IL_0555;
	}

	public FireballSpawner()
	{
		//IL_0020: Expected I, but got O
		//IL_00bd: Expected I, but got O
		//IL_0087: Expected I, but got O
		WaitTime = 0.5f;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		movementAxis = Vector3.rightVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v1 (Il2CppStaticFields<UnityEngine.Vector3>)+44]");
		_ = 0;
		startSpeed = 2f;
		endSpeed = 10f;
		speedChangeDuration = 3f;
		moveDuration = 5f;
		nint num3 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v5 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num4 = 0;
		circleAxis = Vector3.forwardVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
		_ = 0;
		circleRadius = 5f;
		nint num5 = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v5 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
