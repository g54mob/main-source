using FishNet.Managing.Predicting;
using FishNet.Object;
using UnityEngine;

namespace FishNet.Component.Prediction
{
	public class OfflineRigidbody : MonoBehaviour
	{
		[Tooltip("Type of prediction movement which is being used.")]
		[SerializeField]
		private RigidbodyType _rigidbodyType;

		private Transform _graphicalObject;

		[SerializeField]
		[Tooltip("True to also get rigidbody components within children.")]
		private bool _getInChildren;

		private RigidbodyPauser _rigidbodyPauser;

		private PredictionManager _predictionManager;

		public void SetGraphicalObject(Transform value)
		{
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void InitializeOnce()
		{
		}

		public void SetPredictionManager(PredictionManager pm)
		{
		}

		public void UpdateRigidbodies()
		{
		}

		private void ChangeSubscription(bool subscribe)
		{
		}

		private void _predictionManager_OnPreReconcile(NetworkBehaviour obj)
		{
		}

		private void _predictionManager_OnPostReconcile(NetworkBehaviour obj)
		{
		}
	}
}
