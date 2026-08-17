using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Cursors;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Stages;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Items;

public class Pickup_EME_Teleporter : PickupTeleporter
{
	private GameObject _doorClosed;

	private GameObject _doorOpen;

	private float _playerProximityDistance;

	private float _maxDisabledTime;

	private MapToken _mapToken;

	private EME_TeleportFader _teleportFader;

	private float _disabledTimer;

	private bool _disabledDueToProximity;

	public BackgroundEmerald.EmeraldsBiomes EmeraldBiome;

	private BackgroundEmerald _bgManager;

	private BackgroundEmerald.EmeraldsBiomes _myBiome = BackgroundEmerald.EmeraldsBiomes.nil;

	private bool _showingCursor;

	private bool _wantsCursors;

	private bool _isOpen;

	private string _003CDestinationName_003Ek__BackingField;

	public string DestinationName
	{
		get
		{
			return _003CDestinationName_003Ek__BackingField;
		}
		set
		{
			_003CDestinationName_003Ek__BackingField = value;
		}
	}

	public unsafe void Init(EME_TeleportFader teleportFader)
	{
		//IL_005e: Expected F4, but got O
		//IL_0158: Expected I, but got O
		//IL_0160: Expected I, but got O
		//IL_0170: Expected O, but got I
		//IL_01f0: Expected O, but got I4
		//IL_01ac: Expected O, but got I
		//IL_01e2: Expected O, but got I4
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Expected Ref, but got Unknown
		_teleportFader = teleportFader;
		_doorClosed.SetActive(value: true);
		((Pickup)this)._003CDisableGet_003Ek__BackingField = true;
		MapToken mapToken = new MapToken();
		mapToken.texture = "EME_items";
		mapToken.frameName = "EME_DoorIcon";
		float2 float5 = base.position;
		mapToken.x = (float)float5;
		float2 float6 = base.position;
		float y = default(float);
		mapToken.y = y;
		_mapToken = mapToken;
		GameManager core = GM.Core;
		MapToken mapToken2 = _mapToken;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1340");
		BackgroundEmerald bgManager = _bgManager;
		if ((object)_bgManager != null && ((UnityEngine.Object)bgManager).m_CachedPtr != (IntPtr)0)
		{
			goto IL_0202;
		}
		GameManager core2 = GM.Core;
		Stage stage = core2._stage;
		mapToken2 = (MapToken)(object)stage._fancyBg;
		BackgroundEmerald bgManager2;
		if ((object)stage._fancyBg == null)
		{
			bgManager2 = null;
			goto IL_02f0;
		}
		nint num = (nint)typeof(BackgroundEmerald);
		nint num2 = (nint)mapToken2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v727 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundEmerald>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v728 @ r9_v6 (Il2CppClass<VampireSurvivors.App.Objects.MapToken>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v727 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundEmerald>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v728 @ r9_v6 (Il2CppClass<VampireSurvivors.App.Objects.MapToken>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v767 @ rax_v40+FFFFFFF8+v729 @ rax_v35*8]");
			if (0 == (nint)typeof(BackgroundEmerald))
			{
				obj3 = 1;
				goto IL_02ff;
			}
		}
		obj3 = 0;
		goto IL_02ff;
		IL_0202:
		if (_myBiome == BackgroundEmerald.EmeraldsBiomes.nil)
		{
			BackgroundEmerald bgManager3 = _bgManager;
			if ((object)_bgManager != null)
			{
				float2 float7 = base.position;
				Vector2 vector = default(Vector2);
				bool flag = bgManager3._biomeBounds.TryGetBiomePositionIsInside(vector, out *(BackgroundEmerald.EmeraldsBiomes*)(this + 640));
			}
		}
		PlayerOptionsData config = _playerOptions.Config;
		_wantsCursors = config._003CShowPickups_003Ek__BackingField;
		return;
		IL_02f0:
		_bgManager = bgManager2;
		goto IL_0202;
		IL_02ff:
		bool flag2 = obj3 == null;
		bgManager2 = null;
		if (!flag2)
		{
			bgManager2 = (BackgroundEmerald)(object)mapToken2;
		}
		goto IL_02f0;
	}

