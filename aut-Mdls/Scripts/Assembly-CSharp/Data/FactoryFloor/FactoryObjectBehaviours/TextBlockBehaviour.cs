using Data.FactoryFloor.Behaviours;
using Logic.Threading.Events;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.FactoryFloor.FactoryObjectBehaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/TextBlock", fileName = "TextBlockBehaviour", order = 0)]
	public class TextBlockBehaviour : FactoryObjectBehaviour
	{
		public MainThreadEvent<TextBlockBehaviourConfigurationDto> OnConfigurationChanged = new MainThreadEvent<TextBlockBehaviourConfigurationDto>();

		private OperatorStateBehaviour _operatorStateBehaviour;

		private TextBlockBehaviourConfigurationDto _configuration;

		public TextBlockBehaviourConfigurationDto Configuration => _configuration;

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
			return _configuration.CopyOf();
		}

		public override void ApplyConfigurationDto(BehaviourConfigurationDto configDto)
		{
			throw new NotIncludedInDemoException();
		}
	}
}
