using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Lemuria1Spike_Projectile : Projectile
{
	public LineRenderer _lineRenderer;

	protected MultiTargetTween _alphaTween;

	[NonSerialized]
	public float LineAlpha;

	protected MultiTargetTween _lineTween;

	[NonSerialized]
	public float LineRatio;

	private float _spikeHeight;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_02f9: Expected O, but got I4
		//IL_0302: Expected O, but got I4
		//IL_0343: Expected O, but got I4
		//IL_0054: Expected O, but got I4
		//IL_03b7: Expected I4, but got O
		//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Expected O, but got Unknown
		//IL_03fc: Expected I, but got O
		//IL_0412: Expected O, but got I
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected O, but got Unknown
		//IL_0230: Expected I, but got O
		//IL_0446: Expected O, but got I4
		//IL_045d: Expected I, but got I8
		//IL_020c: Expected I, but got I8
		//IL_0263->IL0263: Incompatible stack heights: 1 vs 0
		//IL_003b->IL03ea: Incompatible stack heights: 6 vs 2
		Weapon weapon2 = default(Weapon);
		while (true)
		{
			base.InitProjectile(pool, weapon2, index);
			object lineRenderer = _lineRenderer;
			bool flag = (object)_lineRenderer == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rbx_v2 (System.Object)+10]");
			if ((nint)0 != 0)
			{
				break;
			}
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_lineRenderer);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rbx_v2 (System.Object)+10]");
		LineRenderer.set_positionCount_Injected((IntPtr)0, 2);
		object lineRenderer2 = _lineRenderer;
		bool flag2 = (object)_lineRenderer == null;
		object obj = 0;
		object obj2 = 0;
		Vector3 vector = default(Vector3);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rbx_v11 (System.Object)+10]");
			bool flag3 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rbx_v11 (System.Object)+10]");
			object obj3 = LineRenderer.get_positionCount_Injected((IntPtr)0);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
			{
				break;
			}
			object lineRenderer3 = _lineRenderer;
			bool flag4 = (object)_lineRenderer == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rbx_v14 (System.Object)+10]");
			bool flag5 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rbx_v14 (System.Object)+10]");
			LineRenderer.SetPosition_Injected((IntPtr)0, (int)obj, ref vector);
			lineRenderer2 = _lineRenderer;
			obj++;
			bool flag6 = (object)_lineRenderer == null;
			obj2 = obj;
		}
		LineAlpha = 1f;
		object obj4 = 10 - index;
		LineRatio = 0f;
		bool flag7 = _lineTween == null;
		float spikeHeight = (float)obj4 * 0.049999997f;
		_spikeHeight = spikeHeight;
		if (!flag7)
		{
			_lineTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		bool flag8 = array == null;
		object obj5 = array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj6 = default(object);
		bool flag9 = obj6 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		bool flag10 = tweenConfig == null;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		bool flag11 = dictionary == null;
		object value = default(object);
		bool flag12 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"LineRatio", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		_ = 6;
		_ = 1120403456;
		TweenCallback tweenCallback = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ r10_v1 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback).method = (nint)__ldftn(TP_Lemuria1Spike_Projectile.OnLineComplete);
		((Delegate)tweenCallback).m_target = this;
		((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ r10_v1 (Il2CppMethodInfo)+4C]");
		object obj7 = (nint)0 >> 4;
		object obj8 = obj7 & 1;
		nint num2;
		if (obj8 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ r10_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num2 = unchecked((nint)6447293664L);
				goto IL_043d;
			}
		}
		num2 = ((Delegate)tweenCallback).method_ptr;
		((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
		goto IL_043d;
		IL_043d:
		object obj9 = 24;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		MultiTargetTween lineTween = Tweens.Add(tweenConfig);
		_lineTween = lineTween;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_00a1: Expected O, but got Ref
		//IL_00a6->IL00d9: Incompatible stack heights: 1 vs 0
		LineRenderer lineRenderer = _lineRenderer;
		if ((object)_lineRenderer != null && ((UnityEngine.Object)lineRenderer).m_CachedPtr != (IntPtr)0)
		{
			object lineRenderer2 = _lineRenderer;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdi_v4 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdi_v4 (System.Object)+10]");
			Vector3 vector = default(Vector3);
			LineRenderer.SetPosition_Injected((IntPtr)0, 1, ref vector);
			Material material = ((Renderer)_lineRenderer).GetMaterial();
			Color color = material.GetColor("_Color");
			Material material2 = ((Renderer)_lineRenderer).GetMaterial();
			float num = default(float);
			material2.SetColor("_Color", (Color)(&num));
		}
	}

	private void OnLineComplete()
	{
		//IL_003f: Expected I, but got O
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
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
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"LineAlpha", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.duration = 1000f;
			TweenCallback onComplete = delegate
			{
				Despawn();
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
			_alphaTween = alphaTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public override void Despawn()
	{
		if (_lineTween != null)
		{
			_lineTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		base.Despawn();
	}

	private void _003COnLineComplete_003Eb__8_0()
	{
		Despawn();
	}
}
