using CTS.Core;
using UnityEngine;

namespace CTS
{
	[DefaultExecutionOrder(-10)]
	[Constructor("Construct")]
	public class AgentCollider : CTSBehaviour
	{
		[SerializeField]
		private Transform _headBone;

		private LockToggle _selectionToggle;

		public CapsuleCollider InterCollider { get; private set; }

		public SelectableObject SelectableObject { get; private set; }

		public CapsuleCollider Collider { get; private set; }

		[field: InjectScope(EGetScope.Children)]
		[field: Inject(false)]
		public OutlineRendererCollection OutlineRenderers { get; }

		public bool Selectable
		{
			get
			{
				return SelectableObject.Selectable;
			}
			set
			{
				_selectionToggle.SetLock(!value);
			}
		}

		private void Construct([InjectScope(EGetScope.Children)] CapsuleCollider collider, SelectableObject selectableObject)
		{
			Collider = collider;
			InterCollider = Collider.transform.GetChild(0).GetComponent<CapsuleCollider>();
			SelectableObject = selectableObject;
			_selectionToggle = new LockToggle(SelectableObject);
		}

		protected override void OnAwake()
		{
			base.OnAwake();
			base.enabled = _headBone != null;
		}

		private void LateUpdate()
		{
			Vector3 vector = _headBone.position - base.transform.position;
			Collider.transform.SetPositionAndRotation(base.transform.position + vector * 0.5f, Quaternion.LookRotation(vector.normalized));
			Collider.height = vector.magnitude;
		}

		public void SetHeadBoneFormReferenceDispatcher(Transform headBone)
		{
			_headBone = headBone;
			base.enabled = _headBone != null;
		}
	}
}
