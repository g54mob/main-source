using Events.Generic;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Await Painted Shape", fileName = "AwaitPaintedShape", order = 8)]
	public class AwaitPaintedShapeQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private ColorEvent _shapePaintedEvent;

		[SerializeField]
		private Color _color;

		[SerializeField]
		private int _shapesToBePainted;

		private bool _isSetup;

		private bool _allShapesPainted;

		private int _shapesPaintedCount;

		public override bool IsValid()
		{
			if (!_isSetup)
			{
				_shapePaintedEvent.Register(HandleShapePaintedEvent);
				_isSetup = true;
			}
			return _allShapesPainted;
		}

		private void HandleShapePaintedEvent(Color color)
		{
			if (ColorUtility.ToHtmlStringRGB(color) == ColorUtility.ToHtmlStringRGB(_color))
			{
				_shapesPaintedCount++;
			}
			if (_shapesPaintedCount >= _shapesToBePainted)
			{
				_allShapesPainted = true;
			}
		}

		public override void Reset()
		{
			_isSetup = false;
			_allShapesPainted = false;
			_shapesPaintedCount = 0;
			_shapePaintedEvent?.UnRegister(HandleShapePaintedEvent);
		}
	}
}
