using System.Collections.Generic;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Missions.Objectives;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.TravelEvents;
using Assets.Nimbatus.Scripts.WorldObjects;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Cursor
{
	public class CursorToTarget : MonoBehaviour
	{
		public SpriteRenderer TargetArrowPrefab;

		public static CursorToTarget Instance;

		private List<string> _targets = new List<string>();

		private Dictionary<InteractiveWorldObject, SpriteRenderer> _targetDictionary = new Dictionary<InteractiveWorldObject, SpriteRenderer>();

		public void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else
			{
				Object.Destroy(base.gameObject);
			}
			if (!(SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveEvent != null))
			{
				EMissionType mission = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.Mission;
			}
			else
			{
				EMissionType activeMission2 = SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveMission;
			}
			NimbatusMission activeMission = SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission;
			if (activeMission == null || activeMission.IsCompleted())
			{
				return;
			}
			foreach (MissionObjective missionObjective in activeMission.GetMissionObjectives())
			{
				DestroyObjective destroyObjective;
				CollectItemObjective collectItemObjective;
				if ((destroyObjective = missionObjective as DestroyObjective) != null)
				{
					_targets.Add(destroyObjective.GetTarget().WorldObject.UniqueId);
				}
				else if ((collectItemObjective = missionObjective as CollectItemObjective) != null)
				{
					_targets.Add(collectItemObjective.GetTarget().WorldObject.UniqueId);
				}
			}
		}

		public void Register(InteractiveWorldObject obj)
		{
			if (_targets.Contains(obj.UniqueId))
			{
				_targetDictionary.Add(obj, Object.Instantiate(TargetArrowPrefab, base.transform));
			}
		}

		public void Update()
		{
			if (_targetDictionary.Count < 1 || RuntimeGlobals.Camera.Camera == null)
			{
				return;
			}
			Vector3 vector = new Vector3(RuntimeGlobals.Camera.Camera.transform.position.x, RuntimeGlobals.Camera.Camera.transform.position.y, 0f);
			Vector3 vector2 = RuntimeGlobals.Camera.Camera.ViewportToWorldPoint(new Vector3(0f, 1f, 0f - RuntimeGlobals.Camera.Camera.transform.position.z));
			Vector3 vector3 = RuntimeGlobals.Camera.Camera.ViewportToWorldPoint(new Vector3(1f, 1f, 0f - RuntimeGlobals.Camera.Camera.transform.position.z));
			Vector3 vector4 = RuntimeGlobals.Camera.Camera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f - RuntimeGlobals.Camera.Camera.transform.position.z));
			Vector3 vector5 = RuntimeGlobals.Camera.Camera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f - RuntimeGlobals.Camera.Camera.transform.position.z));
			Vector3 b = RuntimeGlobals.Camera.Camera.ViewportToWorldPoint(new Vector3(0.5f, 1f, 0f - RuntimeGlobals.Camera.Camera.transform.position.z + 10f));
			Vector3 b2 = RuntimeGlobals.Camera.Camera.ViewportToWorldPoint(new Vector3(1f, 0.5f, 0f - RuntimeGlobals.Camera.Camera.transform.position.z + 10f));
			Vector3 b3 = RuntimeGlobals.Camera.Camera.ViewportToWorldPoint(new Vector3(0.5f, 0f, 0f - RuntimeGlobals.Camera.Camera.transform.position.z + 10f));
			Vector3 b4 = RuntimeGlobals.Camera.Camera.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0f - RuntimeGlobals.Camera.Camera.transform.position.z + 10f));
			Plane plane = new Plane(vector2, b, vector3);
			Plane plane2 = new Plane(vector3, b2, vector5);
			Plane plane3 = new Plane(vector5, b3, vector4);
			Plane plane4 = new Plane(vector4, b4, vector2);
			foreach (KeyValuePair<InteractiveWorldObject, SpriteRenderer> item in _targetDictionary)
			{
				if (item.Key == null)
				{
					item.Value.enabled = false;
					continue;
				}
				Vector3 vector6 = new Vector3(item.Key.transform.position.x, item.Key.transform.position.y, 0f);
				Vector3 direction = vector6 - vector;
				Ray ray = new Ray(vector, direction);
				float enter;
				plane.Raycast(ray, out enter);
				float enter2;
				plane2.Raycast(ray, out enter2);
				float enter3;
				plane3.Raycast(ray, out enter3);
				float enter4;
				plane4.Raycast(ray, out enter4);
				if (Mathf.FloorToInt(enter) <= 0)
				{
					enter = float.PositiveInfinity;
				}
				if (Mathf.FloorToInt(enter2) <= 0)
				{
					enter2 = float.PositiveInfinity;
				}
				if (Mathf.FloorToInt(enter3) <= 0)
				{
					enter3 = float.PositiveInfinity;
				}
				if (Mathf.FloorToInt(enter4) <= 0)
				{
					enter4 = float.PositiveInfinity;
				}
				float num = Mathf.Min(enter, enter2, enter3, enter4);
				Vector3 position = ((direction.magnitude < num) ? vector6 : ray.GetPoint(num));
				position -= direction.normalized * (1f + (Mathf.Sin(Time.time * 10f) + 1f) * 0.5f * 2f);
				item.Value.transform.position = position;
				item.Value.transform.position = new Vector3(position.x, position.y, RuntimeGlobals.Camera.Camera.transform.position.z + 2f);
				item.Value.transform.eulerAngles = new Vector3(0f, 0f, Mathf.Atan2(direction.y, direction.x) * 57.29578f);
				Vector2 vector7 = RuntimeGlobals.Camera.transform.position - vector6;
				item.Value.enabled = vector7.magnitude > 100f;
			}
		}

		public void OnDisable()
		{
			if (Instance == this)
			{
				Instance = null;
			}
		}
	}
}
