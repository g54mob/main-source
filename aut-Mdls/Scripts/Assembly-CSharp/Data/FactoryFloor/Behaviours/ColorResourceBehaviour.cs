using Data.FactoryFloor.FactoryObjectBehaviours;
using Logic.Threading.Events;
using SaveData.FactoryFloor;
using UnityEngine;

namespace Data.FactoryFloor.Behaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/ColorResourceBehaviour", fileName = "ColorResourceBehaviour", order = 0)]
	public class ColorResourceBehaviour : ResourceBehaviour
	{
		[SerializeField]
		protected Color _color;

		public MainThreadEvent ColorChanged = new MainThreadEvent();

		public Color Color => _color;

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			PaintResourceConfigurationDto behaviourConfigurationDto = factoryObject.GetBehaviourConfigurationDto<PaintResourceConfigurationDto>();
			if (behaviourConfigurationDto != null)
			{
				SetColor(behaviourConfigurationDto.Color);
			}
		}

		public override BehaviourConfigurationDto GetConfiguration()
		{
			return new PaintResourceConfigurationDto(_color);
		}

		public virtual void SetColor(Color color)
		{
			_color = color;
			ColorChanged.Fire();
		}

		public override void Update()
		{
		}
	}
}
