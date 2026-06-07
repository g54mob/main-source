using LeTai.Asset.TranslucentImage;
using ModApi.Scenes.Events;
using UnityEngine;

namespace Assets.Scripts.Ui.XmlLayoutExtensions
{
	public class TranslucentImageHelperScript : MonoBehaviour
	{
		private static bool _initialized;

		private static TranslucentImageSource _source;

		private static Material _translucentMaterial;

		public static void SetupTranslucentImage(TranslucentImage image)
		{
			if (!_initialized)
			{
				_initialized = true;
				_translucentMaterial = Game.Instance.ResourceLoader.LoadMaterial("Ui/Materials/Default-Translucent");
				Game.Instance.SceneManager.SceneUnloading += SceneManager_SceneUnloading;
			}
			if (_source == null)
			{
				_source = Object.FindObjectOfType<TranslucentImageSource>(includeInactive: true);
			}
			if (_source != null)
			{
				image.source = _source;
				image.material = _translucentMaterial;
			}
			else
			{
				image.enabled = false;
				Debug.LogError("Could not find TranslucentImageSource for " + image.gameObject.name + ". The TranslucentImage component has been disabled.", image.gameObject);
			}
		}

		protected virtual void Awake()
		{
			SetupTranslucentImage(GetComponent<TranslucentImage>());
		}

		private static void SceneManager_SceneUnloading(object sender, SceneEventArgs e)
		{
			_source = null;
		}
	}
}
