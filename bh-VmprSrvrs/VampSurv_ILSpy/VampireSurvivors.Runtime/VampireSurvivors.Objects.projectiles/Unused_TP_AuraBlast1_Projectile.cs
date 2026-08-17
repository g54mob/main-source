using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Unused_TP_AuraBlast1_Projectile : TP_WhipCore_Projectile
{
	[NonSerialized]
	public float LineAlpha;

	private MultiTargetTween _lineTween;

	[NonSerialized]
	public float LerpRatio;

	private MultiTargetTween _lerpTween;

	[NonSerialized]
	public float Lerp2Ratio;

	private MultiTargetTween _lerp2Tween;

	private List<Vector2> _waypointList;

	private List<Vector2> _waypoint2List;

	private int _attackCount;

	private int _attackAmount;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		((Projectile)this).InitProjectile(pool, weapon, index);
		_isCullable = false;
		base.InitWhips();
		LineAlpha = 1f;
		_attackCount = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 19 Invalid \"Jump target not found in method: 0x1871B40E0\"");
	}

	private void startAttack(int delay)
	{
		//IL_003f: Expected I, but got O
		//IL_00fb: Expected F4, but got I4
		//IL_01d0: Expected I, but got O
		//IL_028c: Expected F4, but got I4
		bool flag = _lerpTween == null;
		LerpRatio = 0f;
		if (!flag)
		{
			_lerpTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"LerpRatio", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.ease = Ease.OutSine;
			tweenConfig.duration = 400f;
			tweenConfig.delay = delay;
			TweenCallback onComplete = OnWhipComplete;
			tweenConfig.onComplete = onComplete;
			TweenCallback onStart = OnWhipStart;
			tweenConfig.onStart = onStart;
			MultiTargetTween lerpTween = Tweens.Add(tweenConfig);
			_lerpTween = lerpTween;
			bool flag3 = _lerp2Tween == null;
			Lerp2Ratio = 0f;
			if (!flag3)
			{
				_lerp2Tween.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value2 = default(object);
				bool flag4 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"Lerp2Ratio", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				tweenConfig2.custom = dictionary2;
				tweenConfig2.ease = Ease.Linear;
				tweenConfig2.duration = 375f;
				tweenConfig2.delay = delay;
				MultiTargetTween lerp2Tween = Tweens.Add(tweenConfig2);
				_lerp2Tween = lerp2Tween;
				return;
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	private void OnWhipStart()
	{
		//IL_002f: Expected O, but got I4
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		Weapon weapon = _weapon;
		bool flag = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
		object obj = (flag ? 1 : 0) ^ 1;
		object obj2 = obj * 2;
		float flipNum = (float)obj2 - 1f;
		_flipNum = flipNum;
		_applyNodeControl = true;
		bodyEnabled(enable: true);
	}

	private void OnWhipComplete()
	{
		//IL_005b: Expected O, but got I4
		//IL_0093: Expected O, but got I
		//IL_00e7: Expected I, but got O
		//IL_00ef: Expected I, but got O
		//IL_00ff: Expected O, but got I
		//IL_013b: Expected O, but got I
		//IL_0178: Expected O, but got I
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected O, but got Unknown
		//IL_02da: Expected I, but got O
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Expected O, but got Unknown
		WhipVerletNode[] nodes = _nodes;
		float num = (float)nodes.Length * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		object obj = default(object);
		WhipVerletNode whipVerletNode = nodes[obj];
		WhipVerletNode[] nodes2 = _nodes;
		object obj2 = nodes2.Length - 1;
		WhipVerletNode whipVerletNode2 = nodes2[obj2];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v5 (VampireSurvivors.Objects.Projectiles.WhipVerletNode)+14]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rcx_v6 (VampireSurvivors.Objects.Projectiles.WhipVerletNode)+14]");
		object obj3 = num2 - 0;
		Weapon weapon = _weapon;
		float num3 = (float)obj3 * 0.5f;
		float num4 = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rcx_v6 (VampireSurvivors.Objects.Projectiles.WhipVerletNode)+14]");
		float num5 = num4 + 0f;
		float num6 = num5 + 0.14999999f;
		nint num7 = (nint)typeof(Unused_TP_AuraBlast1_Weapon);
		nint num8 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_AuraBlast1_Weapon>)+130]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_AuraBlast1_Weapon>)+130]");
		if (num9 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v15+FFFFFFF8+v121 @ rax_v14*8]");
			if (0 == (nint)typeof(Unused_TP_AuraBlast1_Weapon))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_AuraBlast1_Weapon>)+130]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v15+FFFFFFF8+v473 @ rcx_v9*8]");
				object obj7 = 0 - typeof(Unused_TP_AuraBlast1_Weapon);
				bool flag = obj7 == null;
				bool flag2 = !flag;
				Unused_TP_AuraBlast1_Weapon unused_TP_AuraBlast1_Weapon = null;
				if (!flag2)
				{
					unused_TP_AuraBlast1_Weapon = (Unused_TP_AuraBlast1_Weapon)weapon;
				}
				float2 pos = default(float2);
				Projectile projectile = unused_TP_AuraBlast1_Weapon.CreateSlamProjectile(pos);
				if (_attackCount >= _attackAmount)
				{
					Projectile[] nodeProjectiles = _nodeProjectiles;
					_applyNodeControl = false;
					Unused_TP_AuraBlast1_Weapon unused_TP_AuraBlast1_Weapon2 = null;
					Unused_TP_AuraBlast1_Weapon unused_TP_AuraBlast1_Weapon3 = null;
					while ((nint)unused_TP_AuraBlast1_Weapon3 < nodeProjectiles.Length)
					{
						Projectile[] nodeProjectiles2 = _nodeProjectiles;
						Projectile projectile2 = nodeProjectiles2[(object)unused_TP_AuraBlast1_Weapon2];
						BaseBody baseBody = projectile2.body;
						unused_TP_AuraBlast1_Weapon2 = (Unused_TP_AuraBlast1_Weapon)(unused_TP_AuraBlast1_Weapon2 + 1);
						baseBody._enable = false;
						nodeProjectiles = _nodeProjectiles;
						unused_TP_AuraBlast1_Weapon3 = unused_TP_AuraBlast1_Weapon2;
					}
					if (_lineTween != null)
					{
						_lineTween.Kill();
					}
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					nint num10 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj8 = default(object);
					if (obj8 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					tweenConfig.targets = array;
					Dictionary<string, object> dictionary = new Dictionary<string, object>();
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					object value = default(object);
					bool flag3 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"LineAlpha", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
					tweenConfig.custom = dictionary;
					tweenConfig.duration = 2000f;
					tweenConfig.delay = 500f;
					TweenCallback onComplete = delegate
					{
						Despawn();
					};
					tweenConfig.onComplete = onComplete;
					MultiTargetTween lineTween = Tweens.Add(tweenConfig);
					_lineTween = lineTween;
				}
				else
				{
					int attackCount = _attackCount + 1;
					_attackCount = attackCount;
					startAttack(0);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	protected override Projectile CreateNodeProjectile(float2 pos)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_0067: Expected O, but got I
		//IL_00a4: Expected O, but got I
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			nint num = (nint)typeof(Unused_TP_AuraBlast1_Weapon);
			nint num2 = (nint)weapon;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_AuraBlast1_Weapon>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_AuraBlast1_Weapon>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v5+FFFFFFF8+v46 @ rax_v4*8]");
				if (0 == (nint)typeof(Unused_TP_AuraBlast1_Weapon))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_AuraBlast1_Weapon>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v5+FFFFFFF8+v88 @ rcx_v4*8]");
					object obj4 = 0 - typeof(Unused_TP_AuraBlast1_Weapon);
					bool flag = obj4 == null;
					bool flag2 = !flag;
					TP_WhipCore1_Weapon tP_WhipCore1_Weapon = null;
					if (!flag2)
					{
						tP_WhipCore1_Weapon = (TP_WhipCore1_Weapon)_weapon;
					}
					float area = default(float);
					return tP_WhipCore1_Weapon.CreateNodeProjectile(pos, 0, 1, area);
				}
			}
		}
		return (Projectile)(object)new NullReferenceException();
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0062: Expected O, but got I4
		//IL_043b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0440: Expected O, but got Unknown
		//IL_044b: Expected O, but got I4
		//IL_00c9: Expected O, but got I4
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected I4, but got Unknown
		//IL_01ca: Expected O, but got I
		//IL_0491: Unknown result type (might be due to invalid IL or missing references)
		//IL_0496: Expected O, but got Unknown
		//IL_029a: Expected I4, but got O
		//IL_04ef: Expected I4, but got O
		//IL_0501: Expected O, but got Ref
		//IL_0192->IL0425: Incompatible stack heights: 1 vs 0
		//IL_01ea->IL0425: Incompatible stack heights: 2 vs 0
		//IL_0234->IL0425: Incompatible stack heights: 3 vs 0
		//IL_04b0->IL0425: Incompatible stack heights: 3 vs 0
		//IL_0334->IL0506: Incompatible stack heights: 3 vs 0
		//IL_060e->IL0425: Incompatible stack heights: 1 vs 0
		//IL_02c8->IL0425: Incompatible stack heights: 3 vs 0
		//IL_02ea->IL0425: Incompatible stack heights: 3 vs 0
		//IL_066e->IL0425: Incompatible stack heights: 2 vs 0
		//IL_0506->IL047e: Incompatible stack heights: 5 vs 3
		//IL_06ac->IL054b: Incompatible stack heights: 3 vs 0
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			bool flag = (object)((Equipment)weapon)._003COwner_003Ek__BackingField == null;
			if (!flag)
			{
				float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
				base.position = float5;
				ApplyGravity();
				ApplyManualNodeControl();
				object obj = 5;
				object obj2;
				do
				{
					ApplyVerletConstraints();
					obj--;
					obj2 = !flag;
				}
				while (obj2 != null);
				Projectile[] nodeProjectiles = _nodeProjectiles;
				if (_nodeProjectiles != null)
				{
					WhipVerletNode[] nodes = _nodes;
					if (_nodes != null)
					{
						object obj3 = nodes.Length - 1;
						object obj4 = nodeProjectiles.Length / obj3;
						int stepsPerCurve = obj4 - 1;
						List<Vector2> list = TP_WhipCore_Projectile.GenerateSpline(_nodes, stepsPerCurve, 0.5f);
						Projectile[] nodeProjectiles2 = _nodeProjectiles;
						if (_nodeProjectiles != null)
						{
							object obj5 = obj;
							float2 float6 = default(float2);
							float2 ret = default(float2);
							Color value = default(Color);
							while (true)
							{
								if ((nint)obj5 < nodeProjectiles2.Length)
								{
									Projectile[] nodeProjectiles3 = _nodeProjectiles;
									if (_nodeProjectiles == null)
									{
										break;
									}
									bool flag2 = (nint)obj >= nodeProjectiles3.Length;
									if (list == null)
									{
										break;
									}
									object obj6 = obj;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v43 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
									bool flag3 = (nint)obj6 >= 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v43 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
									object obj7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v43 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
									if ((nint)0 == 0)
									{
										break;
									}
									object obj8 = obj;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rdx_v41+18]");
									bool flag4 = (nint)obj8 >= 0;
									if ((object)nodeProjectiles3[obj] == null)
									{
										break;
									}
									nodeProjectiles3[obj].position = float6;
									LineRenderer lineRenderer = _lineRenderer;
									if ((object)_lineRenderer != null && ((UnityEngine.Object)lineRenderer).m_CachedPtr != (IntPtr)0)
									{
										int num = (int)_lineRenderer;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
										Weapon weapon2 = _weapon;
										if ((object)_weapon == null || (object)((Equipment)weapon2)._003COwner_003Ek__BackingField == null)
										{
											break;
										}
										float2 float7 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
										bool flag5 = (object)_lineRenderer == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbp_v18 (System.Int32)+10]");
										bool flag6 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rbp_v18 (System.Int32)+10]");
										LineRenderer.SetPosition_Injected((IntPtr)0, (int)obj, ref *(Vector3*)(&ret));
										ret = float6;
										obj3 = (object)(&ret);
									}
									nodeProjectiles2 = _nodeProjectiles;
									obj++;
									if (_nodeProjectiles == null)
									{
										break;
									}
									obj5 = obj;
									continue;
								}
								LineRenderer lineRenderer2 = _lineRenderer;
								if ((object)_lineRenderer != null && ((UnityEngine.Object)lineRenderer2).m_CachedPtr != (IntPtr)0)
								{
									object lineRenderer3 = _lineRenderer;
									if ((object)_lineRenderer == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rbx_v21 (System.Object)+10]");
									if ((nint)0 == 0)
									{
										UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_lineRenderer);
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rbx_v21 (System.Object)+10]");
									IntPtr material_Injected = Renderer.GetMaterial_Injected((IntPtr)0);
									Material material = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Material>(material_Injected);
									if ((object)material == null)
									{
										break;
									}
									int num2 = Shader.PropertyToID("_Color");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rax_v56 (UnityEngine.Material)+10]");
									bool flag7 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rax_v56 (UnityEngine.Material)+10]");
									Material.GetColorImpl_Injected((IntPtr)0, num2, out *(Color*)(&ret));
									object lineRenderer4 = _lineRenderer;
									if ((object)_lineRenderer == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rbx_v23 (System.Object)+10]");
									bool flag8 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rbx_v23 (System.Object)+10]");
									IntPtr material_Injected2 = Renderer.GetMaterial_Injected((IntPtr)0);
									Material material2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Material>(material_Injected2);
									if ((object)material2 == null)
									{
										break;
									}
									int num3 = Shader.PropertyToID("_Color");
									bool flag9 = ((UnityEngine.Object)material2).m_CachedPtr == (IntPtr)0;
									Material.SetColorImpl_Injected(((UnityEngine.Object)material2).m_CachedPtr, num3, ref value);
								}
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void ApplyManualNodeControl()
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_009f: Expected O, but got I4
		//IL_00a8: Expected O, but got I4
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		//IL_0246: Expected O, but got I4
		//IL_0260: Expected O, but got I4
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Expected O, but got Unknown
		//IL_02a9: Expected O, but got I4
		//IL_02f6: Expected O, but got I
		//IL_0386: Expected O, but got F4
		WhipVerletNode[] nodes = _nodes;
		WhipVerletNode whipVerletNode = nodes[0];
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float6 = float5 + _characterOffset;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.Unused_TP_AuraBlast1_Projectile)+100]");
		object obj2 = default(object);
		object obj = obj2 + 0;
		whipVerletNode.position = float6;
		WhipVerletNode[] nodes2 = _nodes;
		WhipVerletNode[] nodes3 = _nodes;
		object obj3 = 1;
		object obj4 = 1;
		while ((nint)obj3 < nodes2.Length)
		{
			WhipVerletNode whipVerletNode2 = nodes3[obj4];
			whipVerletNode2.isStatic = false;
			obj4++;
			nodes3 = _nodes;
			obj3 = obj4;
			nodes2 = _nodes;
		}
		WhipVerletNode[] nodes4 = _nodes;
		float num = (float)nodes4.Length * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		WhipVerletNode[] nodes5 = _nodes;
		object obj5 = default(object);
		WhipVerletNode whipVerletNode3 = nodes5[obj5];
		whipVerletNode3.isStatic = _applyNodeControl;
		WhipVerletNode[] nodes6 = _nodes;
		WhipVerletNode whipVerletNode4 = nodes6[obj5];
		if (whipVerletNode4.isStatic)
		{
			WhipVerletNode whipVerletNode5 = nodes6[0];
			float2 float7 = MultiLerp(_waypointList, LerpRatio);
			object obj6 = float7 * _flipNum;
			float num2 = (float)obj2 * -1f;
			float2 float8 = (float2)(obj6 + (object)whipVerletNode5.position);
			float num3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rcx_v14 (VampireSurvivors.Objects.Projectiles.WhipVerletNode)+14]");
			float num4 = num3 + 0f;
			whipVerletNode4.position = float8;
		}
		WhipVerletNode[] nodes7 = _nodes;
		object obj7 = nodes7.Length;
		WhipVerletNode[] nodes8 = _nodes;
		object obj8 = nodes7.Length - 1;
		WhipVerletNode whipVerletNode6 = nodes8[obj8];
		whipVerletNode6.isStatic = _applyNodeControl;
		WhipVerletNode[] nodes9 = _nodes;
		object obj9 = nodes7.Length - 1;
		WhipVerletNode whipVerletNode7 = nodes9[obj9];
		if (whipVerletNode7.isStatic)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v10 (VampireSurvivors.Objects.Projectiles.WhipVerletNode[])+18+v63 @ rdx_v8*8]");
			WhipVerletNode whipVerletNode8 = (WhipVerletNode)0;
			WhipVerletNode whipVerletNode9 = nodes9[0];
			float2 float9 = MultiLerp(_waypoint2List, Lerp2Ratio);
			float num5 = (float)obj2 * -1f;
			float num6 = _flipNum * (float)float9;
			float num7 = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rcx_v12 (VampireSurvivors.Objects.Projectiles.WhipVerletNode)+14]");
			float num8 = num7 + 0f;
			float num9 = num6 + (float)whipVerletNode9.position;
			whipVerletNode8.position = (float2)num9;
		}
	}

	protected override float CalculateIndexNodeDistance(int index)
	{
		WhipVerletNode[] nodes = _nodes;
		float num = _nodeDistance / (float)nodes.Length;
		float num2 = num * (float)index;
		return num2 + 0.15f;
	}

	public override void Despawn()
	{
		if (_lineTween != null)
		{
			_lineTween.Kill();
		}
		if (_lerpTween != null)
		{
			_lerpTween.Kill();
		}
		base.Despawn();
	}

	public Unused_TP_AuraBlast1_Projectile()
	{
		Vector2 item = default(Vector2);
		_waypointList = new List<Vector2>
		{
			item, item, item, item, item, item, item, item, item, item,
			item, item, item, item, item, item
		};
		_waypoint2List = new List<Vector2>
		{
			item, item, item, item, item, item, item, item, item, item,
			item, item, item, item
		};
		base._002Ector();
	}

	private void _003COnWhipComplete_003Eb__13_0()
	{
		Despawn();
	}
}
