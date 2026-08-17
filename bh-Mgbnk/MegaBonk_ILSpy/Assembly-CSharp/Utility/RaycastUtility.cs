using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;

namespace Utility;

public class RaycastUtility
{
	public struct ConeSphere
	{
		public Vector3 pos;

		public float radius;

		public ConeSphere(Vector3 position, float radius)
		{
			//IL_000f: Expected O, but got F4
			pos = (Vector3)position.x;
			_ = position.z;
			this.radius = radius;
		}
	}

	private static Collider[] coneCastBuffer;

	public unsafe static Vector3 RayToGround(Vector3 pos, float maxDistance = 9999f)
	{
		//IL_0024: Expected O, but got Ref
		//IL_0136: Expected native int or pointer, but got O
		//IL_0143: Expected native int or pointer, but got O
		//IL_00d9: Expected F4, but got O
		//IL_00e9: Expected F4, but got I
		GameManager instance = GameManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		object obj = default(object);
		int layerMask = default(int);
		float x;
		float z;
		if (Physics.Raycast((Ray)(&obj), out var hitInfo, maxDistance, layerMask))
		{
			Collider collider = hitInfo.collider;
			if ((object)collider != null)
			{
				GameObject gameObject = collider.gameObject;
				if ((object)gameObject != null)
				{
					string name = gameObject.name;
					if (!(name != "WorldCollider"))
					{
						goto IL_00ee;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
					object obj2 = default(object);
					x = (float)obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rax_v28+8]");
					z = 0f;
					goto IL_012e;
				}
			}
			return (Vector3)new NullReferenceException();
		}
		goto IL_00ee;
		IL_00ee:
		z = pos.z;
		x = pos.x;
		goto IL_012e;
		IL_012e:
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = x;
		((Vector3*)(nint)vector)->z = z;
		return vector;
	}

	public unsafe static Vector3 RayToGround(Vector3 pos, LayerMask layerMask, float maxDistance = 9999f)
	{
		//IL_001a: Expected O, but got Ref
		//IL_0103: Expected native int or pointer, but got O
		//IL_0128: Expected native int or pointer, but got O
		//IL_00d7: Expected F4, but got I
		//IL_00e4: Expected F4, but got O
		//IL_00df: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		object obj = default(object);
		int layerMask2 = default(int);
		float z;
		Vector3 vector = default(Vector3);
		if (Physics.Raycast((Ray)(&obj), out var hitInfo, maxDistance, layerMask2))
		{
			Collider collider = hitInfo.collider;
			if ((object)collider != null)
			{
				GameObject gameObject = collider.gameObject;
				if ((object)gameObject != null)
				{
					string name = gameObject.name;
					if (name == "WorldCollider")
					{
						goto IL_00e9;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v24+8]");
					z = 0f;
					object obj2 = default(object);
					((Vector3*)(nint)vector)->x = (float)obj2;
					goto IL_0120;
				}
			}
			return (Vector3)new NullReferenceException();
		}
		goto IL_00e9;
		IL_0120:
		((Vector3*)(nint)vector)->z = z;
		return vector;
		IL_00e9:
		z = pos.z;
		((Vector3*)(nint)vector)->x = pos.x;
		goto IL_0120;
	}

