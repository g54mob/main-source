using System;
using System.Collections.Generic;
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

public class Unused_TP_DragonWater1_Projectile : TP_WhipCore_Projectile
{
	[NonSerialized]
	public float LineAlpha;

	private MultiTargetTween _lineTween;

	[NonSerialized]
	public float LerpRatio;

	private MultiTargetTween _lerpTween;

	private Timer _despawnTimer;

	private List<Vector2> _waypointList;

	private int _attackCount;

	private int _attackAmount;

	protected override void Awake()
	{
		base.Awake();
		_timeStartAttack = 0f;
		_timeFadeOut = 100f;
		_delayFadeOut = 400f;
		_timeLerpRatio = 500f;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		((Projectile)this).InitProjectile(pool, weapon, index);
		_isCullable = false;
		base.InitWhips();
		LineAlpha = 1f;
		_attackCount = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 19 Invalid \"Jump target not found in method: 0x1871B5EA0\"");
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

	private void OnWhipStart()
	{
		//IL_002f: Expected O, but got I4
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_0062: Expected O, but got I4
		Weapon weapon = _weapon;
		bool flag = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
		object obj = (flag ? 1 : 0) ^ 1;
		object obj2 = obj * 2;
		float flipNum = (float)obj2 - 1f;
		_flipNum = flipNum;
		_gravity = (float2)0;
		_ = 1092616192;
		_applyNodeControl = true;
		bodyEnabled(enable: true);
	}

	private void OnWhipComplete()
	{
		//IL_02ad: Expected O, but got I4
		//IL_00f9: Expected I, but got O
		//IL_0234: Expected I, but got O
		_gravity = (float2)0;
		_ = 3248488448L;
		if (_attackCount >= _attackAmount)
		{
			Projectile[] nodeProjectiles = _nodeProjectiles;
			_applyNodeControl = false;
			bool flag = false;
			bool flag2 = false;
			while ((flag ? 1 : 0) < nodeProjectiles.Length)
			{
				Projectile[] nodeProjectiles2 = _nodeProjectiles;
				Projectile projectile = nodeProjectiles2[flag2 ? 1u : 0u];
				BaseBody baseBody = projectile.body;
				flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
				baseBody._enable = false;
				nodeProjectiles = _nodeProjectiles;
				flag = flag2;
			}
			if (_lineTween != null)
			{
				_lineTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
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
			tweenConfig.duration = _timeFadeOut;
			tweenConfig.delay = _delayFadeOut;
			MultiTargetTween lineTween = Tweens.Add(tweenConfig);
			_lineTween = lineTween;
			if (_indexInWeapon != 2)
			{
				if (_despawnTimer != null)
				{
					_despawnTimer.Cancel();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v685 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Unused_TP_DragonWater1_Projectile>)+370]");
				Action onComplete = new Action(this, (IntPtr)0);
				nint num2 = (nint)this;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer despawnTimer = Timers.Register(2.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_despawnTimer = despawnTimer;
			}
		}
		else
		{
			int attackCount = _attackCount + 1;
			_attackCount = attackCount;
			startAttack(0f);
		}
	}

	private void StartOrbTracker()
	{
	}

	private void StepOrbTracker()
	{
	}

	private void CompleteOrbTracker()
	{
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
		//IL_011e: Expected O, but got I4
		//IL_0138: Expected O, but got I4
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		//IL_0181: Expected O, but got I4
		//IL_01ce: Expected O, but got I
		//IL_025e: Expected O, but got F4
		WhipVerletNode[] nodes = _nodes;
		WhipVerletNode whipVerletNode = nodes[0];
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float6 = _characterOffset + float5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.Unused_TP_DragonWater1_Projectile)+100]");
		object obj2 = default(object);
		object obj = 0 + obj2;
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
		object obj5 = nodes4.Length;
		WhipVerletNode[] nodes5 = _nodes;
		object obj6 = nodes4.Length - 1;
		WhipVerletNode whipVerletNode3 = nodes5[obj6];
		whipVerletNode3.isStatic = _applyNodeControl;
		WhipVerletNode[] nodes6 = _nodes;
		object obj7 = nodes4.Length - 1;
		WhipVerletNode whipVerletNode4 = nodes6[obj7];
		if (whipVerletNode4.isStatic)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rcx_v8 (VampireSurvivors.Objects.Projectiles.WhipVerletNode[])+18+v54 @ rdx_v6*8]");
			WhipVerletNode whipVerletNode5 = (WhipVerletNode)0;
			WhipVerletNode whipVerletNode6 = nodes6[0];
			float2 float7 = MultiLerp(_waypointList, LerpRatio);
			float num = (float)obj2 * -1f;
			float num2 = _flipNum * (float)float7;
			float num3 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rcx_v10 (VampireSurvivors.Objects.Projectiles.WhipVerletNode)+14]");
			float num4 = num3 + 0f;
			float num5 = num2 + (float)whipVerletNode6.position;
			whipVerletNode5.position = (float2)num5;
		}
	}

	protected override float CalculateIndexNodeDistance(int index)
	{
		WhipVerletNode[] nodes = _nodes;
		float num = _nodeDistance / (float)nodes.Length;
		float num2 = num * (float)index;
		return num2 + 0.1f;
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
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		base.Despawn();
	}

	public Unused_TP_DragonWater1_Projectile()
	{
		Vector2 item = default(Vector2);
		_waypointList = new List<Vector2>
		{
			item, item, item, item, item, item, item, item, item, item,
			item, item, item, item, item, item, item, item, item, item,
			item, item, item, item, item
		};
		base._002Ector();
	}
}
