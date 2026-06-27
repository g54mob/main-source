using System.Collections.Generic;
using SleepyNodes;
using UnityEngine;

public class ProgressionManager : MonoBehaviour
{
	private Dictionary<string, OperationState> operationStates;

	public static ProgressionManager Instance { get; private set; }

	public UserProgression UserProgression { get; private set; }

	public IReadOnlyDictionary<string, OperationState> OperationStates => null;

	public OperationState CurrentOperation { get; private set; }

	private string ProgressionPath => null;

	private string OperationsFolder => null;

	private void Awake()
	{
	}

	public void StartOperation(OperationGraph operation)
	{
	}

	public OperationState GetOperation(string id)
	{
		return null;
	}

	public void SaveAll()
	{
	}

	public void SaveProgression()
	{
	}

	public void SaveOperation(string operationId)
	{
	}

	public void LoadAll()
	{
	}

	private void LoadAllOperations()
	{
	}

	private string GetOperationPath(string operationId)
	{
		return null;
	}

	private void SaveToFile<T>(T data, string path)
	{
	}

	private T LoadFromFile<T>(string path)
	{
		return default(T);
	}

	private byte[] Compress(byte[] data)
	{
		return null;
	}

	private byte[] Decompress(byte[] data)
	{
		return null;
	}

	private byte[] Encrypt(byte[] data)
	{
		return null;
	}

	private byte[] Decrypt(byte[] data)
	{
		return null;
	}
}
