using System.Collections.Generic;
using System.Collections.Immutable;
using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;

namespace Timberborn.WaterSourceSystem
{
	internal class WaterSourceRegulatorAnimationController : BaseComponent, IAwakableComponent, IStartableComponent, IUpdatableComponent
	{
		private BlockObject _blockObject;

		private WaterSourceRegulator _waterSourceRegulator;

		private WaterSourceRegulatorAnimationControllerSpec _waterSourceRegulatorAnimationControllerSpec;

		private readonly List<RegulatorTransform> _regulatorTransforms = new List<RegulatorTransform>();

		public void Awake()
		{
			_blockObject = GetComponent<BlockObject>();
			_waterSourceRegulator = GetComponent<WaterSourceRegulator>();
			_waterSourceRegulatorAnimationControllerSpec = GetComponent<WaterSourceRegulatorAnimationControllerSpec>();
		}

		public void Start()
		{
			ImmutableArray<RegulatorTransformSpec>.Enumerator enumerator = _waterSourceRegulatorAnimationControllerSpec.RegulatorTransforms.GetEnumerator();
			while (enumerator.MoveNext())
			{
				RegulatorTransformSpec current = enumerator.Current;
				_regulatorTransforms.Add(RegulatorTransform.Create(base.GameObject, current, _waterSourceRegulator.IsOpen));
			}
		}

		public void Update()
		{
			foreach (RegulatorTransform regulatorTransform in _regulatorTransforms)
			{
				if (_blockObject.IsFinished)
				{
					regulatorTransform.UpdateSmoothly(_waterSourceRegulator.IsOpen);
				}
				else
				{
					regulatorTransform.UpdateInstantly(_waterSourceRegulator.IsOpen);
				}
			}
		}
	}
}
