using System;
using System.Runtime.CompilerServices;
using Coherence.Toolkit;
using Coherence.Toolkit.Bindings.TransformBindings;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors;

public class EnemyOnlineDebugger : MonoBehaviour
{
	public Material material;

	private static bool _003CEnableDebugPosition_003Ek__BackingField;

	private static bool _003CEnableDebugAuthority_003Ek__BackingField;

	private LineRenderer _errorLineRenderer;

	private LineRenderer _velocityLineRenderer;

	private EnemyController _enemy;

	private SpriteRenderer _enemyRenderer;

	private Vector3 _latestRemotePosition;

	private bool _init;

	public static bool EnableDebugPosition
	{
		get
		{
			return _003CEnableDebugPosition_003Ek__BackingField;
		}
		set
		{
			_003CEnableDebugPosition_003Ek__BackingField = value;
		}
	}

	public static bool EnableDebugAuthority
	{
		get
		{
			return _003CEnableDebugAuthority_003Ek__BackingField;
		}
		set
		{
			_003CEnableDebugAuthority_003Ek__BackingField = value;
		}
	}

	private unsafe void Start()
	{
		//IL_0126: Expected O, but got Ref
		//IL_0148: Expected O, but got Ref
		EnemyController enemy = _enemy;
		if ((object)_enemy == null || ((UnityEngine.Object)enemy).m_CachedPtr == (IntPtr)0)
		{
			EnemyController componentInParent = GetComponentInParent<EnemyController>();
			_enemy = componentInParent;
		}
		EnemyController enemy2 = _enemy;
		CoherenceSync coherenceSync = enemy2._coherenceSync;
		if ((object)enemy2._coherenceSync != null && ((UnityEngine.Object)coherenceSync).m_CachedPtr != (IntPtr)0)
		{
			EnemyController enemy3 = _enemy;
			PositionBinding bakedValueBinding = enemy3._coherenceSync.GetBakedValueBinding<PositionBinding>();
			Action<object, bool, long> value = OnNetworkSampleReceived;
			bakedValueBinding.OnNetworkSampleReceived += value;
		}
		EnemyController enemy4 = _enemy;
		_enemyRenderer = enemy4._EnemyRenderer;
		object obj = default(object);
		LineRenderer errorLineRenderer = CreateLineRenderer("ErrorPosition", (Color)(&obj));
		_errorLineRenderer = errorLineRenderer;
		LineRenderer velocityLineRenderer = CreateLineRenderer("Velocity", (Color)(&obj));
		_velocityLineRenderer = velocityLineRenderer;
		EnemyController enemy5 = _enemy;
		CoherenceSync coherenceSync2 = enemy5._coherenceSync;
		bool init;
		if ((object)enemy5._coherenceSync != null)
		{
			bool flag = ((UnityEngine.Object)coherenceSync2).m_CachedPtr == (IntPtr)0;
			init = !flag;
		}
		else
		{
			init = false;
		}
		_init = init;
	}

	private void InitEnemy()
	{
		EnemyController enemy = _enemy;
		if ((object)_enemy == null || ((UnityEngine.Object)enemy).m_CachedPtr == (IntPtr)0)
		{
			EnemyController componentInParent = GetComponentInParent<EnemyController>();
			_enemy = componentInParent;
		}
	}

