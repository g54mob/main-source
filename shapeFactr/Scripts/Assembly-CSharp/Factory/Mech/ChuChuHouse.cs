using System;
using System.Collections.Generic;
using Factory.FieldData;
using Models;

namespace Factory.Mech
{
	public class ChuChuHouse : MechBase
	{
		public enum ChuChuHouseMode
		{
			ModeNormal = 0,
			ModeError = 1
		}

		private readonly ChuChuHouseMode mode;

		private readonly int _needMaterialCount;

		private Structure[] _fromStrs;

		private int outMain;

		private int outSub;

		private MstBlendDataEntities _fixedRecipe;

		private BlendState _blendState;

		private double lastCraftSpeed;

		private double blendStartTime;

		private double AllChuChuHouse_SpeedUp;

		private bool _nanCheckDone;

		private readonly HashSet<ArrivePair> arrivePairSet;

		private double attachmentRate;

		private bool idleAnime;

		public override eLuggage Product => default(eLuggage);

		public override double outputPortUtilizationAverageMain => 0.0;

		public override double outputPortUtilizationAverageSub => 0.0;

		public override bool HasToggleSwitch => false;

		public override bool HasRotateSwitch => false;

		public ChuChuHouse(Structure[] structures)
			: base(null)
		{
		}

		private void _UpdatePortAddrs()
		{
		}

		private void _UpdateCircuitData()
		{
		}

		private void _UpdateAttachmentData()
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

		private void PlayBillboardAnimationAndUpdateMapView(bool play, string partsName = null, bool? loopOnce = null)
		{
		}

		private bool IsReady()
		{
			return false;
		}

		public override void SwitchToggle()
		{
		}

		public override void SwitchRotate(StructureAddr addr)
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
