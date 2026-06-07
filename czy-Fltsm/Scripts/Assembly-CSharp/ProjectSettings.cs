using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;
using UnityEngine.PajamaLlama;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Flotsam/Settings/Project Settings")]
public class ProjectSettings : ScriptableObject
{
	[Serializable]
	public struct Priority
	{
		[SerializeField]
		private LocalizedString _label;

		[SerializeField]
		[Range(-49f, 49f)]
		private int _score;

		public LocalizedString Label => _label;

		public int Score => _score;
	}

	[Header("Assignments")]
	public List<AssignmentSetting> AssignmentSettings = new List<AssignmentSetting>();

	[SerializeField]
	private DrifterAttributes _drifterAttributes;

	[Header("Priority Weights")]
	[SerializeField]
	[NamedArrayElement(new string[] { "_label" })]
	private List<Priority> _producerProjectPriorities;

	[SerializeField]
	private int _producerProjectDefaultPriority = 2;

	[SerializeField]
	private int _assingmentPriortyWeight = 1000000;

	[SerializeField]
	private int _projectPriorityWeight = 100;

	[SerializeField]
	private int _projectPrimaryAssignmentWeight = 20;

	[SerializeField]
	private int _projectSecondaryAssignmentWeight = 10;

	[Header("General")]
	[Tooltip("Properties of the 'Go to the closest town construction' project.")]
	public ProjectProperties GoToTownProperties;

	[Header("Vital Projects")]
	[Tooltip("Properties of the drink project.")]
	public ProjectProperties GetAndDrinkProperties;

	[Tooltip("Properties of the eat project.")]
	public ProjectProperties GetAndEatProperties;

	[Tooltip("Properties of the rejuvenate project.")]
	public ProjectProperties RejuvenateProperties;

	[Tooltip("Properties of the restore vital project.")]
	public ProjectProperties SleepOnGround;

	[Tooltip("Properties of the visit clinic store project.")]
	public ProjectProperties VisitClinic;

	[Tooltip("Properties of the visit drug store project.")]
	public ProjectProperties VisitDrugStore;

	[Header("Build Projects")]
	[Tooltip("Properties of the haul to buildable project.")]
	public ProjectProperties HaulToBuildableProperties;

	[Tooltip("Properties of the build buildable project.")]
	public ProjectProperties BuildBuildableProperties;

	[Tooltip("Properties of the build buildable project.")]
	public ProjectProperties DeconstructBuildableProperties;

	[Header("Salvage Projects")]
	[Tooltip("Properties of the reclaiming project.")]
	public ProjectProperties ReclaimBoatProperties;

	[Tooltip("Properties of the clear inventory project.")]
	public ProjectProperties ClearInventoryProperties;

	[Tooltip("Properties of the marker boat salvaging project.")]
	[FormerlySerializedAs("SalvageWaypointProperties")]
	public ProjectProperties SalvageMarkerBoatProperties;

	[Tooltip("Properties of the marker swimming salvaging project.")]
	public ProjectProperties SalvageMarkerSwimmingProperties;

	[Tooltip("Properties of the clear salvage inventory project.")]
	public ProjectProperties SalvageInventoryClear;

	[Tooltip("Properties of the fishing salvage inventory project.")]
	public ProjectProperties SalvageFishingProperties;

	[Header("Rescuing Projects")]
	[Tooltip("Properties of the rescued passenger project.")]
	public ProjectProperties RescuedPassengerProperties;

	[Tooltip("Properties of rescue project for landmarks.")]
	public ProjectProperties RescueLandmark;

	public ProjectProperties RescueLandmarkSwiming;

	[Tooltip("Properties of rescue animal project for landmarks with boat.")]
	public ProjectProperties RescueAnimalLandmark;

	[Tooltip("Properties of rescue animal project for landmarks.")]
	public ProjectProperties RescueAnimalLandmarkSwimming;

	[Header("Hauling")]
	[Tooltip("Properties of the import project.")]
	public ProjectProperties ImportProperties;

	[Tooltip("Properties of the import fuel project.")]
	public ProjectProperties ImportFuelProperties;

	[Tooltip("Properties of the export project of cancelled items.")]
	public ProjectProperties CancelledItemsExportProperties;

	[Tooltip("[LEGACY] Properties of the global hauling project")]
	public ProjectProperties GlobalHaulingProperties;

	[Header("Global")]
	[Tooltip("List of global projects that get initialized when a game is started.")]
	public ProjectProperties[] GlobalProjects;

	[Header("Landmark")]
	[Tooltip("Properties of scout project for landmarks.")]
	public ProjectProperties ScoutLandmark;

	[Tooltip("Properties of the investigate project.")]
	public ProjectProperties InvestigatePOIProperties;

	[Tooltip("Properties of the salvage project for POIs.")]
	public ProjectProperties SalvagePOIProperties;

	[Tooltip("Properties of the salvage project for POIs.")]
	public ProjectProperties SalvagePOISwimProperties;

	[Tooltip("Properties of research project for POIs")]
	public ProjectProperties ResearchLandmark;

	[Tooltip("Properties of the project for landmarks that reveals a part of the map.")]
	public ProjectProperties RevealMapProperties;

	[Tooltip("Properties for the go to town project when an agent stops a project while being on a Landmark.")]
	public ProjectProperties GoToTownFromLandmark;

	[Tooltip("Properties for the go to town project when an agent stops a project while being on a Landmark.")]
	public ProjectProperties GoToTownFromLandmarkSwimming;

	[Space]
	[Tooltip("Project properties for researching new technologies.")]
	public ProjectProperties ResearchProject;

	public ProjectProperties ManualEnergyProducingProject;

	[Header("Miscellaneous Projects")]
	[Tooltip("Properties of the mooring project.")]
	public ProjectProperties MooringProperties;

	[Tooltip("Properties of the mooring project.")]
	public ProjectProperties MoveToFreeNodeProperties;

	[Header("Malfunctions")]
	[SerializeField]
	private ProjectMalfunction[] _malfunctions;

	public List<Priority> ProducerProjectPriorities => _producerProjectPriorities;

	public Priority ProducerProjectDefaultPriority => _producerProjectPriorities[_producerProjectDefaultPriority];

	public int AssingmentPriortyWeight => _assingmentPriortyWeight;

	public int ProjectPriorityWeight => _projectPriorityWeight;

	public int ProjectPrimaryAssignmentWeight => _projectPrimaryAssignmentWeight;

	public int ProjectSecondaryAssignmentWeight => _projectSecondaryAssignmentWeight;

	public ProjectMalfunction[] Malfunctions => _malfunctions;

	public AssignmentSetting ReturnAssignmentSetting(AssignmentType assignmentType)
	{
		return AssignmentSettings.Find((AssignmentSetting setting) => setting.Type == assignmentType);
	}

	public static bool TryGetAssignmentSettings(out AssignmentSetting settings, AssignmentType assignmentType)
	{
		try
		{
			ProjectSettings projectSettings = GameSettings.Instance.ProjectSettings;
			for (int i = 0; i < projectSettings.AssignmentSettings.Count; i++)
			{
				settings = projectSettings.AssignmentSettings[i];
				if (settings.Type == assignmentType)
				{
					return true;
				}
			}
			settings = null;
			return false;
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			settings = null;
			return false;
		}
	}
}
