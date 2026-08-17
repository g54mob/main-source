using System;
using Cpp2ILInjected;
using UnityEngine;

public class ArcadePhysicsRunner : MonoBehaviour
{
	public bool _DrawDebug;

	private bool _RunPhysics;

	private int _gizmoRunningCooldown;

	protected void Update()
	{
		if (!PauseSystem._paused)
		{
			if (_gizmoRunningCooldown <= 0)
			{
				_gizmoRunningCooldown = 0;
			}
			else
			{
				int gizmoRunningCooldown = _gizmoRunningCooldown - 1;
				_gizmoRunningCooldown = gizmoRunningCooldown;
			}
			if (_RunPhysics)
			{
				VSDebug.s_drawDebug = _DrawDebug;
				ArcadePhysics.s_world.update();
			}
		}
	}

	private void LateUpdate()
	{
		if (!PauseSystem._paused && _RunPhysics)
		{
			ArcadePhysics.s_world.postUpdate();
		}
	}

	private void OnDestroy()
	{
		ArcadePhysics s_instance = ArcadePhysics.s_instance;
		if ((object)ArcadePhysics.s_instance != null && ((UnityEngine.Object)s_instance).m_CachedPtr != (IntPtr)0)
		{
			if (ArcadePhysics.s_world != null)
			{
				ArcadePhysics.s_world.destroy();
			}
			ArcadePhysics.s_world = null;
			ArcadePhysics.s_scene = null;
		}
	}

	private void OnDrawGizmos()
	{
		_gizmoRunningCooldown = 2;
	}

	public ArcadePhysicsRunner()
	{
		//IL_0020: Expected I, but got O
		_RunPhysics = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
