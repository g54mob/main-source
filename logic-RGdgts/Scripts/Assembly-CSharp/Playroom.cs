using System.Collections;

public class Playroom : SceneManager, ILogOrigin
{
	private struct WebGLData
	{
		public string meta;

		public string gadget;
	}

	public const float areaWidth = 1152f;

	public const float areaHeight = 1040f;

	public Lamp lamp;

	public float startupLightDelay;

	public override void Setup()
	{
	}

	protected override void Update()
	{
	}

	public IEnumerator Idle()
	{
		return null;
	}

	public IEnumerator RunMultiToolMode()
	{
		return null;
	}

	public IEnumerator SetMultitoolMode()
	{
		return null;
	}

	public IEnumerator SetIdleMode()
	{
		return null;
	}

	public override void OnDestroyGadget()
	{
	}

	public override void SetGadget(Gadget gadget, bool positionImmediatly = false)
	{
	}

	public void LoadWebGLData(string data)
	{
	}

	public void StartMoveMotherboard()
	{
	}

	public void UpdateMoveMotherboard()
	{
	}

	public void StopMoveMotherboard()
	{
	}

	public bool ShouldPlaceMotherboard()
	{
		return false;
	}

	private void UpdateMovingMotherboardValidPositionMarker()
	{
	}
}
