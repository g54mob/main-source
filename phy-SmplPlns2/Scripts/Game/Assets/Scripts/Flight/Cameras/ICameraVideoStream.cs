using System;
using UnityEngine;

namespace Assets.Scripts.Flight.Cameras
{
	public interface ICameraVideoStream
	{
		RenderTexture RenderTexture { get; }

		event Action<ICameraVideoStream> Released;
	}
}
