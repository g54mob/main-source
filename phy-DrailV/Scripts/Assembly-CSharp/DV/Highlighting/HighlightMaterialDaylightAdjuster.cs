using System.Collections;
using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;

namespace DV.Highlighting
{
	public class HighlightMaterialDaylightAdjuster : MonoBehaviour
	{
		private class RuntimeHelper
		{
			public Highlight highlight;

			public Color colorMain;

			public Color colorOccluded;
		}

		private static readonly int COLOR_MAIN = Shader.PropertyToID("_ColorMain");

		private static readonly int COLOR_OCCLUDED = Shader.PropertyToID("_ColorOccluded");

		public float nightMultiplier = 0.4f;

		private RuntimeHelper[] helpers;

		private LightingCoordinator lightingCoordinator;

		private WeatherPresetManager weatherPresetManager;

		private void Start()
		{
			AGeneralHighlighter instance = SingletonBehaviour<AGeneralHighlighter>.Instance;
			if (!instance)
			{
				Debug.LogError("AGeneralHighlighter missing, Destroying self.");
				Object.Destroy(this);
				return;
			}
			Highlight[] components = instance.GetComponents<Highlight>();
			helpers = new RuntimeHelper[components.Length];
			for (int i = 0; i < helpers.Length; i++)
			{
				helpers[i] = new RuntimeHelper
				{
					highlight = components[i],
					colorMain = components[i].imageEffectMaterial.GetColor(COLOR_MAIN),
					colorOccluded = components[i].imageEffectMaterial.GetColor(COLOR_OCCLUDED)
				};
			}
			lightingCoordinator = SingletonBehaviour<WeatherDriver>.Instance.GetComponent<LightingCoordinator>();
			weatherPresetManager = SingletonBehaviour<WeatherDriver>.Instance.manager;
			weatherPresetManager.HourChanged += HourChanged;
		}

		private void HourChanged()
		{
			StartCoroutine(SetColor());
		}

		private IEnumerator SetColor()
		{
			while (SingletonBehaviour<WeatherDriver>.Instance.IsLightningFlashing)
			{
				yield return null;
			}
			while ((bool)SingletonBehaviour<AGeneralHighlighter>.Instance && SingletonBehaviour<AGeneralHighlighter>.Instance.CurrentlyHighlightedCount != 0)
			{
				yield return null;
			}
			RuntimeHelper[] array = helpers;
			foreach (RuntimeHelper runtimeHelper in array)
			{
				runtimeHelper.highlight.imageEffectMaterial.SetColor(COLOR_MAIN, GetColor(runtimeHelper.colorMain, Mathf.Lerp(nightMultiplier, 1f, lightingCoordinator.SunlightIntensity01)));
				runtimeHelper.highlight.imageEffectMaterial.SetColor(COLOR_OCCLUDED, GetColor(runtimeHelper.colorOccluded, Mathf.Lerp(nightMultiplier, 1f, lightingCoordinator.SunlightIntensity01)));
			}
		}

		private Color GetColor(Color col, float alpha)
		{
			col.a *= alpha;
			return col;
		}

		private void OnDestroy()
		{
			RuntimeHelper[] array = helpers;
			foreach (RuntimeHelper runtimeHelper in array)
			{
				runtimeHelper.highlight.imageEffectMaterial.SetColor(COLOR_MAIN, runtimeHelper.colorMain);
				runtimeHelper.highlight.imageEffectMaterial.SetColor(COLOR_OCCLUDED, runtimeHelper.colorOccluded);
			}
			if (!UnloadWatcher.isUnloading)
			{
				weatherPresetManager.HourChanged -= HourChanged;
			}
		}
	}
}
