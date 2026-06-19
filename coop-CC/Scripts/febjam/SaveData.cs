using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Newtonsoft.Json;
using Unity.Mathematics;

public class SaveData
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct CostumeData
	{
	}

	private struct ContractData
	{
		public int bells;

		public ContractScore score;

		public int milliseconds;
	}

	private struct TipTapData
	{
		public bool seen;

		public bool shared;

		public bool liked;
	}

	[JsonProperty]
	private ulong _version;

	[JsonProperty]
	private int _colorIndex;

	[JsonProperty]
	private string _currentCostume;

	[JsonProperty]
	private int _saveVersion = 1;

	[JsonProperty]
	private int _contractCount;

	[JsonProperty]
	private string _lastContractPlayed;

	[JsonProperty]
	private Dictionary<string, ContractData> _contracts = new Dictionary<string, ContractData>();

	[JsonProperty]
	private Dictionary<string, CostumeData> _costumes = new Dictionary<string, CostumeData>();

	[JsonProperty]
	private Dictionary<string, TipTapData> _tipTaps = new Dictionary<string, TipTapData>();

	[JsonProperty]
	private bool _debugUnlock;

	private static List<ContractObject> _contractObjects = new List<ContractObject>();

	public const int SAVE_VERSION = 1;

	public ulong GetVersion()
	{
		return _version;
	}

	public int GetSaveVersion()
	{
		return _saveVersion;
	}

	public int GetColorIndex()
	{
		return _colorIndex;
	}

	public void SetColorIndex(int index)
	{
		_version++;
		_colorIndex = index;
	}

	public int GetContractCount()
	{
		return _contractCount;
	}

	public void IncrementContractCount()
	{
		_version++;
		_contractCount++;
	}

	public bool TryGetLastPlayedContract(out ContractObject contract)
	{
		if (string.IsNullOrEmpty(_lastContractPlayed))
		{
			contract = null;
			return false;
		}
		_contractObjects.Clear();
		GameManager.GetAllContracts(_contractObjects);
		for (int i = 0; i < _contractObjects.Count; i++)
		{
			ContractObject contractObject = _contractObjects[i];
			if (contractObject.name == _lastContractPlayed)
			{
				contract = contractObject;
				return true;
			}
		}
		contract = null;
		return false;
	}

	public void SetLastPlayedContract(ContractObject contract)
	{
		_version++;
		if ((object)contract == null)
		{
			_lastContractPlayed = "";
		}
		else
		{
			_lastContractPlayed = contract.name;
		}
	}

	public bool HasBeatenContract(ContractObject contract)
	{
		if (TryGetContractBellCount(contract, out var bells))
		{
			return bells >= 5;
		}
		return false;
	}

	public int GetTotalBells()
	{
		int num = 0;
		foreach (ContractData value in _contracts.Values)
		{
			num += value.bells;
		}
		return num;
	}

	public void ClearContracts()
	{
		_version++;
		_contracts.Clear();
	}

	public void SetContractBellCount(ContractObject contract, int bellCount)
	{
		_version++;
		_contracts.TryGetValue(contract.name, out var value);
		value.bells = bellCount;
		_contracts[contract.name] = value;
	}

	public void SetContractBellCountIfHigher(ContractObject contract, int bellCount)
	{
		_version++;
		_contracts.TryGetValue(contract.name, out var value);
		value.bells = math.max(value.bells, bellCount);
		_contracts[contract.name] = value;
	}

	public bool TryGetContractBellCount(ContractObject contract, out int bells)
	{
		if (_contracts.TryGetValue(contract.name, out var value))
		{
			bells = value.bells;
			return true;
		}
		bells = 0;
		return false;
	}

	public void SetContractScoreIfHigher(ContractObject contract, ContractScore score)
	{
		_version++;
		_contracts.TryGetValue(contract.name, out var value);
		value.score = (ContractScore)math.max((int)value.score, (int)score);
		_contracts[contract.name] = value;
	}

	public void SetContractScore(ContractObject contract, ContractScore score)
	{
		_version++;
		_contracts.TryGetValue(contract.name, out var value);
		value.score = score;
		_contracts[contract.name] = value;
	}

	public bool TryGetContractTime(ContractObject contract, out int milliseconds)
	{
		if (_contracts.TryGetValue(contract.name, out var value))
		{
			milliseconds = value.milliseconds;
			return true;
		}
		milliseconds = 0;
		return false;
	}

	public bool TryGetContractTime(ContractObject contract, out TimeSpan timeSpan)
	{
		if (TryGetContractTime(contract, out int milliseconds))
		{
			timeSpan = TimeSpan.FromMilliseconds(milliseconds);
			return true;
		}
		timeSpan = TimeSpan.Zero;
		return false;
	}

	public void SetContractTimeIfHigher(ContractObject contract, int milliseconds)
	{
		_version++;
		_contracts.TryGetValue(contract.name, out var value);
		value.milliseconds = math.max(value.milliseconds, milliseconds);
		_contracts[contract.name] = value;
	}

	public void SetContractTime(ContractObject contract, int milliseconds)
	{
		_version++;
		_contracts.TryGetValue(contract.name, out var value);
		value.milliseconds = milliseconds;
		_contracts[contract.name] = value;
	}

	public bool TryGetContractScore(ContractObject contract, out ContractScore score)
	{
		if (_contracts.TryGetValue(contract.name, out var value) && value.bells >= 5)
		{
			score = value.score;
			return true;
		}
		score = ContractScore.D;
		return false;
	}

	public bool IsCostumeUnlocked(CostumeObject costume)
	{
		if ((object)costume == null)
		{
			return false;
		}
		if (SaveManager.data.IsDebugUnlocked())
		{
			return true;
		}
		return _costumes.ContainsKey(costume.name);
	}

	public void UnlockCostume(CostumeObject costume)
	{
		_version++;
		if (!_costumes.ContainsKey(costume.name))
		{
			_costumes[costume.name] = default(CostumeData);
		}
	}

	public void SetCurrentCostume(CostumeObject costume)
	{
		_version++;
		_currentCostume = costume.name;
	}

	public bool TryGetCurrentCostume(out CostumeObject costume)
	{
		if (string.IsNullOrWhiteSpace(_currentCostume))
		{
			costume = null;
			return false;
		}
		CostumeObject[] costumes = GlobalScriptableObject<CosmeticGlobalData>.instance.costumes;
		foreach (CostumeObject costumeObject in costumes)
		{
			if ((object)costumeObject != null && costumeObject.name == _currentCostume)
			{
				costume = costumeObject;
				return true;
			}
		}
		costume = null;
		return false;
	}

	public CostumeObject[] GetUnlockedCostumes()
	{
		List<CostumeObject> list = new List<CostumeObject>();
		GetUnlockedCostumes(list);
		return list.ToArray();
	}

	public void GetUnlockedCostumes(List<CostumeObject> list)
	{
		CostumeObject[] costumes = GlobalScriptableObject<CosmeticGlobalData>.instance.costumes;
		foreach (CostumeObject costumeObject in costumes)
		{
			if (IsCostumeUnlocked(costumeObject))
			{
				list.Add(costumeObject);
			}
		}
	}

	public void TipTapSeen(TipTapObject tipTap)
	{
		_version++;
		_tipTaps.TryGetValue(tipTap.name, out var value);
		value.seen = true;
		_tipTaps[tipTap.name] = value;
	}

	public void TipTapShared(TipTapObject tipTap)
	{
		_version++;
		_tipTaps.TryGetValue(tipTap.name, out var value);
		value.shared = true;
		_tipTaps[tipTap.name] = value;
	}

	public void TipTapLiked(TipTapObject tipTap)
	{
		_version++;
		_tipTaps.TryGetValue(tipTap.name, out var value);
		value.liked = true;
		_tipTaps[tipTap.name] = value;
	}

	public bool IsTipTapLiked(TipTapObject tipTap)
	{
		if (_tipTaps.TryGetValue(tipTap.name, out var value))
		{
			return value.liked;
		}
		return false;
	}

	public bool IsTipTapSeen(TipTapObject tipTap)
	{
		if (_tipTaps.TryGetValue(tipTap.name, out var value))
		{
			return value.seen;
		}
		return false;
	}

	public bool IsTipTapShared(TipTapObject tipTap)
	{
		if (_tipTaps.TryGetValue(tipTap.name, out var value))
		{
			return value.shared;
		}
		return false;
	}

	public void DebugUnlock()
	{
		_version++;
		_debugUnlock = true;
	}

	public bool IsDebugUnlocked()
	{
		return false;
	}
}
