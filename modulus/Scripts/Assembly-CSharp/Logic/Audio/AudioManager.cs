using System.Collections.Generic;
using Data.Buildings;
using Data.Operator;
using Data.Variables;
using FMOD.Studio;
using FMODUnity;
using Logic.Factory.Blueprint;
using Presentation.Locators;
using UnityEngine;

namespace Logic.Audio
{
	public class AudioManager : MonoBehaviour
	{
		private const string ObjectSizeParameterName = "ObjectSize";

		private const string RankParameterName = "Rank";

		private const string AmbientIntensityName = "ambienceIntensity";

		private const string ZoomLevelParameterName = "zoomLevel";

		private const string DaytimeParameterName = "Daytime";

		private const string TechTreeCreditsMusicParameterName = "techTreeCreditsMusic";

		[SerializeField]
		private AudioManagerPlayer _player;

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		[Header("Buildings")]
		[SerializeField]
		private EventReference _floorCompleted;

		[SerializeField]
		private EventReference _monumentCharged;

		[SerializeField]
		private EventReference _monumentCompleted;

		[Header("GNN")]
		[SerializeField]
		private EventReference _gnnIslandUnlock;

		[SerializeField]
		private EventReference _gnnPhaseComplete;

		[SerializeField]
		private EventReference _gnnGateCompleted;

		[Header("Music")]
		[SerializeField]
		private EventReference _musicFactory;

		[Header("Operators")]
		[SerializeField]
		private EventReference _crane;

		[SerializeField]
		private EventReference _droneDropOff;

		[SerializeField]
		private EventReference _droneLand;

		[SerializeField]
		private EventReference _dronePickup;

		[SerializeField]
		private EventReference _droneTakeOff;

		[SerializeField]
		private EventReference _linkBuilding;

		[SerializeField]
		private EventReference _unlinkBuilding;

		[SerializeField]
		private EventReference _itemDeliveredDepot;

		[SerializeField]
		private EventReference _itemEnter;

		[SerializeField]
		private EventReference _itemExit;

		[SerializeField]
		private EventReference _overflowGreen;

		[SerializeField]
		private EventReference _overflowRed;

		[Header("UI")]
		[SerializeField]
		private EventReference _buttonGeneric;

		[SerializeField]
		private EventReference _buttonHoverGeneric;

		[SerializeField]
		private EventReference _cannotDoThatGeneric;

		[SerializeField]
		private EventReference _undo;

		[SerializeField]
		private EventReference _redo;

		[SerializeField]
		private EventReference _rankUp;

		[SerializeField]
		private EventReference _newObjective;

		[SerializeField]
		private EventReference _subObjectiveCompleted;

		[SerializeField]
		private EventReference _notificationReward;

		[SerializeField]
		private EventReference _deliveryTargetCompleted;

		[SerializeField]
		private EventReference _moduleChallengeCompleted;

		[SerializeField]
		private EventReference _techtreeStartUnlockingNode;

		[SerializeField]
		private EventReference _techtreeNodeUnlock;

		[SerializeField]
		private EventReference _techtreeNodeunlockInterrupt;

		[SerializeField]
		private EventReference _islandHover;

		[SerializeField]
		private EventReference _islandClick;

		[SerializeField]
		private EventReference _islandPurchase;

		[SerializeField]
		private EventReference _stamperSelection;

		[SerializeField]
		private EventReference _uiOpen;

		[SerializeField]
		private EventReference _uiClose;

		[SerializeField]
		private EventReference _modalOpen;

		[SerializeField]
		private EventReference _uiEmptyClick;

		[SerializeField]
		private EventReference _newModuleCreated;

		[Header("Narrators")]
		[SerializeField]
		private EventReference _openNarrator;

		[SerializeField]
		private EventReference _atlasTalk;

		[SerializeField]
		private EventReference _gnnTalk;

		[SerializeField]
		private EventReference _introLoop;

		[Header("Inside Operators")]
		[SerializeField]
		private EventReference _insideViewOpen;

		[SerializeField]
		private EventReference _insideViewClose;

		[SerializeField]
		private EventReference _insideViewModuleEnter;

