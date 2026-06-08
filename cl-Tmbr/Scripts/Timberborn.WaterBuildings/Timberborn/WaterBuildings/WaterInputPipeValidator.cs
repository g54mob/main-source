using System.Collections.Generic;
using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using Timberborn.Common;
using Timberborn.Localization;

namespace Timberborn.WaterBuildings
{
	internal class WaterInputPipeValidator : BaseComponent, IAwakableComponent, IPreviewValidator
	{
		private static readonly string PipeObstructedKey = "Buildings.PipeObstructed";

		private static readonly ReadOnlyHashSet<BaseComponent> EmptyHashSet = new HashSet<BaseComponent>().AsReadOnlyHashSet();

		private readonly ILoc _loc;

		private WaterInputCoordinates _waterInputCoordinates;

		public WaterInputPipeValidator(ILoc loc)
		{
			_loc = loc;
		}

		public void Awake()
		{
			_waterInputCoordinates = GetComponent<WaterInputCoordinates>();
		}

		public bool IsValid(out string warningMessage)
		{
			if (_waterInputCoordinates.Depth == 0)
			{
				warningMessage = _loc.T(PipeObstructedKey);
				return false;
			}
			warningMessage = string.Empty;
			return true;
		}

		public ReadOnlyHashSet<BaseComponent> InvalidatedObjects(out string warningMessage)
		{
			warningMessage = string.Empty;
			return EmptyHashSet;
		}
	}
}
