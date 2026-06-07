using UnityEngine;

namespace VampireSurvivors.Objects.Props
{
	public class PropDoor : GameMonoBehaviour
	{
		[SerializeField]
		private ArcadeSprite _sideA;

		[SerializeField]
		private ArcadeSprite _sideB;

		[SerializeField]
		private ArcadeSprite _openingZone;

		[SerializeField]
		private Vector3 _openingScaleA;

		[SerializeField]
		private Vector3 _openingScaleB;

		[SerializeField]
		private Vector2 _originA;

		[SerializeField]
		private Vector2 _originB;

		[SerializeField]
		private float _openingSpeed;

		[SerializeField]
		private float _closingSpeed;

		[SerializeField]
		private SpriteRenderer _sideARenderer;

		[SerializeField]
		private SpriteRenderer _sideBRenderer;

		private Material _sideAMaterial;

		private Material _sideBMaterial;

		private float _proportionClosed;

		private Vector3 _startingScaleA;

		private Vector3 _startingScaleB;

		private bool _anyoneInRange;

		private void Start()
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void AddSide(ArcadeSprite side, Vector2 origin)
		{
		}

		private void RemoveSide(ArcadeSprite side)
		{
		}

		private void AddOpeningZone(ArcadeSprite zone)
		{
		}

		private bool OnPlayerOverlapsZone(CallbackContext context, ArcadeColliderType zone, ArcadeColliderType player)
		{
			return false;
		}

		private void RemoveOpeningZone(ArcadeSprite zone)
		{
		}
	}
}
