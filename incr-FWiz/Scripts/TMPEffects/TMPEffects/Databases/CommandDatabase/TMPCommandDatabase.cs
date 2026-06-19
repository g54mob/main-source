using TMPEffects.SerializedCollections;
using TMPEffects.TMPCommands;
using UnityEngine;

namespace TMPEffects.Databases.CommandDatabase
{
	[CreateAssetMenu(fileName = "new TMPCommandDatabase", menuName = "TMPEffects/Database/Command Database", order = 30)]
	public class TMPCommandDatabase : TMPEffectDatabase<TMPCommand>
	{
		[SerializeField]
		private SerializedDictionary<string, TMPCommand> commands;

		public override bool ContainsEffect(string name)
		{
			return false;
		}

		public override TMPCommand GetEffect(string name)
		{
			return null;
		}
	}
}
