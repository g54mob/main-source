using System;
using System.Collections.Generic;
using Jundroo.Common.Resource;
using UnityEngine;
using UnityFS;

namespace Assets.Scripts.Storage
{
	public class ResourceLoader : ResourceLoaderBase, IResourceLoader, IResourceLoaderBase
	{
		private Dictionary<string, Aerofoil> _airfoils = new Dictionary<string, Aerofoil>();

		private Dictionary<string, Material> _materials = new Dictionary<string, Material>();

		public virtual Aerofoil LoadAirfoil(string airfoilName)
		{
			if (!_airfoils.TryGetValue(airfoilName, out var value))
			{
				GameObject gameObject = Resources.Load<GameObject>("Data/Parts/Airfoils/" + airfoilName);
				if (gameObject == null)
				{
					throw new ArgumentException("Requested airfoil (" + airfoilName + ") could not be found", "airfoilName");
				}
				GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject);
				gameObject2.hideFlags = HideFlags.HideAndDontSave;
				UnityEngine.Object.DontDestroyOnLoad(gameObject2);
				if (!gameObject2.TryGetComponent<Aerofoil>(out value))
				{
					throw new ArgumentException("Requested airfoil (" + airfoilName + ") object was loaded but the airfoil component could not be found", "airfoilName");
				}
				_airfoils[airfoilName] = value;
			}
			return value;
		}

		public virtual Material LoadSharedMaterial(string path)
		{
			if (!_materials.TryGetValue(path, out var value))
			{
				value = LoadMaterial(path);
				_materials[path] = value;
			}
			return value;
		}
	}
}
