using System.Collections.Generic;
using System.Linq;
using Data.FactoryFloor.FactoryObjectBehaviours.CustomInputOutputSpeeds;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.SaveData.PersistentSOs;
using Data.Variables.Recipes;
using Logic.Threading.Events;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.FactoryFloor.Behaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/RecipeOperatorBehaviour", fileName = "RecipeOperatorBehaviour", order = 0)]
	public class RecipeOperatorBehaviour : ResourceHolderBehaviour, ICustomInputSpeeds
	{
		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		[SerializeField]
		private List<RecipeData> _recipeDatas;

		[SerializeField]
		private UnlockedRecipesPersistentSO _unlockedRecipesPersistentSO;

		private OperatorStateBehaviour _operatorStateBehaviour;

		private bool _hasRecipeSet;

		private int _recipeIndex;

		private int[] _currentResources;

		private readonly Dictionary<int, List<Resource>> _createdResourcesByOutputIndex = new Dictionary<int, List<Resource>>();

		public MainThreadEvent OnResourceCountUpdated = new MainThreadEvent();

		public MainThreadEvent<ResourceRecipe> OnChangedRecipe = new MainThreadEvent<ResourceRecipe>();

		public MainThreadEvent<Resource, int> OnResourceAdded = new MainThreadEvent<Resource, int>();

		public ResourceRecipe CurrentRecipe => _recipeDatas[_recipeIndex].Recipe;

		public List<ResourceRecipe> UnlockedRecipes => (from recipeData in _recipeDatas
			where _unlockedRecipesPersistentSO.IsRecipeUnlocked(recipeData)
			select recipeData.Recipe).ToList();

		public List<RecipeData> Recipes => _recipeDatas;

		public int[] CurrentResources => _currentResources;

		public bool HasRecipeSet => _hasRecipeSet;

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			_currentResources = new int[0];
			_operatorStateBehaviour = factoryObject.GetFactoryObjectBehaviour<OperatorStateBehaviour>();
			RecipeOperatorBehaviourConfigurationDto behaviourConfigurationDto = factoryObject.GetBehaviourConfigurationDto<RecipeOperatorBehaviourConfigurationDto>();
			ApplyConfigurationDto(behaviourConfigurationDto);
			RecipeOperatorBehaviourSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<RecipeOperatorBehaviourSaveStateDto>();
			if (behaviourSaveStateDto != null)
			{
				ApplySaveState(behaviourSaveStateDto);
			}
			OnOutputResource.RegisterInline(OnOutput);
		}

		public override void UnInit()
		{
			for (int i = 0; i < _currentResources.Length; i++)
			{
				_currentResources[i] = 0;
			}
			_createdResourcesByOutputIndex.Clear();
			OnOutputResource.UnRegisterInline(OnOutput);
			base.UnInit();
		}

		private void OnOutput(Resource resource, int outputIndex)
		{
			_createdResourcesByOutputIndex.ElementAt(outputIndex).Value.RemoveAt(0);
			TryOutputNewResource();
		}

		public override void Update()
		{
			TryCreateNewResource();
			TryOutputNewResource();
		}

		private void TryCreateNewResource()
		{
			if (!_hasRecipeSet)
			{
				EndActivity();
				return;
			}
			bool flag = true;
			for (int i = 0; i < _createdResourcesByOutputIndex.Count; i++)
			{
				if (_createdResourcesByOutputIndex[i].Count != 0)
				{
					flag = false;
					break;
				}
			}
			if (!flag)
			{
				EndActivity();
				return;
			}
			for (int j = 0; j < CurrentRecipe.Inputs.Count; j++)
			{
				KeyValuePair<ResourceDataSO, int> keyValuePair = CurrentRecipe.Inputs.ElementAt(j);
				if (_currentResources[j] < keyValuePair.Value)
				{
					EndActivity();
					return;
				}
			}
			ResetRecipe();
			bool flag2 = false;
			_createdResourcesByOutputIndex.Clear();
			foreach (ResourceRecipe.Output output in CurrentRecipe.Outputs)
			{
				Color colour = ((output.resourceDataSO is PaintResourceDataSO paintResourceDataSO) ? paintResourceDataSO.Color : Color.black);
				for (int k = 0; k < output.OutputAmount; k++)
				{
					if (!_createdResourcesByOutputIndex.TryGetValue(output.OutputBeltIndex, out var value))
					{
						value = new List<Resource>();
						_createdResourcesByOutputIndex[output.OutputBeltIndex] = value;
					}
					value.Add(_resourceFactory.CreateResource(output.resourceDataSO, colour, output.ShapeHash));
					flag2 = true;
				}
			}
			if (flag2)
			{
				StartActivity();
			}
		}

		private void TryOutputNewResource()
		{
			foreach (KeyValuePair<int, List<Resource>> item in _createdResourcesByOutputIndex)
			{
				int key = item.Key;
				if (item.Value.Count != 0 && !IsTryingToOutputAtIndex(key))
				{
					TryOutput(item.Value[0], key);
				}
			}
		}

		private void ResetRecipe()
		{
			_operatorStateBehaviour.ResetState();
			for (int i = 0; i < _currentResources.Length; i++)
			{
				_currentResources[i] = 0;
			}
			CallCanReceiveNewResources();
		}

		public void ChangeRecipe(int recipeIndex)
		{
			_operatorStateBehaviour.ResetState();
			_hasRecipeSet = true;
			_recipeIndex = recipeIndex;
			_currentResources = new int[CurrentRecipe.Inputs.Count];
			OnChangedRecipe.Fire(CurrentRecipe);
			CallCanReceiveNewResources();
		}

		public int GetRecipeIDFromRecipe(ResourceRecipe recipe)
		{
			for (int i = 0; i < _recipeDatas.Count; i++)
			{
				if (_recipeDatas[i].Recipe == recipe)
				{
					return i;
				}
			}
			return -1;
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
			base.AddResource(resource, inputData);
			Resource resource2 = TakeResourceFromInputBuffer(inputData.Index);
			bool flag = true;
			if (resource2.Data is NonShapeResourceDataSO nonShapeResourceDataSO)
			{
				for (int i = 0; i < CurrentRecipe.Inputs.Count; i++)
				{
					KeyValuePair<ResourceDataSO, int> keyValuePair = CurrentRecipe.Inputs.ElementAt(i);
					if (keyValuePair.Key.ID == nonShapeResourceDataSO.ID)
					{
						flag = false;
						if (_currentResources[i] < keyValuePair.Value)
						{
							_currentResources[i]++;
							_operatorStateBehaviour.ResetState();
							OnResourceCountUpdated.Fire();
							OnResourceAdded.Fire(resource2, inputData.Index);
							return;
						}
					}
				}
			}
			if (flag)
			{
				_operatorStateBehaviour.SetStateWrongInputTypeGeneral();
			}
		}

		public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			if (!base.CanReceiveResource(resource, inputData, position))
			{
				return false;
			}
			if (!_hasRecipeSet)
			{
				_operatorStateBehaviour.SetStateNoRecipeSelected();
				return false;
			}
			bool flag = true;
			if (resource.Data is NonShapeResourceDataSO nonShapeResourceDataSO)
			{
				for (int i = 0; i < CurrentRecipe.Inputs.Count; i++)
				{
					KeyValuePair<ResourceDataSO, int> keyValuePair = CurrentRecipe.Inputs.ElementAt(i);
					if (keyValuePair.Key.ID == nonShapeResourceDataSO.ID)
					{
						flag = false;
						if (_currentResources[i] < keyValuePair.Value)
						{
							return true;
						}
					}
				}
			}
			if (flag)
			{
				_operatorStateBehaviour.SetStateWrongInputTypeGeneral();
			}
			return false;
		}

		public override void ClearResources()
		{
			base.ClearResources();
			_createdResourcesByOutputIndex.Clear();
		}

		private void ApplySaveState(RecipeOperatorBehaviourSaveStateDto saveStateDto)
		{
			for (int i = 0; i < _currentResources.Length; i++)
			{
				if (i >= saveStateDto.Resources.Length)
				{
					_currentResources[i] = 0;
				}
				else
				{
					_currentResources[i] = saveStateDto.Resources[i];
				}
			}
			if (saveStateDto.CreatedResourcesByIndex == null)
			{
				return;
			}
			_createdResourcesByOutputIndex.Clear();
			foreach (KeyValuePair<int, List<ResourceDto>> item in saveStateDto.CreatedResourcesByIndex)
			{
				_createdResourcesByOutputIndex.Add(item.Key, new List<Resource>());
				foreach (ResourceDto item2 in item.Value)
				{
					_createdResourcesByOutputIndex[item.Key].Add(item2.ToResource(_resourceFactory, _resourceDatabase));
				}
			}
		}

		public override BehaviourConfigurationDto GetConfiguration()
		{
			return new RecipeOperatorBehaviourConfigurationDto(_hasRecipeSet, _recipeIndex);
		}

		public override void ApplyConfigurationDto(BehaviourConfigurationDto configDto)
		{
			if (configDto is RecipeOperatorBehaviourConfigurationDto recipeOperatorBehaviourConfigurationDto)
			{
				if (recipeOperatorBehaviourConfigurationDto.HasRecipeSet)
				{
					ChangeRecipe(recipeOperatorBehaviourConfigurationDto.RecipeIndex);
				}
				else
				{
					ResetRecipe();
				}
			}
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			Dictionary<int, List<ResourceDto>> dictionary = new Dictionary<int, List<ResourceDto>>();
			foreach (KeyValuePair<int, List<Resource>> item in _createdResourcesByOutputIndex)
			{
				dictionary.Add(item.Key, new List<ResourceDto>());
				foreach (Resource item2 in item.Value)
				{
					dictionary[item.Key].Add(new ResourceDto(item2));
				}
			}
			int[] array = new int[_currentResources.Length];
			for (int i = 0; i < _currentResources.Length; i++)
			{
				array[i] = _currentResources[i];
			}
			return new RecipeOperatorBehaviourSaveStateDto
			{
				Resources = array,
				CreatedResourcesByIndex = dictionary
			};
		}

		public bool IsConfigSet()
		{
			return _hasRecipeSet;
		}

		public int[] GetInputFrequencies()
		{
			int[] array = new int[CurrentRecipe.Inputs.Count];
			for (int i = 0; i < CurrentRecipe.Inputs.Count; i++)
			{
				array[i] = base.UpdateFrequency / CurrentRecipe.Inputs.ElementAt(i).Value;
			}
			return array;
		}
	}
}
