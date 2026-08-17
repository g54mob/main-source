using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Unused_TP_Lemuria1_Projectile : TP_WhipCore_Projectile
{
	[NonSerialized]
	public float LineAlpha;

	private MultiTargetTween _lineTween;

	[NonSerialized]
	public float LerpRatio;

	private MultiTargetTween _lerpTween;

	private List<Vector2> _waypointList;

	private Timer _spikeTimer;

	private float2 _spikePosition;

	private int _attackCount;

	private int _attackAmount;

	protected override float WhipLength()
	{
		float num = _weapon.PArea();
		object obj = default(object);
		float num2 = (float)obj * 1.25f;
		bool flag = !(3.14f > num2);
		float result = 3.14f;
		if (!flag)
		{
			result = num2;
		}
		return result;
	}

	protected override void Awake()
	{
		base.Awake();
		_timeStartAttack = 0f;
		_timeLerpRatio = 200f;
		_timeFadeOut = 100f;
		_delayFadeOut = 400f;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		((Projectile)this).InitProjectile(pool, weapon, index);
		_isCullable = false;
		base.InitWhips();
		List<Vector2> list = new List<Vector2>();
		Vector2 item = default(Vector2);
		list.Add(item);
		list.Add(item);
		list.Add(item);
		list.Add(item);
		list.Add(item);
		list.Add(item);
		list.Add(item);
		list.Add(item);
		list.Add(item);
		list.Add(item);
		list.Add(item);
		list.Add(item);
		list.Add(item);
		_waypointList = list;
		LineAlpha = 1f;
		_attackCount = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 259 Invalid \"Jump target not found in method: 0x1871B7A40\"");
		throw new NullReferenceException();
	}

	private void startAttack(float delay)
	{
		//IL_003f: Expected I, but got O
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
			tweenConfig.ease = Ease.OutQuad;
			tweenConfig.delay = delay;
			tweenConfig.duration = _timeLerpRatio;
			TweenCallback onComplete = OnWhipComplete;
			tweenConfig.onComplete = onComplete;
			TweenCallback onStart = OnWhipStart;
			tweenConfig.onStart = onStart;
			MultiTargetTween lerpTween = Tweens.Add(tweenConfig);
			_lerpTween = lerpTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
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
			nint num = (nint)typeof(Unused_TP_Lemuria1_Weapon);
			nint num2 = (nint)weapon;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_Lemuria1_Weapon>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_Lemuria1_Weapon>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v5+FFFFFFF8+v46 @ rax_v4*8]");
				if (0 == (nint)typeof(Unused_TP_Lemuria1_Weapon))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_Lemuria1_Weapon>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v5+FFFFFFF8+v88 @ rcx_v4*8]");
					object obj4 = 0 - typeof(Unused_TP_Lemuria1_Weapon);
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
		//IL_0015: Expected O, but got I4
		//IL_0069: Expected I, but got O
		//IL_0071: Expected I, but got O
		//IL_0081: Expected O, but got I
		//IL_00bd: Expected O, but got I
		//IL_00fa: Expected O, but got I
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		//IL_03ad: Invalid comparison between I4 and F4
		//IL_03be: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Expected O, but got Unknown
		//IL_01a8: Expected I, but got O
		//IL_0274: Expected I, but got O
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Expected O, but got Unknown
		WhipVerletNode[] nodes = _nodes;
		object obj = nodes.Length - 1;
		WhipVerletNode whipVerletNode = nodes[obj];
		Weapon weapon = _weapon;
		_spikePosition = whipVerletNode.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v7 (VampireSurvivors.Objects.Projectiles.WhipVerletNode)+14]");
		_ = 0;
		nint num = (nint)typeof(Unused_TP_Lemuria1_Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_Lemuria1_Weapon>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_Lemuria1_Weapon>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rax_v13+FFFFFFF8+v141 @ rax_v12*8]");
			if (0 == (nint)typeof(Unused_TP_Lemuria1_Weapon))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_Lemuria1_Weapon>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rax_v13+FFFFFFF8+v439 @ rcx_v9*8]");
				object obj5 = 0 - typeof(Unused_TP_Lemuria1_Weapon);
				bool flag = obj5 == null;
				bool flag2 = !flag;
				Unused_TP_Lemuria1_Weapon unused_TP_Lemuria1_Weapon = null;
				if (!flag2)
				{
					unused_TP_Lemuria1_Weapon = (Unused_TP_Lemuria1_Weapon)weapon;
				}
				bool flag3 = 0f < _flipNum;
				object obj6 = 0 - _flipNum;
				bool flag4 = obj6 == null;
				bool flag5 = !flag3;
				bool flag6 = !flag4;
				bool flag7 = flag6 & flag5;
				Vector2 spikePos = default(Vector2);
				unused_TP_Lemuria1_Weapon.FireSpikes(spikePos, flag7);
				if (_attackCount >= _attackAmount)
				{
					if (_lineTween != null)
					{
						_lineTween.Kill();
					}
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					nint num4 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj7 = default(object);
					if (obj7 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					tweenConfig.targets = array;
					Dictionary<string, object> dictionary = new Dictionary<string, object>();
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					object value = default(object);
					bool flag8 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"LineAlpha", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
					tweenConfig.custom = dictionary;
					tweenConfig.duration = _timeFadeOut;
					tweenConfig.delay = _delayFadeOut;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v679 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Unused_TP_Lemuria1_Projectile>)+370]");
					TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
					nint num5 = (nint)this;
					tweenConfig.onComplete = onComplete;
					MultiTargetTween lineTween = Tweens.Add(tweenConfig);
					_lineTween = lineTween;
					Projectile[] nodeProjectiles = _nodeProjectiles;
					_applyNodeControl = false;
					Unused_TP_Lemuria1_Weapon unused_TP_Lemuria1_Weapon2 = null;
					Unused_TP_Lemuria1_Weapon unused_TP_Lemuria1_Weapon3 = null;
					while ((nint)unused_TP_Lemuria1_Weapon3 < nodeProjectiles.Length)
					{
						Projectile[] nodeProjectiles2 = _nodeProjectiles;
						Projectile projectile = nodeProjectiles2[(object)unused_TP_Lemuria1_Weapon2];
						BaseBody baseBody = projectile.body;
						unused_TP_Lemuria1_Weapon2 = (Unused_TP_Lemuria1_Weapon)(unused_TP_Lemuria1_Weapon2 + 1);
						baseBody._enable = false;
						nodeProjectiles = _nodeProjectiles;
						unused_TP_Lemuria1_Weapon3 = unused_TP_Lemuria1_Weapon2;
					}
				}
				else
				{
					int attackCount = _attackCount + 1;
					_attackCount = attackCount;
					startAttack(0f);
				}
				return;
			}
		}
		throw new NullReferenceException();
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
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_014e: Expected O, but got I4
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		//IL_0183: Expected O, but got I4
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected O, but got Unknown
		WhipVerletNode[] nodes = _nodes;
		WhipVerletNode whipVerletNode = nodes[0];
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float6 = float5 + _characterOffset;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.Unused_TP_Lemuria1_Projectile)+100]");
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
		object obj5 = nodes4.Length * LerpRatio;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		WhipVerletNode[] nodes5 = _nodes;
		object obj6 = nodes5.Length - 1;
		object obj7 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6))
		{
			obj6 = obj7;
		}
		WhipVerletNode[] nodes6 = _nodes;
		if ((nint)obj6 < 4)
		{
			obj6 = 4;
		}
		WhipVerletNode whipVerletNode3 = nodes6[obj6];
		whipVerletNode3.isStatic = _applyNodeControl;
		WhipVerletNode[] nodes7 = _nodes;
		WhipVerletNode whipVerletNode4 = nodes7[obj6];
		if (whipVerletNode4.isStatic)
		{
			WhipVerletNode whipVerletNode5 = nodes7[obj6];
			WhipVerletNode whipVerletNode6 = nodes7[0];
			float2 float7 = MultiLerp(_waypointList, LerpRatio);
			float num = (float)obj2 * -1f;
			object obj8 = float7 * _flipNum;
			float num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rcx_v9 (VampireSurvivors.Objects.Projectiles.WhipVerletNode)+14]");
			float num3 = num2 + 0f;
			float2 float8 = (float2)((object)whipVerletNode6.position + obj8);
			whipVerletNode5.position = float8;
		}
	}

	protected override float CalculateIndexNodeDistance(int index)
	{
		WhipVerletNode[] nodes = _nodes;
		float num = _nodeDistance / (float)nodes.Length;
		float num2 = num * (float)index;
		return num2 + 0.125f;
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
		if (_spikeTimer != null)
		{
			_spikeTimer.Cancel();
		}
		base.Despawn();
	}

	public Unused_TP_Lemuria1_Projectile()
	{
		Vector2 item = default(Vector2);
		_waypointList = new List<Vector2>
		{
			item, item, item, item, item, item, item, item, item, item,
			item, item, item
		};
		base._002Ector();
	}
}
