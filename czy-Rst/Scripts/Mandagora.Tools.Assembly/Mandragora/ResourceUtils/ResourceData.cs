using System;
using UnityEngine;

namespace Mandragora.ResourceUtils
{
	[Serializable]
	public class ResourceData : IComparable<ResourceData>
	{
		public string Name;

		public string Path;

		public UnityEngine.Object Resource;

		public ResourceData()
		{
		}

		public ResourceData(string path)
		{
			Path = path;
		}

		public ResourceData(string path, UnityEngine.Object resource)
		{
			Path = path;
			Resource = resource;
			Name = Path.Split('\\', '/')[^1];
		}

		public int CompareTo(ResourceData obj)
		{
			if (obj == null)
			{
				return 1;
			}
			return Path.CompareTo(obj.Path);
		}
	}
}