		[SerializeField]
		private EventReference _insideViewShapePickup;

		[SerializeField]
		private EventReference _insideViewShapeDrop;

		[Header("Ambient Tracks")]
		[SerializeField]
		private EventReference _ambientTrackFactory;

		[SerializeField]
		private EventReference _ambientTrackConveyor;

		[SerializeField]
		private EventReference _ambientTrackWater;

		[SerializeField]
		private EventReference _ambientTrackNature;

		[Header("UX")]
		[SerializeField]
		private EventReference _cameraPan;

		[SerializeField]
		private EventReference _cameraRotate;

		[SerializeField]
		private EventReference _cameraZoom;

		[SerializeField]
		private EventReference _clickFloorGrass;

		[SerializeField]
		private EventReference _clickFloorStone;

		[SerializeField]
		private EventReference _clickOperatorUIPopup;

		[Space]
		[SerializeField]
		private EventReference _deleteObject;

		[SerializeField]
		private EventReference _moveObject;

		[SerializeField]
		private EventReference _placeObject;

		[SerializeField]
		private EventReference _rotateObject;

		[SerializeField]
		private EventReference _selectObject;

		[SerializeField]
		private EventReference _placeNatureObject;

		[SerializeField]
		private EventReference _duplicateObject;

		[SerializeField]
		private EventReference _placeConveyor;

		[Space]
		[SerializeField]
		private EventReference _setupFaulty;

		[SerializeField]
		private EventReference _shapeRotate;

		[Header("Building Placement Sounds")]
		[SerializeField]
		private EventReference _placeBuildingBot;

		[SerializeField]
		private EventReference _placeBuildingCore;

		[SerializeField]
		private EventReference _placeBuildingDatashard;

		[SerializeField]
		private EventReference _placeBuildingProcessor;

		[SerializeField]
		private EventReference _placeBuildingPigment;

		[SerializeField]
		private EventReference _placeBuildingMonument;

		[SerializeField]
		private int _maxConcurrentPlaceSoundsAmount = 5;

		[SerializeField]
		private List<BuildingObjectData> _buildingsPlaceSoundBot;

		[SerializeField]
		private List<BuildingObjectData> _buildingsPlaceSoundCore;

		[SerializeField]
		private List<BuildingObjectData> _buildingsPlaceSoundDatashard;

		[SerializeField]
		private List<BuildingObjectData> _buildingsPlaceSoundProcessor;

		[SerializeField]
		private List<BuildingObjectData> _buildingsPlaceSoundPigment;

		[SerializeField]
		private List<BuildingObjectData> _buildingsPlaceSoundMonument;

		[Header("Volumes")]
		[SerializeField]
		private FloatVariableSO _musicVolume;

		[Header("Volumes")]
		[SerializeField]
		private FloatVariableSO _sfxVolume;

		[Header("Volumes")]
		[SerializeField]
		private FloatVariableSO _masterVolume;

		[Header("Snapshot")]
		[SerializeField]
		private EventReference _insideOperatorUISnapshot;

		[SerializeField]
		private EventReference _introSnapshot;

		private Bus _musicBus;

		private Bus _sfxBus;

		private EventInstance _cameraPanInstance;

		private EventInstance _cameraRotateInstance;

		private EventInstance _insideOperatorSnapShotInstance;

		private EventInstance _introSnapShotInstance;

		private EventInstance _musicInstance;

		private EventInstance _insideViewLoopInstance;

		private EventInstance _factoryAmbientEventInstance;

		private EventInstance _conveyorAmbientEventInstance;

		private EventInstance _natureAmbientEventInstance;

		private EventInstance _waterAmbientEventInstance;

		private EventInstance _techtreeUnlockingEventInstance;

		private EventInstance _narratorTalkLoopInstance;

		private EventInstance _introLoopInstance;

