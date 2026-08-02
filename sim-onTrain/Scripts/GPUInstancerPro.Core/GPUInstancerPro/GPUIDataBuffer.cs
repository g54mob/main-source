using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace GPUInstancerPro
{
	public class GPUIDataBuffer<T> : IGPUIDisposable, IDisposable where T : struct
	{
		private readonly string _name;

		private readonly GraphicsBuffer.Target _target;

		private readonly int _stride;

		protected NativeArray<T> _data;

		protected bool _requireUpdate;

		private bool _isDataRequested;

		private bool _isRequestedDataInvalid;

		private AsyncGPUReadbackRequest _readbackRequest;

		private readonly Action<AsyncGPUReadbackRequest> _requestCallbackInternal;

		private List<Action<GPUIDataBuffer<T>>> _requestCallbacksExternal;

		private NativeArray<T> _requestedData;

		private bool _writeToDataAfterReadback;

		public GraphicsBuffer Buffer { get; private set; }

		public int Length { get; private set; }

		public T this[int index]
		{
			get
			{
				return _data[index];
			}
			set
			{
				if (_isDataRequested && _writeToDataAfterReadback)
				{
					_readbackRequest.WaitForCompletion();
				}
				_data[index] = value;
				_requireUpdate = true;
			}
		}

		public GPUIDataBuffer(string name, int length = 0, GraphicsBuffer.Target target = GraphicsBuffer.Target.Structured)
		{
			if (length < 0)
			{
				length = 0;
			}
			Length = length;
			_name = name;
			_target = target;
			if (length > 0)
			{
				_data = new NativeArray<T>(length, Allocator.Persistent);
				_requireUpdate = true;
			}
			_stride = Marshal.SizeOf(typeof(T));
			_requestCallbackInternal = OnDataRequestCompleted;
			_requestCallbacksExternal = new List<Action<GPUIDataBuffer<T>>>();
		}

		public void Add(T element)
		{
			if (_isDataRequested && _writeToDataAfterReadback)
			{
				_readbackRequest.WaitForCompletion();
			}
			int length = Length;
			Length++;
			GPUIUtility.ResizeNativeArray(ref _data, Length, Allocator.Persistent);
			_data[length] = element;
			_requireUpdate = true;
		}

		public void Add(params T[] elements)
		{
			if (_isDataRequested && _writeToDataAfterReadback)
			{
				_readbackRequest.WaitForCompletion();
			}
			int length = Length;
			Length += elements.Length;
			GPUIUtility.ResizeNativeArray(ref _data, Length, Allocator.Persistent);
			for (int i = 0; i < elements.Length; i++)
			{
				_data[length + i] = elements[i];
			}
			_requireUpdate = true;
		}

		public void Add(List<T> elements)
		{
			if (_isDataRequested && _writeToDataAfterReadback)
			{
				_readbackRequest.WaitForCompletion();
			}
			int length = Length;
			Length += elements.Count;
			GPUIUtility.ResizeNativeArray(ref _data, Length, Allocator.Persistent);
			for (int i = 0; i < elements.Count; i++)
			{
				_data[length + i] = elements[i];
			}
			_requireUpdate = true;
		}

		public void AddOrSet(int index, T element)
		{
			if (_isDataRequested && _writeToDataAfterReadback)
			{
				_readbackRequest.WaitForCompletion();
			}
			if (!_data.IsCreated)
			{
				Length = index + 1;
				_data = new NativeArray<T>(Length, Allocator.Persistent);
			}
			else if (index >= Length)
			{
				Length = index + 1;
				GPUIUtility.ResizeNativeArray(ref _data, Length, Allocator.Persistent);
			}
			_data[index] = element;
			_requireUpdate = true;
		}

		public void Resize(int newSize)
		{
			if (_isDataRequested && _writeToDataAfterReadback)
			{
				_readbackRequest.WaitForCompletion();
			}
			Length = newSize;
			if (newSize <= 0)
			{
				ReleaseBuffers();
				return;
			}
			GPUIUtility.ResizeNativeArray(ref _data, Length, Allocator.Persistent);
			_requireUpdate = true;
		}

		public bool UpdateBufferData(bool forceUpdate = false)
		{
			if (forceUpdate || _requireUpdate)
			{
				SetBufferData();
				return true;
			}
			return false;
		}

		public void SetBufferData()
		{
			if (_isDataRequested)
			{
				_readbackRequest.WaitForCompletion();
			}
			_requireUpdate = false;
			if (Length == 0 || !_data.IsCreated)
			{
				ReleaseBuffers();
				return;
			}
			if (Buffer != null && Buffer.count != Length)
			{
				Buffer.Release();
				Buffer = null;
			}
			if (Buffer == null)
			{
				Buffer = new GraphicsBuffer(_target, Length, _stride);
			}
			SetBufferDataInternal();
		}

		protected virtual void SetBufferDataInternal()
		{
			Buffer.SetData(_data);
		}

		public virtual void ReleaseBuffers()
		{
			if (_isDataRequested)
			{
				_isRequestedDataInvalid = true;
				_readbackRequest.WaitForCompletion();
			}
			if (Buffer != null)
			{
				Buffer.Release();
				Buffer = null;
			}
			if (_data.IsCreated)
			{
				_data.Dispose();
			}
			Length = 0;
			if (!_isDataRequested && _requestedData.IsCreated)
			{
				_requestedData.Dispose();
			}
			_requireUpdate = true;
		}

		public void Dispose()
		{
			ReleaseBuffers();
		}

		public T[] GetBufferData()
		{
			UpdateBufferData();
			T[] array = new T[Length];
			if (Buffer != null)
			{
				Buffer.GetData(array);
			}
			_data.CopyFrom(array);
			return array;
		}

		public NativeArray<T> GetNativeData(bool isReadFromGPU = false)
		{
			if (isReadFromGPU)
			{
				AsyncDataRequest(null, writeToDataAfterReadback: true);
				if (_isDataRequested)
				{
					_readbackRequest.WaitForCompletion();
				}
			}
			return _data;
		}

		public bool AsyncDataRequest(Action<GPUIDataBuffer<T>> callback, bool writeToDataAfterReadback)
		{
			if (Buffer == null)
			{
				return false;
			}
			if (!_isDataRequested)
			{
				_writeToDataAfterReadback = writeToDataAfterReadback;
				if (!_requestedData.IsCreated || _requestedData.Length != Length)
				{
					if (_requestedData.IsCreated)
					{
						_requestedData.Dispose();
					}
					_requestedData = new NativeArray<T>(Length, Allocator.Persistent);
				}
				_readbackRequest = AsyncGPUReadback.RequestIntoNativeArray(ref _requestedData, Buffer, _requestCallbackInternal);
				_isDataRequested = true;
			}
			else if (writeToDataAfterReadback != _writeToDataAfterReadback)
			{
				Debug.LogWarning("There is another AsyncDataRequest pending results.");
				return false;
			}
			_requestCallbacksExternal.Add(callback);
			return true;
		}

		private void OnDataRequestCompleted(AsyncGPUReadbackRequest obj)
		{
			_isDataRequested = false;
			if (obj.hasError)
			{
				Debug.LogError("Async data request has encountered an error. Data buffer name: " + _name);
				return;
			}
			if (_isRequestedDataInvalid)
			{
				_isRequestedDataInvalid = false;
				if (_requestedData.IsCreated)
				{
					_requestedData.Dispose();
				}
				return;
			}
			if (_writeToDataAfterReadback)
			{
				if (!_data.IsCreated)
				{
					return;
				}
				if (_data.Length != _requestedData.Length)
				{
					if (Application.isPlaying)
					{
						Debug.LogError("GPUI async data request size mismatch. Data length: " + _data.Length + " requested length: " + _requestedData.Length + " name: " + _name);
					}
					return;
				}
				_data.CopyFrom(_requestedData);
			}
			foreach (Action<GPUIDataBuffer<T>> item in _requestCallbacksExternal)
			{
				item?.Invoke(this);
			}
			_requestCallbacksExternal.Clear();
		}

		public bool IsDataRequested()
		{
			return _isDataRequested;
		}

		public NativeArray<T> GetRequestedData()
		{
			if (_isDataRequested)
			{
				return default(NativeArray<T>);
			}
			return _requestedData;
		}

		public void WaitForReadbackCompletion()
		{
			if (_isDataRequested)
			{
				_readbackRequest.WaitForCompletion();
			}
		}
	}
}
