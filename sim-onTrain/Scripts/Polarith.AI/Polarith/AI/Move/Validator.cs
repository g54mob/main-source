using UnityEngine;

namespace Polarith.AI.Move
{
	public abstract class Validator
	{
		[Tooltip("Determines if this 'Validator' instance is enabled.")]
		public bool Enabled;

		public abstract bool Validate();
	}
}
