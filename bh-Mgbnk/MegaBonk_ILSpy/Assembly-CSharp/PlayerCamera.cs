using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Managers;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using MilkShake;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	public enum ECameraState
	{
		Portal,
		Player3rd,
		Player1st,
		Death
	}

	public Vector3 offset3rdPerson;

	private float currentBob;

	private float desiredBob;

	public Shaker shaker;

	private ECameraState cameraState;

	public CameraOutlines cameraOutlines;

	public Camera camera;

	private bool inited;

	public static PlayerCamera Instance;

	private float defaultZ;

	private Transform portal;

	public bool isPortalCameraFocusingPlayer;

	private float currentZ;

	private float maxExtraZoomoutDistance;

	public bool useCenter;

	public Transform testingTarget;

	public Camera deathCamera;

	public RenderTexture deathRenderTexture;

	private float deathOffset;

	public static Action<GameObject> A_CameraFadeObjectEnter;

	private float cameraRadius;

	public float testDist;

	private void Awake()
	{
		TryInit();
	}

	public void TryInit()
	{
		//IL_004a: Expected F4, but got I
		//IL_005c: Expected F4, but got I
		//IL_00d9: Expected O, but got I4
		//IL_00e7: Expected I, but got O
		//IL_00f0: Expected O, but got I4
		//IL_0131: Expected O, but got I4
		//IL_013f: Expected I, but got O
		//IL_0148: Expected O, but got I4
		//IL_01c1: Expected I, but got O
		//IL_01ca: Expected O, but got I4
		//IL_03f3: Expected O, but got I4
		//IL_0195: Expected I, but got O
		//IL_0208: Expected I, but got O
		//IL_0216: Expected I, but got O
		//IL_021f: Expected O, but got I4
		//IL_0259: Expected O, but got I4
		//IL_0291: Expected O, but got I4
		//IL_02bc: Expected O, but got I4
		//IL_02e4: Expected O, but got I4
		//IL_030b: Expected F4, but got O
		//IL_0325: Expected O, but got I4
		//IL_0342: Expected F4, but got O
		if (inited)
		{
			return;
		}
		inited = true;
		Delegate obj6;
		object obj3;
		if (Instance == null)
		{
			Instance = this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerCamera)+28]");
			defaultZ = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerCamera)+28]");
			currentZ = 0f;
			Action<float> b = OnPlayerLanded;
			Delegate obj = Delegate.Combine(PlayerMovement.A_Landed, b);
			nint num;
			object obj2;
			Delegate obj4;
			if ((object)obj == null)
			{
				PlayerMovement.A_Landed = (Action<float>)obj;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<float> action = default(Action<float>);
				bool flag = action == null;
				obj2 = 0;
				num = (nint)typeof(Action<float>);
				obj3 = 0;
				obj4 = obj;
				if (flag)
				{
					goto IL_039c;
				}
				PlayerMovement.A_Landed = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj5 = default(object);
				bool flag2 = obj5 == null;
				obj2 = 0;
				num = (nint)typeof(Action<float>);
				obj3 = 0;
				obj4 = obj;
				if (flag2)
				{
					goto IL_03a7;
				}
			}
			Action<string, object, object> b2 = OnSettingUpdated;
			obj6 = Delegate.Combine(CurrentSettings.A_SettingUpdated, b2);
			if ((object)obj6 == null)
			{
				CurrentSettings.A_SettingUpdated = (Action<string, object, object>)obj6;
				nint num2 = (nint)CurrentSettings.A_SettingUpdated;
				goto IL_0237;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string, object, object> action2 = default(Action<string, object, object>);
			bool flag3 = action2 == null;
			num = (nint)typeof(Action<string, object, object>);
			obj3 = 0;
			if (!flag3)
			{
				CurrentSettings.A_SettingUpdated = action2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj7 = default(object);
				bool flag4 = obj7 == null;
				nint num2 = (nint)typeof(Action<string, object, object>);
				num = (nint)typeof(Action<string, object, object>);
				obj3 = 0;
				if (!flag4)
				{
					goto IL_0237;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			obj2 = 0;
			obj4 = obj6;
			goto IL_03a7;
		}
		GameObject obj8 = base.gameObject;
		UnityEngine.Object.Destroy(obj8);
		return;
		IL_03a7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_039c;
		IL_039c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0237:
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		bool flag5 = (object)SaveManager._003CInstance_003Ek__BackingField == null;
		obj3 = 0;
		if (!flag5)
		{
			ConfigSaveFile config = saveManager.config;
			bool flag6 = saveManager.config == null;
			obj3 = 0;
			if (!flag6)
			{
				bool flag7 = config.cfVideoSettings == null;
				obj3 = 0;
				if (!flag7)
				{
					bool flag8 = (object)camera == null;
					obj3 = 0;
					if (!flag8)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ebx,dword ptr [rdx+24h]\"");
						camera.fieldOfView = (float)obj6;
						bool flag9 = (object)deathCamera == null;
						obj3 = 0;
						if (!flag9)
						{
							deathCamera.fieldOfView = (float)obj6;
							UpdateZoom();
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnDestroy()
	{
		//IL_01ed: Expected O, but got I4
		//IL_01fb: Expected I, but got O
		//IL_0204: Expected O, but got I4
		//IL_00d2: Expected O, but got I4
		//IL_00e0: Expected I, but got O
		//IL_00e9: Expected O, but got I4
		//IL_0154: Expected O, but got I4
		//IL_0162: Expected I, but got O
		//IL_016b: Expected O, but got I4
		//IL_01ac: Expected O, but got I4
		//IL_01ba: Expected I, but got O
		//IL_01c3: Expected O, but got I4
		if (!(Instance == this))
		{
			return;
		}
		Action<float> value = OnPlayerLanded;
		Delegate obj = Delegate.Remove(PlayerMovement.A_Landed, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerMovement.A_Landed = (Action<float>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<float> action = default(Action<float>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				obj2 = obj;
				obj3 = 0;
				num = (nint)typeof(Action<float>);
				obj4 = 0;
				goto IL_0252;
			}
			PlayerMovement.A_Landed = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			obj2 = obj;
			obj3 = 0;
			num2 = (nint)typeof(Action<float>);
			obj4 = 0;
			if (flag)
			{
				goto IL_020f;
			}
		}
		Action<string, object, object> value2 = OnSettingUpdated;
		Delegate obj6 = Delegate.Remove(CurrentSettings.A_SettingUpdated, value2);
		if ((object)obj6 == null)
		{
			CurrentSettings.A_SettingUpdated = (Action<string, object, object>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<string, object, object> action2 = default(Action<string, object, object>);
		bool flag2 = action2 == null;
		obj2 = obj6;
		obj3 = 0;
		num2 = (nint)typeof(Action<string, object, object>);
		obj4 = 0;
		if (flag2)
		{
			goto IL_0242;
		}
		CurrentSettings.A_SettingUpdated = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		obj2 = obj6;
		obj3 = 0;
		num = (nint)typeof(Action<string, object, object>);
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_0252;
		IL_0242:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_020f;
		IL_020f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0252:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0242;
	}

	private void Start()
	{
		StageData stageData = MapController._003CcurrentStage_003Ek__BackingField;
		camera.farClipPlane = stageData.farClipPlane;
	}

	private void AdjustCameraFar()
	{
		StageData stageData = MapController._003CcurrentStage_003Ek__BackingField;
		camera.farClipPlane = stageData.farClipPlane;
	}

	public ECameraState GetCameraState()
	{
		return cameraState;
	}

	private void Update()
	{
		//IL_0022: Invalid comparison between I4 and F4
		//IL_006d: Expected F4, but got I4
		//IL_0164: Invalid comparison between I4 and F4
		//IL_00a9: Expected F4, but got I4
		float deltaTime = Time.deltaTime;
		float num = deltaTime * 7f;
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		float num2 = 0f - desiredBob;
		float num3 = num2 * num;
		float num4 = (desiredBob = num3 + desiredBob);
		float deltaTime2 = Time.deltaTime;
		float num5 = deltaTime2 * 12f;
		if (!(0f > num5))
		{
			if (num5 > 1f)
			{
				num5 = 1f;
			}
		}
		else
		{
			num5 = 0f;
		}
		bool flag = cameraState == ECameraState.Player3rd;
		float num6 = num4 - currentBob;
		float num7 = num6 * num5;
		float num8 = num7 + currentBob;
		currentBob = num8;
		if (flag)
		{
			return;
		}
		if (cameraState != ECameraState.Death)
		{
			if (cameraState == ECameraState.Portal)
			{
				PortalCamera();
			}
		}
		else
		{
			DeathCam();
		}
	}

	private void UpdateBob()
	{
		//IL_0022: Invalid comparison between I4 and F4
		//IL_006d: Expected F4, but got I4
		//IL_010c: Invalid comparison between I4 and F4
		//IL_00a9: Expected F4, but got I4
		float deltaTime = Time.deltaTime;
		float num = deltaTime * 7f;
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		float num2 = 0f - desiredBob;
		float num3 = num2 * num;
		float num4 = (desiredBob = num3 + desiredBob);
		float deltaTime2 = Time.deltaTime;
		float num5 = deltaTime2 * 12f;
		if (!(0f > num5))
		{
			if (num5 > 1f)
			{
				num5 = 1f;
			}
		}
		else
		{
			num5 = 0f;
		}
		float num6 = num4 - currentBob;
		float num7 = num6 * num5;
		float num8 = num7 + currentBob;
		currentBob = num8;
	}

	public void SetCameraState(ECameraState state)
	{
		cameraState = state;
	}

	public unsafe void CameraInput(Vector3 playerRotation)
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_00b2: Expected O, but got Ref
		//IL_00de: Expected O, but got Ref
		if (cameraState == ECameraState.Player3rd)
		{
			float num = playerRotation.x * ((float)Math.PI / 180f);
			float num2 = playerRotation.z * ((float)Math.PI / 180f);
			object obj = default(object);
			Vector3 euler = (Vector3)(obj - 56);
			float num3 = playerRotation.y * ((float)Math.PI / 180f);
			Quaternion quaternion = Quaternion.Internal_FromEulerRad(euler);
			Transform transform = base.transform;
			float num4 = default(float);
			transform.rotation = (Quaternion)(&num4);
			Vector3 cameraPosition = GetCameraPosition();
			Transform transform2 = base.transform;
			transform2.position = (Vector3)(&num4);
		}
	}

	public unsafe void StartPortalCamera(Transform portal)
	{
		//IL_004a: Expected O, but got Ref
		//IL_0082: Expected O, but got Ref
		//IL_00a2: Expected O, but got Ref
		isPortalCameraFocusingPlayer = false;
		this.portal = portal;
		Transform transform = base.transform;
		Transform transform2 = portal.transform;
		Vector3 position = transform2.position;
		Vector3 forward = portal.forward;
		float num = default(float);
		transform.position = (Vector3)(&num);
		Transform transform3 = base.transform;
		transform3.LookAt(portal);
		MyPlayer instance = MyPlayer.Instance;
		Vector3 forward2 = portal.forward;
		Vector3 vector = VectorExtensions.XZVector((Vector3)(&num));
		instance.playerInput.SetSpawnDirection((Vector3)(&num));
	}

	public void StopPortalCamera()
	{
		cameraState = ECameraState.Player3rd;
	}

	private unsafe void PortalCamera()
	{
		//IL_0008: Expected O, but got Ref
		//IL_01e0: Invalid comparison between I4 and F4
		//IL_022b: Expected F4, but got I4
		//IL_0243: Expected O, but got Ref
		//IL_03cd: Expected I, but got O
		//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Expected O, but got Unknown
		//IL_0416: Expected O, but got I
		//IL_0433: Expected O, but got I
		//IL_00eb: Invalid comparison between I4 and F4
		//IL_0136: Expected F4, but got I4
		//IL_02aa: Expected O, but got Ref
		//IL_034b: Expected O, but got Ref
		//IL_0359: Expected O, but got Ref
		//IL_014e: Expected O, but got Ref
		//IL_0381: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (!isPortalCameraFocusingPlayer && portal != null)
		{
			Vector3 position = portal.position;
			Vector3 forward = portal.forward;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerCamera)+28]");
			float num = 0f + 3f;
			float num2 = num * forward.x;
			float num3 = num * forward.y;
			float num4 = num * forward.z;
			nint num5 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rax_v29 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num6 = 0;
			_ = Vector3.upVector;
			Vector3 upVector = Vector3.upVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerCamera)+24]");
			object obj3 = upVector * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-65]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerCamera)+24]");
			object obj4 = num7 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ rcx_v25 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerCamera)+24]");
			object obj5 = num8 * 0;
			float num9 = (float)obj3 + num2;
			float num10 = (float)obj4 + num3;
			float num11 = (float)obj5 + num4;
			float num12 = num9 + position.x;
			float num13 = num10 + position.y;
			float num14 = num11 + position.z;
			Transform transform = base.transform;
			Transform transform2 = base.transform;
			Vector3 position2 = transform2.position;
			float deltaTime = Time.deltaTime;
			float num15 = deltaTime * 0.9f;
			if (!(0f > num15))
			{
				if (num15 > 1f)
				{
					num15 = 1f;
				}
			}
			else
			{
				num15 = 0f;
			}
			float num16 = num12 - position2.x;
			float num17 = num13 - position2.y;
			float num18 = num14 - position2.z;
			float num19 = num16 * num15;
			float num20 = num17 * num15;
			float num21 = num18 * num15;
			float num22 = num19 + position2.x;
			float num23 = num20 + position2.y;
			float num24 = num21 + position2.z;
			Vector3 position3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
			transform.position = position3;
			Transform transform3 = base.transform;
			transform3.LookAt(portal);
			return;
		}
		Transform transform4 = base.transform;
		Transform transform5 = base.transform;
		Vector3 position4 = transform5.position;
		Vector3 cameraPosition = GetCameraPosition();
		float deltaTime2 = Time.deltaTime;
		float num25 = deltaTime2 * 5f;
		if (!(0f > num25))
		{
			if (num25 > 1f)
			{
				num25 = 1f;
			}
		}
		else
		{
			num25 = 0f;
		}
		float num26 = cameraPosition.x - position4.x;
		float num27 = cameraPosition.y - position4.y;
		float num28 = cameraPosition.z - position4.z;
		float num29 = num26 * num25;
		float num30 = num27 * num25;
		float num31 = num28 * num25;
		float num32 = num29 + position4.x;
		float num33 = num30 + position4.y;
		float num34 = num31 + position4.z;
		Vector3 position5 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		transform4.position = position5;
		Transform transform6 = base.transform;
		Transform transform7 = base.transform;
		Quaternion rotation = transform7.rotation;
		MyPlayer instance = MyPlayer.Instance;
		PlayerInput playerInput = instance.playerInput;
		Vector3 euler = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		float num35 = (float)playerInput.cameraRotation * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v17 (PlayerInput)+40]");
		float num36 = 0f * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v17 (PlayerInput)+3C]");
		float num37 = 0f * ((float)Math.PI / 180f);
		Quaternion quaternion = Quaternion.Internal_FromEulerRad(euler);
		_ = rotation.x;
		_ = quaternion.x;
		float deltaTime3 = Time.deltaTime;
		float t = deltaTime3 * 3f;
		Quaternion b = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		Quaternion a = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		Quaternion quaternion2 = Quaternion.Lerp(a, b, t);
		Quaternion rotation2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		_ = quaternion2.x;
		transform6.rotation = rotation2;
	}

	public unsafe Vector3 GetPortalOffsetPosition(Vector3 portalForward)
	{
		//IL_0067: Expected I, but got O
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00aa: Expected O, but got I
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00f4: Expected native int or pointer, but got O
		//IL_0101: Expected native int or pointer, but got O
		//IL_010e: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerCamera)+28]");
		float num = 0f + 3f;
		float num2 = num * portalForward.x;
		float num3 = num * portalForward.y;
		float num4 = num * portalForward.z;
		nint num5 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerCamera)+24]");
		object obj = 0 * Vector3.upVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerCamera)+24]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v2 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		object obj2 = num7 * 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerCamera)+24]");
		object obj4 = default(object);
		object obj3 = 0 * obj4;
		float x = (float)obj + num2;
		float z = (float)obj2 + num4;
		float y = (float)obj3 + num3;
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = x;
		((Vector3*)(nint)vector)->z = z;
		((Vector3*)(nint)vector)->y = y;
		return vector;
	}

	private unsafe void PlayerCam(Vector3 playerRotation)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0090: Expected O, but got Ref
		//IL_00bc: Expected O, but got Ref
		float num = playerRotation.x * ((float)Math.PI / 180f);
		float num2 = playerRotation.z * ((float)Math.PI / 180f);
		object obj = default(object);
		Vector3 euler = (Vector3)(obj - 56);
		float num3 = playerRotation.y * ((float)Math.PI / 180f);
		Quaternion quaternion = Quaternion.Internal_FromEulerRad(euler);
		Transform transform = base.transform;
		float num4 = default(float);
		transform.rotation = (Quaternion)(&num4);
		Vector3 cameraPosition = GetCameraPosition();
		Transform transform2 = base.transform;
		transform2.position = (Vector3)(&num4);
	}

	public unsafe void MovePositionOnly()
	{
		//IL_0027: Expected O, but got Ref
		Vector3 cameraPosition = GetCameraPosition();
		Transform transform = base.transform;
		float num = default(float);
		transform.position = (Vector3)(&num);
	}

	private unsafe void DeathCam()
	{
		//IL_0008: Expected O, but got Ref
		//IL_013d: Expected O, but got Ref
		//IL_015f: Expected O, but got Ref
		//IL_01d5: Expected O, but got Ref
		//IL_01e3: Expected O, but got Ref
		//IL_020b: Expected O, but got Ref
		//IL_02e9: Expected I, but got O
		//IL_025b: Invalid comparison between I4 and F4
		//IL_02a6: Expected F4, but got I4
		//IL_02be: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		Transform transform2 = MyPlayer.Instance.transform;
		Vector3 up = transform2.up;
		MyPlayer instance = MyPlayer.Instance;
		Transform transform3 = instance.playerRenderer.transform;
		Vector3 up2 = transform3.up;
		float num = up2.y * 0.55f;
		float num2 = up2.x * 0.55f;
		float num3 = num + position.y;
		float num4 = up2.z * 0.55f;
		float num5 = num2 + position.x;
		float num6 = num4 + position.z;
		Transform transform4 = base.transform;
		Vector3 position2 = transform4.position;
		_ = up.x;
		_ = up.z;
		Vector3 upwards = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		float num7 = num6 - position2.z;
		Vector3 forward = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		Quaternion quaternion = Quaternion.LookRotation(forward, upwards);
		Transform transform5 = base.transform;
		Transform transform6 = base.transform;
		Quaternion rotation = transform6.rotation;
		_ = quaternion.x;
		_ = rotation.x;
		float deltaTime = Time.deltaTime;
		Quaternion b = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		Quaternion a = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		Quaternion quaternion2 = Quaternion.Lerp(a, b, deltaTime);
		Quaternion rotation2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		_ = quaternion2.x;
		transform5.rotation = rotation2;
		nint num8 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ rax_v22 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num9 = 0;
		float num10 = (float)Vector3.upVector * 4.5f;
		float num11 = num10 + num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rcx_v23 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
		float num12 = 0f * 4.5f;
		float num13 = num12 + num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rcx_v23 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		float num14 = 0f * 4.5f;
		float num15 = num14 + num6;
		Transform transform7 = base.transform;
		Transform transform8 = base.transform;
		Vector3 position3 = transform8.position;
		float deltaTime2 = Time.deltaTime;
		float num16 = deltaTime2 * 0.5f;
		if (!(0f > num16))
		{
			if (num16 > 1f)
			{
				num16 = 1f;
			}
		}
		else
		{
			num16 = 0f;
		}
		float num17 = num11 - position3.x;
		float num18 = num13 - position3.y;
		float num19 = num15 - position3.z;
		float num20 = num17 * num16;
		float num21 = num18 * num16;
		float num22 = num19 * num16;
		float num23 = num20 + position3.x;
		float num24 = num21 + position3.y;
		float num25 = num22 + position3.z;
		Vector3 position4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		transform7.position = position4;
	}

	private unsafe Vector3 GetPlayerHeadPosition()
	{
		//IL_00d1: Expected native int or pointer, but got O
		//IL_00e3: Expected native int or pointer, but got O
		//IL_012b: Expected I, but got O
		//IL_01c6: Expected I, but got O
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_022c: Expected O, but got I
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Expected O, but got Unknown
		//IL_0276: Expected native int or pointer, but got O
		//IL_0283: Expected native int or pointer, but got O
		//IL_0290: Expected native int or pointer, but got O
		Vector3 vector = default(Vector3);
		if (!useCenter)
		{
			if ((object)GameManager.Instance != null)
			{
				MyPlayer player = GameManager.Instance.GetPlayer();
				if ((object)player != null && (object)player.head != null)
				{
					Vector3 position = player.head.position;
					nint num = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rdx_v6 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num2 = 0;
					float num3 = (float)Vector3.downVector * 0.5f;
					float num4 = num3 + position.x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v17 (Il2CppStaticFields<UnityEngine.Vector3>)+28]");
					float num5 = 0f * 0.5f;
					float num6 = num5 + position.y;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v17 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
					float num7 = 0f * 0.5f;
					float num8 = num7 + position.z;
					nint num9 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rdx_v7 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerCamera)+24]");
					object obj = 0 * Vector3.upVector;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerCamera)+24]");
					nint num11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v19 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
					object obj2 = num11 * 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerCamera)+24]");
					object obj4 = default(object);
					object obj3 = 0 * obj4;
					float x = (float)obj + num4;
					float z = (float)obj2 + num8;
					float y = (float)obj3 + num6;
					((Vector3*)(nint)vector)->x = x;
					((Vector3*)(nint)vector)->z = z;
					((Vector3*)(nint)vector)->y = y;
					return vector;
				}
			}
		}
		else if ((object)MyPlayer.Instance != null)
		{
			Transform transform = MyPlayer.Instance.transform;
			if ((object)transform != null)
			{
				Vector3 position2 = transform.position;
				((Vector3*)(nint)vector)->x = position2.x;
				((Vector3*)(nint)vector)->z = position2.z;
				return vector;
			}
		}
		return (Vector3)new NullReferenceException();
	}

	private unsafe Vector3 GetCameraPosition()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_09fd: Invalid comparison between I4 and F4
		//IL_0063: Expected F4, but got I4
		//IL_0196: Expected O, but got F4
		//IL_0173: Expected F4, but got I4
		//IL_0155: Expected O, but got F4
		//IL_086e: Expected I, but got O
		//IL_03d0: Expected O, but got Ref
		//IL_03fa: Expected O, but got I4
		//IL_040c: Expected O, but got I4
		//IL_06b9: Expected O, but got Ref
		//IL_06e0: Invalid comparison between I4 and F4
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Expected O, but got Unknown
		//IL_072b: Expected F4, but got I4
		//IL_0750: Expected O, but got F4
		//IL_0763: Expected O, but got F4
		//IL_0776: Expected O, but got F4
		//IL_0940: Expected I, but got O
		//IL_09de: Expected I, but got O
		//IL_08be: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c3: Expected O, but got Unknown
		//IL_0ab3: Expected native int or pointer, but got O
		//IL_0ac0: Expected native int or pointer, but got O
		//IL_0acd: Expected native int or pointer, but got O
		//IL_0661: Invalid comparison between F4 and O
		object obj2 = default(object);
		object obj = obj2 - 104;
		_ = 0;
		_ = 0;
		Vector3 playerHeadPosition = GetPlayerHeadPosition();
		_ = playerHeadPosition.y;
		_ = playerHeadPosition.z;
		float num = MyTime.runTimer / 1320f;
		if (!(0f > num))
		{
			if (num > 1.5f)
			{
				num = 1.5f;
			}
		}
		else
		{
			num = 0f;
		}
		if (MapController.isFinalBossStage)
		{
			if ((object)GameManager.Instance == null)
			{
				goto IL_0805;
			}
			if (!GameManager.Instance.IsFinalBossDead())
			{
				num *= 0.5f;
			}
		}
		if ((object)camera != null)
		{
			float num2 = num * maxExtraZoomoutDistance;
			float fieldOfView = camera.fieldOfView;
			float num4;
			if (!(90f > fieldOfView))
			{
				if (fieldOfView > 90f)
				{
					float num3 = fieldOfView - 90f;
					object obj3 = num3 ^ -0f;
					num4 = (float)obj3 / 10f;
				}
				else
				{
					num4 = 0f;
				}
			}
			else
			{
				float num5 = fieldOfView - 90f;
				object obj4 = num5 ^ -0f;
				num4 = (float)obj4 / 5f;
			}
			float num6 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerCamera)+28]");
			float num7 = num6 + 0f;
			float num8 = num7 + num4;
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				Vector3 forward = transform.forward;
				float num9 = num8 * forward.x;
				float num10 = num8 * forward.y;
				float num11 = playerHeadPosition.x - num9;
				float num12 = num8 * forward.z;
				float num13 = playerHeadPosition.y - num10;
				float num14 = playerHeadPosition.z - num12;
				Transform transform2 = base.transform;
				if ((object)transform2 != null)
				{
					Vector3 forward2 = transform2.forward;
					float num15 = cameraRadius * forward2.z;
					float num16 = num13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
					float num17 = num16 - 0f;
					float num18 = num14;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+88]");
					float num19 = num18 - 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					nint num20 = (nint)typeof(Math);
					float num21 = num11 - playerHeadPosition.x;
					float num22 = num13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
					float num23 = num22 - 0f;
					float num24 = num14;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+88]");
					float num25 = num24 - 0f;
					float num26 = num23 * num23;
					float num27 = num21 * num21;
					float num28 = num25 * num25;
					float num29 = num26 + num27;
					float num30 = num29 + num28;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ rcx_v19 (Il2CppClass<System.Math>)+E4]");
					if ((nint)0 <= (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
					}
					else
					{
						double num31 = Math.Sqrt(num30);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm7,xmm0\"");
					GameManager instance = GameManager.Instance;
					if ((object)GameManager.Instance != null)
					{
						float num32 = 0f - cameraRadius;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
						object obj5 = default(object);
						int layerMask = default(int);
						RaycastHit[] array = Physics.SphereCastAll((Ray)(&obj5), cameraRadius, num32, layerMask);
						if (array != null)
						{
							object obj6 = 0;
							float num33 = 3.4028235E+38f;
							object obj7 = 0;
							RaycastHit raycastHit = default(RaycastHit);
							object obj9 = default(object);
							float num34 = default(float);
							float num35 = default(float);
							Vector3 vector = default(Vector3);
							while (true)
							{
								if ((nint)obj7 < array.Length)
								{
									object obj8 = obj6 * 44;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v883 @ rcx_v34+30+v581 @ rax_v28 (UnityEngine.RaycastHit[])]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v883 @ rcx_v34+3C+v581 @ rax_v28 (UnityEngine.RaycastHit[])]");
									_ = 0;
									Collider collider = raycastHit.collider;
									if ((object)collider == null)
									{
										break;
									}
									GameObject gameObject = collider.gameObject;
									if ((object)gameObject == null)
									{
										break;
									}
									if (!gameObject.CompareTag("CameraFade"))
									{
										Collider collider2 = raycastHit.collider;
										if ((object)collider2 == null)
										{
											break;
										}
										GameObject gameObject2 = collider2.gameObject;
										if ((object)gameObject2 == null)
										{
											break;
										}
										if (!gameObject2.CompareTag("CameraIgnore"))
										{
											Collider collider3 = raycastHit.collider;
											if ((object)collider3 == null)
											{
												break;
											}
											GameObject gameObject3 = collider3.gameObject;
											if ((object)gameObject3 == null)
											{
												break;
											}
											if (!gameObject3.CompareTag("Ignore"))
											{
												Collider collider4 = raycastHit.collider;
												if ((object)collider4 == null)
												{
													break;
												}
												if (!collider4.isTrigger)
												{
													Collider collider5 = raycastHit.collider;
													if ((object)collider5 == null)
													{
														break;
													}
													GameObject gameObject4 = collider5.gameObject;
													if ((object)gameObject4 == null)
													{
														break;
													}
													if (!gameObject4.CompareTag("Interactable"))
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18231C560");
														if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num33) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9))
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18231C560");
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18231C560");
															num8 = num34;
															num33 = num35;
														}
													}
												}
											}
										}
									}
									obj6++;
									obj7 = obj6;
									continue;
								}
								CheckFadeObjects((Ray)(&obj5), num32, 6f);
								float deltaTime = Time.deltaTime;
								float num36 = deltaTime * 30f;
								if (!(0f > num36))
								{
									if (num36 > 1f)
									{
										num36 = 1f;
									}
								}
								else
								{
									num36 = 0f;
								}
								float num37 = num8 - currentZ;
								float num38 = num37 * num36;
								float num39 = (currentZ = num38 + currentZ);
								Transform transform3 = base.transform;
								if ((object)transform3 == null)
								{
									break;
								}
								Vector3 forward3 = transform3.forward;
								object obj10 = forward3.x ^ -0f;
								object obj11 = forward3.y ^ -0f;
								object obj12 = forward3.z ^ -0f;
								float num40 = (float)obj10 * num39;
								float num41 = (float)obj11 * num39;
								float num42 = (float)obj12 * num39;
								nint num43 = (nint)typeof(Vector3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1043 @ rdx_v16 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num44 = 0;
								float num45 = num40 + (float)Vector3.upVector;
								float num46 = num41;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1044 @ rax_v35 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
								float num47 = num46 + 0f;
								float num48 = num42;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1044 @ rax_v35 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
								float num49 = num48 + 0f;
								float num50 = num45 + playerHeadPosition.x;
								float num51 = num47;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
								float num52 = num51 + 0f;
								float num53 = num49;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+88]");
								float num54 = num53 + 0f;
								nint num55 = (nint)typeof(Vector3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v657 @ rdx_v17 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num56 = 0;
								float num57 = (float)Vector3.downVector * currentBob;
								float num58 = num17 * currentBob;
								float x = num57 + num50;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1055 @ rax_v37 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
								float num59 = 0f * currentBob;
								float y = num58 + num52;
								float z = num59 + num54;
								((Vector3*)(nint)vector)->x = x;
								((Vector3*)(nint)vector)->y = y;
								((Vector3*)(nint)vector)->z = z;
								return vector;
							}
						}
					}
				}
			}
		}
		goto IL_0805;
		IL_0805:
		return (Vector3)new NullReferenceException();
	}

	private unsafe void CheckFadeObjects(Ray ray, float distance, float radius)
	{
		//IL_0166: Expected native int or pointer, but got O
		//IL_0042: Expected O, but got Ref
		//IL_0054: Expected O, but got I4
		//IL_005d: Expected O, but got I4
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		float num = radius + 0.25f;
		float num2 = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [ray @ rdx (UnityEngine.Ray)+14]");
		float num3 = num2 * 0f;
		GameManager instance = GameManager.Instance;
		float num4 = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [ray @ rdx (UnityEngine.Ray)+8]");
		float num5 = num4 + 0f;
		Vector3 origin = default(Vector3);
		((Ray*)(nint)ray)->m_Origin = origin;
		float maxDistance = distance + radius;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		Vector3 vector = default(Vector3);
		int layerMask = default(int);
		RaycastHit[] array = Physics.SphereCastAll((Ray)(&vector), radius, maxDistance, layerMask);
		object obj = 0;
		object obj2 = 0;
		RaycastHit raycastHit = default(RaycastHit);
		while ((nint)obj2 < array.Length)
		{
			object obj3 = obj * 44;
			Collider collider = raycastHit.collider;
			GameObject gameObject = collider.gameObject;
			if (gameObject.CompareTag("CameraFade"))
			{
				Action<GameObject> a_CameraFadeObjectEnter = A_CameraFadeObjectEnter;
				if (A_CameraFadeObjectEnter != null)
				{
					Collider collider2 = raycastHit.collider;
					GameObject gameObject2 = collider2.gameObject;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v272 @ rsi_v4 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
				}
			}
			obj++;
			obj2 = obj;
		}
	}

	public void DeathCamera()
	{
		int width = Screen.width;
		int height = Screen.height;
		RenderTexture renderTexture = new RenderTexture(width, height, 24);
		renderTexture._002Ector(width, height, 24);
		deathRenderTexture = renderTexture;
		deathRenderTexture.useMipMap = false;
		deathRenderTexture.autoGenerateMips = false;
		deathRenderTexture.format = RenderTextureFormat.ARGB32;
		deathCamera.targetTexture = deathRenderTexture;
		GameObject gameObject = deathCamera.gameObject;
		gameObject.SetActive(value: true);
		cameraState = ECameraState.Death;
	}

	public void HideDeathCamera()
	{
		GameObject gameObject = deathCamera.gameObject;
		gameObject.SetActive(value: false);
	}

	private void OnPlayerLanded(float fallSpeed)
	{
		if (!(6f > fallSpeed))
		{
			desiredBob = 2f;
		}
	}

	private void BobOnce(float strength = 0.5f)
	{
		desiredBob = strength;
	}

	private unsafe Vector3 GetBobOffset()
	{
		//IL_0013: Expected I, but got O
		//IL_0067: Expected native int or pointer, but got O
		//IL_0074: Expected native int or pointer, but got O
		//IL_0081: Expected native int or pointer, but got O
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		float x = currentBob * (float)Vector3.downVector;
		object obj = default(object);
		float y = currentBob * (float)obj;
		float num3 = currentBob;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ r8_v1 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
		float z = num3 * 0f;
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->y = y;
		((Vector3*)(nint)vector)->x = x;
		((Vector3*)(nint)vector)->z = z;
		return vector;
	}

	private float Get3rdPersonOffset()
	{
		//IL_01c8: Invalid comparison between I4 and F4
		//IL_003c: Expected F4, but got I4
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_0135: Expected F4, but got I4
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		float num = MyTime.runTimer / 1320f;
		if (!(0f > num))
		{
			if (num > 1.5f)
			{
				num = 1.5f;
			}
		}
		else
		{
			num = 0f;
		}
		if (MapController.isFinalBossStage && !GameManager.Instance.IsFinalBossDead())
		{
			num *= 0.5f;
		}
		float num2 = num * maxExtraZoomoutDistance;
		float fieldOfView = camera.fieldOfView;
		float num4;
		if (!(90f > fieldOfView))
		{
			if (fieldOfView > 90f)
			{
				float num3 = fieldOfView - 90f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
				object obj = num3 ^ 0;
				num4 = (float)obj / 10f;
			}
			else
			{
				num4 = 0f;
			}
		}
		else
		{
			float num5 = fieldOfView - 90f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
			object obj2 = num5 ^ 0;
			num4 = (float)obj2 / 5f;
		}
		float num6 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerCamera)+28]");
		float num7 = num6 + 0f;
		return num7 + num4;
	}

	private unsafe Vector3 Get3rdPersonOffset(float zValue)
	{
		//IL_0047: Expected O, but got F4
		//IL_005a: Expected O, but got F4
		//IL_006d: Expected O, but got F4
		//IL_00bb: Expected I, but got O
		//IL_0111: Expected native int or pointer, but got O
		//IL_011e: Expected native int or pointer, but got O
		//IL_012b: Expected native int or pointer, but got O
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Vector3 forward = transform.forward;
			object obj = forward.x ^ -0f;
			object obj2 = forward.y ^ -0f;
			object obj3 = forward.z ^ -0f;
			float num = (float)obj * zValue;
			float num2 = (float)obj2 * zValue;
			float num3 = (float)obj3 * zValue;
			nint num4 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v6 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num5 = 0;
			float x = num + (float)Vector3.upVector;
			float num6 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v4 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
			float y = num6 + 0f;
			float num7 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v4 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			float z = num7 + 0f;
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = x;
			((Vector3*)(nint)vector)->y = y;
			((Vector3*)(nint)vector)->z = z;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	private void OnSettingUpdated(string name, object oldValue, object newValue)
	{
		//IL_004b: Expected O, but got I4
		//IL_01b0: Expected O, but got I4
		//IL_0072: Expected I, but got O
		//IL_0082: Expected O, but got I
		//IL_00ac: Expected O, but got I4
		//IL_01d7: Expected I, but got O
		//IL_01e7: Expected O, but got I
		//IL_0211: Expected O, but got I4
		//IL_00e6: Expected O, but got I4
		//IL_0139: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183171FED]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (!(name == "fov"))
		{
			goto IL_016d;
		}
		bool flag = newValue == null;
		object obj = 0;
		string text = "fov";
		string text2 = name;
		if (!flag)
		{
			nint num = (nint)newValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B58]");
			text = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v12 (Il2CppClass<System.Object>)+40]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rdx_v2 (System.String)+40]");
			bool flag2 = num2 != 0;
			obj = 0;
			text2 = (string)newValue;
			if (flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				goto IL_0284;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
			bool flag3 = (object)camera == null;
			obj = 0;
			text2 = (string)(object)camera;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ebp,dword ptr [rax]\"");
				float num3 = default(float);
				camera.fieldOfView = num3;
				bool flag4 = (object)deathCamera == null;
				float num4 = num3;
				obj = 0;
				text2 = (string)(object)deathCamera;
				if (!flag4)
				{
					deathCamera.fieldOfView = num3;
					num4 = num3;
					goto IL_016d;
				}
			}
		}
		goto IL_023d;
		IL_016d:
		if (name == "camera_distance")
		{
			bool flag5 = newValue == null;
			obj = 0;
			text = "camera_distance";
			text2 = name;
			if (flag5)
			{
				goto IL_023d;
			}
			nint num5 = (nint)newValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B58]");
			text = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rcx_v9 (Il2CppClass<System.Object>)+40]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rdx_v2 (System.String)+40]");
			bool flag6 = num6 != 0;
			obj = 0;
			text2 = (string)newValue;
			if (!flag6)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
				UpdateZoom();
				return;
			}
			goto IL_0284;
		}
		return;
		IL_0284:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_023d:
		throw new NullReferenceException();
	}

	public void SetFov(int fov)
	{
		//IL_000f: Expected F4, but got I4
		//IL_0023: Expected F4, but got I4
		camera.fieldOfView = fov;
		deathCamera.fieldOfView = fov;
	}

	public void SetZoom(float ratio)
	{
		UpdateZoom();
	}

	private void UpdateZoom()
	{
		if (SaveManager._003CInstance_003Ek__BackingField != null)
		{
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager.config;
			CFVideoSettings cfVideoSettings = config.cfVideoSettings;
			float num = cfVideoSettings.camera_distance + defaultZ;
			float num2 = cfVideoSettings.camera_distance + defaultZ;
			currentZ = num;
		}
	}

	public PlayerCamera()
	{
		//IL_000b: Expected O, but got I4
		offset3rdPerson = (Vector3)0;
		_ = 1056964608;
		_ = 1092091904;
		maxExtraZoomoutDistance = 15f;
		deathOffset = 4f;
		cameraRadius = 1f;
		base._002Ector();
	}
}
