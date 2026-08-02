using System.Collections.Generic;

namespace GPUInstancerPro
{
	public class GPUIRenderSourceGroupProvider : GPUIDataProvider<int, GPUIRenderSourceGroup>
	{
		public override void Dispose()
		{
			if (_dataDict != null)
			{
				foreach (GPUIRenderSourceGroup value in base.Values)
				{
					value?.Dispose();
				}
			}
			base.Dispose();
		}

		internal GPUIRenderSourceGroup GetOrCreateRenderSourceGroup(int prototypeKey, GPUILODGroupData lodGroupData, GPUIProfile profile, int groupID = 0, GPUITransformBufferType transformBufferType = GPUITransformBufferType.Default, List<string> shaderKeywords = null)
		{
			int key = GPUIRenderSourceGroup.GetKey(prototypeKey, profile, groupID, shaderKeywords);
			if (!TryGetData(key, out var result))
			{
				result = new GPUIRenderSourceGroup(prototypeKey, profile, groupID, transformBufferType, shaderKeywords);
				_dataDict.Add(key, result);
				profile.SetParameterBufferData();
				lodGroupData.SetParameterBufferData();
				GPUIRenderingSystem.Instance.UpdateCommandBuffers(result);
			}
			return result;
		}

		internal void DisposeCameraData(GPUICameraData cameraData)
		{
			if (_dataDict == null)
			{
				return;
			}
			foreach (GPUIRenderSourceGroup value in base.Values)
			{
				if (value != null && value.TransformBufferData != null)
				{
					value.TransformBufferData.Dispose(cameraData);
				}
			}
		}
	}
}
