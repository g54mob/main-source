using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class MissileWingsScript : MonoBehaviour
	{
		private MissileScript _missile;

		private Sequence _tween;

		[SerializeField]
		private Transform _wing1;

		[SerializeField]
		private Transform _wing2;

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
			if (componentInParent != null)
			{
				if (componentInParent.LoadContext == CraftLoadContext.Designer)
				{
					componentInParent.PartScript.PartMaterialScript.SelectedChanged += OnPartSelected;
				}
				else if (componentInParent?.Missile != null)
				{
					_missile = componentInParent.Missile;
					_missile.WeaponFired += OnFired;
					_wing1.transform.SetParent(componentInParent.transform);
					_wing2.transform.SetParent(componentInParent.transform);
				}
			}
		}

		private void AnimateWings(float delay, float targetAngle)
		{
			ProceduralMissileSubPartScript componentInParent = GetComponentInParent<ProceduralMissileSubPartScript>();
			_wing1.transform.SetParent(componentInParent.transform);
			_wing2.transform.SetParent(componentInParent.transform);
			_tween?.Kill();
			_tween = DOTween.Sequence().SetDelay(delay).SetLink(base.gameObject)
				.Append(_wing1.DOLocalRotate(new Vector3(0f, 0f - targetAngle, 0f), 1f))
				.Join(_wing2.DOLocalRotate(new Vector3(0f, targetAngle, 0f), 1f));
		}

		private void OnFired(object sender, WeaponFiredEventArgs e)
		{
			AnimateWings(1f, 90f);
		}

		private void OnPartSelected(object sender, PartMaterialScript.PartMaterialEventArgs e)
		{
		}
	}
}
