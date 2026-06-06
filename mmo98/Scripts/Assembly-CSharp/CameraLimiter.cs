using Cysharp.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public abstract class CameraLimiter : MonoBehaviour
{
	private Camera _camera;

	private float _accumulator;

	private float _interval;

	protected abstract float FrameInterval { get; }

	private void Awake()
	{
		_camera = GetComponent<Camera>();
		_camera.enabled = false;
		_interval = FrameInterval;
	}

	private void Start()
	{
		UniTaskUtility.Delayed(0.5f, _camera.Render, this.GetCancellationTokenOnDestroy()).Forget();
	}

	private void Update()
	{
		if (!Database.Disposed && !Database.State.Studio.Paused.Value)
		{
			_accumulator += Time.deltaTime;
			if (!(_accumulator < _interval))
			{
				_accumulator -= _interval;
				_interval = FrameInterval;
				_camera.Render();
			}
		}
	}
}
