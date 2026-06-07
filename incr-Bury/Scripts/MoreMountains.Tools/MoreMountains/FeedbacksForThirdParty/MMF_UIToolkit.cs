using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.UIElements;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback is a base for UI Toolkit feedbacks")]
	public class MMF_UIToolkit : MMF_Feedback
	{
		public enum QueryModes
		{
			Name = 0,
			Class = 1
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Target", true, 54, true, false)]
		[Tooltip("the UI document on which to make modifications")]
		public UIDocument TargetDocument;

		[Tooltip("the way to perform the query, either via element name or via class")]
		public QueryModes QueryMode;

		[Tooltip("the query to perform (replace this with your own element name or class)")]
		public string Query = "ButtonA";

		[Tooltip("whether to mark the UI document dirty after the operation. Set this to true when making a change that requires a repaint such as when using generateVisualContent to render a mesh and the mesh data has now changed.")]
		public bool MarkDirty;

		protected List<VisualElement> _visualElements = new List<VisualElement>();

		public override bool HasAutomatedTargetAcquisition => true;

		protected override void AutomateTargetAcquisition()
		{
			TargetDocument = FindAutomatedTarget<UIDocument>();
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			PerformQuery();
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected virtual void PerformQuery()
		{
			if (TargetDocument == null)
			{
				Debug.LogWarning("[UI Toolkit] The UI Toolkit feedback on " + Owner.name + " doesn't have a TargetDocument, it won't work. You need to specify one in its inspector.");
				return;
			}
			switch (QueryMode)
			{
			case QueryModes.Name:
				_visualElements = TargetDocument.rootVisualElement.Query(Query).ToList();
				break;
			case QueryModes.Class:
				_visualElements = TargetDocument.rootVisualElement.Query(null, Query).ToList();
				break;
			}
		}

		protected virtual void HandleMarkDirty(VisualElement element)
		{
			if (MarkDirty)
			{
				element.MarkDirtyRepaint();
			}
		}
	}
}
