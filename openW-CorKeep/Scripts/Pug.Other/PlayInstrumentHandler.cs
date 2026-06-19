using System.Collections.Generic;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using UnityEngine;

public class PlayInstrumentHandler
{
	private const int MAX_NOTES = 24;

	private const int HALF_MAX_NOTES = 12;

	private static readonly Vector3 PARTICLE_OFFSET = new Vector3(0f, 1.5f, 0f);

	private static readonly Vector3 SHEET_OFFSET = new Vector3(0f, 1f, 0f);

	private static readonly CollisionFilter SHEET_STAND_COLLISION_FILTER = new CollisionFilter
	{
		BelongsTo = uint.MaxValue,
		CollidesWith = 1u
	};

	private int particleCountMax = 1;

	private int particleCount;

	private int particleTimerMax = 10;

	private int particleTimer;

	private float sheetParticleTimerMax = 0.5f;

	private float sheetParticleTimer;

	private readonly int[] storedNotes = new int[16];

	private static float[] storedDelays = new float[16];

	private static TimerSimple delayTimer;

	private static readonly PlayerInput.InputType[] KEY_INPUTS = new PlayerInput.InputType[24]
	{
		PlayerInput.InputType.C1_NOTE,
		PlayerInput.InputType.C1S_NOTE,
		PlayerInput.InputType.D1_NOTE,
		PlayerInput.InputType.D1S_NOTE,
		PlayerInput.InputType.E1_NOTE,
		PlayerInput.InputType.F1_NOTE,
		PlayerInput.InputType.F1S_NOTE,
		PlayerInput.InputType.G1_NOTE,
		PlayerInput.InputType.G1S_NOTE,
		PlayerInput.InputType.A1_NOTE,
		PlayerInput.InputType.A1S_NOTE,
		PlayerInput.InputType.B1_NOTE,
		PlayerInput.InputType.C2_NOTE,
		PlayerInput.InputType.C2S_NOTE,
		PlayerInput.InputType.D2_NOTE,
		PlayerInput.InputType.D2S_NOTE,
		PlayerInput.InputType.E2_NOTE,
		PlayerInput.InputType.F2_NOTE,
		PlayerInput.InputType.F2S_NOTE,
		PlayerInput.InputType.G2_NOTE,
		PlayerInput.InputType.G2S_NOTE,
		PlayerInput.InputType.A2_NOTE,
		PlayerInput.InputType.A2S_NOTE,
		PlayerInput.InputType.B2_NOTE
	};

	private readonly List<AudioManager.RunningSfxReference>[] _activeNotes;

	private PlayedNotes _previousPlayedNotes;

	private bool _octaveWasPreviouslyIncreasedOn;

	private int _noteSfx0;

	private int _noteSfx1;

	private float[] _notePitch0 = new float[24];

	private float[] _notePitch1 = new float[24];

	private int[] _overrideSfx = new int[24];

	private PlayerController _playerController;

	private bool[] _previousKeysPressed = new bool[24];

	private int _particleCountMax = 1;

	private int _particleCount;

	private int _particleTimerMax = 10;

	private int _particleTimer;

	private float _sheetParticleTimerMax = 0.5f;

	private float _sheetParticleTimer;

	private InstrumentType _currentInstrumentTypePlayed;

	private ObjectID _currentSheetPlayed;

	private SfxID _equipSfx;

	private SfxID _unequipSfx;

	public bool IsPlayingInstrument { get; private set; }

	private World World => _playerController.world;

	public PlayInstrumentHandler(PlayerController playerController)
	{
		_playerController = playerController;
		_activeNotes = new List<AudioManager.RunningSfxReference>[24];
		for (int i = 0; i < _activeNotes.Length; i++)
		{
			_activeNotes[i] = new List<AudioManager.RunningSfxReference>();
		}
	}

