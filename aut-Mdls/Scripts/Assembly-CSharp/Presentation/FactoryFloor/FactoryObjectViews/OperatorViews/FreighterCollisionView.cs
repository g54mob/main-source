using System.Collections.Generic;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews.OperatorViews
{
	public class FreighterCollisionView : MonoBehaviour
	{
		private const int MAX_COLLISION_COUNT = 8;

		private static readonly int CollisionPosition = Shader.PropertyToID("_otherPosition");

		private static readonly int TintColor = Shader.PropertyToID("_TintColor");

		[SerializeField]
		private FreighterView _freighterView;

		[SerializeField]
		private List<Renderer> _renderers;

		[SerializeField]
		private Collider _collider;

		[SerializeField]
		private float _checkRadius;

		[SerializeField]
		private LayerMask _layerMask;

		private MaterialPropertyBlock _propertyBlock;

		private Collider _closestCollider;

		private bool _isColliding;

		private bool _collidingWithBuilding;

		private Vector3 _collisionPos;

		private Collider[] _currentCollisions = new Collider[8];

		private void OnEnable()
		{
			_propertyBlock = new MaterialPropertyBlock();
			_freighterView.OnFreighterColorChanged += FreighterColorChanged;
			FreighterColorChanged(_freighterView.Color);
		}

		private void OnDisable()
		{
			SetIsColliding(value: false);
			_freighterView.OnFreighterColorChanged -= FreighterColorChanged;
		}

		private void FreighterColorChanged(Color color)
		{
			_propertyBlock.SetColor(TintColor, color);
			ApplyPropertyBlocks();
		}

		private void CheckIfColliding()
		{
			int num = Physics.OverlapSphereNonAlloc(base.transform.position, _checkRadius, _currentCollisions, _layerMask);
			float num2 = float.MaxValue;
			for (int i = 0; i < num; i++)
			{
				Collider collider = _currentCollisions[i];
				if (!(collider.transform == _collider.transform))
				{
					_collidingWithBuilding = !collider.TryGetComponent<FreighterCollisionView>(out var _);
					Vector3 center = collider.bounds.center;
					center.y = (_collidingWithBuilding ? base.transform.position.y : center.y);
					float num3 = Vector3.Distance(center, base.transform.position);
					if (num3 < num2)
					{
						num2 = num3;
						_closestCollider = collider;
					}
				}
			}
			SetIsColliding(num > 1);
		}

		private void Update()
		{
			CheckIfColliding();
			if (_isColliding)
			{
				_collisionPos = (_collidingWithBuilding ? _closestCollider.ClosestPoint(base.transform.position) : _closestCollider.transform.position);
				_propertyBlock.SetVector(CollisionPosition, _collisionPos);
				ApplyPropertyBlocks();
			}
		}

		private void ApplyPropertyBlocks()
		{
			foreach (Renderer renderer in _renderers)
			{
				renderer.SetPropertyBlock(_propertyBlock);
			}
		}

		private void SetIsColliding(bool value)
		{
			if (_isColliding != value)
			{
				_isColliding = value;
				IsCollidingChanged(_isColliding);
			}
		}

		private void IsCollidingChanged(bool isColliding)
		{
			if (!isColliding)
			{
				_propertyBlock.SetVector(CollisionPosition, Vector3.down * 1000f);
				ApplyPropertyBlocks();
			}
		}
	}
}
