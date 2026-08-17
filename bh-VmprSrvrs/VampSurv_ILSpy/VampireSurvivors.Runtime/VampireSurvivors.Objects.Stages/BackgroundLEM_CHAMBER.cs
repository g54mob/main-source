using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundLEM_CHAMBER : BackgroundManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__9_0;

		public static Predicate<Equipment> _003C_003E9__9_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003COnInitCompleted_003Eb__9_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1700;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003COnInitCompleted_003Eb__9_1(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1700;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private MeshRenderer _magicWaterImage;

	private Vector2 _playerVelocity;

	private Vector2 _uvOffset;

	private static readonly int PlayerVelocityHash;

	public List<WeaponType> LemonEvos;

	public override void Create()
	{
		base.Create();
		InitVFX();
	}

	private void Update()
	{
		UpdatePlayerVelocity();
	}

	private unsafe void UpdatePlayerVelocity()
	{
		//IL_0122: Expected O, but got F4
		//IL_0163: Expected O, but got F4
		//IL_0209: Expected O, but got Ref
		GameManager core = GM.Core;
		VampireSurvivors.Objects.Characters.CharacterController characterController;
		if ((object)GM.Core != null && ((UnityEngine.Object)core).m_CachedPtr != (IntPtr)0)
		{
			GameManager core2 = GM.Core;
			if (core2._multiplayer.IsOnlineMultiplayer)
			{
				VampireSurvivors.Objects.Characters.CharacterController myOnlinePlayer = GM.Core.MyOnlinePlayer;
				characterController = myOnlinePlayer;
			}
			else
			{
				VampireSurvivors.Objects.Characters.CharacterController playerOne = GM.Core.PlayerOne;
				characterController = playerOne;
			}
		}
		else
		{
			characterController = null;
		}
		if ((object)characterController == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		float frameWalk = characterController.FrameWalk;
		float num = (float)characterController._lastMovementDirection * frameWalk;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v2 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
		float num2 = 0f * frameWalk;
		_playerVelocity = (Vector2)num;
		float num3 = num + (float)_uvOffset;
		float num4 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundLEM_CHAMBER)+94]");
		float num5 = num4 + 0f;
		MeshRenderer magicWaterImage = _magicWaterImage;
		_uvOffset = (Vector2)num3;
		if ((object)_magicWaterImage != null && ((UnityEngine.Object)magicWaterImage).m_CachedPtr != (IntPtr)0)
		{
			Material material = ((Renderer)_magicWaterImage).GetMaterial();
			if ((object)material != null && ((UnityEngine.Object)material).m_CachedPtr != (IntPtr)0)
			{
				Material material2 = ((Renderer)_magicWaterImage).GetMaterial();
				object obj = default(object);
				material2.SetVector(PlayerVelocityHash, (Vector4)(&obj));
			}
		}
	}

	private void InitVFX()
	{
		//IL_01d1: Expected I4, but got I8
		GameObject original = Resources.Load<GameObject>("LemonBG");
		Camera main = Camera.main;
		Transform parent = main.transform;
		GameObject gameObject = UnityEngine.Object.Instantiate(original, parent, worldPositionStays: false);
		int2 renderTextureSize = CameraExtensions.GetRenderTextureSize(_mainCamera);
		Transform transform = gameObject.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		Transform transform2 = gameObject.transform;
		Transform child = transform2.GetChild(0);
		GameObject gameObject2 = child.gameObject;
		int layer = (gameObject2.layer = LayerMask.NameToLayer("Default"));
		gameObject.layer = layer;
		Transform transform3 = gameObject.transform;
		Transform child2 = transform3.GetChild(0);
		MeshRenderer component = child2.GetComponent<MeshRenderer>();
		_magicWaterImage = component;
		Transform magicWaterImage = (Transform)(object)_magicWaterImage;
		bool flag2 = ((UnityEngine.Object)magicWaterImage).m_CachedPtr == (IntPtr)0;
		Renderer.set_sortingOrder_Injected(((UnityEngine.Object)magicWaterImage).m_CachedPtr, -9000);
		Transform transform4 = _magicWaterImage.transform;
		bool flag3 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value2);
	}

	public unsafe override void OnInitCompleted()
	{
		//IL_001b: Expected O, but got I4
		//IL_0601: Expected O, but got I
		//IL_007e: Expected O, but got I
		//IL_0093: Expected O, but got I
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_024f: Expected O, but got I4
		//IL_01db: Expected O, but got I
		//IL_02a3: Expected O, but got Ref
		base.OnInitCompleted();
		List<WeaponType> list = LemonEvos;
		object obj2 = default(object);
		object obj = obj2;
		object obj3 = 0;
		object obj4 = default(object);
		object obj6 = default(object);
		nint num2 = default(nint);
		object obj10 = default(object);
		while (true)
		{
			PlayerOptionsData playerOptionsData;
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rdx_v40+1C]");
				if (obj4 != null)
				{
					break;
				}
				object obj5 = obj6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rdx_v40+18]");
				if ((nint)obj5 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rdx_v40+10]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rax_v124+20+v234 @ stack_-58_v19*4]");
				object obj8 = 0;
				obj6++;
				GameManager core = GM.Core;
				PlayerOptions playerOptions = core._playerOptions;
				if (playerOptions._onlineClientWithRunDataConfig == null)
				{
					if (playerOptions._hostGameConfig == null)
					{
						if (playerOptions._currentAdventureSaveData != null)
						{
							playerOptionsData = playerOptions._currentAdventureSaveData;
							if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
							{
								goto IL_0175;
							}
						}
						playerOptionsData = playerOptions._mainGameConfig;
					}
					else
					{
						playerOptionsData = playerOptions._hostGameConfig;
					}
				}
				else
				{
					playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
				}
				goto IL_0175;
			}
			throw new NullReferenceException();
			IL_0175:
			BackgroundManager backgroundManager = (BackgroundManager)(object)playerOptionsData._003CCollectedWeapons_003Ek__BackingField;
			bool flag = ((MonoBehaviour)backgroundManager).m_CancellationTokenSource == null;
			nint num = num2;
			object obj9 = obj;
			List<WeaponType> list2 = list;
			if (!flag)
			{
				list2 = (List<WeaponType>)(object)((MonoBehaviour)backgroundManager).m_CancellationTokenSource;
				backgroundManager = (BackgroundManager)(nint)((UnityEngine.Object)backgroundManager).m_CachedPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				bool flag2 = (nint)obj10 != -1;
				num = 0;
				obj9 = obj2;
				num2 = 0;
				obj = obj2;
				list = (List<WeaponType>)(object)((MonoBehaviour)backgroundManager).m_CancellationTokenSource;
				if (flag2)
				{
					continue;
				}
			}
			num2 = num;
			obj = obj9;
			list = list2;
			obj3 = 1;
		}
		bool flag3 = obj == null;
		BackgroundManager backgroundManager2 = (BackgroundManager)0;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rdx_v40+1C]");
			if (obj4 == null)
			{
				if (obj3 != null)
				{
					List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
					if (enumerator.MoveNext())
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController = null;
						AccessoriesFacade accessoriesFacade = (AccessoriesFacade)(&enumerator);
						throw new NullReferenceException();
					}
				}
				else
				{
					Vector2 playerStartingPosition = GetPlayerStartingPosition();
					Vector2 pos = default(Vector2);
					float value = default(float);
					ItemType relicType = default(ItemType);
					bool validatePickups = default(bool);
					Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.WEAPON, WeaponType.LEM_ACC_SABOTEUR, value, relicType, validatePickups);
				}
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			backgroundManager2 = null;
		}
		throw new NullReferenceException();
	}

	public BackgroundLEM_CHAMBER()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_020e: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0236: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_025e: Expected O, but got I
		//IL_01c0: Expected O, but got I
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1704);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1704;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1706);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1706;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1702);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1702;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1708);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1708;
		}
		LemonEvos = list;
		base._002Ector();
	}

	static BackgroundLEM_CHAMBER()
	{
		int playerVelocityHash = Shader.PropertyToID("_PlayerVelocity");
		PlayerVelocityHash = playerVelocityHash;
	}
}
