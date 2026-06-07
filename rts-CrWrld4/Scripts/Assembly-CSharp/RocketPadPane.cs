using UnityEngine;
using UnityEngine.UI;

public class RocketPadPane : MonoBehaviour
{
	public RocketPadPayloadControl[] payloadControls;

	public Toggle autoLaunch;

	public GameObject rocketGO;

	public Material rocketBuiltMaterial;

	public Material rocketNotBuiltMaterial;

	private RocketPad rocketPad;

	private Renderer rocketGORenderer;

	public void SetRocketPad(RocketPad rocketPad)
	{
	}

	public RocketPad GetRocketPad()
	{
		return null;
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void Update()
	{
	}

	public void AssignPayloads(int pos)
	{
	}

	public void ChangeAutoPayload(int pos)
	{
	}

	private void SetPayloadControlsAuto(int pos, bool val)
	{
	}

	public void LaunchRocket()
	{
	}

	public void AutoLaunchToggle(bool val)
	{
	}
}
