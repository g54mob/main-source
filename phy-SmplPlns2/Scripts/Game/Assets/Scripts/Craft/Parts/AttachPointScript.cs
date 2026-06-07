using System.Collections.Generic;
using Assets.Scripts.Design;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class AttachPointScript : MonoBehaviour
	{
		public class AttachPointEdge
		{
			public bool IsHardEdge { get; set; }

			public Vector3 LocalEdgeNormal { get; set; }

			public AttachPointEdge(Vector3 edgeNormal, bool isHardEdge)
			{
				LocalEdgeNormal = edgeNormal;
				IsHardEdge = isHardEdge;
			}
		}

		public const int AngledAttachPointLayer = 27;

		[SerializeField]
		private AttachPointData _attachPoint;

		private AttachPointGizmo _gizmo;

		public AttachPointData AttachPoint
		{
			get
			{
				return _attachPoint;
			}
			set
			{
				_attachPoint = value;
				if (_attachPoint != null)
				{
					Edges.Add(new AttachPointEdge(Vector3.up, AttachPoint.AdaptiveHardEdges[0]));
					Edges.Add(new AttachPointEdge(Vector3.right, AttachPoint.AdaptiveHardEdges[1]));
					Edges.Add(new AttachPointEdge(Vector3.down, AttachPoint.AdaptiveHardEdges[2]));
					Edges.Add(new AttachPointEdge(Vector3.left, AttachPoint.AdaptiveHardEdges[3]));
				}
			}
		}

		public List<AttachPointEdge> Edges { get; private set; }

		public int HardEdgeMask
		{
			get
			{
				if (Edges.Count == 4)
				{
					int num = 0;
					for (int i = 0; i < 4; i++)
					{
						if (Edges[i].IsHardEdge)
						{
							num |= 1 << i;
						}
					}
					return num;
				}
				return 0;
			}
		}

		public PartScript PartScript { get; set; }

		public bool SupportsDragging { get; set; }

		public Vector3 WorldNormal => base.transform.parent.TransformDirection(AttachPoint.Normal);

		public AttachPointScript()
		{
			Edges = new List<AttachPointEdge>();
		}

		public static AttachPointScript GetAttachPointFromCollider(Collider collider)
		{
			if (collider.TryGetComponent<AttachPointScript>(out var component))
			{
				return component;
			}
			if (collider.TryGetComponent<AttachPointProxyScript>(out var component2))
			{
				return component2.AttachPointScript;
			}
			return null;
		}

		public static bool TryGetAttachPointFromCollider(Collider collider, out AttachPointScript result)
		{
			if (collider.TryGetComponent<AttachPointScript>(out result))
			{
				return true;
			}
			if (collider.TryGetComponent<AttachPointProxyScript>(out var component))
			{
				result = component.AttachPointScript;
				return result != null;
			}
			result = null;
			return false;
		}

		public void RefreshGizmos()
		{
			if (_gizmo != null)
			{
				bool activeSelf = _gizmo.gameObject.activeSelf;
				Object.Destroy(_gizmo.gameObject);
				_gizmo = null;
				ShowGizmo(activeSelf);
			}
		}

		public void ShowGizmo(bool show)
		{
			if (show)
			{
				if (_gizmo == null)
				{
					bool flag = false;
					GameObject original;
					if (AttachPoint.ReceiveType.HasFlag(AttachPointConnectionType.PowertrainInput))
					{
						flag = true;
						original = ((!AttachPoint.ReceiveType.HasFlag(AttachPointConnectionType.PowertrainOutput)) ? Resources.Load<GameObject>("Designer/AttachPointGizmoFemale") : Resources.Load<GameObject>("Designer/AttachPointGizmoDual"));
					}
					else if (!AttachPoint.ReceiveType.HasFlag(AttachPointConnectionType.PowertrainOutput))
					{
						original = ((!AttachPoint.AllowRotation) ? Resources.Load<GameObject>("Designer/AttachPointGizmo") : Resources.Load<GameObject>("Designer/AttachPointGizmoCube"));
					}
					else
					{
						flag = true;
						original = Resources.Load<GameObject>("Designer/AttachPointGizmoMale");
					}
					GameObject gameObject = Object.Instantiate(original);
					gameObject.transform.SetParent(base.transform, worldPositionStays: false);
					gameObject.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
					if (Game.Instance.Device.IsTouchEnabled)
					{
						gameObject.transform.localScale *= 1.5f;
					}
					_gizmo = gameObject.GetComponent<AttachPointGizmo>();
					_gizmo.NormalColor = (flag ? Constants.Colors.WarningColor : Constants.Colors.PrimaryLight);
					_gizmo.AttachPoint = AttachPoint;
				}
				_gizmo.gameObject.SetActive(value: true);
			}
			else if (_gizmo != null)
			{
				_gizmo.gameObject.SetActive(value: false);
			}
		}
	}
}
