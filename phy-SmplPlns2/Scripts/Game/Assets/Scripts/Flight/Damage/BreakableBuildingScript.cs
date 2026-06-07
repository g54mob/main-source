using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Flight.Damage
{
	public class BreakableBuildingScript : BreakableObjectScript
	{
		[SerializeField]
		private GameObject _destructionParticleSystemPrefab;

		private float _height;

		private Vector3 _originalPosition;

		private Rigidbody _rb;

		public GameObject DestructionParticleSystemPrefab
		{
			get
			{
				return _destructionParticleSystemPrefab;
			}
			set
			{
				_destructionParticleSystemPrefab = value;
			}
		}

		protected override void OnBroken(bool initialValue)
		{
			base.OnBroken(initialValue);
			EnableRigidBody(enable: true);
			float num = Mathf.Max(_height / 10f, 6f);
			TweenerCore<Vector3, Vector3, VectorOptions> t = base.transform.DOLocalMoveY(0f - _height, num).SetEase(Ease.InQuad).OnComplete(delegate
			{
				base.gameObject.SetActive(value: false);
				EnableRigidBody(enable: false);
			});
			if (initialValue)
			{
				t.Complete();
			}
			else if (DestructionParticleSystemPrefab != null)
			{
				GameObject obj = Object.Instantiate(DestructionParticleSystemPrefab);
				obj.transform.SetParent(base.transform.parent, worldPositionStays: false);
				obj.transform.position = base.transform.position;
				Object.Destroy(obj, num + 5f);
			}
		}

		protected override void OnHealed()
		{
			base.OnHealed();
			base.gameObject.SetActive(value: true);
			EnableRigidBody(enable: true);
			float duration = Mathf.Max(_height / 10f, 6f);
			base.transform.DOLocalMoveY(_originalPosition.y, duration).SetEase(Ease.OutQuad).OnComplete(delegate
			{
				EnableRigidBody(enable: false);
			});
		}

		protected override void Start()
		{
			base.Start();
			_originalPosition = base.transform.localPosition;
			_height = Utilities.CalculateRendererBounds(base.gameObject).size.y;
		}

		private void EnableRigidBody(bool enable)
		{
			if (enable)
			{
				if (_rb == null)
				{
					_rb = base.gameObject.AddComponent<Rigidbody>();
					_rb.isKinematic = true;
				}
			}
			else if (_rb != null)
			{
				Object.Destroy(_rb);
				_rb = null;
			}
		}
	}
}
