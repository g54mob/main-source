using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Title("Axonometry Type")]
	public interface IAxonometry : ICloneable
	{
		Vector3 ProcessTranslation(TUnitDriver driver, Vector3 movement);

		void ProcessPosition(TUnitDriver driver, Vector3 position);

		Vector3 ProcessRotation(TUnitFacing facing, Vector3 direction);
	}
}