	public void StartPlaying()
	{
		IsPlayingInstrument = true;
		ResetStoredNotes();
		if (_playerController.isLocal)
		{
			_equipSfx = SfxID.inventoryOpen;
			_unequipSfx = SfxID.inventoryClose;
			ContainedObjectsBuffer visuallyEquippedContainedObject = _playerController.visuallyEquippedContainedObject;
			if (PugDatabase.HasComponent<InstrumentCD>(visuallyEquippedContainedObject.objectData))
			{
				InstrumentCD component = PugDatabase.GetComponent<InstrumentCD>(visuallyEquippedContainedObject.objectData);
				_equipSfx = Manager.audio.InspectorFriendlySfxIDToSfxID(component.equipSound);
				_unequipSfx = Manager.audio.InspectorFriendlySfxIDToSfxID(component.unequipSound);
			}
			AudioManager.SfxUI(_equipSfx, 1f, reuse: true, 1f, 0.1f, playOnGamepad: true);
		}
	}

	public void StopPlaying()
	{
		if (_currentSheetPlayed != ObjectID.None && _playerController.isLocal)
		{
			_currentSheetPlayed = ObjectID.None;
			_playerController.playerCommandSystem.StopPlayingMusicSheet(_playerController.entity);
		}
		if (_currentInstrumentTypePlayed != InstrumentType.None && _playerController.isLocal)
		{
			_currentInstrumentTypePlayed = InstrumentType.None;
			AudioManager.SfxUI(_unequipSfx, 1f, reuse: true, 1f, 0.1f, playOnGamepad: true);
		}
		List<AudioManager.RunningSfxReference>[] activeNotes = _activeNotes;
		foreach (List<AudioManager.RunningSfxReference> list in activeNotes)
		{
			foreach (AudioManager.RunningSfxReference item in list)
			{
				item.FadeOutAndStop();
			}
			list.Clear();
		}
		for (int j = 0; j < _previousKeysPressed.Length; j++)
		{
			_previousKeysPressed[j] = false;
		}
		IsPlayingInstrument = false;
		_octaveWasPreviouslyIncreasedOn = false;
	}

	public void Update(PlayedNotes playedNotes)
	{
		ContainedObjectsBuffer visuallyEquippedContainedObject = _playerController.visuallyEquippedContainedObject;
		if (PugDatabase.HasComponent<InstrumentCD>(visuallyEquippedContainedObject.objectData))
		{
			InstrumentCD component = PugDatabase.GetComponent<InstrumentCD>(visuallyEquippedContainedObject.objectData);
			int keyOffsetFromC = component.keyOffsetFromC5;
			if (component.instrumentType == InstrumentType.Drumkit)
			{
				for (int i = 0; i < 24; i++)
				{
					_overrideSfx[i] = Manager.audio.GetOverrideInstrumentSounds(visuallyEquippedContainedObject.objectID, i);
				}
			}
			else
			{
				_noteSfx0 = component.noteSound;
				_noteSfx1 = component.noteSoundOctave;
			}
			int num = keyOffsetFromC - 12;
			int num2 = 6;
			for (int j = 0; j < 24; j++)
			{
				_notePitch0[j] = Mathf.Pow(2f, (float)(j + num + num2) / 12f);
				_notePitch1[j] = Mathf.Pow(2f, (float)(j + num - num2) / 12f);
			}
		}
		UpdateTones(playedNotes);
		UpdateMusicSheetToneParticles();
	}

