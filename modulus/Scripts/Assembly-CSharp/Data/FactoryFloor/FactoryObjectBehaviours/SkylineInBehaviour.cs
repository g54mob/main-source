using System;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Logic.Threading.Events;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.FactoryFloor.FactoryObjectBehaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/SkylineInBehaviour", fileName = "SkylineInBehaviour", order = 0)]
	public class SkylineInBehaviour : ResourceHolderBehaviour
	{
		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabase;

		private Resource[] _resources;

		private bool[] _backPlatforms;

		private SkylineOutBehaviour _skylineOutBehaviour;

		private int _skylineLength;

		private Vector3 _direction;

		public MainThreadEvent<int> OnMoveResource = new MainThreadEvent<int>();

		public MainThreadEvent<int> OnMoveBackPlatform = new MainThreadEvent<int>();

		public MainThreadEvent OnRemoveLastResource = new MainThreadEvent();

		public MainThreadEvent OnRemoveLastBackPlatform = new MainThreadEvent();

		public MainThreadEvent<Resource> OnReceiveResource = new MainThreadEvent<Resource>();

		public MainThreadEvent OnClearSkyline = new MainThreadEvent();

		public bool HasSkylineOutBehaviour => _skylineOutBehaviour != null;

		public Resource[] Resources => _resources;

		public int SkylineLength => _skylineLength;

		public Vector3 Direction => _direction;

		public event Action OnSkylineOutFound = delegate
		{
		};

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			factoryObject.OnObjectLinked += GetOutSkyline;
			if (factoryObject.IsLinked)
			{
				GetOutSkyline(factoryObject.HardLinkedObjects[0]);
			}
		}

		public override void UnInit()
		{
			_resources = Array.Empty<Resource>();
			_backPlatforms = Array.Empty<bool>();
			_skylineOutBehaviour = null;
			_factoryObject.OnObjectLinked -= GetOutSkyline;
			base.UnInit();
		}

		private void GetOutSkyline(FactoryObject linkObject)
		{
			linkObject.HardLink(_factoryObject);
			SkylineOutBehaviour factoryObjectBehaviour = linkObject.GetFactoryObjectBehaviour<SkylineOutBehaviour>();
			if (factoryObjectBehaviour.Initialized)
			{
				SetSkylineOut(factoryObjectBehaviour);
			}
		}

		public void SetSkylineOut(SkylineOutBehaviour skylineOutBehaviour)
		{
			_skylineOutBehaviour = skylineOutBehaviour;
			Vector3Int vector3Int = skylineOutBehaviour.Position - _factoryObject.Position;
			_skylineLength = Mathf.RoundToInt(vector3Int.magnitude) - 1;
			_resources = new Resource[_skylineLength];
			_backPlatforms = new bool[_skylineLength];
			for (int i = 0; i < _backPlatforms.Length; i++)
			{
				_backPlatforms[i] = false;
			}
			_direction = new Vector3(vector3Int.x, vector3Int.y, vector3Int.z).normalized;
			SkylineInBehaviourSaveStateDto behaviourSaveStateDto = base.FactoryObject.GetBehaviourSaveStateDto<SkylineInBehaviourSaveStateDto>();
			if (behaviourSaveStateDto != null)
			{
				SetSaveState(behaviourSaveStateDto);
			}
			_factoryObject.OnObjectLinked -= GetOutSkyline;
			this.OnSkylineOutFound();
			skylineOutBehaviour.OnSkylineInFound(_skylineLength);
		}

		public override void Update()
		{
			PassResources();
			PassBackPlatforms();
		}

		private void PassBackPlatforms()
		{
			if (_backPlatforms[^1])
			{
				_backPlatforms[^1] = false;
				OnRemoveLastBackPlatform.Fire();
			}
			for (int num = _backPlatforms.Length - 2; num >= 0; num--)
			{
				if (_backPlatforms[num])
				{
					_backPlatforms[num + 1] = true;
					_backPlatforms[num] = false;
					OnMoveBackPlatform.Fire(num + 1);
				}
			}
		}

		private void PassResources()
		{
			TryPassResourceToOutputSkyline();
			for (int num = _resources.Length - 2; num >= 0; num--)
			{
				if (_resources[num + 1] == null && _resources[num] != null)
				{
					_resources[num + 1] = _resources[num];
					_resources[num] = null;
					OnMoveResource.Fire(num + 1);
					CallCanReceiveNewResources();
				}
			}
		}

		private void TryPassResourceToOutputSkyline()
		{
			if (!_initialized || _resources[^1] == null)
			{
				return;
			}
			lock (_skylineOutBehaviour)
			{
				if (_skylineOutBehaviour.CanReceiveResource(_resources[^1]))
				{
					_skylineOutBehaviour.AddResource(_resources[^1]);
					OnRemoveLastResource.Fire();
					_backPlatforms[0] = true;
					_resources[^1] = null;
					EndActivity();
				}
			}
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData)
		{
			StartActivity();
			_resources[0] = resource;
			OnReceiveResource.Fire(resource);
		}

		public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData, Vector3Int position = default(Vector3Int))
		{
			return _resources[0] == null;
		}

		public override void RemoveResource(Resource resource)
		{
		}

		public override void ClearResources()
		{
			base.ClearResources();
			_resources = new Resource[_skylineLength];
			for (int i = 0; i < _backPlatforms.Length; i++)
			{
				_backPlatforms[i] = false;
			}
			OnClearSkyline.Fire();
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			if (_resources == null)
			{
				return new SkylineInBehaviourSaveStateDto
				{
					Resources = new ResourceDto[0]
				};
			}
			ResourceDto[] array = new ResourceDto[_resources.Length];
			for (int i = 0; i < _resources.Length; i++)
			{
				array[i] = new ResourceDto(_resources[i]);
			}
			return new SkylineInBehaviourSaveStateDto
			{
				Resources = array
			};
		}

		private void SetSaveState(SkylineInBehaviourSaveStateDto saveStateDto)
		{
			for (int i = 0; i < _resources.Length; i++)
			{
				_resources[i] = saveStateDto.Resources[i].ToResource(_resourceFactory, _resourceDatabase);
			}
		}
	}
}
