using UltimateReplay;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(DynamicObjectBase))]
public class DynamicObjectReplay : ReplayBehaviour
{
	private DynamicObjectBase dynamicObjectBase;

	public override void Awake()
	{
		base.Awake();
		dynamicObjectBase = GetComponent<DynamicObjectBase>();
	}

	public override void OnReplaySerialize(UltimateReplay.ReplayState state)
	{
		if (dynamicObjectBase != null)
		{
			state.Write(dynamicObjectBase.IsExisting);
		}
	}

	public override void OnReplayDeserialize(UltimateReplay.ReplayState state)
	{
		if (dynamicObjectBase != null)
		{
			dynamicObjectBase.SetExistence(state.ReadBool());
		}
	}
}
