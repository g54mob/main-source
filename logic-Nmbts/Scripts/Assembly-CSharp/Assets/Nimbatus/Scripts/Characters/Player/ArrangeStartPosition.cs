using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Characters.Player
{
	public class ArrangeStartPosition : MonoBehaviour
	{
		public bool AutoArrange;

		public Transform ContainerTransform;

		private bool _hasWokenUp;

		public void Update()
		{
			if (!RuntimeGlobals.IsMovementBlocked && !RuntimeGlobals.IsGameLoading && !_hasWokenUp)
			{
				_hasWokenUp = true;
				if (AutoArrange)
				{
					Arrange();
				}
			}
		}

		public void Arrange()
		{
			float x = 0f;
			if (SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone != null)
			{
				float regionMax = SpawnTransformHelper.GetRegionMax(ESpawnRegion.Surface, SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone.SelectedSettings.PlanetSize);
				float regionMin = SpawnTransformHelper.GetRegionMin(ESpawnRegion.Surface, SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone.SelectedSettings.PlanetSize);
				Vector3 pos;
				Vector3 n;
				ContainerTransform.position = (TransformHelper.GetSurfacePosition(0f, regionMax + 100f, regionMax + 100f - regionMin, out pos, out n) ? new Vector3(x, pos.y + 50f, ContainerTransform.position.z) : new Vector3(x, regionMax + 50f, ContainerTransform.position.z));
				float num = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone.Diameter + 50f;
				Vector3 position = new Vector3(x, ContainerTransform.position.y + num + 180f, 0f);
				RuntimeGlobals.NimbatusPlayer.transform.position = new Vector3(ContainerTransform.position.x, ContainerTransform.position.y, 0f) + new Vector3(0f, 100f + num / 2f);
				RuntimeGlobals.NimbatusPlayer.StartPosition = RuntimeGlobals.NimbatusPlayer.transform.position;
				RuntimeGlobals.Camera.ChangeStartPosition(new Vector3(position.x, position.y, RuntimeGlobals.Camera.transform.position.z));
				NimbatusSpaceShip.Instance.transform.position = position;
			}
			else
			{
				RuntimeGlobals.NimbatusPlayer.transform.position = new Vector3(x, 0f, 0f);
				RuntimeGlobals.NimbatusPlayer.StartPosition = RuntimeGlobals.NimbatusPlayer.transform.position;
				float num2 = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone.Diameter + 50f;
				ContainerTransform.transform.position = new Vector3(x, RuntimeGlobals.NimbatusPlayer.transform.position.y - (num2 / 2f + 90f), 0f);
				Vector3 position2 = new Vector3(x, RuntimeGlobals.NimbatusPlayer.transform.position.y + (num2 / 2f + 90f), 0f);
				RuntimeGlobals.Camera.ChangeStartPosition(new Vector3(position2.x, position2.y, RuntimeGlobals.Camera.transform.position.z));
				NimbatusSpaceShip.Instance.transform.position = position2;
			}
			ContainerTransform.transform.position = new Vector3(ContainerTransform.transform.position.x, ContainerTransform.transform.position.y, -3f);
		}
	}
}
