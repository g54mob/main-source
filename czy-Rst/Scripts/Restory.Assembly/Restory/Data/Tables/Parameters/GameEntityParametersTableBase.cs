using Restory.Data.Tables.Abstracts;
using UnityEngine;

namespace Restory.Data.Tables.Parameters
{
	public abstract class GameEntityParametersTableBase : GameEntityTableBase, IGameParametersEntity
	{
		[SerializeField]
		[TextArea(1, 10)]
		private string description;
	}
}
