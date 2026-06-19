using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CurrentCamera : MonoBehaviour
{
	[SerializeField]
	private Camera _camera;

	public static Camera Main { get; private set; }

	public static event Action<Camera> AnnounceCameraChanged
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

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}
}
