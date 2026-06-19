using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CursorPositioning : MonoBehaviour
{
	private static CursorPositioning _instance;

	private static Camera _camera;

	public static Vector2 WorldPosition { get; private set; }

	public static Vector2 ScreenPosition => default(Vector2);

	public static event Action<Vector2> AnnounceWorldPosition
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action<Vector2> AnnounceScreenPosition
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void UpdateCamera(Camera camera)
	{
	}

	public static void UpdatePosition()
	{
	}

	private static void UpdatePosition(Vector2 position)
	{
	}
}
