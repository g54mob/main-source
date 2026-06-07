using Assets.Scripts.Audio;
using Assets.Scripts.Input.Events;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Mfd
{
	public class MfdButtonScript : MonoBehaviour, IInteractablePartModifier
	{
		private enum AudioClipIndex
		{
			Press = 0,
			Release = 1
		}

		private AudioRandomiser _audio;

		[SerializeField]
		private int _buttonID;

		private bool _isRemoteCraft;

		private MfdScript _mfd;

		private Vector3 _originalPosition;

		private Tween _pushTween;

		public bool InteractionDisabled => false;

		public bool IsOutlined
		{
			get
			{
				return _mfd.OutlinedButton == this;
			}
			set
			{
				_mfd.OutlinedButton = (value ? this : null);
			}
		}

		public MeshRenderer Renderer { get; private set; }

		public PartTooltipPosition GetTooltipPosition()
		{
			return default(PartTooltipPosition);
		}

		public bool HandleInput(IInputEvent e, bool isPartStillTarget)
		{
			if (_isRemoteCraft)
			{
				return false;
			}
			if (e.InputState == InputState.Begin)
			{
				_mfd.OnButtonPressed(_buttonID, pressed: true);
				_pushTween?.Kill(complete: true);
				_pushTween = null;
				_pushTween = base.transform.DOLocalMoveY(_originalPosition.y - 0.0025f, 0.15f);
				_audio.Play(0, randomise: false);
			}
			else if (e.InputState == InputState.End)
			{
				_mfd.OnButtonPressed(_buttonID, pressed: false);
				_pushTween?.Kill(complete: true);
				_pushTween = null;
				_pushTween = base.transform.DOLocalMoveY(_originalPosition.y, 0.15f);
				_audio.Play(1, randomise: false);
			}
			return true;
		}

		public string OnHover()
		{
			return string.Empty;
		}

		protected virtual void Start()
		{
			_mfd = GetComponentInParent<MfdScript>();
			_isRemoteCraft = _mfd.PartScript.Aircraft.RemoteAircraft;
			if (!_isRemoteCraft)
			{
				Renderer = GetComponent<MeshRenderer>();
				base.gameObject.layer = 16;
				_originalPosition = base.transform.localPosition;
				AudioSource source = base.gameObject.AddComponent<AudioSource>();
				AudioStore.SetupAudioSource(source, AudioStore.KnobAudio, null, loop: false);
				_audio = new AudioRandomiser(2, source);
				for (int i = 1; i <= 3; i++)
				{
					_audio.AddFiles($"Sound/Button/Button_ON_IN_{i}", $"Sound/Button/Button_ON_OUT_{i}");
				}
			}
		}
	}
}
