using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI
{
	public class GoldFeverUIManager : MonoBehaviour
	{
		[SerializeField]
		private Image _FillBackground;

		[SerializeField]
		private Image _Panel;

		[SerializeField]
		private Image _ProgressFill;

		[SerializeField]
		private Text _RewardText;

		[SerializeField]
		private Text _TimeLeft;

		[SerializeField]
		private ParticleEmitterManager _Emitter;

		[SerializeField]
		private RectTransform _Title;

		[SerializeField]
		private GoldFeverFlashingLights _Lights;

		[SerializeField]
		private Vector3 _TitleStartPos;

		[SerializeField]
		private Vector3 _TitleEndPos;

		private Sequence _exitSequence1;

		private Sequence _exitSequence2;

		private Vector3 _RewardOriginPos;

		private Vector3 _RewardScale;

		private bool _isActive;

		private SignalBus _signalBus;

		private GoldFeverController _goldFever;

		private ParticleSystem _particles;

		private bool _emitterBuilt;

		public bool IsGoldFeverShowing { get; private set; }

		[Inject]
		private void Construct(SignalBus signalBus, GoldFeverController fever)
		{
		}

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		public void Hide()
		{
		}

		public void Show()
		{
		}

		private void FormatTitle(UISignals.GoldFeverCoinCollectedSignal sig)
		{
		}

		private void DoParticles(UISignals.EmitGoldFeverParticleSignal sig)
		{
		}

		private void BuildEmitter()
		{
		}

		private void IntroTween()
		{
		}

		private void ExitTween()
		{
		}

		private float Approach(float start, float end, float shift)
		{
			return 0f;
		}
	}
}
