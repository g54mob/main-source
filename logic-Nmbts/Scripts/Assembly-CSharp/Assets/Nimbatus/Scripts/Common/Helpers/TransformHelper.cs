using System;
using System.Linq;
using Assets.Nimbatus.Scripts.Combat;
using Assets.Nimbatus.Scripts.GalaxyMap.CombatArena;
using Assets.Nimbatus.Scripts.GalaxyMap.Race;
using Assets.Nimbatus.Scripts.GalaxyMap.Race.Arena;
using Assets.Nimbatus.Scripts.GalaxyMap.Race.Obstacle;
using Assets.Nimbatus.Scripts.GalaxyMap.Race.Timed;
using Assets.Nimbatus.Scripts.GalaxyMap.Race.Versus;
using Assets.Nimbatus.Scripts.GalaxyMap.SumoArena;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	public static class TransformHelper
	{
		public static void DestroyAllChildren(this Transform transform)
		{
			(from Transform child in transform
				select child.gameObject).ToList().ForEach(delegate(GameObject p)
			{
				p.transform.parent = null;
				UnityEngine.Object.Destroy(p);
			});
		}

		public static bool GetSurfacePosition(float angle, float checkHeight, float range, out Vector3 pos, out Vector3 n)
		{
			float x = checkHeight * Mathf.Sin(angle * ((float)Math.PI / 180f));
			float y = checkHeight * Mathf.Cos(angle * ((float)Math.PI / 180f));
			Vector2 vector = new Vector2(x, y);
			Vector2 vector2 = Vector2.zero - vector;
			RaycastHit hitInfo;
			if (Physics.Raycast(new Ray(vector, vector2), out hitInfo, range, BaseSingleton<CollisionLayerManager>.Instance.TerrainLayerMask))
			{
				pos = hitInfo.point;
				n = hitInfo.normal;
				return true;
			}
			pos = Vector3.zero;
			n = Vector3.zero;
			return false;
		}

		public static float GetAngle(Vector3 pos)
		{
			return Mathf.Atan2(pos.x, pos.y) * 57.29578f;
		}

		public static bool IsInsideCameraViewport(Camera cam, Vector3 position, float modifier)
		{
			Vector3 vector = cam.WorldToViewportPoint(position);
			float num = 0f + modifier;
			float num2 = 1f - modifier;
			float num3 = 0f + modifier / cam.aspect;
			float num4 = 1f - modifier / cam.aspect;
			if (vector.z > num && vector.x > num3 && vector.x < num4 && vector.y > num)
			{
				return vector.y < num2;
			}
			return false;
		}

		public static bool GetSurfacePosition(Vector2 startPosition, float angle, out Vector3 pos, out Vector3 n, float maxDistance = 1000f)
		{
			float x = 1000f * Mathf.Sin(angle * ((float)Math.PI / 180f));
			float y = 1000f * Mathf.Cos(angle * ((float)Math.PI / 180f));
			RaycastHit hitInfo;
			if (Physics.Raycast(new Ray(direction: new Vector2(x, y), origin: startPosition), out hitInfo, maxDistance, BaseSingleton<CollisionLayerManager>.Instance.TerrainLayerMask))
			{
				pos = hitInfo.point;
				n = hitInfo.normal;
				return true;
			}
			pos = Vector3.zero;
			n = Vector3.zero;
			return false;
		}

		public static float GetSurfaceHeight(float angle)
		{
			float x = 1000f * Mathf.Sin(angle * ((float)Math.PI / 180f));
			float y = 1000f * Mathf.Cos(angle * ((float)Math.PI / 180f));
			Vector2 vector = new Vector2(x, y);
			Vector2 vector2 = Vector2.zero - vector;
			RaycastHit hitInfo;
			if (Physics.Raycast(new Ray(vector, vector2), out hitInfo, 1000f, BaseSingleton<CollisionLayerManager>.Instance.TerrainLayerMask))
			{
				return hitInfo.point.magnitude;
			}
			return WorldController.TerrainSettings.PlanetSize;
		}

		public static Vector2 GetDirection(float angle)
		{
			float x = Mathf.Sin(angle * ((float)Math.PI / 180f));
			float y = Mathf.Cos(angle * ((float)Math.PI / 180f));
			return new Vector2(x, y);
		}

		public static Vector3 GetMousePosition(Camera camera)
		{
			Vector3 position = Input.mousePosition + new Vector3(0f, 0f, Mathf.Abs(camera.transform.position.z));
			Vector3 result = camera.ScreenToWorldPoint(position);
			result.z = 0f;
			return result;
		}

		public static Vector3 RotateVector(Vector3 vector, float angle)
		{
			float f = angle * ((float)Math.PI / 180f);
			float x = vector.x * Mathf.Cos(f) - vector.y * Mathf.Sin(f);
			float y = vector.x * Mathf.Sin(f) + vector.y * Mathf.Cos(f);
			return new Vector2(x, y);
		}

		public static Quaternion Get2DRotationTowardsMouse(Vector3 currentPosition, Camera camera)
		{
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.z = (currentPosition - camera.transform.position).z;
			Vector3 vector = camera.ScreenToWorldPoint(mousePosition);
			vector -= currentPosition;
			return Quaternion.AngleAxis(Mathf.Atan2(vector.y, vector.x) * 57.29578f, Vector3.forward);
		}

		public static Quaternion Get2DRotationTowardsPlayer(Vector3 currentPosition)
		{
			Vector3 position = RuntimeGlobals.NimbatusPlayer.transform.position;
			position -= currentPosition;
			return Quaternion.AngleAxis(Mathf.Atan2(position.y, position.x) * 57.29578f, Vector3.forward);
		}

		public static Quaternion Get2DRotationTowardsTarget(Vector3 currentPosition, Vector3 targetPosition)
		{
			Vector3 vector = targetPosition;
			vector -= currentPosition;
			return Quaternion.AngleAxis(Mathf.Atan2(vector.y, vector.x) * 57.29578f, Vector3.forward);
		}

		public static void ActivateChildren(this Transform transform, bool active)
		{
			for (int i = 0; i < transform.childCount; i++)
			{
				transform.GetChild(i).gameObject.SetActive(active);
			}
		}

		public static bool GetDirectionToOpponent(NimbatusDrone rootDrone, Vector2 myPosition, out Vector2 direction)
		{
			direction = Vector2.zero;
			if (SumoArenaManager.Instance != null)
			{
				direction = SumoArenaManager.Instance.GetOpponentPosition(rootDrone) - myPosition;
				return true;
			}
			if (CombatArenaManager.Instance != null)
			{
				direction = CombatArenaManager.Instance.GetOpponentPosition(rootDrone) - myPosition;
				return true;
			}
			if (BaseRaceManager.Instance != null)
			{
				RaceVersusManager raceVersusManager = BaseRaceManager.Instance as RaceVersusManager;
				if (raceVersusManager != null)
				{
					direction = raceVersusManager.GetOpponentPosition(rootDrone) - myPosition;
					return true;
				}
				VersusArenaManager versusArenaManager = BaseRaceManager.Instance as VersusArenaManager;
				if (versusArenaManager != null)
				{
					direction = versusArenaManager.GetOpponentPosition(rootDrone) - myPosition;
					return true;
				}
				int num;
				bool flag;
				if ((bool)(BaseRaceManager.Instance as RaceManager))
				{
					num = 1;
				}
				else
					flag = (bool)(BaseRaceManager.Instance as RaceObstacleCourseManager);
				return false;
			}
			return false;
		}

		public static bool GetDirectionToWaypoint(NimbatusDrone rootDrone, DronePart dronePart, Vector2 myPosition, out Vector2 direction)
		{
			if (rootDrone.TrackerManager != null && rootDrone.TrackerManager.Initialized)
			{
				direction = (Vector2)rootDrone.TrackerManager.GetTargetPosition(dronePart) - myPosition;
				return true;
			}
			VersusArenaManager versusArenaManager;
			if ((object)(versusArenaManager = BaseRaceManager.Instance as VersusArenaManager) != null)
			{
				direction = (Vector2)versusArenaManager.GetTrackerPosition() - myPosition;
				return true;
			}
			if (SumoArenaManager.Instance != null)
			{
				direction = SumoArenaManager.Instance.GetOpponentPosition(rootDrone) - myPosition;
				return true;
			}
			if (CombatArenaManager.Instance != null)
			{
				direction = CombatArenaManager.Instance.GetOpponentPosition(rootDrone) - myPosition;
				return true;
			}
			direction = Vector2.zero;
			return false;
		}

		public static bool GetDirectionToNearestEnemy(Vector3 position, LayerMask layer, int radius, out Vector2 direction)
		{
			Collider[] array = Physics.OverlapSphere(position, radius, layer.value);
			float num = float.MaxValue;
			direction = Vector2.zero;
			foreach (Collider collider in array)
			{
				float num2 = Vector2.Distance(position, collider.transform.position);
				if (num2 < num)
				{
					num = num2;
					direction = collider.transform.position - position;
				}
			}
			if (array.Length != 0)
			{
				return true;
			}
			return false;
		}
	}
}
