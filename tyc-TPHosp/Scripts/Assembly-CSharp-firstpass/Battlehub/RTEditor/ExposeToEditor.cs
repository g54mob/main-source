using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Battlehub.RTEditor
{
	[DisallowMultipleComponent]
	public class ExposeToEditor : MonoBehaviour
	{
		public bool AddColliders;

		public bool DisableOnAwake;

		private bool m_applicationQuit;

		private Collider[] m_colliders;

		private HierarchyItem m_hierarchyItem;

		private List<ExposeToEditor> m_children = new List<ExposeToEditor>();

		private ExposeToEditor m_parent;

		public int ChildCount => m_children.Count;

		public ExposeToEditor Parent
		{
			get
			{
				return m_parent;
			}
			set
			{
				if (m_parent != value)
				{
					ExposeToEditor parent = m_parent;
					m_parent = value;
					if (parent != null)
					{
						parent.m_children.Remove(this);
					}
					if (m_parent != null)
					{
						m_parent.m_children.Add(this);
					}
					if (ExposeToEditor.ParentChanged != null)
					{
						ExposeToEditor.ParentChanged(this, parent, m_parent);
					}
				}
			}
		}

		public static event ExposeToEditorEvent NameChanged;

		public static event ExposeToEditorEvent TransformChanged;

		public static event ExposeToEditorEvent Awaked;

		public static event ExposeToEditorEvent Started;

		public static event ExposeToEditorEvent Enabled;

		public static event ExposeToEditorEvent Disabled;

		public static event ExposeToEditorEvent Destroyed;

		public static event ExposeToEditorChangeEvent<ExposeToEditor> ParentChanged;

		public ExposeToEditor GetChild(int index)
		{
			return m_children[index];
		}

		public ExposeToEditor[] GetChildren()
		{
			return m_children.OrderBy((ExposeToEditor c) => c.transform.GetSiblingIndex()).ToArray();
		}

		private void Awake()
		{
			if (DisableOnAwake)
			{
				base.gameObject.SetActive(value: false);
			}
			List<Collider> list = new List<Collider>();
			MeshFilter component = GetComponent<MeshFilter>();
			bool flag = GetComponent<Rigidbody>() != null;
			if (component != null && !flag && AddColliders)
			{
				MeshCollider meshCollider = base.gameObject.AddComponent<MeshCollider>();
				meshCollider.convex = flag;
				meshCollider.sharedMesh = component.mesh;
				list.Add(meshCollider);
			}
			SkinnedMeshRenderer component2 = GetComponent<SkinnedMeshRenderer>();
			if (component2 != null && !flag && AddColliders)
			{
				MeshCollider meshCollider2 = base.gameObject.AddComponent<MeshCollider>();
				meshCollider2.convex = flag;
				meshCollider2.sharedMesh = component2.sharedMesh;
				list.Add(meshCollider2);
			}
			m_colliders = list.ToArray();
			if (base.transform.parent != null)
			{
				ExposeToEditor componentInParent = base.transform.parent.GetComponentInParent<ExposeToEditor>();
				if (m_parent != componentInParent)
				{
					m_parent = componentInParent;
					if (m_parent != null)
					{
						m_parent.m_children.Add(this);
					}
				}
			}
			m_hierarchyItem = base.gameObject.GetComponent<HierarchyItem>();
			if (m_hierarchyItem == null)
			{
				m_hierarchyItem = base.gameObject.AddComponent<HierarchyItem>();
			}
			if (ExposeToEditor.Awaked != null)
			{
				ExposeToEditor.Awaked(this);
			}
		}

		private void Start()
		{
			if (ExposeToEditor.Started != null)
			{
				ExposeToEditor.Started(this);
			}
		}

		private void OnEnable()
		{
			if (ExposeToEditor.Enabled != null)
			{
				ExposeToEditor.Enabled(this);
			}
		}

		private void OnDisable()
		{
			if (ExposeToEditor.Disabled != null)
			{
				ExposeToEditor.Disabled(this);
			}
		}

		private void OnApplicationQuit()
		{
			m_applicationQuit = true;
		}

		private void OnDestroy()
		{
			if (m_applicationQuit)
			{
				return;
			}
			Parent = null;
			for (int i = 0; i < m_colliders.Length; i++)
			{
				Collider collider = m_colliders[i];
				if (collider != null)
				{
					Object.Destroy(collider);
				}
			}
			if (m_hierarchyItem != null)
			{
				Object.Destroy(m_hierarchyItem);
			}
			if (ExposeToEditor.Destroyed != null)
			{
				ExposeToEditor.Destroyed(this);
			}
		}

		private void Update()
		{
			if (ExposeToEditor.TransformChanged != null && base.transform.hasChanged)
			{
				base.transform.hasChanged = false;
				if (ExposeToEditor.TransformChanged != null)
				{
					ExposeToEditor.TransformChanged(this);
				}
			}
		}

		public void SetName(string name)
		{
			base.gameObject.name = name;
			if (ExposeToEditor.NameChanged != null)
			{
				ExposeToEditor.NameChanged(this);
			}
		}
	}
}
