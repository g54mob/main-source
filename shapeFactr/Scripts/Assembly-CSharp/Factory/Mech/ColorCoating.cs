using System;
using Factory.FieldData;

namespace Factory.Mech
{
	public class ColorCoating : MechBase
	{
		private Structure[] fromStrs;

		private bool ColorCoating_Lv2;

		private bool ColorCoating_Lv3;

		private bool _isAnimation;

		private eLuggage animeInk;

		private int? enchantLevel;

		private int inkIndex;

		private int unitIndex;

		public static readonly int CoatingLevelBasicColor;

		public static readonly int CoatingLevelMixColor;

		public static readonly int CoatingLevelWhite;

		private eLuggage product;

		private Structure LuggageStock => null;

		private Structure fromStrHero => null;

		private MiniLiquidCarrier InkTank => null;

		private Structure fromStrPipe => null;

		public override bool HasToggleSwitch => false;

		public override eLuggage Product => default(eLuggage);

		public ColorCoating(Structure[] structures)
			: base(null)
		{
		}

		private void _UpdateAttachmentData()
		{
		}

		private void _UpdatePortAddrs()
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

		private int SearchColorCoatingBlueprint(eLuggage ink)
		{
			return 0;
		}

		private bool IsReady(out int _inkIndex, out eLuggage _newInk)
		{
			_inkIndex = default(int);
			_newInk = default(eLuggage);
			return false;
		}

		public override void SwitchToggle()
		{
		}

		private void PlayBillboardAnimation(bool play, eLuggage ink, bool force = false)
		{
		}

		public override bool IsPickupable(Structure from, out ILuggageCarrier carrier)
		{
			carrier = null;
			return false;
		}

		public override bool IsInsertable(ILuggageCarrier fromCarrier, Structure to, out ILuggageCarrier toCarrier, out double luggageRate, out bool visible, out bool? cautionIcon, out Action<ILuggageCarrier> successCallback)
		{
			toCarrier = null;
			luggageRate = default(double);
			visible = default(bool);
			cautionIcon = null;
			successCallback = null;
			return false;
		}

		public override string ToDump()
		{
			return null;
		}
	}
}
