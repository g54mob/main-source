using UnityEngine;

namespace MG_BlocksEngine2.Block
{
	public interface I_BE2_BlockSectionHeaderInput
	{
		Transform Transform { get; }

		I_BE2_Spot Spot { get; }

		float FloatValue { get; }

		string StringValue { get; }

		BE2_InputValues InputValues { get; }

		void UpdateValues();
	}
}