	private bool IsSynced()
	{
		//IL_00d4: Expected I4, but got O
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._multiplayer != null)
		{
			if (core._multiplayer.IsOnlineMultiplayer)
			{
				EnemyController enemy = _enemy;
				if ((object)_enemy == null)
				{
					goto IL_00c6;
				}
				CoherenceSync coherenceSync = enemy._coherenceSync;
				if ((object)enemy._coherenceSync != null)
				{
					bool flag = ((UnityEngine.Object)coherenceSync).m_CachedPtr == (IntPtr)0;
					return !flag;
				}
			}
			return false;
		}
		goto IL_00c6;
		IL_00c6:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void OnDisable()
	{
		if (_init)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 12 Invalid \"Jump target not found in method: 0x186F37E20\"");
		}
	}

	private void DisableLineRenderers()
	{
		//IL_014c: Expected I, but got O
		//IL_00fd->IL009b: Incompatible stack heights: 1 vs 0
		if ((object)_errorLineRenderer != null)
		{
			_errorLineRenderer.enabled = false;
			if ((object)_velocityLineRenderer != null)
			{
				_velocityLineRenderer.enabled = false;
				object errorLineRenderer = _errorLineRenderer;
				if ((object)_errorLineRenderer != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdi_v6 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdi_v6 (System.Object)+10]");
					LineRenderer.set_positionCount_Injected((IntPtr)0, 0);
					object velocityLineRenderer = _velocityLineRenderer;
					if ((object)_velocityLineRenderer != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdi_v7 (System.Object)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdi_v7 (System.Object)+10]");
						LineRenderer.set_positionCount_Injected((IntPtr)0, 0);
						nint num = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rax_v24 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num2 = 0;
						_latestRemotePosition = Vector3.zeroVector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rcx_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
						_ = 0;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnNetworkSampleReceived(object positionSample, bool stopped, long _)
	{
		//IL_006a: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_004e: Expected O, but got I
		nint num = (nint)typeof(Vector3);
		nint num2 = (nint)positionSample;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v4 (Il2CppClass<System.Object>)+40]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdx_v1 (Il2CppClass<UnityEngine.Vector3>)+40]");
		if (num3 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [positionSample @ rdx (System.Object)+10]");
			_latestRemotePosition = (Vector3)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [positionSample @ rdx (System.Object)+18]");
			int num4 = 0;
			return;
		}
		throw new InvalidCastException();
	}

	private unsafe LineRenderer CreateLineRenderer(string goName, Color color)
	{
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, goName);
		if ((object)gameObject != null)
		{
			Transform transform = gameObject.transform;
			Transform parent = base.transform;
			if ((object)transform != null)
			{
				transform.parent = parent;
				Transform transform2 = gameObject.transform;
				Transform transform3 = base.transform;
				if ((object)transform3 != null)
				{
					bool flag = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
					bool flag2 = (object)transform2 == null;
					bool flag3 = ((string)(object)transform2)._stringLength == 0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected((IntPtr)((string)(object)transform2)._stringLength, ref value);
					LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
					bool flag4 = (object)lineRenderer == null;
					((Renderer)lineRenderer).SetMaterial(material);
					bool flag5 = ((UnityEngine.Object)lineRenderer).m_CachedPtr == (IntPtr)0;
					float value2 = default(float);
					LineRenderer.set_endColor_Injected(((UnityEngine.Object)lineRenderer).m_CachedPtr, ref *(Color*)(&value2));
					bool flag6 = ((UnityEngine.Object)lineRenderer).m_CachedPtr == (IntPtr)0;
					float value3 = default(float);
					LineRenderer.set_startColor_Injected(((UnityEngine.Object)lineRenderer).m_CachedPtr, ref *(Color*)(&value3));
					lineRenderer.endWidth = 0.01f;
					lineRenderer.startWidth = 0.01f;
					bool flag7 = ((UnityEngine.Object)lineRenderer).m_CachedPtr == (IntPtr)0;
					LineRenderer.set_positionCount_Injected(((UnityEngine.Object)lineRenderer).m_CachedPtr, 2);
					return lineRenderer;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void LateUpdate()
	{
		//IL_01d7: Expected O, but got I
		//IL_01c2: Expected O, but got I
		//IL_0517: Unknown result type (might be due to invalid IL or missing references)
		//IL_051c: Expected O, but got Unknown
		//IL_054e: Expected O, but got I
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0563: Expected O, but got Unknown
		//IL_0573: Unknown result type (might be due to invalid IL or missing references)
		//IL_0578: Expected O, but got Unknown
		//IL_0588: Unknown result type (might be due to invalid IL or missing references)
		//IL_058d: Expected O, but got Unknown
		//IL_05f1: Invalid comparison between F4 and O
		//IL_065c: Expected O, but got I
		//IL_01ec: Expected O, but got I
		//IL_0104: Expected O, but got I
		//IL_0686: Unknown result type (might be due to invalid IL or missing references)
		//IL_068b: Expected O, but got Unknown
		//IL_0618: Expected O, but got I
		//IL_0137: Expected O, but got I
		//IL_0642: Unknown result type (might be due to invalid IL or missing references)
		//IL_0647: Expected O, but got Unknown
		//IL_069e: Expected I, but got O
		//IL_06c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ca: Expected O, but got Unknown
		//IL_06da: Unknown result type (might be due to invalid IL or missing references)
		//IL_06df: Expected O, but got Unknown
		//IL_06fc: Expected O, but got I
		//IL_0746: Invalid comparison between F4 and O
		//IL_0784: Unknown result type (might be due to invalid IL or missing references)
		//IL_0789: Expected O, but got Unknown
		//IL_07f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f7: Expected O, but got Unknown
		//IL_0868: Unknown result type (might be due to invalid IL or missing references)
		//IL_086d: Expected O, but got Unknown
		//IL_08e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e5: Expected O, but got Unknown
		//IL_0928->IL0466: Incompatible stack heights: 1 vs 0
		//IL_020e->IL0466: Incompatible stack heights: 1 vs 0
		//IL_0466->IL0494: Incompatible stack heights: 1 vs 0
		//IL_064c->IL092d: Incompatible stack heights: 3 vs 1
		//IL_024d->IL0466: Incompatible stack heights: 1 vs 0
		//IL_0279->IL0466: Incompatible stack heights: 1 vs 0
		//IL_0320->IL0466: Incompatible stack heights: 1 vs 0
		//IL_0904->IL0494: Incompatible stack heights: 13 vs 0
		GameManager core = GM.Core;
		object obj2 = default(object);
		object obj5 = default(object);
		if ((object)GM.Core != null && core._multiplayer != null)
		{
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				return;
			}
			EnemyController enemy = _enemy;
			if ((object)_enemy != null)
			{
				CoherenceSync coherenceSync = enemy._coherenceSync;
				if ((object)enemy._coherenceSync == null || ((UnityEngine.Object)coherenceSync).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				object enemyRenderer = _enemyRenderer;
				bool num;
				if (!_003CEnableDebugAuthority_003Ek__BackingField)
				{
					if (enemyRenderer == null)
					{
						goto IL_0466;
					}
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rdi_v24 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					num = flag;
					object obj = obj2 - 48;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rdi_v24 (System.Object)+10]");
					SpriteRenderer.get_color_Injected((IntPtr)0, out *(Color*)obj);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
					object obj3 = num2 - 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-2C]");
					object obj4 = 0 - obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
					object obj6 = 0 - obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-24]");
					object obj7 = 0 - obj5;
					object obj8 = obj4 * obj4;
					object obj9 = obj3 * obj3;
					object obj10 = obj6 * obj6;
					object obj11 = obj8 + obj9;
					object obj12 = obj7 * obj7;
					object obj13 = obj11 + obj10;
					object obj14 = obj13 + obj12;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14))
					{
						goto IL_0904;
					}
					object enemyRenderer2 = _enemyRenderer;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
					object obj15 = 0;
					bool flag2 = (object)_enemyRenderer == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ rdi_v33 (System.Object)+10]");
					object obj16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ rdi_v33 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					object obj17 = 0;
					object obj18 = obj2 - 64;
				}
				else
				{
					EnemyController enemy2 = _enemy;
					if ((object)_enemy == null || (object)enemy2._coherenceSync == null)
					{
						goto IL_0466;
					}
					if (enemy2._coherenceSync.HasStateAuthority)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
						object obj15 = 0;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
						object obj15 = 0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rdi_v24 (System.Object)+10]");
					object obj16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rdi_v24 (System.Object)+10]");
					bool flag4 = (nint)0 == 0;
					num = flag4;
					object obj17 = 0;
					object obj18 = obj2 - 48;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1276 @ rax_v61 (should have been resolved before IL gen)");
				goto IL_0904;
			}
		}
		goto IL_0466;
		IL_0904:
		EnemyController enemy3 = _enemy;
		if ((object)_enemy != null && (object)enemy3._coherenceSync != null)
		{
			if (enemy3._coherenceSync.HasStateAuthority)
			{
				goto IL_045b;
			}
			if ((object)_enemy != null)
			{
				GameObject gameObject = _enemy.gameObject;
				if ((object)gameObject != null)
				{
					if (gameObject.activeInHierarchy)
					{
						_ = _latestRemotePosition;
						nint num3 = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1229 @ rax_v71 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num4 = 0;
						_ = Vector3.zeroVector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-60]");
						object obj19 = 0 - Vector3.zeroVector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-5C]");
						object obj20 = 0 - obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.EnemyOnlineDebugger)+50]");
						nint num5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1232 @ rcx_v62 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
						object obj21 = num5 - 0;
						object obj22 = obj20 * obj20;
						object obj23 = obj19 * obj19;
						object obj24 = obj21 * obj21;
						object obj25 = obj22 + obj23;
						object obj26 = obj25 + obj24;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj26))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186F537C0");
							object obj27 = default(object);
							if (obj27 != null)
							{
								SetPositionCount(_errorLineRenderer);
								SetPositionCount(_velocityLineRenderer);
								object errorLineRenderer = _errorLineRenderer;
								Transform transform = base.transform;
								if ((object)transform != null)
								{
									Vector3 position = transform.position;
									bool flag5 = (object)_errorLineRenderer == null;
									_ = position.x;
									_ = position.z;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rdi_v29 (System.Object)+10]");
									bool flag6 = (nint)0 == 0;
									object obj28 = obj2 - 96;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rdi_v29 (System.Object)+10]");
									LineRenderer.SetPosition_Injected((IntPtr)0, 0, ref *(Vector3*)obj28);
									object errorLineRenderer2 = _errorLineRenderer;
									bool flag7 = (object)_errorLineRenderer == null;
									_ = _latestRemotePosition;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.EnemyOnlineDebugger)+50]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1107 @ rdi_v30 (System.Object)+10]");
									bool flag8 = (nint)0 == 0;
									object obj29 = obj2 - 80;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1107 @ rdi_v30 (System.Object)+10]");
									LineRenderer.SetPosition_Injected((IntPtr)0, 1, ref *(Vector3*)obj29);
									object velocityLineRenderer = _velocityLineRenderer;
									Transform transform2 = base.transform;
									bool flag9 = (object)transform2 == null;
									Vector3 position2 = transform2.position;
									bool flag10 = (object)_velocityLineRenderer == null;
									_ = position2.x;
									_ = position2.z;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rdi_v31 (System.Object)+10]");
									bool flag11 = (nint)0 == 0;
									object obj30 = obj2 - 64;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1295 @ rdi_v31 (System.Object)+10]");
									LineRenderer.SetPosition_Injected((IntPtr)0, 0, ref *(Vector3*)obj30);
									EnemyController enemy4 = _enemy;
									object velocityLineRenderer2 = _velocityLineRenderer;
									bool flag12 = (object)_enemy == null;
									bool flag13 = enemy4.body == null;
									Transform transform3 = base.transform;
									bool flag14 = (object)transform3 == null;
									Vector3 position3 = transform3.position;
									_ = position3.x;
									bool flag15 = (object)_velocityLineRenderer == null;
									_ = position3.z;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rdi_v32 (System.Object)+10]");
									bool flag16 = (nint)0 == 0;
									object obj31 = obj2 - 80;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rdi_v32 (System.Object)+10]");
									LineRenderer.SetPosition_Injected((IntPtr)0, 1, ref *(Vector3*)obj31);
									return;
								}
								goto IL_0466;
							}
						}
					}
					goto IL_045b;
				}
			}
		}
		goto IL_0466;
		IL_0466:
		throw new NullReferenceException();
		IL_045b:
		DisableLineRenderers();
	}

	private void SetPositionCount(LineRenderer renderer)
	{
		//IL_005c: Expected O, but got I4
		bool flag = ((UnityEngine.Object)renderer).m_CachedPtr == (IntPtr)0;
		object obj = LineRenderer.get_positionCount_Injected(((UnityEngine.Object)renderer).m_CachedPtr);
		if (obj == null)
		{
			renderer.enabled = true;
			renderer.positionCount = 2;
		}
	}

	public EnemyOnlineDebugger()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
