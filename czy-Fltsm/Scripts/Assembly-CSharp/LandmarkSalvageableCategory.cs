using System;
using I2.Loc;
using UnityEngine;

[CreateAssetMenu(fileName = "Landmark Salvageable Category", menuName = "Flotsam/Landmarks/Assets/Landmark Salvageable Category")]
public class LandmarkSalvageableCategory : PersistentProperties
{
	[Serializable]
	public struct Requirement
	{
		public ItemProperties ItemProperties;

		public float Amount;

		public bool IsNullOrEmpty()
		{
			if (!(ItemProperties == null))
			{
				return Amount <= 0f;
			}
			return true;
		}
	}

	[Tooltip("Dictates the order the categories are dislayed in the UI, lower value is higher in the list")]
	[SerializeField]
	private int _uiOrder;

	[SerializeField]
	private LocalizedString _description;

	[SerializeField]
	[Tooltip("The item(s) required for each salvageable that falls into this category")]
	private Requirement _requiredItem;

	[SerializeField]
	[Tooltip("The AssignmentTypes required for each salvageable that falls into this category")]
	private AssignmentType _requiredAssignmentType;

	[SerializeField]
	[Tooltip("Buildable required for each salvageable that falls into this category")]
	private BuildableProperties _requiredBuildable;

	[SerializeField]
	[Tooltip("The item(s) required for each salvageable that falls into this category")]
	private float _salvageItemExperience;

	public int UIOrder => _uiOrder;

	public LocalizedString Description => _description;

	public Requirement RequiredItem => _requiredItem;

	public float SalvageItemExperience => _salvageItemExperience;

	public override Types Type => Types.LandmarkSalvageableCategory;

	public bool ReturnRequiresItem()
	{
		if (_requiredItem.ItemProperties != null)
		{
			return 0f < _requiredItem.Amount;
		}
		return false;
	}

	public bool ReturnRequiresAssignmentType()
	{
		if (_requiredAssignmentType == AssignmentType.None)
		{
			return false;
		}
		foreach (Agent agent in Community.PlayerCommunity.Agents)
		{
			if (agent.ReturnAcceptsAssignmentType(_requiredAssignmentType))
			{
				return false;
			}
		}
		return true;
	}

	public bool ReturnRequiresBuildable()
	{
		if (_requiredBuildable == null)
		{
			return false;
		}
		return !Community.PlayerCommunity.ReturnHasBuildable(_requiredBuildable);
	}
}
