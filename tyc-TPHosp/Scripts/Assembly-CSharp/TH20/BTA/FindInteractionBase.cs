using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20.BTA
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public abstract class FindInteractionBase : CharacterAction
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("Room to search")]
		public SharedRoomRef _room;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Room item to search")]
		public SharedItemRef _roomItem;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Interaction to search for")]
		public string _interactionName;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Whether to search in all plots (warning: returns first plot with valid interaction, not necessarily the closest/best)")]
		public bool _searchAllPlots;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Choose a random interaction")]
		public bool _chooseRandom;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Choose interaction with best score")]
		public bool _chooseBestScore;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Include navigation unreachable interactions")]
		public bool _includeUnreachables;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Ignore flaming items")]
		public bool _excludeIfOnFire;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Evaluate attractiveness at interaction location")]
		public bool _evaluateAttractiveness;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Filter any interactions that aren't available")]
		public InteractionFilterAvailable _filterAvailable = new InteractionFilterAvailable();

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Filter any interactions that aren't functional")]
		public InteractionFilterFunctional _filterFunctional = new InteractionFilterFunctional();

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Filter any interactions that're outside the radius")]
		public InteractionFilterWithinRadius _filterWithinRadius = new InteractionFilterWithinRadius();

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Filter any interactions that have other people interacting")]
		public InteractionFilterExclusive _filterExclusive = new InteractionFilterExclusive();

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Interaction to play")]
		public SharedObjectInteractionRef _interaction;

		private Vector3 _characterPos;

		private NavMesh _navMesh;

		private bool _setup;

		private bool _characterIsKinematic;

		protected ObjectInteraction FindInteraction(string interactionName)
		{
			ObjectInteraction objectInteraction = null;
			_setup = false;
			if (_roomItem.IsValid())
			{
				objectInteraction = (_chooseRandom ? InteractionAlgorithms.GetRandomInteractionByName(interactionName, _roomItem.Get, ValidDelegate) : ((!_chooseBestScore) ? InteractionAlgorithms.GetClosestInteractionByName(interactionName, _roomItem.Get, base.Character.Position, _evaluateAttractiveness, ValidDelegate) : InteractionAlgorithms.GetBestInteractionByName(interactionName, _roomItem.Get, base.Character, _evaluateAttractiveness, ValidDelegate)));
				if (objectInteraction != null)
				{
				}
			}
			else
			{
				Room room = (_room.IsValid() ? _room.Get : base.Character.RoomUsing);
				if (room != null)
				{
					if (!_searchAllPlots)
					{
						objectInteraction = (_chooseRandom ? InteractionAlgorithms.GetRandomInteractionByName(interactionName, room.FloorPlan, ValidDelegate) : ((!_chooseBestScore) ? InteractionAlgorithms.GetClosestInteractionByName(interactionName, room.FloorPlan, base.Character.Position, _evaluateAttractiveness, ValidDelegate) : InteractionAlgorithms.GetBestInteractionByName(interactionName, room.FloorPlan, base.Character, _evaluateAttractiveness, ValidDelegate, _excludeIfOnFire)));
					}
					else
					{
						foreach (HospitalPlot hospitalPlot in room.FloorPlan.WorldState.HospitalPlots)
						{
							if (hospitalPlot != null && hospitalPlot.HospitalMap != null)
							{
								if (hospitalPlot.Bought && hospitalPlot.Built)
								{
									objectInteraction = (_chooseRandom ? InteractionAlgorithms.GetRandomInteractionByName(interactionName, hospitalPlot.HospitalMap.FloorPlan, ValidDelegate) : ((!_chooseBestScore) ? InteractionAlgorithms.GetClosestInteractionByName(interactionName, hospitalPlot.HospitalMap.FloorPlan, base.Character.Position, _evaluateAttractiveness, ValidDelegate) : InteractionAlgorithms.GetBestInteractionByName(interactionName, hospitalPlot.HospitalMap.FloorPlan, base.Character, _evaluateAttractiveness, ValidDelegate)));
								}
								if (objectInteraction != null)
								{
									break;
								}
							}
						}
					}
				}
			}
			if (_evaluateAttractiveness && objectInteraction != null && base.Character.Interaction != null && GetInteractionAttractiveness(objectInteraction) <= GetInteractionAttractiveness(base.Character.Interaction))
			{
				objectInteraction = base.Character.Interaction;
			}
			return objectInteraction;
		}

		private void InitNavInfo()
		{
			if (!_setup)
			{
				_setup = true;
				_navMesh = base.Character.Level.WorldState.NavMesh;
				_characterPos = base.Character.Position;
				_characterIsKinematic = base.Character.NavPath.IsKinematic;
			}
		}

		protected bool ValidDelegate(ObjectInteraction interaction)
		{
			InitNavInfo();
			if (interaction.Valid && _filterAvailable.IsValid(interaction, base.Character) && _filterFunctional.IsValid(interaction, base.Character) && _filterWithinRadius.IsValid(interaction, base.Character) && _filterExclusive.IsValid(interaction, base.Character) && (_includeUnreachables || _characterIsKinematic || InteractionAlgorithms.InteractionReachable(_navMesh, _characterPos, interaction)))
			{
				return true;
			}
			return false;
		}

		private float GetInteractionAttractiveness(ObjectInteraction interaction)
		{
			return base.Character.Level.WorldState.HospitalAttributeMaps[1].GetMapAttribute(interaction.WorldStartPosition);
		}
	}
}
