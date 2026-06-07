using System;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Styles;
using ModApi.Levels;
using ModApi.Scripts.State.Validation;
using ModApi.State;

namespace Assets.Scripts.State.Validation
{
	public class SandboxValidator : IGameStateValidator
	{
		public bool IsCareerMode => false;

		public float GetInitialPartScale(IGameStateValidator.InitialPartScaleType initialPartScaleType)
		{
			return 1f;
		}

		public string GetItemId(string rootItemId, string specificId = null)
		{
			return null;
		}

		public bool IsDesignerPartAvailable(DesignerPart designerPart)
		{
			return true;
		}

		public bool IsItemAvailable(string rootItemId, string specificId = null)
		{
			return true;
		}

		public bool IsLaunchLocationLocked(string name)
		{
			return false;
		}

		public bool IsPartStyleAvailable(PartData partData, IPartStyle style)
		{
			return true;
		}

		public float ItemValue(string techItemId)
		{
			throw new NotSupportedException("Item values cannot be requested in sandbox mode and should be guarded by first checking if the game state is in career mode.");
		}

		public ValidationResult ValidateCraft(ICraftScript craftScript, LaunchLocation launchLocation, bool fix = false)
		{
			ValidationResult validationResult = new ValidationResult();
			ILevel currentLevel = Game.Instance.LevelManager.CurrentLevel;
			if (currentLevel != null)
			{
				if (!currentLevel.IsLegalCraft(craftScript))
				{
					validationResult.AddMessage("Invalid Parts", "The craft contains invalid parts for this level.");
				}
				string missingPartsMessage = string.Empty;
				if (!currentLevel.HasRequiredParts(craftScript, out missingPartsMessage))
				{
					if (string.IsNullOrEmpty(missingPartsMessage))
					{
						validationResult.AddMessage("Missing Part", "The craft is missing a required part.");
					}
					else
					{
						validationResult.AddMessage("Missing Parts", missingPartsMessage);
					}
				}
			}
			else
			{
				foreach (PartData part in craftScript.Data.Assembly.Parts)
				{
					foreach (PartModifierData modifier in part.Modifiers)
					{
						if (modifier.VersionUpToDate != 1)
						{
							if (fix)
							{
								modifier.VersionUpToDate = 1;
							}
							else
							{
								validationResult.AddPartWarning(modifier.TypeId + ".VersionAllowed", part, "The " + modifier.TypeId + " modifier has a newer version, you may miss some features or fixes by keeping it.");
							}
						}
					}
				}
			}
			craftScript.ValidateCraft(validationResult);
			return validationResult;
		}
	}
}
