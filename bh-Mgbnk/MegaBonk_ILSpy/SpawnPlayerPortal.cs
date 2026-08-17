using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Managers;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class SpawnPlayerPortal : MonoBehaviour
{
	private sealed class _003CDoPortal_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SpawnPlayerPortal _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CDoPortal_003Ed__12(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0012: Expected O, but got I8
			//IL_002c: Expected O, but got I8
			while (true)
			{
				int num = _003C_003E1__state;
				if (_003C_003E1__state > 6)
				{
					break;
				}
				object obj = 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rdx_v1+3633A8+v29 @ rax_v2 (System.Int32)*4]");
				object obj2 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ rcx_v3 (should have been resolved before IL gen)");
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	public AudioSource audioOpen;

	public AudioSource audioLoop;

	public AudioSource audioClose;

	public AudioSource audioPassing;

	public GameObject blockObjectSpawns;

	public Transform portalRender;

	private Vector3 portalScale;

	public ParticleSystem passingFx;

	public static Action A_PortalOpen;

	public static Action A_PortalClosed;

	private bool movePlayer;

	private float moveTime = 1f;

	private float moveTimer;

	private Vector3 playerStartPosition;

	private Vector3 desiredPosition;

	private float openTime = 0.5f;

	private float scaleTimer;

	private bool open;

	public unsafe void StartPortal()
	{
		//IL_00d8: Expected O, but got Ref
		//IL_00d8: Expected O, but got Ref
		//IL_010b: Expected O, but got Ref
		//IL_012b: Expected O, but got Ref
		//IL_036a: Expected I, but got O
		//IL_0203: Expected O, but got Ref
		if (MapController.index == 0)
		{
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager.config;
			CFGameSettings cfGameSettings = config.cfGameSettings;
			if (cfGameSettings.skip_portal_animation == 1)
			{
				Transform transform = base.transform;
				Vector3 position = transform.position;
				Transform transform2 = base.transform;
				Vector3 forward = transform2.forward;
				float num = default(float);
				float num2 = default(float);
				MyPlayer.Instance.Spawn((Vector3)(&num), (Vector3)(&num2));
				MyPlayer instance = MyPlayer.Instance;
				Transform transform3 = base.transform;
				Vector3 forward2 = transform3.forward;
				Vector3 vector = VectorExtensions.XZVector((Vector3)(&num2));
				instance.playerInput.SetSpawnDirection((Vector3)(&num));
				Transform transform4 = PlayerCamera.Instance.transform;
				Transform transform5 = base.transform;
				Vector3 position2 = transform5.position;
				Transform transform6 = base.transform;
				Vector3 forward3 = transform6.forward;
				float num3 = forward3.x * -5f;
				float num4 = num3 + position2.x;
				float num5 = forward3.y * -5f;
				float num6 = num5 + position2.y;
				float num7 = forward3.z * -5f;
				float num8 = num7 + position2.z;
				nint num9 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rax_v46 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num10 = 0;
				float num11 = (float)Vector3.upVector * 5f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v365 @ rcx_v37 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
				float num12 = 0f * 5f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v365 @ rcx_v37 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				float num13 = 0f * 5f;
				float num14 = num11 + num4;
				float num15 = num12 + num6;
				float num16 = num13 + num8;
				transform4.position = (Vector3)(&num2);
				Transform transform7 = PlayerCamera.Instance.transform;
				Transform target = base.transform;
				transform7.LookAt(target);
				GameManager.Instance.StartPlaying();
				UiManager instance2 = UiManager.Instance;
				if ((object)UiManager.Instance != null)
				{
					instance2.mapTile.StartAnimation();
				}
				PlayerCamera instance3 = PlayerCamera.Instance;
				instance3.cameraState = PlayerCamera.ECameraState.Player3rd;
				Transform transform8 = blockObjectSpawns.transform;
				transform8.parent = null;
				DestroyObject destroyObject = blockObjectSpawns.AddComponent<DestroyObject>();
				destroyObject.time = 1f;
				Action a_PortalClosed = A_PortalClosed;
				if (A_PortalClosed != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v775.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
				GameObject obj = base.gameObject;
				UnityEngine.Object.Destroy(obj);
				return;
			}
		}
		_003CDoPortal_003Ed__12 obj2 = new _003CDoPortal_003Ed__12(0);
		obj2._003C_003E1__state = 0;
		obj2._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj2);
	}

	private bool CanSkipPortalAnimation()
	{
		return MapController.index == 0;
	}

	private IEnumerator DoPortal()
	{
		_003CDoPortal_003Ed__12 obj = new _003CDoPortal_003Ed__12(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void PassShake()
	{
		ControllerShaker.Shake(0, 0.4f, 0.25f);
	}

	private unsafe void MovePlayer()
	{
		//IL_0116: Invalid comparison between I4 and F4
		//IL_0041: Expected F4, but got I4
		//IL_0069: Invalid comparison between I4 and F4
		//IL_00b4: Expected F4, but got I4
		//IL_00c6: Expected O, but got Ref
		if (!movePlayer)
		{
			return;
		}
		float num = MyTime.deltaTime / moveTime;
		float num2 = num + moveTimer;
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		moveTimer = num2;
		Transform transform = MyPlayer.Instance.transform;
		float num3 = moveTimer;
		if (!(0f > moveTimer))
		{
			if (num3 > 1f)
			{
				num3 = 1f;
			}
		}
		else
		{
			num3 = 0f;
		}
		float num4 = default(float);
		transform.position = (Vector3)(&num4);
	}

	private unsafe void Update()
	{
		//IL_0118: Invalid comparison between F4 and I4
		//IL_021b: Invalid comparison between I4 and F4
		//IL_0266: Expected F4, but got I4
		//IL_0163: Invalid comparison between I4 and F4
		//IL_01ae: Expected F4, but got I4
		//IL_0099: Invalid comparison between I4 and F4
		//IL_00e6: Expected F4, but got I4
		//IL_02c9: Invalid comparison between I4 and F4
		//IL_01ea: Expected F4, but got I4
		//IL_01fe: Expected O, but got Ref
		MovePlayer();
		if (!open)
		{
			goto IL_010d;
		}
		if (1f > scaleTimer)
		{
			float deltaTime = Time.deltaTime;
			float num = deltaTime / openTime;
			float num2 = num + scaleTimer;
			if (!(0f > num2))
			{
				if (num2 > 1f)
				{
					scaleTimer = 1f;
					goto IL_0203;
				}
			}
			else
			{
				num2 = 0f;
			}
			scaleTimer = num2;
		}
		else if (!open)
		{
			goto IL_010d;
		}
		goto IL_0203;
		IL_010d:
		if (scaleTimer > 0f)
		{
			float deltaTime2 = Time.deltaTime;
			float num3 = deltaTime2 / openTime;
			float num4 = scaleTimer - num3;
			if (!(0f > num4))
			{
				if (num4 > 1f)
				{
					num4 = 1f;
				}
			}
			else
			{
				num4 = 0f;
			}
			scaleTimer = num4;
			float num5 = Easing.InOutCirc(scaleTimer);
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
			float num6 = default(float);
			portalRender.localScale = (Vector3)(&num6);
		}
		goto IL_0203;
		IL_0203:
		float num7 = Easing.InOutCirc(scaleTimer);
		if (!(0f > num7))
		{
			if (num7 > 1f)
			{
				num7 = 1f;
			}
		}
		else
		{
			num7 = 0f;
		}
		float volume = num7 * 0.5f;
		audioLoop.volume = volume;
	}

	private void ClosePortal()
	{
		audioClose.Play();
	}
}
