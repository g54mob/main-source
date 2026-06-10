using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bas Boule Team Name", menuName = "Database/Base Boule/Base Boule Team")]
public class BasebouleTeam : ScriptableObject
{
	public string teamName;

	public string teamIntroductionWhenFirstInLineUp;

	public string teamIntroductionWhenSecondInLineUp;

	public List<BaseboulePlayer> roster;
}
