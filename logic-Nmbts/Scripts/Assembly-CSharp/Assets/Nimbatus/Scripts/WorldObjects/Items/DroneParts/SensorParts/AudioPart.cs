using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Controls.Keybinds;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Selection;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public class AudioPart : BindableDronePart
	{
		public List<AudioPartSound> Sounds = new List<AudioPartSound>();

		[HideInInspector]
		[EnumSetting("DronePartSettings/Sound", UndoManager.EStoreReason.AudioPartSound)]
		public ESoundEffect SoundEffect;

		[HideInInspector]
		[IntSetting("DronePartSettings/Volume", 0, 100, 101, UndoManager.EStoreReason.AudioPartVolume)]
		public int Volume = 50;

		[HideInInspector]
		[IntSetting("DronePartSettings/Pitch", 0, 100, 101, UndoManager.EStoreReason.AudioPartPitch)]
		public int Pitch = 50;

		[HideInInspector]
		[FloatSetting("DronePartSettings/SpatialBlend", 0f, 1f, 11, UndoManager.EStoreReason.AudioPartSpatial)]
		public float SpatialBlend;

		public tk2dSprite OutputLed;

		private KeyBinding _inputBinding;

		private bool _wasTrue;

		private AudioObject _activeAudioObject;

		private bool _shouldPlay;

		private bool _disableAudio;

		private ESoundEffect _selectedSoundEffect;

		private AudioPartSound _sound;

		private AudioItem _audioItem;

		[ButtonSetting("DronePartSettings/Play", UndoManager.EStoreReason.None)]
		public void Play()
		{
			AudioPartSound audioPartSound = Sounds.First((AudioPartSound s) => s.Category == SoundEffect);
			AudioItem audioItem = SingletonMonoBehaviour<AudioController>.Instance._GetAudioItem(audioPartSound.SoundName);
			if (_activeAudioObject == null || (audioItem != null && audioItem.Loop == AudioItem.LoopMode.DoNotLoop))
			{
				_activeAudioObject = PlaySound(audioPartSound.SoundName);
				_activeAudioObject.pitch = (float)Pitch / 100f * 2f * RuntimeGlobals.TimeScale;
				_activeAudioObject.primaryAudioSource.spatialBlend = SpatialBlend;
				_activeAudioObject.volume = (float)Volume / 100f;
			}
			else
			{
				Stop();
			}
		}

		public void Stop()
		{
			if (_activeAudioObject != null)
			{
				_activeAudioObject.Stop(0.25f);
				_activeAudioObject = null;
			}
		}

		protected override void Start()
		{
			base.Start();
			_sound = Sounds.First((AudioPartSound s) => s.Category == SoundEffect);
			_audioItem = SingletonMonoBehaviour<AudioController>.Instance._GetAudioItem(_sound.SoundName);
		}

		public override void FixedUpdate()
		{
			if (BaseSingleton<KeybindManager>.Instance.GetKeyDown(EKeybinding.DisableAudioParts))
			{
				_disableAudio = !_disableAudio;
			}
			if (_activeAudioObject != null)
			{
				if (_disableAudio)
				{
					_activeAudioObject.volume = 0f;
				}
				else
				{
					_activeAudioObject.pitch = (float)Pitch / 100f * 2f * RuntimeGlobals.TimeScale;
					_activeAudioObject.primaryAudioSource.spatialBlend = SpatialBlend;
					_activeAudioObject.volume = (float)Volume / 100f;
				}
			}
			if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
			{
				if (!ItemSelector.IsSelected(this))
				{
					Stop();
				}
				if (_selectedSoundEffect != SoundEffect)
				{
					_selectedSoundEffect = SoundEffect;
					Stop();
				}
				return;
			}
			base.FixedUpdate();
			if (IsActive())
			{
				if (_inputBinding.KeyCode != KeyCode.None || !string.IsNullOrEmpty(_inputBinding.StringCode))
				{
					bool flag = _inputBinding.IsPressed(KeyEventHub);
					OutputLed.color = (flag ? Color.green : ColorHelper.BlackAlpha0);
					if (flag)
					{
						if (!_wasTrue)
						{
							if (_activeAudioObject != null && _audioItem.Loop != AudioItem.LoopMode.DoNotLoop)
							{
								_activeAudioObject.Stop();
								_activeAudioObject = null;
							}
							_activeAudioObject = PlaySound(_sound.SoundName);
							_activeAudioObject.pitch = (float)Pitch / 100f * 2f * RuntimeGlobals.TimeScale;
							_activeAudioObject.primaryAudioSource.spatialBlend = SpatialBlend;
							_activeAudioObject.volume = (float)Volume / 100f;
							_wasTrue = true;
						}
					}
					else if (_wasTrue)
					{
						_wasTrue = false;
						if (_activeAudioObject != null && _audioItem.Loop != AudioItem.LoopMode.DoNotLoop)
						{
							_activeAudioObject.Stop(0.25f);
							_activeAudioObject = null;
						}
					}
				}
			}
			else
			{
				OutputLed.color = ColorHelper.BlackAlpha0;
			}
			if (IsBroken && _wasTrue)
			{
				_wasTrue = false;
				if (_activeAudioObject != null)
				{
					_activeAudioObject.Stop(0.25f);
					_activeAudioObject = null;
				}
			}
		}

		public override void OnDisable()
		{
			base.OnDisable();
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			_inputBinding = new KeyBinding("Activate", KeyCode.None);
			return new List<KeyBinding> { _inputBinding };
		}

		public override NimbatusItemData CreateData()
		{
			return new AudioPartData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			AudioPartData audioPartData;
			if ((audioPartData = data as AudioPartData) != null)
			{
				audioPartData.SoundEffect = SoundEffect;
				audioPartData.Pitch = Pitch;
				audioPartData.Volume = Volume;
				audioPartData.SpatialBlend = SpatialBlend;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			AudioPartData audioPartData;
			if ((audioPartData = data as AudioPartData) != null)
			{
				Volume = audioPartData.Volume;
				Pitch = audioPartData.Pitch;
				SoundEffect = audioPartData.SoundEffect;
				SpatialBlend = audioPartData.SpatialBlend;
			}
		}
	}
}