	public void UpdateInput()
	{
		PlayedNotes playedNotes = default(PlayedNotes);
		for (int i = 0; i < KEY_INPUTS.Length; i++)
		{
			if (_playerController.inputModule.IsButtonCurrentlyDown(KEY_INPUTS[i]))
			{
				playedNotes.SetKey(i);
			}
		}
		if (!Manager.input.SystemPrefersKeyboardAndMouse() && _playerController.inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.OCTAVE_CHANGE))
		{
			playedNotes.SetOctave();
		}
		_playerController.clientInput.playedNotes = playedNotes.Value;
		if (!IsPlayingInstrument)
		{
			_playerController.clientInput.playedNotes = 0;
			_playerController.currentSheetStandBeingPlayedAt = Entity.Null;
		}
		else
		{
			UpdatePlayingSheetMusic();
			UpdatePlayedInstrument();
		}
	}

	private void UpdateMusicSheetToneParticles()
	{
		_sheetParticleTimer -= Time.deltaTime;
		if (_sheetParticleTimer <= 0f)
		{
			PlayerController playerController = _playerController;
			if (EntityUtility.TryGetComponentData<MusicSheetPlayedCD>(playerController.entity, World, out var value) && value.currentSheetPlayed != ObjectID.None)
			{
				Vector3 renderPosition = playerController.RenderPosition;
				Manager.effects.PlayPuff(PuffID.NoteRed, renderPosition + SHEET_OFFSET, 1);
				_playerController.animator.SetTrigger(-1884439050);
				_sheetParticleTimer = _sheetParticleTimerMax;
			}
		}
	}

	private void UpdateTones(PlayedNotes playedNotes)
	{
		bool octave = _previousPlayedNotes.GetOctave();
		bool octave2 = playedNotes.GetOctave();
		if (octave2 != octave)
		{
			List<AudioManager.RunningSfxReference>[] activeNotes = _activeNotes;
			foreach (List<AudioManager.RunningSfxReference> list in activeNotes)
			{
				foreach (AudioManager.RunningSfxReference item in list)
				{
					item.FadeOutAndStop(0.2f);
				}
				list.Clear();
			}
		}
		for (int j = 0; j < KEY_INPUTS.Length; j++)
		{
			bool flag = ((octave2 != octave) ? playedNotes.GetKeyPressed(_previousPlayedNotes, j) : playedNotes.GetKey(j));
			bool key = playedNotes.GetKey(j);
			int num = j;
			if (octave2)
			{
				num += 12;
			}
			if (num >= 24)
			{
				break;
			}
			if (flag && _activeNotes[num].Count == 0)
			{
				InstrumentCD component = PugDatabase.GetComponent<InstrumentCD>(_playerController.visuallyEquippedContainedObject.objectData);
				Vector3 position = _playerController.transform.position;
				if (component.instrumentType == InstrumentType.Drumkit)
				{
					AudioManager.Sfx(_overrideSfx[num], position, 1f, 1f, loop: false, freeAudioSourceAfterItStoppedPlaying: false, AudioManager.MixerGroupEnum.INSTRUMENTS, reuseSfxs: false, playOnGamepad: false, _activeNotes[num]);
				}
				else
				{
					int sfxTableID = ((num >= 12) ? _noteSfx1 : _noteSfx0);
					float pitchMultiplier = ((num >= 12) ? _notePitch1 : _notePitch0)[num];
					AudioManager.Sfx(sfxTableID, position, 1f, pitchMultiplier, loop: false, freeAudioSourceAfterItStoppedPlaying: false, AudioManager.MixerGroupEnum.INSTRUMENTS, reuseSfxs: false, playOnGamepad: false, _activeNotes[num]);
				}
				if (_particleCount == 0)
				{
					_particleTimer = _particleTimerMax;
				}
				if (_particleCount < _particleCountMax)
				{
					Manager.effects.PlayPuff(PuffID.Note, position + PARTICLE_OFFSET, 1);
					Manager.effects.PlayPuff(PuffID.SmallAncientEnergy, position + PARTICLE_OFFSET, 2);
					_particleCount++;
				}
				_playerController.animator.SetTrigger(-1884439050);
				float elapsedTime = delayTimer.elapsedTime;
				UpdateStoredNotes(num, elapsedTime);
				MelodyID matchingMelodyID = GetMatchingMelodyID();
				if (matchingMelodyID != MelodyID.None)
				{
					Melody melody = MelodyData.melodies[(int)(matchingMelodyID - 1)];
					int scale = storedNotes[0] - melody[0];
					MelodyData.OnMelodyPlayed(matchingMelodyID, _playerController, scale, autoplay: false);
					ResetStoredNotes();
				}
			}
			else
			{
				if (key || _activeNotes[num].Count <= 0)
				{
					continue;
				}
				foreach (AudioManager.RunningSfxReference item2 in _activeNotes[num])
				{
					item2.FadeOutAndStop(0.2f);
				}
				_activeNotes[num].Clear();
			}
		}
		if (_particleTimer > 0)
		{
			_particleTimer--;
		}
		else
		{
			_particleCount = 0;
		}
		_previousPlayedNotes = playedNotes;
	}

	public void UpdateStoredNotes(int newNote, float newDelay)
	{
		int num = 0;
		for (int i = 0; i < storedNotes.Length - 1; i++)
		{
			storedNotes[i] = storedNotes[i + 1];
			storedDelays[i] = storedDelays[i + 1];
			num += storedNotes[i] * (int)math.pow(10f, 2 * i);
		}
		storedNotes[^1] = newNote;
		storedDelays[^1] = newDelay;
		delayTimer.Start();
	}

	public void ResetStoredNotes()
	{
		for (int i = 0; i < storedNotes.Length; i++)
		{
			storedNotes[i] = -1;
		}
		delayTimer.Stop();
	}

	public MelodyID GetMatchingMelodyID()
	{
		for (int i = 1; i <= MelodyData.melodies.Length; i++)
		{
			Melody melody = MelodyData.melodies[i - 1];
			int[] array = new int[melody.Length];
			for (int j = 0; j < melody.Length; j++)
			{
				int num = storedNotes[storedNotes.Length - 1 - j];
				int num2 = melody[melody.Length - 1 - j];
				array[j] = num - num2;
			}
			bool flag = false;
			for (int k = 0; k < melody.Length - 1; k++)
			{
				if (array[k] != array[k + 1])
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return melody.id;
			}
		}
		return MelodyID.None;
	}

	private void UpdatePlayedInstrument()
	{
		EquipmentSlot equippedSlot = _playerController.GetEquippedSlot();
		InstrumentType instrumentType = InstrumentType.None;
		if (PugDatabase.HasComponent<InstrumentCD>(equippedSlot.objectData.objectID))
		{
			instrumentType = PugDatabase.GetComponent<InstrumentCD>(equippedSlot.objectData.objectID).instrumentType;
		}
		if (instrumentType != _currentInstrumentTypePlayed)
		{
			_currentInstrumentTypePlayed = instrumentType;
			Debug.Log($"playing from music sheet {_currentSheetPlayed} with instrument {_currentInstrumentTypePlayed}");
			_playerController.playerCommandSystem.PlayMusicSheet(_playerController.entity, _currentSheetPlayed, _currentInstrumentTypePlayed);
		}
	}

	private void UpdatePlayingSheetMusic()
	{
		CollisionWorld collisionWorld = PhysicsManager.GetCollisionWorld();
		NativeList<DistanceHit> outHits = new NativeList<DistanceHit>(Allocator.TempJob);
		float num = 2.1474836E+09f;
		ObjectID objectID = ObjectID.None;
		Entity currentSheetStandBeingPlayedAt = Entity.Null;
		if (collisionWorld.OverlapSphere(_playerController.WorldPosition, 1.5f, ref outHits, SHEET_STAND_COLLISION_FILTER))
		{
			foreach (DistanceHit item in outHits)
			{
				Entity entity = item.Entity;
				if ((EntityUtility.HasComponentData<EntityDestroyedCD>(entity, World) && EntityUtility.IsComponentEnabled<EntityDestroyedCD>(entity, World)) || !EntityUtility.HasComponentData<ObjectDataCD>(entity, World) || !EntityUtility.HasComponentData<ContainedObjectsBuffer>(entity, World) || EntityUtility.GetComponentData<ObjectDataCD>(entity, World).objectID != ObjectID.MusicSheetStand)
				{
					continue;
				}
				DynamicBuffer<ContainedObjectsBuffer> buffer = EntityUtility.GetBuffer<ContainedObjectsBuffer>(entity, World);
				if (buffer.Length == 0 || buffer[0].objectData.objectID == ObjectID.None)
				{
					continue;
				}
				EntityMonoBehaviour entityMono = Manager.memory.GetEntityMono(entity);
				if (!(entityMono == null))
				{
					float num2 = math.distancesq(_playerController.RenderPosition, entityMono.RenderPosition);
					if (num2 < num)
					{
						objectID = buffer[0].objectData.objectID;
						num = num2;
						currentSheetStandBeingPlayedAt = entity;
					}
				}
			}
		}
		outHits.Dispose();
		if (objectID != _currentSheetPlayed)
		{
			_currentSheetPlayed = objectID;
			_currentInstrumentTypePlayed = InstrumentType.None;
		}
		_playerController.currentSheetStandBeingPlayedAt = currentSheetStandBeingPlayedAt;
	}
}
