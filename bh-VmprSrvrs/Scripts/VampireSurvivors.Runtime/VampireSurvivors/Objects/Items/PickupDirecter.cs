using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Items
{
	public class PickupDirecter : NetworkPickup
	{
		[HideInInspector]
		public float _Radius1;

		[HideInInspector]
		public float _Radius2;

		[HideInInspector]
		public float _Radius3;

		[HideInInspector]
		public float _Radius4;

		[HideInInspector]
		public float _Radius5;

		[HideInInspector]
		public float _Radius6;

		[HideInInspector]
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

		private TileSprite _stars1;

		private TileSprite _stars2;

		private bool _isBehind;

		private PhaserSprite _LeftHand;

		private PhaserSprite _RightHand;

		private float _angleUnit;

		private SpriteMask _spriteMask;

		private List<MultiTargetTween> _allTweens;

		private bool _locallyDisableGet;

		protected override bool UsesOrderedCommand => false;

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

		public override void Despawn()
		{
		}

		private void OnForceClosedUi()
		{
		}
	}
}