		private void Awake()
		{
			_audioManagerLocator.AudioManager = this;
			RuntimeManager.LoadBank("SFX", loadSamples: true);
			_musicBus = RuntimeManager.GetBus("bus:/MUSIC_main");
			_sfxBus = RuntimeManager.GetBus("bus:/SFX_main");
			_musicVolume.ValueChanged += SetMusicVolume;
			_sfxVolume.ValueChanged += SetSFXVolume;
			_masterVolume.ValueChanged += SetMasterVolume;
			PlayMusic();
			SetMasterVolume(_masterVolume.Value);
			SetMusicVolume(_musicVolume.Value);
			SetSFXVolume(_sfxVolume.Value);
			SetTechTreeCreditsMusicParameter(0f);
		}

		private void OnDestroy()
		{
			_musicVolume.ValueChanged -= SetMusicVolume;
			_sfxVolume.ValueChanged -= SetSFXVolume;
			_masterVolume.ValueChanged -= SetMasterVolume;
			StopMusic();
		}

		public void SetMusicVolume(float value)
		{
			_musicBus.setVolume(value * _masterVolume.Value);
		}

		public void SetSFXVolume(float value)
		{
			_sfxBus.setVolume(value * _masterVolume.Value);
		}

		public void SetMasterVolume(float value)
		{
			_musicBus.setVolume(_musicVolume.Value * value);
			_sfxBus.setVolume(_sfxVolume.Value * value);
		}

		private void PlayMusic()
		{
			_musicInstance = RuntimeManager.CreateInstance(_musicFactory);
			_musicInstance.start();
		}

		private void StopMusic()
		{
			_musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			_musicInstance.release();
		}

		public void PlayFloorCompleted(Vector3 sourcePosition, int objectSize = 0)
		{
			_player.PlayOneShot(_floorCompleted, sourcePosition, "ObjectSize", objectSize);
		}

		public void PlayChargedMonument(Vector3 sourcePosition, bool isCharged, ref EventInstance loopInstance)
		{
			if (isCharged && !loopInstance.isValid())
			{
				loopInstance = _player.PlayLoop(_monumentCharged, sourcePosition);
			}
			if (!isCharged && loopInstance.isValid())
			{
				_player.StopLoop(ref loopInstance, fadeOut: true);
			}
		}

		public void PlayMonumentCompleted(Vector3 sourcePosition)
		{
			_player.PlayOneShot(_monumentCompleted, sourcePosition, "ObjectSize", 2, force: true);
		}

		public void PlayGNNGateCompleted(Vector3 sourcePosition)
		{
			_player.PlayOneShot(_gnnGateCompleted, sourcePosition, "ObjectSize", 2, force: true);
		}

		public void PlayGNNIslandUnlock()
		{
			_player.PlayOneShot(_gnnIslandUnlock, force: true);
		}

		public void PlayGNNPhaseComplete(Vector3 sourcePosition)
		{
			_player.PlayOneShot(_gnnPhaseComplete, force: true);
		}

		public void PlayFactoryBehaviourViewOneShot(EventReference eventReference, Vector3 sourcePosition, int objectSize = 0)
		{
			_player.PlayOneShot(eventReference, sourcePosition, "ObjectSize", objectSize);
		}

		public void PlayCrane(Vector3 sourcePosition)
		{
			_player.PlayOneShot(_crane, sourcePosition);
		}

		public void PlayDroneDropOff(Vector3 sourcePosition)
		{
			_player.PlayOneShot(_droneDropOff, sourcePosition);
		}

		public void PlayDroneLand(Vector3 sourcePosition)
		{
			_player.PlayOneShot(_droneLand, sourcePosition);
		}

		public void PlayDronePickup(Vector3 sourcePosition)
		{
			_player.PlayOneShot(_dronePickup, sourcePosition);
		}

		public void PlayDroneTakeOff(Vector3 sourcePosition)
		{
			_player.PlayOneShot(_droneTakeOff, sourcePosition);
		}

		public EventInstance PlayDroneFlyingWithSpeed(EventReference eventReference, GameObject attachedGameObject, float speed = 1f)
		{
			EventInstance eventInstance = _player.PlayLoop(eventReference, attachedGameObject);
			SetDroneFlyingSpeed(eventInstance, speed);
			return eventInstance;
		}

		public void SetDroneFlyingSpeed(EventInstance eventInstance, float speed)
		{
			eventInstance.setParameterByName("Dronespeed", speed);
		}

