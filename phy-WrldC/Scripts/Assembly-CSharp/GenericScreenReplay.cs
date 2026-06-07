using UltimateReplay;
using UnityEngine;

public class GenericScreenReplay : ReplayBehaviour
{
	private GenericScreen genericScreen;

	private GameObject genericScreenCanvas;

	public override void Awake()
	{
		base.Awake();
		genericScreen = GetComponent<GenericScreen>();
		genericScreenCanvas = base.transform.Find("GenericSceenCanvas").gameObject;
	}

	public override void OnReplaySerialize(UltimateReplay.ReplayState state)
	{
		state.Write(genericScreen.CurrentValue);
	}

	public override void OnReplayDeserialize(UltimateReplay.ReplayState state)
	{
		genericScreen.SetScreenValue(state.ReadFloat());
	}

	public override void OnReplayStart()
	{
		Behaviour[] componentsInChildren = genericScreenCanvas.GetComponentsInChildren<Behaviour>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = true;
		}
	}
}
