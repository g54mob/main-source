using ModApi.Settings;
using UnityEngine;

namespace Assets.Scripts.Tools.Fracturing
{
	public interface IFracturePieceProcessor
	{
		void ProcessPiece(GameObject fracturePiece, Vector3? colliderWorldCenter);

		void SetQuality(ExplosionsQualitySettings explosionQuality);
	}
}
