using System;
using ModApi.Planet;
using ModApi.PlanetStudio;
using ModApi.PlanetStudio.Events;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.PlanetStudio.UI
{
	public class EquirectangularMapViewScript : MonoBehaviour, IEquirectangularMapView, IPlanetStudioInitialized
	{
		private XmlElement _element;

		private RawImage _image;

		private float _scale = 1f;

		private int _size;

		public bool Enabled
		{
			get
			{
				return base.gameObject.activeSelf;
			}
			set
			{
				if (Enabled != value)
				{
					base.gameObject.SetActive(value);
					if (value)
					{
						Refresh();
					}
				}
			}
		}

		public float Scale
		{
			get
			{
				return _scale;
			}
			set
			{
				_scale = value;
				_element.SetAttribute("width", ((int)((float)_size * _scale)).ToString());
				_element.SetAttribute("height", ((int)((float)_size * 0.5f * _scale)).ToString());
				_element.ApplyAttributes();
				_ = _image.rectTransform.rect;
			}
		}

		void IPlanetStudioInitialized.OnInitialized(IPlanetStudioUI planetStudioUI)
		{
			planetStudioUI.EditModeChanged += OnPlanetStudioEditModeChanged;
			planetStudioUI.PlanetStudio.CelestialBodyDesigner.CelestialBodyLoaded += OnCelestialBodyLoaded;
		}

		public void Refresh()
		{
			Rect rect = _image.rectTransform.rect;
			PlanetDataScript currentCelestialBody = PlanetStudioScript.Instance.CelestialBodyDesigner.CurrentCelestialBody;
			PlanetDataScript planetDataScript = PlanetDataScript.CreateFromXml(PlanetStudioScript.Instance.CelestialBodyDesignerScript.SaveXml(useFilePaths: true).Root, currentCelestialBody.File, null, null, null, createTerrainData: true, applyScaleAndOverrides: false);
			Texture2D[] array = PlanetCubemapUtility.CreateEquirectangularMap(planetDataScript, (int)rect.width, (int)rect.height, 0, currentCelestialBody.EquirectangularMapBrightness * 0.15f, currentCelestialBody.EquirectangularMapLight, saveMaps: false);
			array[0].Apply();
			_image.texture = array[0];
			UnityEngine.Object.Destroy(planetDataScript.gameObject);
		}

		protected virtual void Awake()
		{
			_element = GetComponent<XmlElement>();
			_image = GetComponentInChildren<RawImage>();
			_size = _element.GetAttribute("width").ToInt();
			Enabled = false;
		}

		protected virtual void Start()
		{
		}

		private void OnCelestialBodyLoaded(object sender, CelestialBodyLoadedEventArgs e)
		{
			_image.texture = null;
			if (Enabled)
			{
				Refresh();
			}
		}

		private void OnPlanetStudioEditModeChanged(object sender, EventArgs e)
		{
			Enabled = false;
		}
	}
}
