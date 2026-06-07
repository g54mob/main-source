using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Character;
using Assets.Scripts.Design.Symmetry;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.Design.Tutorials.Steps.PartChanges;
using Assets.Scripts.Design.UI;
using Assets.Scripts.UI;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design.Tutorials.Steps
{
	public abstract class TutorialStep
	{
		private class HighlightTarget
		{
			public CanvasGroup CanvasGroup { get; set; }

			public Vector2 Padding { get; set; }

			public ScrollRect ScrollRect { get; set; }

			public RectTransform Target { get; set; }
		}

		private Func<Color> _defaultHidePartColorFunc;

		private Func<Color> _defaultHighlightPartColorFunc;

		private Vector3 _defaultHighlightPartScale;

		private bool _defaultHighlightPartUseZTest;

		private Color _highlightColor;

		private List<(PartData Part, Vector3 Scale, Func<Color> ColorFunc, bool UseZTest)> _highlightedParts;

		private HighlightTarget _highlightTarget;

		private float _highlightTime;

		private int _targetPartId = -1;

		private int _targetSymmetricPartId = -1;

		public List<int> AddedPartIds { get; }

		public List<ITutorialStepPartChange> AppliedPartChanges { get; }

		public TutorialStepCameraTarget CameraTarget { get; set; }

		public XElement CraftXml { get; set; }

		public Action<TutorialStep> CustomStart { get; set; }

		public DesignerScript Designer { get; }

		public string InstructionText { get; set; }

		public List<int> LoadedPartIds { get; }

		public List<ITutorialStepPartChange> PendingPartChanges { get; }

		public virtual bool SkipOnRewind { get; }

		public string StepText { get; set; }

		public PartData TargetPart { get; private set; }

		public int TargetPartId => _targetPartId;

		public PartData TargetSymmetricPart { get; private set; }

		public int TargetSymmetricPartId => _targetSymmetricPartId;

		public Tutorial Tutorial { get; }

		protected Color TargetPartColor { get; private set; }

		protected Color TargetSymmetricPartColor { get; private set; }

		public TutorialStep(TutorialStepBuilderContext context, string stepText = null)
			: this(context, -1, targetPartSymmetry: false, stepText)
		{
		}

		public TutorialStep(TutorialStepBuilderContext context, int targetPartId, string stepText = null)
			: this(context, targetPartId, targetPartSymmetry: false, stepText)
		{
		}

		public TutorialStep(TutorialStepBuilderContext context, int targetPartId, bool targetPartSymmetry, string stepText = null)
		{
			StepText = stepText;
			Tutorial = context.Tutorial;
			Designer = context.Designer;
			CraftXml = context.CraftXml;
			LoadedPartIds = new List<int>(context.LoadedPartIds);
			AddedPartIds = new List<int>();
			PendingPartChanges = new List<ITutorialStepPartChange>();
			AppliedPartChanges = new List<ITutorialStepPartChange>();
			_highlightedParts = new List<(PartData, Vector3, Func<Color>, bool)>();
			SetDefaultHighlightConfiguration();
			_defaultHidePartColorFunc = () => TargetSymmetricPartColor;
			_targetPartId = targetPartId;
			if (targetPartId >= 0 && !LoadedPartIds.Contains(targetPartId))
			{
				LoadedPartIds.Add(targetPartId);
			}
			if (targetPartSymmetry)
			{
				_targetSymmetricPartId = GetSymmetricPartId(targetPartId, CraftXml);
				if (_targetSymmetricPartId >= 0 && !LoadedPartIds.Contains(_targetSymmetricPartId))
				{
					LoadedPartIds.Add(_targetSymmetricPartId);
				}
			}
		}

		public static int GetPartIdByName(string partName, XElement craftXml)
		{
			int? num = (int?)craftXml?.Element("Assembly")?.Element("Parts")?.Elements("Part")?.FirstOrDefault((XElement x) => (string)x.Attribute("name") == partName)?.Attribute("id");
			if (!num.HasValue)
			{
				throw new Exception("Part with name '" + partName + "' not found in tutorial craft xml.");
			}
			return num.Value;
		}

		public static bool GetPartPositionAndRotation(int partId, XElement craftXml, out Vector3 position, out Vector3 rotation)
		{
			XElement xElement = craftXml?.Element("Assembly")?.Element("Parts")?.Elements("Part")?.FirstOrDefault((XElement x) => (int)x.Attribute("id") == partId);
			if (xElement == null)
			{
				position = Vector3.zero;
				rotation = Vector3.zero;
				return false;
			}
			position = xElement.GetVector3Attribute("position");
			rotation = xElement.GetVector3Attribute("rotation");
			return true;
		}

		public static int GetSymmetricPartId(int partId, XElement craftXml)
		{
			int? symmetryId = (int?)craftXml?.Element("Assembly")?.Element("Parts")?.Elements("Part")?.FirstOrDefault((XElement x) => (int)x.Attribute("id") == partId)?.Attribute("symmetryId");
			if (!symmetryId.HasValue)
			{
				throw new Exception($"Symmetric part for part id '{partId}' not found in tutorial craft xml. No symmetry id was found.");
			}
			int? num = (int?)craftXml?.Element("Assembly")?.Element("Parts")?.Elements("Part")?.FirstOrDefault((XElement x) => (int?)x.Attribute("symmetryId") == symmetryId && (int)x.Attribute("id") != partId)?.Attribute("id");
			if (!symmetryId.HasValue)
			{
				throw new Exception($"Symmetric part for part id '{partId}' and symmetry id '{symmetryId}' not found in tutorial craft xml.");
			}
			return num.Value;
		}

		public static int? GetSymmetricPartIdOrNull(int partId, XElement craftXml)
		{
			int? symmetryId = (int?)craftXml?.Element("Assembly")?.Element("Parts")?.Elements("Part")?.FirstOrDefault((XElement x) => (int)x.Attribute("id") == partId)?.Attribute("symmetryId");
			if (!symmetryId.HasValue)
			{
				return null;
			}
			return (int?)craftXml?.Element("Assembly")?.Element("Parts")?.Elements("Part")?.FirstOrDefault((XElement x) => (int?)x.Attribute("symmetryId") == symmetryId && (int)x.Attribute("id") != partId)?.Attribute("id");
		}

		public void ClearHighlightedPart(PartData part)
		{
			for (int num = _highlightedParts.Count - 1; num >= 0; num--)
			{
				if (_highlightedParts[num].Part == part)
				{
					_highlightedParts.RemoveAt(num);
					PartMaterialScript partMaterialScript = part.PartScript?.PartMaterialScript;
					if (partMaterialScript != null)
					{
						partMaterialScript.TutorialHighlight = null;
					}
				}
			}
		}

		public PartData ConfigurePartForNonInteractableHighlight(PartData part, bool duplicatePart = false)
		{
			if (part == null)
			{
				return null;
			}
			if (part.TryGetModifier<JFuselageData>(out var _))
			{
				JFuselageScript.ApplyBufferedChanges();
			}
			if (part.TryGetModifier<IKSeatData>(out var result2))
			{
				result2.DesignerCharacter = "None";
			}
			PartData partData = part;
			if (duplicatePart)
			{
				part = SymmetryUtility.DuplicatePart(part, mirrored: false);
			}
			if (part.PartScript.TryGetComponent<TutorialPartScript>(out var component))
			{
				component.IsHiddenPart = true;
			}
			else
			{
				TutorialPartScript.Create(part.PartScript.gameObject, isUserAddedPart: false, isHiddenPart: true);
			}
			PartData partData2 = null;
			if (partData.TryGetModifier<ControlSurfacePartData>(out var result3))
			{
				partData2 = SymmetryUtility.DuplicatePart(result3.GetFirstConnectedWing().Part, mirrored: false);
				ConfigurePartForNonInteractableHighlight(partData2);
				HidePart(partData2);
			}
			LayerUtility.SetLayerRecursive(part.PartScript.gameObject, 2);
			Renderer[] componentsInChildren = part.PartScript.GetComponentsInChildren<Renderer>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = false;
			}
			if (partData2 != null)
			{
				foreach (PartConnection item in partData.PartConnections.ToList())
				{
					if (item.GetOtherPart(part).GetModifier<JWingData>() == null)
					{
						continue;
					}
					if (item.AttachPointsA.Count != 1 || item.AttachPointsB.Count != 1)
					{
						Debug.LogError("Unexpected number of connected attach points on control surface connection. Expected 1 attach point on each side.");
						continue;
					}
					AttachPointData attachPointData = ((item.PartA == part) ? item.AttachPointsA[0] : item.AttachPointsB[0]);
					AttachPointData attachPointData2 = ((item.PartA == part) ? item.AttachPointsB[0] : item.AttachPointsA[0]);
					if (attachPointData.Id >= part.AttachPoints.Count || attachPointData2.Id >= partData2.PartScript.Part.AttachPoints.Count)
					{
						Debug.LogError("Unexpected attach point id on control surface connection. Attach point id was greater than or equal to the number of attach points on the part.");
						continue;
					}
					if (!duplicatePart)
					{
						item.DestroyConnection(isSymmetryOperation: false, destroySymmetricConnections: false, raiseConnectionChangedEvents: true);
					}
					AttachPointData attachPointData3 = part.AttachPoints[attachPointData.Id];
					MovePartTool.ConnectPartToAttachPoint(targetAttachPointScript: partData2.PartScript.Part.AttachPoints[attachPointData2.Id].AttachPointScript, attachPointScript: attachPointData3.AttachPointScript, connectSymmetricParts: false, autoConcealSymmetricParts: false);
				}
			}
			else
			{
				foreach (PartConnection item2 in part.PartConnections.ToList())
				{
					item2.DestroyConnection(isSymmetryOperation: false, destroySymmetricConnections: false, raiseConnectionChangedEvents: true);
				}
			}
			if (part.TryGetModifier<JWingData>(out var result4))
			{
				result4.UpdateMeshes(updateSymmetricParts: false);
			}
			if (Designer.Designer.SelectedPart == part.PartScript)
			{
				Designer.Designer.SelectedPart = null;
			}
			if (Designer.DesignerUI.Flyouts.JFuselageShape.IsOpen)
			{
				Designer.DesignerUI.Flyouts.JFuselageShape.Widget.GetComponentInChildren<JFuselageShapePanelScript>().RefreshUI();
			}
			return part;
		}

		public void DisableUIHighlight()
		{
			_highlightTarget = null;
		}

		public void End()
		{
			Tutorial.TutorialScript.UI.DisableHighlight();
			Tutorial.TutorialScript.UI.EnableEmptySpaceWidget(enable: false);
			OnEnd();
		}

		public void FixedUpdate()
		{
			OnFixedUpdate();
		}

		public void HidePart(PartData part)
		{
			Func<Color> defaultHidePartColorFunc = _defaultHidePartColorFunc;
			HighlightPart(part, null, defaultHidePartColorFunc);
		}

		public void HighlightPart(PartData part, Vector3? scale = null, Func<Color> colorFunc = null, bool? useZTest = null)
		{
			(PartData, Vector3, Func<Color>, bool) tuple = (part, scale ?? _defaultHighlightPartScale, colorFunc ?? _defaultHighlightPartColorFunc, useZTest ?? _defaultHighlightPartUseZTest);
			for (int i = 0; i < _highlightedParts.Count; i++)
			{
				if (_highlightedParts[i].Part == part)
				{
					_highlightedParts[i] = tuple;
					return;
				}
			}
			_highlightedParts.Add(tuple);
			PartMaterialScript partMaterialScript = part.PartScript?.PartMaterialScript;
			if (partMaterialScript != null)
			{
				PartMaterialScript partMaterialScript2 = partMaterialScript;
				if (partMaterialScript2.TutorialHighlight == null)
				{
					PartMaterialScript.PartHighlightSettings partHighlightSettings = (partMaterialScript2.TutorialHighlight = new PartMaterialScript.PartHighlightSettings(tuple.Item3(), tuple.Item2, tuple.Item4));
				}
			}
		}

		public bool HighlightUIElement(string widgetPath, Vector2 padding, bool highlightEvenIfInactive = false)
		{
			return HighlightUIElement(Designer.DesignerUI.RootWidget, widgetPath, padding, highlightEvenIfInactive);
		}

		public bool HighlightUIElement(Widget rootWidget, string widgetPath, Vector2 padding, bool highlightEvenIfInactive = false)
		{
			Widget widget = rootWidget;
			string[] array = widgetPath.Split(new char[1] { '/' });
			foreach (string text in array)
			{
				if (text.StartsWith("go:"))
				{
					GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren(text.Substring(3), widget.gameObject);
					widget = ((gameObject != null) ? gameObject.GetComponent<Widget>() : null);
				}
				else
				{
					widget = widget.FindWidget(text);
				}
			}
			return HighlightUIElement(widget, padding, highlightEvenIfInactive);
		}

		public bool HighlightUIElement(Widget widget, Vector2 padding, bool highlightEvenIfInactive)
		{
			if (widget == null || (!highlightEvenIfInactive && (!widget.Visible || !widget.gameObject.activeInHierarchy)))
			{
				_highlightTarget = null;
				return false;
			}
			if (_highlightTarget == null)
			{
				_highlightTarget = new HighlightTarget();
			}
			_highlightTarget.Target = widget.Rect;
			_highlightTarget.Padding = padding;
			_highlightTarget.ScrollRect = widget.GetComponentInParent<ScrollRect>();
			_highlightTarget.CanvasGroup = widget.GetComponentInParent<CanvasGroup>();
			return true;
		}

		public void LateUpdate()
		{
			AnimateHighlightColors();
			foreach (var highlightedPart in _highlightedParts)
			{
				PartMaterialScript partMaterialScript = highlightedPart.Part.PartScript?.PartMaterialScript;
				if (partMaterialScript != null)
				{
					PartMaterialScript partMaterialScript2 = partMaterialScript;
					PartMaterialScript.PartHighlightSettings partHighlightSettings = partMaterialScript2.TutorialHighlight ?? (partMaterialScript2.TutorialHighlight = new PartMaterialScript.PartHighlightSettings(highlightedPart.ColorFunc(), highlightedPart.Scale, highlightedPart.UseZTest));
					partHighlightSettings.Color = highlightedPart.ColorFunc();
					partHighlightSettings.Scale = highlightedPart.Scale;
					partHighlightSettings.UseZTest = highlightedPart.UseZTest;
					partMaterialScript.TutorialHighlight = partHighlightSettings;
				}
			}
			if (_highlightTarget != null && _highlightTarget.Target != null)
			{
				Tutorial.TutorialScript.StartCoroutine(UpdateUIHighlight(_highlightTarget));
			}
			else
			{
				Tutorial.TutorialScript.UI.DisableHighlight();
			}
			OnLateUpdate();
		}

		public void SetDefaultHighlightConfiguration(Vector3? scale = null, Func<Color> colorFunc = null, bool? useZTest = null)
		{
			_defaultHighlightPartScale = scale ?? (Vector3.one * 1.005f);
			_defaultHighlightPartColorFunc = colorFunc ?? ((Func<Color>)(() => TargetPartColor));
			_defaultHighlightPartUseZTest = useZTest ?? true;
		}

		public void Start()
		{
			(string, Vector3) tuple = (Designer.SelectedPart?.Part.PartType.PartTypeId ?? null, Designer.SelectedPart?.transform.position ?? Vector3.zero);
			Action flyoutAndToolReselectAction = GetFlyoutAndToolReselectAction();
			using (FlyoutScript.TemporarilySkipAnimations())
			{
				Designer.Designer.LoadXml(CraftXml);
				Designer.Designer.Aircraft.Initialized += CraftInitialized;
				if (_targetPartId != -1)
				{
					TargetPart = Designer.Aircraft.GetPartById(_targetPartId, includeDisconnected: true);
					if (TargetPart == null)
					{
						Debug.LogError($"Target part with id {_targetPartId} not found in the loaded craft.");
					}
					else
					{
						ControlSurfacePartData result;
						bool flag = TargetPart.TryGetModifier<ControlSurfacePartData>(out result);
						PartData targetPart = TargetPart;
						bool? useZTest = (flag ? new bool?(false) : ((bool?)null));
						HighlightPart(targetPart, null, null, useZTest);
					}
				}
				if (_targetSymmetricPartId != -1)
				{
					TargetSymmetricPart = Designer.Aircraft.GetPartById(_targetSymmetricPartId, includeDisconnected: true);
					if (TargetSymmetricPart == null)
					{
						Debug.LogError($"Target symmetric part with id {_targetSymmetricPartId} not found in the loaded craft.");
					}
					else
					{
						HidePart(TargetSymmetricPart);
					}
				}
				List<int> value;
				using (CollectionPool<List<int>, int>.Get(out value))
				{
					foreach (PartData part in Designer.Aircraft.Parts)
					{
						if (!LoadedPartIds.Contains(part.Id))
						{
							value.Add(part.Id);
						}
						TutorialPartScript.Create(part.PartScript.gameObject, isUserAddedPart: false);
					}
					foreach (int partId in value)
					{
						PartData partData = Designer.Aircraft.Parts.FirstOrDefault((PartData p) => p.Id == partId);
						if (partData != null)
						{
							Designer.Designer.DeletePart(partData.PartScript);
						}
					}
					AircraftData aircraft = Designer.Aircraft.Aircraft;
					foreach (ITutorialStepPartChange pendingPartChange in PendingPartChanges)
					{
						pendingPartChange.Revert(aircraft);
					}
					OnStartBeforePartChanges();
					foreach (ITutorialStepPartChange appliedPartChange in AppliedPartChanges)
					{
						appliedPartChange.Revert(aircraft);
					}
					if (tuple.Item1 != null)
					{
						float num = 0.25f;
						if (Tutorial.PreviousStep is AddPartStep addPartStep)
						{
							num = addPartStep.PlacementDistanceThreshold;
						}
						PartScript selectedPart = null;
						float num2 = float.MaxValue;
						foreach (PartData part2 in Designer.Aircraft.Aircraft.Assembly.Parts)
						{
							if (part2.PartType.PartTypeId == tuple.Item1)
							{
								float num3 = Vector3.Distance(part2.PartScript.transform.position, tuple.Item2);
								if (num3 < num && num3 < num2)
								{
									selectedPart = part2.PartScript;
									num2 = num3;
								}
							}
						}
						Designer.Designer.SelectedPart = selectedPart;
					}
					flyoutAndToolReselectAction();
					CameraTarget?.MoveCameraToTarget();
					OnStart();
				}
			}
		}

		public void Update()
		{
			TutorialUIScript uI = Tutorial.TutorialScript.UI;
			if (StepText != uI.PrimaryText)
			{
				uI.PrimaryText = StepText;
			}
			if (InstructionText != uI.SecondaryText)
			{
				uI.SecondaryText = InstructionText;
			}
			OnUpdate();
		}

		protected void CompleteStep()
		{
			OnStepCompleted();
			Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerStep);
			Tutorial.MoveToNextStep();
		}

		protected Widget FindUIWidget(string widgetPath)
		{
			Widget widget = Designer.DesignerUI.RootWidget;
			string[] array = widgetPath.Split('/');
			foreach (string text in array)
			{
				if (widget == null)
				{
					break;
				}
				if (text.StartsWith("go:", StringComparison.OrdinalIgnoreCase))
				{
					GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren(text.Substring(3), widget.gameObject);
					widget = ((gameObject != null) ? gameObject.GetComponent<Widget>() : null);
				}
				else
				{
					widget = widget.FindWidget(text);
				}
			}
			return widget;
		}

		protected void GetUserAddedParts(List<PartScript> userAddedParts)
		{
			foreach (PartData part in Designer.Aircraft.Aircraft.Assembly.Parts)
			{
				if (!part.PartScript.TryGetComponent<TutorialPartScript>(out var component) || component.IsUserAddedPart)
				{
					userAddedParts.Add(part.PartScript);
				}
			}
		}

		protected virtual void OnCraftInitialized(AircraftScript craft)
		{
		}

		protected virtual void OnEnd()
		{
		}

		protected virtual void OnFixedUpdate()
		{
		}

		protected virtual void OnLateUpdate()
		{
		}

		protected virtual void OnStart()
		{
			CustomStart?.Invoke(this);
		}

		protected virtual void OnStartBeforePartChanges()
		{
		}

		protected virtual void OnStepCompleted()
		{
		}

		protected virtual void OnUpdate()
		{
		}

		private void AnimateHighlightColors()
		{
			_highlightTime += Time.deltaTime;
			float t = (Mathf.Sin(_highlightTime * 5f) + 1f) / 2f;
			Color targetPartColor = Color.Lerp(new Color32(0, byte.MaxValue, 0, 128), new Color32(0, byte.MaxValue, 0, 32), t);
			TargetPartColor = targetPartColor;
			TargetSymmetricPartColor = Color.clear;
			float num = (Mathf.Sin(_highlightTime * 5f) + 1f) / 2f;
			float num2 = 0.25f;
			float num3 = num2 + (1f - num2) * num;
			num3 *= _highlightTarget?.CanvasGroup?.alpha ?? 1f;
			_highlightColor = new Color(0f, 1f, 0f, num3);
		}

		private void CraftInitialized(AircraftScript craft)
		{
			craft.Initialized -= CraftInitialized;
			OnCraftInitialized(craft);
		}

		private Action GetFlyoutAndToolReselectAction()
		{
			IFlyout previouslyActiveFlyout = Designer.DesignerUI.Flyouts.Selected;
			DesignerTool previouslyActiveTool = Designer.Designer.Tools.SelectedTool;
			JFuselageTool fuselageTool = Designer.Designer.Tools.JFuselageTool;
			bool isFuselageFlyout = previouslyActiveFlyout == Designer.DesignerUI.Flyouts.JFuselageShape;
			bool fuselageIsSlice = isFuselageFlyout && fuselageTool.Slice != null;
			int fuselageIndex = ((!isFuselageFlyout) ? (-1) : (fuselageTool.Slice?.PrimarySliceIndex ?? fuselageTool.Section?.PrimaryFuselageIndex ?? (-1)));
			return delegate
			{
				if (previouslyActiveFlyout != null)
				{
					if (isFuselageFlyout)
					{
						PartScript selectedPart = Designer.SelectedPart;
						JFuselageData jFuselageData = selectedPart?.Part.GetModifier<JFuselageData>();
						if (jFuselageData != null && selectedPart.gameObject.layer != 2)
						{
							Designer.Designer.Tools.SelectTool(fuselageTool);
							if (fuselageIsSlice)
							{
								fuselageTool.SelectSlice(jFuselageData, fuselageIndex);
							}
							else
							{
								fuselageTool.SelectSection(jFuselageData, fuselageIndex);
							}
						}
					}
					else
					{
						Designer.DesignerUI.Flyouts.Selected = previouslyActiveFlyout;
					}
				}
				if (previouslyActiveTool != null && previouslyActiveTool != Designer.Designer.Tools.SelectedTool && !isFuselageFlyout)
				{
					Designer.Designer.Tools.SelectTool(previouslyActiveTool);
				}
			};
		}

		private IEnumerator UpdateUIHighlight(HighlightTarget target)
		{
			yield return new WaitForEndOfFrame();
			TutorialUIScript uI = Tutorial.TutorialScript.UI;
			RectTransform rect = uI.Widget.Rect;
			Vector2[] array = new Vector2[4];
			UserInterfaceUtility.GetRectCornersInLocalSpace(target.Target, rect, array, null);
			Vector2 vector = (array[0] + array[2]) / 2f;
			Vector2 vector2 = array[2] - array[0];
			if (vector2.x > 2f && vector2.y > 2f)
			{
				uI.EnableHighlight(vector, (int)Mathf.Abs(vector2.x + target.Padding.x), (int)Mathf.Abs(vector2.y + target.Padding.y), _highlightColor, target.ScrollRect);
			}
			else
			{
				uI.DisableHighlight();
			}
		}
	}
}