		public void StopPlayDroneFly(ref EventInstance eventInstance)
		{
			_player.StopLoop(ref eventInstance, fadeOut: true);
		}

		public EventInstance PlayFreighterFlyingWithSpeed(EventReference eventReference, GameObject attachedGameObject, float speed = 1f)
		{
			EventInstance eventInstance = _player.PlayLoop(eventReference, attachedGameObject);
			SetDroneFlyingSpeed(eventInstance, speed);
			return eventInstance;
		}

		public void SetFreighterFlyingSpeed(EventInstance eventInstance, float speed)
		{
			eventInstance.setParameterByName("Dronespeed", speed);
		}

		public void StopPlayFreighterFly(ref EventInstance eventInstance)
		{
			_player.StopLoop(ref eventInstance, fadeOut: true);
		}

		public void PlayLinkBuilding(Vector3 sourcePosition)
		{
			_player.PlayOneShot(_linkBuilding, sourcePosition);
		}

		public void PlayUnlinkBuilding(Vector3 sourcePosition)
		{
			_player.PlayOneShot(_unlinkBuilding, sourcePosition);
		}

		public void PlayItemDeliveredDepot(Vector3 sourcePosition)
		{
			_player.PlayOneShot(_itemDeliveredDepot, sourcePosition);
		}

		public void PlayItemEnter(Vector3 sourcePosition)
		{
			_player.PlayOneShot(_itemEnter, sourcePosition);
		}

		public void PlayItemExit(Vector3 sourcePosition)
		{
			_player.PlayOneShot(_itemExit, sourcePosition);
		}

		public void PlayOverflowSplitterGreen(Vector3 sourcePosition)
		{
			_player.PlayOneShot(_overflowGreen, sourcePosition);
		}

		public void PlayOverflowSplitterRed(Vector3 sourcePosition)
		{
			_player.PlayOneShot(_overflowRed, sourcePosition);
		}

		public EventInstance PlayFactoryObjectViewLoop(EventReference eventReference, Vector3 position)
		{
			return _player.PlayLoop(eventReference, position);
		}

		public void StopFactoryObjectViewLoop(ref EventInstance eventInstance)
		{
			_player.StopLoop(ref eventInstance, fadeOut: true);
		}

		public void PlayOperatorStateOneShot(EventReference eventReference, Vector3 sourcePosition)
		{
			_player.PlayOneShot(eventReference, sourcePosition, force: true);
		}

		public void PlayCantDoThat()
		{
			_player.PlayOneShot(_cannotDoThatGeneric, force: true);
		}

		public void PlayButtonSound()
		{
			_player.PlayOneShot(_buttonGeneric, force: true);
		}

		public void PlayButtonHoverSound()
		{
			_player.PlayOneShot(_buttonHoverGeneric, force: true);
		}

		public void PlayButtonSound(EventReference buttonEventReference)
		{
			_player.PlayOneShot(buttonEventReference, force: true);
		}

		public void PlayRotateShape()
		{
			_player.PlayOneShot(_shapeRotate, force: true);
		}

		public void PlayBuildingStateSound(EventReference eventReference)
		{
			_player.PlayOneShot(eventReference, force: true);
		}

		public void PlayOpenOperatorUIPanel()
		{
			_player.PlayOneShot(_clickOperatorUIPopup, force: true);
		}

		public void PlayOpenUI()
		{
			_player.PlayOneShot(_uiOpen, force: true);
		}

		public void PlayCloseUI()
		{
			_player.PlayOneShot(_uiClose, force: true);
		}

		public void PlayOpenModal()
		{
			_player.PlayOneShot(_modalOpen, force: true);
		}

		public void PlayUIEmptyClick()
		{
			_player.PlayOneShot(_uiEmptyClick, force: true);
		}

		public void PlayUndo()
		{
			_player.PlayOneShot(_undo, force: true);
		}

		public void PlayRedo()
		{
			_player.PlayOneShot(_redo, force: true);
		}

		public void PlayRankUp(int rank)
		{
			RuntimeManager.StudioSystem.setParameterByName("Rank", rank);
			_player.PlayOneShot(_rankUp);
		}

