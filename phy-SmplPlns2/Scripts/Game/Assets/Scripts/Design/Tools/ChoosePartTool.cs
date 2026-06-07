using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Input.Events;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class ChoosePartTool : DesignerTool
	{
		private Action<PartData> _callback;

		private List<PartData> _choices = new List<PartData>();

		private PartData _selectedPart;

		private bool _waitForDoneButton = true;

		protected override bool PartHighlightEnabled => true;

		public ChoosePartTool(Designer designer, CameraController cameraController)
			: base(designer, cameraController)
		{
			base.AllowPartSelection = false;
			base.AllowFingerAid = false;
		}

		public override void HandleInput(InputEvent e)
		{
			if (e.InputState == InputState.End && e.InputButton == InputButton.Primary && e.DeltaPositionSinceBegin.magnitude < 5f)
			{
				Ray ray = base.CameraController.Camera.ScreenPointToRay(e.Position);
				float num = float.MaxValue;
				RaycastHit[] array = Physics.RaycastAll(ray, 10000f, 2129921);
				if (array != null && array.Length != 0)
				{
					PartScript partScript = null;
					RaycastHit[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						RaycastHit raycastHit = array2[i];
						PartScript componentInParent = raycastHit.transform.GetComponentInParent<PartScript>(includeInactive: true);
						if (!(componentInParent != null) || !_choices.Contains(componentInParent.Part) || !(raycastHit.distance < num) || !componentInParent.IsInteractable)
						{
							continue;
						}
						num = raycastHit.distance;
						if (!(partScript != componentInParent))
						{
							continue;
						}
						partScript = componentInParent;
						if (!componentInParent.PartMaterialScript.IsSelected)
						{
							componentInParent.PartMaterialScript.SetSelected(selected: true, updateSymmetricParts: false);
							_selectedPart = componentInParent.Part;
							foreach (PartData choice in _choices)
							{
								if (choice != _selectedPart)
								{
									choice.PartScript.PartMaterialScript.SetSelected(selected: false, updateSymmetricParts: false);
								}
							}
						}
						else
						{
							_selectedPart = null;
							componentInParent.PartMaterialScript.SetSelected(selected: false, updateSymmetricParts: false);
						}
					}
					if (_selectedPart != null && !_waitForDoneButton)
					{
						base.Designer.Tools.SelectMovePartTool();
					}
				}
				else if (_selectedPart != null)
				{
					_selectedPart.PartScript.PartMaterialScript.SetSelected(selected: false, updateSymmetricParts: false);
					_selectedPart = null;
				}
			}
			base.HandleInput(e);
		}

		public void Setup(Func<PartData, bool> partFilter, bool connectedToSelectedPart, int selectedPartId, string zeroChoicesMessage, Action<PartData> callback, bool waitForDoneButton = true)
		{
			_callback = callback;
			_selectedPart = null;
			_waitForDoneButton = waitForDoneButton;
			PartGraph partGraph = new PartGraph(base.Designer.SelectedPart.Part, breakOnRigidBodyBoundary: false);
			foreach (PartData part in base.Designer.Aircraft.Aircraft.Assembly.Parts)
			{
				bool flag = true;
				if (partFilter(part) && (!connectedToSelectedPart || partGraph.Parts.Contains(part)))
				{
					flag = false;
					if (part.Id == selectedPartId)
					{
						part.PartScript.PartMaterialScript.SetSelected(selected: true, updateSymmetricParts: false);
						_selectedPart = part;
					}
					_choices.Add(part);
				}
				if (flag)
				{
					part.PartScript.PartMaterialScript.IsHidden = true;
				}
			}
			if (_choices.Count == 0)
			{
				base.Designer.ShowMessage(zeroChoicesMessage);
			}
		}

		public override void Start()
		{
			base.Start();
			Designer.IncludeHiddenPartsInRaycast = false;
			base.Designer.DisableMovePart = true;
			base.Designer.DesignerScript.DesignerUI.SetEditingState(editing: true);
			base.Designer.DesignerScript.DesignerUI.DoneEditingButtonClicked += OnDoneClicked;
		}

		public override void Stop()
		{
			base.Stop();
			Designer.IncludeHiddenPartsInRaycast = true;
			base.Designer.DesignerScript.DesignerUI.DoneEditingButtonClicked -= OnDoneClicked;
			base.Designer.DisableMovePart = false;
			base.Designer.DesignerScript.DesignerUI.SetEditingState(editing: false);
			foreach (PartData part in base.Designer.Aircraft.Aircraft.Assembly.Parts)
			{
				part.PartScript.PartMaterialScript.IsHidden = false;
			}
			foreach (PartData choice in _choices)
			{
				choice.PartScript.PartMaterialScript.SetSelected(selected: false, updateSymmetricParts: false);
			}
			_choices.Clear();
			base.Designer.ShowMessage(string.Empty);
			_callback(_selectedPart);
			_selectedPart = null;
		}

		private void OnDoneClicked()
		{
			base.Designer.Tools.SelectMovePartTool();
		}
	}
}
