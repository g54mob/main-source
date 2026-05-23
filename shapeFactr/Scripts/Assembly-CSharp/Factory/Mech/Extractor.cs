using Factory.FieldData;
using Libs;
using Models;

namespace Factory.Mech
{
	public class Extractor : MechBase
	{
		private Mine _sourceMine;

		public StructureAddr? SourceMineAddr;

		public StructureAddr? SourceInkAddr;

		private Ink _sourceInk;

		private readonly eSecondaryMachineCategory _mode;

		private readonly Dir.Rot _dir;

		private bool _isPlayingAnime;

		private ILiquidCarrier toPipeStr;

		private double _pseudoUptakeInkOperationCycle;

		private double Drawmotif_SpeedUp;

		private double UptakeInk_SpeedUp;

		private double AllDrawmotif_SpeedUpAdd;

		private double AllMine_SpeedUpAdd;

		private double AllInk_SpeedUpAdd;

		private double rateByProductMine;

		private double rateAddByProductInk;

		private double _outputSpeed;

		private MiniLiquidCarrier ExitTank => null;

		public bool FirstCreateDone
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override double OutputSpeedPerSec => 0.0;

		public override eLuggage Product => default(eLuggage);

		protected override bool isLiquidProduct => false;

		public Extractor(Structure[] structures)
			: base(null)
		{
		}

		private void _UpdateAttachmentData()
		{
		}

		private void _UpdateCircuitData()
		{
		}

		public override void Vanish()
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

		private void PrepareMechView()
		{
		}

		public override void UpdateMechView(bool prepare = true)
		{
		}

		private void PlayBillboardAnimationAndUpdateView(bool play, bool force = false)
		{
		}

		public override string ToDump()
		{
			return null;
		}
	}
}
