using Cinemachine;
using UnityEngine;

public class CineMachineCamera : PlayerCamera
{
	private CinemachineVirtualCamera mainVirtualCamera;

	private CinemachineTargetGroup targetGroup;

	private ICinemachineCamera auxCamera;

	public override GameObject Target
	{
		get
		{
			return base.Target;
		}
		set
		{
			if ((bool)base.Target)
			{
				TargetGroup.RemoveMember(base.Target.transform);
			}
			base.Target = value;
			if ((bool)base.Target)
			{
				TargetGroup.AddMember(base.Target.transform, 1f, 0.5f);
			}
		}
	}

	public CinemachineTargetGroup TargetGroup
	{
		get
		{
			if (!targetGroup)
			{
				TargetGroup = GetComponentInChildren<CinemachineTargetGroup>();
			}
			return targetGroup;
		}
		set
		{
			targetGroup = value;
		}
	}

	public CinemachineVirtualCamera MainVirtualCamera
	{
		get
		{
			if (!mainVirtualCamera)
			{
				MainVirtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
			}
			return mainVirtualCamera;
		}
		set
		{
			mainVirtualCamera = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		MainVirtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
		TargetGroup = GetComponentInChildren<CinemachineTargetGroup>();
	}

	public void ChangeCamera(ICinemachineCamera newCamera)
	{
		if (auxCamera != newCamera)
		{
			MainVirtualCamera.Priority = 0;
			if (auxCamera != null)
			{
				auxCamera.Priority = 0;
			}
			auxCamera = newCamera;
			auxCamera.Priority = 10;
		}
	}

	public void ResetCamera()
	{
		if (auxCamera != null)
		{
			auxCamera.Priority = 0;
			auxCamera = null;
		}
		MainVirtualCamera.Priority = 10;
	}

	public void AddTargetGroupMember(Transform memberTransform, float weight, float radius)
	{
		TargetGroup.AddMember(memberTransform, weight, radius);
	}

	public void RemoveTargetGroupMember(Transform memberTransform)
	{
		TargetGroup.RemoveMember(memberTransform);
	}
}
