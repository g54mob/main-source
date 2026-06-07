using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class DeployableFinScript : MonoBehaviour
	{
		private MissileScript _missile;

		[SerializeField]
		private float _retractAngle;

		private Quaternion _targetRotation;

		private Sequence _tween;

		protected void OnDestroy()
		{
			if (_missile != null)
			{
				_missile.WeaponFired -= OnFired;
			}
		}

		protected void Start()
		{
			ProceduralMissileSubPartScript componentInParent = GetComponentInParent<ProceduralMissileSubPartScript>();
			if (componentInParent != null && componentInParent.LoadContext != CraftLoadContext.Designer && componentInParent?.Missile != null)
			{
				_missile = componentInParent.Missile;
				_missile.WeaponFired += OnFired;
				Quaternion quaternion = Quaternion.AngleAxis(_retractAngle, base.transform.right);
				base.transform.SetParent(componentInParent.transform);
				_targetRotation = base.transform.localRotation;
				base.transform.rotation = quaternion * base.transform.rotation;
			}
		}

		private void AnimateFins(float delay, float targetAngle)
		{
			ProceduralMissileSubPartScript componentInParent = GetComponentInParent<ProceduralMissileSubPartScript>();
			base.transform.SetParent(componentInParent.transform);
			_tween?.Kill();
			_tween = DOTween.Sequence().SetDelay(delay).SetLink(base.gameObject)
				.Append(base.transform.DOLocalRotateQuaternion(_targetRotation, 0.5f));
		}

		private void OnFired(object sender, WeaponFiredEventArgs e)
		{
			AnimateFins(0.5f, 0f);
		}
	}
}
