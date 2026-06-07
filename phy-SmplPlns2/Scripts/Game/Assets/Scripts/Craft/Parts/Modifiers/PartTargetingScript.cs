using Assets.Scripts.Craft.Parts.Events;
using Assets.Scripts.Design.Tools;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class PartTargetingScript : PartModifierScript
	{
		public PartTargetingData Data { get; private set; }

		public IPartTargetingHandler Handler { get; set; }

		public void Initialize(PartTargetingData data)
		{
			Data = data;
		}

		public override void OnMirrored(PartData sourcePart)
		{
			base.OnMirrored(sourcePart);
			Data.OnMirrored(sourcePart.GetModifier<PartTargetingData>());
		}

		public override void PreviewPartPlacement(AttachPointData myAttachPointBeingUsed, AttachPointData theirAttachPointToPreviewConnectionTo, PartSelection selection)
		{
			base.PreviewPartPlacement(myAttachPointBeingUsed, theirAttachPointToPreviewConnectionTo, selection);
			if (myAttachPointBeingUsed == base.PartScript.Part.AttachPoints[0] && Data.TargetMode == PartTargetingMode.SinglePart)
			{
				Data.TargetPart = theirAttachPointToPreviewConnectionTo.AttachPointScript.PartScript.Part;
			}
		}

		protected void OnDestroy()
		{
			if (base.PartScript != null)
			{
				base.PartScript.PartConnectionChanged -= OnConnectionChanged;
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnDesignerStart, CraftUpdateFlags.DesignerDefault);
		}

		private void OnConnectionChanged(object sender, PartConnectionChangedEventArgs e)
		{
			if (Data.TargetMode == PartTargetingMode.SinglePart)
			{
				Data.FindConnectedTargetPart();
			}
		}

		private void OnDesignerStart(in CraftUpdateFrameData frame)
		{
			base.PartScript.PartConnectionChanged += OnConnectionChanged;
			Data.OnTargetingChanged();
		}
	}
}
