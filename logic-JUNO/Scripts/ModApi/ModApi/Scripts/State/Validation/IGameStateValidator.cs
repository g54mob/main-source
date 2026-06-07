using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Styles;
using ModApi.State;

namespace ModApi.Scripts.State.Validation
{
	public interface IGameStateValidator
	{
		public enum InitialPartScaleType
		{
			Fuselage = 0,
			Wing = 1
		}

		bool IsCareerMode { get; }

		float GetInitialPartScale(InitialPartScaleType initialPartScaleType);

		string GetItemId(string rootItemId, string specificId = null);

		bool IsDesignerPartAvailable(DesignerPart designerPart);

		bool IsItemAvailable(string rootItemId, string specificId = null);

		bool IsLaunchLocationLocked(string name);

		bool IsPartStyleAvailable(PartData partData, IPartStyle style);

		float ItemValue(string techItemId);

		ValidationResult ValidateCraft(ICraftScript craftScript, LaunchLocation launchLocation, bool fix = false);
	}
}
