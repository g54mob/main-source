using System;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using ModApi.Craft;
using ModApi.Design;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class DesignerCraftLoader
	{
		private DesignerScript _designer;

		public DesignerCraftLoader(DesignerScript designer)
		{
			_designer = designer;
		}

		public CraftScript LoadCraftImmediate(XElement craftXml, bool createUndoStep, bool centerCamera, string postLoadMessage)
		{
			CraftData craftData = Game.Instance.CraftLoader.LoadCraftImmediate(craftXml);
			return LoadCraftImmediate(craftData, craftXml, createUndoStep, centerCamera, postLoadMessage);
		}

		public CraftScript LoadCraftImmediate(CraftData craftData, XElement craftXml, bool createUndoStep, bool centerCamera, string postLoadMessage)
		{
			return LoadCraft(craftData, craftXml, createUndoStep, centerCamera, postLoadMessage);
		}

		public void LoadCraftInteractive(string craftId, bool createUndoStep, bool centerCamera, string postLoadMessage, Action<CraftScript> successCallback, Action failureCallback)
		{
			try
			{
				XElement craftDesign = Game.Instance.CraftDesigns.GetCraftDesign(craftId);
				try
				{
					LoadCraftInteractive(craftDesign, createUndoStep, centerCamera, postLoadMessage, successCallback, failureCallback);
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

		public void LoadCraftInteractive(XElement craftXml, bool createUndoStep, bool centerCamera, string postLoadMessage, Action<CraftScript> successCallback, Action failureCallback)
		{
			Game.Instance.CraftLoader.LoadCraftInteractive(craftXml, delegate(CraftData craftData)
			{
				CraftScript craftScript = null;
				try
				{
					craftScript = LoadCraft(craftData, craftXml, createUndoStep, centerCamera, postLoadMessage);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					ShowErrorMessage("An error occurred trying to load craft '" + craftData.Name + "'.", failureCallback);
					craftScript = null;
				}
				if (craftScript != null)
				{
					successCallback?.Invoke(craftScript);
				}
			}, failureCallback);
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

		private CraftScript LoadCraft(CraftData craftData, XElement craftXml, bool createUndoStep, bool centerCamera, string postLoadMessage)
		{
			CraftScript craftScript = null;
			try
			{
				craftScript = new CraftBuilder(craftData).BuildCraft(createRigidBodies: false, initialLaunch: false);
			}
			catch
			{
				try
				{
					craftScript = UnityEngine.Object.FindObjectOfType<CraftScript>();
					if (craftScript != null)
					{
						UnityEngine.Object.Destroy(craftScript.gameObject);
					}
				}
				catch
				{
				}
				throw;
			}
			_designer.SetCraft(craftScript, positionAtExistingCraftPosition: false);
			XElement xElement = craftXml.Element("Symmetry");
			if (xElement != null)
			{
				Symmetry.LoadSymmetryXml(xElement, craftData.Assembly);
			}
			if (createUndoStep || _designer.UndoHistory.NumUndoSteps == 0)
			{
				_designer.CreateUndoStep();
			}
			if (!string.IsNullOrWhiteSpace(postLoadMessage))
			{
				_designer.ShowMessage(postLoadMessage);
			}
			if (centerCamera)
			{
				_designer.DesignerCamera.SetViewDirection(DesignerCameraViewDirection.Showcase);
			}
			return craftScript;
		}
	}
}
