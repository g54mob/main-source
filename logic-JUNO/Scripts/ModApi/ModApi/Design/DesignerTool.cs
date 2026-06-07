using System;
using System.Collections.Generic;
using ModApi.Craft.Parts;
using ModApi.Input.Events;
using UnityEngine;

namespace ModApi.Design
{
	public abstract class DesignerTool
	{
		private bool _requestCaptureOnNextInput;

		public bool Active { get; private set; }

		public virtual ICollection<IPartScript> ActiveParts => Array.Empty<IPartScript>();

		public IDesigner Designer { get; private set; }

		public virtual bool HandleFingerToolEvents => false;

		public abstract bool IsBaseTool { get; }

		public bool IsInputCaptured => Designer.CapturedTool == this;

		public string Name { get; private set; }

		public IPartScript SelectedPart => Designer.SelectedPart;

		public DesignerTool(IDesigner designer)
		{
			Designer = designer;
			Designer.CanPinch = true;
			Name = GetType().Name;
		}

		public virtual void Activate()
		{
			Active = true;
		}

		public virtual void Deactivate()
		{
			Active = false;
		}

		public virtual bool HandleClick(ClickEventArgs e)
		{
			bool result = false;
			if (_requestCaptureOnNextInput)
			{
				result = true;
				_requestCaptureOnNextInput = false;
			}
			return result;
		}

		public virtual bool HandlePinch(PinchEventArgs e)
		{
			return false;
		}

		public virtual bool HandleScroll(ScrollEventArgs e)
		{
			return false;
		}

		public virtual void OnCapturedToolChanged(DesignerTool designerTool)
		{
		}

		public virtual void OnCraftStructureChanged()
		{
		}

		public virtual void OnOtherToolActivated(DesignerTool toolActivated)
		{
		}

		public virtual void OnOtherToolDeactivated(DesignerTool toolDeactivated)
		{
		}

		public virtual void SelectedPartChanged(IPartScript newPart, RaycastHit? hit, bool justAdded)
		{
		}

		public virtual void SelectedPartClicked(IPartScript selectedPart, RaycastHit? hit)
		{
		}

		public virtual void Update(float deltaTime)
		{
		}

		protected void RequestCaptureOnNextInput()
		{
			_requestCaptureOnNextInput = true;
		}
	}
}
