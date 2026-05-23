using System;
using System.Collections.Generic;
using Factory.FieldData;
using Libs;
using Models;

namespace Factory.Mech
{
	public class Canvas : MechBase
	{
		public enum CanvasMode
		{
			Mode22 = 0,
			Mode33 = 1,
			ModeError = 2
		}

		private readonly CanvasMode mode;

		private readonly int _needMaterialCount;

		private Structure[] _fromStrs;

		private int outMain;

		private int outSub;

		private MstBlendDataEntities _fixedRecipe;

		private BlendState _blendState;

		private double lastCraftSpeed;

		private double lastProcessSpeed;

		private double blendStartTime;

		private double ParallelCircuit_BuffRate;

		private double ParallelCircuit_AttenuationRate;

		private double _parallelCircuitRate;

		private double BoredomPainter;

		private double Canvas_NonConsumptionRateUp;

		private double AllCanvas_SpeedUp;

		private double AllCanvas_Tier1GenerateSpeedUp;

		private double AllCanvas_SpeedUp_Parts;

		private double Human_AllCanvas_SpeedUp;

		private double Fairy_AllCanvas_SpeedUp;

		private Dictionary<eLuggage, OmakeProduct> additionalProducts;

		private OmakeProduct currentOmakeProduct;

		private Dictionary<eLuggage, int> AllCanvas_AddProduct_BySource;

		private int AllCanvas_AddProduct_Parts;

		private AddProduct currentAddProduct_BySource;

		private AddProduct currentAddProduct_Parts;

		private double _sprinklerUseInkSpeedUp;

		private int AllCanvas_UnifiedSpeed;

		private RingBuffer<eLuggage> _blendLogForBoredomPainter;

		private bool _nanCheckDone;

		private readonly HashSet<ArrivePair> arrivePairSet;

		private double attachmentRate;

		private double craftRateByPlayUnlockInfo;

		public override eLuggage Product => default(eLuggage);

		public override double outputPortUtilizationAverageMain => 0.0;

		public override double outputPortUtilizationAverageSub => 0.0;

		public override bool HasToggleSwitch => false;

		public override bool HasMultiOutputProduct => false;

		public Canvas(Structure[] structures)
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

		private static bool ChoosingLiquid(MiniLiquidCarrier luggageCarrier, eLuggage[] targetIds)
		{
			return false;
		}

		private double UpdateParallelCircuitCanvas()
		{
			return 0.0;
		}

		private bool IsReady(out IBlendMaterial[] blendMaterials)
		{
			blendMaterials = null;
			return false;
		}

		public override void SwitchToggle()
		{
		}

		public bool CheckArriveLuggage(eLuggage luggageID)
		{
			return false;
		}

		public override MiniLuggageCarrier GetTargetStock(StructureAddr toAddr)
		{
			return null;
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
