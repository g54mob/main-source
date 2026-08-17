using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemySnek_Generic : EnemyController
{
	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		base.InitEnemy(enemyType, asRemote);
		BaseBody baseBody = body;
		float2 float5 = default(float2);
		baseBody._transform.setOrigin(float5);
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x18774E1F0\"");
	}

	private unsafe void SnakeUpdate()
	{
		//IL_015e: Expected F4, but got I
		//IL_00a8->IL004d: Incompatible stack heights: 1 vs 0
		RetargetIfNecessary();
		Transform targetTransform = base._targetTransform;
		if ((object)base._targetTransform != null)
		{
			bool flag = ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)targetTransform).m_CachedPtr, out Vector3 ret);
			Transform cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag2 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret2);
				object obj = ret - ret2;
				object obj3 = default(object);
				object obj4 = default(object);
				object obj2 = obj3 - obj4;
				EnemySnek_Generic cachedTransform2 = (EnemySnek_Generic)(object)_cachedTransform;
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
