using System.Collections.Generic;
using Factory.FieldData;
using UnityEngine;

namespace Factory.Mech
{
	public class InkCatcher : MechBase
	{
		private bool _isAnimation;

		private eLuggage animeInk;

		private bool InkCatcher_FilterSetting;

		private List<ILiquidCarrier> toPipeStrs;

		private InkSprinkler fromSprinkler;

		private Dictionary<Vector2Int, InkSprinkler> sprinklerDB;

		private int lastCatchFrame;

		private GameObject _effectObject;

		private ParticleSystem _particleSystem;

		public MiniLiquidCarrier InkTank => null;

		public override bool HasLuggageFilter => false;

		public override bool IsLiquidFilter => false;

		public override bool IsSerialize => false;

		public override eLuggage GetLiquidId => default(eLuggage);

		public override double GetLiquidMeasure => 0.0;

		public override double GetLiquidCapacity => 0.0;

		public InkCatcher(Structure[] structures)
			: base(null)
		{
		}

		public override string ToString()
		{
			return null;
		}

		private void UpdateFromSprinkler()
		{
		}

		public static InkSprinkler GetNearestSprinkler(FactoryMap factoryMap, Vector2Int centerAddr)
		{
			return null;
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

		public override void Update(double deltaTime)
		{
		}

		private void PlayAnimation(bool play, eLuggage? ink = null, bool force = false)
		{
		}

		private void VanishEffect()
		{
		}

		public override void Vanish()
		{
		}

		public override List<eLuggage> GetFilterLuggageList()
		{
			return null;
		}

		public override void SetIntArray(int[] array)
		{
		}

		public override int[] GetIntArray()
		{
			return null;
		}

		public bool CheckPairOrNot(eLuggage sprinklerInk, InkSprinkler inkSprinkler)
		{
			return false;
		}

		public void SendFeedResult(eCarrierResultFlag result)
		{
		}

		public override string ToDump()
		{
			return null;
		}
	}
}
