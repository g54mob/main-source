using Assets.Scripts.Craft;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.State;
using ModApi.Flight.Sim;
using UnityEngine;

namespace Assets.Scripts.DebugScripts
{
	public class ChangeOrbitsScript : MonoBehaviour
	{
		[SerializeField]
		private bool _copyValues;

		[SerializeField]
		private Vector3d _craftPosition;

		[SerializeField]
		private float _craftSoi;

		[SerializeField]
		private bool _craftSoiShow = true;

		private GameObject _craftSoiSphere;

		[SerializeField]
		private Vector3d _craftVelocity;

		[SerializeField]
		private bool _go;

		private bool _initialized;

		private MapItem _mapCraft;

		[SerializeField]
		private MapPlanet _mapPlanet;

		[SerializeField]
		private Vector3d _newCraftPosition;

		[SerializeField]
		private Vector3d _newCraftVelocity;

		[SerializeField]
		private Vector3d _newPlanetPosition;

		[SerializeField]
		private Vector3d _newPlanetVelocity;

		[SerializeField]
		private Vector3d _planetPosition;

		[SerializeField]
		private float _planetSoi;

		[SerializeField]
		private bool _planetSoiShow = true;

		private GameObject _planetSoiSphere;

		[SerializeField]
		private Vector3d _planetVelocity;

		private CraftScript _playerCraft;

		public void Update()
		{
			IOrbit orbit = _playerCraft.CraftNode.Orbit;
			_craftPosition = orbit.Position;
			_craftVelocity = orbit.Velocity;
			IOrbitNode orbitNode = _mapPlanet?.OrbitInfo.OrbitNode;
			if (orbitNode != null)
			{
				IOrbit orbit2 = orbitNode.Orbit;
				_planetVelocity = orbit2.Velocity;
				_planetPosition = orbit2.Position;
			}
		}

		private void OnValidate()
		{
			if (!_initialized)
			{
				return;
			}
			if (_go)
			{
				_go = false;
				IOrbit orbit = _playerCraft.CraftNode.Orbit;
				_playerCraft.CraftNode.Orbit.UpdateFromStateVectors(_newCraftPosition, _newCraftVelocity, orbit.Time, orbit.PrimaryMass);
				IOrbitNode orbitNode = _mapPlanet.OrbitInfo.OrbitNode;
				if (orbitNode != null)
				{
					orbitNode.Orbit.UpdateFromStateVectors(_newPlanetPosition, _newPlanetVelocity, orbit.Time, orbit.PrimaryMass);
				}
				else
				{
					Debug.LogWarning("PlanetNode wasn't set");
				}
				_playerCraft.CraftNode.RecalculateFrameState(Game.Instance.FlightScene.ViewManager.GameView.ReferenceFrame);
			}
			_craftSoiSphere.SetActive(_craftSoiShow);
			_craftSoiSphere.transform.localScale = _craftSoi * 2f * Vector3.one;
			_planetSoiSphere.SetActive(_planetSoiShow);
			_planetSoiSphere.transform.localScale = _planetSoi * 2f * Vector3.one;
			if (_copyValues)
			{
				_copyValues = false;
				_newCraftPosition = _craftPosition;
				_newCraftVelocity = _craftVelocity;
				_newPlanetPosition = _planetPosition;
				_newPlanetVelocity = _planetVelocity;
			}
		}

		private void Start()
		{
			_initialized = true;
			IItemRegistry itemRegistry = Game.Instance.FlightScene.IocContainer.Resolve<IItemRegistry>(_mapCraft.MapViewContext);
			_playerCraft = Game.Instance.FlightScene.CraftNode.CraftScript as CraftScript;
			_mapCraft = itemRegistry.GetCraft(_playerCraft.CraftNode);
			IPlanetNode childPlanet = FlightState.GetChildPlanet(((FlightSceneScript)Game.Instance.FlightScene).FlightState.RootNode, "Cylero");
			_mapPlanet = itemRegistry.GetPlanet(childPlanet);
			_newCraftPosition = new Vector3d(164399251720.82098, -6277149256.813671, 196875424541.12305);
			_newCraftVelocity = new Vector3d(1123.0212750822332, 8.921278534737995, -937.4855064990838);
			_newPlanetVelocity = new Vector3d(-4645.615268860776, -1502.4294911703143, -2726.5629777347935);
			_newPlanetPosition = new Vector3d(-10383854475.450872, 1110847823.5689478, -9627037622.785395);
			_craftSoi = 6592.3027f;
			_planetSoi = 12788.061f;
			_planetSoiSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			_planetSoiSphere.layer = LayerMask.NameToLayer("MapView");
			_planetSoiSphere.transform.parent = _mapPlanet.transform;
			_planetSoiSphere.transform.localPosition = Vector3.zero;
			_planetSoiSphere.transform.localScale = _planetSoi * 2f * Vector3.one;
			Object.Destroy(_planetSoiSphere.GetComponent<Collider>());
			_craftSoiSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			_craftSoiSphere.layer = LayerMask.NameToLayer("MapView");
			_craftSoiSphere.transform.parent = _mapCraft.transform;
			_craftSoiSphere.transform.localPosition = Vector3.zero;
			_craftSoiSphere.transform.localScale = _craftSoi * 2f * Vector3.one;
			Object.Destroy(_craftSoiSphere.GetComponent<Collider>());
		}
	}
}
