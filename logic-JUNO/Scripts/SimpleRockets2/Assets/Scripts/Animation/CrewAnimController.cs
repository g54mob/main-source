using System;
using Assets.Scripts.Craft.Parts.Modifiers.Eva;
using DG.Tweening;
using ModApi;
using ModApi.Audio;
using ModApi.Common.Events;
using UnityEngine;

namespace Assets.Scripts.Animation
{
	public class CrewAnimController
	{
		private enum JumpStyleType
		{
			Stationary = 0,
			Running = 1
		}

		public const string EndingJumpName = "EndingJump";

		public const string InMidAirName = "InMidAir";

		private const string BaseControllerFolder = "Craft/Parts/Animations/Controllers/";

		private const string ForwardInputName = "ForwardInput";

		private const string ForwardSideMovementName = "ForwardSideMovementBlend";

		private const string ForwardSpeedName = "ForwardSpeed";

		private const int IdleAnimCount = 6;

		private const string IdleBlendName = "IdleBlend";

		private const string InAirStateName = "InAir";

		private const int LayerIndexBase = 0;

		private const int LayerIndexSwimming = 1;

		private const string LeftFootBecameDownName = "LeftFootBecameDown";

		private const string LeftFootBecameUpName = "LeftFootBecameUp";

		private const string LeftFootDownName = "LeftFootDown";

		private const string PrepareForJumpName = "PrepareForJump";

		private const string RightFootBecameDownName = "RightFootBecameDown";

		private const string RightFootBecameUpName = "RightFootBecameUp";

		private const string RightFootDownName = "RightFootDown";

		private const string SideInputName = "SideInput";

		private const string SideSpeedName = "SideSpeed";

		private const int StepCount = 10;

		private const int StepCountWater = 5;

		private const string TurnInputName = "TurnInput";

		private const string VerticalSpeedName = "VerticalSpeed";

		private Animator _animator;

		private CrewCompartmentScript _crewCompartment;

		private float _forwardInput;

		private float _forwardSpeed;

		private int _hashEndingJump;

		private int _hashForwardSideMovement;

		private int _hashForwardSpeed;

		private int _hashIdleBlend;

		private int _hashInAirState;

		private int _hashInMidAir;

		private int _hashLeftFootBecameDown;

		private int _hashLeftFootBecameUp;

		private int _hashLeftFootDown;

		private int _hashPrepareForJump;

		private int _hashRightFootBecameDown;

		private int _hashRightFootBecameUp;

		private int _hashRightFootDown;

		private int _hashSideSpeed;

		private int _hashTurnInput;

		private int _hashVerticalSpeed;

		private float _idleBlend;

		private bool _inAir;

		private bool _insideAtmosphere;

		private RuntimeAnimatorController _insideAtmosphereController;

		private RuntimeAnimatorController _insideAtmosphereControllerLowGrav;

		private bool _inWater;

		private float? _jumpPrepTimeComplete;

		private float _layerWeight;

		private Transform _leftFoot;

		private bool _leftFootDown;

		private bool _lowGravityAnimation;

		private RuntimeAnimatorController _outsideAtmosphereController;

		private bool _prepareForJump;

		private bool _readyForJump;

		private Transform _rightFoot;

		private bool _rightFootDown;

		private bool _shouldBeSwimming;

		private float _sideInput;

		private float _sideSpeed;

		private AudioClip[] _soundSteps;

		private AudioClip[] _soundStepsWater;

		private AudioSource _soundWalkSource;

		private AudioSource _swimAudio;

		private TransformInfoScript _transformInfo;

		private float _turnInput;

		private float _updateIdleBlendTime;

		private float _verticalSpeed;

		private bool _zeroGeeAnimation;

		public Animator Animator => _animator;

		public CrewCompartmentScript CrewCompartment
		{
			get
			{
				return _crewCompartment;
			}
			set
			{
				if (_crewCompartment != value)
				{
					_crewCompartment = value;
					SelectAnimationController();
				}
			}
		}

		public float ForwardInput
		{
			get
			{
				return _forwardInput;
			}
			set
			{
				_forwardInput = value;
				UpdateForwardSideMovement();
			}
		}

		public float ForwardSpeed
		{
			get
			{
				return _forwardSpeed;
			}
			set
			{
				_forwardSpeed = value;
				AnimatorPropertyChanged(_hashForwardSpeed, value);
				UpdateForwardSideMovement();
			}
		}

		public bool InAir
		{
			get
			{
				return _inAir;
			}
			set
			{
				_inAir = value;
				AnimatorPropertyChanged(_hashInAirState, value);
			}
		}

		public bool InsideAtmosphere
		{
			get
			{
				return _insideAtmosphere;
			}
			set
			{
				_insideAtmosphere = value;
			}
		}

