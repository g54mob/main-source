using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Input.Events;
using Assets.Scripts.UI;
using Jundroo.Common.Platform;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class ColorTool : DesignerTool
	{
		private class PartMaterialHit
		{
			public List<int> MaterialIds { get; set; }

			public int MaterialLevel { get; set; }

			public PartScript Part { get; set; }
		}

		private static bool _previewEnabled = true;

		private bool _actuallyPaintedSomething;

		private ColorToolAutoPaint _autoPaint;

		private bool _painting;

		private PartMaterialHit _previewPartHit;

		public int PartMaterialId { get; set; }

		public int PartMaterialLevel { get; set; }

		public bool PreviewEnabled
		{
			get
			{
				return _previewEnabled;
			}
			set
			{
				_previewEnabled = value;
			}
		}

		private PartMaterialHit PreviewPartHit
		{
			get
			{
				return _previewPartHit;
			}
			set
			{
				if (_previewPartHit?.Part != null)
				{
					for (int i = 0; i < _previewPartHit.MaterialIds.Count; i++)
					{
						_previewPartHit.Part.PartMaterialScript.SetMaterial(_previewPartHit.MaterialIds[i], i, initializingPartMaterial: false);
					}
				}
				_previewPartHit = value;
				if (_previewPartHit?.Part != null)
				{
					PartMaterialHit previewPartHit = _previewPartHit;
					if (SetPartMaterial(previewPartHit.Part, _previewPartHit?.MaterialIds ?? previewPartHit.MaterialIds, previewPartHit.MaterialLevel, PartMaterialId, updateSymmetricParts: false))
					{
						Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerHoverPart);
					}
				}
			}
		}

		public ColorTool(Designer designer, CameraController cameraController)
			: base(designer, cameraController)
		{
			base.AllowPartSelection = false;
			_autoPaint = new ColorToolAutoPaint();
		}

		public override void HandleInput(InputEvent e)
		{
			bool flag = false;
			if (e.InputState == InputState.End && e.InputButton == InputButton.Primary)
			{
				if (_painting)
				{
					_painting = false;
					if (_actuallyPaintedSomething)
					{
						base.Designer.CreateUndoStep("Paint craft");
						_actuallyPaintedSomething = false;
					}
				}
				base.Designer.DesignerScript.DesignerUI.HideMainUI(hide: false);
				flag = true;
			}
			else if ((e.InputState == InputState.Updated || e.InputState == InputState.Begin) && e.InputButton == InputButton.Primary && !base.Designer.UserPreventPartGrab)
			{
				base.Designer.DesignerScript.DesignerUI.HideMainUI(hide: true);
				if (e.DragDistanceSinceBegin < 10f || _painting)
				{
					PartMaterialHit partHitAtScreenPosition = GetPartHitAtScreenPosition(e.Position);
					if (partHitAtScreenPosition?.Part != null)
					{
						_painting = true;
						flag = true;
						if (SetPartMaterial(partHitAtScreenPosition.Part, _previewPartHit?.MaterialIds ?? partHitAtScreenPosition.MaterialIds, partHitAtScreenPosition.MaterialLevel, PartMaterialId, updateSymmetricParts: true))
						{
							_actuallyPaintedSomething = true;
							Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerSprayPaint);
						}
						_previewPartHit = null;
					}
				}
			}
			if (!flag && !_painting)
			{
				base.HandleInput(e);
			}
		}

		public override void MouseHover(Vector3? screenPosition)
		{
			if (PreviewEnabled)
			{
				PartMaterialHit partMaterialHit = null;
				if (screenPosition.HasValue)
				{
					partMaterialHit = GetPartHitAtScreenPosition(screenPosition.Value);
				}
				if (PreviewPartHit?.Part != partMaterialHit?.Part)
				{
					PreviewPartHit = partMaterialHit;
				}
				else if (PreviewPartHit != null && partMaterialHit != null && PreviewPartHit.MaterialLevel != partMaterialHit.MaterialLevel)
				{
					partMaterialHit.MaterialIds = PreviewPartHit.MaterialIds;
					PreviewPartHit = partMaterialHit;
					if (Device.IsDebugBuild)
					{
						Debug.Log($"Trim Level: {partMaterialHit.MaterialLevel}");
					}
				}
			}
			else
			{
				PreviewPartHit = null;
			}
		}

		public override void Start()
		{
			base.Start();
			base.Designer.SelectedPart = null;
			base.Designer.HighlightedPart = null;
		}

		public override void Stop()
		{
			base.Stop();
			PreviewPartHit = null;
			_autoPaint.OnColorToolStopped();
		}

		private static bool SetPartMaterial(PartScript partHit, List<int> partMaterialIds, int partMaterialLevel, int partMaterialId, bool updateSymmetricParts)
		{
			if (updateSymmetricParts)
			{
				List<PartData> value;
				using (CollectionPool<List<PartData>, PartData>.Get(out value))
				{
					partHit.Aircraft.Aircraft.Assembly.GetOtherSymmetricParts(partHit.Part, value);
					foreach (PartData item in value)
					{
						SetPartMaterial(item.PartScript, partMaterialIds, partMaterialLevel, partMaterialId, updateSymmetricParts: false);
					}
				}
			}
			bool result = false;
			if (partMaterialLevel < partHit.Part.MaterialIds.Count)
			{
				PartMaterialScript component = partHit.GetComponent<PartMaterialScript>();
				if (partMaterialLevel == -1)
				{
					component.StartDesignerPaintEvents(uvChange: true);
					for (int i = 0; i < partHit.Part.MaterialIds.Count; i++)
					{
						if (partMaterialIds[i] != partMaterialId)
						{
							component.SetMaterialNoEvents(partMaterialId, i, initializingPartMaterial: false);
							result = true;
						}
					}
					component.EndDesignerPaintEvents(uvChange: true);
				}
				else if (partMaterialIds[partMaterialLevel] != partMaterialId)
				{
					component.SetMaterial(partMaterialId, partMaterialLevel, initializingPartMaterial: false);
					result = true;
				}
			}
			return result;
		}

		private PartMaterialHit GetPartHitAtScreenPosition(Vector2 screenPosition)
		{
			if (PartMaterialLevel == -2)
			{
				if (_autoPaint.GetPartAndMaterialLevelAtScreenPosition(base.Designer.Aircraft, base.Designer.CameraController.Camera, screenPosition, out var partHit, out var materialLevel))
				{
					PartMaterialHit obj = new PartMaterialHit
					{
						Part = partHit
					};
					obj.MaterialIds = obj.Part.Part.MaterialIds.ToList();
					obj.MaterialLevel = materialLevel;
					return obj;
				}
				return null;
			}
			(PartScript, RaycastHit, Ray)? partAtScreenPosition = base.Designer.GetPartAtScreenPosition(screenPosition, 0.025f);
			if (partAtScreenPosition.HasValue && partAtScreenPosition.Value.Item1 != null)
			{
				PartMaterialHit obj2 = new PartMaterialHit
				{
					Part = partAtScreenPosition.Value.Item1
				};
				obj2.MaterialIds = obj2.Part.Part.MaterialIds.ToList();
				obj2.MaterialLevel = PartMaterialLevel;
				return obj2;
			}
			return null;
		}
	}
}
