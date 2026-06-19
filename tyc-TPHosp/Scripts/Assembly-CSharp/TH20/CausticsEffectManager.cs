using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace TH20
{
	[DontSave]
	public class CausticsEffectManager : MustCallDestroy
	{
		private Level _level;

		private Mesh _unitCubeMesh;

		private Material _causticesMaterial;

		private MaterialPropertyBlock _materialPropertyBlock;

		private Dictionary<Camera, CommandBuffer> _commandBuffers;

		private float _elapsedTime;

		public CausticsEffectManager(Level level, CausticsEffectManagerConfig config)
		{
			_level = level;
			_causticesMaterial = config.CausticsMaterial;
			_unitCubeMesh = MeshUtils.CreateCubeMesh(Vector3.one);
			_materialPropertyBlock = new MaterialPropertyBlock();
			_commandBuffers = new Dictionary<Camera, CommandBuffer>();
			Camera.onPreRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPreRender, new Camera.CameraCallback(OnPreRender));
		}

		public void Update()
		{
			_elapsedTime += Time.deltaTime * 0.05f;
		}

		private void OnPreRender(Camera camera)
		{
			if ((camera.cameraType == CameraType.Game || camera.cameraType == CameraType.SceneView) && !(camera.name == "PreRenderCamera") && (camera.cameraType != CameraType.Game || camera.enabled) && (_level.MetagameMap.CameraLogic == null || !(camera == _level.MetagameMap.CameraLogic.CameraComponent)) && !(_level.Config.GetLevelLightingConfig() == null) && _level.Config.GetLevelLightingConfig().Caustics.Enabled)
			{
				CommandBuffer orCreate = CommandBufferUtils.GetOrCreate(_commandBuffers, camera, CameraEvent.AfterLighting, "Caustics Effect");
				if (_level.App.LocalPreferences.Video.HospitalLightingQuality == LocalPreferences.VideoPreferences.HospitalLightingQualityMode.High)
				{
					_materialPropertyBlock.Clear();
					_materialPropertyBlock.SetFloat("_ElapsedTime", _elapsedTime);
					Vector3 causticsVolumePosition = _level.Config.GetLevelLightingConfig().Caustics.CausticsVolumePosition;
					Vector3 causticsVolumeScale = _level.Config.GetLevelLightingConfig().Caustics.CausticsVolumeScale;
					orCreate.DrawMesh(_unitCubeMesh, Matrix4x4.TRS(causticsVolumePosition, Quaternion.identity, causticsVolumeScale), _causticesMaterial, 0, 0, _materialPropertyBlock);
				}
			}
		}

		public override void Destroy()
		{
			Camera.onPreRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPreRender, new Camera.CameraCallback(OnPreRender));
			foreach (KeyValuePair<Camera, CommandBuffer> commandBuffer in _commandBuffers)
			{
				commandBuffer.Value.Release();
			}
			_commandBuffers.Clear();
			UnityEngine.Object.Destroy(_unitCubeMesh);
			base.Destroy();
		}
	}
}
