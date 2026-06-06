using UnityEngine;

namespace PajamaLlama.Flotsam.World
{
	public interface ILandmarkEditor : IWorldEditorWindow
	{
		void AddLandmark(ILandmarkBehaviourProvider landmarkBehaviourProvider, Vector2 position);

		void RemoveLandmarksInRegion(IRegion region);
	}
}
