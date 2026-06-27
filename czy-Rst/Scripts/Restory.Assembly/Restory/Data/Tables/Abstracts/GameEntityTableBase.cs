using Restory.Data.Base;
using UnityEngine;

namespace Restory.Data.Tables.Abstracts
{
	public abstract class GameEntityTableBase : ScriptableObject, IGameEntityTable
	{
		public abstract bool Contains(RestoryEntityInfoBase entity);
	}
}
