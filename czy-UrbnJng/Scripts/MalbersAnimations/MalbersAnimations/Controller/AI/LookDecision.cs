using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Decision/Look", order = -101)]
	public class LookDecision : MAIDecision
	{
		[Range(0f, 1f)]
		[Tooltip("Shorten the Look Ray to not found the ground by mistake")]
		public float LookMultiplier = 0.9f;

		[Space]
		[Tooltip("Range for Looking forward and Finding something")]
		public FloatReference LookRange = new FloatReference(15f);

		[Range(0f, 360f)]
		[Tooltip("Angle of Vision of the Animal")]
		public float LookAngle = 120f;

		[Space]
		[Tooltip("What to look for??")]
		public LookFor lookFor;

		[Tooltip("Layers that can block the Animal Eyes")]
		public LayerReference ObstacleLayer = new LayerReference(1);

		[Space(20f)]
		[Tooltip("If the what we are looking for is found then Assign it as a new Target")]
		public bool AssignTarget = true;

		[Tooltip("If the what we are looking for is found then also start moving")]
		public bool MoveToTarget = true;

		[Tooltip("Select randomly one of the potential targets, not the closest one found")]
		public bool ChooseRandomly;

		[Space]
		[Tooltip("Look for this Unity Tag on an Object")]
		public string UnityTag = string.Empty;

		[Tooltip("Look for an Specific GameObject by its name")]
		public string GameObjectName = string.Empty;

		[RequiredField]
		[Tooltip("Transform Reference value. This value should be set by a Transform Hook Component")]
		public TransformVar transform;

		[RequiredField]
		[Tooltip("GameObject Reference value. This value should be set by a GameObject Hook Component")]
		public GameObjectVar gameObject;

		[RequiredField]
		[Tooltip("GameObjectSet. Search for all  GameObjects Set in the Set")]
		public RuntimeGameObjects gameObjectSet;

		[Tooltip("Custom Tags you want to find")]
		public Tag[] tags;

		[Tooltip("Type of Zone we want to find")]
		public ZoneType zoneType;

		[Tooltip("Search for all zones")]
		public bool AllZones = true;

		[Tooltip("ID value of the Zone we want to find")]
		[Min(-1f)]
		public int ZoneID = -1;

		[Tooltip("Mode Zone Index")]
		[Min(-1f)]
		public int ZoneModeAbility = -1;

		public Color debugColor = new Color(0f, 0f, 0.7f, 0.3f);

		public override string DisplayName => "General/Look";

		private void Reset()
		{
			Description = "The Animal will look for an Object using a cone view";
		}

		public override bool Decide(MAnimalBrain brain, int index)
		{
			return Look_For(brain, assign: false, index);
		}

		public override void FinishDecision(MAnimalBrain brain, int index)
		{
			Look_For(brain, AssignTarget, index);
		}

		public override void PrepareDecision(MAnimalBrain brain, int index)
		{
			switch (lookFor)
			{
			case LookFor.MalbersTag:
			{
				if (Tags.TagsHolders == null || tags == null || tags.Length == 0)
				{
					return;
				}
				List<GameObject> list = new List<GameObject>();
				foreach (Tags tagsHolder in Tags.TagsHolders)
				{
					if (tagsHolder.gameObject.HasMalbersTag(tags))
					{
						list.Add(tagsHolder.gameObject);
					}
				}
				if (list.Count > 0)
				{
					brain.DecisionsVars[index].gameobjects = list.ToArray();
				}
				break;
			}
			case LookFor.UnityTag:
				if (string.IsNullOrEmpty(UnityTag))
				{
					return;
				}
				brain.DecisionsVars[index].gameobjects = GameObject.FindGameObjectsWithTag(UnityTag);
				break;
			case LookFor.RuntimeGameobjectSet:
				if (gameObjectSet == null || gameObjectSet.Count == 0)
				{
					return;
				}
				brain.DecisionsVars[index].gameobjects = gameObjectSet.Items.ToArray();
				break;
			}
			StoreColliders(brain, index);
		}

		private void StoreColliders(MAnimalBrain brain, int index)
		{
			if (brain.DecisionsVars[index].gameobjects == null || brain.DecisionsVars[index].gameobjects.Length == 0)
			{
				return;
			}
			List<Collider> list = new List<Collider>();
			for (int i = 0; i < brain.DecisionsVars[index].gameobjects.Length; i++)
			{
				Collider[] componentsInChildren = brain.DecisionsVars[index].gameobjects[i].GetComponentsInChildren<Collider>();
				foreach (Collider collider in componentsInChildren)
				{
					if (!collider.isTrigger && !MTools.Layer_in_LayerMask(collider.gameObject.layer, ObstacleLayer.Value))
					{
						list.Add(collider);
					}
				}
			}
			ref BrainVars reference = ref brain.DecisionsVars[index];
			Component[] components = list.ToArray();
			reference.AddComponents(components);
		}

		private bool Look_For(MAnimalBrain brain, bool assign, int index)
		{
			return lookFor switch
			{
				LookFor.MainAnimalPlayer => LookForAnimalPlayer(brain, assign), 
				LookFor.MalbersTag => LookForMalbersTags(brain, assign, index), 
				LookFor.UnityTag => LookForUnityTags(brain, assign, index), 
				LookFor.Zones => LookForZones(brain, assign), 
				LookFor.GameObject => LookForGameObjectByName(brain, assign), 
				LookFor.ClosestWayPoint => LookForClosestWaypoint(brain, assign), 
				LookFor.CurrentTarget => LookForTarget(brain, assign), 
				LookFor.TransformVar => LookForTransformVar(brain, assign), 
				LookFor.GameObjectVar => LookForGoVar(brain, assign), 
				LookFor.RuntimeGameobjectSet => LookForGoSet(brain, assign, index), 
				_ => false, 
			};
		}

		public bool LookForTarget(MAnimalBrain brain, bool assign)
		{
			if (brain.Target == null)
			{
				return false;
			}
			AssignMoveTarget(brain, brain.Target, assign);
			Vector3 center = (brain.TargetAnimal ? brain.TargetAnimal.Center : brain.Target.position);
			float Distance;
			return IsInFieldOfView(brain, center, out Distance);
		}

		public bool LookForTransformVar(MAnimalBrain brain, bool assign)
		{
			if (transform == null || transform.Value == null)
			{
				return false;
			}
			AssignMoveTarget(brain, transform.Value, assign);
			Vector3 center = ((transform.Value == brain.Target && brain.AIControl.IsAITarget != null) ? brain.AIControl.IsAITarget.GetCenterY() : transform.Value.position);
			float Distance;
			return IsInFieldOfView(brain, center, out Distance);
		}

		public bool LookForGoVar(MAnimalBrain brain, bool assign)
		{
			if (gameObject == null && (bool)gameObject.Value && !gameObject.Value.IsPrefab())
			{
				return false;
			}
			AssignMoveTarget(brain, gameObject.Value.transform, assign);
			Vector3 center = ((gameObject.Value.transform == brain.Target && brain.AIControl.IsAITarget != null) ? brain.AIControl.IsAITarget.GetCenterY() : gameObject.Value.transform.position);
			float Distance;
			return IsInFieldOfView(brain, center, out Distance);
		}

		private bool IsInFieldOfView(MAnimalBrain brain, Vector3 Center, out float Distance)
		{
			Vector3 vector = Center - brain.Eyes.position;
			Distance = Vector3.Distance(Center, brain.Eyes.position) * LookMultiplier;
			if (LookAngle == 0f || (float)LookRange <= 0f)
			{
				return true;
			}
			if (Distance < LookRange.Value * brain.Animal.ScaleFactor)
			{
				Vector3 to = Vector3.ProjectOnPlane(brain.Eyes.forward, brain.Animal.UpVector);
				if (Vector3.Angle(vector, to) < LookAngle / 2f)
				{
					if (Physics.Raycast(brain.Eyes.position, vector, out var hitInfo, Distance, ObstacleLayer, QueryTriggerInteraction.Ignore))
					{
						if (brain.debug)
						{
							Debug.DrawRay(brain.Eyes.position, vector * LookMultiplier, Color.green, interval);
							Debug.DrawLine(hitInfo.point, Center, Color.red, interval);
							MDebug.DrawWireSphere(Center, Color.red, interval);
							MDebug.DrawCircle(hitInfo.point, hitInfo.normal, 0.1f, Color.red, cross: true, interval);
						}
						return false;
					}
					if (brain.debug)
					{
						Debug.DrawRay(brain.Eyes.position, vector, Color.green, interval);
						MDebug.DrawWireSphere(Center, Color.green, interval);
					}
					return true;
				}
				return false;
			}
			return false;
		}

		private void AssignMoveTarget(MAnimalBrain brain, Transform target, bool assign)
		{
			if (assign && AssignTarget)
			{
				brain.AIControl.SetTarget(target, MoveToTarget);
			}
		}

		public bool LookForZones(MAnimalBrain brain, bool assign)
		{
			List<Zone> zones = Zone.Zones;
			if (zones == null || zones.Count == 0)
			{
				return false;
			}
			float num = float.PositiveInfinity;
			Zone zone = null;
			foreach (Zone item in zones)
			{
				if ((AllZones || ((bool)item && item.zoneType == zoneType && ZoneID == -1) || item.ZoneID == ZoneID || item.zoneType != ZoneType.Mode || (item.zoneType == ZoneType.Mode && ZoneModeAbility == -1) || item.ModeAbilityIndex == ZoneModeAbility) && IsInFieldOfView(brain, item.ZoneCollider.bounds.center, out var Distance) && Distance < num)
				{
					num = Distance;
					zone = item;
				}
			}
			if ((bool)zone)
			{
				AssignMoveTarget(brain, zone.transform, assign);
				return true;
			}
			return false;
		}

		public bool LookForMalbersTags(MAnimalBrain brain, bool assign, int index)
		{
			if (Tags.TagsHolders == null || tags == null || tags.Length == 0)
			{
				return false;
			}
			float num = float.MaxValue;
			Transform transform = null;
			List<GameObject> list = Tags.GambeObjectbyTag(tags);
			if (list == null)
			{
				return false;
			}
			if (ChooseRandomly)
			{
				while (list.Count != 0)
				{
					int index2 = Random.Range(0, list.Count);
					Transform transform2 = list[index2].transform;
					if (transform2 != null && IsInFieldOfView(brain, transform2.position, out var _))
					{
						AssignMoveTarget(brain, transform2, assign);
						return true;
					}
					list.RemoveAt(index2);
				}
			}
			else
			{
				for (int i = 0; i < list.Count; i++)
				{
					Transform transform3 = list[i].transform;
					if (transform3 != null && IsInFieldOfView(brain, transform3.position, out var Distance2) && Distance2 < num)
					{
						num = Distance2;
						transform = transform3;
					}
				}
			}
			if ((bool)transform)
			{
				AssignMoveTarget(brain, transform.transform, assign);
				return true;
			}
			return false;
		}

		public bool LookForUnityTags(MAnimalBrain brain, bool assign, int index)
		{
			if (string.IsNullOrEmpty(UnityTag))
			{
				return false;
			}
			if (ChooseRandomly)
			{
				return ChooseRandomObject(brain, assign, index);
			}
			return ClosestGameObject(brain, assign, index);
		}

		public bool LookForGoSet(MAnimalBrain brain, bool assign, int index)
		{
			if (gameObjectSet == null || gameObjectSet.Count == 0)
			{
				return false;
			}
			if (ChooseRandomly)
			{
				return ChooseRandomObject(brain, assign, index);
			}
			return ClosestGameObject(brain, assign, index);
		}

		private bool ClosestGameObject(MAnimalBrain brain, bool assign, int index)
		{
			GameObject[] gameobjects = brain.DecisionsVars[index].gameobjects;
			if (gameobjects == null || gameobjects.Length == 0)
			{
				return false;
			}
			float num = float.MaxValue;
			GameObject gameObject = null;
			foreach (GameObject gameObject2 in gameobjects)
			{
				if (!(gameObject2 != null))
				{
					continue;
				}
				Vector3 center = gameObject2.transform.position;
				if (brain.DecisionsVars[index].Components != null && brain.DecisionsVars[index].Components.Length != 0)
				{
					Vector3 zero = Vector3.zero;
					int num2 = 0;
					Component[] components = brain.DecisionsVars[index].Components;
					foreach (Component component in components)
					{
						if (component != null && component is Collider && component.transform.SameHierarchy(gameObject2.transform))
						{
							zero += (component as Collider).bounds.center;
							num2++;
						}
					}
					zero /= (float)num2;
					if (zero != Vector3.zero)
					{
						center = zero;
					}
				}
				if (IsInFieldOfView(brain, center, out var Distance) && Distance < num)
				{
					num = Distance;
					gameObject = gameObject2;
				}
			}
			if ((bool)gameObject)
			{
				AssignMoveTarget(brain, gameObject.transform, assign);
				return true;
			}
			return false;
		}

		public bool ChooseRandomObject(MAnimalBrain brain, bool assign, int index)
		{
			List<GameObject> list = new List<GameObject>();
			if (brain.DecisionsVars[index].gameobjects != null)
			{
				list.AddRange(brain.DecisionsVars[index].gameobjects);
			}
			if (list.Count == 0)
			{
				return false;
			}
			while (list.Count != 0)
			{
				int num = Random.Range(0, list.Count);
				if (list[num] != null)
				{
					Vector3 center = list[num].transform.position + new Vector3(0f, brain.Animal.Height, 0f);
					Component component = brain.DecisionsVars[index].Components[num];
					if (component != null && component is Renderer)
					{
						center = (component as Renderer).bounds.center;
					}
					if (IsInFieldOfView(brain, center, out var _))
					{
						AssignMoveTarget(brain, list[num].transform, assign);
						return true;
					}
				}
				list.RemoveAt(num);
			}
			return false;
		}

		public bool LookForGameObjectByName(MAnimalBrain brain, bool assign)
		{
			if (string.IsNullOrEmpty(GameObjectName))
			{
				return false;
			}
			GameObject gameObject = GameObject.Find(GameObjectName);
			if ((bool)gameObject)
			{
				AssignMoveTarget(brain, gameObject.transform, assign);
				float Distance;
				return IsInFieldOfView(brain, gameObject.transform.position, out Distance);
			}
			return false;
		}

		public bool LookForClosestWaypoint(MAnimalBrain brain, bool assign)
		{
			List<MWayPoint> wayPoints = MWayPoint.WayPoints;
			if (wayPoints == null || wayPoints.Count == 0)
			{
				return false;
			}
			float num = float.MaxValue;
			MWayPoint mWayPoint = null;
			foreach (MWayPoint item in wayPoints)
			{
				Vector3 centerY = item.GetCenterY();
				if (IsInFieldOfView(brain, centerY, out var Distance) && Distance < num)
				{
					num = Distance;
					mWayPoint = item;
				}
			}
			if ((bool)mWayPoint)
			{
				AssignMoveTarget(brain, mWayPoint.transform, assign);
				return true;
			}
			return false;
		}

		private bool LookForAnimalPlayer(MAnimalBrain brain, bool assign)
		{
			if (MAnimal.MainAnimal == null || (int)MAnimal.MainAnimal.ActiveStateID == StateEnum.Death)
			{
				return false;
			}
			if (MAnimal.MainAnimal == brain.Animal)
			{
				Debug.LogError("AI Animal is set as MainAnimal. Fix it!", brain.Animal);
				return false;
			}
			AssignMoveTarget(brain, MAnimal.MainAnimal.transform, assign);
			float Distance;
			return IsInFieldOfView(brain, MAnimal.MainAnimal.Center, out Distance);
		}
	}
}
