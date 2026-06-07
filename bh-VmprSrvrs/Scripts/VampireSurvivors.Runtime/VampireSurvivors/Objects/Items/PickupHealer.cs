using System;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items
{
	public class PickupHealer : Pickup
	{
		public float _Radius1;

		public float _Radius2;

		public float _Radius3;

		public float _Radius4;

		public float _Radius5;

		public float _Radius6;

		public float _Radius7;

		private float _myAngle1;

		private float _myAngle2;

		private float _myAngle3;

		private float _myAngle4;

		private float _myAngle5;

		private float _myAngle6;

		private float _myAngle7;

		private PhaserSprite _eye1;

		private PhaserSprite _eye2;

		private PhaserSprite _eye3;

		private PhaserSprite _eye4;

		private PhaserSprite _eye5;

		private PhaserSprite _eye6;

		private PhaserSprite _eye7;

		private const float ANGLE_UNIT = -(float)Math.PI / 180f;

		protected override void Awake()
		{
		}

		public override void SetData(ItemType itemType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void GetTaken()
		{
		}
	}
}
