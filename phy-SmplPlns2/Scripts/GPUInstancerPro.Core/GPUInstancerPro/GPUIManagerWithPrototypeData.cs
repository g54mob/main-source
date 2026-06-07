using System;
using UnityEngine;

namespace GPUInstancerPro
{
	public abstract class GPUIManagerWithPrototypeData<T> : GPUIManager where T : GPUIPrototypeData, new()
	{
		[SerializeField]
		protected T[] _prototypeDataArray;

		public override void Initialize()
		{
			base.Initialize();
			OnPrototypePropertiesModified();
		}

		protected override bool RegisterRenderer(int prototypeIndex)
		{
			GPUIPrototype prototype = _prototypes[prototypeIndex];
			T val = _prototypeDataArray[prototypeIndex];
			if (val.Initialize(prototype))
			{
				if (base.RegisterRenderer(prototypeIndex))
				{
					return true;
				}
				val.Dispose();
			}
			return false;
		}

		protected override void DisposeRenderer(int prototypeIndex)
		{
			base.DisposeRenderer(prototypeIndex);
			if (_prototypeDataArray != null && _prototypeDataArray.Length > prototypeIndex)
			{
				T val = _prototypeDataArray[prototypeIndex];
				if (val != null && val.IsInitialized)
				{
					val.Dispose();
				}
			}
		}

		public override void OnPrototypeEnabledStatusChanged(int prototypeIndex, bool isEnabled)
		{
			base.OnPrototypeEnabledStatusChanged(prototypeIndex, isEnabled);
			OnPrototypePropertiesModified();
		}

		protected override void ClearNullPrototypes()
		{
			base.ClearNullPrototypes();
			if (_prototypeDataArray == null)
			{
				_prototypeDataArray = new T[0];
			}
		}

		protected override void SynchronizeData()
		{
			base.SynchronizeData();
			int num = _prototypes.Length;
			if (_prototypeDataArray == null)
			{
				_prototypeDataArray = new T[num];
			}
			else if (_prototypeDataArray.Length != num)
			{
				Array.Resize(ref _prototypeDataArray, num);
			}
			for (int i = 0; i < num; i++)
			{
				if (_prototypeDataArray[i] == null)
				{
					_prototypeDataArray[i] = new T();
					OnNewPrototypeDataCreated(i);
				}
				_prototypeDataArray[i].FillRequiredFields();
			}
		}

		protected virtual void OnNewPrototypeDataCreated(int prototypeIndex)
		{
		}

		public override void OnPrototypePropertiesModified()
		{
			base.OnPrototypePropertiesModified();
			if (!base.IsInitialized)
			{
				return;
			}
			for (int i = 0; i < _prototypes.Length; i++)
			{
				if (_runtimeRenderKeys[i] != 0)
				{
					_prototypeDataArray[i].SetParameterBufferData();
				}
			}
		}

		public override void RemovePrototypeAtIndex(int index)
		{
			_prototypeDataArray = _prototypeDataArray.RemoveAtAndReturn(index);
			base.RemovePrototypeAtIndex(index);
		}

		public override void RemoveAllPrototypes()
		{
			base.RemoveAllPrototypes();
			_prototypeDataArray = new T[0];
		}

		public T GetPrototypeData(int prototypeIndex)
		{
			if (prototypeIndex < 0 || _prototypeDataArray == null || prototypeIndex >= _prototypeDataArray.Length)
			{
				return null;
			}
			return _prototypeDataArray[prototypeIndex];
		}

		public override GPUIPrototypeData GetPrototypeDataGeneric(int prototypeIndex)
		{
			return GetPrototypeData(prototypeIndex);
		}

		public T GetPrototypeDataWithRenderKey(int renderKey)
		{
			if (_runtimeRenderKeys != null)
			{
				for (int i = 0; i < _runtimeRenderKeys.Length; i++)
				{
					if (_runtimeRenderKeys[i] == renderKey)
					{
						return _prototypeDataArray[i];
					}
				}
			}
			return null;
		}
	}
}