	public void SetDoorOpen(bool isOpen)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A2F7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = !isOpen;
		string text = "False";
		if (!flag)
		{
			text = "True";
		}
		string message = "Setting door open: " + text;
		Debug.Log(message, this);
		bool flag2 = (byte)((isOpen ? 1u : 0u) ^ 1u) != 0;
		_doorClosed.SetActive(flag2);
		_doorOpen.SetActive(isOpen);
		Transform transform = _doorClosed.transform;
		bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		Transform transform2 = _doorOpen.transform;
		bool flag4 = (object)transform2 == null;
		bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
		_isOpen = isOpen;
		bool flag6 = (byte)((isOpen ? 1u : 0u) ^ 1u) != 0;
		((Pickup)this)._003CDisableGet_003Ek__BackingField = flag6;
		if (!_showingCursor)
		{
			SpawnCursor();
		}
	}

	public void SetDestinationName(string destination)
	{
		_003CDestinationName_003Ek__BackingField = destination;
	}

	public override void GetOnlineTaken()
	{
		//IL_010c: Expected O, but got I4
		GameObject gameObject = base.gameObject;
		bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
		object obj = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
		if (obj == null || _disabledDueToProximity)
		{
			return;
		}
		GameManager core = GM.Core;
		bool flag2;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config = core2._playerOptions.Config;
			if (config._003CSelectedOnlineFreeRoam_003Ek__BackingField)
			{
				flag2 = base._canTeleportLocally;
				goto IL_0137;
			}
		}
		flag2 = base._canTeleport;
		goto IL_0137;
		IL_0137:
		if (flag2)
		{
			((NetworkPickup)this).GetOnlineTaken();
		}
	}

	public override void GetTaken()
	{
		//IL_0186: Expected O, but got I4
		GameObject gameObject = base.gameObject;
		bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
		object obj = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
		if (obj == null || _disabledDueToProximity || ((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			return;
		}
		if (!base._canTeleport)
		{
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				return;
			}
		}
		base._canTeleport = false;
		GameManager core2 = GM.Core;
		if (core2._multiplayer.IsOnlineMultiplayer)
		{
			VampireSurvivors.Objects.Characters.CharacterController targetPlayer = _targetPlayer;
			if (!targetPlayer._coherenceSync.HasStateAuthority)
			{
				goto IL_01c5;
			}
		}
		base._canTeleportLocally = false;
		Disable();
		base._link.Disable();
		StartTeleport();
		TrackItemPickup();
		goto IL_01c5;
		IL_01c5:
		Reset();
	}

	protected unsafe override void DoTeleportAnimation()
	{
		Action onFadeInComplete = base.DoTeleport;
		Action action = base.OnTeleportFinished;
		action._002Ector(this, (nint)__ldftn(PickupTeleporter.OnTeleportFinished));
		_teleportFader.BeginFade(onFadeInComplete, action);
	}

	protected override void GenerateSpritesAndAnims()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CSelectedInverse_003Ek__BackingField)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			if (config2._003CVisuallyInvertStages_003Ek__BackingField)
			{
				Transform doorTransform = _doorClosed.transform;
				InvertDoor(doorTransform);
				Transform transform = _doorOpen.transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 158 Invalid \"Jump target not found in method: 0x187372BC0\"");
			}
		}
	}

	private void InvertDoor(Transform doorTransform)
	{
		bool flag = ((UnityEngine.Object)doorTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_localScale_Injected(((UnityEngine.Object)doorTransform).m_CachedPtr, out Vector3 _);
		bool flag2 = ((UnityEngine.Object)doorTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)doorTransform).m_CachedPtr, ref value);
	}

	public void TemporarilyDisableDueToProximity()
	{
		_disabledDueToProximity = true;
	}

	public override void InternalUpdate()
	{
		//IL_01ca: Expected O, but got F4
		//IL_02cc: Expected O, but got I4
		//IL_0311: Expected O, but got F4
		//IL_032b->IL034b: Incompatible stack heights: 4 vs 0
		//IL_0184->IL0330: Incompatible stack heights: 4 vs 0
		((Pickup)this).InternalUpdate();
		if (!_hasSpawned && IsAnyPlayerInGuardSpawnRange())
		{
			base.TriggerSpawn();
		}
		BackgroundEmerald bgManager = _bgManager;
		if (_myBiome == bgManager._003CCurrentBiome_003Ek__BackingField)
		{
			if (!_showingCursor && _wantsCursors != _showingCursor)
			{
				SpawnCursor();
			}
		}
		else if (_showingCursor || _wantsCursors == _showingCursor)
		{
			RemoveCursor();
		}
		if (!_disabledDueToProximity)
		{
			return;
		}
		object obj = UnityEngine.Time.unscaledDeltaTime;
		object obj2 = default(object);
		float disabledTimer = (float)obj2 + _disabledTimer;
		_disabledTimer = disabledTimer;
		float num = (float)obj2 + _disabledTimer;
		if (!(num > _maxDisabledTime))
		{
			GameManager core = GM.Core;
			Component component = null;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator mainCharacters = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)core._mainCharacters;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
			object obj4 = default(object);
			object obj5 = default(object);
			object obj10;
			do
			{
				if (enumerator.MoveNext())
				{
					Transform transform = ((Component)null).transform;
					bool flag = (object)transform == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ rax_v40 (UnityEngine.Transform)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ rax_v40 (UnityEngine.Transform)+10]");
					Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
					Transform transform2 = base.transform;
					bool flag3 = (object)transform2 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v812 @ rax_v46 (UnityEngine.Transform)+10]");
					bool flag4 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v812 @ rax_v46 (UnityEngine.Transform)+10]");
					Transform.get_position_Injected((IntPtr)0, out Vector3 ret2);
					object obj3 = obj4 - obj5;
					object obj6 = ret - ret2;
					component = (Component)(0 * 0);
					object obj7 = obj3 * obj3;
					object obj8 = obj6 * obj6;
					object obj9 = obj8 + obj7;
					obj10 = obj9 + (object)component;
					mainCharacters = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(_playerProximityDistance * _playerProximityDistance);
					continue;
				}
				return;
			}
			while (System.Runtime.CompilerServices.Unsafe.As<List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator, UIntPtr>(ref mainCharacters) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10));
		}
		_disabledDueToProximity = false;
		_disabledTimer = 0f;
	}

	public void SetMapTokenHidden(bool isHidden)
	{
		if (_mapToken != null)
		{
			MapToken mapToken = _mapToken;
			mapToken.Hidden = isHidden;
		}
	}

	protected unsafe override void OnDrawGizmos()
	{
		//IL_0011: Invalid comparison between F4 and I4
		//IL_0092: Expected F4, but got Ref
		//IL_0097->IL0037: Incompatible stack heights: 1 vs 0
		base.OnDrawGizmos();
		if (_playerProximityDistance > 0f)
		{
			Color value = default(Color);
			Gizmos.set_color_Injected(ref value);
			Transform transform = base.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
			Gizmos.DrawWireSphere_Injected(ref *(Vector3*)(&value), (float)(nint)(&ret));
		}
	}

	protected override void ToggleCursors(UISignals.ToggleGuidesSignal sig)
	{
		//IL_002a: Expected I4, but got O
		if ((object)sig == null)
		{
			_wantsCursors = (byte)(int)sig != 0;
			RemoveCursor();
		}
		else
		{
			_wantsCursors = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 18 Invalid \"Jump target not found in method: 0x187373380\"");
		}
	}

	private void SpawnCursor()
	{
		//IL_01fd: Expected O, but got I4
		//IL_0029->IL0194: Incompatible stack heights: 1 vs 0
		//IL_0055->IL0194: Incompatible stack heights: 1 vs 0
		//IL_017f->IL0194: Incompatible stack heights: 1 vs 0
		_showingCursor = false;
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			object obj = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			if (obj == null)
			{
				return;
			}
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					if (!config._003CShowPickups_003Ek__BackingField || !_isOpen)
					{
						return;
					}
					_showingCursor = true;
					CursorData cursorData = new CursorData
					{
						IconAlpha = 1f,
						_cursorProportionOfScreenFromCenter = 0.45f,
						AnimationName = "arrowNeutral_0"
					};
					_ = 1;
					_ = 8;
					_ = 16;
					Sprite sprite = SpriteManager.GetSprite("arrowNeutral_01", "UI");
					_ = 1073741824;
					_ = 1065353216;
					_ = 0;
					Sprite sprite2 = SpriteManager.GetSprite("EME_DoorIcon_sm", "EME_items");
					GameObject gameObject2 = base.gameObject;
					if (_signalBus != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4920");
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void RemoveCursor()
	{
		_showingCursor = false;
		Transform transform = base.transform;
		GameObject gameObject = transform.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4A10");
	}

	public Pickup_EME_Teleporter()
	{
		base._canTeleport = true;
		_hasDoorAnimation = true;
		_triggerDelay = 10000f;
		((PickupGuarded)this)._002Ector();
	}

	private void _003CInternalUpdate_003Eg__ReenableTeleporter_007C27_0()
	{
		_disabledDueToProximity = false;
		_disabledTimer = 0f;
	}
}
