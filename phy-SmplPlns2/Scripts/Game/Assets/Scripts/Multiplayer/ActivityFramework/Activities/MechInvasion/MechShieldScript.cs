using Assets.Scripts.Input;
using Assets.Scripts.Multiplayer.FlightObjects.Damage;
using Assets.Scripts.Multiplayer.FlightObjects.Damage.Events;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.ActivityFramework.Activities.MechInvasion
{
	public class MechShieldScript : MonoBehaviour
	{
		private Material _material;

		private MechScript _mech;

		private float _opacity;

		private Sequence _tween;

		protected float Opacity
		{
			get
			{
				return _opacity;
			}
			set
			{
				_opacity = value;
				Color color = _material.color;
				color.a = value;
				_material.color = color;
			}
		}

		protected void Start()
		{
			NetworkFlightObjectDamageReceiverScript component = GetComponent<NetworkFlightObjectDamageReceiverScript>();
			component.DamageLevelChanged += OnShieldsDamageLevelChanged;
			component.NotableDamageReceived += OnShieldsNotableDamageReceived;
			component.LocalDamageReceived += OnShieldsLocalDamageReceived;
			_mech = GetComponentInParent<MechScript>();
			MeshRenderer component2 = GetComponent<MeshRenderer>();
			_material = component2.material;
		}

		protected void Update()
		{
			if (DebugInput.GetKeyDown(KeyCode.L))
			{
				Debug.Log("Animate hit");
				AnimateHit();
			}
		}

		private void AnimateHit()
		{
			_tween?.Kill();
			_tween = DOTween.Sequence().Append(DOTween.To(() => Opacity, delegate(float x)
			{
				Opacity = x;
			}, 0.5f, 0.1f).SetEase(Ease.OutCirc)).Append(DOTween.To(() => Opacity, delegate(float x)
			{
				Opacity = x;
			}, 0f, 0.25f).SetEase(Ease.OutCirc));
		}

		private void OnShieldsDamageLevelChanged(object sender, DamageLevelEventArgs e)
		{
			if (e.NewLevel.Level >= 4)
			{
				_mech.Activity.ShowMessageToAllPlayers(_mech.MechName + "'s shields have been disabled", logMessage: true, highlighted: true);
				base.gameObject.SetActive(value: false);
				_mech.DamageReceiver.DamageReceptionEnabled = true;
			}
		}

		private void OnShieldsLocalDamageReceived(object sender, LocalDamageReceivedEventArgs e)
		{
			if (e.PlayerId.HasValue && _mech.Activity.LocalPlayer != null && e.PlayerId == _mech.Activity.LocalPlayer.PlayerId)
			{
				_mech.Activity.RegisterDamageFromLocalPlayer(e.DamageReceived);
			}
		}

		private void OnShieldsNotableDamageReceived(object sender, NotableDamageReceivedEventArgs e)
		{
			AnimateHit();
		}
	}
}
