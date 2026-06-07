using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class AdjustableJoystickScript : PartModifierScript
	{
		private const float PrefabLength = 0.1f;

		private CapsuleCollider _collider;

		private Vector3 _colliderCenter;

		private float _colliderSize;

		private Transform _cylinder;

		private Dictionary<Transform, Vector3> _headTransforms;

		private Vector3 _shaftBasePosition;

		private Vector3 _shaftBaseScale;

		public AdjustableJoystickData Modifier { get; private set; }

		public void Initialise(AdjustableJoystickData modifier)
		{
			Modifier = modifier;
			_collider = base.transform.Find(modifier.ColliderPath)?.GetComponent<CapsuleCollider>();
			_cylinder = base.transform.Find(modifier.CylinderPath);
			_headTransforms = new Dictionary<Transform, Vector3>();
			string[] headPaths = modifier.HeadPaths;
			foreach (string n in headPaths)
			{
				Transform transform = base.transform.Find(n);
				if (transform != null)
				{
					_headTransforms.Add(transform, transform.localPosition);
				}
			}
			if (_collider != null)
			{
				_colliderCenter = _collider.center;
				_colliderSize = _collider.height;
			}
			if (_cylinder != null)
			{
				_shaftBasePosition = _cylinder.localPosition;
				_shaftBaseScale = _cylinder.localScale;
			}
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				modifier.OnHeightChanged += SetHeight;
			}
			SetHeight(modifier.Height);
		}

		protected virtual void OnDestroy()
		{
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				Modifier.OnHeightChanged -= SetHeight;
			}
		}

		private void SetHeight(float height)
		{
			float num = height - 0.1f;
			if (_collider != null)
			{
				Vector3 colliderCenter = _colliderCenter;
				colliderCenter.y += num * 0.5f;
				_collider.center = colliderCenter;
				_collider.height = _colliderSize + num;
			}
			if (_cylinder != null)
			{
				if (height == 0f)
				{
					_cylinder.gameObject.SetActive(value: false);
				}
				else
				{
					Vector3 shaftBasePosition = _shaftBasePosition;
					shaftBasePosition.y += num * 0.5f;
					_cylinder.localPosition = shaftBasePosition;
					Vector3 shaftBaseScale = _shaftBaseScale;
					shaftBaseScale.y *= height / 0.1f;
					_cylinder.localScale = shaftBaseScale;
					_cylinder.gameObject.SetActive(value: true);
				}
			}
			Vector3 vector = new Vector3(0f, num, 0f);
			foreach (KeyValuePair<Transform, Vector3> headTransform in _headTransforms)
			{
				if (!(headTransform.Key == null))
				{
					headTransform.Key.localPosition = headTransform.Value + vector;
				}
			}
		}
	}
}
