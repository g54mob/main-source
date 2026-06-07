using Assets.Nimbatus.Scripts.Behaviours.Health;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class SetScaleProportionalToHealth : NimbatusAction
	{
		public bool CustomHealthPool;

		[ShowIf("CustomHealthPool", true)]
		public HealthPool HealthPool;

		public bool CustomTransform;

		[ShowIf("CustomTransform", true)]
		public Transform TargetTransform;

		public bool ScaleX = true;

		public bool ScaleY = true;

		private bool _isInitialized;

		private Vector3 _originalScale;

		private HealthPool _pool;

		private Transform _target;

		public override void Execute()
		{
			if (!_isInitialized)
			{
				_target = (CustomTransform ? TargetTransform : OwnWorldObject.transform);
				_pool = (CustomHealthPool ? HealthPool : OwnWorldObject.HealthPool);
				_originalScale = _target.transform.localScale;
				_isInitialized = true;
			}
			float num = _pool.CurrentHealth / _pool.ActiveMaxHealth;
			if (ScaleX && !ScaleY)
			{
				_target.transform.localScale = new Vector3(_originalScale.x * num, _originalScale.y, _originalScale.z);
			}
			else if (!ScaleX && ScaleY)
			{
				_target.transform.localScale = new Vector3(_originalScale.x, _originalScale.y * num, _originalScale.z);
			}
			else if (ScaleX && ScaleY)
			{
				_target.transform.localScale = new Vector3(_originalScale.x * num, _originalScale.y * num, _originalScale.z);
			}
		}
	}
}
