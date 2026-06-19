using AssembleSystem.Utils;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityHFSM;

namespace AssembleSystem.FSM.PlacedObject
{
	public class PlacedParentReadyToBePlacedState : StateBase<StateIdentifier>
	{
		private readonly PlacedObjectStateMachine _fsm;

		private GameObject _ghost;

		private Material _transparentMaterial;

		public PlacedParentReadyToBePlacedState(PlacedObjectStateMachine sm, bool needsExitTime, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
			_fsm = sm;
			AsyncOperationHandle<Material> asyncOperationHandle = Addressables.LoadAssetAsync<Material>("Materials/TransparentGreen");
			asyncOperationHandle.Completed += delegate(AsyncOperationHandle<Material> res)
			{
				_transparentMaterial = res.Result;
			};
		}

		public override void OnEnter()
		{
			CreateGhostParent();
			ClearParentInParts();
			if (_fsm.PlacedParent == null)
			{
				_fsm.transform.position = _fsm.PlacedPosition;
				_fsm.transform.rotation = _fsm.PlacedRotation;
			}
			else
			{
				_fsm.transform.SetParent(_fsm.PlacedParent, worldPositionStays: false);
				_fsm.transform.localPosition = _fsm.PlacedPosition;
				_fsm.transform.localRotation = _fsm.PlacedRotation;
			}
		}

		private void CreateGhostParent()
		{
			_ghost = new GameObject("GhostParent");
			_ghost.transform.SetParent(_fsm.transform, worldPositionStays: true);
			_ghost.transform.localPosition = Vector3.zero;
			_ghost.transform.localRotation = Quaternion.identity;
			_ghost.transform.localScale = Vector3.one;
			for (int i = 0; i < _fsm.RootAssemble.Parts.Count; i++)
			{
				GameObject gameObject = _fsm.RootAssemble.Parts[i];
				PartObject component = gameObject.GetComponent<PartObject>();
				if (!(component == null))
				{
					GameObject gameObject2 = CreateGhostMesh(gameObject.gameObject);
					if (!(gameObject2 == null))
					{
						PartConfig config = component.Config;
						Vector3 lossyScale = gameObject.transform.lossyScale;
						gameObject2.transform.SetParent(_ghost.transform, worldPositionStays: true);
						gameObject2.transform.localPosition = config.AssembledPosition;
						gameObject2.transform.localRotation = config.AssembledRotation;
						gameObject2.transform.localScale = new Vector3(lossyScale.x / _fsm.RootAssemble.transform.lossyScale.x, lossyScale.y / _fsm.RootAssemble.transform.lossyScale.y, lossyScale.z / _fsm.RootAssemble.transform.lossyScale.z);
						gameObject2.SetActive(value: true);
					}
				}
			}
		}

		private GameObject CreateGhostMesh(GameObject source)
		{
			GameObject gameObject = new GameObject("GhostPart_" + source.name);
			MeshFilter component = source.GetComponent<MeshFilter>();
			if (component != null)
			{
				gameObject.AddComponent<MeshFilter>().sharedMesh = component.sharedMesh;
			}
			MeshRenderer component2 = source.GetComponent<MeshRenderer>();
			if (component2 != null)
			{
				MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
				meshRenderer.sharedMaterials = component2.sharedMaterials;
				meshRenderer.material = _transparentMaterial;
			}
			gameObject.SetActive(value: false);
			return gameObject;
		}

		private void ClearParentInParts()
		{
			foreach (GameObject part in _fsm.RootAssemble.Parts)
			{
				part.transform.parent = null;
			}
		}

		public override void OnExit()
		{
			Object.Destroy(_ghost.gameObject);
			base.OnExit();
		}

		public override void OnLogic()
		{
			base.OnLogic();
		}
	}
}
