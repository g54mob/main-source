using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.Shapes;
using Logic.Threading.Events;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.FactoryFloor.Behaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/SorterBehaviour", fileName = "SorterBehaviour", order = 0)]
	public class SorterBehavior : SplitterBehaviorAbstract
	{
		public MainThreadEvent<int> OnSkippedResource = new MainThreadEvent<int>();

		public MainThreadEvent OnResourcesCleared = new MainThreadEvent();

		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		[SerializeField]
		private ShapesDatabase _shapesDatabase;

		private OperatorStateBehaviour _operatorStateBehaviour;

		private bool _currentResourceIsFilter;

		private bool _skipOutput;

		private ResourceDto _filteredResource;

		private ShapeHashPair _filterHash;

		public MainThreadEvent<Resource> OnResourceAdded = new MainThreadEvent<Resource>();

		public MainThreadEvent OnItemPushedAside = new MainThreadEvent();

		public MainThreadEvent<Resource> OnItemAssigned = new MainThreadEvent<Resource>();

		public Resource CurrentResource => GetResourceInInputBuffer();

		public bool IsTryingToSkip => _skipOutput;

		public bool IsFilterSet
		{
			get
			{
				if (_filteredResource != null)
				{
					return _filteredResource.ResourceID != -1;
				}
				return false;
			}
		}

		public ResourceDto Filter => _filteredResource;

		public ShapeHashPair FilterHash => _filterHash;

		public override void Init(FactoryObject factoryObject)
		{
			throw new NotIncludedInDemoException();
		}

		public override void UnInit()
		{
			throw new NotIncludedInDemoException();
		}

		private void OutputResource(Resource resource, int outputIndex)
		{
			_skipOutput = false;
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData)
		{
			throw new NotIncludedInDemoException();
		}

		public void AssignCurrentResource()
		{
			throw new NotIncludedInDemoException();
		}

		public void ResetCurrentResource()
		{
			throw new NotIncludedInDemoException();
		}

		public void SkipCurrentResource()
		{
			throw new NotIncludedInDemoException();
		}

		private bool IsResourceInFilter(Resource resource)
		{
			throw new NotIncludedInDemoException();
		}

		protected override void TryOutputShapeInternal()
		{
			throw new NotIncludedInDemoException();
		}

		public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			throw new NotIncludedInDemoException();
		}

		public override void ClearResources()
		{
			base.ClearResources();
			OnResourcesCleared.Fire();
		}

		public override BehaviourConfigurationDto GetConfiguration()
		{
			throw new NotIncludedInDemoException();
		}

		public override void ApplyConfigurationDto(BehaviourConfigurationDto configDto)
		{
			throw new NotIncludedInDemoException();
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			throw new NotIncludedInDemoException();
		}
	}
}