		public bool InWater
		{
			get
			{
				return _inWater;
			}
			set
			{
				_inWater = value;
			}
		}

		public bool LowGravityAnimation
		{
			get
			{
				return _lowGravityAnimation;
			}
			set
			{
				if (_lowGravityAnimation != value)
				{
					_lowGravityAnimation = value;
					SelectAnimationController();
				}
			}
		}

		public bool PreventJump
		{
			get
			{
				if (!Animator.GetBool(_hashEndingJump) && Animator.GetBool(_hashInMidAir) && _leftFootDown)
				{
					return _rightFootDown;
				}
				return false;
			}
		}

		public float SideInput
		{
			get
			{
				return _sideInput;
			}
			set
			{
				_sideInput = value;
				UpdateForwardSideMovement();
			}
		}

		public float SideSpeed
		{
			get
			{
				return _sideSpeed;
			}
			set
			{
				_sideSpeed = value;
				AnimatorPropertyChanged(_hashSideSpeed, value);
				UpdateForwardSideMovement();
			}
		}

		public float Speed { get; set; }

		public float TurnInput
		{
			get
			{
				return _turnInput;
			}
			set
			{
				_turnInput = value;
				AnimatorPropertyChanged(_hashTurnInput, value);
				UpdateForwardSideMovement();
			}
		}

		public float VerticalSpeed
		{
			get
			{
				return _verticalSpeed;
			}
			set
			{
				_verticalSpeed = value;
				AnimatorPropertyChanged(_hashVerticalSpeed, _verticalSpeed);
			}
		}

		public bool ZeroGeeAnimation
		{
			get
			{
				return _zeroGeeAnimation;
			}
			set
			{
				if (_zeroGeeAnimation != value)
				{
					_zeroGeeAnimation = value;
					SelectAnimationController();
				}
			}
		}

		private JumpStyleType JumpStyle
		{
			get
			{
				if (ForwardSpeed > 3f)
				{
					return JumpStyleType.Running;
				}
				return JumpStyleType.Stationary;
			}
		}

		public CrewAnimController(Animator animator, TransformInfoScript transformInfo)
		{
			_animator = animator;
			_transformInfo = transformInfo;
			_updateIdleBlendTime = Time.time + (float)UnityEngine.Random.Range(1, 5);
			_leftFoot = _animator.GetBoneTransform(HumanBodyBones.LeftFoot);
			_rightFoot = _animator.GetBoneTransform(HumanBodyBones.RightFoot);
			_insideAtmosphereController = Game.Instance.ResourceLoader.Load<RuntimeAnimatorController>("Craft/Parts/Animations/Controllers/CrewMember");
			_insideAtmosphereControllerLowGrav = Game.Instance.ResourceLoader.Load<RuntimeAnimatorController>("Craft/Parts/Animations/Controllers/CrewMember_LowGrav");
			_outsideAtmosphereController = Game.Instance.ResourceLoader.Load<RuntimeAnimatorController>("Craft/Parts/Animations/Controllers/CrewMemberSpace");
			if (Game.InFlightScene)
			{
				InitializeAudio(animator);
			}
			UpdatePropertyHashes();
			SelectAnimationController();
		}

		public Func<bool> PrepareForJump()
		{
			if (InAir)
			{
				return () => true;
			}
			_prepareForJump = true;
			AnimatorPropertyChanged(_hashPrepareForJump, value: true);
			_readyForJump = false;
			_jumpPrepTimeComplete = null;
			return () => _readyForJump;
		}

		public void SelectAnimationController()
		{
			RuntimeAnimatorController controller;
			if (_crewCompartment != null && CrewCompartment.Data.VisibleInCompartment)
			{
				controller = Game.Instance.ResourceLoader.Load<RuntimeAnimatorController>(CrewCompartment.CrewLoadedAnimationControllerPath);
			}
			else if (ZeroGeeAnimation)
			{
				controller = _outsideAtmosphereController;
			}
			else
			{
				controller = (LowGravityAnimation ? _insideAtmosphereControllerLowGrav : _insideAtmosphereController);
			}
			if (!(_animator.runtimeAnimatorController != controller))
			{
				return;
			}
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
			{
				if (_animator != null)
				{
					_animator.runtimeAnimatorController = controller;
				}
			});
		}

