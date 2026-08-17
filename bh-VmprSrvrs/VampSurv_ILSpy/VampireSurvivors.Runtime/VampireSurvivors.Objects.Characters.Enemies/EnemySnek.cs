using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemySnek : EnemyController
{
	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0211: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0157: Expected O, but got I
		//IL_026c: Expected O, but got I4
		//IL_017d: Expected O, but got I
		base.InitEnemy(enemyType, asRemote);
		List<uint> list = new List<uint>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v9+18]");
		if (num >= 0)
		{
			list.AddWithResize(4504575u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 4504575;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdx_v11+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(8978431u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 8978431;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		uint num3 = 0u;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v13 (System.UInt32)+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(4521915u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj5 = (nint)0 + (nint)1;
			_ = 4521915;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		object obj6 = UnityEngine.Random.RandomRangeInt(0, 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		bool flag = (nint)obj6 >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rcx_v22+20+v104 @ rax_v22*4]");
		_saveTint = 0u;
		SpriteRenderer enemyRenderer = _EnemyRenderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rcx_v22+20+v104 @ rax_v22*4]");
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(enemyRenderer, 0u);
		BaseBody baseBody = body;
		float2 float5 = default(float2);
		baseBody._transform.setOrigin(float5);
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x18774D650\"");
	}

	private unsafe void SnakeUpdate()
	{
		//IL_01c6: Expected F4, but got I
		//IL_010c->IL007d: Incompatible stack heights: 1 vs 0
		//IL_01b0->IL00b7: Incompatible stack heights: 4 vs 0
		Transform targetTransform = base._targetTransform;
		if ((object)base._targetTransform == null || ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Transform targetTransform2 = base._targetTransform;
		if ((object)base._targetTransform != null)
		{
			bool flag = ((UnityEngine.Object)targetTransform2).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)targetTransform2).m_CachedPtr, out Vector3 ret);
			Transform cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag2 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret2);
				object obj = ret - ret2;
				object obj3 = default(object);
				object obj4 = default(object);
				object obj2 = obj3 - obj4;
				EnemySnek cachedTransform2 = (EnemySnek)(object)_cachedTransform;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
				Quaternion.AngleAxis_Injected((float)(nint)((UnityEngine.Object)cachedTransform).m_CachedPtr, ref ret, out Quaternion _);
				bool flag3 = (object)_cachedTransform == null;
				bool flag4 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
				Transform.set_rotation_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref *(Quaternion*)(&ret2));
				return;
			}
		}
		throw new NullReferenceException();
	}
}
