using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework;

public class DebugSpawnWeapon : MonoBehaviour
{
	private bool Loop;

	private GameObject _particleSystemToSpawn;

	private List<GameObject> SpawnedFXs;

	private float _spawnTimeInterval;

	private float _time;

	private Vector3 offset;

	private Vector3 offsetAmount;

	private void Start()
	{
		if (!Loop)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(_particleSystemToSpawn);
			ParticleSystem component = gameObject.GetComponent<ParticleSystem>();
			component.Play(withChildren: true);
			GameManager core = GM.Core;
			ParticleSystem[] componentsInChildren = gameObject.GetComponentsInChildren<ParticleSystem>(includeInactive: false);
			core._particleManager.RegisterParticleSystem(componentsInChildren);
		}
	}

	private void Update()
	{
		//IL_01a8: Expected O, but got F4
		//IL_015a: Expected O, but got I
		//IL_0179->IL0330: Incompatible stack heights: 10 vs 0
		if (!Loop)
		{
			return;
		}
		object obj = Time.deltaTime;
		object obj2 = default(object);
		if ((_time = (float)obj2 + _time) < _spawnTimeInterval)
		{
			return;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(_particleSystemToSpawn);
		if (SpawnedFXs != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
			if ((object)gameObject != null)
			{
				Transform transform = gameObject.transform;
				Transform transform2 = base.transform;
				if ((object)transform2 != null)
				{
					bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret);
					bool flag2 = (object)transform == null;
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					Transform transform3 = gameObject.transform;
					Transform transform4 = base.transform;
					bool flag4 = (object)transform4 == null;
					bool flag5 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
					Transform.get_localScale_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out ret);
					bool flag6 = (object)transform3 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v930 @ rax_v50 (UnityEngine.Transform)+10]");
					bool flag7 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v930 @ rax_v50 (UnityEngine.Transform)+10]");
					Vector3 value2 = default(Vector3);
					Transform.set_localScale_Injected((IntPtr)0, ref value2);
					ParticleSystem component = gameObject.GetComponent<ParticleSystem>();
					bool flag8 = (object)component == null;
					component.Play(withChildren: true);
					GameManager core = GM.Core;
					bool flag9 = (object)GM.Core == null;
					ParticleSystem[] componentsInChildren = gameObject.GetComponentsInChildren<ParticleSystem>(includeInactive: false);
					bool flag10 = core._particleManager == null;
					core._particleManager.RegisterParticleSystem(componentsInChildren);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rcx_v1 (DebugSpawnWeapon)+54]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rcx_v1 (DebugSpawnWeapon)+48]");
					object obj3 = num + 0;
					_time = 0f;
					Vector3 vector = default(Vector3);
					offset = vector;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public DebugSpawnWeapon()
	{
		//IL_003d: Expected I, but got O
		//IL_007d: Expected I, but got O
		List<GameObject> spawnedFXs = new List<GameObject>();
		SpawnedFXs = spawnedFXs;
		_spawnTimeInterval = 1f;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v6 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		offset = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		nint num3 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v9 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num4 = 0;
		offsetAmount = Vector3.upVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		_ = 0;
	}
}
