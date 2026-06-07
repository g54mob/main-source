using DV.UserManagement;
using DV.UserManagement.Storage;
using UnityEngine;

public abstract class APreLoadUpgrader : ScriptableObject
{
	public int InputVersion { get; }

	public abstract void ProcessData(UserManager manager, IStorageProvider storage);
}
