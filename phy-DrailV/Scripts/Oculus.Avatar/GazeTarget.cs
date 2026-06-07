using Oculus.Avatar;
using UnityEngine;

public class GazeTarget : MonoBehaviour
{
	public ovrAvatarGazeTargetType Type;

	private static ovrAvatarGazeTargets RuntimeTargetList;

	static GazeTarget()
	{
		RuntimeTargetList.targets = new ovrAvatarGazeTarget[128];
		RuntimeTargetList.targetCount = 1u;
	}

	private void Start()
	{
		UpdateGazeTarget();
		base.transform.hasChanged = false;
	}

	private void Update()
	{
		if (base.transform.hasChanged)
		{
			base.transform.hasChanged = false;
			UpdateGazeTarget();
		}
	}

	private void OnDestroy()
	{
		CAPI.ovrAvatar_RemoveGazeTargets(1u, new uint[1] { (uint)base.transform.GetInstanceID() });
	}

	private void UpdateGazeTarget()
	{
		ovrAvatarGazeTarget ovrAvatarGazeTarget2 = CreateOvrGazeTarget((uint)base.transform.GetInstanceID(), base.transform.position, Type);
		RuntimeTargetList.targets[0] = ovrAvatarGazeTarget2;
		CAPI.ovrAvatar_UpdateGazeTargets(RuntimeTargetList);
	}

	private ovrAvatarGazeTarget CreateOvrGazeTarget(uint targetId, Vector3 targetPosition, ovrAvatarGazeTargetType targetType)
	{
		return new ovrAvatarGazeTarget
		{
			id = targetId,
			worldPosition = new Vector3(targetPosition.x, targetPosition.y, 0f - targetPosition.z),
			type = targetType
		};
	}
}