		public void PlayNewObjective()
		{
			_player.PlayOneShot(_newObjective, force: true);
		}

		public void PlaySubQuestComplete()
		{
			_player.PlayOneShot(_subObjectiveCompleted, force: true);
		}

		public void PlayNotificationReward()
		{
			_player.PlayOneShot(_notificationReward, force: true);
		}

		public void PlayDeliveryTargetComplete()
		{
			_player.PlayOneShot(_deliveryTargetCompleted, force: true);
		}

		public void PlayModuleChallengeComplete()
		{
			_player.PlayOneShot(_moduleChallengeCompleted, force: true);
		}

		public void PlayStartUnlocking()
		{
			StopUnlocking(isComplete: false);
			_techtreeUnlockingEventInstance = _player.PlayLoop(_techtreeStartUnlockingNode);
		}

		public void StopUnlocking(bool isComplete)
		{
			if (_techtreeUnlockingEventInstance.isValid())
			{
				_player.StopLoop(ref _techtreeUnlockingEventInstance, fadeOut: true);
				if (!isComplete)
				{
					_player.PlayOneShot(_techtreeNodeunlockInterrupt, force: true);
				}
			}
		}

		public void PlayStamperSelection()
		{
			_player.PlayOneShot(_stamperSelection);
		}

		public void PlayTechtreeNodeUnlock()
		{
			_player.PlayOneShot(_techtreeNodeUnlock, force: true);
		}

		public void PlayIslandHover()
		{
			_player.PlayOneShot(_islandHover);
		}

		public void PlayIslandClick()
		{
			_player.PlayOneShot(_islandClick);
		}

		public void PlayIslandPurchase()
		{
			_player.PlayOneShot(_islandPurchase, force: true);
		}

		public void PlayNewModuleCreated()
		{
			_player.PlayOneShot(_newModuleCreated, force: true);
		}

		public void StartAtlasTalkLoop()
		{
			_narratorTalkLoopInstance = _player.PlayLoop(_atlasTalk);
		}

		public void StartGNNTalkLoop()
		{
			_narratorTalkLoopInstance = _player.PlayLoop(_gnnTalk);
		}

		public void StopNarratorTalkLoop()
		{
			_player.StopLoop(ref _narratorTalkLoopInstance, fadeOut: true);
		}

		public void PlayOpenNarrator()
		{
			_player.PlayOneShot(_openNarrator);
		}

		public void PlayIntroLoop()
		{
			_introLoopInstance = _player.PlayLoop(_introLoop);
		}

		public void StopIntroLoop()
		{
			if (_introLoopInstance.isValid())
			{
				_player.StopLoop(ref _introLoopInstance, fadeOut: true);
			}
		}

		public void PlayToolOneShot(EventReference eventReference, Vector3 sourcePosition)
		{
			_player.PlayOneShot(eventReference, sourcePosition, force: true);
		}

		public void PlayPlaceObjectGeneric(Vector3 blueprintPosition, Blueprint blueprint, int objectSize = 0)
		{
			for (int i = 0; i < blueprint.Elements.Count && i < _maxConcurrentPlaceSoundsAmount; i++)
			{
				FactoryObjectData objectData = blueprint.Elements[i].ObjectData;
				Vector3 position = blueprintPosition + objectData.RelativePositions[0];
				if (objectData is BuildingObjectData item)
				{
					if (_buildingsPlaceSoundBot.Contains(item))
					{
						_player.PlayOneShot(_placeBuildingBot, position, "ObjectSize", objectSize, force: true);
					}
					else if (_buildingsPlaceSoundCore.Contains(item))
					{
						_player.PlayOneShot(_placeBuildingCore, position, "ObjectSize", objectSize, force: true);
					}
					else if (_buildingsPlaceSoundDatashard.Contains(item))
					{
						_player.PlayOneShot(_placeBuildingDatashard, position, "ObjectSize", objectSize, force: true);
					}
					else if (_buildingsPlaceSoundPigment.Contains(item))
					{
						_player.PlayOneShot(_placeBuildingPigment, position, "ObjectSize", objectSize, force: true);
					}
					else if (_buildingsPlaceSoundProcessor.Contains(item))
					{
						_player.PlayOneShot(_placeBuildingProcessor, position, "ObjectSize", objectSize, force: true);
					}
					else if (_buildingsPlaceSoundMonument.Contains(item))
					{
						_player.PlayOneShot(_placeBuildingMonument, position, "ObjectSize", objectSize, force: true);
					}
					else
					{
						_player.PlayOneShot(_placeObject, position, "ObjectSize", objectSize, force: true);
					}
				}
				else
				{
					_player.PlayOneShot(_placeObject, position, "ObjectSize", objectSize, force: true);
				}
			}
		}

