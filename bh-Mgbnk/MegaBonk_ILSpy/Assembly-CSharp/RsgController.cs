using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Cpp2ILInjected;
using Unity.AI.Navigation;
using UnityEngine;

public class RsgController : MonoBehaviour
{
	public enum EDungeonType
	{
		Normal,
		BossDungeon
	}

	private sealed class _003CGenerateMap_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RsgController _003C_003E4__this;

		private Stopwatch _003Ctimer_003E5__2;

		private float _003ClowestCordsHeight_003E5__3;

		private int _003CmaxPieces_003E5__4;

		private int _003CnumPieces_003E5__5;

		private int _003Ccollisions_003E5__6;

		private int _003CmaxCollisions_003E5__7;

		private int _003ClookAhead_003E5__8;

		private RsgPiece _003Cprevious_003E5__9;

		private RsgPiece _003CpieceBeforeLookahead_003E5__10;

		private List<RsgPiece> _003ClookaheadPieces_003E5__11;

		private int _003Cj_003E5__12;

		private int _003Ck_003E5__13;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CGenerateMap_003Ed__41(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_1ed2: Expected O, but got I4
			//IL_00e8: Expected I4, but got I8
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			//IL_00bd: Expected I4, but got I8
			//IL_00c6: Expected F4, but got I4
			//IL_00cf: Expected O, but got I4
			//IL_0092: Expected I4, but got I8
			//IL_009b: Expected F4, but got I4
			//IL_00a4: Expected O, but got I4
			//IL_0499: Expected O, but got I4
			//IL_0271: Expected I, but got O
			//IL_13ae: Expected O, but got F4
			//IL_201a: Expected O, but got F4
			//IL_04fb: Expected I, but got O
			//IL_1412: Unknown result type (might be due to invalid IL or missing references)
			//IL_1417: Expected O, but got Unknown
			//IL_1464: Unknown result type (might be due to invalid IL or missing references)
			//IL_1469: Expected O, but got Unknown
			//IL_12f8: Invalid comparison between F4 and O
			//IL_02a0: Expected I, but got O
			//IL_02b0: Expected O, but got I
			//IL_0820: Expected I, but got O
			//IL_08e1: Expected I, but got O
			//IL_08fd: Expected O, but got F4
			//IL_14b6: Expected O, but got I
			//IL_073c: Expected I, but got O
			//IL_2355: Unknown result type (might be due to invalid IL or missing references)
			//IL_235a: Expected O, but got Unknown
			//IL_037c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0381: Expected O, but got Unknown
			//IL_038a: Expected O, but got I4
			//IL_0b75: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b7a: Expected I4, but got Unknown
			//IL_208c: Unknown result type (might be due to invalid IL or missing references)
			//IL_2091: Expected O, but got Unknown
			//IL_20ea: Expected F4, but got I
			//IL_20fa: Expected F4, but got I
			//IL_08bb: Expected O, but got Ref
			//IL_08ca: Expected O, but got I8
			//IL_08cf: Expected I, but got O
			//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d1: Expected O, but got Unknown
			//IL_0957: Expected O, but got Ref
			//IL_03e0: Expected I4, but got O
			//IL_03e8: Expected I, but got O
			//IL_03f9: Expected O, but got I4
			//IL_0bd3: Expected F4, but got I
			//IL_0be3: Expected F4, but got I
			//IL_0bf0: Expected F4, but got O
			//IL_0bfd: Expected F4, but got O
			//IL_0c06: Expected F4, but got O
			//IL_098c: Expected O, but got Ref
			//IL_0d30: Expected O, but got Ref
			//IL_0437: Invalid comparison between F4 and O
			//IL_0d74: Expected O, but got Ref
			//IL_0c7d: Expected O, but got I
			//IL_0ca0: Expected O, but got Ref
			//IL_1c97: Expected F4, but got O
			//IL_0ce6: Expected O, but got I
			//IL_1bf4: Unknown result type (might be due to invalid IL or missing references)
			//IL_1bf9: Expected O, but got Unknown
			//IL_10f0: Expected O, but got Ref
			//IL_1cdf: Expected O, but got Ref
			//IL_0e4d: Expected O, but got Ref
			//IL_188a: Expected O, but got Ref
			//IL_11cc: Expected O, but got Ref
			//IL_1d7f: Expected I, but got O
			//IL_2171: Expected I, but got O
			//IL_22b3: Invalid comparison between F4 and I4
			//IL_18b5: Expected F8, but got I
			//IL_18d8: Expected O, but got I
			//IL_18f7: Expected O, but got Ref
			//IL_1202: Unknown result type (might be due to invalid IL or missing references)
			//IL_1207: Expected O, but got Unknown
			//IL_1239: Expected O, but got F4
			//IL_123e: Expected I, but got O
			//IL_255d: Expected I, but got O
			//IL_1915: Expected O, but got I
			//IL_12ab: Expected O, but got F4
			//IL_12b0: Expected I, but got O
			//IL_1988: Expected O, but got I
			//IL_1953: Expected O, but got Ref
			//IL_19d2: Expected O, but got I
			//IL_19e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_19e7: Expected O, but got Unknown
			//IL_0fcd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0fd2: Expected O, but got Unknown
			//IL_0eff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f04: Expected O, but got Unknown
			//IL_107a: Expected O, but got Ref
			//IL_10b9: Expected I, but got O
			//IL_10c2: Expected O, but got I4
			RsgController rsgController = _003C_003E4__this;
			GameObject gameObject = (GameObject)_003C_003E1__state;
			bool flag = _003C_003E1__state == 0;
			bool result;
			float num;
			object obj;
			List<RsgPiece> list;
			float num2;
			if (!flag)
			{
				gameObject = (GameObject)(gameObject - 1);
				if (!flag)
				{
					bool flag2 = (nint)gameObject != 1;
					result = false;
					if (!flag2)
					{
						_003C_003E1__state = -1;
						num = 0f;
						obj = 0;
						list = null;
						goto IL_130c;
					}
					goto IL_1ef1;
				}
				_003C_003E1__state = -1;
				num2 = 0f;
				obj = 0;
				list = null;
				goto IL_044b;
			}
			_003C_003E1__state = -1;
			RsgPiece rsgPiece;
			nint num6;
			RsgPiece prefabs2;
			Vector3 vector;
			if ((object)_003C_003E4__this != null)
			{
				GameObject[] prefabs = rsgController.prefabs;
				if (rsgController.prefabs != null)
				{
					bool flag3 = false;
					bool flag4 = false;
					while ((flag4 ? 1 : 0) < prefabs.Length)
					{
						bool flag5 = (flag3 ? 1 : 0) >= prefabs.Length;
						Component component = (Component)(object)gameObject;
						if (!flag5)
						{
							gameObject = prefabs[flag3 ? 1u : 0u];
							if ((object)prefabs[flag3 ? 1u : 0u] != null)
							{
								prefabs[flag3 ? 1u : 0u].SetActive(value: true);
								flag3 = (byte)((flag3 ? 1u : 0u) + 1u) != 0;
								flag4 = flag3;
								continue;
							}
							goto IL_1ef6;
						}
						goto IL_1f01;
					}
					gameObject = rsgController.roomStart;
					if ((object)rsgController.roomStart != null)
					{
						rsgController.roomStart.SetActive(value: true);
						gameObject = rsgController.roomEnd;
						if ((object)rsgController.roomEnd != null)
						{
							rsgController.roomEnd.SetActive(value: true);
							nint num3 = (nint)typeof(RsgController);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2315 @ rcx_v186 (Il2CppClass<RsgController>)+B8]");
							int num4 = (int)((nint)0 + (nint)8);
							string text = ((int*)num4)->ToString();
							string text2 = "crypt seed: " + text;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
							Stopwatch stopwatch = Stopwatch.StartNew();
							_003Ctimer_003E5__2 = stopwatch;
							gameObject = (GameObject)(object)random;
							if (random != null)
							{
								nint num5 = (nint)gameObject;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2729 @ rax_v269 (Il2CppClass<UnityEngine.GameObject>)+1A0]");
								rsgPiece = (RsgPiece)0;
								num6 = rsgController.maxPieces;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2729 @ rax_v269 (Il2CppClass<UnityEngine.GameObject>)+198] (should have been resolved before IL gen)");
								int mapLength = default(int);
								rsgController.mapLength = mapLength;
								List<Bounds> bounds = new List<Bounds>();
								rsgController.bounds = bounds;
								List<RsgPiece> allPieces = new List<RsgPiece>();
								rsgController.allPieces = allPieces;
								_003ClowestCordsHeight_003E5__3 = 3.4028235E+38f;
								int num7 = rsgController.mapLength + 2;
								_003CmaxPieces_003E5__4 = num7;
								_003CnumPieces_003E5__5 = 0;
								_003CmaxCollisions_003E5__7 = 5;
								rsgController.totalTraversalTime = 0f;
								_003ClookAhead_003E5__8 = 2;
								_003Cprevious_003E5__9 = null;
								_003CpieceBeforeLookahead_003E5__10 = null;
								gameObject = (GameObject)(this + 80);
								vector = (Vector3)0;
								prefabs2 = (RsgPiece)(object)rsgController.prefabs;
								list = null;
								goto IL_2562;
							}
						}
					}
				}
			}
			goto IL_1ef6;
			IL_1ef1:
			return result;
			IL_20ff:
			Transform transform = prefabs2.transform;
			bool flag6 = (object)transform == null;
			gameObject = (GameObject)(object)prefabs2;
			Vector3 vector2 = default(Vector3);
			float num8 = default(float);
			float num9;
			float num10;
			float num11;
			float num12;
			float num13;
			float num14;
			Vector3 forward;
			Vector3 forward2;
			double num35;
			double num38;
			nint num15 = default(nint);
			if (!flag6)
			{
				transform.rotation = (Quaternion)(&vector2);
				Transform transform2 = prefabs2.transform;
				bool flag7 = (object)transform2 == null;
				gameObject = (GameObject)(object)prefabs2;
				if (!flag7)
				{
					transform2.position = (Vector3)(&num8);
					bool flag8 = _003Cprevious_003E5__9 != null;
					bool flag9 = !flag8;
					num9 = num10;
					num11 = num12;
					num13 = num14;
					num15 = 0;
					if (flag9)
					{
						goto IL_2131;
					}
					RsgPiece rsgPiece2 = _003Cprevious_003E5__9;
					bool flag10 = (object)_003Cprevious_003E5__9 == null;
					gameObject = (GameObject)(object)_003Cprevious_003E5__9;
					if (!flag10)
					{
						bool flag11 = (object)rsgPiece2.end == null;
						gameObject = (GameObject)(object)_003Cprevious_003E5__9;
						if (!flag11)
						{
							forward = rsgPiece2.end.forward;
							bool flag12 = (object)prefabs2.start == null;
							object obj2 = default(object);
							gameObject = (GameObject)(&obj2);
							if (!flag12)
							{
								forward2 = prefabs2.start.forward;
								nint num16 = (nint)typeof(Vector3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3363 @ rax_v156 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num17 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
								float num18 = forward2.z * forward.y;
								float num19 = forward2.y * forward.z;
								float num20 = num18 - num19;
								float num21 = num20 * (float)Vector3.upVector;
								float num22 = forward2.x * forward.z;
								float num23 = forward2.z * forward.x;
								float num24 = num22 - num23;
								float num25 = num24;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3364 @ rcx_v125 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
								float num26 = num25 * 0f;
								float num27 = num21 + num26;
								float num28 = forward2.y * forward.x;
								float num29 = forward2.x * forward.y;
								float num30 = num28 - num29;
								float num31 = num30;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3364 @ rcx_v125 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
								float num32 = num31 * 0f;
								float num33 = num27 + num32;
								if (!(num33 < 0f))
								{
								}
								nint num34 = (nint)typeof(Math);
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm6,xmm9\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FD990");
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm6,qword ptr [18262F0B0h]\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3446 @ rcx_v128 (Il2CppClass<System.Math>)+E4]");
								double num37 = default(double);
								if ((nint)0 >= (nint)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000180512EE0h\"");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3446 @ rcx_v128 (Il2CppClass<System.Math>)+E4]");
									double num36;
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm6,xmm1\"");
										num35 = Math.Floor(0.0);
										num36 = 0.5;
										goto IL_1047;
									}
									object obj3 = num37 & 1;
									bool flag13 = obj3 == null;
									num36 = 0.5;
									num38 = num37;
									if (!flag13)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm6,qword ptr [18262EC98h]\"");
										num36 = 0.5;
										num38 = num37;
									}
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [18262ED10h]\"");
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000180512F13h\"");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3446 @ rcx_v128 (Il2CppClass<System.Math>)+E4]");
									double num36;
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm6,qword ptr [18262EC90h]\"");
										num35 = Math.Ceiling(0.0);
										num36 = num26;
										goto IL_1047;
									}
									object obj4 = num37 & 1;
									bool flag14 = obj4 == null;
									num36 = num26;
									num38 = num37;
									if (!flag14)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm6,qword ptr [18262EC98h]\"");
										num36 = num26;
										num38 = num37;
									}
								}
								goto IL_22cc;
							}
						}
					}
				}
			}
			goto IL_1ef6;
			IL_1ef6:
			throw new NullReferenceException();
			IL_0a30:
			prefabs2.SetCollider();
			List<object> list2 = (List<object>)(object)_003ClookaheadPieces_003E5__11;
			bool flag15 = _003ClookaheadPieces_003E5__11 == null;
			gameObject = (GameObject)(object)_003ClookaheadPieces_003E5__11;
			float num40;
			float num41;
			float num42;
			float num43;
			if (!flag15)
			{
				int version = list2._version + 1;
				list2._version = version;
				object[] items = list2._items;
				bool flag16 = list2._items == null;
				gameObject = (GameObject)(object)_003ClookaheadPieces_003E5__11;
				if (!flag16)
				{
					int size = list2._size;
					if (list2._size >= items.Length)
					{
						((List<object>)(object)_003ClookaheadPieces_003E5__11).AddWithResize((object)prefabs2);
					}
					else
					{
						int size2 = list2._size + 1;
						list2._size = size2;
						bool flag17 = list2._size >= items.Length;
						Component component = (Component)(object)_003ClookaheadPieces_003E5__11;
						if (flag17)
						{
							goto IL_1f01;
						}
						items[size] = prefabs2;
					}
					int num39 = this + 56;
					string name = ((int*)num39)->ToString();
					prefabs2.name = name;
					UnityEngine.Object obj5 = _003Cprevious_003E5__9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r14_v1 (RsgController)+A0]");
					num12 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r14_v1 (RsgController)+A4]");
					num10 = 0f;
					bool flag18 = _003Cprevious_003E5__9 != null;
					bool flag19 = !flag18;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r14_v1 (RsgController)+A4]");
					num40 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r14_v1 (RsgController)+A0]");
					num41 = 0f;
					num42 = (float)rsgController.startPosition;
					num14 = (float)rsgController.startPosition;
					num43 = (float)Quaternion.identityQuaternion;
					if (flag19)
					{
						goto IL_20ff;
					}
					bool flag20 = (object)_003Cprevious_003E5__9 == null;
					gameObject = (GameObject)(object)_003Cprevious_003E5__9;
					if (!flag20)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rbx_v33 (UnityEngine.Object)+30]");
						bool flag21 = (nint)0 == 0;
						gameObject = (GameObject)(object)_003Cprevious_003E5__9;
						if (!flag21)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rbx_v33 (UnityEngine.Object)+30]");
							Vector3 position = ((Transform)0).position;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rbx_v33 (UnityEngine.Object)+30]");
							bool flag22 = (nint)0 == 0;
							object obj6 = default(object);
							gameObject = (GameObject)(&obj6);
							if (!flag22)
							{
								num14 = position.x;
								num12 = position.y;
								num10 = position.z;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rbx_v33 (UnityEngine.Object)+30]");
								num43 = ((Transform)0).rotation.x;
								num40 = position.z;
								num41 = position.y;
								num42 = position.x;
								goto IL_20ff;
							}
						}
					}
				}
			}
			goto IL_1ef6;
			IL_146e:
			List<RsgPiece> list3 = _003ClookaheadPieces_003E5__11;
			nint num44;
			if (_003ClookaheadPieces_003E5__11 != null)
			{
				bool flag23 = list3._size <= 0;
				rsgPiece = (RsgPiece)num15;
				num6 = num44;
				if (flag23)
				{
					goto IL_2345;
				}
				RsgPiece rsgPiece3 = _003ClookaheadPieces_003E5__11.get_Item(0);
				bool flag24 = (object)rsgPiece3 == null;
				gameObject = (GameObject)(object)_003ClookaheadPieces_003E5__11;
				if (!flag24)
				{
					float lowestCordY = rsgPiece3.GetLowestCordY();
					bool flag25 = !(_003ClowestCordsHeight_003E5__3 > lowestCordY);
					gameObject = (GameObject)(object)rsgPiece3;
					if (flag25)
					{
						goto IL_235f;
					}
					bool flag26 = _003ClookaheadPieces_003E5__11 == null;
					gameObject = (GameObject)(object)_003ClookaheadPieces_003E5__11;
					if (!flag26)
					{
						RsgPiece rsgPiece4 = _003ClookaheadPieces_003E5__11.get_Item(0);
						bool flag27 = (object)rsgPiece4 == null;
						gameObject = (GameObject)(object)_003ClookaheadPieces_003E5__11;
						if (!flag27)
						{
							float lowestCordY2 = rsgPiece4.GetLowestCordY();
							_003ClowestCordsHeight_003E5__3 = lowestCordY2;
							gameObject = (GameObject)(object)rsgPiece4;
							goto IL_235f;
						}
					}
				}
			}
			goto IL_1ef6;
			IL_2303:
			if (_003Cj_003E5__12 >= _003ClookAhead_003E5__8)
			{
				goto IL_146e;
			}
			if ((object)_003C_003E4__this == null)
			{
				goto IL_1ef6;
			}
			num2 = rsgController.generationDelay;
			float generationDelay = rsgController.generationDelay;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)generationDelay) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				goto IL_044b;
			}
			WaitForSeconds waitForSeconds = new WaitForSeconds(rsgController.generationDelay);
			_003C_003E2__current = waitForSeconds;
			_003C_003E1__state = 1;
			goto IL_23e4;
			IL_044b:
			if (_003CnumPieces_003E5__5 != 0)
			{
				if ((object)_003C_003E4__this != null)
				{
					object obj7 = _003CmaxPieces_003E5__4 - 1;
					if (_003CnumPieces_003E5__5 < (nint)obj7)
					{
						GameObject[] prefabs3 = rsgController.prefabs;
						GameObject[] prefabs4 = rsgController.prefabs;
						if (rsgController.prefabs != null)
						{
							gameObject = (GameObject)(object)random;
							if (random != null)
							{
								nint num45 = (nint)gameObject;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2296 @ rax_v246 (Il2CppClass<UnityEngine.GameObject>)+1A0]");
								num15 = 0;
								num44 = prefabs4.Length;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2296 @ rax_v246 (Il2CppClass<UnityEngine.GameObject>)+198] (should have been resolved before IL gen)");
								if (rsgController.prefabs != null)
								{
									object obj8 = default(object);
									bool flag28 = (nint)obj8 >= prefabs3.Length;
									Component component = (Component)(object)random;
									if (flag28)
									{
										goto IL_1f01;
									}
									GameObject gameObject2 = UnityEngine.Object.Instantiate(prefabs3[obj8]);
									bool flag29 = (object)gameObject2 == null;
									gameObject = prefabs3[obj8];
									if (!flag29)
									{
										RsgPiece component2 = gameObject2.GetComponent<RsgPiece>();
										bool flag30 = (object)component2 == null;
										gameObject = gameObject2;
										if (!flag30)
										{
											prefabs2 = component2;
											goto IL_1fa5;
										}
									}
								}
							}
						}
					}
					else
					{
						GameObject gameObject3 = UnityEngine.Object.Instantiate(rsgController.roomEnd);
						bool flag31 = (object)gameObject3 == null;
						gameObject = rsgController.roomEnd;
						if (!flag31)
						{
							RsgPiece component3 = gameObject3.GetComponent<RsgPiece>();
							bool flag32 = (object)component3 == null;
							gameObject = gameObject3;
							if (!flag32)
							{
								InteractableCryptLeave componentInChildren = component3.GetComponentInChildren<InteractableCryptLeave>();
								rsgController._003CrsgEnd_003Ek__BackingField = componentInChildren;
								gameObject = (GameObject)(object)rsgController._003CrsgEnd_003Ek__BackingField;
								if ((object)rsgController._003CrsgEnd_003Ek__BackingField != null)
								{
									_ = rsgController.dungeonType;
									bool flag33 = (object)rsgController._003CrsgEnd_003Ek__BackingField == null;
									gameObject = (GameObject)(object)rsgController._003CrsgEnd_003Ek__BackingField;
									if (!flag33)
									{
										GameObject gameObject4 = rsgController._003CrsgEnd_003Ek__BackingField.gameObject;
										bool flag34 = (object)gameObject4 == null;
										gameObject = (GameObject)(object)rsgController._003CrsgEnd_003Ek__BackingField;
										if (!flag34)
										{
											gameObject4.SetActive(value: true);
											num44 = unchecked((nint)null);
											prefabs2 = component3;
											goto IL_0802;
										}
									}
								}
							}
						}
					}
				}
			}
			else if ((object)_003C_003E4__this != null)
			{
				GameObject gameObject5 = UnityEngine.Object.Instantiate(rsgController.roomStart);
				bool flag35 = (object)gameObject5 == null;
				gameObject = rsgController.roomStart;
				if (!flag35)
				{
					RsgPiece component4 = gameObject5.GetComponent<RsgPiece>();
					bool flag36 = (object)component4 == null;
					gameObject = gameObject5;
					if (!flag36)
					{
						RsgStart component5 = component4.GetComponent<RsgStart>();
						rsgController._003CrsgStart_003Ek__BackingField = component5;
						prefabs2 = component4;
						goto IL_0802;
					}
				}
			}
			goto IL_1ef6;
			IL_1047:
			num38 = num35;
			goto IL_22cc;
			IL_1ffe:
			bool flag37 = !prefabs2.reverse;
			vector = (Vector3)num2;
			if (flag37)
			{
				goto IL_0a30;
			}
			gameObject = (GameObject)(object)random;
			bool flag38 = (nint)random < 0;
			float num47;
			if (random != null)
			{
				nint num46 = (nint)gameObject;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2659 @ rax_v188 (Il2CppClass<UnityEngine.GameObject>)+1B8] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm6\"");
				vector = (Vector3)num2;
				if (flag38)
				{
					goto IL_0a30;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172E30]");
				if ((nint)0 == (flag38 ? 1 : 0))
				{
					_ = 1;
				}
				prefabs2.end = prefabs2.start;
				prefabs2.start = prefabs2.end;
				gameObject = (GameObject)(prefabs2 + 40);
				if ((object)prefabs2.end != null)
				{
					Vector3 upVector = default(Vector3);
					prefabs2.end.Rotate((Vector3)(&upVector), 180f);
					gameObject = (GameObject)(object)prefabs2.end;
					if ((object)prefabs2.start != null)
					{
						vector = Vector3.upVector;
						Vector3 upVector2 = default(Vector3);
						prefabs2.start.Rotate((Vector3)(&upVector2), 180f);
						bool flag39 = (object)prefabs2.start == null;
						gameObject = (GameObject)(object)prefabs2.start;
						if (!flag39)
						{
							prefabs2.start.name = "start";
							bool flag40 = (object)prefabs2.end == null;
							gameObject = (GameObject)(object)prefabs2.end;
							if (!flag40)
							{
								prefabs2.end.name = "end";
								upVector2 = Vector3.upVector;
								num47 = 180f;
								upVector = Vector3.upVector;
								goto IL_0a30;
							}
						}
					}
				}
			}
			goto IL_1ef6;
			IL_2131:
			Transform transform3 = prefabs2.transform;
			bool flag41 = (object)transform3 == null;
			gameObject = (GameObject)(object)prefabs2;
			if (!flag41)
			{
				Vector3 position2 = transform3.position;
				bool flag42 = (object)prefabs2.start == null;
				object obj9 = default(object);
				gameObject = (GameObject)(&obj9);
				if (!flag42)
				{
					Vector3 position3 = prefabs2.start.position;
					float num48 = position2.z - position3.z;
					float num49 = position2.y - position3.y;
					float num50 = position2.x - position3.x;
					Transform transform4 = prefabs2.transform;
					float num51 = num48 + num9;
					float num52 = num49 + num11;
					float num53 = num50 + num13;
					bool flag43 = (object)transform4 == null;
					gameObject = (GameObject)(object)prefabs2;
					if (!flag43)
					{
						float num54 = default(float);
						transform4.position = (Vector3)(&num54);
						if (!_003C_003E4__this.BoundsOverlap(prefabs2))
						{
							_003Cprevious_003E5__9 = prefabs2;
							gameObject = (GameObject)(this + 72);
							int num55 = _003Cj_003E5__12 + 1;
							_003Cj_003E5__12 = num55;
							num54 = num53;
							num8 = num14;
							vector2 = (Vector3)num43;
							num44 = unchecked((nint)null);
							goto IL_2303;
						}
						List<RsgPiece> list4 = _003ClookaheadPieces_003E5__11;
						bool flag44 = _003ClookaheadPieces_003E5__11 == null;
						gameObject = (GameObject)(object)_003C_003E4__this;
						if (!flag44)
						{
							int num56 = list4._size - 1;
							_003Ck_003E5__13 = num56;
							num54 = num53;
							num8 = num14;
							vector2 = (Vector3)num43;
							num44 = unchecked((nint)null);
							gameObject = (GameObject)(object)_003C_003E4__this;
							goto IL_2326;
						}
					}
				}
			}
			goto IL_1ef6;
			IL_2345:
			_003ClookaheadPieces_003E5__11 = list;
			gameObject = (GameObject)(this + 88);
			goto IL_2562;
			IL_1a9f:
			RsgPiece rsgPiece5 = _003ClookaheadPieces_003E5__11.get_Item(0);
			_003Cprevious_003E5__9 = rsgPiece5;
			int num57 = _003CnumPieces_003E5__5 + 1;
			_003CnumPieces_003E5__5 = num57;
			RsgPiece rsgPiece6;
			rsgPiece = rsgPiece6;
			num6 = 0;
			goto IL_2345;
			IL_23e4:
			result = true;
			goto IL_1ef1;
			IL_1f01:
			throw new IndexOutOfRangeException();
			IL_235f:
			if ((object)_003C_003E4__this != null)
			{
				bool flag45 = _003ClookaheadPieces_003E5__11 == null;
				gameObject = (GameObject)(object)_003ClookaheadPieces_003E5__11;
				if (!flag45)
				{
					List<object> allPieces2 = (List<object>)(object)rsgController.allPieces;
					rsgPiece6 = _003ClookaheadPieces_003E5__11.get_Item(0);
					bool flag46 = rsgController.allPieces == null;
					gameObject = (GameObject)(object)_003ClookaheadPieces_003E5__11;
					if (!flag46)
					{
						int version2 = allPieces2._version + 1;
						allPieces2._version = version2;
						gameObject = (GameObject)(object)allPieces2._items;
						if (allPieces2._items != null)
						{
							int size3 = allPieces2._size;
							int size4 = allPieces2._size;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v748 @ rcx_v176 (UnityEngine.GameObject)+18]");
							if ((nint)size4 >= (nint)0)
							{
								((List<object>)(object)rsgController.allPieces).AddWithResize((object)rsgPiece6);
							}
							else
							{
								int size5 = allPieces2._size + 1;
								allPieces2._size = size5;
								int size6 = allPieces2._size;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v748 @ rcx_v176 (UnityEngine.GameObject)+18]");
								bool flag47 = (nint)size6 >= (nint)0;
								Component component = (Component)(object)allPieces2._items;
								if (flag47)
								{
									goto IL_1f01;
								}
							}
							bool flag48 = _003ClookaheadPieces_003E5__11 == null;
							gameObject = (GameObject)(object)_003ClookaheadPieces_003E5__11;
							if (!flag48)
							{
								RsgPiece rsgPiece7 = _003ClookaheadPieces_003E5__11.get_Item(0);
								gameObject = (GameObject)(object)_003ClookaheadPieces_003E5__11;
								if ((object)rsgPiece7 != null)
								{
									List<Bounds> bounds2 = rsgController.bounds;
									Bounds bounds3 = rsgPiece7.GetBounds();
									bool flag49 = rsgController.bounds == null;
									gameObject = (GameObject)(&vector2);
									if (!flag49)
									{
										vector = bounds3.m_Center;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1547 @ rax_v95 (UnityEngine.Bounds)+10]");
										double num36 = 0.0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v663 @ rbx_v24 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v663 @ rbx_v24 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
										object obj10 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v663 @ rbx_v24 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
										bool flag50 = (nint)0 == 0;
										gameObject = (GameObject)(&vector2);
										if (!flag50)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v663 @ rbx_v24 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
											Component component = (Component)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v663 @ rbx_v24 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
											nint num58 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v585 @ rdx_v58+18]");
											if (num58 >= 0)
											{
												rsgController.bounds.AddWithResize((Bounds)(&vector2));
												vector2 = bounds3.m_Center;
												gameObject = (GameObject)(object)rsgController.bounds;
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v663 @ rbx_v24 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
												object obj11 = (nint)0 + (nint)1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v663 @ rbx_v24 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
												nint num59 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v585 @ rdx_v58+18]");
												if (num59 >= 0)
												{
													goto IL_1f01;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v663 @ rbx_v24 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
												object obj12 = (nint)0 * (nint)2;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v663 @ rbx_v24 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
												gameObject = (GameObject)(0 + obj12);
												_ = bounds3.m_Center;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1547 @ rax_v95 (UnityEngine.Bounds)+10]");
												_ = 0;
											}
											int num60 = 1;
											prefabs2 = rsgPiece7;
											while (true)
											{
												List<RsgPiece> list5 = _003ClookaheadPieces_003E5__11;
												if (_003ClookaheadPieces_003E5__11 == null)
												{
													break;
												}
												if (num60 < list5._size)
												{
													RsgPiece rsgPiece8 = _003ClookaheadPieces_003E5__11.get_Item(num60);
													bool flag51 = (object)rsgPiece8 == null;
													gameObject = (GameObject)(object)_003ClookaheadPieces_003E5__11;
													if (flag51)
													{
														break;
													}
													GameObject gameObject6 = rsgPiece8.gameObject;
													UnityEngine.Object.Destroy(gameObject6);
													num60++;
													prefabs2 = (RsgPiece)(object)gameObject6;
													gameObject = gameObject6;
													continue;
												}
												goto IL_1a9f;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_1ef6;
			IL_130c:
			bool flag52 = _003ClookaheadPieces_003E5__11 == null;
			gameObject = (GameObject)(object)_003ClookaheadPieces_003E5__11;
			if (!flag52)
			{
				RsgPiece rsgPiece9 = _003ClookaheadPieces_003E5__11.get_Item(_003Ck_003E5__13);
				bool flag53 = (object)rsgPiece9 == null;
				gameObject = (GameObject)(object)_003ClookaheadPieces_003E5__11;
				if (!flag53)
				{
					GameObject gameObject7 = rsgPiece9.gameObject;
					UnityEngine.Object.Destroy(gameObject7);
					int num61 = _003Ck_003E5__13 - 1;
					_003Ck_003E5__13 = num61;
					vector = (Vector3)num;
					num44 = 0;
					gameObject = gameObject7;
					goto IL_2326;
				}
			}
			goto IL_1ef6;
			IL_2562:
			if (_003CnumPieces_003E5__5 < _003CmaxPieces_003E5__4)
			{
				List<RsgPiece> list6 = new List<RsgPiece>();
				_003ClookaheadPieces_003E5__11 = list6;
				_003CpieceBeforeLookahead_003E5__10 = _003Cprevious_003E5__9;
				gameObject = (GameObject)(this + 80);
				_003Cj_003E5__12 = (int)list;
				num15 = (nint)rsgPiece;
				num44 = num6;
				obj = 0;
				goto IL_2303;
			}
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			Component component6 = default(Component);
			if ((object)_003C_003E4__this != null)
			{
				GameObject[] prefabs5 = rsgController.prefabs;
				if (rsgController.prefabs != null)
				{
					List<RsgPiece> list7 = list;
					List<RsgPiece> list8 = list;
					while ((nint)list8 < prefabs5.Length)
					{
						if ((nint)list7 < prefabs5.Length)
						{
							gameObject = prefabs5[(object)list7];
							if ((object)prefabs5[(object)list7] != null)
							{
								GameObject gameObject8 = prefabs5[(object)list7].gameObject;
								if ((object)gameObject8 != null)
								{
									gameObject8.SetActive(value: false);
									list7 = (List<RsgPiece>)(list7 + 1);
									list8 = list7;
									continue;
								}
							}
							goto IL_1ef6;
						}
						goto IL_1f01;
					}
					gameObject = rsgController.roomStart;
					if ((object)rsgController.roomStart != null)
					{
						rsgController.roomStart.SetActive(value: false);
						gameObject = rsgController.roomEnd;
						if ((object)rsgController.roomEnd != null)
						{
							rsgController.roomEnd.SetActive(value: false);
							rsgController.totalTraversalTime = (float)list;
							if (rsgController.allPieces != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
								while (enumerator.MoveNext())
								{
									bool flag54 = (object)component6 == null;
									List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
									if (!flag54)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2705 @ stack_-178 (UnityEngine.Component)+5C]");
										float totalTraversalTime = 0f + rsgController.totalTraversalTime;
										rsgController.totalTraversalTime = totalTraversalTime;
										continue;
									}
									throw new NullReferenceException();
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
								float totalTraversalTime2 = ((rsgController.dungeonType == EDungeonType.Normal) ? (rsgController.totalTraversalTime * rsgController.extraTime) : (rsgController.totalTraversalTime * rsgController.extraTimeBoss));
								rsgController.totalTraversalTime = totalTraversalTime2;
								bool flag55 = !rsgController.combineColliderMesh;
								nint num62 = 0;
								if (!flag55)
								{
									_003C_003E4__this.CombineMeshes(rsgController.allPieces);
									num62 = unchecked((nint)null);
								}
								bool flag56 = _003Ctimer_003E5__2 == null;
								gameObject = (GameObject)(object)_003Ctimer_003E5__2;
								if (!flag56)
								{
									_003Ctimer_003E5__2.Stop();
									bool flag57 = _003Ctimer_003E5__2 == null;
									gameObject = (GameObject)(object)_003Ctimer_003E5__2;
									if (!flag57)
									{
										long elapsedMilliseconds = _003Ctimer_003E5__2.ElapsedMilliseconds;
										Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
										object arg = default(object);
										string text3 = $"Generated map in {arg}ms";
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
										if (rsgController.navmeshSurface != null)
										{
											bool flag58 = (object)rsgController.navmeshSurface == null;
											gameObject = (GameObject)(object)rsgController.navmeshSurface;
											if (flag58)
											{
												goto IL_1ef6;
											}
											rsgController.navmeshSurface.BuildNavMesh();
										}
										Action<float> a_GenerationFinished = A_GenerationFinished;
										if (A_GenerationFinished != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1667 @ rdx_v19 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
										}
										result = false;
										goto IL_1ef1;
									}
								}
								throw new NullReferenceException();
							}
						}
					}
				}
			}
			goto IL_1ef6;
			IL_22cc:
			Transform transform5 = prefabs2.transform;
			gameObject = (GameObject)(object)prefabs2;
			if ((object)transform5 == null)
			{
				goto IL_1ef6;
			}
			vector = Vector3.upVector;
			float num63 = (float)(0.0 - num38);
			Vector3 vector3 = default(Vector3);
			transform5.Rotate((Vector3)(&vector3), num63);
			float x = forward.x;
			float x2 = forward2.x;
			num9 = num40;
			num11 = num41;
			num13 = num42;
			num47 = num63;
			num15 = unchecked((nint)null);
			obj = 0;
			goto IL_2131;
			IL_2326:
			if (_003Ck_003E5__13 >= 0)
			{
				if ((object)_003C_003E4__this != null)
				{
					num = rsgController.generationDelay;
					float generationDelay2 = rsgController.generationDelay;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)generationDelay2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
					{
						goto IL_130c;
					}
					WaitForSeconds waitForSeconds2 = new WaitForSeconds(rsgController.generationDelay);
					_003C_003E2__current = waitForSeconds2;
					_003C_003E1__state = 2;
					goto IL_23e4;
				}
			}
			else
			{
				List<RsgPiece> list9 = new List<RsgPiece>();
				_003ClookaheadPieces_003E5__11 = list9;
				gameObject = (GameObject)(this + 88);
				if (++_003Ccollisions_003E5__6 < _003CmaxCollisions_003E5__7)
				{
					_003Cprevious_003E5__9 = _003CpieceBeforeLookahead_003E5__10;
					gameObject = (GameObject)(this + 72);
					goto IL_146e;
				}
				if ((object)_003C_003E4__this != null && rsgController.allPieces != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
					while (enumerator.MoveNext())
					{
						if ((object)component6 != null)
						{
							GameObject gameObject9 = component6.gameObject;
							UnityEngine.Object.Destroy(gameObject9);
							continue;
						}
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
					IEnumerator routine = _003C_003E4__this.GenerateMap();
					Coroutine coroutine = _003C_003E4__this.StartCoroutine(routine);
					result = false;
					goto IL_1ef1;
				}
			}
			goto IL_1ef6;
			IL_1fa5:
			if (prefabs2.mirror)
			{
				gameObject = (GameObject)(object)random;
				bool flag59 = (nint)random < 0;
				if (random != null)
				{
					nint num64 = (nint)gameObject;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2534 @ rax_v216 (Il2CppClass<UnityEngine.GameObject>)+1B8] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm6\"");
					if (flag59)
					{
						goto IL_1ffe;
					}
					prefabs2.mirrored = true;
					gameObject = prefabs2.children;
					if ((object)prefabs2.children != null)
					{
						Transform transform6 = prefabs2.children.transform;
						if ((object)transform6 != null)
						{
							object obj13 = default(object);
							transform6.localScale = (Vector3)(&obj13);
							obj13 = 3212836864L;
							num44 = unchecked((nint)null);
							goto IL_1ffe;
						}
					}
				}
				goto IL_1ef6;
			}
			goto IL_1ffe;
			IL_0802:
			_003Cj_003E5__12 = _003ClookAhead_003E5__8;
			goto IL_1fa5;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	public bool combineColliderMesh;

	public NavMeshSurface navmeshSurface;

	public GameObject[] prefabs;

	public GameObject roomStart;

	public GameObject roomEnd;

	public GraveyardBossRoom roomBoss;

	private float generationDelay;

	private static ConsistentRandom random;

	public static int seed = 69420;

	public static Action<float> A_GenerationFinished;

	private static int customSeed = 0;

	private float extraTime;

	private float extraTimeBoss;

	public static RsgController Instance;

	public int testSeed;

	private EDungeonType dungeonType;

	public static bool isCurrentMapRandomSeed;

	private float totalTraversalTime;

	private RsgPiece previousPiece;

	private List<RsgPiece> allPieces;

	private RsgStart _003CrsgStart_003Ek__BackingField;

	private InteractableCryptLeave _003CrsgEnd_003Ek__BackingField;

	private List<Bounds> bounds;

	private int mapLength;

	public int minPieces;

	public int maxPieces;

	private Vector3 startPosition;

	public GameObject combinedColliderMesh;

	private bool HasCustomSeed
	{
		get
		{
			bool flag = customSeed < 0;
			bool flag2 = customSeed == 0;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag4 & flag3;
		}
	}

	public RsgStart rsgStart
	{
		get
		{
			return _003CrsgStart_003Ek__BackingField;
		}
		private set
		{
			_003CrsgStart_003Ek__BackingField = value;
		}
	}

	public InteractableCryptLeave rsgEnd
	{
		get
		{
			return _003CrsgEnd_003Ek__BackingField;
		}
		private set
		{
			_003CrsgEnd_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		if (Instance != null)
		{
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj);
		}
		else
		{
			Instance = this;
		}
	}

	public static void SetCustomSeed(int seed)
	{
		customSeed = seed;
	}

	private bool CanUseCustomSeed()
	{
		bool flag = ChallengesTracker.HasChallengeModifier("crypt");
		return !flag;
	}

	public unsafe void Generate(int newSeed, EDungeonType dungeonType, out float traversalTime)
	{
		//IL_004d: Expected Ref, but got F4
		int num;
		if (customSeed > 0 && !ChallengesTracker.HasChallengeModifier("crypt"))
		{
			num = customSeed;
			isCurrentMapRandomSeed = false;
		}
		else
		{
			isCurrentMapRandomSeed = true;
			num = newSeed;
		}
		this.dungeonType = dungeonType;
		seed = num;
		ConsistentRandom consistentRandom = new ConsistentRandom(num);
		random = consistentRandom;
		_003CGenerateMap_003Ed__41 obj = new _003CGenerateMap_003Ed__41(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
		ref float reference = ref *(float*)totalTraversalTime;
	}

	private int FindMapLength()
	{
		//IL_0032: Expected I4, but got O
		if (random != null)
		{
			return random.Next(minPieces, maxPieces);
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public void ClearMap()
	{
		if (allPieces != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			Component component = default(Component);
			while (enumerator.MoveNext())
			{
				if ((object)component != null)
				{
					GameObject obj = component.gameObject;
					UnityEngine.Object.Destroy(obj);
					continue;
				}
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		}
		List<RsgPiece> list = new List<RsgPiece>();
		allPieces = list;
		if (combinedColliderMesh != null)
		{
			UnityEngine.Object.Destroy(combinedColliderMesh);
		}
	}

	private IEnumerator GenerateMap()
	{
		_003CGenerateMap_003Ed__41 obj = new _003CGenerateMap_003Ed__41(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void MirrorPiece(RsgPiece piece)
	{
		//IL_0037: Expected O, but got Ref
		piece.mirrored = true;
		Transform transform = piece.children.transform;
		object obj = default(object);
		transform.localScale = (Vector3)(&obj);
	}

	private unsafe void ReversePiece(RsgPiece piece)
	{
		//IL_0079: Expected O, but got Ref
		//IL_0095: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172E30]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		piece.end = piece.start;
		piece.start = piece.end;
		Vector3 vector = default(Vector3);
		piece.end.Rotate((Vector3)(&vector), 180f);
		piece.start.Rotate((Vector3)(&vector), 180f);
		piece.start.name = "start";
		piece.end.name = "end";
	}

	private unsafe bool BoundsOverlap(RsgPiece piece)
	{
		//IL_004e: Expected O, but got Ref
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		if ((object)piece != null)
		{
			Bounds bounds = piece.GetBounds();
			bool flag = this.bounds == null;
			List<Bounds>.Enumerator enumerator = default(List<Bounds>.Enumerator);
			RsgController rsgController = (RsgController)(&enumerator);
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18113FB70");
				List<Bounds>.Enumerator enumerator2 = default(List<Bounds>.Enumerator);
				object obj2 = default(object);
				object obj4 = default(object);
				object obj5 = default(object);
				object obj9 = default(object);
				object obj11 = default(object);
				object obj15 = default(object);
				object obj16 = default(object);
				while (enumerator2.MoveNext())
				{
					object obj = (object)bounds.m_Center - obj2;
					object obj3 = obj4 + obj5;
					bool flag3;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
					{
						object obj6 = obj2 + (object)bounds.m_Center;
						object obj7 = obj5 - obj4;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v6 (UnityEngine.Bounds)+10]");
							object obj8 = obj9 - 0;
							object obj10 = obj11 + obj4;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v6 (UnityEngine.Bounds)+10]");
								object obj12 = 0 + obj9;
								object obj13 = obj4 - obj11;
								if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13))
								{
									object obj14 = obj15 - obj16;
									object obj17 = obj16 + obj4;
									if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj17) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14))
									{
										object obj18 = obj16 + obj15;
										object obj19 = obj4 - obj16;
										bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj18) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj19);
										flag3 = !flag2;
										goto IL_0237;
									}
								}
							}
						}
					}
					flag3 = false;
					goto IL_0237;
					IL_0237:
					if (flag3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
						return true;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				return false;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void BoundsAdd(RsgPiece piece)
	{
		//IL_0044: Expected O, but got I
		//IL_0099: Expected O, but got I
		//IL_00b9: Expected O, but got I
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_0082: Expected O, but got Ref
		List<Bounds> list = this.bounds;
		Bounds bounds = piece.GetBounds();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v4 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v4 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v4 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rdx_v4+18]");
		if (num >= 0)
		{
			object obj2 = default(object);
			list.AddWithResize((Bounds)(&obj2));
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v4 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
		object obj3 = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v4 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
		object obj4 = (nint)0 * (nint)2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v4 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
		object obj5 = 0 + obj4;
		_ = bounds.m_Center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v6 (UnityEngine.Bounds)+10]");
		_ = 0;
	}

	private unsafe void GetNextTransform(RsgPiece piece, out Vector3 pos, out Quaternion rotation)
	{
		//IL_004b: Expected Ref, but got F4
		//IL_0079: Expected Ref, but got F4
		ref Vector3 reference = ref *(Vector3*)startPosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (RsgController)+A4]");
		_ = 0;
		ref Quaternion reference2 = ref *(Quaternion*)Quaternion.identityQuaternion;
		if (piece != null)
		{
			Vector3 position = piece.end.position;
			reference = ref *(Vector3*)position.x;
			_ = position.z;
			reference2 = ref *(Quaternion*)piece.end.rotation.x;
		}
	}

	public unsafe void CombineMeshes(List<RsgPiece> allPieces)
	{
		//IL_045e: Expected O, but got I4
		//IL_0031: Expected O, but got Ref
		//IL_0056: Expected O, but got Ref
		//IL_0196: Expected O, but got I4
		//IL_0091: Expected I, but got O
		//IL_00ad: Expected O, but got Ref
		//IL_00c8: Expected O, but got I4
		//IL_0106: Expected O, but got I
		//IL_0231: Expected O, but got Ref
		//IL_0243: Expected O, but got Ref
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		List<MeshCollider> list = new List<MeshCollider>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		nint num = 0;
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		Collider collider = default(Collider);
		float m = default(float);
		CombineInstance combineInstance2 = default(CombineInstance);
		List<object>.Enumerator enumerator4 = default(List<object>.Enumerator);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag = (object)collider == null;
				List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
				if (!flag)
				{
					bool flag2 = list == null;
					enumerator2 = (List<object>.Enumerator)(&enumerator);
					if (!flag2)
					{
						int version = list._version + 1;
						list._version = version;
						num = (nint)list._items;
						bool flag3 = list._items == null;
						enumerator2 = (List<object>.Enumerator)(&enumerator);
						if (flag3)
						{
							break;
						}
						List<object>.Enumerator enumerator3 = (List<object>.Enumerator)list._size;
						int size = list._size;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ r8_v3 (Il2CppMethodInfo)+18]");
						if ((nint)size >= (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ stack_-1A8 (UnityEngine.Collider)+50]");
							((List<object>)(object)list).AddWithResize((object)0);
							num = 0;
						}
						else
						{
							int size2 = list._size + 1;
							list._size = size2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ stack_-1A8 (UnityEngine.Collider)+50]");
							_ = 0;
						}
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			((List<RsgPiece>.Enumerator*)(&enumerator))->Dispose();
			List<CombineInstance> list2 = new List<CombineInstance>();
			CombineInstance combineInstance = (CombineInstance)0;
			int num2 = 0;
			for (int num3 = 0; num3 < list._size; num3 = num2)
			{
				MeshCollider meshCollider = list.get_Item(num2);
				object obj = 0;
				while (true)
				{
					Mesh sharedMesh = meshCollider.sharedMesh;
					int subMeshCount = sharedMesh.subMeshCount;
					if ((nint)obj >= subMeshCount)
					{
						break;
					}
					Mesh sharedMesh2 = meshCollider.sharedMesh;
					combineInstance.mesh = sharedMesh2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805F68E0");
					Transform transform = meshCollider.transform;
					Matrix4x4 localToWorldMatrix = transform.localToWorldMatrix;
					combineInstance.transform = (Matrix4x4)(&m);
					list2.Add((CombineInstance)(&combineInstance2));
					obj++;
					m = localToWorldMatrix.m00;
				}
				num2++;
			}
			GameObject gameObject = new GameObject();
			combinedColliderMesh = gameObject;
			combinedColliderMesh.name = "MapMesh";
			MeshFilter meshFilter = combinedColliderMesh.AddComponent<MeshFilter>();
			Mesh mesh = new Mesh();
			CombineInstance[] combine = list2.ToArray();
			mesh.CombineMeshes(combine, mergeSubMeshes: true);
			AutoWeld(mesh, 0.25f);
			meshFilter.mesh = mesh;
			MeshCollider meshCollider2 = combinedColliderMesh.AddComponent<MeshCollider>();
			meshCollider2.sharedMesh = mesh;
			combinedColliderMesh.SetActive(value: true);
			int layer = LayerMask.NameToLayer("Ground");
			combinedColliderMesh.layer = layer;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			while (true)
			{
				if (enumerator4.MoveNext())
				{
					if ((object)collider == null)
					{
						break;
					}
					collider.enabled = false;
					continue;
				}
				((List<MeshCollider>.Enumerator*)(&enumerator4))->Dispose();
				return;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public static void AutoWeld(Mesh mesh, float threshold)
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

	private unsafe void OnDrawGizmos()
	{
		//IL_0095: Expected O, but got Ref
		//IL_0095: Expected O, but got Ref
		if (!Application.isPlaying || bounds == null)
		{
			return;
		}
		List<Bounds> list = bounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v5 (System.Collections.Generic.List`1<UnityEngine.Bounds>)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18113FB70");
			List<Bounds>.Enumerator enumerator = default(List<Bounds>.Enumerator);
			object obj = default(object);
			object obj2 = default(object);
			while (enumerator.MoveNext())
			{
				Gizmos.DrawWireCube((Vector3)(&obj), (Vector3)(&obj2));
			}
			enumerator.Dispose();
		}
	}

	public RsgController()
	{
		//IL_004a: Expected I, but got O
		extraTime = 1.2f;
		extraTimeBoss = 1f;
		totalTraversalTime = 60f;
		minPieces = 3;
		maxPieces = 5;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rcx_v2 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num3 = 0f * 2000f;
		Vector3 vector = default(Vector3);
		startPosition = vector;
		base._002Ector();
	}
}
