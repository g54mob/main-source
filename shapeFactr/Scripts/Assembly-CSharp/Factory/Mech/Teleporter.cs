using System.Collections.Generic;
using Factory.FieldData;
using Libs;
using Models;

namespace Factory.Mech
{
	public class Teleporter : MechBase
	{
		private Structure inputFromStr;

		private Structure outputToStr;

		public override bool HasRotateSwitch => false;

		public Teleporter(Structure[] structures)
			: base(null)
		{
		}

		public override string ToString()
		{
			return null;
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

		private void PrepareMechView()
		{
		}

		private void PlayBillboardAnimationAndUpdateView(bool play)
		{
		}

		public override void SwitchRotate(StructureAddr addr)
		{
		}

		public static Vector2IntBundle? GetVector2IntBundleFromSerializableStructures(List<SerializableStructure> sames)
		{
			return null;
		}
	}
}
