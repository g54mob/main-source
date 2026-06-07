using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Controls;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.GalaxyMap
{
	public class LocationUi : MonoBehaviour
	{
		public SpriteRenderer SelectableBorder;

		public MissionPointDisplay PointDisplay;

		public Color HoverBorderColor;

		public Color NormalBorderColor;

		public SpriteRenderer Image;

		public Transform UndiscoveredPlanet;

		public Transform SpecialPlanet;

		public ParticleSystem SpecialLocationParticles;

		[HideInInspector]
		public LocationData Location;

		private float _radius;

		private GalaxyMapSector _sector;

		private GalaxyMapUiManager _manager;

		private LineRenderer _line;

		private Collider _collider;

		private bool _wasShown;

		private StarmapCamera _cam;

		private Color _lineInitColor;

		private float _lineStartAlpha;

		public void Init(GalaxyMapUiManager manager, LocationData location, GalaxyMapSector sector)
		{
			_manager = manager;
			Location = location;
			_sector = sector;
			_collider = GetComponent<Collider>();
			_line = GetComponent<LineRenderer>();
			_line.useWorldSpace = false;
			_radius = location.Position.magnitude;
			Image.sprite = location.LocationSetting.LocationImage;
			PointDisplay.Init(Location.MissionDifficulty, Location.MissionCompleted);
			if (sector is SolarSystem && (sector.Revealed || sector.Scanned || sector.Explored))
			{
				DrawOrbit();
			}
			if (StarmapCamera.Instance != null)
			{
				_cam = StarmapCamera.Instance;
				_lineInitColor = _line.startColor;
				_lineStartAlpha = _line.colorGradient.alphaKeys.FirstOrDefault().alpha;
			}
			SphereCollider sphereCollider;
			if ((object)(sphereCollider = _collider as SphereCollider) != null)
			{
				sphereCollider.radius *= location.CustomScale;
			}
			Image.transform.localScale *= location.CustomScale;
			UndiscoveredPlanet.localScale *= location.CustomScale;
			SpecialPlanet.localScale *= location.CustomScale;
			SelectableBorder.transform.localScale *= location.CustomScale;
			Vector3 localPosition = PointDisplay.transform.localPosition;
			localPosition.Set(localPosition.x, localPosition.y * location.CustomScale, localPosition.z);
		}

		public void Update()
		{
			_collider.enabled = _sector.Scanned || _sector.Explored;
			if (!_wasShown && (_sector.Revealed || _sector.Scanned || _sector.Explored))
			{
				_wasShown = true;
				if (Location.LocationSetting.CustomMapGameObject != null)
				{
					Image.gameObject.SetActive(false);
					UndiscoveredPlanet.gameObject.SetActive(false);
					GameObject obj = UnityEngine.Object.Instantiate(Location.LocationSetting.CustomMapGameObject, base.transform);
					obj.transform.localPosition = Image.gameObject.transform.localPosition;
					obj.transform.localScale *= Location.CustomScale;
				}
				else
				{
					Image.gameObject.SetActive(true);
					UndiscoveredPlanet.gameObject.SetActive(false);
					Image.sprite = Location.LocationSetting.LocationImage;
					PlanetLocationData planetLocationData;
					if ((planetLocationData = Location as PlanetLocationData) != null)
					{
						NimbatusTerrainClimateZone climateZone = planetLocationData.ClimateZone;
						climateZone.SetSettings(planetLocationData.PlanetSettings);
						Image.sprite = climateZone.StarmapSprite;
						Vector3 localScale = Vector3.one * Mathf.Pow(1f + (float)climateZone.SelectedSettings.PlanetSize / 400f, 5f) / 10f;
						localScale.z = 1f;
						Image.transform.localScale = localScale;
						Image.transform.eulerAngles = new Vector3(0f, 0f, UnityEngine.Random.Range(0, 360));
					}
				}
			}
			else if (!_sector.Revealed && !_sector.Scanned && !_sector.Explored)
			{
				_wasShown = false;
				Image.gameObject.SetActive(false);
				UndiscoveredPlanet.gameObject.SetActive(true);
				Image.transform.localScale = Vector3.one;
			}
			SpecialPlanet.gameObject.SetActive(Location.IsSpecialLocation);
			if (Location.IsSpecialLocation)
			{
				ParticleSystem.MainModule main = SpecialLocationParticles.main;
				main.startColor = Location.LocationSetting.SpecialLocationColor;
			}
			PointDisplay.gameObject.SetActive((_sector.Scanned || _sector.Explored) && _sector is SolarSystem);
			SelectableBorder.gameObject.SetActive(_sector.Scanned || _sector.Explored);
			if (_manager.HoveredLocation == this)
			{
				SelectableBorder.color = HoverBorderColor;
			}
			else
			{
				SelectableBorder.color = NormalBorderColor;
			}
			if (_cam != null)
			{
				float value = (_cam.CurrentZoom - _cam.StartZoom) / (_cam.MaxZoom - _cam.StartZoom);
				value = Mathf.Clamp(value, 0f, 1f);
				Gradient gradient = new Gradient();
				Color col = Color.Lerp(_lineInitColor, new Color(0.9f, 0.9f, 0.9f), value);
				float alpha = Mathf.Lerp(_lineStartAlpha, 0.8f, value);
				gradient.SetKeys(new GradientColorKey[2]
				{
					new GradientColorKey(col, 0f),
					new GradientColorKey(col, 1f)
				}, new GradientAlphaKey[2]
				{
					new GradientAlphaKey(alpha, 0f),
					new GradientAlphaKey(alpha, 1f)
				});
				_line.colorGradient = gradient;
			}
		}

		public void Select()
		{
			if (_sector.Scanned || _sector.Explored)
			{
				_manager.SelectedLocation = this;
				_manager.CalculateTravelCost();
			}
		}

		private void DrawOrbit()
		{
			float num = 0f;
			float num2 = 0.01f;
			int num3 = (int)(1f / num2 + 1f);
			_line.positionCount = num3;
			for (int i = 0; i < num3; i++)
			{
				num += (float)Math.PI * 2f * num2;
				float x = _radius * Mathf.Cos(num);
				float y = _radius * Mathf.Sin(num);
				_line.SetPosition(i, new Vector3(x, y, 0f) + (base.transform.parent.position - base.transform.position).normalized * _radius);
			}
		}

		public void OnClick()
		{
			Select();
		}

		public void OnHover(bool isOver)
		{
			_manager.HoveredLocation = (isOver ? this : null);
		}

		public void OnTooltip(bool show)
		{
			string translation = GetTooltip();
			WormHoleLocationData wormHoleLocationData;
			if ((wormHoleLocationData = Location as WormHoleLocationData) != null)
			{
				translation = LocalizationManager.GetTranslation("GalaxyMap/WormholeTooltip");
				LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, string> { 
				{
					"Level",
					wormHoleLocationData.GalaxyLevel.ToString()
				} });
			}
			NimbatusToolTip.Show(translation);
			if (!show)
			{
				NimbatusToolTip.Show(null);
			}
		}

		public virtual string GetTooltip()
		{
			return Location.Name;
		}
	}
}
