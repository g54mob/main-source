using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.GameView.Planet;
using Assets.Scripts.Flight.ScaledSpace;
using ModApi.Planet;
using ModApi.Planet.Events;
using UnityEngine;

namespace Assets.Scripts.Terrain.Rendering
{
	public class TerrainRendererManagerScript : MonoBehaviour
	{
		public delegate void ScaledSpacePlanetEnabledChangedHandler(TerrainRendererManagerScript source, ScaledSpacePlanetScript planetScript, bool enabled);

		private ScaledSpacePlanetScript _currentScaledSpacePlanetScript;

		private bool _firstFrame = true;

		private IPlanet _planet;

		private List<QuadSphereRenderer> _quadSphereRenderers = new List<QuadSphereRenderer>();

		private List<IScaledSpaceRenderer> _scaledSpaceRenderers = new List<IScaledSpaceRenderer>();

		public static TerrainRendererManagerScript Instance { get; private set; }

		public ScaledSpacePlanetScript CurrentScaledSpacePlanet => _currentScaledSpacePlanetScript;

		public IReadOnlyList<QuadSphereRenderer> QuadSphereRenderers => _quadSphereRenderers;

		public IReadOnlyList<IScaledSpaceRenderer> ScaledSpaceRenderers => _scaledSpaceRenderers;

		public event ScaledSpacePlanetEnabledChangedHandler ScaledSpacePlanetEnabledChanged;

		public IScaledSpaceRenderer AddRenderer(ScaledSpacePlanetScript planetScript, bool isSun)
		{
			IScaledSpaceRenderer scaledSpaceRenderer = (isSun ? ((IScaledSpaceRenderer)ScaledSpaceSunRenderer.Create(planetScript)) : ((IScaledSpaceRenderer)ScaledSpaceRenderer.Create(planetScript)));
			_scaledSpaceRenderers.Add(scaledSpaceRenderer);
			if (_planet.PlanetNode == planetScript.PlanetNode)
			{
				_currentScaledSpacePlanetScript = planetScript;
			}
			return scaledSpaceRenderer;
		}

		public void AddRenderer(QuadSphereScript quadSphereScript)
		{
			_quadSphereRenderers.Add(QuadSphereRenderer.Create(quadSphereScript));
		}

		public void RemoveRenderer(QuadSphereScript quadSphereScript)
		{
			_quadSphereRenderers.RemoveAll((QuadSphereRenderer x) => x.QuadSphereScript == quadSphereScript);
		}

		public void UpdateQuadSphereRenderers()
		{
			for (int i = 0; i < _quadSphereRenderers.Count; i++)
			{
				_quadSphereRenderers[i].UpdateRenderer();
			}
		}

		public void UpdateScaledSpaceRenderers(Camera camera, Vector3d scaledSpaceCameraPosition)
		{
			for (int i = 0; i < _scaledSpaceRenderers.Count; i++)
			{
				IScaledSpaceRenderer scaledSpaceRenderer = _scaledSpaceRenderers[i];
				bool currentPlanet = (object)scaledSpaceRenderer.Planet == _currentScaledSpacePlanetScript;
				scaledSpaceRenderer.UpdateRenderer(camera, scaledSpaceCameraPosition, currentPlanet);
			}
		}

		protected virtual void OnDestroy()
		{
			if (_planet != null)
			{
				_planet.QuadSphereEnabledStateChanged -= OnPlanetScriptQuadSphereEnabledChanged;
				_planet.PlanetNodeChanged -= OnPlanetNodeChanged;
			}
			Instance = null;
		}

		private void Awake()
		{
			Instance = this;
			if (Game.InFlightScene)
			{
				_planet = Game.Instance.FlightScene?.ViewManager.GameView.Planet;
			}
			else
			{
				if (!Game.InPlanetStudioScene)
				{
					throw new NotSupportedException();
				}
				_planet = GetComponent<PlanetScript>();
			}
			_planet.QuadSphereEnabledStateChanged += OnPlanetScriptQuadSphereEnabledChanged;
			_planet.PlanetNodeChanged += OnPlanetNodeChanged;
		}

		private void CheckScaledSpaceRendererActivation()
		{
			if (!(_currentScaledSpacePlanetScript == null))
			{
				bool flag = ((!_planet.QuadSphereEnabled || _planet.QuadSphereTransitionStrength < 1f) && !_planet.IsHidden) || _planet.PlanetNode.Parent == null;
				if (_currentScaledSpacePlanetScript.IsActive != flag)
				{
					_currentScaledSpacePlanetScript.IsActive = flag;
					this.ScaledSpacePlanetEnabledChanged?.Invoke(this, _currentScaledSpacePlanetScript, flag);
				}
			}
		}

		private void FirstFrameLateUpdate()
		{
			CheckScaledSpaceRendererActivation();
			UpdatePlanetRingsState();
		}

		private void LateUpdate()
		{
			if (_firstFrame)
			{
				_firstFrame = false;
				FirstFrameLateUpdate();
			}
			CheckScaledSpaceRendererActivation();
		}

		private void OnPlanetNodeChanged(object sender, PlanetNodeChangeEventArgs e)
		{
			for (int i = 0; i < _scaledSpaceRenderers.Count; i++)
			{
				ScaledSpacePlanetScript planet = _scaledSpaceRenderers[i].Planet;
				if (planet.PlanetNode == _planet.PlanetNode)
				{
					if (_currentScaledSpacePlanetScript?.PlanetRings != null)
					{
						_currentScaledSpacePlanetScript.PlanetRings.SetQuadSphere(null);
					}
					_currentScaledSpacePlanetScript = planet;
					break;
				}
			}
		}

		private void OnPlanetScriptQuadSphereEnabledChanged(object sender, PlanetQuadSphereEventArgs e)
		{
			CheckScaledSpaceRendererActivation();
			UpdatePlanetRingsState();
		}

		private void UpdatePlanetRingsState()
		{
			if ((Game.InFlightScene || Game.InPlanetStudioScene) && _currentScaledSpacePlanetScript != null && _currentScaledSpacePlanetScript.PlanetRings != null)
			{
				if (_planet.QuadSphereEnabled)
				{
					_currentScaledSpacePlanetScript.PlanetRings.SetQuadSphere(_planet.QuadSphere.Transform);
				}
				else
				{
					_currentScaledSpacePlanetScript.PlanetRings.SetQuadSphere(null);
				}
			}
		}
	}
}