		public void PlayPlaceObject(Vector3 sourcePosition, int objectSize = 0)
		{
			_player.PlayOneShot(_placeObject, sourcePosition, "ObjectSize", objectSize, force: true);
		}

		public void PlayPlaceNatureObject(Vector3 sourcePosition, int objectSize = 0)
		{
			_player.PlayOneShot(_placeNatureObject, sourcePosition, "ObjectSize", objectSize, force: true);
		}

		public void PlayMoveObject(Vector3 sourcePosition, int objectSize = 0)
		{
			_player.PlayOneShot(_moveObject, sourcePosition, "ObjectSize", objectSize, force: true);
		}

		public void PlayRotateObject(Vector3 sourcePosition, int objectSize = 0)
		{
			_player.PlayOneShot(_rotateObject, sourcePosition, "ObjectSize", objectSize, force: true);
		}

		public void PlayDeleteObject(Vector3 sourcePosition, int objectSize = 0)
		{
			_player.PlayOneShot(_deleteObject, sourcePosition, "ObjectSize", objectSize, force: true);
		}

		public void PlayObjectSelected(Vector3 sourcePosition, int objectSize = 0)
		{
			_player.PlayOneShot(_selectObject, sourcePosition, "ObjectSize", objectSize, force: true);
		}

		public void PlayDuplicateObject(Vector3 sourcePosition)
		{
			_player.PlayOneShot(_duplicateObject, sourcePosition, force: true);
		}

		public void PlayPlaceConveyorPreview(Vector3 sourcePosition)
		{
			_player.PlayOneShot(_placeConveyor, sourcePosition, force: true);
		}

		public void PlayCantPlace(Vector3 sourcePosition)
		{
			_player.PlayOneShot(_setupFaulty, sourcePosition, force: true);
		}

		public void PlayCantAfford(Vector3 sourcePosition)
		{
			_player.PlayOneShot(_setupFaulty, sourcePosition, force: true);
		}

		public void PlayClickFloorStone(Vector3 sourcePosition)
		{
			_player.PlayOneShot(_clickFloorStone, sourcePosition, force: true);
		}

		public void PlayClickGrass(Vector3 sourcePosition)
		{
			_player.PlayOneShot(_clickFloorGrass, sourcePosition, force: true);
		}

		public void PlayCameraZoom()
		{
			_player.PlayOneShot(_cameraZoom, force: true);
		}

		public void PlayCameraPan(GameObject cameraGameObject)
		{
			if (!_cameraPanInstance.isValid())
			{
				_cameraPanInstance = _player.PlayLoop(_cameraPan, cameraGameObject);
			}
		}

		public void StopCameraPan()
		{
			if (_cameraPanInstance.isValid())
			{
				_player.StopLoop(ref _cameraPanInstance, fadeOut: true);
			}
		}

		public void PlayCameraRotate(GameObject cameraGameObject)
		{
			if (!_cameraRotateInstance.isValid())
			{
				_cameraRotateInstance = _player.PlayLoop(_cameraRotate, cameraGameObject);
			}
		}

		public void StopCameraRotate()
		{
			if (_cameraRotateInstance.isValid())
			{
				_player.StopLoop(ref _cameraRotateInstance, fadeOut: true);
			}
		}

		public void PlayInsideViewOpen()
		{
			_player.PlayOneShot(_insideViewOpen, force: true);
		}

		public void PlayInsideViewClose()
		{
			_player.PlayOneShot(_insideViewClose, force: true);
		}

		public void PlayInsideViewLoop(EventReference insideViewLoop)
		{
			_insideViewLoopInstance = _player.PlayLoop(insideViewLoop);
		}

