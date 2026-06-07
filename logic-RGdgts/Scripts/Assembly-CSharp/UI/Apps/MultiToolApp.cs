using UnityEngine;

namespace UI.Apps
{
	public class MultiToolApp : MonoBehaviour
	{
		protected MultiTool multitool;

		protected Workbench workbench;

		protected UIMultitoolManager uiManager;

		protected RectTransform rectTransform;

		protected Gadget gadget => null;

		public bool isRunning => false;

		public virtual void Init()
		{
		}

		public virtual void AppStart()
		{
		}

		public virtual void AppStop()
		{
		}

		public virtual bool NeedGadget()
		{
			return false;
		}

		public virtual void OnSetGadget(Gadget gadget)
		{
		}

		public virtual void OnGadgetTurnOn()
		{
		}

		public virtual void OnGadgetTurnOff()
		{
		}

		public virtual void OnGadgetEndEdit()
		{
		}

		public virtual void OnSelectModule(Module module)
		{
		}

		public virtual void OnSolderModule(Module module)
		{
		}

		public virtual void OnUnsolderModule(Module module)
		{
		}

		public virtual void OnMultitoolOpen()
		{
		}

		public virtual void OnMultitoolClose()
		{
		}

		public virtual bool SupportsVariableResolution()
		{
			return false;
		}

		public virtual MultitoolCanvas.ShaderMode GetShaderMode()
		{
			return default(MultitoolCanvas.ShaderMode);
		}
	}
}
