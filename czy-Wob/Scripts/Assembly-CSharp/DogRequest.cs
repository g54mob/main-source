using System.Collections.Generic;
using UnityEngine;

public class DogRequest
{
	public delegate void DogRequestCallback(GameObject newDog);

	public delegate void DogRequestCallbackUlongArg(GameObject newDog, ulong optionalUlong);

	private DogRequestCallback _callback;

	private SaveableDogGene _dogGene;

	private Vector3 _pos;

	private bool _dummyDog;

	private Quaternion _rot;

	private bool _manualDog;

	private bool _timeslice;

	private bool _playerOwned;

	private SaveableDog _existingDog;

	private bool _forceCacheThumbnails;

	private SaveableDogProfile _dogProfile;

	private bool _useBaseGeneWithoutMutation;

	private DogAge _customDogAge;

	private float _customDogAgeProgress;

	private float? _customEndOfLifeModifier;

	private float? _customLifeExtension;

	private bool _customEmptyGut;

	private List<string> _customFloraPool;

	private bool _traitsAllowed;

	private bool _useTemporaryID;

	private bool _spawnDuringPause;

	private bool _isGhost;

	private SaveableDogPersonality _customDogPersonality;

	public DogRequest(Vector3 pos, Quaternion rot, SaveableDogGene gene = null, SaveableDog existingDog = null, bool manualDog = false, DogRequestCallback requestCallback = null, bool playerOwned = true, bool useBaseGeneWithoutMutation = false, bool timeslice = true, bool forceCacheThumbnails = false, bool dummyDog = false, SaveableDogProfile dogProfile = null, DogAge customDogAge = DogAge.NONE, float customDogAgeProgress = -1f, bool traitsAllowed = true, bool useTemporaryID = false, SaveableDogPersonality customDogPersonality = null, List<string> customFloraPool = null, bool isGhost = false, float? customEndOfLifeModifier = null, float? customLifeExtension = null, bool spawnDuringPause = true, bool customEmptyGut = false)
	{
		_dogGene = gene;
		_pos = pos;
		_rot = rot;
		_isGhost = isGhost;
		_dummyDog = dummyDog;
		_manualDog = manualDog;
		_timeslice = timeslice;
		_customDogAge = customDogAge;
		_customLifeExtension = customLifeExtension;
		_customDogAgeProgress = customDogAgeProgress;
		_customEndOfLifeModifier = customEndOfLifeModifier;
		_dogProfile = dogProfile;
		_playerOwned = playerOwned;
		_existingDog = existingDog;
		_forceCacheThumbnails = forceCacheThumbnails;
		_useBaseGeneWithoutMutation = useBaseGeneWithoutMutation;
		_traitsAllowed = traitsAllowed;
		_useTemporaryID = useTemporaryID;
		_customDogPersonality = customDogPersonality;
		_customFloraPool = customFloraPool;
		_customEmptyGut = customEmptyGut;
		_spawnDuringPause = spawnDuringPause;
		_callback = requestCallback;
	}

	public Vector3 GetPos()
	{
		return _pos;
	}

	public Quaternion GetRot()
	{
		return _rot;
	}

	public SaveableDogGene GetGene()
	{
		return _dogGene;
	}

	public bool GetDummyDog()
	{
		return _dummyDog;
	}

	public bool GetIsGhost()
	{
		return _isGhost;
	}

	public DogAge GetCustomDogAge()
	{
		return _customDogAge;
	}

	public float GetCustomDogAgeProgress()
	{
		return _customDogAgeProgress;
	}

	public float? GetCustomEndOfLifeModifier()
	{
		return _customEndOfLifeModifier;
	}

	public float? GetCustomLifeExtension()
	{
		return _customLifeExtension;
	}

	public bool GetForceCacheThumbnails()
	{
		return _forceCacheThumbnails;
	}

	public SaveableDogProfile GetDogProfile()
	{
		return _dogProfile;
	}

	public SaveableDog GetExistingDog()
	{
		return _existingDog;
	}

	public bool GetTraitsAllowed()
	{
		return _traitsAllowed;
	}

	public bool GetUseTemporaryID()
	{
		return _useTemporaryID;
	}

	public SaveableDogPersonality GetDogPersonality()
	{
		return _customDogPersonality;
	}

	public bool IsManual()
	{
		return _manualDog;
	}

	public bool Timeslice()
	{
		return _timeslice;
	}

	public bool IsPlayerOwned()
	{
		return _playerOwned;
	}

	public DogRequestCallback GetCallback()
	{
		return _callback;
	}

	public bool GetUseBaseGeneWithoutMutation()
	{
		return _useBaseGeneWithoutMutation;
	}

	public List<string> GetCustomFloraPool()
	{
		return _customFloraPool;
	}

	public bool GetCustomEmptyGut()
	{
		return _customEmptyGut;
	}

	public bool GetSpawnDuringPause()
	{
		return _spawnDuringPause;
	}
}
