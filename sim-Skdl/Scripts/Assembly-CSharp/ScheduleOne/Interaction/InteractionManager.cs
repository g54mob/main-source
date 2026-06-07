using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScheduleOne.Interaction
{
	public class InteractionManager : Singleton<InteractionManager>
	{
		public const float RayRadius = 0.075f;

		public const float MaxInteractionRange = 5f;

		[SerializeField]
		protected LayerMask interaction_SearchMask;

		[SerializeField]
		protected float rightClickRange;

		public EInteractionSearchType interactionSearchType;

		public bool DEBUG;

		[Header("Settings")]
		public InputActionReference InteractInput;

		[Header("Visuals Settings")]
		public Color messageColor_Default;

		public Color iconColor_Default;

		public Color iconColor_Default_Key;

		public Color messageColor_Invalid;

		public Color iconColor_Invalid;

		public Sprite icon_Key;

		public Sprite icon_LeftMouse;

		public Sprite icon_Cross;

		public static float interactCooldown;

		private float timeSinceLastInteractStart;

		private BuildableItem itemBeingDestroyed;

		private float destroyTime;

		private static float timeToDestroy;

		public LayerMask Interaction_SearchMask => default(LayerMask);

		public bool CanDestroy { get; set; }

		public InteractableObject HoveredInteractableObject { get; protected set; }

		public InteractableObject HoveredValidInteractableObject { get; protected set; }

		public InteractableObject InteractedObject { get; protected set; }

		public string InteractKeyStr { get; protected set; }

		protected override void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void LoadInteractKey()
		{
		}

		protected virtual void Update()
		{
		}

		protected virtual void LateUpdate()
		{
		}

		protected virtual void CheckHover()
		{
		}

		public bool IsAnythingBlockingInteraction()
		{
			return false;
		}

		protected virtual void CheckInteraction()
		{
		}

		protected virtual void CheckRightClick()
		{
		}

		protected virtual BuildableItem GetHoveredBuildableItem()
		{
			return null;
		}

		public void SetCanDestroy(bool canDestroy)
		{
		}
	}
}
