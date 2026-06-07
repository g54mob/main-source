using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Assets.Scripts.Mods;
using ModApi.Craft;
using ModApi.Mods;
using ModApi.Ui;
using Unity.IO.Compression;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class CraftLoaderScript : MonoBehaviour, ICraftLoader
	{
		public static byte[] CompressCraftXml(XElement craftXml)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(craftXml.ToString());
			using MemoryStream memoryStream = new MemoryStream();
			using GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress);
			gZipStream.Write(bytes, 0, bytes.Length);
			gZipStream.Close();
			memoryStream.Close();
			return memoryStream.ToArray();
		}

		public static CraftLoaderScript Create(GameObject parent)
		{
			CraftLoaderScript craftLoaderScript = new GameObject("CraftLoader").AddComponent<CraftLoaderScript>();
			craftLoaderScript.transform.SetParent(parent.transform);
			return craftLoaderScript;
		}

		public static XElement LoadCraftXmlFromBytes(byte[] bytes)
		{
			try
			{
				return LoadCraftXmlFromBytesCommon(bytes);
			}
			catch (Exception ex)
			{
				try
				{
					using MemoryStream stream = new MemoryStream(bytes);
					using GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress);
					using MemoryStream memoryStream = new MemoryStream();
					gZipStream.CopyTo(memoryStream);
					return LoadCraftXmlFromBytesCommon(memoryStream.ToArray());
				}
				catch (Exception ex2)
				{
					throw new Exception("Could not load craft.\nError when attempting to load as uncompressed: " + ex.Message + "\nError when attempting to load as compressed: " + ex2.Message);
				}
			}
		}

		public CraftData LoadCraftImmediate(string craftId)
		{
			XElement xElement = null;
			try
			{
				xElement = Game.Instance.CraftDesigns.GetCraftDesign(craftId);
			}
			catch (Exception innerException)
			{
				throw new Exception("Unable to load craft '" + craftId + "'. An error occurred loading the craft XML.", innerException);
			}
			return LoadCraftImmediate(xElement);
		}

		public CraftData LoadCraftImmediate(XElement craftXml)
		{
			if (craftXml == null)
			{
				throw new ArgumentNullException("craftXml", "Unable to load craft because the specified XML is null.");
			}
			string craftName = CraftData.GetCraftName(craftXml);
			int xmlVersion = CraftData.GetXmlVersion(craftXml);
			if (xmlVersion > 15)
			{
				Debug.LogError("Attempting to load craft '" + craftName + "' which was created with a newer version of the game. The craft may fail to load properly. " + $"Craft version: {xmlVersion}, Current version: {15}");
			}
			RequiredModsCheck requiredModsCheck = CraftData.VerifyRequiredMods(craftXml);
			if (!requiredModsCheck.AllRequirementsMet)
			{
				LogModRequirementsNotMetError(craftName, requiredModsCheck);
			}
			CraftData craftData = null;
			try
			{
				Game instance = Game.Instance;
				return new CraftData(craftXml, instance.CraftThemes, instance.PartTypes);
			}
			catch (Exception innerException)
			{
				throw new Exception("An error occurred trying to load craft '" + craftName + "'.", innerException);
			}
		}

		public void LoadCraftInteractive(string craftId, Action<CraftData> successCallback, Action failureCallback)
		{
			try
			{
				XElement craftDesign = Game.Instance.CraftDesigns.GetCraftDesign(craftId);
				try
				{
					LoadCraftInteractive(craftDesign, successCallback, failureCallback);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					ShowErrorMessage("An error occurred trying to load craft '" + craftId + "'.", failureCallback);
				}
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
				ShowErrorMessage("Unable to load craft '" + craftId + "'. An error occurred loading the craft XML.", failureCallback);
			}
		}

		public void LoadCraftInteractive(XElement craftXml, Action<CraftData> successCallback, Action failureCallback)
		{
			string craftName = null;
			if (craftXml == null)
			{
				Debug.LogError("Unable to load the craft because the specified XML is null.");
			}
			else
			{
				try
				{
					craftName = CraftData.GetCraftName(craftXml);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					craftName = null;
				}
			}
			if (craftName == null)
			{
				ShowErrorMessage("An error occurred trying to load the craft.", failureCallback);
				return;
			}
			TryLoadCraftAction(delegate
			{
				CheckXmlVersion(craftXml, craftName, failureCallback, delegate
				{
					TryLoadCraftAction(delegate
					{
						CheckRequiredMods(craftXml, craftName, failureCallback, delegate
						{
							TryLoadCraftAction(delegate
							{
								StartCoroutine(LoadCraftCoroutine(craftXml, craftName, successCallback, failureCallback));
							});
						});
					});
				});
			});
			void TryLoadCraftAction(Action action)
			{
				try
				{
					action();
				}
				catch (Exception exception2)
				{
					Debug.LogException(exception2);
					ShowErrorMessage("An error occurred trying to load craft '" + craftName + "'.", failureCallback);
				}
			}
		}

		private static void CheckRequiredMods(XElement craftXml, string craftName, Action failureCallback, Action continueAction)
		{
			RequiredModsCheck requiredMods = CraftData.VerifyRequiredMods(craftXml);
			if (requiredMods.AllRequirementsMet)
			{
				continueAction();
				return;
			}
			RequiredModsDialogScript requiredModsDialogScript = RequiredModsDialogScript.Create(requiredMods);
			requiredModsDialogScript.CancelClicked += delegate
			{
				string text = requiredMods.BuildFailedRequirementsReport();
				Debug.LogWarning("The user aborted the loading of craft '" + craftName + "' which failed to meet mod requirements. " + Environment.NewLine + Environment.NewLine + text);
				failureCallback?.Invoke();
			};
			requiredModsDialogScript.OkayClicked += delegate
			{
				LogModRequirementsNotMetError(craftName, requiredMods);
				continueAction();
			};
		}

		private static void CheckXmlVersion(XElement craftXml, string craftName, Action failureCallback, Action continueAction)
		{
			int xmlVersion = CraftData.GetXmlVersion(craftXml);
			if (xmlVersion > 15)
			{
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				messageDialogScript.MessageText = "This craft requires a newer version of the game an may fail to load properly. Check your app store and download the newest version of Juno: New Origins. Do you want to try and load the craft anyway?";
				messageDialogScript.OkayButtonText = "LOAD CRAFT";
				messageDialogScript.CancelButtonText = "CANCEL";
				messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
				{
					d.Close();
					Debug.LogWarning("The user chose to force the loading of craft '" + craftName + "' which was created with a newer version of the game. " + $"Craft version: {xmlVersion}, Current version: {15}");
					continueAction();
				};
				messageDialogScript.CancelClicked += delegate(MessageDialogScript d)
				{
					d.Close();
					Debug.LogWarning("The user aborted the loading of craft '" + craftName + "' which was created with a newer version of the game. " + $"Craft version: {xmlVersion}, Current version: {15}");
					failureCallback?.Invoke();
				};
			}
			else
			{
				continueAction();
			}
		}

		private static XElement LoadCraftXmlFromBytesCommon(byte[] bytes)
		{
			using MemoryStream input = new MemoryStream(bytes);
			using XmlTextReader reader = new XmlTextReader(input);
			return XDocument.Load(reader).Root;
		}

		private static void LogModRequirementsNotMetError(string craftName, RequiredModsCheck requiredMods)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Attempting to load craft '" + craftName + "', but not all mod requirements have been met. The craft may fail to load properly.");
			if (requiredMods.ModsMissingCodeExecutionRequirement.Count > 0)
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendLine("The craft requires one or more mods with code execution support, which is not supported by this game version.");
			}
			if (requiredMods.EnabledOutdatedMods.Count > 0 || requiredMods.DisabledOutdatedMods.Count > 0)
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendLine("The craft requires one or more mods that are installed but not up to date.");
			}
			if (requiredMods.DisabledMods.Count > 0 || requiredMods.MissingMods.Count > 0)
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendLine("The craft requires one or more mods that are not currently installed or enabled.");
			}
			stringBuilder.AppendLine();
			stringBuilder.Append(requiredMods.BuildFailedRequirementsReport());
			Debug.LogError(stringBuilder.ToString());
		}

		private static void ShowErrorMessage(string message, Action okayAction)
		{
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog();
			messageDialogScript.MessageText = message;
			messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
			{
				d.Close();
				okayAction?.Invoke();
			};
		}

		private IEnumerator LoadCraftCoroutine(XElement craftXml, string craftName, Action<CraftData> successCallback, Action failureCallback)
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			CraftData craftData = null;
			try
			{
				Game instance = Game.Instance;
				craftData = new CraftData(craftXml, instance.CraftThemes, instance.PartTypes);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				craftData = null;
			}
			if (craftData == null)
			{
				Debug.LogError("An error occurred trying to load craft '" + craftName + "'.");
				ShowErrorMessage("An error occurred trying to load craft '" + craftName + "'.", failureCallback);
				yield break;
			}
			IReadOnlyDictionary<string, List<XElement>> missingParts = craftData.Assembly.MissingParts;
			IReadOnlyList<XElement> loadModifierFailures = craftData.Assembly.LoadModifierFailures;
			if (missingParts.Count > 0 || loadModifierFailures.Count > 0)
			{
				try
				{
					int num = missingParts.Values.Sum((List<XElement> x) => x.Count);
					string text = string.Join(", ", missingParts.Keys);
					string[] array = (from x in loadModifierFailures
						group x by x.Name.LocalName into x
						select x.Key).ToArray();
					string message = string.Empty;
					if (missingParts.Count > 0 && loadModifierFailures.Count > 0)
					{
						message = $"Failed to load {num} parts consisting of {missingParts.Count} distinct part types. " + Environment.NewLine + Environment.NewLine + "Missing part types: " + Environment.NewLine + text + $"{Environment.NewLine}{Environment.NewLine}Failed to load {loadModifierFailures.Count} part modifiers of {array.Length} distinct types." + Environment.NewLine + Environment.NewLine + "Part modifier types: " + Environment.NewLine + string.Join(", ", array);
					}
					else if (missingParts.Count > 0)
					{
						message = $"Failed to load {num} parts consisting of {missingParts.Count} distinct part types. " + Environment.NewLine + Environment.NewLine + "Missing part types: " + Environment.NewLine + text;
					}
					else if (loadModifierFailures.Count > 0)
					{
						message = $"Failed to load {loadModifierFailures.Count} part modifiers of {array.Length} distinct types. " + Environment.NewLine + Environment.NewLine + "Part modifier types: " + Environment.NewLine + string.Join(", ", array);
					}
					ShowErrorMessage(message, delegate
					{
						successCallback?.Invoke(craftData);
					});
					yield break;
				}
				catch (Exception exception2)
				{
					Debug.LogException(exception2);
					yield break;
				}
			}
			successCallback?.Invoke(craftData);
		}
	}
}
