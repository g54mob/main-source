using System;
using System.Net;
using Assets.Scripts.Ui;
using Assets.Scripts.Web;
using ModApi;
using ModApi.Mods;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Mods
{
	public class RequiredModsDialogScript : DialogScript
	{
		private XmlLayout _xmlLayout;

		public RequiredModsCheck Data { get; private set; }

		public MessageDialogResult? Result { get; protected set; }

		public event EventHandler<EventArgs> CancelClicked;

		public event EventHandler<EventArgs> OkayClicked;

		public static RequiredModsDialogScript Create(RequiredModsCheck requiredMods, Transform parent = null)
		{
			return Game.Instance.UserInterface.CreateDialog("Ui/Xml/Mods/RequiredModsDialog", parent, delegate(RequiredModsDialogScript d, IXmlLayoutController c)
			{
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			}, delegate(RequiredModsDialogScript d)
			{
				d.Data = requiredMods;
			});
		}

		public override void Close()
		{
			base.Close();
			_xmlLayout.Hide(delegate
			{
				base.gameObject.SetActive(value: false);
				UnityEngine.Object.Destroy(base.gameObject);
			});
		}

		public WaitUntil WaitForResult()
		{
			return new WaitUntil(() => Result.HasValue);
		}

		protected virtual void Update()
		{
			if (Game.Instance.UserInterface.ActiveDialog == this)
			{
				if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
				{
					OnCancelButtonClicked();
				}
				else if (UnityEngine.Input.GetKeyDown(KeyCode.Return) || UnityEngine.Input.GetKeyDown(KeyCode.KeypadEnter))
				{
					OnOkayButtonClicked();
				}
			}
		}

		private void CreateModListItem(RequiredModData mod, string status, bool installed, XmlElement template, XmlElement parent)
		{
			XmlElement xmlElement = UiUtilities.CloneTemplate(template, parent);
			xmlElement.AddOnClickEvent(delegate
			{
				OnModClicked(mod);
			});
			xmlElement.GetElementByInternalId<TextMeshProUGUI>("name").text = mod.Name;
			xmlElement.GetElementByInternalId<TextMeshProUGUI>("author").text = mod.Author;
			xmlElement.GetElementByInternalId<TextMeshProUGUI>("version").text = string.Format("Version {0}.{1} - {2}", mod.Version.Major, mod.Version.Minor, mod.LastModified.ToString("yyyy-MM-dd HH:mm:ss"));
			XmlElement elementByInternalId = xmlElement.GetElementByInternalId<XmlElement>("status");
			elementByInternalId.AddClass(installed ? "mod-status-valid" : "mod-status-invalid");
			elementByInternalId.SetAttribute("text", status);
			elementByInternalId.ApplyAttributes();
		}

		private void OnCancelButtonClicked()
		{
			Result = MessageDialogResult.Cancel;
			Close();
			this.CancelClicked?.Invoke(this, EventArgs.Empty);
		}

		private void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_xmlLayout = xmlLayout;
			bool flag = Data.ModsMissingCodeExecutionRequirement.Count > 0;
			XmlElement elementById = xmlLayout.GetElementById("mod-template");
			XmlElement xmlElement = (flag ? xmlLayout.GetElementById("mod-code-template") : elementById);
			XmlElement elementById2 = xmlLayout.GetElementById("items-parent");
			TextMeshProUGUI elementById3 = xmlLayout.GetElementById<TextMeshProUGUI>("header-description");
			if (Data.MissingMods.Count > 0 || Data.DisabledMods.Count > 0)
			{
				elementById3.text = "Loading this item requires the following mods, some of which are not currently installed or enabled.";
				if (flag)
				{
					elementById3.text = elementById3.text + " One or more of these mods require code execution support which is not supported by " + (Device.IsMobileBuild ? "this device." : "this version of the game.");
				}
			}
			else if (Data.EnabledOutdatedMods.Count > 0 || Data.DisabledOutdatedMods.Count > 0)
			{
				elementById3.text = "Loading this item requires the following mods, some of which are installed but they are out of date and need updated.";
				if (flag)
				{
					elementById3.text = elementById3.text + " One or more of these mods require code execution support which is not supported by " + (Device.IsMobileBuild ? "this device." : "this version of the game.");
				}
			}
			else if (flag)
			{
				elementById3.text = "Loading this item requires the following mods, some of which require code execution support which is not supported by " + (Device.IsMobileBuild ? "this device." : "this version of the game.");
			}
			else
			{
				elementById3.text = "Loading this item requires the following mods.";
			}
			elementById3.text += " Clicking on a mod below will search the Juno: New Origins website for that mod.";
			foreach (RequiredModData missingMod in Data.MissingMods)
			{
				XmlElement template = (missingMod.RequiresCodeExecution ? xmlElement : elementById);
				CreateModListItem(missingMod, "Not Installed", installed: false, template, elementById2);
			}
			foreach (RequiredModData disabledMod in Data.DisabledMods)
			{
				XmlElement template2 = (disabledMod.RequiresCodeExecution ? xmlElement : elementById);
				CreateModListItem(disabledMod, "Disabled", installed: false, template2, elementById2);
			}
			foreach (RequiredModData disabledOutdatedMod in Data.DisabledOutdatedMods)
			{
				XmlElement template3 = (disabledOutdatedMod.RequiresCodeExecution ? xmlElement : elementById);
				CreateModListItem(disabledOutdatedMod, "Disabled & Outdated", installed: false, template3, elementById2);
			}
			foreach (RequiredModData enabledOutdatedMod in Data.EnabledOutdatedMods)
			{
				XmlElement template4 = (enabledOutdatedMod.RequiresCodeExecution ? xmlElement : elementById);
				CreateModListItem(enabledOutdatedMod, "Outdated", installed: false, template4, elementById2);
			}
			foreach (RequiredModData enabledMod in Data.EnabledMods)
			{
				XmlElement template5 = (enabledMod.RequiresCodeExecution ? xmlElement : elementById);
				CreateModListItem(enabledMod, "Installed", installed: true, template5, elementById2);
			}
		}

		private void OnModClicked(RequiredModData mod)
		{
			Assets.Scripts.Web.WebUtility.OpenUrl(Game.SimpleRocketsWebsiteUrl + "/Mods/SearchByName?name=" + System.Net.WebUtility.UrlEncode(mod.Name));
		}

		private void OnOkayButtonClicked()
		{
			Result = MessageDialogResult.Okay;
			Close();
			this.OkayClicked?.Invoke(this, EventArgs.Empty);
		}
	}
}
