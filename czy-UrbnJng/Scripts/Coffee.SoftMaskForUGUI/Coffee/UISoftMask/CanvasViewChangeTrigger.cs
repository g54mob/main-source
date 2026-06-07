using System;
using Coffee.UISoftMaskInternal;
using UnityEngine;

namespace Coffee.UISoftMask
{
	[RequireComponent(typeof(Canvas))]
	[ExecuteAlways]
	[AddComponentMenu("")]
	public class CanvasViewChangeTrigger : MonoBehaviour
	{
		private Canvas _canvas;

		private Action _checkViewProjectionMatrix;

		private int _lastCameraVpHash;

		private int _lastResHash;

		public event Action onCanvasViewChanged;

		private void OnEnable()
		{
			base.hideFlags = UISoftMaskProjectSettings.hideFlagsForTemp;
			TryGetComponent<Canvas>(out _canvas);
			UIExtraCallbacks.onBeforeCanvasRebuild += CheckViewProjectionMatrix;
		}

		private void OnDisable()
		{
			UIExtraCallbacks.onBeforeCanvasRebuild -= CheckViewProjectionMatrix;
		}

		private void OnDestroy()
		{
			_canvas = null;
			this.onCanvasViewChanged = null;
			_checkViewProjectionMatrix = null;
		}

		private void CheckViewProjectionMatrix()
		{
			if ((bool)_canvas)
			{
				int lastCameraVpHash = _lastCameraVpHash;
				_canvas.GetViewProjectionMatrix(out var vpMatrix);
				_lastCameraVpHash = vpMatrix.GetHashCode();
				int lastResHash = _lastResHash;
				Resolution currentResolution = Screen.currentResolution;
				_lastResHash = new Vector2Int(currentResolution.width, currentResolution.height).GetHashCode();
				if (lastCameraVpHash != _lastCameraVpHash || lastResHash != _lastResHash)
				{
					this.onCanvasViewChanged?.Invoke();
				}
			}
		}

		public static CanvasViewChangeTrigger Find(Transform transform)
		{
			Canvas rootComponent = transform.GetRootComponent<Canvas>();
			if (!rootComponent)
			{
				return null;
			}
			return rootComponent.GetOrAddComponent<CanvasViewChangeTrigger>();
		}
	}
}
