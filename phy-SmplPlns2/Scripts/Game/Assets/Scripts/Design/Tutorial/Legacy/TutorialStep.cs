using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Design.UI;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Legacy
{
	public class TutorialStep
	{
		protected TutorialScript _tutorialScript;

		public XElement AircraftXml { get; set; }

		public bool CenterOnPart { get; set; }

		public bool LoadAllParts { get; set; }

		public List<int> LoadedPartIds { get; private set; }

		public PartData TargetPart { get; set; }

		public List<AttachPointData> TargetPartDestinationAttachPoints { get; private set; }

		public int TargetPartId { get; set; }

		public TutorialStep(int partId, TutorialScript tutorialScript)
		{
			TargetPartId = partId;
			_tutorialScript = tutorialScript;
			LoadedPartIds = new List<int>();
			TargetPartDestinationAttachPoints = new List<AttachPointData>();
		}

		public virtual void End()
		{
		}

		public PartData FindPartAtTargetPosition(List<PartData> parts)
		{
			foreach (PartData part in parts)
			{
				if (part.PartScript.ConnectedToMainCockpit && Utilities.CompareVector3s(part.PartScript.transform.position, TargetPart.PartScript.transform.position, 0.01f) && new PartGraph(part, breakOnRigidBodyBoundary: false).HasCockpit)
				{
					return part;
				}
			}
			return null;
		}

		public List<PartData> FindUserAddedParts()
		{
			List<PartData> list = new List<PartData>();
			foreach (PartData part in _tutorialScript.DesignerScript.Designer.Aircraft.Aircraft.Assembly.Parts)
			{
				if (part.PartScript.gameObject.GetComponent<TutorialPartScript>() == null)
				{
					list.Add(part);
				}
			}
			return list;
		}

		public void LoadStep()
		{
			Designer designer = _tutorialScript.DesignerScript.Designer;
			designer.LoadXml(AircraftXml);
			AircraftScript aircraft = designer.Aircraft;
			PartData[] array = aircraft.Parts.ToArray();
			foreach (PartData partData in array)
			{
				if (TargetPartId == partData.Id)
				{
					TargetPart = partData;
				}
				else if (!LoadedPartIds.Contains(partData.Id) && !LoadAllParts)
				{
					DeletePart(partData);
				}
			}
			foreach (PartData part in aircraft.Parts)
			{
				part.PartScript.gameObject.AddComponent<TutorialPartScript>().TutorialStep = this;
			}
			if (TargetPart != null)
			{
				if (TargetPart.PartConnections.Count > 0)
				{
					List<AttachPointData> list = TargetPart.PartConnections[0].AttachPointsA;
					if (TargetPart.PartConnections[0].PartB == TargetPart)
					{
						list = TargetPart.PartConnections[0].AttachPointsB;
					}
					if (list.Count > 0)
					{
						TargetPartDestinationAttachPoints.AddRange(list);
					}
				}
				if (TargetPartDestinationAttachPoints.Count == 0)
				{
					Debug.Log("Could not find target destination attach points.");
				}
				HighlightTargetPart();
			}
			designer.OnAircraftStructureChanged();
			Start();
		}

		public virtual void OnPartDestroyed()
		{
		}

		public virtual void Skip()
		{
		}

		public virtual void Start()
		{
			if (CenterOnPart)
			{
				DesignerUIScript.TutorialCenterViewOnPart(TargetPart.PartScript);
			}
		}

		public virtual void Update()
		{
		}

		protected static void DisablePartColliders(PartData part)
		{
			Collider[] componentsInChildren = part.PartScript.GetComponentsInChildren<Collider>();
			foreach (Collider collider in componentsInChildren)
			{
				if (!collider.gameObject.TryGetComponent<MeshRenderer>(out var _))
				{
					collider.gameObject.SetActive(value: false);
				}
				else
				{
					collider.enabled = false;
				}
			}
			AttachPointScript[] componentsInChildren2 = part.PartScript.GetComponentsInChildren<AttachPointScript>();
			for (int i = 0; i < componentsInChildren2.Length; i++)
			{
				componentsInChildren2[i].enabled = false;
			}
		}

		protected void DeletePart(PartData part)
		{
			DestroyPartConnections(part);
			_tutorialScript.DesignerScript.Designer.DeletePart(part.PartScript);
		}

		protected void DisplayRetryMessage()
		{
			_tutorialScript.DisplayMessage("It looks like we may have a problem. You can restart this step by clicking 'Restart Step' to the left, or you can skip this step by clicking the 'Skip Step' to the right.");
		}

		protected void HighlightTargetPart()
		{
			if (TargetPart != null)
			{
				PartData targetPart = TargetPart;
				DestroyPartConnections(targetPart);
				DisablePartColliders(targetPart);
				_tutorialScript.StartCoroutine(HighlightPartAfterThingsSettle(targetPart));
			}
		}

		private static void DestroyPartConnections(PartData part)
		{
			List<PartConnection> list = new List<PartConnection>();
			foreach (PartConnection partConnection in part.PartConnections)
			{
				list.Add(partConnection);
			}
			foreach (PartConnection item in list)
			{
				item.DestroyConnection(isSymmetryOperation: false, destroySymmetricConnections: false, raiseConnectionChangedEvents: false);
			}
		}

		private IEnumerator HighlightPartAfterThingsSettle(PartData part)
		{
			yield return new WaitForEndOfFrame();
			part.PartScript.PartMaterialScript.OverrideMaterial = _tutorialScript.TargetPartMaterial;
		}
	}
}
