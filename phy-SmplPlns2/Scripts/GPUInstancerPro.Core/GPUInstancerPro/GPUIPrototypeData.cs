using System;
using Unity.Collections;
using UnityEngine;

namespace GPUInstancerPro
{
	public abstract class GPUIPrototypeData : IGPUIDisposable, IDisposable, IGPUIParameterBufferData
	{
		public bool IsInitialized { get; protected set; }

		public virtual bool IsValid(bool logError, GPUIPrototype prototype)
		{
			return true;
		}

		public virtual bool Initialize(GPUIPrototype prototype)
		{
			if (IsValid(Application.isPlaying, prototype))
			{
				IsInitialized = true;
				SetParameterBufferData();
				return true;
			}
			return false;
		}

		public virtual void ReleaseBuffers()
		{
		}

		public virtual void Dispose()
		{
			ReleaseBuffers();
			IsInitialized = false;
		}

		public virtual void FillRequiredFields()
		{
		}

		public virtual void SetParameterBufferData()
		{
		}

		public virtual bool TryGetParameterBufferIndex(out int index)
		{
			return GPUIRenderingSystem.Instance.ParameterBufferIndexes.TryGetValue(this, out index);
		}

		public virtual NativeArray<Matrix4x4> GetTransformationMatrixArray()
		{
			return default(NativeArray<Matrix4x4>);
		}
	}
}
