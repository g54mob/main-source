using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace CTS.Utilities
{
	[Serializable]
	[DefaultExecutionOrder(-1000)]
	public class Addressable<T> where T : UnityEngine.Object
	{
		private T _reference;

		[SerializeField]
		private string _path;

		private T Reference
		{
			get
			{
				if (_reference != null)
				{
					return _reference;
				}
				if (typeof(Component).IsAssignableFrom(typeof(T)))
				{
					AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>(_path);
					asyncOperationHandle.WaitForCompletion();
					_reference = asyncOperationHandle.Result.GetComponent<T>();
				}
				else
				{
					AsyncOperationHandle<T> asyncOperationHandle2 = Addressables.LoadAssetAsync<T>(_path);
					asyncOperationHandle2.WaitForCompletion();
					_reference = asyncOperationHandle2.Result;
				}
				return _reference;
			}
		}

		public T Value => Reference;

		public Addressable(string path)
		{
			_path = path;
		}

		public static implicit operator T(Addressable<T> p_resource)
		{
			return p_resource.Reference;
		}

		public static implicit operator Addressable<T>(string path)
		{
			return new Addressable<T>(path);
		}

		public override string ToString()
		{
			return Reference.ToString();
		}
	}
}
