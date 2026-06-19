using AssembleSystem.Utils;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityHFSM;

namespace AssembleSystem.FSM.ParentObject.States
{
	public class AssembleParentReadyToBePlacedState : StateBase<StateIdentifier>
	{
		private readonly AssembleObjectParent _parent;

		private GameObject _ghost;

		private Material _transparentMaterial;

		public AssembleParentReadyToBePlacedState(AssembleObjectParent parent, bool needsExitTime, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
			_parent = parent;
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
		}

		private void CreateGhostParent()
		{
			_ghost = new GameObject("GhostParent");
			_ghost.transform.SetParent(_parent.transform, worldPositionStays: true);
			_ghost.transform.localPosition = Vector3.zero;
			_ghost.transform.localRotation = Quaternion.identity;
			_ghost.transform.localScale = Vector3.one;
			for (int i = 0; i < _parent.Parts.Count; i++)
			{
				GameObject gameObject = _parent.Parts[i];
				PartObject component = gameObject.GetComponent<PartObject>();
				if (!(component == null))
				{
					GameObject gameObject2 = CreateGhostMesh(gameObject.gameObject, component);
					if (!(gameObject2 == null))
					{
						PartConfig config = component.Config;
						Vector3 lossyScale = gameObject.transform.lossyScale;
						gameObject2.transform.SetParent(_ghost.transform, worldPositionStays: true);
						gameObject2.transform.localPosition = config.AssembledPosition;
						gameObject2.transform.localRotation = config.AssembledRotation;
						gameObject2.transform.localScale = new Vector3(lossyScale.x / _parent.transform.lossyScale.x, lossyScale.y / _parent.transform.lossyScale.y, lossyScale.z / _parent.transform.lossyScale.z);
						gameObject2.layer = LayerMask.NameToLayer("Ignore Raycast");
						gameObject2.SetActive(value: true);
					}
				}
			}
		}

		private GameObject CreateGhostMesh(GameObject source, PartObject partObject)
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
			foreach (GameObject part in _parent.Parts)
			{
				part.transform.parent = null;
			}
		}

		public override void OnExit()
		{
			if (_ghost != null)
			{
				Object.Destroy(_ghost.gameObject);
			}
			base.OnExit();
		}

		public override void OnLogic()
		{
			_parent.transform.SetPositionAndRotation(_parent.TestMovingPoint.position + _parent.Offset, _parent.TestMovingPoint.rotation);
			base.OnLogic();
		}
	}
}
