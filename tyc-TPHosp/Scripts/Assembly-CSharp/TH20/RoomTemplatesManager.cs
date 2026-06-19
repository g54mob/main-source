#define LOG_LEVEL_VERBOSE
using System;
using System.Collections;
using System.Collections.Generic;
using FullInspector;
using TH20.Analytics;

namespace TH20
{
	public class RoomTemplatesManager : MustCallDestroy
	{
		public readonly Dictionary<RoomDefinition.Type, Dictionary<string, RoomTemplate>> RoomTemplates = new Dictionary<RoomDefinition.Type, Dictionary<string, RoomTemplate>>();

		[DontSave]
		private App _app;

		[DontSave]
		private bool _initialised;

		public RoomTemplatesManager()
		{
			InitRoomTemplatesDict();
		}

		public void RestoreFromSave(App app)
		{
			base.RestoreFromSave();
			Init(app);
		}

		public void Init(App app)
		{
			if (_initialised)
			{
				return;
			}
			_app = app;
			InitRoomTemplatesDict();
			foreach (KeyValuePair<RoomDefinition.Type, Dictionary<string, RoomTemplate>> roomTemplate in RoomTemplates)
			{
				foreach (KeyValuePair<string, RoomTemplate> item in roomTemplate.Value)
				{
					item.Value.FixupUGCDefinitions(_app);
					item.Value.UsedDLCAppIDs = GetUniqueDLCUsedInTemplate(item.Value);
				}
			}
			_initialised = true;
		}

		private void InitRoomTemplatesDict()
		{
			foreach (RoomDefinition.Type value in Enum.GetValues(typeof(RoomDefinition.Type)))
			{
				if (!RoomTemplates.ContainsKey(value))
				{
					RoomTemplates.Add(value, new Dictionary<string, RoomTemplate>());
				}
			}
		}

		private List<uint> GetUniqueDLCUsedInTemplate(RoomTemplate template)
		{
			List<uint> list = new List<uint>();
			SharedInstance<DLCItemDefinition> dlcPackRequired = template.TemplateFloorPlan.Definition.DlcPackRequired;
			if (dlcPackRequired != null)
			{
				list.Add(dlcPackRequired.Instance.AppID);
			}
			foreach (RoomTemplateItem item in template.TemplateFloorPlan.Items)
			{
				if (!(item.Definition != null) || (item.Definition.Instance.DlcPackRequired.IsNull() && item.Definition.Instance.PrimeEntitlementRequired == 0))
				{
					continue;
				}
				bool flag = !item.Definition.Instance.DlcPackRequired.IsNull() && DLCUtils.IsDLCOwned(item.Definition.Instance.DlcPackRequired.Instance);
				if (!((item.Definition.Instance.PrimeEntitlementRequired > 0 && _app.UserProfile.PrimeEntitlementClaimed(item.Definition.Instance.PrimeEntitlementRequired.ToString())) || flag))
				{
					if (template.TemplateFloorPlan.DLCItemsToRemove == null)
					{
						template.TemplateFloorPlan.DLCItemsToRemove = new List<RoomTemplateItem>();
					}
					template.TemplateFloorPlan.DLCItemsToRemove.Add(item);
				}
			}
			return list;
		}

		public bool LoadInRoomTemplate(RoomTemplate template, string fileName)
		{
			if (!RoomTemplates.ContainsKey(template.RoomType))
			{
				Logging.Error(LogChannels.RoomTemplates, "Attempting to remove template for room type not in dictionary: {0}", template.RoomType.ToString());
				return false;
			}
			if (RoomTemplates[template.RoomType].ContainsKey(fileName))
			{
				Logging.Warning(LogChannels.RoomTemplates, "Attempting to load in duplicate template (file name already exists in dictionary) ': {0}", fileName);
				return false;
			}
			template.GeneratedFileName = fileName;
			RoomTemplates[template.RoomType][template.GeneratedFileName] = template;
			return true;
		}

		private string GenerateFilenameForTemplate(RoomDefinition.Type roomType, string userDefinedName)
		{
			string s = roomType.ToString() + "_" + userDefinedName;
			s = SaveSystem.SanitiseFileNameCharacters(s);
			if (RoomTemplates[roomType].ContainsKey(s))
			{
				int num = 1;
				string text = s + num;
				while (RoomTemplates[roomType].ContainsKey(text))
				{
					num++;
					text = s + num;
				}
				s = text;
			}
			return s;
		}

		public bool AddNewRoomTemplate(RoomDefinition.Type roomType, FloorPlan floorPlan, IFloorVisualOverrideDefinition floorVisualOverride, IWallVisualOverrideDefinition wallVisualOverride, string userDefinedName = "")
		{
			string fileName = GenerateFilenameForTemplate(roomType, userDefinedName);
			RoomTemplateFloorPlan floorPlan2 = new RoomTemplateFloorPlan(floorPlan);
			RoomTemplate roomTemplate = new RoomTemplate(RoomTemplates[roomType].Count, roomType, floorPlan2, floorVisualOverride, wallVisualOverride, userDefinedName, fileName);
			RoomTemplates[roomType][roomTemplate.GeneratedFileName] = roomTemplate;
			SaveTemplateDeferred(roomTemplate);
			GameEvent gameEvent = new GameEvent(_app.AnalyticsManager.Config.RoomTemplateCreated).AddParam("roomType", roomType.ToString()).AddParam("numItems", roomTemplate.TemplateFloorPlan.Items.Count).AddParam("templateCost", GameAlgorithms.CalculatePurchaseCostOfRoomTemplate(roomTemplate.TemplateFloorPlan));
			_app.AnalyticsManager.RecordEvent(gameEvent);
			return true;
		}

