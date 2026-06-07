using System;
using Achievements;
using UnityEngine;

public class AdvancedLogoEditorWindow : MonoBehaviour
{
	public GUIWindow Window;

	public SDFEditor MainEditor;

	public SimpleLogoEditorWindow SimpleEditor;

	[NonSerialized]
	public Action<byte[]> OnSave;

	public void Show(byte[] logo, Action<byte[]> onSave)
	{
		OnSave = onSave;
		Window.Show();
		MainEditor.LoadLogo((logo != null) ? SDFCreator.LoadSDFTree(logo) : null);
		AchievementController.SetInteraction(AchievementController.Mechanics.CustomLogos);
		TutorialSystem.Instance.StartTutorial("CustomLogos");
	}

	public void SaveAndExit()
	{
		if (MainEditor.FinalNode != null && MainEditor.FinalNode.Node.IsValid())
		{
			byte[] array = SDFCreator.SerializeTree(MainEditor.FinalNode.Node);
			GameData.SaveLogo(SDFCreator.GetTreeString(array));
			OnSave(array);
			Window.Close();
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("LogoError".Loc(), true, DialogWindow.DialogType.Error, Window);
		}
	}

	public void OpenSimple()
	{
		if (MainEditor.FinalNode == null)
		{
			SimpleEditor.Show(null, OnSave);
			Window.Close();
		}
		else if (MainEditor.FinalNode != null && MainEditor.FinalNode.Node.IsValid())
		{
			SimpleEditor.Show(SDFCreator.SerializeTree(MainEditor.FinalNode.Node), OnSave);
			if (Window.Parent != null)
			{
				SimpleEditor.Window.SetParentWindow(Window.Parent);
			}
			Window.Close();
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("LogoError".Loc(), true, DialogWindow.DialogType.Error, Window);
		}
	}
}
