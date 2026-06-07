using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Pathfinding;
using Shapes;
using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(CollisionDetector))]
	[PersistenceOptIn]
	public class AccessPoint : AttachedBehaviour, IPersistable
	{
		public enum AccessType
		{
			Patron = 0,
			Staff = 1
		}

		public static HashSet<AccessPoint> AllAccessPoints;

		public AccessPoint MasterAccessPoint;

		[Header("Config")]
		public AccessType accessType;

		public bool isMandatory;

		public List<string> allowedActivities;

		public bool RequiresSitting;

		public bool CarryWithLeftHandOnApproach;

		public float MaxCharacterRotation;

		private List<GameObject> _helperVisuals;

		private List<Renderer> _helperVisualIconRenderers;

		private List<Rectangle> _helperVisualRectangles;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		[PersistenceAllowBrokenReferenceOnLoad]
		internal List<Actor> Queue;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private Actor _reservedFor;

		public Material patronMaterial;

		public Material staffMaterial;

		[Tooltip("If set to true, the access point will not dynamically change the material at runtime")]
		public bool hasCustomMaterial;

		public GameObject Model;

		private CollisionDetector _collisionDetector;

		public List<AccessPoint> servingStaffAccessPoints;

		private bool _isObstructed;

		private static string[] _allAPPrefabNamesForIcons;

		public string PrefabNameForIcon;

		private float _maxAlphaValue;

		private float _currentAlphaValue;

		private readonly Color _obstructedMaterialBackerColor;

		private readonly Color _obstructedMaterialBorderColor;

		private readonly Color _obstructedMaterialBorderOccludedColor;

		private readonly Color _obstructedMaterialIconColor;

		private readonly Color _activeBuildableUnobstructedBackerColor;

		private readonly Color _activeBuildableUnobstructedBorderColor;

		private readonly Color _activeBuildableUnobstructedBorderOccludedColor;

		private readonly Color _activeBuildableUnobstructedIconColor;

		private readonly Color _unobstructedMaterialBackerColor;

		private readonly Color _unobstructedMaterialBorderColor;

		private readonly Color _unobstructedMaterialBorderOccludedColor;

		private readonly Color _unobstructedMaterialIconColor;

		private static readonly NNConstraint NnConstraint;

		private Vector3 _lastObstructionCheckPosition;

		private NNInfo _lastNearestInfo;

		private bool _lastNavMeshCheckResult;

		public static bool IsVisualChangeSuspended;

		private bool _showModel;

		private List<EntityObject> _designObjects;

		public int maxConcurrentUsers;

		public double LastTranslationChange => 0.0;

		public List<Actor> ResolvedQueue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Actor ReservedFor => null;

		public bool IsObstructed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsModelVisible => false;

		public event EventHandler ObstructionChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void AddActorToQueue(Actor actor)
		{
		}

		public void AddActorToFrontOfQueue(Actor actor)
		{
		}

		public void RemoveActorFromQueue(Actor actor)
		{
		}

		public bool IsActorInQueue(Actor actor)
		{
			return false;
		}

		public IEnumerable<Actor> GetActorsInQueue()
		{
			return null;
		}

		public int GetQueueCount()
		{
			return 0;
		}

		public bool IsQueueEmpty()
		{
			return false;
		}

		public int IndexOfActorInQueue(Actor actor)
		{
			return 0;
		}

		internal void ReserveFor(Actor actor)
		{
		}

		internal void Unreserve()
		{
		}

		public Actor GetActorInQueue(int index)
		{
			return null;
		}

		public static string[] GetAllAPPrefabNamesForIcons()
		{
			return null;
		}

		public override void Start()
		{
		}

		private void InitHelperVisuals()
		{
		}

		public void CheckCollisions(bool forceAllCollidersToUpdate = false, bool forceRecheckThisFrame = false, bool silentCheck = false)
		{
		}

		public override void OnDestroy()
		{
		}

		public override void Awake()
		{
		}

		public void SetAlphaValue(float alphaValue)
		{
		}

		private void SetColor(Color backerColor, Color borderColor, Color borderOccluded, Color iconColor)
		{
		}

		private void OnCollisionsChanged(object sender, EventArgs e)
		{
		}

		public void UpdateIsObstructed()
		{
		}

		private void LateUpdate()
		{
		}

		public void UpdateVisuals()
		{
		}

		private void UpdateModelState()
		{
		}

		public void UpdateDesignItemVisibility(bool forceUpdate = false)
		{
		}

		private void SetDesignItemVisibility(bool show)
		{
		}

		private void GetDesignObjectsInAccessPoint(List<EntityObject> entityObjects)
		{
		}

		protected override void UpdateInternal()
		{
		}

		public void ShowHelperVisual(bool show)
		{
		}

		public bool IsFull()
		{
			return false;
		}

		public IEnumerable<Actor> GetActorsStandingInQueue()
		{
			return null;
		}

		public void MoveForwardInQueueIfOthersHaveNotArrived(Actor actor)
		{
		}

		public bool IsReadyToUse(Actor actor)
		{
			return false;
		}
	}
}
