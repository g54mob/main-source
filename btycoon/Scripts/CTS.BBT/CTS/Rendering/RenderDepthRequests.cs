using System.Collections.Generic;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.Rendering
{
	public static class RenderDepthRequests
	{
		public static readonly List<RenderDepthRequest> Requests = new List<RenderDepthRequest>();

		public static void ClearRequest(int index)
		{
			if (index.IsCorrectArrayIndex(Requests))
			{
				Requests.RemoveAt(index);
			}
		}

		public static void ClearRequest(RenderDepthRequest request)
		{
			Requests.Remove(request);
		}

		public static RenderDepthRequest CreateNew(RenderTexture target, Vector3 position, Quaternion rotation, float range, float nearPlane, float fov, LayerMask layerMask)
		{
			if (!target)
			{
				return null;
			}
			RenderDepthRequest renderDepthRequest = new RenderDepthRequest
			{
				RenderTarget = target,
				Position = position,
				Rotation = rotation,
				Range = range,
				NearPlane = nearPlane,
				FOV = fov,
				LayerMask = layerMask,
				TemporaryCamera = RenderDepthPass.GetCamera()
			};
			renderDepthRequest.UpdateCamera();
			Requests.Add(renderDepthRequest);
			return renderDepthRequest;
		}
	}
}
