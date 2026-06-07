using System.Text;
using DV.UserManagement.Integration;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Key provider")]
public class DVKeyProvider : AKeyProvider
{
	private static readonly byte[] Key = Encoding.UTF8.GetBytes("WeDidntSecureThisVeryWell!!1");

	public override byte[] GetKeyFor(int uid, string name, string signature)
	{
		return Key;
	}
}
