using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Factory.FieldData;
using Models;

namespace Factory.Mech
{
	public class Engine : MechBase
	{
		public record InkColorAttachment(eLuggage Color, eAttachment TriggerAttachment, eAttachment TriggerAttachment2, double CraftSpeed, eEngineAdditionalEffect AddEffect)
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

			public eEngineAdditionalEffect AddEffect { get; set; }

			public eLuggage Color { get; set; }

			public eAttachment TriggerAttachment { get; set; }

			public eAttachment TriggerAttachment2 { get; set; }

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
			public virtual bool Equals(InkColorAttachment? other)
			{
				return false;
			}

			[CompilerGenerated]
			protected InkColorAttachment(InkColorAttachment original)
			{
			}

			[CompilerGenerated]
			public void Deconstruct(out eLuggage Color, out eAttachment TriggerAttachment, out eAttachment TriggerAttachment2, out double CraftSpeed, out eEngineAdditionalEffect AddEffect)
			{
				Color = default(eLuggage);
				TriggerAttachment = default(eAttachment);
				TriggerAttachment2 = default(eAttachment);
				CraftSpeed = default(double);
				AddEffect = default(eEngineAdditionalEffect);
			}
		}

		public enum State
		{
			Store = 0,
			Consume = 1,
			NoConnect = 2
		}

		private const double SINGLE_INK_BASE_POWER = 0.10000000149011612;

		private const double MIX_INK_BASE_POWER = 0.4000000059604645;

		private readonly StructureAddr[] fromAddrs;

		private readonly StructureAddr toAddr;

		private ILiquidCarrier fromPipeStr;

		private MechBase toMech;

		private bool _isAnimation;

		private Dictionary<eLuggage, InkColorAttachment> colorAttachments;

		private double engineEfficiency;

		private State state;

		private MiniLiquidCarrier EntranceTank => null;

		private MiniLiquidCarrier WorkTank => null;

		private double boostSpeedAdd { get; set; }

		public override double Efficiency => 0.0;

		public Engine(Structure[] structures)
			: base(null)
		{
		}

		public override void Vanish()
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

		public override string ToDump()
		{
			return null;
		}
	}
}
