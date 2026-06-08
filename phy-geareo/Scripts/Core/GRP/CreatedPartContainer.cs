using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace GRP
{
	public class CreatedPartContainer
	{
		public Module module;

		public Part createdPart;

		public PartView myPart;

		public Func<Project> getProject;

		public Vector3 baseRotation;

		public bool noGlue;

		private Vector3 targetPosition;

		private Quaternion targetRotation;

		private RaycastHit lastHit;

		private bool isLastHit;

		private float partHeight;

		private Rigidbody rb;

		private static Transform helperTransform;

		private static Transform helperTransformOffset;

		private static CreatedPartGrid grid;

		public List<SnapContact> snapContacts;

		private Vector3 lastScreenPosition;

		private UndoSnapshot undoSnapshot;

		public Action<Part> onAdded;

		private bool newPart;

		private SnapController snapController;

		private static RaycastHit[] hits;

		private Highlight createHighlight;

		private Highlight glueHighlight;

		private List<Highlightable> highlightables;

		public bool hasCurrentHit;

		public RaycastHit currentHit;

		public CreatedPartContainer(Func<Project> getProject)
		{
		}

		public void Update()
		{
		}

		public static JObject GetData(Project project, Module module)
		{
			return null;
		}

		public void CreatePart(Module module, Id id, Func<Part, PartView> getPartView)
		{
		}

		public void SetSelectable(bool value)
		{
		}

		public void DestroyPart()
		{
		}

		public bool WillCreateGlue()
		{
			return false;
		}

		public void EndDrag()
		{
		}

		public void OnDrag(Vector3 screenPosition)
		{
		}

		private void PoolSnapContacts()
		{
		}
	}
}
