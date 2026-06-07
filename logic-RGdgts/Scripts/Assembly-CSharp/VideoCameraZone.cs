using System;
using System.Collections.Generic;
using Cinemachine;
using SE.EvilLib.Core;
using UnityEngine;

public class VideoCameraZone : MonoBehaviour
{
	[Separator]
	public Collider2D colliderEnter;

	public Collider2D colliderExit;

	public Action<VideoCameraZone> OnZoneEnter;

	public Action<VideoCameraZone> OnZoneExit;

	public CinemachineVirtualCamera vCam { get; private set; }

	public List<Collider2D> colliders { get; private set; }

	public void Init()
	{
	}

	public void Disable()
	{
	}

	public void Enable()
	{
	}
}
