using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Controls
{
	public class CameraEffects : SerializedMonoBehaviour
	{
		private SENaturalBloomAndDirtyLens _bloomEffect;

		private FPSCounter _fpsCounter;

		private bool _showWireframe;

		private bool _showFps;

		protected void Awake()
		{
			_bloomEffect = GetComponent<SENaturalBloomAndDirtyLens>();
			_fpsCounter = GetComponent<FPSCounter>();
		}

		private void ToggleFPS(string[] obj)
		{
			_showFps = !_showFps;
		}

		public void ToggleWireframe(string[] args)
		{
			_showWireframe = !_showWireframe;
		}

		public void OnPreRender()
		{
			GL.wireframe = _showWireframe;
		}

		public void OnPostRender()
		{
			GL.wireframe = false;
		}

		public void Update()
		{
			if (_bloomEffect != null)
			{
				_bloomEffect.enabled = RuntimeGlobals.Settings.BloomActive;
				_bloomEffect.bloomIntensity = RuntimeGlobals.Settings.BloomIntensity * 0.1f;
			}
			if (_fpsCounter != null)
			{
				_fpsCounter.enabled = _showFps;
			}
			if (Input.GetKeyDown(KeyCode.F1))
			{
				_showFps = !_showFps;
			}
			if (_showWireframe && _bloomEffect != null)
			{
				_bloomEffect.enabled = false;
			}
		}
	}
}
