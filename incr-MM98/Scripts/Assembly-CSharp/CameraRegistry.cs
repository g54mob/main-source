using System;
using UnityEngine;

[Serializable]
public struct CameraRegistry
{
	public Camera main;

	public Camera gameBoxArt;

	public Camera sequelBoxArt;

	public CameraLimiter gnome;

	public CameraLimiter world;

	public CameraLimiter auction;
}
