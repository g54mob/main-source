using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Factory.FieldData;
using Libs;
using Models;
using UnityEngine;

namespace Factory.Mech
{
	public class SweetsSupply : MechBase
	{
		public record SweetsAttachment(eLuggage Sweets, double CraftSpeed, int SweetsType)
		{
			[CompilerGenerated]
			protected virtual Type EqualityContract
			{
				[CompilerGenerated]
				get
				{
					return null;
				}
			}

			public double CraftSpeed { get; set; }

			public eLuggage Sweets { get; set; }

			public int SweetsType { get; set; }

			[CompilerGenerated]
			public override string ToString()
			{
				return null;
			}

			[CompilerGenerated]
			protected virtual bool PrintMembers(StringBuilder builder)
			{
				return false;
			}

			[CompilerGenerated]
			public virtual bool Equals(SweetsAttachment? other)
			{
				return false;
			}

			[CompilerGenerated]
			protected SweetsAttachment(SweetsAttachment original)
			{
			}

			[CompilerGenerated]
			public void Deconstruct(out eLuggage Sweets, out double CraftSpeed, out int SweetsType)
			{
				Sweets = default(eLuggage);
				CraftSpeed = default(double);
				SweetsType = default(int);
			}
		}

		public enum State
		{
			Store = 0,
			Consume = 1,
			NoConnect = 2
		}

		private StructureAddr[] toAddrs;

		private int _sweetsSupplyBoostRectLengthForToAddrs;

		private SweetsStorage fromStorage;

		private List<MechBase> toMechList;

		private bool _isAnimation;

		private Dictionary<eLuggage, SweetsAttachment> sweetsAttachments;

		private double SweetsSupplyEfficiency;

		private double SweetsTankMeasure;

		private double SweetsTankCapacity;

		private eLuggage SweetsTankSweets;

		private State state;

		private GameObject _effectObject;

		private ParticleSystem _particleSystem;

		private double boostSpeedAdd { get; set; }

		public override double Efficiency => 0.0;

		public static int GetSweetsSupplyBoostRectLength()
		{
			return 0;
		}

		public SweetsSupply(Structure[] structures)
			: base(null)
		{
		}

		public override string ToString()
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

		private void PlayAnimation(bool play, eLuggage? luggage = null, bool force = false)
		{
		}

		public int CountSweetsEffectedMinion()
		{
			return 0;
		}

		public override void Vanish()
		{
		}

		public override Vector2IntBundle? GetRouteAddrBundle()
		{
			return null;
		}

		public override string ToDump()
		{
			return null;
		}
	}
}
