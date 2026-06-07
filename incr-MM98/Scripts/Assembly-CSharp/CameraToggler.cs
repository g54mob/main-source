using System;
using UnityEngine;

public class CameraToggler : MonoBehaviour
{
	private enum CameraTarget
	{
		Main = 0,
		GameBoxArt = 1,
		SequelBoxArt = 2,
		Gnome = 3,
		World = 4,
		Auction = 5
	}

	[SerializeField]
	private CameraTarget cameraTarget;

	private Behaviour _camera;

	private void OnEnable()
	{
		Behaviour behaviour = CachedCamera();
		if ((bool)behaviour)
		{
			behaviour.enabled = true;
		}
	}

	private void OnDisable()
	{
		Behaviour behaviour = CachedCamera();
		if ((bool)behaviour)
		{
			behaviour.enabled = false;
		}
	}

	private Behaviour CachedCamera()
	{
		if ((bool)_camera)
		{
			return _camera;
		}
		return _camera = cameraTarget switch
		{
			CameraTarget.Main => UI.Registry.cameras.main, 
			CameraTarget.GameBoxArt => UI.Registry.cameras.gameBoxArt, 
			CameraTarget.SequelBoxArt => UI.Registry.cameras.sequelBoxArt, 
			CameraTarget.Gnome => UI.Registry.cameras.gnome, 
			CameraTarget.World => UI.Registry.cameras.world, 
			CameraTarget.Auction => UI.Registry.cameras.auction, 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}
}