		public void Update()
		{
			if (!(CrewCompartment == null))
			{
				return;
			}
			if (ForwardInput == 0f)
			{
				AnimatorPropertyChanged(_hashIdleBlend, _idleBlend);
				if (Time.time > _updateIdleBlendTime)
				{
					DOTween.To(() => _idleBlend, delegate(float x)
					{
						_idleBlend = x;
					}, Mathf.RoundToInt(UnityEngine.Random.Range(0, 6)), 3f).SetEase(Ease.InQuad).OnComplete(delegate
					{
						_updateIdleBlendTime = Time.time + UnityEngine.Random.Range(4f, 10f);
					});
				}
			}
			bool leftFootDown = _leftFootDown;
			bool rightFootDown = _rightFootDown;
			_leftFootDown = !InAir && _transformInfo.FeetExtendedPos.InverseTransformPoint(_leftFoot.position).y < 0.15f;
			_rightFootDown = !InAir && _transformInfo.FeetExtendedPos.InverseTransformPoint(_rightFoot.position).y < 0.15f;
			bool flag = false;
			if (leftFootDown != _leftFootDown)
			{
				if (_leftFootDown)
				{
					AnimatorPropertyChanged(_hashLeftFootBecameDown, value: true);
					AnimatorPropertyChanged(_hashLeftFootBecameUp, value: false);
					flag = true;
				}
				else
				{
					AnimatorPropertyChanged(_hashLeftFootBecameUp, value: true);
					AnimatorPropertyChanged(_hashLeftFootBecameDown, value: false);
				}
			}
			else
			{
				AnimatorPropertyChanged(_hashLeftFootBecameUp, value: false);
				AnimatorPropertyChanged(_hashLeftFootBecameDown, value: false);
			}
			bool flag2 = false;
			if (rightFootDown != _rightFootDown)
			{
				if (_rightFootDown)
				{
					AnimatorPropertyChanged(_hashRightFootBecameDown, value: true);
					AnimatorPropertyChanged(_hashRightFootBecameUp, value: false);
					flag2 = true;
				}
				else
				{
					AnimatorPropertyChanged(_hashRightFootBecameUp, value: true);
					AnimatorPropertyChanged(_hashRightFootBecameDown, value: false);
				}
			}
			else
			{
				AnimatorPropertyChanged(_hashRightFootBecameUp, value: false);
				AnimatorPropertyChanged(_hashRightFootBecameDown, value: false);
			}
			AnimatorPropertyChanged(_hashRightFootDown, _rightFootDown);
			AnimatorPropertyChanged(_hashLeftFootDown, _leftFootDown);
			if (Game.InFlightScene)
			{
				UpdateAudio(flag, flag2);
			}
			if (_prepareForJump)
			{
				if (!_jumpPrepTimeComplete.HasValue)
				{
					switch (JumpStyle)
					{
					case JumpStyleType.Running:
						if (flag2 || flag)
						{
							_jumpPrepTimeComplete = Time.time + 0.2f;
						}
						break;
					case JumpStyleType.Stationary:
						_jumpPrepTimeComplete = Time.time + 0.6f;
						break;
					default:
						Debug.LogError($"Unsupported jump style: {JumpStyle}");
						break;
					}
				}
				else if (Time.time > _jumpPrepTimeComplete)
				{
					_readyForJump = true;
					_jumpPrepTimeComplete = null;
					_prepareForJump = false;
					AnimatorPropertyChanged(_hashPrepareForJump, value: false);
				}
			}
			UpdateSwimming();
		}

		private void AnimatorPropertyChanged(int propertyHash, float value)
		{
			if (!ZeroGeeAnimation)
			{
				_animator.SetFloat(propertyHash, value);
			}
		}

		private void AnimatorPropertyChanged(int propertyHash, bool value)
		{
			if (!ZeroGeeAnimation)
			{
				_animator.SetBool(propertyHash, value);
			}
		}

		private void InitializeAudio(Animator animator)
		{
			_soundSteps = new AudioClip[10]
			{
				Game.Instance.ResourceLoader.LoadAudio("Audio/Sounds/Walking/Step1"),
				Game.Instance.ResourceLoader.LoadAudio("Audio/Sounds/Walking/Step2"),
				Game.Instance.ResourceLoader.LoadAudio("Audio/Sounds/Walking/Step3"),
				Game.Instance.ResourceLoader.LoadAudio("Audio/Sounds/Walking/Step4"),
				Game.Instance.ResourceLoader.LoadAudio("Audio/Sounds/Walking/Step5"),
				Game.Instance.ResourceLoader.LoadAudio("Audio/Sounds/Walking/Step6"),
				Game.Instance.ResourceLoader.LoadAudio("Audio/Sounds/Walking/Step7"),
				Game.Instance.ResourceLoader.LoadAudio("Audio/Sounds/Walking/Step8"),
				Game.Instance.ResourceLoader.LoadAudio("Audio/Sounds/Walking/Step9"),
				Game.Instance.ResourceLoader.LoadAudio("Audio/Sounds/Walking/Step10")
			};
			_soundStepsWater = new AudioClip[5]
			{
				Game.Instance.ResourceLoader.LoadAudio("Audio/Sounds/Walking/SPLASH_Small_01_mono"),
				Game.Instance.ResourceLoader.LoadAudio("Audio/Sounds/Walking/SPLASH_Small_02_mono"),
				Game.Instance.ResourceLoader.LoadAudio("Audio/Sounds/Walking/SPLASH_Small_04_mono"),
				Game.Instance.ResourceLoader.LoadAudio("Audio/Sounds/Walking/SPLASH_Small_05_mono"),
				Game.Instance.ResourceLoader.LoadAudio("Audio/Sounds/Walking/SPLASH_Subtle_mono")
			};
			_swimAudio = Game.Instance.AudioPlayer.CreateAudioSource(AudioLibrary.Flight.Swimming, Animator.gameObject, userInterfaceSound: false);
			_swimAudio.loop = true;
			_swimAudio.PlayDelayed(Time.deltaTime);
			_swimAudio.enabled = false;
			_soundWalkSource = animator.gameObject.AddComponent<AudioSource>();
			_soundWalkSource.spatialBlend = 1f;
			_soundWalkSource.minDistance = 2f;
			_soundWalkSource.maxDistance = 20f;
			_soundWalkSource.outputAudioMixerGroup = Game.Instance.AudioPlayer.GetGameMixerGroup();
			_soundWalkSource.loop = false;
		}

