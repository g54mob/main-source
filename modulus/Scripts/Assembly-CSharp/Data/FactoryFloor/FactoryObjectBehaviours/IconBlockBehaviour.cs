using System.Collections.Generic;
using Data.FactoryFloor.Behaviours;
using Logic.Threading.Events;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.FactoryFloor.FactoryObjectBehaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/IconBlock", fileName = "IconBlockBehaviour", order = 0)]
	public class IconBlockBehaviour : FactoryObjectBehaviour
	{
		public MainThreadEvent<IconBlockBehaviourConfigurationDto> OnConfigurationChanged = new MainThreadEvent<IconBlockBehaviourConfigurationDto>();

		[SerializeField]
		private Sprite[] _displayIcons;

		private OperatorStateBehaviour _operatorStateBehaviour;

		private IconBlockBehaviourConfigurationDto _configuration;

		public IReadOnlyList<Sprite> DisplayIcons => _displayIcons;

		public IconBlockBehaviourConfigurationDto Configuration => _configuration;

		public override void Init(FactoryObject factoryObject)
		{
			throw new NotIncludedInDemoException();
		}

		public void NotifyConfigurationChanged()
		{
			throw new NotIncludedInDemoException();
		}

		public override void Update()
		{
		}

		public override BehaviourConfigurationDto GetConfiguration()
		{
			return _configuration;
		}

		public override void ApplyConfigurationDto(BehaviourConfigurationDto configDto)
		{
			throw new NotIncludedInDemoException();
		}
	}
}