		public void ReplaceTemplate(RoomTemplate template, FloorPlan floorPlan, IFloorVisualOverrideDefinition floorVisualOverride, IWallVisualOverrideDefinition wallVisualOverride)
		{
			if (!RoomTemplates.ContainsKey(template.RoomType))
			{
				Logging.Error(LogChannels.RoomTemplates, "Attempting to remove template for room type not in dictionary: {0}", template.RoomType.ToString());
				return;
			}
			if (!RoomTemplates[template.RoomType].ContainsKey(template.GeneratedFileName))
			{
				Logging.Error(LogChannels.RoomTemplates, "Attempting to replace template that doesn't exist in dictionary with name ': {0}", template.UserDefinedName);
				return;
			}
			RoomTemplateFloorPlan floorPlan2 = new RoomTemplateFloorPlan(floorPlan);
			RoomTemplate roomTemplate = new RoomTemplate(template.TemplateID, template.RoomType, floorPlan2, floorVisualOverride, wallVisualOverride, template.UserDefinedName, template.GeneratedFileName);
			RoomTemplates[template.RoomType][template.GeneratedFileName] = roomTemplate;
			SaveTemplateDeferred(roomTemplate);
			GameEvent gameEvent = new GameEvent(_app.AnalyticsManager.Config.RoomTemplateCreated).AddParam("roomType", roomTemplate.RoomType.ToString()).AddParam("numItems", roomTemplate.TemplateFloorPlan.Items.Count).AddParam("templateCost", GameAlgorithms.CalculatePurchaseCostOfRoomTemplate(roomTemplate.TemplateFloorPlan));
			_app.AnalyticsManager.RecordEvent(gameEvent);
		}

		public void RemoveRoomTemplate(RoomTemplate template)
		{
			if (!RoomTemplates.ContainsKey(template.RoomType))
			{
				Logging.Error(LogChannels.RoomTemplates, "Attempting to remove template for room type not in dictionary: {0}", template.RoomType.ToString());
			}
			else
			{
				DeleteTemplateDeferred(template);
				RoomTemplates[template.RoomType].Remove(template.GeneratedFileName);
			}
		}

		public void RenameRoomTemplate(RoomTemplate template, string newName)
		{
			_ = template.GeneratedFileName;
			string fileName = GenerateFilenameForTemplate(template.RoomType, newName);
			RoomTemplate roomTemplate = new RoomTemplate(template.TemplateID, template.RoomType, template.TemplateFloorPlan, template.FloorVisualOverride, template.WallVisualOverride, newName, fileName);
			RoomTemplates[template.RoomType][roomTemplate.GeneratedFileName] = roomTemplate;
			SaveThenDeleteRoomTemplatesDeferred(roomTemplate, template.GeneratedFileName);
			RoomTemplates[template.RoomType].Remove(template.GeneratedFileName);
		}

		public List<RoomTemplate> GetTemplatesForRoom(RoomDefinition.Type roomType)
		{
			if (!RoomTemplates.ContainsKey(roomType))
			{
				Logging.Error(LogChannels.RoomTemplates, "Attempting to retrieve list of room templates for room type not in dictionary: {0}", roomType.ToString());
				return null;
			}
			List<RoomTemplate> list = new List<RoomTemplate>();
			foreach (KeyValuePair<string, RoomTemplate> item in RoomTemplates[roomType])
			{
				list.Add(item.Value);
			}
			return list;
		}

		private RoomTemplateSaveData CreateRoomTemplateSaveData(RoomTemplate template)
		{
			return new RoomTemplateSaveData
			{
				RoomTemplate = template
			};
		}

		private void SaveTemplateInstantly(RoomTemplate template)
		{
			_app.SaveSystem.SaveRoomTemplate(CreateRoomTemplateSaveData(template));
		}

		private IEnumerator SaveRoomTemplatesWithOverlayCoroutine(RoomTemplate template)
		{
			_app.SaveOverlay.SetActive(value: true);
			yield return null;
			SaveTemplateInstantly(template);
			_app.SaveOverlay.SetActive(value: false);
		}

		public void SaveTemplateDeferred(RoomTemplate template)
		{
			_app.StartCoroutine(SaveRoomTemplatesWithOverlayCoroutine(template));
		}

		public void DeleteTemplateDeferred(RoomTemplate template)
		{
			_app.StartCoroutine(DeleteRoomTemplateWithOverlayCoroutine(template.GeneratedFileName));
		}

		private void DeleteTemplateInstantly(string generatedFilename)
		{
			_app.SaveSystem.DeleteRoomTemplateSave(generatedFilename);
		}

		private IEnumerator DeleteRoomTemplateWithOverlayCoroutine(string generatedFilename)
		{
			_app.SaveOverlay.SetActive(value: true);
			yield return null;
			DeleteTemplateInstantly(generatedFilename);
			_app.SaveOverlay.SetActive(value: false);
		}

		public void SaveThenDeleteRoomTemplatesDeferred(RoomTemplate template, string filenameToDelete)
		{
			_app.StartCoroutine(SaveThenDeleteRoomTemplatesWithOverlayCoroutine(template, filenameToDelete));
		}

		private IEnumerator SaveThenDeleteRoomTemplatesWithOverlayCoroutine(RoomTemplate templateToSave, string filenameToDelete)
		{
			_app.SaveOverlay.SetActive(value: true);
			yield return null;
			SaveTemplateInstantly(templateToSave);
			DeleteTemplateInstantly(filenameToDelete);
			_app.SaveOverlay.SetActive(value: false);
		}
	}
}
