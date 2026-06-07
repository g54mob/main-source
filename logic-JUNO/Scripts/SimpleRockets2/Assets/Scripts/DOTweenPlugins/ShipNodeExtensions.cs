using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Sim;
using DG.Tweening;
using ModApi.Flight.GameView;
using UnityEngine;

namespace Assets.Scripts.DOTweenPlugins
{
	public static class ShipNodeExtensions
	{
		public static Tweener DOMove(this ShipNode shipNode, Vector3d endPosition, float duration)
		{
			return shipNode.DOMove(shipNode.Position, endPosition, duration);
		}

		public static Tweener DOMove(this ShipNode shipNode, Vector3d startPosition, Vector3d endPosition, float duration)
		{
			IReferenceFrame referenceFrame = FlightSceneScript.Instance.ViewManager.GameView.ReferenceFrame;
			return DOTween.To(Vector3dPlugin.Instance, () => shipNode.Position, delegate(Vector3d x)
			{
				shipNode.SetStateVectorsAtDefaultTime(x, OrbitNode.MinimumOrbitVelocity);
				shipNode.RecalculateFrameState(referenceFrame);
			}, endPosition, duration);
		}
	}
}
