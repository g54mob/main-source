using System.Collections.Generic;
using Factory.FieldData;
using Libs;
using ScriptableObjects.ScriptableObjectScripts.Tile;

namespace Factory.Mech
{
	public class BridgeConveyer : MechBase
	{
		private Structure inputFromStr;

		private Structure outputToStr;

		public BridgeConveyer(Structure[] structures)
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

		public static Vector2IntBundle? GetVector2IntBundleFromSerializableStructures(List<SerializableStructure> sames, Dir.Rot rot, out int? joint)
		{
			joint = null;
			return null;
		}

		public new static bool IsValidBridge(Vector2IntBundle gridRect, TileDetailPack tileDetailPack)
		{
			return false;
		}

		public new static bool IsValidBridge(StructurePack pack)
		{
			return false;
		}
	}
}
