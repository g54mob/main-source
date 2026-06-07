using Jundroo.Common.Resource;
using UnityEngine;
using UnityFS;

namespace Assets.Scripts.Storage
{
	public interface IResourceLoader : IResourceLoaderBase
	{
		Aerofoil LoadAirfoil(string airfoilName);

		Material LoadSharedMaterial(string path);
	}
}
