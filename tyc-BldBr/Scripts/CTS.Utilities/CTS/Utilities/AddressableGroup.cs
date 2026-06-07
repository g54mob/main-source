using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace CTS.Utilities
{
	[Serializable]
	[DefaultExecutionOrder(-1000)]
	public class AddressableGroup<T> where T : UnityEngine.Object
	{
		private IList<T> _reference;

		[SerializeField]
		private string _path;

		private IList<T> Reference
		{
			get
			{
				if (_reference != null)
				{
					return _reference;
				}
				AsyncOperationHandle<IList<T>> asyncOperationHandle = Addressables.LoadAssetsAsync<T>(_path);
				asyncOperationHandle.WaitForCompletion();
				_reference = asyncOperationHandle.Result;
				return _reference;
			}
		}

		public IList<T> Value => Reference;

		public AddressableGroup(string path)
		{
			_path = path;
		}

		public static implicit operator AddressableGroup<T>(string path)
		{
			return new AddressableGroup<T>(path);
		}

		public override string ToString()
		{
			return Reference.ToString();
		}
	}
}
