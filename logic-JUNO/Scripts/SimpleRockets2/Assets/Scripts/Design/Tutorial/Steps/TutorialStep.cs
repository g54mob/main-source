using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Design;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Steps
{
	public class TutorialStep
	{
		public float CameraAnimationDuration { get; set; } = 1.5f;

		public Vector3 CameraFocusOffset { get; set; }

		public Vector2? CameraRotation { get; set; }

		public float? CameraZoom { get; set; }

		public bool CanSkip { get; set; } = true;

		public bool CenterOnTarget { get; set; }

		public Action Complete { get; set; }

		public Action<CraftData> CraftDataLoaded { get; set; }

		public PartData CraftPart { get; private set; }

		public XElement CraftXml { get; set; }

		public int FocusPartId { get; set; }

		public List<int> HidePartIds { get; private set; } = new List<int>();

		public List<int> HighlightPartIds { get; set; } = new List<int>();

		public int InitiallySelectedPartId { get; set; }

		public bool InvokeDesignerPullout { get; set; }

		public bool LoadAllParts { get; set; }

		public bool LoadCraft { get; set; }

		public List<int> LoadedPartIds { get; private set; }

		public List<int> LoadedSymmetricPartIds { get; set; }

		public TutorialPanelScript.TutorialPanelType PanelType { get; set; }

		public bool ReselectPart { get; set; } = true;

		public string StepText { get; set; }

		public PartData TargetPart { get; set; }

		public List<AttachPoint> TargetPartDestinationAttachPoints { get; private set; }

		public int TargetPartId { get; set; }

		protected TutorialScript TutorialScript { get; set; }

		public TutorialStep(int partId, TutorialScript tutorialScript)
		{
			TargetPartId = partId;
			TutorialScript = tutorialScript;
			LoadedPartIds = new List<int>();
			LoadedSymmetricPartIds = new List<int>();
			TargetPartDestinationAttachPoints = new List<AttachPoint>();
			InitiallySelectedPartId = -1;
			FocusPartId = -1;
			StepText = string.Empty;
			PanelType = TutorialPanelScript.TutorialPanelType.Instruction;
			LoadCraft = true;
			CameraZoom = null;
			CameraRotation = null;
			if (TargetPartId >= 0)
			{
				HighlightPartIds.Add(TargetPartId);
			}
		}

		public static T GetDesignerPartModifier<T>(TutorialScript tutorialScript, string designerPartName) where T : PartModifierData
		{
			Assembly assembly = new Assembly(tutorialScript.GetDesignerPart(designerPartName).AssemblyElement, 15, Game.Instance.PartTypes);
			T modifier = assembly.Parts[0].GetModifier<T>();
			modifier.OnDesignerPullout(designerPartName, assembly, skipStartPartScale: false);
			return modifier;
		}

		public virtual void End()
		{
			Complete?.Invoke();
			foreach (int hidePartId in HidePartIds)
			{
				PartData partById = Game.Instance.Designer.CraftScript.Data.Assembly.GetPartById(hidePartId);
				if (partById != null)
				{
					partById.PartScript.DesignerInteractionMode = PartDesignerInteractionMode.Normal;
				}
			}
		}

		public PartData FindPartAtTargetPosition(List<PartData> parts)
		{
			foreach (PartData part in parts)
			{
				if (!part.PartScript.Disconnected && Utilities.CompareVector3s(part.PartScript.Transform.position, TargetPart.PartScript.Transform.position, 0.11f) && new PartGraph(part, breakOnRigidBodyBoundary: false).HasRoot)
				{
					return part;
				}
			}
			return null;
		}

		public List<PartData> FindUserAddedParts()
		{
			List<PartData> list = new List<PartData>();
			foreach (PartData part in TutorialScript.DesignerScript.CraftScript.Data.Assembly.Parts)
			{
				if (part.PartScript.GameObject.GetComponent<TutorialPartScript>() == null)
				{
					list.Add(part);
				}
			}
			return list;
		}

		public void HighlightTargetPart(PartData part)
		{
			if (part != null)
			{
				DestroyPartConnections(part);
				TutorialScript.StartCoroutine(HighlightPartAfterThingsSettle(part));
			}
		}

		public void LoadStep()
		{
			TargetPartDestinationAttachPoints.Clear();
			DesignerScript designerScript = TutorialScript.DesignerScript;
			CraftData craftData = null;
			if (LoadCraft)
			{
				int? num = designerScript.SelectedPart?.Data?.Id;
				craftData = Game.Instance.CraftLoader.LoadCraftImmediate(CraftXml);
				CraftDataLoaded?.Invoke(craftData);
				designerScript.CraftLoader.LoadCraftImmediate(craftData, CraftXml, createUndoStep: false, centerCamera: false, null);
				List<PartData> list = new List<PartData>();
				list.AddRange(craftData.Assembly.Parts);
				foreach (PartData part in craftData.Assembly.Parts)
				{
					if (InvokeDesignerPullout)
					{
						part.OnDesignerPullout(part.Name, craftData.Assembly, skipStartPartScale: false);
					}
					if (!LoadedPartIds.Contains(part.Id) || part.PartScript.SymmetrySlice == null)
					{
						continue;
					}
					List<IPartScript> symmetricPartScripts = Symmetry.GetSymmetricPartScripts(part.PartScript);
					if (LoadedSymmetricPartIds.Contains(part.Id))
					{
						foreach (IPartScript item in symmetricPartScripts)
						{
							int id = item.Data.Id;
							if (!LoadedPartIds.Contains(id))
							{
								LoadedPartIds.Add(id);
							}
							if (!LoadedSymmetricPartIds.Contains(id))
							{
								LoadedSymmetricPartIds.Add(id);
							}
						}
						continue;
					}
					symmetricPartScripts.Add(part.PartScript);
					foreach (IPartScript item2 in symmetricPartScripts)
					{
						item2.Data.SymmetryId = null;
						item2.Data.SymmetryMode = SymmetryMode.None;
						item2.SymmetrySlice.Parts.Remove(item2.Data);
						item2.SymmetrySlice = null;
					}
				}
				foreach (PartData item3 in list)
				{
					if (HighlightPartIds.Contains(item3.Id))
					{
						if (TargetPartId == item3.Id)
						{
							TargetPart = item3;
						}
						else
						{
							HighlightTargetPart(item3);
						}
						Utilities.ChangeLayersOfGameObjectAndChildrenRecursive(TargetPart.PartScript.GameObject, 2);
					}
					else if (!LoadedPartIds.Contains(item3.Id) && !LoadAllParts)
					{
						DeletePart(item3);
					}
				}
				foreach (PartData part2 in craftData.Assembly.Parts)
				{
					part2.PartScript.GameObject.AddComponent<TutorialPartScript>();
				}
				if (TargetPart != null)
				{
					if (TargetPart.PartConnections.Count > 0)
					{
						foreach (PartConnection.Attachment attachment in TargetPart.PartConnections[0].Attachments)
						{
							AttachPoint attachPoint = attachment.AttachPointA;
							CraftPart = TargetPart.PartConnections[0].PartA;
							if (CraftPart == TargetPart)
							{
								attachPoint = attachment.AttachPointB;
								CraftPart = TargetPart.PartConnections[0].PartB;
							}
							if (attachPoint != null)
							{
								TargetPartDestinationAttachPoints.Add(attachPoint);
							}
						}
					}
					if (TargetPartDestinationAttachPoints.Count == 0)
					{
						Debug.Log("Could not find target destination attach points.");
					}
					HighlightTargetPart(TargetPart);
				}
				designerScript.CraftScript.SetStructureChanged();
				int selectPartId = ((InitiallySelectedPartId > -1) ? InitiallySelectedPartId : ((ReselectPart && num.HasValue) ? num.Value : (-1)));
				if (selectPartId > -1)
				{
					PartData partData = craftData.Assembly.Parts.Where((PartData x) => x.Id == selectPartId).FirstOrDefault();
					if (partData != null)
					{
						TutorialScript.StartCoroutine(SelectPartAfterThingsSettle(partData.PartScript));
					}
				}
			}
			else
			{
				craftData = designerScript.CraftScript.Data;
			}
			foreach (PartData part3 in craftData.Assembly.Parts)
			{
				if (HidePartIds.Contains(part3.Id))
				{
					part3.PartScript.DesignerInteractionMode = PartDesignerInteractionMode.Disabled;
				}
			}
			Start();
		}

		public virtual void OnPartDestroyed()
		{
		}

		public void ShowTargetPart(bool show)
		{
			if (TargetPart != null && show != TargetPart.PartScript.GameObject.activeSelf)
			{
				TargetPart.PartScript.GameObject.SetActive(show);
			}
		}

		public virtual void Skip()
		{
		}

		public virtual void Start()
		{
			DisplayStep(StepText);
			TutorialScript.DisplayError(string.Empty);
			UpdateCamera();
		}

		public virtual void Update()
		{
		}

		protected static void DisablePartColliders(PartData part)
		{
			Collider[] componentsInChildren = part.PartScript.GameObject.GetComponentsInChildren<Collider>();
			foreach (Collider collider in componentsInChildren)
			{
				if (collider.gameObject.GetComponent<MeshRenderer>() == null)
				{
					collider.gameObject.SetActive(value: false);
				}
				else
				{
					collider.enabled = false;
				}
			}
			AttachPointScript[] componentsInChildren2 = part.PartScript.GameObject.GetComponentsInChildren<AttachPointScript>();
			for (int i = 0; i < componentsInChildren2.Length; i++)
			{
				componentsInChildren2[i].enabled = false;
			}
		}

		protected void DeletePart(PartData part)
		{
			DestroyPartConnections(part);
			TutorialScript.DesignerScript.CraftScript.Data.Assembly.RemovePart(part);
			part.PartScript.GameObject.SetActive(value: false);
		}

		protected void DisplayInstruction(string text)
		{
			TutorialScript.DisplayInstructionText(text);
		}

		protected void DisplayRetryMessage()
		{
			TutorialScript.DisplayStepText("It looks like we may have a problem. You can restart this step by clicking 'Restart Step' to the left, or you can skip this step by clicking the 'Skip Step' to the right.");
			TutorialScript.HighlightUiElement("Tutorial.RestartButton", new Vector2(4f, 4f));
		}

		protected void DisplayStep(string text)
		{
			TutorialScript.DisplayStepText(text);
		}

		protected bool EnsurePartSelected(PartData part, string partName)
		{
			HighlightPart(part, highlight: false, solid: true);
			if (TutorialScript.DesignerScript.SelectedPart != part.PartScript)
			{
				HighlightPart(part, highlight: true, solid: true);
				TutorialScript.DisableUiHighlight();
				if (Device.IsMobileBuild)
				{
					if (!TutorialScript.DesignerUi.FingerTool.Enabled)
					{
						TutorialScript.HighlightUiElement("ToggleFingerTool", new Vector2(3f, 3f));
						DisplayInstruction("Tap the button in the lower right to enable the Finger Tool.");
					}
					else
					{
						TutorialScript.HighlightUiElement("FingerTool.SelectPart", new Vector2(3f, 3f));
						DisplayInstruction($"Reposition the tip of the Finger Tool over the {partName} part we added ealier to select it. The part is flashing blue.");
					}
				}
				else
				{
					DisplayInstruction($"Click on the '{partName}' part to select it. It's flashing blue.");
				}
				return false;
			}
			return true;
		}

		protected void HighlightPart(PartData part, bool highlight, bool solid = false)
		{
			if (highlight)
			{
				if (solid)
				{
					part.PartScript.PartMaterialScript.OverrideMaterials = new Material[1] { TutorialScript.SolidPartMaterial };
				}
				else
				{
					part.PartScript.PartMaterialScript.OverrideMaterials = new Material[1] { TutorialScript.TargetPartMaterial };
				}
			}
			else
			{
				part.PartScript.PartMaterialScript.OverrideMaterials = null;
			}
		}

		protected void UpdateCamera()
		{
			PartData partData = null;
			if (CenterOnTarget)
			{
				partData = TargetPart;
			}
			else if (FocusPartId > -1)
			{
				partData = TutorialScript.GetCraftPart(FocusPartId);
			}
			if (partData != null)
			{
				TutorialScript.DesignerScript.DesignerCamera.SetTargetPosition(partData.PartScript.Transform.position + CameraFocusOffset, CameraAnimationDuration);
				if (CameraZoom.HasValue)
				{
					TutorialScript.DesignerScript.DesignerCamera.SetTargetZoom(CameraZoom.Value, CameraAnimationDuration);
				}
				if (CameraRotation.HasValue)
				{
					TutorialScript.DesignerScript.DesignerCamera.SetTargetRotation(CameraRotation.Value, CameraAnimationDuration);
				}
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
				item.DestroyConnection();
			}
		}

		private IEnumerator HighlightPartAfterThingsSettle(PartData part)
		{
			yield return new WaitForEndOfFrame();
			HighlightPart(part, highlight: true);
		}

		private IEnumerator SelectPartAfterThingsSettle(IPartScript partScript)
		{
			yield return new WaitForEndOfFrame();
			TutorialScript.DesignerScript.SelectPart(partScript, null, justAdded: false);
		}
	}
}