		private void UpdateAudio(bool leftFootBecameDown, bool rightFootBecameDown)
		{
			if (rightFootBecameDown || leftFootBecameDown)
			{
				if (InWater)
				{
					_soundWalkSource.clip = _soundStepsWater[UnityEngine.Random.Range(0, 5)];
				}
				else
				{
					_soundWalkSource.volume = 1f;
					_soundWalkSource.pitch = 1f;
					_soundWalkSource.clip = _soundSteps[UnityEngine.Random.Range(0, 10)];
				}
				_soundWalkSource.Play();
			}
			if (InWater)
			{
				_swimAudio.enabled = true;
				_swimAudio.volume = Mathf.Clamp01(Speed * 1.5f);
				_swimAudio.pitch = Mathf.Clamp(Speed * 0.25f, 1f, 3f);
			}
			else
			{
				_swimAudio.enabled = false;
			}
		}

		private void UpdateForwardSideMovement()
		{
			float value = 0f;
			float num = Mathf.Abs(ForwardInput);
			float num2 = Mathf.Abs(SideInput);
			if (num == 0f && num2 == 0f)
			{
				value = 0f;
			}
			else if (num != 0f && num2 != 0f)
			{
				value = ((!(num > num2)) ? (1f - 0.5f / (num2 / num)) : (0.5f / (num / num2)));
			}
			else if (num == 0f)
			{
				value = 1f;
			}
			else if (num2 == 0f)
			{
				value = 0f;
			}
			AnimatorPropertyChanged(_hashForwardSideMovement, value);
		}

		private void UpdatePropertyHashes()
		{
			_hashForwardSideMovement = Animator.StringToHash("ForwardSideMovementBlend");
			_hashForwardSpeed = Animator.StringToHash("ForwardSpeed");
			_hashIdleBlend = Animator.StringToHash("IdleBlend");
			_hashInAirState = Animator.StringToHash("InAir");
			_hashLeftFootBecameDown = Animator.StringToHash("LeftFootBecameDown");
			_hashLeftFootBecameUp = Animator.StringToHash("LeftFootBecameUp");
			_hashLeftFootDown = Animator.StringToHash("LeftFootDown");
			_hashPrepareForJump = Animator.StringToHash("PrepareForJump");
			_hashRightFootBecameDown = Animator.StringToHash("RightFootBecameDown");
			_hashRightFootBecameUp = Animator.StringToHash("RightFootBecameUp");
			_hashRightFootDown = Animator.StringToHash("RightFootDown");
			_hashSideSpeed = Animator.StringToHash("SideSpeed");
			_hashTurnInput = Animator.StringToHash("TurnInput");
			_hashVerticalSpeed = Animator.StringToHash("VerticalSpeed");
			_hashInMidAir = Animator.StringToHash("InMidAir");
			_hashEndingJump = Animator.StringToHash("EndingJump");
		}

		private void UpdateSwimming()
		{
			int num = ((InWater && InAir) ? 1 : 0);
			float num2 = Mathf.Lerp(_layerWeight, num, Time.deltaTime * 5f);
			if (Utilities.CompareFloats(num2, 0f, 0.01f))
			{
				num2 = 0f;
			}
			if (Utilities.CompareFloats(num2, 1f, 0.01f))
			{
				num2 = 1f;
			}
			if (num2 != _layerWeight)
			{
				_layerWeight = num2;
				_animator.SetLayerWeight(0, 1f - _layerWeight);
				_animator.SetLayerWeight(1, _layerWeight);
			}
		}
	}
}
