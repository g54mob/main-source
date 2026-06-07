using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[ModuleInfo("Input/Spline Shape", ModuleName = "Input Spline Shape", Description = "Spline Shape")]
	[HelpURL("https://curvyeditor.com/doclink/cginputsplineshape")]
	public class InputSplineShape : SplineInputModuleBase, IExternalInput, IOnRequestProcessing, IPathProvider
	{
		[OutputSlotInfo(typeof(CGShape))]
		[HideInInspector]
		public CGModuleOutputSlot OutShape;

		[Tab("General", Sort = 0)]
		[SerializeField]
		[CGResourceManager("Shape")]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private CurvySpline m_Shape;

		public CurvySpline Shape
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool SupportsIPE => false;

		public bool FreeForm
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected override CurvySpline InputSpline
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CGData[] OnSlotDataRequest(CGModuleInputSlot requestedBy, CGModuleOutputSlot requestedSlot, params CGDataRequestParameter[] requests)
		{
			return null;
		}

		public T SetManagedShape<T>() where T : CurvyShape2D
		{
			return null;
		}

		public void RemoveManagedShape()
		{
		}

		protected override void OnSplineAssigned()
		{
		}
	}
}
