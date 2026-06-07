using System.Collections.Generic;
using UnityEngine;

public class ExampleDesigns : MonoBehaviour
{
	private static ExampleDesigns inst;

	public List<FileOperations.SaveData> saveDatas;

	public static List<FileOperations.SaveData> ExampleDatas => null;

	private void Awake()
	{
	}

	public static void AddCurrent()
	{
	}
}
