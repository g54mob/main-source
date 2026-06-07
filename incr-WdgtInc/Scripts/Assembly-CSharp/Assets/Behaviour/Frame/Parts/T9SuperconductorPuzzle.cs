using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T9SuperconductorPuzzle : MonoBehaviour
	{
		[SerializeField]
		private T9SuperconductorTube[] _tubes;

		[SerializeField]
		private FrameButton _button;

		[SerializeField]
		private SecretButton _secretButton;

		[SerializeField]
		private T9SuperconductorRotator _swirl;

		[SerializeField]
		private FrameGizmoShaker _swirlShaker;

		private float _connectedTimer;

		private void Update()
		{
			for (int i = 0; i < _tubes.Length; i++)
			{
				if (!_tubes[i].Done)
				{
					_button.SetActive(active: false);
					_connectedTimer = 0f;
					return;
				}
			}
			_button.SetActive(active: true);
			_connectedTimer += Time.deltaTime;
			if (_connectedTimer > 10f)
			{
				_swirlShaker.ForceActive = true;
				float num = Mathf.Clamp01((_connectedTimer - 10f) / 20f);
				_swirlShaker.SetAmplitude(0.1f + num, 0.1f + num);
				_swirl.Speed = 180f + 720f * num;
			}
			if (_connectedTimer > 30f)
			{
				UISounds.CraftFinished();
				_button.gameObject.SetActive(value: false);
				_secretButton.gameObject.SetActive(value: true);
				_swirlShaker.ForceActive = false;
				_swirlShaker.SetAmplitude(0.1f, 0.1f);
				_swirl.Speed = 180f;
				base.enabled = false;
			}
		}

		public void StartCraft()
		{
			_connectedTimer = 0f;
			_swirlShaker.SetAmplitude(0.1f, 0.1f);
			_swirl.Speed = 180f;
			GetComponentInParent<ActiveWorldFrame>().ActiveFrame.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
			for (int i = 0; i < _tubes.Length; i++)
			{
				_tubes[i].Reset();
			}
		}
	}
}
