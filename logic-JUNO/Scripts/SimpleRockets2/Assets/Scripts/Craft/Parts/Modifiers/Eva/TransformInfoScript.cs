using ModApi.Audio;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Eva
{
	public class TransformInfoScript : MonoBehaviour
	{
		[SerializeField]
		private Transform _feetExtendedPos;

		[SerializeField]
		private Transform _headCenter;

		[SerializeField]
		private Transform _jetpackAlternate;

		[SerializeField]
		private Transform _jetpackNormal;

		private Transform _lowerLeftJetPackNozzle;

		private ParticleSystem _lowerLeftParticle;

		private Transform _lowerRightJetPackNozzle;

		private ParticleSystem _lowerRightParticle;

		private AudioSource _sound;

		private Transform _upperLeftJetPackNozzle;

		private ParticleSystem _upperLeftParticle;

		private Transform _upperRightJetPackNozzle;

		private ParticleSystem _upperRightParticle;

		public Transform FeetExtendedPos => _feetExtendedPos;

		public Transform HeadCenter => _headCenter;

		public Transform LowerLeftJetpackNozzle => _lowerLeftJetPackNozzle;

		public Vector3 LowerLeftOriginal => -base.transform.parent.right;

		public Transform LowerRightJetpackNozzle => _lowerRightJetPackNozzle;

		public Vector3 LowerRightOriginal => base.transform.parent.right;

		public Transform UpperLeftJetpackNozzle => _upperLeftJetPackNozzle;

		public Vector3 UpperLeftOriginal => -base.transform.parent.right;

		public Transform UpperRightJetpackNozzle => _upperRightJetPackNozzle;

		public Vector3 UpperRightOriginal => base.transform.parent.right;

		public bool UseAlternateJetpackStyle { get; set; }

		public void InitializeJetpack()
		{
			Transform transform = (UseAlternateJetpackStyle ? _jetpackAlternate : _jetpackNormal);
			if (transform != null)
			{
				transform.gameObject.SetActive(value: true);
				_lowerLeftJetPackNozzle = transform.Find("JetPackNozzleBottomLeft");
				_lowerRightJetPackNozzle = transform.Find("JetPackNozzleBottomRight");
				_upperLeftJetPackNozzle = transform.Find("JetPackNozzleTopLeft");
				_upperRightJetPackNozzle = transform.Find("JetPackNozzleTopRight");
				_lowerLeftParticle = _lowerLeftJetPackNozzle.GetComponentInChildren<ParticleSystem>();
				_lowerRightParticle = _lowerRightJetPackNozzle.GetComponentInChildren<ParticleSystem>();
				_upperLeftParticle = _upperLeftJetPackNozzle.GetComponentInChildren<ParticleSystem>();
				_upperRightParticle = _upperRightJetPackNozzle.GetComponentInChildren<ParticleSystem>();
				if (_sound == null)
				{
					_sound = Game.Instance.AudioPlayer.CreateAudioSource(AudioLibrary.Flight.EvaJetpack, base.gameObject, userInterfaceSound: false);
					_sound.playOnAwake = false;
					_sound.loop = true;
				}
			}
			Transform transform2 = (UseAlternateJetpackStyle ? _jetpackNormal : _jetpackAlternate);
			if ((bool)transform2)
			{
				transform2.gameObject.SetActive(value: false);
			}
		}

		public void SetParticleSystemEnabled(bool enabled)
		{
			if (enabled)
			{
				if (_lowerLeftParticle != null && !_lowerLeftParticle.isPlaying)
				{
					_lowerLeftParticle.Play();
					_lowerRightParticle.Play();
					_upperLeftParticle.Play();
					_upperRightParticle.Play();
					_sound.Play();
				}
			}
			else if (_lowerLeftParticle != null && !_lowerLeftParticle.isStopped)
			{
				_sound.Stop();
				_lowerLeftParticle.Stop();
				_lowerRightParticle.Stop();
				_upperLeftParticle.Stop();
				_upperRightParticle.Stop();
			}
		}

		private void Start()
		{
			InitializeJetpack();
		}
	}
}
