using UnityEngine;

namespace NSMedieval.Construction
{
	public interface IBeamView
	{
		Transform Transform { get; }

		void SetupPositionAndScale(Vector3 rightOffset, Vector3 leftOffset, Vector3 scale);
	}
}
