using System.Collections.Generic;
using Utils;

namespace Events.FactoryFloor
{
	public class BlueprintViewEventDto
	{
		public BlueprintViewDto Blueprint;

		private readonly bool _canBePlaced;

		public readonly List<bool> _canBePlacedElements;

		public bool CanBePlaced(int elementIndex)
		{
			if (!_canBePlaced)
			{
				return false;
			}
			if (_canBePlacedElements.IsNullOrEmpty())
			{
				return true;
			}
			return _canBePlacedElements[elementIndex];
		}

		public BlueprintViewEventDto(BlueprintViewDto blueprint, bool canBePlaced)
		{
			Blueprint = blueprint;
			_canBePlaced = canBePlaced;
			_canBePlacedElements = null;
		}

		public BlueprintViewEventDto(BlueprintViewDto blueprint, List<bool> canBePlacedElements)
		{
			Blueprint = blueprint;
			_canBePlaced = true;
			_canBePlacedElements = canBePlacedElements;
		}
	}
}
