using Data.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NewGameplayScripts
{
	public class WallForPlants : MonoBehaviour
	{
		public WorldOrientation wallOrientation;

		private Vector3 topWorld;

		private float lastStateChangeTime;

		private float stateChangeCooldown = 0.02f;

		private bool isInside;

		private BoxCollider boxCollider;

		private void Start()
		{
			boxCollider = GetComponent<BoxCollider>();
			if (boxCollider != null)
			{
				Vector3 position = boxCollider.center + new Vector3(0f, boxCollider.size.y / 2f, 0f);
				topWorld = base.transform.TransformPoint(position);
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			Plant componentInParent = other.GetComponentInParent<Plant>();
			if (MovementSystem.Instance.IsMoving() && componentInParent.plantSize != PlantSize.Big && !(MovementSystem.Instance.GetPlantMoveID() != componentInParent.MoveId))
			{
				componentInParent.ChangePot(plantOnWall: true, wallOrientation);
				MovementSystem.Instance.SetWallPlant(isWallPlant: true, topWorld);
			}
		}

		private void OnTriggerExit(Collider other)
		{
			Plant componentInParent = other.GetComponentInParent<Plant>();
			if (MovementSystem.Instance.IsMoving() && !(MovementSystem.Instance.GetPlantMoveID() != componentInParent.MoveId))
			{
				componentInParent.ChangePot(plantOnWall: false, wallOrientation);
				MovementSystem.Instance.SetWallPlant(isWallPlant: false, topWorld);
			}
		}

		private void OnTriggerStay(Collider other)
		{
			Plant componentInParent = other.GetComponentInParent<Plant>();
			if (InputManager.Instance.gamePause)
			{
				componentInParent.ChangePot(plantOnWall: true, wallOrientation);
			}
			if (MovementSystem.Instance.IsMoving() && componentInParent.plantSize != PlantSize.Big && !(MovementSystem.Instance.GetPlantMoveID() != componentInParent.MoveId))
			{
				componentInParent.ChangePot(plantOnWall: true, wallOrientation);
				MovementSystem.Instance.SetWallPlant(isWallPlant: true, topWorld);
			}
		}

		private void Update()
		{
			RaycastHit[] array = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));
			foreach (RaycastHit raycastHit in array)
			{
				if (raycastHit.collider.gameObject == base.gameObject)
				{
					WorldOrientation worldOrientation = wallOrientation;
					bool flag = worldOrientation == WorldOrientation.North || worldOrientation == WorldOrientation.South;
					if (SceneManager.GetActiveScene().name == "Level_6_New")
					{
						flag = !flag;
					}
					MovementSystem.Instance.MouseEnterInWallForPlantZone(flag, base.gameObject.transform.position.z, base.gameObject.transform.position.x);
					break;
				}
			}
		}
	}
}
