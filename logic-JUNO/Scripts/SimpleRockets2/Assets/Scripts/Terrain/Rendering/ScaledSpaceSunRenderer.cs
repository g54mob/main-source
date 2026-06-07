using System;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.ScaledSpace;
using Assets.Scripts.Terrain.Rendering.Events;
using ModApi;
using ModApi.Flight.Sim;
using ModApi.Planet;
using UnityEngine;

namespace Assets.Scripts.Terrain.Rendering
{
	public class ScaledSpaceSunRenderer : MonoBehaviour, IScaledSpaceRenderer
	{
		private MeshRenderer _mesh;

		private IPlanetData _planetData;

		private int _terrainRenderQueue = 2000;

		private Transform _transform;

		public ScaledSpacePlanetScript Planet { get; private set; }

		protected int TerrainRenderQueue
		{
			get
			{
				return _terrainRenderQueue;
			}
			set
			{
				if (_terrainRenderQueue != value)
				{
					_terrainRenderQueue = value;
					_mesh.material.renderQueue = value;
				}
			}
		}

		public event EventHandler<PlanetCubemapsChangedEventArgs> CubemapsChanged
		{
			add
			{
				throw new NotSupportedException();
			}
			remove
			{
			}
		}

		public static ScaledSpaceSunRenderer Create(ScaledSpacePlanetScript planetScript)
		{
			ScaledSpaceSunRenderer scaledSpaceSunRenderer = planetScript.gameObject.AddComponent<ScaledSpaceSunRenderer>();
			scaledSpaceSunRenderer.Planet = planetScript;
			scaledSpaceSunRenderer._planetData = scaledSpaceSunRenderer.Planet.PlanetNode.PlanetData;
			scaledSpaceSunRenderer._transform = scaledSpaceSunRenderer.Planet.gameObject.transform;
			GameObject gameObject = Game.Instance.ResourceLoader.InstantiatePrefab("Planets/Sun");
			gameObject.layer = planetScript.gameObject.layer;
			gameObject.transform.SetParent(scaledSpaceSunRenderer._transform);
			gameObject.transform.localPosition = Vector3.zero;
			float num = (float)scaledSpaceSunRenderer._planetData.RadiusScaledSpace;
			gameObject.transform.localScale = new Vector3(num, num, num);
			scaledSpaceSunRenderer._mesh = Utilities.FindFirstGameObjectMyselfOrChildren("Mesh", gameObject).GetComponent<MeshRenderer>();
			scaledSpaceSunRenderer._mesh.material.color = 8f * (FlightSceneScript.Instance?.FlightState?.SolarSystemData?.FlareColor ?? Color.white);
			return scaledSpaceSunRenderer;
		}

		public Material CreateMaterialDuplicate()
		{
			return null;
		}

		public void GetTextures(out Texture cubeTex, out Texture bumpTex)
		{
			throw new InvalidOperationException("The Sun does not have a cube/bump map textures");
		}

		public void UpdateRenderer(Camera camera, Vector3d scaledSpaceCameraPosition, bool currentPlanet)
		{
			IPlanetNode planetNode = Planet.PlanetNode;
			Vector3d vector3d = (planetNode.SolarPosition - scaledSpaceCameraPosition) * 0.0001;
			_transform.SetLocalPositionAndRotation(vector3d.ToVector3(), planetNode.Rotation.ToQuaternion());
		}
	}
}
