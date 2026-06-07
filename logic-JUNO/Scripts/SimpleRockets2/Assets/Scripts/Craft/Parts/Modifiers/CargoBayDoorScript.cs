using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class CargoBayDoorScript : MonoBehaviour
	{
		private CargoBayScript _cargoBay;

		private Transform _hinge;

		private float _openAmount;

		private Transform _rotationRoot;

		private SubPartRotatorScript _rotator;

		[SerializeField]
		private float _side = 1f;

		private Quaternion _targetRotation;

		public float Side => _side;

		public void Initialize(CargoBayScript cargoBay)
		{
			_cargoBay = cargoBay;
			_rotationRoot = base.transform.parent;
			_hinge = _rotationRoot.parent;
			_targetRotation = Quaternion.identity;
			_rotator = (from x in cargoBay.PartScript.GetModifiers<SubPartRotatorScript>()
				where x.Data.SubPartPath.Contains(base.gameObject.name)
				select x).FirstOrDefault();
			UpdateRotator();
		}

		public void SetOpenAmount(float amount)
		{
			_openAmount = Mathf.Clamp01(amount);
			if (_rotator == null)
			{
				base.transform.parent.localRotation = Quaternion.Lerp(Quaternion.identity, _targetRotation, _openAmount);
			}
			else
			{
				_rotator.SetEnabledPercent(_openAmount);
			}
		}

		public void UpdateRotator()
		{
			if (_rotator != null)
			{
				_rotator.SetSubPart(_rotationRoot);
			}
		}

		public void UpdateHinge(Vector3 rotationAxis, Vector3 localPosition, float angle, bool custom = false)
		{
			if (!custom)
			{
				_targetRotation = Quaternion.AngleAxis(angle, rotationAxis);
				base.transform.SetParent(_hinge.parent, worldPositionStays: false);
				_hinge.localPosition = localPosition;
				base.transform.SetParent(_rotationRoot, worldPositionStays: false);
				base.transform.localPosition = -localPosition;
				if (_rotator != null)
				{
					_rotator.Data.PositionOffset = Vector3.zero;
					_rotator.Data.DisabledRotation = Vector3.zero;
					_rotator.Data.EnabledRotation = _targetRotation.eulerAngles;
					_rotator.SetSubPart(_rotationRoot);
				}
			}
			else
			{
				_rotator.AngleMultiplier = angle;
			}
		}
	}
}
