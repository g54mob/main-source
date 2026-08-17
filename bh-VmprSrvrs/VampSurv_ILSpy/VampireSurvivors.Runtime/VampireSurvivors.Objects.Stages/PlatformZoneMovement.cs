using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Stages;

public class PlatformZoneMovement : GameMonoBehaviour
{
	public class JumpInfo
	{
		public float _fallingTimer;

		public bool _hasJumped;
	}

	public struct ClosestEdge
	{
		public StageEdge _edge;

		public float2 _point;

		public float _distSqrd;

		public float _yDistance;
	}

	[StructLayout((LayoutKind)3)]
	private struct _003C_003Ec__DisplayClass45_0
	{
		public PlatformZoneMovement _003C_003E4__this;

		public bool movingInsideLimits;
	}

	private List<StageEdge> _stageEdges;

	private ParticleEmitterManager _pfxEmitterManager;

	private ParticleSystem _smokeEmitter;

	private List<JumpInfo> _characterInfo;

	private bool _limitCameraPosition;

	private bool _blendAfterCameraLimitsDisabled;

	private Vector2 _cameraBlendVelocity;

	private float _cameraXVelocity;

	private float _cameraYVelocity;

	private CoherenceSync _sync;

	private static PlatformZoneMovement _003CInstance_003Ek__BackingField;

	private bool _003CMoveCameraInsideLimitsOnLimitsEnabled_003Ek__BackingField;

	public float? MinCameraX;

	public float? MinCameraY;

	public float? MaxCameraX;

	public float? MaxCameraY;

	public List<StageEdge> StageEdges => _stageEdges;

	public static PlatformZoneMovement Instance
	{
		get
		{
			return _003CInstance_003Ek__BackingField;
		}
		private set
		{
			_003CInstance_003Ek__BackingField = value;
		}
	}

	public bool MoveCameraInsideLimitsOnLimitsEnabled
	{
		get
		{
			return _003CMoveCameraInsideLimitsOnLimitsEnabled_003Ek__BackingField;
		}
		set
		{
			_003CMoveCameraInsideLimitsOnLimitsEnabled_003Ek__BackingField = value;
		}
	}

	public bool LimitCameraPosition
	{
		get
		{
			return _limitCameraPosition;
		}
		set
		{
			//IL_0052: Expected O, but got I4
			//IL_005d: Expected O, but got I4
			//IL_0068: Expected O, but got I4
			//IL_0073: Expected O, but got I4
			if (!value)
			{
				if (_limitCameraPosition != value)
				{
					_blendAfterCameraLimitsDisabled = true;
				}
				MinCameraX = (float?)(object)0;
				MinCameraY = (float?)(object)0;
				MaxCameraX = (float?)(object)0;
				MaxCameraY = (float?)(object)0;
			}
			_limitCameraPosition = value;
		}
	}

	public void SetCameraLimits(Rectangle cameraLimitsRectangle)
	{
		//IL_001a: Expected O, but got I4
		//IL_0025: Expected O, but got I4
		//IL_0030: Expected O, but got I4
		//IL_003b: Expected O, but got I4
		MinCameraX = (float?)(object)1;
		MaxCameraX = (float?)(object)1;
		MinCameraY = (float?)(object)1;
		MaxCameraY = (float?)(object)1;
	}

	private void Awake()
	{
		CoherenceSync componentInParent = GetComponentInParent<CoherenceSync>();
		_sync = componentInParent;
		List<JumpInfo> characterInfo = new List<JumpInfo>();
		_characterInfo = characterInfo;
		_stageEdges = null;
		InitJumpParticles();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186FDEB20");
	}

