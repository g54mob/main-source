using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Title("Player")]
	public interface IUnitPlayer : IUnitCommon
	{
		bool IsControllable { get; set; }

		Vector3 LocalInputDirection { get; }

		Vector3 InputDirection { get; }
	}
}
