using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LauncherAgent : SceneManager, ILogOrigin
{
	private enum WM
	{
		USER = 0x400
	}

	private enum WPARAM
	{
		GAME_STARTED = 100,
		GAME_STOPPED = 101,
		AGENT_STARTED = 200,
		AGENT_STOPPED = 201,
		ADD_PERMISSION_GRANT = 1000,
		REMOVE_PERMISSION_GRANT = 1001,
		CONFIGURATION_CHANGE = 1100
	}

	public SpriteRenderer editorDesktopBg;

	public Light2D desktopModeLight;

	private bool canApplicationQuit;

	private SerializedDesktopGadgetState beforeDesktopMode_state;

	public override void Setup()
	{
	}

	private void OnDestroy()
	{
	}

	public override void OnGadgetTurnOn(Gadget.State lastState)
	{
	}

	public override void OnGadgetTurnOff(Gadget.State lastState)
	{
	}

	public override void OnDestroyGadget()
	{
	}

	private Vector2 GetModuleMouseOffset(Module module)
	{
		return default(Vector2);
	}

	public override void SetGadget(Gadget gadget, bool positionImmediatly = false)
	{
	}

	private bool ApplicationWantsToQuit()
	{
		return false;
	}

	private void OnApplicationQuit()
	{
	}

	public override Rect GetGadgetAreaRect()
	{
		return default(Rect);
	}

	public void RefreshZoom()
	{
	}

	public IEnumerator SetDesktopMode()
	{
		return null;
	}

	public void RunDesktopMode()
	{
	}

	public void EndDesktopMode()
	{
	}

	private void EndDesktopMode_RestoreGadgetState()
	{
	}

	public bool ShouldStopDesktopMode()
	{
		return false;
	}

	public void StartDesktopMoveMotherboard()
	{
	}

	public void UpdateDesktopMoveMotherboard()
	{
	}

	public void StopDesktopMoveMotherboard()
	{
	}

	public bool ShouldPlaceMotherboard()
	{
		return false;
	}
}
