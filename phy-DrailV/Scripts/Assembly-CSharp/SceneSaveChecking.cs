using System.Collections.Generic;
using UnityEngine;

public static class SceneSaveChecking
{
	public abstract class AComponentChecker : MonoBehaviour
	{
		public abstract bool Check(string scenePath, string objectPath);
	}

	private static HashSet<AComponentChecker> componentsToCheck = new HashSet<AComponentChecker>();

	public static void Register(AComponentChecker checker)
	{
		componentsToCheck.Add(checker);
	}

	public static void Unregister(AComponentChecker checker)
	{
		componentsToCheck.Remove(checker);
	}
}
