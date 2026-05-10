using System.Collections.Generic;
using UnityEngine;

namespace SoulGames.EasyGridBuilderPro
{
	public class MultiGridBuildConditionManager : MonoBehaviour
	{
		public delegate void OnBuildConditionCheckBuildableGridObjectDelegate(BuildableGridObjectTypeSO buildableGridObjectTypeSO);

		public delegate void OnBuildConditionCheckBuildableEdgeObjectDelegate(BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSO);

		public delegate void OnBuildConditionCheckBuildableFreeObjectDelegate(BuildableFreeObjectTypeSO buildableFreeObjectTypeSO);

		public delegate void OnBuildConditionCompleteBuildableGridObjectDelegate(BuildableGridObjectTypeSO buildableGridObjectTypeSO);

		public delegate void OnBuildConditionCompleteBuildableEdgeObjectDelegate(BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSO);

		public delegate void OnBuildConditionCompleteBuildableFreeObjectDelegate(BuildableFreeObjectTypeSO buildableFreeObjectTypeSO);

		public static bool BuidConditionResponseBuildableGridObject;

		public static bool BuidConditionResponseBuildableEdgeObject;

		public static bool BuidConditionResponseBuildableFreeObject;

		public static List<BuildableGridObjectTypeSO> BuildableGridObjectTypeSOList;

		public static List<BuildableEdgeObjectTypeSO> BuildableEdgeObjectTypeSOList;

		public static List<BuildableFreeObjectTypeSO> BuildableFreeObjectTypeSOList;

		[Tooltip("Add all the 'Buildable Grid Object Type SO' that has build conditions enabled")]
		[SerializeField]
		private List<BuildableGridObjectTypeSO> _buildableGridObjectTypeSOList;

		[Tooltip("Add all the 'Buildable Edge Object Type SO' that has build conditions enabled")]
		[SerializeField]
		private List<BuildableEdgeObjectTypeSO> _buildableEdgeObjectTypeSOList;

		[Tooltip("Add all the 'Buildable Free Object Type SO' that has build conditions enabled")]
		[SerializeField]
		private List<BuildableFreeObjectTypeSO> _buildableFreeObjectTypeSOList;

		private List<EasyGridBuilderPro> easyGridBuilderProList;

		public static event OnBuildConditionCheckBuildableGridObjectDelegate OnBuildConditionCheckBuildableGridObject;

		public static event OnBuildConditionCheckBuildableEdgeObjectDelegate OnBuildConditionCheckBuildableEdgeObject;

		public static event OnBuildConditionCheckBuildableFreeObjectDelegate OnBuildConditionCheckBuildableFreeObject;

		public static event OnBuildConditionCompleteBuildableGridObjectDelegate OnBuildConditionCompleteBuildableGridObject;

		public static event OnBuildConditionCompleteBuildableEdgeObjectDelegate OnBuildConditionCompleteBuildableEdgeObject;

		public static event OnBuildConditionCompleteBuildableFreeObjectDelegate OnBuildConditionCompleteBuildableFreeObject;

