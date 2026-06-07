using Assets.Scripts.Flight.GameView.Planet;
using Assets.Scripts.Terrain.Rendering;
using ModApi.Flight.Sim;
using UnityEngine;

namespace Assets.Scripts.Flight.ScaledSpace
{
	public class ScaledSpacePlanetScript : MonoBehaviour
	{
		public bool IsActive
		{
			get
			{
				return base.gameObject.activeSelf;
			}
			set
			{
				base.gameObject.SetActive(value);
			}
		}

		public IPlanetNode PlanetNode { get; private set; }

		public PlanetRingsScript PlanetRings { get; private set; }

		public IScaledSpaceRenderer Renderer { get; private set; }

		public static ScaledSpacePlanetScript Create(IPlanetNode planet, Transform parent)
		{
			GameObject obj = new GameObject(planet.PlanetData.Name);
			obj.transform.SetParent(parent, worldPositionStays: false);
			ScaledSpacePlanetScript scaledSpacePlanetScript = obj.AddComponent<ScaledSpacePlanetScript>();
			scaledSpacePlanetScript.Initialize(planet, parent);
			return scaledSpacePlanetScript;
		}

		public void Initialize(IPlanetNode planetNode, Transform parent)
		{
			PlanetNode = planetNode;
			base.gameObject.layer = 8;
			if (PlanetNode.PlanetData.RingsData.HasRings)
			{
				GameObject gameObject = Game.Instance.ResourceLoader.InstantiatePrefab("Planets/PlanetRings");
				PlanetRings = gameObject.GetComponent<PlanetRingsScript>();
				PlanetRings.Initialize(planetNode.PlanetData, base.transform, parent);
			}
			bool flag = planetNode.Parent == null;
			if (!flag)
			{
				base.gameObject.AddComponent<SphereCollider>().radius = (float)planetNode.PlanetData.RadiusScaledSpace;
			}
			SetRenderer(TerrainRendererManagerScript.Instance.AddRenderer(this, flag));
		}

		public void SetRenderer(IScaledSpaceRenderer renderer)
		{
			Renderer = renderer;
		}
	}
}