	public unsafe static List<Collider> ConeCastAll(Vector3 origin, Vector3 direction, float maxDistance, float coneAngle)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_04a1: Expected O, but got Ref
		//IL_04bc: Expected F4, but got O
		//IL_04b7: Expected native int or pointer, but got O
		//IL_04d1: Expected F4, but got I
		//IL_04cc: Expected native int or pointer, but got O
		//IL_04da: Expected O, but got Ref
		//IL_003f: Expected O, but got Ref
		//IL_003f: Expected O, but got Ref
		//IL_004c: Expected O, but got Ref
		//IL_0063: Expected O, but got Ref
		//IL_0063: Expected O, but got Ref
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected Ref, but got Unknown
		//IL_009b: Expected O, but got Ref
		//IL_00c8: Expected O, but got I4
		//IL_05a7: Expected O, but got I
		//IL_0112: Expected O, but got I
		//IL_014a: Expected O, but got Ref
		//IL_04ff: Expected I, but got O
		//IL_0203: Expected F8, but got I4
		//IL_0556: Expected I, but got O
		//IL_0512: Expected I, but got O
		//IL_052b: Expected F4, but got O
		//IL_053b: Expected F4, but got I
		//IL_02fa: Invalid comparison between F4 and I4
		//IL_03ff: Expected F4, but got I4
		//IL_0463: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Expected O, but got Unknown
		//IL_0414: Expected O, but got I
		//IL_0455: Expected O, but got I
		object obj2 = default(object);
		object obj = obj2 - 56;
		_ = 0;
		float num = default(float);
		Vector3 vector = VectorExtensions.XZVector((Vector3)(&num));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		object obj3 = default(object);
		((Vector3*)(nint)direction)->x = (float)obj3;
		Vector3 vector2 = direction;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v6+8]");
		((Vector3*)(nint)vector2)->z = 0f;
		Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&num));
		float num2 = default(float);
		Vector3 vector3 = (Quaternion)(&num2) * (Vector3)(&num);
		Quaternion quaternion2 = Quaternion.Internal_FromEulerRad((Vector3)(&num));
		Vector3 vector4 = (Quaternion)(&num2) * (Vector3)(&num);
		List<Collider> list = new List<Collider>();
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(null, (Vector3)(&num), maxDistance, out *(Collider[]*)(obj + 64));
		if (enemiesInRadiusSafe > 0)
		{
			object obj4 = 0;
			num = origin.x;
			float num16 = default(float);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+40]");
				object obj5 = 0;
				object obj6 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rcx_v16+18]");
				if ((nint)obj6 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rcx_v16+20+v278 @ rbx_v4*8]");
					Transform transform = ((Component)0).transform;
					float num3 = transform.position.x - origin.x;
					Vector3 vector5 = VectorExtensions.XZVector((Vector3)(&num));
					nint num4 = (nint)typeof(Math);
					float num5 = vector5.y * vector5.y;
					float num6 = vector5.x * vector5.x;
					float num7 = vector5.z * vector5.z;
					float num8 = num5 + num6;
					float num9 = num8 + num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm3\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rcx_v23 (Il2CppClass<System.Math>)+E4]");
					double num10;
					if ((nint)0 <= (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm3\"");
						num10 = 0.0;
					}
					else
					{
						num10 = Math.Sqrt(num9);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
					float num11;
					float num12;
					float num13;
					if (num10 > 9.999999747378752E-06)
					{
						num11 = vector5.x / (float)num10;
						num12 = vector5.y / (float)num10;
						num13 = vector5.z / (float)num10;
					}
					else
					{
						nint num14 = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v595 @ rax_v42 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num15 = 0;
						num11 = (float)Vector3.zeroVector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v596 @ rcx_v33 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
						num13 = 0f;
						num12 = num16;
					}
					nint num17 = (nint)typeof(Math);
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm7\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v645 @ rcx_v26 (Il2CppClass<System.Math>)+E4]");
					if ((nint)0 <= (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
					}
					else
					{
						double num18 = Math.Sqrt(0.0);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
					float num26;
					if (!(1E-15f > 0f))
					{
						float num19 = direction.x * num11;
						float num20 = direction.y * num12;
						float num21 = direction.z * num13;
						float num22 = num19 + num20;
						float num23 = num22 + num21;
						float num24 = num23 / 0f;
						if (-1f > num24 || num24 > 1f)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
						double num25 = Math.Acos(0.0);
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
						num26 = 0f * 57.29578f;
					}
					else
					{
						num26 = 0f;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+58]");
					float num27 = 0f * 0.5f;
					if (num27 > num26)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+40]");
						object obj7 = 0;
						object obj8 = obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rax_v35+18]");
						if ((nint)obj8 >= 0)
						{
							goto IL_04e3;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rax_v35+20+v278 @ rbx_v4*8]");
						list.Add((Collider)0);
					}
					obj4++;
					bool flag = (nint)obj4 < enemiesInRadiusSafe;
					num = num3;
					if (!flag)
					{
						break;
					}
					continue;
				}
				goto IL_04e3;
				IL_04e3:
				return (List<Collider>)(object)new IndexOutOfRangeException();
			}
		}
		return list;
	}

	public unsafe static HashSet<Collider> ConeCastNew(Vector3 origin, Vector3 direction, float distance, float coneAngle)
	{
		//IL_0039: Expected O, but got Ref
		//IL_0039: Expected O, but got Ref
		//IL_007c: Expected O, but got Ref
		//IL_008a: Expected O, but got I4
		//IL_00ed: Expected O, but got I
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		HashSet<Collider> hashSet = (HashSet<Collider>)(object)new HashSet<object>();
		List<ConeSphere>.Enumerator enumerator = default(List<ConeSphere>.Enumerator);
		float num = default(float);
		List<ConeSphere> conecastPositions = GetConecastPositions((Vector3)(&enumerator), (Vector3)(&num), distance, coneAngle);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126FB0");
		List<ConeSphere>.Enumerator enumerator2 = default(List<ConeSphere>.Enumerator);
		float radius = default(float);
		int layerMask = default(int);
		while (true)
		{
			if (!enumerator2.MoveNext())
			{
				enumerator2.Dispose();
				return hashSet;
			}
			GameManager instance = GameManager.Instance;
			if ((object)GameManager.Instance == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			int num2 = Physics.OverlapSphereNonAlloc((Vector3)(&num), radius, coneCastBuffer, layerMask);
			object obj = 0;
			while ((nint)obj < num2)
			{
				Vector3 vector = (Vector3)coneCastBuffer;
				bool flag = coneCastBuffer == null;
				instance = (GameManager)(object)coneCastBuffer;
				if (!flag)
				{
					object obj2 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v6 (UnityEngine.Vector3)+18]");
					if ((nint)obj2 < 0)
					{
						if (hashSet != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v6 (UnityEngine.Vector3)+20+v174 @ rdi_v10*8]");
							bool flag2 = hashSet.Add((Collider)0);
							obj++;
							continue;
						}
						throw new NullReferenceException();
					}
					throw new IndexOutOfRangeException();
				}
				throw new NullReferenceException();
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static List<ConeSphere> GetConecastPositions(Vector3 pos, Vector3 dir, float dist, float coneAngle)
	{
		//IL_004b: Expected O, but got I
		//IL_00b2: Expected O, but got I
		//IL_0089: Expected O, but got Ref
		//IL_00fc: Expected O, but got I
		//IL_02a7: Expected O, but got I
		//IL_013b: Expected F4, but got I4
		//IL_0300: Expected O, but got I
		//IL_0569: Expected O, but got I
		//IL_02e5: Expected O, but got Ref
		//IL_034a: Expected O, but got I
		//IL_019c: Expected O, but got I
		//IL_0179: Expected O, but got Ref
		//IL_01e6: Expected O, but got I
		float num = coneAngle * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180300560");
		float num2 = num * dist;
		float num3 = num2 - 1f;
		float num4 = num3 / dist;
		List<ConeSphere> list = new List<ConeSphere>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (System.Collections.Generic.List`1<Utility.RaycastUtility+ConeSphere>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (System.Collections.Generic.List`1<Utility.RaycastUtility+ConeSphere>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (System.Collections.Generic.List`1<Utility.RaycastUtility+ConeSphere>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v6+18]");
		float num6 = default(float);
		Vector3 vector = default(Vector3);
		if (num5 >= 0)
		{
			list.AddWithResize((ConeSphere)(&num6));
			num6 = vector.x;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (System.Collections.Generic.List`1<Utility.RaycastUtility+ConeSphere>)+18]");
			object obj2 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (System.Collections.Generic.List`1<Utility.RaycastUtility+ConeSphere>)+18]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v6+18]");
			if (num7 >= 0)
			{
				goto IL_0434;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (System.Collections.Generic.List`1<Utility.RaycastUtility+ConeSphere>)+18]");
			object obj3 = (nint)0 + (nint)2;
			object obj4 = obj3 + obj3;
			_ = vector.x;
			_ = vector.y;
			_ = vector.z;
			_ = 1065353216;
		}
		float num8 = num4 * 0f;
		float num9 = 1f - num4;
		float num10 = num8 + 1f;
		float num11 = num10 + num10;
		float num12 = num11 / num9;
		if (!(num12 < dist))
		{
			goto IL_020c;
		}
		float num13 = 0f;
		while (true)
		{
			num13 += num12;
			float num14 = dir.x * num13;
			float num15 = dir.y * num13;
			float num16 = dir.z * num13;
			float num17 = num14 + vector.x;
			float num18 = num15 + vector.y;
			float num19 = num16 + vector.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (System.Collections.Generic.List`1<Utility.RaycastUtility+ConeSphere>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (System.Collections.Generic.List`1<Utility.RaycastUtility+ConeSphere>)+10]");
			object obj5 = 0;
			float num20 = num13 * num4;
			float num21 = num20 + 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (System.Collections.Generic.List`1<Utility.RaycastUtility+ConeSphere>)+18]");
			nint num22 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rcx_v13+18]");
			if (num22 >= 0)
			{
				list.AddWithResize((ConeSphere)(&num6));
				num6 = num17;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (System.Collections.Generic.List`1<Utility.RaycastUtility+ConeSphere>)+18]");
				object obj6 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (System.Collections.Generic.List`1<Utility.RaycastUtility+ConeSphere>)+18]");
				nint num23 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rcx_v13+18]");
				if (num23 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (System.Collections.Generic.List`1<Utility.RaycastUtility+ConeSphere>)+18]");
				object obj7 = (nint)0 + (nint)2;
				object obj8 = obj7 + obj7;
			}
			float num24 = num13 * num4;
			float num25 = 1f - num4;
			float num26 = num24 + 1f;
			float num27 = num26 + num26;
			num12 = num27 / num25;
			float num28 = num12 + num13;
			if (num28 < dist)
			{
				continue;
			}
			goto IL_020c;
		}
		goto IL_0434;
		IL_0434:
		return (List<ConeSphere>)(object)new IndexOutOfRangeException();
		IL_020c:
		float num29 = dist * dir.x;
		float num30 = dist * dir.y;
		float num31 = dist * dir.z;
		float num32 = num29 + vector.x;
		float num33 = num30 + vector.y;
		float num34 = num31 + vector.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (System.Collections.Generic.List`1<Utility.RaycastUtility+ConeSphere>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (System.Collections.Generic.List`1<Utility.RaycastUtility+ConeSphere>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (System.Collections.Generic.List`1<Utility.RaycastUtility+ConeSphere>)+18]");
		nint num35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v9+18]");
		if (num35 >= 0)
		{
			list.AddWithResize((ConeSphere)(&num6));
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (System.Collections.Generic.List`1<Utility.RaycastUtility+ConeSphere>)+18]");
			object obj10 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (System.Collections.Generic.List`1<Utility.RaycastUtility+ConeSphere>)+18]");
			nint num36 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v9+18]");
			if (num36 >= 0)
			{
				goto IL_0434;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (System.Collections.Generic.List`1<Utility.RaycastUtility+ConeSphere>)+18]");
			object obj11 = (nint)0 + (nint)2;
			object obj12 = obj11 + obj11;
		}
		return list;
	}

	static RaycastUtility()
	{
		Collider[] array = new Collider[EnemyManager.maxNumEnemiesPooled];
		coneCastBuffer = array;
	}
}
