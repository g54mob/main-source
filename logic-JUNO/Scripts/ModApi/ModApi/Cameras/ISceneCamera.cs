using System;
using UnityEngine;

namespace ModApi.Cameras
{
	public interface ISceneCamera
	{
		Camera Camera { get; }

		ISceneMasterCamera MasterCamera { get; }

		bool UseConfigurableFOV { get; }

		event EventHandler<EventArgs> PostRender;

		event EventHandler<EventArgs> PreRender;
	}
}
