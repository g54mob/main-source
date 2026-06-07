using System;
using UnityEngine;

namespace CTS
{
	[Serializable]
	[DefaultExecutionOrder(-1000)]
	public class Resource<T> where T : UnityEngine.Object
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
				_reference = Resources.Load<T>(_path);
				return _reference;
			}
		}

		public T Value => Reference;

		public Resource(string path)
		{
			_path = path;
		}

		public static implicit operator T(Resource<T> p_resource)
		{
			return p_resource.Reference;
		}

		public static implicit operator Resource<T>(string path)
		{
			return new Resource<T>(path);
		}

		public override string ToString()
		{
			return Reference.ToString();
		}
	}
}
