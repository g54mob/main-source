using System.Collections.Generic;
using Factory.FieldData;
using Models;

namespace Factory.Mech
{
	public class MixColor : MechBase
	{
		public enum State
		{
			Store = 0,
			Mix = 1,
			FeedWait = 2
		}

		private readonly StructureAddr[] _fromAddrs;

		private bool _isAnimation;

		private List<ILiquidCarrier> fromPipeStrs;

		private ILiquidCarrier toPipeStr;

		private bool modeTileAnimation;

		private eLuggage _mixedColor;

		private float _specificRate;

		private int? _tileAnimationFrameCount;

		private int? _tileAnimationSpecificFrame;

		private double _smartParallelCircuitRate;

		private List<MachineInformation.MeasureInfo> measureInfos;

		private const int EntranceCount = 2;

		private State state;

		private eLuggage? receipt;

		private double mixColorEfficiency;

		private double _outputSpeed;

		public override int MinionLayer { get; set; }

		private MiniLiquidCarrier ExitTank => null;

		private MiniLiquidCarrier WorkTank => null;

		public override double OutputSpeedPerSec => 0.0;

		public override double Efficiency => 0.0;

		public override eLuggage Product => default(eLuggage);

		public override bool HasToggleSwitch => false;

		public override List<MachineInformation.MeasureInfo> GetMeasureInfos => null;

		protected override bool isLiquidProduct => false;

		public MixColor(Structure[] structures)
			: base(null)
		{
		}

		private void _UpdateAttachmentData()
		{
		}

		private void _UpdateCircuitData()
		{
		}

		public override void UpdateCircuitData(bool updateAttachment = false)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public override void Update(double deltaTime)
		{
		}

		private eLuggage SearchMixColorBlueprint(eLuggage a, eLuggage b)
		{
			return default(eLuggage);
		}

		private void PlayAnimation(eLuggage color, bool? playAnimation = null, float? specificRate = null, bool force = false, bool ctor = false)
		{
		}

		public override void SwitchToggle()
		{
		}

		public override string ToDump()
		{
			return null;
		}
	}
}
