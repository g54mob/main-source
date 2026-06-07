using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enum/Enum")]
public class ScriptableEnum : ScriptableBaseEnum
{
	public List<string> entries = new List<string>();

	public override List<string> Entries => entries;
}
