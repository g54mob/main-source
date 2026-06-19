using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;

namespace TH20
{
	public class BlobShadowManager : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public bool StartEnabled;
		}

		[DontSave]
		private Dictionary<Camera, CommandBuffer> _cameras;

		[DontSave]
		private HashSet<BlobShadowDecal> _blobShadowDecals;

		[DontSave]
		private Mesh _mesh;

		public BlobShadowManager(Config config)
		{
			if (config.StartEnabled)
			{
				_cameras = new Dictionary<Camera, CommandBuffer>();
				_blobShadowDecals = new HashSet<BlobShadowDecal>();
				Camera.onPreRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPreRender, new Camera.CameraCallback(OnPreRender));
				_mesh = MeshUtils.CreateCubeMesh(Vector3.one);
			}
		}

		public void RegisterDecal(BlobShadowDecal decal)
		{
			if (_blobShadowDecals != null)
			{
				_blobShadowDecals.Add(decal);
			}
		}

		public void UnregisterDecal(BlobShadowDecal decal)
		{
			if (_blobShadowDecals != null)
			{
				_blobShadowDecals.Remove(decal);
			}
		}

		private void OnPreRender(Camera camera)
		{
			CommandBuffer commandBuffer;
			if (_cameras.ContainsKey(camera))
			{
				commandBuffer = _cameras[camera];
				commandBuffer.Clear();
			}
			else
			{
				commandBuffer = new CommandBuffer();
				commandBuffer.name = "Deferred Blob Shadow Decals";
				_cameras[camera] = commandBuffer;
				camera.AddCommandBuffer(CameraEvent.AfterImageEffectsOpaque, commandBuffer);
			}
			commandBuffer.SetRenderTarget(BuiltinRenderTextureType.CameraTarget, BuiltinRenderTextureType.CameraTarget);
			_blobShadowDecals.RemoveWhere((BlobShadowDecal decal) => decal == null);
			foreach (BlobShadowDecal blobShadowDecal in _blobShadowDecals)
			{
				commandBuffer.DrawMesh(_mesh, blobShadowDecal.transform.localToWorldMatrix, blobShadowDecal.Material);
			}
		}

		public override void Destroy()
		{
			Camera.onPreRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPreRender, new Camera.CameraCallback(OnPreRender));
			if (_cameras != null)
			{
				foreach (KeyValuePair<Camera, CommandBuffer> camera in _cameras)
				{
					if ((bool)camera.Key)
					{
						camera.Key.RemoveCommandBuffer(CameraEvent.AfterImageEffectsOpaque, camera.Value);
					}
				}
			}
			base.Destroy();
		}
	}
}
