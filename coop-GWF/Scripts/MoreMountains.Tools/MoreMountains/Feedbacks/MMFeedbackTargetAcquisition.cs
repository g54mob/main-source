using System;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[Serializable]
	public class MMFeedbackTargetAcquisition
	{
		public enum Modes
		{
			None = 0,
			Self = 1,
			AnyChild = 2,
			ChildAtIndex = 3,
			Parent = 4,
			FirstReferenceHolder = 5,
			PreviousReferenceHolder = 6,
			ClosestReferenceHolder = 7,
			NextReferenceHolder = 8,
			LastReferenceHolder = 9
		}

		[Tooltip("the selected mode for target acquisition\nNone : nothing will happen\nSelf : the target will be picked on the MMF Player's game object\nAnyChild : the target will be picked on any of the MMF Player's child objects\nChildAtIndex : the target will be picked on the child at index X of the MMF Player\nParent : the target will be picked on the first parent where a matching target is found\nVarious reference holders : the target will be picked on the specified reference holder in the list (either the first one, previous : first one found before this feedback in the list, closest in any direction from this feedback, the next one found, or the last one in the list)")]
		public Modes Mode;

		[MMFEnumCondition("Mode", new int[] { 3 })]
		public int ChildIndex;

		private static MMF_ReferenceHolder _referenceHolder;

		public static MMF_ReferenceHolder GetReferenceHolder(MMFeedbackTargetAcquisition settings, MMF_Player owner, int currentFeedbackIndex)
		{
			return settings.Mode switch
			{
				Modes.FirstReferenceHolder => owner.GetFeedbackOfType<MMF_ReferenceHolder>(MMF_Player.AccessMethods.First, currentFeedbackIndex), 
				Modes.PreviousReferenceHolder => owner.GetFeedbackOfType<MMF_ReferenceHolder>(MMF_Player.AccessMethods.Previous, currentFeedbackIndex), 
				Modes.ClosestReferenceHolder => owner.GetFeedbackOfType<MMF_ReferenceHolder>(MMF_Player.AccessMethods.Closest, currentFeedbackIndex), 
				Modes.NextReferenceHolder => owner.GetFeedbackOfType<MMF_ReferenceHolder>(MMF_Player.AccessMethods.Next, currentFeedbackIndex), 
				Modes.LastReferenceHolder => owner.GetFeedbackOfType<MMF_ReferenceHolder>(MMF_Player.AccessMethods.Last, currentFeedbackIndex), 
				_ => null, 
			};
		}

		public static GameObject FindAutomatedTargetGameObject(MMFeedbackTargetAcquisition settings, MMF_Player owner, int currentFeedbackIndex)
		{
			if (owner.FeedbacksList[currentFeedbackIndex].ForcedReferenceHolder != null)
			{
				return owner.FeedbacksList[currentFeedbackIndex].ForcedReferenceHolder.GameObjectReference;
			}
			_referenceHolder = GetReferenceHolder(settings, owner, currentFeedbackIndex);
			switch (settings.Mode)
			{
			case Modes.Self:
				return owner.gameObject;
			case Modes.ChildAtIndex:
				return owner.transform.GetChild(settings.ChildIndex).gameObject;
			case Modes.AnyChild:
				return owner.transform.GetChild(0).gameObject;
			case Modes.Parent:
				return owner.transform.parent.gameObject;
			case Modes.FirstReferenceHolder:
			case Modes.PreviousReferenceHolder:
			case Modes.ClosestReferenceHolder:
			case Modes.NextReferenceHolder:
			case Modes.LastReferenceHolder:
				return _referenceHolder?.GameObjectReference;
			default:
				return null;
			}
		}

		public static T FindAutomatedTarget<T>(MMFeedbackTargetAcquisition settings, MMF_Player owner, int currentFeedbackIndex)
		{
			if (owner.FeedbacksList[currentFeedbackIndex].ForcedReferenceHolder != null)
			{
				return owner.FeedbacksList[currentFeedbackIndex].ForcedReferenceHolder.GameObjectReference.GetComponent<T>();
			}
			_referenceHolder = GetReferenceHolder(settings, owner, currentFeedbackIndex);
			switch (settings.Mode)
			{
			case Modes.Self:
				return owner.GetComponent<T>();
			case Modes.ChildAtIndex:
				return owner.transform.GetChild(settings.ChildIndex).gameObject.GetComponent<T>();
			case Modes.AnyChild:
			{
				for (int i = 0; i < owner.transform.childCount; i++)
				{
					if (owner.transform.GetChild(i).GetComponent<T>() != null)
					{
						return owner.transform.GetChild(i).GetComponent<T>();
					}
				}
				return owner.GetComponentInChildren<T>();
			}
			case Modes.Parent:
				return owner.transform.parent.GetComponentInParent<T>();
			case Modes.FirstReferenceHolder:
			case Modes.PreviousReferenceHolder:
			case Modes.ClosestReferenceHolder:
			case Modes.NextReferenceHolder:
			case Modes.LastReferenceHolder:
				if (_referenceHolder == null)
				{
					return default(T);
				}
				return _referenceHolder.GameObjectReference.GetComponent<T>();
			default:
				return default(T);
			}
		}
	}
}