	protected override void OnDestroy()
	{
		//IL_006d: Expected F4, but got I4
		//IL_0076: Expected O, but got I4
		//IL_007b: Expected I, but got O
		//IL_00f7: Expected F4, but got I4
		//IL_0100: Expected O, but got I4
		//IL_0105: Expected I, but got O
		ParticleSystem smokeEmitter = _smokeEmitter;
		if ((object)_smokeEmitter != null && ((UnityEngine.Object)smokeEmitter).m_CachedPtr != (IntPtr)0)
		{
			GameObject obj = _smokeEmitter.gameObject;
			UnityEngine.Object.Destroy(obj, 0f);
			_smokeEmitter = null;
			float num = 0f;
			object obj2 = 0;
			nint num2 = unchecked((nint)null);
		}
		ParticleEmitterManager pfxEmitterManager = _pfxEmitterManager;
		if ((object)_pfxEmitterManager != null && ((UnityEngine.Object)pfxEmitterManager).m_CachedPtr != (IntPtr)0)
		{
			GameObject obj3 = _pfxEmitterManager.gameObject;
			UnityEngine.Object.Destroy(obj3, 0f);
			_pfxEmitterManager = null;
			float num = 0f;
			object obj2 = 0;
			nint num2 = unchecked((nint)null);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186FDEB20");
	}

	protected override void OnUpdate()
	{
	}

	private void LateUpdate()
	{
		if (_stageEdges != null)
		{
			RunEdgeLogic();
		}
	}

	public unsafe void LoadStageEdges(PolygonGroupComponent polygonGroup)
	{
		//IL_02e1: Expected O, but got I4
		//IL_02e9: Expected O, but got Ref
		//IL_006a: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_0367: Expected I, but got O
		//IL_037d: Expected O, but got I
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Expected O, but got Unknown
		//IL_03dc: Expected O, but got I8
		//IL_027f: Expected I, but got O
		//IL_03b1: Expected O, but got I4
		//IL_03c8: Expected I, but got I8
		//IL_0241: Expected I, but got I8
		//IL_01a8: Expected O, but got I4
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected O, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
		//IL_02aa: Expected O, but got I4
		//IL_02b2: Expected O, but got Ref
		GameManager core;
		Action action;
		if ((object)polygonGroup != null && ((UnityEngine.Object)polygonGroup).m_CachedPtr != (IntPtr)0)
		{
			List<StageEdge> stageEdges = new List<StageEdge>();
			_stageEdges = stageEdges;
			PolygonComponent[] componentsInChildren = polygonGroup.GetComponentsInChildren<PolygonComponent>();
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < componentsInChildren.Length)
			{
				PolygonComponent polygonComponent = componentsInChildren[obj];
				StageEdge stageEdge = new StageEdge();
				Polygon worldSpacePolygon = componentsInChildren[obj].GetWorldSpacePolygon();
				stageEdge._polygon = worldSpacePolygon;
				stageEdge._rotationAngle = polygonComponent._rotationAngle;
				stageEdge._fallRegion = polygonComponent._fallRegion;
				List<object> stageEdges2 = (List<object>)(object)_stageEdges;
				int version = stageEdges2._version + 1;
				stageEdges2._version = version;
				object[] items = stageEdges2._items;
				if (stageEdges2._size >= items.Length)
				{
					stageEdges2.AddWithResize((object)stageEdge);
					obj++;
					obj2 = obj;
				}
				else
				{
					int size = stageEdges2._size + 1;
					stageEdges2._size = size;
					((List<StageEdge>)(object)items).AddWithResize((StageEdge)stageEdges2._size);
					obj++;
					obj2 = obj;
				}
			}
			core = GM.Core;
			action = null;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ r10_v6 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(PlatformZoneMovement.UpdateCameraTarget);
			((Delegate)action).m_target = this;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ r10_v6 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num2;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ r10_v6 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num2 = unchecked((nint)6447293664L);
					goto IL_03a8;
				}
			}
			else if ((object)this == null)
			{
				((List<StageEdge>)null).AddWithResize((StageEdge)6570564832L);
				List<JumpInfo>.Enumerator enumerator = default(List<JumpInfo>.Enumerator);
				throw enumerator;
			}
			num2 = ((Delegate)action).method_ptr;
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			goto IL_03a8;
		}
		_stageEdges = null;
		List<JumpInfo>.Enumerator enumerator2 = default(List<JumpInfo>.Enumerator);
		if (enumerator2.MoveNext())
		{
			object obj5 = 0;
			List<JumpInfo>.Enumerator enumerator3 = (List<JumpInfo>.Enumerator)(&enumerator2);
			throw new NullReferenceException();
		}
		return;
		IL_03a8:
		object obj6 = 24;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		core._003CManualCameraTargetControl_003Ek__BackingField = action;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator4 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator4.MoveNext())
		{
			object obj7 = 0;
			List<JumpInfo>.Enumerator enumerator3 = (List<JumpInfo>.Enumerator)(&enumerator4);
			throw new NullReferenceException();
		}
	}

	private unsafe ClosestEdge FindClosestEdge(float2 position, float rangeSqrd = 3.4028235E+38f, bool includeFalling = false)
	{
		//IL_01bd: Expected native int or pointer, but got O
		//IL_01cb: Expected native int or pointer, but got O
		//IL_01de: Expected I, but got O
		//IL_0207: Expected O, but got I
		//IL_0257: Expected O, but got I4
		//IL_0252: Expected native int or pointer, but got O
		//IL_0260: Expected native int or pointer, but got O
		//IL_026d: Expected native int or pointer, but got O
		//IL_016b: Expected native int or pointer, but got O
		//IL_017d: Expected native int or pointer, but got O
		//IL_0199: Expected native int or pointer, but got O
		//IL_009d: Expected O, but got Ref
		//IL_006c: Expected O, but got Ref
		ClosestEdge closestEdge = default(ClosestEdge);
		System.Runtime.CompilerServices.Unsafe.Write(&((ClosestEdge*)(nint)closestEdge)->_edge, null);
		((ClosestEdge*)(nint)closestEdge)->_distSqrd = 0f;
		nint num = (nint)typeof(float2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v4 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
		nint num2 = 0;
		float2 zero = float2.zero;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v2 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
		object obj = 0;
		StageEdge edge = null;
		List<StageEdge>.Enumerator enumerator = default(List<StageEdge>.Enumerator);
		if (enumerator.MoveNext())
		{
			StageEdge stageEdge = null;
			object obj2 = default(object);
			List<StageEdge>.Enumerator enumerator2;
			if (obj2 == null)
			{
				enumerator2 = (List<StageEdge>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			enumerator2 = (List<StageEdge>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		((ClosestEdge*)(nint)closestEdge)->_point = (float2)0;
		((ClosestEdge*)(nint)closestEdge)->_distSqrd = 0f;
		System.Runtime.CompilerServices.Unsafe.Write(&((ClosestEdge*)(nint)closestEdge)->_edge, edge);
		((ClosestEdge*)(nint)closestEdge)->_point = zero;
		((ClosestEdge*)(nint)closestEdge)->_distSqrd = rangeSqrd;
		object obj3 = default(object);
		float yDistance = (float)obj - (float)obj3;
		((ClosestEdge*)(nint)closestEdge)->_yDistance = yDistance;
		return closestEdge;
	}

	public unsafe ClosestEdge FindClosestWalkableEdgeBelow(float2 position)
	{
		//IL_01e1: Expected native int or pointer, but got O
		//IL_01ef: Expected native int or pointer, but got O
		//IL_0202: Expected I, but got O
		//IL_022b: Expected O, but got I
		//IL_0280: Expected O, but got I4
		//IL_027b: Expected native int or pointer, but got O
		//IL_0289: Expected native int or pointer, but got O
		//IL_0296: Expected native int or pointer, but got O
		//IL_005c: Expected O, but got Ref
		//IL_015c: Expected native int or pointer, but got O
		//IL_01b1: Expected native int or pointer, but got O
		//IL_01cd: Expected native int or pointer, but got O
		ClosestEdge closestEdge = default(ClosestEdge);
		System.Runtime.CompilerServices.Unsafe.Write(&((ClosestEdge*)(nint)closestEdge)->_edge, null);
		((ClosestEdge*)(nint)closestEdge)->_distSqrd = 0f;
		nint num = (nint)typeof(float2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
		nint num2 = 0;
		float2 zero = float2.zero;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rcx_v2 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
		object obj = 0;
		StageEdge edge = null;
		float num3 = 3.4028235E+38f;
		List<StageEdge>.Enumerator enumerator = default(List<StageEdge>.Enumerator);
		if (enumerator.MoveNext())
		{
			StageEdge stageEdge = null;
			List<StageEdge>.Enumerator enumerator2 = (List<StageEdge>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		((ClosestEdge*)(nint)closestEdge)->_point = (float2)0;
		((ClosestEdge*)(nint)closestEdge)->_distSqrd = 0f;
		System.Runtime.CompilerServices.Unsafe.Write(&((ClosestEdge*)(nint)closestEdge)->_edge, edge);
		((ClosestEdge*)(nint)closestEdge)->_point = zero;
		object obj2 = position - zero;
		object obj4 = default(object);
		object obj3 = obj4 - obj;
		object obj5 = obj2 * obj2;
		object obj6 = obj3 * obj3;
		float distSqrd = (float)obj5 + (float)obj6;
		((ClosestEdge*)(nint)closestEdge)->_distSqrd = distSqrd;
		float yDistance = (float)obj - (float)obj4;
		((ClosestEdge*)(nint)closestEdge)->_yDistance = yDistance;
		return closestEdge;
	}

	private void RunEdgeLogic()
	{
		//IL_026c: Expected I, but got O
		//IL_0242: Expected O, but got I
		List<JumpInfo> characterInfo = _characterInfo;
		while (true)
		{
			GameManager core = GM.Core;
			List<VampireSurvivors.Objects.Characters.CharacterController> characters = core._characters;
			if (characterInfo._size >= characters._size)
			{
				break;
			}
			List<object> characterInfo2 = (List<object>)(object)_characterInfo;
			JumpInfo item = new JumpInfo();
			int version = characterInfo2._version + 1;
			characterInfo2._version = version;
			object[] items = characterInfo2._items;
			if (characterInfo2._size >= items.Length)
			{
				characterInfo2.AddWithResize((object)item);
			}
			else
			{
				int size = characterInfo2._size + 1;
				characterInfo2._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			characterInfo = _characterInfo;
		}
		GameManager core2 = GM.Core;
		int num = 0;
		int num2 = 0;
		float2 lastFacingDirection = default(float2);
		bool tryingToJump = default(bool);
		while (true)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = core2._characters;
			if (num2 >= characters2._size)
			{
				return;
			}
			GameManager core3 = GM.Core;
			List<VampireSurvivors.Objects.Characters.CharacterController> characters3 = core3._characters;
			if (num >= characters3._size)
			{
				break;
			}
			VampireSurvivors.Objects.Characters.CharacterController[] items2 = characters3._items;
			VampireSurvivors.Objects.Characters.CharacterController characterController = items2[num];
			CoherenceSync coherenceSync = characterController._coherenceSync;
			NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
			if (coherenceSync._003CEntityState_003Ek__BackingField != null)
			{
				ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rcx_v25 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				bool flag = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rcx_v25 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				if ((nint)0 != 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rcx_v25 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					object obj = -3;
					bool flag2 = obj == null;
					flag = flag2;
				}
				if (!flag)
				{
					goto IL_03a0;
				}
			}
			nint num3 = (nint)typeof(float2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ rax_v26 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
			nint num4 = 0;
			characterController._003CExternalVelocity_003Ek__BackingField = float2.zero;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v645 @ rcx_v16 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
			_ = 0;
			if (!characterController._isDead && !characterController.IsDisconnectedFromOnlinePlay)
			{
				float num5 = characterController.PMoveSpeed();
				if ((nint)float2.zero < 0)
				{
				}
			}
			JumpInfo info = _characterInfo.get_Item(num);
			float2 float5 = ApplyMovement(characterController, info, lastFacingDirection, tryingToJump);
			characterController._003CExternalVelocity_003Ek__BackingField = float5;
			if (GM.Core.IsMultiplayer)
			{
				characterController.RefreshMultiplayerOutline();
			}
			goto IL_03a0;
			IL_03a0:
			num++;
			core2 = GM.Core;
			bool flag3 = (object)GM.Core != null;
			num2 = num;
			if (!flag3)
			{
				throw new NullReferenceException();
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public unsafe bool IsInFallZone(float2 position)
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		List<StageEdge>.Enumerator enumerator = default(List<StageEdge>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<StageEdge>.Enumerator enumerator2 = (List<StageEdge>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return false;
	}

	public unsafe float2 ApplyMovement(ArcadeSprite character, JumpInfo info, float2 lastFacingDirection, bool tryingToJump)
	{
		//IL_00b6: Expected F4, but got I4
		//IL_0060: Invalid comparison between I4 and F4
		//IL_0072: Expected F4, but got I4
		//IL_00a0: Expected F4, but got I4
		//IL_02bf: Expected F4, but got I4
		//IL_02d1: Expected O, but got F4
		//IL_03dd: Expected O, but got I
		//IL_0b03: Expected O, but got I4
		//IL_0b03: Expected O, but got I
		//IL_0444: Expected O, but got I
		//IL_0e31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e36: Expected O, but got Unknown
		//IL_0e50: Expected O, but got I4
		//IL_08ee: Expected O, but got I
		//IL_0925: Expected F4, but got I4
		//IL_0925: Expected O, but got I4
		//IL_06c7: Expected O, but got I
		//IL_0c47: Expected O, but got Ref
		//IL_05de: Expected O, but got I
		//IL_0f14: Expected O, but got I4
		//IL_072b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0730: Expected O, but got Unknown
		//IL_074f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0754: Expected O, but got Unknown
		//IL_02b1: Expected F4, but got I4
		//IL_0659: Expected O, but got I4
		//IL_0659: Expected O, but got I
		//IL_0eb4: Expected O, but got I4
		//IL_0eb4: Expected O, but got I
		//IL_0abf: Expected O, but got Ref
		//IL_0886: Expected O, but got I
		//IL_0083->IL0ca6: Incompatible stack heights: 1 vs 0
		//IL_00ad->IL0ca6: Incompatible stack heights: 1 vs 0
		//IL_0d14->IL02b6: Incompatible stack heights: 3 vs 1
		//IL_0e10->IL0f3a: Incompatible stack heights: 2 vs 1
		//IL_038a->IL0d8a: Incompatible stack heights: 4 vs 1
		//IL_0194->IL02b6: Incompatible stack heights: 3 vs 1
		//IL_04b2->IL0e10: Incompatible stack heights: 2 vs 1
		//IL_039c->IL0d8a: Incompatible stack heights: 4 vs 1
		//IL_0969->IL0e5e: Incompatible stack heights: 3 vs 2
		//IL_0256->IL02b6: Incompatible stack heights: 7 vs 1
		//IL_06ed->IL0e5e: Incompatible stack heights: 3 vs 2
		//IL_0f3a->IL0f3a: Incompatible stack heights: 7 vs 1
		//IL_0f0b->IL0f0b: Incompatible stack heights: 2 vs 7
		//IL_0604->IL0e5e: Incompatible stack heights: 3 vs 2
		//IL_0294->IL02b6: Incompatible stack heights: 8 vs 1
		//IL_0f19->IL0e03: Incompatible stack heights: 7 vs 2
		//IL_0f44->IL0f0b: Incompatible stack heights: 2 vs 7
		//IL_076b->IL0e5e: Incompatible stack heights: 3 vs 2
		//IL_0629->IL0e5e: Incompatible stack heights: 3 vs 2
		//IL_02b6->IL0d19: Incompatible stack heights: 8 vs 1
		//IL_0794->IL0e5e: Incompatible stack heights: 3 vs 2
		//IL_08b6->IL0e5e: Incompatible stack heights: 4 vs 2
		//IL_0ac4->IL0ecb: Incompatible stack heights: 7 vs 2
		//IL_0898->IL0898: Incompatible stack heights: 4 vs 3
		//IL_0863->IL0e5e: Incompatible stack heights: 7 vs 2
		//IL_086e->IL0e89: Incompatible stack heights: 7 vs 4
		float deltaTime = PauseSystem.DeltaTime;
		object obj = default(object);
		float num;
		float num2;
		if (obj == null)
		{
			bool flag = info == null;
			bool flag2 = !(0f > info._fallingTimer);
			num = 0f;
			num2 = deltaTime;
			if (!flag2)
			{
				float num3 = deltaTime + deltaTime;
				num = 0f;
				num2 = num3;
			}
		}
		else
		{
			num = 0f;
			num2 = deltaTime;
		}
		GameManager core = GM.Core;
		bool flag3 = (object)GM.Core == null;
		Stage stage = core._stage;
		List<StageEdge>.Enumerator enumerator = default(List<StageEdge>.Enumerator);
		float num4;
		if ((object)core._stage != null && ((UnityEngine.Object)stage).m_CachedPtr != (IntPtr)0)
		{
			GameManager core2 = GM.Core;
			bool flag4 = (object)GM.Core == null;
			Stage stage2 = core2._stage;
			bool flag5 = (object)core2._stage == null;
			TilingTileset tilingTileset = stage2._tilingTileset;
			if ((object)stage2._tilingTileset != null && ((UnityEngine.Object)tilingTileset).m_CachedPtr != (IntPtr)0)
			{
				GameManager core3 = GM.Core;
				bool flag6 = (object)GM.Core == null;
				Stage stage3 = core3._stage;
				bool flag7 = (object)core3._stage == null;
				bool flag8 = (object)character == null;
				float2 position = character.position;
				bool flag9 = (object)stage3._tilingTileset == null;
				if (stage3._tilingTileset.IsPointWithinCollisionLayer((Vector2)enumerator))
				{
					bool flag10 = info == null;
					if (num > info._fallingTimer)
					{
						info._fallingTimer = 0f;
						num4 = 0f;
						goto IL_0d19;
					}
				}
			}
		}
		num4 = 0f;
		goto IL_0d19;
		IL_0e5e:
		StageEdge stageEdge;
		bool flag11 = !stageEdge._fallRegion;
		float2 result = float2.zero;
		if (flag11)
		{
			goto IL_0e03;
		}
		if ((info._fallingTimer = num2 + info._fallingTimer) > 0.125f)
		{
			bool flag12 = (object)character == null;
			character.CheckRenderer();
			character.CheckRenderer();
			bool flag13 = (object)character._spriteRenderer == null;
			Transform transform = character._spriteRenderer.transform;
			bool flag14 = (object)transform == null;
			Vector3 localEulerAngles = transform.localEulerAngles;
			float deltaTime2 = PauseSystem.DeltaTime;
			if (character.flipX)
			{
			}
			bool flag15 = (object)character._spriteRenderer == null;
			Transform transform2 = character._spriteRenderer.transform;
			bool flag16 = (object)transform2 == null;
			List<StageEdge>.Enumerator enumerator2 = default(List<StageEdge>.Enumerator);
			transform2.localEulerAngles = (Vector3)(&enumerator2);
		}
		if (info._fallingTimer > num)
		{
		}
		if (num > info._fallingTimer)
		{
		}
		goto IL_0f0b;
		IL_0e03:
		return result;
		IL_0898:
		bool flag17 = stageEdge == null;
		goto IL_0e5e;
		IL_0d19:
		if (_stageEdges != null)
		{
			stageEdge = (StageEdge)num4;
			List<StageEdge>.Enumerator enumerator3 = default(List<StageEdge>.Enumerator);
			while (enumerator3.MoveNext())
			{
				StageEdge stageEdge2 = null;
				bool flag18 = (object)character == null;
				Transform cachedTrans = character.CachedTrans;
				bool flag19 = (object)cachedTrans == null;
				bool flag20 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
				float2 ret;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
				if (character.body != null)
				{
					BaseBody body = character.body;
					ArcadeTransform arcadeTransform = body._transform;
					arcadeTransform.position = ret;
				}
				if (stageEdge2._polygon.IsPointInside((float2)enumerator))
				{
					stageEdge = null;
				}
			}
			bool num5;
			IntPtr intPtr = default(IntPtr);
			bool flag22 = default(bool);
			float num6;
			IntPtr intPtr2;
			if (stageEdge == null)
			{
				bool flag21 = (object)character == null;
				num5 = flag21;
				float2 position2 = character.position;
				ClosestEdge closestEdge = ((PlatformZoneMovement)(nint)intPtr).FindClosestEdge(position2, 0.01f, flag22);
				StageEdge edge = closestEdge._edge;
				bool flag23 = closestEdge._edge != null;
				ArcadeSprite arcadeSprite = character;
				if (!flag23)
				{
					float2 position3 = character.position;
					ClosestEdge closestEdge2 = ((PlatformZoneMovement)(nint)intPtr).FindClosestEdge(position3, 3.4028235E+38f, flag22);
					edge = closestEdge2._edge;
					bool flag24 = closestEdge2._edge == null;
					result = float2.zero;
					if (flag24)
					{
						goto IL_0e03;
					}
					arcadeSprite = character;
				}
				arcadeSprite.position = (float2)enumerator;
				bool flag25 = edge == null;
				result = float2.zero;
				if (flag25)
				{
					goto IL_0e03;
				}
				num6 = 0.01f;
				stageEdge = edge;
				intPtr2 = intPtr;
			}
			else
			{
				num6 = 0.01f;
				intPtr2 = intPtr;
			}
			bool flag26 = info == null;
			num5 = flag26;
			if (stageEdge._fallRegion)
			{
				bool flag28;
				if (!info._hasJumped && 0.125f > info._fallingTimer)
				{
					bool flag27 = info._fallingTimer < num;
					flag28 = !flag27;
				}
				else
				{
					flag28 = false;
				}
				object obj2 = obj & flag28;
				bool flag29 = obj2 == null;
				object obj3 = !flag29;
				if (obj3 == null)
				{
					if (num6 > info._fallingTimer && !(info._fallingTimer < num))
					{
						bool flag30 = (object)character == null;
						float2 position4 = character.position;
						ClosestEdge closestEdge3 = ((PlatformZoneMovement)(nint)intPtr2).FindClosestWalkableEdgeBelow((float2)enumerator);
						if (closestEdge3._edge != null && 0.1f > closestEdge3._distSqrd)
						{
							character.position = (float2)enumerator;
							((PlatformZoneMovement)(nint)intPtr2).LockToEdge(character, info, closestEdge3._edge, (float2)flag22);
							stageEdge = closestEdge3._edge;
							goto IL_0898;
						}
					}
					else if (info._fallingTimer > num6)
					{
						bool flag31 = (object)character == null;
						float2 position5 = character.position;
						ClosestEdge closestEdge4 = ((PlatformZoneMovement)(nint)intPtr2).FindClosestWalkableEdgeBelow(position5);
						if (closestEdge4._edge != null)
						{
							float num7 = info._fallingTimer * -0.5f;
							float num8 = num7 * info._fallingTimer;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
							object obj4 = enumerator & 0;
							float num9 = num8 + num8;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
							object obj5 = num9 & 0;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
							{
								float2 position6 = character.position;
								object obj6 = default(object);
								if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) >= System.Runtime.CompilerServices.Unsafe.As<List<StageEdge>.Enumerator, UIntPtr>(ref enumerator))
								{
									bool flag32 = (object)GM.Core == null;
									if (GM.Core.IsMultiplayer)
									{
										bool flag33 = (object)GM.Core == null;
										PhaserScene scene = GM.Core.scene;
										bool flag34 = scene == null;
										bool flag35 = scene._renderer == null;
										if (!scene._renderer.IsInPlayableScreenBounds((float2)enumerator))
										{
											goto IL_0e5e;
										}
									}
									character.position = (float2)enumerator;
									((PlatformZoneMovement)(nint)intPtr2).LockToEdge(character, info, closestEdge4._edge, (float2)flag22);
									float2 position7 = character.position;
									((PlatformZoneMovement)(nint)intPtr2).TriggerSmokeEmitter((Vector2)enumerator, 10);
									stageEdge = closestEdge4._edge;
									goto IL_0898;
								}
							}
						}
					}
				}
				else
				{
					bool flag36 = (object)character == null;
					float2 position8 = character.position;
					((PlatformZoneMovement)(nint)intPtr2).TriggerSmokeEmitter((Vector2)enumerator, 100);
					float rate = default(float);
					float detune = default(float);
					bool loop = default(bool);
					PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Jump14, 1000f, 10, num, (float?)(object)flag22, rate, detune, loop, 1f);
					info._fallingTimer = -0.5f;
					info._hasJumped = true;
					float2 position9 = character.position;
					character.position = (float2)enumerator;
				}
				goto IL_0e5e;
			}
			if (!(num > info._fallingTimer))
			{
				((PlatformZoneMovement)(nint)intPtr2).LockToEdge(character, info, stageEdge, (float2)flag22);
				result = float2.zero;
				goto IL_0e03;
			}
			float fallingTimer = num2 + info._fallingTimer;
			info._fallingTimer = fallingTimer;
			bool flag37 = (object)character == null;
			character.CheckRenderer();
			character.CheckRenderer();
			bool flag38 = (object)character._spriteRenderer == null;
			Transform transform3 = character._spriteRenderer.transform;
			bool flag39 = (object)transform3 == null;
			Vector3 localEulerAngles2 = transform3.localEulerAngles;
			float deltaTime3 = PauseSystem.DeltaTime;
			if (character.flipX)
			{
			}
			bool flag40 = (object)character._spriteRenderer == null;
			Transform transform4 = character._spriteRenderer.transform;
			bool flag41 = (object)transform4 == null;
			List<StageEdge>.Enumerator enumerator4 = default(List<StageEdge>.Enumerator);
			transform4.localEulerAngles = (Vector3)(&enumerator4);
			if (info._fallingTimer > num)
			{
			}
			float2 result2 = default(float2);
			if (!(num > info._fallingTimer))
			{
				return result2;
			}
			goto IL_0f0b;
		}
		return (float2)enumerator;
		IL_0f0b:
		result = (float2)0;
		goto IL_0e03;
	}

	private void TriggerSmokeEmitter(Vector2 position, int count)
	{
		//IL_0076: Expected O, but got I
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_00eb: Expected O, but got I
		//IL_0139: Expected O, but got I4
		//IL_00d6: Expected O, but got I8
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			ActivateSmokeEmitter(position, count);
			return;
		}
		Action<Vector2, int> action = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r10_v2 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r10_v2 (Il2CppMethodInfo)+4C]");
		object obj = (nint)0 >> 4;
		object obj2 = obj & 1;
		object obj3;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r10_v2 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 2)
			{
				obj3 = 6447775280L;
				goto IL_0130;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v7 (System.Action`2<UnityEngine.Vector2, System.Int32>)+10]");
		obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v7 (System.Action`2<UnityEngine.Vector2, System.Int32>)+20]");
		_ = 0;
		goto IL_0130;
		IL_0130:
		object obj4 = 24;
		_ = 6447775168L;
		int param = default(int);
		bool flag = _sync.SendCommand(action, MessageTarget.All, position, param);
	}

	public void ActivateSmokeEmitter(Vector2 position, int count)
	{
		RenderingExtensions.EmitParticleAt(_smokeEmitter, position, count);
	}

	private unsafe void LockToEdge(ArcadeSprite character, JumpInfo info, StageEdge edge, float2 lastFacingDirection)
	{
		//IL_005d: Expected O, but got Ref
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d3: Invalid comparison between O and F4
		//IL_00f3: Invalid comparison between I4 and F4
		//IL_0112: Invalid comparison between F4 and I4
		info._fallingTimer = 0f;
		info._hasJumped = false;
		character.CheckRenderer();
		Transform transform = character._spriteRenderer.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		float num = edge._rotationAngle * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
		object obj2 = default(object);
		float num2 = num * (float)obj2;
		object obj3 = default(object);
		float num3 = num * (float)obj3;
		float num4 = num3 + num2;
		object obj4 = num4 & -2147483649L;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.1f))
		{
			bool flag = 0f < num4;
			float num5 = 0f - num4;
			bool flag2 = num5 == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			bool flipX = flag4 & flag3;
			ArcadeSprite arcadeSprite = character.setFlipX(flipX);
		}
	}

	private unsafe void InitJumpParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_006f: Expected O, but got I
		//IL_0206: Expected O, but got Ref
		//IL_0220: Expected native int or pointer, but got O
		//IL_046f: Expected O, but got I4
		//IL_0238: Expected O, but got Ref
		//IL_0247: Expected O, but got I4
		//IL_0255: Expected native int or pointer, but got O
		//IL_048c: Expected O, but got I4
		//IL_026d: Expected O, but got Ref
		//IL_0294: Expected O, but got I
		//IL_02ae: Expected native int or pointer, but got O
		//IL_02c8: Expected O, but got I
		//IL_02e8: Expected O, but got Ref
		//IL_0302: Expected native int or pointer, but got O
		//IL_031c: Expected O, but got I
		//IL_033c: Expected O, but got Ref
		//IL_0356: Expected native int or pointer, but got O
		//IL_04b6: Expected O, but got I
		//IL_038e: Expected O, but got Ref
		//IL_03a8: Expected native int or pointer, but got O
		//IL_04f0: Expected O, but got I
		//IL_03f9: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, (string)null);
		_ = 0;
		ParticleEmitterManager pfxEmitterManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+E0]");
			pfxEmitterManager = (ParticleEmitterManager)0;
		}
		else
		{
			pfxEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_pfxEmitterManager = pfxEmitterManager;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Smoke1");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Smoke2");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(-100f, 100f));
		particleSystemConfig._speedX = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
		_ = 0;
		obj = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(-10f, 10f));
		particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
		_ = 0;
		_ = 2;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+E0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+10]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+20]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(500f, 600f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+30]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+40]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.65f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.25f, 0.75f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-58]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-38]");
		_ = 0;
		_ = 0;
		_ = 16772829;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+E0]");
		particleSystemConfig._tint = (uint?)(object)0;
		particleSystemConfig._on = false;
		ParticleSystem smokeEmitter = _pfxEmitterManager.CreateEmitter(particleSystemConfig, null, "JumpSmoke");
		_smokeEmitter = smokeEmitter;
		Vector2 pos = default(Vector2);
		RenderingExtensions.EmitParticleAt(_smokeEmitter, pos, 1);
	}

	private void UpdateCameraTarget()
	{
		ActualUpdateCameraTarget();
	}

	private unsafe void ActualUpdateCameraTarget()
	{
		//IL_0008: Expected O, but got Ref
		//IL_1272: Expected I, but got O
		//IL_12d4: Expected F4, but got I4
		//IL_12dc: Expected F4, but got O
		//IL_12e5: Expected O, but got I4
		//IL_0532: Invalid comparison between I4 and F4
		//IL_0bb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb9: Expected O, but got Unknown
		//IL_0552: Expected F4, but got I4
		//IL_02f5: Expected O, but got I
		//IL_0c26: Expected O, but got I
		//IL_0351: Expected O, but got I
		//IL_1417: Expected F4, but got I4
		//IL_1428: Expected F4, but got O
		//IL_143d: Expected F4, but got I
		//IL_05e1: Expected F4, but got I4
		//IL_038a: Expected O, but got I
		//IL_10a5: Expected O, but got Ref
		//IL_10ca: Invalid comparison between I and F4
		//IL_0df6: Expected O, but got Ref
		//IL_1125: Expected O, but got Ref
		//IL_1140: Unknown result type (might be due to invalid IL or missing references)
		//IL_1145: Expected Ref, but got Unknown
		//IL_1162: Expected F4, but got I
		//IL_0622: Expected F4, but got I
		//IL_0632: Invalid comparison between F4 and I
		//IL_0658: Invalid comparison between F4 and I4
		//IL_0681: Expected O, but got I4
		//IL_0e37: Expected O, but got Ref
		//IL_1191: Expected O, but got Ref
		//IL_0713: Expected F4, but got I
		//IL_0723: Invalid comparison between I and F4
		//IL_0749: Invalid comparison between F4 and I4
		//IL_0772: Expected O, but got I4
		//IL_0e78: Expected O, but got Ref
		//IL_079f: Expected F4, but got I
		//IL_1203: Expected O, but got Ref
		//IL_123f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1244: Expected O, but got Unknown
		//IL_124d: Invalid comparison between F4 and O
		//IL_0814: Expected F4, but got I
		//IL_0824: Invalid comparison between F4 and I
		//IL_084a: Invalid comparison between F4 and I4
		//IL_0873: Expected O, but got I4
		//IL_0ac5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aca: Expected O, but got Unknown
		//IL_0ad3: Invalid comparison between F4 and O
		//IL_0905: Expected F4, but got I
		//IL_0915: Invalid comparison between I and F4
		//IL_093b: Invalid comparison between F4 and I4
		//IL_0964: Expected O, but got I4
		//IL_0991: Expected F4, but got I
		//IL_0f34: Expected O, but got Ref
		//IL_0fbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc1: Expected O, but got Unknown
		//IL_0fd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd6: Expected O, but got Unknown
		//IL_0fff: Expected O, but got I4
		//IL_1036: Expected F4, but got I4
		//IL_0a49: Expected F4, but got I4
		//IL_0106->IL0b2c: Incompatible stack heights: 1 vs 0
		//IL_014b->IL0b2c: Incompatible stack heights: 2 vs 0
		//IL_017f->IL0b2c: Incompatible stack heights: 2 vs 0
		//IL_0ba6->IL0b2c: Incompatible stack heights: 3 vs 0
		//IL_01d8->IL0b2c: Incompatible stack heights: 4 vs 0
		//IL_0d4f->IL0b2c: Incompatible stack heights: 3 vs 0
		//IL_0501->IL0b2c: Incompatible stack heights: 3 vs 0
		//IL_022c->IL0b2c: Incompatible stack heights: 5 vs 0
		//IL_0d6d->IL0b2c: Incompatible stack heights: 3 vs 0
		//IL_0bc6->IL12ea: Incompatible stack heights: 5 vs 3
		//IL_027d->IL0b2c: Incompatible stack heights: 5 vs 0
		//IL_0d94->IL0b2c: Incompatible stack heights: 3 vs 0
		//IL_02a7->IL0b2c: Incompatible stack heights: 5 vs 0
		//IL_0586->IL0b2c: Incompatible stack heights: 3 vs 0
		//IL_142d->IL0b75: Incompatible stack heights: 1 vs 3
		//IL_0a82->IL0b2c: Incompatible stack heights: 3 vs 0
		//IL_0603->IL0b2c: Incompatible stack heights: 3 vs 0
		//IL_11c3->IL0b2b: Incompatible stack heights: 6 vs 0
		//IL_125f->IL0b2b: Incompatible stack heights: 7 vs 0
		//IL_0ae5->IL0b2b: Incompatible stack heights: 7 vs 0
		//IL_0b17->IL0b2c: Incompatible stack heights: 7 vs 0
		//IL_0ef4->IL0a65: Incompatible stack heights: 7 vs 3
		//IL_0b2b->IL0b2b: Incompatible stack heights: 7 vs 0
		//IL_09fa->IL0a65: Incompatible stack heights: 7 vs 3
		//IL_0a1c->IL0b2c: Incompatible stack heights: 7 vs 0
		//IL_1056->IL105b: Incompatible stack heights: 9 vs 5
		//IL_0a65->IL105b: Incompatible stack heights: 9 vs 5
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		GameManager core = GM.Core;
		Vector3 ret;
		float num6;
		float num8;
		float num3;
		float num7;
		if ((object)GM.Core != null)
		{
			GameManager core2 = GM.Core;
			object coopCameraTarget = core._coopCameraTarget;
			List<VampireSurvivors.Objects.Characters.CharacterController> characters = core2._characters;
			if (core2._multiplayer != null)
			{
				Vector3 vector = default(Vector3);
				if (!core2._multiplayer.IsOnlineMultiplayer)
				{
					if (core2._characters != null)
					{
						bool flag = characters._size <= 0;
						VampireSurvivors.Objects.Characters.CharacterController[] items = characters._items;
						if (characters._items != null)
						{
							bool flag2 = items.Length <= 0;
							if ((object)items[0] != null)
							{
								Transform cameraTarget = items[0].CameraTarget;
								if ((object)cameraTarget != null)
								{
									bool flag3 = ((UnityEngine.Object)cameraTarget).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)cameraTarget).m_CachedPtr, out ret);
									nint num = (nint)typeof(Vector3);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1444 @ rax_v247 (Il2CppClass<UnityEngine.Vector3>)+B8]");
									nint num2 = 0;
									Vector3 zeroVector = Vector3.zeroVector;
									num3 = (float)vector * 0.5f;
									_ = Vector3.zeroVector;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1446 @ rcx_v185 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
									float num4 = 0f * 0.5f;
									float num5 = num4;
									num6 = 0f;
									num7 = (float)vector;
									object obj3 = 1;
									VampireSurvivors.Objects.Characters.CharacterController characterController2 = default(VampireSurvivors.Objects.Characters.CharacterController);
									while (true)
									{
										bool flag4 = (nint)obj3 >= characters._size;
										num8 = 0.5f;
										if (flag4)
										{
											break;
										}
										bool flag5 = (nint)obj3 >= characters._size;
										VampireSurvivors.Objects.Characters.CharacterController[] items2 = characters._items;
										float num9;
										if (characters._items != null)
										{
											bool flag6 = (nint)obj3 >= items2.Length;
											VampireSurvivors.Objects.Characters.CharacterController characterController = items2[obj3];
											if ((object)items2[obj3] != null)
											{
												bool flag7 = !characterController._003CTrackedByCamera_003Ek__BackingField;
												num9 = num5;
												if (flag7)
												{
													goto IL_0bab;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
												if ((object)characterController2 != null)
												{
													Transform cameraTarget2 = characterController2.CameraTarget;
													if ((object)cameraTarget2 != null)
													{
														Vector3 position = cameraTarget2.position;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
														float num10 = 0f;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-2D]");
														float num11 = num10 - 0f;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-35]");
														nint num12 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
														object obj4 = num12 - 0;
														float num13 = num6 - num5;
														_ = position.x;
														if (!(position.x > num11))
														{
															num11 = position.x;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-65]");
														if (0 <= (nint)obj4)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-65]");
															obj4 = 0;
														}
														if (!(position.z > num13))
														{
															num13 = position.z;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
														float num14 = 0f;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-2D]");
														float num15 = num14 + 0f;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-35]");
														nint num16 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
														object obj5 = num16 + 0;
														float num17 = num6 + num5;
														_ = position.x;
														if (!(num15 > position.x))
														{
															num15 = position.x;
														}
														object obj6 = obj5;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-75]");
														if ((nint)obj6 <= 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-75]");
															obj5 = 0;
														}
														if (!(num17 > position.z))
														{
															num17 = position.z;
														}
														float num18 = num15 - num11;
														object obj7 = obj5 - obj4;
														float num19 = num17 - num13;
														num7 = num18 * 0.5f;
														num3 = (float)obj7 * 0.5f;
														num4 = num19 * 0.5f;
														float num20 = num13 + num4;
														num9 = num4;
														num6 = num20;
														zeroVector = vector;
														goto IL_0bab;
													}
												}
											}
										}
										goto IL_0b2c;
										IL_0bab:
										obj3++;
										num5 = num9;
									}
									goto IL_0b75;
								}
							}
						}
					}
				}
				else
				{
					object instance = OnlineStageManager._instance;
					if ((object)OnlineStageManager._instance == null)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rbx_v43 (System.Object)+10]");
					if ((nint)0 == 0)
					{
						return;
					}
					if ((object)OnlineStageManager._instance != null)
					{
						PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
						if ((object)myPlayerInfo == null || ((UnityEngine.Object)myPlayerInfo).m_CachedPtr == (IntPtr)0)
						{
							return;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
						OnlineStageManager onlineStageManager = default(OnlineStageManager);
						if ((object)onlineStageManager != null)
						{
							PlayerInfo myPlayerInfo2 = onlineStageManager.GetMyPlayerInfo();
							if ((object)myPlayerInfo2 != null)
							{
								VampireSurvivors.Objects.Characters.CharacterController characterController3 = myPlayerInfo2.CharacterController;
								if ((object)characterController3 != null)
								{
									Transform cameraTarget3 = characterController3.CameraTarget;
									if ((object)cameraTarget3 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ rax_v216 (UnityEngine.Transform)+10]");
										bool flag8 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ rax_v216 (UnityEngine.Transform)+10]");
										Transform.get_position_Injected((IntPtr)0, out ret);
										_ = Vector3.zeroVector;
										num3 = (float)vector * 0.5f;
										num6 = 0f;
										num8 = 0.5f;
										num7 = (float)vector;
										goto IL_0b75;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0b2c;
		IL_1498:
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v29 (System.Object)+10]");
		bool flag9 = (nint)0 == 0;
		object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v29 (System.Object)+10]");
		Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj8);
		_ = MinCameraY;
		float num21;
		if ((object)MinCameraY != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6B]");
			float num4 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6B]");
			bool flag10 = 0f < num21;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6B]");
			float num22 = 0f - num21;
			bool flag11 = num22 == 0f;
			bool flag12 = !flag10;
			bool flag13 = !flag11;
			object obj9 = flag13 & flag12;
			if (obj9 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-65]");
				float num23 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-65]");
				nint num24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6B]");
				bool flag14 = num24 < 0;
				bool flag15 = !flag14;
				if (!flag15)
				{
					if (_003CMoveCameraInsideLimitsOnLimitsEnabled_003Ek__BackingField == flag15)
					{
						goto IL_14e4;
					}
					_ = 1;
				}
				num21 = num4;
			}
		}
		goto IL_14e4;
		IL_157c:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v29 (System.Object)+10]");
		bool flag16 = (nint)0 == 0;
		object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v29 (System.Object)+10]");
		Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj10);
		if (_stageEdges != null)
		{
			return;
		}
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v29 (System.Object)+10]");
		bool flag17 = (nint)0 == 0;
		object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v29 (System.Object)+10]");
		Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj11);
		float num25 = num21;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-65]");
		float num26 = num25 - 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj12 = num26 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.01f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12))
		{
			float cameraYVelocity = _cameraYVelocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj13 = cameraYVelocity & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.01f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13))
			{
				_cameraYVelocity = 0f;
				GameManager core3 = GM.Core;
				if ((object)GM.Core != null)
				{
					core3._003CManualCameraTargetControl_003Ek__BackingField = null;
					return;
				}
				goto IL_0b2c;
			}
			return;
		}
		return;
		IL_14e4:
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v29 (System.Object)+10]");
		bool flag18 = (nint)0 == 0;
		object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v29 (System.Object)+10]");
		Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj14);
		_ = MaxCameraX;
		float num28;
		if ((object)MaxCameraX != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6B]");
			float num23 = 0f;
			float num27 = num28;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6B]");
			bool flag19 = num27 < 0f;
			float num29 = num28;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6B]");
			float num30 = num29 - 0f;
			bool flag20 = num30 == 0f;
			bool flag21 = !flag19;
			bool flag22 = !flag20;
			object obj15 = flag22 & flag21;
			if (obj15 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6B]");
				nint num31 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-79]");
				bool flag23 = num31 < 0;
				bool flag24 = !flag23;
				if (!flag24)
				{
					if (_003CMoveCameraInsideLimitsOnLimitsEnabled_003Ek__BackingField == flag24)
					{
						goto IL_1530;
					}
					_ = 1;
				}
				num28 = num23;
			}
		}
		goto IL_1530;
		IL_1530:
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v29 (System.Object)+10]");
		bool flag25 = (nint)0 == 0;
		nint num32 = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v29 (System.Object)+10]");
		Transform.get_position_Injected((IntPtr)0, out *(Vector3*)num32);
		_ = MinCameraX;
		if ((object)MinCameraX != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6B]");
			float num4 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6B]");
			bool flag26 = 0f < num28;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6B]");
			float num33 = 0f - num28;
			bool flag27 = num33 == 0f;
			bool flag28 = !flag26;
			bool flag29 = !flag27;
			object obj16 = flag29 & flag28;
			if (obj16 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-69]");
				float num23 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-69]");
				nint num34 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6B]");
				bool flag30 = num34 < 0;
				bool flag31 = !flag30;
				if (!flag31 && _003CMoveCameraInsideLimitsOnLimitsEnabled_003Ek__BackingField != flag31)
				{
					_ = 1;
				}
			}
		}
		bool flag32 = !_limitCameraPosition;
		if (flag32 || flag32)
		{
			goto IL_0a65;
		}
		if ((object)core._coopCameraTarget == null)
		{
			goto IL_0b2c;
		}
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v29 (System.Object)+10]");
		bool flag33 = (nint)0 == 0;
		object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v29 (System.Object)+10]");
		Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj17);
		float deltaTime = PauseSystem.DeltaTime;
		float num35 = deltaTime * 3f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BE70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v29 (System.Object)+10]");
		bool flag34 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v29 (System.Object)+10]");
		Transform.get_position_Injected((IntPtr)0, out ret);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
		object obj18 = 0 - ret;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6B]");
		object obj20 = default(object);
		object obj19 = 0 - obj20;
		object obj21 = obj18 * obj18;
		object obj22 = obj19 * obj19;
		object obj23 = 0 * 0;
		object obj24 = obj21 + obj22;
		float num36 = (float)obj24 + (float)obj23;
		bool flag35 = !(0.001f > num36);
		float num37 = 0f;
		num3 = num35;
		ref float reference = ref *(float*)typeof(ArcadePhysics);
		if (!flag35)
		{
			_blendAfterCameraLimitsDisabled = false;
			num37 = 0f;
			num3 = num35;
			reference = ref *(float*)typeof(ArcadePhysics);
		}
		goto IL_157c;
		IL_0a65:
		if ((object)core._coopCameraTarget == null)
		{
			goto IL_0b2c;
		}
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v29 (System.Object)+10]");
		bool flag36 = (nint)0 == 0;
		object obj25 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v29 (System.Object)+10]");
		Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj25);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-75]");
		bool flag37 = !(0f > num21);
		float num38 = 1f;
		if (!flag37)
		{
			num38 = 0.125f;
		}
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v29 (System.Object)+10]");
		bool flag38 = (nint)0 == 0;
		object obj26 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v29 (System.Object)+10]");
		Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj26);
		reference = ref *(float*)(this + 88);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-65]");
		float num39 = Mathf.SmoothDamp(0f, num21, ref reference, num38);
		num37 = num6;
		num36 = num21;
		num7 = num38;
		goto IL_157c;
		IL_0b75:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
		float num40 = 0f * 2f;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					float num41 = renderer.height * num8;
					float num42 = num41 - num40;
					if (0f > num42)
					{
						num42 = 0f;
					}
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene2 = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							PhaserScene.Renderer renderer2 = s_scene2._renderer;
							if (s_scene2._renderer != null)
							{
								float num23 = renderer2.height * 0.25f;
								float num43 = num42 * num8;
								if (!(num23 > num43))
								{
									num43 = num23;
								}
								if (_stageEdges == null)
								{
									num43 = 0f;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
								num28 = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-35]");
								num21 = 0f + num43;
								bool flag39 = !_limitCameraPosition;
								_ = 0;
								if (flag39)
								{
									goto IL_0a65;
								}
								if ((object)core._coopCameraTarget != null)
								{
									_ = 0;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v29 (System.Object)+10]");
									bool flag40 = (nint)0 == 0;
									object obj27 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v29 (System.Object)+10]");
									Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj27);
									_ = MaxCameraY;
									if ((object)MaxCameraY != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6B]");
										num23 = 0f;
										float num44 = num21;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6B]");
										bool flag41 = num44 < 0f;
										float num45 = num21;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6B]");
										float num46 = num45 - 0f;
										bool flag42 = num46 == 0f;
										bool flag43 = !flag41;
										bool flag44 = !flag42;
										object obj28 = flag44 & flag43;
										if (obj28 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6B]");
											nint num47 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-75]");
											bool flag45 = num47 < 0;
											bool flag46 = !flag45;
											if (!flag46)
											{
												if (_003CMoveCameraInsideLimitsOnLimitsEnabled_003Ek__BackingField == flag46)
												{
													goto IL_1498;
												}
												_ = 1;
											}
											num21 = num23;
										}
									}
									goto IL_1498;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0b2c;
		IL_0b2c:
		throw new NullReferenceException();
	}

	public PlatformZoneMovement()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CActualUpdateCameraTarget_003Eg__LimitCameraCoordinate_007C45_0(float? limitValue, bool isMax, float cameraPositionValue, ref float targetPositionValue, ref _003C_003Ec__DisplayClass45_0 P_4)
	{
		//IL_0139: Expected O, but got I4
		//IL_00b0: Invalid comparison between F4 and O
		//IL_009d: Invalid comparison between O and F4
		if ((object)limitValue == null)
		{
			return;
		}
		bool flag;
		object obj2 = default(object);
		bool flag2;
		object obj = default(object);
		if (isMax)
		{
			flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
			object obj3 = obj - obj2;
			flag2 = obj3 == null;
		}
		else
		{
			flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
			object obj4 = obj2 - obj;
			flag2 = obj4 == null;
		}
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj5 = flag4 & flag3;
		if (obj5 == null)
		{
			return;
		}
		bool flag5 = ((!isMax) ? (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)cameraPositionValue) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2)) : (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)cameraPositionValue)));
		bool flag6 = !flag5;
		if (!flag6)
		{
			if (_003CMoveCameraInsideLimitsOnLimitsEnabled_003Ek__BackingField != flag6)
			{
				obj = obj2;
				_ = 1;
			}
		}
		else
		{
			obj = obj2;
		}
	}
}