		public void StopInsideViewLoop()
		{
			if (_insideViewLoopInstance.isValid())
			{
				_player.StopLoop(ref _insideViewLoopInstance, fadeOut: true);
			}
		}

		public void PlayInsideViewModuleEnter()
		{
			_player.PlayOneShot(_insideViewModuleEnter, force: true);
		}

		public void PlayShapePickup()
		{
			_player.PlayOneShot(_insideViewShapePickup, force: true);
		}

		public void PlayShapeDrop()
		{
			_player.PlayOneShot(_insideViewShapeDrop, force: true);
		}

		public void StartAmbientTrackLoops()
		{
			_factoryAmbientEventInstance = _player.PlayLoop(_ambientTrackFactory);
			_conveyorAmbientEventInstance = _player.PlayLoop(_ambientTrackConveyor);
			_natureAmbientEventInstance = _player.PlayLoop(_ambientTrackNature);
			_waterAmbientEventInstance = _player.PlayLoop(_ambientTrackWater);
			_factoryAmbientEventInstance.setParameterByName("ambienceIntensity", 0f);
			_conveyorAmbientEventInstance.setParameterByName("ambienceIntensity", 0f);
			_natureAmbientEventInstance.setParameterByName("ambienceIntensity", 0f);
			_waterAmbientEventInstance.setParameterByName("ambienceIntensity", 0f);
		}

		public void SetAmbientTrackLoopVolume(AmbientTrackType trackType, float volume)
		{
			switch (trackType)
			{
			case AmbientTrackType.FactoryAmbient:
				_factoryAmbientEventInstance.setParameterByName("ambienceIntensity", volume);
				break;
			case AmbientTrackType.ConveyorAmbient:
				_conveyorAmbientEventInstance.setParameterByName("ambienceIntensity", volume);
				break;
			case AmbientTrackType.NatureAmbient:
				_natureAmbientEventInstance.setParameterByName("ambienceIntensity", volume);
				break;
			case AmbientTrackType.WaterAmbient:
				_waterAmbientEventInstance.setParameterByName("ambienceIntensity", volume);
				break;
			}
		}

		public void StopAmbientTrackLoops()
		{
			if (_factoryAmbientEventInstance.isValid())
			{
				_player.StopLoop(ref _factoryAmbientEventInstance, fadeOut: false);
			}
			if (_conveyorAmbientEventInstance.isValid())
			{
				_player.StopLoop(ref _conveyorAmbientEventInstance, fadeOut: false);
			}
			if (_natureAmbientEventInstance.isValid())
			{
				_player.StopLoop(ref _natureAmbientEventInstance, fadeOut: false);
			}
			if (_waterAmbientEventInstance.isValid())
			{
				_player.StopLoop(ref _waterAmbientEventInstance, fadeOut: false);
			}
		}

		public void SetZoomLevelParameter(float zoomLevel)
		{
			RuntimeManager.StudioSystem.setParameterByName("zoomLevel", zoomLevel);
		}

		public void SetDaytimeParameter(float value01)
		{
			RuntimeManager.StudioSystem.setParameterByName("Daytime", value01);
		}

		public void SetTechTreeCreditsMusicParameter(float value02)
		{
			RuntimeManager.StudioSystem.setParameterByName("techTreeCreditsMusic", value02);
		}

		public void SetInsideOperatorSnapshot(bool active)
		{
			SetSnapShotActive(ref _insideOperatorSnapShotInstance, _insideOperatorUISnapshot, active);
		}

		public void SetIntroSnapshot(bool active)
		{
			SetSnapShotActive(ref _introSnapShotInstance, _introSnapshot, active);
		}

		private void SetSnapShotActive(ref EventInstance snapShotInstance, EventReference snapShotReference, bool active)
		{
			if (!snapShotInstance.isValid() && active)
			{
				snapShotInstance = RuntimeManager.CreateInstance(snapShotReference);
				snapShotInstance.start();
			}
			else if (snapShotInstance.isValid() && !active)
			{
				snapShotInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
				snapShotInstance.release();
			}
		}
	}
}
