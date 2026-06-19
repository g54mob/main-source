using System.Collections.Generic;
using Loxodon.Framework.Contexts;
using UI.HUD;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityHFSM;

namespace AssembleSystem.FSM.Parts.States
{
	public class PartObjectReadyToBePlacedState : StateBase<StateIdentifier>
	{
		private PartObject _part;

		private AssembleObjectParent _assembleParent;

		private Material _greenTransparent;

		private GameObject _ghostObject;

		private List<Collider> _otherPartsColliders = new List<Collider>();

		protected Collider _partCollider;

		protected InfoCursorsViewModel _infoCursorsViewModel;

		private readonly LayerMask _originalLayerMask;

		public PartObjectReadyToBePlacedState(AssembleObjectParent assembleObjectParent, PartObject part, bool needsExitTime, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
			_infoCursorsViewModel = Context.GetApplicationContext().GetService<InfoCursorsViewModel>();
			_assembleParent = assembleObjectParent;
			_part = part;
			_originalLayerMask = _part.gameObject.layer;
			_partCollider = part.GetComponent<Collider>();
			AsyncOperationHandle<Material> asyncOperationHandle = Addressables.LoadAssetAsync<Material>("Materials/TransparentGreen");
			asyncOperationHandle.Completed += delegate(AsyncOperationHandle<Material> res)
			{
				_greenTransparent = res.Result;
			};
			foreach (GameObject part2 in _assembleParent.Parts)
			{
				Collider component = part2.GetComponent<Collider>();
				if (component != null)
				{
					_otherPartsColliders.Add(component);
				}
			}
		}

		public override void OnEnter()
		{
			_ghostObject = CreateGhostMesh(_part);
			_ghostObject.transform.SetParent(_part.AssembleParent.transform, worldPositionStays: false);
			_ghostObject.transform.localPosition = _part.Config.AssembledPosition;
			_ghostObject.transform.localRotation = _part.Config.AssembledRotation;
			Vector3 lossyScale = _part.transform.lossyScale;
			Vector3 lossyScale2 = _part.AssembleParent.transform.lossyScale;
			_ghostObject.transform.localScale = new Vector3(lossyScale.x / lossyScale2.x, lossyScale.y / lossyScale2.y, lossyScale.z / lossyScale2.z);
			EnableCollisionBetweenThisPart(value: false);
			_part.gameObject.layer = 28;
			_ghostObject.SetActive(value: true);
		}

		public override void OnExit()
		{
			EnableCollisionBetweenThisPart(value: true);
			_part.gameObject.layer = _originalLayerMask;
			Object.Destroy(_ghostObject);
			_part.StateMachine.IsInRangeOfTempPart = false;
			_infoCursorsViewModel.TickEnabled = false;
			base.OnExit();
		}

		public override void OnLogic()
		{
			if (_ghostObject != null)
			{
				Renderer component = _part.GetComponent<Renderer>();
				Renderer component2 = _ghostObject.GetComponent<Renderer>();
				Vector3 a = ((component != null) ? component.bounds.center : _part.transform.position);
				Vector3 b = ((component2 != null) ? component2.bounds.center : _ghostObject.transform.position);
				if (Vector3.Distance(a, b) <= 1f)
				{
					_infoCursorsViewModel.TickEnabled = true;
					_part.StateMachine.IsInRangeOfTempPart = true;
				}
				else
				{
					_infoCursorsViewModel.TickEnabled = false;
					_part.StateMachine.IsInRangeOfTempPart = false;
				}
			}
		}

		private GameObject CreateGhostMesh(PartObject source)
		{
			GameObject gameObject = new GameObject("GhostMesh_" + source.name);
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
				meshRenderer.material = _greenTransparent;
			}
			gameObject.SetActive(value: false);
			return gameObject;
		}

		private void EnableCollisionBetweenThisPart(bool value)
		{
			foreach (Collider otherPartsCollider in _otherPartsColliders)
			{
				Physics.IgnoreCollision(otherPartsCollider, _partCollider, !value);
			}
		}
	}
}
