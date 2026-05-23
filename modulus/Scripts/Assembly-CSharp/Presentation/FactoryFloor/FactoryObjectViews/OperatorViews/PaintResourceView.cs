using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews.OperatorViews
{
	public class PaintResourceView : FactoryBehaviorView<ColorResourceBehaviour>
	{
		[SerializeField]
		private SpriteRenderer _spriteRenderer;

		[SerializeField]
		private Renderer _paintRenderer;

		[SerializeField]
		private int _materialIndexToChange = 1;

		public override void SetFactoryObject(FactoryObject factoryObject, bool isGameLoading)
		{
			base.SetFactoryObject(factoryObject, isGameLoading);
			BehaviourOnColorChanged();
			_behaviour.ColorChanged.RegisterMainThread(BehaviourOnColorChanged);
		}

		protected override void ResetFactoryObject()
		{
			if ((bool)_behaviour)
			{
				_behaviour.ColorChanged.UnRegisterMainThread(BehaviourOnColorChanged);
			}
			base.ResetFactoryObject();
		}

		private void BehaviourOnColorChanged()
		{
			_spriteRenderer.color = _behaviour.Color;
			_paintRenderer.materials[_materialIndexToChange].SetColor("_BaseColor", _behaviour.Color);
		}
	}
}
