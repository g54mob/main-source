using Assets.Packages.SocialPlatforms.Achievements;
using Assets.Scripts.Craft.Parts;
using ModApi.Audio;
using ModApi.Craft.Parts;
using ModApi.Design;
using ModApi.Input.Events;
using ModApi.Settings;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class PaintTool : DesignerToolBase
	{
		private static bool _achievementUnlocked;

		private MouseInputSettingsDesigner _mouseInputSettings;

		private bool _painting;

		private AudioSource _paintSound;

		private IPartScript _previouslySelectedPart;

		public override bool HandleFingerToolEvents => true;

		public override bool IsBaseTool => false;

		public int MaterialId { get; set; }

		public int MaterialLevel { get; set; }

		public PaintTool(DesignerScript designer)
			: base(designer)
		{
			_mouseInputSettings = Game.Instance.Settings.Game.MouseInputDesigner;
		}

		public override void Activate()
		{
			base.Activate();
			base.Designer.AllowPartSelection = false;
			_previouslySelectedPart = base.Designer.SelectedPart;
			base.Designer.DeselectPart();
			base.Designer.HighlightedPart = null;
			if (_paintSound == null)
			{
				_paintSound = Game.Instance.AudioPlayer.CreateAudioSource(AudioLibrary.Design.SprayPaint, null);
			}
		}

		public override void Deactivate()
		{
			base.Deactivate();
			base.Designer.AllowPartSelection = true;
			if (_previouslySelectedPart != null && _previouslySelectedPart.Transform != null)
			{
				base.Designer.SelectPart(_previouslySelectedPart, null, justAdded: false);
			}
			_previouslySelectedPart = null;
		}

		public override bool HandleClick(ClickEventArgs e)
		{
			bool flag = base.HandleClick(e);
			if ((!e.IsTouchPrimary && !_mouseInputSettings.CanSelectPart(e.InputButton)) || MaterialId == -1)
			{
				return base.IsInputCaptured;
			}
			if (e.InputState == InputState.End)
			{
				if (_painting)
				{
					base.Designer.CreateUndoStep();
				}
				_painting = false;
			}
			else if (e.InputState == InputState.Begin)
			{
				IPartScript part = GetPart(e.Position);
				if (part != null)
				{
					_painting = true;
					PaintPart(part, paintSymmetricParts: true);
				}
			}
			else if (e.InputState == InputState.Updated && _painting)
			{
				IPartScript part2 = GetPart(e.Position);
				if (part2 != null)
				{
					PaintPart(part2, paintSymmetricParts: true);
				}
			}
			return _painting;
		}

		private IPartScript GetPart(Vector2 screenPosition)
		{
			return base.Designer.GetPartAtScreenPosition(screenPosition).PartScript;
		}

		private void PaintPart(IPartScript part, bool paintSymmetricParts)
		{
			bool flag = false;
			if (MaterialLevel < part.Data.MaterialIds.Count)
			{
				PartMaterialScript partMaterialScript = (PartMaterialScript)part.PartMaterialScript;
				if (MaterialLevel == -1)
				{
					for (int i = 0; i < part.Data.MaterialIds.Count; i++)
					{
						if (part.Data.MaterialIds[i] != MaterialId)
						{
							partMaterialScript.SetMaterial(MaterialId, i);
							flag = true;
						}
					}
				}
				else if (part.Data.MaterialIds[MaterialLevel] != MaterialId)
				{
					partMaterialScript.SetMaterial(MaterialId, MaterialLevel);
					flag = true;
				}
				if (paintSymmetricParts)
				{
					foreach (IPartScript item in Symmetry.EnumerateSymmetricPartScripts(part))
					{
						PaintPart(item, paintSymmetricParts: false);
					}
				}
			}
			if (!flag)
			{
				return;
			}
			part.PartMaterialScript.OnMaterialsChanged();
			foreach (PartModifierData modifier in part.Data.Modifiers)
			{
				((IDesignerPartModifierData)modifier).DesignerPartProperties.OnPartMaterialsChanged();
			}
			if (paintSymmetricParts && !_paintSound.isPlaying)
			{
				_paintSound.Play();
			}
			if (!_achievementUnlocked)
			{
				_achievementUnlocked = true;
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.PaintJob);
			}
		}
	}
}
