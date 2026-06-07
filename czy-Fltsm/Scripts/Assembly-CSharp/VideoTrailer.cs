using System.Collections.Generic;
using PajamaLlama.Debugs;
using UnityEngine;
using UnityEngine.Video;

public class VideoTrailer : MonoBehaviour
{
	[SerializeField]
	[Tooltip("Threshold in seconds to wait before playing the video.")]
	private float _idleThreshold = 30f;

	private Camera _camera;

	private VideoPlayer _videoPlayer;

	private readonly List<Canvas> _activeSceneCanvases = new List<Canvas>();

	private float _currentIdleTime;

	private Vector3 _lastMousePosition = Vector3.zero;

	private void Start()
	{
		InitializeReferences();
		if (_videoPlayer.clip == null)
		{
			Debugger.Warning("No videoclip set for VideoTrailer, removing object.", this);
			Object.Destroy(base.gameObject);
		}
		if (_videoPlayer.targetCamera == null)
		{
			_videoPlayer.targetCamera = _camera;
		}
	}

	private void InitializeReferences()
	{
		_camera = Camera.main;
		_videoPlayer = GetComponent<VideoPlayer>();
	}

	private void Update()
	{
		_currentIdleTime += Time.deltaTime;
		if (Input.anyKey || _lastMousePosition != FlotsamInputManager.MousePosition)
		{
			_currentIdleTime = 0f;
			if (_videoPlayer.isPlaying)
			{
				StopVideo();
			}
		}
		if (_currentIdleTime >= _idleThreshold && !_videoPlayer.isPlaying)
		{
			PlayVideo();
		}
		_lastMousePosition = FlotsamInputManager.MousePosition;
	}

	private void PlayVideo()
	{
		_activeSceneCanvases.Clear();
		_activeSceneCanvases.AddRange(Object.FindObjectsByType<Canvas>(FindObjectsInactive.Exclude, FindObjectsSortMode.None));
		for (int i = 0; i < _activeSceneCanvases.Count; i++)
		{
			_activeSceneCanvases[i].enabled = false;
		}
		_videoPlayer.Play();
	}

	private void StopVideo()
	{
		_videoPlayer.Stop();
		for (int i = 0; i < _activeSceneCanvases.Count; i++)
		{
			_activeSceneCanvases[i].enabled = true;
		}
	}
}
