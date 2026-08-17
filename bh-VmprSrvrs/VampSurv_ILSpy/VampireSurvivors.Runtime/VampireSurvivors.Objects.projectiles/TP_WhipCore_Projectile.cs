using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_WhipCore_Projectile : Projectile
{
	public LineRenderer _lineRenderer;

	protected WhipVerletNode[] _nodes;

	protected Projectile[] _nodeProjectiles;

	protected float2 _gravity;

	protected float _flipNum;

	protected bool _applyNodeControl;

	protected float _nodeDistance;

	protected float2 _characterOffset;

	protected float _whipSize;

	protected float _timeStartAttack;

	protected float _timeFadeOut;

	protected float _delayFadeOut;

	protected float _timeLerpRatio;

	public virtual int Nodes => 36;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		InitWhips();
	}

	protected virtual float WhipLength()
	{
		if ((object)_weapon != null)
		{
			float num = _weapon.PArea();
			float num2 = num2 * 0.5f;
			bool flag = !(3.5f > num2);
			float num3 = 3.5f;
			if (!flag)
			{
				num3 = num2;
			}
			if ((object)_weapon != null)
			{
				float num4 = _weapon.PAmount();
				float num5 = num2 * 0.5f;
				return num5 + num3;
			}
		}
		throw new NullReferenceException();
	}

	protected virtual float2 GetCharacterOffset()
	{
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			return ((Equipment)weapon)._003COwner_003Ek__BackingField.GetVectorWhipOffset;
		}
		return (float2)new NullReferenceException();
	}

	protected unsafe virtual void InitWhips()
	{
		//IL_0243: Expected O, but got I4
		//IL_0860: Expected O, but got F4
		//IL_0872: Expected O, but got F4
		//IL_06c7: Expected I, but got O
		//IL_0157: Expected I, but got O
		//IL_0361: Expected I, but got O
		//IL_0891->IL060d: Incompatible stack heights: 1 vs 0
		//IL_0116->IL060d: Incompatible stack heights: 1 vs 0
		//IL_01d0->IL060d: Incompatible stack heights: 1 vs 0
		//IL_017a->IL017a: Incompatible stack heights: 2 vs 1
		//IL_0384->IL0384: Incompatible stack heights: 1 vs 0
		//IL_01e2->IL0697: Incompatible stack heights: 1 vs 0
		//IL_0773->IL0446: Incompatible stack heights: 1 vs 0
		//IL_07d7->IL0896: Incompatible stack heights: 3 vs 1
		//IL_07dc->IL0446: Incompatible stack heights: 3 vs 0
		float num = WhipLength();
		float whipSize = default(float);
		_whipSize = whipSize;
		WhipVerletNode[] nodes = new WhipVerletNode[7];
		_nodes = nodes;
		WhipVerletNode[] nodes2 = _nodes;
		if (_nodes != null)
		{
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			float2 ret = default(float2);
			object obj = default(object);
			object obj2 = default(object);
			object obj4 = default(object);
			while (true)
			{
				Weapon weapon = _weapon;
				if (num4 < nodes2.Length)
				{
					WhipVerletNode[] nodes3 = _nodes;
					if ((object)_weapon == null)
					{
						break;
					}
					ArcadeSprite arcadeSprite = ((Equipment)weapon)._003COwner_003Ek__BackingField;
					if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField == null)
					{
						break;
					}
					Transform cachedTrans = ((ArcadeSprite)((Equipment)weapon)._003COwner_003Ek__BackingField).CachedTrans;
					if ((object)cachedTrans == null)
					{
						break;
					}
					bool flag = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
					if (arcadeSprite.body != null)
					{
						BaseBody baseBody = arcadeSprite.body;
						ArcadeTransform arcadeTransform = baseBody._transform;
						if (baseBody._transform == null)
						{
							break;
						}
						arcadeTransform.position = ret;
					}
					float num5 = (float)obj - 0.049999997f;
					float num6 = (float)num2 * 0.01f;
					float num7 = num6 * _flipNum;
					whipSize = num7 * _whipSize;
					float num8 = (float)ret + whipSize;
					WhipVerletNode whipVerletNode = null;
					whipVerletNode.position = (float2)num8;
					whipVerletNode.oldPosition = (float2)num8;
					if (_nodes == null)
					{
						break;
					}
					if (whipVerletNode != null)
					{
						nint num9 = (nint)nodes3;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						bool flag2 = obj2 == null;
					}
					nodes3[num3] = whipVerletNode;
					nodes2 = _nodes;
					num3++;
					num2 += 10;
					if (_nodes == null)
					{
						break;
					}
					num4 = num3;
					continue;
				}
				if ((object)_weapon == null || (object)((Equipment)weapon)._003COwner_003Ek__BackingField == null)
				{
					break;
				}
				bool flag3 = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
				object obj3 = (flag3 ? 1 : 0) * 2;
				float flipNum = (float)obj3 - 1f;
				_flipNum = flipNum;
				float2 characterOffset = GetCharacterOffset();
				Weapon weapon2 = _weapon;
				_characterOffset = characterOffset;
				if ((object)_weapon == null || (object)((Equipment)weapon2)._003COwner_003Ek__BackingField == null)
				{
					break;
				}
				float2 float5 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
				float2 pos = float5 + _characterOffset;
				int nodes4 = Nodes;
				Projectile[] nodeProjectiles = new Projectile[nodes4];
				_nodeProjectiles = nodeProjectiles;
				if (nodes4 > 0)
				{
					int num10 = 0;
					while (true)
					{
						nint num11 = (nint)this;
						ArcadeSprite nodeProjectiles2 = (ArcadeSprite)(object)_nodeProjectiles;
						Projectile projectile = CreateNodeProjectile(pos);
						if (_nodeProjectiles == null)
						{
							break;
						}
						if ((object)projectile != null)
						{
							nint num12 = (nint)nodeProjectiles2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							bool flag4 = obj4 == null;
						}
						num10++;
						if (num10 < nodes4)
						{
							continue;
						}
						goto IL_03b8;
					}
					break;
				}
				goto IL_03b8;
				IL_03b8:
				object lineRenderer = _lineRenderer;
				if ((object)_lineRenderer != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ rdi_v15 (System.Object)+10]");
					if ((nint)0 != 0)
					{
						object lineRenderer2 = _lineRenderer;
						if ((object)_lineRenderer == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rdi_v18 (System.Object)+10]");
						bool flag5 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rdi_v18 (System.Object)+10]");
						LineRenderer.set_positionCount_Injected((IntPtr)0, nodes4);
						if (nodes4 > 0)
						{
							int num13 = 0;
							do
							{
								object lineRenderer3 = _lineRenderer;
								bool flag6 = (object)_lineRenderer == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rdi_v20 (System.Object)+10]");
								bool flag7 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rdi_v20 (System.Object)+10]");
								LineRenderer.SetPosition_Injected((IntPtr)0, num13, ref *(Vector3*)(&ret));
								num13++;
							}
							while (num13 < nodes4);
						}
					}
				}
				Projectile[] nodeProjectiles3 = _nodeProjectiles;
				bool flag8 = _nodeProjectiles == null;
				int num14 = 0;
				int num15 = 0;
				if (flag8)
				{
					break;
				}
				bool flag9;
				do
				{
					if (num15 < nodeProjectiles3.Length)
					{
						Projectile[] nodeProjectiles4 = _nodeProjectiles;
						if (_nodeProjectiles == null)
						{
							break;
						}
						Projectile projectile2 = nodeProjectiles4[num14];
						if ((object)nodeProjectiles4[num14] == null)
						{
							break;
						}
						BaseBody baseBody2 = projectile2.body;
						if (projectile2.body == null)
						{
							break;
						}
						num14++;
						baseBody2._enable = false;
						nodeProjectiles3 = _nodeProjectiles;
						flag9 = _nodeProjectiles != null;
						num15 = num14;
						continue;
					}
					WhipVerletNode[] nodes5 = _nodes;
					if (_nodes == null)
					{
						break;
					}
					WhipVerletNode whipVerletNode2 = nodes5[0];
					if (nodes5[0] == null)
					{
						break;
					}
					whipVerletNode2.isStatic = true;
					float num16 = _whipSize * 0.005f;
					_applyNodeControl = false;
					float nodeDistance = num16 + 0.005f;
					_nodeDistance = nodeDistance;
					return;
				}
				while (flag9);
				break;
			}
		}
		throw new NullReferenceException();
	}

	protected virtual Projectile CreateNodeProjectile(float2 pos)
	{
		return null;
	}

	protected void bodyEnabled(bool enable)
	{
		//IL_0022: Expected O, but got I4
		//IL_002b: Expected O, but got I4
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		Projectile[] nodeProjectiles = _nodeProjectiles;
		Projectile[] nodeProjectiles2 = _nodeProjectiles;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < nodeProjectiles.Length)
		{
			Projectile projectile = nodeProjectiles2[obj2];
			BaseBody baseBody = projectile.body;
			obj2++;
			baseBody._enable = enable;
			nodeProjectiles2 = _nodeProjectiles;
			obj = obj2;
			nodeProjectiles = _nodeProjectiles;
		}
	}

	protected void ApplyGravity()
	{
		//IL_005c: Expected O, but got I4
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_00a2: Expected O, but got I4
		//IL_00b0: Expected O, but got I4
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected O, but got Unknown
		//IL_019b: Expected O, but got I
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Expected O, but got Unknown
		Weapon weapon = _weapon;
		bool flag = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
		object obj = (flag ? 1 : 0) * 4;
		object obj2 = flag + obj;
		object obj3 = obj2 * 4;
		float2 gravity = (float2)(obj3 - 10);
		_gravity = gravity;
		WhipVerletNode[] nodes = _nodes;
		object obj4 = 0;
		WhipVerletNode whipVerletNode = null;
		object obj5 = 0;
		object obj9 = default(object);
		object obj10 = default(object);
		float2 float7 = default(float2);
		while ((nint)obj5 < nodes.Length)
		{
			WhipVerletNode[] nodes2 = _nodes;
			WhipVerletNode whipVerletNode2 = nodes2[obj4];
			if (!whipVerletNode2.isStatic)
			{
				WhipVerletNode[] nodes3 = _nodes;
				WhipVerletNode whipVerletNode3 = nodes3[obj4];
				WhipVerletNode whipVerletNode4 = nodes3[obj4];
				whipVerletNode = nodes3[obj4];
				object obj6 = whipVerletNode4.position - whipVerletNode.oldPosition;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rdx_v7 (VampireSurvivors.Objects.Projectiles.WhipVerletNode)+14]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rdx_v5 (VampireSurvivors.Objects.Projectiles.WhipVerletNode)+1C]");
				object obj7 = num - 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184B45AC0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184B45AC0");
				object obj8 = obj9 * obj10;
				object obj11 = (object)_gravity * obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_WhipCore_Projectile)+EC]");
				object obj12 = 0 * obj8;
				object obj13 = obj11 + obj6;
				object obj14 = obj12 + obj7;
				float2 float5 = (float2)(obj13 + (object)whipVerletNode2.position);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdi_v6 (VampireSurvivors.Objects.Projectiles.WhipVerletNode)+14]");
				object obj15 = obj14 + 0;
				whipVerletNode2.position = float5;
				Weapon weapon2 = _weapon;
				float2 float6 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
				if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float7) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15))
				{
					Weapon weapon3 = _weapon;
					float2 float8 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.position;
				}
				whipVerletNode2.oldPosition = whipVerletNode3.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdx_v6 (VampireSurvivors.Objects.Projectiles.WhipVerletNode)+14]");
				_ = 0;
			}
			nodes = _nodes;
			obj4++;
			obj5 = obj4;
		}
	}

	protected void ApplyVerletConstraints()
	{
		//IL_0313: Expected O, but got I4
		//IL_0075: Expected O, but got I4
		//IL_00c3: Expected O, but got I
		//IL_025a: Expected I, but got O
		//IL_028e: Expected O, but got I
		//IL_0187: Expected F8, but got I4
		//IL_0133: Expected F8, but got I4
		//IL_01f2: Expected O, but got F8
		//IL_0234: Expected O, but got F8
		WhipVerletNode[] nodes = _nodes;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			object obj = nodes.Length - 1;
			if (num < (nint)obj)
			{
				WhipVerletNode[] nodes2 = _nodes;
				object obj2 = num2 + 1;
				WhipVerletNode whipVerletNode = nodes2[num2];
				WhipVerletNode whipVerletNode2 = nodes2[obj2];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdi_v6 (VampireSurvivors.Objects.Projectiles.WhipVerletNode)+14]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rbx_v7 (VampireSurvivors.Objects.Projectiles.WhipVerletNode)+14]");
				object obj3 = num3 - 0;
				nint num4 = (nint)typeof(Math);
				object obj4 = whipVerletNode.position - whipVerletNode2.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdi_v6 (VampireSurvivors.Objects.Projectiles.WhipVerletNode)+14]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rbx_v7 (VampireSurvivors.Objects.Projectiles.WhipVerletNode)+14]");
				object obj5 = num5 - 0;
				object obj6 = obj5 * obj5;
				object obj7 = obj4 * obj4;
				double d = (double)obj6 + (double)obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rcx_v6 (Il2CppClass<System.Math>)+E4]");
				double num6;
				if ((nint)0 <= (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
					num6 = 0.0;
				}
				else
				{
					num6 = Math.Sqrt(d);
				}
				object obj8 = whipVerletNode.position - whipVerletNode2.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm6,xmm0\"");
				bool flag = 0 <= 0;
				double num7 = 0.0;
				if (!flag)
				{
					float num8 = CalculateIndexNodeDistance(num2);
					num7 = num6 / 0.0;
				}
				double num9 = num7 * 0.800000011920929;
				double num10 = num9 * (double)obj3;
				double num11 = num9 * (double)obj8;
				if (!whipVerletNode.isStatic)
				{
					double num12 = (double)whipVerletNode.position + num11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdi_v6 (VampireSurvivors.Objects.Projectiles.WhipVerletNode)+14]");
					double num13 = 0.0 + num10;
					whipVerletNode.position = (float2)num12;
				}
				if (!whipVerletNode2.isStatic)
				{
					double num14 = (double)whipVerletNode2.position - num11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rbx_v7 (VampireSurvivors.Objects.Projectiles.WhipVerletNode)+14]");
					double num15 = 0.0 - num10;
					whipVerletNode2.position = (float2)num14;
				}
				nodes = _nodes;
				num2++;
				num = num2;
				continue;
			}
			break;
		}
	}

	protected virtual float CalculateIndexNodeDistance(int index)
	{
		if ((object)_weapon != null)
		{
			float num = _weapon.PArea();
			WhipVerletNode[] nodes = _nodes;
			float num2 = num2 * 0.04f;
			if (_nodes != null)
			{
				float num3 = num2 + 0.04f;
				float num4 = num3 / (float)nodes.Length;
				float num5 = num4 * (float)index;
				return num5 + 0.02f;
			}
		}
		throw new NullReferenceException();
	}

	protected float2 MultiLerp(List<Vector2> waypoints, float lerp)
	{
		//IL_02dd: Expected F4, but got I4
		//IL_02e6: Expected O, but got I4
		//IL_02f7: Expected O, but got I4
		//IL_00f1: Expected O, but got I
		//IL_00f9: Expected I4, but got O
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0029: Expected O, but got I
		//IL_027e: Expected O, but got I
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_02ad: Expected O, but got I4
		//IL_009b: Expected I4, but got O
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected I4, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		//IL_01de: Expected O, but got I4
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Expected O, but got Unknown
		//IL_0257: Expected O, but got I4
		//IL_0263: Expected O, but got I4
		float num = MultiDistance(waypoints);
		float num2 = num * lerp;
		float num3 = 0f;
		object obj = 0;
		List<Vector2> list = waypoints;
		object obj2 = 0;
		int index;
		List<Vector2> list2 = default(List<Vector2>);
		while (true)
		{
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)obj3 < 0)
			{
				object obj4 = obj + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				object obj5 = -1;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
					object obj6 = obj + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
					float num4 = num + num3;
					bool flag = num4 > num2;
					index = (int)list2;
					if (flag)
					{
						break;
					}
					obj++;
					num3 += num;
					list = list2;
					obj2 = obj;
					continue;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			obj = -1;
			index = (int)list;
			break;
		}
		int num6 = default(int);
		if (lerp < 1f)
		{
			object obj7 = obj + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)obj7 < 0)
			{
				int count = obj + 1;
				List<Vector2> range = waypoints.GetRange(index, count);
				float num5 = MultiDistance(range);
				object obj8 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if ((nint)obj8 < 0)
				{
					object obj9 = obj + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					if ((nint)obj9 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
						List<Vector2> range2 = ((List<Vector2>)num6).GetRange(num6, 0);
						object obj10 = obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
						if ((nint)obj10 < 0)
						{
							object obj11 = obj + 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
							if ((nint)obj11 < 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
								List<Vector2> range3 = ((List<Vector2>)num6).GetRange(num6, 0);
								return (float2)num6;
							}
						}
					}
				}
				goto IL_0343;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		object obj12 = -1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		if ((nint)obj12 < 0)
		{
			return (float2)num6;
		}
		goto IL_0343;
		IL_0343:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		float2 result = default(float2);
		return result;
	}

	protected int GetVectorIndexFromDistanceTravelled(List<Vector2> waypoints, float distanceTravelled)
	{
		//IL_011d: Expected I4, but got O
		//IL_000e: Expected O, but got I4
		//IL_0033: Expected O, but got I4
		//IL_0049: Expected O, but got I
		//IL_007d: Expected O, but got I4
		//IL_00ab: Invalid comparison between O and F4
		if (waypoints != null)
		{
			object obj = 0;
			int num = 0;
			int num2 = 0;
			object obj6 = default(object);
			while (true)
			{
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if ((nint)num3 >= (nint)0)
				{
					break;
				}
				object obj2 = num + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				object obj3 = -1;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
				object obj4 = num + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
				object obj5 = obj6 + obj;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)distanceTravelled))
				{
					num++;
					obj += obj6;
					num2 = num;
					continue;
				}
				return num;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			return (int)(-1);
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	protected float MultiDistance(List<Vector2> waypoints)
	{
		//IL_0219: Expected F4, but got I4
		//IL_0222: Expected O, but got I4
		//IL_0233: Expected O, but got I4
		//IL_02c2: Expected O, but got I
		//IL_0044: Expected O, but got I
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_026d: Expected I, but got O
		//IL_028a: Expected O, but got I
		//IL_02a7: Expected O, but got I
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		//IL_01a2: Expected F8, but got I4
		bool flag = waypoints == null;
		float num = 0f;
		object obj = 0;
		double num3 = default(double);
		double num2 = num3;
		object obj2 = 0;
		if (!flag)
		{
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				object obj3 = -1;
				float result;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
				{
					object obj4 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					bool flag2 = (nint)obj4 >= 0;
					result = (float)num2;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
						bool flag3 = (nint)0 == 0;
						num3 = num2;
						if (flag3)
						{
							break;
						}
						object obj6 = obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v4+18]");
						bool flag4 = (nint)obj6 >= 0;
						num3 = num2;
						if (!flag4)
						{
							object obj7 = obj + 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
							bool flag5 = (nint)obj7 >= 0;
							result = (float)num2;
							if (flag5)
							{
								goto IL_0241;
							}
							object obj8 = obj + 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v4+18]");
							bool flag6 = (nint)obj8 >= 0;
							num3 = num2;
							if (!flag6)
							{
								nint num4 = (nint)typeof(Math);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v4+20+v61 @ rbx_v2*8]");
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v4+28+v61 @ rbx_v2*8]");
								object obj9 = num5 - 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v4+24+v61 @ rbx_v2*8]");
								nint num6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v4+2C+v61 @ rbx_v2*8]");
								object obj10 = num6 - 0;
								object obj11 = obj10 * obj10;
								object obj12 = obj9 * obj9;
								double d = (double)obj11 + (double)obj12;
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rcx_v6 (Il2CppClass<System.Math>)+E4]");
								if ((nint)0 <= (nint)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
									obj++;
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
									num2 = 0.0;
									obj2 = obj;
								}
								else
								{
									num2 = Math.Sqrt(d);
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
									obj++;
									num += (float)num2;
									obj2 = obj;
								}
								continue;
							}
						}
						throw new IndexOutOfRangeException();
					}
					goto IL_0241;
				}
				return num;
				IL_0241:
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
		}
		throw new NullReferenceException();
	}

	public static List<Vector2> GenerateSpline(WhipVerletNode[] points, int stepsPerCurve = 5, float tension = 1f)
	{
		//IL_0020: Expected O, but got I4
		//IL_002a: Expected O, but got I4
		//IL_04cb: Expected O, but got I4
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected O, but got Unknown
		//IL_0193: Expected O, but got I4
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		//IL_0269: Expected O, but got I4
		//IL_035d: Expected O, but got I4
		//IL_0365: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Expected O, but got Unknown
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Expected O, but got Unknown
		List<Vector2> list = new List<Vector2>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		float num = 0.5f;
		float num2 = 4f;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			object obj3 = points.Length - 1;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
			{
				float2 float5;
				float2 float6;
				if (obj == null)
				{
					if (points.Length == 0)
					{
						break;
					}
					WhipVerletNode whipVerletNode = points[0];
					float5 = whipVerletNode.position;
					float6 = whipVerletNode.position;
				}
				else
				{
					object obj4 = obj - 1;
					if ((nint)obj4 >= points.Length)
					{
						break;
					}
					WhipVerletNode whipVerletNode2 = points[obj4];
					float5 = whipVerletNode2.position;
					bool flag = (nint)obj >= points.Length;
					float6 = whipVerletNode2.position;
					if (flag)
					{
						break;
					}
				}
				WhipVerletNode whipVerletNode3 = points[obj];
				object obj5 = obj + 1;
				if ((nint)obj5 >= points.Length)
				{
					break;
				}
				WhipVerletNode whipVerletNode4 = points[obj5];
				object obj6 = points.Length - 2;
				if (obj != obj6)
				{
					object obj7 = obj + 2;
					if ((nint)obj7 >= points.Length)
					{
						break;
					}
				}
				if (stepsPerCurve >= 0)
				{
					float num3 = tension - 6f;
					float num4 = tension - 3f;
					float num5 = num2 - tension;
					float num6 = tension * num;
					float num7 = tension * -0.5f;
					float num8 = tension - num2;
					object obj8 = 0;
					int num9 = stepsPerCurve;
					bool flag2;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm4,edi\"");
						int num10 = 0 / num9;
						float num11 = num6 * (float)num10;
						object obj9 = num10 * num10;
						object obj10 = obj9 * num10;
						float num12 = (float)obj9 * tension;
						float num13 = num7 * (float)obj10;
						float num14 = num13 + num12;
						float num15 = num14 - num11;
						float num16 = (float)float5 * num15;
						float num17 = (float)obj9 * num;
						float num18 = (float)obj10 * num;
						float num19 = num17 * num3;
						float num20 = num18 * num5;
						float num21 = num19 + 1f;
						float num22 = num21 + num20;
						float num23 = (float)whipVerletNode3.position * num22;
						float num24 = num23 + num16;
						float num25 = (float)obj10 * 0.5f;
						float num26 = num6 * (float)num10;
						float num27 = num25 * num8;
						float num28 = num4 * (float)obj9;
						float num29 = num27 + num26;
						float num30 = num29 - num28;
						float num31 = (float)whipVerletNode4.position * num30;
						float num32 = num31 + num24;
						list._002Ector();
						obj8++;
						flag2 = (nint)obj8 <= stepsPerCurve;
						num9 = stepsPerCurve;
						float5 = float6;
						num = 0.5f;
					}
					while (flag2);
					nint num33 = 0;
					num = 0.5f;
					num2 = 4f;
				}
				obj++;
				obj2 = obj;
				continue;
			}
			return list;
		}
		return (List<Vector2>)(object)new IndexOutOfRangeException();
	}

	public override void Despawn()
	{
		//IL_0032: Expected O, but got I4
		//IL_003b: Expected O, but got I4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		if (_nodeProjectiles != null)
		{
			Projectile[] nodeProjectiles = _nodeProjectiles;
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj < nodeProjectiles.Length)
			{
				Projectile[] nodeProjectiles2 = _nodeProjectiles;
				nodeProjectiles2[obj2].Despawn();
				nodeProjectiles = _nodeProjectiles;
				obj2++;
				obj = obj2;
			}
			_nodeProjectiles = null;
		}
		base.Despawn();
	}

	public TP_WhipCore_Projectile()
	{
		//IL_0017: Expected O, but got I4
		_gravity = (float2)0;
		_ = 3248488448L;
		_flipNum = 1f;
		_whipSize = 1f;
		_timeStartAttack = 500f;
		_timeFadeOut = 100f;
		_delayFadeOut = 400f;
		_timeLerpRatio = 100f;
		base._002Ector();
	}
}