		private void Start()
		{
			BuildableGridObjectTypeSOList = new List<BuildableGridObjectTypeSO>();
			BuildableEdgeObjectTypeSOList = new List<BuildableEdgeObjectTypeSO>();
			BuildableFreeObjectTypeSOList = new List<BuildableFreeObjectTypeSO>();
			easyGridBuilderProList = MultiGridManager.Instance.easyGridBuilderProList;
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.OnBuildConditionCheckCallerBuildableGridObject += OnBuildConditionCheckCallerBuildableGridObject;
				easyGridBuilderPro.OnBuildConditionCompleteCallerBuildableGridObject += OnBuildConditionCompleteCallerBuildableGridObject;
				easyGridBuilderPro.OnBuildConditionCheckCallerBuildableEdgeObject += OnBuildConditionCheckCallerBuildableEdgeObject;
				easyGridBuilderPro.OnBuildConditionCompleteCallerBuildableEdgeObject += OnBuildConditionCompleteCallerBuildableEdgeObject;
				easyGridBuilderPro.OnBuildConditionCheckCallerBuildableFreeObject += OnBuildConditionCheckCallerBuildableFreeObject;
				easyGridBuilderPro.OnBuildConditionCompleteCallerBuildableFreeObject += OnBuildConditionCompleteCallerBuildableFreeObject;
			}
			foreach (BuildableGridObjectTypeSO buildableGridObjectTypeSO in _buildableGridObjectTypeSOList)
			{
				BuildableGridObjectTypeSOList.Add(buildableGridObjectTypeSO);
			}
			foreach (BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSO in _buildableEdgeObjectTypeSOList)
			{
				BuildableEdgeObjectTypeSOList.Add(buildableEdgeObjectTypeSO);
			}
			foreach (BuildableFreeObjectTypeSO buildableFreeObjectTypeSO in _buildableFreeObjectTypeSOList)
			{
				BuildableFreeObjectTypeSOList.Add(buildableFreeObjectTypeSO);
			}
		}

		private void OnDisable()
		{
			foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
			{
				easyGridBuilderPro.OnBuildConditionCheckCallerBuildableGridObject -= OnBuildConditionCheckCallerBuildableGridObject;
				easyGridBuilderPro.OnBuildConditionCompleteCallerBuildableGridObject -= OnBuildConditionCompleteCallerBuildableGridObject;
				easyGridBuilderPro.OnBuildConditionCheckCallerBuildableEdgeObject -= OnBuildConditionCheckCallerBuildableEdgeObject;
				easyGridBuilderPro.OnBuildConditionCompleteCallerBuildableEdgeObject -= OnBuildConditionCompleteCallerBuildableEdgeObject;
				easyGridBuilderPro.OnBuildConditionCheckCallerBuildableFreeObject -= OnBuildConditionCheckCallerBuildableFreeObject;
				easyGridBuilderPro.OnBuildConditionCompleteCallerBuildableFreeObject -= OnBuildConditionCompleteCallerBuildableFreeObject;
			}
		}

		private void OnBuildConditionCheckCallerBuildableGridObject(BuildableGridObjectTypeSO buildableGridObjectTypeSO)
		{
			MultiGridBuildConditionManager.OnBuildConditionCheckBuildableGridObject?.Invoke(buildableGridObjectTypeSO);
		}

		private void OnBuildConditionCompleteCallerBuildableGridObject(BuildableGridObjectTypeSO buildableGridObjectTypeSO)
		{
			MultiGridBuildConditionManager.OnBuildConditionCompleteBuildableGridObject?.Invoke(buildableGridObjectTypeSO);
		}

		private void OnBuildConditionCheckCallerBuildableEdgeObject(BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSO)
		{
			MultiGridBuildConditionManager.OnBuildConditionCheckBuildableEdgeObject?.Invoke(buildableEdgeObjectTypeSO);
		}

		private void OnBuildConditionCompleteCallerBuildableEdgeObject(BuildableEdgeObjectTypeSO buildableEdgeObjectTypeSO)
		{
			MultiGridBuildConditionManager.OnBuildConditionCompleteBuildableEdgeObject?.Invoke(buildableEdgeObjectTypeSO);
		}

		private void OnBuildConditionCheckCallerBuildableFreeObject(BuildableFreeObjectTypeSO buildableFreeObjectTypeSO)
		{
			MultiGridBuildConditionManager.OnBuildConditionCheckBuildableFreeObject?.Invoke(buildableFreeObjectTypeSO);
		}

		private void OnBuildConditionCompleteCallerBuildableFreeObject(BuildableFreeObjectTypeSO buildableFreeObjectTypeSO)
		{
			MultiGridBuildConditionManager.OnBuildConditionCompleteBuildableFreeObject?.Invoke(buildableFreeObjectTypeSO);
		}
	}
}
