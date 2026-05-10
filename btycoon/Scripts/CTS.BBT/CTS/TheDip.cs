using System;
using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Pooling;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class TheDip : MachineBase, IDestructibleFurniture, IInteractiveFurniture, IVisibleBBTObject, IBBTObject, IObject, IVisible, IBodyDisposalMachine, IManageableFurniture
	{
		[SerializeField]
		private float _dissolveTime;

		[SerializeField]
		private float _refillTime;

		[SerializeField]
		private int _costOfUsingThis;

		[BoxGroup("Drop Settings")]
		public Vector3 droppingPointsCoords;

		private TheDipAnimation _dipAnimation;

		private float _timerUI;

		private float _timerNormalizedValue;

		private static readonly Resource<BodyBag> _bodyBagPrefab = new Resource<BodyBag>("Prefabs/Pfb_BodyBag");

		private DeadBodyData? _deadBody;

		private bool _isInUse;

		private bool _alreadyPut;

		private AudioSource _audioSource;

		[field: Inject(false)]
		public BodyDisposalCredibility Credibility { get; }

		public MachineUpgrade Upgrade => base.MachineUpgrade;

		public bool IsSomebodyIn => _isInUse;

		public static event Action Dissolved;

		public static event Action Refilled;

		protected override void OnAwake()
		{
			base.OnAwake();
			_dipAnimation = GetComponent<TheDipAnimation>();
			if (base.Furniture.Purchased)
			{
				if (_isInUse)
				{
					_dipAnimation.OpenOrCloseMorgue(value: false);
					_dipAnimation.ResetTriggerClose();
				}
				else
				{
					_dipAnimation.OpenOrCloseMorgue(value: true);
				}
				_alreadyPut = base.Furniture.Purchased;
			}
			base.MachineUI.SetupMachineUI(MachineUI.EMachineUIType.ProgressDefine, MachineUI.EMachineClockwiseType.Clockwise, base.MachineUI.ProgressSprite, base.MachineUI._blueColor);
		}

		public override void OnFurniturePlaced()
		{
			_alreadyPut = true;
			base.OnFurniturePlaced();
			if (_isInUse)
			{
				_audioSource = PlayASound(SFXMachineList.SoundsList[2]);
				if (MonoSingleton<TimeController>.Instance.TimeMode == ETimeModes.Pause)
				{
					_audioSource.pitch = 0f;
				}
			}
			else
			{
				_dipAnimation.ResetTriggerClose();
				_ = droppingPointsCoords == base.transform.position;
			}
		}

		protected override void OnFurniturePickedUp()
		{
			droppingPointsCoords = base.transform.position;
			if ((bool)_audioSource)
			{
				_audioSource.Stop();
				_audioSource = null;
			}
			base.OnFurniturePickedUp();
		}

		public override void OnFurnitureSold()
		{
			StopAllCoroutines();
			if (_isInUse)
			{
				DropBodyBag();
			}
			if (_audioSource != null)
			{
				_audioSource.Stop();
			}
			base.OnFurnitureSold();
		}

		public override void OnFurnitureDestroyed()
		{
			if (_audioSource != null)
			{
				_audioSource.Stop();
			}
			StopAllCoroutines();
			base.OnFurnitureDestroyed();
		}

		protected override void OnDisabled()
		{
			if (_audioSource != null)
			{
				_audioSource.Stop();
			}
			base.OnDisabled();
		}

		public void Launch()
		{
			base.MachineUI.DisplayOrHide(_value: true);
			StartCoroutine(DissolveBodyCoroutine(FirstUsing: true));
		}

		public void LaunchAfterSave(bool needWait)
		{
			base.MachineUI.DisplayOrHide(_value: true);
			StartCoroutine(DissolveBodyCoroutine(FirstUsing: false, needWait));
		}

		[Button(null, EButtonEnableMode.Always)]
		public void testLaunch()
		{
			base.MachineUI.DisplayOrHide(_value: false);
			StopAllCoroutines();
			StartCoroutine(DissolveBodyCoroutine(FirstUsing: true));
			base.MachineUI.DisplayOrHide(_value: true);
		}

		public IEnumerator DissolveBodyCoroutine(bool FirstUsing, bool needToWait = false)
		{
			if (FirstUsing)
			{
				_timerUI = 0f;
				_timerNormalizedValue = 0f;
				base.MachineUI.ResetFillArea(0f);
				MonoSingleton<SoundManager>.Instance.PlaySpatializedAudioAsset(SFXMachineList.SoundsList[1], base.gameObject.transform.position);
				_dipAnimation.OpenOrCloseMorgue(value: false);
			}
			_isInUse = true;
			float totalTime = base.MachineUpgrade.CurrentProcessDuration;
			_dissolveTime = totalTime / 2f;
			bool dissolveCompleted = false;
			if (needToWait)
			{
				MonoSingleton<SoundManager>.Instance.OnLoadingFinished += Instance_OnLoadingFinished;
			}
			else
			{
				PlayASound(SFXMachineList.SoundsList[2]);
			}
			while (_timerUI < totalTime)
			{
				if (MachinePowerState == EMachinePowerState.On)
				{
					float deltaTime = Time.deltaTime;
					_timerUI += deltaTime;
					_timerNormalizedValue = Mathf.Clamp01(_timerUI / totalTime);
					base.MachineUI.RunFillArea(_timerNormalizedValue);
					if (!dissolveCompleted && _timerUI >= _dissolveTime)
					{
						dissolveCompleted = true;
						TheDip.Dissolved?.Invoke();
						InvokeCorpseDisposed();
					}
				}
				yield return null;
			}
			base.MachineUI.DisplayOrHide(_value: false);
			if (_deadBody.HasValue && (bool)_deadBody.Value.VigilanceData)
			{
				Bounds bounds = base.Furniture.Bounds.PlacementCollider.bounds;
				MonoSingleton<VigilanceHandlers>.Instance.ChangeVigilanceBy(_deadBody.Value.VigilanceData.GetVigilanceForTheDip(_deadBody.Value.Credibility), bounds.center + Vector3.up * bounds.extents.y);
			}
			EventsManager.ChangeMoney?.Invoke(Currencies.Dollars, -_costOfUsingThis);
			TheDip.Refilled?.Invoke();
			yield return Coroutines.WaitForEndOfFrame();
			_dipAnimation.OpenOrCloseMorgue(value: true);
			PlayASound(SFXMachineList.SoundsList[0]);
			_deadBody = null;
			_isInUse = false;
			yield return null;
		}

		private void Instance_OnLoadingFinished()
		{
			PlayASound(SFXMachineList.SoundsList[2]);
			MonoSingleton<SoundManager>.Instance.OnLoadingFinished -= Instance_OnLoadingFinished;
		}

		protected override Sequence LoadIn()
		{
			Debug.Log("LoadIn");
			return null;
		}

		protected override Sequence Unload()
		{
			Debug.Log("Unload");
			return null;
		}

		protected override Sequence ProcessIn()
		{
			Debug.Log("ProcessIn");
			return null;
		}

		protected override Sequence Process()
		{
			Debug.Log("Process");
			return null;
		}

		protected override Sequence ProcessOut()
		{
			Debug.Log("ProcessOut");
			return null;
		}

		public void AddBodyBag(DeadBodyData customerData)
		{
			_deadBody = customerData;
		}

		public void DropBodyBag()
		{
			if (base.gameObject.scene.isLoaded && _deadBody.HasValue)
			{
				BodyBag bodyBag = Pooler.Pull(_bodyBagPrefab.Value, active: true);
				bodyBag.transform.SetPositionAndRotation(droppingPointsCoords, Quaternion.Euler(0f, 0f, 0f));
				bodyBag.SetBodyData(_deadBody.Value);
				bodyBag.CreateBodyBagCleaningChore(allowMorgue: true);
			}
		}

		protected override void OnMachineSwitchPower(EMachinePowerState value)
		{
			base.OnMachineSwitchPower(value);
			if (!_isInUse)
			{
				AudioAsset audioToPlay;
				if (value == EMachinePowerState.On)
				{
					_dipAnimation.OpenOrCloseMorgue(value: true);
					audioToPlay = SFXMachineList.SoundsList[0];
				}
				else
				{
					_dipAnimation.OpenOrCloseMorgue(value: false);
					audioToPlay = SFXMachineList.SoundsList[1];
				}
				if (_alreadyPut)
				{
					PlayASound(audioToPlay);
				}
			}
		}

		private AudioSource PlayASound(AudioAsset AudioToPlay)
		{
			if (_audioSource == null)
			{
				_audioSource = MonoSingleton<SoundManager>.Instance.PlaySpatializedAudioAsset(AudioToPlay, base.gameObject.transform.position);
			}
			else
			{
				if (_audioSource.isPlaying)
				{
					_audioSource.Stop();
				}
				_audioSource = null;
				_audioSource = MonoSingleton<SoundManager>.Instance.PlaySpatializedAudioAsset(AudioToPlay, base.gameObject.transform.position);
			}
			if (MonoSingleton<TimeController>.Instance.TimeMode == ETimeModes.Pause)
			{
				_audioSource.pitch = 0f;
			}
			return _audioSource;
		}

		protected override void OnVictimUnloaded()
		{
		}

		public bool CanBeUsedToDisposeBody(Agent agent, Customer customer)
		{
			if (MachinePowerState == EMachinePowerState.Off)
			{
				return false;
			}
			if (!_isInUse)
			{
				return CanBeUsed(agent);
			}
			return false;
		}

		public bool CanBeUsedToDisposeBody(Agent agent, DeadBodyData deadBodyData)
		{
			if (MachinePowerState == EMachinePowerState.Off)
			{
				return false;
			}
			if (_isInUse)
			{
				return _deadBody.Value.Equals(deadBodyData);
			}
			return CanBeUsed(agent);
		}

		public bool CanBeUsedToDisposeBody(DeadBodyData deadBodyData)
		{
			if (MachinePowerState == EMachinePowerState.Off)
			{
				return false;
			}
			if (_isInUse)
			{
				return _deadBody.Value.Equals(deadBodyData);
			}
			return CanBeUsed();
		}

		public AgentAction GetAction()
		{
			return new WorkerActionTheDipBodyDrop(this);
		}
	}
}
