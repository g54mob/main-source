using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace NSMedieval.Manager
{
	public class MaterialManager : MonoSingleton<MaterialManager>
	{
		private readonly Dictionary<Image, Material> imageMaterials = new Dictionary<Image, Material>();

		public Material GetMaterialInstance(Image image)
		{
			if (!imageMaterials.ContainsKey(image))
			{
				Material value = (image.material = Object.Instantiate(image.material));
				imageMaterials.Add(image, value);
			}
			return imageMaterials[image];
		}

		private void Start()
		{
			MonoSingleton<LoadingController>.Instance.SceneUnloadedEvent += OnSceneChange;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.SceneUnloadedEvent -= OnSceneChange;
			}
		}

		private void OnSceneChange(Scene scene)
		{
			using PooledList<KeyValuePair<Image, Material>> pooledList = imageMaterials.WherePooled((KeyValuePair<Image, Material> kvp) => kvp.Key == null);
			foreach (var (key, obj) in pooledList)
			{
				Object.DestroyImmediate(obj);
				imageMaterials.Remove(key);
			}
		}
	}
}
