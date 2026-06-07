using System.Collections.Generic;
using System.Linq;
using Jundroo.ModTools;
using Jundroo.ModTools.Core;
using ModApi.Core;
using TMPro;

namespace Assets.Scripts.Menu.ListView
{
	public class ModsDetails
	{
		private DetailsPropertyScript _author;

		private DetailsTextScript _desription;

		private DetailsTextScript _errors;

		private DetailsWidgetGroup _issuesGroup;

		private DetailsPropertyScript _lastModified;

		private DetailsWidgetGroup _pendingDisableGroup;

		private DetailsTextScript _pendingDisableText;

		private DetailsPropertyScript _version;

		private DetailsTextScript _warnings;

		public ModsDetails(ListViewDetailsScript listViewDetails)
		{
			DetailsWidgetGroup widgets = listViewDetails.Widgets;
			_author = widgets.AddProperty("Author");
			_version = widgets.AddProperty("Version");
			_lastModified = widgets.AddProperty("LastModified");
			widgets.AddSpacer();
			_pendingDisableGroup = widgets.AddGroup();
			_pendingDisableGroup.AddSpacer();
			_pendingDisableText = _pendingDisableGroup.AddText("This mod will be disabled when the game is restarted.", "Warning");
			_pendingDisableGroup.AddSpacer();
			_pendingDisableGroup.AddSpacer();
			_desription = widgets.AddText("Description");
			_issuesGroup = widgets.AddGroup();
			_issuesGroup.AddSpacer();
			_issuesGroup.AddSpacer();
			_warnings = _issuesGroup.AddText("Warnings", "Warning");
			_errors = _issuesGroup.AddText("Errors", "Danger");
			_author.LabelText = "Author";
			_version.LabelText = "Version";
			_lastModified.LabelText = "Created Date";
		}

		public void UpdateDetails(ModInfo mod)
		{
			_author.ValueText = mod.Author;
			_version.ValueText = mod.Version.ToString(2);
			_lastModified.ValueText = mod.LastUpdated.ToString("yyyy-MM-dd HH:mm:ss");
			_desription.Text = mod.Description;
			if (mod.BuildInfo.BuildGameVersion != null)
			{
				_version.Tooltip = "Mod built on '" + (mod.BuildInfo.BuildOperatingSystem ?? "Unknown OS") + "' using Unity version '" + (mod.BuildInfo.BuildUnityVersion ?? "Unknown") + "' and version '" + (mod.BuildInfo.BuildGameVersion?.ToString() ?? "Unknown") + "' of the game.";
			}
			_pendingDisableGroup.Visible = mod.PendingDisable;
			IModManager modManager = Game.Instance.ModManagerScript.ModManager;
			List<ModLoadMessage> list = modManager.ModLoadWarnings.Where((ModLoadMessage x) => x.Mod == mod).ToList();
			_warnings.Visible = list.Count > 0;
			_warnings.Text = string.Join("\n\n", list.Select((ModLoadMessage x) => x.Message));
			_warnings.Alignment = TextAlignmentOptions.Left;
			List<ModLoadMessage> list2 = modManager.ModLoadErrors.Where((ModLoadMessage x) => x.Mod == mod).ToList();
			_errors.Visible = list2.Count > 0;
			_errors.Text = string.Join("\n\n", list2.Select((ModLoadMessage x) => x.Message));
			_errors.Alignment = TextAlignmentOptions.Left;
			_issuesGroup.Visible = _errors.Visible || _warnings.Visible;
		}
	}
}
